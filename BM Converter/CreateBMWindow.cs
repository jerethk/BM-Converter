using BM_Converter.Types;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BM_Converter
{
    public partial class CreateBMWindow : Form
    {
        private List<Bitmap> SourceImages;
        private DFPal palette;
        private string palPath;
        private string loadPath;
        private string savePath;

        public CreateBMWindow()
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

        private void CreateBMWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.SourceImages.ForEach(b => b.Dispose());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Pal

        private void btnLoadPal_Click(object sender, EventArgs e)
        {
            openPALDialog.InitialDirectory = this.palPath ?? openPALDialog.InitialDirectory;
            openPALDialog.ShowDialog();
        }

        private void openPALDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (palette.LoadfromFile(openPALDialog.FileName))
            {
                labelPal.Text = $"PAL: {Path.GetFileName(openPALDialog.FileName)}";
                btnCreateBM.Enabled = true;
                this.palPath = Path.GetDirectoryName(openPALDialog.FileName);
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

        #endregion

        #region BM options

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
            groupUv.Enabled = this.SourceImages.Count == 1;
            groupUv.Visible = this.SourceImages.Count == 1;

        }

        private void radioBtnMultiBM_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxCompressed.Enabled = false;
            checkBoxCompressed.Checked = false;
            numericFramerate.Enabled = true;
            numericFramerate.Value = 0;
            radioBtnOpaque.Checked = true;
            radioBtnWeapon.Enabled = false;
            groupUv.Enabled = false;
            groupUv.Visible = false;
        }

        private void radioBtnOpaque_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxTransparentColour.Enabled = !radioBtnOpaque.Checked;

            if (radioBtnOpaque.Checked)
            {
                comboBoxTransparentColour.SelectedIndex = 0;
            }
        }

        private void btnPreviewUv_Click(object sender, EventArgs e)
        {
            if (listBoxImages.SelectedIndex < 0 || SourceImages[listBoxImages.SelectedIndex] == null)
            {
                return;
            }
            
            var uvPreviewWindow = new UvPreviewWindow(
                (int)this.numericUvWidth.Value,
                (int)this.numericUvHeight.Value,
                SourceImages[listBoxImages.SelectedIndex]);
            uvPreviewWindow.ShowDialog();

            this.numericUvWidth.Value = uvPreviewWindow.FinalValues.uvWidth;
            this.numericUvHeight.Value = uvPreviewWindow.FinalValues.uvHeight;
            uvPreviewWindow.Dispose();
        }

        #endregion

        #region Add and remove images

        // Add & remove image ------------------------------------------------------------------------------------
        private void btnAddImage_Click(object sender, EventArgs e)
        {
            LoadImageDialog.InitialDirectory = this.loadPath ?? LoadImageDialog.InitialDirectory;
            LoadImageDialog.ShowDialog();
        }

        private void LoadImageDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var failedImages = 0;
            this.loadPath = Path.GetDirectoryName(LoadImageDialog.FileName);

            foreach (var imgFile in LoadImageDialog.FileNames)
            {
                try
                {
                    var newImage = Image.FromFile(imgFile);
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
                        SourceImages.Add(new Bitmap(newImage));
                        newImage.Dispose();
                        listBoxImages.Items.Add(Path.GetFileName(imgFile));
                        listBoxImages.SelectedIndex = listBoxImages.Items.Count - 1;
                    }
                }
                catch (Exception)
                {
                    failedImages++;
                }
            }

            if (failedImages > 0)
            {
                MessageBox.Show($"{failedImages} images failed to load.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // If there is only 1 source image, set the UV dimensions to the image dimensions
            this.groupUv.Enabled = this.SourceImages.Count == 1 && this.radioBtnSingleBM.Checked;
            this.groupUv.Visible = this.SourceImages.Count == 1 && this.radioBtnSingleBM.Checked;
            if (this.SourceImages.Count == 1)
            {
                this.numericUvWidth.Value = this.SourceImages[0].Width;
                this.numericUvHeight.Value = this.SourceImages[0].Height;
            }
        }

        private void listBoxImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxImages.SelectedIndex >= 0)
            {
                var img = SourceImages[listBoxImages.SelectedIndex];
                this.displayBox.Image = img;
                this.labelImageSize.Text = $"Image size {img.Width} x {img.Height}";
            }
            else
            {
                this.labelImageSize.Text = $"Image size";
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

                this.groupUv.Enabled = this.SourceImages.Count == 1 && this.radioBtnSingleBM.Checked;
                this.groupUv.Visible = this.SourceImages.Count == 1 && this.radioBtnSingleBM.Checked;
            }
        }

        #endregion

        #region Create BM

        // Create BM ------------------------------------------------------------------------
        private void btnCreateBM_Click(object sender, EventArgs e)
        {
            if (this.SourceImages.Count > 1 && radioBtnSingleBM.Checked)
            {
                var response = MessageBox.Show("You have added multiple images. They will each be converted into a BM. Confirm?", "Multiple images", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (response == DialogResult.Cancel)
                {
                    return;
                }
            }

            if (SourceImages.Count > 0)
            {
                var fn = Path.GetFileNameWithoutExtension((string)listBoxImages.Items[0]);
                saveBMDialog.InitialDirectory = this.savePath ?? saveBMDialog.InitialDirectory;
                saveBMDialog.FileName = fn;
                saveBMDialog.ShowDialog();
            }
        }

        private void saveBMDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // pass transparency info as a char
            char transparency;
            if (radioBtnTransparent.Checked)
            {
                transparency = TransparencyOptions.Transparent;
            }
            else if (radioBtnWeapon.Checked)
            {
                transparency = TransparencyOptions.Weapon;
            }
            else
            {
                transparency = TransparencyOptions.Opaque;
            }

            TransparentColour transparentColour;
            switch (comboBoxTransparentColour.SelectedIndex)
            {
                case 1:
                    transparentColour = TransparentColour.Alpha0;
                    break;

                case 2:
                    transparentColour = TransparentColour.Alpha127;
                    break;

                default:
                    transparentColour = TransparentColour.Black;
                    break;
            }

            var palOptions = new PaletteOptions()
            {
                includeFullbrights = checkBoxIncludeIlluminated.Checked,
                commonColoursOnly = checkBoxCommonColours.Checked,
            };

            // Bulk convert single BMs
            if (!radioBtnMultiBM.Checked && this.SourceImages.Count > 1)
            {
                var failed = 0;

                for (int i = 0; i < this.SourceImages.Count; i++)
                {
                    var dir = Path.GetDirectoryName(saveBMDialog.FileName);
                    var filename = Path.GetFileNameWithoutExtension((string)listBoxImages.Items[i]);
                    var source = new List<Bitmap>() { this.SourceImages[i] };

                    var BM = MiscFunctions.BuildBM(false, this.palette, source, transparency, transparentColour, (byte)numericFramerate.Value, palOptions, checkBoxCompressed.Checked);

                    if (!BM.SaveToFile($"{dir}\\{filename}.bm"))
                    {
                        failed++;
                    }
                }

                if (failed > 0)
                {
                    MessageBox.Show("One or more BMs failed to successfully save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }

            DFBM newBM = MiscFunctions.BuildBM(radioBtnMultiBM.Checked, palette, SourceImages, transparency, transparentColour, (byte)numericFramerate.Value, palOptions, checkBoxCompressed.Checked, ((int)this.numericUvWidth.Value, (int)this.numericUvHeight.Value));

            if (newBM.SaveToFile(saveBMDialog.FileName))
            {
                MessageBox.Show("Successfully saved BM file!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error saving BM file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.savePath = Path.GetDirectoryName(saveBMDialog.FileName);
        }

        #endregion
    }
}
