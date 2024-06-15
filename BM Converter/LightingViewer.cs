using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BM_Converter
{
    public partial class LightingViewer : Form
    {
        private DFPal pal;
        private DFCmp cmp;
        private DFBM bm;
        private int subBm;

        public LightingViewer(DFPal pal, DFCmp cmp, DFBM bm, int subBm)
        {
            InitializeComponent();

            this.pal = pal;
            this.cmp = cmp;
            this.bm = bm;
            this.subBm = subBm;
            this.numericLight.Value = 31;
        }

        private async void LightingViewer_Shown(object sender, EventArgs e)
        {
            await Task.Delay(100);
            this.UpdateDisplay();
        }

        private void numericLight_ValueChanged(object sender, EventArgs e)
        {
            this.UpdateDisplay();
        }

        private void checkBoxZoom_CheckedChanged(object sender, EventArgs e)
        {
            this.displayBox.SizeMode = this.checkBoxZoom.Checked
                ? PictureBoxSizeMode.Zoom
                : PictureBoxSizeMode.Normal;
        }

        private void UpdateDisplay()
        {
            var light = (int)numericLight.Value;
            if (light < 0 )
            {
                light = 0;
            }
            if (light > 31)
            {
                light = 31;
            }

            // Generate a temp pal to use
            var tempPal = new DFPal();
            for (int c = 0; c < 256; c++)
            {
                tempPal.Colours[c].R = this.pal.Colours[this.cmp.Colourmap[light, c]].R;
                tempPal.Colours[c].G = this.pal.Colours[this.cmp.Colourmap[light, c]].G;
                tempPal.Colours[c].B = this.pal.Colours[this.cmp.Colourmap[light, c]].B;
            }

            if (!this.bm.IsMultiBM)
            {
                this.displayBox.Image = DFBM.BMtoBitmap(
                    this.bm.SizeX,
                    this.bm.SizeY,
                    this.bm.PixelData,
                    tempPal,
                    this.bm.IsTransparentOrWeapon());
            }
            else
            {
                this.displayBox.Image = DFBM.BMtoBitmap(
                    this.bm.SubBMs[this.subBm].SizeX,
                    this.bm.SubBMs[this.subBm].SizeY,
                    this.bm.SubBMs[this.subBm].PixelData,
                    tempPal,
                    this.bm.SubBMs[this.subBm].IsTransparent());
            }
        }
    }
}

