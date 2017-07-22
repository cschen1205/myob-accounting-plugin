using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Accounting.Core;
using Accounting.Bll;
using Accounting.Core.Cards;
using Accounting.Bll.Sales;
using Accounting.Core.Definitions;
using Accounting.Core.Sales;

namespace Was.Web
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Accountant acc = AccLoader.Instance.Pool.CurrentAccountant;
            //BOListSale model = new BOListSale(acc);
            //Customer customer = acc.CustomerMgr.FindById(CustomerID);
            //Status invoiceStatus = acc.StatusMgr.FindById(InvoiceStatusID);
            //List<SaleRow> rows=model.ListLight(start, end, customer, invoiceStatus);

            int? CustomerID = 6;
            BOListSale model = new BOListSale(acc);
            Customer customer = acc.CustomerMgr.FindById(CustomerID);
            Status invoiceStatus = acc.StatusMgr.FindByStatusType(Status.StatusType.Open);
            DateTime start = DateTime.Now.AddYears(-3);
            DateTime end = DateTime.Now;
            List<SaleRow> rows = model.ListLight(start, end, customer, invoiceStatus, 0, 10);
            int sale_count=model.GetSaleCount(start, end, customer, invoiceStatus);
            List<LightSale> _grp = new List<LightSale>();
            foreach (SaleRow _row in rows)
            {
                _grp.Add(new LightSale
                {
                    SaleID = _row.SaleID.ToString(),
                    Amount = _row.AmountDesc,
                    AmountDue = _row.AmountDueDesc
                });
            }

            

            acc.Release();

            ListInvoiceTypes();
            LightSale2 _sale2=RetrieveSale(2);

            lblInfo.Text = _sale2.InvoiceNumber;
        }

        public LightSale2 RetrieveSale(int? SaleID)
        {
            Accountant acc = AccLoader.Instance.Pool.CurrentAccountant;
            BOListSale model = new BOListSale(acc);
            Sale _sale = acc.SaleMgr.FindById(SaleID);

            acc.Release();

            if (_sale == null) return null;

            LightSale2 _sale2 = new LightSale2();
            _sale2.BackorderSaleID = _sale.BackorderSaleID == null ? "" : _sale.BackorderSaleID.ToString();
            _sale2.Comment = _sale.Comment;
            _sale2.CostCentreID = _sale.CostCentreID == null ? "" : _sale.CostCentreID.ToString();
            _sale2.CurrencyID = _sale.CurrencyID == null ? "" : _sale.CurrencyID.ToString();
            _sale2.CustomerID = _sale.CardRecordID == null ? "" : _sale.CardRecordID.ToString();
            _sale2.CustomerPONumber = _sale.CustomerPONumber;
            _sale2.Date = _sale.Date == null ? "" : _sale.Date.Value.ToString("dd/MM/yyyy");
            _sale2.DaysTillPaid = _sale.DaysTillPaid == null ? "" : _sale.DaysTillPaid.ToString();
            _sale2.DestinationCountry = _sale.DestinationCountry;
            _sale2.FreightTaxCodeID = _sale.FreightTaxCodeID == null ? "" : _sale.FreightTaxCodeID.ToString();
            _sale2.InvoiceDate = _sale.InvoiceDate == null ? "" : _sale.InvoiceDate.Value.ToString("dd/MM/yyyy");
            _sale2.InvoiceDeliveryID = _sale.InvoiceDeliveryID;
            _sale2.InvoiceNumber = _sale.InvoiceNumber;
            _sale2.InvoiceStatusID = _sale.InvoiceStatusID;
            _sale2.InvoiceTypeID = _sale.InvoiceTypeID;
            _sale2.IsAutoRecorded = _sale.IsAutoRecorded;
            _sale2.IsHistorical = _sale.IsHistorical;
            _sale2.IsPrinted = _sale.IsPrinted;
            _sale2.IsTaxInclusive = _sale.IsTaxInclusive;
            _sale2.IsThirteenthPeriod = _sale.IsThirteenthPeriod;
            _sale2.LinesPurged = _sale.LinesPurged;
            _sale2.Memo = _sale.Memo;
            _sale2.OutstandingBalance = _sale.OutstandingBalance;
            _sale2.PreAuditTrail = _sale.PreAuditTrail;
            _sale2.PromisedDate = _sale.PromisedDate == null ? "" : _sale.PromisedDate.Value.ToString("dd/MM/yyyy");
            _sale2.ReferralSourceID = _sale.ReferralSourceID == null ? "" : _sale.ReferralSourceID.ToString();
            _sale2.SaleID = _sale.SaleID == null ? "" : _sale.SaleID.ToString();
            _sale2.SalesPersonID = _sale.SalesPersonID == null ? "" : _sale.SalesPersonID.ToString();
            _sale2.ShippingMethodID = _sale.ShippingMethodID == null ? "" : _sale.ShippingMethodID.ToString();
            _sale2.ShipToAddress = _sale.ShipToAddress;
            _sale2.ShipToAddressLine1 = _sale.ShipToAddressLine1;
            _sale2.ShipToAddressLine2 = _sale.ShipToAddressLine2;
            _sale2.ShipToAddressLine3 = _sale.ShipToAddressLine3;
            _sale2.ShipToAddressLine4 = _sale.ShipToAddressLine4;
            _sale2.TaxExclusiveFreight = _sale.TaxExclusiveFreight;
            _sale2.TaxInclusiveFreight = _sale.TaxInclusiveFreight;
            _sale2.TermsID = _sale.TermsID == null ? "" : _sale.TermsID.ToString();
            _sale2.TotalCredits = _sale.TotalCredits;
            _sale2.TotalDeposits = _sale.TotalDeposits;
            _sale2.TotalDiscounts = _sale.TotalDiscounts;
            _sale2.TotalLines = _sale.TotalLines;
            _sale2.TotalPaid = _sale.TotalPaid;
            _sale2.TotalTax = _sale.TotalTax;
            _sale2.TransactionExchangeRate = _sale.TransactionExchangeRate;



            return _sale2;
        }


        public List<LightInvoiceType> ListInvoiceTypes()
        {

            Accountant acc = AccLoader.Instance.Pool.CurrentAccountant;
            IList<InvoiceType> rows = acc.InvoiceTypeMgr.FindAllCollection();


            List<LightInvoiceType> _grp = new List<LightInvoiceType>();
            foreach (InvoiceType _row in rows)
            {
                _grp.Add(new LightInvoiceType
                {
                    InvoiceTypeID = _row.InvoiceTypeID.ToString(),
                    Description = _row.ToString()
                });
            }

            //_grp.Add(new Was.Web.LightCustomer { CustomerID = "1", AmountDue = "20", Amount = "20" });
            //_grp.Add(new Was.Web.LightCustomer { CustomerID = "2", AmountDue = "20", Amount = "20" });



            return _grp;
        }
    }
}
