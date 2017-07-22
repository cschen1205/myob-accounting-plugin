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

    public partial class FrmServicePurchaseLine : BaseView
    {
        private BOServicePurchaseLine mModel = null;
        private BOViewModel mViewModel;

        public FrmServicePurchaseLine(ApplicationPresenter ap, BOServicePurchaseLine model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;
            mViewModel = new BOViewModel(mModel);

            BindViews();
            RegisterEventHandlers();
        }

        public BOServicePurchaseLine Model
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
                cboTax.SelectedIndex = -1;
                return;
            }
            cboTax.SelectedItem = _obj.TaxCode;
        }

        protected override void BindViews()
        {
            base.BindViews();

            cboAccount.DataSource = mApplicationController.FindAllAccounts();
            cboTax.DataSource = mApplicationController.FindAllTaxCodes();
            cboJob.DataSource = mApplicationController.FindAllJobs();

            mViewModel.BindView(BOServicePurchaseLine.ACCOUNT, lblAccount, cboAccount);
            mViewModel.BindView(BOServicePurchaseLine.TAXCODE, lblTax, cboTax);
            mViewModel.BindView(BOServicePurchaseLine.JOB, lblJob, cboJob);
            mViewModel.BindView(BOServicePurchaseLine.AMOUNT, lblAmount, txtAmount);
            mViewModel.BindView(BOServicePurchaseLine.DESCRIPTION, lblDescription, txtDescription);
            mViewModel.BindView(BOServicePurchaseLine.PERSIST_OBJECT, btnOK);
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
