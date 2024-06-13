using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BM_Converter
{
    public partial class UvPreviewWindow : Form
    {
        private const int margin = 5;

        private Bitmap sourceImage;
        private Graphics graphics;

        public (int uvWidth, int uvHeight) FinalValues { get; set; }

        public UvPreviewWindow(int uvWidth, int uvHeight, Bitmap image)
        {
            InitializeComponent();

            this.FinalValues = (uvWidth, uvHeight);
            this.numericUvWidth.Value = uvWidth;
            this.numericUvHeight.Value = uvHeight;
            this.graphics = this.displayBox.CreateGraphics();
            this.sourceImage = image;
        }

        private void UvPreviewWindow_Shown(object sender, EventArgs e)
        {
            this.Redraw();
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.FinalValues = ((int)this.numericUvWidth.Value, (int)this.numericUvHeight.Value);
            this.Close();
        }

        private void displayBox_Resize(object sender, EventArgs e)
        {
            this.Redraw();
        }

        private void Redraw()
        {
            (int x, int y) origin = (margin, this.displayBox.Height - margin);
            this.graphics.Clear(Color.LightGray);

            this.graphics.DrawImage(this.sourceImage, origin.x, origin.y - sourceImage.Height);
        }
    }
}
