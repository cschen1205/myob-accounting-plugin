using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Transactions
{
    public class ElectronicPayment : Entity
    {
        internal ElectronicPayment(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mElectronicPaymentID;
        public int? ElectronicPaymentID
        {
            get { return mElectronicPaymentID; }
            set
            {
                mElectronicPaymentID = value;
                NotifyPropertyChanged("ElectronicPaymentID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("ElectronicPaymentID", ElectronicPaymentID);
            }
        }

        private string mPaymentNumber = "";
        public string PaymentNumber
        {
            get { return mPaymentNumber; }
            set
            {
                mPaymentNumber = value;
                NotifyPropertyChanged("PaymentNumber");
            }
        }

        private string mStatementText = "";
        public string StatementText
        {
            get { return mStatementText; }
            set
            {
                mStatementText = value;
                NotifyPropertyChanged("StatementText");
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

        #region IssuingAccount
        private Accounts.Account mIssuingAccount = null;
        public Accounts.Account IssuingAccount
        {
            get
            {
                if (mIssuingAccount == null) mIssuingAccount = (Accounts.Account)BuildProperty(this, "IssuingAccount");
                return mIssuingAccount;
            }
            set
            {
                mIssuingAccount = value;
                NotifyPropertyChanged("IssuingAccount");
            }
        }
        private int? mIssuingAccountID;
        public int? IssuingAccountID
        {
            get
            {
                if (mIssuingAccount != null) return mIssuingAccount.AccountID;
                return mIssuingAccountID;
            }
            set
            {
                mIssuingAccountID = value;
                NotifyPropertyChanged("IssuingAccountID");
            }
        }
        #endregion

        private double mTotalPaymentAmount;
        public double TotalPaymentAmount
        {
            get { return mTotalPaymentAmount; }
            set
            {
                mTotalPaymentAmount = value;
                NotifyPropertyChanged("TotalPaymentAmount");
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
                if (mCurrency == null) mCurrency = (Currencies.Currency)BuildProperty(this, "Currency");
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
            set
            {
                mTransactionExchangeRate = value;
                NotifyPropertyChanged("TransactionExchangeRate");
            }
        }

    }
}
