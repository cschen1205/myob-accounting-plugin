using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Inventory
{
    public class ItemPrice : Entity
    {
        internal ItemPrice(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mItemPriceID;
        public int? ItemPriceID
        {
            get { return mItemPriceID; }
            set
            {
                mItemPriceID = value;
                NotifyPropertyChanged("ItemPriceID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("ItemPriceID", ItemPriceID);
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

        private int? mQuantityBreak;
        public int? QuantityBreak
        {
            get { return mQuantityBreak; }
            set
            {
                mQuantityBreak = value;
                NotifyPropertyChanged("QuantityBreak");
            }
        }

        private double mQuantityBreakAmount;
        public double QuantityBreakAmount
        {
            get { return mQuantityBreakAmount; }
            set
            {
                mQuantityBreakAmount = value;
                NotifyPropertyChanged("QuantityBreakAmount");
            }
        }

        private string mPriceLevel = "";
        public string PriceLevel
        {
            get { return mPriceLevel; }
            set
            {
                mPriceLevel = value;
                NotifyPropertyChanged("PriceLevel");
            }
        }

        private string mPriceLevelNameID = "";
        public string PriceLevelNameID
        {
            get { return mPriceLevelNameID; }
            set
            {
                mPriceLevelNameID = value;
                NotifyPropertyChanged("PriceLevelNameID");
            }
        }

        private double mSellingPrice;
        public double SellingPrice
        {
            get { return mSellingPrice; }
            set
            {
                mSellingPrice = value;
                NotifyPropertyChanged("SellingPrice");
            }
        }

        private string mPriceIsInclusive="N";
        public string PriceIsInclusive
        {
         get

        {
            return mPriceIsInclusive;
        }
            set
            {
                mPriceIsInclusive = value;
                NotifyPropertyChanged("PriceIsInclusive");
            }
        }

        private int? mChangeControl;
        public int? ChangeControl
        {
            get { return mChangeControl; }
            set
            {
                mChangeControl = value;
                NotifyPropertyChanged("ChangeControl");
            }
        }
    }
}
