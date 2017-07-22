using System;
using System.Windows.Forms;

namespace DacII.WinForms.Sales
{
    using DacII.Presenters;
    using DacII.ViewModels;
    using DacII.DacHandlers;

    using Accounting.Core.Cards;
    using Accounting.Core.Definitions;
    using Accounting.Bll.Sales;
    using Accounting.Core.Sales;

    public partial class FrmSalesRegister : BaseView
    {
        private BOListSale mModel;
        private BOViewModel mViewModel;

        public FrmSalesRegister(ApplicationPresenter ap, BOListSale model)
            : base(ap)
        {
            InitializeComponent();

            //code added to ensure date time value changed event will be fired later when the datetime field value is set to now
            DateTime default_date = new DateTime(DateTime.Now.Year - 100, 1, 1);
            dtpEndDate.Value = default_date;
            dtpStartDate.Value = default_date;

            mModel = model;
            mViewModel=new BOViewModel(mModel); 

            BindViews();
            RegisterEventHandlers();

            ConfigureDataGridView(dgvAll);
            ConfigureDataGridView(dgvQuote);
            ConfigureDataGridView(dgvOrder);
            ConfigureDataGridView(dgvOpenInvoice);
            ConfigureDataGridView(dgvCreditReturn);
            ConfigureDataGridView(dgvClosedInvoice);
        }

        private void ConfigureDataGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            DataGridViewColumn c = null;

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "InvoiceNumber";
            c.HeaderText = "Invoice #";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "Customer";
            c.HeaderText = "Customer";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "InvoiceDate";
            c.HeaderText = "Invoice Date";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "AmountText";
            c.HeaderText = "Amount";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "AmountDueText";
            c.HeaderText = "Amt Due";
            dgv.Columns.Add(c);

            if (dgv == dgvAll)
            {
                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "InvoiceStatus";
                c.HeaderText = "Status";
                dgv.Columns.Add(c);
            }

            DacII.Util.DataGridViewHelper.UpdateColumnHeaderStyles(dgv);
        }

        private void OpenFrom_AllSales(object sender, EventArgs args)
        { 
             if (dgvAll.SelectedRows.Count == 0) return;
             mApplicationController.OpenSale(dgvAll.SelectedRows[0].DataBoundItem as Sale);
        }

        protected override void BindViews()
        {
            dgvAll.DataSource = mModel.AllSales;
            dgvQuote.DataSource = mModel.Quotes;
            dgvOrder.DataSource = mModel.Orders;
            dgvOpenInvoice.DataSource = mModel.OpenInvoices;
            dgvClosedInvoice.DataSource = mModel.ClosedInvoices;
            dgvCreditReturn.DataSource = mModel.CreditReturns;

            cboCustomerSearchCriteria.DataSource = mApplicationController.FindAllCustomers();
            if (cboCustomerSearchCriteria.Items.Count != 0) cboCustomerSearchCriteria.SelectedIndex = 0;

            mViewModel.BindView(BOListSale.CREATE_QUOTE, btnCreateQuote);
            mViewModel.BindView(BOListSale.CREATE_ORDER, btnCreateOrder);
            mViewModel.BindView(BOListSale.DELETE_QUOTE, btnDelQuote);

            mViewModel.BindView(BOListSale.CHANGE_QUOTE_TO_ORDER, btnChangeQuote2Order);
            mViewModel.BindView(BOListSale.CHANGE_QUOTE_TO_INVOICE, btnChangeQuote2OpenInvoice);
            mViewModel.BindView(BOListSale.CHANGE_ORDER_TO_INVOICE, btnChangeOrder2OpenInvoice);

            mViewModel.BindView(BOListSale.START_DATE, lblStartDate, dtpStartDate);
            mViewModel.BindView(BOListSale.END_DATE, lblEndDate, dtpEndDate);
            mViewModel.BindView(BOListSale.CUSTOMER, lblCustomerSearchCriteria, cboCustomerSearchCriteria);
            mViewModel.BindView(BOListSale.ALL_CUSTOMERS, chkAllCustomers);

            mViewModel.BindView(BOListSale.ALL_SALES_INFORMATION, lblCountAll);
            mViewModel.BindView(BOListSale.QUOTES_INFORMATION, lblCountQuotes);
            mViewModel.BindView(BOListSale.ORDERS_INFORMATION, lblCountOrders);
            mViewModel.BindView(BOListSale.OPEN_INVOICES_INFORMATION, lblCountOpenInvoices);
            mViewModel.BindView(BOListSale.CLOSED_INVOICES_INFORMATION, lblCountClosedInvoices);
            mViewModel.BindView(BOListSale.CREDIT_RETURNS_INFORMATION, lblCountCreditReturns);
        }

