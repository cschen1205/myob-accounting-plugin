using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Was.Web
{
    [DataContract()]
    public class LightSale
    {
        [DataMember()]
        public string SaleID { get; set; }

        [DataMember()]
        public string Amount { get; set; }

        [DataMember()]
        public string AmountDue { get; set; }

        [DataMember()]
        public string Customer { get; set; }

        [DataMember()]
        public string InvoiceDate { get; set; }

        [DataMember()]
        public string InvoiceStatus { get; set; }

        [DataMember()]
        public string InvoiceNumber { get; set; }
    }
}
