using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BM_Converter;

public partial class GobBrowserWindow : Form
{
    private GobBrowserWindow()
    {
        InitializeComponent();
    }
    
    public GobBrowserWindow(DFPal pal) : this()
    {
        this.pal = pal;
    }

    private DFPal pal;
    private string currentGobPath;
    private List<GobIndexEntry> bmList;

    private void GobBrowserWindow_Shown(object sender, EventArgs e)
    {
        this.OpenGob();
    }

    private void BtnOpenGob_Click(object sender, EventArgs e)
    {
        this.OpenGob();
    }

    private void OpenGob()
    {
        var dialogResult = this.openGobDialog.ShowDialog();
        if (dialogResult == DialogResult.OK)
        {
            var gobIndex = Gob.GetGobIndex(this.openGobDialog.FileName);

            if (gobIndex.Count == 0)
            {
                MessageBox.Show("No files read from GOB.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var bmList = gobIndex.Where(entry =>
            {
                var extension = Path.GetExtension(entry.NameString);
                return extension.Equals(".bm", StringComparison.OrdinalIgnoreCase);
            }).OrderBy(entry => entry.NameString).ToList();

            if (!bmList.Any())
            {
                MessageBox.Show($"{this.openGobDialog.FileName} does not contain any BM files.", "No textures", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.currentGobPath = this.openGobDialog.FileName;
            this.bmList = bmList;
            this.listBoxBMs.DataSource = this.bmList;
            this.listBoxBMs.DisplayMember = nameof(GobIndexEntry.NameString);
        }
    }
}
