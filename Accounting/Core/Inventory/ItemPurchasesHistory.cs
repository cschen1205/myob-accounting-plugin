using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Inventory
{
    public class ItemPurchasesHistory : Entity
    {
        internal ItemPurchasesHistory(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mItemPurchasesHistoryID;
        public int? ItemPurchasesHistoryID
        {
            get { return mItemPurchasesHistoryID; }
            set
            {
                mItemPurchasesHistoryID = value;
                NotifyPropertyChanged("ItemPurchasesHistoryID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("ItemPurchasesHistoryID", ItemPurchasesHistoryID);
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
            get { return mFinancialYear; }
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

        private double mUnitsBought;
        public double UnitsBought
        {
            get { return mUnitsBought; }
            set
            {
                mUnitsBought = value;
                NotifyPropertyChanged("UnitsBought");
            }
        }

        private double mPurchaseAmount;
        public double PurchaseAmount
        {
            get { return mPurchaseAmount; }
            set
            {
                mPurchaseAmount = value;
                NotifyPropertyChanged("PurchaseAmount");
            }
        }

    }
}
