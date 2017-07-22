using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Inventory
{
    public class ItemSalesHistory : Entity
    {
        internal ItemSalesHistory(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mItemSalesHistoryID;
        public int? ItemSalesHistoryID
        {
            get { return mItemSalesHistoryID; }
            set
            {
                mItemSalesHistoryID = value;
                NotifyPropertyChanged("ItemSalesHistoryID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("ItemSalesHistoryID", ItemSalesHistoryID);
            }
        }

        #region Item
        private Item mItem = null;
        public Item Item
        {
            get
            {
                if (mItem == null) mItem = (Item)BuildProperty(this, "Item");
                return mItem;
            }
            set
            {
                mItem = value;
                NotifyPropertyChanged("Item");
            }
        }
        private int? mItemID;
        public int? ItemID
        {
            get
            {
                if (mItem != null) return mItem.ItemID;
                return mItemID;
            }
            set
            {
                mItemID = value;
                NotifyPropertyChanged("ItemID");
            }
        }
        #endregion

        private int? mFinancialYear;
        public int? FinancialYear
        {
            get
            {
                return mFinancialYear;
            }
            set
            {
                mFinancialYear = value;
                NotifyPropertyChanged("FinancialYear");
            }
        }

        private int? mPeriod;
        public int? Period
        {
            get { return mPeriod; }
            set
            {
                mPeriod = value;
                NotifyPropertyChanged("Period");
            }
        }

        private double mUnitsSold;
        public double UnitsSold
        {
            get
            {
                return mUnitsSold;
            }
            set
            {
                mUnitsSold = value;
                NotifyPropertyChanged("UnitsSold");
            }
        }

        private double mSaleAmount;
        public double SaleAmount
        {
            get { return mSaleAmount; }
            set
            {
                mSaleAmount = value;
                NotifyPropertyChanged("SaleAmount");
            }
        }


        private double mCostOfSalesAmount;
        public double CostOfSalesAmount
        {
            get { return mCostOfSalesAmount; }
            set
            {
                mCostOfSalesAmount = value;
                NotifyPropertyChanged("CostOfSalesAmount");
            }
        }

    }
}
