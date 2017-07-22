using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SyntechRpt.Util;
using Accounting.Core.TaxCodes;
using Accounting.Core.Definitions;
using Accounting.Core.Cards;
using Accounting.Core.Currencies;
using Accounting.Core.Accounts;
using Accounting.Core.ShippingMethods;
using Accounting.Core.Misc;
using Accounting.Core.Terms;
using Accounting.Bll;
using Accounting.Bll.Cards;
using SyntechRpt.WinForms.Util;

namespace SyntechRpt.WinForms.Cards
{
    public partial class FrmSupplier : Form
    {
        private BOSupplier mModel=null;

        public BOSupplier Model
        {
            set
            {
                mModel = value;
                mModel.Revised += new BOSupplier.RevisedHandler(mModel_Revised);
            }
        }

        void mModel_Revised()
        {
            
        }

        public FrmSupplier()
        {
            InitializeComponent();
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            cboCurrencyCode.DataSource = mModel.List("Currency");
            cboInvoiceDelivery.DataSource = mModel.List("InvoiceDelivery");
            cboPurchaseLayout.DataSource = mModel.List("PurchaseLayout");
            cboTaxCode.DataSource = mModel.List("TaxCode");
            cboShippingMethod.DataSource = mModel.List("ShippingMethod");
            cboExpenseAccount.DataSource = mModel.List("ExpenseAccount");
            cboPurchaseComment.DataSource = mModel.List("PurchaseComment");
            cboFreightTaxCode.DataSource = mModel.List("FreightTaxCode");
            cboTerms.DataSource = mModel.List("Terms");

            if (mModel.RecordContext == BusinessObject.BOContext.Record_Create)
            {
                UI_Clear();
            }
            else
            {
                ViewModel();
            }

            dtpStartDate.ValueChanged += new EventHandler(dtpStartDate_ValueChanged);
            dtpEndDate.ValueChanged += new EventHandler(dtpEndDate_ValueChanged);
        }

        void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            dgvContactLog.DataSource = mModel.DataGridView_ContactLog(dtpStartDate.Value, dtpEndDate.Value);
        }

