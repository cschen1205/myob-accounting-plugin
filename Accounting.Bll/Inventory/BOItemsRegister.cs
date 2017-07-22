using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Db.Elements;


namespace Accounting.Bll.Inventory
{
    using Accounting.Core.Purchases;
    using Accounting.Core.Sales;
    using Accounting.Core.Inventory;
    using System.ComponentModel;
    public class BOItemsRegister : BOList<BOTransaction>
    {
 
        public static readonly string ITEM = "Item";
        public static readonly string ALL_ITEMS = "AllItems";
        public static readonly string START_DATE = "StartDate";
        public static readonly string END_DATE = "EndDate";

        private BindingList<ItemTransactionJournal> mJournals = new BindingList<ItemTransactionJournal>();

        private DateTime? mStartDate;
        private DateTime? mEndDate;
        private Item mItem;
        private bool mAllItem = true;

        public BindingList<ItemTransactionJournal> Journals
        {
            get { return mJournals; }
        }

        public BOItemsRegister(Accountant accountant)
            : base(accountant)
        {
            mObjectID = BOType.BOItemsRegister;

            UpdateContent();
            mAccountant.SaleMgr.PropertyChanged += new PropertyChangedEventHandler(SaleMgr_PropertyChanged);
            mAccountant.PurchaseMgr.PropertyChanged += new PropertyChangedEventHandler(PurchaseMgr_PropertyChanged);
        }

        void PurchaseMgr_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateContent();
            NotifyPropertyChanged(e.PropertyName);
        }

        void SaleMgr_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateContent();
            NotifyPropertyChanged(e.PropertyName);
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

            AddProperty(ITEM,
                ITEM,
                Item_Get,
                Item_Set,
                Item_IsEnabled,
                Item_IsVisible,
                Item_Validate);

            AddProperty(ALL_ITEMS,
                ALL_ITEMS,
                AllItems_Get,
                AllItems_Set,
                AllItems_IsEnabled,
                AllItems_IsVisible,
                AllItems_Validate);
        }


        private void NotifyContentChanged()
        {
            //NotifyPropertyChanged(ALL_SALES_INFORMATION);
            //NotifyPropertyChanged(QUOTES_INFORMATION);
            //NotifyPropertyChanged(ORDERS_INFORMATION);
            //NotifyPropertyChanged(OPEN_INVOICES_INFORMATION);
            //NotifyPropertyChanged(CLOSED_INVOICES_INFORMATION);
            //NotifyPropertyChanged(CREDIT_RETURNS_INFORMATION);
        }

        #region AllItems
        public bool AllItems_IsVisible()
        {
            return true;
        }

        public bool AllItems_IsEnabled()
        {
            return true;
        }

        public bool AllItems_Validate(object value, ref string error)
        {
            return true;
        }
        public object AllItems_Get()
        {
            return mAllItem;
        }

        public void AllItems_Set(object value)
        {
            mAllItem = (bool)value;
            UpdateContent();
            NotifyContentChanged();
        }
        #endregion

        #region Item
        public object Item_Get()
        {
            return mItem;
        }
        public void Item_Set(object value)
        {
            if (mItem != value)
            {
                mItem = value as Item;
                UpdateContent();
                NotifyContentChanged();
            }
        }
        public bool Item_IsEnabled()
        {
            return mAllItem == false;
        }
        public bool Item_IsVisible()
        {
            return true;
        }
        public bool Item_Validate(object value, ref string error)
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
            //Console.WriteLine("EndDate: {0}", mEndDate.Value);
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
            //Console.WriteLine("Start Date: {0}", mStartDate.Value);
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

        protected override void UpdateContent()
        {
            //Console.WriteLine("UpdateContent on ItemRegisters");
            //if (mStartDate == null)
            //{
            //    Console.WriteLine("UpdateContent: Start Date is null");
            //}
            //else
            //{
            //    Console.WriteLine("UpdateContent: Start Date is {0}", mStartDate.Value);
            //}

            //if (mEndDate == null)
            //{
            //    Console.WriteLine("UpdateContent: End Date is null");
            //}
            //else
            //{
            //    Console.WriteLine("UpdateContent: End Date is {0}", mEndDate.Value);
            //}
            if (mStartDate == null || mEndDate == null) return;
            //Console.WriteLine("UpdateContent on ItemRegisters: start date and end date not null");

            Item _item=mItem;
             if (mAllItem)
            {
                 _item=null;
             }

            mJournals.Clear();
            IList<Sale> sales = mAccountant.SaleMgr.FindFilteredItemSaleCollection(mStartDate, mEndDate, _item);
            IList<Purchase> purchases = mAccountant.PurchaseMgr.FindFilteredItemPurchaseCollection(mStartDate, mEndDate, _item);
            IList<InventoryAdjustment> ias = mAccountant.InventoryAdjustmentMgr.FindFilteredInventoryAdjustmentCollection(mStartDate, mEndDate, _item);

            //Console.WriteLine("UpdateContent on ItemRegisters: sale item count={0}", sales.Count);
            //Console.WriteLine("UpdateContent on ItemRegisters: purchase item count={0}", purchases.Count);

            foreach (Sale _sale in sales)
            {
                foreach (ItemSaleLine _line in _sale.SaleLines)
                {
                    ItemTransactionJournal journal = new ItemTransactionJournal();
                    journal.Item = _line.Item;
                    journal.SaleJournal = _sale;
                    journal.ItemSaleLine = _line;
                    mJournals.Add(journal);
                }
            }
            foreach (Purchase _purchase in purchases)
            {
                foreach (ItemPurchaseLine _line in _purchase.PurchaseLines)
                {
                    ItemTransactionJournal journal = new ItemTransactionJournal();
                    journal.Item = _line.Item;
                    journal.PurchaseJournal = _purchase;
                    journal.ItemPurchaseLine = _line;
                    mJournals.Add(journal);
                }
            }
            foreach (InventoryAdjustment _ia in ias)
            {
                foreach (InventoryAdjustmentLine _line in _ia.Lines)
                {
                    ItemTransactionJournal journal = new ItemTransactionJournal();
                    journal.Item = _line.Item;
                    journal.InventoryAdjustmentJournal = _ia;
                    journal.InventoryAdjustmentLine = _line;
                    mJournals.Add(journal);
                }
            }
        }
        
    }
}
