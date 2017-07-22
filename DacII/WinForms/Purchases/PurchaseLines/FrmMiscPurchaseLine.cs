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

    public partial class FrmMiscPurchaseLine : BaseView
    {
        private BOMiscPurchaseLine mModel = null;
        private BOViewModel mViewModel;

        public FrmMiscPurchaseLine(ApplicationPresenter ap, BOMiscPurchaseLine model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;
            mViewModel = new BOViewModel(mModel);

            BindViews();
            RegisterEventHandlers();
        }

        public BOMiscPurchaseLine Model
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

        protected override void BindViews()
        {
            base.BindViews();

            cboAccount.DataSource = mApplicationController.FindAllAccounts();
            cboTax.DataSource = mApplicationController.FindAllTaxCodes();
            cboJob.DataSource = mApplicationController.FindAllJobs();

            mViewModel.BindView(BOMiscPurchaseLine.TAXCODE, lblTax, cboTax);
            mViewModel.BindView(BOMiscPurchaseLine.ACCOUNT, lblAccount, cboAccount);
            mViewModel.BindView(BOMiscPurchaseLine.JOB, lblJob, cboJob);
            mViewModel.BindView(BOMiscPurchaseLine.AMOUNT, lblAmount, txtAmount);
            mViewModel.BindView(BOMiscPurchaseLine.DESCRIPTION, lblDescription, txtDescription);
            mViewModel.BindView(BOMiscPurchaseLine.PERSIST_OBJECT, btnOK);
        }

        protected override void LoadView()
        {
            base.LoadView();
            mViewModel.UpdateView();
        }
    }
}
