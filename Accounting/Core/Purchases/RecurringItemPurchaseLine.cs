using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.TaxCodes;

namespace Accounting.Core.Purchases
{
    public class RecurringItemPurchaseLine : RecurringPurchaseLine
    {
        #region -(Constructor)
        internal RecurringItemPurchaseLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        //protected override RecurringPurchaseLine CreateLine()
        //{
        //    return new RecurringItemPurchaseLine(false, EntityBuilder);
        //}

        #region RecurringItemPurchaseLineID
        private int? mRecurringItemPurchaseLineID;
        public int? RecurringItemPurchaseLineID
        {
            get { return mRecurringItemPurchaseLineID; }
            set { mRecurringItemPurchaseLineID = value;
            NotifyPropertyChanged("RecurringItemPurchaseLineID");
            }
        }
        #endregion

        #region Item
        private int? mItemID;
        public int? ItemID
        {
            get {
                if (mItem != null)
                {
                    return mItem.ItemID;
                }
                return mItemID; }
            set { mItemID = value;
            NotifyPropertyChanged("ItemID");
            }
        }
        private Inventory.Item mItem;
        public Inventory.Item Item
        {
            get
            {
                if (mItem == null)
                {
                    mItem = (Inventory.Item)BuildProperty(this, "Item");
                }
                return mItem;
            }
            set
            {
                mItem = value;
                NotifyPropertyChanged("Item");
            }
        }
        #endregion

        #region Quantity
        private double mQuantity;
        public double Quantity
        {
            get { return mQuantity; }
            set { mQuantity = value;
            NotifyPropertyChanged("Quantity");
            }
        }
        #endregion

        #region TaxExclusiveUnitPrice
        private double mTaxExclusiveUnitPrice;
        public double TaxExclusiveUnitPrice
        {
            get { return mTaxExclusiveUnitPrice; }
            set { mTaxExclusiveUnitPrice=value;
            NotifyPropertyChanged("TaxExclusiveUnitPrice");
            }
        }
        #endregion

        #region TaxInclusiveUnitPrice
        private double mTaxInclusiveUnitPrice;
        public double TaxInclusiveUnitPrice
        {
            get { return mTaxInclusiveUnitPrice; }
            set { mTaxInclusiveUnitPrice=value;
            NotifyPropertyChanged("TaxInclusiveUnitPrice");
            }
        }
        #endregion

        #region TaxExclusiveTotal
        private double mTaxExclusiveTotal;
        public double TaxExclusiveTotal
        {
            get { return mTaxExclusiveTotal; }
            set { mTaxExclusiveTotal=value;
            NotifyPropertyChanged("TaxExclusiveTotal");
            }
        }
        #endregion

        #region TaxInclusiveTotal
        private double mTaxInclusiveTotal;
        public double TaxInclusiveTotal
        {
            get { return mTaxInclusiveTotal; }
            set { mTaxInclusiveTotal=value;
            NotifyPropertyChanged("TaxInclusiveTotal");
            }
        }
        #endregion

        #region Discount
        private double mDiscount;
        public double Discount
        {
            get { return mDiscount; }
            set { mDiscount = value;
            NotifyPropertyChanged("Discount");
            }
        }
        #endregion

        #region Location
        private int? mLocationID;
        public int? LocationID
        {
            get {
                if (mLocation != null)
                {
                    return mLocation.LocationID;
                }
                return mLocationID; }
            set { mLocationID=value;
            NotifyPropertyChanged("LocationID");
            }
        }

        private Inventory.Location mLocation;
        public Inventory.Location Location
        {
            get { return mLocation; }
            set 
            { 
                mLocation=value;
                NotifyPropertyChanged("Location");
            }
        }
        #endregion

        #region -(Object Override Methods)
        public override string ToString()
        {
            return string.Format("[Item]: {0}", base.ToString());
        }

        public override bool Equals(object obj)
        {
            if (obj is RecurringItemPurchaseLine)
            {
                RecurringItemPurchaseLine _obj = (RecurringItemPurchaseLine)obj;
                return _obj.RecurringItemPurchaseLineID == mRecurringItemPurchaseLineID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        //#region Entity Override Methods
        //public override void AssignFrom(Entity rhs)
        //{
        //    base.AssignFrom(rhs);
        //    Copy2(rhs);

        //    RecurringItemPurchaseLine _obj = (RecurringItemPurchaseLine)rhs;
        //    RecurringItemPurchaseLineID = _obj.RecurringItemPurchaseLineID;
        //}
        //public override void Copy2(Entity rhs)
        //{
        //    base.Copy2(rhs);

        //    RecurringItemPurchaseLine _obj = (RecurringItemPurchaseLine)rhs;
        //    ItemID = _obj.ItemID;
        //    Item = _obj.Item;
        //    Quantity = _obj.Quantity;
        //    TaxExclusiveUnitPrice = _obj.TaxExclusiveUnitPrice;
        //    TaxInclusiveUnitPrice = _obj.TaxInclusiveUnitPrice;
        //    TaxInclusiveTotal = _obj.TaxInclusiveTotal;
        //    TaxInclusiveTotal = _obj.TaxInclusiveTotal;
        //    Discount = _obj.Discount;
        //}
        //#endregion
    }
}
