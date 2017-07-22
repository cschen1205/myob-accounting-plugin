using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.JournalRecords
{
    public class JournalRecord : Entity
    {        
        #region -(Constructor)
        internal JournalRecord(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        

        #region RecordSessionTime
        private string mRecordSessionTime="";
        public string RecordSessionTime
        {
            get { return mRecordSessionTime; }
            set 
            {
                mRecordSessionTime = value;
                NotifyPropertyChanged("RecordSessionTime");
            }
        }
        #endregion

        #region RecordSessionDate
        private Nullable<DateTime> mRecordSessionDate;
        public Nullable<DateTime> RecordSessionDate
        {
            get { return mRecordSessionDate; }
            set 
            {
                mRecordSessionDate = value;
                NotifyPropertyChanged("RecordSessionDate");
            }
        }
        #endregion

        #region User
        private int? mUserID;
        public int? UserID
        {
            get { return mUserID; }
            set 
            {
                mUserID = value;
                NotifyPropertyChanged("UserID");
            }
        }
        #endregion

        #region DateReconciled
        private Nullable<DateTime> mDateReconciled;
        public Nullable<DateTime> DateReconciled
        {
            get { return mDateReconciled; }
            set 
            {
                mDateReconciled = value;
                NotifyPropertyChanged("DateReconciled");
            }
        }
        #endregion

        #region ReconciliationStatus
        private string mReconciliationStatusID="";
        public string ReconciliationStatusID
        {
            get { return mReconciliationStatusID; }
            set 
            {
                mReconciliationStatusID = value;
                NotifyPropertyChanged("ReconciliationStatusID");
            }
        }
        #endregion

        #region IsExchangeConversion
        private string mIsExchangeConversion="N";
        public string IsExchangeConversion
        {
            get { return mIsExchangeConversion; }
            set 
            {
                mIsExchangeConversion = value;
                NotifyPropertyChanged("IsExchangeConversion");
            }
        }
        #endregion

        #region IsForeignTransaction
        private string mIsForeignTransaction="N";
        public string IsForeignTransaction
        {
            get { return mIsForeignTransaction; }
            set 
            { 
                mIsForeignTransaction = value;
                NotifyPropertyChanged("IsForeignTransaction");
            }
        }
        #endregion

        #region EntryIsPurged
        private string mEntryIsPurged="N";
        public string EntryIsPurged
        {
            get { return mEntryIsPurged; }
            set 
            {
                mEntryIsPurged = value;
                NotifyPropertyChanged("EntryIsPurged");
            }
        }
        #endregion

        #region IsMultipleJob
        private string mIsMultipleJob="N";
        public string IsMultipleJob
        {
            get { return mIsMultipleJob; }
            set 
            {
                mIsMultipleJob = value;
                NotifyPropertyChanged("IsMultipleJob");
            }
        }
        #endregion

        #region Job
        private int? mJobID;
        public int? JobID
        {
            get {
                if (mJob != null)
                {
                    return mJob.JobID;
                }
                return mJobID; }
            set 
            {
                mJobID = value;
                NotifyPropertyChanged("JobID");
            }
        }
        private Jobs.Job mJob=null;
        public Jobs.Job Job
        {
            get 
            {
                if (mJob == null)
                {
                    mJob = (Jobs.Job)BuildProperty(this, "Job");
                }
                return mJob; 
            }
            set
            {
                mJob = value;
                NotifyPropertyChanged("Job");
            }
        }
        #endregion

        #region TaxExclusiveAmount
        private double mTaxExclusiveAmount;
        public double TaxExclusiveAmount
        {
            get { return mTaxExclusiveAmount; }
            set 
            {
                mTaxExclusiveAmount = value;
                NotifyPropertyChanged("TaxExclusiveAmount");
            }
        }
        #endregion

        #region Account
        private int? mAccountID;
        public int? AccountID
        {
            get {
                if (mAccount != null)
                {
                    return mAccount.AccountID;
                }
                return mAccountID; }
            set 
            {
                mAccountID = value;
                NotifyPropertyChanged("AccountID");
            }
        }
        private Accounts.Account mAccount=null;
        public Accounts.Account Account
        {
            get 
            {
                if (mAccount == null)
                {
                    mAccount = (Accounts.Account)BuildProperty(this, "Account");
                }
                return mAccount; 
            }
            set
            {
                mAccount = value;
                NotifyPropertyChanged("Account");
            }
        }
        #endregion

        #region IsThirteenthPeriod
        private string mIsThirteenthPeriod="N";
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

        #region JournalRecordID
        private int? mJournalRecordID;
        public int? JournalRecordID
        {
            get { return mJournalRecordID; }
            set 
            {
                mJournalRecordID = value;
                NotifyPropertyChanged("JournalRecordID");
            }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("JournalRecordID", JournalRecordID);
            }
        }

        #region JournalSet
        private int? mSetID;
        public int? SetID
        {
            get {
                if (JournalSet != null)
                {
                    return JournalSet.SetID;
                }
                return mSetID; }
            set 
            {
                mSetID = value;
                NotifyPropertyChanged("SetID");
            }
        }
        private JournalSet mJournalSet = null;
        public JournalSet JournalSet
        {
            get
            {
                if (mJournalSet == null)
                {
                    mJournalSet = (JournalSet)BuildProperty(this, "JournalSet");
                }
                return mJournalSet;
            }
            set
            {
                mJournalSet = value;
                NotifyPropertyChanged("JournalSet");
            }
        }
        #endregion

        #region LineNumber
        private int? mLineNumber;
        public int? LineNumber
        {
            get { return mLineNumber; }
            set 
            {
                mLineNumber = value;
                NotifyPropertyChanged("LineNumber");
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

        #region Credit
        public string CreditDescription
        {
            get
            {
                if (mTaxExclusiveAmount < 0)
                {
                    return mAccount.Currency.Format(-mTaxExclusiveAmount);
                }
                return "";
            }
        }
        #endregion

        #region Debit
        public string DebitDescription
        {
            get
            {
                if (mTaxExclusiveAmount > 0)
                {
                    return mAccount.Currency.Format(mTaxExclusiveAmount);
                }
                return "";
            }
        }
        #endregion

        #region -(Object Override Methods)
        public override bool Equals(object obj)
        {
            if (obj is JournalRecord)
            {
                JournalRecord _obj = (JournalRecord)obj;
                return _obj.JournalRecordID == mJournalRecordID;
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
