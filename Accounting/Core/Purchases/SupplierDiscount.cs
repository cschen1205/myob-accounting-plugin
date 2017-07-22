using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Purchases
{
    public class SupplierDiscount : Entity
    {
        internal SupplierDiscount(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        #region +(Factory Methods)
        public static SupplierDiscount CreateDbSupplierDiscount(EntityBuilder eb)
        {
            return new SupplierDiscount(true, eb);
        }
        public static SupplierDiscount CreateSupplierDiscount()
        {
            return new SupplierDiscount(false, null);
        }
        #endregion

        private int? mSupplierDiscountID;
        public int? SupplierDiscountID
        {
            get
            {
                return mSupplierDiscountID;
            }
            set
            {
                mSupplierDiscountID = value;
                NotifyPropertyChanged("SupplierDiscountID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("SupplierDiscountID", SupplierDiscountID);
            }
        }

        private string mSupplierDiscountNumber = "";
        public string SupplierDiscountNumber
        {
            get
            {
                return mSupplierDiscountNumber;
            }
            set
            {
                mSupplierDiscountNumber = value;
                NotifyPropertyChanged("SupplierDiscountNumber");
            }
        }

        private DateTime? mDate;
        public DateTime? Date
        {
            get
            {
                return mDate;
            }
            set
            {
                mDate = value;
                NotifyPropertyChanged("Date");
            }
        }

        private DateTime? mTransactionDate;
        public DateTime? TransactionDate
        {
            get
            {
                return mTransactionDate;
            }
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

        #region DiscountAccount
        private Accounts.Account mDiscountAccount = null;
        public Accounts.Account DiscountAccount
        {
            get
            {
                if (mDiscountAccount == null)
                {
                    mDiscountAccount = (Accounts.Account)BuildProperty(this, "DiscountAccount");
                }
                return mDiscountAccount;
            }
            set
            {
                mDiscountAccount = value;
                NotifyPropertyChanged("DiscountAccount");
            }
        }
        private int? mDiscountAccountID;
        public int? DiscountAccountID
        {
            get
            {
                if (mDiscountAccount != null)
                {
                    return mDiscountAccount.AccountID;
                }
                return mDiscountAccountID;
            }
            set
            {
                mDiscountAccountID = value;
                NotifyPropertyChanged("DiscountAccountID");
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

        private double mTotalDiscount;
        public double TotalDiscount
        {
            get { return mTotalDiscount; }
            set
            {
                mTotalDiscount = value;
                NotifyPropertyChanged("TotalDiscount");
            }
        }
    }
}
