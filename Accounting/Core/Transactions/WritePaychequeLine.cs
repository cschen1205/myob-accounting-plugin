using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Transactions
{
    public class WritePaychequeLine : Entity
    {
        internal WritePaychequeLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mWritePaychequeLineID;
        public int? WritePaychequeLineID
        {
            get { return mWritePaychequeLineID; }
            set
            {
                mWritePaychequeLineID = value;
                NotifyPropertyChanged("WritePaychequeLineID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("WritePaychequeLineID", WritePaychequeLineID);
            }
        }

        #region WritePaycheque
        private WritePaycheque mWritePaycheque = null;
        public WritePaycheque WritePaycheque
        {
            get
            {
                if (mWritePaycheque == null) mWritePaycheque = (WritePaycheque)BuildProperty(this, "WritePaycheque");
                return mWritePaycheque;
            }
            set
            {
                mWritePaycheque = value;
                NotifyPropertyChanged("WritePaycheque");
            }
        }
        private int? mWritePaychequeID;
        public int? WritePaychequeID
        {
            get
            {
                if (mWritePaycheque != null) return mWritePaycheque.WritePaychequeID;
                return mWritePaychequeID;
            }
            set
            {
                mWritePaychequeID = value;
                NotifyPropertyChanged("WritePaychequeID");
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

        private double mHours;
        public double Hours
        {
            get { return mHours; }
            set
            {
                mHours = value;
                NotifyPropertyChanged("Hours");
            }
        }

        private int? mCategoryID;
        public int? CategoryID
        {
            get { return mCategoryID; }
            set
            {
                mCategoryID = value;
                NotifyPropertyChanged("CategoryID");
            }
        }

        #region CategoryType
        private Definitions.CategoryType mCategoryType = null;
        public Definitions.CategoryType CategoryType
        {
            get
            {
                if (mCategoryType == null) mCategoryType = (Definitions.CategoryType)BuildProperty(this, "CategoryType");
                return mCategoryType;
            }
            set
            {
                mCategoryType = value;
                NotifyPropertyChanged("CategoryType");
            }
        }
        private string mCategoryTypeID;
        public string CategoryTypeID
        {
            get
            {
                if (mCategoryType != null) return mCategoryType.CategoryTypeID;
                return mCategoryTypeID;
            }
            set
            {
                mCategoryTypeID = value;
                NotifyPropertyChanged("CategoryTypeID");
            }
        }
        #endregion

        #region Account
        private Accounts.Account mAccount = null;
        public Accounts.Account Account
        {
            get
            {
                if (mAccount == null) mAccount = (Accounts.Account)BuildProperty(this, "Account");
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
                if (mAccount != null) return mAccount.AccountID;
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

        private string mHasActivitySlip = "N";
        public string HasActivitySlip
        {
            get { return mHasActivitySlip; }
            set
            {
                mHasActivitySlip = value;
                NotifyPropertyChanged("HasActivitySlip");
            }
        }

        #region Job
        private Jobs.Job mJob = null;
        public Jobs.Job Job
        {
            get
            {
                if (mJob == null) mJob = (Jobs.Job)BuildProperty(this, "Job");
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
                if (mJob != null) return mJob.JobID;
                return mJobID;
            }
            set
            {
                mJobID = value;
                NotifyPropertyChanged("JobID");
            }
        }
        #endregion

        #region PaymentStatus
        private Definitions.DepositStatus mPaymentStatus = null;
        public Definitions.DepositStatus PaymentStatus
        {
            get
            {
                if (mPaymentStatus == null) mPaymentStatus = (Definitions.DepositStatus)BuildProperty(this, "PaymentStatus");
                return mPaymentStatus;
            }
            set
            {
                mPaymentStatus = value;
                NotifyPropertyChanged("PaymentStatus");
            }
        }
        private string mPaymentStatusID;
        public string PaymentStatusID
        {
            get
            {
                if (mPaymentStatus != null) return mPaymentStatus.DepositStatusID;
                return mPaymentStatusID;
            }
            set
            {
                mPaymentStatusID = value;
                NotifyPropertyChanged("PaymentStatusID");
            }
        }
        #endregion;
    }
}