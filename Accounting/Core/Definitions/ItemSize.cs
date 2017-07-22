using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class ItemSize : Entity
    {
        internal ItemSize(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        //public override void Copy2(Entity rhs)
        //{
        //    base.Copy2(rhs);
        //    ItemSize _rhs=rhs as ItemSize;
        //    mItemSizeID = _rhs.ItemSizeID;
        //    mDescription = _rhs.Description;
        //}

        private string mItemSizeID = "";
        public string ItemSizeID
        {
            get { return mItemSizeID; }
            set
            {
                mItemSizeID = value;
                NotifyPropertyChanged("ItemSizeID");
            }
        }


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("ItemSizeID", ItemSizeID);
            }
        }

        private string mDescription = "";
        public string Description
        {
            get { return mDescription; }
            set
            {
                mDescription = value;
                NotifyPropertyChanged("Description");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is ItemSize)
            {
                ItemSize _obj = (ItemSize)obj;
                if (string.IsNullOrEmpty(ItemSizeID))
                {
                    return false;
                }
                return ItemSizeID.Equals(_obj.ItemSizeID);
            }
            return false;
        }

        public override string ToString()
        {
            return Description;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
