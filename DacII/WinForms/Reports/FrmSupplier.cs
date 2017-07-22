using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Accounting.Core.Cards;

namespace DacII.WinForms.Report
{
    public partial class FrmSupplier : Form
    {
        Supplier mSupplier;
        public FrmSupplier(Supplier _obj)
        {
            mSupplier = _obj;
            InitializeComponent();
        }

        private void FrmPrintSuppliers_Load(object sender, EventArgs e)
        {
            this.SupplierBindingSource.DataSource = mSupplier;
            this.rptSuppliers.RefreshReport();
        }
    }
}