using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Inventory
{
    public class InventoryTransferLine : Entity
    {
        internal InventoryTransferLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mInventoryTransferLineID;
        public int? InventoryTransferLineID
        {
            get { return mInventoryTransferLineID; }
            set
            {
                mInventoryTransferLineID = value;
                NotifyPropertyChanged("InventoryTransferLineID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("InventoryTransferLineID", InventoryTransferLineID);
            }
        }

        #region InventoryTransfer
        private InventoryTransfer mInventoryTransfer=null;
        public InventoryTransfer InventoryTransfer
        {
            get
            {
                if (mInventoryTransfer == null)
                {
                    mInventoryTransfer = (InventoryTransfer)BuildProperty(this, "InventoryTransfer");
                }
                return mInventoryTransfer;
            }
            set
            {
                mInventoryTransfer = value;
                NotifyPropertyChanged("InventoryTransfer");
            }
        }
        private int? mInventoryTransferID;
        public int? InventoryTransferID
        {
            get
            {
                if (mInventoryTransfer != null)
                {
                    return mInventoryTransfer.InventoryTransferID;
                }
                return mInventoryTransferID;
            }
            set
            {
                mInventoryTransferID = value;
                NotifyPropertyChanged("InventoryTransferID");
            }
        }
        #endregion

        private int? mLineNumber;
        public int? LineNumber
        {
            get { return mLineNumber; }
            set
            {
                mLineNumber = value;
                NotifyPropertyChanged("LineNumber");
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

        private double mAmount;
        public double Amount
        {
            get { return mAmount; }
            set
            {
                mAmount = value;
                NotifyPropertyChanged("Amount");
            }
        }

        private string mIsMultipleJob = "N";
        public string IsMultipleJob
        {
            get { return mIsMultipleJob; }
            set
            {
                mIsMultipleJob = value;
                NotifyPropertyChanged("IsMultipleJob");
            }
        }

        #region Job
        private Jobs.Job mJob = null;
        public Jobs.Job Job
        {
            get
            {
                if (mJob == null)
                {
                    mJob = (Jobs.Job)BuildProperty(this, "Job");
                }
                return mJob;
            }
            set
            {
                mJob = value;
                NotifyPropertyChanged("Job");
            }
        }
        private int? mJobID;
        public int? JobID
        {
            get
            {
                if (mJob != null)
                {
                    return mJob.JobID;
                }
                return mJobID;
            }
            set
            {
                mJobID = value;
                NotifyPropertyChanged("JobID");
            }
        }
        #endregion

        #region Location
        private Location mLocation = null;
        public Location Location
        {
            get
            {
                if (mLocation == null)
                {
                    mLocation = (Location)BuildProperty(this, "Location");
                }
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
                if (mLocation != null)
                {
                    return mLocation.LocationID;
                }
                return mLocationID;
            }
            set
            {
                mLocationID = value;
                NotifyPropertyChanged("LocationID");
            }
        }
        #endregion

        public override bool Equals(object obj)
        {
            if (obj is InventoryTransferLine)
            {
                InventoryTransferLine _obj = obj as InventoryTransferLine;
                return _obj.InventoryTransferLineID == InventoryTransferLineID;
            }
            return false;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
