using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Accounts;
using Accounting.Core.TaxCodes;

namespace Accounting.Core.Activities
{
    public class Activity : Entity
    {
        #region ActivityID
        private int? mActivityID = null;
        public int? ActivityID
        {
            get { return mActivityID; }
            set
            {
                mActivityID = value;
                NotifyPropertyChanged("ActivityID");
            }
        }
        #endregion

        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("ActivityID", ActivityID);
            }
        }

        #region IsInactive
        private string mIsInactive = "N";
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

        #region ActivityName
        private string mActivityName = "";
        public string ActivityName
        {
            get { return mActivityName; }
            set
            {
                mActivityName = value;
                NotifyPropertyChanged("ActivityName");
            }
        }
        #endregion

        #region ActivityNumber
        private string mActivityNumber = "";
        public string ActivityNumber
        {
            get { return mActivityNumber; }
            set
            {
                mActivityNumber = value;
                NotifyPropertyChanged("ActivityNumber");
            }
        }
        #endregion

        #region IncomeAccount
        private int? mIncomeAccountID;
        public int? IncomeAccountID
        {
            get
            {
                if (mIncomeAccount != null)
                {
                    return mIncomeAccount.AccountID;
                }
                return mIncomeAccountID;
            }
            set
            {
                mIncomeAccountID = value;
                NotifyPropertyChanged("IncomeAccountID");
            }
        }
        private Account mIncomeAccount;
        public Account IncomeAccount
        {
            get
            {
                if (mIncomeAccount == null)
                {
                    mIncomeAccount = (Account)BuildProperty(this, "IncomeAccount");
                }
                return mIncomeAccount;
            }
            set
            {
                mIncomeAccount = value;
                NotifyPropertyChanged("IncomeAccount");
            }
        }
        #endregion

        #region IsHourly
        private string mIsHourly = "Y";
        public string IsHourly
        {
            get { return mIsHourly; }
            set
            {
                mIsHourly = value;
                NotifyPropertyChanged("IsHourly");
            }
        }
        #endregion

        #region IsChargeable
        private string mIsChargeable = "Y";
        public string IsChargeable
        {
            get { return mIsChargeable; }
            set
            {
                mIsChargeable = value;
                NotifyPropertyChanged("IsChargeable");
            }
        }
        #endregion

        #region BillingRateUsed
        private string mBillingRateUsedID="Y";
        public string BillingRateUsedID
        {
            get
            {
                if (mBillingRateUsed != null)
                {
                    return mBillingRateUsed.BillingRateUsedID;
                }
                return mBillingRateUsedID;
            }
            set
            {
                mBillingRateUsedID = value;
                NotifyPropertyChanged("BillingRateUsedID");
            }
        }
        private BillingRateUsed mBillingRateUsed;
        public BillingRateUsed BillingRateUsed
        {
            get
            {
                if (mBillingRateUsed == null)
                {
                    mBillingRateUsed = (BillingRateUsed)BuildProperty(this, "BillingRateUsed");
                }
                return mBillingRateUsed;
            }
            set
            {
                mBillingRateUsed = value;
                NotifyPropertyChanged("mBillingRateUsed");
            }
        }
        #endregion

        #region ActivityDescription
        private string mActivityDescription = "";
        public string ActivityDescription
        {
            get { return mActivityDescription; }
            set
            {
                mActivityDescription = value;
                NotifyPropertyChanged("ActivityDescription");
            }
        }
        #endregion

        #region UseDescription
        private string mUseDescription = "Y";
        public string UseDescription
        {
            get { return mUseDescription; }
            set
            {
                mUseDescription = value;
                NotifyPropertyChanged("UseDescription");
            }
        }
        #endregion

        #region ActivityRate
        private double mActivityRate;
        public double ActivityRate
        {
            get { return mActivityRate; }
            set
            {
                mActivityRate = value;
                NotifyPropertyChanged("ActivityRate");
            }
        }
        #endregion

        #region TaxCode
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

        private TaxCode mTaxCode;
        public TaxCode TaxCode
        {
            get 
            {
                if (mTaxCode == null)
                {
                    mTaxCode = (TaxCode)BuildProperty(this, "TaxCode");
                }
                return mTaxCode; 
            }

            set
            {
                mTaxCode = value;
                NotifyPropertyChanged("TaxCode");
            }
        }
        #endregion

        #region SellUnitMeasure
        private string mSellUnitMeasure = "";
        public string SellUnitMeasure
        {
            get { return mSellUnitMeasure; }
            set
            {
                mSellUnitMeasure = value;
                NotifyPropertyChanged("SellUnitMeasure");
            }
        }
        #endregion

        #region ChangeControl
        private int? mChangeControl;
        public int? ChangeControl
        {
            get { return mChangeControl; }
            set
            {
                mChangeControl = value;
                NotifyPropertyChanged("ChangeControl");
            }
        }
        #endregion

        #region -(Constructor)
        internal Activity(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        

        #region Object Override Methods
        public override bool Equals(object obj)
        {
            if (obj is Activity)
            {
                Activity _obj = (Activity)obj;
                return _obj.ActivityID == ActivityID;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return ActivityName;
        }
        #endregion
    }

}
