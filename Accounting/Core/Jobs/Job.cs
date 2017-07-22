using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Jobs
{
    public class Job : Entity
    {
        #region -(Constructor)
        internal Job(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {

        }
        #endregion

        

        #region JobID
        private int? mJobID;
        public int? JobID
        {
            get { return mJobID; }
            set 
            {
                mJobID = value;
                NotifyPropertyChanged("JobID");
            }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("JobID", JobID);
            }
        }

        #region IsInactive
        private string mIsInactive="N";
        public string IsInactive
        {
            get { return mIsInactive; }
            set 
            {
                mIsInactive = value;
                NotifyPropertyChanged("IsInactive");
            }
        }
        #endregion

        #region JobName
        private string mJobName;
        public string JobName
        {
            get { return mJobName; }
            set 
            {
                mJobName = value;
                NotifyPropertyChanged("JobName");
            }
        }
        #endregion

        #region JobNumber
        private string mJobNumber;
        public string JobNumber
        {
            get { return mJobNumber; }
            set 
            {
                mJobNumber = value;
                NotifyPropertyChanged("JobNumber");
            }
        }
        #endregion

        #region IsHeader
        private string mIsHeader="N";
        public string _IsHeader
        {
            get { return mIsHeader; }
            set 
            {
                mIsHeader = value;
                NotifyPropertyChanged("_IsHeader");
            }
        }
        public bool IsHeader
        {
            get { return _IsHeader.Equals("Y"); }
            set
            {
                if (value) _IsHeader = "Y";
                else _IsHeader = "N";
            }
        }
        #endregion

        #region JobLevel
        private int? mJobLevel;
        public int? JobLevel
        {
            get { return mJobLevel; }
            set 
            {
                mJobLevel = value;
                NotifyPropertyChanged("JobLevel");
            }
        }
        #endregion

        #region IsTrackingReimburseable
        private string mIsTrackingReimburseable="N";
        public string IsTrackingReimburseable
        {
            get { return mIsTrackingReimburseable; }
            set 
            {
                mIsTrackingReimburseable = value;
                NotifyPropertyChanged("IsTrackingReimburseable");
            }
        }
        #endregion

        #region JobDescription
        private string mJobDescription;
        public string JobDescription
        {
            get { return mJobDescription; }
            set 
            {
                mJobDescription = value;
                NotifyPropertyChanged("JobDescription");
            }
        }
        #endregion

        #region ContactName
        private string mContactName;
        public string ContactName
        {
            get { return mContactName; }
            set 
            {
                mContactName = value;
                NotifyPropertyChanged("ContactName");
            }
        }
        #endregion

        #region Manager
        private string mManager;
        public string Manager
        {
            get { return mManager; }
            set
            {
                mManager = value;
                NotifyPropertyChanged("Manager");
            }
        }
        #endregion

        #region PercentCompleted
        private double mPercentCompleted;
        public double PercentCompleted
        {
            get { return mPercentCompleted; }
            set 
            {
                mPercentCompleted = value;
                NotifyPropertyChanged("PercentCompleted");
            }
        }
        #endregion

        #region StartDate
        private Nullable<DateTime> mStartDate;
        public Nullable<DateTime> StartDate
        {
            get { return mStartDate; }
            set 
            {
                mStartDate = value;
                NotifyPropertyChanged("StartDate");
            }
        }
        #endregion

        #region FinishDate
        private Nullable<DateTime> mFinishDate;
        public Nullable<DateTime> FinishDate
        {
            get { return mFinishDate; }
            set 
            {
                mFinishDate = value;
                NotifyPropertyChanged("FinishDate");
            }
        }
        #endregion

        #region Customer
        private int? mCustomerID;
        public int? CustomerID
        {
            get {
                if (mCustomer != null)
                {
                    return mCustomer.CardRecordID;
                }
                return mCustomerID; }
            set 
            {
                mCustomerID = value;
                NotifyPropertyChanged("CustomerID");
            }
        }
        private Cards.Customer mCustomer;
        public Cards.Customer Customer
        {
            get 
            {
                if (mCustomer == null)
                {
                    mCustomer = (Cards.Customer)BuildProperty(this, "Customer");
                }
                return mCustomer; 
            }
            set
            {
                mCustomer = value;
                NotifyPropertyChanged("Customer");
            }
        }
        #endregion

        #region ParentJob
        private int? mParentJobID;
        public int? ParentJobID
        {
            get {
                if (mParentJob != null)
                {
                    return mParentJob.JobID;
                }
                return mParentJobID; }
            set 
            {
                mParentJobID = value;
                NotifyPropertyChanged("ParentJobID");
            }
        }
        private Job mParentJob;
        public Job ParentJob
        {
            get 
            {
                if (mParentJob == null)
                {
                    mParentJob = (Job)BuildProperty(this, "ParentJob");
                }
                return mParentJob; 
            }
            set 
            { 
                mParentJob = value;
                NotifyPropertyChanged("ParentJob");
            }
        }
        #endregion

        #region -(Object Override Methods)
        public override string ToString()
        {
            return string.Format("{0}", mJobNumber);
        }

        public override bool Equals(object obj)
        {
            if (obj is Job)
            {
                Job _obj = (Job)obj;
                return _obj.JobID == mJobID;
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
