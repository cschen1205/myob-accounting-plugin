using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SyntechRpt.Util;
using Accounting.Bll;
using Accounting.Bll.Cards;
using Accounting.Core.TaxCodes;
using Accounting.Core.Definitions;
using Accounting.Core.Cards;

namespace SyntechRpt.WinForms.Cards
{
    public partial class FrmEmployee : Form
    {
        private BOEmployee mModel=null;

        public BOEmployee Model
        {
            set
            {
                mModel = value;
                mModel.Revised += new BOEmployee.RevisedHandler(mModel_Revised);
            }
        }

        void mModel_Revised()
        {
            
        }

        public FrmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            cboCurrencyCode.DataSource = mModel.List("Currency");
            if (cboCurrencyCode.Items.Count > 0) cboCurrencyCode.SelectedIndex = 0;
            cboGender.DataSource = mModel.List("Gender");
            if (cboGender.Items.Count > 0) cboGender.SelectedIndex = 0;

            if (mModel.RecordContext == BusinessObject.BOContext.Record_Create)
            {
                UI_Clear();
            }
            else
            {
                ViewModel();
            }
        }

        private void ViewModel()
        {
            txtEmployeeCardID.Text = mModel.CardIdentification;
            txtFirstName.Text = mModel.FirstName;
            txtLastName.Text = mModel.LastName;

            chkActive.Checked = mModel.IsActive;
            chkIndividual.Checked = mModel.IsIndividual;

            cboCurrencyCode.SelectedItem = mModel.Currency;
            cboGender.SelectedItem = mModel.Gender;

            Address adr = mModel.Address1;
            txtAddressLine11.Text = adr.StreetLine1;
            txtAddressLine12.Text = adr.StreetLine2;
            txtAddressLine13.Text = adr.StreetLine3;
            txtAddressLine14.Text = adr.StreetLine4;
            txtPhone11.Text = adr.Phone1;
            txtPhone21.Text = adr.Phone2;
            txtCity1.Text = adr.City;
            txtCountry1.Text = adr.Country;
            txtEmail1.Text = adr.Email;
            txtWeb1.Text = adr.Website;
            txtFax1.Text = adr.Fax;
            txtContact1.Text = adr.ContactName;

            adr = mModel.Address2;
            txtAddressLine21.Text = adr.StreetLine1;
            txtAddressLine22.Text = adr.StreetLine2;
            txtAddressLine23.Text = adr.StreetLine3;
            txtAddressLine24.Text = adr.StreetLine4;
            txtPhone12.Text = adr.Phone1;
            txtPhone22.Text = adr.Phone2;
            txtCity2.Text = adr.City;
            txtCountry2.Text = adr.Country;
            txtEmail2.Text = adr.Email;
            txtWeb2.Text = adr.Website;
            txtFax2.Text = adr.Fax;
            txtContact2.Text = adr.ContactName;

            adr = mModel.Address3;
            txtAddressLine31.Text = adr.StreetLine1;
            txtAddressLine32.Text = adr.StreetLine2;
            txtAddressLine33.Text = adr.StreetLine3;
            txtAddressLine34.Text = adr.StreetLine4;
            txtPhone13.Text = adr.Phone1;
            txtPhone23.Text = adr.Phone2;
            txtCity3.Text = adr.City;
            txtCountry3.Text = adr.Country;
            txtEmail3.Text = adr.Email;
            txtWeb3.Text = adr.Website;
            txtFax3.Text = adr.Fax;
            txtContact3.Text = adr.ContactName;

            adr = mModel.Address4;
            txtAddressLine41.Text = adr.StreetLine1;
            txtAddressLine42.Text = adr.StreetLine2;
            txtAddressLine43.Text = adr.StreetLine3;
            txtAddressLine44.Text = adr.StreetLine4;
            txtPhone14.Text = adr.Phone1;
            txtPhone24.Text = adr.Phone2;
            txtCity4.Text = adr.City;
            txtCountry4.Text = adr.Country;
            txtEmail4.Text = adr.Email;
            txtWeb4.Text = adr.Website;
            txtFax4.Text = adr.Fax;
            txtContact4.Text = adr.ContactName;

            adr = mModel.Address5;
            txtAddressLine51.Text = adr.StreetLine1;
            txtAddressLine52.Text = adr.StreetLine2;
            txtAddressLine53.Text = adr.StreetLine3;
            txtAddressLine54.Text = adr.StreetLine4;
            txtPhone15.Text = adr.Phone1;
            txtPhone25.Text = adr.Phone2;
            txtCity5.Text = adr.City;
            txtCountry5.Text = adr.Country;
            txtEmail5.Text = adr.Email;
            txtWeb5.Text = adr.Website;
            txtFax5.Text = adr.Fax;
            txtContact5.Text = adr.ContactName;
        }

