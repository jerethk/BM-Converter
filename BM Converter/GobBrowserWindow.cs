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

    public DFBM BM { get; private set; }
    public string BmName { get; private set; }
    public bool LoadIntoMainWindow { get; private set; }

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

    private void ListBoxBMs_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listBoxBMs.SelectedIndex < 0)
        {
            return;
        }

        if (!File.Exists(this.currentGobPath))
        {
            MessageBox.Show("GOB file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var bmFileName = (listBoxBMs.SelectedItem as GobIndexEntry).NameString;
        if (string.IsNullOrEmpty(bmFileName))
        {
            return;
        }

        var bmFile = Gob.GetFileFromGob(this.currentGobPath, bmFileName);
        if (bmFile == null || bmFile.Length == 0)
        {
            return;
        }

        var bm = new DFBM();

        using (var stream = new MemoryStream(bmFile))
        {
            if (!bm.LoadFromStream(stream))
            {
                MessageBox.Show("Error reading BM.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        this.BM = bm;
        this.BmName = bmFileName;

        var bitmap = bm.IsMultiBM
            ? DFBM.BMtoBitmap(
                bm.SubBMs[0].SizeX,
                bm.SubBMs[0].SizeY,
                bm.SubBMs[0].PixelData,
                this.pal,
                bm.SubBMs[0].IsTransparent())
            : DFBM.BMtoBitmap(
                bm.SizeX,
                bm.SizeY,
                bm.PixelData,
                this.pal,
                bm.IsTransparentOrWeapon());

        if (bitmap != null)
        {
            this.displayBox.Image = bitmap;
        }
    }

    private void BtnClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void BtnLoadBm_Click(object sender, EventArgs e)
    {
        if (this.BM == null)
        {
            return;
        }
        
        this.LoadIntoMainWindow = true;
        this.Close();
    }
}
