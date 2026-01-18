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
            SuspendLayout();
            // 
            // openGobDialog
            // 
            openGobDialog.Filter = "GOB Container|*.gob";
            openGobDialog.Title = "Open GOB";
            // 
            // btnOpenGob
            // 
            btnOpenGob.Location = new System.Drawing.Point(59, 24);
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
            listBoxBMs.Size = new System.Drawing.Size(157, 394);
            listBoxBMs.TabIndex = 1;
            // 
            // GobBrowserWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 539);
            Controls.Add(listBoxBMs);
            Controls.Add(btnOpenGob);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "GobBrowserWindow";
            Text = "GOB Browser";
            Shown += GobBrowserWindow_Shown;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openGobDialog;
        private System.Windows.Forms.Button btnOpenGob;
        private System.Windows.Forms.ListBox listBoxBMs;
    }
}