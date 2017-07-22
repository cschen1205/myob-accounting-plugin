using System;
using System.Windows.Forms;


namespace DacII.WinForms.Definitions
{
    using Accounting.Bll;
    using Accounting.Bll.Definitions;
    using Accounting.Core.Definitions;

    using DacII.Presenters;
    using DacII.ViewModels;

    public partial class FrmDataFieldsRegister : BaseView
    {
        private BOListDataField mModel;
        private BOViewModel mViewModel;

        public FrmDataFieldsRegister(ApplicationPresenter ap, BOListDataField model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;
            mViewModel = new BOViewModel(mModel);

            BindViews();
            RegisterEventHandlers();

            ConfigureDataGridView(dgv);
        }

        private void ConfigureDataGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            DataGridViewColumn c = null;

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "DataFieldName";
            c.HeaderText = "Field Name";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "DataFieldType";
            c.HeaderText = "Data Type";
            dgv.Columns.Add(c);

            DacII.Util.DataGridViewHelper.UpdateColumnHeaderStyles(dgv);
        }

        protected override void BindViews()
        {
            dgv.DataSource = mModel.DataSource;
        }

        private void OpenDataField(object sender, EventArgs args)
        {
            if (dgv.SelectedRows.Count == 0) return;
            mApplicationController.OpenDataFieldForItemAddOn(dgv.SelectedRows[0].DataBoundItem as DataField);
        }

        private void CreateDataField(object sender, EventArgs args)
        {
            mApplicationController.CreateDataFieldForItemAddOn();
        }

        private void DeleteDataField(object sender, EventArgs args)
        {
            if (dgv.SelectedRows.Count == 0) return;
            mApplicationController.DeleteDataFieldForItemAddOn(dgv.SelectedRows[0].DataBoundItem as DataField);
        }

        protected override void LoadView()
        {
            mViewModel.UpdateView();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }
    }
}
