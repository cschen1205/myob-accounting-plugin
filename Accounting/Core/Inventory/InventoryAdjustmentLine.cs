using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Inventory
{
    public class InventoryAdjustmentLine : Entity
    {
        internal InventoryAdjustmentLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        private int? mInventoryAdjustmentLineID;
        public int? InventoryAdjustmentLineID
        {
            get { return mInventoryAdjustmentLineID; }
            set
            {
                mInventoryAdjustmentLineID = value;
                NotifyPropertyChanged("InventoryAdjustmentLineID");
            }
        }

        public string AccountNumber
        {
            get
            {
                if (Account != null)
                {
                    return Account.AccountNumber;
                }
                return "";
            }
        }

        public string JobNumber
        {
            get
            {
                if (Job != null)
                {
                    return Job.JobNumber;
                }
                return "";
            }
        }

        private string mMemo = "";
        public string Memo
        {
            get { return mMemo; }
            set
            {
                if (mMemo != value)
                {
                    mMemo = value;
                    NotifyPropertyChanged("Memo");
                }
            }
        }

        public string ItemName
        {
            get
            {
                if (Item != null)
                {
                    return Item.ItemName;
                }
                return "";
            }
        }

        public string _Amount
        {
            get
            {
                if (Account != null)
                {
                    return Account.Currency.Format(Amount);
                }
                return RepositoryMgr.CurrencyMgr.Format(Amount);
            }
        }

        public string _UnitCost
        {
            get
            {
                if (Account != null)
                {
                    return Account.Currency.Format(UnitCost);
                }
                return RepositoryMgr.CurrencyMgr.Format(UnitCost);
            }
        }

        public string ItemNumber
        {
            get
            {
                if (Item != null)
                {
                    return Item.ItemNumber;
                }
                return "";
            }
        }

        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("InventoryAdjustmentLineID", InventoryAdjustmentLineID);
            }
        }

        #region InventoryAdjustment
        private InventoryAdjustment mInventoryAdjustment = null;
        public InventoryAdjustment InventoryAdjustment
        {
            get
            {
                if (mInventoryAdjustment == null)
                {
                    mInventoryAdjustment = (InventoryAdjustment)BuildProperty(this, "InventoryAdjustment");
                }
                return mInventoryAdjustment;
            }
            set
            {
                mInventoryAdjustment = value;
                NotifyPropertyChanged("InventoryAdjustment");
            }
        }
        private int? mInventoryAdjustmentID;
        public int? InventoryAdjustmentID
        {
            get
            {
                if (mInventoryAdjustment != null)
                {
                    return mInventoryAdjustment.InventoryAdjustmentID;
                }
                return mInventoryAdjustmentID;
            }
            set
            {
                mInventoryAdjustmentID = value;
                NotifyPropertyChanged("InventoryAdjustmentID");
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
                NotifyPropertyChanged("ItemNumber");
                NotifyPropertyChanged("ItemName");
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
                NotifyPropertyChanged("_UnitCost");
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
                NotifyPropertyChanged("_Amount");
            }
        }

        #region Account
        private Accounts.Account mAccount=null;
        public Accounts.Account Account
        {
            get
            {
                if(mAccount==null)
                {
                    mAccount=(Accounts.Account)BuildProperty(this, "Account");
                }
                return mAccount;
            }
            set
            {
                if (mAccount != value)
                {
                    mAccount = value;
                    NotifyPropertyChanged("Account");
                    NotifyPropertyChanged("AccountNumber");
                }
            }
        }
        private int? mAccountID;
        public int? AccountID
        {
            get
            {
                if (mAccount != null)
                {
                    return mAccount.AccountID;
                }
                return mAccountID;
            }
            set
            {
                mAccountID = value;
                NotifyPropertyChanged("AccountID");
            }
        }
        #endregion

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

        private string mIsCOGSAdjustment = "N";
        public string IsCOGSAdjustment
        {
            get { return mIsCOGSAdjustment; }
            set
            {
                mIsCOGSAdjustment=value;
                NotifyPropertyChanged("IsCOGSAdjustment");
            }
        }

        #region Sale
        private Sales.Sale mSale = null;
        public Sales.Sale Sale
        {
            get
            {
                if (mSale == null)
                {
                    mSale = (Sales.Sale)BuildProperty(this, "Sale");
                }
                return mSale;
            }
            set
            {
                mSale = value;
                NotifyPropertyChanged("Sale");
            }
        }
        private int? mSaleID;
        public int? SaleID
        {
            get
            {
                if (mSale != null)
                {
                    return mSale.SaleID;
                }
                return mSaleID;
            }
            set
            {
                mSaleID=value;
                NotifyPropertyChanged("SaleID");
            }
        }
        #endregion

        #region SaleLine
        private Sales.SaleLine mSaleLine = null;
        public Sales.SaleLine SaleLine
        {
            get
            {
                if (mSaleLine == null)
                {
                    mSaleLine = (Sales.SaleLine)BuildProperty(this, "SaleLine");
                }
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
                if (mSaleLine != null)
                {
                    return mSaleLine.SaleLineID;
                }
                return mSaleLineID;
            }
            set
            {
                mSaleLineID = value;
                NotifyPropertyChanged("SaleLineID");
            }
        }
        #endregion

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
                NotifyPropertyChanged("JobNumber");
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

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            if(obj is InventoryAdjustmentLine)
            {
                InventoryAdjustmentLine _obj = obj as InventoryAdjustmentLine;
                return _obj.InventoryAdjustmentLineID == InventoryAdjustmentLineID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void Evaluate()
        {
            Amount = UnitCost * Quantity;
        }

    }
}
