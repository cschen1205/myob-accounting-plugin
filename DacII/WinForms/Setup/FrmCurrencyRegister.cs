using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DacII.WinForms.Setup
{
    using DacII.Presenters;
    public partial class FrmCurrencyRegister : BaseView
    {
        public FrmCurrencyRegister(ApplicationPresenter ap)
            : base(ap)
        {
            InitializeComponent();

            BindViews();
            RegisterEventHandlers();

            ConfigureDataGridView(dgvCurrency);
        }

        private void ConfigureDataGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            DataGridViewColumn c = null;

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "CurrencyCode";
            c.HeaderText = "Currency";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "CurrencyName";
            c.HeaderText = "Name";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "ExchangeRate";
            c.HeaderText = "Exchange Rate";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "CurrencySymbol";
            c.HeaderText = "Symbol";
            dgv.Columns.Add(c);

            DacII.Util.DataGridViewHelper.UpdateColumnHeaderStyles(dgv);
        }

        protected override void LoadView()
        {
            base.LoadView();

            if (mApplicationController.SupportMultiCurrency)
            {
                gbCurrency.Caption = "Currency Register (Multi-Currency Supported)";
            }
            else
            {
                gbCurrency.Caption = "Currency Register (Multi-Currency Not Supported)";
            }
        }

        protected override void BindViews()
        {
            base.BindViews();
            dgvCurrency.DataSource = mApplicationController.FindAllCurrencies();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }
    }
}
