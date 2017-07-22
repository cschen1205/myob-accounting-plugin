using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Accounts
{
    using System.ComponentModel;
    using Accounting.Core.Accounts;
    using Accounting.Core.TaxCodes;
    using Accounting.Core.Enumeration;
    using Accounting.Core.Currencies;

    public class BOAccount : BusinessObject
    {
        public static readonly string ACCOUNT_TYPE = "AccountType";
        public static readonly string ACCOUNT_NAME = "AccountName";
        public static readonly string ACCOUNT_NUMBER = "AccountNumber";
        public static readonly string CURRENT_ACCOUNT_BALANCE = "CurrentAccountBalance";
        public static readonly string LINKED_ACCOUNT_TYPE_DESCRIPTION = "LinkedAccountTypeDescription";
        public static readonly string ACCOUNT_CLASSIFICATION = "AccountClassification";
        public static readonly string SUB_ACCOUNT_TYPE = "SubAccountType";
        public static readonly string IS_ACTIVE = "IsActive";
        public static readonly string DESCRIPTION = "Description";
        public static readonly string TAX_CODE = "TaxCode";
        public static readonly string CASH_FLOW_CLASSIFICATION = "CashFlowClassification";
        public static readonly string IS_TOTAL = "IsTotal";
        public static readonly string BSB_CODE = "BSBCode";
        public static readonly string BANK_ACCOUNT_NUMBER = "BankAccountNumber";
        public static readonly string BANK_ACCOUNT_NAME = "BankAccountName";
        public static readonly string COMPANY_TRADING_NAME = "CompanyTradingName";
        public static readonly string CREATE_BANK_FILES = "CreateBankFiles";
        public static readonly string BANK_CODE = "BankCode";
        public static readonly string DIRECT_ENTRY_USER_ID = "DirectEntryUserID";
        public static readonly string IS_SELF_BALANCING = "IsSelfBalancing";

        private Account mDataProxy = null;
        private Account mDataSource = null;

        public BOAccount(Accountant acc, Account account, BOContext state)
            : base(acc, state)
        {
            mObjectID = BOType.BOAccount;
            mDataProxy = account.Clone() as Account;
            mDataSource = account;
        }

        protected override void UpdateContent()
        {
            Account discovered = mDataSource.Discover() as Account;
            if (discovered != null)
            {
                mDataSource = discovered;
                mDataProxy = mDataSource.Clone() as Account;
            }
        }

        public IList<AccountBudget> ThisYearAccountBudgets
        {
            get
            {
                return mAccountant.AccountBudgetMgr.FindCollectionByAccountYear(mDataProxy.AccountID, CurrentFinancialYear);
            }
        }

        public IList<AccountBudget> NextyearAccountBudgets
        {
            get
            {
                return mAccountant.AccountBudgetMgr.FindCollectionByAccountYear(mDataProxy.AccountID, NextFinancialYear);
            }
        }

        public int NextFinancialYear
        {
            get { return CurrentFinancialYear + 1; }
        }

        public IList<AccountActivity> FindAccountActivities(int year)
        {
            return mAccountant.AccountActivityMgr.FindCollectionByAccountYear(mDataProxy, year);
        }

        public IList<AccountHistory> AccountHistories
        {
            get
            {
                IList<AccountHistory> histories = new List<AccountHistory>();

                IList<AccountActivity> last_fy_activities = FindAccountActivities(LastFinancialYear);
                IList<AccountActivity> curr_fy_activities = FindAccountActivities(CurrentFinancialYear);
                double last_fy_opening_balance = mDataProxy.LastYearOpeningBalance;
                double curr_fy_opening_balance = mDataProxy.ThisYearOpeningBalance;
                Currency currency = mDataProxy.Currency;

                int lastmonth=mAccountant.CompanyInfo.LastMonthInFinancialYear.Value;
                double last_year_balance=last_fy_opening_balance;
                double current_year_balance=curr_fy_opening_balance;
                for (int period = 0; period < 12; ++period)
                {
                    int month = period + lastmonth;
                    month = month % 12;

                    AccountHistory history = new AccountHistory();
                    history.Month = Month.Int2LongString(month + 1);

                    if(period < last_fy_activities.Count)
                    {
                        last_year_balance+=last_fy_activities[period].Amount;
                    }
                    if(period < curr_fy_activities.Count)
                    {
                        current_year_balance+=curr_fy_activities[period].Amount;
                    }

                    history.LastFYBalance = currency.Format(last_year_balance);
                    history.CurrentFYBalance = currency.Format(current_year_balance);
                    histories.Add(history);
                }
                return histories;
            }
        }

        public int CurrentFinancialYear
        {
            get
            {
                //Console.WriteLine("Last Month in Financial Year: ... {0}", mAccountant.CompanyInfo.LastMonthInFinancialYear);
                return mAccountant.CompanyInfo.CurrentFinancialYear.Value;
            }
        }

        public int LastFinancialYear
        {
            get
            {
                return CurrentFinancialYear - 1;
            }
        }

        public bool IsBank
        {
            get { return mDataProxy.IsBank; }
        }

        public bool IsHeader
        {
            get { return mDataProxy.IsHeader; }
        }

        protected override void InitializeProperties()
        {
            base.InitializeProperties();

            #region ACCOUNT_TYPE
            AddProperty(ACCOUNT_TYPE,
                ACCOUNT_TYPE,
                delegate()  {  return AccountType;  },
                delegate(object value) { AccountType = value as AccountType; },
                AccountType_IsEnabled,
                delegate() { return true; },
                AccountType_Validate);
            #endregion

            #region ACCOUNT_NAME
            AddProperty(ACCOUNT_NAME,
                ACCOUNT_NAME,
                delegate() { return mDataProxy.AccountName; },
                delegate(object value) { mDataProxy.AccountName = (string)value; },
                delegate() { return CanEdit; },
                delegate() { return true; },
                AccountName_Validate);
            #endregion

            #region ACCOUNT_NUMBER
            AddProperty(ACCOUNT_NUMBER,
                ACCOUNT_NUMBER,
                delegate() { return AccountNumber; },
                delegate(object value) { AccountNumber = value as string; },
                delegate() { return CanEdit; },
                delegate() { return true; },
                AccountNumber_Validate);
            #endregion

            #region IS_ACTIVE
            AddProperty(IS_ACTIVE,
                IS_ACTIVE,
                delegate() { return IsActive; },
                delegate(object value) { IsActive = (bool)value; },
                delegate() { return CanEdit; },
                delegate() { return true; },
                IsActive_Validate);
            #endregion

            #region SUB_ACCOUNT_TYPE
            AddProperty(SUB_ACCOUNT_TYPE,
                SUB_ACCOUNT_TYPE,
                delegate() { return SubAccountType; },
                delegate(object value) { SubAccountType = value as SubAccountType; },
                SubAccountType_IsEnabled,
                SubAccountType_IsVisible,
                SubAccountType_Validate);
            #endregion

            #region ACCOUNT_CLASSIFICATION
            AddProperty(ACCOUNT_CLASSIFICATION,
                ACCOUNT_CLASSIFICATION,
                delegate() { return AccountClassification; },
                delegate(object value) { },
                AccountClassification_IsEnabled,
                delegate() { return true; },
                AccountClassification_Validate);
            #endregion

            #region CASH_FLOW_CLASSIFICATION
            AddProperty(CASH_FLOW_CLASSIFICATION,
                CASH_FLOW_CLASSIFICATION,
                delegate() { return CashFlowClassification; },
                delegate(object value) { CashFlowClassification = value as CashFlowClassification; },
                delegate() { return CanEdit; },
                CashFlowClassification_IsVisible,
                CashFlowClassification_Validate);
            #endregion

            #region DESCRIPTION
            AddProperty(DESCRIPTION,
                DESCRIPTION,
                delegate() { return Description; },
                delegate(object value) { Description = value as string; },
                delegate() { return CanEdit; },
                delegate() { return true; },
                Description_Validate);
            #endregion

            #region TAX_CODE
            AddProperty(TAX_CODE,
                TAX_CODE,
                delegate() { return TaxCode; },
                delegate(object value) { TaxCode = value as TaxCode; },
                delegate() { return CanEdit; },
                TaxCode_IsVisible,
                TaxCode_Validate);
            #endregion

            #region IS_TOTAL
            AddProperty(IS_TOTAL,
                IS_TOTAL,
                delegate() { return IsTotal; },
                delegate(object value) { IsTotal = (bool)value; },
                delegate() { return CanEdit; },
                IsTotal_IsVisible,
                IsTotal_Validate);
            #endregion

            #region CURRENT_ACCOUNT_BALANCE
            AddProperty(CURRENT_ACCOUNT_BALANCE,
                CURRENT_ACCOUNT_BALANCE,
                delegate() { return mDataProxy.CurrentAccountBalance; },
                delegate(object value) { mDataProxy.CurrentAccountBalance = double.Parse(value as string); },
                delegate() { return CanEdit; },
                delegate() { return true; },
                CurrentAccountBalance_Validate);
            #endregion

            #region LINKED_ACCOUNT_TYPE_DESCRIPTION
            AddProperty(LINKED_ACCOUNT_TYPE_DESCRIPTION,
                LINKED_ACCOUNT_TYPE_DESCRIPTION,
                delegate() { return mDataProxy.LinkedAccountType.ToString(); },
                delegate(object value) { },
                LinkedAccount_IsEnabled,
                LinkedAccount_IsVisible,
                delegate(object value, ref string error) { return true; });
            #endregion

            #region BSB_CODE
            AddProperty(BSB_CODE,
                BSB_CODE,
                delegate() { return BSBCode; },
                delegate(object value) { BSBCode = value as string; },
                delegate() { return CanEdit; },
                delegate() { return true; },
                BSBCode_Validate);
            #endregion

            #region BANK_ACCOUNT_NUMBER
            AddProperty(BANK_ACCOUNT_NUMBER,
                BANK_ACCOUNT_NUMBER,
                delegate() { return BankAccountNumber; },
                delegate(object value) { BankAccountNumber = value as string; },
                delegate() { return CanEdit; },
                delegate() { return true; },
                BankAccountNumber_Validate);
            #endregion

            #region BANK_ACCOUNT_NAME
            AddProperty(BANK_ACCOUNT_NAME,
                BANK_ACCOUNT_NAME,
                delegate() { return BankAccountName; },
                delegate(object value) { BankAccountName = value as string; },
                delegate() { return CanEdit; },
                delegate() { return true; },
                BankAccountName_Validate);
            #endregion

            #region COMPANY_TRADING_NAME
            AddProperty(COMPANY_TRADING_NAME,
                COMPANY_TRADING_NAME,
                delegate() { return CompanyTradingName; },
                delegate(object value) { CompanyTradingName = value as string; },
                delegate() { return CanEdit; },
                delegate() { return true; },
                CompanyTradingName_Validate);
            #endregion

            #region CREATE_BANK_FILES
            AddProperty(CREATE_BANK_FILES,
                CREATE_BANK_FILES,
                delegate() { return CreateBankFiles; },
                delegate(object value) { CreateBankFiles = (bool)value; },
                delegate() { return CanEdit; },
                delegate() { return true; },
                CreateBankFiles_Validate);
            #endregion

            #region BANK_CODE
            AddProperty(BANK_CODE,
                BANK_CODE,
                delegate() { return BankCode; },
                delegate(object value) { BankCode = value as string; },
                delegate() { return CanEdit; },
                BankCode_IsVisible,
                BankCode_Validate);
            #endregion

            #region DIRECT_ENTRY_USER_ID
            AddProperty(DIRECT_ENTRY_USER_ID,
                DIRECT_ENTRY_USER_ID,
                delegate() { return DirectEntryUserID; },
                delegate(object value) { DirectEntryUserID = value as string; },
                delegate() { return CanEdit; },
                DirectEntryUserID_IsVisible,
                DirectEntryUserID_Validate);
            #endregion

            #region IS_SELF_BALANCING
            AddProperty(IS_SELF_BALANCING,
                IS_SELF_BALANCING,
                delegate() { return IsSelfBalancing; },
                delegate(object value) { IsSelfBalancing = (bool)value; },
                delegate() { return CanEdit; },
                IsSelfBalancing_IsVisible,
                IsSelfBalancing_Validate);
            #endregion

        }

        public string BSBCode
        {
            get { return mDataProxy.BSBCode; }
            set { mDataProxy.BSBCode = value; }
        }

        public string BankAccountNumber
        {
            get { return mDataProxy.BankAccountNumber; }
            set { mDataProxy.BankAccountNumber = value; }
        }

        public string BankAccountName
        {
            get { return mDataProxy.BankAccountName; }
            set { mDataProxy.BankAccountName = value; }
        }

        public string CompanyTradingName
        {
            get { return mDataProxy.CompanyTradingName; }
            set { mDataProxy.CompanyTradingName = value; }
        }

        public bool CreateBankFiles
        {
            get { return mDataProxy.CreateBankFiles == "Y"; }
            set
            {
                if (value) mDataProxy.CreateBankFiles = "Y";
                else mDataProxy.CreateBankFiles = "N";
            }
        }

        public string BankCode
        {
            get { return mDataProxy.BankCode; }
            set { mDataProxy.BankCode = value; }
        }

        public string DirectEntryUserID
        {
            get { return mDataProxy.DirectEntryUserID; }
            set { mDataProxy.DirectEntryUserID = value; }
        }

        public bool IsSelfBalancing
        {
            get { return mDataProxy.IsSelfBalancing == "Y"; }
            set
            {
                if (value) mDataProxy.IsSelfBalancing = "Y";
                else mDataProxy.IsSelfBalancing = "N";
            }
        }

        public bool BSBCode_Validate(object value, ref string error)
        {
            if (value is string)
            {
                string bsb_code=value as string;
                if (!IsAlphabet(bsb_code, 0, 3, out error))
                {
                    error = DecorateError(BSB_CODE, error);
                    return false;
                }
                return true;
            }
            error = DecorateTypeMismatchError(BSB_CODE, "string");
            return false;
        }

        public bool BankAccountNumber_Validate(object value, ref string error)
        {
            if (value is string)
            {
                string _result = value as string;
                if (!IsWithinRange(_result, 0, 20, out error))
                {
                    error = DecorateError(BANK_ACCOUNT_NUMBER, error);
                    return false;
                }
                return true;
            }
            error = DecorateTypeMismatchError(BANK_ACCOUNT_NUMBER, "string");
            return false;
        }

        public bool BankAccountName_Validate(object value, ref string error)
        {
            if (value is string)
            {
                string _result = value as string;
                if (!IsWithinRange(_result, 0, 32, out error))
                {
                    error = DecorateError(BANK_ACCOUNT_NAME, error);
                    return false;
                }
                return true;
            }
            error = DecorateTypeMismatchError(BANK_ACCOUNT_NAME, "string");
            return false;
        }

        public bool CompanyTradingName_Validate(object value, ref string error)
        {
            if (value is string)
            {
                string _result = value as string;
                if (!IsWithinRange(_result, 0, 50, out error))
                {
                    error = DecorateError(COMPANY_TRADING_NAME, error);
                    return false;
                }
                return true;
            }
            error = DecorateTypeMismatchError(COMPANY_TRADING_NAME, "string");
            return false;
        }

        public bool CreateBankFiles_Validate(object value, ref string error)
        {
            return true;
        }

        public bool BankCode_Validate(object value, ref string error)
        {
            if (value is string)
            {
                string _result = value as string;
                if (!IsAlphabet(_result, 0, 3, out error))
                {
                    error = DecorateError(BANK_CODE, error);
                    return false;
                }
                return true;
            }
            error = DecorateTypeMismatchError(BANK_CODE, "string");
            return false;
        }

        public bool DirectEntryUserID_Validate(object value, ref string error)
        {
            if (value is string)
            {
                string _result = value as string;
                if (!IsAlphabet(_result, 0, 6, out error))
                {
                    error = DecorateError(DIRECT_ENTRY_USER_ID, error);
                    return false;
                }
                return true;
            }
            error = DecorateTypeMismatchError(DIRECT_ENTRY_USER_ID, "string");
            return false;
        }

        public bool IsSelfBalancing_Validate(object value, ref string error)
        {
            return true;
        }

        public bool BankCode_IsVisible()
        {
            return CreateBankFiles;
        }

        public bool DirectEntryUserID_IsVisible()
        {
            return CreateBankFiles;
        }

        public bool IsSelfBalancing_IsVisible()
        {
            return CreateBankFiles;
        }



        public bool CurrentAccountBalance_Validate(object value, ref string error)
        {
            if (value is string)
            {
                if (IsNumeric(value as string, 13, 2, out error))
                {
                    return true;
                }
                error = DecorateError(CURRENT_ACCOUNT_BALANCE, error);
            }
            else
            {
                error = DecorateInputTypeMismatchError(CURRENT_ACCOUNT_BALANCE, "string");
            }
            return false;
        }

        public bool IsTotal
        {
            get { return mDataProxy.IsTotal == "Y"; }
            set
            {
                if (value) mDataProxy.IsTotal = "Y";
                else mDataProxy.IsTotal = "N";
            }
        }

        public bool IsTotal_IsVisible()
        {
            if (mDataProxy.AccountType.IsHeader)
            {
                return true;
            }
            return false;
        }

        public bool IsTotal_Validate(object value, ref string error)
        {
            return true;
        }

        public bool AccountName_Validate(object value, ref string error)
        {
            if (value is string)
            {
                if (IsWithinRange(value as string, 1, 30, out error))
                {
                    return true;
                }
                error = DecorateError(ACCOUNT_NAME, error);
            }
            else
            {
                error = DecorateTypeMismatchError(ACCOUNT_NAME, "string");
            }
            return false;
        }

        public CashFlowClassification CashFlowClassification
        {
            get { return mDataProxy.CashFlowClassification; }
            set { mDataProxy.CashFlowClassification = value; }
        }

        public bool CashFlowClassification_IsVisible()
        {
            if (mDataProxy.AccountType.IsHeader)
            {
                return false;
            }
            if (IsBank)
            {
                return false;
            }
            return true;
        }

        public bool TaxCode_IsVisible()
        {
            if (mDataProxy.AccountType.IsHeader)
            {
                return false;
            }
            return true;
        }

        public bool LinkedAccount_IsEnabled()
        {
            if (mDataProxy.LinkedAccountType == LinkedAccount.LinkAccountType.Unlinked)
            {
                return false;
            }
            return true;
        }

        public bool LinkedAccount_IsVisible()
        {
            if(mDataProxy.AccountType.IsHeader)
            {
                return false;
            }
            return true;
        }

        public bool CashFlowClassification_Validate(object value, ref string error)
        {
            if (value is CashFlowClassification)
            {
                return true;
            }
            error = DecorateTypeMismatchError(CASH_FLOW_CLASSIFICATION, "CashFlowClassification");
            return false;
        }

        public string Description
        {
            get { return mDataProxy.AccountDescription; }
            set { mDataProxy.AccountDescription = value; }
        }

        public bool Description_Validate(object value, ref string error)
        {
            return true;
        }

        public TaxCode TaxCode
        {
            get { return mDataProxy.TaxCode; }
            set { mDataProxy.TaxCode = value; }
        }

        public bool TaxCode_Validate(object value, ref string error)
        {
            if (value is TaxCode) return true;
            error = DecorateTypeMismatchError(TAX_CODE, "TaxCode");
            return false;
        }

        public bool AccountType_IsEnabled()
        {
            if (IsUpdating) return false;
            return true;
        }

        public bool IsActive
        {
            get
            {
                return mDataProxy.IsInactive != "Y";
            }
            set
            {
                if (value) mDataProxy.IsInactive = "N";
                else mDataProxy.IsInactive = "Y";
            }
        }

        public bool IsActive_Validate(object value, ref string error)
        {
            return true;
        }
        

        public bool SubAccountType_IsEnabled()
        {
            if (IsUpdating)
            {
                return false;
            }
            return true;
        }

        public bool AccountClassification_IsEnabled()
        {
            if (IsUpdating) return false;
            if (mDataProxy.AccountType.IsHeader)
            {
                return true;
            }
            return false;
        }

        public bool SubAccountType_IsVisible()
        {
            if (mDataProxy.AccountType.IsHeader)
            {
                return false;
            }
            return true;
        }

        public SubAccountType SubAccountType
        {
            get { return mDataProxy.SubAccountClassification; }
            set { mDataProxy.SubAccountClassification = value; }
        }

        public bool SubAccountType_Validate(object value, ref string error)
        {
            if (value is SubAccountType)
            {
                return true;
            }
            error = DecorateTypeMismatchError(SUB_ACCOUNT_TYPE, "SubAccountType");
            return false;
        }

        public bool AccountClassification_Validate(object value, ref string error)
        {
            return true;
        }

        public AccountClassification AccountClassification
        {
            get { return mDataProxy.AccountClassification; }
            set { mDataProxy.AccountClassification = value; }
        }
        public string AccountNumber
        {
            get { return mDataProxy.AccountNumber; }
            set { mDataProxy.AccountNumber = value; } 
        }

        public string AccountName
        {
            get { return mDataProxy.AccountName; }
            set { mDataProxy.AccountName = value; }
        }

        public AccountType AccountType
        {
            get {
                //Console.WriteLine("{0} : {1} : {2}", mDataProxy.AccountNumber, mDataProxy.AccountTypeID, mDataProxy.AccountType.AccountTypeID);
                return mDataProxy.AccountType; 
            }
            set { mDataProxy.AccountType = value; }
        }

        public bool AccountType_Validate(object value, ref string error)
        {
            if (value == null)
            {
                return true;
            }
            else if (value is AccountType)
            {
                return true;
            }
            error = DecorateTypeMismatchError(ACCOUNT_TYPE, "AccountType");
            return false;
        }

        public bool AccountNumber_Validate(object value, ref string error)
        {
            if (value is string)
            {
                string account_number=value as string;
                if (!IsValidAccountNumber(account_number, out error))
                {
                    error = DecorateError(ACCOUNT_NUMBER, error);
                    return false;
                }
                return true;
            }
            else
            {
                error = DecorateTypeMismatchError(ACCOUNT_NUMBER, "string");
                return false;
            }
        }

        protected override Accounting.Core.OpResult _Delete()
        {
            return mAccountant.AccountMgr.Delete(mDataSource);
        }

        protected override Accounting.Core.OpResult _Record()
        {
            mDataSource.AssignFrom(mDataProxy);
            return mAccountant.AccountMgr.Store(mDataSource);
        }

        public override bool CanEdit
        {
            get
            {
                if (this.RecordContext == BOContext.Record_Create)
                {
                    return mDataProxy.AllowCreate;
                }
                else if (this.RecordContext == BOContext.Record_Update)
                {
                    return mDataProxy.AllowUpdate;
                }
                return false;
            }
        }

        public override bool CanDelete
        {
            get
            {
                return mDataProxy.AllowDelete;
            }
        }

    }
}
