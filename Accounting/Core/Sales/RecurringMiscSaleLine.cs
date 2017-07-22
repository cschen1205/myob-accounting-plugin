using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Sales
{
    public class RecurringMiscSaleLine : RecurringSaleLine
    {
        #region -(Constructor)
        internal RecurringMiscSaleLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        //protected override RecurringSaleLine CreateLine()
        //{
        //    return new RecurringMiscSaleLine(false, EntityBuilder);
        //}

        #region RecurringMiscSaleLineID
        private int? mRecurringMiscSaleLineID;
        public int? RecurringMiscSaleLineID
        {
            get { return mRecurringMiscSaleLineID; }
            set 
            {
                mRecurringMiscSaleLineID = value;
                NotifyPropertyChanged("RecurringMiscSaleLineID");
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

        //#region Entity Override Methods
        //public override void AssignFrom(Entity rhs)
        //{
        //    base.AssignFrom(rhs);
        //    RecurringMiscSaleLine _obj = (RecurringMiscSaleLine)rhs;
        //    RecurringMiscSaleLineID = _obj.RecurringMiscSaleLineID;
        //}
        //public override void Copy2(Entity rhs)
        //{
        //    base.Copy2(rhs);
        //    RecurringMiscSaleLine _obj = (RecurringMiscSaleLine)rhs;
        //    AccountID = _obj.AccountID;
        //    Account = _obj.Account;
        //}
        //#endregion
    }
}
