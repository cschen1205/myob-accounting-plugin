using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.TaxCodes;
using Accounting.Core.Misc;

namespace Accounting.Core.Cards
{
    public class Customer : Cards.Card
    {
        
        #region Terms
        private int? mTermsID;
        public int? TermsID
        {
            set {

                mTermsID = value; NotifyPropertyChanged("TermsID"); 
            }
            get {
                if (mTerms != null)
                {
                    return mTerms.TermsID;
                }
                return mTermsID; }
        }
        private Terms.Terms mTerms;
        public Terms.Terms Terms
        {
            get 
            {
                if (mTerms == null)
                {
                    mTerms = (Terms.Terms)BuildProperty(this, "Terms");
                }
                return mTerms; 
            }
            set
            {
                mTerms = value;
                NotifyPropertyChanged("Terms");
            }
        }
        #endregion

        #region CurrentBalance
        private double mCurrentBalance;
        public double CurrentBalance
        {
            get { return mCurrentBalance; }
            set { mCurrentBalance = value; NotifyPropertyChanged("CurrentBalance");  }
        }
        #endregion

        #region SaleComment
        private int? mSaleCommentID;
        public int? SaleCommentID
        {
            set { mSaleCommentID = value; NotifyPropertyChanged("SaleCommentID");  }
            get {
                if (mSaleComment != null)
                {
                    return mSaleComment.CommentID;
                }
                return mSaleCommentID; }
        }
        private Misc.Comment mSaleComment;
        public Misc.Comment SaleComment
        {
            get 
            {
                if (mSaleComment == null)
                {
                    mSaleComment = (Misc.Comment)BuildProperty(this, "SaleComment");
                }
                return mSaleComment; 
            }
            set
            {
                mSaleComment = value;
                NotifyPropertyChanged("SaleComment");
            }
        }
        #endregion

        #region SaleLayout
        private string mSaleLayoutID;
        public string SaleLayoutID
        {
            get {
                if (mSaleLayout != null)
                {
                    return mSaleLayout.InvoiceTypeID;
                }
                return mSaleLayoutID; }
            set { mSaleLayoutID = value; NotifyPropertyChanged("SaleLayoutID");  }
        }
        Definitions.InvoiceType mSaleLayout;
        public Definitions.InvoiceType SaleLayout
        {
            get 
            {
                if (mSaleLayout == null)
                {
                    mSaleLayout = (Definitions.InvoiceType)BuildProperty(this, "SaleLayout");
                }
                return mSaleLayout; 
            }
            set
            {
                mSaleLayout = value;
                NotifyPropertyChanged("SaleLayout");
            }
        }
        #endregion

        #region InvoiceDelivery
        private string mInvoiceDeliveryID;
        public string InvoiceDeliveryID
        {
            get {
                if (mInvoiceDelivery != null)
                {
                    return mInvoiceDelivery.InvoiceDeliveryID;
                }
                return mInvoiceDeliveryID; }
            set { mInvoiceDeliveryID = value; NotifyPropertyChanged("InvoiceDeliveryID");  }
        }
        Definitions.InvoiceDelivery mInvoiceDelivery;
        public Definitions.InvoiceDelivery InvoiceDelivery
        {
            get 
            {
                if (mInvoiceDelivery == null)
                {
                    mInvoiceDelivery = (Definitions.InvoiceDelivery)BuildProperty(this, "InvoiceDelivery");
                }
                return mInvoiceDelivery; 
            }
            set
            {
                mInvoiceDelivery = value;
                NotifyPropertyChanged("InvoiceDelivery");
            }
        }
        #endregion

