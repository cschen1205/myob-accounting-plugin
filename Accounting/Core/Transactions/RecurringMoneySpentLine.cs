using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Transactions
{
    public class RecurringMoneySpentLine : Entity
    {
        internal RecurringMoneySpentLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mRecurringMoneySpentLineID;
        public int? RecurringMoneySpentLineID
        {
            get { return mRecurringMoneySpentLineID; }
            set
            {
                mRecurringMoneySpentLineID = value;
                NotifyPropertyChanged("RecurringMoneySpentLineID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("RecurringMoneySpentLineID", RecurringMoneySpentLineID);
            }
        }

        #region RecurringMoneySpent
        private RecurringMoneySpent mRecurringMoneySpent = null;
        public RecurringMoneySpent RecurringMoneySpent
        {
            get
            {
                if (mRecurringMoneySpent == null)
                {
                    mRecurringMoneySpent = (RecurringMoneySpent)BuildProperty(this, "RecurringMoneySpent");
                }
                return mRecurringMoneySpent;
            }
            set
            {
                mRecurringMoneySpent = value;
                NotifyPropertyChanged("RecurringMoneySpent");
            }
        }
        private int? mRecurringMoneySpentID;
        public int? RecurringMoneySpentID
        {
            get
            {
                if (mRecurringMoneySpent != null)
                {
                    return mRecurringMoneySpent.RecurringMoneySpentID;
                }
                return mRecurringMoneySpentID;
            }
            set
            {
                mRecurringMoneySpentID = value;
                NotifyPropertyChanged("RecurringMoneySpentID");
            }
        }
        #endregion

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

        #region Account
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

        #region Job
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


        #region TaxCode
        private TaxCodes.TaxCode mTaxCode = null;
        public TaxCodes.TaxCode TaxCode
        {
            get
            {
                if (mTaxCode == null)
                {
                    mTaxCode = (TaxCodes.TaxCode)BuildProperty(this, "TaxCode");
                }
                return mTaxCode;
            }
            set
            {
                mTaxCode = value;
                NotifyPropertyChanged("TaxCode");
            }
        }
        private int? mTaxCodeID;
        public int? TaxCodeID
        {
            get
            {
                if (mTaxCode != null)
                {
                    return mTaxCode.TaxCodeID;
                }
                return mTaxCodeID;
            }
            set
            {
                mTaxCodeID = value;
                NotifyPropertyChanged("TaxCodeID");
            }
        }
        #endregion

        private string mLineMemo = "";
        public string LineMemo
        {
            get { return mLineMemo; }
            set
            {
                mLineMemo = value;
                NotifyPropertyChanged("LineMemo");
            }
        }


    }
}
