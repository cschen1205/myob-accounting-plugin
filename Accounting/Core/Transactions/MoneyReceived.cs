using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Transactions
{
    public class MoneyReceived : Entity
    {
        internal MoneyReceived(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mMoneyReceivedID;
        public int? MoneyReceivedID
        {
            get { return mMoneyReceivedID; }
            set
            {
                mMoneyReceivedID = value;
                NotifyPropertyChanged("MoneyReceivedID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("MoneyReceivedID", MoneyReceivedID);
            }
        }

        private string mDepositNumber = "";
        public string DepositNumber
        {
            get { return mDepositNumber; }
            set
            {
                mDepositNumber = value;
                NotifyPropertyChanged("DepositNumber");
            }
        }

        private DateTime? mDate;
        public DateTime? Date
        {
            get { return mDate; }
            set
            {
                mDate = value;
                NotifyPropertyChanged("Date");
            }
        }

        private DateTime? mTransactionDate;
        public DateTime? TransactionDate
        {
            get { return mTransactionDate; }
            set
            {
                mTransactionDate = value;
                NotifyPropertyChanged("TransactionDate");
            }
        }

        private string mIsThirteenthPeriod = "N";
        public string IsThirteenthPeriod
        {
            get { return mIsThirteenthPeriod; }
            set
            {
                mIsThirteenthPeriod = value;
                NotifyPropertyChanged("IsThirteenthPeriod");
            }
        }

        private double mTransactionExchangeRate;
        public double TransactionExchangeRate
        {
            get { return mTransactionExchangeRate; }
            set
            {
                mTransactionExchangeRate = value;
                NotifyPropertyChanged("TransactionExchangeRate");
            }
        }

        #region RecipientAccount
        private Accounts.Account mRecipientAccount = null;
        public Accounts.Account RecipientAccount
        {
            get
            {
                if (mRecipientAccount == null)
                {
                    mRecipientAccount = (Accounts.Account)BuildProperty(this, "RecipientAccount");
                }
                return mRecipientAccount;
            }
            set
            {
                mRecipientAccount = value;
                NotifyPropertyChanged("RecipientAccount");
            }
        }
        private int? mRecipientAccountID;
        public int? RecipientAccountID
        {
            get
            {
                if (mRecipientAccount != null)
                {
                    return mRecipientAccount.AccountID;
                }
                return mRecipientAccountID;
            }
            set
            {
                mRecipientAccountID = value;
                NotifyPropertyChanged("RecipientAccountID");
            }
        }
        #endregion

        #region MethodOfPayment
        private Misc.PaymentMethod mMethodOfPayment = null;
        public Misc.PaymentMethod MethodOfPayment
        {
            get
            {
                if (mMethodOfPayment == null)
                {
                    mMethodOfPayment = (Misc.PaymentMethod)BuildProperty(this, "MethodOfPayment");
                }
                return mMethodOfPayment;
            }
            set
            {
                mMethodOfPayment = value;
                NotifyPropertyChanged("MethodOfPayment");
            }
        }
        private int? mMethodOfPaymentID;
        public int? MethodOfPaymentID
        {
            get
            {
                if (mMethodOfPayment != null)
                {
                    return mMethodOfPayment.PaymentMethodID;
                }
                return mMethodOfPaymentID;
            }
            set
            {
                mMethodOfPaymentID = value;
                NotifyPropertyChanged("MethodOfPaymentID");
            }
        }
        #endregion

        private string mPaymentCardNumber = "";
        public string PaymentCardNumber
        {
            get { return mPaymentCardNumber; }
            set
            {
                mPaymentCardNumber = value;
                NotifyPropertyChanged("PaymentCardNumber");
            }
        }

        private string mPaymentNameOnCard = "";
        public string PaymentNameOnCard
        {
            get { return mPaymentNameOnCard; }
            set
            {
                mPaymentNameOnCard = value;
                NotifyPropertyChanged("PaymentNameOnCard");
            }
        }

        private string mPaymentExpirationDate;
        public string PaymentExpirationDate
        {
            get { return mPaymentExpirationDate; }
            set
            {
                mPaymentExpirationDate = value;
                NotifyPropertyChanged("PaymentExpirationDate");
            }
        }

        private string mPaymentAuthorisationNumber="";
        public string PaymentAuthorisationNumber
        {
            get { return mPaymentAuthorisationNumber; }
            set
            {
                mPaymentAuthorisationNumber = value;
                NotifyPropertyChanged("PaymentAuthorisationNumber");
            }
        }

        private string mPaymentBSB = "";
        public string PaymentBSB
        {
            get { return mPaymentBSB; }
            set
            {
                mPaymentBSB = value;
                NotifyPropertyChanged("PaymentBSB");
            }
        }

        private string mPaymentBankAccountNumber = "";
        public string PaymentBankAccountNumber
        {
            get { return mPaymentBankAccountNumber; }
            set
            {
                mPaymentBankAccountNumber = value;
                NotifyPropertyChanged("PaymentBankAccountNumber");
            }
        }

        private string mPaymentBankAccountName = "";
        public string PaymentBankAccountName
        {
            get { return mPaymentBankAccountName; }
            set
            {
                mPaymentBankAccountName = value;
                NotifyPropertyChanged("PaymentBankAccountName");
            }
        }

        private string mPaymentBankBranch = "";
        public string PaymentBankBranch
        {
            get { return mPaymentBankBranch; }
            set
            {
                mPaymentBankBranch = value;
                NotifyPropertyChanged("PaymentBankBranch");
            }
        }

        private string mPaymentChequeNumber = "";
        public string PaymentChequeNumber
        {
            get { return mPaymentChequeNumber; }
            set
            {
                mPaymentChequeNumber = value;
                NotifyPropertyChanged("PaymentChequeNumber");
            }
        }

        private string mPaymentNotes = "";
        public string PaymentNotes
        {
            get { return mPaymentNotes; }
            set
            {
                mPaymentNotes = value;
                NotifyPropertyChanged("PaymentNotes");
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

        private string mMemo="";
        public string Memo
        {
            get { return mMemo; }
            set
            {
                mMemo = value;
                NotifyPropertyChanged("Memo");
            }
        }

        private string mIsTaxInclusive = "N";
        public string IsTaxInclusive
        {
            get { return mIsTaxInclusive; }
            set
            {
                mIsTaxInclusive = value;
                NotifyPropertyChanged("IsTaxInclusive");
            }
        }

        private string mIsAutoRecorded = "N";
        public string IsAutoRecorded
        {
            get { return mIsAutoRecorded; }
            set
            {
                mIsAutoRecorded = value;
                NotifyPropertyChanged("IsAutoRecorded");
            }
        }

        #region Currency
        private Currencies.Currency mCurrency = null;
        public Currencies.Currency Currency
        {
            get
            {
                if (mCurrency == null)
                {
                    mCurrency = (Currencies.Currency)BuildProperty(this, "Currency");
                }
                return mCurrency;
            }
            set
            {
                mCurrency = value;
                NotifyPropertyChanged("Currency");
            }
        }
        private int? mCurrencyID;
        public int? CurrencyID
        {
            get
            {
                if (mCurrency != null)
                {
                    return mCurrency.CurrencyID;
                }
                return mCurrencyID;
            }
            set
            {
                mCurrencyID = value;
                NotifyPropertyChanged("CurrencyID");
            }
        }
        #endregion

        #region DepositStatus
        private Definitions.DepositStatus mDepositStatus = null;
        public Definitions.DepositStatus DepositStatus
        {
            get
            {
                if (mDepositStatus == null)
                {
                    mDepositStatus = (Definitions.DepositStatus)BuildProperty(this, "DepositStatus");
                }
                return mDepositStatus;
            }
            set
            {
                mDepositStatus = value;
                NotifyPropertyChanged("DepositStatus");
            }
        }
        private string mDepositStatusID;
        public string DepositStatusID
        {
            get
            {
                if (mDepositStatus != null)
                {
                    return mDepositStatus.DepositStatusID;
                }
                return mDepositStatusID;
            }
            set
            {
                mDepositStatusID = value;
                NotifyPropertyChanged("DepositStatusID");
            }
        }
        #endregion

        private int? mCostCentreID;
        public int? CostCentreID
        {
            get { return mCostCentreID; }
            set
            {
                mCostCentreID = value;
                NotifyPropertyChanged("CostCentreID");
            }
        }

    }
}