        #region TaxCode
        private int? mTaxCodeID;
        public int? TaxCodeID
        {
            set { mTaxCodeID = value; NotifyPropertyChanged("TaxCodeID");  }
            get {
                if (mTaxCode != null)
                {
                    return mTaxCode.TaxCodeID;
                }
                return mTaxCodeID; }
        }
        TaxCodes.TaxCode mTaxCode = null;
        public TaxCodes.TaxCode TaxCode
        {
            get 
            {
                if (mTaxCode == null)
                {
                    mTaxCode = (TaxCodes.TaxCode)BuildProperty(this, "TaxCode");
                }
                return mTaxCode; 
            }
            set
            {
                mTaxCode = value;
                NotifyPropertyChanged("TaxCode");
            }
        }
        #endregion

        #region SalesPerson
        private int? mSalespersonID;
        public int? SalespersonID
        {
            get {
                if (mSalesPerson != null)
                {
                    return mSalesPerson.CardRecordID;
                }
                
                return mSalespersonID; }
            set { mSalespersonID = value; NotifyPropertyChanged("SalespersonID");  }
        }
        private Cards.Employee mSalesPerson;
        public Cards.Employee SalesPerson
        {
            get 
            {
                if (mSalesPerson == null)
                {
                    mSalesPerson = (Cards.Employee)BuildProperty(this, "SalesPerson");
                }
                return mSalesPerson; 
            }
            set
            {
                mSalesPerson = value;
                NotifyPropertyChanged("SalesPerson");
            }
        }
        #endregion

        #region ShippingMethod
        private int? mShippingMethodID;
        public int? ShippingMethodID
        {
            get 
            {
                if (mShippingMethod != null)
                {
                    return mShippingMethod.ShippingMethodID;
                }
                return mShippingMethodID; 
            }
            set 
            { 
                mShippingMethodID = value;
                NotifyPropertyChanged("ShippingMethodID");
            }
        }
        private ShippingMethods.ShippingMethod mShippingMethod;
        public ShippingMethods.ShippingMethod ShippingMethod
        {
            get 
            {
                if (mShippingMethod == null)
                {
                    mShippingMethod = (ShippingMethods.ShippingMethod)BuildProperty(this, "ShippingMethod");
                }
                return mShippingMethod; 
            }
            set
            {
                mShippingMethod = value;
                NotifyPropertyChanged("ShippingMethod");
            }
        }
        #endregion

        #region OnHold
        private string mOnHold="N";
        public string OnHold
        {
            get { return mOnHold; }
            set 
            { 
                mOnHold = value;
                NotifyPropertyChanged("OnHold");
            }
        }
        #endregion

        #region FreightTaxCode
        private int? mFreightTaxCodeID;
        public int? FreightTaxCodeID
        {
            get 
            {
                if (mFreightTaxCode != null)
                {
                    return mFreightTaxCode.TaxCodeID;
                }
                return mFreightTaxCodeID; 
            }
            set 
            { 
                mFreightTaxCodeID = value;
                NotifyPropertyChanged("FreightTaxCodeID");
            }
        }
        private TaxCode mFreightTaxCode;
        public TaxCode FreightTaxCode
        {
            get 
            {
                if (mFreightTaxCode == null)
                {
                    mFreightTaxCode = (TaxCodes.TaxCode)BuildProperty(this, "FreightTaxCode");
                }
                return mFreightTaxCode; 
            }
            set
            {
                mFreightTaxCode = value;
                NotifyPropertyChanged("FreightTaxCode");
            }
        }
        #endregion

        #region -(Constructor)
        internal Customer(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {

        }
        #endregion

        #region -PriceLevel
        private string mPriceLevelID;
        public string PriceLevelID
        {
            get
            {
                if (mPriceLevel != null)
                {
                    return mPriceLevel.PriceLevelID;
                }
                return mPriceLevelID;
            }
            set
            {
                mPriceLevelID = value;
                NotifyPropertyChanged("PriceLevelID");
            }
        }
        private Definitions.PriceLevel mPriceLevel = null;
        public Definitions.PriceLevel PriceLevel
        {
            get
            {
                if (mPriceLevel == null)
                {
                    mPriceLevel = (Definitions.PriceLevel)BuildProperty(this, "PriceLevel");
                }
                return mPriceLevel;
            }
            set
            {
                mPriceLevel = value;
                NotifyPropertyChanged("PriceLevel");
            }
        }
        #endregion


        #region CustomerID
        private int? mCustomerID;
        public int? CustomerID
        {
            get { return mCustomerID; }
            set 
            { 
                mCustomerID = value;
                NotifyPropertyChanged("CustomerID");
            }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("CustomerID", CustomerID);
            }
        }

