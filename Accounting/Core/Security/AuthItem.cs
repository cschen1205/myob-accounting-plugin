using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Security
{
    public class AuthItem : Entity
    {
        internal AuthItem(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {

        }

        public enum AuthItemType
        {
            Root,
            Category,
            Property,
            Attribute
        }

        private AuthItemType mAuthItemType = AuthItemType.Root;
        public AuthItemType Type
        {
            get { return mAuthItemType; }
            set { mAuthItemType = value; }
        }

        private object mTag=null;
        public object Tag
        {
            get { return mTag; }
            set 
            {
                mTag = value;
                NotifyPropertyChanged("Tag");
            }
        }

        public override string ToString()
        {
            return ItemName;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is AuthItem)
            {
                AuthItem _obj = obj as AuthItem;
                if (_obj.ItemName.Equals(ItemName))
                {
                    return true;
                }
            }
            return false;
        }

        private string mItemName = "";
        public string ItemName
        {
            get
            {
                 if (mTag != null && mGetItemNameHandler != null) 
                {
                    string text=mGetItemNameHandler(mTag);
                    return text;
                }
                return mItemName; 
            }
            set
            {
                mItemName = value;
                NotifyPropertyChanged("ItemName");
            }
        }

        public delegate string GetItemNameHandler(object tag);
        private GetItemNameHandler mGetItemNameHandler = null;
        public GetItemNameHandler GetItemNameFunc
        {
            set { mGetItemNameHandler = value; }
        }

        private string mDisplayName = "";
        public string DisplayName
        {
            get
            {
                if (mTag != null && mGetItemNameHandler != null) 
                {
                    string text=mGetItemNameHandler(mTag);
                    return text;
                }
                return mDisplayName;
            }
            set
            {
                mDisplayName = value;
                NotifyPropertyChanged("DisplayName");
            }
        }

        private string mDescription = "";
        public string Description
        {
            get
            {
                if (mTag != null && mGetItemNameHandler != null) 
                {
                    string text=mGetItemNameHandler(mTag);
                    return text;
                }
                return mDescription;
            }
            set
            {
                mDescription = value;
                NotifyPropertyChanged("Description");
            }
        }

        

        private int? mItemID;
        public int? ItemID
        {
            get { return mItemID; }
            set 
            {
                mItemID = value;
                NotifyPropertyChanged("ItemID");
            }
        }


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("ItemName", ItemName);
            }
        }

        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("ItemID", ItemID);
            }
        }

        private int? mParentItemID;
        public int? ParentItemID
        {
            get
            {
                if (mParentItem != null)
                {
                    return mParentItem.ItemID;
                }
                else
                {
                    return mParentItemID;
                }
            }
            set
            {
                mParentItemID = value;
                NotifyPropertyChanged("ParentItemID");
            }
        }

        private AuthItem mParentItem=null;
        public AuthItem ParentItem
        {
            get
            {
                if (mParentItem == null)
                {
                    mParentItem = (AuthItem)BuildProperty(this, "ParentItem");
                }
                return mParentItem;
            }
            set
            {
                mParentItem = value;
                NotifyPropertyChanged("ParentItem");
            }
        }

        public List<AuthItem> mChildren = null;
        public List<AuthItem> Children
        {
            get
            {
                if (mChildren == null)
                {
                    if (FromDb)
                    {
                        mChildren = (List<AuthItem>)BuildProperty(this, "Children");
                    }
                    else
                    {
                        mChildren = new List<AuthItem>();
                    }
                }
                return mChildren;
            }
        }
    }
}
