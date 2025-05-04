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

        private int uvWidth = 0;
        private int uvHeight = 0;
        private Bitmap sourceImage;
        private Graphics graphics;

        public (int uvWidth, int uvHeight) FinalValues { get; set; }

        public UvPreviewWindow(int uvWidth, int uvHeight, Bitmap image)
        {
            InitializeComponent();

            this.FinalValues = (uvWidth, uvHeight);
            this.graphics = this.displayBox.CreateGraphics();
            this.sourceImage = image;
            this.uvWidth = uvWidth;
            this.uvHeight = uvHeight;
            this.numericUvWidth.Value = this.uvWidth;
            this.numericUvHeight.Value = this.uvHeight;
            this.labelImageSize.Text = $"Image Size: {image.Width} x {image.Height}";
        }

        private async void UvPreviewWindow_Shown(object sender, EventArgs e)
        {
            // for some reason there needs to be a delay before the graphic can be drawn
            await Task.Delay(100);
            this.RepositionGraphic();
        }

        private void numericUvWidth_ValueChanged(object sender, EventArgs e)
        {
            this.uvWidth = (int)this.numericUvWidth.Value;
            this.RepositionGraphic();
        }

        private void numericUvHeight_ValueChanged(object sender, EventArgs e)
        {
            this.uvHeight = (int)this.numericUvHeight.Value;
            this.RepositionGraphic();
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.FinalValues = (this.uvWidth, this.uvHeight);
            this.Close();
        }

        private void UvPreviewWindow_Resize(object sender, EventArgs e)
        {
            this.RepositionGraphic();
        }

        private void panelDisplay_Scroll(object sender, ScrollEventArgs e)
        {
            this.Redraw();
        }

        private void RepositionGraphic()
        {
            this.displayBox.Width = Math.Max(this.uvWidth + margin * 2, this.panelDisplay.Width - 20);
            this.displayBox.Height = Math.Max(this.uvHeight + margin * 2, this.panelDisplay.Height - 20);

            this.graphics.Clear(Color.LightGray);
            this.graphics.Dispose();
            this.graphics = this.displayBox.CreateGraphics();
            this.Redraw();
        }

        private void Redraw()
        {
            int xTiles = this.uvWidth / this.sourceImage.Width + 1;
            int yTiles = this.uvHeight / this.sourceImage.Height + 1;
            (int x, int y) origin = (margin, this.displayBox.Height - margin);

            for (int x = 0; x < xTiles; x++)
            {
                for (int y = 0; y < yTiles; y++)
                {
                    this.graphics.DrawImage(
                        this.sourceImage,
                        origin.x + this.sourceImage.Width * x,
                        (origin.y - sourceImage.Height) - this.sourceImage.Height * y);
                }
            }

            var pen = new Pen(Color.Red, 2);
            this.graphics.DrawRectangle(pen, origin.x, origin.y - this.uvHeight, this.uvWidth, this.uvHeight);
        }

        private async void panelDisplay_Paint(object sender, PaintEventArgs e)
        {
            await Task.Delay(100);
            this.Redraw();
        }
    }
}
