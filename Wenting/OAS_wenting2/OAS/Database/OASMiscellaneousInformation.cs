using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

namespace OAS.Database
{
    public class OASMiscellaneousInformation
    {
        private DBManager mDBMgr;

        public OASMiscellaneousInformation(DBManager mgr)
        {
            mDBMgr = mgr;
        }

        public void CreateDBs()
        {
            CreateDB_DataFileInformation();
            CreateDB_LinkedAccounts();
            CreateDB_Terms();
            CreateDB_Address();
            CreateDB_Currency();
            CreateDB_Accounts();
            CreateDB_AccountActivities();
            CreateDB_AccountBudgets();
            CreateDB_PaymentMethods();
            CreateDB_Users();
            CreateDB_ContactLog();
            CreateDB_AuditTrail();
            CreateDB_ImportantDates();
        }

        private void CreateDB_DataFileInformation()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["CompanyName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_40];
            fields["Address"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["Phone"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_20];
            fields["FaxNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_20];
            fields["IRDNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["ServiceTaxNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["CompanyNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_19];
            fields["SalesTaxNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_19];
            fields["Email"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["CurrentFinancialYear"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LastMonthInFinancialYear"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ConversionDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["PeriodsPerYear"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LastPurgeDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["LastBackupDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["DatabaseVersion"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["DataFileCountry"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3];
            fields["DriverBuildNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SerialNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["UseRetailManagerLink"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["UseMultipleCurrencies"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["UseCategories"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CategoriesRequired"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["UseDailyAgeing"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["FirstAgeingPeriod"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SecondAgeingPeriod"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ThirdAgeingPeriod"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["IdentifyAgeByName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["LockPeriodIsActive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["LockPeriodDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["LockThirteenthPeriod"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["DefaultCustomerTermsID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["DefaultCustomerPriceLevelID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3];
            fields["DefaultCustomerTaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["DefaultUseCustomerTaxCode"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["DefaultCustomerFreightTaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["DefaultCustomerCreditLimit"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["DefaultSupplierTermsID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["DefaultSupplierTaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["DefaultUseSupplierTaxCode"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["DefaultSupplierFreightTaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["DefaultSupplierCreditLimit"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["InvoiceSubject"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["InvoiceMessage"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IncludeInvoiceNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["InvoiceQuoteSubject"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["InvoiceQuoteMessage"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IncludeInvoiceQuoteNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["InvoiceOrderSubject"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["InvoiceOrderMessage"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IncludeInvoiceOrderNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["PurchaseSubject"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["PurchaseMessage"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IncludePurchaseNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["PurchaseQuoteSubject"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["PurchaseQuoteMessage"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IncludePurchaseQuoteNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["PurchaseOrderSubject"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["PurchaseOrderMessage"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IncludePurchaseOrderNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["StatementSubject"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["StatementMessage"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["PaymentSubject"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["PaymentMessage"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["UseAuditTracking"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["UseCreditLimitWarning"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["LimitTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["ChangeControl"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_15];
            fields["UseStandardCost"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["UseReceivablesFreight"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["UseReceivablesDeposits"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["UseReceivablesDiscounts"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["UseReceivablesLateFees"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["UsePayablesInventory"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["UsePayablesFreight"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["UsePayablesDeposits"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["UsePayablesDiscounts"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["UsePayablesLateFees"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];

            /*
            foreignKeys["DefaultCustomerTermsID"] = "Terms(DefaultCustomerTermsID)";
            foreignKeys["DefaultCustomerPriceLevelID"] = "PriceLevels(DefaultCustomerPriceLevelID)";
            foreignKeys["DefaultCustomerTaxCodeID"] = "TaxCodes(DefaultCustomerTaxCodeID)";
            foreignKeys["DefaultCustomerFreightTaxCodeID"] = "TaxCodes(DefaultCustomerFreightTaxCodeID)";
            foreignKeys["DefaultSupplierTermsID"] = "Terms(DefaultSupplierTermsID)";
            foreignKeys["DefaultSupplierTaxCodeID"] = "TaxCodes(DefaultSupplierTaxCodeID)";
            foreignKeys["DefaultSupplierFreightTaxCodeID"] = "TaxCodes(DefaultSupplierFreightTaxCodeID)";
            foreignKeys["LimitTypeID"] = "LimitTypes(LimitTypeID)";
             * */

            mDBMgr.CreateTable("DataFileInformation", fields, "", foreignKeys);
        }

        private void CreateDB_LinkedAccounts()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["CurrentEarningsID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["RetainedEarningsID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["HistoricalBalancingID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["UndepositedFundsID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CurrencyGainLossID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ReceivablesAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ReceivablesChequeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ReceivablesFreightID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ReceivablesDepositsID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ReceivablesDiscountsID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ReceivablesLateFeesID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PayablesAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PayablesChequeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PayablesFreightID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PayablesDepositsID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PayablesDiscountsID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PayablesLateFeesID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ChangeControl"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_6];
            fields["PayablesInventoryID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];

            /*
            foreignKeys["CurrentEarningsID"] = "Accounts(CurrentEarningsID)";
            foreignKeys["RetainedEarningsID"] = "Accounts(RetainedEarningsID)";
            foreignKeys["HistoricalBalancingID"] = "Accounts(HistoricalBalancingID)";
            foreignKeys["UndepositedFundsID"] = "Accounts(UndepositedFundsID)";
            foreignKeys["CurrencyGainLossID"] = "Accounts(CurrencyGainLossID)";
            foreignKeys["ReceivablesAccountID"] = "Accounts(ReceivablesAccountID)";
            foreignKeys["ReceivablesChequeID"] = "Accounts(ReceivablesChequeID)";
            foreignKeys["ReceivablesFreightID"] = "Accounts(ReceivablesFreightID)";
            foreignKeys["ReceivablesDepositsID"] = "Accounts(ReceivablesDepositsID)";
            foreignKeys["ReceivablesDiscountsID"] = "Accounts(ReceivablesDiscountsID)";
            foreignKeys["ReceivablesLateFeesID"] = "Accounts(ReceivablesLateFeesID)";
            foreignKeys["PayablesAccountID"] = "Accounts(PayablesAccountID)";
            foreignKeys["PayablesChequeID"] = "Accounts(PayablesChequeID)";
            foreignKeys["PayablesFreightID"] = "Accounts(PayablesFreightID)";
            foreignKeys["PayablesDepositsID"] = "Accounts(PayablesDepositsID)";
            foreignKeys["PayablesDiscountsID"] = "Accounts(PayablesDiscountsID)";
            foreignKeys["PayablesLateFeesID"] = "Accounts(PayablesLateFeesID)";
            foreignKeys["PayablesInventoryID"] = "Accounts(PayablesInventoryID)";
             * */

            mDBMgr.CreateTable("LinkedAccounts", fields, "", foreignKeys);
        }

        private void CreateDB_Terms()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["TermsID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["LatePaymentChargePercent"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["EarlyPaymentDiscountPercent"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TermsOfPaymentID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_4];
            fields["DiscountDays"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["BalanceDueDays"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ImportPaymentIsDue"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["DiscountDate"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_2];
            fields["BalanceDueDate"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_2];

            //foreignKeys["TermsOfPaymentID"] = "TermsOfPayment(TermsOfPaymentID)";

            mDBMgr.CreateTable("Terms", fields, "TermsID", foreignKeys);
        }

        private void CreateDB_Address()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["AddressID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Location"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Street"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_256];
            fields["StreetLine1"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_256];
            fields["StreetLine2"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_256];
            fields["StreetLine3"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_256];
            fields["StreetLine4"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_256];
            fields["City"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_256];
            fields["State"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_256];
            fields["Postcode"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["Country"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_256];
            fields["Phone1"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_21];
            fields["Phone2"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_21];
            fields["Phone3"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_21];
            fields["Fax"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_21];
            fields["Email"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["Salutation"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_15];
            fields["ContactName"]=mDBMgr[DBManager.FIELDTYPE.VARCHAR_25];
            fields["ChangeControl"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_5];
            fields["WWW"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];

            /*
            foreignKeys["CardRecordID"]="Cards(CardRecordID)";
            //foreignKeys["CardRecordID"]="Suppliers(CardRecordID)";
            //foreignKeys["CardRecordID"]="Employees(CardRecordID)";
            //foreignKeys["CardRecordID"] = "PersonalCards(CardRecordID)";
             * */

            mDBMgr.CreateTable("Address", fields, "AddressID", foreignKeys);
        }

        private void CreateDB_Currency()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CurrencyCode"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3];
            fields["CurrencyName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["ExchangeRate"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["CurrencySymbol"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_4];
            fields["DigitGroupingSymbol"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["SymbolPosition"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_13];
            fields["DecimalPlaces"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["NumberDigitsInGroup"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["DecimalPlaceSymbol"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["NegativeFormat"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_25];
            fields["UseLeadingZero"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["LinkedReceivablesAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LinkedReceivablesChequeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LinkedReceivablesFreightID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LinkedReceivablesDepositsID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LinkedReceivablesDiscountsID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LinkedReceivablesLateFeesID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LinkedPayablesAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LinkedPayablesChequeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LinkedPayablesFreightID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LinkedPayablesDepositsID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LinkedPayablesDiscountsID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LinkedPayablesLateFeesID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LinkedPayablesInventoryID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];

            /*
            foreignKeys["LinkedReceivablesAccountID"] = "Accounts(LinkedReceivablesAccountID)";
            foreignKeys["LinkedReceivablesChequeID"] = "Accounts(LinkedReceivablesChequeID)";
            foreignKeys["LinkedReceivablesFreightID"] = "Accounts(LinkedReceivablesFreightID)";
            foreignKeys["LinkedReceivablesDepositsID"] = "Accounts(LinkedReceivablesDepositsID)";
            foreignKeys["LinkedReceivablesDiscountsID"] = "Accounts(LinkedReceivablesDiscountsID)";
            foreignKeys["LinkedReceivablesLateFeesID"] = "Accounts(LinkedReceivablesLateFeesID)";
            foreignKeys["LinkedPayablesAccountID"] = "Accounts(LinkedPayablesAccountID)";
            foreignKeys["LinkedPayablesChequeID"] = "Accounts(LinkedPayablesChequeID)";
            foreignKeys["LinkedPayablesFreightID"] = "Accounts(LinkedPayablesFreightID)";
            foreignKeys["LinkedPayablesDepositsID"] = "Accounts(LinkedPayablesDepositsID)";
            foreignKeys["LinkedPayablesDiscountsID"] = "Accounts(LinkedPayablesDiscountsID)";
            foreignKeys["LinkedPayablesLateFeesID"] = "Accounts(LinkedPayablesLateFeesID)";
            foreignKeys["LinkedPayablesInventoryID"] = "Accounts(LinkedPayablesInventoryID)";
             * */

            mDBMgr.CreateTable("Currency", fields, "CurrencyID", foreignKeys);
        }

        private void CreateDB_Accounts()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["ParentAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["IsInactive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["AccountName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["AccountNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_256];
            fields["TaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CurrencyExchangeAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AccountClassificationID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_4];
            fields["SubAccountClassificationID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_4];
            fields["AccountLevel"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AccountTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["LastChequeNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_8];
            fields["IsReconciled"]=mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["LastReconciledDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["StatementBalance"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["IsCreditBalance"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["OpeningAccountBalance"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["CurrentAccountBalance"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["PreLastYearActivity"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["LastYearOpeningBalance"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["ThisYearOpeningBalance"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["PostThisYearActivity"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["AccountDescription"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IsTotal"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CashFlowClassificationID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3];
            fields["BankAccountNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_20];
            fields["BankAccountName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_32];

            /*
            foreignKeys["ParentAccountID"] = "Accounts(ParentAccountID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CurrencyExchangeAccountID"] = "Accounts(CurrencyExchangeAccountID)";
            foreignKeys["AccountClassificationID"] = "AccountClassification(AccountClassificationID)";
            foreignKeys["SubAccountClassificationID"] = "SubAccountTypes(SubAccountClassificationID)";
            foreignKeys["CashFlowClassificationID"] = "CashFlowClassifications(CashFlowClassificationID)";
            foreignKeys["AccountTypeID"] = "AccountType(AccountTypeID)";
             * */

            mDBMgr.CreateTable("Accounts", fields, "AccountID", foreignKeys);
        }

        private void CreateDB_AccountActivities()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["AccountActivityID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["FinancialYear"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Period"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Amount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];

            //foreignKeys["AccountID"] = "Accounts(AccountID)";

            mDBMgr.CreateTable("AccountActivities", fields, "AccountActivityID", foreignKeys);
        }

        private void CreateDB_AccountBudgets()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["AccountBudgetID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Period"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Amount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["FinancialYear"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];

            //foreignKeys["AccountID"] = "Accounts(AccountID)";

            mDBMgr.CreateTable("AccountBudgets", fields, "AccountBudgetID", foreignKeys);
        }

        private void CreateDB_PaymentMethods()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["PaymentMethodID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["PaymentMethod"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["MethodType"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_11];

            mDBMgr.CreateTable("PaymentMethods", fields, "PaymentMethodID", foreignKeys);
        }

        private void CreateDB_Users()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["UserID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["UserName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_26];
            fields["UseTimeslipsLink"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["UseBillingUnits"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["BillingUnit"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_2];
            fields["RoundCalculatedTime"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["RoundToID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["MinuteIncrement"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3];
            fields["IncludeItemsInTimeBilling"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];

            //foreignKeys["RoundToID"] = "Rounding(RoundToID)";

            mDBMgr.CreateTable("Users", fields, "UserID", foreignKeys);
        }

        private void CreateDB_ContactLog()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ContactLogID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Contact"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["Date"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["LogDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["Notes"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["ElapsedTime"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_6];
            fields["RecontactDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["ChangeControl"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];

            /*
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            //foreignKeys["CardRecordID"] = "Customers(CardRecordID)";
            //foreignKeys["CardRecordID"] = "Employees(CardRecordID)";
            //foreignKeys["CardRecordID"] = "PersonalCards(CardRecordID)";
            //foreignKeys["CardRecordID"] = "Suppliers(CardRecordID)";
             * */


            mDBMgr.CreateTable("ContactLog", fields, "ContactLogID", foreignKeys);

           
        }

        private void CreateDB_AuditTrail()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["AuditTrailID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["AuditTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["TransactionNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["ChangeDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["OriginalDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["WasThirteenthPeriod"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["IsReconciled"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["UserID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];

            //foreignKeys["UserID"] = "Users(UserID)";

            mDBMgr.CreateTable("AuditTrail", fields, "AuditTrailID", foreignKeys);
        }

        private void CreateDB_ImportantDates()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ImportantDatesID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CalendarYear"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["JanuaryDetails"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["FebruaryDetails"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["MarchDetails"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["AprilDetails"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["MayDetails"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["JuneDetails"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["JulyDetails"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["AugustDetails"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["SeptemberDetails"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["OctoberDetails"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["NovemberDetails"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["DecemberDetails"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];

            mDBMgr.CreateTable("ImportantDates", fields, "ImportantDatesID", foreignKeys);
        }
    }
}
