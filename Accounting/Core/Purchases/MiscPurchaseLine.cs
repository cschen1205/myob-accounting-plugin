using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Purchases
{
    public class MiscPurchaseLine : PurchaseLine
    {
        #region -(Constructor)
        internal MiscPurchaseLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        

        #region MiscPurchaseLineID
        private int? mMiscPurchaseLineID;
        public int? MiscPurchaseLineID
        {
            get { return mMiscPurchaseLineID; }
            set { mMiscPurchaseLineID = value; NotifyPropertyChanged("MiscPurchaseLineID");  }
        }
        #endregion

        #region Account
        private int? mAccountID;
        public int? AccountID
        {
            get {
                if (mAccount != null)
                {
                    return mAccount.AccountID;
                }
                return mAccountID; }
            set { mAccountID = value; NotifyPropertyChanged("AccountID");  }
        }

        private Accounts.Account mAccount;
        public Accounts.Account Account
        {
            get 
            {
                if (mAccount == null)
                {
                    mAccount = (Accounts.Account)BuildProperty(this, "Account");
                }
                return mAccount; 
            }
            set 
            { 
                mAccount = value;
                NotifyPropertyChanged("Account");
                NotifyPropertyChanged("AccountNumber");
            }
        }

        public string AccountNumber
        {
            get
            {
                if (Account != null)
                {
                    return Account.AccountNumber;
                }
                return "";
            }
        }
        #endregion

        #region -(Object Override Methods)
        public override string ToString()
        {
            return string.Format("[Misc]: {0}", base.ToString());
        }

        public override bool Equals(object obj)
        {
            if (obj is MiscPurchaseLine)
            {
                MiscPurchaseLine _obj = (MiscPurchaseLine)obj;
                return _obj.MiscPurchaseLineID == mMiscPurchaseLineID;
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
