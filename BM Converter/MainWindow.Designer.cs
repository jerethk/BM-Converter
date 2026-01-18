
namespace BM_Converter
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            OpenPALDialog = new System.Windows.Forms.OpenFileDialog();
            OpenBMDialog = new System.Windows.Forms.OpenFileDialog();
            SavePngDialog = new System.Windows.Forms.SaveFileDialog();
            panel2 = new System.Windows.Forms.Panel();
            label3 = new System.Windows.Forms.Label();
            comboBoxZoom = new System.Windows.Forms.ComboBox();
            btnLighting = new System.Windows.Forms.Button();
            comboBoxImageVersion = new System.Windows.Forms.ComboBox();
            btnNextSub = new System.Windows.Forms.Button();
            btnPrevSub = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            textBoxSubBMInfo = new System.Windows.Forms.TextBox();
            displayBox = new System.Windows.Forms.PictureBox();
            label1 = new System.Windows.Forms.Label();
            labelPal = new System.Windows.Forms.Label();
            textBoxBMInfo = new System.Windows.Forms.TextBox();
            openBulkDialog = new System.Windows.Forms.OpenFileDialog();
            openRawLocationDialog = new System.Windows.Forms.OpenFileDialog();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            MenuLoadPal = new System.Windows.Forms.ToolStripMenuItem();
            MenuLoadBm = new System.Windows.Forms.ToolStripMenuItem();
            MenuBrowseGob = new System.Windows.Forms.ToolStripMenuItem();
            MenuRawLocation = new System.Windows.Forms.ToolStripMenuItem();
            MenuExport = new System.Windows.Forms.ToolStripMenuItem();
            MenuExportBm = new System.Windows.Forms.ToolStripMenuItem();
            MenuExportHighRes = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            MenuBulkConvert = new System.Windows.Forms.ToolStripMenuItem();
            MenuCreate = new System.Windows.Forms.ToolStripMenuItem();
            MenuCreateBm = new System.Windows.Forms.ToolStripMenuItem();
            MenuCreateRaw = new System.Windows.Forms.ToolStripMenuItem();
            MenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            openCMPDialog = new System.Windows.Forms.OpenFileDialog();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)displayBox).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // OpenPALDialog
            // 
            OpenPALDialog.DefaultExt = "pal";
            OpenPALDialog.Filter = "DF Palette files|*.pal";
            OpenPALDialog.Title = "Open PAL";
            OpenPALDialog.FileOk += OpenPALDialog_FileOk;
            // 
            // OpenBMDialog
            // 
            OpenBMDialog.DefaultExt = "bm";
            OpenBMDialog.Filter = "Dark Forces BM file|*.bm";
            OpenBMDialog.Title = "Open BM";
            OpenBMDialog.FileOk += OpenBMDialog_FileOk;
            // 
            // SavePngDialog
            // 
            SavePngDialog.DefaultExt = "png";
            SavePngDialog.Filter = "PNG file|*.png";
            SavePngDialog.Title = "Export";
            // 
            // panel2
            // 
            panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel2.Controls.Add(label3);
            panel2.Controls.Add(comboBoxZoom);
            panel2.Controls.Add(btnLighting);
            panel2.Controls.Add(comboBoxImageVersion);
            panel2.Controls.Add(btnNextSub);
            panel2.Controls.Add(btnPrevSub);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(textBoxSubBMInfo);
            panel2.Controls.Add(displayBox);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(labelPal);
            panel2.Controls.Add(textBoxBMInfo);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 24);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(864, 657);
            panel2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(247, 73);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(39, 15);
            label3.TabIndex = 12;
            label3.Text = "Zoom";
            // 
            // comboBoxZoom
            // 
            comboBoxZoom.FormattingEnabled = true;
            comboBoxZoom.Items.AddRange(new object[] { "100%", "200%", "300%", "400%" });
            comboBoxZoom.Location = new System.Drawing.Point(296, 70);
            comboBoxZoom.Name = "comboBoxZoom";
            comboBoxZoom.Size = new System.Drawing.Size(136, 23);
            comboBoxZoom.TabIndex = 11;
            comboBoxZoom.SelectedIndexChanged += ComboBoxZoom_SelectedIndexChanged;
            // 
            // btnLighting
            // 
            btnLighting.Location = new System.Drawing.Point(296, 14);
            btnLighting.Name = "btnLighting";
            btnLighting.Size = new System.Drawing.Size(152, 36);
            btnLighting.TabIndex = 10;
            btnLighting.Text = "View lighting";
            btnLighting.UseVisualStyleBackColor = true;
            btnLighting.Click += btnLighting_Click;
            // 
            // comboBoxImageVersion
            // 
            comboBoxImageVersion.Enabled = false;
            comboBoxImageVersion.FormattingEnabled = true;
            comboBoxImageVersion.Items.AddRange(new object[] { "Original texture", "Remastered texture", "Remastered texture - no alpha", "Remaster - alpha channel" });
            comboBoxImageVersion.Location = new System.Drawing.Point(570, 13);
            comboBoxImageVersion.Name = "comboBoxImageVersion";
            comboBoxImageVersion.Size = new System.Drawing.Size(266, 23);
            comboBoxImageVersion.TabIndex = 9;
            comboBoxImageVersion.SelectedIndexChanged += comboBoxImageVersion_SelectedIndexChanged;
            // 
            // btnNextSub
            // 
            btnNextSub.Enabled = false;
            btnNextSub.Location = new System.Drawing.Point(128, 286);
            btnNextSub.Name = "btnNextSub";
            btnNextSub.Size = new System.Drawing.Size(28, 29);
            btnNextSub.TabIndex = 7;
            btnNextSub.Text = ">";
            btnNextSub.UseVisualStyleBackColor = true;
            btnNextSub.Click += btnNextSub_Click;
            // 
            // btnPrevSub
            // 
            btnPrevSub.Enabled = false;
            btnPrevSub.Location = new System.Drawing.Point(84, 286);
            btnPrevSub.Name = "btnPrevSub";
            btnPrevSub.Size = new System.Drawing.Size(28, 29);
            btnPrevSub.TabIndex = 6;
            btnPrevSub.Text = "<";
            btnPrevSub.UseVisualStyleBackColor = true;
            btnPrevSub.Click += btnPrevSub_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(13, 286);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 15);
            label2.TabIndex = 5;
            label2.Text = "Sub BMs:";
            // 
            // textBoxSubBMInfo
            // 
            textBoxSubBMInfo.Location = new System.Drawing.Point(13, 321);
            textBoxSubBMInfo.Multiline = true;
            textBoxSubBMInfo.Name = "textBoxSubBMInfo";
            textBoxSubBMInfo.ReadOnly = true;
            textBoxSubBMInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            textBoxSubBMInfo.Size = new System.Drawing.Size(212, 154);
            textBoxSubBMInfo.TabIndex = 4;
            // 
            // displayBox
            // 
            displayBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            displayBox.BackColor = System.Drawing.Color.DarkGray;
            displayBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            displayBox.Location = new System.Drawing.Point(247, 103);
            displayBox.Name = "displayBox";
            displayBox.Size = new System.Drawing.Size(598, 523);
            displayBox.TabIndex = 3;
            displayBox.TabStop = false;
            displayBox.Paint += DisplayBox_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 85);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(52, 15);
            label1.TabIndex = 2;
            label1.Text = "BM Info:";
            // 
            // labelPal
            // 
            labelPal.AutoSize = true;
            labelPal.Location = new System.Drawing.Point(13, 21);
            labelPal.Name = "labelPal";
            labelPal.Size = new System.Drawing.Size(98, 15);
            labelPal.TabIndex = 1;
            labelPal.Text = "PAL: Secbase.PAL";
            // 
            // textBoxBMInfo
            // 
            textBoxBMInfo.Location = new System.Drawing.Point(13, 103);
            textBoxBMInfo.Multiline = true;
            textBoxBMInfo.Name = "textBoxBMInfo";
            textBoxBMInfo.ReadOnly = true;
            textBoxBMInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            textBoxBMInfo.Size = new System.Drawing.Size(212, 149);
            textBoxBMInfo.TabIndex = 0;
            textBoxBMInfo.WordWrap = false;
            // 
            // openBulkDialog
            // 
            openBulkDialog.DefaultExt = "bm";
            openBulkDialog.Filter = "Dark Forces BM files|*.BM";
            openBulkDialog.Multiselect = true;
            openBulkDialog.Title = "Choose BM files to convert";
            openBulkDialog.FileOk += openBulkDialog_FileOk;
            // 
            // openRawLocationDialog
            // 
            openRawLocationDialog.Filter = "RAW, GOB|*.raw; *.GOB";
            openRawLocationDialog.Title = "Select folder or GOB containing RAW (DF Remaster) textures";
            openRawLocationDialog.FileOk += openRawLocationDialog_FileOk;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { MenuFile, MenuExport, MenuCreate, MenuAbout });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(864, 24);
            menuStrip1.TabIndex = 2;
            // 
            // MenuFile
            // 
            MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { MenuLoadPal, MenuLoadBm, MenuBrowseGob, MenuRawLocation });
            MenuFile.Name = "MenuFile";
            MenuFile.Size = new System.Drawing.Size(37, 20);
            MenuFile.Text = "File";
            // 
            // MenuLoadPal
            // 
            MenuLoadPal.Name = "MenuLoadPal";
            MenuLoadPal.Size = new System.Drawing.Size(193, 22);
            MenuLoadPal.Text = "Load PAL";
            MenuLoadPal.Click += MenuLoadPal_Click;
            // 
            // MenuLoadBm
            // 
            MenuLoadBm.Name = "MenuLoadBm";
            MenuLoadBm.Size = new System.Drawing.Size(193, 22);
            MenuLoadBm.Text = "Load BM";
            MenuLoadBm.Click += MenuLoadBm_Click;
            // 
            // MenuBrowseGob
            // 
            MenuBrowseGob.Name = "MenuBrowseGob";
            MenuBrowseGob.Size = new System.Drawing.Size(193, 22);
            MenuBrowseGob.Text = "Browse GOB";
            MenuBrowseGob.Click += MenuBrowseGob_Click;
            // 
            // MenuRawLocation
            // 
            MenuRawLocation.Name = "MenuRawLocation";
            MenuRawLocation.Size = new System.Drawing.Size(193, 22);
            MenuRawLocation.Text = "Remaster files location";
            MenuRawLocation.Click += MenuRawLocation_Click;
            // 
            // MenuExport
            // 
            MenuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { MenuExportBm, MenuExportHighRes, toolStripSeparator1, MenuBulkConvert });
            MenuExport.Name = "MenuExport";
            MenuExport.Size = new System.Drawing.Size(53, 20);
            MenuExport.Text = "Export";
            // 
            // MenuExportBm
            // 
            MenuExportBm.Name = "MenuExportBm";
            MenuExportBm.Size = new System.Drawing.Size(196, 22);
            MenuExportBm.Text = "Export BM to PNG";
            MenuExportBm.Click += MenuExportBm_Click;
            // 
            // MenuExportHighRes
            // 
            MenuExportHighRes.Name = "MenuExportHighRes";
            MenuExportHighRes.Size = new System.Drawing.Size(196, 22);
            MenuExportHighRes.Text = "Export high-res images";
            MenuExportHighRes.Click += MenuExportHighRes_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // MenuBulkConvert
            // 
            MenuBulkConvert.Name = "MenuBulkConvert";
            MenuBulkConvert.Size = new System.Drawing.Size(196, 22);
            MenuBulkConvert.Text = "Bulk Convert";
            MenuBulkConvert.Click += MenuBulkConvert_Click;
            // 
            // MenuCreate
            // 
            MenuCreate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { MenuCreateBm, MenuCreateRaw });
            MenuCreate.Name = "MenuCreate";
            MenuCreate.Size = new System.Drawing.Size(53, 20);
            MenuCreate.Text = "Create";
            // 
            // MenuCreateBm
            // 
            MenuCreateBm.Name = "MenuCreateBm";
            MenuCreateBm.Size = new System.Drawing.Size(218, 22);
            MenuCreateBm.Text = "Create BM";
            MenuCreateBm.Click += MenuCreateBM_Click;
            // 
            // MenuCreateRaw
            // 
            MenuCreateRaw.Name = "MenuCreateRaw";
            MenuCreateRaw.Size = new System.Drawing.Size(218, 22);
            MenuCreateRaw.Text = "Create RAW (high res asset)";
            MenuCreateRaw.Click += MenuCreateRaw_Click;
            // 
            // MenuAbout
            // 
            MenuAbout.Name = "MenuAbout";
            MenuAbout.Size = new System.Drawing.Size(52, 20);
            MenuAbout.Text = "About";
            MenuAbout.Click += MenuAbout_Click;
            // 
            // openCMPDialog
            // 
            openCMPDialog.Filter = "Dark Forces CMP|*.cmp";
            openCMPDialog.Title = "Open CMP file";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(864, 681);
            Controls.Add(panel2);
            Controls.Add(menuStrip1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new System.Drawing.Size(880, 720);
            Name = "MainWindow";
            Text = "BM Converter (version 2.4)";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)displayBox).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.OpenFileDialog OpenPALDialog;
        private System.Windows.Forms.OpenFileDialog OpenBMDialog;
        private System.Windows.Forms.SaveFileDialog SavePngDialog;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelPal;
        private System.Windows.Forms.TextBox textBoxBMInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox displayBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSubBMInfo;
        private System.Windows.Forms.Button btnNextSub;
        private System.Windows.Forms.Button btnPrevSub;
        private System.Windows.Forms.OpenFileDialog openBulkDialog;
        private System.Windows.Forms.OpenFileDialog openRawLocationDialog;
        private System.Windows.Forms.ComboBox comboBoxImageVersion;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuExport;
        private System.Windows.Forms.ToolStripMenuItem MenuCreate;
        private System.Windows.Forms.ToolStripMenuItem MenuAbout;
        private System.Windows.Forms.ToolStripMenuItem MenuLoadPal;
        private System.Windows.Forms.ToolStripMenuItem MenuLoadBm;
        private System.Windows.Forms.ToolStripMenuItem MenuRawLocation;
        private System.Windows.Forms.ToolStripMenuItem MenuExportBm;
        private System.Windows.Forms.ToolStripMenuItem MenuExportHighRes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuBulkConvert;
        private System.Windows.Forms.ToolStripMenuItem MenuCreateBm;
        private System.Windows.Forms.ToolStripMenuItem MenuCreateRaw;
        private System.Windows.Forms.Button btnLighting;
        private System.Windows.Forms.OpenFileDialog openCMPDialog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxZoom;
        private System.Windows.Forms.ToolStripMenuItem MenuBrowseGob;
    }
}

