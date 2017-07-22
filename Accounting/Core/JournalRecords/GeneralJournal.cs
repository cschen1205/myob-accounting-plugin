using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.JournalRecords
{
    public class GeneralJournal : Entity, JournalSource
    {
        #region -(GetTransactionDate)
        public Nullable<DateTime> GetTransactionDate()
        {
            return mTransactionDate;
        }
        #endregion

        #region -(Constructor)
        internal GeneralJournal(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        

        #region GeneralJournalID
        private int? mGeneralJournalID;
        public int? GeneralJournalID
        {
            get { return mGeneralJournalID; }
            set 
            {
                mGeneralJournalID = value;
                NotifyPropertyChanged("GeneralJournalID");
            }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("GeneralJournalID", GeneralJournalID);
            }
        }

        #region -(GetSourceID)
        public int? GetSourceID()
        {
                return mGeneralJournalID;
        }
        #endregion

        #region GeneralJournalNumber
        private string mGeneralJournalNumber;
        public string GeneralJournalNumber
        {
            get { return mGeneralJournalNumber; }
            set 
            {
                mGeneralJournalNumber = value;
                NotifyPropertyChanged("GeneralJournalNumber");
            }
        }
        #endregion

        #region TransactionDate
        private Nullable<DateTime> mTransactionDate;
        public Nullable<DateTime> TransactionDate
        {
            get { return mTransactionDate; }
            set 
            {
                mTransactionDate = value;
                NotifyPropertyChanged("TransactionDate");
            }
        }
        #endregion

        #region IsThirteenthPeriod
        private string mIsThirteenthPeriod;
        public string IsThirteenthPeriod
        {
            get { return mIsThirteenthPeriod; }
            set 
            {
                mIsThirteenthPeriod = value;
                NotifyPropertyChanged("IsThirteenthPeriod");
            }
        }
        #endregion

        #region Memo
        private string mMemo="";
        public string Memo
        {
            get { return mMemo; }
            set 
            {
                mMemo = value;
                NotifyPropertyChanged("Memo");
            }
        }
        #endregion

        #region IsTaxInclusive
        private string mIsTaxInclusive="N";
        public string IsTaxInclusive
        {
            get { return mIsTaxInclusive; }
            set 
            {
                mIsTaxInclusive = value;
                NotifyPropertyChanged("IsTaxInclusive");
            }
        }
        #endregion

        #region IsAutoRecorded
        private string mIsAutoRecorded="N";
        public string IsAutoRecorded
        {
            get { return mIsAutoRecorded; }
            set 
            {
                mIsAutoRecorded = value;
                NotifyPropertyChanged("IsAutoRecorded");
            }
        }
        #endregion

        #region Currency
        private int? mCurrencyID;
        public int? CurrencyID
        {
            get {
                if (mCurrency != null)
                {
                    return mCurrency.CurrencyID;
                }
                return mCurrencyID; }
            set 
            {
                mCurrencyID = value;
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

        #region TransactionExchangeRate
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
        #endregion

        #region CostCentreID
        private int? mCostCentreID;
        public int? CostCentreID
        {
            get { return mCostCentreID; }
            set 
            {
                mCostCentreID = value;
                NotifyPropertyChanged("CostCentreID");
            }
        }
        #endregion

        #region GSTReportingMethodID
        private string mGSTReportingMethodID;
        public string GSTReportingMethodID
        {
            get { return mGSTReportingMethodID; }
            set 
            {
                mGSTReportingMethodID = value;
                NotifyPropertyChanged("GSTReportingMethodID");
            }
        }
        #endregion

        #region GeneralJournalLines
        private List<GeneralJournalLine> mGeneralJournalLines = null;
        public List<GeneralJournalLine> GeneralJournalLines
        {
            get 
            {
                if (mGeneralJournalLines == null)
                {
                    if (FromDb)
                    {
                        mGeneralJournalLines = (List<GeneralJournalLine>)BuildProperty(this, "GeneralJournalLines");
                    }
                    else
                    {
                        mGeneralJournalLines=new List<GeneralJournalLine>();
                    }
                }
                return mGeneralJournalLines; 
            }
        }
        #endregion

        /*
        #region -(Add)
        public void Add(GeneralJournalLine line)
        {
            line.GeneralJournal = this;
            mGeneralJournalLines.Add(line);
        }
        #endregion
         */

        #region -(Object Override Methods)
        public override string ToString()
        {
            return string.Format("{0} {1}", mGeneralJournalNumber, mMemo);
        }

        public override bool Equals(object obj)
        {
            if (obj is GeneralJournal)
            {
                GeneralJournal _obj = (GeneralJournal)obj;
                return _obj.GeneralJournalID == mGeneralJournalID;
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
