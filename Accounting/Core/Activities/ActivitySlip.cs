using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Activities
{
    public class ActivitySlip : Entity
    {
        internal ActivitySlip(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mActivitySlipID;
        public int? ActivitySlipID
        {
            get { return mActivitySlipID; }
            set
            {
                mActivitySlipID = value;
                NotifyPropertyChanged("ActivitySlipID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("ActivitySlipID", ActivitySlipID);
            }
        }

        #region Activity
        private Activity mActivity = null;
        public Activity Activity
        {
            get
            {
                if (mActivity == null) mActivity = (Activity)BuildProperty(this, "Activity");
                return mActivity;
            }
            set
            {
                mActivity = value;
                NotifyPropertyChanged("Activity");
            }
        }
        private int? mActivityID;
        public int? ActivityID
        {
            get
            {
                if (mActivity != null) return mActivity.ActivityID;
                return mActivityID;
            }
            set
            {
                mActivityID = value;
                NotifyPropertyChanged("ActivityID");
            }
        }
        #endregion

        #region EmployeeSupplier
        private Cards.Card mEmployeeSupplier = null;
        public Cards.Card EmployeeSupplier
        {
            get
            {
                if (mEmployeeSupplier == null) mEmployeeSupplier = (Cards.Card)BuildProperty(this, "EmployeeSupplier");
                return mEmployeeSupplier;
            }
            set
            {
                mEmployeeSupplier = value;
                NotifyPropertyChanged("EmployeeSupplier");
            }
        }
        private int? mEmployeeSupplierID;
        public int? EmployeeSupplierID
        {
            get
            {
                if (mEmployeeSupplier != null) return mEmployeeSupplier.CardRecordID;
                return mEmployeeSupplierID;
            }
            set
            {
                mEmployeeSupplierID = value;
                NotifyPropertyChanged("EmployeeSupplierID");
            }
        }
        #endregion

        #region CardType
        private Cards.CardType mCardType = null;
        public Cards.CardType CardType
        {
            get
            {
                if (mCardType == null) mCardType = (Cards.CardType)BuildProperty(this, "CardType");
                return mCardType;
            }
            set
            {
                mCardType = value;
                NotifyPropertyChanged("CardType");
            }
        }
        private string mCardTypeID;
        public string CardTypeID
        {
            get
            {
                if (mCardType != null) return mCardType.CardTypeID;
                return mCardTypeID;
            }
            set
            {
                mCardTypeID = value;
                NotifyPropertyChanged("CardTypeID");
            }
        }
        #endregion

        #region Customer
        private Cards.Customer mCustomer = null;
        public Cards.Customer Customer
        {
            get
            {
                if (mCustomer == null) mCustomer = (Cards.Customer)BuildProperty(this, "Customer");
                return mCustomer;
            }
            set
            {
                mCustomer = value;
                NotifyPropertyChanged("Customer");
            }
        }
        private int? mCustomerID;
        public int? CustomerID
        {
            get
            {
                if (mCustomer != null) return mCustomer.CustomerID;
                return mCustomerID;
            }
            set
            {
                mCustomerID = value;
                NotifyPropertyChanged("CustomerID");
            }
        }
        #endregion

        private string mActivitySlipNumber = "";
        public string ActivitySlipNumber
        {
            get { return mActivitySlipNumber; }
            set
            {
                mActivitySlipNumber = value;
                NotifyPropertyChanged("ActivitySlipNumber");
            }
        }

        private DateTime? mDate;
        public DateTime? Date
        {
            get { return mDate; }
            set
            {
                mDate = value;
                NotifyPropertyChanged("Date");
            }
        }

        private DateTime? mActivityDate;
        public DateTime? ActivityDate
        {
            get { return mActivityDate; }
            set
            {
                mActivityDate = value;
                NotifyPropertyChanged("ActivityDate");
            }
        }

        private double mUnits;
        public double Units
        {
            get { return mUnits; }
            set
            {
                mUnits = value;
                NotifyPropertyChanged("Units");
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

        private double mRate;
        public double Rate
        {
            get { return mRate; }
            set
            {
                mRate = value;
                NotifyPropertyChanged("Rate");
            }
        }

        private double mAlreadyBilledUnits;
        public double AlreadyBilledUnits
        {
            get { return mAlreadyBilledUnits; }
            set 
            {
                mAlreadyBilledUnits = value;
                NotifyPropertyChanged("AlreadyBilledUnits");
            }
        }

        private double mAlreadyBilledAmount;
        public double AlreadyBilledAmount
        {
            get { return mAlreadyBilledAmount; }
            set
            {
                mAlreadyBilledAmount = value;
                NotifyPropertyChanged("AlreadyBilledAmount");
            }
        }

        private double mAdjustmentUnits;
        public double AdjustmentUnits
        {
            get { return mAdjustmentUnits; }
            set
            {
                mAdjustmentUnits = value;
                NotifyPropertyChanged("AdjustmentUnits");
            }
        }

        private double mAdjustmentAmount;
        public double AdjustmentAmount
        {
            get { return mAdjustmentAmount; }
            set
            {
                mAdjustmentAmount = value;
                NotifyPropertyChanged("AdjustmentAmount");
            }
        }

        private string mNotes = "";
        public string Notes
        {
            get { return mNotes; }
            set
            {
                mNotes = value;
                NotifyPropertyChanged("Notes");
            }
        }

        private string mStartTime = "";
        public string StartTime
        {
            get { return mStartTime; }
            set
            {
                mStartTime = value;
                NotifyPropertyChanged("StartTime");
            }
        }

        private string mStopTime = "";
        public string StopTime
        {
            get { return mStopTime; }
            set
            {
                mStopTime = value;
                NotifyPropertyChanged("StopTime");
            }
        }

        private int? mElapsedTime;
        public int? ElapsedTime
        {
            get { return mElapsedTime; }
            set
            {
                mElapsedTime = value;
                NotifyPropertyChanged("ElapsedTime");
            }
        }

        #region SlipStatus
        private Definitions.Status mSlipStatus = null;
        public Definitions.Status SlipStatus
        {
            get
            {
                if (mSlipStatus == null) mSlipStatus = (Definitions.Status)BuildProperty(this, "SlipStatus");
                return mSlipStatus;
            }
            set
            {
                mSlipStatus = value;
                NotifyPropertyChanged("SlipStatus");
            }
        }
        private string mSlipStatusID;
        public string SlipStatusID
        {
            get
            {
                if (mSlipStatus != null) return mSlipStatus.StatusID;
                return mSlipStatusID;
            }
            set
            {
                mSlipStatusID = value;
                NotifyPropertyChanged("SlipStatusID");
            }
        }
        #endregion

        #region PayrollStatus
        private Definitions.Status mPayrollStatus = null;
        public Definitions.Status PayrollStatus
        {
            get
            {
                if (mPayrollStatus == null) mPayrollStatus = (Definitions.Status)BuildProperty(this, "PayrollStatus");
                return mPayrollStatus;
            }
            set
            {
                mPayrollStatus = value;
                NotifyPropertyChanged("PayrollStatus");
            }
        }
        private string mPayrollStatusID;
        public string PayrollStatusID
        {
            get
            {
                if (mPayrollStatus != null) return mPayrollStatus.StatusID;
                return mPayrollStatusID;
            }
            set
            {
                mPayrollStatusID = value;
                NotifyPropertyChanged("PayrollStatusID");
            }
        }
        #endregion

        private string mIncludeInPayroll = "N";
        public string IncludeInPayroll
        {
            get { return mIncludeInPayroll; }
            set
            {
                mIncludeInPayroll = value;
                NotifyPropertyChanged("IncludeInPayroll");
            }
        }

        #region Wage
        private Payroll.Wage mWage=null;
        public Payroll.Wage Wage
        {
            get
            {
                if (mWage == null) mWage = (Payroll.Wage)BuildProperty(this, "Wage");
                return mWage;
            }
            set
            {
                mWage = value;
                NotifyPropertyChanged("Wage");
            }
        }
        private int? mWagesID;
        public int? WagesID
        {
            get
            {
                if (mWage != null) return mWage.WageID;
                return mWagesID;
            }
            set
            {
                mWagesID = value;
                NotifyPropertyChanged("WagesID");
            }
        }
        #endregion

        #region JournalRecord
        private JournalRecords.JournalRecord mJournalRecord = null;
        public JournalRecords.JournalRecord JournalRecord
        {
            get
            {
                if (mJournalRecord == null) mJournalRecord = (JournalRecords.JournalRecord)BuildProperty(this, "JournalRecord");
                return mJournalRecord;
            }
            set
            {
                mJournalRecord = value;
                NotifyPropertyChanged("JournalRecord");
            }
        }
        private int? mJournalRecordID;
        public int? JournalRecordID
        {
            get
            {
                if (mJournalRecord != null) return mJournalRecord.JournalRecordID;
                return mJournalRecordID;
            }
            set
            {
                mJournalRecordID = value;
                NotifyPropertyChanged("JournalRecordID");
            }
        }
        #endregion

        private int? mSetID;
        public int? SetID
        {
            get { return mSetID; }
            set
            {
                mSetID = value;
                NotifyPropertyChanged("SetID");
            }
        }
    }
}
