using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace DacII.WinForms.Sales.Reports
{
    using DacII.Presenters;
    using Accounting.Report.Sales;
    using Accounting.Core.Sales;
    using Accounting.Core.Definitions;
    using Microsoft.Reporting.WinForms;

    public partial class FrmSale : BaseView
    {
        Accounting.Report.Sales.SalePrintPresenter mModel;
        public FrmSale(ApplicationPresenter ap, SalePrintPresenter _obj)
            : base(ap)
        {
            mModel = _obj;
            InitializeComponent();
            rpv.LocalReport.EnableExternalImages = true;
            rpv.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);

            Status sale_status = mModel.SaleStatus;
            if (sale_status != null)
            {
                Status.StatusType sale_status_type = sale_status.Type;
                switch (sale_status_type)
                {
                    case Status.StatusType.Quote:
                        LoadReport(DacII.Reports.Sales.SaleReports.GetReportTemplate(DacII.Reports.Sales.SaleReports.ReportType.SaleQuote));
                        break;
                    case Status.StatusType.Order:
                        LoadReport(DacII.Reports.Sales.SaleReports.GetReportTemplate(DacII.Reports.Sales.SaleReports.ReportType.SaleOrder));
                        break;
                    case Status.StatusType.Open:
                        LoadReport(DacII.Reports.Sales.SaleReports.GetReportTemplate(DacII.Reports.Sales.SaleReports.ReportType.SaleOpenInvoice));
                        break;
                    case Status.StatusType.Credit:
                        LoadReport(DacII.Reports.Sales.SaleReports.GetReportTemplate(DacII.Reports.Sales.SaleReports.ReportType.SaleCreditReturn));
                        break;
                    case Status.StatusType.Closed:
                        LoadReport(DacII.Reports.Sales.SaleReports.GetReportTemplate(DacII.Reports.Sales.SaleReports.ReportType.SaleClosedInvoice));
                        break;
                }
                
            }
        }

        private void FrmSale_Load(object sender, EventArgs e)
        {
            gbFilter.Caption = string.Format("Sale Print Form: {0}", mModel.InvoiceNumber);
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

            IList<SaleLine> lines = mModel.SaleLines;

            IList<ItemSaleLine> item_lines = new List<ItemSaleLine>();
            IList<ServiceSaleLine> service_lines = new List<ServiceSaleLine>();
            IList<MiscSaleLine> misc_lines = new List<MiscSaleLine>();
            IList<ProfessionalSaleLine> professional_lines = new List<ProfessionalSaleLine>();
            IList<TimeBillingSaleLine> time_billing_lines = new List<TimeBillingSaleLine>();

            foreach (SaleLine line in lines)
            {
                if (line is ItemSaleLine)
                {
                    item_lines.Add(line as ItemSaleLine);
                }
                else if (line is MiscSaleLine)
                {
                    misc_lines.Add(line as MiscSaleLine);
                }
                else if (line is ProfessionalSaleLine)
                {
                    professional_lines.Add(line as ProfessionalSaleLine);
                }
                else if (line is TimeBillingSaleLine)
                {
                    time_billing_lines.Add(line as TimeBillingSaleLine);
                }
                else if (line is ServiceSaleLine)
                {
                    service_lines.Add(line as ServiceSaleLine);
                }
            }

            e.DataSources.Add(new ReportDataSource("Accounting_Core_Sale_ItemSaleLine", item_lines));
            e.DataSources.Add(new ReportDataSource("Accounting_Core_Sale_ServiceSaleLine", service_lines));
            e.DataSources.Add(new ReportDataSource("Accounting_Core_Sale_ProfessionalSaleLine", professional_lines));
            e.DataSources.Add(new ReportDataSource("Accounting_Core_Sale_MiscSaleLine", misc_lines));

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }
    }
}