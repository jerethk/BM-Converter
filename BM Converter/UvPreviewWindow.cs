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
        private static readonly Pen RedPen = new(Color.Red, 2);

        private int uvWidth = 0;
        private int uvHeight = 0;
        private Bitmap sourceImage;

        public (int uvWidth, int uvHeight) FinalValues { get; set; }

        public UvPreviewWindow(int uvWidth, int uvHeight, Bitmap image)
        {
            this.FinalValues = (uvWidth, uvHeight);
            this.sourceImage = image;
            this.uvWidth = uvWidth;
            this.uvHeight = uvHeight;

            InitializeComponent();

            this.numericUvWidth.Value = this.uvWidth;
            this.numericUvHeight.Value = this.uvHeight;
            this.labelImageSize.Text = $"Image Size: {image.Width} x {image.Height}";
        }

        private void UvPreviewWindow_Shown(object sender, EventArgs e)
        {
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

        private void RepositionGraphic()
        {
            this.displayBox.Width = Math.Max(this.uvWidth + margin * 2, this.panelDisplay.Width - 30);
            this.displayBox.Height = Math.Max(this.uvHeight + margin * 2, this.panelDisplay.Height - 30);

            this.displayBox.Invalidate();
        }

        private void DisplayBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.LightGray);

            int xTiles = this.uvWidth / this.sourceImage.Width + 1;
            int yTiles = this.uvHeight / this.sourceImage.Height + 1;
            (int x, int y) origin = (margin, this.displayBox.Height - margin);

            for (int x = 0; x < xTiles; x++)
            {
                for (int y = 0; y < yTiles; y++)
                {
                    e.Graphics.DrawImage(
                        this.sourceImage,
                        origin.x + this.sourceImage.Width * x,
                        (origin.y - sourceImage.Height) - this.sourceImage.Height * y);
                }
            }

            e.Graphics.DrawRectangle(RedPen, origin.x, origin.y - this.uvHeight, this.uvWidth, this.uvHeight);
        }
    }
}
