using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Accounts
{
    public class AccountClassification : Entity
    {
        #region AccountClassificaiton.AccountClassificationID
        private string mAccountClassificationID;
        public string AccountClassificationID
        {
            get { return mAccountClassificationID; }
            set 
            { 
                mAccountClassificationID = value;
                NotifyPropertyChanged("AccountClassificationID");
            }
        }
        #endregion

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


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("AccountClassificationID", AccountClassificationID);
            }
        }

        #region +(Constructor)
        internal AccountClassification(bool fromDb, EntityBuilder eb)
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
            if (obj is AccountClassification)
            {
                AccountClassification _obj = (AccountClassification)obj;
                return _obj.AccountClassificationID == mAccountClassificationID;
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