        private void UI_Clear()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";

            txtCity1.Text = "";
            txtCountry1.Text = "";
            txtEmail1.Text = "";
            txtPhone11.Text = "";
            txtPhone21.Text = "";
            txtEmployeeCardID.Text = "";
            txtWeb1.Text = "";
            txtContact1.Text = "";
            txtMobile1.Text = "";
            txtFax1.Text = "";

            txtCity2.Text = "";
            txtCountry2.Text = "";
            txtEmail2.Text = "";
            txtPhone12.Text = "";
            txtPhone22.Text = "";
            txtEmployeeCardID.Text = "";
            txtWeb2.Text = "";
            txtContact2.Text = "";
            txtMobile2.Text = "";
            txtFax2.Text = "";

            txtCity3.Text = "";
            txtCountry3.Text = "";
            txtEmail3.Text = "";
            txtPhone13.Text = "";
            txtPhone23.Text = "";
            txtEmployeeCardID.Text = "";
            txtWeb3.Text = "";
            txtContact3.Text = "";
            txtMobile3.Text = "";
            txtFax3.Text = "";

            txtCity4.Text = "";
            txtCountry4.Text = "";
            txtEmail4.Text = "";
            txtPhone14.Text = "";
            txtPhone24.Text = "";
            txtEmployeeCardID.Text = "";
            txtWeb4.Text = "";
            txtContact4.Text = "";
            txtMobile4.Text = "";
            txtFax4.Text = "";

            txtCity5.Text = "";
            txtCountry5.Text = "";
            txtEmail5.Text = "";
            txtPhone15.Text = "";
            txtPhone25.Text = "";
            txtEmployeeCardID.Text = "";
            txtWeb5.Text = "";
            txtContact5.Text = "";
            txtMobile5.Text = "";
            txtFax5.Text = "";

            txtAddressLine11.Text = "";
            txtAddressLine12.Text = "";
            txtAddressLine13.Text = "";
            txtAddressLine14.Text = "";
            txtAddressLine21.Text = "";
            txtAddressLine22.Text = "";
            txtAddressLine23.Text = "";
            txtAddressLine24.Text = "";
            txtAddressLine31.Text = "";
            txtAddressLine32.Text = "";
            txtAddressLine33.Text = "";
            txtAddressLine34.Text = "";
            txtAddressLine41.Text = "";
            txtAddressLine42.Text = "";
            txtAddressLine43.Text = "";
            txtAddressLine44.Text = "";
            txtAddressLine51.Text = "";
            txtAddressLine52.Text = "";
            txtAddressLine53.Text = "";
            txtAddressLine54.Text = "";

