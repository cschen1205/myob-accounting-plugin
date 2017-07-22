using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.TaxCodes;

namespace Accounting.Core.Purchases
{
    public class ItemPurchaseLine : PurchaseLine
    {
        #region -(Constructor)
        internal ItemPurchaseLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        

        #region ItemPurchaseLineID
        private int? mItemPurchaseLineID;
        public int? ItemPurchaseLineID
        {
            get { return mItemPurchaseLineID; }
            set { mItemPurchaseLineID = value; NotifyPropertyChanged("ItemPurchaseLineID");  }
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
            set { mItemID = value; NotifyPropertyChanged("ItemID");  }
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
                NotifyPropertyChanged("ItemNumber");
                NotifyPropertyChanged("ItemName");
            }
        }
        public string ItemNumber
        {
            get
            {
                if (Item != null) return Item.ItemNumber;
                return "";
            }
        }
        public string ItemName
        {
            get
            {
                if (Item != null) return Item.ItemName;
                return "";
            }
        }
        #endregion

        #region Quantity
        private double mQuantity;
        public double Quantity
        {
            get { return mQuantity; }
            set { mQuantity = value; NotifyPropertyChanged("Quantity");  }
        }
        #endregion

        public double _Ordered
        {
            get { return Quantity; }
        }

        public double _Billed
        {
            get { return Quantity; }
        }

        public double _Received
        {
            get { return -Received; }
        }

        #region TaxExclusiveUnitPrice
        private double mTaxExclusiveUnitPrice;
        public double TaxExclusiveUnitPrice
        {
            get { return mTaxExclusiveUnitPrice; }
            set
            {
                if (mTaxExclusiveUnitPrice != value)
                {
                    mTaxExclusiveUnitPrice = value;
                    NotifyPropertyChanged("TaxExclusiveUnitPrice");
                }
            }
        }
        #endregion

        public string _Price
        {
            get
            {
                return this.Purchase.Currency.Format(Price);
            }
        }

        #region TaxInclusiveUnitPrice
        private double mTaxInclusiveUnitPrice;
        public double TaxInclusiveUnitPrice
        {
            get { return mTaxInclusiveUnitPrice; }
            set 
            {
                if (mTaxInclusiveUnitPrice != value)
                {
                    mTaxInclusiveUnitPrice = value;
                    NotifyPropertyChanged("TaxInclusiveUnitPrice");
                }
            }
        }
        #endregion

        #region TaxExclusiveTotal
        private double mTaxExclusiveTotal;
        public double TaxExclusiveTotal
        {
            get { return mTaxExclusiveTotal; }
            set 
            {
                if (mTaxExclusiveTotal != value)
                {
                    mTaxExclusiveTotal = value;
                    NotifyPropertyChanged("TaxExclusiveTotal");

                    TaxExclusiveAmount = value;
                }
            }
        }
        #endregion

        #region TaxInclusiveTotal
        private double mTaxInclusiveTotal;
        public double TaxInclusiveTotal
        {
            get { return mTaxInclusiveTotal; }
            set
            {
                if (mTaxInclusiveTotal != value)
                {
                    mTaxInclusiveTotal = value;
                    NotifyPropertyChanged("TaxInclusiveTotal");

                    TaxInclusiveAmount = value;
                }
            }
        }
        #endregion

        #region Discount
        private double mDiscount;
        public double Discount
        {
            get { return mDiscount; }
            set 
            {
                if (mDiscount != value)
                {
                    mDiscount = value;
                    NotifyPropertyChanged("Discount");
                }
            }
        }
        #endregion

        #region Received
        private double mReceived;
        public double Received
        {
            get { return mReceived; }
            set { mReceived = value; NotifyPropertyChanged("Received");  }
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
            set { mLocationID = value; NotifyPropertyChanged("LocationID");  }
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
            if (obj is ItemPurchaseLine)
            {
                ItemPurchaseLine _obj = (ItemPurchaseLine)obj;
                return _obj.ItemPurchaseLineID == mItemPurchaseLineID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        public double Price
        {
            get 
            {
                if (TaxBasisAmountIsInclusive == "Y")
                {
                    return TaxInclusiveUnitPrice;
                }
                else
                {
                    return TaxExclusiveUnitPrice;
                }
            }
        }

        

        public override void Evaluate()
        {
            TaxInclusiveAmount = TaxInclusiveTotal = TaxInclusiveUnitPrice * Quantity;
            TaxExclusiveAmount = TaxExclusiveTotal = TaxExclusiveUnitPrice * Quantity;

            if (TaxBasisAmountIsInclusive == "Y")
            {
                TaxBasisAmount = TaxInclusiveAmount;
                
            }
            else
            {
                TaxBasisAmount = TaxExclusiveAmount;
            }

            NotifyPropertyChanged("Price");
            NotifyPropertyChanged("_Price");
            NotifyPropertyChanged("_Total");
        }
    }
}
