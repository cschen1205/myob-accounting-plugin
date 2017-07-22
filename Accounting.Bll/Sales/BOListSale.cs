using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Sales
{
    using Accounting.Core.Sales;
    using Accounting.Core.Definitions;
    using Accounting.Core.Cards;
    using Accounting.Core.Inventory;
    using Accounting.Core.Terms;
    using Accounting.Core.ShippingMethods;
    using Accounting.Core.TaxCodes;
    using Accounting.Db.Elements;
    using Accounting.Core;
    using System.ComponentModel;
    public class BOListSale : BOList<BOSale>
    {
        public static readonly string CHANGE_ORDER_TO_INVOICE = "ChangeOrder2Invoice";
        public static readonly string CHANGE_QUOTE_TO_ORDER = "ChangeQuote2Order";
        public static readonly string CHANGE_QUOTE_TO_INVOICE = "ChangeQuote2Invoice";


        public static readonly string ALL_SALES_INFORMATION = "AllSalesInformation";
        public static readonly string QUOTES_INFORMATION = "QuotesInformation";
        public static readonly string ORDERS_INFORMATION = "OrdersInformation";
        public static readonly string OPEN_INVOICES_INFORMATION = "OpenInvoicesInformation";
        public static readonly string CREDIT_RETURNS_INFORMATION = "CreditReturnsInformation";
        public static readonly string CLOSED_INVOICES_INFORMATION = "ClosedInvoicesInformation";

        public static string START_DATE = "StartDate";
        public static readonly string END_DATE = "EndDate";
        public static readonly string CUSTOMER = "Customer";
        public static readonly string ALL_CUSTOMERS = "AllCustomers";
        public static readonly string CREATE_QUOTE = "CreateQuote";
        public static readonly string CREATE_ORDER = "CreateOrder";
        public static readonly string DELETE_QUOTE = "DeleteQuote";

        private BindingList<Sale> mQuotes = new BindingList<Sale>();
        private BindingList<Sale> mOrders = new BindingList<Sale>();
        private BindingList<Sale> mOpenInvoices = new BindingList<Sale>();
        private BindingList<Sale> mClosedInvoices = new BindingList<Sale>();
        private BindingList<Sale> mCreditReturns = new BindingList<Sale>();
        private BindingList<Sale> mAllSales = new BindingList<Sale>();

        public IList<Sale> Quotes { get { return mQuotes; } }
        public IList<Sale> Orders { get { return mOrders; } }
        public IList<Sale> OpenInvoices { get { return mOpenInvoices; } }
        public IList<Sale> ClosedInvoices { get { return mClosedInvoices; } }
        public IList<Sale> CreditReturns { get { return mCreditReturns; } }
        public IList<Sale> AllSales { get { return mAllSales; } }

        private DateTime? mStartDate;
        private DateTime? mEndDate;
        private Customer mCustomer;
        private bool mAllCustomer = true;

        public BOListSale(Accountant accountant)
            : base(accountant)
        {
            mObjectID = BOType.BOListSale;
            UpdateContent();
            mAccountant.SaleMgr.PropertyChanged += new PropertyChangedEventHandler(SaleMgr_PropertyChanged);
        }

        protected override void UpdateContent()
        {
            if (mStartDate == null || mEndDate == null) return;
            Customer customer = mCustomer;
            if (mAllCustomer) customer = null;

            mQuotes.Clear();
            IList<Sale> quotes = FindQuotes(mStartDate, mEndDate, customer);
            foreach (Sale quote in quotes)
            {
                mQuotes.Add(quote);
            }

            mOrders.Clear();
            IList<Sale> orders = FindOrders(mStartDate, mEndDate, customer);
            foreach (Sale order in orders)
            {
                mOrders.Add(order);
            }

            mOpenInvoices.Clear();
            IList<Sale> open_invoices = FindOpenInvoices(mStartDate, mEndDate, customer);
            foreach (Sale open_invoice in open_invoices)
            {
                mOpenInvoices.Add(open_invoice);
            }

            mClosedInvoices.Clear();
            IList<Sale> closed_invoices = FindClosedInvoices(mStartDate, mEndDate, customer);
            foreach (Sale closed_invoice in closed_invoices)
            {
                mClosedInvoices.Add(closed_invoice);
            }

            mCreditReturns.Clear();
            IList<Sale> debit_returns = FindCreditReturns(mStartDate, mEndDate, customer);
            foreach (Sale debit_return in debit_returns)
            {
                mCreditReturns.Add(debit_return);
            }

            mAllSales.Clear();
            IList<Sale> all_purchases = FindAllSales(mStartDate, mEndDate, customer);
            foreach (Sale purchase in all_purchases)
            {
                mAllSales.Add(purchase);
            }
        }

        void SaleMgr_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateContent();
            NotifyPropertyChanged(e.PropertyName);
        }

        public Status InvoiceStatus_Quote
        {
            get { return mAccountant.StatusMgr.Status_Quote; }
        }

        public Status InvoiceStatus_Order
        {
            get { return mAccountant.StatusMgr.Status_Order; }
        }

        public Status InvoiceStatus_ClosedInvoice
        {
            get { return mAccountant.StatusMgr.Status_Closed; }
        }

        public Status InvoiceStatus_OpenInvoice
        {
            get { return mAccountant.StatusMgr.Status_Open; }
        }

        public Status InvoiceStatus_CreditReturn
        {
            get { return mAccountant.StatusMgr.Status_CreditReturn; }
        }

        public int GetSaleCount(DateTime start, DateTime end, Customer customer, Status invoiceStatus)
        {
            DbCriteria criteria = mAccountant.SaleMgr.CreateCriteria();
            criteria
                .IsGreaterEqual("Sales", "InvoiceDate", start)
                .IsLessEqual("Sales", "InvoiceDate", end);

            if (customer != null)
            {
                criteria.IsEqual("Customers", "CardIdentification", customer.CardIdentification);
            }

            if (invoiceStatus != null)
            {
                criteria.IsEqual("Sales", "InvoiceStatusID", invoiceStatus.StatusID);
            }

            return mAccountant.SaleMgr.GetPageCount(criteria);
        }

        public List<SaleRow> ListLight(DateTime start, DateTime end, Customer customer, Status invoiceStatus, int? startIndex, int? pageSize)
        {
            DbCriteria criteria = mAccountant.SaleMgr.CreateCriteria();
            criteria
                .IsGreaterEqual("Sales", "InvoiceDate", start)
                .IsLessEqual("Sales", "InvoiceDate", end);

            if (customer != null)
            {
                criteria.IsEqual("Customers", "CardIdentification", customer.CardIdentification);
            }

            if (invoiceStatus != null)
            {
                criteria.IsEqual("Sales", "InvoiceStatusID", invoiceStatus.StatusID);
            }

            return mAccountant.SaleMgr.ListTableRow(criteria, startIndex, pageSize);
        }

        protected override void InitializeProperties()
        {
            base.InitializeProperties();

            AddProperty(START_DATE,
                START_DATE,
                StartDate_Get,
                StartDate_Set,
                StartDate_IsEnabled,
                StartDate_IsVisible,
                StartDate_Validate);

            AddProperty(END_DATE,
                END_DATE,
                EndDate_Get,
                EndDate_Set,
                EndDate_IsEnabled,
                EndDate_IsVisible,
                EndDate_Validate);

            AddProperty(CUSTOMER,
                CUSTOMER,
                Customer_Get,
                Customer_Set,
                Customer_IsEnabled,
                Customer_IsVisible,
                Customer_Validate);

            AddProperty(ALL_CUSTOMERS,
                ALL_CUSTOMERS,
                AllCustomers_Get,
                AllCustomers_Set,
                AllCustomers_IsEnabled,
                AllCustomers_IsVisible,
                AllCustomers_Validate);

            AddProperty(CHANGE_ORDER_TO_INVOICE,
                CHANGE_ORDER_TO_INVOICE,
                delegate() { return "Change Order to Invoice"; },
                delegate(object value) { },
                delegate() { return CanEdit; },
                delegate() { return true; },
                delegate(object value, ref string error) { return true; });

            AddProperty(CHANGE_QUOTE_TO_ORDER,
                CHANGE_QUOTE_TO_ORDER,
                delegate() { return "Change Quote to Order"; },
                delegate(object value) { },
                delegate() { return true; },
                delegate() { return true; },
                delegate(object value, ref string error) { return true; });

            AddProperty(CHANGE_QUOTE_TO_INVOICE,
                CHANGE_QUOTE_TO_INVOICE,
                delegate() { return "Change Quote to Invoice"; },
                delegate(object value) { },
                delegate() { return CanEdit; },
                delegate() { return true; },
                delegate(object value, ref string error) { return true; });

            AddProperty(CREATE_ORDER,
               CREATE_ORDER,
               delegate() { return "Create Order"; },
               delegate(object value) { },
               delegate() { return CanEdit; },
               delegate() { return true; },
               delegate(object value, ref string error) { return true; });

            AddProperty(CREATE_QUOTE,
               CREATE_QUOTE,
               delegate() { return "Create Quote"; },
               delegate(object value) { },
               delegate() { return CanEdit; },
               delegate() { return true; },
               delegate(object value, ref string error) { return true; });

            AddProperty(DELETE_QUOTE,
               DELETE_QUOTE,
               delegate() { return "Delete Quote"; },
               delegate(object value) { },
               delegate() { return CanDelete; },
               delegate() { return CanDelete; },
               delegate(object value, ref string error) { return true; });

            AddProperty(ALL_SALES_INFORMATION,
                ALL_SALES_INFORMATION,
                delegate() { return string.Format("# Records: {0}", mAllSales.Count); },
                delegate(object value) { },
                delegate() { return true; },
                delegate() { return true; },
                delegate(object value, ref string errror) { return true; });

            AddProperty(QUOTES_INFORMATION,
                QUOTES_INFORMATION,
                delegate() { return string.Format("# Records: {0}", mQuotes.Count); },
                delegate(object value) { },
                delegate() { return true; },
                delegate() { return true; },
                delegate(object value, ref string errror) { return true; });

            AddProperty(ORDERS_INFORMATION,
                ORDERS_INFORMATION,
                delegate() { return string.Format("# Records: {0}", mOrders.Count); },
                delegate(object value) { },
                delegate() { return true; },
                delegate() { return true; },
                delegate(object value, ref string errror) { return true; });

            AddProperty(OPEN_INVOICES_INFORMATION,
                OPEN_INVOICES_INFORMATION,
                delegate() { return string.Format("# Records: {0}", mOpenInvoices.Count); },
                delegate(object value) { },
                delegate() { return true; },
                delegate() { return true; },
                delegate(object value, ref string errror) { return true; });

            AddProperty(CREDIT_RETURNS_INFORMATION,
                CREDIT_RETURNS_INFORMATION,
                delegate() { return string.Format("# Records: {0}", mCreditReturns.Count); },
                delegate(object value) { },
                delegate() { return true; },
                delegate() { return true; },
                delegate(object value, ref string errror) { return true; });

            AddProperty(CLOSED_INVOICES_INFORMATION,
                CLOSED_INVOICES_INFORMATION,
                delegate() { return string.Format("# Records: {0}", mClosedInvoices.Count); },
                delegate(object value) { },
                delegate() { return true; },
                delegate() { return true; },
                delegate(object value, ref string errror) { return true; });

        }


        private IList<Sale> FindAllSales(DateTime? start, DateTime? end, Customer customer)
        {
            return mAccountant.SaleMgr.FindFilteredCollection(start, end, customer, null);
        }

        private IList<Sale> FindOrders(DateTime? start, DateTime? end, Customer customer)
        {
            return mAccountant.SaleMgr.FindFilteredCollection(start, end, customer, InvoiceStatus_Order);
        }

        private IList<Sale> FindQuotes(DateTime? start, DateTime? end, Customer customer)
        {
            return mAccountant.SaleMgr.FindFilteredCollection(start, end, customer, InvoiceStatus_Quote);
        }

        private IList<Sale> FindOpenInvoices(DateTime? start, DateTime? end, Customer customer)
        {
            return mAccountant.SaleMgr.FindFilteredCollection(start, end, customer, InvoiceStatus_OpenInvoice);
        }
        private IList<Sale> FindCreditReturns(DateTime? start, DateTime? end, Customer customer)
        {
            return mAccountant.SaleMgr.FindFilteredCollection(start, end, customer, InvoiceStatus_CreditReturn);
        }
        private IList<Sale> FindClosedInvoices(DateTime? start, DateTime? end, Customer customer)
        {
            return mAccountant.SaleMgr.FindFilteredCollection(start, end, customer, InvoiceStatus_ClosedInvoice);
        }

      

        private void NotifyContentChanged()
        {
            NotifyPropertyChanged(ALL_SALES_INFORMATION);
            NotifyPropertyChanged(QUOTES_INFORMATION);
            NotifyPropertyChanged(ORDERS_INFORMATION);
            NotifyPropertyChanged(OPEN_INVOICES_INFORMATION);
            NotifyPropertyChanged(CLOSED_INVOICES_INFORMATION);
            NotifyPropertyChanged(CREDIT_RETURNS_INFORMATION);
        }

        #region AllCustomers
        public bool AllCustomers_IsVisible()
        {
            return true;
        }

        public bool AllCustomers_IsEnabled()
        {
            return true;
        }

        public bool AllCustomers_Validate(object value, ref string error)
        {
            return true;
        }
        public object AllCustomers_Get()
        {
            return mAllCustomer;
        }

        public void AllCustomers_Set(object value)
        {
            mAllCustomer = (bool)value;
            UpdateContent();
            NotifyContentChanged();
        }
        #endregion

        #region Customer
        public object Customer_Get()
        {
            return mCustomer;
        }
        public void Customer_Set(object value)
        {
            if (mCustomer != value)
            {
                mCustomer = value as Customer;
                UpdateContent();
                NotifyContentChanged();
            }
        }
        public bool Customer_IsEnabled()
        {
            return mAllCustomer == false;
        }
        public bool Customer_IsVisible()
        {
            return true;
        }
        public bool Customer_Validate(object value, ref string error)
        {
            return true;
        }
        #endregion

        #region EndDate
        public object EndDate_Get()
        {
            return mEndDate;
        }
        public void EndDate_Set(object value)
        {
            mEndDate = value as DateTime?;
            UpdateContent();
            NotifyContentChanged();
        }
        public bool EndDate_IsEnabled()
        {
            return true;
        }
        public bool EndDate_IsVisible()
        {
            return true;
        }
        public bool EndDate_Validate(object value, ref string error)
        {
            return true;
        }
        #endregion

        #region StartDate
        public object StartDate_Get()
        {
            return mStartDate;
        }
        public void StartDate_Set(object value)
        {
            mStartDate = value as DateTime?;
            UpdateContent();
            NotifyContentChanged();
        }
        public bool StartDate_IsVisible()
        {
            return true;
        }
        public bool StartDate_IsEnabled()
        {
            return true;
        }
        public bool StartDate_Validate(object value, ref string error)
        {
            return true;
        }
        #endregion


        public Sale FindByInvoiceNumber(string invoice_number)
        {
            return mAccountant.SaleMgr.FindByInvoiceNumber(invoice_number);
        }
    }
}
