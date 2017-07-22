using System;
using System.Windows.Forms;
using Accounting.Bll.Inventory;

namespace DacII.WinForms.Inventory
{
    using DacII.Presenters;
    using DacII.ViewModels;

    public partial class FrmItemDataFieldEntry : BaseView
    {
        private BOItemDataFieldEntry mModel = null;
        private BOViewModel mViewModel;

        public FrmItemDataFieldEntry(ApplicationPresenter ap, BOItemDataFieldEntry model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;
            mViewModel = new BOViewModel(mModel);
            mViewModel.ErrorProvider = errorProvider;

            BindViews();
            RegisterEventHandlers();
        }

        public BOItemDataFieldEntry Model
        {
            set
            {
                mModel = value;
                mViewModel.Model = mModel;
            }
        }

        protected override void BindViews()
        {
            base.BindViews();
            cboDataField.DataSource = mApplicationController.FindAllDataFieldsForItemAddOn();

            mViewModel.BindView(BOItemDataFieldEntry.DATA_FIELD, lblDataField, cboDataField);
            mViewModel.BindView(BOItemDataFieldEntry.CONTENT, lblContent, txtContent);
            mViewModel.BindView(BOItemDataFieldEntry.PERSIST_OBJECT, btnOK);
        }

        private void Record(object sender, EventArgs args)
        {
            if (mViewModel.ValidateModel())
            {
                mModel.Record();
            }
            else
            {
                DialogResult = DialogResult.None;
                return;
            }
            DialogResult = DialogResult.OK;
        }

        protected override void LoadView()
        {
            base.LoadView();
            mViewModel.UpdateView();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