        #region ReceiptMemo
        private string mReceiptMemo="";
        public string ReceiptMemo
        {
            get
            {
                return mReceiptMemo;
            }
            set
            {
                mReceiptMemo = value;
                NotifyPropertyChanged("ReceiptMemo");
            }
        }
        #endregion

        #region ABNBranch
        private string mABNBranch;
        public string ABNBranch
        {
            get { return mABNBranch; }
            set 
            { 
                mABNBranch = value;
                NotifyPropertyChanged("ABNBranch");
            }
        }
        #endregion

        #region TaxIDNumber
        private string mTaxIDNumber="";
        public string TaxIDNumber
        {
            get { return mTaxIDNumber; }
            set 
            { 
                mTaxIDNumber = value;
                NotifyPropertyChanged("TaxIDNumber");
            }
        }
        #endregion

        #region FirstName
        private string mFirstName = "";
        public string FirstName
        {
            get { return mFirstName; }
            set 
            { 
                mFirstName = value;
                NotifyPropertyChanged("FirstName");
            }
        }
        #endregion

        #region LastName
        private string mLastName = "";
        public string LastName
        {
            get { return mLastName; }
            set 
            { 
                mLastName = value;
                NotifyPropertyChanged("LastName");
            }
        }
        #endregion

        #region PaymentNotes
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
        #endregion

        #region PaymentCardNumber
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
        #endregion

        #region CustomerSince
        private DateTime? mCustomerSince;
        public DateTime? CustomerSince
        {
            get { return mCustomerSince; }
            set 
            {
                mCustomerSince = value;
                NotifyPropertyChanged("CustomerSince");
            }
        }
        #endregion

        #region LastSaleDate
        private DateTime? mLastSaleDate;
        public DateTime? LastSaleDate
        {
            get { return mLastSaleDate; }
            set 
            {
                mLastSaleDate = value;
                NotifyPropertyChanged("LastSaleDate");
            }
        }
        #endregion

        #region LastPaymentDate
        private DateTime? mLastPaymentDate;
        public DateTime? LastPaymentDate
        {
            get { return mLastPaymentDate; }
            set 
            { 
                mLastPaymentDate = value;
                NotifyPropertyChanged("LastPaymentDate");
            }
        }
        #endregion

        #region HighestInvoiceAmount
        private double mHighestInvoiceAmount;
        public double HighestInvoiceAmount
        {
            get { return mHighestInvoiceAmount; }
            set 
            { 
                mHighestInvoiceAmount = value;
                NotifyPropertyChanged("HighestInvoiceAmount");
            }
        }
        #endregion

        #region HighestReceivableAmount
        private double mHighestReceivableAmount;
        public double HighestReceivableAmount
        {
            get { return mHighestReceivableAmount; }
            set 
            { 
                mHighestReceivableAmount = value;
                NotifyPropertyChanged("HighestReceivableAmount");
            }
        }
        #endregion

        #region PaymentNameOnCard
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
        #endregion

        #region PaymentExpirationDate
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
        #endregion

        #region PaymentBSB
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
        #endregion

        #region PaymentBankAccountNumber
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
        #endregion

        #region PaymentBankAccountName
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
        #endregion

