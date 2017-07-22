using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Payroll
{
    public class WageDollarHistory : Entity
    {
        internal WageDollarHistory(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mWageDollarHistoryID;
        public int? WageDollarHistoryID
        {
            get { return mWageDollarHistoryID; }
            set
            {
                mWageDollarHistoryID = value;
                NotifyPropertyChanged("WageDollarHistoryID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("WageDollarHistoryID", WageDollarHistoryID);
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

        private int? mPayrollYear;
        public int? PayrollYear
        {
            get { return mPayrollYear; }
            set
            {
                mPayrollYear = value;
                NotifyPropertyChanged("PayrollYear");
            }
        }

        private double mDollars;
        public double Dollars
        {
            get { return mDollars; }
            set
            {
                mDollars = value;
                NotifyPropertyChanged("Dollars");
            }
        }

        #region Wage
        private Wage mWage=null;
        public Wage Wage
        {
            get
            {
                if (mWage == null) mWage = (Wage)BuildProperty(this, "Wage");
                return mWage;
            }
            set
            {
                mWage = value;
                NotifyPropertyChanged("Wage");
            }
        }
        private int? mWageID;
        public int? WageID
        {
            get
            {
                if (mWage != null) return mWage.WageID;
                return mWageID;
            }
            set
            {
                mWageID = value;
                NotifyPropertyChanged("WageID");
            }
        }
        #endregion

        #region Card
        private Cards.Card mCard = null;
        public Cards.Card Card
        {
            get
            {
                if (mCard == null) mCard = (Cards.Card)BuildProperty(this, "Card");
                return mCard;
            }
            set
            {
                mCard = value;
                NotifyPropertyChanged("Card");
            }
        }
        private int? mCardRecordID;
        public int? CardRecordID
        {
            get
            {
                if (mCard != null) return mCard.CardRecordID;
                return mCardRecordID;
            }
            set
            {
                mCardRecordID = value;
                NotifyPropertyChanged("CardRecordID");
            }
        }
        #endregion

    }

}
