using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DacII.Util;
using Accounting.Bll;
using Accounting.Core.TaxCodes;
using Accounting.Core;
using Accounting.Core.Currencies;
using Accounting.Bll.Company;

namespace DacII.WinForms.Setup
{
    using DacII.Presenters;
    using DacII.ViewModels;

    public partial class FrmDataFileInformation : BaseView
    {
        private BOCompany mModel = null;
        private BOViewModel mViewModel = null;
    
        public FrmDataFileInformation(ApplicationPresenter ap, BOCompany model)
            : base(ap)
        {
            InitializeComponent();
            mModel = model;
            mViewModel = new BOViewModel(model);

            BindViews();
            RegisterEventHandlers();
        }

        protected override void BindViews()
        {
            base.BindViews();
        }

        public BOCompany Model
        {
            set
            {
                mModel = value;
                mViewModel.Model = value;
            }
        }

        protected override void LoadView()
        {
            base.LoadView();

            ViewCompanyModel();

            if (!string.IsNullOrEmpty(mModel.DefaultCompanyLogoPath))
            {
                pbPicture.Load(mModel.DefaultCompanyLogoPath);
            }
        }

        private void pbPicture_DoubleClick(object sender, EventArgs e)
        {
            //Create a new instance of the OpenFileDialog because it's an object.
            OpenFileDialog dialog = new OpenFileDialog();

            //Now set the file type
            dialog.Filter = "PNG (*.png)|*.png|All files (*.*)|*.*";

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

            System.IO.File.Copy(input, mModel.DefaultCompanyLogoPath, true);
            pbPicture.Load(input);
        }

        private void ReviseCompanyModel()
        {
            mModel.CompanyName=txtCompanyName.Text;
            mModel.Address=txtAddress.Text;
            mModel.Phone1=txtPhone1.Text;
            mModel.Phone2=txtPhone2.Text;
            mModel.Fax=txtFax.Text;
            mModel.Province=txtProvince.Text;
            mModel.City=txtCity.Text;
            mModel.Country=txtCountry.Text;
            mModel.WebSite=txtWebSite.Text;
            mModel.PostCode=txtPostCode.Text;
            mModel.RegistrationNumber = txtRegistrationNumber.Text;
        }

        private void ViewCompanyModel()
        {
            txtCompanyName.Text = mModel.CompanyName;
            txtAddress.Text = mModel.Address;
            txtPhone1.Text = mModel.Phone1;
            txtPhone2.Text = mModel.Phone2;
            txtFax.Text = mModel.Fax;
            txtEmail.Text = mModel.Email;
            txtProvince.Text = mModel.Province;
            txtCity.Text = mModel.City;
            txtCountry.Text = mModel.Country;
            txtWebSite.Text = mModel.WebSite;
            txtPostCode.Text = mModel.PostCode;
            txtRegistrationNumber.Text = mModel.RegistrationNumber;
        }

        private void btnNewTaxCode_Click(object sender, EventArgs e)
        {
            
           
        }

     

        private void btnCompanyUpdate_Click(object sender, EventArgs e)
        {
            ReviseCompanyModel();
            if (mViewModel.ValidateModel())
            {
                mModel.Record();
                MessageBox.Show("Updated!");
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        private void btnPrintCompany_Click(object sender, EventArgs e)
        {
            mApplicationController.PrintCompany();
        }

     
        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }
    }
}