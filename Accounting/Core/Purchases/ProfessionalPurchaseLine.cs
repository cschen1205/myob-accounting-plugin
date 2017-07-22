using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Purchases
{
    public class ProfessionalPurchaseLine : PurchaseLine
    {
        #region -(Constructor)
        internal ProfessionalPurchaseLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
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
                NotifyPropertyChanged("_LineDate");
            }
        }
        public string _LineDate
        {
            get
            {
                if (mLineDate != null)
                {
                    return mLineDate.Value.ToString("dd/MM/yyyy");
                }
                return "";
            }
        }
        #endregion

        #region ProfessionalPurchaseLineID
        private int? mProfessionalPurchaseLineID;
        public int? ProfessionalPurchaseLineID
        {
            get { return mProfessionalPurchaseLineID; }
            set { mProfessionalPurchaseLineID = value;
            NotifyPropertyChanged("ProfessionalPurchaseLineID");
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
            if (obj is ProfessionalPurchaseLine)
            {
                ProfessionalPurchaseLine _obj = (ProfessionalPurchaseLine)obj;
                return _obj.ProfessionalPurchaseLineID == mProfessionalPurchaseLineID;
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
    }
}