        private void OpenFrom_ClosedInvoices(object sender, EventArgs args)
        {
            if (dgvClosedInvoice.SelectedRows.Count == 0) return;
            mApplicationController.OpenSale(dgvClosedInvoice.SelectedRows[0].DataBoundItem as Sale);
        }

        private void OpenFrom_OpenInvoices(object sender, EventArgs args)
        {
            if (dgvOpenInvoice.SelectedRows.Count == 0) return;
            mApplicationController.OpenSale(dgvOpenInvoice.SelectedRows[0].DataBoundItem as Sale);
        }

        private void OpenFrom_CreditReturns(object sender, EventArgs args)
        {
            if (dgvCreditReturn.SelectedRows.Count == 0) return;
            mApplicationController.OpenSale(dgvCreditReturn.SelectedRows[0].DataBoundItem as Sale);
        }

        private void CreateSaleQuote(object sender, EventArgs args)
        {
            mApplicationController.CreateSaleQuote();
        }

        private void CreateSaleOrder(object sender, EventArgs args)
        {
            mApplicationController.CreateSaleOrder();
        }

        private void CreateSaleOpenInvoice(object sender, EventArgs args)
        {
            mApplicationController.CreateSaleOpenInvoice();
        }

        private void DeleteQuote(object sender, EventArgs args)
        {
            if (dgvQuote.SelectedRows.Count == 0) return;
            mApplicationController.DeleteSale(dgvQuote.SelectedRows[0].DataBoundItem as Sale);
        }

        private void ChangeQuote2Order(object sender, EventArgs args)
        {
            if (dgvQuote.SelectedRows.Count == 0) return;
            mApplicationController.CreateSaleOrderFromQuote(dgvQuote.SelectedRows[0].DataBoundItem as Sale);
        }

        private void ChangeQuote2OpenInvoice(object sender, EventArgs args)
        {
            if (dgvQuote.SelectedRows.Count == 0) return;
            mApplicationController.CreateSaleOpenInvoiceFromQuote(dgvQuote.SelectedRows[0].DataBoundItem as Sale);
        }

        private void ChangeOrder2OpenInvoice(object sender, EventArgs args)
        {
            if (dgvOrder.SelectedRows.Count == 0) return;
            mApplicationController.CreateSaleOpenInvoiceFromOrder(dgvOrder.SelectedRows[0].DataBoundItem as Sale);
        }

        private void OpenFrom_Quotes(object sender, EventArgs args)
        {
            if (dgvQuote.SelectedRows.Count == 0) return;
            mApplicationController.OpenSale(dgvQuote.SelectedRows[0].DataBoundItem as Sale);
        }

        private void OpenFrom_Orders(object sender, EventArgs args)
        {
            if (dgvOrder.SelectedRows.Count == 0) return;
            mApplicationController.OpenSale(dgvOrder.SelectedRows[0].DataBoundItem as Sale);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }

       protected override void  LoadView()
        {
            DateTime end_date = DateTime.Now;
            DateTime start_date = new DateTime(DateTime.Now.Year, 1, 1);
            dtpEndDate.Value = end_date;
            dtpStartDate.Value = start_date;

           chkAllCustomers.Checked = true;
           cboCustomerSearchCriteria.Enabled = !chkAllCustomers.Checked;

           mViewModel.UpdateView();
        }

       protected override void RegisterEventHandlers()
       {
           RegisterEventHandler(chkAllCustomers, DacEventHandler.EventTypes.CheckedChanged, new System.EventHandler(this.chkAllCustomers_CheckedChanged));
       }

        private void btnPrint_Click(object sender, EventArgs e)
        {
 
        }

        private void chkAllCustomers_CheckedChanged(object sender, EventArgs e)
        {
            //chkAllCustomers.ImageIndex = chkAllCustomers.Checked ? 0 : 1;
            cboCustomerSearchCriteria.Enabled = !chkAllCustomers.Checked;
        }

        private void btnScanBarcode_Click(object sender, EventArgs e)
        {
            mApplicationController.ShowBarcodeReader(new DacII.WinForms.Util.FrmReadBarcode.BarcodeReadHandler(BarcodeRead));
        }

        void BarcodeRead(string barcode)
        {
            Sale instance = mModel.FindByInvoiceNumber(barcode);
            if (instance == null)
            {
                MessageBox.Show(string.Format("Failed to find the sale with invoice number {0}", barcode));
                return;
            }
            mApplicationController.OpenSale(instance);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            mModel.InvalidateDataStore();
        }
    }
}