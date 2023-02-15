﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BM_Converter
{
    public partial class Form2 : Form
    {
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.btnLoadPal = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxCommonColours = new System.Windows.Forms.CheckBox();
            this.checkBoxIncludeIlluminated = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.openPALDialog = new System.Windows.Forms.OpenFileDialog();
            this.LoadImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.labelPal = new System.Windows.Forms.Label();
            this.radioBtnSingleBM = new System.Windows.Forms.RadioButton();
            this.groupTypeBM = new System.Windows.Forms.GroupBox();
            this.radioBtnMultiBM = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCreateBM = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericFramerate = new System.Windows.Forms.NumericUpDown();
            this.checkBoxCompressed = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxTransparentColour = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioBtnWeapon = new System.Windows.Forms.RadioButton();
            this.radioBtnTransparent = new System.Windows.Forms.RadioButton();
            this.radioBtnOpaque = new System.Windows.Forms.RadioButton();
            this.displayBox = new System.Windows.Forms.PictureBox();
            this.btnRemoveImage = new System.Windows.Forms.Button();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.listBoxImages = new System.Windows.Forms.ListBox();
            this.saveBMDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.groupTypeBM.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericFramerate)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadPal
            // 
            this.btnLoadPal.Location = new System.Drawing.Point(11, 14);
            this.btnLoadPal.Name = "btnLoadPal";
            this.btnLoadPal.Size = new System.Drawing.Size(97, 33);
            this.btnLoadPal.TabIndex = 0;
            this.btnLoadPal.Text = "Load PAL";
            this.btnLoadPal.UseVisualStyleBackColor = true;
            this.btnLoadPal.Click += new System.EventHandler(this.btnLoadPal_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.checkBoxCommonColours);
            this.panel1.Controls.Add(this.checkBoxIncludeIlluminated);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnLoadPal);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(824, 65);
            this.panel1.TabIndex = 1;
            // 
            // checkBoxCommonColours
            // 
            this.checkBoxCommonColours.AutoSize = true;
            this.checkBoxCommonColours.Location = new System.Drawing.Point(360, 22);
            this.checkBoxCommonColours.Name = "checkBoxCommonColours";
            this.checkBoxCommonColours.Size = new System.Drawing.Size(145, 19);
            this.checkBoxCommonColours.TabIndex = 3;
            this.checkBoxCommonColours.Text = "Common colours only";
            this.checkBoxCommonColours.UseVisualStyleBackColor = true;
            this.checkBoxCommonColours.CheckedChanged += new System.EventHandler(this.checkBoxCommonColours_CheckedChanged);
            // 
            // checkBoxIncludeIlluminated
            // 
            this.checkBoxIncludeIlluminated.AutoSize = true;
            this.checkBoxIncludeIlluminated.Location = new System.Drawing.Point(138, 22);
            this.checkBoxIncludeIlluminated.Name = "checkBoxIncludeIlluminated";
            this.checkBoxIncludeIlluminated.Size = new System.Drawing.Size(170, 19);
            this.checkBoxIncludeIlluminated.TabIndex = 2;
            this.checkBoxIncludeIlluminated.Text = "Include illuminated colours";
            this.checkBoxIncludeIlluminated.UseVisualStyleBackColor = true;
            this.checkBoxIncludeIlluminated.CheckedChanged += new System.EventHandler(this.checkBoxIncludeIlluminated_CheckedChanged);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(722, 14);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(76, 34);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // openPALDialog
            // 
            this.openPALDialog.DefaultExt = "pal";
            this.openPALDialog.Filter = "Dark Forces PAL file|*.PAL";
            this.openPALDialog.ShowHelp = true;
            this.openPALDialog.Title = "Load PAL";
            this.openPALDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openPALDialog_FileOk);
            // 
            // LoadImageDialog
            // 
            this.LoadImageDialog.Filter = "PNG image|*.PNG|BMP image|*.BMP|JPEG image|*.JPG";
            this.LoadImageDialog.Title = "Load image";
            this.LoadImageDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.LoadImageDialog_FileOk);
            // 
            // labelPal
            // 
            this.labelPal.AutoSize = true;
            this.labelPal.Location = new System.Drawing.Point(11, 13);
            this.labelPal.Name = "labelPal";
            this.labelPal.Size = new System.Drawing.Size(98, 15);
            this.labelPal.TabIndex = 2;
            this.labelPal.Text = "PAL: Secbase.PAL";
            // 
            // radioBtnSingleBM
            // 
            this.radioBtnSingleBM.AutoSize = true;
            this.radioBtnSingleBM.Checked = true;
            this.radioBtnSingleBM.Location = new System.Drawing.Point(20, 26);
            this.radioBtnSingleBM.Name = "radioBtnSingleBM";
            this.radioBtnSingleBM.Size = new System.Drawing.Size(78, 19);
            this.radioBtnSingleBM.TabIndex = 3;
            this.radioBtnSingleBM.TabStop = true;
            this.radioBtnSingleBM.Text = "Single BM";
            this.radioBtnSingleBM.UseVisualStyleBackColor = true;
            this.radioBtnSingleBM.CheckedChanged += new System.EventHandler(this.radioBtnSingleBM_CheckedChanged);
            this.radioBtnSingleBM.Click += new System.EventHandler(this.radioBtnSingleBM_Click);
            // 
            // groupTypeBM
            // 
            this.groupTypeBM.Controls.Add(this.radioBtnMultiBM);
            this.groupTypeBM.Controls.Add(this.radioBtnSingleBM);
            this.groupTypeBM.Location = new System.Drawing.Point(11, 47);
            this.groupTypeBM.Name = "groupTypeBM";
            this.groupTypeBM.Size = new System.Drawing.Size(240, 63);
            this.groupTypeBM.TabIndex = 4;
            this.groupTypeBM.TabStop = false;
            this.groupTypeBM.Text = "Type of BM";
            // 
            // radioBtnMultiBM
            // 
            this.radioBtnMultiBM.AutoSize = true;
            this.radioBtnMultiBM.Location = new System.Drawing.Point(133, 26);
            this.radioBtnMultiBM.Name = "radioBtnMultiBM";
            this.radioBtnMultiBM.Size = new System.Drawing.Size(74, 19);
            this.radioBtnMultiBM.TabIndex = 5;
            this.radioBtnMultiBM.Text = "Multi BM";
            this.radioBtnMultiBM.UseVisualStyleBackColor = true;
            this.radioBtnMultiBM.CheckedChanged += new System.EventHandler(this.radioBtnMultiBM_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCreateBM);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.numericFramerate);
            this.panel2.Controls.Add(this.checkBoxCompressed);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.displayBox);
            this.panel2.Controls.Add(this.btnRemoveImage);
            this.panel2.Controls.Add(this.btnAddImage);
            this.panel2.Controls.Add(this.listBoxImages);
            this.panel2.Controls.Add(this.labelPal);
            this.panel2.Controls.Add(this.groupTypeBM);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(824, 719);
            this.panel2.TabIndex = 5;
            // 
            // btnCreateBM
            // 
            this.btnCreateBM.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCreateBM.Location = new System.Drawing.Point(681, 47);
            this.btnCreateBM.Name = "btnCreateBM";
            this.btnCreateBM.Size = new System.Drawing.Size(118, 49);
            this.btnCreateBM.TabIndex = 12;
            this.btnCreateBM.Text = "Create BM";
            this.btnCreateBM.UseVisualStyleBackColor = true;
            this.btnCreateBM.Click += new System.EventHandler(this.btnCreateBM_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Frame Rate (0 = Switch)";
            // 
            // numericFramerate
            // 
            this.numericFramerate.Enabled = false;
            this.numericFramerate.Location = new System.Drawing.Point(280, 172);
            this.numericFramerate.Name = "numericFramerate";
            this.numericFramerate.Size = new System.Drawing.Size(78, 23);
            this.numericFramerate.TabIndex = 10;
            // 
            // checkBoxCompressed
            // 
            this.checkBoxCompressed.AutoSize = true;
            this.checkBoxCompressed.Location = new System.Drawing.Point(481, 173);
            this.checkBoxCompressed.Name = "checkBoxCompressed";
            this.checkBoxCompressed.Size = new System.Drawing.Size(92, 19);
            this.checkBoxCompressed.TabIndex = 9;
            this.checkBoxCompressed.Text = "Compressed";
            this.checkBoxCompressed.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxTransparentColour);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.radioBtnWeapon);
            this.groupBox1.Controls.Add(this.radioBtnTransparent);
            this.groupBox1.Controls.Add(this.radioBtnOpaque);
            this.groupBox1.Location = new System.Drawing.Point(280, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 110);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transparency";
            // 
            // comboBoxTransparentColour
            // 
            this.comboBoxTransparentColour.FormattingEnabled = true;
            this.comboBoxTransparentColour.Items.AddRange(new object[] {
            "Black (RGB 0,0,0)",
            "Transparent (alpha 0)"});
            this.comboBoxTransparentColour.Location = new System.Drawing.Point(156, 65);
            this.comboBoxTransparentColour.Name = "comboBoxTransparentColour";
            this.comboBoxTransparentColour.Size = new System.Drawing.Size(190, 23);
            this.comboBoxTransparentColour.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Transparent colour:";
            // 
            // radioBtnWeapon
            // 
            this.radioBtnWeapon.AutoSize = true;
            this.radioBtnWeapon.Location = new System.Drawing.Point(224, 26);
            this.radioBtnWeapon.Name = "radioBtnWeapon";
            this.radioBtnWeapon.Size = new System.Drawing.Size(69, 19);
            this.radioBtnWeapon.TabIndex = 6;
            this.radioBtnWeapon.Text = "Weapon";
            this.radioBtnWeapon.UseVisualStyleBackColor = true;
            // 
            // radioBtnTransparent
            // 
            this.radioBtnTransparent.AutoSize = true;
            this.radioBtnTransparent.Location = new System.Drawing.Point(112, 26);
            this.radioBtnTransparent.Name = "radioBtnTransparent";
            this.radioBtnTransparent.Size = new System.Drawing.Size(86, 19);
            this.radioBtnTransparent.TabIndex = 5;
            this.radioBtnTransparent.Text = "Transparent";
            this.radioBtnTransparent.UseVisualStyleBackColor = true;
            // 
            // radioBtnOpaque
            // 
            this.radioBtnOpaque.AutoSize = true;
            this.radioBtnOpaque.Checked = true;
            this.radioBtnOpaque.Location = new System.Drawing.Point(16, 26);
            this.radioBtnOpaque.Name = "radioBtnOpaque";
            this.radioBtnOpaque.Size = new System.Drawing.Size(67, 19);
            this.radioBtnOpaque.TabIndex = 3;
            this.radioBtnOpaque.TabStop = true;
            this.radioBtnOpaque.Text = "Opaque";
            this.radioBtnOpaque.UseVisualStyleBackColor = true;
            this.radioBtnOpaque.CheckedChanged += new System.EventHandler(this.radioBtnOpaque_CheckedChanged);
            // 
            // displayBox
            // 
            this.displayBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayBox.BackColor = System.Drawing.Color.DarkGray;
            this.displayBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.displayBox.Location = new System.Drawing.Point(280, 216);
            this.displayBox.Name = "displayBox";
            this.displayBox.Size = new System.Drawing.Size(519, 488);
            this.displayBox.TabIndex = 8;
            this.displayBox.TabStop = false;
            // 
            // btnRemoveImage
            // 
            this.btnRemoveImage.Location = new System.Drawing.Point(135, 137);
            this.btnRemoveImage.Name = "btnRemoveImage";
            this.btnRemoveImage.Size = new System.Drawing.Size(104, 55);
            this.btnRemoveImage.TabIndex = 7;
            this.btnRemoveImage.Text = "Remove Image";
            this.btnRemoveImage.UseVisualStyleBackColor = true;
            this.btnRemoveImage.Click += new System.EventHandler(this.btnRemoveImage_Click);
            // 
            // btnAddImage
            // 
            this.btnAddImage.Location = new System.Drawing.Point(11, 137);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(104, 55);
            this.btnAddImage.TabIndex = 6;
            this.btnAddImage.Text = "Add Image";
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // listBoxImages
            // 
            this.listBoxImages.FormattingEnabled = true;
            this.listBoxImages.ItemHeight = 15;
            this.listBoxImages.Location = new System.Drawing.Point(11, 216);
            this.listBoxImages.Name = "listBoxImages";
            this.listBoxImages.Size = new System.Drawing.Size(228, 379);
            this.listBoxImages.TabIndex = 5;
            this.listBoxImages.SelectedIndexChanged += new System.EventHandler(this.listBoxImages_SelectedIndexChanged);
            // 
            // saveBMDialog
            // 
            this.saveBMDialog.DefaultExt = "bm";
            this.saveBMDialog.Filter = "Dark Forces BM|*.bm";
            this.saveBMDialog.Title = "Save BM";
            this.saveBMDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveBMDialog_FileOk);
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(824, 784);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(840, 800);
            this.Name = "Form2";
            this.Text = "Create BM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupTypeBM.ResumeLayout(false);
            this.groupTypeBM.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericFramerate)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayBox)).EndInit();
            this.ResumeLayout(false);

        }

        private Button btnLoadPal;
        private Panel panel1;
        private OpenFileDialog openPALDialog;
        private OpenFileDialog LoadImageDialog;
        private Button btnExit;
        private Label labelPal;
        private RadioButton radioBtnSingleBM;
        private GroupBox groupTypeBM;
        private Panel panel2;
        private RadioButton radioBtnMultiBM;
        private Button btnAddImage;
        private ListBox listBoxImages;
        private Button btnRemoveImage;
        private PictureBox displayBox;
        private GroupBox groupBox1;
        private RadioButton radioBtnWeapon;
        private RadioButton radioBtnTransparent;
        private RadioButton radioBtnOpaque;
        private CheckBox checkBoxCompressed;
        private NumericUpDown numericFramerate;
        private Label label1;
        private Button btnCreateBM;
        private SaveFileDialog saveBMDialog;
        private CheckBox checkBoxIncludeIlluminated;
        private CheckBox checkBoxCommonColours;
        private ComboBox comboBoxTransparentColour;
        private Label label2;
    }
}
