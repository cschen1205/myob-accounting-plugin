using System;
using System.Text;
using System.Windows.Forms;

namespace DacII.WinForms.Inventory
{
    using DacII.Presenters;
    using DacII.DacHandlers;

    using Accounting.Bll.Inventory;
    using Accounting.Bll.Purchases;
    using Accounting.Bll.Sales;
    using Accounting.Bll;
    using DacII.WinForms.Purchases;
    using DacII.WinForms.Sales;
    using DacII.ViewModels;

    public partial class FrmItemRegister : BaseView
    {
        private BOItemsRegister mModel;
        private BOViewModel mViewModel = null;

        public FrmItemRegister(ApplicationPresenter ap, BOItemsRegister model)
            : base(ap)
        {
            InitializeComponent();

            //code added to ensure date time value changed event will be fired later when the datetime field value is set to now
            DateTime default_date = new DateTime(DateTime.Now.Year - 100, 1, 1);
            dtpEndDate.Value = default_date;
            dtpStartDate.Value = default_date;

            mModel = model;
            mViewModel = new BOViewModel(mModel);

            BindViews();
            RegisterEventHandlers();

            ConfigureDataGridView(dgvAll);
        }

        protected override void BindViews()
        {
            base.BindViews();

            dgvAll.DataSource = mModel.Journals;

            cboItemSearchCriteria.DataSource = mApplicationController.FindAllItems();
            if (cboItemSearchCriteria.Items.Count != 0) cboItemSearchCriteria.SelectedIndex = 0;

            mViewModel.BindView(BOItemsRegister.START_DATE, lblStartDate, dtpStartDate);
            mViewModel.BindView(BOItemsRegister.END_DATE, lblEndDate, dtpEndDate);
            mViewModel.BindView(BOItemsRegister.ITEM, lblItemSearchCriteria, cboItemSearchCriteria);
            mViewModel.BindView(BOItemsRegister.ALL_ITEMS, chkAllItems);
        }

        protected override void LoadView()
        {
            DateTime end_date = DateTime.Now;
            DateTime start_date = new DateTime(DateTime.Now.Year, 1, 1);

            dtpEndDate.Value = end_date;
            dtpStartDate.Value = start_date;

            chkAllItems.Checked = true;
            cboItemSearchCriteria.Enabled = !chkAllItems.Checked;

            dgvAll.DataSource = mModel.Journals;

            mViewModel.UpdateView();
        }

        private void ConfigureDataGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            DataGridViewColumn c = null;

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "Date";
            c.HeaderText = "Date";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "Src";
            c.HeaderText = "Src";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "JournalID";
            c.HeaderText = "ID #";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "Memo";
            c.HeaderText = "Memo";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "Quantity";
            c.HeaderText = "Quantity";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "Amount";
            c.HeaderText = "Amount";
            dgv.Columns.Add(c);

            DacII.Util.DataGridViewHelper.UpdateColumnHeaderStyles(dgv);
        }

        protected override void RegisterEventHandlers()
        {
            RegisterEventHandler(chkAllItems, DacEventHandler.EventTypes.CheckedChanged, new System.EventHandler(this.chkAllItems_CheckedChanged));
        }

        private void chkAllItems_CheckedChanged(object sender, EventArgs e)
        {
            cboItemSearchCriteria.Enabled = !chkAllItems.Checked;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void dgvAll_DoubleClick(object sender, EventArgs e)
        {
            if (dgvAll.SelectedRows.Count == 0) return;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            mModel.Refresh();
            dgvAll.DataSource = mModel.Journals;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            mApplicationController.ShowItemsRegisterSummaryRpt();
        }
    }
}
