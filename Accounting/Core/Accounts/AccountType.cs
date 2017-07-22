using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Accounts
{
    public class AccountType : Entity
    {
        #region AccountTypeID
        private string mAccountTypeID;
        public string AccountTypeID
        {
            get { return mAccountTypeID; }
            set 
            { 
                mAccountTypeID = value;
                NotifyPropertyChanged("AccountTypeID");
            }
        }
        #endregion

        public bool IsHeader
        {
            get
            {
                return AccountTypeID == "H";
            }
        }

        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("AccountTypeID", AccountTypeID);
            }
        }

        #region Description
        private string mDescription;
        public string Description
        {
            get { return mDescription; }
            set 
            { 
                mDescription = value;
                NotifyPropertyChanged("Description");
            }
        }
        #endregion

        #region +(Constructor)
        internal AccountType(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

    

        #region -(Object Override Methods)
        public override bool Equals(object obj)
        {
            if (obj is AccountType)
            {
                AccountType _obj = obj as AccountType;
                return _obj.AccountTypeID == mAccountTypeID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Description;
        }
        #endregion
    }
}
