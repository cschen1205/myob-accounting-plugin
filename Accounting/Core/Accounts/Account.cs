using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Accounts
{
    public class Account : Entity
    {    
        #region constructor
        internal Account(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
            
        }
        #endregion

        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("AccountID", AccountID);
            }
        }

        #region AccountantLinkCode
        private string mAccountantLinkCode;
        public string AccountantLinkCode
        {
            get { return mAccountantLinkCode; }
            set 
            { 
                mAccountantLinkCode = value;
                NotifyPropertyChanged("AccountantLinkCode");
            }
        }
        #endregion

        #region StatementReference
        private string mStatementReference;
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

        #region StatementCode
        private string mStatementCode;
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

        #region StatementParticulars
        private string mStatementParticulars;
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

        #region IsSelfBalancing
        private string mIsSelfBalancing;
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

        #region DirectEntryUserID
        private string mDirectEntryUserID;
        public string DirectEntryUserID
        {
            get { return mDirectEntryUserID; }
            set 
            {
                mDirectEntryUserID = value;
                NotifyPropertyChanged("DirectEntryUserID");
            }
        }
        #endregion

        #region BankCode
        private string mBankCode;
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

        #region CreateBankFiles
        private string mCreateBankFiles;
        public string CreateBankFiles
        {
            get
            {
                return mCreateBankFiles;
            }
            set 
            { 
                mCreateBankFiles = value;
                NotifyPropertyChanged("CreateBankFiles");
            }
        }
        #endregion

        #region CompanyTradingName
        private string mCompanyTradingName;
        public string CompanyTradingName
        {
            get { return mCompanyTradingName; }
            set 
            { 
                mCompanyTradingName = value;
                NotifyPropertyChanged("CompanyTradingName");
            }
        }
        #endregion

        #region BankAccountName
        private string mBankAccountName;
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

        #region BankAccountNumber
        private string mBankAccountNumber;
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

        #region BSBCode
        private string mBSBCode;
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

        #region IsTotal
        private string mIsTotal;
        public string IsTotal
        {
            get { return mIsTotal; }
            set 
            { 
                mIsTotal = value;
                NotifyPropertyChanged("IsTotal");
            }
        }
        #endregion

        #region ThisYearOpeningBalance
        private double mThisYearOpeningBalance;
        public double ThisYearOpeningBalance
        {
            get { return mThisYearOpeningBalance; }
            set 
            { 
                mThisYearOpeningBalance = value;
                NotifyPropertyChanged("ThisYearOpeningBalance");
            }
        }
        #endregion

        #region PostThisYearActivity
        private double mPostThisYearActivity;
        public double PostThisYearActivity
        {
            get { return mPostThisYearActivity; }
            set 
            { 
                mPostThisYearActivity = value;
                NotifyPropertyChanged("PostThisYearActivity");
            }
        }
        #endregion

        #region LastYearOpeningBalance
        private double mLastYearOpeningBalance;
        public double LastYearOpeningBalance
        {
            get { return mLastYearOpeningBalance; }
            set 
            { 
                mLastYearOpeningBalance = value;
                NotifyPropertyChanged("LastYearOpeningBalance");
            }
        }
        #endregion

        #region PreLastYearActivity
        private double mPreLastYearActivity;
        public double PreLastYearActivity
        {
            get { return mPreLastYearActivity; }
            set 
            { 
                mPreLastYearActivity = value;
                NotifyPropertyChanged("PreLastYearActivity");
            }
        }
        #endregion

        #region OpeningAccountBalance
        private double mOpeningAccountBalance;
        public double OpeningAccountBalance
        {
            get { return mOpeningAccountBalance; }
            set 
            { 
                mOpeningAccountBalance = value;
                NotifyPropertyChanged("OpeningAccountBalance");
            }
        }
        #endregion

        #region IsCreditBalance
        private string mIsCreditBalance;
        public string IsCreditBalance
        {
            get { return mIsCreditBalance; }
            set 
            { 
                mIsCreditBalance = value;
                NotifyPropertyChanged("IsCreditBalance");
            }
        }
        #endregion

        #region StatementBalance
        private double mStatementBalance;
        public double StatementBalance
        {
            get { return mStatementBalance; }
            set 
            { 
                mStatementBalance = value;
                NotifyPropertyChanged("StatementBalance");
            }
        }
        #endregion

        #region LastReconciledDate
        private Nullable<DateTime> mLastReconciledDate;
        public Nullable<DateTime> LastReconciledDate
        {
            get { return mLastReconciledDate; }
            set 
            { 
                mLastReconciledDate = value;
                NotifyPropertyChanged("LastReconciledDate");
            }
        }
        #endregion

        #region IsReconciled
        private string mIsReconciled;
        public string IsReconciled
        {
            get { return mIsReconciled; }
            set 
            { 
                mIsReconciled = value;
                NotifyPropertyChanged("IsReconciled");
            }
        }
        #endregion

        #region LastChequeNumber
        private string mLastChequeNumber;
        public string LastChequeNumber
        {
            get { return mLastChequeNumber; }
            set 
            { 
                mLastChequeNumber = value;
                NotifyPropertyChanged("LastChequeNumber");
            }
        }
        #endregion

        #region CurrencyExchangeAccount
        private int? mCurrencyExchangeAccountID;
        public int? CurrencyExchangeAccountID
        {
            get
            {
                if (mCurrencyExchangeAccount != null)
                {
                    return mCurrencyExchangeAccount.AccountID;
                }
                return mCurrencyExchangeAccountID; 
            }
            set 
            { 
                mCurrencyExchangeAccountID = value;
                NotifyPropertyChanged("CurrencyExchangeAccountID");
            }
        }
        private Account mCurrencyExchangeAccount = null;
        public Account CurrencyExchangeAccount
        {
            get
            {
                if (mCurrencyExchangeAccount == null)
                {
                    mCurrencyExchangeAccount = (Account)BuildProperty(this, "CurrencExchangeAccount");
                }
                return mCurrencyExchangeAccount;
            }
            set
            {
                mCurrencyExchangeAccount = value;
                NotifyPropertyChanged("CurrencyExchangeAccount");
            }
        }
        #endregion

        #region AccountDescription
        private string mAccountDescription;
        public string AccountDescription
        {
            get { return mAccountDescription; }
            set 
            { 
                mAccountDescription = value;
                NotifyPropertyChanged("AccountDescription");
            }
        }
        #endregion

        #region CashFlowClassification
        private string mCashFlowClassificationID;
        public string CashFlowClassificationID
        {
            get {
                if (mCashFlowClassification != null)
                {
                    return mCashFlowClassification.CashFlowClassID;
                }
                return mCashFlowClassificationID; }
            set 
            { 
                mCashFlowClassificationID = value;
                NotifyPropertyChanged("CashFlowClassificationID");
            }
        }
        private CashFlowClassification mCashFlowClassification;
        public CashFlowClassification CashFlowClassification
        {
            get 
            {
                if (mCashFlowClassification == null)
                {
                    mCashFlowClassification = (CashFlowClassification)BuildProperty(this, "CashFlowClassification");
                }
                return mCashFlowClassification; 
            }
            set
            {
                mCashFlowClassification = value;
                NotifyPropertyChanged("CashFlowClassification");
            }
        }
        #endregion

        #region AccountCurrentAccountBalance
        private double mCurrentAccountBalance;
        public double CurrentAccountBalance
        {
            get { return mCurrentAccountBalance; }
            set 
            { 
                mCurrentAccountBalance = value;
                NotifyPropertyChanged("CurrentAccountBalance");
            }
        }
        public string CurrentAccountBalanceDescription
        {
            get { return Currency.Format(CurrentAccountBalance); }
        }
        public string CurrentYearAccountBalanceDescription
        {
            get { return Currency.Format(CurrentYearAccountBalance); }
        }
        public double CurrentYearAccountBalance
        {
            get { return CurrentAccountBalance - PostThisYearActivity; }
        }
        #endregion

        #region AccountLevel
        private int? mAccountLevel;
        public int? AccountLevel
        {
            get { return mAccountLevel; }
            set 
            { 
                mAccountLevel = value;
                NotifyPropertyChanged("AccountLevel");
            }
        }
        #endregion

        #region AccountType
        private string mAccountTypeID;
        public string AccountTypeID
        {
            get 
            {
                if (mAccountType != null)
                {
                    return mAccountType.AccountTypeID;
                }
                return mAccountTypeID; }
            set 
            { 
                mAccountTypeID = value;
                NotifyPropertyChanged("AccountTypeID");
            }
        }
        private AccountType mAccountType;
        public AccountType AccountType
        {
            get 
            {
                if (mAccountType == null)
                {
                    mAccountType = (AccountType)BuildProperty(this, "AccountType");
                }
                return mAccountType; 
            }
            set
            {
                mAccountType = value;
                NotifyPropertyChanged("AccountType");
            }
        }
        #endregion

        #region AccountNumberDigits
        public string AccountNumberDigits
        {
            get
            {
                string result = AccountNumber.Remove(1, 1); //remove the "-" in the account number
                return result;
            }
        }
        #endregion

        #region IsHeader
        public bool IsHeader
        {
            get
            {
                return AccountTypeID == "H";
            }
        }
        #endregion

        #region IsBank
        public bool IsBank
        {
            get { return AccountTypeID == "B"; }
        }
        #endregion

        #region SubAccountType
        private string mSubAccountClassificationID;
        private SubAccountType mSubAccountClassification;
        public SubAccountType SubAccountClassification
        {
            get 
            {
                if (mSubAccountClassification == null)
                {
                    mSubAccountClassification = (SubAccountType)BuildProperty(this, "SubAccountClassification");
                }
                return mSubAccountClassification; 
            }
            set
            {
                mSubAccountClassification = value;
                NotifyPropertyChanged("SubAccountClassification");
            }
        }
        public string SubAccountClassificationID
        {
            get 
            {
                if (mSubAccountClassification != null)
                {
                    return mSubAccountClassification.SubAccountTypeID;
                }
                return mSubAccountClassificationID; 
            }
            set 
            {
                mSubAccountClassificationID = value;
                NotifyPropertyChanged("SubAccountClassificationID");
            }
        }
        #endregion

        #region AccountClassification
        private string mAccountClassificationID;
        public string AccountClassificationID
        {
            get {
                if (mAccountClassification != null)
                {
                    return mAccountClassification.AccountClassificationID;
                }
                return mAccountClassificationID; }
            set 
            { 
                mAccountClassificationID = value;
                NotifyPropertyChanged("AccountClassificationID");
            }
        }
        private AccountClassification mAccountClassification;
        public AccountClassification AccountClassification
        {
            get 
            {
                if (mAccountClassification == null)
                {
                    mAccountClassification = (AccountClassification)BuildProperty(this, "AccountClassification");
                }
                return mAccountClassification; 
            }
            set
            {
                mAccountClassification = value;
                NotifyPropertyChanged("AccountClassification");
            }
        }
        #endregion

        #region TaxCode
        private int? mTaxCodeID;
        public int? TaxCodeID
        {
            set 
            { 
                mTaxCodeID = value;
                NotifyPropertyChanged("TaxCodeID");
            }
            get 
            {
                if (mTaxCode != null)
                {
                    return mTaxCode.TaxCodeID;
                }
                return mTaxCodeID; 
            }
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

        #region Currency
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
        private Currencies.Currency mCurrency;
        public Currencies.Currency Currency
        {
            get 
            {
                if (mCurrency == null)
                {
                    mCurrency=(Currencies.Currency)BuildProperty(this, "Currency");
                }
                return mCurrency; 
            }
            set
            {
                mCurrency = value;
                NotifyPropertyChanged("Currency");
            }
        }
        #endregion

        #region AccountNumber
        private string mAccountNumber;
        public string AccountNumber
        {
            get { return mAccountNumber; }
            set 
            { 
                mAccountNumber = value;
                NotifyPropertyChanged("AccountNumber");
            }
        }
        public int AccountNumberInteger
        {
            get
            {
                string account_number = AccountNumber.Replace("-", "");
                return Int32.Parse(account_number);
            }
        }
        #endregion

        

        #region IsInactive
        private string mIsInactive;
        public string IsInactive
        {
            get { return mIsInactive; }
            set 
            { 
                mIsInactive = value;
                NotifyPropertyChanged("IsInactive");
            }
        }
        #endregion

        #region AccountName
        private string mAccountName;
        public string AccountName
        {
            get { return mAccountName; }
            set 
            { 
                mAccountName = value;
                NotifyPropertyChanged("AccountName");
            }
        }
        #endregion

        #region ParentAccount
        private int? mParentAccountID;
        public int? ParentAccountID
        {
            get { return mParentAccountID; }
            set 
            { 
                mParentAccountID = value;
                NotifyPropertyChanged("ParentAccountID");
            }
        }
        #endregion

        #region AccountID
        private int? mAccountID;
        public int? AccountID
        {
            set 
            { 
                mAccountID = value;
                NotifyPropertyChanged("mAccountID");
            }
            get { return mAccountID; }
        }
        #endregion

        #region Account object override methods
        public override string ToString()
        {
            return string.Format("{0} {1}", AccountNumber, AccountName);
        }
        public override bool Equals(object obj)
        {
            if (obj is Account)
            {
                Account _obj = (Account)obj;
                if (_obj.FromDb && FromDb)
                {
                    return _obj.AccountID == AccountID;
                }
                return _obj.AccountNumber.Equals(AccountNumber);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        #region -(GetAmountByPeriod)
        public double GetAmountByPeriod(int year, int period, bool budgets)
        {
            if(budgets) return GetBudgetAmountByPeriod(year, period);
            else return GetActivityAmountByPeriod(year, period);
        }
        #endregion


        #region -(GetAmountDescriptionByPeriod)
        public string GetAmountDescriptionByPeriod(int year, int period, bool budgets)
        {
            double amount = GetAmountByPeriod(year, period, budgets);
            return Currency.Format(amount);
        }
        #endregion

        #region -(GetActivity)
        public AccountActivity GetActivity(int year, int period)
        {
            return RepositoryMgr.AccountActivityMgr.FindByAccountYearPeriod(AccountID.Value, year, period);
        }
        #endregion

        #region -(GetActivityAmountByPeriod)
        public double GetActivityAmountByPeriod(int year, int period)
        {
            AccountActivity activity = GetActivity(year, period);
            if (activity == null)
            {
                return 0;
            }
            return activity.Amount;
        }
        #endregion

        #region -(GetAmountDescriptionByPeriod)
        public string GetActivityAmountDescriptionByPeriod(int year, int period)
        {
            double amount = GetActivityAmountByPeriod(year, period);
            return Currency.Format(amount);
        }
        #endregion

        #region -(GetBudget)
        public AccountBudget GetBudget(int year, int period)
        {
            return RepositoryMgr.AccountBudgetMgr.FindByAccountYearPeriod(AccountID.Value, year, period);
        }
        #endregion

        #region -(GetBudgetAmountByPeriod)
        public double GetBudgetAmountByPeriod(int year, int period)
        {
            AccountBudget Budget = GetBudget(year, period);
            if (Budget == null)
            {
                return 0;
            }
            return Budget.Amount;
        }
        #endregion

        #region -(GetAmountDescriptionByPeriod)
        public string GetBudgetAmountDescriptionByPeriod(int year, int period)
        {
            double amount = GetBudgetAmountByPeriod(year, period);
            return Currency.Format(amount);
        }
        #endregion

        #region -(GetAccountBalance)
        public double GetAccountBalance(int year, int period, bool budgets)
        {
            double sum = 0;
            if (budgets)
            {
                AccountBudget _obj = RepositoryMgr.AccountBudgetMgr.FindByAccountYearPeriod(AccountID, year, period);
                if(_obj != null)
                {
                    sum += _obj.Amount;
                }
            }
            else
            {
                AccountActivity _obj = RepositoryMgr.AccountActivityMgr.FindByAccountYearPeriod(AccountID, year, period);
                if(_obj != null)
                {
                    sum += _obj.Amount;
                }
            }

            
            return sum;
        }
        #endregion

        #region -(GetAccountBalance)
        public string GetAccountBalanceDescription(int year, int period, bool budgets)
        {
            double amount = GetAccountBalance(year, period, budgets);
            return Currency.Format(amount);
        }
        #endregion

        #region LinkedAccountType
        public LinkedAccount.LinkAccountType LinkedAccountType
        {
            get
            {
                return RepositoryMgr.LinkedAccountMgr.GetLinkedAccountType(this);
            }
        }
        #endregion

        #region IsLinked
        public bool IsLinked
        {
            get
            {
                return LinkedAccountType != LinkedAccount.LinkAccountType.Unlinked;
            }
        }
        #endregion

        
    }
}
