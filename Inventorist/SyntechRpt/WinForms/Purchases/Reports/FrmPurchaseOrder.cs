using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Accounting;
using Accounting.Report.Purchases;
using Accounting.Core.Purchases;
using Microsoft.Reporting.WinForms;

namespace SyntechRpt.WinForms.Purchases.Reports
{
    public partial class FrmPurchaseOrder : Form
    {
        PurchaseOrder mModel;
        public FrmPurchaseOrder(PurchaseOrder _obj)
        {
            mModel = _obj;
            InitializeComponent();
            rpv.LocalReport.EnableExternalImages = true;
            rpv.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
        }

        private void FrmPurchaseOrder_Load(object sender, EventArgs e)
        {
            this.BindingSource.DataSource = mModel;
            this.rpv.RefreshReport();
        }

        public void LoadReport(string reportfile)
        {
            this.rpv.LocalReport.ReportEmbeddedResource = reportfile;
        }

        void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            // Author id is passed to the subreport as a parameter.
            //int authorId = int.Parse(e.Parameters[0].Values[0]);

            // Supply data for the subreport.
            e.DataSources.Add(new ReportDataSource("Accounting_Core_Purchase_ItemPurchaseLine", mModel.ItemPurchaseLines));
            e.DataSources.Add(new ReportDataSource("Accounting_Core_Purchase_ServicePurchaseLine", mModel.ServicePurchaseLines));
            e.DataSources.Add(new ReportDataSource("Accounting_Core_Purchase_ProfessionalPurchaseLine", mModel.ProfessionalPurchaseLines));
            e.DataSources.Add(new ReportDataSource("Accounting_Core_Purchase_MiscPurchaseLine", mModel.MiscPurchaseLines));

        }
    }
}