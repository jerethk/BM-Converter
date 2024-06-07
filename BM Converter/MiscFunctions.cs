using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BM_Converter
{
    static class MiscFunctions
    {
        public static bool IsPowerOfTwo(int number)
        {
            double log = Math.Log2(number);
            double remainder = log % 1;
            return remainder == 0 ? true : false;
        }
        
        // Builds a BM object from source images
        public static DFBM BuildBM(bool multiBM, DFPal pal, List<Bitmap> SourceImages, char transparency, string transparentColour, byte FRate, bool includeIlluminated, bool commonColoursOnly, bool compress)
        {
            DFBM newBM = new DFBM();

            byte trn;
            switch (transparency)
            {
                case 'o':
                    trn = 0x36;
                    break;
                case 't':
                    trn = 0x3E;
                    break;
                case 'w':
                    trn = 0x08;
                    break;
                default:
                    trn = 0x36;
                    break;
            }

            if (!multiBM)
            {
                // Single BM
                newBM.IsMultiBM = false;
                Bitmap source = SourceImages[0];

                // Create BM header. The FileID is automatically created by the object constructor
                newBM.SizeX = (ushort)source.Width;
                newBM.SizeY = (ushort)source.Height;
                newBM.idemX = newBM.SizeX;
                newBM.idemY = newBM.SizeY;
                newBM.transparent = trn;                

                if (IsPowerOfTwo(newBM.SizeY))
                {
                    newBM.logSizeY = (byte)Math.Log2(newBM.SizeY);
                }
                else
                {
                    // presumably a weapon so the value is set to 0
                    newBM.logSizeY = 0;
                }

                // Create BM image data
                newBM.PixelData = DFBM.BitmaptoBM(source, pal, includeIlluminated, commonColoursOnly, transparentColour);

                if (compress)
                {
                    if (transparency == 'o')
                    {
                        newBM.compressed = 1;   // RLE compression for non-transparent texture
                        newBM.CompressRLE();
                    }
                    else
                    {
                        newBM.compressed = 2;   // RLE0 compression for transparent texture
                        newBM.CompressRLE0();
                    }
                }
                else
                {
                    newBM.compressed = 0;
                    newBM.DataSize = newBM.SizeX * newBM.SizeY;
                }

            }
            else
            {
                // Multi BM
                newBM.IsMultiBM = true;
                newBM.NumImages = SourceImages.Count;
                
                newBM.SizeX = 1;
                newBM.idemX = 0xfffe;
                newBM.idemY = (ushort)newBM.NumImages;
                newBM.transparent = trn;
                newBM.compressed = 0;
                newBM.DataSize = 0;
                newBM.FrameRate = FRate;
                newBM.SecondByte = 2;

                newBM.Offsets = new int[newBM.NumImages];
                newBM.SubBMs = new List<SubBM>();

                for (int i = 0; i < newBM.NumImages; i++)
                {
                    SubBM newSubBM = new SubBM();
                    newSubBM.SizeX = (short)SourceImages[i].Width;
                    newSubBM.SizeY = (short)SourceImages[i].Height;
                    newSubBM.idemX = newSubBM.SizeX;
                    newSubBM.idemY = newSubBM.SizeY;
                    newSubBM.DataSize = newSubBM.SizeX * newSubBM.SizeY;
                    newSubBM.transparent = trn;

                    if (IsPowerOfTwo (newSubBM.SizeY))
                    {
                        newSubBM.logSizeY = (byte)Math.Log2(newSubBM.SizeY);
                    }
                    else
                    {
                        newSubBM.logSizeY = 0;
                    }

                    newSubBM.PixelData = DFBM.BitmaptoBM(SourceImages[i], pal, includeIlluminated, commonColoursOnly, transparentColour);
                    newBM.SubBMs.Add(newSubBM);
                }

                newBM.logSizeY = newBM.SubBMs[0].logSizeY;  // sub BMs should all be the same size

                // calculate the "sizeY" value, which in a multi BM is the length of the entire file minus the header (32 bytes). Also work out the sub BM offsets.
                int counter = (2 + 4 * newBM.NumImages);    // the 2 bytes following the header + the table of offsets
                for (int i=0; i < newBM.NumImages; i++)
                {
                    newBM.Offsets[i] = counter - 2;
                    counter += 28;  // len of sub BM header = 28
                    counter += newBM.SubBMs[i].DataSize;
                }
                // TODO need to throw error when counter is > 0xffff !!!
                newBM.SizeY = (ushort)counter;
            }

            return newBM;
        }

        // Color matches to the PAL using Euclidean distance technique
        public static byte MatchPixeltoPal(Color pixelColour, DFPal palette, bool includeIlluminatedColours, bool commonColoursOnly)
        {
            int sourceRed = pixelColour.R;
            int sourceGreen = pixelColour.G;
            int sourceBlue = pixelColour.B;

            int startColour;
            if (includeIlluminatedColours)
            {
                startColour = 1;        // first 32 colours are always bright / illuminated
            }
            else
            {
                startColour = 32;
            }

            double smallestDistance = 500;
            int bestMatch = 0;

            for (int i = startColour; i <= 255; i++)
            {
                if (commonColoursOnly && i >= 208 && i <= 254) continue;    // colours 208-254 are different in different PALs

                int deltaRed = sourceRed - palette.Colours[i].R;
                int deltaGreen = sourceGreen - palette.Colours[i].G;
                int deltaBlue = sourceBlue - palette.Colours[i].B;
                double distance = Math.Sqrt(deltaRed * deltaRed + deltaGreen * deltaGreen + deltaBlue * deltaBlue);

                if (distance < smallestDistance)
                {
                    smallestDistance = distance;
                    bestMatch = i;
                }
            }

            return (byte)bestMatch;
        }

        public static byte[] LoadRawFile(string path)
        {
            var fileSize = (int)new FileInfo(path).Length;
            var fileBytes = new byte[fileSize];

            try
            {
                using (var fileReader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    fileBytes = fileReader.ReadBytes(fileSize);
                }
            }
            catch
            {
                MessageBox.Show("Error reading RAW file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return fileBytes;
        }
        
        /// <summary>
        /// Generates bitmaps from RAW (remaster texture) data
        /// </summary>
        /// <returns>Three bitmaps, one representing the image without alpha, one representing the alpha channel, and one combined</returns>
        public static (Bitmap noAlphaImage, Bitmap alphaImage, Bitmap combinedImage) GenerateRemasterImage(byte[] rawData, int imageWidth, int imageHeight)
        {   
            if (rawData == null)
            {
                return (null, null, null);
            }

            if (rawData.Length < imageWidth * imageHeight * 4)
            {
                return (null, null, null);
            }
            
            // Put the RAW data into an array of texels
            var imageData = new Texel[imageWidth, imageHeight];
            var texelCount = 0;
            for (var y = 0; y < imageHeight; y++)
            {
                for (var x = 0; x < imageWidth; x++)
                {
                    var txl = new Texel();
                    txl.Red = rawData[texelCount * 4];
                    txl.Green = rawData[texelCount * 4 + 1];
                    txl.Blue = rawData[texelCount * 4 + 2];
                    txl.Alpha = rawData[texelCount * 4 + 3];
                    imageData[x, y] = txl;

                    texelCount++;
                }
            }

            var noAlphaBitmap = new Bitmap(imageWidth, imageHeight);
            var alphaBitmap = new Bitmap(imageWidth, imageHeight);
            var combinedBitmap = new Bitmap(imageWidth, imageHeight);

            for (var x = 0; x < imageWidth; x++)
            {
                for (var y = 0; y < imageHeight; y++)
                {
                    var colour1 = Color.FromArgb(
                        255,
                        imageData[x, y].Red,
                        imageData[x, y].Green,
                        imageData[x, y].Blue);
                    noAlphaBitmap.SetPixel(x, y, colour1);

                    // Create the alpha bitmap in greyscale
                    var colour2 = Color.FromArgb(
                        255,
                        imageData[x, y].Alpha,
                        imageData[x, y].Alpha,
                        imageData[x, y].Alpha);
                    alphaBitmap.SetPixel(x, y, colour2);

                    var colour3 = Color.FromArgb(
                        imageData[x, y].Alpha,
                        imageData[x, y].Red,
                        imageData[x, y].Green,
                        imageData[x, y].Blue);
                    combinedBitmap.SetPixel(x, y, colour3);
                }
            }

            return (noAlphaBitmap, alphaBitmap, combinedBitmap);
        }

        public static bool WriteRawFile(string path, Bitmap img)
        {
            try
            {
                using (var fileWriter = new BinaryWriter(File.Open(path, FileMode.Create)))
                {
                    for (var y = 0; y < img.Height; y++)
                    {
                        for (var x = 0; x < img.Width; x++)
                        {
                            var red = img.GetPixel(x, y).R;
                            var green = img.GetPixel(x, y).G;
                            var blue = img.GetPixel(x, y).B;
                            var alpha = img.GetPixel(x, y).A;

                            fileWriter.Write(red);
                            fileWriter.Write(green);
                            fileWriter.Write(blue);
                            fileWriter.Write(alpha);
                        }
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
