using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Sales
{
    public class ProfessionalSaleLine : SaleLine
    {
        #region -(Constructor)
        internal ProfessionalSaleLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        //protected override SaleLine CreateLine()
        //{
        //    return new ProfessionalSaleLine(false, EntityBuilder);
        //}

        #region ProfessionalSaleLineID
        private int? mProfessionalSaleLineID;
        public int? ProfessionalSaleLineID
        {
            get { return mProfessionalSaleLineID; }
            set { mProfessionalSaleLineID = value;
            NotifyPropertyChanged("ProfessionalSaleLineID");
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

        #region LineDate
        private DateTime? mLineDate;
        public Nullable<DateTime> LineDate
        {
            get
            {
                return mLineDate;
            }
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
        //    ProfessionalSaleLine _obj = (ProfessionalSaleLine)rhs;
        //    ProfessionalSaleLineID = _obj.ProfessionalSaleLineID;
        //}
        //public override void Copy2(Entity rhs)
        //{
        //    base.Copy2(rhs);
        //    ProfessionalSaleLine _obj = (ProfessionalSaleLine)rhs;
        //    AccountID = _obj.AccountID;
        //    Account = _obj.Account;
        //    LineDate = _obj.LineDate;
        //}
        //#endregion
    }
}
