using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Definitions;

namespace Accounting.Core.Inventory
{
    public class ItemDataFieldEntry : Entity
    {
        internal ItemDataFieldEntry(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

      

        private int? mItemDataFieldEntryID;
        public int? ItemDataFieldEntryID
        {
            get { return mItemDataFieldEntryID; }
            set 
            {
                mItemDataFieldEntryID = value;
                NotifyPropertyChanged("ItemDataFieldEntryID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("ItemDataFieldEntryID", ItemDataFieldEntryID);
            }
        }

        public string FieldName
        {
            get
            {
                if (this.DataField == null) return "";
                return this.DataField.DataFieldName;
            }
        }

        private int? mDataFieldID;
        public int? DataFieldID
        {
            get
            {
                if(mDataField != null)
                {
                    return mDataField.DataFieldID;
                }
                return mDataFieldID;
            }
            set
            {
                mDataFieldID=value;
                NotifyPropertyChanged("DataFieldID");
            }
        }
        private DataField mDataField;
        public DataField DataField
        {
            get
            {
                if (mDataField == null)
                {
                    mDataField = (DataField)BuildProperty(this, "DataField");
                }
                return mDataField;
            }
            set
            {
                mDataField = value;
                NotifyPropertyChanged("DataField");
            }
        }

        private string mItemNumber;
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

        private string mContent;
        public string Content
        {
            get { return mContent; }
            set 
            {
                mContent = value;
                NotifyPropertyChanged("Content");
            }
        }
    }
}
