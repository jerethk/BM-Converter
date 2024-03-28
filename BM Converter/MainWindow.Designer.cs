
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
            panel1 = new System.Windows.Forms.Panel();
            btnRawPath = new System.Windows.Forms.Button();
            btnCreateBM = new System.Windows.Forms.Button();
            buttonHelp = new System.Windows.Forms.Button();
            btnBulkConvert = new System.Windows.Forms.Button();
            BtnLoadBM = new System.Windows.Forms.Button();
            BtnLoadPAL = new System.Windows.Forms.Button();
            btnExport = new System.Windows.Forms.Button();
            OpenPALDialog = new System.Windows.Forms.OpenFileDialog();
            OpenBMDialog = new System.Windows.Forms.OpenFileDialog();
            saveBMPDialog = new System.Windows.Forms.SaveFileDialog();
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
            openRawDialog = new System.Windows.Forms.OpenFileDialog();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)displayBox).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(btnRawPath);
            panel1.Controls.Add(btnCreateBM);
            panel1.Controls.Add(buttonHelp);
            panel1.Controls.Add(btnBulkConvert);
            panel1.Controls.Add(BtnLoadBM);
            panel1.Controls.Add(BtnLoadPAL);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(784, 65);
            panel1.TabIndex = 0;
            // 
            // btnRawPath
            // 
            btnRawPath.Location = new System.Drawing.Point(203, 12);
            btnRawPath.Name = "btnRawPath";
            btnRawPath.Size = new System.Drawing.Size(129, 32);
            btnRawPath.TabIndex = 5;
            btnRawPath.Text = "Remaster files";
            btnRawPath.UseVisualStyleBackColor = true;
            btnRawPath.Click += btnRawPath_Click;
            // 
            // btnCreateBM
            // 
            btnCreateBM.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnCreateBM.Location = new System.Drawing.Point(560, 12);
            btnCreateBM.Name = "btnCreateBM";
            btnCreateBM.Size = new System.Drawing.Size(123, 32);
            btnCreateBM.TabIndex = 4;
            btnCreateBM.Text = "Create BM";
            btnCreateBM.UseVisualStyleBackColor = true;
            btnCreateBM.Click += btnCreateBM_Click;
            // 
            // buttonHelp
            // 
            buttonHelp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonHelp.Location = new System.Drawing.Point(736, 12);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Size = new System.Drawing.Size(30, 32);
            buttonHelp.TabIndex = 3;
            buttonHelp.Text = "?";
            buttonHelp.UseVisualStyleBackColor = true;
            buttonHelp.Click += buttonHelp_Click;
            // 
            // btnBulkConvert
            // 
            btnBulkConvert.Location = new System.Drawing.Point(386, 12);
            btnBulkConvert.Name = "btnBulkConvert";
            btnBulkConvert.Size = new System.Drawing.Size(117, 32);
            btnBulkConvert.TabIndex = 2;
            btnBulkConvert.Text = "Bulk Convert";
            btnBulkConvert.UseVisualStyleBackColor = true;
            btnBulkConvert.Click += btnBulkConvert_Click;
            // 
            // BtnLoadBM
            // 
            BtnLoadBM.Location = new System.Drawing.Point(106, 12);
            BtnLoadBM.Name = "BtnLoadBM";
            BtnLoadBM.Size = new System.Drawing.Size(81, 32);
            BtnLoadBM.TabIndex = 1;
            BtnLoadBM.Text = "Load BM";
            BtnLoadBM.UseVisualStyleBackColor = true;
            BtnLoadBM.Click += BtnLoadBM_Click;
            // 
            // BtnLoadPAL
            // 
            BtnLoadPAL.Location = new System.Drawing.Point(12, 12);
            BtnLoadPAL.Name = "BtnLoadPAL";
            BtnLoadPAL.Size = new System.Drawing.Size(79, 32);
            BtnLoadPAL.TabIndex = 0;
            BtnLoadPAL.Text = "Load PAL";
            BtnLoadPAL.UseVisualStyleBackColor = true;
            BtnLoadPAL.Click += BtnLoadPAL_Click;
            // 
            // btnExport
            // 
            btnExport.Enabled = false;
            btnExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnExport.Location = new System.Drawing.Point(58, 462);
            btnExport.Name = "btnExport";
            btnExport.Size = new System.Drawing.Size(111, 32);
            btnExport.TabIndex = 2;
            btnExport.Text = "Export PNG";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
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
            // saveBMPDialog
            // 
            saveBMPDialog.DefaultExt = "png";
            saveBMPDialog.Filter = "PNG file|*.png";
            saveBMPDialog.Title = "Export";
            saveBMPDialog.FileOk += saveBMPDialog_FileOk;
            // 
            // panel2
            // 
            panel2.Controls.Add(comboBoxImageVersion);
            panel2.Controls.Add(btnExport);
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
            panel2.Location = new System.Drawing.Point(0, 65);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(784, 536);
            panel2.TabIndex = 1;
            // 
            // comboBoxImageVersion
            // 
            comboBoxImageVersion.Enabled = false;
            comboBoxImageVersion.FormattingEnabled = true;
            comboBoxImageVersion.Items.AddRange(new object[] { "Original texture", "Remastered texture", "Remaster - alpha channel" });
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
            displayBox.Size = new System.Drawing.Size(520, 425);
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
            // openRawDialog
            // 
            openRawDialog.Filter = "RAW|*.raw";
            openRawDialog.Title = "Select folder containing RAW (DF Remaster) textures";
            openRawDialog.FileOk += openRawDialog_FileOk;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(784, 601);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MinimumSize = new System.Drawing.Size(800, 640);
            Name = "MainWindow";
            Text = "BM Converter (version 2.1.1)";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)displayBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnLoadBM;
        private System.Windows.Forms.Button BtnLoadPAL;
        private System.Windows.Forms.OpenFileDialog OpenPALDialog;
        private System.Windows.Forms.OpenFileDialog OpenBMDialog;
        private System.Windows.Forms.SaveFileDialog saveBMPDialog;
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
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnBulkConvert;
        private System.Windows.Forms.OpenFileDialog openBulkDialog;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button btnCreateBM;
        private System.Windows.Forms.Button btnRawPath;
        private System.Windows.Forms.OpenFileDialog openRawDialog;
        private System.Windows.Forms.ComboBox comboBoxImageVersion;
    }
}

