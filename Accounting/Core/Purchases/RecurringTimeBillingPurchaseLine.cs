using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Activities;

namespace Accounting.Core.Purchases
{
    public class RecurringTimeBillingPurchaseLine : RecurringPurchaseLine
    {
        #region -(Constructor)
        internal RecurringTimeBillingPurchaseLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        //protected override RecurringPurchaseLine CreateLine()
        //{
        //    return new RecurringTimeBillingPurchaseLine(false, EntityBuilder);
        //}

        #region RecurringTimeBillingPurchaseLineID
        private int? mRecurringTimeBillingPurchaseLineID;
        public int? RecurringTimeBillingPurchaseLineID
        {
            get { return mRecurringTimeBillingPurchaseLineID; }
            set 
            {
                mRecurringTimeBillingPurchaseLineID = value;
                NotifyPropertyChanged("RecurringTimeBillingPurchaseLineID");
            }
        }
        #endregion

        #region Account
        private int? mAccountID;
        public int? AccountID
        {
            get {
                if (mAccount != null)
                {
                    return mAccount.AccountID;
                }
                return mAccountID; }
            set 
            {
                mAccountID = value;
                NotifyPropertyChanged("AccountID");
            }
        }

        private Accounts.Account mAccount;
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
        #endregion

        #region LineDate
        private DateTime? mLineDate;
        public Nullable<DateTime> LineDate
        {
            get
            {
                return mLineDate;
            }
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
            get
            {
                return mHoursUnits;
            }
            set
            {
                mHoursUnits=value;
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
        private Activity mActivity = null;
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
                mTaxExclusiveRate=value;
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
            set 
            {
                mLocationID = value; 
                NotifyPropertyChanged("LocationID");
            }
        }
        private Inventory.Location mLocation;
        public Inventory.Location Location
        {
            get { return mLocation; }
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
        //    RecurringTimeBillingPurchaseLine _obj = (RecurringTimeBillingPurchaseLine)rhs;
        //    RecurringTimeBillingPurchaseLineID = _obj.RecurringTimeBillingPurchaseLineID;
        //    LineDate = _obj.LineDate;
        //    HoursUnits = _obj.HoursUnits;
        //    ActivityID = _obj.ActivityID;
        //    Activity = _obj.Activity;
        //    TaxExclusiveRate = _obj.TaxExclusiveRate;
        //    TaxInclusiveRate = _obj.TaxInclusiveRate;
        //    LocationID = _obj.LocationID;
        //    Location = _obj.Location;
        //}
        //#endregion

        #region -(Object Override Methods)
        public override bool Equals(object obj)
        {
            if (obj is RecurringTimeBillingPurchaseLine)
            {
                RecurringTimeBillingPurchaseLine _obj = (RecurringTimeBillingPurchaseLine)obj;
                return _obj.RecurringTimeBillingPurchaseLineID == mRecurringTimeBillingPurchaseLineID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("[Tbil]: {0}", base.ToString());
        }
        #endregion
    }
}
