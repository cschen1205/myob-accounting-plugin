using System;
using System.Windows.Forms;

namespace DacII.WinForms.Sales
{
    using Accounting.Bll.Sales;
    using Accounting.Core;
    using Accounting.Core.Cards;
    using Accounting.Core.Sales;
    using DacII.Presenters;
    using DacII.ViewModels;

    public partial class FrmSaleOrder : BaseView
    {
        private BOSaleOrder mModel = null;
        private BOViewModel mViewModel;

        public FrmSaleOrder(ApplicationPresenter ap, BOSaleOrder model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;
            mViewModel = new BOViewModel(mModel);
            mViewModel.ErrorProvider = errorProvider;

            BindViews();
            RegisterEventHandlers();
        }

        public BOSaleOrder Model
        {
            set
            {
                mModel = value;
                mViewModel.Model = mModel;
            }
        }

        private void OnAddressIndexChanged(object sender, EventArgs args)
        {
            UpdateView_Address();
        }

        protected override void BindViews()
        {
            cboCustomer.DataSource = mApplicationController.FindAllCustomers(); ;
            cboComments.DataSource = mApplicationController.FindAllComments();
            cboTerms.DataSource = mApplicationController.FindAllTerms();
            cboInvoiceDelivery.DataSource = mApplicationController.FindallInvoiceDeliveries();
            cboShippingMethod.DataSource = mApplicationController.FindAllShippingMethods();
            cboFreightTaxCode.DataSource = mApplicationController.FindAllTaxCodes();
            cboSalesperson.DataSource = mApplicationController.FindAllEmployees();
            cboReferralSource.DataSource = mApplicationController.FindAllReferralSources();
            cboSaleLayout.DataSource = mApplicationController.FindAllSaleLayouts();
            cboCurrency.DataSource = mApplicationController.FindAllCurrencies();
            cboAddresses.DataSource = mApplicationController.FindAllAddresses();

            mViewModel.BindView(BOSale.COMMENT, lblComments, cboComments);
            mViewModel.BindView(BOSale.INVOICE_NUMBER, lblSaleNo, txtSaleNo);
            mViewModel.BindView(BOSale.PROMISED_DATE, lblPromisedDate, dtpPromisedDate);
            mViewModel.BindView(BOSale.INVOICE_DATE, lblSaleDate, dtpSaleDate);
            mViewModel.BindView(BOSale.TERMS, lblTerms, cboTerms);
            mViewModel.BindView(BOSale.INVOICE_DELIVERY, lblInvoiceDelivery, cboInvoiceDelivery);
            mViewModel.BindView(BOSale.SHIP_TO_ADDRESS_LINE1, lblAddressLine1, txtAddressLine1);
            mViewModel.BindView(BOSale.SHIP_TO_ADDRESS_LINE2, lblAddressLine2, txtAddressLine2);
            mViewModel.BindView(BOSale.SHIP_TO_ADDRESS_LINE3, lblAddressLine3, txtAddressLine3);
            mViewModel.BindView(BOSale.SHIP_TO_ADDRESS_LINE4, lblAddressLine4, txtAddressLine4);
            mViewModel.BindView(BOSale.SHIPPING_METHOD, lblShippingMethod, cboShippingMethod);
            mViewModel.BindView(BOSale.CUSTOMER, lblCustomer, cboCustomer);
            mViewModel.BindView(BOSale.CUSTOMER_PO_NUMBER, lblCustomerPO, txtCustomerPO);
            mViewModel.BindView(BOSale.FREIGHT_TAXCODE, null, cboFreightTaxCode);
            mViewModel.BindView(BOSale.FREIGHT, lblFreight, txtFreight);
            mViewModel.BindView(BOSale.IS_TAX_INCLUSIVE, chkTaxInclusive);
            mViewModel.BindView(BOSale.SALES_PERSON, lblSalesperson, cboSalesperson);
            mViewModel.BindView(BOSale.INVOICE_TYPE, lblSaleLayout, cboSaleLayout);
            mViewModel.BindView(BOSale.CURRENCY, lblCurrency, cboCurrency);
            mViewModel.BindView(BOSale.MEMO, lblJournalMemo, txtJournalMemo);
            mViewModel.BindView(BOSale.CUSTOMER_PHONE1, lblCustomerPhone1, txtCustomerPhone1);
            mViewModel.BindView(BOSale.CUSTOMER_PHONE2, lblCustomerPhone2, txtCustomerPhone2);
            mViewModel.BindView(BOSale.CUSTOMER_EMAIL, lblCustomerEmail, txtCustomerEmail);
            mViewModel.BindView(BOSale.DESTINATION_COUNTRY, lblDestinationCountry, txtDestinationCountry);
            mViewModel.BindView(BOSale.TOTAL_TAX, lblTaxValue, txtTaxValue);
            mViewModel.BindView(BOSale.TOTAL, lblTotalValue, txtTotalValue);
            mViewModel.BindView(BOSale.TOTAL_LINES, lblSubtotalValue, txtSubtotalValue);
            mViewModel.BindView(BOSale.CUSTOMER_ADDRESS, null, cboAddresses);

            mViewModel.BindView(BOSale.PERSIST_OBJECT, btnRecord);
        }