        void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dgvContactLog.DataSource = mModel.DataGridView_ContactLog(dtpStartDate.Value, dtpEndDate.Value);
        }

        private void ViewModel()
        {
            txtStatementText.Text = mModel.StatementText;

            txtSupplierCardID.Text = mModel.CardIdentification;
            txtName.Text = mModel.Name;
            txtPaymentMemo.Text = mModel.PaymentMemo;
            txtHourlyBillingRate.Text = string.Format("{0}", mModel.HourlyBillingRate);
            txtCreditLimit.Text = string.Format("{0}", mModel.CreditLimit);
            txtABN.Text = mModel.ABN;
            txtABNBranch.Text = mModel.ABNBranch;
            txtTaxIDNumber.Text = mModel.TaxIDNumber;
            txtCurrentBalance.Text = string.Format("{0}", mModel.CurrentBalance);
            txtVolumeDiscount.Text = string.Format("{0}", mModel.VolumeDiscount);
            txtNotes.Text = mModel.Notes;
            txtBSBCode.Text = mModel.BSBCode;
            txtBankAccountNumber.Text = mModel.BankAccountNumber;
            txtBankAccountName.Text = mModel.BankAccountName;
            txtHighestPurchaseAmount.Text = string.Format("{0}", mModel.HighestPurchaseAmount);
            txtHighestPayableAmount.Text = string.Format("{0}", mModel.HighestPayableAmount);
            txtEstimatedCostPerHour.Text = string.Format("{0}", mModel.EstimatedCostPerHour);

            if (mModel.LastPaymentDate != null)
            {
                txtLastPaymentDate.Text = mModel.LastPaymentDate.Value.ToString("yyyy-MM-dd");
            }

            if(mModel.LastPurchaseDate != null)
            {
                txtLastPurchaseDate.Text = mModel.LastPurchaseDate.Value.ToString("yyyy-MM-dd");
            }

            if (mModel.SupplierSince != null)
            {
                dtpSupplierSince.Value = mModel.SupplierSince.Value;
            }
            
            chkActive.Checked = mModel.IsActive;
            chkIndividual.Checked = mModel.IsIndividual;
            chkUseSupplierTaxCode.Checked = mModel.UseSupplierTaxCode;
            

            if (mModel.GetPropertyValue<string>(BOItem.PICTURE_PATH) != null)
            {
                pbPicture.Load(mModel.GetPropertyValue<string>(BOItem.PICTURE_PATH));
            }
            lblPicture.Text = mModel.GetPropertyValue<string>(BOItem.PICTURE);

            cboShippingMethod.SelectedItem = mModel.ShippingMethod;
            cboExpenseAccount.SelectedItem = mModel.ExpenseAccount;
            cboTaxCode.SelectedItem = mModel.TaxCode;
            cboFreightTaxCode.SelectedItem = mModel.FreightTaxCode;
            cboInvoiceDelivery.SelectedItem = mModel.InvoiceDelivery;
            cboPurchaseLayout.SelectedItem = mModel.PurchaseLayout;
            cboCurrencyCode.SelectedItem = mModel.Currency;
            cboPurchaseComment.SelectedItem = mModel.PurchaseComment;
            cboTerms.SelectedItem = mModel.Terms;

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
            chkUseSupplierTaxCode.Checked = false;

            txtPaymentMemo.Text = "";
            txtHourlyBillingRate.Text = "0";
            txtCreditLimit.Text = "0";
            txtABN.Text = "";
            txtABNBranch.Text = "";
            txtTaxIDNumber.Text = "";
            txtCurrentBalance.Text = "0";
            txtVolumeDiscount.Text = "0";
            txtBSBCode.Text = "";
            txtBankAccountNumber.Text = "";
            txtBankAccountName.Text = "";
            txtEstimatedCostPerHour.Text = "0";

            txtCity1.Text = "";
            txtCountry1.Text = "";
            txtEmail1.Text = "";
            txtName.Text = "";
            txtPhone11.Text = "";
            txtPhone21.Text = "";
            txtSupplierCardID.Text = "";
            txtWeb1.Text = "";
            txtContact1.Text = "";
            txtMobile1.Text = "";
            txtFax1.Text = "";

            txtCity2.Text = "";
            txtCountry2.Text = "";
            txtEmail2.Text = "";
            txtName.Text = "";
            txtPhone12.Text = "";
            txtPhone22.Text = "";
            txtSupplierCardID.Text = "";
            txtWeb2.Text = "";
            txtContact2.Text = "";
            txtMobile2.Text = "";
            txtFax2.Text = "";

            txtCity3.Text = "";
            txtCountry3.Text = "";
            txtEmail3.Text = "";
            txtName.Text = "";
            txtPhone13.Text = "";
            txtPhone23.Text = "";
            txtSupplierCardID.Text = "";
            txtWeb3.Text = "";
            txtContact3.Text = "";
            txtMobile3.Text = "";
            txtFax3.Text = "";

            txtCity4.Text = "";
            txtCountry4.Text = "";
            txtEmail4.Text = "";
            txtName.Text = "";
            txtPhone14.Text = "";
            txtPhone24.Text = "";
            txtSupplierCardID.Text = "";
            txtWeb4.Text = "";
            txtContact4.Text = "";
            txtMobile4.Text = "";
            txtFax4.Text = "";

            txtCity5.Text = "";
            txtCountry5.Text = "";
            txtEmail5.Text = "";
            txtName.Text = "";
            txtPhone15.Text = "";
            txtPhone25.Text = "";
            txtSupplierCardID.Text = "";
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

            txtSupplierCardID.Text = mModel.GenerateCardIdentification();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReviseModel()
        {
            mModel.Name = txtName.Text;
            mModel.CardIdentification = txtSupplierCardID.Text;
            mModel.PaymentMemo = txtPaymentMemo.Text;
            mModel.HourlyBillingRate = double.Parse(txtHourlyBillingRate.Text);
            mModel.CreditLimit = double.Parse(txtCreditLimit.Text);
            mModel.ABN = txtABN.Text;
            mModel.ABNBranch = txtABNBranch.Text;
            mModel.TaxIDNumber = txtTaxIDNumber.Text;
            mModel.CurrentBalance = double.Parse(txtCurrentBalance.Text);
            mModel.VolumeDiscount = double.Parse(txtVolumeDiscount.Text);
            mModel.GetPropertyValue<string>(BOItem.PICTURE) = lblPicture.Text;
            mModel.Notes = txtNotes.Text;
            mModel.BSBCode = txtBSBCode.Text;
            mModel.BankAccountNumber = txtBankAccountNumber.Text;
            mModel.BankAccountName = txtBankAccountName.Text;
            mModel.EstimatedCostPerHour = double.Parse(txtEstimatedCostPerHour.Text);

            mModel.SupplierSince = dtpSupplierSince.Value;

            mModel.Currency = (Currency)cboCurrencyCode.SelectedItem;
            mModel.TaxCode = (TaxCode)cboTaxCode.SelectedItem;
            mModel.FreightTaxCode = (TaxCode)cboFreightTaxCode.SelectedItem;
            mModel.InvoiceDelivery = (InvoiceDelivery)cboInvoiceDelivery.SelectedItem;
            mModel.PurchaseLayout = (InvoiceType)cboPurchaseLayout.SelectedItem;
            mModel.ExpenseAccount = (Account)cboExpenseAccount.SelectedItem;
            mModel.ShippingMethod = (ShippingMethod)cboShippingMethod.SelectedItem;
            mModel.PurchaseComment = (Comment)cboPurchaseComment.SelectedItem;
            mModel.Terms = (Terms)cboTerms.SelectedItem;

            mModel.IsActive = chkActive.Checked;
            mModel.IsIndividual = chkIndividual.Checked;
            mModel.UseSupplierTaxCode = chkUseSupplierTaxCode.Checked;

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

        private void pbPicture_DoubleClick(object sender, EventArgs e)
        {
            FrmPicture frm = new FrmPicture();
            frm.Model.Picture = lblPicture.Text;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                lblPicture.Text = frm.Model.Picture;
                mModel.GetPropertyValue<string>(BOItem.PICTURE) = lblPicture.Text;
                if (frm.Model.Picture == "")
                {
                    pbPicture.Image = null;
                }
                else
                {
                    string picture_path = mModel.GetPropertyValue<string>(BOItem.PICTURE_PATH);
                    if (System.IO.File.Exists(picture_path))
                    {
                        pbPicture.Load(picture_path);
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ReviseModel();

            OpResult result = mModel.Record();
            if (result.IsValid)
            {
                MessageBox.Show("Supplier recorded");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (WinFormUtil.Confirm("Do you want to delete the customer?", "Delete") == DialogResult.Yes)
            {
                mModel.Delete();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}