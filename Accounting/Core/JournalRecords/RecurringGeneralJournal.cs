using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.JournalRecords
{
    public class RecurringGeneralJournal : RecurringEntity
    {
        #region -(Constructor)
        internal RecurringGeneralJournal(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        

        #region RecurringGeneralJournalID
        private int? mRecurringGeneralJournalID;
        public int? RecurringGeneralJournalID
        {
            get { return mRecurringGeneralJournalID; }
            set 
            {
                mRecurringGeneralJournalID = value;
                NotifyPropertyChanged("RecurringGeneralJournalID");
            }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("RecurringGeneralJournalID", RecurringGeneralJournalID);
            }
        }

        #region -(GetSourceID)
        public int? GetSourceID()
        {
                return mRecurringGeneralJournalID;
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

        #region RecurringGeneralJournalLines
        private List<RecurringGeneralJournalLine> mRecurringGeneralJournalLines = null;
        public List<RecurringGeneralJournalLine> RecurringGeneralJournalLines
        {
            get 
            {
                if (mRecurringGeneralJournalLines == null)
                {
                    if (FromDb)
                    {
                        mRecurringGeneralJournalLines = (List<RecurringGeneralJournalLine>)BuildProperty(this, "RecurringGeneralJournalLines");
                    }
                    else
                    {
                        mRecurringGeneralJournalLines=new List<RecurringGeneralJournalLine>();
                    }
                }
                return mRecurringGeneralJournalLines; 
            }
        }
        #endregion

        /*
        #region -(Add)
        public void Add(RecurringGeneralJournalLine line)
        {
            line.RecurringGeneralJournal = this;
            mRecurringGeneralJournalLines.Add(line);
        }
        #endregion
         */

        #region -(Object Override Methods)
        public override string ToString()
        {
            return string.Format("{0}", mMemo);
        }

        public override bool Equals(object obj)
        {
            if (obj is RecurringGeneralJournal)
            {
                RecurringGeneralJournal _obj = (RecurringGeneralJournal)obj;
                return _obj.RecurringGeneralJournalID == mRecurringGeneralJournalID;
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
