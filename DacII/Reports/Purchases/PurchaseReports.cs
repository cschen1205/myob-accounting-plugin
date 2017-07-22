using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacII.Reports.Purchases
{
    public class PurchaseReports
    {
          public enum ReportType
        {
            PurchaseQuote,
            PurchaseOrder,
            PurchaseOpenBill,
            PurchaseClosedBill,
            PurchaseDebitReturn
        }

        public static string GetReportTemplate(ReportType type)
        {
            string template_name = GetReportTemplateName(type);
            if (string.IsNullOrEmpty(template_name)) return string.Empty;
            return string.Format("DacII.Reports.Purchases.{0}.rdlc", template_name);
        }

        public static string GetReportTemplateName(ReportType type)
        {
            switch (type)
            {
                case ReportType.PurchaseQuote:
                    return "RptPurchaseOrder";
                case ReportType.PurchaseOrder:
                    return "RptPurchaseOrder";
                case ReportType.PurchaseOpenBill:
                    return "RptPurchaseOrder";
                case ReportType.PurchaseDebitReturn:
                    return "RptPurchaseOrder";
                case ReportType.PurchaseClosedBill:
                    return "RptPurchaseOrder";
            }
            return string.Empty;
        }

        
    }
}
