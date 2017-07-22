using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Purchases
{
    public class RecurringMiscPurchaseLine : RecurringPurchaseLine
    {
        #region -(Constructor)
        internal RecurringMiscPurchaseLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        //protected override RecurringPurchaseLine CreateLine()
        //{
        //    return new RecurringMiscPurchaseLine(false, EntityBuilder);
        //}
        

        #region RecurringMiscPurchaseLineID
        private int? mRecurringMiscPurchaseLineID;
        public int? RecurringMiscPurchaseLineID
        {
            get { return mRecurringMiscPurchaseLineID; }
            set { mRecurringMiscPurchaseLineID = value; 
                NotifyPropertyChanged("RecurringMiscPurchaseLineID");
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
                return mAccountID; }
            set { mAccountID = value;
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
        public override string ToString()
        {
            return string.Format("[Misc]: {0}", base.ToString());
        }

        public override bool Equals(object obj)
        {
            if (obj is RecurringMiscPurchaseLine)
            {
                RecurringMiscPurchaseLine _obj = (RecurringMiscPurchaseLine)obj;
                return _obj.RecurringMiscPurchaseLineID == mRecurringMiscPurchaseLineID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        //#region Entity Override Methods
        //public override void AssignFrom(Entity rhs)
        //{
        //    base.AssignFrom(rhs);
        //    Copy2(rhs);

        //    RecurringMiscPurchaseLine _obj = (RecurringMiscPurchaseLine)rhs;
        //    RecurringMiscPurchaseLineID = _obj.RecurringMiscPurchaseLineID;
        //}
        //public override void Copy2(Entity rhs)
        //{
        //    base.Copy2(rhs);

        //    RecurringMiscPurchaseLine _obj = (RecurringMiscPurchaseLine)rhs;
        //    AccountID = _obj.AccountID;
        //    Account = _obj.Account;
        //}
        //#endregion
    }
}
