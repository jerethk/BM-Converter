using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BM_Converter
{
    public partial class CreateBMWindow : Form
    {
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateBMWindow));
            btnLoadPal = new Button();
            panel1 = new Panel();
            checkBoxCommonColours = new CheckBox();
            checkBoxIncludeIlluminated = new CheckBox();
            btnExit = new Button();
            openPALDialog = new OpenFileDialog();
            LoadImageDialog = new OpenFileDialog();
            labelPal = new Label();
            radioBtnSingleBM = new RadioButton();
            groupTypeBM = new GroupBox();
            radioBtnMultiBM = new RadioButton();
            panel2 = new Panel();
            btnCreateBM = new Button();
            label1 = new Label();
            numericFramerate = new NumericUpDown();
            checkBoxCompressed = new CheckBox();
            groupBox1 = new GroupBox();
            comboBoxTransparentColour = new ComboBox();
            label2 = new Label();
            radioBtnWeapon = new RadioButton();
            radioBtnTransparent = new RadioButton();
            radioBtnOpaque = new RadioButton();
            displayBox = new PictureBox();
            btnRemoveImage = new Button();
            btnAddImage = new Button();
            listBoxImages = new ListBox();
            saveBMDialog = new SaveFileDialog();
            panel1.SuspendLayout();
            groupTypeBM.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericFramerate).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)displayBox).BeginInit();
            SuspendLayout();
            // 
            // btnLoadPal
            // 
            btnLoadPal.Location = new System.Drawing.Point(11, 14);
            btnLoadPal.Name = "btnLoadPal";
            btnLoadPal.Size = new System.Drawing.Size(97, 33);
            btnLoadPal.TabIndex = 0;
            btnLoadPal.Text = "Load PAL";
            btnLoadPal.UseVisualStyleBackColor = true;
            btnLoadPal.Click += btnLoadPal_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(checkBoxCommonColours);
            panel1.Controls.Add(checkBoxIncludeIlluminated);
            panel1.Controls.Add(btnExit);
            panel1.Controls.Add(btnLoadPal);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(824, 65);
            panel1.TabIndex = 1;
            // 
            // checkBoxCommonColours
            // 
            checkBoxCommonColours.AutoSize = true;
            checkBoxCommonColours.Location = new System.Drawing.Point(360, 22);
            checkBoxCommonColours.Name = "checkBoxCommonColours";
            checkBoxCommonColours.Size = new System.Drawing.Size(145, 19);
            checkBoxCommonColours.TabIndex = 3;
            checkBoxCommonColours.Text = "Common colours only";
            checkBoxCommonColours.UseVisualStyleBackColor = true;
            checkBoxCommonColours.CheckedChanged += checkBoxCommonColours_CheckedChanged;
            // 
            // checkBoxIncludeIlluminated
            // 
            checkBoxIncludeIlluminated.AutoSize = true;
            checkBoxIncludeIlluminated.Location = new System.Drawing.Point(138, 22);
            checkBoxIncludeIlluminated.Name = "checkBoxIncludeIlluminated";
            checkBoxIncludeIlluminated.Size = new System.Drawing.Size(164, 19);
            checkBoxIncludeIlluminated.TabIndex = 2;
            checkBoxIncludeIlluminated.Text = "Include full-bright colours";
            checkBoxIncludeIlluminated.UseVisualStyleBackColor = true;
            checkBoxIncludeIlluminated.CheckedChanged += checkBoxIncludeIlluminated_CheckedChanged;
            // 
            // btnExit
            // 
            btnExit.Location = new System.Drawing.Point(722, 14);
            btnExit.Name = "btnExit";
            btnExit.Size = new System.Drawing.Size(76, 34);
            btnExit.TabIndex = 1;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // openPALDialog
            // 
            openPALDialog.DefaultExt = "pal";
            openPALDialog.Filter = "Dark Forces PAL file|*.PAL";
            openPALDialog.ShowHelp = true;
            openPALDialog.Title = "Load PAL";
            openPALDialog.FileOk += openPALDialog_FileOk;
            // 
            // LoadImageDialog
            // 
            LoadImageDialog.Filter = "PNG image|*.PNG|BMP image|*.BMP|JPEG image|*.JPG";
            LoadImageDialog.Multiselect = true;
            LoadImageDialog.Title = "Load image";
            LoadImageDialog.FileOk += LoadImageDialog_FileOk;
            // 
            // labelPal
            // 
            labelPal.AutoSize = true;
            labelPal.Location = new System.Drawing.Point(11, 13);
            labelPal.Name = "labelPal";
            labelPal.Size = new System.Drawing.Size(98, 15);
            labelPal.TabIndex = 2;
            labelPal.Text = "PAL: Secbase.PAL";
            // 
            // radioBtnSingleBM
            // 
            radioBtnSingleBM.AutoSize = true;
            radioBtnSingleBM.Checked = true;
            radioBtnSingleBM.Location = new System.Drawing.Point(20, 26);
            radioBtnSingleBM.Name = "radioBtnSingleBM";
            radioBtnSingleBM.Size = new System.Drawing.Size(78, 19);
            radioBtnSingleBM.TabIndex = 3;
            radioBtnSingleBM.TabStop = true;
            radioBtnSingleBM.Text = "Single BM";
            radioBtnSingleBM.UseVisualStyleBackColor = true;
            radioBtnSingleBM.CheckedChanged += radioBtnSingleBM_CheckedChanged;
            radioBtnSingleBM.Click += radioBtnSingleBM_Click;
            // 
            // groupTypeBM
            // 
            groupTypeBM.Controls.Add(radioBtnMultiBM);
            groupTypeBM.Controls.Add(radioBtnSingleBM);
            groupTypeBM.Location = new System.Drawing.Point(11, 47);
            groupTypeBM.Name = "groupTypeBM";
            groupTypeBM.Size = new System.Drawing.Size(240, 63);
            groupTypeBM.TabIndex = 4;
            groupTypeBM.TabStop = false;
            groupTypeBM.Text = "Type of BM";
            // 
            // radioBtnMultiBM
            // 
            radioBtnMultiBM.AutoSize = true;
            radioBtnMultiBM.Location = new System.Drawing.Point(133, 26);
            radioBtnMultiBM.Name = "radioBtnMultiBM";
            radioBtnMultiBM.Size = new System.Drawing.Size(74, 19);
            radioBtnMultiBM.TabIndex = 5;
            radioBtnMultiBM.Text = "Multi BM";
            radioBtnMultiBM.UseVisualStyleBackColor = true;
            radioBtnMultiBM.CheckedChanged += radioBtnMultiBM_CheckedChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnCreateBM);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(numericFramerate);
            panel2.Controls.Add(checkBoxCompressed);
            panel2.Controls.Add(groupBox1);
            panel2.Controls.Add(displayBox);
            panel2.Controls.Add(btnRemoveImage);
            panel2.Controls.Add(btnAddImage);
            panel2.Controls.Add(listBoxImages);
            panel2.Controls.Add(labelPal);
            panel2.Controls.Add(groupTypeBM);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 65);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(824, 719);
            panel2.TabIndex = 5;
            // 
            // btnCreateBM
            // 
            btnCreateBM.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnCreateBM.Location = new System.Drawing.Point(681, 47);
            btnCreateBM.Name = "btnCreateBM";
            btnCreateBM.Size = new System.Drawing.Size(118, 49);
            btnCreateBM.TabIndex = 12;
            btnCreateBM.Text = "Create BM";
            btnCreateBM.UseVisualStyleBackColor = true;
            btnCreateBM.Click += btnCreateBM_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(280, 145);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(132, 15);
            label1.TabIndex = 11;
            label1.Text = "Frame Rate (0 = Switch)";
            // 
            // numericFramerate
            // 
            numericFramerate.Enabled = false;
            numericFramerate.Location = new System.Drawing.Point(280, 172);
            numericFramerate.Name = "numericFramerate";
            numericFramerate.Size = new System.Drawing.Size(78, 23);
            numericFramerate.TabIndex = 10;
            // 
            // checkBoxCompressed
            // 
            checkBoxCompressed.AutoSize = true;
            checkBoxCompressed.Location = new System.Drawing.Point(481, 173);
            checkBoxCompressed.Name = "checkBoxCompressed";
            checkBoxCompressed.Size = new System.Drawing.Size(92, 19);
            checkBoxCompressed.TabIndex = 9;
            checkBoxCompressed.Text = "Compressed";
            checkBoxCompressed.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBoxTransparentColour);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(radioBtnWeapon);
            groupBox1.Controls.Add(radioBtnTransparent);
            groupBox1.Controls.Add(radioBtnOpaque);
            groupBox1.Location = new System.Drawing.Point(280, 13);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(372, 110);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Transparency";
            // 
            // comboBoxTransparentColour
            // 
            comboBoxTransparentColour.FormattingEnabled = true;
            comboBoxTransparentColour.Items.AddRange(new object[] { "Black (RGB 0,0,0)", "Alpha 0", "Alpha < 128" });
            comboBoxTransparentColour.Location = new System.Drawing.Point(156, 65);
            comboBoxTransparentColour.Name = "comboBoxTransparentColour";
            comboBoxTransparentColour.Size = new System.Drawing.Size(190, 23);
            comboBoxTransparentColour.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(16, 68);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(108, 15);
            label2.TabIndex = 7;
            label2.Text = "Transparent colour:";
            // 
            // radioBtnWeapon
            // 
            radioBtnWeapon.AutoSize = true;
            radioBtnWeapon.Location = new System.Drawing.Point(224, 26);
            radioBtnWeapon.Name = "radioBtnWeapon";
            radioBtnWeapon.Size = new System.Drawing.Size(69, 19);
            radioBtnWeapon.TabIndex = 6;
            radioBtnWeapon.Text = "Weapon";
            radioBtnWeapon.UseVisualStyleBackColor = true;
            // 
            // radioBtnTransparent
            // 
            radioBtnTransparent.AutoSize = true;
            radioBtnTransparent.Location = new System.Drawing.Point(112, 26);
            radioBtnTransparent.Name = "radioBtnTransparent";
            radioBtnTransparent.Size = new System.Drawing.Size(86, 19);
            radioBtnTransparent.TabIndex = 5;
            radioBtnTransparent.Text = "Transparent";
            radioBtnTransparent.UseVisualStyleBackColor = true;
            // 
            // radioBtnOpaque
            // 
            radioBtnOpaque.AutoSize = true;
            radioBtnOpaque.Checked = true;
            radioBtnOpaque.Location = new System.Drawing.Point(16, 26);
            radioBtnOpaque.Name = "radioBtnOpaque";
            radioBtnOpaque.Size = new System.Drawing.Size(67, 19);
            radioBtnOpaque.TabIndex = 3;
            radioBtnOpaque.TabStop = true;
            radioBtnOpaque.Text = "Opaque";
            radioBtnOpaque.UseVisualStyleBackColor = true;
            radioBtnOpaque.CheckedChanged += radioBtnOpaque_CheckedChanged;
            // 
            // displayBox
            // 
            displayBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            displayBox.BackColor = System.Drawing.Color.DarkGray;
            displayBox.BorderStyle = BorderStyle.Fixed3D;
            displayBox.Location = new System.Drawing.Point(280, 216);
            displayBox.Name = "displayBox";
            displayBox.Size = new System.Drawing.Size(519, 488);
            displayBox.TabIndex = 8;
            displayBox.TabStop = false;
            // 
            // btnRemoveImage
            // 
            btnRemoveImage.Location = new System.Drawing.Point(135, 137);
            btnRemoveImage.Name = "btnRemoveImage";
            btnRemoveImage.Size = new System.Drawing.Size(104, 55);
            btnRemoveImage.TabIndex = 7;
            btnRemoveImage.Text = "Remove Image";
            btnRemoveImage.UseVisualStyleBackColor = true;
            btnRemoveImage.Click += btnRemoveImage_Click;
            // 
            // btnAddImage
            // 
            btnAddImage.Location = new System.Drawing.Point(11, 137);
            btnAddImage.Name = "btnAddImage";
            btnAddImage.Size = new System.Drawing.Size(104, 55);
            btnAddImage.TabIndex = 6;
            btnAddImage.Text = "Add Image(s)";
            btnAddImage.UseVisualStyleBackColor = true;
            btnAddImage.Click += btnAddImage_Click;
            // 
            // listBoxImages
            // 
            listBoxImages.FormattingEnabled = true;
            listBoxImages.ItemHeight = 15;
            listBoxImages.Location = new System.Drawing.Point(11, 216);
            listBoxImages.Name = "listBoxImages";
            listBoxImages.Size = new System.Drawing.Size(228, 379);
            listBoxImages.TabIndex = 5;
            listBoxImages.SelectedIndexChanged += listBoxImages_SelectedIndexChanged;
            // 
            // saveBMDialog
            // 
            saveBMDialog.DefaultExt = "bm";
            saveBMDialog.Filter = "Dark Forces BM|*.bm";
            saveBMDialog.Title = "Save BM";
            saveBMDialog.FileOk += saveBMDialog_FileOk;
            // 
            // CreateBMWindow
            // 
            ClientSize = new System.Drawing.Size(824, 784);
            ControlBox = false;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MinimumSize = new System.Drawing.Size(840, 800);
            Name = "CreateBMWindow";
            Text = "Create BM";
            FormClosing += Form2_FormClosing;
            FormClosed += CreateBMWindow_FormClosed;
            Load += Form2_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupTypeBM.ResumeLayout(false);
            groupTypeBM.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericFramerate).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)displayBox).EndInit();
            ResumeLayout(false);
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
