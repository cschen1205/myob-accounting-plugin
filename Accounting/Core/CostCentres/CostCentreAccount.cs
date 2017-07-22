using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.CostCentres
{
    public class CostCentreAccount : Entity
    {
        internal CostCentreAccount(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mCostCentreAccountID;
        public int? CostCentreAccountID
        {
            get { return mCostCentreAccountID; }
            set
            {
                mCostCentreAccountID = value;
                NotifyPropertyChanged("CostCentreAccountID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("CostCentreAccountID", CostCentreAccountID);
            }
        }

        #region CostCentre
        private CostCentre mCostCentre = null;
        public CostCentre CostCentre
        {
            get
            {
                if (mCostCentre == null) mCostCentre = (CostCentre)BuildProperty(this, "CostCentre");
                return mCostCentre;
            }
            set
            {
                mCostCentre = value;
                NotifyPropertyChanged("CostCentre");
            }
        }
        private int? mCostCentreID;
        public int? CostCentreID
        {
            get
            {
                if (mCostCentre != null) return mCostCentre.CostCentreID;
                return mCostCentreID;
            }
            set
            {
                mCostCentreID = value;
                NotifyPropertyChanged("CostCentreID");
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

        private double mCurrentBalance;
        public double CurrentBalance
        {
            get { return mCurrentBalance; }
            set
            {
                mCurrentBalance = value;
                NotifyPropertyChanged("CurrentBalance");
            }
        }

        private double mPreLastYearActivity;
        public double PreLastYearActivity
        {
            get { return mPreLastYearActivity; }
            set
            {
                mPreLastYearActivity = value;
                NotifyPropertyChanged("PreLastYearActivity");
            }
        }

        private double mLastYearOpeningBalance;
        public double LastYearOpeningBalance
        {
            get { return mLastYearOpeningBalance; }
            set
            {
                mLastYearOpeningBalance = value;
                NotifyPropertyChanged("LastYearOpeningBalance");
            }
        }

        private double mThisYearOpeningBalance;
        public double ThisYearOpeningBalance
        {
            get { return mThisYearOpeningBalance; }
            set
            {
                mThisYearOpeningBalance = value;
                NotifyPropertyChanged("ThisYearOpeningBalance");
            }
        }

        private double mPostThisYearActivity;
        public double PostThisYearActivity
        {
            get { return mPostThisYearActivity; }
            set
            {
                mPostThisYearActivity = value;
                NotifyPropertyChanged("PostThisYearActivity");
            }
        }

    }
}
