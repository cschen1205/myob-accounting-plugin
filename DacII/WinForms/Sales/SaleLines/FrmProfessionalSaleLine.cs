using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.Bll.Sales.SaleLines;
using Accounting.Core.Accounts;
using Accounting.Core.TaxCodes;
using Accounting.Core.Jobs;

namespace DacII.WinForms.Sales.SaleLines
{
    using DacII.Presenters;
    using DacII.ViewModels;

    public partial class FrmProfessionalSaleLine : BaseView
    {
        private BOProfessionalSaleLine mModel = null;
        private BOViewModel mViewModel;

        public FrmProfessionalSaleLine(ApplicationPresenter ap, BOProfessionalSaleLine model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;
            mViewModel = new BOViewModel(mModel);
            mViewModel.ErrorProvider = errorProvider;

            BindViews();
            RegisterEventHandlers();
        }

        public BOProfessionalSaleLine Model
        {
            set
            {
                mModel = value;
                mViewModel.Model = value;
            }
        }

        private void OnAccountChanged(object sender, EventArgs args)
        {
            Account _obj = (Account)cboAccount.SelectedItem;
            if (_obj == null)
            {
                txtAmount.Text = string.Format("{0}", 0);
                cboTax.SelectedIndex = -1;
                return;
            }
            cboTax.SelectedItem = _obj.TaxCode;
            txtAmount.Text = string.Format("{0}", 0);
        }

        protected override void BindViews()
        {
            base.BindViews();

            cboAccount.DataSource = mApplicationController.FindAllAccounts();
            cboTax.DataSource = mApplicationController.FindAllTaxCodes();
            cboJob.DataSource = mApplicationController.FindAllJobs();

            mViewModel.BindView(BOProfessionalSaleLine.ACCOUNT, lblAccount, cboAccount);
            mViewModel.BindView(BOProfessionalSaleLine.TAXCODE, lblTax, cboTax);
            mViewModel.BindView(BOProfessionalSaleLine.JOB, lblJob, cboJob);
            mViewModel.BindView(BOProfessionalSaleLine.LINE_DATE, lblLineDate, dtpLineDate);
            mViewModel.BindView(BOProfessionalSaleLine.AMOUNT, lblAmount, txtAmount);
            mViewModel.BindView(BOProfessionalSaleLine.DESCRIPTION, lblDescription, txtDescription);
            mViewModel.BindView(BOProfessionalSaleLine.PERSIST_OBJECT, btnOK);
        }

        private void Record(object sender, EventArgs args)
        {
            if (mViewModel.ValidateModel())
            {
                mModel.Update();
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        protected override void LoadView()
        {
            base.LoadView();
            mViewModel.UpdateView();
        }
    }
}
