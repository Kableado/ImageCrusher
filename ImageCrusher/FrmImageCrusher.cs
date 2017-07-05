using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ImageCrusher
{
    public partial class FrmImageCrusher : Form
    {
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
            txtSize.Text = Properties.Settings.Default.LastSize;
            txtSize.Text = InitialSize.ToString();
        }
        
        private void FrmImageCrusher_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.LastSize = txtSize.Text;
            Properties.Settings.Default.Save();
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
            string path = txtPath.Text;
            if (!Directory.Exists(path))
            {
                MessageBox.Show("El directorio no existe");
                return;
            }

            String destPath;
            if (path.EndsWith("/") || path.EndsWith("\\"))
            {
                path = path.Substring(0, path.Length - 1);
            }
            destPath = String.Format("{0}/small", path);
            string currentPath = path;

            int size = InitialSize;

            lstImagenes_Clean();

            ProcessDirectory(currentPath, path, destPath, size);
            lstImagenes_AddLine("End.");
        }

        private void ProcessDirectory(string currentPath, string path, string destPath, int size)
        {
            string[] fileNames = Directory.GetFiles(currentPath);
            foreach (string fileName in fileNames)
            {
                ProcessFile(fileName, path, destPath, size);
            }
            string[] directories = Directory.GetDirectories(currentPath);
            foreach (string directory in directories)
            {
                ProcessDirectory(directory, path, destPath, size);
            }
        }

        private void ProcessFile(string fileName, string path, string destPath, int size)
        {
            string ext = Path.GetExtension(fileName).ToLower();
            if (ext == ".png" || ext == ".jpg" || ext == ".jpeg")
            {
                try
                {
                    Image img = Image.FromFile(fileName);
                    Image imgThumb = Image_GenerateThumbnail(img, size);

                    string fileDirectory = Path.GetDirectoryName(fileName);
                    fileDirectory = fileDirectory.Replace(path, destPath);
                    if (!Directory.Exists(fileDirectory))
                    {
                        Directory.CreateDirectory(fileDirectory);
                    }
                    string newFileName = String.Format("{0}/{1}.small.jpg", fileDirectory, Path.GetFileNameWithoutExtension(fileName));
                    imgThumb.Save(newFileName, ImageFormat.Jpeg);

                    // Hack: collect garbage now
                    GC.Collect();

                    lstImagenes_AddLine(string.Format("OK: {0}", newFileName));
                }
                catch (Exception ex)
                {
                    lstImagenes_AddLine(string.Format("Error: {0} {1}", fileName, ex.Message));
                }
            }
        }

        private Image Image_GenerateThumbnail(Image img, int size)
        {
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
            Image imgThumb = Image_Resize(img, width, height);
            return imgThumb;
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
