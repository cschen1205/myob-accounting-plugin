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
    public class OASCardInformation
    {
        private DBManager mDBMgr;

        public OASCardInformation(DBManager mgr)
        {
            mDBMgr = mgr;    
        }

        public void CreateDBs()
        {
            CreateDB_Cards();
            CreateDB_Customers();
            CreateDB_Suppliers();
            CreateDB_Employees();
            CreateDB_PersonalCards();
            CreateDB_CardActivities();
        }

        private void CreateDB_Cards()
        {
            //create table: Cards
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CardTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CardIdentification"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_16];
            fields["Name"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_52];
            fields["LastName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_52];
            fields["FirstName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_20];
            fields["ChangeControl"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["IsIndividual"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["IsInactive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Notes"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IdentifierID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_26];
            fields["CustomList1ID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CustomList2ID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CustomList3ID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CustomField1"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["CustomField2"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["CustomField3"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["PaymentDeliveryID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];

            /*
            foreignKeys["CardTypeID"] = "CardTypes(CardTypeID)";
            foreignKeys["CurrencyID"]="Currency(CurrencyID)";
            foreignKeys["IdentifierID"]="Identifiers(IdentifierID)";
            foreignKeys["CustomList1ID"]="CustomLists(CustomList1ID)";
            foreignKeys["CustomList2ID"]="CustomLists(CustomList2ID)";
            foreignKeys["CustomList3ID"] = "CustomLists(CustomList3ID)";
            foreignKeys["PaymentDeliveryID"]="InvoiceDelivery(PaymentDeliveryID)";
             * */

            mDBMgr.CreateTable("Cards", fields, "CardRecordID", foreignKeys);
        }

        private void CreateDB_Customers()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["CustomerID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CardIdentification"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_16];
            fields["Name"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_52];
            fields["LastName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_52];
            fields["FirstName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_20];
            fields["IsIndividual"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["IsInactive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Picture"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["Notes"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IdentifierID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_26];
            fields["CustomList1ID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CustomList2ID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CustomList3ID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CustomField1"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["CustomField2"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["CustomField3"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["TermsID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PriceLevelID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3];
            fields["TaxIDNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_19];
            fields["TaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["FreightTaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["UseCustomerTaxCode"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CreditLimit"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["OnHold"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["VolumeDiscount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["CurrentBalance"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TotalDeposits"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["CustomerSince"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["LastSaleDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["LastPaymentDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["TotalReceivableDays"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TotalPaidInvoices"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["HighestInvoiceAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["HighestReceivableAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["MethodOfPaymentID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PaymentCardNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_25];
            fields["PaymentNameOnCard"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_50];
            fields["PaymentExpiryDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME]; //in MYOB is given by TEXT[yy/mm]
            fields["PaymentNotes"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["HourlyBillingRate"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["SaleLayoutID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["PrintedForm"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_34];
            fields["InvoiceDeliveryID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["IncomeAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ReceiptMemo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["SalespersonID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SaleCommentID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ShippingMethodID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PaymentDeliveryID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["ChangeControl"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_15];

            /*
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["IdentifierID"] = "Identifiers(IdentifierID)";
            foreignKeys["CustomList1ID"] = "CustomLists(CustomList1ID)";
            foreignKeys["CustomList2ID"] = "CustomLists(CustomList2ID)";
            foreignKeys["CustomList3ID"] = "CustomLists(CustomList3ID)";
            foreignKeys["TermsID"] = "Terms(TermsID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
            foreignKeys["MethodOfPaymentID"] = "PaymentMethods(MethodOfPaymentID)";
            foreignKeys["CodeID"] = "TaxCodes(CodeID)";
            foreignKeys["SaleLayoutID"] = "InvoiceType(SaleLayoutID)";
            foreignKeys["PriceLevelID"] = "PriceLevels(PriceLevelID)";
            foreignKeys["SalespersonID"] = "Cards(SalespersonID)";
            //foreignKeys["SalespersonID"]="Employees(SalespersonID)";
            foreignKeys["SaleCommentID"] = "Comments(SaleCommentID)";
            foreignKeys["InvoiceDeliveryID"] = "InvoiceDelivery(InvoiceDeliveryID)";
            foreignKeys["IncomeAccountID"] = "Accounts(IncomeAccountID)";
            foreignKeys["ShippingMethodID"] = "Methods(ShippingMethodID)";
            foreignKeys["PaymentDeliveryID"] = "InvoiceDelivery(PaymentDeliveryID)";
            * */

            mDBMgr.CreateTable("Customers", fields, "CustomerID", foreignKeys);
        }

        private void CreateDB_Suppliers()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["SupplierID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CardIdentification"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_16];
            fields["Name"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_52];
            fields["LastName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_52];
            fields["FirstName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_20];
            fields["IsIndividual"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["IsInactive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Picture"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["Notes"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IdentifierID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_26];
            fields["CustomList1ID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CustomList2ID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CustomList3ID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CustomField1"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["CustomField2"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["CustomField3"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["TermsID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxIDNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_19];
            fields["TaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["FreightTaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["UseSupplierTaxCode"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CreditLimit"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["VolumeDiscount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["CurrentBalance"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TotalDeposits"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["SupplierSince"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["LastPuchaseDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["LastPaymentDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["TotalPayableDays"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TotalPaidPurchases"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["HighestPurchaseAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["HighestPayableAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["EstimatedCostPerHour"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["HourlyBillingRate"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["PurchaseLayoutID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["PrintedForm"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_34];
            fields["InvoiceDeliveryID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["ExpenseAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PaymentMemo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["PurchaseCommentID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ShippingMethodID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PaymentDeliveryID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["ChangeControl"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];

            /*
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["IdentifierID"] = "Identifiers(IdentifierID)";
            foreignKeys["CustomList1ID"] = "CustomLists(CustomList1ID)";
            foreignKeys["CustomList2ID"] = "CustomLists(CustomList2ID)";
            foreignKeys["CustomList3ID"] = "CustomLists(CustomList3ID)";
            foreignKeys["TermsID"] = "Terms(TermsID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
            foreignKeys["PurchaseLayoutID"] = "InvoiceType(PurchaseLayoutID)";
            foreignKeys["PurchaseCommentID"] = "Comments(PurchaseCommentID)";
            foreignKeys["InvoiceDeliveryID"] = "InvoiceDelivery(InvoiceDeliveryID)";
            foreignKeys["ExpenseAccountID"] = "Accounts(ExpenseAccountID)";
            foreignKeys["ShippingMethodID"] = "Methods(ShippingMethodID)";
            foreignKeys["PaymentDeliveryID"] = "InvoiceDelivery(PaymentDeliveryID)";
             * */

            mDBMgr.CreateTable("Suppliers", fields, "SupplierID", foreignKeys);
        }

        private void CreateDB_Employees()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["EmployeeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CardIdentification"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_16];
            fields["Name"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_52];
            fields["LastName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_52];
            fields["FirstName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_20];
            fields["IsIndividual"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["IsInactive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Picture"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["Notes"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IdentifierID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_26];
            fields["CustomList1ID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CustomList2ID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CustomList3ID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CustomField1"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["CustomField2"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["CustomField3"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["HourlyBillingRate"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["EstimatedCostPerHour"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["PaymentDeliveryID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["ChangeControl"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_20];

            /*
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["IdentifierID"] = "Identifiers(IdentifierID)";
            foreignKeys["CustomList1ID"] = "CustomLists(CustomList1ID)";
            foreignKeys["CustomList2ID"] = "CustomLists(CustomList2ID)";
            foreignKeys["CustomList3ID"] = "CustomLists(CustomList3ID)";
            foreignKeys["PaymentDeliveryID"] = "InvoiceDelivery(PaymentDeliveryID)";
             * */

            mDBMgr.CreateTable("Employees", fields, "EmployeeID", foreignKeys);
        }

        private void CreateDB_PersonalCards()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["PersonalCardID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CardIdentification"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_16];
            fields["Name"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_52];
            fields["LastName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_52];
            fields["FirstName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_20];
            fields["ChangeControl"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["IsIndividual"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["IsInactive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Notes"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IdentifierID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_26];
            fields["CustomList1ID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CustomList2ID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CustomList3ID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CustomField1"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["CustomField2"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["CustomField3"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["PaymentDeliveryID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["Picture"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];

            /*
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["IdentifierID"] = "Identifiers(IdentifierID)";
            foreignKeys["CustomList1ID"] = "CustomLists(CustomList1ID)";
            foreignKeys["CustomList2ID"] = "CustomLists(CustomList2ID)";
            foreignKeys["CustomList3ID"] = "CustomLists(CustomList3ID)";
            foreignKeys["PaymentDeliveryID"] = "InvoiceDelivery(PaymentDeliveryID)";
             * */

            mDBMgr.CreateTable("PersonalCards", fields, "PersonalCardID", foreignKeys);
        }

        private void CreateDB_CardActivities()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["CardActivityID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["FinancialYear"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Period"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["DollarsSold"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];

            /*
            foreignKeys["CardRecordID"]="Cards(CardRecordID)";
            //foreignKeys["CardRecordID"]="Customers(CardRecordID)";
            //foreignKeys["CardRecordID"]="Suppliers(CardRecordID)";
            //foreignKeys["CardRecordID"]="Employees(CardRecordID)";
            //foreignKeys["CardRecordID"] = "PersonalCards(CardRecordID)";
             * */

            mDBMgr.CreateTable("CardActivities", fields, "CardActivityID", foreignKeys);
        }
    }
}
