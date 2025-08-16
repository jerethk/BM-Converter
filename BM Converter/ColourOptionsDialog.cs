using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BM_Converter
{
    public partial class ColourOptionsDialog : Form
    {
        public bool UseFullBrightColours { get; set; }
        public bool CommonColoursOnly { get; set; }
        public bool UseHudColours { get; set; }
        public List<int> ColoursToExclude { get; set; }

        private DFPal pal;
        private static readonly int ColourRectSize = 32;

        public ColourOptionsDialog()
        {
            InitializeComponent();
            this.ColoursToExclude = new();
        }

        public void SetValues(bool fullbright, bool commonColours, DFPal pal)
        {
            this.checkBoxFullbright.Checked = fullbright;
            this.checkBoxCommon.Checked = commonColours;
            this.pal = pal;

            this.DrawPal();
        }

        private async void DrawPal()
        {
            if (this.pal == null) { return; }

            // there needs to be a delay before the graphic can be drawn
            await Task.Delay(100);

            Graphics gra = this.pictureBoxPal.CreateGraphics();
            var brush = new SolidBrush(Color.Black);

            for (var y = 0; y < 16; y++)
            {
                for (var x = 0; x < 16; x++)
                {
                    var colour = this.pal.Colours[y * 16 + x];
                    brush.Color = Color.FromArgb(255, colour.R, colour.G, colour.B);
                    gra.FillRectangle(brush, x * ColourRectSize, y * ColourRectSize, ColourRectSize, ColourRectSize);
                }
            }
        }

        private void pictureBoxPal_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.pal == null) { return; }

            var colourIndex = (e.Y / ColourRectSize) * 16 + (e.X / ColourRectSize);
            var colour = this.pal.Colours[colourIndex];
            this.labelColour.Text = $"Colour {colourIndex}: R{colour.R}, G{colour.G}, B{colour.B}";
        }

        private void textBoxExclude_Validating(object sender, CancelEventArgs e)
        {
            var sanitisedText = string.Empty;

            foreach (var c in textBoxExclude.Text.Trim())
            {
                if (char.IsDigit(c) || char.IsWhiteSpace(c) || c == ',' || c == '-')
                {
                    sanitisedText += c;
                }
            }

            textBoxExclude.Text = sanitisedText;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (!this.TryParseColoursToExclude())
            {
                MessageBox.Show("Unable to parse colours to exclude.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.UseFullBrightColours = this.checkBoxFullbright.Checked;
            this.CommonColoursOnly = this.checkBoxCommon.Checked;
            this.UseHudColours = this.checkBoxHud.Checked;

            this.DialogResult = DialogResult.OK;
        }

        private bool TryParseColoursToExclude()
        {
            this.ColoursToExclude.Clear();

            // Remove whitespace
            var text = Regex.Replace(textBoxExclude.Text.Trim(), @"\s+", "");

            if (string.IsNullOrEmpty(text))
            {
                return true;
            }

            // Revalidate - check for any character that is not a number, comma or hyphen
            if (text.Any(c => !char.IsDigit(c) && !char.IsWhiteSpace(c) && c != ',' && c != '-'))
            {
                return false;
            }

            var splitText = text.Split(',');
            var coloursToExclude = new List<int>();
            foreach (var item in splitText)
            {
                // A single number
                if (Regex.IsMatch(item, @"^\d+$"))
                {
                    int colour;
                    if (Int32.TryParse(item, out colour))
                    {
                        coloursToExclude.Add(colour);
                        continue;
                    }
                }

                // A range of numbers
                if (Regex.IsMatch(item, @"^\d+-\d+$"))
                {
                    var splitItem = item.Split('-');
                    if (splitItem.Length != 2)
                    {
                        return false;   // this shouldn't happen, but just in case....
                    }

                    int startRange;
                    int endRange;
                    if (Int32.TryParse(splitItem[0], out startRange) && Int32.TryParse(splitItem[1], out endRange))
                    {
                        for (int colour = startRange; colour <= endRange; colour++)
                        {
                            coloursToExclude.Add(colour);
                        }
                        continue;
                    }
                }

                return false;
            }

            this.ColoursToExclude = coloursToExclude.Distinct().Where(c => c < 256).ToList();
            return true;
        }
    }
}
