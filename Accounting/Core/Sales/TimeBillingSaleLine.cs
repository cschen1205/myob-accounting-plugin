using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Activities;

namespace Accounting.Core.Sales
{
    public class TimeBillingSaleLine : SaleLine
    {
        #region -(Constructor)
        internal TimeBillingSaleLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        protected override SaleLine CreateLine()
        {
            return new TimeBillingSaleLine(false, EntityBuilder);
        }
        

        #region TimeBillingSaleLineID
        private int? mTimeBillingSaleLineID;
        public int? TimeBillingSaleLineID
        {
            get { return mTimeBillingSaleLineID; }
            set { mTimeBillingSaleLineID = value;
            NotifyPropertyChanged("TimeBillingSaleLineID");
            }
        }
        #endregion

        #region LineDate
        private DateTime? mLineDate;
        public Nullable<DateTime> LineDate
        {
            get { return mLineDate; }
            set
            {
                mLineDate = value;
                NotifyPropertyChanged("LineDate");
            }
        }
        #endregion

        #region HoursUnits
        private double mHoursUnits;
        public double HoursUnits
        {
            get { return mHoursUnits; }

            set
            {
                mHoursUnits = value;
                NotifyPropertyChanged("HoursUnits");
            }
        }
        #endregion

        #region Activity
        private int? mActivityID;
        public int? ActivityID
        {
            get
            {
                if (mActivity != null)
                {
                    return mActivity.ActivityID;
                }
                return mActivityID;
            }
            set
            {
                mActivityID = value;
                NotifyPropertyChanged("ActivityID");
            }
        }
        private Activity mActivity;
        public Activity Activity
        {
            get
            {
                if (mActivity == null)
                {
                    mActivity = (Activity)BuildProperty(this, "Activity");
                }

                return mActivity;
            }
            set
            {
                mActivity = value;
                NotifyPropertyChanged("Activity");
            }
        }
        #endregion

        #region TaxExclusiveRate
        private double mTaxExclusiveRate;
        public double TaxExclusiveRate
        {
            get
            {
                return mTaxExclusiveRate;
            }
            set
            {
                mTaxExclusiveRate = value;
                NotifyPropertyChanged("TaxExclusiveRate");
            }
        }
        #endregion

        #region TaxInclusiveRate
        private double mTaxInclusiveRate;
        public double TaxInclusiveRate
        {
            get
            {
                return mTaxInclusiveRate;
            }
            set
            {
                mTaxInclusiveRate=value;
                NotifyPropertyChanged("TaxInclusiveRate");
            }
        }
        #endregion

        #region EstimatedCost
        private double mEstimatedCost;
        public double EstimatedCost
        {
            get
            {
                return mEstimatedCost;
            }
            set
            {
                mEstimatedCost=value;
                NotifyPropertyChanged("EstimatedCost");
            }
        }
        #endregion

        #region Location
        private int? mLocationID;
        public int? LocationID
        {
            get
            {
                if (mLocation != null)
                {
                    return mLocation.LocationID;
                }
                return mLocationID;
            }
            set { mLocationID = value; 
                NotifyPropertyChanged("LocationID");
            }
        }
        private Inventory.Location mLocation;
        public Inventory.Location Location
        {
            get 
            {
                if (mLocation == null)
                {
                    mLocation = (Inventory.Location)BuildProperty(this, "Location");
                }
                return mLocation; 
            }
            set
            {
                mLocation = value;
                NotifyPropertyChanged("Location");
            }
        }
        #endregion


        //#region Entity Override Methods
        //public override void AssignFrom(Entity rhs)
        //{
        //    base.AssignFrom(rhs);
        //    TimeBillingSaleLine _obj = (TimeBillingSaleLine)rhs;
        //    TimeBillingSaleLineID = _obj.TimeBillingSaleLineID;            
        //}
        //public override void Copy2(Entity rhs)
        //{
        //    base.Copy2(rhs);

        //    TimeBillingSaleLine _obj = (TimeBillingSaleLine)rhs;
        //    LineDate = _obj.LineDate;
        //    HoursUnits = _obj.HoursUnits;
        //    ActivityID = _obj.ActivityID;
        //    Activity = _obj.Activity;
        //    TaxExclusiveRate = _obj.TaxExclusiveRate;
        //    TaxInclusiveRate = _obj.TaxInclusiveRate;
        //    LocationID = _obj.LocationID;
        //    Location = _obj.Location;
        //    EstimatedCost = _obj.EstimatedCost;
        //}
        //#endregion
    }
}
