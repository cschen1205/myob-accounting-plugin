using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Purchases
{
    public class RecurringProfessionalPurchaseLine : RecurringPurchaseLine
    {
        #region -(Constructor)
        internal RecurringProfessionalPurchaseLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        //protected override RecurringPurchaseLine CreateLine()
        //{
        //    return new RecurringProfessionalPurchaseLine(false, EntityBuilder);
        //}

        #region LineDate
        private DateTime? mLineDate;
        public Nullable<DateTime> LineDate
        {
            get { return mLineDate; }
            set
            {
                mLineDate = value;
                NotifyPropertyChanged("LineDate");
            }
        }
        #endregion

        #region RecurringProfessionalPurchaseLineID
        private int? mRecurringProfessionalPurchaseLineID;
        public int? RecurringProfessionalPurchaseLineID
        {
            get { return mRecurringProfessionalPurchaseLineID; }
            set { mRecurringProfessionalPurchaseLineID = value;
            NotifyPropertyChanged("RecurringProfessionalPurchaseLineID");
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
        public override bool Equals(object obj)
        {
            if (obj is RecurringProfessionalPurchaseLine)
            {
                RecurringProfessionalPurchaseLine _obj = (RecurringProfessionalPurchaseLine)obj;
                return _obj.RecurringProfessionalPurchaseLineID == mRecurringProfessionalPurchaseLineID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format("[Prof]: {0}", base.ToString());
        }
        #endregion

        //#region Entity Override Methods
        //public override void AssignFrom(Entity rhs)
        //{
        //    base.AssignFrom(rhs);
        //    Copy2(rhs);

        //    RecurringProfessionalPurchaseLine _obj = (RecurringProfessionalPurchaseLine)rhs;
        //    RecurringProfessionalPurchaseLineID = _obj.RecurringProfessionalPurchaseLineID;
        //}
        //public override void Copy2(Entity rhs)
        //{
        //    base.Copy2(rhs);
        //    RecurringProfessionalPurchaseLine _obj = (RecurringProfessionalPurchaseLine)rhs;
        //    AccountID = _obj.AccountID;
        //    Account = _obj.Account;
        //    LineDate = _obj.LineDate;
        //}
        //#endregion
    }
}
