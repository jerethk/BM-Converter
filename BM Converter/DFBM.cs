using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using BM_Converter.Types;

namespace BM_Converter
{
    public class DFBM
    {
        public byte[] FileId { get; set; }      // header
        public ushort SizeX { get; set; }
        public ushort SizeY { get; set; }
        public ushort UvWidth { get; set; }
        public ushort UvHeight { get; set; }
        public byte Transparency { get; set; }
        public byte logSizeY { get; set; }
        public short Compressed { get; set; }
        public int DataSize { get; set; }
        public byte[] pad { get; set; }

        public byte[] CompressedData { get; set; }      // data for single BM
        public int [] ColumnStarts { get; set; }
        public byte[,] PixelData { get; set; }

        public byte FrameRate { get; set; }     // fields for multi BMs
        public byte SecondByte { get; set; }
        public int[] Offsets { get; set; }
        public List<SubBM> SubBMs { get; set; }

        // custom fields for convenience, not used in an actual BM file
        public bool IsMultiBM { get; set; }
        private int fileLength;
        public int NumImages { get; set; }


        // Constructor        
        public DFBM()
        {
            FileId = new byte[4] { 0x42, 0x4d, 0x20, 0x1e };
            pad = new byte[12];
        }

        public bool LoadFromFile(string FileName)
        {
            bool result = false;

            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open)))
                {
                    this.FileId = reader.ReadBytes(4);

                    if (FileId[0] != 0x42 || FileId[1] != 0x4d || FileId[2] != 0x20 || FileId[3] != 0x1e)
                    {
                        // Not a valid BM file
                        result = false;
                    }
                    else
                    {
                        this.SizeX = reader.ReadUInt16();
                        this.SizeY = reader.ReadUInt16();
                        this.UvWidth = reader.ReadUInt16();
                        this.UvHeight = reader.ReadUInt16();
                        this.Transparency = reader.ReadByte();
                        this.logSizeY = reader.ReadByte();
                        this.Compressed = reader.ReadInt16();
                        this.DataSize = reader.ReadInt32();
                        this.pad = reader.ReadBytes(12);

                        this.IsMultiBM = false;
                        this.NumImages = 1;

                        if (this.SizeX == 1 && this.SizeY > 1)
                        {
                            // multi BM !
                            this.IsMultiBM = true;
                            this.NumImages = this.UvHeight;
                            this.fileLength = this.SizeY + 32;

                            this.FrameRate = reader.ReadByte();
                            this.SecondByte = reader.ReadByte();

                            this.Offsets = new int[this.NumImages];
                            for (int i = 0; i < this.NumImages; i++)
                            {
                                this.Offsets[i] = reader.ReadInt32();
                            }

                            this.SubBMs = new List<SubBM>();
                            for (int i = 0; i < this.NumImages; i++)
                            {
                                SubBM newSubBM = new SubBM();
                                newSubBM.SizeX = reader.ReadInt16();
                                newSubBM.SizeY = reader.ReadInt16();
                                newSubBM.idemX = reader.ReadInt16();
                                newSubBM.idemY = reader.ReadInt16();
                                newSubBM.DataSize = reader.ReadInt32();
                                newSubBM.logSizeY = reader.ReadByte();
                                newSubBM.pad1 = reader.ReadBytes(3);
                                newSubBM.u1 = reader.ReadBytes(3);
                                newSubBM.pad2 = reader.ReadBytes(5);
                                newSubBM.Transparency = reader.ReadByte();
                                newSubBM.pad3 = reader.ReadBytes(3);

                                newSubBM.PixelData = new byte[newSubBM.SizeX, newSubBM.SizeY];
                                for (int x = 0; x < newSubBM.SizeX; x++)
                                {
                                    for (int y = 0; y < newSubBM.SizeY; y++)
                                    {
                                        newSubBM.PixelData[x, y] = reader.ReadByte();
                                    }
                                }

                                this.SubBMs.Add(newSubBM);
                            }

                        }
                        else
                        {
                            // single BM
                            this.PixelData = new byte[this.SizeX, this.SizeY];

                            if (this.Compressed == 0)
                            {
                                // Uncompressed BM
                                for (int x = 0; x < this.SizeX; x++)
                                {
                                    for (int y = 0; y < this.SizeY; y++)
                                    {
                                        this.PixelData[x, y] = reader.ReadByte();
                                    }
                                }
                            }
                            else
                            {
                                // read Compressed data
                                this.CompressedData = new byte[this.DataSize];
                                this.CompressedData = reader.ReadBytes(this.DataSize);

                                this.ColumnStarts = new int[this.SizeX];
                                for (int x = 0; x < this.SizeX; x++)
                                {
                                    this.ColumnStarts[x] = reader.ReadInt32();
                                }
                            }

                            if (this.Compressed == 1)
                            {
                                UncompressRLE();
                            }
                            else if (this.Compressed == 2)
                            {
                                UncompressRLE0();
                            }
                        }

                        result = true;
                    }
                }
            }
            catch (IOException)
            {
                result = false;
            }

            return result;
        }

        // Static method to convert a BM image into a Bitmap object
        public static Bitmap BMtoBitmap(int SizeX, int SizeY, byte[,] PixelData, DFPal pal, bool isTransparentBM)
        {
            Bitmap bitmap = new Bitmap(SizeX, SizeY);
            
            for (int x = 0; x < SizeX; x++)
            {
                for (int y = 0; y < SizeY; y++)
                {
                    Color colour;
                    if (isTransparentBM && PixelData[x, y] == 0)   // transparent
                    {
                        colour = Color.FromArgb(0, 0, 0, 0);
                    }
                    else
                    {
                        int R = pal.Colours[PixelData[x, y]].R;
                        int G = pal.Colours[PixelData[x, y]].G;
                        int B = pal.Colours[PixelData[x, y]].B;

                        colour = Color.FromArgb(255, R, G, B);
                    }

                    bitmap.SetPixel(x, y, colour);
                }
            }

            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);  // need to flip because BMs are defined bottom-up
            return bitmap;
        }

        // Static method to convert a Bitmap object into a BM image
        public static byte[,] BitmaptoBM(Bitmap bitmap, DFPal pal, PaletteOptions palOptions, TransparentColour transparentColour)
        {
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

            var PixelArray = new byte[bitmap.Width, bitmap.Height];

            // current options for transparent colour are black (RGB 0,0,0) and alpha 0
            Func<Color, bool> isTransparentColour;
            switch (transparentColour)
            {
                case TransparentColour.Black:
                    isTransparentColour = colour => colour.R == 0 && colour.G == 0 && colour.B == 0;
                    break;

                case TransparentColour.Alpha0:
                    isTransparentColour = colour => colour.A == 0;
                    break;

                case TransparentColour.Alpha127:
                    isTransparentColour = colour => colour.A < 128;
                    break;

                default:
                    isTransparentColour = colour => false;
                    break;
            }
            
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color pixelColour = bitmap.GetPixel(x, y);
                    byte palIndex;

                    if (isTransparentColour(pixelColour))
                    {
                        palIndex = 0;
                    }
                    else
                    {
                        palIndex = MiscFunctions.MatchPixeltoPal(pixelColour, pal, palOptions);
                    }

                    PixelArray[x, y] = palIndex;
                }

            }

            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY); 
            return PixelArray;
        }

        public bool SaveToFile(string filename)
        {
            bool success = false;

            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
                {
                    // write BM header
                    foreach (byte b in this.FileId) writer.Write(b);
                    writer.Write(this.SizeX);
                    writer.Write(this.SizeY);
                    writer.Write(this.UvWidth);
                    writer.Write(this.UvHeight);
                    writer.Write(this.Transparency);
                    writer.Write(this.logSizeY);
                    writer.Write(this.Compressed);
                    writer.Write(this.DataSize);
                    foreach (byte b in this.pad) writer.Write(b);

                    if (!this.IsMultiBM)
                    {
                        // single BM image

                        if (this.Compressed == 0)
                        {
                            // uncompressed BM
                            for (int x = 0; x < this.SizeX; x++)
                            {
                                for (int y = 0; y < this.SizeY; y++)
                                {
                                    writer.Write(this.PixelData[x, y]);
                                }
                            }
                        }
                        else if (this.Compressed == 1 || this.Compressed == 2)
                        {
                            // compressed BM
                            writer.Write(this.CompressedData);
                            foreach (int i in this.ColumnStarts) writer.Write(i);
                        }
                    }
                    else
                    {
                        // multi BM
                        writer.Write(this.FrameRate);
                        writer.Write(this.SecondByte);
                        foreach (int i in this.Offsets) writer.Write(i);

                        foreach (SubBM sub in this.SubBMs)
                        {
                            //Sub BM header
                            writer.Write(sub.SizeX);
                            writer.Write(sub.SizeY);
                            writer.Write(sub.idemX);
                            writer.Write(sub.idemY);
                            writer.Write(sub.DataSize);
                            writer.Write(sub.logSizeY);
                            foreach (byte b in sub.pad1) writer.Write(b);
                            foreach (byte b in sub.u1) writer.Write(b);
                            foreach (byte b in sub.pad2) writer.Write(b);
                            writer.Write(sub.Transparency);
                            foreach (byte b in sub.pad3) writer.Write(b);

                            //Sub BM image
                            for (int x = 0; x < sub.SizeX; x++)
                            {
                                for (int y = 0; y < sub.SizeY; y++)
                                {
                                    writer.Write(sub.PixelData[x, y]);
                                }
                            }
                        }
                    }
                }

                success = true;
            }
            catch (IOException)
            {
                success = false;
            }

            return success;
        }

        public bool IsTransparentOrWeapon()
        {
            return this.Transparency == 0x3E || this.Transparency == 0x08;
        }

        // Uncompress image encoded with RLE method (header.compressed == 1)
        private void UncompressRLE()
        {
            int dataPosition = 0;

            for (int x = 0; x < this.SizeX; x++)
            {
                int y = 0;
                while (y < this.SizeY)
                {
                    int numPixels;
                    byte b = this.CompressedData[dataPosition];

                    if (b < 128)
                    {
                        numPixels = b;
                        dataPosition++;

                        for (int i = 0; i < numPixels; i++)
                        {
                            this.PixelData[x, y] = this.CompressedData[dataPosition];
                            y++;
                            dataPosition++;
                        }
                    }
                    else
                    {
                        // run of same coloured pixels
                        numPixels = b - 128;
                        dataPosition++;
                        byte colour = this.CompressedData[dataPosition];

                        for (int i = 0; i < numPixels; i++)
                        {
                            this.PixelData[x, y] = colour;
                            y++;
                        }

                        dataPosition++;
                    }
                }
            }
        }

        // Uncompress image encoded with RLE0 method (header.compressed == 2)
        private void UncompressRLE0()
        {
            int dataPosition = 0;

            for (int x = 0; x < this.SizeX; x++)
            {
                int y = 0;
                while (y < this.SizeY)
                {
                    int numPixels;
                    byte b = this.CompressedData[dataPosition];

                    if (b >= 128)    // transparent section
                    {
                        numPixels = b - 128;
                        for (int i = 0; i < numPixels; i++)
                        {
                            this.PixelData[x, y] = 0;  // transparency = palette index 0
                            y++;
                        }

                        dataPosition++;
                    }
                    else            // non-transparent section
                    {
                        numPixels = b;
                        dataPosition++;
                        for (int i = 0; i < numPixels; i++)
                        {
                            this.PixelData[x, y] = CompressedData[dataPosition];
                            y++;
                            dataPosition++;
                        }
                    }
                }

            }
        }

        // compress BM image by RLE method.
        public void CompressRLE()
        {
            List<byte>[] compressedColumns = new List<byte>[this.SizeX];
            
            for (int x = 0; x < this.SizeX; x++)    // compress each column of the image
            {
                List<byte> thisColumn = new List<byte>();

                int y = 0;
                while (y < this.SizeY)
                {
                    // note: because of the way data is encoded, cannot do a run of more than 127 pixels
                    byte counter;

                    if (y <= this.SizeY - 2 && this.PixelData[x, y] == this.PixelData [x, y+1])    // same colour run
                    {
                        byte colour = this.PixelData[x, y]; 
                        counter = 1;

                        while (y < this.SizeY - 1 && this.PixelData[x, y+1] == colour && counter < 127)
                        {
                            y++;
                            counter++;
                        }

                        // write run of same colour
                        thisColumn.Add((byte)(128 + counter));
                        thisColumn.Add(colour);

                        y += 1;
                    }
                    else                        // run of different colours
                    {
                        int startOfRun = y;
                        counter = 1;

                        while (y < this.SizeY - 1 && this.PixelData[x, y+1] != this.PixelData[x, y] && counter < 127)
                        {
                            y++;
                            counter++;
                        }

                        thisColumn.Add(counter);    // number of non-transparent pixels

                        // go back to start of run and add the pixels
                        y = startOfRun;
                        for (int i = 0; i < counter; i++)
                        {
                            thisColumn.Add((byte)this.PixelData[x, y]);
                            y++;
                        }
                    }
                }

                compressedColumns[x] = thisColumn;
            }

            AssembleCompressedData(compressedColumns);
        }

        // compress BM image by RLE0 method (transparency)
        public void CompressRLE0()
        {
            List<byte>[] compressedColumns = new List<byte>[this.SizeX];

            for (int x = 0; x < this.SizeX; x++)    // compress each column of the image
            {
                List<byte> thisColumn = new List<byte>();

                int y = 0;
                while (y < this.SizeY)
                {
                    // note: because of the way data is encoded, cannot do a run of more than 127 pixels
                    byte counter;

                    if (this.PixelData[x, y] == 0)    // transparent run
                    {
                        counter = 1;

                        while (y < this.SizeY - 1 && this.PixelData[x, y + 1] == 0 && counter < 127)
                        {
                            y++;
                            counter++;
                        }

                        // write run of transparent pixels
                        thisColumn.Add((byte)(128 + counter));

                        y += 1;
                    }
                    else                        // non-transparent run
                    {
                        int startOfRun = y;
                        counter = 1;

                        while (y < this.SizeY - 1 && this.PixelData[x, y + 1] != 0 && counter < 127)
                        {
                            y++;
                            counter++;
                        }

                        thisColumn.Add(counter);    // number of non-transparent pixels

                        // go back to start of run and add the pixels
                        y = startOfRun;
                        for (int i = 0; i < counter; i++)
                        {
                            thisColumn.Add((byte)this.PixelData[x, y]);
                            y++;
                        }
                    }
                }

                compressedColumns[x] = thisColumn;
            }

            AssembleCompressedData(compressedColumns);
        }

        // Assembles compressed columns into a single array of bytes (CompressedData) and creates the table of ColumnStarts
        private void AssembleCompressedData(List<byte>[] compressedColumns)
        {
            // Calculate DataSize
            this.DataSize = 0;
            foreach (List<byte> column in compressedColumns) this.DataSize += column.Count;

            this.ColumnStarts = new int[this.SizeX];
            this.CompressedData = new byte[this.DataSize];

            int position = 0;
            for (int x = 0; x < this.SizeX; x++)
            {
                this.ColumnStarts[x] = position;
                compressedColumns[x].CopyTo(this.CompressedData, position);
                position += compressedColumns[x].Count;
            }
        }
    }

    public class SubBM
    {
        public short SizeX { get; set; }
        public short SizeY { get; set; }
        public short idemX { get; set; }
        public short idemY { get; set; }
        public int DataSize { get; set; }
        public byte logSizeY { get; set; }
        public byte[] pad1 { get; set; }
        public byte[] u1 { get; set; }
        public byte[] pad2 { get; set; }
        public byte Transparency { get; set; }
        public byte[] pad3 { get; set; }
        public byte[,] PixelData { get; set; }

        public SubBM()
        {
            pad1 = new byte[3];
            u1 = new byte[3];
            pad2 = new byte[5];
            pad3 = new byte[3];
        }

        public bool IsTransparent()
        {
            return this.Transparency == 0x3E || this.Transparency == 0x08;
        }
    }
}
