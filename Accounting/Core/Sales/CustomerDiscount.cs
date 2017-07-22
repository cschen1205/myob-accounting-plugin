using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Sales
{
    public class CustomerDiscount : Entity
    {
        internal CustomerDiscount(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mCustomerDiscountID;
        public int? CustomerDiscountID
        {
            get { return mCustomerDiscountID; }
            set
            {
                mCustomerDiscountID = value;
                NotifyPropertyChanged("CustomerDiscountID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("CustomerDiscountID", CustomerDiscountID);
            }
        }

        private string mCustomerDiscountNumber = "";
        public string CustomerDiscountNumber
        {
            get { return mCustomerDiscountNumber; }
            set
            {
                mCustomerDiscountNumber = value;
                NotifyPropertyChanged("CustomerDiscountNumber");
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
            set { 
            mTransactionDate=value;
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

        private double mExchangeGainLoss;
        public double ExchangeGainLoss
        {
            get { return mExchangeGainLoss; }
            set
            {
                mExchangeGainLoss = value;
                NotifyPropertyChanged("ExchangeGainLoss");
            }
        }

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

        private string mPaymentExpirationDate = "";
        public string PaymentExpirationDate
        {
            get { return mPaymentExpirationDate; }
            set
            {
                mPaymentExpirationDate = value;
                NotifyPropertyChanged("PaymentExpirationDate");
            }
        }

        private string mPaymentAuthorisationNumber = "";
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

        private string mMemo = "";
        public string Memo
        {
            get { return mMemo; }
            set
            {
                mMemo = value;
                NotifyPropertyChanged("Memo");
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

        private double mTransactionExchangeRate;
        public double TransactionExchangeRate
        {
            get
            {
                return mTransactionExchangeRate;
            }
            set
            {
                mTransactionExchangeRate = value;
                NotifyPropertyChanged("TransactionExchangeRate");
            }
        }

        #region DiscountAccount
        private Accounts.Account mDiscountAccount = null;
        public Accounts.Account DiscountAccount
        {
            get
            {
                if (mDiscountAccount == null)
                {
                    mDiscountAccount = (Accounts.Account)BuildProperty(this, "DiscountAccount");
                }
                return mDiscountAccount;
            }
            set
            {
                mDiscountAccount = value;
                NotifyPropertyChanged("DiscountAccount");
            }
        }
        private int? mDiscountAccountID;
        public int? DiscountAccountID
        {
            get
            {
                if (mDiscountAccount != null)
                {
                    return mDiscountAccount.AccountID;
                }
                return mDiscountAccountID;
            }
            set
            {
                mDiscountAccountID = value;
                NotifyPropertyChanged("DiscountAccountID");
            }
        }
        #endregion

        private double mTotalDiscount;
        public double TotalDiscount
        {
            get { return mTotalDiscount; }
            set
            {
                mTotalDiscount = value;
                NotifyPropertyChanged("TotalDiscount");
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

     

    }
}
