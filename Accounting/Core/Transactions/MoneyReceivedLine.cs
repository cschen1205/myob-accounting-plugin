using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Transactions
{
    public class MoneyReceivedLine : Entity
    {
        internal MoneyReceivedLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mMoneyReceivedLineID;
        public int? MoneyReceivedLineID
        {
            get { return mMoneyReceivedLineID; }
            set
            {
                mMoneyReceivedLineID = value;
                NotifyPropertyChanged("MoneyReceivedLineID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("MoneyReceivedLineID", MoneyReceivedLineID);
            }
        }

        #region MoneyReceived
        private MoneyReceived mMoneyReceived = null;
        public MoneyReceived MoneyReceived
        {
            get
            {
                if (mMoneyReceived == null)
                {
                    mMoneyReceived = (MoneyReceived)BuildProperty(this, "MoneyReceived");
                }
                return mMoneyReceived;
            }
            set
            {
                mMoneyReceived = value;
                NotifyPropertyChanged("MoneyReceived");
            }
        }
        private int? mMoneyReceivedID;
        public int? MoneyReceivedID
        {
            get
            {
                if (mMoneyReceived != null)
                {
                    return mMoneyReceived.MoneyReceivedID;
                }
                return mMoneyReceivedID;
            }
            set
            {
                mMoneyReceivedID = value;
                NotifyPropertyChanged("MoneyReceivedID");
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
