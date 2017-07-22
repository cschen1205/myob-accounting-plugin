using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Sales
{
    public class MiscSaleLine : SaleLine
    {
        #region -(Constructor)
        internal MiscSaleLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        //protected override SaleLine CreateLine()
        //{
        //    return new MiscSaleLine(false, EntityBuilder);
        //}

        #region MiscSaleLineID
        private int? mMiscSaleLineID;
        public int? MiscSaleLineID
        {
            get { return mMiscSaleLineID; }
            set { mMiscSaleLineID = value;
            NotifyPropertyChanged("MiscSaleLineID");
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

        //#region Entity Override Methods
        //public override void AssignFrom(Entity rhs)
        //{
        //    base.AssignFrom(rhs);
        //    MiscSaleLine _obj = (MiscSaleLine)rhs;
        //    MiscSaleLineID = _obj.MiscSaleLineID;
        //}
        //public override void Copy2(Entity rhs)
        //{
        //    base.Copy2(rhs);
        //    MiscSaleLine _obj = (MiscSaleLine)rhs;
        //    AccountID = _obj.AccountID;
        //    Account = _obj.Account;
        //}
        //#endregion
    }
}
