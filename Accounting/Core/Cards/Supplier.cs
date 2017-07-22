using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.TaxCodes;
using Accounting.Core.Misc;

namespace Accounting.Core.Cards
{
    public class Supplier : Cards.Card
    {
        #region Supplier constructor
        internal Supplier(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        

        #region -(Object Override Methods)
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Supplier))
            {
                return false;
            }
            Supplier rhs = (Supplier)obj;
            if (rhs.SupplierID == SupplierID)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return Name;
        }
        #endregion

        #region PurchaseLayout
        private string mPurchaseLayoutID;
        public string PurchaseLayoutID
        {
            get {
                if (mPurchaseLayout != null)
                {
                    return mPurchaseLayout.InvoiceTypeID;
                }
                return mPurchaseLayoutID; }
           set 
           { 
               mPurchaseLayoutID=value;
               NotifyPropertyChanged("PurchaseLayoutID");
           }
        }

        private Definitions.InvoiceType mPurchaseLayout;
        public Definitions.InvoiceType PurchaseLayout
        {
            get 
            {
                if (mPurchaseLayout == null)
                {
                    mPurchaseLayout = (Definitions.InvoiceType)BuildProperty(this, "PurchaseLayout");
                }
                return mPurchaseLayout; 
            }
            set
            {
                mPurchaseLayout = value;
                NotifyPropertyChanged("PurchaseLayout");
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
            set 
            {
                mInvoiceDeliveryID = value;
                NotifyPropertyChanged("InvoiceDeliveryID");
            }
        }

        private Definitions.InvoiceDelivery mInvoiceDelivery;
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

        #region PurchaseComment
        private int? mPurchaseCommentID;
        public int? PurchaseCommentID
        {
            set 
            { 
                mPurchaseCommentID = value;
                NotifyPropertyChanged("PurchaseCommentID");
            }
            get {
                if (mPurchaseComment != null)
                {
                    return mPurchaseComment.CommentID;
                }
                return mPurchaseCommentID; }
        }
        private Misc.Comment mPurchaseComment;
        public Misc.Comment PurchaseComment
        {
            get
            {
                if (mPurchaseComment == null)
                {
                    mPurchaseComment = (Misc.Comment)BuildProperty(this, "PurchaseComment");
                }
                return mPurchaseComment;
            }
            set
            {
                mPurchaseComment = value;
                NotifyPropertyChanged("PurchaseComment");
            }
        }
        #endregion

        #region TaxCode
        private int? mTaxCodeID;
        public int? TaxCodeID
        {
            set 
            { 
                mTaxCodeID=value;
                NotifyPropertyChanged("TaxCodeID");
            }
            get {
                if (mTaxCode != null)
                {
                    return mTaxCode.TaxCodeID;
                }
                return mTaxCodeID; }
        }
        private TaxCodes.TaxCode mTaxCode;
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

        #region CurrentBalance
        private double mCurrentBalance;
        public double CurrentBalance
        {
            get { return mCurrentBalance; }
            set 
            { 
                mCurrentBalance = value;
                NotifyPropertyChanged("CurrentBalance");
            }
        }
        #endregion

        #region Terms
        private int? mTermsID;
        public int? TermsID
        {
            set 
            {
                mTermsID=value;
                NotifyPropertyChanged("TermsID");
            }
            get {
                if (mTerms != null)
                {
                    return Terms.TermsID;
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

        #region SupplierID
        private int? mSupplierID;
        public int? SupplierID
        {
            get { return mSupplierID; }
            set 
            {
                mSupplierID = value;
                NotifyPropertyChanged("SupplierID");
            }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("SupplierID", SupplierID);
            }
        }

        #region ShippingMethod
        private ShippingMethods.ShippingMethod mShippingMethod=null;
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
        #endregion

        #region FreightTaxCode
        private TaxCodes.TaxCode mFreightTaxCode = null;
        public TaxCodes.TaxCode FreightTaxCode
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
        private string mTaxIDNumber = "";
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

        #region PaymentMemo
        private string mPaymentMemo = "";
        public string PaymentMemo
        {
            get { return mPaymentMemo; }
            set 
            {
                mPaymentMemo = value;
                NotifyPropertyChanged("PaymentMemo");
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
        private PaymentMethod mPaymentMethod = null;
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

        #region SupplierSince
        private DateTime? mSupplierSince;
        public DateTime? SupplierSince
        {
            get { return mSupplierSince; }
            set 
            {
                mSupplierSince = value;
                NotifyPropertyChanged("SupplierSince");
            }
        }
        #endregion

        #region LastPurchaseDate
        private DateTime? mLastPurchaseDate;
        public DateTime? LastPurchaseDate
        {
            get { return mLastPurchaseDate; }
            set 
            {
                mLastPurchaseDate = value;
                NotifyPropertyChanged("LastPurchaseDate");
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

        #region HighestPurchaseAmount
        private double mHighestPurchaseAmount;
        public double HighestPurchaseAmount
        {
            get { return mHighestPurchaseAmount; }
            set
            {
                mHighestPurchaseAmount = value;
                NotifyPropertyChanged("HighestPurchaseAmount");
            }
        }
        #endregion

        #region HighestPayableAmount
        private double mHighestPayableAmount;
        public double HighestPayableAmount
        {
            get { return mHighestPayableAmount; }
            set 
            {
                mHighestPayableAmount = value;
                NotifyPropertyChanged("HighestPayableAmount");
            }
        }
        #endregion

        #region EstimatedCostPerHour
        private double mEstimatedCostPerHour;
        public double EstimatedCostPerHour
        {
            get { return mEstimatedCostPerHour; }
            set 
            {
                mEstimatedCostPerHour = value;
                NotifyPropertyChanged("EstimatedCostPerHour");
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

        #region Notes
        private string mNotes = "";
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

        #region UseSupplierTaxCode
        private string mUseSupplierTaxCode = "N";
        public string UseSupplierTaxCode
        {
            get { return mUseSupplierTaxCode; }
            set 
            {
                mUseSupplierTaxCode = value;
                NotifyPropertyChanged("UseSupplierTaxCode");
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

        #region ExpenseAccount
        private int? mExpenseAccountID = null;
        public int? ExpenseAccountID
        {
            get
            {
                if (mExpenseAccount != null)
                {
                    return mExpenseAccount.AccountID;
                }
                return mExpenseAccountID;
            }
            set
            {
                mExpenseAccountID = value;
                NotifyPropertyChanged("ExpenseAccountID");
            }
        }
        private Accounts.Account mExpenseAccount = null;
        public Accounts.Account ExpenseAccount
        {
            get
            {
                if (mExpenseAccount == null)
                {
                    mExpenseAccount = (Accounts.Account)BuildProperty(this, "ExpenseAccount");
                }
                return mExpenseAccount;
            }
            set
            {
                mExpenseAccount = value;
                NotifyPropertyChanged("ExpenseAccount");
            }
        }
        #endregion

        #region BSBCode
        private string mBSBCode = "";
        public string BSBCode
        {
            get { return mBSBCode; }
            set
            {
                mBSBCode = value;
                NotifyPropertyChanged("BSBCode");
            }
        }
        #endregion

        #region BankAccountNumber
        private string mBankAccountNumber = "";
        public string BankAccountNumber
        {
            get { return mBankAccountNumber; }
            set 
            {
                mBankAccountNumber = value;
                NotifyPropertyChanged("BankAccountNumber");
            }
        }
        #endregion

        #region BankAccountName
        private string mBankAccountName = "";
        public string BankAccountName
        {
            get { return mBankAccountName; }
            set
            {
                mBankAccountName = value;
                NotifyPropertyChanged("BankAccountName");
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
    }
}
