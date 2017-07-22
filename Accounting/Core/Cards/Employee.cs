using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Cards
{
    using Accounting.Core.Definitions;
    using Accounting.Core.Accounts;
    using Accounting.Core.Payroll;
    public class Employee : Cards.Card
    {
        #region -(Constructor)
        internal Employee(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        

        #region Gender
        private string mGender = "M";
        public string Gender
        {
            get { return mGender; }
            set 
            { 
                mGender = value;
                NotifyPropertyChanged("Gender");
            }
        }
        #endregion

        #region DateOfBirth
        private DateTime? mDateOfBirth = null;
        public DateTime? DateOfBirth
        {
            get
            {
                return mDateOfBirth;
            }
            set
            {
                mDateOfBirth = value;
                NotifyPropertyChanged("DateOfBirth");
            }
        }
        #endregion

        #region StartDate
        private DateTime? mStartDate = null;
        public DateTime? StartDate
        {
            get
            {
                return mStartDate;
            }
            set
            {
                mStartDate = value;
                NotifyPropertyChanged("StartDate");
            }
        }
        #endregion

        #region TerminationDate
        private DateTime? mTerminationDate = null;
        public DateTime? TerminationDate
        {
            get
            {
                return mTerminationDate;
            }
            set
            {
                mTerminationDate = value;
                NotifyPropertyChanged("TerminationDate");
            }
        }
        #endregion

        #region Notes
        private string mNotes;
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

        #region LastName
        private string mLastName;
        public string LastName
        {
            set 
            { 
                mLastName = value;
                NotifyPropertyChanged("LastName");
            }
            get 
            { 
                return mLastName; 
            }
        }
        #endregion

        #region -(Object Override Method)
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Employee))
            {
                return false;
            }
            Employee rhs = (Employee)obj;
            if (rhs.EmployeeID == EmployeeID)
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

        #region SalaryRate / BasePay
        private double mBasePay;
        public double BasePay
        {
            get { return mBasePay; }
            set 
            { 
                mBasePay = value;
                NotifyPropertyChanged("BasePay");
            }
        }
        #endregion

        #region FirstName
        private string mFirstName;
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

        #region EmployeeID
        private int? mEmployeeID;
        public int? EmployeeID
        {
            get { return mEmployeeID; }
            set 
            { 
                mEmployeeID = value;
                NotifyPropertyChanged("EmployeeID");
            }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("EmployeeID", EmployeeID);
            }
        }

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

        #region NumberOfBankAccounts
        private int? mNumberOfBankAccounts;
        public int? NumberOfBankAccounts
        {
            get { return mNumberOfBankAccounts; }
            set 
            { 
                mNumberOfBankAccounts = value;
                NotifyPropertyChanged("NumberOfBankAccounts");
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

        #region Bank1Value
        private double mBank1Value;
        public double Bank1Value
        {
            get { return mBank1Value; }
            set 
            {
                mBank1Value = value;
                NotifyPropertyChanged("Bank1Value");
            }
        }
        #endregion

        #region Bank1ValueType
        private PaymentValueType mBank1ValueType = null;
        public PaymentValueType Bank1ValueType
        {
            get
            {
                if (mBank1ValueType == null)
                {
                    mBank1ValueType = (PaymentValueType)BuildProperty(this, "Bank1ValueType");
                }
                return mBank1ValueType;
            }
            set
            {
                mBank1ValueType = value;
                NotifyPropertyChanged("Bank1ValueType");
            }
        }
        private string mBank1ValueTypeID="";
        public string Bank1ValueTypeID
        {
            get 
            {
                if (mBank1ValueType != null)
                {
                    return mBank1ValueType.ValueTypeID;
                }
                return mBank1ValueTypeID; 
            }
            set 
            {
                mBank1ValueTypeID = value;
                NotifyPropertyChanged("Bank1ValueTypeID");
            }
        }
        #endregion

        #region Bank2Value
        private double mBank2Value;
        public double Bank2Value
        {
            get { return mBank2Value; }
            set 
            { 
                mBank2Value = value;
                NotifyPropertyChanged("Bank2Value");
            }
        }
        #endregion

        #region Bank2ValueType
        private PaymentValueType mBank2ValueType = null;
        public PaymentValueType Bank2ValueType
        {
            get
            {
                if (mBank2ValueType == null)
                {
                    mBank2ValueType = (PaymentValueType)BuildProperty(this, "Bank2ValueType");
                }
                return mBank2ValueType;
            }
            set
            {
                mBank2ValueType = value;
                NotifyPropertyChanged("Bank2ValueType");
            }
        }
        private string mBank2ValueTypeID = "";
        public string Bank2ValueTypeID
        {
            get
            {
                if (mBank2ValueType != null)
                {
                    return mBank2ValueType.ValueTypeID;
                }
                return mBank2ValueTypeID;
            }
            set 
            { 
                mBank2ValueTypeID = value;
                NotifyPropertyChanged("Bank2ValueTypeID");
            }
        }
        #endregion

        #region Bank3Value
        private double mBank3Value;
        public double Bank3Value
        {
            get { return mBank3Value; }
            set 
            {
                mBank3Value = value;
                NotifyPropertyChanged("Bank3Value");
            }
        }
        #endregion

        #region Bank3ValueType
        private PaymentValueType mBank3ValueType = null;
        public PaymentValueType Bank3ValueType
        {
            get
            {
                if (mBank3ValueType == null)
                {
                    mBank3ValueType = (PaymentValueType)BuildProperty(this, "Bank3ValueType");
                }
                return mBank3ValueType;
            }
            set
            {
                mBank3ValueType = value;
                NotifyPropertyChanged("Bank3ValueType");
            }
        }
        private string mBank3ValueTypeID = "";
        public string Bank3ValueTypeID
        {
            get
            {
                if (mBank3ValueType != null)
                {
                    return mBank3ValueType.ValueTypeID;
                }
                return mBank3ValueTypeID;
            }
            set 
            {
                mBank3ValueTypeID = value;
                NotifyPropertyChanged("Bank3ValueTypeID");
            }
        }
        #endregion

        #region BSBCode2
        private string mBSBCode2 = "";
        public string BSBCode2
        {
            get { return mBSBCode2; }
            set 
            {
                mBSBCode2 = value;
                NotifyPropertyChanged("BSBCode2");
            }
        }
        #endregion

        #region BankAccountNumber2
        private string mBankAccountNumber2 = "";
        public string BankAccountNumber2
        {
            get { return mBankAccountNumber2; }
            set 
            {
                mBankAccountNumber2 = value;
                NotifyPropertyChanged("BankAccountNumber2");
            }
        }
        #endregion

        #region BankAccountName2
        private string mBankAccountName2 = "";
        public string BankAccountName2
        {
            get { return mBankAccountName2; }
            set 
            {
                mBankAccountName2 = value;
                NotifyPropertyChanged("BankAccountName2");
            }
        }
        #endregion

        #region BSBCode3
        private string mBSBCode3 = "";
        public string BSBCode3
        {
            get { return mBSBCode3; }
            set
            {     
                mBSBCode3 = value;
                NotifyPropertyChanged("BSBCode3");
            }
        }
        #endregion

        #region BankAccountNumber3
        private string mBankAccountNumber3 = "";
        public string BankAccountNumber3
        {
            get { return mBankAccountNumber3; }
            set 
            {
                mBankAccountNumber3 = value;
                NotifyPropertyChanged("BankAccountNumber3");
            }
        }
        #endregion

        #region BankAccountName3
        private string mBankAccountName3 = "";
        public string BankAccountName3
        {
            get { return mBankAccountName3; }
            set 
            { 
                mBankAccountName3 = value;
                NotifyPropertyChanged("BankAccountName3");
            }
        }
        #endregion

        #region StatementText
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
        #endregion

        #region EmploymentBasis
        private EmploymentBasis mEmploymentBasis = null;
        public EmploymentBasis EmploymentBasis
        {
            get
            {
                if (mEmploymentBasis == null)
                {
                    mEmploymentBasis = (EmploymentBasis)BuildProperty(this, "EmploymentBasis");
                }
                return mEmploymentBasis;
            }
            set
            {
                mEmploymentBasis = value;
                NotifyPropertyChanged("EmploymentBasis");
            }
        }
        private string mEmploymentBasisID = "";
        public string EmploymentBasisID
        {
            get
            {
                if (mEmploymentBasis != null)
                {
                    return mEmploymentBasis.EmploymentBasisID;
                }
                return mEmploymentBasisID;
            }
            set
            {
                mEmploymentBasisID = value;
                NotifyPropertyChanged("EmploymentBasisID");
            }
        }
        #endregion

        #region PaymentType
        private string mPaymentTypeID;
        public string PaymentTypeID
        {
            get
            {
                if(mPaymentType != null)
                {
                    return mPaymentType.PaymentTypeID;
                }
                return mPaymentTypeID;
            }
            set
            {
                mPaymentTypeID = value;
                NotifyPropertyChanged("PaymentTypeID");
            }
        }
        private PaymentType mPaymentType=null;
        public PaymentType PaymentType
        {
            get
            {
                if(mPaymentType == null)
                {
                    mPaymentType=(PaymentType)BuildProperty(this, "PaymentType");
                }
                return mPaymentType;
            }
            set
            {
                mPaymentType=value;
                NotifyPropertyChanged("PaymentType");
            }
        }
        #endregion

        #region EmploymentClassification
        private int? mEmploymentClassificationID;
        public int? EmploymentClassificationID
        {
            get
            {
                if (mEmploymentClassification != null)
                {
                    return mEmploymentClassification.EmploymentClassificationID;
                }
                return mEmploymentClassificationID;
            }
            set
            {
                mEmploymentClassificationID = value;
                NotifyPropertyChanged("EmploymentClassificationID");
            }
        }
        private EmploymentClassification mEmploymentClassification = null;
        public EmploymentClassification EmploymentClassification
        {
            get
            {
                if (mEmploymentClassification == null)
                {
                    mEmploymentClassification = (EmploymentClassification)BuildProperty(this, "EmploymentClassification");
                }
                return mEmploymentClassification;
            }
            set
            {
                mEmploymentClassification = value;
                NotifyPropertyChanged("EmploymentClassification");
            }
        }
        #endregion

        #region PayBasis
        private PayBasis mPayBasis = null;
        public PayBasis PayBasis
        {
            get
            {
                if (mPayBasis == null)
                {
                    mPayBasis = (PayBasis)BuildProperty(this, "PayBasis");
                }
                return mPayBasis;
            }
            set
            {
                mPayBasis = value;
                NotifyPropertyChanged("PayBasis");
            }
        }
        private string mPayBasisID = "";
        public string PayBasisID
        {
            get
            {
                if (mPayBasis != null)
                {
                    return mPayBasis.PayBasisID;
                }
                return mPayBasisID;
            }
            set
            {
                mPayBasisID = value;
                NotifyPropertyChanged("PayBasisID");
            }
        }
        #endregion

        #region PayFrequency
        private Frequency mPayFrequency = null;
        public Frequency PayFrequency
        {
            get
            {
                if (mPayFrequency == null)
                {
                    mPayFrequency = (Frequency)BuildProperty(this, "PayFrequency");
                }
                return mPayFrequency;
            }
            set
            {
                mPayFrequency = value;
                NotifyPropertyChanged("PayFrequency");
            }
        }
        private string mPayFrequencyID = "W";
        public string PayFrequencyID
        {
            get
            {
                if (mPayFrequency != null)
                {
                    return mPayFrequency.FrequencyID;
                }
                return mPayFrequencyID;
            }
            set
            {
                mPayFrequencyID = value;
                NotifyPropertyChanged("PayFrequencyID");
            }
        }
        #endregion

        #region HoursInPayPeriod
        private double mHoursInPayPeriod;
        public double HoursInPayPeriod
        {
            get { return mHoursInPayPeriod; }
            set 
            { 
                mHoursInPayPeriod = value;
                NotifyPropertyChanged("HoursInPayPeriod");
            }
        }
        #endregion

        #region WagesExpenseAccount
        private Account mWagesExpenseAccount = null;
        public Account WagesExpenseAccount
        {
            get
            {
                if (mWagesExpenseAccount == null)
                {
                    mWagesExpenseAccount = (Account)BuildProperty(this, "WagesExpenseAccount");
                }
                return mWagesExpenseAccount;
            }
            set
            {
                mWagesExpenseAccount = value;
                NotifyPropertyChanged("WagesExpenseAccount");
            }
        }
        private int? mWagesExpenseAccountID;
        public int? WagesExpenseAccountID
        {
            get
            {
                if (mWagesExpenseAccount != null)
                {
                    return mWagesExpenseAccount.AccountID;
                }
                return mWagesExpenseAccountID;
            }
            set
            {
                mWagesExpenseAccountID = value;
                NotifyPropertyChanged("WagesExpenseAccountID");
            }
        }
        #endregion

        #region SuperannuationFund
        private SuperannuationFund mSuperannuationFund = null;
        public SuperannuationFund SuperannuationFund
        {
            get
            {
                if (mSuperannuationFund == null)
                {
                    mSuperannuationFund = (SuperannuationFund)BuildProperty(this, "SuperannuationFund");
                }
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
                if (mSuperannuationFund != null)
                {
                    return mSuperannuationFund.SuperannuationFundID;
                }
                return mSuperannuationFundID;
            }
            set
            {
                mSuperannuationFundID = value;
                NotifyPropertyChanged("SuperannuationFundID");
            }
        }
        #endregion

        #region SuperannuationMembershipNumber
        private string mSuperannuationMembershipNumber = "";
        public string SuperannuationMembershipNumber
        {
            get
            {
                return mSuperannuationMembershipNumber;
            }
            set
            {
                mSuperannuationMembershipNumber = value;
                NotifyPropertyChanged("SuperannuationMembershipNumber");
            }
        }
        #endregion

        #region TaxFileNumber
        private string mTaxFileNumber = "";
        public string TaxFileNumber
        {
            get
            {
                return mTaxFileNumber;
            }
            set
            {
                mTaxFileNumber = value;
                NotifyPropertyChanged("TaxFileNumber");
            }
        }
        #endregion

        #region TaxScale
        private TaxScale mTaxScale = null;
        public TaxScale TaxScale
        {
            get
            {
                if (mTaxScale == null)
                {
                    mTaxScale = (TaxScale)BuildProperty(this, "TaxScale");
                }
                return mTaxScale;
            }
            set
            {
                mTaxScale = value;
                NotifyPropertyChanged("TaxScale");
            }
        }
        private int? mTaxScaleID;
        public int? TaxScaleID
        {
            get
            {
                if (mTaxScale != null)
                {
                    return mTaxScale.TaxScaleID;
                }
                return mTaxScaleID;
            }
            set
            {
                mTaxScaleID = value;
                NotifyPropertyChanged("TaxScaleID");
            }
        }
        #endregion

        #region WithholdingVariationRate
        private double mWithholdingVariationRate;
        public double WithholdingVariationRate
        {
            get
            {
                return mWithholdingVariationRate;
            }
            set
            {
                mWithholdingVariationRate = value;
                NotifyPropertyChanged("WithholdingVariationRate");
            }
        }
        #endregion

        #region TotalRebates
        private double mTotalRebates;
        public double TotalRebates
        {
            get { return mTotalRebates; }
            set 
            { 
                mTotalRebates = value;
                NotifyPropertyChanged("TotalRebates");
            }
        }
        #endregion

        #region ExtraTax
        private double mExtraTax;
        public double ExtraTax
        {
            get { return mExtraTax; }
            set 
            { 
                mExtraTax = value;
                NotifyPropertyChanged("ExtraTax");
            }
        }
        #endregion

        #region EmploymentStatus
        private EmploymentStatus mEmploymentStatus = null;
        public EmploymentStatus EmploymentStatus
        {
            get
            {
                if (mEmploymentStatus == null)
                {
                    mEmploymentStatus = (EmploymentStatus)BuildProperty(this, "EmploymentStatus");
                }
                return mEmploymentStatus;
            }
            set
            {
                mEmploymentStatus=value;
                NotifyPropertyChanged("EmploymentStatus");
            }
        }
        private string mEmploymentStatusID = "";
        public string EmploymentStatusID
        {
            get
            {
                if (mEmploymentStatus != null)
                {
                    return mEmploymentStatus.EmploymentStatusID;
                }
                return mEmploymentStatusID;
            }
            set
            {
                mEmploymentStatusID = value;
                NotifyPropertyChanged("EmploymentStatusID");
            }
        }
        #endregion

        #region EmploymentCategory
        private EmploymentCategory mEmploymentCategory = null;
        public EmploymentCategory EmploymentCategory
        {
            get
            {
                if (mEmploymentCategory == null)
                {
                    mEmploymentCategory = (EmploymentCategory)BuildProperty(this, "EmploymentCategory");
                }
                return mEmploymentCategory;
            }
            set
            {
                mEmploymentCategory = value;
                NotifyPropertyChanged("EmploymentCategory");
            }
        }
        private string mEmploymentCategoryID = "";
        public string EmploymentCategoryID
        {
            get
            {
                if (mEmploymentCategory != null)
                {
                    return mEmploymentCategory.EmploymentCategoryID;
                }
                return mEmploymentCategoryID;
            }
            set
            {
                mEmploymentCategoryID = value;
                NotifyPropertyChanged("EmploymentCategoryID");
            }
        }
        #endregion
    }
}
