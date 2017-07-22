using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Sales
{
    public class CreditRefund : Entity
    {
        internal CreditRefund(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mCreditRefundID;
        public int? CreditRefundID
        {
            get { return mCreditRefundID; }
            set
            {
                mCreditRefundID = value;
                NotifyPropertyChanged("CreditRefundID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("CreditRefundID", CreditRefundID);
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

        private double mAmountRefunded;
        public double AmountRefunded
        {
            get { return mAmountRefunded; }
            set
            {
                mAmountRefunded = value;
                NotifyPropertyChanged("AmountRefunded");
            }
        }

        #region CreditNote
        private Sale mCreditNote = null;
        public Sale CreditNote
        {
            get
            {
                if (mCreditNote == null)
                {
                    mCreditNote = (Sale)BuildProperty(this, "CreditNote");
                }
                return mCreditNote;
            }
            set
            {
                mCreditNote = value;
                NotifyPropertyChanged("CreditNote");
            }
        }
        private int? mCreditNoteID;
        public int? CreditNoteID
        {
            get
            {
                if (mCreditNote != null)
                {
                    return mCreditNote.SaleID;
                }
                return mCreditNoteID;
            }
            set
            {
                mCreditNoteID = value;
                NotifyPropertyChanged("CreditNoteID");
            }
        }
        #endregion

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
                    mCard = (Cards.Card)BuildProperty(this, "Card");
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
            get
            {
                return mPayee;
            }
            set
            {
                mPayee = value;
                NotifyPropertyChanged("Payee");
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

    }
}
