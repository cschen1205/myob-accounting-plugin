using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Accounts
{
    public class AccountBudget : Entity
    {
        internal AccountBudget(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
            
        }


        public bool Match(int? account_id, int? year, int? period)
        {
            if (account_id != null && AccountID.Value != account_id.Value) return false;
            if (year != null && FinancialYear.Value != year.Value) return false;
            if (period != null && Period.Value != period.Value) return false;
            return true;
        }

        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("AccountBudgetID", AccountBudgetID);
            }
        }

        #region AccountBudgetID
        private int? mAccountBudgetID;
        public int? AccountBudgetID
        {
            get { return mAccountBudgetID; }
            set 
            { 
                mAccountBudgetID = value;
                NotifyPropertyChanged("AccountBudgetID");
            }
        }
        #endregion

        #region AccountID
        private int? mAccountID;
        public int? AccountID
        {
            get { return mAccountID; }
            set 
            { 
                mAccountID = value;
                NotifyPropertyChanged("AccountID");
            }
        }
        #endregion

        #region Period
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
        #endregion

        #region Amount
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
        #endregion 

        #region FinancialYear
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
        #endregion




    }
}
