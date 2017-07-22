using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Sales
{
    public class ServiceSaleLine : SaleLine
    {
        #region -(Constructor)
        internal ServiceSaleLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        //protected override SaleLine CreateLine()
        //{
        //    return new ServiceSaleLine(false, EntityBuilder);
        //}

        #region ServiceSaleLineID
        private int? mServiceSaleLineID;
        public int? ServiceSaleLineID
        {
            get { return mServiceSaleLineID; }
            set { mServiceSaleLineID = value;
            NotifyPropertyChanged("ServiceSaleLineID");
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
        //    ServiceSaleLine _obj = (ServiceSaleLine)rhs;
        //    ServiceSaleLineID = _obj.ServiceSaleLineID;
        //}
        //public override void Copy2(Entity rhs)
        //{
        //    base.Copy2(rhs);

        //    ServiceSaleLine _obj = (ServiceSaleLine)rhs;
        //    AccountID = _obj.AccountID;
        //    Account = _obj.Account;
        //}
        //#endregion
    }
}
