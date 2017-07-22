using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Cards
{
    public class CardActivity : Entity
    {
        internal CardActivity(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mCardActivityID;
        public int? CardActivityID
        {
            get { return mCardActivityID; }
            set
            {
                mCardActivityID = value;
                NotifyPropertyChanged("CardActivityID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("CardActivityID", CardActivityID);
            }
        }

        #region Card
        private Card mCard = null;
        public Card Card
        {
            get
            {
                if (mCard == null)
                {
                    mCard = (Card)BuildProperty(this, "Card");
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

        private double mDollarsSold;
        public double DollarsSold
        {
            get { return mDollarsSold; }
            set
            {
                mDollarsSold = value;
                NotifyPropertyChanged("DollarsSold");
            }
        }

    }
}
