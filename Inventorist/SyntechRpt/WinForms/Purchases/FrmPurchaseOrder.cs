using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Accounting;
using Accounting.Core.Cards;
using Accounting.Core.Purchases;
using Accounting.Report.Purchases;
using Accounting.Core.Definitions;
using Accounting.Core.Inventory;
using Accounting.Core.Terms;
using Accounting.Core.ShippingMethods;
using Accounting.Core.TaxCodes;
using Accounting.Core.Currencies;
using Accounting.Bll;
using Accounting.Bll.Purchases;
using Accounting.Bll.Purchases.PurchaseLines;
using SyntechRpt.WinForms.Purchases.PurchaseLines;
using SyntechRpt.Util;

namespace SyntechRpt.WinForms.Purchases
{
    public partial class FrmPurchaseOrder : Form
    {
        private BOPurchaseOrder mModel = null;

        public BOPurchaseOrder Model
        {
            set
            {
                mModel = value;
                mModel.Revised += new BOPurchase.RevisedHandler(Model_Revised);
            }
        }

        public FrmPurchaseOrder()
        {
            InitializeComponent();
        }

        private void FrmPurchaseOrder_Load(object sender, EventArgs e)
        {
            cboSupplier.DataSource = mModel.List("Supplier");
            cboComments.DataSource = mModel.List("Comment");
            cboTerms.DataSource = mModel.List("Terms");
            cboInvoiceDelivery.DataSource = mModel.List("InvoiceDelivery");
            cboShippMethod.DataSource = mModel.List("ShippingMethod");
            cboFreightTaxCode.DataSource = mModel.List("FreightTaxCode");
            cboReferralSource.DataSource = mModel.List("ReferralSource");
            cboPurchaseLayout.DataSource = mModel.List("PurchaseLayout");
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
                txtPurchaseNo.Text = mModel.GeneratePurchaseNumber();
                UI_Clear();
            }


            if (Editable)
            {
                this.cboSupplier.SelectedIndexChanged += new System.EventHandler(this.cboSupplier_SelectedIndexChanged);
                this.cboAddresses.SelectedIndexChanged += new System.EventHandler(this.cboAddresses_SelectedIndexChanged);
                this.cboPurchaseLayout.SelectedIndexChanged += new EventHandler(cboPurchaseLayout_SelectedIndexChanged);
                this.dgvPurchaseLines.DoubleClick += new EventHandler(dgvPurchaseLines_DoubleClick);
            }
            else
            {
                UI_Disable();
            }
        }

        void dgvPurchaseLines_DoubleClick(object sender, EventArgs e)
        {
            int linenumber;
            if (WinFormUtil.DataGridView_GetSelectedID(dgvPurchaseLines, out linenumber))
            {
                BOPurchaseLine lineModel = mModel.UpdatePurchaseLine(linenumber);
                OpenPurchaseLineDialog(lineModel);
            }
        }

        private bool Editable
        {
            get
            {
                if (mModel.RecordContext == BusinessObject.BOContext.Record_Update && SecurityUtil.CheckAccessSilent("Purchase_UpdatePurchaseOrder"))
                {
                    return true;
                }
                else if (mModel.RecordContext == BusinessObject.BOContext.Record_Create && SecurityUtil.CheckAccessSilent("Purchase_CreatePurchaseOrder"))
                {
                    return true;
                }
                return false;
            }
        }

        private void UI_Disable()
        {
            cboSupplier.Enabled = false;
            cboComments.Enabled = false;
            cboTerms.Enabled = false;
            cboInvoiceDelivery.Enabled = false;
            cboShippMethod.Enabled = false;
            cboFreightTaxCode.Enabled = false;
            cboReferralSource.Enabled = false;
            cboPurchaseLayout.Enabled = false;
            cboCurrency.Enabled = false;

            txtAddressLine1.Enabled = false;
            txtAddressLine2.Enabled = false;
            txtAddressLine3.Enabled = false;
            txtAddressLine4.Enabled = false;
            txtFreight.Enabled = false;

            txtSupplierCity.Enabled = false;
            txtSupplierEmail.Enabled = false;
            txtPurchaseNo.Enabled = false;
            chkTaxInclusive.Enabled = false;

            txtJournalMemo.Enabled = false;
            txtSupplierPO.Enabled = false;
            txtSupplierCountry.Enabled = false;
            dtpPromisedDate.Enabled = false;
            dtpPurchaseDate.Enabled = false;

            btnRecord.Enabled = false;
            btnCopyAddress.Enabled = false;
            btnDelLine.Enabled = false;
            btnClearAddress.Enabled = false;
            btnNewLine.Enabled = false;
            cboAddresses.Enabled = false;
            btnClearAddress.Enabled = false;
        }

