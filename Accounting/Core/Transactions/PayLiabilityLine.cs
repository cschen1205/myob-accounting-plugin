using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Transactions
{
    public class PayLiabilityLine : Entity
    {
        internal PayLiabilityLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mPayLiabilityLineID;
        public int? PayLiabilityLineID
        {
            get { return mPayLiabilityLineID; }
            set
            {
                mPayLiabilityLineID = value;
                NotifyPropertyChanged("PayLiabilityLineID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("PayLiabilityLineID", PayLiabilityLineID);
            }
        }

        #region PayLiability
        private PayLiability mPayLiability=null;
        public PayLiability PayLiability
        {
            get
            {
                if(mPayLiability == null) mPayLiability=(PayLiability)BuildProperty(this, "PayLiability");
                return mPayLiability;
            }
            set
            {
                mPayLiability=value;
                NotifyPropertyChanged("PayLiability");
            }
        }
        private int? mPayLiabilitiesID;
        public int? PayLiabilitiesID
        {
            get
            {
                if(mPayLiability != null) return mPayLiability.PayLiabilityID;
                return mPayLiabilitiesID;
            }
            set
            {
                mPayLiabilitiesID=value;
                NotifyPropertyChanged("PayLiabilitiesID");
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

        private int? mCategoryID;
        public int? CategoryID
        {
            get { return mCategoryID; }
            set
            {
                mCategoryID = value;
                NotifyPropertyChanged("CategoryID");
            }
        }

        #region CategoryType
        private Definitions.CategoryType mCategoryType;
        public Definitions.CategoryType CategoryType
        {
            get
            {
                if (mCategoryType == null) mCategoryType = (Definitions.CategoryType)BuildProperty(this, "CategoryType");
                return mCategoryType;
            }
            set
            {
                mCategoryType = value;
                NotifyPropertyChanged("CategoryType");
            }
        }
        private string mCategoryTypeID;
        public string CategoryTypeID
        {
            get
            {
                if (mCategoryType != null) return mCategoryType.CategoryTypeID;
                return mCategoryTypeID;
            }
            set
            {
                mCategoryTypeID = value;
                NotifyPropertyChanged("CategoryTypeID");
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
                NotifyPropertyChanged("PaymentStatusID");
            }
        }
        #endregion
    }
}
