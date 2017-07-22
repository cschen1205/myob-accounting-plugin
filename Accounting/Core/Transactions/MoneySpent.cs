using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Transactions
{
    public class MoneySpent : Entity
    {
        internal MoneySpent(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mMoneySpentID;
        public int? MoneySpentID
        {
            get { return mMoneySpentID; }
            set
            {
                mMoneySpentID = value;
                NotifyPropertyChanged("MoneySpentID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("MoneySpentID", MoneySpentID);
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
        private Accounts.Account mIssuingAccount=null;
        public Accounts.Account IssuingAccount
        {
            get
            {
                if (mIssuingAccount == null)
                {
                    mIssuingAccount = (Accounts.Account)BuildProperty(this, "IssuingAccount");
                }
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
                if (mIssuingAccount != null)
                {
                    return mIssuingAccount.AccountID;
                }
                return mIssuingAccountID;
            }
            set
            {
                mIssuingAccountID = value;
                NotifyPropertyChanged("IssuingAccountID");
            }
        }
        #endregion

        private double mTotalSpentAmount;
        public double TotalSpentAmount
        {
            get { return mTotalSpentAmount; }
            set
            {
                mTotalSpentAmount = value;
                NotifyPropertyChanged("TotalSpentAmount");
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

        private string mStatementParticulars = "";
        public string StatementParticulars
        {
            get { return mStatementParticulars; }
            set
            {
                mStatementParticulars = value;
                NotifyPropertyChanged("StatementParticulars");
            }
        }

        private string mStatementCode = "";
        public string StatementCode
        {
            get { return mStatementCode; }
            set
            {
                mStatementCode = value;
                NotifyPropertyChanged("StatementCode");
            }
        }

        private string mStatementReference = "";
        public string StatementReference
        {
            get { return mStatementReference; }
            set
            {
                mStatementReference = value;
                NotifyPropertyChanged("StatementReference");
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

        #region PaymentStatus
        private Definitions.DepositStatus mPaymentStatus = null;
        public Definitions.DepositStatus PaymentStatus
        {
            get
            {
                if (mPaymentStatus == null)
                {
                    mPaymentStatus = (Definitions.DepositStatus)BuildProperty(this, "PaymentStatus");
                }
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
                if (mPaymentStatus != null)
                {
                    return mPaymentStatus.DepositStatusID;
                }
                return mPaymentStatusID;
            }
            set
            {
                mPaymentStatusID = value;
                NotifyPropertyChanged("PaymentStatusID");
            }
        }
        #endregion

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

        #region PaymentDelivery
        private Definitions.InvoiceDelivery mPaymentDelivery=null;
        public Definitions.InvoiceDelivery PaymentDelivery
        {
            get
            {
                if (mPaymentDelivery == null)
                {
                    mPaymentDelivery = (Definitions.InvoiceDelivery)BuildProperty(this, "PaymentDelivery");
                }
                return mPaymentDelivery;
            }
            set
            {
                mPaymentDelivery = value;
                NotifyPropertyChanged("PaymentDelivery");
            }
        }
        private string mPaymentDeliveryID;
        public string PaymentDeliveryID
        {
            get
            {
                if (mPaymentDelivery != null)
                {
                    return mPaymentDelivery.InvoiceDeliveryID;
                }
                return mPaymentDeliveryID;
            }
            set
            {
                mPaymentDeliveryID = value;
                NotifyPropertyChanged("PaymentDeliveryID");
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
