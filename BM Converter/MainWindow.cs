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
        private List<Bitmap> remasterNoAlphaImages;
        private List<Bitmap> remasterAlphaImages;
        private List<Bitmap> remasterCombinedImages;
        private Bitmap displayImage;

        private string remasterPath;
        private string palPath;
        private string bmPath;
        private string exportPath;
        private int selectedSubBM = 0;
        private float zoomFactor = 1.0f;
        private DFCmp cmp;

        public MainWindow(string[] args)
        {
            InitializeComponent();

            this.palette = new DFPal();
            this.BM = new DFBM();
            this.images = new List<Bitmap>();
            this.remasterNoAlphaImages = new List<Bitmap>();
            this.remasterAlphaImages = new List<Bitmap>();
            this.remasterCombinedImages = new List<Bitmap>();

            if (args.Length > 0)
            {
                // Attempt to load file that has been passed in from command line
                this.LoadBM(args[0]);
            }

            this.comboBoxZoom.SelectedIndex = 0;
        }

        private void MenuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This app is © 2021-2024 Jereth K.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Load PAL  -------------------------------------------------------------------------
        private void MenuLoadPal_Click(object sender, EventArgs e)
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
                    this.UpdateDisplay();
                }

                MessageBox.Show("PAL Loaded.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                labelPal.Text = $"PAL: {Path.GetFileName(OpenPALDialog.FileName)}";
                this.palPath = Path.GetDirectoryName(OpenPALDialog.FileName);
            }
            else
            {
                MessageBox.Show("Error. May not have been a valid PAL file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load BM  -------------------------------------------------------------------------
        private void MenuLoadBm_Click(object sender, EventArgs e)
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
                switch (BM.Transparency)
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
                s[4] = $"UV width: {BM.UvWidth}";
                s[5] = $"UV height: {BM.UvHeight}";
                s[6] = $"Compressed: {BM.Compressed}";
                s[7] = $"Transparency: {transparency}";

                if (BM.IsMultiBM)
                {
                    s[9] = $"Number of sub BMs: {BM.NumImages}";
                    s[10] = $"Frame rate: {BM.FrameRate}";
                    //s[11] = $"{BM.SecondByte}";
                }

                s[12] = $"logSizeY: {BM.logSizeY}";
                s[13] = $"DataSize: {BM.DataSize}";
                textBoxBMInfo.Lines = s;

                this.GenerateImages();

                this.selectedSubBM = 0;
                if (BM.IsMultiBM)
                {
                    // Set up multi BM interface
                    btnPrevSub.Enabled = true;
                    btnNextSub.Enabled = true;
                    this.UpdateSubBMInfoAndDisplay();
                }
                else
                {
                    btnPrevSub.Enabled = false;
                    btnNextSub.Enabled = false;
                    textBoxSubBMInfo.Text = null;
                    this.UpdateDisplay();
                }

                MenuExportBm.Enabled = true;
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
                Bitmap newBitmap = DFBM.BMtoBitmap(BM.SizeX, BM.SizeY, BM.PixelData, palette, BM.IsTransparentOrWeapon());
                this.images.Add(newBitmap);
            }
            else
            {
                for (int i = 0; i < BM.NumImages; i++)
                {
                    Bitmap newBitmap = DFBM.BMtoBitmap(BM.SubBMs[i].SizeX, BM.SubBMs[i].SizeY, BM.SubBMs[i].PixelData, palette, BM.SubBMs[i].IsTransparent());
                    this.images.Add(newBitmap);
                }
            }
        }

        private void ComboBoxZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.zoomFactor = comboBoxZoom.SelectedIndex switch
            {
                0 => 1.0f,
                1 => 2.0f,
                2 => 3.0f,
                3 => 4.0f,
                _ => 1.0f,
            };

            this.displayBox.Invalidate();
        }

        private void btnLighting_Click(object sender, EventArgs e)
        {
            if (this.BM == null || this.BM.NumImages == 0)
            {
                return;
            }

            if (this.cmp == null)
            {
                var dialogResult = this.openCMPDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    var cmp = new DFCmp();
                    if (!cmp.LoadFromFile(openCMPDialog.FileName))
                    {
                        return;
                    }

                    this.cmp = cmp;
                }
            }

            if (this.cmp == null)
            {
                MessageBox.Show("No CMP loaded.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var lightingViewerWindow = new LightingViewer(this.palette, this.cmp, this.BM, this.selectedSubBM, this.openCMPDialog);
            lightingViewerWindow.ShowDialog(this);
            this.cmp = lightingViewerWindow.Cmp;
            lightingViewerWindow.Dispose();
        }

        // Multi BM Interface ------------------------------------------------------------
        private void btnPrevSub_Click(object sender, EventArgs e)
        {
            if (selectedSubBM >= 0)
            {
                selectedSubBM--;
                if (selectedSubBM < 0)
                {
                    selectedSubBM = BM.NumImages - 1;
                }

                this.UpdateSubBMInfoAndDisplay();
            }
        }

        private void btnNextSub_Click(object sender, EventArgs e)
        {
            if (selectedSubBM < BM.NumImages)
            {
                selectedSubBM++;
                if (selectedSubBM >= BM.NumImages)
                {
                    selectedSubBM = 0;
                }

                this.UpdateSubBMInfoAndDisplay();
            }
        }

        private void UpdateSubBMInfoAndDisplay()
        {
            int a = selectedSubBM;

            string transparency;
            switch (BM.SubBMs[a].Transparency)
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

            this.UpdateDisplay();
        }

        // Export -------------------------------------------------------------------------------
        private void MenuExportBm_Click(object sender, EventArgs e)
        {
            if (this.images.Count == 0)
            {
                return;
            }

            SavePngDialog.InitialDirectory = this.exportPath ?? Path.GetDirectoryName(this.OpenBMDialog.FileName);
            SavePngDialog.FileName = Path.GetFileNameWithoutExtension(OpenBMDialog.FileName);
            var dialogResult = SavePngDialog.ShowDialog();

            if (dialogResult != DialogResult.OK)
            {
                return;
            }

            if (!BM.IsMultiBM)
            {
                // single BM
                try
                {
                    this.images[0].Save(SavePngDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
                catch (IOException)
                {
                    MessageBox.Show("Failed to export. An error occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // multi BM
                string dir = Path.GetDirectoryName(SavePngDialog.FileName);
                string filenameWithoutExtension = Path.GetFileNameWithoutExtension(SavePngDialog.FileName);

                try
                {
                    for (int i = 0; i < BM.NumImages; i++)
                    {
                        string saveName = $"{dir}/{filenameWithoutExtension}_{i}.png";
                        this.images[i].Save(saveName, System.Drawing.Imaging.ImageFormat.Png);
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Failed to export. An error occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            this.exportPath = Path.GetDirectoryName(this.SavePngDialog.FileName);
        }

        // Bulk convert  ------------------------------------------------------------------
        private void MenuBulkConvert_Click(object sender, EventArgs e)
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
                            Bitmap bitmap = DFBM.BMtoBitmap(ConvertingBM.SizeX, ConvertingBM.SizeY, ConvertingBM.PixelData, palette, ConvertingBM.IsTransparentOrWeapon());

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
        private void MenuCreateBM_Click(object sender, EventArgs e)
        {
            CreateBMWindow BMCreator = new CreateBMWindow();
            BMCreator.Show();
        }


        // RAW (remaster) images ------------------------------------------------------------------------

        private void MenuRawLocation_Click(object sender, EventArgs e)
        {
            this.openRawLocationDialog.InitialDirectory = !string.IsNullOrEmpty(this.remasterPath) ? Path.GetDirectoryName(this.remasterPath) : this.openRawLocationDialog.InitialDirectory;
            this.openRawLocationDialog.ShowDialog(this);
        }

        private void openRawLocationDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (Path.GetExtension(this.openRawLocationDialog.FileName).Equals(".gob", StringComparison.OrdinalIgnoreCase))
            {
                this.remasterPath = this.openRawLocationDialog.FileName;
            }
            else
            {
                this.remasterPath = Path.GetDirectoryName(this.openRawLocationDialog.FileName);
            }

            MessageBox.Show($"High res (DF Remaster) images will automatically be loaded from [{this.remasterPath}] when you open a BM.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.comboBoxImageVersion.Enabled = true;
            this.comboBoxImageVersion.SelectedIndex = 0;

            if (this.BM != null && !string.IsNullOrEmpty(this.OpenBMDialog.FileName))
            {
                this.loadRemasterImages(Path.GetFileNameWithoutExtension(this.OpenBMDialog.FileName));
            }
        }

        private void loadRemasterImages(string bmFilenameWithoutExtension)
        {
            this.remasterNoAlphaImages.Clear();
            this.remasterAlphaImages.Clear();
            this.remasterCombinedImages.Clear();

            if (string.IsNullOrEmpty(this.remasterPath) || string.IsNullOrEmpty(bmFilenameWithoutExtension))
            {
                return;
            }

            if (this.BM == null || this.BM.NumImages == 0)
            {
                return;
            }

            // Check if RAW file exists, then attempt to load
            byte[] rawData;
            var rawFileName = $"{bmFilenameWithoutExtension}.raw";

            if (Path.GetExtension(this.remasterPath).Equals(".gob", StringComparison.OrdinalIgnoreCase))
            {
                // Path is a GOB
                if (!Gob.GobContainsFile(this.remasterPath, rawFileName))
                {
                    return;
                }

                rawData = Gob.GetFileFromGob(this.remasterPath, rawFileName);
            }
            else
            {
                // Path is a directory
                var rawPath = $"{this.remasterPath}\\{rawFileName}";
                if (!File.Exists(rawPath))
                {
                    return;
                }

                rawData = MiscFunctions.LoadRawFile(rawPath);
            }

            if (rawData == null || rawData.Length == 0)
            {
                return;
            }

            if (!this.BM.IsMultiBM)
            {
                // Single BM
                var bitmaps = MiscFunctions.GenerateRemasterImage(rawData, this.BM.SizeX * 2, this.BM.SizeY * 2);
                this.remasterNoAlphaImages.Add(bitmaps.noAlphaImage);
                this.remasterAlphaImages.Add(bitmaps.alphaImage);
                this.remasterCombinedImages.Add(bitmaps.combinedImage);
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

                    var bitmaps = MiscFunctions.GenerateRemasterImage(imageData, subBM.SizeX * 2, subBM.SizeY * 2);
                    this.remasterNoAlphaImages.Add(bitmaps.noAlphaImage);
                    this.remasterAlphaImages.Add(bitmaps.alphaImage);
                    this.remasterCombinedImages.Add(bitmaps.combinedImage);
                    dataPosition += imageDataSize;
                }
            }
        }

        private void comboBoxImageVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            switch (comboBoxImageVersion.SelectedIndex)
            {
                case 1:
                    this.displayImage = this.remasterCombinedImages.Count > this.selectedSubBM
                        ? this.remasterCombinedImages[this.selectedSubBM]
                        : null;
                    break;

                case 2:
                    this.displayImage = this.remasterNoAlphaImages.Count > this.selectedSubBM
                        ? this.remasterNoAlphaImages[this.selectedSubBM]
                        : null;
                    break;

                case 3:
                    this.displayImage = this.remasterAlphaImages.Count > this.selectedSubBM
                        ? this.remasterAlphaImages[this.selectedSubBM]
                        : null;
                    break;

                default:
                    this.displayImage = this.images.Count > this.selectedSubBM
                        ? this.images[this.selectedSubBM]
                        : null;
                    break;
            }

            this.displayBox.Invalidate();
        }

        private void DisplayBox_Paint(object sender, PaintEventArgs e)
        {
            if (this.displayImage == null)
            {
                return;
            }

            e.Graphics.Clear(Color.DarkGray);
            e.Graphics.DrawImage(this.displayImage, 0, 0, this.displayImage.Width * this.zoomFactor, this.displayImage.Height * this.zoomFactor);
        }

        private void MenuExportHighRes_Click(object sender, EventArgs e)
        {
            if (this.remasterNoAlphaImages.Count == 0 || this.remasterCombinedImages.Count == 0)
            {
                return;
            }

            if (this.remasterNoAlphaImages.Any(i => i == null) || this.remasterCombinedImages.Any(i => i == null))
            {
                return;
            }

            SavePngDialog.InitialDirectory = this.exportPath ?? Path.GetDirectoryName(this.OpenBMDialog.FileName);
            SavePngDialog.FileName = Path.GetFileNameWithoutExtension(OpenBMDialog.FileName);
            var dialogResult = SavePngDialog.ShowDialog();

            if (dialogResult != DialogResult.OK)
            {
                return;
            }

            var response = MessageBox.Show("Do you wish to save the alpha channel separately? The alpha data will be saved as a greyscale image.", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (response == DialogResult.Cancel)
            {
                return;
            }

            if (!BM.IsMultiBM)
            {
                // Single BM
                try
                {
                    var dir = Path.GetDirectoryName(SavePngDialog.FileName);
                    var filenameWithoutExtension = Path.GetFileNameWithoutExtension(SavePngDialog.FileName);

                    switch (response)
                    {
                        case DialogResult.Yes:
                            if (this.remasterNoAlphaImages.Count == 1 && this.remasterAlphaImages.Count == 1)
                            {
                                this.remasterNoAlphaImages[0].Save($"{dir}\\{filenameWithoutExtension}_remaster.png", System.Drawing.Imaging.ImageFormat.Png);
                                this.remasterAlphaImages[0].Save($"{dir}\\{filenameWithoutExtension}_remaster_alpha.png", System.Drawing.Imaging.ImageFormat.Png);
                            }

                            break;

                        case DialogResult.No:
                            if (this.remasterCombinedImages.Count == 1)
                            {
                                this.remasterCombinedImages[0].Save($"{dir}\\{filenameWithoutExtension}_remaster.png", System.Drawing.Imaging.ImageFormat.Png);
                            }

                            break;
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Failed to export. An error occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Multi BM
                string dir = Path.GetDirectoryName(SavePngDialog.FileName);
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(SavePngDialog.FileName);

                try
                {
                    for (int i = 0; i < BM.NumImages; i++)
                    {
                        switch (response)
                        {
                            case (DialogResult.Yes):
                                if (this.remasterNoAlphaImages.Count > i && this.remasterAlphaImages.Count > i)
                                {
                                    string saveName2 = $"{dir}/{fileNameWithoutExtension}_{i}_remaster.png";
                                    this.remasterNoAlphaImages[i].Save(saveName2, System.Drawing.Imaging.ImageFormat.Png);
                                    string saveName3 = $"{dir}/{fileNameWithoutExtension}_{i}_remaster_alpha.png";
                                    this.remasterAlphaImages[i].Save(saveName3, System.Drawing.Imaging.ImageFormat.Png);
                                }

                                break;

                            case (DialogResult.No):
                                if (this.remasterCombinedImages.Count > i)
                                {
                                    string saveName2 = $"{dir}/{fileNameWithoutExtension}_{i}_remaster.png";
                                    this.remasterCombinedImages[i].Save(saveName2, System.Drawing.Imaging.ImageFormat.Png);
                                }

                                break;
                        }
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Failed to export. An error occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            this.exportPath = Path.GetDirectoryName(this.SavePngDialog.FileName);
        }

        private void MenuCreateRaw_Click(object sender, EventArgs e)
        {
            var createRawWindow = new CreateRawWindow(this.BM);
            createRawWindow.Show();
        }
    }
}
