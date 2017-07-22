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
    using Accounting.Core.Activities;
    using Accounting.Core.Inventory;

    public partial class FrmTimeBillingSaleLine : BaseView
    {
        private BOTimeBillingSaleLine mModel = null;
        private BOViewModel mViewModel;

        public FrmTimeBillingSaleLine(ApplicationPresenter ap, BOTimeBillingSaleLine model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;
            mViewModel = new BOViewModel(mModel);
            mViewModel.ErrorProvider = errorProvider;

            BindViews();
            RegisterEventHandlers();
        }

        public BOTimeBillingSaleLine Model
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

            mViewModel.BindView(BOTimeBillingSaleLine.TAXCODE, lblTax, cboTax);
            mViewModel.BindView(BOTimeBillingSaleLine.ACTIVITY, lblActivity, cboActivity);
            mViewModel.BindView(BOTimeBillingSaleLine.LINE_DATE, lblLineDate, dtpLineDate);
            mViewModel.BindView(BOTimeBillingSaleLine.JOB, lblJob, cboJob);
            mViewModel.BindView(BOTimeBillingSaleLine.LOCATION, lblLocation, cboLocation);
            mViewModel.BindView(BOTimeBillingSaleLine.NOTES, lblNotes, txtNotes);
            mViewModel.BindView(BOTimeBillingSaleLine.RATE, lblRate, txtRate);
            mViewModel.BindView(BOTimeBillingSaleLine.HOURS_UNITS, lblHoursUnits, txtHoursUnits);
            mViewModel.BindView(BOTimeBillingSaleLine.ESTIMATED_COST, lblEstimatedCost, txtEstimatedCost);
            mViewModel.BindView(BOTimeBillingSaleLine.PERSIST_OBJECT, btnOK);
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
