using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacII.Reports.Sales
{
    public class SaleReports
    {
        public enum ReportType
        {
            SaleQuote,
            SaleOrder,
            SaleOpenInvoice,
            SaleClosedInvoice,
            SaleCreditReturn
        }

        public static string GetReportTemplate(ReportType type)
        {
            string template_name = GetReportTemplateName(type);
            if (string.IsNullOrEmpty(template_name)) return string.Empty;
            return string.Format("DacII.Reports.Sales.{0}.rdlc", template_name);
        }

        public static string GetReportTemplateName(ReportType type)
        {
            switch (type)
            {
                case ReportType.SaleQuote:
                    return "rptInvoice";
                case ReportType.SaleOrder:
                    return "rptInvoice";
                case ReportType.SaleOpenInvoice:
                    return "rptInvoice";
                case ReportType.SaleCreditReturn:
                    return "rptInvoice";
                case ReportType.SaleClosedInvoice:
                    return "rptInvoice";
            }
            return string.Empty;
        }
    }
}
