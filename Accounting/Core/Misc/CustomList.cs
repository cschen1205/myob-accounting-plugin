using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Misc
{
    public class CustomList : Entity
    {
        #region +(Constructor)
        internal CustomList(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {

        }
        #endregion


        #region CustomListID
        private int? mCustomListID;
        public int? CustomListID
        {
            get { return mCustomListID; }
            set 
            {
                mCustomListID = value;
                NotifyPropertyChanged("CustomListID");
            }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("CustomListID", CustomListID);
            }
        }

        #region CustomListText
        private string mCustomListText="";
        public string CustomListText
        {
            get { return mCustomListText; }
            set 
            {
                mCustomListText = value;
                NotifyPropertyChanged("CustomListText");
            }
        }
        #endregion

        #region CustomListName
        private string mCustomListName = "";
        public string CustomListName
        {
            get { return mCustomListName; }
            set 
            {
                mCustomListName = value;
                NotifyPropertyChanged("CustomListName");
            }
        }
        #endregion

        #region CustomListNumber
        private int? mCustomListNumber = null;
        public int? CustomListNumber
        {
            get { return mCustomListNumber; }
            set 
            {
                mCustomListNumber = value;
                NotifyPropertyChanged("CustomListNumber");
            }
        }
        #endregion

        #region ChangeControl
        private string mChangeControl = "";
        public string ChangeControl
        {
            get { return mChangeControl; }
            set 
            {
                mChangeControl = value;
                NotifyPropertyChanged("ChangeControl");
            }
        }
        #endregion

        #region CustomListType
        private string mCustomListType = "";
        public string CustomListType
        {
            get { return mCustomListType; }
            set 
            {
                mCustomListType = value;
                NotifyPropertyChanged("CustomListType");
            }
        }
        #endregion


        #region -(Object Override Methods)
        public override string ToString()
        {
            return mCustomListText;
        }

        public override bool Equals(object obj)
        {
            if (obj is CustomList)
            {
                CustomList _obj = (CustomList)obj;
                return _obj.CustomListID == mCustomListID; 
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
