using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DacII.WinForms.Report
{
    using DacII.Presenters;
    using Accounting.Bll.Cards;

    public partial class FrmSuppliers : BaseView
    {
        BOListCard mModel;
        public FrmSuppliers(ApplicationPresenter ap, BOListCard model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;

            BindViews();
            RegisterEventHandlers();
        }

        protected override void LoadView()
        {
            base.LoadView();

            this.SupplierBindingSource.DataSource = mModel.Suppliers;
            this.rptSuppliers.RefreshReport();
        }

        private void frmPrintSuppliers_Load(object sender, EventArgs e)
        {
           
        }
    }
}