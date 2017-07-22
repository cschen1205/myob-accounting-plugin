using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace DacII.WinForms.Sales.SaleLines
{
    using DacII.Presenters;
    using DacII.ViewModels;

    using Accounting.Bll.Sales.SaleLines;
    using Accounting.Core.Accounts;
    using Accounting.Core.TaxCodes;
    using Accounting.Core.Jobs;

    public partial class FrmServiceSaleLine : BaseView
    {
        private BOServiceSaleLine mModel = null;
        private BOViewModel mViewModel;

        public FrmServiceSaleLine(ApplicationPresenter ap, BOServiceSaleLine model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;
            mViewModel = new BOViewModel(mModel);
            mViewModel.ErrorProvider = errorProvider;

            BindViews();
            RegisterEventHandlers();
        }

        public BOServiceSaleLine Model
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

            mViewModel.BindView(BOServiceSaleLine.ACCOUNT, lblAccount, cboAccount);
            mViewModel.BindView(BOServiceSaleLine.TAXCODE, lblTax, cboTax);
            mViewModel.BindView(BOServiceSaleLine.JOB, lblJob, cboJob);
            mViewModel.BindView(BOServiceSaleLine.AMOUNT, lblAmount, txtAmount);
            mViewModel.BindView(BOServiceSaleLine.DESCRIPTION, lblDescription, txtDescription);
            mViewModel.BindView(BOServiceSaleLine.PERSIST_OBJECT, btnOK);
        }

        protected override void LoadView()
        {
            base.LoadView();
            mViewModel.UpdateView();
        }
    }
}
