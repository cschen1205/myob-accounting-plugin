using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Inventory
{
    public class ItemOpeningBalance : Entity
    {
        internal ItemOpeningBalance(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mItemOpeningBalanceID;
        public int? ItemOpeningBalanceID
        {
            get { return mItemOpeningBalanceID; }
            set
            {
                mItemOpeningBalanceID = value;
                NotifyPropertyChanged("ItemOpeningBalanceID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("ItemOpeningBalanceID", ItemOpeningBalanceID);
            }
        }

        #region Item
        private Item mItem = null;
        public Item Item
        {
            get
            {
                if (mItem == null)
                {
                    mItem = (Item)BuildProperty(this, "Item");
                }
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
                if (mItem != null)
                {
                    return mItem.ItemID;
                }
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

        private double mUnits;
        public double Units
        {
            get { return mUnits; }
            set
            {
                mUnits = value;
                NotifyPropertyChanged("Units");
            }
        }

        private double mDollars;
        public double Dollars
        {
            get { return mDollars; }
            set
            {
                mDollars = value;
                NotifyPropertyChanged("Dollars");
            }
        }
    }
}
