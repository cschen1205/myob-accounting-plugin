using System;
using System.Windows.Forms;

namespace DacII.WinForms.Definitions
{
    using DacII.Presenters;
    using DacII.ViewModels;

    using Accounting.Bll;
    using Accounting.Bll.Definitions;
    using Accounting.Core.Definitions;

    public partial class FrmGendersRegister : BaseView
    {
        private BOListGender mModel = null;
        private BOViewModel mViewModel;

        public FrmGendersRegister(ApplicationPresenter ap, BOListGender model)
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
            c.DataPropertyName = "GenderID";
            c.HeaderText = "Gender";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "Description";
            c.HeaderText = "Details";
            dgv.Columns.Add(c);

            DacII.Util.DataGridViewHelper.UpdateColumnHeaderStyles(dgv);
        }

        public BOListGender Model
        {
            set
            {
                mModel = value;
                mViewModel.Model = value;
            }
        }

        private void OpenGender(object sender, EventArgs args)
        {
            if (dgv.SelectedRows.Count == 0) return;
            mApplicationController.OpenGenderForItemAddOn(dgv.SelectedRows[0].DataBoundItem as Gender);
        }

        protected override void BindViews()
        {
            dgv.DataSource = mModel.DataSource;
        }

        private void CreateGender(object sender, EventArgs args)
        {
            mApplicationController.CreateGenderForItemAddOn();
        }

        private void DeleteGender(object sender, EventArgs args)
        {
            if (dgv.SelectedRows.Count == 0) return;
            mApplicationController.DeleteGenderForItemAddOn(dgv.SelectedRows[0].DataBoundItem as Gender);
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
