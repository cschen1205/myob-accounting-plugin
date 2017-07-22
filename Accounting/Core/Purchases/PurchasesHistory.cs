using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Purchases
{
    public class PurchasesHistory : Entity
    {
        internal PurchasesHistory(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mPurchasesHistoryID;
        public int? PurchasesHistoryID
        {
            get { return mPurchasesHistoryID; }
            set
            {
                mPurchasesHistoryID = value;
                NotifyPropertyChanged("PurchasesHistoryID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("PurchasesHistoryID", PurchasesHistoryID);
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

        private double mPurchaseAmount;
        public double PurchaseAmount
        {
            get { return mPurchaseAmount; }
            set
            {
                mPurchaseAmount = value;
                NotifyPropertyChanged("PurchaseAmount");
            }
        }
    }
}
