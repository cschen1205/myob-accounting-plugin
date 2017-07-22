using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Payroll
{
    public class Superannuation : Entity
    {
        internal Superannuation(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mSuperannuationID;
        public int? SuperannuationID
        {
            get { return mSuperannuationID; }
            set
            {
                mSuperannuationID = value;
                NotifyPropertyChanged("SuperannuationID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("SuperannuationID", SuperannuationID);
            }
        }

        private string mSuperannuationName = "";
        public string SuperannuationName
        {
            get { return mSuperannuationName; }
            set
            {
                mSuperannuationName = value;
                NotifyPropertyChanged("SuperannuationName");
            }
        }

        #region ExpenseAccount
        private Accounts.Account mExpenseAccount = null;
        public Accounts.Account ExpenseAccount
        {
            get
            {
                if (mExpenseAccount == null) mExpenseAccount = (Accounts.Account)BuildProperty(this, "ExpenseAccount");
                return mExpenseAccount;
            }
            set
            {
                mExpenseAccount = value;
                NotifyPropertyChanged("ExpenseAccount");
            }
        }
        private int? mExpenseAccountID;
        public int? ExpenseAccountID
        {
            get
            {
                if (mExpenseAccount != null) return mExpenseAccount.AccountID;
                return mExpenseAccountID;
            }
            set
            {
                mExpenseAccountID = value;
                NotifyPropertyChanged("ExpenseAccountID");
            }
        }
        #endregion

        #region PayableAccount
        private Accounts.Account mPayableAccount = null;
        public Accounts.Account PayableAccount
        {
            get
            {
                if (mPayableAccount == null) mPayableAccount = (Accounts.Account)BuildProperty(this, "PayableAccount");
                return mPayableAccount;
            }
            set
            {
                mPayableAccount = value;
                NotifyPropertyChanged("PayableAccount");
            }
        }
        private int? mPayableAccountID;
        public int? PayableAccountID
        {
            get
            {
                if (mPayableAccount != null) return mPayableAccount.AccountID;
                return mPayableAccountID;
            }
            set
            {
                mPayableAccountID = value;
                NotifyPropertyChanged("PayableAccountID");
            }
        }
        #endregion

        #region ContributionType
        private Definitions.ContributionType mContributionType = null;
        public Definitions.ContributionType ContributionType
        {
            get
            {
                if (mContributionType == null) mContributionType = (Definitions.ContributionType)BuildProperty(this, "ContributionType");
                return mContributionType;
            }
            set
            {
                mContributionType = value;
                NotifyPropertyChanged("ContributionType");
            }
        }
        private string mContributionTypeID;
        public string ContributionTypeID
        {
            get
            {
                if (mContributionType != null) return mContributionType.ContributionTypeID;
                return mContributionTypeID;
            }
            set
            {
                mContributionTypeID = value;
                NotifyPropertyChanged("ContributionTypeID");
            }
        }
        #endregion

        public override string ToString()
        {
            return SuperannuationName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is Superannuation)
            {
                Superannuation _obj = obj as Superannuation;
                return _obj.SuperannuationName == SuperannuationName;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
