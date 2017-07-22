using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Jobs
{
    public class JobJournalRecord : Entity
    {
        internal JobJournalRecord(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        #region JobJournalRecordID
        private int? mJobJournalRecordID;
        public int? JobJournalRecordID
        {
            get { return mJobJournalRecordID; }
            set
            {
                mJobJournalRecordID = value;
                NotifyPropertyChanged("JobJournalRecordID");
            }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("JobJournalRecordID", JobJournalRecordID);
            }
        }

        #region TransactionDate
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
        #endregion

        #region IsThirteenthPeriod
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
        #endregion

        #region Job
        private Job mJob;
        public Job Job
        {
            get
            {
                if (mJob == null)
                {
                    mJob = (Job)BuildProperty(this, "Job");
                }
                return mJob;
            }
            set
            {
                mJob = value;
                NotifyPropertyChanged("Job");
            }
        }
        private int? mJobID;
        public int? JobID
        {
            get
            {
                if (mJob != null)
                {
                    return mJob.JobID;
                }
                return mJobID;
            }
            set
            {
                mJobID = value;
                NotifyPropertyChanged("JobID");
            }
        }
        #endregion

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

        #region JournalRecord
        private JournalRecords.JournalRecord mJournalRecord;
        public JournalRecords.JournalRecord JournalRecord
        {
            get
            {
                if (mJournalRecord == null)
                {
                    mJournalRecord = (JournalRecords.JournalRecord)BuildProperty(this, "JournalRecord");
                }
                return mJournalRecord;
            }
            set
            {
                mJournalRecord = value;
                NotifyPropertyChanged("JournalRecord");
            }
        }
        private int? mJournalRecordID;
        public int? JournalRecordID
        {
            get
            {
                if (mJournalRecord != null)
                {
                    return mJournalRecord.JournalRecordID;
                }
                return mJournalRecordID;
            }
            set
            {
                mJournalRecordID = value;
                NotifyPropertyChanged("JournalRecordID");
            }
        }
        #endregion

        private int? mSalePurchaseLineID;
        public int? SalePurchaseLineID
        {
            get { return mSalePurchaseLineID; }
            set
            {
                mSalePurchaseLineID = value;
                NotifyPropertyChanged("SalePurchaseLineID");
            }
        }

        #region JournalType
        private JournalRecords.JournalType mJournalType;
        public JournalRecords.JournalType JournalType
        {
            get
            {
                if (mJournalType == null)
                {
                    mJournalType = (JournalRecords.JournalType)BuildProperty(this, "JournalType");
                }
                return mJournalType;
            }
            set
            {
                mJournalType = value;
                NotifyPropertyChanged("JournalType");
            }
        }
        private string mJournalTypeID;
        public string JournalTypeID
        {
            get
            {
                if (mJournalType != null)
                {
                    return mJournalType.JournalTypeID;
                }
                return mJournalTypeID;
            }
            set
            {
                mJournalTypeID = value;
                NotifyPropertyChanged("JournalTypeID");
            }
        }
        #endregion

        private string mIsReimbursed = "N";
        public string IsReimbursed
        {
            get { return mIsReimbursed; }
            set
            {
                mIsReimbursed = value;
                NotifyPropertyChanged("IsReimbursed");
            }
        }

        private string mTransactionNumber = "";
        public string TransactionNumber
        {
            get { return mTransactionNumber; }
            set
            {
                mTransactionNumber = value;
                NotifyPropertyChanged("TransactionNumber");
            }
        }

        #region Account
        private Accounts.Account mAccount;
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
        private int? mAccountID;
        public int? AccountID
        {
            get
            {
                if (mAccount != null)
                {
                    return mAccount.AccountID;
                }
                return mAccountID;
            }
            set
            {
                mAccountID = value;
                NotifyPropertyChanged("AccountID");
            }
        }
        #endregion

    }
}
