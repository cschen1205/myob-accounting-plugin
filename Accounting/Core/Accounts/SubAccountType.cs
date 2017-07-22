using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Accounts
{
    public class SubAccountType : Entity
    {
        #region SubAccountTypeID
        private string mSubAccountTypeID;
        public string SubAccountTypeID
        {
            get { return mSubAccountTypeID; }
            set 
            { 
                mSubAccountTypeID = value;
                NotifyPropertyChanged("SubAccountTypeID");
            }
        }
        #endregion


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("SubAccountTypeID", SubAccountTypeID);
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

        #region  [Constructor]
        internal SubAccountType(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

 

        #region -(Object Override Methods)
        public override string ToString()
        {
            return mDescription;
        }

        public override bool Equals(object obj)
        {
            if (obj is SubAccountType)
            {
                SubAccountType _obj = (SubAccountType)obj;
                return _obj.SubAccountTypeID == mSubAccountTypeID;
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
