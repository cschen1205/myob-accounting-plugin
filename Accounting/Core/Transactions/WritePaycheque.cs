using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Transactions
{
    public class WritePaycheque : Entity
    {
        internal WritePaycheque(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        

        private int? mWritePaychequeID;
        public int? WritePaychequeID
        {
            get { return mWritePaychequeID; }
            set
            {
                mWritePaychequeID = value;
                NotifyPropertyChanged("WritePaychequeID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("WritePaychequeID", WritePaychequeID);
            }
        }

        private string mChequeNumber = "";
        public string ChequeNumber
        {
            get { return mChequeNumber; }
            set
            {
                mChequeNumber = value;
                NotifyPropertyChanged("ChequeNumber");
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

        #region IssuingAccount
        private Accounts.Account mIssuingAccount = null;
        public Accounts.Account IssuingAccount
        {
            get
            {
                if (mIssuingAccount == null) mIssuingAccount = (Accounts.Account)BuildProperty(this, "IssuingAccount");
                return mIssuingAccount;
            }
            set
            {
                mIssuingAccount = value;
                NotifyPropertyChanged("IssuingAccount");
            }
        }
        private int? mIssuingAccountID;
        public int? IssuingAccountID
        {
            get
            {
                if (mIssuingAccount != null) return mIssuingAccount.AccountID;
                return mIssuingAccountID;
            }
            set
            {
                mIssuingAccountID = value;
                NotifyPropertyChanged("IssuingAccountID");
            }
        }
        #endregion

        private double mNetPay;
        public double NetPay
        {
            get { return mNetPay; }
            set
            {
                mNetPay = value;
                NotifyPropertyChanged("NetPay");
            }
        }

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

        private string mPayee = "";
        public string Payee
        {
            get { return mPayee; }
            set
            {
                mPayee = value;
                NotifyPropertyChanged("Payee");
            }
        }

        #region PaymentType
        private Definitions.PaymentType mPaymentType = null;
        public Definitions.PaymentType PaymentType
        {
            get
            {
                if (mPaymentType == null) mPaymentType = (Definitions.PaymentType)BuildProperty(this, "PaymentType");
                return mPaymentType;
            }
            set
            {
                mPaymentType = value;
                NotifyPropertyChanged("PaymentType");
            }
        }
        private string mPaymentTypeID;
        public string PaymentTypeID
        {
            get
            {
                if (mPaymentType != null) return mPaymentType.PaymentTypeID;
                return mPaymentTypeID;
            }
            set
            {
                mPaymentTypeID = value;
                NotifyPropertyChanged("PaymentTypeID");
            }
        }
        #endregion


        #region BankingDetails
        private Payroll.BankingDetail mBankingDetails = null;
        public Payroll.BankingDetail BankingDetails
        {
            get
            {
                if (mBankingDetails == null) mBankingDetails = (Payroll.BankingDetail)BuildProperty(this, "BankingDetails");
                return mBankingDetails;
            }
            set
            {
                mBankingDetails = value;
                NotifyPropertyChanged("BankingDetails");
            }
        }
        private int? mBankingDetailsID;
        public int? BankingDetailsID
        {
            get
            {
                if (mBankingDetails != null) return mBankingDetails.BankingDetailID;
                return mBankingDetailsID;
            }
            set
            {
                mBankingDetailsID = value;
                NotifyPropertyChanged("BankingDetailsID");
            }
        }
        #endregion

        private DateTime? mPayPeriodStartDate;
        public DateTime? PayPeriodStartDate
        {
            get { return mPayPeriodStartDate; }
            set
            {
                mPayPeriodStartDate = value;
                NotifyPropertyChanged("PayPeriodStartDate");
            }
        }

        private DateTime? mPayPeriodEndingDate;
        public DateTime? PayPeriodEndingDate
        {
            get { return mPayPeriodEndingDate; }
            set
            {
                mPayPeriodEndingDate = value;
                NotifyPropertyChanged("PayPeriodEndingDate");
            }
        }

        private double mNumberOfPayPeriods;
        public double NumberOfPayPeriods
        {
            get { return mNumberOfPayPeriods; }
            set
            {
                mNumberOfPayPeriods = value;
                NotifyPropertyChanged("NumberOfPayPeriods");
            }
        }

        private string mPayeeLine1 = "";
        public string PayeeLine1
        {
            get { return mPayeeLine1; }
            set
            {
                mPayeeLine1 = value;
                NotifyPropertyChanged("PayeeLine1");
            }
        }

        private string mPayeeLine2 = "";
        public string PayeeLine2
        {
            get { return mPayeeLine2; }
            set
            {
                mPayeeLine2 = value;
                NotifyPropertyChanged("PayeeLine2");
            }
        }

        private string mPayeeLine3 = "";
        public string PayeeLine3
        {
            get { return mPayeeLine3; }
            set
            {
                mPayeeLine3 = value;
                NotifyPropertyChanged("PayeeLine3");
            }
        }

        private string mPayeeLine4 = "";
        public string PayeeLine4
        {
            get { return mPayeeLine4; }
            set
            {
                mPayeeLine4 = value;
                NotifyPropertyChanged("PayeeLine4");
            }
        }

        private string mStatementText = "";
        public string StatementText
        {
            get { return mStatementText; }
            set
            {
                mStatementText = value;
                NotifyPropertyChanged("StatementText");
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

        private string mIsPrinted = "N";
        public string IsPrinted
        {
            get { return mIsPrinted; }
            set
            {
                mIsPrinted = value;
                NotifyPropertyChanged("IsPrinted");
            }
        }

        #region Currency
        private Currencies.Currency mCurrency = null;
        public Currencies.Currency Currency
        {
            get
            {
                if (mCurrency == null) mCurrency = (Currencies.Currency)BuildProperty(this, "Currency");
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
                if (mCurrency != null) return mCurrency.CurrencyID;
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
            get { return mTransactionExchangeRate; }
            set
            {
                mTransactionExchangeRate = value;
                NotifyPropertyChanged("TransactionExchangeRate");
            }
        }

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
