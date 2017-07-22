using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Payroll
{
    public class Wage : Entity
    {
        internal Wage(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mWageID;
        public int? WageID
        {
            get { return mWageID; }
            set
            {
                mWageID = value;
                NotifyPropertyChanged("WageID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("WageID", WageID);
            }
        }

        private string mWagesName = "";
        public string WagesName
        {
            get { return mWagesName; }
            set
            {
                mWagesName = value;
            }
        }

        private string mIsDummy = "N";
        public string IsDummy
        {
            get { return mIsDummy; }
            set
            {
                mIsDummy = value;
                NotifyPropertyChanged("IsDummy");
            }
        }

        private string mIsHourly = "N";
        public string IsHourly 
        {
            get { return mIsHourly; }
            set
            {
                mIsHourly = value;
                NotifyPropertyChanged("IsHourly");
            }
            }

        private string mUseFixedRate = "N";
        public string UseFixedRate
        {
            get { return mUseFixedRate; }
            set
            {
                mUseFixedRate = value;
                NotifyPropertyChanged("UseFixedRate");
            }
        }

        private double mRegularRateMultiplier;
        public double RegularRateMultiplier
        {
            get { return mRegularRateMultiplier; }
            set
            {
                mRegularRateMultiplier = value;
                NotifyPropertyChanged("RegularRateMultiplier");
            }
        }

        private double mFixedHourlyRate;
        public double FixedHourlyRate
        {
            get { return mFixedHourlyRate; }
            set
            {
                mFixedHourlyRate = value;
                NotifyPropertyChanged("FixedHourlyRate");
            }
        }

        #region OverideAccount
        private Accounts.Account mOverideAccount = null;
        public Accounts.Account OverideAccount
        {
            get
            {
                if (mOverideAccount == null) mOverideAccount = (Accounts.Account)BuildProperty(this, "OverideAccount");
                return mOverideAccount;
            }
            set
            {
                mOverideAccount = value;
                NotifyPropertyChanged("OverideAccount");
            }
        }
        private int? mOverideAccountID;
        public int? OverideAccountID
        {
            get
            {
                if (mOverideAccount != null) return mOverideAccount.AccountID;
                return mOverideAccountID;
            }
            set
            {
                mOverideAccountID = value;
                NotifyPropertyChanged("OverideAccountID");
            }
        }
        #endregion

        public override string ToString()
        {
            return WagesName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is Wage)
            {
                Wage _obj = obj as Wage;
                return _obj.WagesName == WagesName;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


    }
}