        #region PaymentMethod
        private int? mPaymentMethodID;
        public int? PaymentMethodID
        {
            get
            {
                if (mPaymentMethod != null)
                {
                    return mPaymentMethod.PaymentMethodID;
                }
                return mPaymentMethodID;
            }
            set
            {
                mPaymentMethodID = value;
                NotifyPropertyChanged("PaymentMethodID");
            }
        }
        private PaymentMethod mPaymentMethod=null;
        public PaymentMethod PaymentMethod
        {
            get
            {
                if (mPaymentMethod == null)
                {
                    mPaymentMethod = (PaymentMethod)BuildProperty(this, "PaymentMethod");
                }
                return mPaymentMethod;
            }
            set
            {
                mPaymentMethod = value;
                NotifyPropertyChanged("PaymentMethod");
            }
        }
        #endregion

        #region Notes
        private string mNotes="";
        public string Notes
        {
            get { return mNotes; }
            set 
            {
                mNotes = value;
                NotifyPropertyChanged("Notes");
            }
        }
        #endregion

        #region Identifiers
        private string mIdentifiers = "";
        public string Identifiers
        {
            get { return mIdentifiers; }
            set 
            { 
                mIdentifiers = value;
                NotifyPropertyChanged("Identifiers");
            }
        }
        #endregion

        #region Picture
        private string mPicture = "";
        public string Picture
        {
            get { return mPicture; }
            set 
            { 
                mPicture = value;
                NotifyPropertyChanged("Picture");
            }
        }
        #endregion

        #region UseCustomerTaxCode
        private string mUseCustomerTaxCode = "N";
        public string UseCustomerTaxCode
        {
            get { return mUseCustomerTaxCode; }
            set 
            { 
                mUseCustomerTaxCode = value;
                NotifyPropertyChanged("UseCustomerTaxCode");
            }
        }
        #endregion

        #region VolumeDiscount
        private double mVolumeDiscount;
        public double VolumeDiscount
        {
            get { return mVolumeDiscount; }
            set 
            { 
                mVolumeDiscount = value;
                NotifyPropertyChanged("VolumeDiscount");
            }
        }
        #endregion


        #region ABN
        private string mABN;
        public string ABN
        {
            get
            {
                return mABN;
            }
            set
            {
                mABN = value;
                NotifyPropertyChanged("ABN");
            }
        }
        #endregion

        #region CreditLimit
        private double mCreditLimit;
        public double CreditLimit
        {
            get { return mCreditLimit; }
            set 
            { 
                mCreditLimit = value;
                NotifyPropertyChanged("CreditLimit");
            }
        }
        #endregion

        #region HourlyBillingRate
        private double mHourlyBillingRate;
        public double HourlyBillingRate
        {
            get { return mHourlyBillingRate; }
            set 
            { 
                mHourlyBillingRate = value;
                NotifyPropertyChanged("HourlyBillingRate");
            }
        }
        #endregion

        #region IncomeAccount
        private int? mIncomeAccountID = null;
        public int? IncomeAccountID
        {
            get
            {
                if (mIncomeAccount != null)
                {
                    return mIncomeAccount.AccountID;
                }
                return mIncomeAccountID;
            }
            set
            {
                mIncomeAccountID = value;
                NotifyPropertyChanged("IncomeAccountID");
            }
        }
        private Accounts.Account mIncomeAccount = null;
        public Accounts.Account IncomeAccount
        {
            get
            {
                if (mIncomeAccount == null)
                {
                    mIncomeAccount = (Accounts.Account)BuildProperty(this, "IncomeAccount");
                }
                return mIncomeAccount;
            }
            set
            {
                mIncomeAccount = value;
                NotifyPropertyChanged("IncomeAccount");
            }
        }
        #endregion

        #region -(Object Override Methods)
        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Customer))
            {
                return false;
            }
            Customer _obj = (Customer)obj;
            if (_obj.FromDb && FromDb)
            {
                return _obj.CustomerID == CustomerID;
            }
            else
            {
                return _obj.CardIdentification.Equals(CardIdentification);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
