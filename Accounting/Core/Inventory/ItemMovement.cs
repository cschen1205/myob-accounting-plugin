using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Inventory
{
    public class ItemMovement : Entity
    {
        internal ItemMovement(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mItemMovementID;
        public int? ItemMovementID
        {
            get { return mItemMovementID; }
            set
            {
                mItemMovementID = value;
                NotifyPropertyChanged("ItemMovementID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("ItemMovementID", ItemMovementID);
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

        private double mUnitChange;
        public double UnitChange
        {
            get { return mUnitChange; }
            set
            {
                mUnitChange = value;
                NotifyPropertyChanged("UnitChange");
            }
        }

        private double mDollarChange;
        public double DollarChange
        {
            get { return mDollarChange; }
            set
            {
                mDollarChange = value;
                NotifyPropertyChanged("DollarChange");
            }
        }
    }
}
