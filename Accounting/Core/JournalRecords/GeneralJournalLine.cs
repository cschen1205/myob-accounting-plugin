using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.JournalRecords
{
    public class GeneralJournalLine : Entity
    {
        #region -(Constructor)
        internal GeneralJournalLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        

        #region GeneralJournalLineID
        private int? mGeneralJournalLineID;
        public int? GeneralJournalLineID
        {
            get { return mGeneralJournalLineID; }
            set 
            {
                mGeneralJournalLineID = value;
                NotifyPropertyChanged("GeneralJournalLineID");
            }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("GeneralJournalLineID", GeneralJournalLineID);
            }
        }

        #region GeneralJournal
        private int? mGeneralJournalID;
        public int? GeneralJournalID
        {
            get {
                if (GeneralJournal != null)
                {
                    return GeneralJournal.GeneralJournalID;
                }
                return mGeneralJournalID; }
            set 
            {
                mGeneralJournalID = value;
                NotifyPropertyChanged("GeneralJournalID");
            }
        }
        private GeneralJournal mGeneralJournal=null;
        public GeneralJournal GeneralJournal
        {
            get
            {
                if (mGeneralJournal == null)
                {
                    mGeneralJournal = (GeneralJournal)BuildProperty(this, "GeneralJournal");
                }
                return mGeneralJournal;
            }
            set

        {
            mGeneralJournal = value;
            NotifyPropertyChanged("GeneralJournalID");
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
        private Jobs.Job mJob;
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

        #region TaxInclusiveAmount
        private double mTaxInclusiveAmount;
        public double TaxInclusiveAmount
        {
            get { return mTaxInclusiveAmount; }
            set 
            {
                mTaxInclusiveAmount = value;
                NotifyPropertyChanged("TaxInclusiveAmount");
            }
        }
        #endregion

        #region LineMemo
        private string mLineMemo="";
        public string LineMemo
        {
            get { return mLineMemo; }
            set 
            {
                mLineMemo = value;
                NotifyPropertyChanged("LineMemo");
            }
        }
        #endregion

        #region -(Factory Methods)
        public override string ToString()
        {
            return string.Format("{0} {1}", mAccount, mLineNumber);
        }

        public override bool Equals(object obj)
        {
            if (obj is GeneralJournalLine)
            {
                GeneralJournalLine _obj = (GeneralJournalLine)obj;
                return _obj.GeneralJournalLineID == mGeneralJournalLineID;
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
