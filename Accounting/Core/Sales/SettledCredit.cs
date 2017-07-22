using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Sales
{
    public class SettledCredit : Entity
    {
        internal SettledCredit(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mSettledCreditID;
        public int? SettledCreditID
        {
            get { return mSettledCreditID; }
            set
            {
                mSettledCreditID = value;
                NotifyPropertyChanged("SettledCreditID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("SettledCreditID", SettledCreditID);
            }
        }

        private string mSettledCreditNumber = "";
        public string SettledCreditNumber
        {
            get { return mSettledCreditNumber; }
            set
            {
                mSettledCreditNumber = value;
                NotifyPropertyChanged("SettledCreditNumber");
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

        #region CreditNote
        private Sale mCreditNote = null;
        public Sale CreditNote
        {
            get
            {
                if (mCreditNote == null)
                {
                    mCreditNote = (Sale)BuildProperty(this, "CreditNote");
                }
                return mCreditNote;
            }
            set
            {
                mCreditNote = value;
                NotifyPropertyChanged("CreditNote");
            }
        }
        private int? mCreditNoteID;
        public int? CreditNoteID
        {
            get
            {
                if (mCreditNote != null)
                {
                    return mCreditNote.SaleID;
                }
                return mCreditNoteID;
            }
            set
            {
                mCreditNoteID = value;
                NotifyPropertyChanged("CreditNoteID");
            }
        }
        #endregion

        private double mAmountSettled;
        public double AmountSettled
        {
            get { return mAmountSettled; }
            set
            {
                mAmountSettled = value;
                NotifyPropertyChanged("AmountSettled");
            }
        }

        private string mIsDiscount = "N";
        public string IsDiscount
        {
            get { return mIsDiscount; }
            set
            {
                mIsDiscount = value;
                NotifyPropertyChanged("IsDiscount");
            }
        }

        private double mFinanceCharge;
        public double FinanceCharge
        {
            get { return mFinanceCharge; }
            set
            {
                mFinanceCharge = value;
                NotifyPropertyChanged("FinanceCharge");
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


    }
}
