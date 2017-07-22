using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Accounting;
using Accounting.Core.Cards;
using Accounting.Core.Sales;
using Accounting.Report.Sales;
using Accounting.Core.Definitions;
using Accounting.Core.Inventory;
using Accounting.Core.Terms;
using Accounting.Core.ShippingMethods;
using Accounting.Core.TaxCodes;
using Accounting.Core.Currencies;
using Accounting.Bll;
using Accounting.Bll.Sales;
using Accounting.Bll.Sales.SaleLines;
using SyntechRpt.WinForms.Sales.SaleLines;
using SyntechRpt.Util;

namespace SyntechRpt.WinForms.Sales
{
    public partial class FrmSaleOrder : Form
    {
        private BOSaleOrder mModel = null;

        public BOSaleOrder Model
        {
            set
            {
                mModel = value;
                mModel.Revised += new BOSale.RevisedHandler(Model_Revised);
            }
        }

        public FrmSaleOrder()
        {
            InitializeComponent();
        }

        private void FrmSaleOrder_Load(object sender, EventArgs e)
        {
            cboCustomer.DataSource = mModel.List("Customer");
            cboComments.DataSource = mModel.List("Comment");
            cboTerms.DataSource = mModel.List("Terms");
            cboInvoiceDelivery.DataSource = mModel.List("InvoiceDelivery");
            cboShippMethod.DataSource = mModel.List("ShippingMethod");
            cboFreightTaxCode.DataSource = mModel.List("FreightTaxCode");
            cboSalesperson.DataSource = mModel.List("Salesperson");
            cboReferralSource.DataSource = mModel.List("ReferralSource");
            cboSaleLayout.DataSource = mModel.List("SaleLayout");
            cboCurrency.DataSource = mModel.List("Currency");

            cboAddresses.Items.Add("Address 1");
            cboAddresses.Items.Add("Address 2");
            cboAddresses.Items.Add("Address 3");
            cboAddresses.Items.Add("Address 4");
            cboAddresses.Items.Add("Address 5");
            cboAddresses.SelectedIndex = 0;

            if (mModel.RecordContext == BusinessObject.BOContext.Record_Update)
            {
                ViewModel();
            }
            else if (mModel.RecordContext == BusinessObject.BOContext.Record_Create)
            {
                txtSaleNo.Text = mModel.GenerateInvoiceNumber();
                UI_Clear();
            }

            if (Editable)
            {
                this.cboCustomer.SelectedIndexChanged += new System.EventHandler(this.cboCustomer_SelectedIndexChanged);
                this.cboAddresses.SelectedIndexChanged += new System.EventHandler(this.cboAddresses_SelectedIndexChanged);
                this.cboSaleLayout.SelectedIndexChanged += new EventHandler(cboSaleLayout_SelectedIndexChanged);
                this.dgvSaleLines.DoubleClick += new EventHandler(dgvSaleLines_DoubleClick);
            }
            else
            {
                UI_Disable();
            }
        }

        void dgvSaleLines_DoubleClick(object sender, EventArgs e)
        {
            int linenumber;
            if (WinFormUtil.DataGridView_GetSelectedID(dgvSaleLines, out linenumber))
            {
                BOSaleLine lineModel = mModel.UpdateSaleLine(linenumber);
                OpenSaleLineDialog(lineModel);
            }
        }

        private bool Editable
        {
            get
            {
                if (mModel.RecordContext == BusinessObject.BOContext.Record_Update && SecurityUtil.CheckAccessSilent("Sale_UpdateSaleOrder"))
                {
                    return true;
                }
                else if (mModel.RecordContext == BusinessObject.BOContext.Record_Create && SecurityUtil.CheckAccessSilent("Sale_CreateSaleOrder"))
                {
                    return true;
                }
                return false;
            }
        }

