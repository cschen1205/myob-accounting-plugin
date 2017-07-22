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
using Accounting.Bll;
using Accounting.Bll.Purchases.PurchaseLines;

namespace SyntechRpt.WinForms.Purchases.PurchaseLines
{
    public partial class FrmServicePurchaseLine : Form
    {
        private BOServicePurchaseLine mModel = null;

        public BOServicePurchaseLine Model
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

        public FrmServicePurchaseLine()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            mModel.Account = (Account)cboAccount.SelectedItem;
            mModel.Description = txtDescription.Text;
            mModel.Amount = double.Parse(txtAmount.Text);
            mModel.TaxCode = (TaxCode)cboTax.SelectedItem;
            mModel.Job = (Job)cboJob.SelectedItem;

            OpResult result = mModel.Revise();
            if (!result.IsValid)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(result.Error);
            }
        }

        private void FrmServicePurchaseLine_Load(object sender, EventArgs e)
        {
            cboAccount.DataSource = mModel.List("Account");
            cboTax.DataSource = mModel.List("TaxCode");
            cboJob.DataSource = mModel.List("Job");

            cboAccount.SelectedItem = mModel.Account;
            cboTax.SelectedItem = mModel.TaxCode;
            cboJob.SelectedItem = mModel.Job;
            txtAmount.Text = string.Format("{0}", mModel.Amount);
            txtDescription.Text = mModel.Description;
        }

        private void cboAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            Account _obj=(Account)cboAccount.SelectedItem;
            if (_obj == null)
            {
                txtAmount.Text = string.Format("{0}", 0);
                cboTax.SelectedIndex = -1;
                return;
            }
            cboTax.SelectedItem = _obj.TaxCode;
            txtAmount.Text = string.Format("{0}", 0);
        }
    }
}
