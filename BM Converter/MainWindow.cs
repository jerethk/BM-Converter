using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BM_Converter
{
    public partial class MainWindow : Form
    {
        private DFPal palette;
        private DFBM BM;
        private List<Bitmap> images;
        private List<Bitmap> remasterImages;
        private List<Bitmap> remasterAlphaImages;
        private string remasterPath;
        private string palPath;
        private string bmPath;
        private string exportPath;
        private int selectedSubBM = 0;

        public MainWindow(string[] args)
        {
            InitializeComponent();

            this.palette = new DFPal();
            this.BM = new DFBM();
            this.images = new List<Bitmap>();
            this.remasterImages = new List<Bitmap>();
            this.remasterAlphaImages = new List<Bitmap>();

            if (args.Length > 0)
            {
                // Attempt to load file that has been passed in from command line
                this.LoadBM(args[0]);
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This app is © 2021-2024 Jereth K.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Load PAL  -------------------------------------------------------------------------
        private void BtnLoadPAL_Click(object sender, EventArgs e)
        {
            OpenPALDialog.InitialDirectory = this.palPath ?? OpenPALDialog.InitialDirectory;
            OpenPALDialog.ShowDialog();
        }

        private void OpenPALDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (this.palette.LoadfromFile(OpenPALDialog.FileName))
            {
                if (BM.PixelData != null || BM.SubBMs != null)
                {
                    this.GenerateImages();
                    displayBox.Image = images[0];

                    if (BM.IsMultiBM)
                    {
                        this.UpdateSubBMInfo();
                    }

                }

                MessageBox.Show("PAL Loaded.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                labelPal.Text = $"PAL: {Path.GetFileName(OpenPALDialog.FileName)}";
                BtnLoadBM.Enabled = true;
                btnBulkConvert.Enabled = true;
                this.palPath = Path.GetDirectoryName(OpenPALDialog.FileName);
            }
            else
            {
                MessageBox.Show("Error. May not have been a valid PAL file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load BM  -------------------------------------------------------------------------
        private void BtnLoadBM_Click(object sender, EventArgs e)
        {
            OpenBMDialog.InitialDirectory = this.bmPath ?? OpenBMDialog.InitialDirectory;
            OpenBMDialog.ShowDialog();
        }

        private void OpenBMDialog_FileOk(object sender, CancelEventArgs e)
        {
            LoadBM(OpenBMDialog.FileName);
        }

        private void LoadBM(string path)
        {
            if (!BM.LoadFromFile(path))
            {
                MessageBox.Show("Error loading BM file. Please check that it is a valid DF BM file and not open in another program.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else // successful load!
            {
                OpenBMDialog.FileName = path;

                // Display Info
                string transparency;
                switch (BM.transparent)
                {
                    case 0x36:
                        transparency = "Non-transparent";
                        break;
                    case 0x3E:
                        transparency = "Transparent";
                        break;
                    case 0x08:
                        transparency = "Weapon";
                        break;
                    default:
                        transparency = "Error - unknown";
                        break;
                }

                string[] s = new string[18];
                s[0] = Path.GetFileName(path);
                s[2] = $"SizeX: {BM.SizeX}";
                s[3] = $"SizeY: {BM.SizeY}";
                s[4] = $"Compressed: {BM.compressed}";
                s[5] = $"Transparency: {transparency}";

                if (BM.IsMultiBM)
                {
                    s[6] = $"Number of sub BMs: {BM.NumImages}";
                    s[7] = $"Frame rate: {BM.FrameRate}";
                    //s[8] = $"{BM.SecondByte}";
                }

                s[10] = $"UV width: {BM.idemX.ToString()}";
                s[11] = $"UV height: {BM.idemY.ToString()}";
                s[12] = $"logSizeY: {BM.logSizeY.ToString()}";
                s[13] = $"DataSize: {BM.DataSize.ToString()}";
                textBoxBMInfo.Lines = s;

                this.GenerateImages();

                // Set up multi BM interface
                selectedSubBM = 0;
                if (BM.IsMultiBM)
                {
                    btnPrevSub.Enabled = true;
                    btnNextSub.Enabled = true;
                    displayBox.Image = images[0];
                    UpdateSubBMInfo();
                }
                else
                {
                    btnPrevSub.Enabled = false;
                    btnNextSub.Enabled = false;
                    textBoxSubBMInfo.Text = null;
                }

                btnExport.Enabled = true;
                this.bmPath = Path.GetDirectoryName(path);

                this.comboBoxImageVersion.SelectedIndex = 0;
                this.loadRemasterImages(Path.GetFileNameWithoutExtension(path));
            }
        }

        private void GenerateImages()
        {
            // Convert image(s) to Bitmap(s) and store in List
            this.images.Clear();
            if (!BM.IsMultiBM)
            {
                Bitmap newBitmap = DFBM.BMtoBitmap(BM.SizeX, BM.SizeY, BM.PixelData, palette, BM.transparent == 0x3E || BM.transparent == 0x08);
                this.images.Add(newBitmap);
                this.displayBox.Image = images[0];
            }
            else
            {
                for (int i = 0; i < BM.NumImages; i++)
                {
                    Bitmap newBitmap = DFBM.BMtoBitmap(BM.SubBMs[i].SizeX, BM.SubBMs[i].SizeY, BM.SubBMs[i].PixelData, palette, BM.transparent == 0x3E || BM.transparent == 0x08);
                    this.images.Add(newBitmap);
                }
            }
        }

        private void checkBoxZoom_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxZoom.Checked)
            {
                displayBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else displayBox.SizeMode = PictureBoxSizeMode.Normal;
        }

        // Multi BM Interface ------------------------------------------------------------
        private void btnPrevSub_Click(object sender, EventArgs e)
        {
            if (selectedSubBM > 0)
            {
                selectedSubBM--;
                UpdateSubBMInfo();
            }
        }

        private void btnNextSub_Click(object sender, EventArgs e)
        {
            if (selectedSubBM < BM.NumImages - 1)
            {
                selectedSubBM++;
                UpdateSubBMInfo();
            }
        }

        private void UpdateSubBMInfo()
        {
            int a = selectedSubBM;

            string transparency;
            switch (BM.SubBMs[a].transparent)
            {
                case 0x36:
                    transparency = "Non-transparent";
                    break;
                case 0x3E:
                    transparency = "Transparent";
                    break;
                case 0x08:
                    transparency = "Weapon";
                    break;
                default:
                    transparency = "Error - unknown";
                    break;
            }

            string[] s = new string[10];
            s[0] = $"Sub BM {selectedSubBM + 1} of {BM.NumImages}";
            s[1] = $"SizeX: {BM.SubBMs[a].SizeX}";
            s[2] = $"SizeY: {BM.SubBMs[a].SizeY}";
            s[3] = $"Transparency: {transparency}";

            s[5] = $"UV width: {BM.SubBMs[a].idemX}";
            s[6] = $"UV height: {BM.SubBMs[a].idemY}";
            s[7] = $"logSizeY: {BM.SubBMs[a].logSizeY}";
            s[8] = $"DataSize: {BM.SubBMs[a].DataSize}";
            textBoxSubBMInfo.Lines = s;

            this.UpdateDisplayBox();
        }

        // Export -------------------------------------------------------------------------------
        private void btnExport_Click(object sender, EventArgs e)
        {
            saveBMPDialog.InitialDirectory = this.exportPath ?? Path.GetDirectoryName(this.OpenBMDialog.FileName);
            saveBMPDialog.FileName = Path.GetFileNameWithoutExtension(OpenBMDialog.FileName);
            saveBMPDialog.ShowDialog();
        }

        private void saveBMPDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (!BM.IsMultiBM)
            {
                // single BM
                try
                {
                    this.images[0].Save(saveBMPDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    
                    
                    if (this.remasterImages.Count == 1 && this.remasterAlphaImages.Count == 1)
                    {
                        var dir = Path.GetDirectoryName(saveBMPDialog.FileName);
                        var filenameWithoutExtension = Path.GetFileNameWithoutExtension(saveBMPDialog.FileName);
                        this.remasterImages[0].Save($"{dir}\\{filenameWithoutExtension} remaster.png", System.Drawing.Imaging.ImageFormat.Png);
                        this.remasterAlphaImages[0].Save($"{dir}\\{filenameWithoutExtension} remaster_alpha.png", System.Drawing.Imaging.ImageFormat.Png);
                    }

                }
                catch (IOException)
                {
                    MessageBox.Show("Failed to export. An error occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // multi BM
                string f = saveBMPDialog.FileName;
                string dir = Path.GetDirectoryName(f);
                string fil = Path.GetFileNameWithoutExtension(f);

                try
                {
                    for (int i = 0; i < BM.NumImages; i++)
                    {
                        string saveName = $"{dir}/{fil}_{i}.png";
                        this.images[i].Save(saveName, System.Drawing.Imaging.ImageFormat.Png);

                        if (this.remasterImages.Count > i && this.remasterAlphaImages.Count > i)
                        {
                            string saveName2 = $"{dir}/{fil}_{i}_remaster.png";
                            this.remasterImages[i].Save(saveName2, System.Drawing.Imaging.ImageFormat.Png);
                            string saveName3 = $"{dir}/{fil}_{i}_remaster_alpha.png";
                            this.remasterAlphaImages[i].Save(saveName3, System.Drawing.Imaging.ImageFormat.Png);
                        }
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Failed to export. An error occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            this.exportPath = Path.GetDirectoryName(this.saveBMPDialog.FileName);
        }

        // Bulk convert  ------------------------------------------------------------------
        private void btnBulkConvert_Click(object sender, EventArgs e)
        {
            openBulkDialog.ShowDialog();
        }

        private void openBulkDialog_FileOk(object sender, CancelEventArgs e)
        {
            DialogResult answer = MessageBox.Show("This will convert all selected BMs into PNG files. It will skip any multi BMs that you selected. The PNGs will be saved in the same directory as the BMs. Proceed?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (answer == DialogResult.OK)
            {
                int numSuccessful = 0;
                int numFailed = 0;

                foreach (string BMFile in openBulkDialog.FileNames)
                {
                    string dir = Path.GetDirectoryName(BMFile);
                    string fname = Path.GetFileNameWithoutExtension(BMFile);
                    string exportFile = $"{dir}/{fname}.png";

                    DFBM ConvertingBM = new DFBM();
                    if (ConvertingBM.LoadFromFile(BMFile))
                    {
                        if (ConvertingBM.IsMultiBM)
                        {
                            // multi BM so skip it. Don't increment either success or fail counter
                            continue;
                        }
                        else
                        {
                            Bitmap bitmap = DFBM.BMtoBitmap(ConvertingBM.SizeX, ConvertingBM.SizeY, ConvertingBM.PixelData, palette, ConvertingBM.transparent == 0x3E || ConvertingBM.transparent == 0x08);

                            try
                            {
                                bitmap.Save(exportFile, System.Drawing.Imaging.ImageFormat.Png);
                                numSuccessful++;
                            }
                            catch (IOException)
                            {
                                // something went wrong with output
                                numFailed++;
                            }
                        }
                    }
                    else
                    {
                        // that BM failed to load
                        numFailed++;
                    }
                }

                MessageBox.Show($"Successfully converted {numSuccessful} BMs. {numFailed} BMs failed to convert.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // Create BM ------------------------------------------------------------------------------
        private void btnCreateBM_Click(object sender, EventArgs e)
        {
            Form2 BMCreator = new Form2();
            BMCreator.Show();
        }


        // RAW (remaster) images ------------------------------------------------------------------------

        private void btnRawPath_Click(object sender, EventArgs e)
        {
            this.openRawDialog.InitialDirectory = this.remasterPath ?? this.openRawDialog.InitialDirectory;
            this.openRawDialog.ShowDialog(this);
        }

        private void openRawDialog_FileOk(object sender, CancelEventArgs e)
        {
            this.remasterPath = Path.GetDirectoryName(this.openRawDialog.FileName);
            this.comboBoxImageVersion.Enabled = true;
            this.comboBoxImageVersion.SelectedIndex = 0;

            if (this.BM != null && !string.IsNullOrEmpty(this.OpenBMDialog.FileName))
            {
                this.loadRemasterImages(Path.GetFileNameWithoutExtension(this.OpenBMDialog.FileName));
            }
        }

        private void loadRemasterImages(string bmFilenameWithoutExtension)
        {
            this.remasterImages.Clear();
            this.remasterAlphaImages.Clear();

            if (string.IsNullOrEmpty(this.remasterPath) || string.IsNullOrEmpty(bmFilenameWithoutExtension))
            {
                return;
            }

            if (this.BM == null)
            {
                return;
            }

            // Attempt to load remaster version
            var rawPath = $"{this.remasterPath}\\{bmFilenameWithoutExtension}.raw";
            if (!File.Exists(rawPath))
            {
                return;
            }

            var rawData = MiscFunctions.LoadRawFile(rawPath);

            if (!this.BM.IsMultiBM)
            {
                // Single BM
                if (rawData != null && rawData.Length > 0)
                {
                    var (bitmap, alphaBitmap) = MiscFunctions.GenerateRemasterImage(rawData, this.BM.SizeX * 2, this.BM.SizeY * 2);
                    this.remasterImages.Add(bitmap);
                    this.remasterAlphaImages.Add(alphaBitmap);
                }
            }
            else
            {
                // Multi BM
                var dataPosition = 0;

                foreach (var subBM in this.BM.SubBMs)
                {
                    var imageDataSize = subBM.SizeX * subBM.SizeY * 4 * 4;
                    var imageData = new byte[imageDataSize];

                    try
                    {
                        Array.Copy(rawData, dataPosition, imageData, 0, imageDataSize);
                    }
                    catch (ArgumentException ex)
                    {
                        return;
                    }


                    var (bitmap, alphaBitmap) = MiscFunctions.GenerateRemasterImage(imageData, subBM.SizeX * 2, subBM.SizeY * 2);
                    this.remasterImages.Add(bitmap);
                    this.remasterAlphaImages.Add(alphaBitmap);
                    dataPosition += imageDataSize;
                }
            }
        }

        private void comboBoxImageVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateDisplayBox();
        }

        private void UpdateDisplayBox()
        {
            switch (comboBoxImageVersion.SelectedIndex)
            {
                case 1:
                    this.displayBox.Image = this.remasterImages.Count > this.selectedSubBM
                        ? this.remasterImages[this.selectedSubBM]
                        : null;
                    return;

                case 2:
                    this.displayBox.Image = this.remasterAlphaImages.Count > this.selectedSubBM
                        ? this.remasterAlphaImages[this.selectedSubBM]
                        : null;
                    return;

                default:
                    this.displayBox.Image = this.images.Count > this.selectedSubBM
                        ? this.images[this.selectedSubBM]
                        : null;
                    return;
            }
        }
    }
}
