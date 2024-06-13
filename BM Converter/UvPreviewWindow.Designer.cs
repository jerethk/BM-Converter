namespace BM_Converter
{
    partial class UvPreviewWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UvPreviewWindow));
            label4 = new System.Windows.Forms.Label();
            numericUvHeight = new System.Windows.Forms.NumericUpDown();
            label3 = new System.Windows.Forms.Label();
            numericUvWidth = new System.Windows.Forms.NumericUpDown();
            panel1 = new System.Windows.Forms.Panel();
            labelImageSize = new System.Windows.Forms.Label();
            btnDiscard = new System.Windows.Forms.Button();
            btnAccept = new System.Windows.Forms.Button();
            panel2 = new System.Windows.Forms.Panel();
            displayBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)numericUvHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUvWidth).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)displayBox).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(153, 21);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(59, 15);
            label4.TabIndex = 7;
            label4.Text = "UV height";
            // 
            // numericUvHeight
            // 
            numericUvHeight.Location = new System.Drawing.Point(153, 49);
            numericUvHeight.Maximum = new decimal(new int[] { 2048, 0, 0, 0 });
            numericUvHeight.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUvHeight.Name = "numericUvHeight";
            numericUvHeight.Size = new System.Drawing.Size(120, 23);
            numericUvHeight.TabIndex = 6;
            numericUvHeight.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUvHeight.ValueChanged += numericUvHeight_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(19, 21);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(55, 15);
            label3.TabIndex = 5;
            label3.Text = "UV width";
            // 
            // numericUvWidth
            // 
            numericUvWidth.Location = new System.Drawing.Point(19, 49);
            numericUvWidth.Maximum = new decimal(new int[] { 2048, 0, 0, 0 });
            numericUvWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUvWidth.Name = "numericUvWidth";
            numericUvWidth.Size = new System.Drawing.Size(120, 23);
            numericUvWidth.TabIndex = 4;
            numericUvWidth.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUvWidth.ValueChanged += numericUvWidth_ValueChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(labelImageSize);
            panel1.Controls.Add(btnDiscard);
            panel1.Controls.Add(btnAccept);
            panel1.Controls.Add(numericUvWidth);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(numericUvHeight);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(984, 110);
            panel1.TabIndex = 8;
            // 
            // labelImageSize
            // 
            labelImageSize.AutoSize = true;
            labelImageSize.Location = new System.Drawing.Point(326, 51);
            labelImageSize.Name = "labelImageSize";
            labelImageSize.Size = new System.Drawing.Size(66, 15);
            labelImageSize.TabIndex = 10;
            labelImageSize.Text = "Image Size:";
            // 
            // btnDiscard
            // 
            btnDiscard.Location = new System.Drawing.Point(838, 38);
            btnDiscard.Name = "btnDiscard";
            btnDiscard.Size = new System.Drawing.Size(106, 40);
            btnDiscard.TabIndex = 9;
            btnDiscard.Text = "Discard";
            btnDiscard.UseVisualStyleBackColor = true;
            btnDiscard.Click += btnDiscard_Click;
            // 
            // btnAccept
            // 
            btnAccept.Location = new System.Drawing.Point(705, 38);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new System.Drawing.Size(106, 40);
            btnAccept.TabIndex = 8;
            btnAccept.Text = "Accept";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.BackColor = System.Drawing.SystemColors.Control;
            panel2.Controls.Add(displayBox);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 110);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(984, 691);
            panel2.TabIndex = 9;
            // 
            // displayBox
            // 
            displayBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            displayBox.BackColor = System.Drawing.Color.LightGray;
            displayBox.Location = new System.Drawing.Point(19, 23);
            displayBox.Name = "displayBox";
            displayBox.Size = new System.Drawing.Size(937, 644);
            displayBox.TabIndex = 0;
            displayBox.TabStop = false;
            displayBox.Resize += displayBox_Resize;
            // 
            // UvPreviewWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(984, 801);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MinimumSize = new System.Drawing.Size(1000, 840);
            Name = "UvPreviewWindow";
            Text = "3DO UV dimensions";
            Shown += UvPreviewWindow_Shown;
            ((System.ComponentModel.ISupportInitialize)numericUvHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUvWidth).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)displayBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUvHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUvWidth;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnDiscard;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox displayBox;
        private System.Windows.Forms.Label labelImageSize;
    }
}