        private void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            Supplier _obj = (Supplier)cboSupplier.SelectedItem;
            if (_obj == null)
            {
                UI_Clear();
                return;
            }

            cboAddresses.SelectedIndex = 0;
            Address addr = _obj.Address1;
            txtSupplierPhone1.Text = addr.Phone1;
            txtSupplierPhone2.Text = addr.Phone2;
            txtSupplierCountry.Text = addr.Country;
            txtSupplierEmail.Text = addr.Email;

            cboShippMethod.SelectedItem = _obj.ShippingMethod;
            cboInvoiceDelivery.SelectedItem = _obj.InvoiceDelivery;
            cboFreightTaxCode.SelectedItem = _obj.FreightTaxCode;
            cboTerms.SelectedItem = _obj.Terms;
            cboComments.SelectedItem = _obj.PurchaseComment;
            cboPurchaseLayout.SelectedItem = _obj.PurchaseLayout;
            cboCurrency.SelectedItem = _obj.Currency;

            txtFreight.Text = "0";
            txtJournalMemo.Text = mModel.GenerateJournalMemo(_obj);

            RenderSelectedAddress();

            if (!tc.Contains(tpPurchaseLines))
            {
                tc.Controls.Add(tpPurchaseLines);
            }
        }

        void Model_Revised()
        {
            txtSubtotalValue.Text = string.Format("{0:C}", mModel.Subtotal);
            txtTaxValue.Text = string.Format("{0:C}", mModel.TotalTax);
            txtTotalValue.Text = string.Format("{0:C}", mModel.Total);
            txtBalanceDue.Text = string.Format("{0:C}", mModel.BalanceDue);

            dgvPurchaseLines.DataSource = mModel.PurchaseLineDataGridView;
        }

        private void UI_Clear()
        {
            cboSupplier.SelectedIndex = -1;
            cboComments.SelectedIndex = -1;
            cboTerms.SelectedIndex = -1;
            cboInvoiceDelivery.SelectedIndex = -1;
            cboShippMethod.SelectedIndex = -1;
            cboFreightTaxCode.SelectedIndex = -1;
            cboReferralSource.SelectedIndex = -1;
            cboPurchaseLayout.SelectedIndex = -1;
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

            if (tc.Contains(tpPurchaseLines))
            {
                tc.Controls.Remove(tpPurchaseLines);
            }
        }

        private void cboAddresses_SelectedIndexChanged(object sender, EventArgs e)
        {
            RenderSelectedAddress();
        }

        private void RenderSelectedAddress()
        {
            Supplier customer = (Supplier)cboSupplier.SelectedItem;
            if (customer == null) return;

            Address addr = customer.Address1;
            txtSupplierPhone1.Text = addr.Phone1;
            txtSupplierPhone2.Text = addr.Phone2;
            txtSupplierCountry.Text = addr.Country;
            txtSupplierEmail.Text = addr.Email;

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

        private void cboPurchaseLayout_SelectedIndexChanged(object sender, EventArgs e)
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
            mModel.PurchaseNumber = txtPurchaseNo.Text;
            mModel.PromisedDate = dtpPromisedDate.Value;
            mModel.PurchaseDate = dtpPurchaseDate.Value;
            mModel.InvoiceDelivery = (InvoiceDelivery)cboInvoiceDelivery.SelectedItem;
            mModel.Terms = (Terms)cboTerms.SelectedItem;
            mModel.ShipToAddressLine1 = txtAddressLine1.Text;
            mModel.ShipToAddressLine2 = txtAddressLine2.Text;
            mModel.ShipToAddressLine3 = txtAddressLine3.Text;
            mModel.ShipToAddressLine4 = txtAddressLine4.Text;
            mModel.ShippingMethod = (ShippingMethod)cboShippMethod.SelectedItem;
            mModel.Supplier = (Supplier)cboSupplier.SelectedItem;
            mModel.SupplierInvoiceNumber = txtSupplierPO.Text;
            mModel.FreightTaxCode = (TaxCode)cboFreightTaxCode.SelectedItem;
            mModel.TaxExclusiveFreight = double.Parse(txtFreight.Text);
            mModel.IsTaxInclusive = chkTaxInclusive.Checked;
            mModel.PurchaseType = (InvoiceType)cboPurchaseLayout.SelectedItem;
            mModel.Currency = (Currency)cboCurrency.SelectedItem;
            mModel.TotalPaid += double.Parse(txtPaidToday.Text);
            mModel.Memo = txtJournalMemo.Text;

            mModel.Revise();
        }

        private void ViewModel()
        {
            cboComments.Text=mModel.Comment;
            txtPurchaseNo.Text = mModel.PurchaseNumber;
            if (mModel.PromisedDate != null)
            {
                dtpPromisedDate.Value = mModel.PromisedDate.Value;
            }

            if (mModel.PurchaseDate != null)
            {
                dtpPurchaseDate.Value = mModel.PurchaseDate.Value;
            }

            cboInvoiceDelivery.SelectedItem = mModel.InvoiceDelivery;
            cboTerms.SelectedItem = mModel.Terms;
            txtAddressLine1.Text = mModel.ShipToAddressLine1;
            txtAddressLine2.Text = mModel.ShipToAddressLine2;
            txtAddressLine3.Text = mModel.ShipToAddressLine3;
            txtAddressLine4.Text = mModel.ShipToAddressLine4;
            cboShippMethod.SelectedItem = mModel.ShippingMethod;
            cboSupplier.SelectedItem = mModel.Supplier;
            txtSupplierPO.Text = mModel.SupplierInvoiceNumber;
            cboFreightTaxCode.SelectedItem = mModel.FreightTaxCode;
            txtFreight.Text = string.Format("{0}", mModel.TaxExclusiveFreight);
            chkTaxInclusive.Checked = mModel.IsTaxInclusive;
            cboPurchaseLayout.SelectedItem = mModel.PurchaseType;
            cboCurrency.SelectedItem = mModel.Currency;
            txtPaidToday.Text = string.Format("{0}", mModel.TotalPaid);
            txtJournalMemo.Text = mModel.Memo;

            Supplier customer = mModel.Supplier;
            if (customer != null)
            {
                Address addr = customer.Address1;
                txtSupplierPhone1.Text = addr.Phone1;
                txtSupplierPhone2.Text = addr.Phone2;
                txtSupplierEmail.Text = addr.Email;
                txtSupplierCountry.Text = addr.Country;
            }

            txtBalanceDue.Text = string.Format("{0:C}", mModel.OutstandingBalance);
            txtSubtotalValue.Text = string.Format("{0:C}", mModel.Subtotal);
            txtTaxValue.Text = string.Format("{0:C}", mModel.TotalTax);
            txtTotalValue.Text = string.Format("{0:C}", mModel.Total);

            dgvPurchaseLines.DataSource = mModel.PurchaseLineDataGridView;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Reports.FrmPurchaseOrder frm = new Reports.FrmPurchaseOrder(new PurchaseOrder(mModel.Purchase));
            frm.MdiParent = this.MdiParent;
            frm.LoadReport("Dac.Reports.Purchases.RptPurchaseOrder.rdlc");
            frm.Show();
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

            BOPurchaseLine lineModel=mModel.CreatePurchaseLine();
            OpenPurchaseLineDialog(lineModel);
        }

        private void chkTaxInclusive_CheckedChanged(object sender, EventArgs e)
        {
            mModel.IsTaxInclusive = chkTaxInclusive.Checked;
            mModel.Revise();
        }

        private void btnDelLine_Click(object sender, EventArgs e)
        {
           int linenumber;
           if (WinFormUtil.DataGridView_GetSelectedID(dgvPurchaseLines, out linenumber))
           {
               ReviseModel();
               mModel.DeletePurchaseLine(linenumber);
           }
        }

        private void OpenPurchaseLineDialog(BOPurchaseLine lineModel)
        {
            if (lineModel is BOItemPurchaseLine)
            {
                FrmItemPurchaseLine frm = new FrmItemPurchaseLine();
                frm.Model = (BOItemPurchaseLine)lineModel;
                frm.ShowDialog();
            }
            else if (lineModel is BOServicePurchaseLine)
            {
                FrmServicePurchaseLine frm = new FrmServicePurchaseLine();
                frm.Model = (BOServicePurchaseLine)lineModel;
                frm.ShowDialog();
            }
            else if (lineModel is BOProfessionalPurchaseLine)
            {
                FrmProfessionalPurchaseLine frm = new FrmProfessionalPurchaseLine();
                frm.Model = (BOProfessionalPurchaseLine)lineModel;
                frm.ShowDialog();
            }
            else if (lineModel is BOTimeBillingPurchaseLine)
            {
                FrmTimeBillingPurchaseLine frm = new FrmTimeBillingPurchaseLine();
                frm.Model = (BOTimeBillingPurchaseLine)lineModel;
                frm.ShowDialog();
            }
            else if (lineModel is BOMiscPurchaseLine)
            {
                FrmMiscPurchaseLine frm = new FrmMiscPurchaseLine();
                frm.Model = (BOMiscPurchaseLine)lineModel;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a valid purchase layout first!", "Current Sale Layout: No Default");
            }
        }

        private void txtPaidToday_Leave(object sender, EventArgs e)
        {
            ReviseModel();
        }
    }
}