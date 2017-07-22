using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Sales
{
    public class SalesHistory : Entity
    {
        internal SalesHistory(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mSalesHistoryID;
        public int? SalesHistoryID
        {
            get { return mSalesHistoryID; }
            set
            {
                mSalesHistoryID = value;
                NotifyPropertyChanged("SalesHistoryID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("SalesHistoryID", SalesHistoryID);
            }
        }

        #region Card
        private Cards.Card mCard = null;
        public Cards.Card Card
        {
            get
            {
                if (mCard == null)
                {
                    mCard = (Cards.Card)BuildProperty(this, "Card");
                }
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
                if (mCard != null)
                {
                    return mCard.CardRecordID;
                }
                return mCardRecordID;
            }
            set
            {
                mCardRecordID = value;
                NotifyPropertyChanged("CardRecordID");
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
    }
}
