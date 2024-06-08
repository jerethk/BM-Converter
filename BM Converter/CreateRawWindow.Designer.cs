namespace BM_Converter
{
    partial class CreateRawWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateRawWindow));
            openBmDialog = new System.Windows.Forms.OpenFileDialog();
            sourceImagesDialog = new System.Windows.Forms.OpenFileDialog();
            btnSourceImages = new System.Windows.Forms.Button();
            btnQuit = new System.Windows.Forms.Button();
            listBoxBmImages = new System.Windows.Forms.ListBox();
            label1 = new System.Windows.Forms.Label();
            pictureBoxBmImage = new System.Windows.Forms.PictureBox();
            label2 = new System.Windows.Forms.Label();
            listBoxSourceImages = new System.Windows.Forms.ListBox();
            label3 = new System.Windows.Forms.Label();
            pictureBoxSourceImages = new System.Windows.Forms.PictureBox();
            pictureBoxHighRes = new System.Windows.Forms.PictureBox();
            btnApplyImage = new System.Windows.Forms.Button();
            labelBmImageSize = new System.Windows.Forms.Label();
            labelSourceImageSize = new System.Windows.Forms.Label();
            btnCreateRaw = new System.Windows.Forms.Button();
            saveBmDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBmImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSourceImages).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHighRes).BeginInit();
            SuspendLayout();
            // 
            // openBmDialog
            // 
            openBmDialog.Filter = "BM files|*.BM";
            openBmDialog.Title = "Open BM file";
            openBmDialog.FileOk += openBmDialog_FileOk;
            // 
            // sourceImagesDialog
            // 
            sourceImagesDialog.Filter = "PNG images|*.PNG";
            sourceImagesDialog.Title = "Select directory containing high-res images";
            sourceImagesDialog.FileOk += sourceImagesDialog_FileOk;
            // 
            // btnSourceImages
            // 
            btnSourceImages.Location = new System.Drawing.Point(235, 456);
            btnSourceImages.Name = "btnSourceImages";
            btnSourceImages.Size = new System.Drawing.Size(141, 40);
            btnSourceImages.TabIndex = 0;
            btnSourceImages.Text = "Get Source Images";
            btnSourceImages.UseVisualStyleBackColor = true;
            btnSourceImages.Click += btnSourceImages_Click;
            // 
            // btnQuit
            // 
            btnQuit.Location = new System.Drawing.Point(939, 755);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new System.Drawing.Size(126, 40);
            btnQuit.TabIndex = 1;
            btnQuit.Text = "Exit";
            btnQuit.UseVisualStyleBackColor = true;
            btnQuit.Click += btnQuit_Click;
            // 
            // listBoxBmImages
            // 
            listBoxBmImages.FormattingEnabled = true;
            listBoxBmImages.ItemHeight = 15;
            listBoxBmImages.Location = new System.Drawing.Point(30, 39);
            listBoxBmImages.Name = "listBoxBmImages";
            listBoxBmImages.Size = new System.Drawing.Size(64, 349);
            listBoxBmImages.TabIndex = 2;
            listBoxBmImages.SelectedIndexChanged += listBoxBmImages_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(30, 12);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(66, 15);
            label1.TabIndex = 3;
            label1.Text = "BM images";
            // 
            // pictureBoxBmImage
            // 
            pictureBoxBmImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxBmImage.Location = new System.Drawing.Point(146, 39);
            pictureBoxBmImage.Name = "pictureBoxBmImage";
            pictureBoxBmImage.Size = new System.Drawing.Size(412, 390);
            pictureBoxBmImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBoxBmImage.TabIndex = 4;
            pictureBoxBmImage.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(778, 12);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(92, 15);
            label2.TabIndex = 5;
            label2.Text = "High res version";
            // 
            // listBoxSourceImages
            // 
            listBoxSourceImages.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            listBoxSourceImages.FormattingEnabled = true;
            listBoxSourceImages.Location = new System.Drawing.Point(30, 541);
            listBoxSourceImages.Name = "listBoxSourceImages";
            listBoxSourceImages.Size = new System.Drawing.Size(92, 355);
            listBoxSourceImages.TabIndex = 6;
            listBoxSourceImages.SelectedIndexChanged += listBoxSourceImages_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(30, 514);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(84, 15);
            label3.TabIndex = 7;
            label3.Text = "Source images";
            // 
            // pictureBoxSourceImages
            // 
            pictureBoxSourceImages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxSourceImages.Location = new System.Drawing.Point(146, 541);
            pictureBoxSourceImages.Name = "pictureBoxSourceImages";
            pictureBoxSourceImages.Size = new System.Drawing.Size(412, 390);
            pictureBoxSourceImages.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBoxSourceImages.TabIndex = 8;
            pictureBoxSourceImages.TabStop = false;
            // 
            // pictureBoxHighRes
            // 
            pictureBoxHighRes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxHighRes.Cursor = System.Windows.Forms.Cursors.No;
            pictureBoxHighRes.Location = new System.Drawing.Point(778, 39);
            pictureBoxHighRes.Name = "pictureBoxHighRes";
            pictureBoxHighRes.Size = new System.Drawing.Size(412, 390);
            pictureBoxHighRes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBoxHighRes.TabIndex = 9;
            pictureBoxHighRes.TabStop = false;
            // 
            // btnApplyImage
            // 
            btnApplyImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnApplyImage.Location = new System.Drawing.Point(584, 541);
            btnApplyImage.Name = "btnApplyImage";
            btnApplyImage.Size = new System.Drawing.Size(164, 75);
            btnApplyImage.TabIndex = 10;
            btnApplyImage.Text = "Set Image";
            btnApplyImage.UseVisualStyleBackColor = true;
            btnApplyImage.Click += btnApplyImage_Click;
            // 
            // labelBmImageSize
            // 
            labelBmImageSize.AutoSize = true;
            labelBmImageSize.Location = new System.Drawing.Point(146, 12);
            labelBmImageSize.Name = "labelBmImageSize";
            labelBmImageSize.Size = new System.Drawing.Size(38, 15);
            labelBmImageSize.TabIndex = 11;
            labelBmImageSize.Text = "Size =";
            // 
            // labelSourceImageSize
            // 
            labelSourceImageSize.AutoSize = true;
            labelSourceImageSize.Location = new System.Drawing.Point(146, 514);
            labelSourceImageSize.Name = "labelSourceImageSize";
            labelSourceImageSize.Size = new System.Drawing.Size(38, 15);
            labelSourceImageSize.TabIndex = 12;
            labelSourceImageSize.Text = "Size =";
            // 
            // btnCreateRaw
            // 
            btnCreateRaw.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnCreateRaw.Location = new System.Drawing.Point(939, 636);
            btnCreateRaw.Name = "btnCreateRaw";
            btnCreateRaw.Size = new System.Drawing.Size(126, 96);
            btnCreateRaw.TabIndex = 14;
            btnCreateRaw.Text = "Create RAW";
            btnCreateRaw.UseVisualStyleBackColor = true;
            btnCreateRaw.Click += btnCreateRaw_Click;
            // 
            // saveBmDialog
            // 
            saveBmDialog.DefaultExt = "WXX";
            saveBmDialog.Filter = "High res BM|*.RAW";
            saveBmDialog.Title = "Save RAW";
            // 
            // CreateRawWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1224, 951);
            ControlBox = false;
            Controls.Add(btnCreateRaw);
            Controls.Add(labelSourceImageSize);
            Controls.Add(labelBmImageSize);
            Controls.Add(btnApplyImage);
            Controls.Add(pictureBoxHighRes);
            Controls.Add(pictureBoxSourceImages);
            Controls.Add(label3);
            Controls.Add(listBoxSourceImages);
            Controls.Add(label2);
            Controls.Add(pictureBoxBmImage);
            Controls.Add(label1);
            Controls.Add(listBoxBmImages);
            Controls.Add(btnQuit);
            Controls.Add(btnSourceImages);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MinimumSize = new System.Drawing.Size(1240, 990);
            Name = "CreateRawWindow";
            Text = "Create RAW";
            Shown += BmBuilderWindow_Shown;
            ((System.ComponentModel.ISupportInitialize)pictureBoxBmImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSourceImages).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHighRes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openBmDialog;
        private System.Windows.Forms.OpenFileDialog sourceImagesDialog;
        private System.Windows.Forms.Button btnSourceImages;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.ListBox listBoxBmImages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxBmImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxSourceImages;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBoxSourceImages;
        private System.Windows.Forms.PictureBox pictureBoxHighRes;
        private System.Windows.Forms.Button btnApplyImage;
        private System.Windows.Forms.Label labelBmImageSize;
        private System.Windows.Forms.Label labelSourceImageSize;
        private System.Windows.Forms.Button btnCreateRaw;
        private System.Windows.Forms.SaveFileDialog saveBmDialog;
    }
}