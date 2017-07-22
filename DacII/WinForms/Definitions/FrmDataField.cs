using System;
using System.Windows.Forms;
using Accounting.Bll.Definitions;

namespace DacII.WinForms.Definitions
{
    using DacII.Presenters;
    using DacII.ViewModels;

    public partial class FrmDataField : BaseView
    {
        private BODataField mModel = null;
        private BOViewModel mViewModel;

        public FrmDataField(ApplicationPresenter ap, BODataField model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;
            mViewModel = new BOViewModel(mModel);
            mViewModel.ErrorProvider = errorProvider;

            BindViews();
            RegisterEventHandlers();
        }

        public BODataField Model
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

            mViewModel.BindView(BODataField.DATA_FIELD_NAME, lblDataFieldName, txtDataFieldName);
            mViewModel.BindView(BODataField.DATA_FIELD_TYPE, lblDataFieldType, cboDataFieldType);
            mViewModel.BindView(BODataField.PERSIST_OBJECT, btnOK);
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
            GoBack();
        }
    }
}
