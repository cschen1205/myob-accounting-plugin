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
    Public Class OASTaxRecords
    {
        DBManager mDBMgr;

        public OASTaxRecords(DBManager mgr)
        {
            mDBMgr = mgr;
        }

        public void CreateDBs()
        {
            CreateDB_TaxCodes();
            CreateDB_TaxCodeConsolidations();
            CreateDB_TaxInformation();
            CreateDB_TaxInformationConsolidations();   
        }

        private void CreateDB_TaxCodes()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["TaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["TaxCode"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3];
            fields["TaxCodeDescription"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["TaxPercentageRate"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxCodeTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3];
            fields["TaxCollectedAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxPaidAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LinkedCardID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];

            /*
            foreignKeys["TaxCodeTypeID"] = "TaxCodeConsolidations(TaxCodeTypeID)";
            foreignKeys["TaxCollectedAccountID"] = "Accounts(TaxCollectedAccountID)";
            foreignKeys["TaxPaidAccountID"] = "Accounts(TaxPaidAccountID)";
            foreignKeys["LinkedCardID"] = "Cards(LinkedCardID)";
        
             * */

            mDBMgr.CreateTable("TaxCodes", fields, "TaxCodeID", foreignKeys);
        }

        private void CreateDB_TaxCodeConsolidations()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["TaxCodeConsolidationID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["ConsolidatedTaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ElementTaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];

            /*
            foreignKeys["ConsolidatedTaxCodeID"] = "TaxCodes(ConsolidatedTaxCodeID)";
            foreignKeys["ElementTaxCodeID"] = "TaxCodes(ElementTaxCodeID)";        
             * */

            mDBMgr.CreateTable("TaxCodeConsolidations", fields, "TaxCodeConsolidationID", foreignKeys);
        }

        private void CreateDB_TaxInformation()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["TaxInformationID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["TaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["JournalTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_2];
            fields["TransactionID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxPercentageRate"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxableAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxBasisAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxAmountIsChanged"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
 
            /*
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
            foreignKeys["JournalTypeID"] = "JournalTypes(JournalTypeID)";
            foreignKeys["TransactionID"] = "GeneralJournals(TransactionID)";     
             * */

            mDBMgr.CreateTable("TaxInformation", fields, "TaxInformationID", foreignKeys);
        }

        private void CreateDB_TaxInformationConsolidations()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["TaxInformationConsolidationID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["ConsolidationTaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ElementTaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["JournalTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_2];
            fields["TransactionID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ElementTaxableAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["ElementTaxBasisAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["ElementTaxAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];

            /*
            foreignKeys["ConsolidationTaxCodeID"] = "TaxCodes(ConsolidationTaxCodeID)";
            foreignKeys["ElementTaxCodeID"] = "TaxCodes(ElementTaxCodeID)";
            foreignKeys["JournalTypeID"] = "JournalTypes(JournalTypeID)";
            foreignKeys["TransactionID"] = "GeneralJournals(TransactionID)";           
             * */

            mDBMgr.CreateTable("TaxInformationConsolidations", fields, "TaxInformationConsolidationID", foreignKeys);
        }
    }
}


