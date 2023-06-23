using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BM_Converter
{
    public partial class Form2 : Form
    {
        private List<Bitmap> SourceImages;
        private DFPal palette;

        public Form2()
        {
            InitializeComponent();

            this.SourceImages = new List<Bitmap>();
            this.palette = new DFPal();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBoxTransparentColour.SelectedIndex = 0;
            radioBtnSingleBM.Checked = true;
            radioBtnOpaque.Checked = true;
            comboBoxTransparentColour.Enabled = false;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure you want to leave? You will lose any work you have done.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (answer == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnLoadPal_Click(object sender, EventArgs e)
        {
            openPALDialog.ShowDialog();
        }

        private void openPALDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (palette.LoadfromFile(openPALDialog.FileName))
            {
                labelPal.Text = $"PAL: {Path.GetFileName(openPALDialog.FileName)}";
                btnCreateBM.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error. May not have been a valid PAL file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxIncludeIlluminated_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIncludeIlluminated.Checked)
            {
                MessageBox.Show("Glow-in-dark colours (1-31) will be included when performing colour matching.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkBoxCommonColours_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCommonColours.Checked)
            {
                MessageBox.Show("Only common PAL colours (excluding 208-254) will be used for colour matching. This makes your texture suitable for use with all PALs.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // BM Options --------------------------------------------------------------------------------------------------------

        private void radioBtnSingleBM_Click(object sender, EventArgs e)
        {
            //if (SourceImages.Count > 1)
            //{
            //    MessageBox.Show("You have added multiple images!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    radioBtnMultiBM.Checked = true;
            //}
        }

        private void radioBtnSingleBM_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxCompressed.Enabled = true;
            numericFramerate.Enabled = false;
            radioBtnWeapon.Enabled = true;
        }

        private void radioBtnMultiBM_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxCompressed.Enabled = false;
            checkBoxCompressed.Checked = false;
            numericFramerate.Enabled = true;
            numericFramerate.Value = 0;
            radioBtnOpaque.Checked = true;
            radioBtnWeapon.Enabled = false;
        }

        private void radioBtnOpaque_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxTransparentColour.Enabled = !radioBtnOpaque.Checked;
            
            if (radioBtnOpaque.Checked)
            {
                comboBoxTransparentColour.SelectedIndex = 0;
            }
        }

        // Add & remove image ------------------------------------------------------------------------------------
        private void btnAddImage_Click(object sender, EventArgs e)
        {
            LoadImageDialog.ShowDialog();
        }

        private void LoadImageDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Bitmap newImage;
            
            try
            {
                newImage = new Bitmap(LoadImageDialog.FileName);
                bool proceed = false;

                // Check image wd&ht is power of 2
                if (!MiscFunctions.IsPowerOfTwo(newImage.Width) || !MiscFunctions.IsPowerOfTwo(newImage.Height))
                {
                    var answer = MessageBox.Show("Your image width or height is not a power of 2. This is only allowed for weapon textures. Continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (answer == DialogResult.Yes)
                    {
                        proceed = true;
                    }
                }
                else
                {
                    proceed = true;
                }

                if (proceed)
                {
                    SourceImages.Add(newImage);
                    listBoxImages.Items.Add(Path.GetFileName(LoadImageDialog.FileName));
                    listBoxImages.SelectedIndex = listBoxImages.Items.Count - 1;
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Error loading image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void listBoxImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxImages.SelectedIndex >= 0)
            {
                displayBox.Image = SourceImages[listBoxImages.SelectedIndex];
            }
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            int idx = listBoxImages.SelectedIndex;

            if (SourceImages.Count > 0 && idx >= 0)
            {
                SourceImages.RemoveAt(idx);
                listBoxImages.Items.RemoveAt(idx);
                displayBox.Image = null;

                if (SourceImages.Count > 0 && idx > 0)
                {
                    listBoxImages.SelectedIndex = idx - 1;
                }
            }
        }

        // Create BM ------------------------------------------------------------------------
        private void btnCreateBM_Click(object sender, EventArgs e)
        {
            if (SourceImages.Count > 0)
            {
                var fn = Path.GetFileNameWithoutExtension((string)listBoxImages.Items[0]);
                saveBMDialog.FileName = fn;
                saveBMDialog.ShowDialog();
            }
            
        }

        private void saveBMDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // pass transparency info as a char
            char transparency = 'o';    // default
            if (radioBtnTransparent.Checked)
            {
                transparency = 't';
            } 
            else if (radioBtnWeapon.Checked)
            {
                transparency = 'w';
            }

            string transparentColour;
            switch (comboBoxTransparentColour.SelectedIndex)
            {
                case 1:
                    transparentColour = "alpha0";
                    break;

                case 2:
                    transparentColour = "alpha127";
                    break;

                default:
                    transparentColour = "black";
                    break;
            }

            // New feature - Bulk convert single BMs
            if (!radioBtnMultiBM.Checked && this.SourceImages.Count > 1)
            {
                // Bulk convert!
                for (int i = 0; i < this.SourceImages.Count; i++)
                {
                    var dir = Path.GetDirectoryName(saveBMDialog.FileName);
                    var filename = Path.GetFileNameWithoutExtension((string)listBoxImages.Items[i]);
                    var source = new List<Bitmap>() { this.SourceImages[i] };

                    var BM = MiscFunctions.BuildBM(false, this.palette, source, transparency, transparentColour, (byte)numericFramerate.Value, checkBoxIncludeIlluminated.Checked, checkBoxCommonColours.Checked, checkBoxCompressed.Checked);
                    BM.SaveToFile($"{dir}\\{filename}.bm");
                }

                return;
            }

            DFBM newBM = MiscFunctions.BuildBM(radioBtnMultiBM.Checked, palette, SourceImages, transparency, transparentColour, (byte) numericFramerate.Value, checkBoxIncludeIlluminated.Checked, checkBoxCommonColours.Checked, checkBoxCompressed.Checked);

            if (newBM.SaveToFile(saveBMDialog.FileName))
            {
                MessageBox.Show("Successfully saved BM file!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error saving BM file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
