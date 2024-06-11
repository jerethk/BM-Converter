using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BM_Converter
{
    public partial class CreateRawWindow : Form
    {
        private List<Bitmap> bmImages = new();
        private List<Bitmap> sourceDirectoryImages = new();
        private Bitmap[] highResImages;

        public CreateRawWindow(DFBM bm)
        {
            InitializeComponent();

            if (bm == null || bm.NumImages == 0)
            {
                this.openBmDialog.ShowDialog();
            }
            else
            {
                this.Setup(bm);
            }
        }

        private void openBmDialog_FileOk(object sender, CancelEventArgs e)
        {
            var bm = new DFBM();
            var successfulLoad = bm.LoadFromFile(openBmDialog.FileName);

            if (!successfulLoad)
            {
                MessageBox.Show("Error loading BM", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                this.Dispose();
            }
            else
            {
                this.Setup(bm);
            }
        }

        private void BmBuilderWindow_Shown(object sender, EventArgs e)
        {
            if (this.bmImages.Count == 0)
            {
                this.Close();
                this.Dispose();
            }
            else
            {
                this.listBoxBmImages.SelectedIndex = 0;
            }
        }

        private void Setup(DFBM bm)
        {
            if (!bm.IsMultiBM)
            {
                var newBitmap = DFBM.BMtoBitmap(bm.SizeX, bm.SizeY, bm.PixelData, new DFPal(), bm.Transparency == 0x3E || bm.Transparency == 0x08);
                this.bmImages.Add(newBitmap);
                this.listBoxBmImages.Items.Add(0);
            }
            else
            {
                for (int i = 0; i < bm.NumImages; i++)
                {
                    var newBitmap = DFBM.BMtoBitmap(bm.SubBMs[i].SizeX, bm.SubBMs[i].SizeY, bm.SubBMs[i].PixelData, new DFPal(), bm.Transparency == 0x3E || bm.Transparency == 0x08);
                    this.bmImages.Add(newBitmap);
                    this.listBoxBmImages.Items.Add(i);
                }
            }
            this.highResImages = new Bitmap[this.bmImages.Count];
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            var response = MessageBox.Show("Are you sure you want to quit? Any work will be lost.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (response == DialogResult.Yes)
            {
                this.Close();
                this.Dispose();
            }
        }

        // ---------------------------------------------------------------------------------------------------------------------

        #region SourceImages

        private void btnSourceImages_Click(object sender, EventArgs e)
        {
            this.sourceImagesDialog.ShowDialog();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The alpha channel in the source image(s) determines transparency and illumination.\n\nAlpha 0 = transparent pixel.\nAlpha 1-254 = full-bright pixel.\nAlpha 255 = ordinary pixel.", "Source Image Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void sourceImagesDialog_FileOk(object sender, CancelEventArgs e)
        {
            this.sourceDirectoryImages.Clear();
            this.listBoxSourceImages.Items.Clear();

            var sourceDirectory = Path.GetDirectoryName(sourceImagesDialog.FileName);
            var allImageFiles = Directory.GetFiles(sourceDirectory)
                .Where(f => Path.GetExtension(f).ToUpper() == ".PNG");

            foreach (var imageFile in allImageFiles)
            {
                try
                {
                    var image = Image.FromFile(imageFile);

                    // Exclude images which aren't the correct size for any of the BM's images
                    if (this.bmImages.All(bmImage => !IsCorrectSize(bmImage, image)))
                    {
                        continue;
                    }

                    this.sourceDirectoryImages.Add(new Bitmap(image));
                    this.listBoxSourceImages.Items.Add(Path.GetFileName(imageFile));
                    image.Dispose();
                }
                catch
                {
                    continue;
                }
            }
        }

        #endregion

        // ---------------------------------------------------------------------------------------------------------------------

        #region UI

        private void listBoxBmImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxBmImages.SelectedIndex >= 0 && this.bmImages.Count > listBoxBmImages.SelectedIndex)
            {
                this.pictureBoxBmImage.Image = this.bmImages[listBoxBmImages.SelectedIndex];
                this.pictureBoxHighRes.Image = this.highResImages?[listBoxBmImages.SelectedIndex] ?? null;

                this.labelBmImageSize.Text = $"Size = {this.pictureBoxBmImage.Image.Width} x {this.pictureBoxBmImage.Image.Height}";
            }
        }

        private void listBoxSourceImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxSourceImages.SelectedIndex >= 0 && this.sourceDirectoryImages.Count > listBoxSourceImages.SelectedIndex)
            {
                this.pictureBoxSourceImages.Image = this.sourceDirectoryImages[listBoxSourceImages.SelectedIndex];

                this.labelSourceImageSize.Text = $"Size = {this.pictureBoxSourceImages.Image.Width} x {this.pictureBoxSourceImages.Image.Height}";

                if (this.listBoxBmImages.SelectedIndex >= 0)
                {
                    var isCorrectSize = IsCorrectSize(this.bmImages[this.listBoxBmImages.SelectedIndex], this.sourceDirectoryImages[listBoxSourceImages.SelectedIndex]);
                    this.labelSourceImageSize.ForeColor = isCorrectSize ? Color.Green : Color.Red;
                }
            }
        }

        private void btnApplyImage_Click(object sender, EventArgs e)
        {
            if (listBoxSourceImages.SelectedIndex >= 0 && this.sourceDirectoryImages.Count > listBoxSourceImages.SelectedIndex)
            {
                var bmImage = this.bmImages[listBoxBmImages.SelectedIndex];
                var hiResImage = this.sourceDirectoryImages[listBoxSourceImages.SelectedIndex];

                if (!IsCorrectSize(bmImage, hiResImage))
                {
                    MessageBox.Show("Selected source image has incorrect dimensions", "Invalid image", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    this.highResImages[listBoxBmImages.SelectedIndex] = new Bitmap(hiResImage);
                    this.pictureBoxHighRes.Image = this.highResImages[listBoxBmImages.SelectedIndex];
                }
            }
        }

        #endregion

        // ---------------------------------------------------------------------------------------------------------------------

        private void btnCreateRaw_Click(object sender, EventArgs e)
        {
            // Run a check of the images
            for (var i = 0; i < this.bmImages.Count; i++)
            {
                var bmImage = this.bmImages[i];
                var hiresImage = this.highResImages[i];

                if (hiresImage == null || !IsCorrectSize(bmImage, hiresImage))
                {
                    MessageBox.Show("The high res images have not been properly populated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            var response = this.saveRawDialog.ShowDialog();
            if (response == DialogResult.OK)
            {
                if (MiscFunctions.WriteRawFile(this.saveRawDialog.FileName, this.highResImages.ToList()))
                {
                    MessageBox.Show("RAW successfully created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to create RAW.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static bool IsCorrectSize(Bitmap lowRes, Image highRes)
        {
            if (lowRes == null || highRes == null)
            {
                return false;
            }

            var isWidthCorrect = lowRes.Width * 2 == highRes.Width;
            var isHeightCorrect = lowRes.Height * 2 == highRes.Height;

            return isWidthCorrect && isHeightCorrect;
        }
    }
}
