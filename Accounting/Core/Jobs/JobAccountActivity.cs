using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Jobs
{
    public class JobAccountActivity : Entity
    {
        internal JobAccountActivity(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        #region JobAccountActivityID
        private int? mJobAccountActivityID;
        public int? JobAccountActivityID
        {
            get { return mJobAccountActivityID; }
            set
            {
                mJobAccountActivityID = value;
                NotifyPropertyChanged("JobAccountActivityID");
            }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("JobAccountActivityID", JobAccountActivityID);
            }
        }

        #region Job
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

        #region Account
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

        private int? mFinancialYear;
        public int? FinancialYear
        {
            get { return mFinancialYear; }
            set
            {
                mFinancialYear = value;
                NotifyPropertyChanged("FinancialYear");
            }
        }

        private int? mPeriod;
        public int? Period
        {
            get { return mPeriod; }
            set
            {
                mPeriod = value;
                NotifyPropertyChanged("Period");
            }
        }

        private double mAmount;
        public double Amount
        {
            get { return mAmount; }
            set
            {
                mAmount=value;
                NotifyPropertyChanged("Amount");
            }
        }

    }
}
