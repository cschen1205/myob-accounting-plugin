using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Activities
{
    public class ActivitySalesHistory : Entity
    {
        internal ActivitySalesHistory(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mActivitySalesHistoryID;
        public int? ActivitySalesHistoryID
        {
            get { return mActivitySalesHistoryID; }
            set
            {
                mActivitySalesHistoryID = value;
                NotifyPropertyChanged("ActivitySalesHistoryID");
            }
        }

        public override Accounting.Core.RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("ActivitySalesHistoryID", ActivitySalesHistoryID);
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

        private double mUnitsSold;
        public double UnitsSold
        {
            get { return mUnitsSold; }
            set
            {
                mUnitsSold = value;
                NotifyPropertyChanged("UnitsSold");
            }
        }

        private double mSaleAmount;
        public double SaleAmount
        {
            get { return mSaleAmount; }
            set
            {
                mSaleAmount = value;
                NotifyPropertyChanged("SaleAmount");
            }
        }

        private double mEstimatedCostOfSalesAmount;
        public double EstimatedCostOfSalesAmount
        {
            get { return mEstimatedCostOfSalesAmount; }
            set
            {
                mEstimatedCostOfSalesAmount = value;
                NotifyPropertyChanged("EstimatedCostOfSalesAmount");
            }
        }


    }
}
