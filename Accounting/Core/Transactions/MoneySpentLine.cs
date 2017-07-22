using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Transactions
{
    public class MoneySpentLine : Entity
    {
        internal MoneySpentLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mMoneySpentLineID;
        public int? MoneySpentLineID
        {
            get { return mMoneySpentLineID; }
            set
            {
                mMoneySpentLineID = value;
                NotifyPropertyChanged("MoneySpentLineID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("MoneySpentLineID", MoneySpentLineID);
            }
        }

        #region MoneySpent
        private MoneySpent mMoneySpent = null;
        public MoneySpent MoneySpent
        {
            get
            {
                if (mMoneySpent == null)
                {
                    mMoneySpent = (MoneySpent)BuildProperty(this, "MoneySpent");
                }
                return mMoneySpent;
            }
            set
            {
                mMoneySpent = value;
                NotifyPropertyChanged("MoneySpent");
            }
        }
        private int? mMoneySpentID;
        public int? MoneySpentID
        {
            get
            {
                if (mMoneySpent != null)
                {
                    return mMoneySpent.MoneySpentID;
                }
                return mMoneySpentID;
            }
            set
            {
                mMoneySpentID = value;
                NotifyPropertyChanged("MoneySpentID");
            }
        }
        #endregion

        private int? mLineNumber ;
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

        private string mIsMultipleJob = "N";
        public string IsMultipleJob
        {
            get { return mIsMultipleJob; }
            set
            {
                mIsMultipleJob = value;
                NotifyPropertyChanged("IsMultipleJob");
            }
        }

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
