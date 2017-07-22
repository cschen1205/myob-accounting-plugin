using System;
using System.Windows.Forms;
using Accounting.Bll;
using Accounting.Bll.Definitions;

namespace DacII.WinForms.Definitions
{
    using DacII.Presenters;
    using DacII.ViewModels;

    public partial class FrmGender : BaseView
    {
        private BOGender mModel = null;
        private BOViewModel mViewModel;

        public FrmGender(ApplicationPresenter ap, BOGender model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;
            mViewModel = new BOViewModel(mModel);
            mViewModel.ErrorProvider = errorProvider;

            BindViews();
            RegisterEventHandlers();
        }

        public BOGender Model
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

            mViewModel.BindView(BOGender.GENDER_ID, lblID, txtID);
            mViewModel.BindView(BOGender.DESCRIPTION, lblDescription, txtDescription);
            mViewModel.BindView(BusinessObject.PERSIST_OBJECT, btnOK);
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
