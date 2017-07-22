using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace DacII.WinForms.Purchases.PurchaseLines
{
    using DacII.Presenters;
    using DacII.ViewModels;

    using Accounting.Core.Accounts;
    using Accounting.Core.TaxCodes;
    using Accounting.Core.Jobs;
    using Accounting.Bll;
    using Accounting.Bll.Purchases.PurchaseLines;

    public partial class FrmProfessionalPurchaseLine : BaseView
    {
        private BOProfessionalPurchaseLine mModel = null;
        private BOViewModel mViewModel;

        public FrmProfessionalPurchaseLine(ApplicationPresenter ap, BOProfessionalPurchaseLine model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;
            mViewModel = new BOViewModel(mModel);

            BindViews();
            RegisterEventHandlers();
        }

        public BOProfessionalPurchaseLine Model
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

            mViewModel.BindView(BOProfessionalPurchaseLine.TAXCODE, lblTax, cboTax);
            mViewModel.BindView(BOProfessionalPurchaseLine.ACCOUNT, lblAccount, cboAccount);
            mViewModel.BindView(BOProfessionalPurchaseLine.JOB, lblJob, cboJob);
            mViewModel.BindView(BOProfessionalPurchaseLine.LINE_DATE, lblLineDate, dtpLineDate);
            mViewModel.BindView(BOProfessionalPurchaseLine.AMOUNT, lblAmount, txtAmount);
            mViewModel.BindView(BOProfessionalPurchaseLine.DESCRIPTION, lblDescription, txtDescription);
            mViewModel.BindView(BOProfessionalPurchaseLine.PERSIST_OBJECT, btnOK);

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
