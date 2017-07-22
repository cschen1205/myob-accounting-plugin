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

namespace SyntechRpt.WinForms.Sales.SaleLines
{
    public partial class FrmProfessionalSaleLine : Form
    {
        private BOProfessionalSaleLine mModel = null;

        public BOProfessionalSaleLine Model
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

        public FrmProfessionalSaleLine()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string errorText = "";
            if (cboAccount.SelectedIndex == -1)
            {
                errorText = "No account selected!";
                errorProvider.SetError(cboAccount, errorText);
                DialogResult = DialogResult.None;
                return;
            }

            mModel.Account = (Account)cboAccount.SelectedItem;
            mModel.Description = txtDescription.Text;
            mModel.Amount = double.Parse(txtAmount.Text);
            mModel.TaxCode = (TaxCode)cboTax.SelectedItem;
            mModel.Job = (Job)cboJob.SelectedItem;
            mModel.LineDate = dtpLineDate.Value;

            mModel.Revise();
        }

        private void FrmProfessionalSaleLine_Load(object sender, EventArgs e)
        {
            cboAccount.DataSource = mModel.List("Account");
            cboTax.DataSource = mModel.List("TaxCode");
            cboJob.DataSource = mModel.List("Job");

            cboAccount.SelectedItem = mModel.Account;
            cboTax.SelectedItem = mModel.TaxCode;
            cboJob.SelectedItem = mModel.Job;
            if (mModel.LineDate != null)
            {
                dtpLineDate.Value = mModel.LineDate.Value;
            }
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
