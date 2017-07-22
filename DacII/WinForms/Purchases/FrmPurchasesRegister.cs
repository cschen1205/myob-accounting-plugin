using System;
using System.Windows.Forms;

namespace DacII.WinForms.Purchases
{
    using DacII.Presenters;
    using DacII.ViewModels;
    using DacII.DacHandlers;

    using Accounting.Core.Cards;
    using Accounting.Core.Definitions;
    using Accounting.Bll.Purchases;
    using Accounting.Core.Purchases;

    public partial class FrmPurchasesRegister : BaseView
    {
        private BOListPurchase mModel;
        private BOViewModel mViewModel;

        public FrmPurchasesRegister(ApplicationPresenter ap, BOListPurchase model)
            : base(ap)
        {
            InitializeComponent();

            //code added to ensure date time value changed event will be fired later when the datetime field value is set to now
            DateTime default_date = new DateTime(DateTime.Now.Year - 100, 1, 1);
            dtpEndDate.Value = default_date;
            dtpStartDate.Value = default_date;

            mModel = model;
            mViewModel = new BOViewModel(model);

            BindViews();
            RegisterEventHandlers();

            ConfigureDataGridView(dgvAll);
            ConfigureDataGridView(dgvQuote);
            ConfigureDataGridView(dgvOrder);
            ConfigureDataGridView(dgvOpenBill);
            ConfigureDataGridView(dgvDebitReturn);
            ConfigureDataGridView(dgvClosedBill);
        }

        private void ConfigureDataGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            DataGridViewColumn c = null;

            

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "PurchaseNumber";
            c.HeaderText = "Purchase #";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "Supplier";
            c.HeaderText = "Supplier";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "PurchaseDate";
            c.HeaderText = "Purchase Date";
            dgv.Columns.Add(c);

            if (dgv == dgvAll)
            {
                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "PurchaseStatus";
                c.HeaderText = "Status";
                dgv.Columns.Add(c);
            }

            DacII.Util.DataGridViewHelper.UpdateColumnHeaderStyles(dgv);
        }

        protected override void BindViews()
        {
            dgvAll.DataSource = mModel.AllPurchases;
            dgvQuote.DataSource = mModel.Quotes;
            dgvOrder.DataSource = mModel.Orders;
            dgvOpenBill.DataSource = mModel.OpenBills;
            dgvClosedBill.DataSource = mModel.ClosedBills;
            dgvDebitReturn.DataSource = mModel.DebitReturns;

            cboSupplierSearchCriteria.DataSource = mApplicationController.FindAllSuppliers();
            if (cboSupplierSearchCriteria.Items.Count != 0) cboSupplierSearchCriteria.SelectedIndex = 0;

            mViewModel.BindView(BOListPurchase.CREATE_QUOTE, btnCreateQuote);
            mViewModel.BindView(BOListPurchase.CREATE_ORDER, btnCreateOrder);
            mViewModel.BindView(BOListPurchase.DELETE_QUOTE, btnDelQuote);

            mViewModel.BindView(BOListPurchase.CHANGE_QUOTE_TO_ORDER, btnChangeQuote2Order);
            mViewModel.BindView(BOListPurchase.CHANGE_QUOTE_TO_BILL, btnChangeQuote2OpenBill);
            mViewModel.BindView(BOListPurchase.CHANGE_ORDER_TO_BILL, btnChangeOrder2OpenBill);

            mViewModel.BindView(BOListPurchase.START_DATE, lblStartDate, dtpStartDate);
            mViewModel.BindView(BOListPurchase.END_DATE, lblEndDate, dtpEndDate);
            mViewModel.BindView(BOListPurchase.SUPPLIER, lblSupplierSearchCriteria, cboSupplierSearchCriteria);
            mViewModel.BindView(BOListPurchase.ALL_SUPPLIERS, chkAllSuppliers);

            mViewModel.BindView(BOListPurchase.ALL_PURCHASES_INFORMATION, lblCountAll);
            mViewModel.BindView(BOListPurchase.QUOTES_INFORMATION, lblCountQuotes);
            mViewModel.BindView(BOListPurchase.ORDERS_INFORMATION, lblCountOrders);
            mViewModel.BindView(BOListPurchase.OPEN_BILLS_INFORMATION, lblCountOpenBills);
            mViewModel.BindView(BOListPurchase.CLOSED_BILLS_INFORMATION, lblCountClosedBills);
            mViewModel.BindView(BOListPurchase.DEBIT_RETURNS_INFORMATION, lblCountDebitReturns);
        }

