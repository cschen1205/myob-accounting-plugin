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

Namespace OAS.Database
{
    Public Class OASDefinitions
    {
        DBManager mDBMgr;

        public OASDefinitions(DBManager mgr)
        {
            mDBMgr = mgr;
        }

        public void CreateDBs()
        {

            CreateDB_JournalTypes();
            CreateDB_TaxCodeTypes();
            CreateDB_PriceLevels();
            CreateDB_Identifiers();   
            CreateDB_TermsOfPayment();
            CreateDB_CardTypes();
            CreateDB_AccountClassification();
            CreateDB_AccountType();
            CreateDB_InvoiceType();
            CreateDB_Status();
            CreateDB_BillingRateUse();
            CreateDB_ReconciliationStatus();
            CreateDB_DepositStatus();
            CreateDB_LimitTypes();
            CreateDB_Frequencies();
            CreateDB_Rounding();
            CreateDB_SubAccountTypes();
            CreateDB_CashFlowClassifications();
            CreateDB_LineType();
            CreateDB_InvoiceDelivery();
            CreateDB_AuditTypes();
            CreateDB_OrderStatus();
            CreateDB_Schedule();
            CreateDB_Alerts();
            CreateDB_AlertTypes();
            CreateDB_NumberingTypes();
        }

        private void CreateDB_JournalTypes()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["JournalTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_23];
 
            mDBMgr.CreateTable("JournalTypes", fields, "JournalTypeID", foreignKeys);
        }

        private void CreateDB_TaxCodeTypes()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["TaxCodeTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_22];
            fields["ImportTaxType"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];

            mDBMgr.CreateTable("TaxCodeTypes", fields, "TaxCodeTypeID", foreignKeys);
        }

        private void CreateDB_PriceLevels()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["PriceLevelID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["ImportPriceLevel"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["ImportSalesTaxCalcMethod"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];

            mDBMgr.CreateTable("PriceLevels", fields, "PriceLevelID", foreignKeys);
        }

        private void CreateDB_Identifiers()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["IdentifierID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["ChangeControl"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_5];


            mDBMgr.CreateTable("Identifiers", fields, "IdentifierID", foreignKeys);
        }

        private void CreateDB_TermsOfPayment()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["TermsOfPaymentID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_4_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_52];

            mDBMgr.CreateTable("TermsOfPayment", fields, "TermsOfPaymentID", foreignKeys);
        }

        private void CreateDB_TermsOfPayment()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["TermsOfPaymentID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_4_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_52];

            mDBMgr.CreateTable("TermsOfPayment", fields, "TermsOfPaymentID", foreignKeys);
        }

        private void CreateDB_CardTypes()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["CardTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_8];

            mDBMgr.CreateTable("CardTypes", fields, "CardTypeID", foreignKeys);
        }

        private void CreateDB_AccountClassification()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["AccountClassificationID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_4_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_13];

            mDBMgr.CreateTable("AccountClassification", fields, "AccountClassificationID", foreignKeys);
        }

        private void CreateDB_AccountType()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["AccountTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_14];

            mDBMgr.CreateTable("AccountType", fields, "AccountTypeID", foreignKeys);
        }

        private void CreateDB_InvoiceType()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["InvoiceTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_13];

            mDBMgr.CreateTable("InvoiceType", fields, "InvoiceTypeID", foreignKeys);
        }

        private void CreateDB_Status()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["StatusID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_2_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_14];

            mDBMgr.CreateTable("Status", fields, "StatusID", foreignKeys);
        }

        private void CreateDB_BillingRateUsed()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["BillingRateUsedID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_2_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_7];

            mDBMgr.CreateTable("BillingRateUsed", fields, "BillingRateUsedID", foreignKeys);
        }

        private void CreateDB_ReconciliationStatus()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ReconciliationStatusID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields[""] = mDBMgr[DBManager.FIELDTYPE.];
            fields[""] = mDBMgr[DBManager.FIELDTYPE.];
            fields[""] = mDBMgr[DBManager.FIELDTYPE.];
            fields[""] = mDBMgr[DBManager.FIELDTYPE.];

            mDBMgr.CreateTable("ReconciliationStatus", fields, "ReconciliationStatusID", foreignKeys);
        }

        private void CreateDB_DepositStatus()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["DepositStatusID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_11];

            mDBMgr.CreateTable("DepositStatus", fields, "DepositStatusID", foreignKeys);
        }

        private void CreateDB_LimitTypes()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["LimitTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];

            mDBMgr.CreateTable("LimitTypes", fields, "LimitTypeID", foreignKeys);
        }

        private void CreateDB_Frequencies()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["FrequencyID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_19];

            mDBMgr.CreateTable("Frequencies", fields, "FrequencyID", foreignKeys);
        }

        private void CreateDB_Rounding()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RoundingID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];

            mDBMgr.CreateTable("Rounding", fields, "RoundingID", foreignKeys);
        }

        private void CreateDB_SubAccountTypes()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["SubAccountTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_23];

            mDBMgr.CreateTable("SubAccountTypes", fields, "SubAccountTypeID", foreignKeys);
        }

        private void CreateDB_CashFlowClassifications()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["CashFlowClassID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_35];

            mDBMgr.CreateTable("CashFlowClassifications", fields, "CashFlowClassID", foreignKeys);
        }

        private void CreateDB_LineType()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["LineTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_23];

            mDBMgr.CreateTable("LineType", fields, "LineTypeID", foreignKeys);
        }

        private void CreateDB_InvoiceDelivery()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["InvoiceDeliveryID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];

            mDBMgr.CreateTable("InvoiceDelivery", fields, "InvoiceDeliveryID", foreignKeys);
        }

        private void CreateDB_AuditTypes()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["AuditTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_35];

            mDBMgr.CreateTable("AuditTypes", fields, "AuditTypeID", foreignKeys);
        }

        private void CreateDB_OrderStatus()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["OrderStatusID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_2_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_14];

            mDBMgr.CreateTable("OrderStatus", fields, "OrderStatusID", foreignKeys);
        }

        private void CreateDB_Schedule()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ScheduleID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_14];

            mDBMgr.CreateTable("Schedule", fields, "ScheduleID", foreignKeys);
        }

        private void CreateDB_Alerts()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["AlertID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_14];

            mDBMgr.CreateTable("Alerts", fields, "AlertID", foreignKeys);
        }

        private void CreateDB_AlertTypes()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["AlertTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_14];

            mDBMgr.CreateTable("AlertTypes", fields, "AlertTypeID", foreignKeys);
        }

        private void CreateDB_NumberingTypes()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["NumberingTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3_AUTOINC];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_14];

            mDBMgr.CreateTable("NumberingTypes", fields, "NumberingTypeID", foreignKeys);
        }
    }
}

