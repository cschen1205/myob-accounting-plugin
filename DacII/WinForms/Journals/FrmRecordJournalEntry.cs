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
    using Accounting.Core.Currencies;

    public partial class FrmRecordJournalEntry : BaseView
    {
        private BORecordJournalEntry mModel = null;
        public FrmRecordJournalEntry(ApplicationPresenter ap, BORecordJournalEntry model)
            : base(ap)
        {
            InitializeComponent();
            mModel = model;
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRecordJournalEntry_Load(object sender, EventArgs e)
        {
            IList<Currency> currency_group = mApplicationController.FindAllCurrencies();
            cboCurrency.DataSource = currency_group;
            Currency _currency=currency_group[0];
            txtOutOfBalance.Text = _currency.Format(0);
            txtTax.Text = _currency.Format(0);
            txtTotalCredit.Text = _currency.Format(0);
            txtTotalDebit.Text = _currency.Format(0);
        }

        private void cboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            Currency _currency = (Currency)cboCurrency.SelectedItem;
            if (_currency != null)
            {
                txtOutOfBalance.Text = _currency.Format(0);
                txtTax.Text = _currency.Format(0);
                txtTotalCredit.Text = _currency.Format(0);
                txtTotalDebit.Text = _currency.Format(0);
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {

        }
    }
}