using System;
using System.Drawing;
using System.Windows.Forms;

namespace DacII.WinForms.Util
{
    using System.IO;
    using DacII.Presenters;
    using BarcodeReader;
    using PdfToImage;

    public partial class FrmReadBarcode : BaseView
    {
        public delegate void BarcodeReadHandler(string barcode);
        public event BarcodeReadHandler BarcodeRead;

        private void OnBarcodeRead(string barcode)
        {
            if (BarcodeRead != null)
            {
                BarcodeRead(barcode);
            }
        }
        public FrmReadBarcode(ApplicationPresenter ap)
            : base(ap)
        {
            InitializeComponent();
            ilSmall.Images.Add(global::DacII.Properties.Resources.barcode_48x48);
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            string curr_dir = Directory.GetCurrentDirectory();
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "PDF Files (*.pdf)|*.pdf|TIFF Files (*.tif)|*.tif|JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|All Files (*.*)|*.*";
            DialogResult result = dlg.ShowDialog();
            string filename="";
            if (result == DialogResult.OK)
            {
               filename=dlg.FileName;
            }
            Directory.SetCurrentDirectory(curr_dir);
            if(Path.GetExtension(filename).ToLower()==".pdf")
            {
                filename = ConvertPdf2Img(filename);
            }

            //Console.Write(filename);

            if (!File.Exists(filename))
            {
                MessageBox.Show(string.Format("Could not file the image file {0}", filename));
                return;
            }

            picBox.Image = Image.FromFile(filename);

            System.Collections.ArrayList barcodes = new System.Collections.ArrayList();
            DateTime dtStart = DateTime.Now;
            int iScans = 100;


            BarcodeImaging.FullScanPage(ref barcodes, (Bitmap)picBox.Image, iScans);
            ShowResults(dtStart, iScans, barcodes);
        }

        private string ConvertPdf2Img(string filename)
        {

            if (!System.IO.File.Exists(Application.StartupPath + "\\gsdll32.dll"))
            {
                //lblDllInfo.Font = new Font(lblDllInfo.Font.FontFamily, 10, FontStyle.Bold);
                //lblDllInfo.ForeColor = Color.Red;
                lblStatus.Text = "Download: http://mirror.cs.wisc.edu/pub/mirrors/ghost/GPL/gs863/gs863w32.exe";
                MessageBox.Show("The library 'gsdll32.dll' required to run this program is not present! download GhostScript and copy \"gsdll32.dll\" to this program directory");
                return "";
            }

            //This is the object that perform the real conversion!
            PDFConvert converter = new PDFConvert();

              //Ok now check what version is!
            GhostScriptRevision version = converter.GetRevision();

            //lblVersion.Text = version.intRevision.ToString() + " " + version.intRevisionDate;
            bool Converted = false;
            //Setup the converter
            //Setup the converter
            converter.RenderingThreads = -1;
            converter.TextAlphaBit = -1;
            converter.TextAlphaBit = -1;
            
            converter.FitPage = false;
            converter.JPEGQuality = 10;
            converter.OutputFormat = "png256";
            converter.ResolutionX = 500;
            converter.ResolutionY = 500;

            converter.OutputToMultipleFile = false;
            converter.FirstPageToConvert = -1;
            converter.LastPageToConvert = -1;
            
            System.IO.FileInfo input = new FileInfo(filename);

            //string output = string.Format("{0}\\Images\\tmp\\{1}{2}", Application.StartupPath, DateTime.Now.ToString("yyyyMMddHHmmss"), ".png");
            string output = string.Format("{0}\\Images\\tmp\\{1}{2}", Application.StartupPath, DateTime.Now.ToString("yyyyMMddHHmmss"), ".png");
            int indexer = 0;
            while (File.Exists(output))
            {
                output = string.Format("{0}\\Images\\tmp\\{1}{2}{3}", Application.StartupPath, DateTime.Now.ToString("yyyyMMddHHmmss"), indexer++, ".png");
            }
            
            //If the output file exist alrady be sure to add a random name at the end until is unique!
           
            //Just avoid this code, isn't working yet
            //if (checkRedirect.Checked)
            //{
            //    Image newImage = converter.Convert(input.FullName);
            //    Converted = (newImage != null);
            //    if (Converted)
            //        pictureOutput.Image = newImage;
            //}
            //else 
            converter.GSPath = string.Format("{0}\\gs", Application.StartupPath);
            Converted = converter.Convert(input.FullName, output);
            //txtArguments.Text = converter.ParametersUsed;
            //if (Converted)
            //{
            //    lblInfo.Text = string.Format("{0}:File converted!", DateTime.Now.ToShortTimeString());
            //    txtArguments.ForeColor = Color.Black;
            //}
            //else
            //{
            //    lblInfo.Text = string.Format("{0}:File NOT converted! Check Args!", DateTime.Now.ToShortTimeString());
            //    txtArguments.ForeColor = Color.Red;
            //}

            return output;
        }


        public void ShowResults(DateTime dtStart, int iScans, System.Collections.ArrayList barcodes)
        {
            lvBarcodes.Items.Clear();

            string message = "Completed " + iScans.ToString() + " scans in " + DateTime.Now.Subtract(dtStart).TotalSeconds.ToString("#0.00") + " seconds. ";
            if (barcodes.Count == 0)
            {
                message += "Failed to find a barcode.";
                lblStatus.Text = message;
                return;
            }
                
            message += string.Format("Found barcodes: {0}", barcodes.Count);
            lblStatus.Text = message;

            foreach (object bc in barcodes)
            {
                lvBarcodes.Items.Add(string.Format("{0}", bc), 0);
            }

            MessageBox.Show(message);
        }

        private void lvBarcodes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvBarcodes.SelectedItems.Count == 0)
            {
                return;
            }
            OnBarcodeRead(lvBarcodes.SelectedItems[0].Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }
    }
}
