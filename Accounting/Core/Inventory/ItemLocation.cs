using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Inventory
{
    public class ItemLocation : Entity
    {
        internal ItemLocation(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        #region ItemLocationID
        private int? mItemLocationID;
        public int? ItemLocationID
        {
            get { return mItemLocationID; }
            set
            {
                mItemLocationID = value;
                NotifyPropertyChanged("ItemLocationID");
            }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("ItemLocationID", ItemLocationID);
            }
        }

        #region Item
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
        private Item mItem;
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
        #endregion

        #region Location
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
        private Inventory.Location mLocation = null;
        public Inventory.Location Location
        {
            get
            {
                if (mLocation == null)
                {
                    mLocation = (Inventory.Location)BuildProperty(this, "Location");
                }
                return mLocation;
            }
            set
            {
                mLocation = value;
                NotifyPropertyChanged("Location");
            }
        }
        #endregion

        #region
        private double mQuantityOnHand;
        public double QuantityOnHand
        {
            get { return mQuantityOnHand; }
            set
            {
                mQuantityOnHand = value;
                NotifyPropertyChanged("QuantityOnHand");
            }
        }
        #endregion

        #region SellOnOrder
        private double mSellOnOrder;
        public double SellOnOrder
        {
            get { return mSellOnOrder; }
            set
            {
                mSellOnOrder = value;
                NotifyPropertyChanged("SellOnOrder");
            }
        }
        #endregion

        #region PurchaseOnOrder
        private double mPurchaseOnOrder;
        public double PurchaseOnOrder
        {
            get { return mPurchaseOnOrder; }
            set
            {
                mPurchaseOnOrder = value;
                NotifyPropertyChanged("PurchaseOnOrder");
            }
        }
        #endregion




    }
}
