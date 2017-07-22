using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Was.Web
{
    [DataContract()]
    public class LightSale2
    {
        [DataMember()]
        public string SaleID { get; set; }

        [DataMember()]
        public string CustomerID { get; set; }

        [DataMember()]
        public string InvoiceNumber { get; set; }

        [DataMember()]
        public string CustomerPONumber { get; set; }

        [DataMember()]
        public string IsHistorical { get; set; }


        [DataMember()]
        public string BackorderSaleID { get; set; }


        [DataMember()]
        public string Date { get; set; }

        [DataMember()]
        public string InvoiceDate { get; set; }

        [DataMember()]
        public string IsThirteenthPeriod { get; set; }

       
        [DataMember()]
        public string ShipToAddressLine1 { get; set; }
        [DataMember()]
        public string ShipToAddressLine2 { get; set; }
        [DataMember()]
        public string ShipToAddressLine3 { get; set; }
        [DataMember()]
        public string ShipToAddressLine4 { get; set; }
        [DataMember()]
        public string ShipToAddress { get; set; }

        [DataMember()]
        public string InvoiceTypeID { get; set; }

       
        [DataMember()]
        public string InvoiceStatusID { get; set; }


        [DataMember()]
        public string TermsID { get; set; }

        [DataMember()]
        public double TotalLines { get; set; }


        [DataMember()]
        public double TaxExclusiveFreight { get; set; }


        [DataMember()]
        public double TaxInclusiveFreight { get; set; }


        [DataMember()]
        public string FreightTaxCodeID { get; set; }


        [DataMember()]
        public double TotalTax { get; set; }


        [DataMember()]
        public double TotalPaid { get; set; }


        [DataMember()]
        public double TotalDeposits { get; set; }

        [DataMember()]
        public double TotalCredits { get; set; }
        
        [DataMember()]
        public double TotalDiscounts { get; set; }

        [DataMember()]
        public double OutstandingBalance { get; set; }

        [DataMember()]
        public string SalesPersonID { get; set; }

        [DataMember()]
        public string Memo { get; set; }


        [DataMember()]
        public string Comment { get; set; }

       
        [DataMember()]
        public string ShippingMethodID { get; set; }


        [DataMember()]
        public string PromisedDate { get; set; }
        [DataMember()]
        public string ReferralSourceID { get; set; }

        [DataMember()]
        public string IsTaxInclusive { get; set; }

       
        [DataMember()]
        public string IsAutoRecorded { get; set; }

        [DataMember()]
        public string IsPrinted { get; set; }

        [DataMember()]
        public string InvoiceDeliveryID { get; set; }

        [DataMember()]
        public string DaysTillPaid { get; set; }

        [DataMember()]
        public double TransactionExchangeRate { get; set; }

        
        [DataMember()]
        public string CostCentreID { get; set; }

        [DataMember()]
        public string LinesPurged { get; set; }

        [DataMember()]
        public string PreAuditTrail { get; set; }

        [DataMember()]
        public string CurrencyID { get; set; }

        [DataMember()]
        public string DestinationCountry
        {
            get;
            set;
        }

        [DataMember()]
        public LightCustomer Customer
        {
            get;
            set;
        }

        [DataMember()]
        public LightTerms Terms { get; set; }

        [DataMember()]
        public LightShippingMethod ShippingMethod { get; set; }

    }
}
