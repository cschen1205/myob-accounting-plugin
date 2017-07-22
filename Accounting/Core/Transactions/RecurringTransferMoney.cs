using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Transactions
{
    public class RecurringTransferMoney : RecurringEntity
    {

        public override RecordKeyInt  IntId
        {
	        get 
	        {
                return new RecordKeyInt("RecurringTransferMoneyID", RecurringTransferMoneyID);
	        }
        }


        #region -(Constructor)
        internal RecurringTransferMoney(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        

        #region RecurringTransferMoneyID
        private int? mRecurringTransferMoneyID;
        public int? RecurringTransferMoneyID
        {
            get { return mRecurringTransferMoneyID; }
            set { mRecurringTransferMoneyID = value;
            NotifyPropertyChanged("RecurringTransferMoneyID");
            }
        }
        #endregion

        #region ToAccount
        private int? mToAccountID;
        public int? ToAccountID
        {
            get
            {
                if (mToAccount != null)
                {
                    return mToAccount.AccountID;
                }
                return mToAccountID;
            }
            set { mToAccountID = value;
            NotifyPropertyChanged("ToAccountID");
            }
        }
        private Accounts.Account mToAccount;
        public Accounts.Account ToAccount
        {
            get
            {
                if (mToAccount == null)
                {
                    mToAccount = (Accounts.Account)BuildProperty(this, "ToAccount");
                }
                return mToAccount;
            }
            set
            {
                mToAccount = value;
                NotifyPropertyChanged("ToAccount");
            }
        }
        #endregion

        #region FromAccount
        private int? mFromAccountID;
        public int? FromAccountID
        {
            get
            {
                if (mFromAccount != null)
                {
                    return mFromAccount.AccountID;
                }
                return mFromAccountID;
            }
            set { mFromAccountID = value;
            NotifyPropertyChanged("FromAccountID");
            }
        }
        private Accounts.Account mFromAccount;
        public Accounts.Account FromAccount
        {
            get
            {
                if (mFromAccount == null)
                {
                    mFromAccount = (Accounts.Account)BuildProperty(this, "FromAccount");
                }
                return mFromAccount;
            }
            set
            {
                mFromAccount = value;
                NotifyPropertyChanged("FromAccount");
            }
        }
        #endregion

        #region Memo
        private string mMemo="";
        public string Memo
        {
            get { return mMemo; }
            set { mMemo = value;
            NotifyPropertyChanged("Memo");
            }
        }
        #endregion

        #region Amount
        private double mAmount;
        public double Amount
        {
            get { return mAmount; }
            set { mAmount = value;
            NotifyPropertyChanged("Amount");
            }
        }
        #endregion

        #region IsTaxInclusive
        private string mIsTaxInclusive="N";
        public string IsTaxInclusive
        {
            get { return mIsTaxInclusive; }
            set { mIsTaxInclusive = value;
            NotifyPropertyChanged("IsTaxInclusive");
            }
        }
        #endregion

        #region IsTransferredElectronically
        private string mIsTransferredElectronically="N";
        public string IsTransferredElectronically
        {
            get { return mIsTransferredElectronically; }
            set { mIsTransferredElectronically = value;
            NotifyPropertyChanged("IsTransferredElectronically");
            }
        }
        #endregion

        #region Currency
        private int? mCurrencyID;
        public int? CurrencyID
        {
            get
            {
                if (mCurrency != null)
                {
                    return mCurrency.CurrencyID;
                }
                return mCurrencyID;
            }
            set { mCurrencyID = value;
            NotifyPropertyChanged("CurrencyID");
            }
        }
        private Currencies.Currency mCurrency;
        public Currencies.Currency Currency
        {
            get
            {
                if (mCurrency == null)
                {
                    mCurrency = (Currencies.Currency)BuildProperty(this, "Currency");
                }
                return mCurrency;
            }
            set
            {
                mCurrency = value;
                NotifyPropertyChanged("Currency");
            }
        }
        #endregion

        #region CostCentreID
        private int? mCostCentreID;
        public int? CostCentreID
        {
            get { return mCostCentreID; }
            set { mCostCentreID = value;
            NotifyPropertyChanged("CostCentreID");
            }
        }
        #endregion

        #region -(Object Override Methods)
        public override bool Equals(object obj)
        {
            if (obj is RecurringTransferMoney)
            {
                RecurringTransferMoney _obj = (RecurringTransferMoney)obj;
                return _obj.RecurringTransferMoneyID == mRecurringTransferMoneyID;
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
