
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
            comboBoxImageVersion = new System.Windows.Forms.ComboBox();
            checkBoxZoom = new System.Windows.Forms.CheckBox();
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
            MenuRawLocation = new System.Windows.Forms.ToolStripMenuItem();
            MenuExport = new System.Windows.Forms.ToolStripMenuItem();
            MenuExportBm = new System.Windows.Forms.ToolStripMenuItem();
            MenuExportHighRes = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            MenuBulkConvert = new System.Windows.Forms.ToolStripMenuItem();
            MenuCreate = new System.Windows.Forms.ToolStripMenuItem();
            MenuCreateBm = new System.Windows.Forms.ToolStripMenuItem();
            MenuAbout = new System.Windows.Forms.ToolStripMenuItem();
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
            SavePngDialog.FileOk += savePngDialog_FileOk;
            // 
            // panel2
            // 
            panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel2.Controls.Add(comboBoxImageVersion);
            panel2.Controls.Add(checkBoxZoom);
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
            panel2.Size = new System.Drawing.Size(784, 577);
            panel2.TabIndex = 1;
            // 
            // comboBoxImageVersion
            // 
            comboBoxImageVersion.Enabled = false;
            comboBoxImageVersion.FormattingEnabled = true;
            comboBoxImageVersion.Items.AddRange(new object[] { "Original texture", "Remastered texture", "Remastered texture - no alpha", "Remaster - alpha channel" });
            comboBoxImageVersion.Location = new System.Drawing.Point(501, 13);
            comboBoxImageVersion.Name = "comboBoxImageVersion";
            comboBoxImageVersion.Size = new System.Drawing.Size(266, 23);
            comboBoxImageVersion.TabIndex = 9;
            comboBoxImageVersion.SelectedIndexChanged += comboBoxImageVersion_SelectedIndexChanged;
            // 
            // checkBoxZoom
            // 
            checkBoxZoom.AutoSize = true;
            checkBoxZoom.Location = new System.Drawing.Point(247, 57);
            checkBoxZoom.Name = "checkBoxZoom";
            checkBoxZoom.Size = new System.Drawing.Size(86, 19);
            checkBoxZoom.TabIndex = 8;
            checkBoxZoom.Text = "Zoom to fit";
            checkBoxZoom.UseVisualStyleBackColor = true;
            checkBoxZoom.CheckedChanged += checkBoxZoom_CheckedChanged;
            // 
            // btnNextSub
            // 
            btnNextSub.Enabled = false;
            btnNextSub.Location = new System.Drawing.Point(128, 265);
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
            btnPrevSub.Location = new System.Drawing.Point(84, 265);
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
            label2.Location = new System.Drawing.Point(13, 265);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 15);
            label2.TabIndex = 5;
            label2.Text = "Sub BMs:";
            // 
            // textBoxSubBMInfo
            // 
            textBoxSubBMInfo.Location = new System.Drawing.Point(13, 300);
            textBoxSubBMInfo.Multiline = true;
            textBoxSubBMInfo.Name = "textBoxSubBMInfo";
            textBoxSubBMInfo.ReadOnly = true;
            textBoxSubBMInfo.Size = new System.Drawing.Size(212, 142);
            textBoxSubBMInfo.TabIndex = 4;
            // 
            // displayBox
            // 
            displayBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            displayBox.BackColor = System.Drawing.Color.DarkGray;
            displayBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            displayBox.Location = new System.Drawing.Point(247, 82);
            displayBox.Name = "displayBox";
            displayBox.Size = new System.Drawing.Size(518, 464);
            displayBox.TabIndex = 3;
            displayBox.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 64);
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
            textBoxBMInfo.Location = new System.Drawing.Point(13, 82);
            textBoxBMInfo.Multiline = true;
            textBoxBMInfo.Name = "textBoxBMInfo";
            textBoxBMInfo.ReadOnly = true;
            textBoxBMInfo.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
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
            menuStrip1.Size = new System.Drawing.Size(784, 24);
            menuStrip1.TabIndex = 2;
            // 
            // MenuFile
            // 
            MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { MenuLoadPal, MenuLoadBm, MenuRawLocation });
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
            MenuCreate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { MenuCreateBm });
            MenuCreate.Name = "MenuCreate";
            MenuCreate.Size = new System.Drawing.Size(53, 20);
            MenuCreate.Text = "Create";
            // 
            // MenuCreateBm
            // 
            MenuCreateBm.Name = "MenuCreateBm";
            MenuCreateBm.Size = new System.Drawing.Size(129, 22);
            MenuCreateBm.Text = "Create BM";
            MenuCreateBm.Click += MenuCreateBM_Click;
            // 
            // MenuAbout
            // 
            MenuAbout.Name = "MenuAbout";
            MenuAbout.Size = new System.Drawing.Size(52, 20);
            MenuAbout.Text = "About";
            MenuAbout.Click += MenuAbout_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(784, 601);
            Controls.Add(panel2);
            Controls.Add(menuStrip1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new System.Drawing.Size(800, 640);
            Name = "MainWindow";
            Text = "BM Converter (version 2.1.2)";
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
        private System.Windows.Forms.CheckBox checkBoxZoom;
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
    }
}

