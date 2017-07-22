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
    public class OASJournalRecordsAndTransations
    {
        DBManager mDBMgr;

        public OASJournalRecordsAndTransations(DBManager mgr)
        {
            mDBMgr = mgr;
        }

        public void CreateDBs()
        {
            CreateDB_JournalRecords();
            CreateDB_JournalSets();
            CreateDB_GeneralJournals();
            CreateDB_GeneralJournalLines();
            CreateDB_MoneySpent();
            CreateDB_MoneySpentLines();
            CreateDB_MoneyReceived();
            CreateDB_MoneyReceivedLines();
            CreateDB_Sales();
            CreateDB_SaleLines();
            CreateDB_ServiceSaleLines();
            CreateDB_ItemSaleLines();
        }

        private void CreateDB_JournalRecords()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["JournalRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["SetID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Date"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["TransactionDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["IsThirteenthPeriod"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxExclusiveAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["IsMultipleJob"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["EntryIsPurged"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["IsForeignTransaction"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["IsExchangeConversion"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["ReconciliationStatusID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["DateReconciled"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["UserID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["RecordSessionDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["RecordSessionTime"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10]; //store hh:mm:ss

            /*
            foreignKeys["SetID"] = "JournalSets(SetID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["ReconciliationStatusID"] = "ReconciliationStatus(ReconciliationStatusID)";
            foreignKeys["UserID"] = "Users(UserID)";
             * */

            mDBMgr.CreateTable("JournalRecords", fields, "JournalRecordID", foreignKeys);
        }

        private void CreateDB_JournalSets()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["SetID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["JournalTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3];
            fields["SourceID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TransactionNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["Memo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TransactionExchangeRate"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];

            /*
            foreignKeys["JournalTypeID"] = "JournalTypes";
            foreignKeys["SourceID"] = "GeneralJournals(SourceID)";
            foreignKeys["SourceID"] = "MoneySpent(SourceID)";
            foreignKeys["SourceID"] = "MoneyReceived(SourceID)";
            foreignKeys["SourceID"] = "BankDeposits(SourceID)";
            foreignKeys["SourceID"] = "Sales(SourceID)";
            foreignKeys["SourceID"] = "CustomerPayments(SourceID)";
            foreignKeys["SourceID"] = "CustomerFinanceCharges(SourceID)";
            foreignKeys["SourceID"] = "CustomerDiscounts(SourceID)";
            foreignKeys["SourceID"] = "CustomerDeposits(SourceID)";
            foreignKeys["SourceID"] = "SettledCredits(SourceID)";
            foreignKeys["SourceID"] = "CreditRefunds(SourceID)";
            foreignKeys["SourceID"] = "Purchases(SourceID)";
            foreignKeys["SourceID"] = "SupplierPayments(SourceID)";
            foreignKeys["SourceID"] = "SupplierFinanceCharges(SourceID)";
            foreignKeys["SourceID"] = "SupplierDiscounts(SourceID)";
            foreignKeys["SourceID"] = "SupplierDeposits(SourceID)";
            foreignKeys["SourceID"] = "SettledDebits(SourceID)";
            foreignKeys["SourceID"] = "DebitRefunds(SourceID)";
            foreignKeys["SourceID"] = "InventoryAdjustments(SourceID)";
            foreignKeys["SourceID"] = "InventoryTransfers(SourceID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
             * */

            mDBMgr.CreateTable("JournalSets", fields, "SetID", foreignKeys);
        }

        private void CreateDB_GeneralJournals()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["GeneralJournalID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["GeneralJournalNumber"]=mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["Date"]=mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["TransactionDate"]=mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["IsThirteenthPeriod"]=mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["Memo"]=mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IsTaxInclusive"]=mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["IsAutoRecorded"]=mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CurrencyID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TransactionExchangeRate"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["CategoryID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];

            /*
            foreignKeys["CurrencyID"]="Currency(CurrencyID)";
            foreignKeys["CategoryID"] = "Categories(CategoryID)";
             * */

            mDBMgr.CreateTable("GeneralJournals", fields, "GeneralJournalID", foreignKeys);
        }

        private void CreateDB_GeneralJournalLines()
        {
             Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["GeneralJournalLineID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["GeneralJournalID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AccountID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["JobID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["IsMultipleJob"]=mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["TaxExclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["LineMemo"]=mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["TaxCodeID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];

            /*
            foreignKeys["GeneralJournalID"]="GeneralJournals(GeneralJournalID)";
            foreignKeys["AccountID"]="Accounts(AccountID)";
            foreignKeys["JobID"]="Jobs(JobID)";
            foreignKeys["TaxCodeID"]="TaxCodes(TaxCodeID)";
             * */

            mDBMgr.CreateTable("GeneralJournalLines", fields, "GeneralJournalLineID", foreignKeys);
        }

        private void CreateDB_MoneySpent()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["MoneySpentID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["ChequeNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["Date"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["TransactionDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["IsThirteenthPeriod"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["IssuingAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TotalSpentAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Payee"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["PayeeLine1"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["PayeeLine2"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["PayeeLine3"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["PayeeLine4"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["Memo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IsTaxInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["IsAutoRecorded"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TransactionExchangeRate"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["IsPrinted"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["PaymentDeliveryID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CategoryID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];

            /*
            foreignKeys["IssuingAccountID"] = "Accounts(IssuingAccountID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["CardRecordID"]="Customers(CardRecordID)";
            foreignKeys["CardRecordID"] = "Suppliers(CardRecordID)";
            foreignKeys["CardRecordID"] = "Employees(CardRecordID)";
            foreignKeys["CardRecordID"] = "PersonalCards(CardRecordID)";
            foreignKeys["PaymentDeliveryID"] = "InvoiceDelivery(PaymentDeliveryID)";
            foreignKeys["CategoryID"] = "Categories(CategoryID)";
             * */

            mDBMgr.CreateTable("MoneySpent", fields, "MoneySpentID", foreignKeys);
        }

        private void CreateDB_MoneySpentLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["MoneySpentLineID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["MoneySpentID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxExclusiveAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["IsMultipleJob"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineMemo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];

            /*
            foreignKeys["MoneySpentID"] = "MoneySpent(MoneySpentID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
             * */

            mDBMgr.CreateTable("MoneySpentLines", fields, "MoneySpentLineID", foreignKeys);
        }

        private void CreateDB_MoneyReceived()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["MoneyReceivedID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["DepositNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["Date"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["TransactionDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["IsThirteenthPeriod"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["TransactionExchangeRate"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["RecipientAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TotalAmountReceived"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["MethodOfPaymentID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PaymentCardNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_25];
            fields["PaymentNameOnCard"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_50];
            fields["PaymentExpirationDate"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10]; //format: dd/mm
            fields["PaymentAuthorisationNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["PaymentBankAccountNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_11];
            fields["PaymentBankAccountName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_32];
            fields["PaymentChequeNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_25];
            fields["PaymentNotes"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Memo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IsTaxInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["IsAutoRecorded"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["DepositStatusID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CategoryID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];

            /*
            foreignKeys["RecipientAccountID"] = "Accounts(RecipientAccountID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["CardRecordID"] = "Customers(CardRecordID)";
            foreignKeys["CardRecordID"] = "Suppliers(CardRecordID)";
            foreignKeys["CardRecordID"] = "Employees(CardRecordID)";
            foreignKeys["CardRecordID"] = "PersonalCards(CardRecordID)";
            foreignKeys["MethodOfPaymentID"] = "PaymentMethods(MethodOfPaymentID)";
            foreignKeys["DepositStatusID"] = "DepositStatus(DepositStatusID)";
            foreignKeys["CategoryID"] = "Categories(CategoryID)";
             * */

            mDBMgr.CreateTable("MoneyReceived", fields, "MoneyReceivedID", foreignKeys);
        }

        private void CreateDB_MoneyReceivedLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["MoneyReceivedLineID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["MoneyReceivedID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AccountID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxExclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["IsMultipleJob"]=mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["JobID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxCodeID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineMemo"]=mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];

            /*
              foreignKeys["MoneyReceivedID"] = "MoneyReceived(MoneyReceivedID)";
              foreignKeys["AccountID"] = "Accounts(AccountID)";
              foreignKeys["JobID"] = "Jobs(JobID)";
              foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
           * */

            mDBMgr.CreateTable("MoneyReceivedLines", fields, "MoneyReceivedLineID", foreignKeys);
        }

        private void CreateDB_Sales()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["SaleID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["InvoiceNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_8];
            fields["CustomerPONumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_20];
            fields["IsHistorical"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["BackorderSaleID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Date"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["InvoiceDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["IsThirteenthPeriod"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["ShipToAddress"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["ShipToAddressLine1"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["ShipToAddressLine2"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["ShipToAddressLine3"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["ShipToAddressLine4"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["InvoiceTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["InvoiceStatusID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_2];
            fields["TermsID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TotalLines"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxExclusiveFreight"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveFreight"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["FreightTaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TotalTax"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TotalPaid"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TotalDeposits"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TotalCredits"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TotalDiscounts"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["OutstandingBalance"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["SalesPersonID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Memo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["Comment"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["ShippingMethodID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PromisedDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["ReferralSourceID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["IsAutoRecorded"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["IsPrinted"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["InvoiceDeliveryID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["DaysTillPaid"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TransactionExchangeRate"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["CategoryID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LinesPurged"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["PreAuditTrail"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];

            /*
            foreignKeys["CardRecordId"] = "Cards(CardRecordId)";
            foreignKeys["CardRecordId"] = "Customers(CardRecordId)";
            foreignKeys["InvoiceTypeID"] = "InvoiceType(InvoiceTypeID)";
            foreignKeys["InvoiceStatusID"] = "Status(InvoiceStatusID)";
            foreignKeys["TermsID"] = "Terms(TermsID)";
            foreignKeys["SalespersonID"] = "Cards(SalespersonID)";
            foreignKeys["SalespersonID"] = "Employees(SalespersonID)";
            foreignKeys["ReferralSourceID"] = "ReferralSources(ReferralSourceID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
            foreignKeys["InvoiceDeliveryID"] = "InvoiceDelivery(InvoiceDeliveryID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CategoryID"] = "Categories(CategoryID)";
             * */

            mDBMgr.CreateTable("Sales", fields, "SaleID", foreignKeys);
        }

        private void CreateDB_SaleLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["SaleLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["SaleID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["TaxExclusiveAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxBasisAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxBasisAmountIsInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["IsMultipleJob"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];

            /*
            foreignKeys["SaleID"] = "Sales(SaleID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
            */

            mDBMgr.CreateTable("SaleLines", fields, "SaleLineID", foreignKeys);
        }

        private void CreateDB_ServiceSaleLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ServiceSaleLineID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["SaleLineID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SaleID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineTypeID"]=mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["Description"]=mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["AccountID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxExclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxBasisAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxBasisAmountIsInclusive"]=mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["IsMultipleJob"]=mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["JobID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxCodeID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];

            /*
            foreignKeys["SaleLineID"]="SaleLines(SaleLineID)";
            foreignKeys["SaleID"]="Sales(SaleID)";
            foreignKeys["LineTypeID"]="LineType(LineTypeID)";
            foreignKeys["AccountID"]="Accounts(AccountID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
             * */


            mDBMgr.CreateTable("ServiceSaleLines", fields, "ServiceSaleLineID", foreignKeys);
        }

        private void CreateDB_ItemSaleLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["ItemSaleLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["SaleLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SaleID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["TaxExclusiveTotal"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveTotal"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["IsMultipleJob"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxBasisAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxBasisAmountIsInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["Quantity"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["ItemID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SalesTaxCalBasisID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3];
            fields["TaxExclusiveUnitPrice"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveUnitPrice"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["Discount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["CostOfGoodsSoldAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["LocationID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];

            /*
            foreignKeys["SaleID"] = "Sales(SaleID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
            foreignKeys["SaleLineID"] = "SaleLines(SaleLineID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";
            foreignKeys["ItemID"] = "Items(ItemID)";
            foreignKeys["SalesTaxCalBasisID"] = "PriceLevels(SalesTaxCalBasisID)";
            foreignKeys["LocationID"] = "Locations(LocationID)";
             * */

            mDBMgr.CreateTable("ItemSaleLines", fields, "ItemSaleLineID", foreignKeys);
        }

        private void CreateDB_ProfessionalSaleLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["ProfessionalSaleLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["SaleLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SaleID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["LineDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxExclusiveAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxBasisAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxBasisAmountIsInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["IsMultipleJob"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["TaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];

            /*
            foreignKeys["SaleLineID"] = "SaleLines(SaleLineID)";
            foreignKeys["SaleID"] = "Sales(SaleID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
             * */

            mDBMgr.CreateTable("ProfessionalSaleLines", fields, "ProfessionalSaleLineID", foreignKeys);
        }

        private void CreateDB_TimeBillingSaleLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["TimeBillingSaleLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["SaleLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SaleID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["LineDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["HoursUnits"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["ActivityID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Notes"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["TaxExclusiveRate"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveRate"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxExclusiveAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxBasisAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxBasisAmountIsInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["IsMultipleJob"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["TaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["EstimatedCost"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];            
            fields["LocationID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];

           
            /*
            foreignKeys["SaleLineID"] = "SaleLines(SaleLineID)";
            foreignKeys["SaleID"] = "Sales(SaleID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";
            foreignKeys["ActivityID"] = "Activities(ActivityID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";            
            foreignKeys["LocationID"] = "Locations(LocationID)";
              * */

            mDBMgr.CreateTable("TimeBillingSaleLines", fields, "TimeBillingSaleLineID", foreignKeys);
        }

        private void CreateDB_MiscSaleLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["MiscSaleLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["SaleLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SaleID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["TaxExclusiveAmoun"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["IsMultipleJob"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["TaxBasisAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxBasisAmountIsInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["TaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
      
            /*
            foreignKeys["SaleLineID"] = "SaleLines(SaleLineID)";
            foreignKeys["SaleID"] = "Sales(SaleID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";
             * */

            mDBMgr.CreateTable("MiscSaleLines", fields, "MiscSaleLineID", foreignKeys);
        }

        private void CreateDB_Purchases()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["PurchaseID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PurchaseNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_8];
            fields["SupplierInvoiceNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_20];
            fields["IsHistorical"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["BackorderPurchaseID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Date"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["PurchaseDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["IsThirteenthPeriod"] = mDBMgr[DBManager.FIELDTYPEVARCHAR_1.];
            fields["ShipToAddress"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["ShipToAddressLine1"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["ShipToAddressLine2"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["ShipToAddressLine3"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["ShipToAddressLine4"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["PurchaseTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];            
            fields["PurchaseStatusID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_2];
            fields["OrderStatusID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_2];
            fields["ReversalLinkID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER]];
            fields["TermsID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TotalLines"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];            
            fields["TaxExclusiveFreight"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveFreight"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["FreightTaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER]];
            fields["TotalTax"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TotalPaid"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TotalDeposits"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TotalDebits"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TotalDiscounts"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];                    
            fields["OutstandingBalance"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["Memo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["Comment"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["ShippingMethodID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];               
            fields["PromisedDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["IsPrinted"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["InvoiceDeliveryID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["IsAutoRecorded"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];               
            fields["DaysTillPaid"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["IsTaxInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["TransactionExchangeRate"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];               
            fields["CategoryID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LinesPurged"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["PreAuditTrail"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
  
            
            /*
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["PurchaseTypeID"] = "InvoiceType(PurchaseTypeID)";
            foreignKeys["PurchaseStatusID"] = "Status(PurchaseStatusID)";
            foreignKeys["OrderStatusID"] = "OrderStatus(OrderStatusID)";
            foreignKeys["ReversalLinkID"] = "Purchases(ReversalLinkID)";
            foreignKeys["TermsID"] = "Terms(TermsID)";                        
            foreignKeys["FreightTaxCodeID"] = "TaxCodes(FreightTaxCodeID)";
            foreignKeys["ShippingMethodID"] = "Methods(ShippingMethodID)";
            foreignKeys["InvoiceDeliveryID"] = "InvoiceDelivery(InvoiceDeliveryID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CategoryID"] = "Categories(CategoryID)";
             * */

            mDBMgr.CreateTable("Purchases", fields, "PurchaseID", foreignKeys);
        }

        private void CreateDB_PurchaseLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["PurchaseLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["PurchaseID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["TaxExclusiveAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["IsMultipleJob"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxBasisAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxBasisAmountIsInclusive"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];

            /*
            foreignKeys["PurchaseID"] = "(PurchaseID)";
            foreignKeys["LineTypeID"] = "(LineTypeID)";
            foreignKeys["JobID"] = "(JobID)";
            foreignKeys["TaxCodeID"] = "(TaxCodeID)";
             * */

            mDBMgr.CreateTable("PurchaseLines", fields, "PurchaseLineID", foreignKeys);
        }

        private void CreateDB_ServicePurchaseLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["ServicePurchaseLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["PurchaseLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PurchaseID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxExclusiveAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["IsMultipleJob"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxBasisAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxBasisAmountIsInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["TaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];

            /*
            foreignKeys["PurchaseLineID"] = "PurchaseLines(PurchaseLineID)";
            foreignKeys["PurchaseID"] = "Purchases(PurchaseID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";
             * */

            mDBMgr.CreateTable("ServicePurchaseLines", fields, "ServicePurchaseLineID", foreignKeys);
        }

                private void CreateDB_ItemPurchaseLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["ItemPurchaseLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["PurchaseLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PurchaseID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["ItemID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["Quantity"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxExclusiveUnitPrice"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveUnitPrice"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxExclusiveTotal"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveTotal"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["Discount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["IsMultipleJob"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];            
            fields["TaxBasisAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxBasisAmountIsInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["TaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Received"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["LocationID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];            

            /*
            foreignKeys["PurchaseLineID"] = "(PurchaseLineID)";
            foreignKeys["PurchaseID"] = "(PurchaseID)";
            foreignKeys["LineTypeID"] = "(LineTypeID)";
            foreignKeys["ItemID"] = "(ItemID)";
            foreignKeys["JobID"] = "(JobID)";
            foreignKeys["TaxCodeID"] = "(TaxCodeID)";            
            foreignKeys["LocationID"] = "(LocationID)";
             * */

            mDBMgr.CreateTable("ItemPurchaseLines", fields, "ItemPurchaseLineID", foreignKeys);
        }

        private void CreateDB_ProfessionalPurchaseLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["ProfessionalPurchaseLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["PurchaseLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PurchaseID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["TaxExclusiveAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["IsMultipleJob"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["TaxBasisAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxBasisAmountIsInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];            

            /*
            foreignKeys["PurchaseLineID"] = "PurchaseLines(PurchaseLineID)";
            foreignKeys["PurchaseID"] = "Purchases(PurchaseID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";            
             * */

            mDBMgr.CreateTable("ProfessionalPurchaseLines", fields, "ProfessionalPurchaseLineID", foreignKeys);
        }

        private void CreateDB_MiscPurchaseLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["MiscPurchaseLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["PurchaseLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PurchaseID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["TaxExclusiveAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["IsMultipleJob"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxBasisAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxBasisAmountIsInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];

            /*
            foreignKeys["PurchaseLineID"] = "PurchaseLines(PurchaseLineID)";
            foreignKeys["PurchaseID"] = "Purchases(PurchaseID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";            
             * */

            mDBMgr.CreateTable("MiscPurchaseLines", fields, "MiscPurchaseLineID", foreignKeys);
        }

        private void CreateDB_CustomerPayments()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["CustomerPaymentID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CustomerPaymentNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["Date"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["TransactionDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["IsThirteenthPeriod"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["Memo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["MethodOfPaymentID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PaymentCardNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_25];
            fields["PaymentNameOnCard"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_50];
            fields["PaymentExpirationDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["PaymentAuthorisationNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["PaymentBankAccountNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_11];
            fields["PaymentBankAccountName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_32];
            fields["PaymentChequeNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_25];
            fields["IsTaxInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];            
            fields["PaymentNotes"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["FinanceCharge"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TransactionExchangeRate"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];            
            fields["RecipientAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TotalCustomerPayment"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["ExchangeGainLoss"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["DepositStatusID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];

            /*
            foreignKeys["MethodOfPaymentID"] = "PaymentMethods(MethodOfPaymentID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["RecipientAccountID"] = "Accounts(RecipientAccountID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["DepositStatusID"] = "DepositStatus(DepositStatusID)";
            * */

            mDBMgr.CreateTable("CustomerPayments", fields, "CustomerPaymentID", foreignKeys);
        }

        private void CreateDB_CustomerPaymentLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["CustomerPaymentLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CustomerPaymentID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SaleID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AmountApplied"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["IsDepositPayment"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];

            /*
            foreignKeys["CustomerPaymentID"] = "CustomerPayments(CustomerPaymentID)";
            foreignKeys["SaleID"] = "Sales(SaleID)";
             * */

            mDBMgr.CreateTable("CustomerPaymentLines", fields, "CustomerPaymentLineID", foreignKeys);
        }

        private void CreateDB_CustomerFinanceCharges()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["CustomerFinanceChargeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CustomerFinanceChargeNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["Date"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["TransactionDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["IsThirteenthPeriod"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["Memo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TransactionExchangeRate"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["LateChargesAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["FinanceCharge"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ExchangeGainLoss"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["MethodOfPaymentID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PaymentCardNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_25];
            fields["PaymentNameOnCard"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_50];            
            fields["PaymentExpirationDate"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["PaymentAuthorisationNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["PaymentBankAccountNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PaymentBankAccountName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_32];            
            fields["PaymentChequeNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_25];
            fields["IsTaxInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["PaymentNotes"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];

            /*
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["LateChargesAccountID"] = "Accounts(LateChargesAccountID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["MethodOfPaymentID"] = "PaymentMethods(MethodOfPaymentID)";
             * */

            mDBMgr.CreateTable("CustomerFinanceCharges", fields, "CustomerFinanceChargeID", foreignKeys);
        }

        private void CreateDB_CustomerDiscounts()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["CustomerDiscountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CustomerDiscountNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["Date"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["TransactionDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["IsThirteenthPeriod"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["ExchangeGainLoss"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["MethodOfPaymentID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PaymentCardNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_25];
            fields["PaymentNameOnCard"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_50];
            fields["PaymentExpirationDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["PaymentAuthorisationNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["PaymentBankAccountNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_11];
            fields["PaymentBankAccountName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_32];
            fields["PaymentChequeNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_25];
            fields["PaymentNotes"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];            
            fields["Memo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TransactionExchangeRate"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["DiscountAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];            
            fields["TotalDiscount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["IsTaxInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
  
            /*
            foreignKeys["MethodOfPaymentID"] = "PaymentMethods(MethodOfPaymentID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["DiscountAccountID"] = "Accounts(DiscountAccountID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
             * */

            mDBMgr.CreateTable("CustomerDiscounts", fields, "CustomerDiscountID", foreignKeys);
        }

        private void CreateDB_CustomerDiscountLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["CustomerDiscountLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CustomerDiscountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SaleID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AmountApplied"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];

            /*
            foreignKeys["CustomerDiscountID"] = "CustomerDiscounts(CustomerDiscountID)";
            foreignKeys["SaleID"] = "Sales(SaleID)";
             * */

            mDBMgr.CreateTable("CustomerDiscountLines", fields, "CustomerDiscountLineID", foreignKeys);
        }

        private void CreateDB_CustomerDeposits()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["CustomerDepositID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CustomerDepositNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["Date"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["TransactionDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["IsThirteenthPeriod"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["Memo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TransactionExchangeRate"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["CustomerDepositsAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SaleID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["DepositApplied"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["IsTaxInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["ExchangeGainLoss"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];

            /*
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CustomerDepositsAccountID"] = "Accounts(CustomerDepositsAccountID)";
            foreignKeys["SaleID"] = "Sales(SaleID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
             * */

            mDBMgr.CreateTable("CustomerDeposits", fields, "CustomerDepositID", foreignKeys);
        }

        private void CreateDB_SupplierPayments()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["SupplierPaymentID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["SupplierPaymentNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["Date"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["TransactionDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["IsThirteenthPeriod"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["Payee"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["PayeeLine1"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["PayeeLine2"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["PayeeLine3"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["PayeeLine4"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["Memo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IsTaxInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TransactionExchangeRate"] = mDBMgr[DBManager.FIELDTYPE.];
            fields["IssuingAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];            
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TotalSupplierPayment"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["FinanceCharge"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["ExchangeGainLoss"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];            
            fields["IsPrinted"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["PaymentDeliveryID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];

            /*
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["IssuingAccountID"] = "Accounts(IssuingAccountID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["PaymentDeliveryID"] = "InvoiceDelivery(PaymentDeliveryID)";
             * */

            mDBMgr.CreateTable("SupplierPayments", fields, "SupplierPaymentID", foreignKeys);
        }

        private void CreateDB_SupplierPaymentLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["SupplierPaymentLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["SupplierPaymentID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PurchaseID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AmountApplied"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["IsDepositPayment"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];

            /*
            foreignKeys["SupplierPaymentID"] = "SupplierPayments(SupplierPaymentID)";
            foreignKeys["PurchaseID"] = "Purchases(PurchaseID)";
             * */

            mDBMgr.CreateTable("SupplierPaymentLines", fields, "SupplierPaymentLineID", foreignKeys);
        }

        private void CreateDB_SupplierFinanceCharges()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["SupplierFinanceChargeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["SupplierFinanceChargeNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["Date"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["TransactionDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["IsThirteenthPeriod"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["Memo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IsTaxInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TransactionExchangeRate"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["ExchangeGainLoss"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["LateChargesAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["FinanceCharge"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];

            /*
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["LateChargesAccountID"] = "Accounts(LateChargesAccountID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
             * */

            mDBMgr.CreateTable("SupplierFinanceCharges", fields, "SupplierFinanceChargeID", foreignKeys);
        }

        private void CreateDB_SupplierDiscounts()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["SupplierDiscountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["SupplierDiscountNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["Date"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["TransactionDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["IsThirteenthPeriod"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["Memo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IsTaxInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TransactionExchangeRate"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["ExchangeGainLoss"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["DiscountAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TotalDiscount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];

            /*
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["DiscountAccountID"] = "Accounts(DiscountAccountID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
             * */

            mDBMgr.CreateTable("SupplierDiscounts", fields, "SupplierDiscountID", foreignKeys);
        }

        private void CreateDB_SupplierDiscountLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["SupplierDiscountLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["SupplierDiscountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PurchaseID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AmountApplied"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];

            /*
            foreignKeys["SupplierDiscountID"] = "SupplierDiscounts(SupplierDiscountID)";
            foreignKeys["PurchaseID"] = "Purchases(PurchaseID)";
             * */

            mDBMgr.CreateTable("SupplierDiscountLines", fields, "SupplierDiscountLineID", foreignKeys);
        }

        private void CreateDB_SupplierDeposits()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["SupplierDepositID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["SupplierDepositNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["Date"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["TransactionDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["IsThirteenthPeriod"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["Memo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["ExchangeGainLoss"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TransactionExchangeRate"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SupplierDepositAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PurchaseID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["IsTaxInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["DepositApplied"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];

            /*
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["SupplierDepositAccountID"] = "Accounts(SupplierDepositAccountID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["PurchaseID"] = "Purchases(PurchaseID)";
             * */

            mDBMgr.CreateTable("SupplierDeposits", fields, "SupplierDepositID", foreignKeys);
        }

        private void CreateDB_SettledCredits()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["SettledCreditID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["SettledCreditNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["Date"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["TransactionDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["IsThirteenthPeriod"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CreditNoteID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AmountSettled"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["IsDiscount"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["FinanceCharge"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["ExchangeGainLoss"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["CardRecordId"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Memo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["IsTaInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["TransactionExchangeRate"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];

            /*
            foreignKeys["CreditNoteID"] = "Sales(CreditNoteID)";
            foreignKeys["CardRecordId"] = "Cards(CardRecordId)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
                * */

            mDBMgr.CreateTable("SettledCredits", fields, "SettledCreditID", foreignKeys);
        }

        private void CreateDB_SettledCreditLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["SettledCreditLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["SettledCreditID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SaleID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AmountApplied"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["IsDepositPayment"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["IsDiscount"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];

            /*
            foreignKeys["SettledCreditID"] = "SettledCredits(SettledCreditID)";
            foreignKeys["SaleID"] = "Sales(SaleID)";
             * */

            mDBMgr.CreateTable("SettledCreditLines", fields, "SettledCreditLineID", foreignKeys);
        }

        private void CreateDB_CreditRefunds()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["CreditRefundID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["ChequeNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["Date"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["TransactionDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["IsThirteenthPeriod"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];            
            fields["IssuingAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AmountRefunded"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["CreditNoteID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ExchangeGainLoss"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Payee"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["Memo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IsTaxInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["IsPrinted"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["PaymentDeliveryID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TransactionExchangeRate"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];

            /*
            foreignKeys["IssuingAccountID"] = "Accounts(IssuingAccountID)";
            foreignKeys["CreditNoteID"] = "Sales(CreditNoteID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["PaymentDeliveryID"] = "InvoiceDelivery(PaymentDeliveryID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
             * */

            mDBMgr.CreateTable("CreditRefunds", fields, "CreditRefundID", foreignKeys);
        }

        private void CreateDB_SettledDebits()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["SettledDebitID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["SettledDebitNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["Date"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["TransactionDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["IsThirteenthPeriod"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];                       
            fields["DebitNoteID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AmountSettled"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["IsDiscount"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["FinanceCharge"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["ExchangeGainLoss"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Memo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IsTaxInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TransactionExchangeRate"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];

            /*
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["DebitNoteID"] = "Purchases(DebitNoteID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
             * */

            mDBMgr.CreateTable("SettledDebits", fields, "SettledDebitID", foreignKeys);
        }

        private void CreateDB_SettledDebitLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["SettledDebitLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["SettledDebitID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PurchaseID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AmountApplied"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["IsDepositPayment"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["IsDiscount"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];

            /*
            foreignKeys["SettledDebitID"] = "SettledDebits(SettledDebitID)";
            foreignKeys["PurchaseID"] = "Purchases(PurchaseID)";
             * */

            mDBMgr.CreateTable("SettledDebitLines", fields, "SettledDebitLineID", foreignKeys);
        }

        private void CreateDB_DebitRefunds()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["DebitRefundID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["DebitRefundNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["Date"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["TransactionDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["IsThirteenthPeriod"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];                 
            fields["RecipientAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AmountRefunded"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["MethodOfPaymentID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PaymentCardNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_25];
            fields["PaymentNameOnCard"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_50];
            fields["PaymentExpirationDate"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["PaymentAuthorisationNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["PaymentBankAccountNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_11];
            fields["PaymentBankAccountName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_32];
            fields["PaymentChequeNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_25];
            fields["PaymentNotes"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["DepositStatusID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["DebitNoteID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];            
            fields["ExchangeGainLoss"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Memo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IsTaxInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];            
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TransactionExchangeRate"] = mDBMgr[DBManager.FIELDTYPEDOUBLE.DOUBLE];

            /*
            foreignKeys["RecipientAccountID"] = "Accounts(RecipientAccountID)";
            foreignKeys["MethodOfPaymentID"] = "PaymentMethods(MethodOfPaymentID)";
            foreignKeys["DepositStatusID"] = "DepositStatus(DepositStatusID)";
            foreignKeys["DebitNoteID"] = "Purchases(DebitNoteID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";            
             * */

            mDBMgr.CreateTable("DebitRefunds", fields, "DebitRefundID", foreignKeys);
        }

        private void CreateDB_InventoryAdjustments()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["InventoryAdjustmentID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["InventoryJournalNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["Date"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["TransactionDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["IsThirteenthPeriod"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];                 
            fields["Memo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IsTaxInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];            
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];            
            fields["CategoryID"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];

            /*
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CategoryID"] = "Categories(CategoryID)";
            * */

            mDBMgr.CreateTable("InventoryAdjustments", fields, "InventoryAdjustmentID", foreignKeys);
        }

        private void CreateDB_InventoryAdjustmentLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["InventoryAdjustmentLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["InventoryAdjustmentID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ItemID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Quantity"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["UnitCost"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["Amount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["IsMultipleJob"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["IsCOGSAdjustment"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["SaleID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SaleLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LocationID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];

            /*
            foreignKeys["ItemID"] = "Items(ItemID)";
            foreignKeys["AccountID"] = "Account(AccountID)";
            foreignKeys["SaleID"] = "Sales(SaleID)";
            foreignKeys["SaleLineID"] = "SaleLines(SaleLineID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["LocationID"] = "Locations(LocationID)";            
            foreignKeys["InventoryAdjustmentID"] = "InventoryAdjustment(InventoryAdjustmentID)";
             * */

            mDBMgr.CreateTable("InventoryAdjustmentLines", fields, "InventoryAdjustmentLineID", foreignKeys);
        }

        private void CreateDB_InventoryTransfers()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["InventoryTransferID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["InventoryJournalNumber"] = mDBMgr[DBManager.FIELDTYPE.];
            fields["Date"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["TransactionDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["IsThirteenthPeriod"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];                 
            fields["Memo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IsTaxInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];            
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];            
            fields["TransactionExchangeRate"] = mDBMgr[DBManager.FIELDTYPEDOUBLE.DOUBLE];
            fields["CategoryID"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];            

            /*
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CategoryID"] = "Categories(CategoryID)";
             * */

            mDBMgr.CreateTable("InventoryTransfers", fields, "InventoryTransferID", foreignKeys);
        }

        private void CreateDB_InventoryTransferLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["InventoryTransferLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["InventoryTransferID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];            
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ItemID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Quantity"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["UnitCost"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["Amount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];            
            fields["IsMultipleJob"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LocationID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];           

            /*
            foreignKeys["InventoryTransferID"] = "InventoryTransfers(InventoryTransferID)";
            foreignKeys["ItemID"] = "Item(ItemID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["LocationID"] = "Locations(LocationID)";
             * */

            mDBMgr.CreateTable("InventoryTransferLines", fields, "InventoryTransferLineID", foreignKeys);
        }

        private void CreateDB_BankDeposits()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["BankDepositID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["BankDepositNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["Date"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["TransactionDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["IsThirteenthPeriod"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];                 
            fields["RecipientAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AmountDeposited"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["Memo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IsTaxInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];            
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];            
            fields["TransactionExchangeRate"] = mDBMgr[DBManager.FIELDTYPEDOUBLE.DOUBLE];

            /*
            foreignKeys["RecipientAccountID"] = "(RecipientAccountID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
             * */

            mDBMgr.CreateTable("BankDeposits", fields, "BankDepositID", foreignKeys);
        }

        private void CreateDB_BankDepositLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["BankDepositLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["BankDepositID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SourceID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["JournalTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3];
            fields["AmountDeposited"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["DepositStatusID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];

            /*
            foreignKeys["BankDepositID"] = "BankDeposits(BankDepositID)";
            foreignKeys["SourceID"] = "MoneyReceived(SourceID)";
            foreignKeys["JournalTypeID"] = "JournalTypes(JournalTypeID)";
            foreignKeys["DepositStatusID"] = "DepositStatus(DepositStatusID)";
             * */

            mDBMgr.CreateTable("BankDepositLines", fields, "BankDepositLineID", foreignKeys);
        }

        private void CreateDB_TransferMoney()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["TransferMoneyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["TransferNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["Date"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["TransactionDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["FromAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGE];
            fields["ToAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGE];
            fields["Amount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];            
            fields["Memo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IsTaxInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["IsAutoRecorded"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];            
            fields["TransactionExchangeRate"] = mDBMgr[DBManager.FIELDTYPEDOUBLE.DOUBLE];
            fields["CategoryID"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];   

            /*
            foreignKeys["FromAccountID"] = "Accounts(FromAccountID)";
            foreignKeys["ToAccountID"] = "Accounts(ToAccountID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CategoryID"] = "Categories(CategoryID)";
             * */

            mDBMgr.CreateTable("TransferMoney", fields, "TransferMoneyID", foreignKeys);
        }
    }
}
