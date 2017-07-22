using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Purchases
{
    public class ServicePurchaseLine : PurchaseLine
    {
        #region -(Constructor)
        internal ServicePurchaseLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        

        #region ServicePurchaseLineID
        private int? mServicePurchaseLineID;
        public int? ServicePurchaseLineID
        {
            get { return mServicePurchaseLineID; }
            set 
            {
                mServicePurchaseLineID = value;
                NotifyPropertyChanged("ServicePurchaseLineID");
            }
        }
        #endregion

        //protected override PurchaseLine CreateLine()
        //{
        //    return new ServicePurchaseLine(false, EntityBuilder);
        //}

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
        public override bool Equals(object obj)
        {
            if (obj is ServicePurchaseLine)
            {
                ServicePurchaseLine _obj = (ServicePurchaseLine)obj;
                return _obj.ServicePurchaseLineID == mServicePurchaseLineID;
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

        #region Entity Override Methods
        public override void AssignFrom(Entity rhs)
        {
            base.AssignFrom(rhs);
            ServicePurchaseLine _obj = (ServicePurchaseLine)rhs;
            ServicePurchaseLineID = _obj.ServicePurchaseLineID;
            AccountID = _obj.AccountID;
            Account = _obj.Account;
        }
        #endregion
    }
}
