using System;
using System.Windows.Forms;


namespace DacII.WinForms.Definitions
{
    using DacII.Presenters;
    using DacII.ViewModels;

    using Accounting.Bll.Definitions;
    using Accounting.Core.Definitions;

    public partial class FrmItemSizesRegister : BaseView
    {
        private BOListItemSize mModel;
        private BOViewModel mViewModel;

        public FrmItemSizesRegister(ApplicationPresenter ap, BOListItemSize model)
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
            c.DataPropertyName = "ItemSizeID";
            c.HeaderText = "Item Size";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "Description";
            c.HeaderText = "Details";
            dgv.Columns.Add(c);

            DacII.Util.DataGridViewHelper.UpdateColumnHeaderStyles(dgv);
        }

        private void OpenItemSize(object sender, EventArgs args)
        {
            if (dgv.SelectedRows.Count == 0) return;
            mApplicationController.OpenItemSizeForItemAddOn(dgv.SelectedRows[0].DataBoundItem as ItemSize);
        }

        private void CreateItemSize(object sendre, EventArgs args)
        {
            mApplicationController.CreateItemSizeForItemAddOn();
        }

        private void DeleteItemSize(object sender, EventArgs args)
        {
            if (dgv.SelectedRows.Count == 0) return;
            mApplicationController.DeleteItemSizeForItemAddOn(dgv.SelectedRows[0].DataBoundItem as ItemSize);
        }

        protected override void BindViews()
        {
            dgv.DataSource = mModel.DataSource;
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
