using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Accounts
{
    public class AccountActivity : Entity
    {
        internal AccountActivity(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
            
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("AccountActivityID", AccountActivityID);
            }
        }

        public bool Match(int? _AccountID, int? _year, int? _period)
        {
            if (_AccountID != null && AccountID != _AccountID) return false;
            if (_year != null && FinancialYear.Value != _year) return false;
            if (_period != null && Period.Value != _period) return false;
            return true;
        }
        

        #region AccountActivityID
        private int? mAccountActivityID;
        public int? AccountActivityID
        {
            get { return mAccountActivityID; }
            set 
            { 
                mAccountActivityID = value;
                NotifyPropertyChanged("AccountActivityID");
            }
        }
        #endregion

        #region Account
        private int? mAccountID;
        public int? AccountID
        {
            get 
            {
                if (mAccount != null)
                {
                    return mAccount.AccountID;
                }
                return mAccountID; 
            }
            set 
            { 
                mAccountID = value;
                NotifyPropertyChanged("AccountID");
            }
        }
        private Account mAccount=null;
        public Account Account
        {
            get
            {
                if (mAccount == null)
                {
                    mAccount = (Account)BuildProperty(this, "Account");
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

        #region FinancialYear
        private int? mFinancialYear;
        public int? FinancialYear
        {
            get { return mFinancialYear; }
            set 
            { 
                mFinancialYear = value;
                NotifyPropertyChanged("FinancialYear");
            }
        }
        #endregion

        #region Period
        private int? mPeriod;
        public int? Period
        {
            get { return mPeriod; }
            set 
            { 
                mPeriod = value;
                NotifyPropertyChanged("Period");
            }
        }
        #endregion

        #region Amount
        private double mAmount;
        public double Amount
        {
            get { return mAmount; }
            set 
            { 
                mAmount = value;
                NotifyPropertyChanged("Amount");
            }
        }
        #endregion

        public string AmountText
        {
            get
            {
                Currencies.CurrencyManager cm = RepositoryMgr.CurrencyMgr;
                Currencies.Currency currency=cm.DefaultCurrency;
                return currency.Format(Amount);
            }
        }

        #region -(Object Override Methods)
        public override string ToString()
        {
            return string.Format("{0} {1}: {2}", FinancialYear, Period, Amount);
        }

        public override bool Equals(object obj)
        {
            if (obj is AccountActivity)
            {
                AccountActivity _obj = obj as AccountActivity;
                if (_obj.FromDb && FromDb)
                {
                    return _obj.AccountActivityID == AccountActivityID;
                }
                return _obj.AccountID == AccountID
                    && _obj.Period == Period
                    && _obj.FinancialYear == FinancialYear
                    && _obj.Amount == Amount;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion


       

    }
}
