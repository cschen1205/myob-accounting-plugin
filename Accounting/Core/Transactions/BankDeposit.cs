using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Transactions
{
    public class BankDeposit : Entity
    {
        internal BankDeposit(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {

        }

        

        private int? mBankDepositID;
        public int? BankDepositID
        {
            get { return mBankDepositID; }
            set
            {
                mBankDepositID = value;
                NotifyPropertyChanged("BankDepositID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("BankDepositID", BankDepositID);
            }
        }

        private string mBankDepositNumber = "";
        public string BankDepositNumber
        {
            get { return mBankDepositNumber; }
            set
            {
                mBankDepositNumber = value;
                NotifyPropertyChanged("BankDepositNumber");
            }
        }

        private DateTime? mDate;
        public DateTime? Date
        {
            get { return mDate; }
            set
            {
                mDate = value;
                NotifyPropertyChanged("Date");
            }
        }

        private DateTime? mTransactionDate;
        public DateTime? TransactionDate
        {
            get { return mTransactionDate; }
            set
            {
                mTransactionDate = value;
                NotifyPropertyChanged("TransactionDate");
            }
        }

        private string mIsThirteenthPeriod = "N";
        public string IsThirteenthPeriod
        {
            get { return mIsThirteenthPeriod; }
            set
            {
                mIsThirteenthPeriod = value;
                NotifyPropertyChanged("IsThirteenthPeriod");
            }
        }

        #region RecipientAccount
        private Accounts.Account mRecipientAccount = null;
        public Accounts.Account RecipientAccount
        {
            get
            {
                if (mRecipientAccount == null) mRecipientAccount = (Accounts.Account)BuildProperty(this, "RecipientAccount");
                return mRecipientAccount;
            }
            set
            {
                mRecipientAccount = value;
                NotifyPropertyChanged("RecipientAccount");
            }
        }
        private int? mRecipientAccountID;
        public int? RecipientAccountID
        {
            get
            {
                if (mRecipientAccount != null) return mRecipientAccount.AccountID;
                return mRecipientAccountID;
            }
            set
            {
                mRecipientAccountID = value;
                NotifyPropertyChanged("RecipientAccountID");
            }
        }
        #endregion

        private double mAmountDeposited;
        public double AmountDeposited
        {
            get { return mAmountDeposited; }
            set
            {
                mAmountDeposited=value;
                NotifyPropertyChanged("AmountDeposited");
            }
        }

        private string mMemo = "";
        public string Memo
        {
            get { return mMemo; }
            set
            {
                mMemo = value;
                NotifyPropertyChanged("Memo");
            }
        }

        private string mIsTaxInclusive = "N";
        public string IsTaxInclusive
        {
            get { return mIsTaxInclusive; }
            set
            {
                mIsTaxInclusive = value;
                NotifyPropertyChanged("IsTaxInclusive");
            }
        }

        #region Currency
        private Currencies.Currency mCurrency = null;
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
        private int? mCurrencyID;
        public int? CurrencyID
        {
            get
            {
                if (mCurrency != null) return mCurrency.CurrencyID;
                return mCurrencyID;
            }
            set
            {
                mCurrencyID = value;
                NotifyPropertyChanged("CurrencyID");
            }
        }
        #endregion

        private double mTransactionExchangeRate;
        public double TransactionExchangeRate
        {
            get { return mTransactionExchangeRate; }
            set{
                mTransactionExchangeRate = value;
                NotifyPropertyChanged("TransactionExchangeRate");
            }
        }

    }
}
