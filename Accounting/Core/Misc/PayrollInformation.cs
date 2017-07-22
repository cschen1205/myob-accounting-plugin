using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Misc
{
    public class PayrollInformation : Entity
    {
        internal PayrollInformation(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        private int? mPayrollInformationID;
        public int? PayrollInformationID
        {
            get { return mPayrollInformationID; }
            set
            {
                mPayrollInformationID = value;
                NotifyPropertyChanged("PayrollInformationID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("PayrollInformationID", PayrollInformationID);
            }
        }

        private int? mCurrentPayrollYear;
        public int? CurrentPayrollYear
        {
            get { return mCurrentPayrollYear; }
            set
            {
                mCurrentPayrollYear = value;
                NotifyPropertyChanged("CurrentPayrollYear");
            }
        }

        private double mHoursInWorkWeek;
        public double HoursInWorkWeek
        {
            get { return mHoursInWorkWeek; }
            set
            {
                mHoursInWorkWeek = value;
                NotifyPropertyChanged("HoursInWorkWeek");
            }
        }

        private string mWithholderPayerNumber = "";
        public string WithholderPayerNumber
        {
            get { return mWithholderPayerNumber; }
            set
            {
                mWithholderPayerNumber = value;
                NotifyPropertyChanged("WithholderPayerNumber");
            }
        }

        private int? mRoundNetPayTo;
        public int? RoundNetPayTo
        {
            get { return mRoundNetPayTo; }
            set
            {
                mRoundNetPayTo = value;
                NotifyPropertyChanged("RoundNetPayTo");
            }
        }

        private DateTime? mTaxTableRevisionDate;
        public DateTime? TaxTableRevisionDate
        {
            get { return mTaxTableRevisionDate; }
            set
            {
                mTaxTableRevisionDate = value;
                NotifyPropertyChanged("TaxTableRevisionDate");
            }
        }

        #region DefaultSuperannuationFund
        private Payroll.SuperannuationFund mDefaultSuperannuationFund = null;
        public Payroll.SuperannuationFund DefaultSuperannuationFund
        {
            get
            {
                if (mDefaultSuperannuationFund == null) mDefaultSuperannuationFund = (Payroll.SuperannuationFund)BuildProperty(this, "DefaultSuperannuationFund");
                return mDefaultSuperannuationFund;
            }
            set
            {
                mDefaultSuperannuationFund = value;
                NotifyPropertyChanged("DefaultSuperannuationFund");
            }
        }
        private int? mDefaultSuperannuationFundID;
        public int? DefaultSuperannuationFundID
        {
            get
            {
                if (mDefaultSuperannuationFund != null) return mDefaultSuperannuationFund.SuperannuationFundID;
                return mDefaultSuperannuationFundID;
            }
            set
            {
                mDefaultSuperannuationFundID = value;
                NotifyPropertyChanged("DefaultSuperannuationFundID");
            }
        }
        #endregion

        #region BaseSalaryWage
        private Payroll.Wage mBaseSalaryWage = null;
        public Payroll.Wage BaseSalaryWage
        {
            get
            {
                if (mBaseSalaryWage == null) mBaseSalaryWage = (Payroll.Wage)BuildProperty(this, "BaseSalaryWage");
                return mBaseSalaryWage;
            }
            set
            {
                mBaseSalaryWage = value;
                NotifyPropertyChanged("BaseSalaryWage");
            }
        }
        private int? mBaseSalaryWageID;
        public int? BaseSalaryWageID
        {
            get
            {
                if (mBaseSalaryWage != null) return mBaseSalaryWage.WageID;
                return mBaseSalaryWageID;
            }
            set
            {
                mBaseSalaryWageID = value;
                NotifyPropertyChanged("BaseSalaryWageID");
            }
        }
        #endregion

        #region BaseHourlyWage
        private Payroll.Wage mBaseHourlyWage = null;
        public Payroll.Wage BaseHourlyWage
        {
            get
            {
                if (mBaseHourlyWage == null) mBaseHourlyWage = (Payroll.Wage)BuildProperty(this, "BaseHourlyWage");
                return mBaseHourlyWage;
            }
            set
            {
                mBaseHourlyWage = value;
                NotifyPropertyChanged("BaseHourlyWage");
            }
        }
        private int? mBaseHourlyWageID;
        public int? BaseHourlyWageID
        {
            get
            {
                if (mBaseHourlyWage != null) return mBaseHourlyWage.WageID;
                return mBaseHourlyWageID;
            }
            set
            {
                mBaseHourlyWageID = value;
                NotifyPropertyChanged("BaseHourlyWageID");
            }
        }
        #endregion

        private string mUseTimesheets = "";
        public string UseTimesheets
        {
            get { return mUseTimesheets; }
            set
            {
                mUseTimesheets = value;
                NotifyPropertyChanged("UseTimesheets");
            }
        }

        private string mIncludeTimeBillingInTimesheets="N";
        public string IncludeTimeBillingInTimesheets
        {
            get { return mIncludeTimeBillingInTimesheets; }
            set
            {
                mIncludeTimeBillingInTimesheets = value;
                NotifyPropertyChanged("IncludeTimeBillingInTimesheets");
            }
        }

        #region TimesheetWeekStart
        private Definitions.DayName mTimesheetWeekStart=null;
        public Definitions.DayName TimesheetWeekStart
        {
            get
            {
                if (mTimesheetWeekStart == null) mTimesheetWeekStart = (Definitions.DayName)BuildProperty(this, "TimesheetWeekStart");
                return mTimesheetWeekStart;
            }
            set
            {
                mTimesheetWeekStart = value;
                NotifyPropertyChanged("TimesheetWeekStart");
            }
        }
        private string mTimesheetWeekStartID;
        public string TimesheetWeekStartID
        {
            get
            {
                if (mTimesheetWeekStart != null) return mTimesheetWeekStart.DayNameID;
                return mTimesheetWeekStartID;
            }
            set
            {
                mTimesheetWeekStartID = value;
                NotifyPropertyChanged("TimesheetWeekStartID");
            }
        }
        #endregion
    }
}
