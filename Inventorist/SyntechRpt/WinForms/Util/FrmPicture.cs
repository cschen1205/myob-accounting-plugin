using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Accounting.Bll;
using Accounting.Bll.Util;

namespace SyntechRpt.WinForms.Util
{
    public partial class FrmPicture : Form
    {
        private BOPicture mModel = new BOPicture(AccountantPool.Instance.CurrentAccountant);
        private string mImagePath = null;

        public BOPicture Model
        {
            get { return mModel; }
            set
            {
                mModel = value;
            }
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
            mImagePath = input;
        }

        private void frmPictureInformation_Load(object sender, EventArgs e)
        {
            mImagePath = mModel.GetPropertyValue<string>(BOItem.PICTURE_PATH);
            if (mImagePath != null && System.IO.File.Exists(mImagePath))
            {
                pbItemPicture.Load(mImagePath);
            }
            else
            {
                mImagePath = "";
            }
        }

        private void btnUnlink_Click(object sender, EventArgs e)
        {
            pbItemPicture.Image = null;
            mImagePath = null;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (mImagePath != null && !mImagePath.Equals(""))
            {
                if (System.IO.File.Exists(mImagePath))
                {
                    System.IO.DirectoryInfo dip = new System.IO.DirectoryInfo(mImagePath);
                    mModel.GetPropertyValue<string>(BOItem.PICTURE)=DateTime.Now.ToString("dd-MMM-yy-hh-mm-ss")+dip.Extension;
                    System.IO.File.Copy(mImagePath, mModel.GetPropertyValue<string>(BOItem.PICTURE_PATH));
                }
            }
        }
    }
}