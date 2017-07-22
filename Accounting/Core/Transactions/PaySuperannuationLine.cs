using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Transactions
{
    public class PaySuperannuationLine : Entity
    {
        internal PaySuperannuationLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mPaySuperannuationLineID;
        public int? PaySuperannuationLineID
        {
            get { return mPaySuperannuationLineID; }
            set
            {
                mPaySuperannuationLineID = value;
                NotifyPropertyChanged("PaySuperannuationLineID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("PaySuperannuationLineID", PaySuperannuationLineID);
            }
        }

        #region PaySuperannuation
        private PaySuperannuation mPaySuperannuation=null;
        public PaySuperannuation PaySuperannuation
        {
            get
            {
                if(mPaySuperannuation == null) mPaySuperannuation=(PaySuperannuation)BuildProperty(this, "PaySuperannuation");
                return mPaySuperannuation;
            }
            set
            {
                mPaySuperannuation=value;
                NotifyPropertyChanged("PaySuperannuation");
            }
        }
        private int? mPaySuperannuationID;
        public int? PaySuperannuationID
        {
            get
            {
                if(mPaySuperannuation != null) return mPaySuperannuation.PaySuperannuationID;
                return mPaySuperannuationID;
            }
            set
            {
                mPaySuperannuationID=value;
                NotifyPropertyChanged("PaySuperannuationID");
            }
        }
        #endregion

        private int? mLineNumber;
        public int? LineNumber
        {
            get { return mLineNumber; }
            set
            {
                mLineNumber = value;
                NotifyPropertyChanged("LineNumber");
            }
        }

        #region SourceLine
        private WritePaychequeLine mSourceLine = null;
        public WritePaychequeLine SourceLine
        {
            get
            {
                if (mSourceLine == null) mSourceLine = (WritePaychequeLine)BuildProperty(this, "SourceLine");
                return mSourceLine;
            }
            set
            {
                mSourceLine = value;
                NotifyPropertyChanged("SourceLine");
            }
        }
        private int? mSourceLineID;
        public int? SourceLineID
        {
            get
            {
                if (mSourceLine != null) return mSourceLine.WritePaychequeLineID;
                return mSourceLineID;
            }
            set
            {
                mSourceLineID = value;
                NotifyPropertyChanged("SourceLineID");
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

      

        #region SuperannuationFund;
        private Payroll.SuperannuationFund mSuperannuationFund = null;
        public Payroll.SuperannuationFund SuperannuationFund
        {
            get
            {
                if (mSuperannuationFund == null) mSuperannuationFund = (Payroll.SuperannuationFund)BuildProperty(this, "SuperannuationFund");
                return mSuperannuationFund;
            }
            set
            {
                mSuperannuationFund = value;
                NotifyPropertyChanged("SuperannuationFund");
            }
        }
        private int? mSuperannuationFundID;
        public int? SuperannuationFundID
        {
            get
            {
                if (mSuperannuationFund != null) return mSuperannuationFund.SuperannuationFundID;
                return mSuperannuationFundID;
            }
            set
            {
                mSuperannuationFundID = value;
                NotifyPropertyChanged("SuperannuationFundID");
            }
        }
        #endregion

        private double mAmountPaid;
        public double AmountPaid
        {
            get { return mAmountPaid; }
            set
            {
                mAmountPaid = value;
                NotifyPropertyChanged("AmountPaid");
            }
        }

        #region PaymentStatus
        private Definitions.DepositStatus mPaymentStatus = null;
        public Definitions.DepositStatus PaymentStatus
        {
            get
            {
                if (mPaymentStatus == null) mPaymentStatus = (Definitions.DepositStatus)BuildProperty(this, "PaymentStatus");
                return mPaymentStatus;
            }
            set
            {
                mPaymentStatus = value;
                NotifyPropertyChanged("PaymentStatus");
            }
        }
        private string mPaymentStatusID;
        public string PaymentStatusID
        {
            get
            {
                if (mPaymentStatus != null) return mPaymentStatus.DepositStatusID;
                return mPaymentStatusID;
            }
            set
            {
                mPaymentStatusID = value;
                NotifyPropertyChanged("PaymentStatus");
            }
        }
        #endregion
    }
}
