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
    public partial class FrmTaxCodesRegister : BaseView
    {
        public FrmTaxCodesRegister(ApplicationPresenter ap)
            :base(ap)
        {
            InitializeComponent();

            BindViews();
            RegisterEventHandlers();

            ConfigureDataGridView(dgvTaxCode);
        }

        private void ConfigureDataGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            DataGridViewColumn c = null;

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "Code";
            c.HeaderText = "Code";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "TaxPercentageRate";
            c.HeaderText = "Percentage Rate";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "TaxCodeTypeID";
            c.HeaderText = "Type";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "SubTaxCode";
            c.HeaderText = "Sub Tax Code";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "TaxCodeDescription";
            c.HeaderText = "Description";
            dgv.Columns.Add(c);

            DacII.Util.DataGridViewHelper.UpdateColumnHeaderStyles(dgv);
        }

        protected override void BindViews()
        {
            base.BindViews();
            dgvTaxCode.DataSource = mApplicationController.FindAllTaxCodes();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }
    }
}