        private void ChangeOrder2OpenBill(object sender, EventArgs args)
        {
            if (dgvOrder.SelectedRows.Count == 0) return;
            mApplicationController.CreatePurchaseOpenBillFromOrder(dgvOrder.SelectedRows[0].DataBoundItem as Purchase);
        }

        private void ChangeQuote2OpenBill(object sender, EventArgs args)
        {
            if (dgvQuote.SelectedRows.Count == 0) return;
            mApplicationController.CreatePurchaseOpenBillFromQuote(dgvQuote.SelectedRows[0].DataBoundItem as Purchase);
        }

        private void ChangeQuote2Order(object sender, EventArgs args)
        {
            if (dgvQuote.SelectedRows.Count == 0) return;
            mApplicationController.CreatePurchaseOrderFromQuote(dgvQuote.SelectedRows[0].DataBoundItem as Purchase);
        }

        private void DeleteQuote(object sender, EventArgs args)
        {
            if (dgvQuote.SelectedRows.Count == 0) return;
            mApplicationController.DeletePurchase(dgvQuote.SelectedRows[0].DataBoundItem as Purchase);
        }

        private void CreatePurchaseQuote(object sender, EventArgs args)
        {
            mApplicationController.CreatePurchaseQuote();
        }

        private void CreatePurchaseOrder(object sender, EventArgs args)
        {
            mApplicationController.CreatePurchaseOrder();
        }

        protected override void RegisterEventHandlers()
        {
            RegisterEventHandler(chkAllSuppliers, DacEventHandler.EventTypes.CheckedChanged, new System.EventHandler(this.chkAllSuppliers_CheckedChanged));
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

            chkAllSuppliers.Checked = true;
            cboSupplierSearchCriteria.Enabled = !chkAllSuppliers.Checked;

            mViewModel.UpdateView();
        }

        private void chkAllSuppliers_CheckedChanged(object sender, EventArgs e)
        {
            chkAllSuppliers.ImageIndex = chkAllSuppliers.Checked ? 0 : 1;
            cboSupplierSearchCriteria.Enabled = !chkAllSuppliers.Checked;
        }

        private void btnScanBarcode_Click(object sender, EventArgs e)
        {
            mApplicationController.ShowBarcodeReader(new DacII.WinForms.Util.FrmReadBarcode.BarcodeReadHandler(BarcodeRead));
        }

        void BarcodeRead(string barcode)
        {
            Purchase instance = mModel.FindByPurchaseNumber(barcode);
            if (instance == null)
            {
                MessageBox.Show(string.Format("Failed to find the purchase with purchase number {0}", barcode));
                return;
            }
            mApplicationController.OpenPurchase(instance);
        }

        private void dgvAll_DoubleClick(object sender, EventArgs e)
        {
            if (dgvAll.SelectedRows.Count == 0) return;
            mApplicationController.OpenPurchase(dgvAll.SelectedRows[0].DataBoundItem as Purchase);
        }

        private void dgvQuote_DoubleClick(object sender, EventArgs e)
        {
            if (dgvQuote.SelectedRows.Count == 0) return;
            mApplicationController.OpenPurchase(dgvQuote.SelectedRows[0].DataBoundItem as Purchase);
        }

        private void dgvOrder_DoubleClick(object sender, EventArgs e)
        {
            if (dgvOrder.SelectedRows.Count == 0) return;
            mApplicationController.OpenPurchase(dgvOrder.SelectedRows[0].DataBoundItem as Purchase);
        }

        private void dgvOpenBill_DoubleClick(object sender, EventArgs e)
        {
            if (dgvOpenBill.SelectedRows.Count == 0) return;
            mApplicationController.OpenPurchase(dgvOpenBill.SelectedRows[0].DataBoundItem as Purchase);
        }

        private void dgvDebitReturn_DoubleClick(object sender, EventArgs e)
        {
            if (dgvDebitReturn.SelectedRows.Count == 0) return;
            mApplicationController.OpenPurchase(dgvDebitReturn.SelectedRows[0].DataBoundItem as Purchase);
        }

        private void dgvClosedBill_DoubleClick(object sender, EventArgs e)
        {
            if (dgvClosedBill.SelectedRows.Count == 0) return;
            mApplicationController.OpenPurchase(dgvClosedBill.SelectedRows[0].DataBoundItem as Purchase);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            mModel.InvalidateDataStore();
        }

        private void CreateOpenBill(object sender, EventArgs e)
        {
            mApplicationController.CreatePurchaseOpenBill();
        }
    }
}