using System;
using System.Windows.Forms;

namespace DacII.WinForms.Security
{
    using DacII.Presenters;
    using DacII.ViewModels;
    using Accounting.Bll;
    using Accounting.Bll.Security;
    using Accounting.Core.Security;
    using Accounting.Core.Cards;

    public partial class FrmAuthUser : BaseView
    {
        BOUser mModel;
        BOViewModel mViewModel;
        public FrmAuthUser(ApplicationPresenter ap, BOUser model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;
            mViewModel = new BOViewModel(model);
            mViewModel.ErrorProvider = errorProvider;

            BindViews();
            RegisterEventHandlers();
        }

        public BOUser Model
        {
            set
            {
                mModel = value;
                mViewModel.Model = value;
            }
        }

        protected override void BindViews()
        {
            cboRole.DataSource = mApplicationController.FindAllAuthRoles();
            cboEmployee.DataSource = mApplicationController.FindAllEmployees();

            mViewModel.BindView(BOUser.USER_NAME, lblUsername, txtUsername);
            mViewModel.BindView(BOUser.USER_PASSWORD, lblPassword, txtPassword);
            mViewModel.BindView(BOUser.USER_ROLE, lblRole, cboRole);
            mViewModel.BindView(BOUser.USER_DESCRIPTION, lblDescription, cboEmployee);
        }

        protected override void LoadView()
        {
            base.LoadView();
            mViewModel.UpdateView();
        }

        private void btnOK_Click(object sender, EventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
