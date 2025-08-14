using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BM_Converter
{
    public partial class ColourOptionsDialog : Form
    {
        public bool UseFullBrightColours { get; set; }
        public bool CommonColoursOnly { get; set; }
        public bool UseHudColours { get; set; }


        public ColourOptionsDialog()
        {
            InitializeComponent();
        }

        public void SetValues(bool fullbright, bool commonColours)
        {
            this.checkBoxFullbright.Checked = fullbright;
            this.checkBoxCommon.Checked = commonColours;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            this.UseFullBrightColours = this.checkBoxFullbright.Checked;
            this.CommonColoursOnly = this.checkBoxCommon.Checked;
            this.UseHudColours = this.checkBoxHud.Checked;

            this.DialogResult = DialogResult.OK;
        }
    }
}
