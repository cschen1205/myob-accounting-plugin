using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Jobs
{
    public class JobBudget : Entity
    {
        internal JobBudget(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {

        }

        

        #region JobBudgetID
        private int? mJobBudgetID;
        public int? JobBudgetID
        {
            get { return mJobBudgetID; }
            set
            {
                mJobBudgetID = value;
                NotifyPropertyChanged("JobBudgetID");
            }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("JobBudgetID", JobBudgetID);
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

        private double mAmount;
        public double Amount
        {
            get { return mAmount; }
            set
            {
                mAmount = value;
                NotifyPropertyChanged("Amount");
            }
        }
    }
}
