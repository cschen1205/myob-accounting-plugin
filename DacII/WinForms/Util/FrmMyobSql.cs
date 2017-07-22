using System;

namespace DacII.WinForms.Util
{
    using DacII.Presenters;
    using Accounting.Bll;
    using Accounting.Bll.Util;

    public partial class FrmMyobSql : BaseView
    {
        private Accountant mMyobAccountant;
        private BOSql mModel ;
        public FrmMyobSql(ApplicationPresenter ap)
            : base(ap)
        {
            InitializeComponent();

            mMyobAccountant = mApplicationController.mAccountant;
            mModel = new BOSql(mMyobAccountant, "MyobSql");
            mModel.QueryUpdated += new BOSql.QueryUpdatedHandler(mModel_QueryUpdated);

            BindViews();
            RegisterEventHandlers();
        }

        void mModel_QueryUpdated(string query)
        {
            dgv.DataSource = mModel.GetQueryDataGridView(query);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string query = txtSqlQuery.Text;
            mModel.Query = query;
        }

        protected override void LoadView()
        {
            txtSqlQuery.Text = mModel.Query;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void btnScript_Click(object sender, EventArgs e)
        {
            FrmScript frm = new FrmScript(mApplicationController);
            frm.ShowDialog();
        }
    }
}