namespace BM_Converter
{
    partial class GobBrowserWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GobBrowserWindow));
            openGobDialog = new System.Windows.Forms.OpenFileDialog();
            btnOpenGob = new System.Windows.Forms.Button();
            listBoxBMs = new System.Windows.Forms.ListBox();
            displayBox = new System.Windows.Forms.PictureBox();
            btnClose = new System.Windows.Forms.Button();
            btnLoadBm = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)displayBox).BeginInit();
            SuspendLayout();
            // 
            // openGobDialog
            // 
            openGobDialog.Filter = "GOB Container|*.gob";
            openGobDialog.Title = "Open GOB";
            // 
            // btnOpenGob
            // 
            btnOpenGob.Location = new System.Drawing.Point(24, 23);
            btnOpenGob.Name = "btnOpenGob";
            btnOpenGob.Size = new System.Drawing.Size(89, 27);
            btnOpenGob.TabIndex = 0;
            btnOpenGob.Text = "Open GOB";
            btnOpenGob.UseVisualStyleBackColor = true;
            btnOpenGob.Click += BtnOpenGob_Click;
            // 
            // listBoxBMs
            // 
            listBoxBMs.FormattingEnabled = true;
            listBoxBMs.ItemHeight = 15;
            listBoxBMs.Location = new System.Drawing.Point(24, 72);
            listBoxBMs.Name = "listBoxBMs";
            listBoxBMs.Size = new System.Drawing.Size(171, 559);
            listBoxBMs.TabIndex = 1;
            listBoxBMs.SelectedIndexChanged += ListBoxBMs_SelectedIndexChanged;
            // 
            // displayBox
            // 
            displayBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            displayBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            displayBox.Location = new System.Drawing.Point(239, 96);
            displayBox.Name = "displayBox";
            displayBox.Size = new System.Drawing.Size(539, 535);
            displayBox.TabIndex = 2;
            displayBox.TabStop = false;
            // 
            // btnClose
            // 
            btnClose.Location = new System.Drawing.Point(689, 23);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(89, 27);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            // 
            // btnLoadBm
            // 
            btnLoadBm.Location = new System.Drawing.Point(578, 23);
            btnLoadBm.Name = "btnLoadBm";
            btnLoadBm.Size = new System.Drawing.Size(89, 27);
            btnLoadBm.TabIndex = 4;
            btnLoadBm.Text = "Load BM";
            btnLoadBm.UseVisualStyleBackColor = true;
            btnLoadBm.Click += BtnLoadBm_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(239, 72);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(51, 15);
            label1.TabIndex = 5;
            label1.Text = "Preview:";
            // 
            // GobBrowserWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(804, 661);
            ControlBox = false;
            Controls.Add(label1);
            Controls.Add(btnLoadBm);
            Controls.Add(btnClose);
            Controls.Add(displayBox);
            Controls.Add(listBoxBMs);
            Controls.Add(btnOpenGob);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MinimumSize = new System.Drawing.Size(820, 700);
            Name = "GobBrowserWindow";
            Text = "GOB Browser";
            Shown += GobBrowserWindow_Shown;
            ((System.ComponentModel.ISupportInitialize)displayBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openGobDialog;
        private System.Windows.Forms.Button btnOpenGob;
        private System.Windows.Forms.ListBox listBoxBMs;
        private System.Windows.Forms.PictureBox displayBox;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnLoadBm;
        private System.Windows.Forms.Label label1;
    }
}