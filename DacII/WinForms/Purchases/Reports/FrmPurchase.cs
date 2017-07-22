using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Reflection;
using System.Windows.Forms;


namespace DacII.WinForms.Purchases.Reports
{
    using DacII.Presenters;
    using Accounting.Core.Definitions;
    using Accounting;
    using Accounting.Report.Purchases;
    using Accounting.Core.Purchases;
    using Microsoft.Reporting.WinForms;

    public partial class FrmPurchase : BaseView
    {
        PurchasePrintPresenter mModel;
        public FrmPurchase(ApplicationPresenter ap, PurchasePrintPresenter _obj)
            : base(ap)
        {
            mModel = _obj;
            InitializeComponent();
            rpv.LocalReport.EnableExternalImages = true;
            rpv.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);

            Status purchase_status = _obj.PurchaseStatus;
            if (purchase_status != null)
            {
                Status.StatusType purchase_status_type = purchase_status.Type;

                switch (purchase_status_type)
                {
                    case Status.StatusType.Quote:
                        LoadReport(DacII.Reports.Purchases.PurchaseReports.GetReportTemplate(DacII.Reports.Purchases.PurchaseReports.ReportType.PurchaseQuote));
                        break;
                    case Status.StatusType.Order:
                        LoadReport(DacII.Reports.Purchases.PurchaseReports.GetReportTemplate(DacII.Reports.Purchases.PurchaseReports.ReportType.PurchaseOrder));
                        break;
                    case Status.StatusType.Open:
                        LoadReport(DacII.Reports.Purchases.PurchaseReports.GetReportTemplate(DacII.Reports.Purchases.PurchaseReports.ReportType.PurchaseOpenBill));
                        break;
                    case Status.StatusType.Debit:
                        LoadReport(DacII.Reports.Purchases.PurchaseReports.GetReportTemplate(DacII.Reports.Purchases.PurchaseReports.ReportType.PurchaseDebitReturn));
                        break;
                    case Status.StatusType.Closed:
                        LoadReport(DacII.Reports.Purchases.PurchaseReports.GetReportTemplate(DacII.Reports.Purchases.PurchaseReports.ReportType.PurchaseClosedBill));
                        break;
                }
            }
            
        }

        private void FrmPurchaseOrder_Load(object sender, EventArgs e)
        {
            gbFilter.Caption = string.Format("Purchase Print Form: {0}", mModel.OrderNumber);
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

            IList<PurchaseLine> lines=mModel.PurchaseLines;

            IList<ItemPurchaseLine> item_lines = new List<ItemPurchaseLine>();
            IList<ServicePurchaseLine> service_lines = new List<ServicePurchaseLine>();
            IList<MiscPurchaseLine> misc_lines = new List<MiscPurchaseLine>();
            IList<ProfessionalPurchaseLine> professional_lines = new List<ProfessionalPurchaseLine>();
            IList<TimeBillingPurchaseLine> time_billing_lines = new List<TimeBillingPurchaseLine>();

            foreach(PurchaseLine line in lines)
            {
                if (line is ItemPurchaseLine)
                {
                    item_lines.Add(line as ItemPurchaseLine);
                }
                else if (line is MiscPurchaseLine)
                {
                    misc_lines.Add(line as MiscPurchaseLine);
                }
                else if (line is ProfessionalPurchaseLine)
                {
                    professional_lines.Add(line as ProfessionalPurchaseLine);
                }
                else if (line is TimeBillingPurchaseLine)
                {
                    time_billing_lines.Add(line as TimeBillingPurchaseLine);
                }
                else if (line is ServicePurchaseLine)
                {
                    service_lines.Add(line as ServicePurchaseLine);
                }
            }

            // Supply data for the subreport.
            e.DataSources.Add(new ReportDataSource("Accounting_Core_Purchase_ItemPurchaseLine", item_lines));
            e.DataSources.Add(new ReportDataSource("Accounting_Core_Purchase_ServicePurchaseLine", service_lines));
            e.DataSources.Add(new ReportDataSource("Accounting_Core_Purchase_ProfessionalPurchaseLine", professional_lines));
            e.DataSources.Add(new ReportDataSource("Accounting_Core_Purchase_MiscPurchaseLine", misc_lines));

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }
    }
}