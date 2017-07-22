using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Collections.Generic;
using System.Text;
using Accounting.Bll;
using Accounting.Bll.Sales;
using Accounting.Core.Sales;
using Accounting.Core.Cards;
using Accounting.Core.Definitions;
using Accounting.Core.Misc;
using Accounting.Core.Terms;
using Accounting.Core.Currencies;
using Accounting.Core.ShippingMethods;
using Accounting.Core.TaxCodes;

namespace Was.Web
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class SaleService
    {
        //private static Dictionary<Guid, TokenData> Tokens = new Dictionary<Guid, TokenData>();

        //[OperationContract]
        //public string GetUsername(Guid tokenId)
        //{
        //    if (Tokens.ContainsKey(tokenId))
        //    {
        //        return Tokens[tokenId].Username;
        //    }
        //    return "";
        //}

        //[OperationContract]
        //public bool IsAdmin(Guid tokenId)
        //{
        //    if (IsLogined(tokenId))
        //    {
        //        string account_name = GetUsername(tokenId);
        //        if (account_name.ToLower().Equals("administrator"))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //[OperationContract]
        //public void Logoff(Guid token)
        //{
        //    Tokens.Remove(token);
        //}

        //[OperationContract]
        //public Guid Login(string account_name, string password)
        //{
        //    int count = 0;
        //    ViSmsManager mgr = ViSmsManager.Singleton;

        //    mgr.Connect();

        //    DbSelectStatement clause = mgr.CreateSelectClause();
        //    clause
        //        .SelectCount()
        //        .From(ViSmsManager.kViSmsAccounts)
        //        .Criteria
        //            .IsEqual(ViSmsManager.kViSmsAccounts, ViSmsManager.kViSmsAccountName, account_name)
        //            .IsEqual(ViSmsManager.kViSmsAccounts, ViSmsManager.kViSmsAccountPassword, password);

        //    count = mgr.ExecuteScalarInt(clause);

        //    mgr.Disconnect();

        //    bool login = (count != 0);

        //    if (login)
        //    {
        //        TokenData token = new TokenData();
        //        token.Username = account_name;
        //        Guid token_id = Guid.NewGuid();
        //        Tokens.Add(token_id, token);
        //        return token_id;
        //    }
        //    else
        //    {
        //        HttpContext.Current.Session.Abandon();
        //        return Guid.Empty;
        //    }
        //}

        //[OperationContract]
        //public bool IsLogined(Guid token_id)
        //{
        //    if (Tokens.ContainsKey(token_id))
        //    {
        //        TokenData token = Tokens[token_id];
        //        if (token.IsExpired)
        //        {
        //            return false;
        //        }

        //        token.UpdateExpiration();
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        [OperationContract]
        public List<LightStatus> ListInvoiceStatus()
        {
            Accountant acc = AccLoader.Instance.Pool.CurrentAccountant;
            List<Status> rows = acc.SaleMgr.RetrieveInvoiceStatuses();

            acc.Release();

            List<LightStatus> _grp = new List<LightStatus>();
            foreach (Status _row in rows)
            {
                _grp.Add(new LightStatus
                {
                    StatusID = _row.StatusID,
                    Description=_row.Description
                });
            }

            return _grp;
        }

        // Add more operations here and mark them with [OperationContract]
        [OperationContract]
        public List<LightReferralSource> ListReferralSources()
        {

            Accountant acc = AccLoader.Instance.Pool.CurrentAccountant;
            IList<ReferralSource> rows = acc.ReferralSourceMgr.FindAllCollection();

            acc.Release();

            List<LightReferralSource> _grp = new List<LightReferralSource>();
            foreach (ReferralSource _row in rows)
            {
                _grp.Add(new LightReferralSource
                {
                    ReferralSourceID = _row.ReferralSourceID.ToString(),
                    Description = _row.ToString()
                });
            }

            return _grp;
        }


        // Add more operations here and mark them with [OperationContract]
        ///*
        [OperationContract]
        public List<LightSale> ListSalesWithPaging(DateTime start, DateTime end, int? CustomerID, string InvoiceStatusID, int startIndex, int pageSize)
        {
            Accountant acc = AccLoader.Instance.Pool.CurrentAccountant;
            BOListSale model = new BOListSale(acc);
            Customer customer = acc.CustomerMgr.FindById(CustomerID);
            Status invoiceStatus = acc.StatusMgr.FindById(InvoiceStatusID);
            List<SaleRow> rows = model.ListLight(start, end, customer, invoiceStatus, startIndex, pageSize);

            acc.Release();

            List<LightSale> _grp = new List<LightSale>();
            foreach (SaleRow _row in rows)
            {
                _grp.Add(new LightSale
                    {
                        SaleID = _row.SaleID.ToString(),
                        Amount = _row.AmountDesc,
                        AmountDue = _row.AmountDueDesc,
                        InvoiceDate=_row.InvoiceDateDesc,
                        Customer=_row.Customer,
                        InvoiceNumber=_row.InvoiceNumber,
                        InvoiceStatus=_row.InvoiceStatus.ToString()
                    });
            }

            return _grp;
        }
        //*/

        [OperationContract]
        public int GetSalesCount(DateTime start, DateTime end, int? CustomerID, string InvoiceStatusID)
        {
            Accountant acc = AccLoader.Instance.Pool.CurrentAccountant;
            BOListSale model = new BOListSale(acc);
            Customer customer = acc.CustomerMgr.FindById(CustomerID);
            Status invoiceStatus = acc.StatusMgr.FindById(InvoiceStatusID);

            int count = model.GetSaleCount(start, end, customer, invoiceStatus);

            acc.Release();

            return count;
        }

        [OperationContract]
        public List<LightEmployee> ListSalespersons()
        {
            Accountant acc = AccLoader.Instance.Pool.CurrentAccountant;
            List<EmployeeRow> rows = acc.EmployeeMgr.ListRow();

            acc.Release();

            List<LightEmployee> _grp = new List<LightEmployee>();
            foreach (EmployeeRow _row in rows)
            {
                _grp.Add(new LightEmployee
                {
                    EmployeeID = _row.EmployeeID.ToString(),
                    Name = string.Format("{0}, {1}", _row.FirstName, _row.LastName)
                });
            }

            //_grp.Add(new Was.Web.LightEmployee { EmployeeID = "1", AmountDue = "20", Amount = "20" });
            //_grp.Add(new Was.Web.LightEmployee { EmployeeID = "2", AmountDue = "20", Amount = "20" });



            return _grp;
        }

        [OperationContract]
        public List<LightCustomer> ListCustomers()
        {
            Accountant acc = AccLoader.Instance.Pool.CurrentAccountant;
            List<CustomerRow> rows = acc.CustomerMgr.ListRow();

            acc.Release();

            List<LightCustomer> _grp = new List<LightCustomer>();
            foreach (CustomerRow _row in rows)
            {
                _grp.Add(new LightCustomer
                {
                    CustomerID = _row.CustomerID.ToString(),
                    Name=_row.Name
                });
            }

            //_grp.Add(new Was.Web.LightCustomer { CustomerID = "1", AmountDue = "20", Amount = "20" });
            //_grp.Add(new Was.Web.LightCustomer { CustomerID = "2", AmountDue = "20", Amount = "20" });



            return _grp;
        }

        [OperationContract]
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

            _sale2.Customer = new LightCustomer { CustomerID = _sale2.CustomerID };
            _sale2.Terms = new LightTerms { TermsID = _sale2.TermsID };
            _sale2.ShippingMethod=new LightShippingMethod{ShippingMethodID=_sale2.ShippingMethodID };
            
            return _sale2;
        }

        [OperationContract]
        public List<LightSale> ListSales(DateTime start, DateTime end, int? CustomerID, string InvoiceStatusID)
        {
            Accountant acc = AccLoader.Instance.Pool.CurrentAccountant;
            BOListSale model = new BOListSale(acc);
            Customer customer = acc.CustomerMgr.FindById(CustomerID);
            Status invoiceStatus = acc.StatusMgr.FindById(InvoiceStatusID);
            List<SaleRow> rows = model.ListLight(start, end, customer, invoiceStatus, null, null);

            acc.Release();

            List<LightSale> _grp = new List<LightSale>();
            foreach (SaleRow _row in rows)
            {
                _grp.Add(new LightSale
                {
                    SaleID = _row.SaleID.ToString(),
                    InvoiceNumber=_row.InvoiceNumber,
                    InvoiceDate=_row.InvoiceDateDesc,
                    Amount = _row.AmountDesc,
                    AmountDue = _row.AmountDueDesc,
                    Customer=_row.Customer,
                    InvoiceStatus = _row.InvoiceStatus.ToString()
                });
            }

            //_grp.Add(new Was.Web.LightSale { SaleID = "1", AmountDue = "20", Amount = "20" });
            //_grp.Add(new Was.Web.LightSale { SaleID = "2", AmountDue = "20", Amount = "20" });



            return _grp;
        }
        //*/

        /*
        [OperationContract]
        public List<Was.Web.LightSale> ListSales(DateTime start, DateTime end)
        {
            
            List<LightSale> _grp = new List<LightSale>();
            _grp.Add(new Was.Web.LightSale { SaleID = "1", AmountDue = "20", Amount = "20" });
            _grp.Add(new Was.Web.LightSale { SaleID = "2", AmountDue = "20", Amount = "20" });

            return _grp; //model.ListLight(start, end, null, null);
        }

        //*/

        // Add more operations here and mark them with [OperationContract]
        [OperationContract]
        public List<LightTaxCode> ListTaxCodes()
        {

            Accountant acc = AccLoader.Instance.Pool.CurrentAccountant;
            IList<TaxCode> rows = acc.TaxCodeMgr.FindAllCollection();

            acc.Release();

            List<LightTaxCode> _grp = new List<LightTaxCode>();
            foreach (TaxCode _row in rows)
            {
                _grp.Add(new LightTaxCode
                {
                    TaxCodeID = _row.TaxCodeID.ToString(),
                    Description = _row.TaxCodeDescription
                });
            }

            //_grp.Add(new Was.Web.LightCustomer { CustomerID = "1", AmountDue = "20", Amount = "20" });
            //_grp.Add(new Was.Web.LightCustomer { CustomerID = "2", AmountDue = "20", Amount = "20" });



            return _grp;
        }

        // Add more operations here and mark them with [OperationContract]
        [OperationContract]
        public List<LightShippingMethod> ListShippingMethods()
        {

            Accountant acc = AccLoader.Instance.Pool.CurrentAccountant;
            IList<ShippingMethod> rows = acc.ShippingMethodMgr.FindAllCollection();

            acc.Release();

            List<LightShippingMethod> _grp = new List<LightShippingMethod>();
            foreach (ShippingMethod _row in rows)
            {
                _grp.Add(new LightShippingMethod
                {
                    ShippingMethodID = _row.ShippingMethodID.ToString(),
                    Description = _row.ToString()
                });
            }

            //_grp.Add(new Was.Web.LightCustomer { CustomerID = "1", AmountDue = "20", Amount = "20" });
            //_grp.Add(new Was.Web.LightCustomer { CustomerID = "2", AmountDue = "20", Amount = "20" });



            return _grp;
        }

        // Add more operations here and mark them with [OperationContract]
        [OperationContract]
        public List<LightComment> ListComments()
        {

            Accountant acc = AccLoader.Instance.Pool.CurrentAccountant;
            IList<Comment> rows = acc.CommentMgr.FindAllCollection();

            acc.Release();

            List<LightComment> _grp = new List<LightComment>();
            foreach (Comment _row in rows)
            {
                _grp.Add(new LightComment
                {
                    CommentID = _row.CommentID.ToString(),
                    Description = _row.Text
                });
            }

            //_grp.Add(new Was.Web.LightCustomer { CustomerID = "1", AmountDue = "20", Amount = "20" });
            //_grp.Add(new Was.Web.LightCustomer { CustomerID = "2", AmountDue = "20", Amount = "20" });



            return _grp;
        }

        // Add more operations here and mark them with [OperationContract]
        [OperationContract]
        public List<LightInvoiceType> ListInvoiceTypes()
        {

            Accountant acc = AccLoader.Instance.Pool.CurrentAccountant;
            IList<InvoiceType> rows = acc.InvoiceTypeMgr.FindAllCollection();

            acc.Release();

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

        // Add more operations here and mark them with [OperationContract]
        [OperationContract]
        public List<LightCurrency> ListCurrency()
        {

            Accountant acc = AccLoader.Instance.Pool.CurrentAccountant;
            IList<Currency> rows = acc.CurrencyMgr.FindAllCollection();

            acc.Release();

            List<LightCurrency> _grp = new List<LightCurrency>();
            foreach (Currency _row in rows)
            {
                _grp.Add(new LightCurrency
                {
                    CurrencyID = _row.CurrencyID.ToString(),
                    Description = _row.ToString()
                });
            }

            //_grp.Add(new Was.Web.LightCustomer { CustomerID = "1", AmountDue = "20", Amount = "20" });
            //_grp.Add(new Was.Web.LightCustomer { CustomerID = "2", AmountDue = "20", Amount = "20" });



            return _grp;
        }

        // Add more operations here and mark them with [OperationContract]
        [OperationContract]
        public List<LightInvoiceDelivery> ListInvoiceDeliveries()
        {

            Accountant acc = AccLoader.Instance.Pool.CurrentAccountant;
            IList<InvoiceDelivery> rows = acc.InvoiceDeliveryMgr.FindAllCollection();

            acc.Release();

            List<LightInvoiceDelivery> _grp = new List<LightInvoiceDelivery>();
            foreach (InvoiceDelivery _row in rows)
            {
                _grp.Add(new LightInvoiceDelivery
                {
                    InvoiceDeliveryID = _row.InvoiceDeliveryID.ToString(),
                    Description = _row.Description
                });
            }

            //_grp.Add(new Was.Web.LightCustomer { CustomerID = "1", AmountDue = "20", Amount = "20" });
            //_grp.Add(new Was.Web.LightCustomer { CustomerID = "2", AmountDue = "20", Amount = "20" });



            return _grp;
        }



        // Add more operations here and mark them with [OperationContract]
        [OperationContract]
        public List<LightTerms> ListTerms()
        {

            Accountant acc = AccLoader.Instance.Pool.CurrentAccountant;
            IList<Terms> rows = acc.TermsMgr.FindAllCollection();

            acc.Release();

            List<LightTerms> _grp = new List<LightTerms>();
            foreach (Terms _row in rows)
            {
                _grp.Add(new LightTerms
                {
                    TermsID = _row.TermsID.ToString(),
                    Description = _row.ToString()
                });
            }

            //_grp.Add(new Was.Web.LightCustomer { CustomerID = "1", AmountDue = "20", Amount = "20" });
            //_grp.Add(new Was.Web.LightCustomer { CustomerID = "2", AmountDue = "20", Amount = "20" });



            return _grp;
        }

        //private class TokenData
        //{
        //    public string Username;
        //    public DateTime Expires = DateTime.Now.AddHours(1);

        //    public void UpdateExpiration()
        //    {
        //        Expires = DateTime.Now.AddHours(1);
        //    }

        //    public bool IsExpired
        //    {
        //        get
        //        {
        //            return DateTime.Now > Expires;
        //        }
        //    }
        //}

    }
}
