using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Purchases;
using Accounting.Core.Definitions;
using Accounting.Core.Cards;
using Accounting.Core.Inventory;
using Accounting.Core.Terms;
using Accounting.Core.ShippingMethods;
using Accounting.Core.TaxCodes;
using Accounting.Db.Elements;
using Accounting.Core;

namespace Accounting.Bll.Purchases
{
    using System.ComponentModel;
    public class BOListPurchase : BOList<BOPurchase>
    {
        public static string CHANGE_QUOTE_TO_ORDER = "ChangeQuote2Order";
        public static string CHANGE_QUOTE_TO_BILL = "ChangeQuote2Bill";
        public static string CHANGE_ORDER_TO_BILL = "ChangeOrder2Bill";
        public static string START_DATE = "StartDate";
        public static readonly string END_DATE = "EndDate";
        public static readonly string SUPPLIER = "Supplier";
        public static readonly string ALL_SUPPLIERS = "AllSuppliers";
        public static readonly string CREATE_QUOTE = "CreateQuote";
        public static readonly string CREATE_ORDER = "CreateOrder";
        public static readonly string DELETE_QUOTE = "DeleteQuote";

        public static readonly string ALL_PURCHASES_INFORMATION = "AllPurchasesInformation";
        public static readonly string QUOTES_INFORMATION = "QuotesInformation";
        public static readonly string ORDERS_INFORMATION = "OrdersInformation";
        public static readonly string OPEN_BILLS_INFORMATION = "OpenBillsInformation";
        public static readonly string DEBIT_RETURNS_INFORMATION = "DebitReturnsInformation";
        public static readonly string CLOSED_BILLS_INFORMATION = "ClosedBillsInformation";


        private BindingList<Purchase> mQuotes = new BindingList<Purchase>();
        private BindingList<Purchase> mOrders=new BindingList<Purchase>();
        private BindingList<Purchase> mOpenBills=new BindingList<Purchase>();
        private BindingList<Purchase> mClosedBills=new BindingList<Purchase>();
        private BindingList<Purchase> mDebitReturns=new BindingList<Purchase>();
        private BindingList<Purchase> mAllPurchases=new BindingList<Purchase>();

        public IList<Purchase> Quotes { get { return mQuotes;  }}
        public IList<Purchase> Orders { get { return mOrders; }}
        public IList<Purchase> OpenBills { get { return mOpenBills; }}
        public IList<Purchase> ClosedBills { get { return mClosedBills; }}
        public IList<Purchase> DebitReturns { get { return mDebitReturns; }}
        public IList<Purchase> AllPurchases { get { return mAllPurchases; }}

        private DateTime? mStartDate;
        private DateTime? mEndDate;
        private Supplier mSupplier;
        private bool mAllSupplier=true;

        public BOListPurchase(Accountant accountant)
            : base(accountant)
        {
            mObjectID = BOType.BOListPurchase;
            UpdateContent();
            mAccountant.PurchaseMgr.PropertyChanged += new PropertyChangedEventHandler(PurchaseMgr_PropertyChanged);
        }

        void PurchaseMgr_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateContent();
            NotifyPropertyChanged(e.PropertyName);
        }

        protected override void UpdateContent()
        {
            if (mStartDate == null || mEndDate == null) return;
            Supplier supplier = mSupplier;
            if (mAllSupplier) supplier = null;

            mQuotes.Clear();
            IList<Purchase> quotes = FindQuotes(mStartDate, mEndDate, supplier);
            foreach (Purchase quote in quotes)
            {
                mQuotes.Add(quote);
            }

            mOrders.Clear();
            IList<Purchase> orders = FindOrders(mStartDate, mEndDate, supplier);
            foreach (Purchase order in orders)
            {
                mOrders.Add(order);
            }

            mOpenBills.Clear();
            IList<Purchase> open_bills = FindOpenBills(mStartDate, mEndDate, supplier);
            foreach (Purchase open_bill in open_bills)
            {
                mOpenBills.Add(open_bill);
            }

            mClosedBills.Clear();
            IList<Purchase> closed_bills = FindClosedBills(mStartDate, mEndDate, supplier);
            foreach (Purchase closed_bill in closed_bills)
            {
                mClosedBills.Add(closed_bill);
            }

            mDebitReturns.Clear();
            IList<Purchase> debit_returns = FindDebitReturns(mStartDate, mEndDate, supplier);
            foreach (Purchase debit_return in debit_returns)
            {
                mDebitReturns.Add(debit_return);
            }

            mAllPurchases.Clear();
            IList<Purchase> all_purchases = FindAllPurchases(mStartDate, mEndDate, supplier);
            foreach (Purchase purchase in all_purchases)
            {
                mAllPurchases.Add(purchase);
            }
        }

        public Status BillStatus_Quote
        {
            get { return mAccountant.StatusMgr.Status_Quote; }
        }

        public Status BillStatus_Order
        {
            get { return mAccountant.StatusMgr.Status_Order; }
        }

        public Status BillStatus_ClosedBill
        {
            get { return mAccountant.StatusMgr.Status_Closed; }
        }

        public Status BillStatus_OpenBill
        {
            get { return mAccountant.StatusMgr.Status_Open; }
        }

        public Status BillStatus_DebitReturn
        {
            get { return mAccountant.StatusMgr.Status_DebitReturn; }
        }

