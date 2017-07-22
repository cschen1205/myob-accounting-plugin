using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Inventory
{
    public class BuiltItem : Entity
    {
        internal BuiltItem(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mBuiltItemID;
        public int? BuiltItemID
        {
            get { return mBuiltItemID; }
            set
            {
                mBuiltItemID = value;
                NotifyPropertyChanged("BuiltItemID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("BuiltItemID", BuiltItemID);
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

        private double mQuantityBuilt;
        public double QuantityBuilt
        {
            get { return mQuantityBuilt; }
            set
            {
                mQuantityBuilt = value;
                NotifyPropertyChanged("QuantityBuilt");
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is BuiltItem)
            {
                BuiltItem _obj = obj as BuiltItem;
                return _obj.BuiltItemID == BuiltItemID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
