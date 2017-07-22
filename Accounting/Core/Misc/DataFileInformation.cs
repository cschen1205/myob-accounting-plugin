using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Misc
{
    public class DataFileInformation : Entity
    {
        internal DataFileInformation(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        
        

        #region ID
        private int? mID;
        public int? ID
        {
            get { return mID; }
            set 
            {
                mID = value;
                NotifyPropertyChanged("ID");
            }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("ID", ID);
            }
        }

        #region CompanyName
        private string mCompanyName;
        public string CompanyName
        {
            get { return mCompanyName; }
            set 
            {
                mCompanyName = value;
                NotifyPropertyChanged("CompanyName");
            }
        }
        #endregion

        #region Address
        private string mAddress;
        public string Address
        {
            get { return mAddress; }
            set 
            {
                mAddress = value;
                NotifyPropertyChanged("Address");
            }
        }
        #endregion

        #region City
        private string mCity;
        public string City
        {
            get { return mCity; }
            set 
            {
                mCity = value;
                NotifyPropertyChanged("City");
            }
        }
        #endregion

        #region CompanyInfo.Province
        private string mProvince;
        public string Province
        {
            get { return mProvince; }
            set 
            {
                mProvince = value;
                NotifyPropertyChanged("Province");
            }
        }
        #endregion

        #region PostCode
        private string mPostCode;
        public string PostCode
        {
            get { return mPostCode; }
            set 
            {
                mPostCode = value;
                NotifyPropertyChanged("PostCode");
            }
        }
        #endregion

        #region DataFileCountry
        private string mDataFileCountry;
        public string DataFileCountry
        {
            get { return mDataFileCountry; }
            set 
            {
                mDataFileCountry = value;
                NotifyPropertyChanged("DataFileCountry");
            }
        }
        #endregion

        #region Phone1
        private string mPhone1;
        public string Phone1
        {
            get { return mPhone1; }
            set 
            {
                mPhone1 = value;
                NotifyPropertyChanged("Phone1");
            }
        }
        #endregion

        #region Phone2
        private string mPhone2;
        public string Phone2
        {
            get { return mPhone2; }
            set 
            {
                mPhone2 = value;
                NotifyPropertyChanged("Phone2");
            }
        }
        #endregion

        #region FaxNumber
        private string mFaxNumber;
        public string FaxNumber
        {
            get { return mFaxNumber; }
            set 
            {
                mFaxNumber = value;
                NotifyPropertyChanged("FaxNumber");
            }
        }
        #endregion

        #region ABN
        private string mABN = "";
        public string ABN
        {
            get { return mABN; }
            set 
            {
                mABN = value;
                NotifyPropertyChanged("ABN");
            }
        }
        #endregion

        #region ABNBranch
        private string mABNBranch = "";
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

        #region ACN
        private string mACN = "";
        public string ACN
        {
            get { return mACN; }
            set 
            {
                mACN = value;
                NotifyPropertyChanged("ACN");
            }
        }
        #endregion

        #region SalesTaxNumber
        private string mSalesTaxNumber = "";
        public string SalesTaxNumber
        {
            get { return mSalesTaxNumber; }
            set 
            {
                mSalesTaxNumber = value;
                NotifyPropertyChanged("SalesTaxNumber");
            }
        }
        #endregion

        #region GSTRegistrationNumber
        private string mGSTRegistrationNumber = "";
        public string GSTRegistrationNumber
        {
            get { return mGSTRegistrationNumber; }
            set 
            {
                mGSTRegistrationNumber = value;
                NotifyPropertyChanged("GSTRegistrationNumber");
            }
        }
        #endregion

        #region PayeeNumber
        private string mPayeeNumber = "";
        public string PayeeNumber
        {
            get { return mPayeeNumber; }
            set 
            {
                mPayeeNumber = value;
                NotifyPropertyChanged("PayeeNumber");
            }
        }
        #endregion

        #region CompanyRegistrationNumber
        private string mCompanyRegistrationNumber;
        public string CompanyRegistrationNumber
        {
            get { return mCompanyRegistrationNumber; }
            set 
            {
                mCompanyRegistrationNumber = value;
                NotifyPropertyChanged("CompanyRegistrationNumber");
            }
        }
        #endregion

        #region CurrentFinancialYear
        private int? mCurrentFinancialYear;
        public int? CurrentFinancialYear
        {
            get { return mCurrentFinancialYear; }
            set 
            {
                mCurrentFinancialYear = value;
                NotifyPropertyChanged("CurrentFinancialYear");
            }
        }
        #endregion

        #region LastMonthInFinancialYear
        private int? mLastMonthInFinancialYear;
        public int? LastMonthInFinancialYear
        {
            get { return mLastMonthInFinancialYear; }
            set 
            {
                mLastMonthInFinancialYear = value;
                NotifyPropertyChanged("LastMonthInFinancialYear");
            }
        }
        #endregion

        #region ConversionDate
        private DateTime? mConversionDate;
        public DateTime? ConversionDate
        {
            get { return mConversionDate; }
            set 
            {
                mConversionDate = value;
                NotifyPropertyChanged("ConversionDate");
            }
        }
        #endregion

        #region PeriodsPerYear
        private int? mPeriodsPerYear;
        public int? PeriodsPerYear
        {
            get { return mPeriodsPerYear; }
            set 
            {
                mPeriodsPerYear = value;
                NotifyPropertyChanged("PeriodsPerYear");
            }
        }
        #endregion

        #region BankCode
        private string mBankCode = "";
        public string BankCode
        {
            get { return mBankCode; }
            set 
            {
                mBankCode = value;
                NotifyPropertyChanged("BankCode");
            }
        }
        #endregion

        #region BankID
        private string mBankID = "";
        public string BankID
        {
            get { return mBankID; }
            set 
            {
                mBankID = value;
                NotifyPropertyChanged("BankID");
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

        #region IsSelfBalancing
        private string mIsSelfBalancing = "";
        public string IsSelfBalancing
        {
            get { return mIsSelfBalancing; }
            set 
            {
                mIsSelfBalancing = value;
                NotifyPropertyChanged("IsSelfBalancing");
            }
        }
        #endregion

        #region StatementParticulars
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
        #endregion

        #region StatementCode
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
        #endregion

        #region StatementReference
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
        #endregion

        #region LastPurgeDate
        private DateTime? mLastPurgeDate;
        public DateTime? LastPurgeDate
        {
            get { return mLastPurgeDate; }
            set 
            {
                mLastPurgeDate = value;
                NotifyPropertyChanged("LastPurgeDate");
            }
        }
        #endregion

        #region LastBackupDate
        private DateTime? mLastBackupDate;
        public DateTime? LastBackupDate
        {
            get { return mLastBackupDate; }
            set 
            {
                mLastBackupDate = value;
                NotifyPropertyChanged("LastBackupDate");
            }
        }
        #endregion

        #region DatabaseVersion
        private string mDatabaseVersion = "";
        public string DatabaseVersion
        {
            get { return mDatabaseVersion; }
            set 
            {
                mDatabaseVersion = value;
                NotifyPropertyChanged("DatabaseVersion");
            }
        }
        #endregion

        #region DriverBuildNumber
        private int? mDriverBuildNumber;
        public int? DriverBuildNumber
        {
            get { return mDriverBuildNumber; }
            set
            {
                mDriverBuildNumber = value;
                NotifyPropertyChanged("DriverBuildNumber");
            }
        }
        #endregion

        #region SerialNumber
        private string mSerialNumber;
        public string SerialNumber
        {
            get { return mSerialNumber; }
            set 
            {
                mSerialNumber = value;
                NotifyPropertyChanged("SerialNumber");
            }
        }
        #endregion

        #region CompanyFileNumber
        private string mCompanyFileNumber = "";
        public string CompanyFileNumber
        {
            get { return mCompanyFileNumber; }
            set 
            {
                mCompanyFileNumber = value;
                NotifyPropertyChanged("CompanyFileNumber");
            }
        }
        #endregion

        #region UseRetailManagerLink
        private string mUseRetailManagerLink = "";
        public string UseRetailManagerLink
        {
            get { return mUseRetailManagerLink; }
            set 
            {
                mUseRetailManagerLink = value;
                NotifyPropertyChanged("UseRetailManagerLink");
            }
        }
        #endregion

        #region UseMultipleCurrencies
        private string mUseMultipleCurrencies = "";
        public string UseMultipleCurrencies
        {
            get { return mUseMultipleCurrencies; }
            set 
            {
                mUseMultipleCurrencies = value;
                NotifyPropertyChanged("UseMultipleCurrencies");
            }
        }
        #endregion

        #region UseCostCentres
        private string mUseCostCentres = "";
        public string UseCostCentres
        {
            get { return mUseCostCentres; }
            set 
            {
                mUseCostCentres = value;
                NotifyPropertyChanged("UseCostCentres");
            }
        }
        #endregion

        #region CostCentresRequired
        private string mCostCentresRequired = "";
        public string CostCentresRequired
        {
            get { return mCostCentresRequired; }
            set 
            {
                mCostCentresRequired = value;
                NotifyPropertyChanged("CostCentresRequired");
            }
        }
        #endregion

        #region UseSimplifiedTaxSystem
        private string mUseSimplifiedTaxSystem="";
        public string UseSimplifiedTaxSystem
        {
            get { return mUseSimplifiedTaxSystem; }
            set 
            {
                mUseSimplifiedTaxSystem = value;
                NotifyPropertyChanged("UseSimplifiedTaxSystem");
            }
        }
        #endregion

        #region SimplifiedTaxSystemDate
        private DateTime? mSimplifiedTaxSystemDate;
        public DateTime? SimplifiedTaxSystemDate
        {
            get { return mSimplifiedTaxSystemDate; }
            set 
            {
                mSimplifiedTaxSystemDate = value;
                NotifyPropertyChanged("SimplifiedTaxSystemDate");
            }
        }
        #endregion

        #region UseDailyAgeing
        private string mUseDailyAgeing = "";
        public string UseDailyAgeing
        {
            get { return mUseDailyAgeing; }
            set 
            {
                mUseDailyAgeing = value;
                NotifyPropertyChanged("UseDailyAgeing");
            }
        }
        #endregion

        #region FirstAgeingPeriod
        private int? mFirstAgeingPeriod;
        public int? FirstAgeingPeriod
        {
            get { return mFirstAgeingPeriod; }
            set 
            {
                mFirstAgeingPeriod = value;
                NotifyPropertyChanged("FirstAgeingPeriod");
            }
        }
        #endregion

        #region SecondAgeingPeriod
        private int? mSecondAgeingPeriod;
        public int? SecondAgeingPeriod
        {
            get { return mSecondAgeingPeriod; }
            set 
            {
                mSecondAgeingPeriod = value;
                NotifyPropertyChanged("SecondAgeingPeriod");
            }
        }
        #endregion

        #region ThirdAgeingPeriod
        private int? mThirdAgeingPeriod;
        public int? ThirdAgeingPeriod
        {
            get { return mThirdAgeingPeriod; }
            set 
            {
                mThirdAgeingPeriod = value;
                NotifyPropertyChanged("ThirdAgeingPeriod");
            }
        }
        #endregion

        #region IdentifyAgeByName
        private string mIdentifyAgeByName = "";
        public string IdentifyAgeByName
        {
            get { return mIdentifyAgeByName; }
            set 
            {
                mIdentifyAgeByName = value;
                NotifyPropertyChanged("IdentifyAgeByName");
            }
        }
        #endregion

        #region LockPeriodIsActive
        private string mLockPeriodIsActive = "";
        public string LockPeriodIsActive
        {
            get { return mLockPeriodIsActive; }
            set
            {
                mLockPeriodIsActive = value;
                NotifyPropertyChanged("LockPeriodIsActive");
            }
        }
        #endregion

        #region LockPeriodDate
        private DateTime? mLockPeriodDate;
        public DateTime? LockPeriodDate
        {
            get { return mLockPeriodDate; }
            set 
            {
                mLockPeriodDate = value;
                NotifyPropertyChanged("LockPeriodDate");
            }
        }
        #endregion

        #region LockThirteenthPeriod
        private string mLockThirteenthPeriod = "";
        public string LockThirteenthPeriod
        {
            get { return mLockThirteenthPeriod; }
            set 
            { 
                mLockThirteenthPeriod = value;
                NotifyPropertyChanged("LockThirteenthPeriod");
            }
        }
        #endregion

        #region DefaultCustomerTermsID
        private int? mDefaultCustomerTermsID;
        public int? DefaultCustomerTermsID
        {
            get { return mDefaultCustomerTermsID; }
            set 
            {
                mDefaultCustomerTermsID = value;
                NotifyPropertyChanged("DefaultCustomerTermsID");
            }
        }
        #endregion 

        #region DefaultCustomerPriceLevelID
        private string mDefaultCustomerPriceLevelID = "";
        public string DefaultCustomerPriceLevelID
        {
            get { return mDefaultCustomerPriceLevelID; }
            set 
            {
                mDefaultCustomerPriceLevelID = value;
                NotifyPropertyChanged("DefaultCustomerPriceLevelID");
            }
        }
        #endregion

        #region DefaultCustomerTaxCodeID
        private int? mDefaultCustomerTaxCodeID;
        public int? DefaultCustomerTaxCodeID
        {
            get { return mDefaultCustomerTaxCodeID; }
            set 
            {
                mDefaultCustomerTaxCodeID = value;
                NotifyPropertyChanged("DefaultCustomerTaxCodeID");
            }
        }
        #endregion

        #region DefaultUseCustomerTaxCode
        private string mDefaultUseCustomerTaxCode = "";
        public string DefaultUseCustomerTaxCode
        {
            get { return mDefaultUseCustomerTaxCode; }
            set 
            {
                mDefaultUseCustomerTaxCode = value;
                NotifyPropertyChanged("DefaultUseCustomerTaxCode");
            }
        }
        #endregion

        #region DefaultCustomerFreightTaxCodeID
        private int? mDefaultCustomerFreightTaxCodeID;
        public int? DefaultCustomerFreightTaxCodeID
        {
            get { return mDefaultCustomerFreightTaxCodeID; }
            set 
            {
                mDefaultCustomerFreightTaxCodeID = value;
                NotifyPropertyChanged("DefaultCustomerFreightTaxCodeID");
            }
        }
        #endregion

        #region DefaultCustomerCreditLimit
        private double mDefaultCustomerCreditLimit;
        public double DefaultCustomerCreditLimit
        {
            get { return mDefaultCustomerCreditLimit; }
            set 
            {
                mDefaultCustomerCreditLimit = value;
                NotifyPropertyChanged("DefaultCustomerCreditLimit");
            }
        }
        #endregion

        #region DefaultSupplierTermsID
        private int? mDefaultSupplierTermsID;
        public int? DefaultSupplierTermsID
        {
            get { return mDefaultSupplierTermsID; }
            set 
            {
                mDefaultSupplierTermsID = value;
                NotifyPropertyChanged("DefaultSupplierTermsID");
            }
        }
        #endregion

        #region DefaultSupplierTaxCodeID
        private int? mDefaultSupplierTaxCodeID;
        public int? DefaultSupplierTaxCodeID
        {
            get { return mDefaultSupplierTaxCodeID; }
            set 
            {
                mDefaultSupplierTaxCodeID = value;
                NotifyPropertyChanged("DefaultSupplierTaxCodeID");
            }
        }
        #endregion

        #region DefaultUseSupplierTaxCode
        private string mDefaultUseSupplierTaxCode = "";
        public string DefaultUseSupplierTaxCode
        {
            get { return mDefaultUseSupplierTaxCode; }
            set 
            {
                mDefaultUseSupplierTaxCode = value;
                NotifyPropertyChanged("DefaultUseSupplierTaxCode");
            }
        }
        #endregion

        #region DefaultSupplierFreightTaxCodeID
        private int? mDefaultSupplierFreightTaxCodeID;
        public int? DefaultSupplierFreightTaxCodeID
        {
            get { return mDefaultSupplierFreightTaxCodeID; }
            set 
            {
                mDefaultSupplierFreightTaxCodeID = value;
                NotifyPropertyChanged("DefaultSupplierFreightTaxCodeID");
            }
        }
        #endregion

        #region DefaultSupplierCreditLimit
        private double mDefaultSupplierCreditLimit;
        public double DefaultSupplierCreditLimit
        {
            get { return mDefaultSupplierCreditLimit; }
            set 
            {
                mDefaultSupplierCreditLimit = value;
                NotifyPropertyChanged("DefaultSupplierCreditLimit");
            }
        }
        #endregion

        #region InvoiceSubject
        private string mInvoiceSubject;
        public string InvoiceSubject
        {
            get { return mInvoiceSubject; }
            set 
            {
                mInvoiceSubject = value;
                NotifyPropertyChanged("InvoiceSubject");
            }
        }
        #endregion

        #region InvoiceMessage
        private string mInvoiceMessage = "";
        public string InvoiceMessage
        {
            get { return mInvoiceMessage; }
            set 
            {
                mInvoiceMessage = value;
                NotifyPropertyChanged("InvoiceMessage");
            }
        }
        #endregion

        #region IncludeInvoiceNumber
        private string mIncludeInvoiceNumber = "";
        public string IncludeInvoiceNumber
        {
            get { return mIncludeInvoiceNumber; }
            set 
            {
                mIncludeInvoiceNumber = value;
                NotifyPropertyChanged("IncludeInvoiceNumber");
            }
        }
        #endregion

        #region InvoiceQuoteSubject
        private string mInvoiceQuoteSubject = "";
        public string InvoiceQuoteSubject
        {
            get { return mInvoiceQuoteSubject; }
            set 
            {
                mInvoiceQuoteSubject = value;
                NotifyPropertyChanged("InvoiceQuoteSubject");
            }
        }
        #endregion

        #region InvoiceQuoteMessage
        private string mInvoiceQuoteMessage = "";
        public string InvoiceQuoteMessage
        {
            get { return mInvoiceQuoteMessage; }
            set 
            {
                mInvoiceQuoteMessage = value;
                NotifyPropertyChanged("InvoiceQuoteMessage");
            }
        }
        #endregion

        #region IncludeInvoiceQuoteNumber
        private string mIncludeInvoiceQuoteNumber = "";
        public string IncludeInvoiceQuoteNumber
        {
            get { return mIncludeInvoiceQuoteNumber; }
            set 
            {
                mIncludeInvoiceQuoteNumber = value;
                NotifyPropertyChanged("IncludeInvoiceQuoteNumber");
            }
        }
        #endregion

        #region InvoiceOrderSubject
        private string mInvoiceOrderSubject = "";
        public string InvoiceOrderSubject
        {
            get { return mInvoiceOrderSubject; }
            set 
            { 
                mInvoiceOrderSubject = value;
                NotifyPropertyChanged("InvoiceOrderSubject");
            }
        }
        #endregion

        #region InvoiceOrderMessage
        private string mInvoiceOrderMessage;
        public string InvoiceOrderMessage
        {
            get { return mInvoiceOrderMessage; }
            set
            {
                mInvoiceOrderMessage = value;
                NotifyPropertyChanged("InvoiceOrderMessage");
            }
        }
        #endregion

        #region IncludeInvoiceOrderNumber
        private string mIncludeInvoiceOrderNumber;
        public string IncludeInvoiceOrderNumber
        {
            get { return mIncludeInvoiceOrderNumber; }
            set 
            {
                mIncludeInvoiceOrderNumber = value;
                NotifyPropertyChanged("IncludeInvoiceOrderNumber");
            }
        }
        #endregion

        #region PurchaseSubject
        private string mPurchaseSubject;
        public string PurchaseSubject
        {
            get { return mPurchaseSubject; }
            set 
            {
                mPurchaseSubject = value;
                NotifyPropertyChanged("PurchaseSubject");
            }
        }
        #endregion

        #region PurchaseMessage
        private string mPurchaseMessage;
        public string PurchaseMessage
        {
            get { return mPurchaseMessage; }
            set 
            {
                mPurchaseMessage = value;
                NotifyPropertyChanged("PurchaseMessage");
            }
        }
        #endregion

        #region IncludePurchaseNumber
        private string mIncludePurchaseNumber;
        public string IncludePurchaseNumber
        {
            get { return mIncludePurchaseNumber; }
            set
            {
                mIncludePurchaseNumber = value;
                NotifyPropertyChanged("IncludePurchaseNumber");
            }
        }
        #endregion

        #region PurchaseQuoteSubject
        private string mPurchaseQuoteSubject;
        public string PurchaseQuoteSubject
        {
            get { return mPurchaseQuoteSubject; }
            set
            {
                mPurchaseQuoteSubject = value;
                NotifyPropertyChanged("PurchaseQuoteSubject");
            }
        }
        #endregion

        #region PurchaseOrderMessage
        private string mPurchaseOrderMessage;
        public string PurchaseOrderMessage
        {
            get { return mPurchaseOrderMessage; }
            set 
            {
                mPurchaseOrderMessage = value;
                NotifyPropertyChanged("PurchaseOrderMessage");
            }
        }
        #endregion

        #region IncludePurchaseOrderNumber
        private string mIncludePurchaseOrderNumber = "";
        public string IncludePurchaseOrderNumber
        {
            get { return mIncludePurchaseOrderNumber; }
            set 
            {
                mIncludePurchaseOrderNumber = value;
                NotifyPropertyChanged("IncludePurchaseOrderNumber");
            }
        }
        #endregion

        #region StatementSubject
        private string mStatementSubject = "";
        public string StatementSubject
        {
            get { return mStatementSubject; }
            set 
            {
                mStatementSubject = value;
                NotifyPropertyChanged("StatementSubject");
            }
        }
        #endregion

        #region StatementMessage
        private string mStatementMessage;
        public string StatementMessage
        {
            get { return mStatementMessage; }
            set 
            {
                mStatementMessage = value;
                NotifyPropertyChanged("StatementMessage");
            }
        }
        #endregion

        #region PaymentSubject
        private string mPaymentSubject;
        public string PaymentSubject
        {
            get { return mPaymentSubject; }
            set 
            {
                mPaymentSubject = value;
                NotifyPropertyChanged("PaymentSubject");
            }
        }
        #endregion

        #region PaymentMessage
        private string mPaymentMessage;
        public string PaymentMessage
        {
            get { return mPaymentMessage; }
            set 
            {
                mPaymentMessage = value;
                NotifyPropertyChanged("PaymentMessage");
            }
        }
        #endregion

        #region UseAuditTracking
        private string mUseAuditTracking = "";
        public string UseAuditTracking
        {
            get { return mUseAuditTracking; }
            set 
            {
                mUseAuditTracking = value;
                NotifyPropertyChanged("UseAuditTracking");
            }
        }
        #endregion

        #region UseCreditLimitWarning
        private string mUseCreditLimitWarning = "";
        public string UseCreditLimitWarning
        {
            get { return mUseCreditLimitWarning; }
            set 
            {
                mUseCreditLimitWarning = value;
                NotifyPropertyChanged("UseCreditLimitWarning");
            }
        }
        #endregion

        #region LimitTypeID
        private string mLimitTypeID = "";
        public string LimitTypeID
        {
            get { return mLimitTypeID; }
            set
            {
                mLimitTypeID = value;
                NotifyPropertyChanged("LimitTypeID");
            }
        }
        #endregion

        #region ChangeControl
        private string mChangeControl = "";
        public string ChangeControl
        {
            get { return mChangeControl; }
            set 
            {
                mChangeControl = value;
                NotifyPropertyChanged("ChangeControl");
            }
        }
        #endregion

        #region UseStandardCost
        private string mUseStandardCost;
        public string UseStandardCost
        {
            get { return mUseStandardCost; }
            set 
            {
                mUseStandardCost = value;
                NotifyPropertyChanged("UseStandardCost");
            }
        }
        #endregion

        #region UseReceivablesFreight
        private string mUseReceivablesFreight;
        public string UseReceivablesFreight
        {
            get { return mUseReceivablesFreight; }
            set 
            {
                mUseReceivablesFreight = value;
                NotifyPropertyChanged("UseReceivablesFreight");
            }
        }
        #endregion

        #region UseReceivablesDeposits
        private string mUseReceivablesDeposits;
        public string UseReceivablesDeposits
        {
            get { return mUseReceivablesDeposits; }
            set 
            {
                mUseReceivablesDeposits = value;
                NotifyPropertyChanged("UseReceivablesDeposits");
            }
        }
        #endregion

        #region UseReceivablesDiscounts
        private string mUseReceivablesDiscounts;
        public string UseReceivablesDiscounts
        {
            get { return mUseReceivablesDiscounts; }
            set 
            {
                mUseReceivablesDiscounts = value;
                NotifyPropertyChanged("UseReceivablesDiscounts");
            }
        }
        #endregion

        #region UseReceivablesLateFees
        private string mUseReceivablesLateFees;
        public string UseReceivablesLateFees
        {
            get { return mUseReceivablesLateFees; }
            set 
            {
                mUseReceivablesLateFees = value;
                NotifyPropertyChanged("UseReceivablesLateFees");
            }
        }
        #endregion 

        #region UsePayablesInventory
        private string mUsePayablesInventory;
        public string UsePayablesInventory
        {
            get { return mUsePayablesInventory; }
            set 
            {
                mUsePayablesInventory = value;
                NotifyPropertyChanged("UsePayablesInventory");
            }
        }
        #endregion

        #region UsePayablesFreight
        private string mUsePayablesFreight;
        public string UsePayablesFreight
        {
            get { return mUsePayablesFreight; }
            set 
            {
                mUsePayablesFreight = value;
                NotifyPropertyChanged("UsePayablesFreight");
            }
        }
        #endregion

        #region UsePayablesDeposits
        private string mUsePayablesDeposits;
        public string UsePayablesDeposits
        {
            get { return mUsePayablesDeposits; }
            set
            {
                mUsePayablesDeposits = value;
                NotifyPropertyChanged("UsePayablesDeposits");
            }
        }
        #endregion

        #region UsePayablesDiscounts
        private string mUsePayablesDiscounts;
        public string UsePayablesDiscounts
        {
            get { return mUsePayablesDiscounts; }
            set 
            {
                mUsePayablesDiscounts = value;
                NotifyPropertyChanged("UsePayablesDiscounts");
            }
        }
        #endregion

        #region UsePayablesLateFees
        private string mUsePayablesLateFees;
        public string UsePayablesLateFees
        {
            get { return mUsePayablesLateFees; }
            set 
            {
                mUsePayablesLateFees = value;
                NotifyPropertyChanged("UsePayablesLateFees");
            }
        }
        #endregion




        #region Email
        private string mEmail;
        public string Email
        {
            get { return mEmail; }
            set 
            {
                mEmail = value;
                NotifyPropertyChanged("Email");
            }
        }
        #endregion

        #region WebSite
        private string mWebSite;
        public string WebSite
        {
            get { return mWebSite; }
            set
            {
                mWebSite = value;
                NotifyPropertyChanged("WebSite");
            }
        }
        #endregion
    }
}
