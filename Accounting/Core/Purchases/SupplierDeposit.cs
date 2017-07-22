using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Purchases
{
    public class SupplierDeposit : Entity
    {
        internal SupplierDeposit(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mSupplierDepositID;
        public int? SupplierDepositID
        {
            get { return mSupplierDepositID; }
            set
            {
                mSupplierDepositID = value;
                NotifyPropertyChanged("SupplierDepositID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("SupplierDepositID", SupplierDepositID);
            }
        }

        private string mSupplierDepositNumber = "";
        public string SupplierDepositNumber
        {
            get { return mSupplierDepositNumber; }
            set
            {
                mSupplierDepositNumber = value;
                NotifyPropertyChanged("SupplierDepositNumber");
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
            get
            {
                return mIsThirteenthPeriod;
            }
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
            get
            {
                return mTransactionExchangeRate;
            }
            set
            {
                mTransactionExchangeRate = value;
                NotifyPropertyChanged("TransactionExchangeRate");
            }
        }

        #region SupplierDepositsAccount
        private Accounts.Account mSupplierDepositsAccount = null;
        public Accounts.Account SupplierDepositsAccount
        {
            get
            {
                if (mSupplierDepositsAccount == null)
                {
                    mSupplierDepositsAccount = (Accounts.Account)BuildProperty(this, "SupplierDepositsAccount");
                }
                return mSupplierDepositsAccount;
            }
            set
            {
                mSupplierDepositsAccount = value;
                NotifyPropertyChanged("SupplierDepositsAccount");
            }
        }
        private int? mSupplierDepositsAccountID;
        public int? SupplierDepositsAccountID
        {
            get
            {
                if (mSupplierDepositsAccount != null)
                {
                    return mSupplierDepositsAccount.AccountID;
                }
                return mSupplierDepositsAccountID;
            }
            set
            {
                mSupplierDepositsAccountID = value;
                NotifyPropertyChanged("SupplierDepositsAccountID");
            }
        }
        #endregion

        #region Purchase
        private Purchase mPurchase = null;
        public Purchase Purchase
        {
            get
            {
                if (mPurchase == null)
                {
                    mPurchase = (Purchase)BuildProperty(this, "Purchase");
                }
                return mPurchase;
            }
            set
            {
                mPurchase = value;
                NotifyPropertyChanged("Purchase");
            }
        }
        private int? mPurchaseID;
        public int? PurchaseID
        {
            get
            {
                if (mPurchase != null)
                {
                    return mPurchase.PurchaseID;
                }
                return mPurchaseID;
            }
            set
            {
                mPurchaseID = value;
                NotifyPropertyChanged("PurchaseID");
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
            get
            {
                return mIsTaxInclusive;
            }
            set
            {
                mIsTaxInclusive = value;
                NotifyPropertyChanged("IsTaxInclusive");
            }
        }

        private double mExchangeGainLoss;
        public double ExchangeGainLoss
        {
            get
            {
                return mExchangeGainLoss;
            }
            set
            {
                mExchangeGainLoss = value;
                NotifyPropertyChanged("ExchangeGainLoss");
            }
        }


    }
}
