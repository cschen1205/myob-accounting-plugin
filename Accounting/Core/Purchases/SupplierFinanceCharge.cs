using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Purchases
{
    public class SupplierFinanceCharge : Entity
    {
        internal SupplierFinanceCharge(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mSupplierFinanceChargeID;
        public int? SupplierFinanceChargeID
        {
            get { return mSupplierFinanceChargeID; }
            set
            {
                mSupplierFinanceChargeID = value;
                NotifyPropertyChanged("SupplierFinanceChargeID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("SupplierFinanceChargeID", SupplierFinanceChargeID);
            }
        }

        private string mSupplierFinanceChargeNumber = "";
        public string SupplierFinanceChargeNumber
        {
            get
            {
                return mSupplierFinanceChargeNumber;
            }
            set
            {
                mSupplierFinanceChargeNumber = value;
                NotifyPropertyChanged("SupplierFinanceChargeNumber");
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
            get { return mIsTaxInclusive; }
            set
            {
                mIsTaxInclusive = value;
                NotifyPropertyChanged("IsTaxInclusive");
            }
        }

        #region Currency
        private Currencies.Currency mCurrency=null;
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

        #region LateChargesAccount
        private Accounts.Account mLateChargesAccount = null;
        public Accounts.Account LateChargesAccount
        {
            get
            {
                if (mLateChargesAccount == null)
                {
                    mLateChargesAccount = (Accounts.Account)BuildProperty(this, "LateChargesAccount");
                }
                return mLateChargesAccount;
            }
            set
            {
                mLateChargesAccount = value;
                NotifyPropertyChanged("LateChargesAccount");
            }
        }
        private int? mLateChargesAccountID;
        public int? LateChargesAccountID
        {
            get
            {
                if (mLateChargesAccount != null)
                {
                    return mLateChargesAccount.AccountID;
                }
                return mLateChargesAccountID;
            }
            set
            {
                mLateChargesAccountID = value;
                NotifyPropertyChanged("LateChargesAccountID");
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

        private double mFinanceCharge;
        public double FinanceCharge
        {
            get
            {
                return mFinanceCharge;
            }
            set
            {
                mFinanceCharge = value;
                NotifyPropertyChanged("FinanceCharge");
            }
        }
    }
}
