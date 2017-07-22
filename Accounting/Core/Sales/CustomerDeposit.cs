using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Sales
{
    public class CustomerDeposit : Entity
    {
        internal CustomerDeposit(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mCustomerDepositID;
        public int? CustomerDepositID
        {
            get { return mCustomerDepositID; }
            set
            {
                mCustomerDepositID = value;
                NotifyPropertyChanged("CustomerDepositID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("CustomerDepositID", CustomerDepositID);
            }
        }

        private string mCustomerDepositNumber = "";
        public string CustomerDepositNumber
        {
            get { return mCustomerDepositNumber; }
            set
            {
                mCustomerDepositNumber = value;
                NotifyPropertyChanged("CustomerDepositNumber");
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

        #region Currency
        public Currencies.Currency mCurrency = null;
        private Currencies.Currency Currency
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
                if (mCurrency != null)
                {
                    return mCurrency.CurrencyID;
                }
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

        #region CustomerDepositsAccount
        private Accounts.Account mCustomerDepositsAccount = null;
        public Accounts.Account CustomerDepositsAccount
        {
            get
            {
                if (mCustomerDepositsAccount == null)
                {
                    mCustomerDepositsAccount = (Accounts.Account)BuildProperty(this, "CustomerDepositsAccount");
                }
                return mCustomerDepositsAccount;
            }
            set
            {
                mCustomerDepositsAccount = value;
                NotifyPropertyChanged("CustomerDepositsAccount");
            }
        }
        private int? mCustomerDepositsAccountID;
        public int? CustomerDepositsAccountID
        {
            get
            {
                if (mCustomerDepositsAccount != null)
                {
                    return mCustomerDepositsAccount.AccountID;
                }
                return mCustomerDepositsAccountID;
            }
            set
            {
                mCustomerDepositsAccountID = value;
                NotifyPropertyChanged("CustomerDepositsAccountID");
            }
        }
        #endregion

        #region Sale
        private Sale mSale = null;
        public Sale Sale
        {
            get
            {
                if (mSale == null)
                {
                    mSale = (Sale)BuildProperty(this, "Sale");
                }
                return mSale;
            }
            set
            {
                mSale = value;
                NotifyPropertyChanged("Sale");
            }
        }
        private int? mSaleID;
        public int? SaleID
        {
            get
            {
                if (mSale != null)
                {
                    return mSale.SaleID;
                }
                return mSaleID;
            }
            set
            {
                mSaleID = value;
                NotifyPropertyChanged("SaleID");
            }
        }
        #endregion

        #region Card
        private Cards.Card mCard = null;
        public Cards.Card Card
        {
            get
            {
                if (mCard == null)
                {
                    mCard = (Cards.Card)BuildProperty(this, "Card");
                }
                return mCard;
            }
            set
            {
                mCard = value;
                NotifyPropertyChanged("Card");
            }
        }
        private int? mCardRecordID;
        public int? CardRecordID
        {
            get
            {
                if (mCard != null)
                {
                    return mCard.CardRecordID;
                }
                return mCardRecordID;
            }
            set
            {
                mCardRecordID = value;
                NotifyPropertyChanged("CardRecordID");
            }
        }
        #endregion

        private double mDepositApplied;
        public double DepositApplied
        {
            get { return mDepositApplied; }
            set
            {
                mDepositApplied = value;
                NotifyPropertyChanged("DepositApplied");
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

        private double mExchangeGainLoss;
        public double ExchangeGainLoss
        {
            get { return mExchangeGainLoss; }
            set
            {
                mExchangeGainLoss = value;
                NotifyPropertyChanged("ExchangeGainLoss");
            }
        }


    }
}