        private void UI_Disable()
        {
            cboCustomer.Enabled = false;
            cboComments.Enabled = false;
            cboTerms.Enabled = false;
            cboInvoiceDelivery.Enabled = false;
            cboShippMethod.Enabled = false;
            cboFreightTaxCode.Enabled = false;
            cboSalesperson.Enabled = false;
            cboReferralSource.Enabled = false;
            cboSaleLayout.Enabled = false;
            cboCurrency.Enabled = false;
            cboPaymentMethod.Enabled = false;

            txtAddressLine1.Enabled = false;
            txtAddressLine2.Enabled = false;
            txtAddressLine3.Enabled = false;
            txtAddressLine4.Enabled = false;
            txtFreight.Enabled = false;

            txtCustomerCity.Enabled = false;
            txtCustomerEmail.Enabled = false;
            txtSaleNo.Enabled = false;
            chkTaxInclusive.Enabled = false;

            txtJournalMemo.Enabled = false;
            txtCustomerPO.Enabled = false;
            txtDestinationCountry.Enabled = false;
            dtpPromisedDate.Enabled = false;
            dtpSaleDate.Enabled = false;

            btnRecord.Enabled = false;
            btnCopyAddress.Enabled = false;
            btnDelLine.Enabled = false;
            btnReceiveGoods.Enabled = false;
            btnClearAddress.Enabled = false;
            btnNewLine.Enabled = false;
            cboAddresses.Enabled = false;
            btnClearAddress.Enabled = false;
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Customer _obj = (Customer)cboCustomer.SelectedItem;
            if (_obj == null)
            {
                UI_Clear();
                return;
            }

            cboAddresses.SelectedIndex = 0;
            Address addr = _obj.Address1;
            txtCustomerPhone1.Text = addr.Phone1;
            txtCustomerPhone2.Text = addr.Phone2;
            txtDestinationCountry.Text = addr.Country;
            txtCustomerEmail.Text = addr.Email;

            cboSalesperson.SelectedItem = _obj.SalesPerson;
            cboShippMethod.SelectedItem = _obj.ShippingMethod;
            cboInvoiceDelivery.SelectedItem = _obj.InvoiceDelivery;
            cboFreightTaxCode.SelectedItem = _obj.FreightTaxCode;
            cboTerms.SelectedItem = _obj.Terms;
            cboComments.SelectedItem = _obj.SaleComment;
            cboSaleLayout.SelectedItem = _obj.SaleLayout;
            cboCurrency.SelectedItem = _obj.Currency;

            txtFreight.Text = "0";
            txtJournalMemo.Text = mModel.GenerateJournalMemo(_obj);

            RenderSelectedAddress();

            if (!tc.Contains(tpSaleLines))
            {
                tc.Controls.Add(tpSaleLines);
            }
        }

        void Model_Revised()
        {
            txtSubtotalValue.Text = string.Format("{0:C}", mModel.Subtotal);
            txtTaxValue.Text = string.Format("{0:C}", mModel.TotalTax);
            txtTotalValue.Text = string.Format("{0:C}", mModel.Total);
            txtBalanceDue.Text = string.Format("{0:C}", mModel.BalanceDue);

            dgvSaleLines.DataSource = mModel.SaleLineDataGridView;
        }

        private void UI_Clear()
        {
            cboCustomer.SelectedIndex = -1;
            cboComments.SelectedIndex = -1;
            cboTerms.SelectedIndex = -1;
            cboInvoiceDelivery.SelectedIndex = -1;
            cboShippMethod.SelectedIndex = -1;
            cboFreightTaxCode.SelectedIndex = -1;
            cboSalesperson.SelectedIndex = -1;
            cboReferralSource.SelectedIndex = -1;
            cboSaleLayout.SelectedIndex = -1;
            cboCurrency.SelectedIndex = -1;
            cboPaymentMethod.SelectedIndex = -1;

            txtAddressLine1.Text = "";
            txtAddressLine2.Text = "";
            txtAddressLine3.Text = "";
            txtAddressLine4.Text = "";
            txtFreight.Text = "0";

            txtSubtotalValue.Text = string.Format("{0:C}", 0);
            txtTaxValue.Text = string.Format("{0:C}", 0);
            txtTotalValue.Text = string.Format("{0:C}", 0);
            txtBalanceDue.Text = string.Format("{0:C}", 0);

            if (tc.Contains(tpSaleLines))
            {
                tc.Controls.Remove(tpSaleLines);
            }
        }

