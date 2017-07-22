using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.JournalRecords
{
    public class JournalSet : Entity
    {        
        #region -(Constructor)
        internal JournalSet(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
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

        #region Currency
        private int? mCurrencyID;
        public int? CurrencyID
        {
            get {
                if (mCurrency != null)
                {
                    return mCurrencyID = mCurrency.CurrencyID;
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

        #region TransactionNumber
        private string mTransactionNumber="";
        public string TransactionNumber
        {
            get { return mTransactionNumber; }
            set 
            {
                mTransactionNumber = value;
                NotifyPropertyChanged("TransactionNumber");
            }
        }
        #endregion

        #region JournalSource
        private int? mSourceID;
        public int? SourceID
        {
            get {
                if (JournalSource != null)
                {
                    return JournalSource.GetSourceID();
                }
                return mSourceID; }
            set 
            {
                mSourceID = value;
                NotifyPropertyChanged("SourceID");
            }
        }
        private JournalSource mJournalSource = null;
        public JournalSource JournalSource
        {
            get
            {
                if (mJournalSource == null)
                {
                    mJournalSource = (JournalSource)BuildProperty(this, "JournalSource");
                }
                return mJournalSource;
            }
            set
            {
                mJournalSource = value;
                NotifyPropertyChanged("JournalSource");
            }
        }
        #endregion

        #region JournalType
        private string mJournalTypeID;
        public string JournalTypeID
        {
            get {
                if (mJournalType != null)
                {
                    return mJournalType.JournalTypeID;
                }
                return mJournalTypeID; }
            set 
            {
                mJournalTypeID = value;
                NotifyPropertyChanged("JournalTypeID");
            }
        }
        private JournalType mJournalType;
        public JournalType JournalType
        {
            get 
            {
                if (mJournalType == null)
                {
                    mJournalType = (JournalType)BuildProperty(this, "JournalType");
                }
                return mJournalType; 
            }
            set
            {
                mJournalType = value;
                NotifyPropertyChanged("JournalType");
            }
        }
        #endregion

        #region SetID
        private int? mSetID;
        public int? SetID
        {
            get { return mSetID; }
            set 
            {
                mSetID = value;
                NotifyPropertyChanged("SetID");
            }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("SetID", SetID);
            }
        }

        #region JournalRecords
        private List<JournalRecord> mJournalRecords =null;
        public List<JournalRecord> JournalRecords
        {
            get 
            {
                if (mJournalRecords == null)
                {
                    if (FromDb)
                    {
                        mJournalRecords = (List<JournalRecord>)BuildProperty(this, "JournalRecords");
                    }
                    else
                    {
                        mJournalRecords = new List<JournalRecord>();
                    }
                }
                return mJournalRecords; 
            }
        }
        #endregion

        #region -(Add)
        public void Add(JournalRecord jr)
        {
            jr.JournalSet = this;
            mJournalRecords.Add(jr);
        }
        #endregion

        #region TransactionDate
        public Nullable<DateTime> TransactionDate
        {
            get
            {
                foreach (JournalRecord jrec in JournalRecords)
                {
                    return jrec.TransactionDate;
                }
                return null;
            }
        }
        #endregion

        #region -(Object Override Methods)
        public override string ToString()
        {
            return mMemo;
        }

        public override bool Equals(object obj)
        {
            if (obj is JournalSet)
            {
                JournalSet _obj = (JournalSet)obj;
                return _obj.SetID == mSetID;
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
