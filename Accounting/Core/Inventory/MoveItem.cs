using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Inventory
{
    public class MoveItem : Entity
    {
        internal MoveItem(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mMoveItemID;
        public int? MoveItemID
        {
            get { return mMoveItemID; }
            set
            {
                mMoveItemID = value;
                NotifyPropertyChanged("MoveItemID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("MoveItemID", MoveItemID);
            }
        }

        private DateTime? mMoveDate;
        public DateTime? MoveDate
        {
            get { return mMoveDate; }
            set
            {
                mMoveDate = value;
                NotifyPropertyChanged("MoveDate");
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

        private string mDescription="";
        public string Description
        {
            get { return mDescription; }
            set
            {
                mDescription = value;
                NotifyPropertyChanged("Description");
            }
        }

        #region AuthUser
        private Security.AuthUser mUser;
        public Security.AuthUser User
        {
            get
            {
                if (mUser == null)
                {
                    mUser = (Security.AuthUser)BuildProperty(this, "User");

                }
                return mUser;
            }
            set
            {
                mUser = value;
                NotifyPropertyChanged("User");
            }
        }
        private int? mUserID;
        public int? UserID
        {
            get
            {
                if (mUser != null)
                {
                    return mUser.UserID;
                }
                return mUserID;
            }
            set
            {
                mUserID = value;
                NotifyPropertyChanged("UserID");
            }
        }
        #endregion


    }
}
