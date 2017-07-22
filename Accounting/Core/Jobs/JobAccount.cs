using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Jobs
{
    public class JobAccount : Entity
    {
        internal JobAccount(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        #region JobAccountID
        private int? mJobAccountID;
        public int? JobAccountID
        {
            get { return mJobAccountID; }
            set
            {
                mJobAccountID = value;
                NotifyPropertyChanged("JobAccountID");
            }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("JobAccountID", JobAccountID);
            }
        }

        #region Job
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
        private Job mJob = null;
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
        #endregion

        #region Account
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
        private Accounts.Account mAccount = null;
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

        #region OpeningBalance
        private double mOpeningBalance;
        public double OpeningBalance
        {
            get { return mOpeningBalance; }
            set
            {
                mOpeningBalance = value;
                NotifyPropertyChanged("OpeningBalance");
            }
        }
        #endregion

        #region CurrentBalance
        private double mCurrentBalance;
        public double CurrentBalance
        {
            get { return mCurrentBalance; }
            set
            {
                mCurrentBalance = value;
                NotifyPropertyChanged("CurrentBalance");
            }
        }
        #endregion

        #region PreLastYearActivity
        private double mPreLastYearActivity;
        public double PreLastYearActivity
        {
            get { return mPreLastYearActivity; }
            set
            {
                mPreLastYearActivity = value;
                NotifyPropertyChanged("PreLastYearActivity");
            }
        }
        #endregion

        #region LastYearOpeningBalance
        private double mLastYearOpeningBalance;
        public double LastYearOpeningBalance
        {
            get { return mLastYearOpeningBalance; }
            set
            {
                mLastYearOpeningBalance = value;
                NotifyPropertyChanged("LastYearOpeningBalance");
            }
        }
        #endregion

        #region ThisYearOpeningBalance
        private double mThisYearOpeningBalance;
        public double ThisYearOpeningBalance
        {
            get { return mThisYearOpeningBalance; }
            set
            {
                mThisYearOpeningBalance=value;
            }
        }
        #endregion

        #region PostThisYearActivity
        private double mPostThisYearActivity;
        public double PostThisYearActivity
        {
            get { return mPostThisYearActivity; }
            set
            {
                mPostThisYearActivity = value;
                NotifyPropertyChanged("PostThisYearActivity");
            }
        }
        #endregion
    }
}
