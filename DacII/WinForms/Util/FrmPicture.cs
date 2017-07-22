using System;
using System.Windows.Forms;

namespace DacII.WinForms.Util
{
    using System.IO;
    public partial class FrmPicture : Form
    {
        private string mResultantPicture = null;
        private string mInitialPicture = null;

        private string mPictureDirectory;
        public string PictureDirectory
        {
            get { return mPictureDirectory; }
            set { mPictureDirectory = value; }
        }

        public string ResultantPicture
        {
            set { mResultantPicture = value; }
            get { return mResultantPicture; }
        }

        public string ResultantPictureName
        {
            get
            {
                if (string.IsNullOrEmpty(mResultantPicture) || !File.Exists(mResultantPicture))
                {
                    return null;
                }
                return (new FileInfo(mResultantPicture)).Name;
            }
        }

        public string InitialPicture
        {
            set { mInitialPicture = value; }
            get { return mInitialPicture; }
        }

        public FrmPicture()
        {
            InitializeComponent();
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            //Create a new instance of the OpenFileDialog because it's an object.
            OpenFileDialog dialog = new OpenFileDialog();

            //Now set the file type
            dialog.Filter = "JPEG (*.jpg)|*.jpg|PNG (*.png)|*.png|BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif|All files (*.*)|*.*";

            //Set the starting directory and the title.
            dialog.InitialDirectory = "C:"; 
            dialog.Title = "Link a picture";

            String input = string.Empty;
            //Present to the user.
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                input = dialog.FileName;
            }
            if (input == String.Empty)
            {
                return;//user didn't select a file
            }
            pbItemPicture.Load(input);
            mResultantPicture = input;
        }

        private void frmPictureInformation_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mInitialPicture) && File.Exists(mInitialPicture))
            {
                pbItemPicture.Load(mInitialPicture);
            }
        }

        private void btnUnlink_Click(object sender, EventArgs e)
        {
            pbItemPicture.Image = null;
            mResultantPicture = null;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mResultantPicture) && System.IO.File.Exists(mResultantPicture))
            {
                System.IO.DirectoryInfo dip = new System.IO.DirectoryInfo(mResultantPicture);
                string filename=(new FileInfo(mResultantPicture)).Name;
                string destpath=string.Format("{0}{1}{2}", mPictureDirectory, System.IO.Path.DirectorySeparatorChar, filename);
                //MessageBox.Show(destpath);
                System.IO.File.Copy(mResultantPicture, destpath, true);
            }
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}