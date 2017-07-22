using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.CostCentres
{
    public class CostCentreAccountActivity : Entity
    {
        internal CostCentreAccountActivity(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mCostCentreAccountActivityID;
        public int? CostCentreAccountActivityID
        {
            get { return mCostCentreAccountActivityID; }
            set
            {
                mCostCentreAccountActivityID = value;
                NotifyPropertyChanged("CostCentreAccountActivityID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("CostCentreAccountActivityID", CostCentreAccountActivityID);
            }
        }

        #region CostCentre
        private CostCentre mCostCentre;
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

        private double mAmount;
        public double Amount
        {
            get { return mAmount; }
            set
            {
                mAmount = value;
                NotifyPropertyChanged("Amount");
            }
        }

    }
}