            txtEmployeeCardID.Text = mModel.GenerateCardIdentification();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReviseModel()
        {
            mModel.FirstName = txtFirstName.Text;
            mModel.LastName = txtLastName.Text;

            mModel.CardIdentification = txtEmployeeCardID.Text;

            mModel.IsActive = chkActive.Checked;
            mModel.IsIndividual = chkIndividual.Checked;

            mModel.Gender = (string)cboGender.SelectedItem;

            mModel.Address1.ContactName = txtContact1.Text;
            mModel.Address1.City = txtCity1.Text;
            mModel.Address1.Country = txtCountry1.Text;
            mModel.Address1.Phone1 = txtPhone11.Text;
            mModel.Address1.Phone2 = txtPhone21.Text;
            mModel.Address1.Email = txtEmail1.Text;
            mModel.Address1.Website = txtWeb1.Text;
            mModel.Address1.Fax = txtFax1.Text;
            mModel.Address1.ContactName = txtContact1.Text;

            mModel.Address2.ContactName = txtContact2.Text;
            mModel.Address2.City = txtCity2.Text;
            mModel.Address2.Country = txtCountry2.Text;
            mModel.Address2.Phone1 = txtPhone12.Text;
            mModel.Address2.Phone2 = txtPhone22.Text;
            mModel.Address2.Email = txtEmail2.Text;
            mModel.Address2.Website = txtWeb2.Text;
            mModel.Address2.Fax = txtFax2.Text;
            mModel.Address2.ContactName = txtContact2.Text;

            mModel.Address3.ContactName = txtContact3.Text;
            mModel.Address3.City = txtCity3.Text;
            mModel.Address3.Country = txtCountry3.Text;
            mModel.Address3.Phone1 = txtPhone13.Text;
            mModel.Address3.Phone2 = txtPhone23.Text;
            mModel.Address3.Email = txtEmail3.Text;
            mModel.Address3.Website = txtWeb3.Text;
            mModel.Address3.Fax = txtFax3.Text;
            mModel.Address3.ContactName = txtContact3.Text;

            mModel.Address4.ContactName = txtContact4.Text;
            mModel.Address4.City = txtCity4.Text;
            mModel.Address4.Country = txtCountry4.Text;
            mModel.Address4.Phone1 = txtPhone14.Text;
            mModel.Address4.Phone2 = txtPhone24.Text;
            mModel.Address4.Email = txtEmail4.Text;
            mModel.Address4.Website = txtWeb4.Text;
            mModel.Address4.Fax = txtFax4.Text;
            mModel.Address4.ContactName = txtContact4.Text;

            mModel.Address5.ContactName = txtContact5.Text;
            mModel.Address5.City = txtCity5.Text;
            mModel.Address5.Country = txtCountry5.Text;
            mModel.Address5.Phone1 = txtPhone15.Text;
            mModel.Address5.Phone2 = txtPhone25.Text;
            mModel.Address5.Email = txtEmail5.Text;
            mModel.Address5.Website = txtWeb5.Text;
            mModel.Address5.Fax = txtFax5.Text;
            mModel.Address5.ContactName = txtContact5.Text;

            mModel.Address1.StreetLine1 = txtAddressLine11.Text;
            mModel.Address1.StreetLine2 = txtAddressLine12.Text;
            mModel.Address1.StreetLine3 = txtAddressLine13.Text;
            mModel.Address1.StreetLine4 = txtAddressLine14.Text;
            mModel.Address2.StreetLine1 = txtAddressLine21.Text;
            mModel.Address2.StreetLine2 = txtAddressLine22.Text;
            mModel.Address2.StreetLine3 = txtAddressLine23.Text;
            mModel.Address2.StreetLine4 = txtAddressLine24.Text;
            mModel.Address3.StreetLine1 = txtAddressLine31.Text;
            mModel.Address3.StreetLine2 = txtAddressLine32.Text;
            mModel.Address3.StreetLine3 = txtAddressLine33.Text;
            mModel.Address3.StreetLine4 = txtAddressLine34.Text;
            mModel.Address4.StreetLine1 = txtAddressLine41.Text;
            mModel.Address4.StreetLine2 = txtAddressLine42.Text;
            mModel.Address4.StreetLine3 = txtAddressLine43.Text;
            mModel.Address4.StreetLine4 = txtAddressLine44.Text;
            mModel.Address5.StreetLine1 = txtAddressLine51.Text;
            mModel.Address5.StreetLine2 = txtAddressLine52.Text;
            mModel.Address5.StreetLine3 = txtAddressLine53.Text;
            mModel.Address5.StreetLine4 = txtAddressLine54.Text;

            mModel.Revise();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ReviseModel();

            OpResult result = mModel.Record();
            if (!result.IsValid)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(result.Error);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (WinFormUtil.Confirm("Do you want to delete the employee?", "Delete") == DialogResult.Yes)
            {
                mModel.Delete();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}