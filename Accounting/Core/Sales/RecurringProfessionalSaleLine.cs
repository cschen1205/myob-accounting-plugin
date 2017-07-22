using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Sales
{
    public class RecurringProfessionalSaleLine : RecurringSaleLine
    {
        #region -(Constructor)
        internal RecurringProfessionalSaleLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        //protected override RecurringSaleLine CreateLine()
        //{
        //    return new RecurringProfessionalSaleLine(false, EntityBuilder);
        //}

        #region RecurringProfessionalSaleLineID
        private int? mRecurringProfessionalSaleLineID;
        public int? RecurringProfessionalSaleLineID
        {
            get { return mRecurringProfessionalSaleLineID; }
            set 
            {
                mRecurringProfessionalSaleLineID = value;
                NotifyPropertyChanged("RecurringProfessionalSaleLineID");
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

        //#region Entity Override Methods
        //public override void AssignFrom(Entity rhs)
        //{
        //    base.AssignFrom(rhs);
        //    RecurringProfessionalSaleLine _obj = (RecurringProfessionalSaleLine)rhs;
        //    RecurringProfessionalSaleLineID = _obj.RecurringProfessionalSaleLineID;
        //}
        //public override void Copy2(Entity rhs)
        //{
        //    base.Copy2(rhs);
        //    RecurringProfessionalSaleLine _obj = (RecurringProfessionalSaleLine)rhs;
        //    AccountID = _obj.AccountID;
        //    Account = _obj.Account;
        //    LineDate = _obj.LineDate;
        //}
        //#endregion
    }
}