        private void Record(object sender, EventArgs args)
        {
            if (mViewModel.ValidateModel())
            {
                OpResult result = mModel.Record();
                if (result.Status == OpResult.ResultStatus.UpdateFailedOnCriteria)
                {
                    MessageBox.Show(result.Error, "Update Sale Order Failed");
                    DialogResult = DialogResult.None;
                }
                else if (result.Status == OpResult.ResultStatus.CreateFailedOnCriteria)
                {
                    MessageBox.Show(result.Error, "Create Sale Order Failed");
                    DialogResult = DialogResult.None;
                }
                else
                {
                    string error = result.Error;
                    if (string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show("Sale Order Recorded!");
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

        private void OnCustomerChanged(object sender, EventArgs args)
        {
            Customer _customer = (Customer)cboCustomer.SelectedItem;
            if (_customer == null)
            {
                return;
            }

            cboAddresses.SelectedIndex = 0;
            Address addr = _customer.Address1;
            txtCustomerPhone1.Text = addr.Phone1;
            txtCustomerPhone2.Text = addr.Phone2;
            txtDestinationCountry.Text = addr.Country;
            txtCustomerEmail.Text = addr.Email;

            cboSalesperson.SelectedItem = _customer.SalesPerson;
            cboShippingMethod.SelectedItem = _customer.ShippingMethod;
            cboInvoiceDelivery.SelectedItem = _customer.InvoiceDelivery;
            cboFreightTaxCode.SelectedItem = _customer.FreightTaxCode;
            cboTerms.SelectedItem = _customer.Terms;
            cboComments.SelectedItem = _customer.SaleComment;
            cboSaleLayout.SelectedItem = _customer.SaleLayout;
            cboCurrency.SelectedItem = _customer.Currency;

            txtFreight.Text = "0";
            txtJournalMemo.Text = mModel.GenerateJournalMemo(_customer);

            UpdateView_Address();
        }

        protected override void  LoadView()
        {
            mViewModel.UpdateView();
            SaleLines_UpdateView();
        }

        private void UpdateView_Address()
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            mApplicationController.PrintSale(mModel.Data, txtSaleNo.Text);
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

        private void SaleLines_UpdateView()
        {
            dgvSaleLines.AutoGenerateColumns = false;
            dgvSaleLines.Columns.Clear();

            DataGridViewColumn c = null;

            if (mModel.IsItem)
            {
                dgvSaleLines.DataSource = mModel.ItemSaleLines;

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "_Ordered";
                c.HeaderText = "Order";
                dgvSaleLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "_Received";
                c.HeaderText = "Received";
                dgvSaleLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "ItemNumber";
                c.HeaderText = "Item #";
                dgvSaleLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "ItemName";
                c.HeaderText = "Description";
                dgvSaleLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "_Price";
                c.HeaderText = "Price";
                dgvSaleLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "Discount";
                c.HeaderText = "Disc%";
                dgvSaleLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "_Total";
                c.HeaderText = "Total";
                dgvSaleLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "JobNumber";
                c.HeaderText = "Job";
                dgvSaleLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "_TaxCode";
                c.HeaderText = "Tax";
                dgvSaleLines.Columns.Add(c);
            }
            else if (mModel.IsMisc)
            {
                dgvSaleLines.DataSource = mModel.MiscSaleLines;

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "Description";
                c.HeaderText = "Description";
                dgvSaleLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "AccountNumber";
                c.HeaderText = "Acct#";
                dgvSaleLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "_Total";
                c.HeaderText = "Amount";
                dgvSaleLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "JobNumber";
                c.HeaderText = "Job";
                dgvSaleLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "_TaxCode";
                c.HeaderText = "Tax";
                dgvSaleLines.Columns.Add(c);
            }
            else if (mModel.IsService)
            {
                dgvSaleLines.DataSource = mModel.ServiceSaleLines;

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "Description";
                c.HeaderText = "Description";
                dgvSaleLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "AccountNumber";
                c.HeaderText = "Acct#";
                dgvSaleLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "_Total";
                c.HeaderText = "Amount";
                dgvSaleLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "JobNumber";
                c.HeaderText = "Job";
                dgvSaleLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "_TaxCode";
                c.HeaderText = "Tax";
                dgvSaleLines.Columns.Add(c);
            }
            else if (mModel.IsProfessional)
            {
                dgvSaleLines.DataSource = mModel.ProfessionalSaleLines;

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "_LineDate";
                c.HeaderText = "Date";
                dgvSaleLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "Description";
                c.HeaderText = "Description";
                dgvSaleLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "AccountNumber";
                c.HeaderText = "Acct#";
                dgvSaleLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "_Total";
                c.HeaderText = "Amount";
                dgvSaleLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "JobNumber";
                c.HeaderText = "Job";
                dgvSaleLines.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "_TaxCode";
                c.HeaderText = "Tax";
                dgvSaleLines.Columns.Add(c);
            }
            else if (mModel.IsTimeBilling)
            {
                dgvSaleLines.DataSource = mModel.TimeBillingSaleLines;
            }

            DacII.Util.DataGridViewHelper.UpdateColumnHeaderStyles(dgvSaleLines);
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            string barcode = txtSaleNo.Text;
            Util.FrmGenBarcode frm = new Util.FrmGenBarcode();
            frm.GenBarcode(barcode);
        }

        private void btnNewLine_Click(object sender, EventArgs e)
        {
            if (mApplicationController.CreateSaleLine(mModel.Data))
            {
                SaleLines_UpdateView();
            }
        }


        private void btnDelLine_Click(object sender, EventArgs e)
        {
            if (dgvSaleLines.SelectedRows.Count == 0) return;
            mApplicationController.DeleteSaleLine(dgvSaleLines.SelectedRows[0].DataBoundItem as SaleLine);
            SaleLines_UpdateView();
        }

        private void dgvSaleLines_DoubleClick(object sender, EventArgs e)
        {
            if (dgvSaleLines.SelectedRows.Count == 0) return;
            mApplicationController.OpenSaleLine(dgvSaleLines.SelectedRows[0].DataBoundItem as SaleLine);
        }
    }
}