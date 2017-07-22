using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Inventory
{
    public class NegativeInventory : Entity
    {
        internal NegativeInventory(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mNegativeInventoryID;
        public int? NegativeInventoryID
        {
            get { return mNegativeInventoryID; }
            set
            {
                mNegativeInventoryID = value;
                NotifyPropertyChanged("NegativeInventoryID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("NegativeInventoryID", NegativeInventoryID);
            }
        }

        #region SaleLine
        private Sales.SaleLine mSaleLine = null;
        public Sales.SaleLine SaleLine
        {
            get
            {
                if (mSaleLine == null) mSaleLine = (Sales.SaleLine)BuildProperty(this, "SaleLine");
                return mSaleLine;
            }
            set
            {
                mSaleLine = value;
                NotifyPropertyChanged("SaleLine");
            }
        }
        private int? mSaleLineID;
        public int? SaleLineID
        {
            get
            {
                if (mSaleLine != null) return mSaleLine.SaleLineID;
                return mSaleLineID;
            }
            set
            {
                mSaleLineID = value;
                NotifyPropertyChanged("SaleLineID");
            }
        }
        #endregion

        private double mQuantity;
        public double Quantity
        {
            get { return mQuantity; }
            set
            {
                mQuantity = value;
                NotifyPropertyChanged("Quantity");
            }
        }

        private string mIsCreditOffset = "N";
        public string IsCreditOffset
        {
            get { return mIsCreditOffset; }
            set
            {
                mIsCreditOffset = value;
                NotifyPropertyChanged("IsCreditOffset");
            }
        }

        private double mUnitCost;
        public double UnitCost
        {
            get { return mUnitCost; }
            set
            {
                mUnitCost = value;
                NotifyPropertyChanged("UnitCost");
            }
        }

        private double mActualCost;
        public double ActualCost
        {
            get { return mActualCost; }
            set
            {
                mActualCost = value;
                NotifyPropertyChanged("ActualCost");
            }
        }

        private double mBaseCost;
        public double BaseCost
        {
            get { return mBaseCost; }
            set
            {
                mBaseCost = value;
                NotifyPropertyChanged("BaseCost");
            }
        }

        private double mLineCost;
        public double LineCost
        {
            get { return mLineCost; }
            set
            {
                mLineCost = value;
                NotifyPropertyChanged("LineCost");
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

        #region Location
        private Location mLocation = null;
        public Location Location
        {
            get
            {
                if (mLocation == null) mLocation = (Location)BuildProperty(this, "Location");
                return mLocation;
            }
            set
            {
                mLocation = value;
                NotifyPropertyChanged("Location");
            }
        }
        private int? mLocationID;
        public int? LocationID
        {
            get
            {
                if (mLocation != null) return mLocation.LocationID;
                return mLocationID;
            }
            set
            {
                mLocationID = value;
                NotifyPropertyChanged("LocationID");
            }
        }
        #endregion

        private int? mTransactionID;
        public int? TransactionID
        {
            get { return mTransactionID; }
        set{
            mTransactionID = value;
            NotifyPropertyChanged("TransactionID");
        }
        
        }

        private string mSaleLineIsPurged = "N";
        public string SaleLineIsPurged
        {
            get { return mSaleLineIsPurged; }
            set
            {
                mSaleLineIsPurged = value;
                NotifyPropertyChanged("SaleLineIsPurged");
            }
        }

        private string mTransactionIsPurged = "N";
        public string TransactionIsPurged
        {
            get { return mTransactionIsPurged; }
            set
            {
                mTransactionIsPurged = value;
                NotifyPropertyChanged("TransactionIsPurged");
            }
        }

        #region JournalType
        private JournalRecords.JournalType mJournalType = null;
        public JournalRecords.JournalType JournalType
        {
            get
            {
                if (mJournalType == null) mJournalType = (JournalRecords.JournalType)BuildProperty(this, "JournalType");
                return mJournalType;
            }
            set
            {
                mJournalType = value;
                NotifyPropertyChanged("JournalType");
            }
        }
        private string mJournalTypeID;
        public string JournalTypeID
        {
            get
            {
                if (mJournalType != null) return mJournalType.JournalTypeID;
                return mJournalTypeID;
            }
            set
            {
                mJournalTypeID = value;
                NotifyPropertyChanged("JournalTypeID");
            }
        }
        #endregion
    }
}
