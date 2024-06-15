using System;
using System.IO;
using System.Windows.Forms;

namespace BM_Converter
{
    public class DFCmp
    {
        public byte[,] Colourmap = new byte[32, 256];

        public bool LoadFromFile(string filename)
        {
            try
            {
                FileInfo cmpFile = new FileInfo(filename);
                if (!File.Exists(filename) || cmpFile.Length != 8320)
                {
                    MessageBox.Show("CMP file does not appear valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                
                using (var cmpReader = new BinaryReader(cmpFile.Open(FileMode.Open, FileAccess.Read)))
                { 
                    for (int light = 0; light < 32; light++)
                    {
                        for (int colour = 0; colour < 256; colour++)
                        {
                            this.Colourmap[light, colour] = cmpReader.ReadByte();
                        }
                    }
                }

                return true;
            }
            catch
            {
                MessageBox.Show("Error loading CMP file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
