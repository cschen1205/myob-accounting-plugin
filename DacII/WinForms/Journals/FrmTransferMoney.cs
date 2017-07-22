using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace DacII.WinForms.Journals
{
    using DacII.Presenters;
    using Accounting.Bll;
    using Accounting.Bll.Journals;
    using Accounting.Core.Accounts;

    public partial class FrmTransferMoney : BaseView
    {
        private BOTransferMoney mModel;

        public FrmTransferMoney(ApplicationPresenter ap, BOTransferMoney model)
            : base(ap)
        {
            InitializeComponent();
            mModel = model;
        }

        private void frmTransferMoney_Load(object sender, EventArgs e)
        {
            IList<Account> account_group = mApplicationController.FindAllFromAccounts();
            IList<Account> account_group2 = mApplicationController.FindAllToAccounts();
            Account selected_account=account_group[0];
            cboFromAccount.DataSource = account_group;
            cboToAccount.DataSource = account_group2;

            string balance=selected_account.CurrentAccountBalanceDescription;
            lblFromAccountCurrentBalance.Text = balance;
            lblToAccountCurrentBalance.Text = balance;
            lblFromAccountBalanceAfterTransfer.Text = balance;
            lblToAccountBalanceAfterTransfer.Text = balance;
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboFromAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            Account from_account = (Account)cboFromAccount.SelectedItem;
            if (from_account != null)
            {
                double balance = from_account.CurrentAccountBalance;
                lblFromAccountCurrentBalance.Text = from_account.Currency.Format(balance);
                double amount_transferred = double.Parse(txtAmount.Text);

                balance = balance - amount_transferred;

                lblFromAccountBalanceAfterTransfer.Text = from_account.Currency.Format(balance);
            }
        }

        private void cboToAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            Account to_account = (Account)cboToAccount.SelectedItem;
            Account from_account = (Account)cboFromAccount.SelectedItem;
            if (to_account != null && from_account!= null)
            {
                double balance = to_account.CurrentAccountBalance;
                lblToAccountCurrentBalance.Text = to_account.Currency.Format(balance);
                double amount_transferred = double.Parse(txtAmount.Text);

                amount_transferred=to_account.Currency.ConvertFromCurrency(from_account.Currency, amount_transferred);
                
                balance = balance - amount_transferred;

                lblToAccountBalanceAfterTransfer.Text = to_account.Currency.Format(balance);
            }
        }
    }
}