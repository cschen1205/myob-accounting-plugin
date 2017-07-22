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
    public partial class FrmTermsRegister : BaseView
    {
        public FrmTermsRegister(ApplicationPresenter ap)
            : base(ap)
        {
            InitializeComponent();

            BindViews();
            RegisterEventHandlers();

            ConfigureDataGridView(dgvTerms);
        }

        protected override void BindViews()
        {
            base.BindViews();
            dgvTerms.DataSource = mApplicationController.FindAllTerms();
        }

        private void ConfigureDataGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            DataGridViewColumn c = null;

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "TermsOfPaymentID";
            c.HeaderText = "Terms Of Payment #";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "TermsOfPayment";
            c.HeaderText = "Terms Of Payment";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "PaymentDescription";
            c.HeaderText = "Payment Description";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "EarlyPaymentDiscountPercent";
            c.HeaderText = "Early Payment Discount %";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "LatePaymentChargePercent";
            c.HeaderText = "Late Payment Charge %";
            dgv.Columns.Add(c);

          
            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "BalanceDueDate";
            c.HeaderText = "Balance Due Date";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "BalanceDueDays";
            c.HeaderText = "Balance Due Days";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "DiscountDate";
            c.HeaderText = "Discount Date";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "DiscountDays";
            c.HeaderText = "Discount Days";
            dgv.Columns.Add(c);

            DacII.Util.DataGridViewHelper.UpdateColumnHeaderStyles(dgv);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }
    }
}
