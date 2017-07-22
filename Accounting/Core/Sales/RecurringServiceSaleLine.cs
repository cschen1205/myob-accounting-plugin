using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Sales
{
    public class RecurringServiceSaleLine : RecurringSaleLine
    {
        #region -(Constructor)
        internal RecurringServiceSaleLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        //protected override RecurringSaleLine CreateLine()
        //{
        //    return new RecurringServiceSaleLine(false, EntityBuilder);
        //}
        

        #region RecurringServiceSaleLineID
        private int? mRecurringServiceSaleLineID;
        public int? RecurringServiceSaleLineID
        {
            get { return mRecurringServiceSaleLineID; }
            set { mRecurringServiceSaleLineID = value;
            NotifyPropertyChanged("RecurringServiceSaleLineID");
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
            set { mAccountID = value; }
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
        //    RecurringServiceSaleLine _obj = (RecurringServiceSaleLine)rhs;
        //    RecurringServiceSaleLineID = _obj.RecurringServiceSaleLineID;
        //}
        //public override void Copy2(Entity rhs)
        //{
        //    base.Copy2(rhs);

        //    RecurringServiceSaleLine _obj = (RecurringServiceSaleLine)rhs;
        //    AccountID = _obj.AccountID;
        //    Account = _obj.Account;
        //}
        //#endregion
    }
}
