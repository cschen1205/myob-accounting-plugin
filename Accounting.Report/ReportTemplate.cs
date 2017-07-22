using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Report
{
    using Accounting.Core.Misc;
    using Accounting.Core.Inventory;
    using System.Data;
    using System.IO;

    using Accounting.Bll;
    public abstract class ReportTemplate
    {
        protected Accountant mAccountant;

        public ReportTemplate(Accountant acc)
        {
            mAccountant = acc;
            IncludeCompanyName = true;
            IncludeReportDateAndTime = true;
            IncludeCompanyAddress = true;
        }

        public bool IncludeCompanyName { get; set; }
        public bool IncludeCompanyAddress { get; set; }
        public bool IncludeReportDateAndTime { get; set; }

        protected Doddle.Reporting.Report CreateReport(string report_title)
        {
            Doddle.Reporting.Report report = new Doddle.Reporting.Report();

            DataFileInformation company = mAccountant.DataFileInformationMgr.Company;

            string title = report_title;
            string subtitle = "";
            if (IncludeCompanyAddress)
            {
                title = string.Format("{0}\r\n{1}", company.CompanyName, company.Address);
                subtitle = report_title;
            }

            string footer = string.Format("Copyright {0}", DateTime.Now.Year);
            if (IncludeCompanyName)
            {
                footer = string.Format("Copyright {0}; The {1}", DateTime.Now.Year, company.CompanyName);
            }

            string header = " ";

            if (IncludeReportDateAndTime)
            {
                StringBuilder header_sb = new StringBuilder();
                header_sb.Append(DateTime.Now.ToString("yyyy-MMM-dd"));
                header_sb.Append("\r\n");
                header_sb.Append(DateTime.Now.ToString("HH:mm:ss"));
                header = header_sb.ToString();
            }

            report.TextFields.Title = title;
            report.TextFields.SubTitle = subtitle;
            report.TextFields.Footer = footer;
            report.TextFields.Header = header;

            // Render hints allow you to pass additional hints to the reports as they are being rendered
            report.RenderHints.BooleanCheckboxes = true;

            return report;
        }


        protected abstract Doddle.Reporting.Report BuildReport();

        public void WriteHtmlReport(string filename)
        {
            Doddle.Reporting.Report report = BuildReport();
            var writer = new Doddle.Reporting.Writers.HtmlReportWriter();

            FileStream fs = File.Create(filename);
            writer.WriteReport(report, fs);
        }

        public void WriteDelimitedTextReport(string filename)
        {
            Doddle.Reporting.Report report = BuildReport();
            var writer = new Doddle.Reporting.Writers.DelimitedTextReportWriter();

            FileStream fs = File.Create(filename);
            writer.WriteReport(report, fs);
        }

        public void WritePdfReport(string filename, bool landscape)
        {
            Doddle.Reporting.Report report = BuildReport();
            var writer = new Doddle.Reporting.Writers.PdfReportWriter();
            writer.Landscape = landscape;
            writer.WriteReport(report, filename);
        }

        public void WriteRtfReport(string filename)
        {
            Doddle.Reporting.Report report = BuildReport();
            var writer = new Doddle.Reporting.Writers.RtfReportWriter();
            writer.WriteReport(report, filename);
        }

        public void WriteExcelReport(string filename)
        {
            Doddle.Reporting.Report report = BuildReport();
            var writer = new Doddle.Reporting.Writers.ExcelReportWriter();

            FileStream fs = File.Create(filename);
            writer.WriteReport(report, fs);
        }
    }
}
