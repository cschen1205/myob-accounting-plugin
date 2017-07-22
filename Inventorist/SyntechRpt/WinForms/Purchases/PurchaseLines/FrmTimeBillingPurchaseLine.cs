using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.Core.Accounts;
using Accounting.Core.TaxCodes;
using Accounting.Core.Jobs;
using Accounting.Core.Activities;
using Accounting.Core.Inventory;
using Accounting.Bll;
using Accounting.Bll.Purchases.PurchaseLines;

namespace SyntechRpt.WinForms.Purchases.PurchaseLines
{
    public partial class FrmTimeBillingPurchaseLine : Form
    {
        private BOTimeBillingPurchaseLine mModel = null;

        public BOTimeBillingPurchaseLine Model
        {
            set
            {
                mModel = value;
            }
            get
            {
                return mModel;
            }
        }

        public FrmTimeBillingPurchaseLine()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            mModel.Activity = (Activity)cboActivity.SelectedItem;
            mModel.Notes = txtNotes.Text;
            mModel.TaxCode = (TaxCode)cboTax.SelectedItem;
            mModel.Job = (Job)cboJob.SelectedItem;
            mModel.LineDate = dtpLineDate.Value;
            mModel.HoursUnits = double.Parse(txtHoursUnits.Text);
            mModel.Rate = double.Parse(txtRate.Text);
            mModel.Location = (Location)cboLocation.SelectedItem;
            mModel.EstimatedCost = double.Parse(txtEstimatedCost.Text);

            OpResult result = mModel.Revise();
            if (!result.IsValid)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(result.Error);
            }
        }

        private void FrmTimeBillingPurchaseLine_Load(object sender, EventArgs e)
        {
            cboActivity.DataSource = mModel.List("Activity");
            cboTax.DataSource = mModel.List("TaxCode");
            cboJob.DataSource = mModel.List("Job");
            cboLocation.DataSource = mModel.List("Location");

            cboActivity.SelectedItem = mModel.Activity;
            cboTax.SelectedItem = mModel.TaxCode;
            if (mModel.LineDate != null)
            {
                mModel.LineDate = dtpLineDate.Value;
            }
            cboJob.SelectedItem = mModel.Job;
            cboLocation.SelectedItem = mModel.Location;
            txtNotes.Text = mModel.Notes;
            txtRate.Text = string.Format("{0}", mModel.Rate);
            txtHoursUnits.Text = string.Format("{0}", mModel.HoursUnits);
            txtEstimatedCost.Text = string.Format("{0}", mModel.EstimatedCost);
        }

        private void cboActivity_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}
