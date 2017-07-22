using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Transactions
{
    public class RecurringMoneyReceivedLine : Entity
    {
        internal RecurringMoneyReceivedLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mRecurringMoneyReceivedLineID;
        public int? RecurringMoneyReceivedLineID
        {
            get { return mRecurringMoneyReceivedLineID; }
            set
            {
                mRecurringMoneyReceivedLineID = value;
                NotifyPropertyChanged("RecurringMoneyReceivedLineID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("RecurringMoneyReceivedLineID", RecurringMoneyReceivedLineID);
            }
        }

        #region RecurringMoneyReceived
        private RecurringMoneyReceived mRecurringMoneyReceived = null;
        public RecurringMoneyReceived RecurringMoneyReceived
        {
            get
            {
                if (mRecurringMoneyReceived == null)
                {
                    mRecurringMoneyReceived = (RecurringMoneyReceived)BuildProperty(this, "RecurringMoneyReceived");
                }
                return mRecurringMoneyReceived;
            }
            set
            {
                mRecurringMoneyReceived = value;
                NotifyPropertyChanged("RecurringMoneyReceived");
            }
        }
        private int? mRecurringMoneyReceivedID;
        public int? RecurringMoneyReceivedID
        {
            get
            {
                if (mRecurringMoneyReceived != null)
                {
                    return mRecurringMoneyReceived.RecurringMoneyReceivedID;
                }
                return mRecurringMoneyReceivedID;
            }
            set
            {
                mRecurringMoneyReceivedID = value;
                NotifyPropertyChanged("RecurringMoneyReceivedID");
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
