using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Purchases
{
    public class RecurringServicePurchaseLine : RecurringPurchaseLine
    {
        #region -(Constructor)
        internal RecurringServicePurchaseLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        //protected override RecurringPurchaseLine CreateLine()
        //{
        //    return new RecurringServicePurchaseLine(false, EntityBuilder);
        //}

        #region RecurringServicePurchaseLineID
        private int? mRecurringServicePurchaseLineID;
        public int? RecurringServicePurchaseLineID
        {
            get { return mRecurringServicePurchaseLineID; }
            set 
            {
                mRecurringServicePurchaseLineID = value;
                NotifyPropertyChanged("RecurringServicePurchaseLineID");
            }
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
                return mAccountID; 
            }
            set 
            {
                mAccountID = value;
                NotifyPropertyChanged("AccountID");
            }
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
            }
        }
        #endregion

        #region -(Object Override Methods)
        public override bool Equals(object obj)
        {
            if (obj is RecurringServicePurchaseLine)
            {
                RecurringServicePurchaseLine _obj = (RecurringServicePurchaseLine)obj;
                return _obj.RecurringServicePurchaseLineID == mRecurringServicePurchaseLineID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("[Serv]: {0}", base.ToString());
        }
        #endregion

        //#region Entity Override Methods
        //public override void AssignFrom(Entity rhs)
        //{
        //    base.AssignFrom(rhs);
        //    RecurringServicePurchaseLine _obj = (RecurringServicePurchaseLine)rhs;
        //    RecurringServicePurchaseLineID = _obj.RecurringServicePurchaseLineID;
        //    AccountID = _obj.AccountID;
        //    Account = _obj.Account;
        //}
        //#endregion
    }
}
