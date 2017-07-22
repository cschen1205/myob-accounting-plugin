using System;
using System.Windows.Forms;
using Accounting.Bll.Definitions;

namespace DacII.WinForms.Definitions
{
    using DacII.Presenters;
    using DacII.ViewModels;

    public partial class FrmItemSize : BaseView
    {
        private BOItemSize mModel = null;
        private BOViewModel mViewModel;

        public FrmItemSize(ApplicationPresenter ap, BOItemSize model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;
            mViewModel = new BOViewModel(mModel);
            mViewModel.ErrorProvider = errorProvider;

            BindViews();
            RegisterEventHandlers();
        }

        public BOItemSize Model
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

            mViewModel.BindView(BOItemSize.ITEM_SIZE_ID, lblID, txtID);
            mViewModel.BindView(BOItemSize.DESCRIPTION, lblDescription, txtDescription);
            mViewModel.BindView(BOItemSize.PERSIST_OBJECT, btnOK);
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
