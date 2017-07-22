using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Accounting.Bll;

namespace DacII.WinForms.Setup.Reports
{
    using DacII.Presenters;
    using Accounting.Bll.Company;

    public partial class FrmCompany : BaseView
    {
        BOCompany mModel;
        public FrmCompany(ApplicationPresenter ap, BOCompany model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;

            LoadReport("DacII.Reports.DataFileInformation.RptCompany.rdlc");

            BindViews();
            RegisterEventHandlers();
        }

        public void LoadReport(string filename)
        {
            this.rpv.LocalReport.ReportEmbeddedResource = filename;
        }

        protected override void LoadView()
        {
            base.LoadView();

            this.CompanyInfoBindingSource.DataSource = mModel.DataSource; //mApplicationController.CurrentAccountant.DataFileInformationMgr.Company;
            this.rpv.RefreshReport();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }
    }
}