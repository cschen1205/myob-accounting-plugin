using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Definitions;

namespace Accounting.Core.Inventory
{
    public class ItemAddOn : Entity
    {
        internal ItemAddOn(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

    

        private int? mItemAddOnID;
        public int? ItemAddOnID
        {
            get { return mItemAddOnID; }
            set
            {
                mItemAddOnID = value;
                NotifyPropertyChanged("ItemAddOnID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("ItemAddOnID", ItemAddOnID);
            }
        }

        private DateTime? mExpiryDate;
        public DateTime? ExpiryDate
        {
            get { return mExpiryDate; }
            set
            {
                mExpiryDate = value;
                NotifyPropertyChanged("ExpiryDate");
            }
        }

        private string mBrand = "";
        public string Brand
        {
            get { return mBrand; }
            set
            {
                mBrand = value;
                NotifyPropertyChanged("Brand");
            }
        }

        private string mColor = "";
        public string Color
        {
            get { return mColor; }
            set
            {
                mColor = value;
                NotifyPropertyChanged("Color");
            }
        }

        private string mBatchNumber = "";
        public string BatchNumber
        {
            get { return mBatchNumber; }
            set
            {
                mBatchNumber = value;
                NotifyPropertyChanged("BatchNumber");
            }
        }

        private string mSerialNumber = "";
        public string SerialNumber
        {
            get { return mSerialNumber; }
            set
            {
                mSerialNumber = value;
                NotifyPropertyChanged("SerialNumber");
            }
        }

        #region Gender
        private string mGenderID;
        private Gender mGender;
        public string GenderID
        {
            get
            {
                if (mGender != null)
                {
                    return mGender.GenderID;
                }
                return mGenderID;
            }
            set
            {
                mGenderID = value;
                NotifyPropertyChanged("GenderID");
            }
        }
        public Gender Gender
        {
            get
            {
                if (mGender == null)
                {
                    mGender = (Gender)BuildProperty(this, "Gender");
                }
                return mGender;
            }
            set
            {
                mGender = value;
                NotifyPropertyChanged("Gender");
            }
        }
        #endregion

        #region Item
       
        private Item mItem;
        private string mItemNumber = "";
        public string ItemNumber
        {
            get
            {
                if (mItem != null)
                {
                    return mItem.ItemNumber;
                }
                return mItemNumber;
            }
            set
            {
                mItemNumber = value;
                NotifyPropertyChanged("ItemNumber");
            }
        }
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

        #region ItemSizeID
        private string mItemSizeID;
        private ItemSize mItemSize=null;
        public string ItemSizeID
        {
            get
            {
                if (mItemSize != null)
                {
                    return mItemSize.ItemSizeID;
                }
                return mItemSizeID;
            }
            set
            {
                mItemSizeID = value;
                NotifyPropertyChanged("ItemSizeID");
            }
        }
        public ItemSize ItemSize
        {
            get
            {
                if (mItemSize == null)
                {
                    mItemSize = (ItemSize)BuildProperty(this, "ItemSize");
                }
                return mItemSize;
            }
            set
            {
                mItemSize = value;
                NotifyPropertyChanged("ItemSize");
            }
        }
        #endregion

        #region -(Object Override Methods)
        public override bool Equals(object obj)
        {
            if (obj is ItemAddOn)
            {
                ItemAddOn _obj = obj as ItemAddOn;
                return _obj.ItemAddOnID == ItemAddOnID;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

    }
}
