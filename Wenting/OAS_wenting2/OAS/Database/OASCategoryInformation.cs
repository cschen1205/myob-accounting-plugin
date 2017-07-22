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
    public class OASCategoryInformation
    {
        private DBManager mDBMgr;

        public OASCategoryInformation(DBManager mgr)
        {
            mDBMgr = mgr;
        }

        public void CreateDBs()
        {
            CreateDB_Categories();
            CreateDB_CategoryAccounts();
            CreateDB_CategoryAccountActivities();
            CreateDB_CategoryJournalRecords();
        }

        private void CreateDB_Categories()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["CategoryID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CategoryName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["CategoryIdentification"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_15];
            fields["CategoryDescription"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IsInactive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];

            mDBMgr.CreateTable("Categories", fields, "CategoryID", foreignKeys);
        }

        private void CreateDB_CategoryAccounts()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["CategoryAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CategoryID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CurrentBalance"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["PreLastYearActivity"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["LastYearOpeningBalance"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["ThisYearOpeningBalance"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["PostThisYearActivity"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];

            /*
            foreignKeys["CategoryID"] = "Categories(CategoryID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";
             * */

            mDBMgr.CreateTable("CategoryAccounts", fields, "CategoryAccountID", foreignKeys);
        }

        private void CreateDB_CategoryAccountActivities()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["CategoryAccountActivityID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CategoryID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["FinancialYear"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Period"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Amount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];

            /*
            foreignKeys["CategoryID"] = "Categories(CategoryID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";
             * */

            mDBMgr.CreateTable("CategoryAccountActivities", fields, "CategoryAccountActivityID", foreignKeys);
        }

        private void CreateDB_CategoryJournalRecords()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["CategoryJournalRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["TransactionNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["Date"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["TransactionDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["IsThirteenthPeriod"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CategoryID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxExclusiveAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["JournalRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["JournalTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3];

            /*
            foreignKeys["CategoryID"] = "Categories(CategoryID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";
            foreignKeys["JournalRecordID"] = "JournalRecords(JournalRecordID)";
            foreignKeys["JournalTypeID"] = "JournalTypes(JournalTypeID)";
             * */

            mDBMgr.CreateTable("CategoryJournalRecords", fields, "CategoryJournalRecordID", foreignKeys);
        }
    }
}
