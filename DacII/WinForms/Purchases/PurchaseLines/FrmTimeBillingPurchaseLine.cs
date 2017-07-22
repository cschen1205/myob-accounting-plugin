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
    using Accounting.Core.Activities;
    using Accounting.Core.Inventory;
    using Accounting.Bll;
    using Accounting.Bll.Purchases.PurchaseLines;

    public partial class FrmTimeBillingPurchaseLine : BaseView
    {
        private BOTimeBillingPurchaseLine mModel = null;
        private BOViewModel mViewModel;

        public FrmTimeBillingPurchaseLine(ApplicationPresenter ap, BOTimeBillingPurchaseLine model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;
            mViewModel = new BOViewModel(mModel);

            BindViews();
            RegisterEventHandlers();
        }

        public BOTimeBillingPurchaseLine Model
        {
            set
            {
                mModel = value;
                mViewModel.Model = value;
            }
        }

        private void OnActivityChanged(object sender, EventArgs args)
        {
            Activity _obj = (Activity)cboActivity.SelectedItem;
            if (_obj == null)
            {
                txtRate.Text = string.Format("{0}", 0);
                cboTax.SelectedIndex = -1;
                return;
            }
            cboTax.SelectedItem = _obj.TaxCode;
            txtHoursUnits.Text = string.Format("{0}", 1);
            txtRate.Text = string.Format("{0}", _obj.ActivityRate);
            txtNotes.Text = _obj.ActivityDescription;
        }

        protected override void BindViews()
        {
            base.BindViews();

            cboActivity.DataSource = mApplicationController.FindAllActivities();
            cboTax.DataSource = mApplicationController.FindAllTaxCodes();
            cboJob.DataSource = mApplicationController.FindAllJobs();
            cboLocation.DataSource = mApplicationController.FindAllLocations();

            mViewModel.BindView(BOTimeBillingPurchaseLine.LINE_DATE, lblLineDate, dtpLineDate);
            mViewModel.BindView(BOTimeBillingPurchaseLine.ACTIVITY, lblActivity, cboActivity);
            mViewModel.BindView(BOTimeBillingPurchaseLine.TAXCODE, lblTax, cboTax);
            mViewModel.BindView(BOTimeBillingPurchaseLine.JOB, lblJob, cboJob);
            mViewModel.BindView(BOTimeBillingPurchaseLine.LOCATION, lblLocation, cboLocation);
            mViewModel.BindView(BOTimeBillingPurchaseLine.DESCRIPTION, lblNotes, txtNotes);
            mViewModel.BindView(BOTimeBillingPurchaseLine.RATE, lblRate, txtRate);
            mViewModel.BindView(BOTimeBillingPurchaseLine.HOURS_UNITS, lblHoursUnits, txtHoursUnits);
            mViewModel.BindView(BOTimeBillingPurchaseLine.ESTIMATED_COST, lblEstimatedCost, txtEstimatedCost);
            mViewModel.BindView(BOTimeBillingPurchaseLine.PERSIST_OBJECT, btnOK);
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
