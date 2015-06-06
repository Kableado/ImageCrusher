using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ImageCrusher
{
    public partial class FrmImageCrusher : Form
    {
        string _initialPath = string.Empty;

        private void Initialize()
        {
            InitializeComponent();
            txtPath.Text = _initialPath;
        }

        public string InitialPath
        {
            get { return txtPath.Text; }
            set { txtPath.Text = value; }
        }

        public int InitialSize
        {
            get
            {
                int size;
                if (!int.TryParse(txtSize.Text, out size))
                {
                    size = 640;
                }
                return size;
            }
            set { txtSize.Text = value.ToString(); }
        }

        public FrmImageCrusher()
        {
            InitializeComponent();
            txtPath.Text = Directory.GetCurrentDirectory();
            txtSize.Text = InitialSize.ToString();
        }

        private void lstImagenes_Clean()
        {
            lstImagenes.Items.Clear();
        }

        private void lstImagenes_AddLine(string line)
        {
            lstImagenes.Items.Add(line);

            Application.DoEvents();

            int visibleItems = lstImagenes.ClientSize.Height / lstImagenes.ItemHeight;
            lstImagenes.TopIndex = Math.Max(lstImagenes.Items.Count - visibleItems + 1, 0);
        }

        private void btnCrush_Click(object sender, EventArgs e)
        {
            string path=txtPath.Text;
            if (!Directory.Exists(path))
            {
                MessageBox.Show("El directorio no existe");
                return;
            }

            String destPath = String.Format("{0}/small", path);
            int size = InitialSize;

            lstImagenes_Clean();

            string[] fileNames = Directory.GetFiles(path);
            foreach (string fileName in fileNames)
            {
                string ext = Path.GetExtension(fileName).ToLower();
                if (ext == ".png" || ext == ".jpg" || ext == ".jpeg")
                {
                    try
                    {
                        Image img = Image.FromFile(fileName);
                        int width = img.Width;
                        int height = img.Height;
                        if (width > height)
                        {
                            height = (int)(height / (width / (double)size));
                            width = size;
                        }
                        else
                        {
                            width = (int)(width / (height / (double)size));
                            height = size;
                        }

                        if (!Directory.Exists(destPath))
                        {
                            Directory.CreateDirectory(destPath);
                        }

                        Image imgThumb = Image_Resize(img, width, height);
                        string newFileName = String.Format("{0}/{1}.small.jpg", destPath, Path.GetFileNameWithoutExtension(fileName));
                        imgThumb.Save(newFileName, ImageFormat.Jpeg);

                        lstImagenes_AddLine(string.Format("OK: {0}", newFileName));
                    }
                    catch (Exception ex)
                    {
                        lstImagenes_AddLine(string.Format("Error: {0} {1}", fileName, ex.Message));
                    }
                }
            }
            lstImagenes_AddLine("End.");
        }


        public Image Image_Resize(Image img, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            Graphics imgGraph = Graphics.FromImage(bitmap);
            imgGraph.CompositingQuality = CompositingQuality.HighQuality;
            imgGraph.SmoothingMode = SmoothingMode.HighQuality;
            imgGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imgDimesions = new Rectangle(0, 0, width, height);
            imgGraph.DrawImage(img, imgDimesions);
            return bitmap;
        }
    }
}