        private void cboAddresses_SelectedIndexChanged(object sender, EventArgs e)
        {
            RenderSelectedAddress();
        }

        private void RenderSelectedAddress()
        {
            Customer customer = (Customer)cboCustomer.SelectedItem;
            if (customer == null) return;

            Address addr = customer.Address1;
            txtCustomerPhone1.Text = addr.Phone1;
            txtCustomerPhone2.Text = addr.Phone2;
            txtDestinationCountry.Text = addr.Country;
            txtCustomerEmail.Text = addr.Email;

            switch (cboAddresses.SelectedIndex)
            {
                case 1:
                    addr = customer.Address2;
                    break;
                case 2:
                    addr = customer.Address3;
                    break;
                case 3:
                    addr = customer.Address4;
                    break;
                case 4:
                    addr = customer.Address5;
                    break;
            }

            txtAddressLine1.Text = customer.Name;
            txtAddressLine2.Text = addr.StreetLine1;
            txtAddressLine3.Text = addr.StreetLine2;
            txtAddressLine4.Text = addr.StreetLine3;
        }

        private void cboSaleLayout_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReviseModel();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            ReviseModel();
            OpResult result = mModel.Record();
            if (!result.IsValid)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(result.Error);
            }
        }

        private void ReviseModel()
        {
            mModel.Comment = cboComments.Text;
            mModel.InvoiceNumber = txtSaleNo.Text;
            mModel.PromisedDate = dtpPromisedDate.Value;
            mModel.InvoiceDate = dtpSaleDate.Value;
            mModel.InvoiceDelivery = (InvoiceDelivery)cboInvoiceDelivery.SelectedItem;
            mModel.Terms = (Terms)cboTerms.SelectedItem;
            mModel.ShipToAddressLine1 = txtAddressLine1.Text;
            mModel.ShipToAddressLine2 = txtAddressLine2.Text;
            mModel.ShipToAddressLine3 = txtAddressLine3.Text;
            mModel.ShipToAddressLine4 = txtAddressLine4.Text;
            mModel.ShippingMethod = (ShippingMethod)cboShippMethod.SelectedItem;
            mModel.Customer = (Customer)cboCustomer.SelectedItem;
            mModel.CustomerPONumber = txtCustomerPO.Text;
            mModel.FreightTaxCode = (TaxCode)cboFreightTaxCode.SelectedItem;
            mModel.TaxExclusiveFreight = double.Parse(txtFreight.Text);
            mModel.IsTaxInclusive = chkTaxInclusive.Checked;
            mModel.SalesPerson = (Employee)cboSalesperson.SelectedItem;
            mModel.InvoiceType = (InvoiceType)cboSaleLayout.SelectedItem;
            mModel.Currency = (Currency)cboCurrency.SelectedItem;
            mModel.TotalPaid += double.Parse(txtPaidToday.Text);
            mModel.DestinationCountry = txtDestinationCountry.Text;
            mModel.Memo = txtJournalMemo.Text;
            
            mModel.Revise();
        }

        private void ViewModel()
        {
            cboComments.Text=mModel.Comment;
            txtSaleNo.Text = mModel.InvoiceNumber;
            if (mModel.PromisedDate != null)
            {
                dtpPromisedDate.Value = mModel.PromisedDate.Value;
            }

            if (mModel.InvoiceDate != null)
            {
                dtpSaleDate.Value = mModel.InvoiceDate.Value;
            }

            cboInvoiceDelivery.SelectedItem = mModel.InvoiceDelivery;
            cboTerms.SelectedItem = mModel.Terms;
            txtAddressLine1.Text = mModel.ShipToAddressLine1;
            txtAddressLine2.Text = mModel.ShipToAddressLine2;
            txtAddressLine3.Text = mModel.ShipToAddressLine3;
            txtAddressLine4.Text = mModel.ShipToAddressLine4;
            cboShippMethod.SelectedItem = mModel.ShippingMethod;
            cboCustomer.SelectedItem = mModel.Customer;
            txtCustomerPO.Text = mModel.CustomerPONumber;
            cboFreightTaxCode.SelectedItem = mModel.FreightTaxCode;
            txtFreight.Text = string.Format("{0}", mModel.TaxExclusiveFreight);
            chkTaxInclusive.Checked = mModel.IsTaxInclusive;
            cboSalesperson.SelectedItem = mModel.SalesPerson;
            cboSaleLayout.SelectedItem = mModel.InvoiceType;
            cboCurrency.SelectedItem = mModel.Currency;
            txtPaidToday.Text = string.Format("{0}", mModel.TotalPaid);
            txtJournalMemo.Text = mModel.Memo;

            Customer customer = mModel.Customer;
            if (customer != null)
            {
                Address addr = customer.Address1;
                txtCustomerPhone1.Text = addr.Phone1;
                txtCustomerPhone2.Text = addr.Phone2;
                txtCustomerEmail.Text = addr.Email;
            }
            txtDestinationCountry.Text = mModel.DestinationCountry;

            txtBalanceDue.Text = string.Format("{0:C}", mModel.OutstandingBalance);
            txtSubtotalValue.Text = string.Format("{0:C}", mModel.Subtotal);
            txtTaxValue.Text = string.Format("{0:C}", mModel.TotalTax);
            txtTotalValue.Text = string.Format("{0:C}", mModel.Total);

            dgvSaleLines.DataSource = mModel.SaleLineDataGridView;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            /*
            string reportname = "rptInvoice";

            Report.WinForms.FrmInvoice frm = new Dac.WinForms.Report.FrmInvoice(new Invoice(mModel.Sale));
            frm.MdiParent = this.MdiParent;
            frm.LoadReport(string.Format("Dac.WinForms.Report.{0}.rdlc", reportname));
            frm.Show();
             */
        }

        private void btnClearAddress_Click(object sender, EventArgs e)
        {
            txtAddressLine1.Text = "";
            txtAddressLine2.Text = "";
            txtAddressLine3.Text = "";
            txtAddressLine4.Text = "";
        }

        private void btnCopyAddress_Click(object sender, EventArgs e)
        {
            RenderSelectedAddress();
        }

        private void btnNewLine_Click(object sender, EventArgs e)
        {
            ReviseModel();

            BOSaleLine lineModel=mModel.CreateSaleLine();
            OpenSaleLineDialog(lineModel);
        }

        private void chkTaxInclusive_CheckedChanged(object sender, EventArgs e)
        {
            mModel.IsTaxInclusive = chkTaxInclusive.Checked;
            mModel.Revise();
        }

        private void btnDelLine_Click(object sender, EventArgs e)
        {
            int linenumber;
            if (WinFormUtil.DataGridView_GetSelectedID(dgvSaleLines, out linenumber))
            {
                ReviseModel();
                mModel.DeleteSaleLine(linenumber);
            }
        }

        private void OpenSaleLineDialog(BOSaleLine lineModel)
        {
            if (lineModel is BOItemSaleLine)
            {
                FrmItemSaleLine frm = new FrmItemSaleLine();
                frm.Model = (BOItemSaleLine)lineModel;
                frm.ShowDialog();
            }
            else if (lineModel is BOServiceSaleLine)
            {
                FrmServiceSaleLine frm = new FrmServiceSaleLine();
                frm.Model = (BOServiceSaleLine)lineModel;
                frm.ShowDialog();
            }
            else if (lineModel is BOProfessionalSaleLine)
            {
                FrmProfessionalSaleLine frm = new FrmProfessionalSaleLine();
                frm.Model = (BOProfessionalSaleLine)lineModel;
                frm.ShowDialog();
            }
            else if (lineModel is BOTimeBillingSaleLine)
            {
                FrmTimeBillingSaleLine frm = new FrmTimeBillingSaleLine();
                frm.Model = (BOTimeBillingSaleLine)lineModel;
                frm.ShowDialog();
            }
            else if (lineModel is BOMiscSaleLine)
            {
                FrmMiscSaleLine frm = new FrmMiscSaleLine();
                frm.Model = (BOMiscSaleLine)lineModel;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a valid sale layout first!", "Current Sale Layout: No Default");
            }
        }

        private void txtPaidToday_Leave(object sender, EventArgs e)
        {
            ReviseModel();
        }
    }
}