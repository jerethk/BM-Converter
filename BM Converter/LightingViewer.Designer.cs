namespace BM_Converter
{
    partial class LightingViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LightingViewer));
            label1 = new System.Windows.Forms.Label();
            numericLight = new System.Windows.Forms.NumericUpDown();
            displayBox = new System.Windows.Forms.PictureBox();
            checkBoxZoom = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)numericLight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)displayBox).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(25, 22);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(61, 15);
            label1.TabIndex = 0;
            label1.Text = "Light level";
            // 
            // numericLight
            // 
            numericLight.Location = new System.Drawing.Point(114, 20);
            numericLight.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            numericLight.Name = "numericLight";
            numericLight.Size = new System.Drawing.Size(107, 23);
            numericLight.TabIndex = 1;
            numericLight.Value = new decimal(new int[] { 31, 0, 0, 0 });
            numericLight.ValueChanged += numericLight_ValueChanged;
            // 
            // displayBox
            // 
            displayBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            displayBox.BackColor = System.Drawing.Color.Silver;
            displayBox.Location = new System.Drawing.Point(25, 64);
            displayBox.Name = "displayBox";
            displayBox.Size = new System.Drawing.Size(652, 541);
            displayBox.TabIndex = 2;
            displayBox.TabStop = false;
            // 
            // checkBoxZoom
            // 
            checkBoxZoom.AutoSize = true;
            checkBoxZoom.Location = new System.Drawing.Point(557, 18);
            checkBoxZoom.Name = "checkBoxZoom";
            checkBoxZoom.Size = new System.Drawing.Size(86, 19);
            checkBoxZoom.TabIndex = 3;
            checkBoxZoom.Text = "Zoom to fit";
            checkBoxZoom.UseVisualStyleBackColor = true;
            checkBoxZoom.CheckedChanged += checkBoxZoom_CheckedChanged;
            // 
            // LightingViewer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(704, 681);
            Controls.Add(checkBoxZoom);
            Controls.Add(displayBox);
            Controls.Add(numericLight);
            Controls.Add(label1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MinimumSize = new System.Drawing.Size(720, 720);
            Name = "LightingViewer";
            Text = "LightingViewer";
            Shown += LightingViewer_Shown;
            ((System.ComponentModel.ISupportInitialize)numericLight).EndInit();
            ((System.ComponentModel.ISupportInitialize)displayBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericLight;
        private System.Windows.Forms.PictureBox displayBox;
        private System.Windows.Forms.CheckBox checkBoxZoom;
    }
}