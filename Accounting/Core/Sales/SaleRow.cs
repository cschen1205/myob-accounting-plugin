using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Sales
{
    public class SaleRow
    {
        public int? SaleID { get; set; }
        public string Customer { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string InvoiceNumber { get; set; }
        public double? Amount { set; get; }
        public double? AmountDue { set; get; }
        public int? CurrencyID { get; set; }
        public Currencies.Currency Currency { get; set; }

        public string InvoiceStatusID { get; set; }

        public Definitions.Status InvoiceStatus { get; set; }

        public string InvoiceDateDesc
        {
            get
            {
                if (InvoiceDate != null) return InvoiceDate.Value.ToString("yyyy-MM-dd");
                return "NA";
            }
        }

        public string AmountDesc
        {
            get
            {
                if (Currency == null) return string.Format("{0:C}", Amount);
                return Currency.Format(Amount.Value);
            }
        }

        public string AmountDueDesc
        {
            get
            {
                if (Currency == null) return string.Format("{0:C}", AmountDue);
                return Currency.Format(AmountDue.Value);
            }
        }
    }
}
