using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BM_Converter
{
    public static class Gob
    {
        /// <summary>
        /// Returns true if the GOB contains the file.
        /// </summary>
        public static bool GobContainsFile(string gob, string fileName)
        {
            try
            {
                using (var gobReader = new BinaryReader(File.Open(gob, FileMode.Open)))
                {
                    var index = GetGobIndex(gobReader);
                    return index.Any(entry => entry.NameString.ToLower() == fileName.ToLower());
                }
            }
            catch
            {
                return false;
            }
        }

        public static byte[] GetFileFromGob(string gob, string fileName)
        {
            try
            {
                using (var gobReader = new BinaryReader(File.Open(gob, FileMode.Open)))
                {
                    var index = GetGobIndex(gobReader);

                    var fileIndexEntry = index.FirstOrDefault(i => i.NameString?.ToLower() == fileName.ToLower());
                    if (fileIndexEntry == null)
                    {
                        return Array.Empty<byte>();
                    }

                    gobReader.BaseStream.Seek(fileIndexEntry.Address, SeekOrigin.Begin);
                    return gobReader.ReadBytes(fileIndexEntry.Length);
                }
            }
            catch
            {
                MessageBox.Show("Error reading file from GOB.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Array.Empty<byte>();
            }
        }

        private static List<GobIndexEntry> GetGobIndex(BinaryReader gobReader)
        {
            var gobMagic = gobReader.ReadBytes(4);
            var indexOffset = gobReader.ReadInt32();

            gobReader.BaseStream.Seek(indexOffset, SeekOrigin.Begin);
            var numFiles = gobReader.ReadInt32();

            var index = new List<GobIndexEntry>();
            for (int f = 0; f < numFiles; f++)
            {
                var entry = new GobIndexEntry();
                entry.Address = gobReader.ReadInt32();
                entry.Length = gobReader.ReadInt32();
                entry.Name = gobReader.ReadBytes(13);
                entry.NameString = ConvertBytesToNameString(entry.Name);

                index.Add(entry);
            }

            return index;
        }

        private static string ConvertBytesToNameString(byte[] bytes)
        {
            var result = string.Empty;
            for (int i = 0; i < 13; i++)
            {
                if (bytes[i] == 0)
                {
                    break;
                }

                result += (char)bytes[i];
            }

            return result.ToString();
        }
    }

    public class GobIndexEntry
    {
        public int Address { get; set; }

        public int Length { get; set; }

        public byte[] Name { get; set; }

        public string? NameString { get; set; }

        public GobIndexEntry()
        {
            this.Name = new byte[13];
        }
    }
}