        private IList<Purchase> FindAllPurchases(DateTime? start, DateTime? end, Supplier supplier)
        {
            return mAccountant.PurchaseMgr.FindFilteredCollection(start, end, supplier, null);
        }

        private IList<Purchase> FindQuotes(DateTime? start, DateTime? end, Supplier supplier)
        {
            return mAccountant.PurchaseMgr.FindFilteredCollection(start, end, supplier, BillStatus_Quote);
        }

        private IList<Purchase> FindOrders(DateTime? start, DateTime? end, Supplier supplier)
        {
            return mAccountant.PurchaseMgr.FindFilteredCollection(start, end, supplier, BillStatus_Order);
        }

        private IList<Purchase> FindOpenBills(DateTime? start, DateTime? end, Supplier supplier)
        {
            return mAccountant.PurchaseMgr.FindFilteredCollection(start, end, supplier, BillStatus_OpenBill);
        }

        private IList<Purchase> FindDebitReturns(DateTime? start, DateTime? end, Supplier supplier)
        {
            return mAccountant.PurchaseMgr.FindFilteredCollection(start, end, supplier, BillStatus_DebitReturn);
        }

        private IList<Purchase> FindClosedBills(DateTime? start, DateTime? end, Supplier supplier)
        {
            return mAccountant.PurchaseMgr.FindFilteredCollection(start, end, supplier, BillStatus_ClosedBill);
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

            AddProperty(SUPPLIER,
                SUPPLIER,
                Supplier_Get,
                Supplier_Set,
                Supplier_IsEnabled,
                Supplier_IsVisible,
                Supplier_Validate);

            AddProperty(ALL_SUPPLIERS,
                ALL_SUPPLIERS,
                AllSuppliers_Get,
                AllSuppliers_Set,
                AllSuppliers_IsEnabled,
                AllSuppliers_IsVisible,
                AllSuppliers_Validate);

            AddProperty(CHANGE_ORDER_TO_BILL,
                CHANGE_ORDER_TO_BILL,
                delegate() { return "Change Order to Bill"; },
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

            AddProperty(CHANGE_QUOTE_TO_BILL,
                CHANGE_QUOTE_TO_BILL,
                delegate() { return "Change Quote to Bill"; },
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

            AddProperty(ALL_PURCHASES_INFORMATION,
                ALL_PURCHASES_INFORMATION,
                delegate() { return string.Format("# Records: {0}", mAllPurchases.Count); },
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

            AddProperty(OPEN_BILLS_INFORMATION,
                OPEN_BILLS_INFORMATION,
                delegate() { return string.Format("# Records: {0}", mOpenBills.Count); },
                delegate(object value) { },
                delegate() { return true; },
                delegate() { return true; },
                delegate(object value, ref string errror) { return true; });

            AddProperty(DEBIT_RETURNS_INFORMATION,
                DEBIT_RETURNS_INFORMATION,
                delegate() { return string.Format("# Records: {0}", mDebitReturns.Count); },
                delegate(object value) { },
                delegate() { return true; },
                delegate() { return true; },
                delegate(object value, ref string errror) { return true; });

            AddProperty(CLOSED_BILLS_INFORMATION,
                CLOSED_BILLS_INFORMATION,
                delegate() { return string.Format("# Records: {0}", mClosedBills.Count); },
                delegate(object value) { },
                delegate() { return true; },
                delegate() { return true; },
                delegate(object value, ref string errror) { return true; });
        }

        public override bool CanDelete
        {
            get
            {
                return mAccountant.PurchaseMgr.DbMgr.AllowDelete;
            }
        }

        public object AllSuppliers_Get()
        {
            return mAllSupplier;
        }

        public void AllSuppliers_Set(object value)
        {
            bool is_all_supplier = (bool)value;
            if(mAllSupplier != is_all_supplier)
            {
                mAllSupplier = is_all_supplier;
                UpdateContent();
                NotifyContentChanged();
            }
        }


        private void NotifyContentChanged()
        {
            NotifyPropertyChanged(ALL_PURCHASES_INFORMATION);
            NotifyPropertyChanged(QUOTES_INFORMATION);
            NotifyPropertyChanged(ORDERS_INFORMATION);
            NotifyPropertyChanged(OPEN_BILLS_INFORMATION);
            NotifyPropertyChanged(CLOSED_BILLS_INFORMATION);
            NotifyPropertyChanged(DEBIT_RETURNS_INFORMATION);
        }

        public bool AllSuppliers_IsVisible()
        {
            return true;
        }

        public bool AllSuppliers_IsEnabled()
        {
            return true;
        }

        public bool AllSuppliers_Validate(object value, ref string error)
        {
            return true;
        }

        public object Supplier_Get()
        {
            return mSupplier;
        }

        public void Supplier_Set(object value)
        {
            if (mSupplier != value)
            {
                mSupplier = value as Supplier;
                UpdateContent();
                NotifyContentChanged();
            }
        }

        public bool Supplier_IsEnabled()
        {
            return mAllSupplier==false;
        }

        public bool Supplier_IsVisible()
        {
            return true;
        }

        public bool Supplier_Validate(object value, ref string error)
        {
            return true;
        }

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

        public Purchase FindByPurchaseNumber(string purchase_number)
        {
            Purchase _entity = mAccountant.PurchaseMgr.FindByPurchaseNumber(purchase_number);
            return _entity;
        }
    }
}
