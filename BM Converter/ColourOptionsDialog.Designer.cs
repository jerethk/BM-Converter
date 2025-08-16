namespace BM_Converter
{
    partial class ColourOptionsDialog
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
            label1 = new System.Windows.Forms.Label();
            checkBoxFullbright = new System.Windows.Forms.CheckBox();
            checkBoxCommon = new System.Windows.Forms.CheckBox();
            checkBoxHud = new System.Windows.Forms.CheckBox();
            textBoxExclude = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            btnProceed = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            pictureBoxPal = new System.Windows.Forms.PictureBox();
            labelColour = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPal).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(31, 31);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(156, 15);
            label1.TabIndex = 0;
            label1.Text = "Please confirm PAL options";
            // 
            // checkBoxFullbright
            // 
            checkBoxFullbright.AutoSize = true;
            checkBoxFullbright.Location = new System.Drawing.Point(31, 74);
            checkBoxFullbright.Name = "checkBoxFullbright";
            checkBoxFullbright.Size = new System.Drawing.Size(178, 19);
            checkBoxFullbright.TabIndex = 1;
            checkBoxFullbright.Text = "Use full-bright colours (1-23)";
            checkBoxFullbright.UseVisualStyleBackColor = true;
            // 
            // checkBoxCommon
            // 
            checkBoxCommon.AutoSize = true;
            checkBoxCommon.Location = new System.Drawing.Point(31, 120);
            checkBoxCommon.Name = "checkBoxCommon";
            checkBoxCommon.Size = new System.Drawing.Size(327, 19);
            checkBoxCommon.TabIndex = 2;
            checkBoxCommon.Text = "Only use common PAL colours (exclude colours 208-254)";
            checkBoxCommon.UseVisualStyleBackColor = true;
            // 
            // checkBoxHud
            // 
            checkBoxHud.AutoSize = true;
            checkBoxHud.Location = new System.Drawing.Point(31, 167);
            checkBoxHud.Name = "checkBoxHud";
            checkBoxHud.Size = new System.Drawing.Size(155, 19);
            checkBoxHud.TabIndex = 3;
            checkBoxHud.Text = "Use HUD colours (24-31)";
            checkBoxHud.UseVisualStyleBackColor = true;
            // 
            // textBoxExclude
            // 
            textBoxExclude.Location = new System.Drawing.Point(31, 241);
            textBoxExclude.Name = "textBoxExclude";
            textBoxExclude.Size = new System.Drawing.Size(647, 23);
            textBoxExclude.TabIndex = 4;
            textBoxExclude.Validating += textBoxExclude_Validating;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(31, 218);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(124, 15);
            label2.TabIndex = 5;
            label2.Text = "Exclude these colours:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(31, 271);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(399, 15);
            label3.TabIndex = 6;
            label3.Text = "Example: 40-55, 68, 101 will exclude colours 40 to 55 (inclusive), 68 and 101";
            // 
            // btnProceed
            // 
            btnProceed.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnProceed.Location = new System.Drawing.Point(164, 341);
            btnProceed.Name = "btnProceed";
            btnProceed.Size = new System.Drawing.Size(115, 43);
            btnProceed.TabIndex = 7;
            btnProceed.Text = "Proceed";
            btnProceed.UseVisualStyleBackColor = true;
            btnProceed.Click += btnProceed_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnCancel.Location = new System.Drawing.Point(406, 341);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(115, 43);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // pictureBoxPal
            // 
            pictureBoxPal.BackColor = System.Drawing.SystemColors.Control;
            pictureBoxPal.Location = new System.Drawing.Point(737, 22);
            pictureBoxPal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            pictureBoxPal.MaximumSize = new System.Drawing.Size(512, 512);
            pictureBoxPal.MinimumSize = new System.Drawing.Size(512, 512);
            pictureBoxPal.Name = "pictureBoxPal";
            pictureBoxPal.Size = new System.Drawing.Size(512, 512);
            pictureBoxPal.TabIndex = 9;
            pictureBoxPal.TabStop = false;
            pictureBoxPal.MouseMove += pictureBoxPal_MouseMove;
            // 
            // labelColour
            // 
            labelColour.AutoSize = true;
            labelColour.Location = new System.Drawing.Point(737, 549);
            labelColour.Name = "labelColour";
            labelColour.Size = new System.Drawing.Size(43, 15);
            labelColour.TabIndex = 10;
            labelColour.Text = "Colour";
            // 
            // ColourOptionsDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1274, 605);
            ControlBox = false;
            Controls.Add(labelColour);
            Controls.Add(pictureBoxPal);
            Controls.Add(btnCancel);
            Controls.Add(btnProceed);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBoxExclude);
            Controls.Add(checkBoxHud);
            Controls.Add(checkBoxCommon);
            Controls.Add(checkBoxFullbright);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MinimumSize = new System.Drawing.Size(1290, 644);
            Name = "ColourOptionsDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Colour Options";
            Paint += ColourOptionsDialog_Paint;
            ((System.ComponentModel.ISupportInitialize)pictureBoxPal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxFullbright;
        private System.Windows.Forms.CheckBox checkBoxCommon;
        private System.Windows.Forms.CheckBox checkBoxHud;
        private System.Windows.Forms.TextBox textBoxExclude;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnProceed;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pictureBoxPal;
        private System.Windows.Forms.Label labelColour;
    }
}