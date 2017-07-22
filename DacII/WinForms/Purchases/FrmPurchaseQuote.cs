using System;
using System.Drawing;
using System.Windows.Forms;

namespace DacII.WinForms.Purchases
{
    using DacII.Presenters;
    using DacII.ViewModels;
    using Accounting.Core;
    using Accounting.Core.Cards;
    using Accounting.Core.Purchases;

    using Accounting.Report.Purchases;
    using Accounting.Bll.Purchases;
    using Accounting.Bll.Purchases.PurchaseLines;
    using DacII.WinForms.Purchases.PurchaseLines;
    using Barcode.Code128;

    public partial class FrmPurchaseQuote : BaseView
    {
        private BOPurchaseQuote mModel;
        private BOViewModel mViewModel;
     

        public FrmPurchaseQuote(ApplicationPresenter ap, BOPurchaseQuote model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;
            mViewModel = new BOViewModel(mModel);
            mViewModel.ErrorProvider = errorProvider;

            BindViews();
            RegisterEventHandlers();
        }

        public BOPurchaseQuote Model
        {
            set
            {
                mModel = value;
                mViewModel.Model = mModel;
            }
        }

        protected override void BindViews()
        {
            cboSupplier.DataSource = mApplicationController.FindAllSuppliers();
            cboComments.DataSource = mApplicationController.FindAllComments();
            cboTerms.DataSource = mApplicationController.FindAllTerms();
            cboInvoiceDelivery.DataSource = mApplicationController.FindallInvoiceDeliveries();
            cboShippingMethod.DataSource = mApplicationController.FindAllShippingMethods();
            cboFreightTaxCode.DataSource = mApplicationController.FindAllTaxCodes();
            cboReferralSource.DataSource = mApplicationController.FindAllReferralSources();
            cboPurchaseLayout.DataSource = mApplicationController.FindAllPurchaseLayouts();
            cboCurrency.DataSource = mApplicationController.FindAllCurrencies();
            cboAddresses.DataSource = mApplicationController.FindAllAddresses();

            mViewModel.BindView(BOPurchase.COMMENT, lblComments, cboComments);
            mViewModel.BindView(BOPurchase.PURCHASE_NUMBER, lblPurchaseNo, txtPurchaseNo);
            mViewModel.BindView(BOPurchase.PROMISED_DATE, lblPromisedDate, dtpPromisedDate);
            mViewModel.BindView(BOPurchase.PURCHASE_DATE, lblPurchaseDate, dtpPurchaseDate);
            mViewModel.BindView(BOPurchase.INVOICE_DELIVERY, lblInvoiceDelivery, cboInvoiceDelivery);
            mViewModel.BindView(BOPurchase.TERMS, lblTerms, cboTerms);
            mViewModel.BindView(BOPurchase.SHIP_TO_ADDRESS_LINE1, lblAddressLine1, txtAddressLine1);
            mViewModel.BindView(BOPurchase.SHIP_TO_ADDRESS_LINE2, lblAddressLine2, txtAddressLine2);
            mViewModel.BindView(BOPurchase.SHIP_TO_ADDRESS_LINE3, lblAddressLine3, txtAddressLine3);
            mViewModel.BindView(BOPurchase.SHIP_TO_ADDRESS_LINE4, lblAddressLine4, txtAddressLine4);
            mViewModel.BindView(BOPurchase.SHIPPING_METHOD, lblShippingMethod, cboShippingMethod);
            mViewModel.BindView(BOPurchase.SUPPLIER_INVOICE_NUMBER, lblSupplierPO, txtSupplierPO);
            mViewModel.BindView(BOPurchase.FREIGHT_TAXCODE, null, cboFreightTaxCode);
            mViewModel.BindView(BOPurchase.FREIGHT, lblFreight, txtFreight);
            mViewModel.BindView(BOPurchase.CURRENCY, lblCurrency, cboCurrency);
            mViewModel.BindView(BOPurchase.MEMO, lblJournalMemo, txtJournalMemo);
            mViewModel.BindView(BOPurchase.SUPPLIER, lblSupplier, cboSupplier);
            mViewModel.BindView(BOPurchase.SUPPLIER_ADDRESS, null, cboAddresses);
            mViewModel.BindView(BOPurchase.PURCHASE_TYPE, lblPurchaseLayout, cboPurchaseLayout);
            mViewModel.BindView(BOPurchase.IS_TAX_INCLUSIVE, chkTaxInclusive);

            mViewModel.BindView(BOPurchase.PERSIST_OBJECT, btnRecord);

            mViewModel.BindView(BOPurchase.TOTAL, lblTotalValue, txtTotalValue);
            mViewModel.BindView(BOPurchase.TOTAL_TAX, lblTaxValue, txtTaxValue);
            mViewModel.BindView(BOPurchase.TOTAL_LINES, lblSubtotalValue, txtSubtotalValue);
            mViewModel.BindView(BOPurchase.FREIGHT, lblFreight, txtFreight);
        }

        private void OnSupplierChanged(object sender, EventArgs args)
        {
            Supplier _obj = (Supplier)cboSupplier.SelectedItem;
            if (_obj == null)
            {
                return;
            }

            cboAddresses.SelectedIndex = 0;
            Address addr = _obj.Address1;
            txtSupplierPhone1.Text = addr.Phone1;
            txtSupplierPhone2.Text = addr.Phone2;
            txtSupplierCountry.Text = addr.Country;
            txtSupplierEmail.Text = addr.Email;

            cboShippingMethod.SelectedItem = _obj.ShippingMethod;
            cboInvoiceDelivery.SelectedItem = _obj.InvoiceDelivery;
            cboFreightTaxCode.SelectedItem = _obj.FreightTaxCode;
            cboTerms.SelectedItem = _obj.Terms;
            cboComments.SelectedItem = _obj.PurchaseComment;
            cboPurchaseLayout.SelectedItem = _obj.PurchaseLayout;
            cboCurrency.SelectedItem = _obj.Currency;

            txtJournalMemo.Text = mModel.GenerateJournalMemo(_obj);

            UpdateView_Address();

            if (!tc.Contains(tpPurchaseLines))
            {
                tc.Controls.Add(tpPurchaseLines);
            }
        }

        private void Record(object sender, EventArgs args)
        {
            if (mViewModel.ValidateModel())
            {
                OpResult result = mModel.Record();
                if (result.Status == OpResult.ResultStatus.UpdateFailedOnCriteria)
                {
                    MessageBox.Show(result.Error, "Update Purchase Quote Failed");
                    DialogResult = DialogResult.None;
                }
                else if (result.Status == OpResult.ResultStatus.CreateFailedOnCriteria)
                {
                    MessageBox.Show(result.Error, "Create Purchase Quote Failed");
                    DialogResult = DialogResult.None;
                }
                else
                {
                    string error = result.Error;
                    if (string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show("Purchase Quote Recorded!");
                    }
                    else
                    {
                        MessageBox.Show(error);
                    }
                }
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        private void OnAddressIndexChanged(object sender, EventArgs args)
        {
            UpdateView_Address();
        }

        protected override void  LoadView()
        {
            mViewModel.UpdateView();
            PurchaseLines_UpdateView();
        }

        private void PurchaseLines_UpdateView()
        {
            dgvPurchaseLines.AutoGenerateColumns = false;
            dgvPurchaseLines.Columns.Clear();

            DataGridViewColumn c = null;

            if (mModel.IsItem)
            {
                dgvPurchaseLines.DataSource = mModel.ItemPurchaseLines;

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "_Ordered";
                c.HeaderText = "Order";
                dgvPurchaseLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "_Received";
                c.HeaderText = "Received";
                dgvPurchaseLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "ItemNumber";
                c.HeaderText = "Item Number";
                dgvPurchaseLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "ItemName";
                c.HeaderText = "Description";
                dgvPurchaseLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "_Price";
                c.HeaderText = "Price";
                dgvPurchaseLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "Discount";
                c.HeaderText = "Disc%";
                dgvPurchaseLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "_Total";
                c.HeaderText = "Total";
                dgvPurchaseLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "JobNumber";
                c.HeaderText = "Job";
                dgvPurchaseLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "_TaxCode";
                c.HeaderText = "Tax";
                dgvPurchaseLines.Columns.Add(c);
            }
            else if (mModel.IsMisc)
            {
                dgvPurchaseLines.DataSource = mModel.MiscPurchaseLines;

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "Description";
                c.HeaderText = "Description";
                dgvPurchaseLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "AccountNumber";
                c.HeaderText = "Acct#";
                dgvPurchaseLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "_Total";
                c.HeaderText = "Amount";
                dgvPurchaseLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "JobNumber";
                c.HeaderText = "Job";
                dgvPurchaseLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "_TaxCode";
                c.HeaderText = "Tax";
                dgvPurchaseLines.Columns.Add(c);
            }
            else if (mModel.IsService)
            {
                dgvPurchaseLines.DataSource = mModel.ServicePurchaseLines;

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "Description";
                c.HeaderText = "Description";
                dgvPurchaseLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "AccountNumber";
                c.HeaderText = "Acct#";
                dgvPurchaseLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "_Total";
                c.HeaderText = "Amount";
                dgvPurchaseLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "JobNumber";
                c.HeaderText = "Job";
                dgvPurchaseLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "_TaxCode";
                c.HeaderText = "Tax";
                dgvPurchaseLines.Columns.Add(c);
            }
            else if (mModel.IsProfessional)
            {
                dgvPurchaseLines.DataSource = mModel.ProfessionalPurchaseLines;

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "_LineDate";
                c.HeaderText = "Date";
                dgvPurchaseLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "Description";
                c.HeaderText = "Description";
                dgvPurchaseLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "AccountNumber";
                c.HeaderText = "Acct#";
                dgvPurchaseLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "_Total";
                c.HeaderText = "Amount";
                dgvPurchaseLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "JobNumber";
                c.HeaderText = "Job";
                dgvPurchaseLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "_TaxCode";
                c.HeaderText = "Tax";
                dgvPurchaseLines.Columns.Add(c);
            }
            else if (mModel.IsTimeBilling)
            {
                dgvPurchaseLines.DataSource = mModel.TimeBillingPurchaseLines;
            }

            DacII.Util.DataGridViewHelper.UpdateColumnHeaderStyles(dgvPurchaseLines);
        }

        private void UpdateView_Address()
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            mApplicationController.PrintPurchase(mModel.Data, txtPurchaseNo.Text);
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
            UpdateView_Address();
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            string barcode = txtPurchaseNo.Text;
            Util.FrmGenBarcode frm = new Util.FrmGenBarcode();
            frm.GenBarcode(barcode);
        }

        private void btnNewLine_Click(object sender, EventArgs e)
        {
            if (mApplicationController.CreatePurchaseLine(mModel.Data))
            {
                PurchaseLines_UpdateView();
            }
        }

        private void dgvPurchaseLines_DoubleClick(object sender, EventArgs e)
        {
            if (dgvPurchaseLines.SelectedRows.Count == 0) return;
            mApplicationController.OpenPurchaseLine(dgvPurchaseLines.SelectedRows[0].DataBoundItem as PurchaseLine);
           
        }

        private void btnDelLine_Click(object sender, EventArgs e)
        {
            if (dgvPurchaseLines.SelectedRows.Count == 0) return;
            mApplicationController.DeletePurchaseLine(dgvPurchaseLines.SelectedRows[0].DataBoundItem as PurchaseLine);
            PurchaseLines_UpdateView();
        }
    }
}