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
    public class OASJobInformation
    {
        private DBManager mDBMgr;

        public OASJobInformation(DBManager mgr)
        {
            mDBMgr = mgr;
        }

        public void CreateDBs()
        {
            CreateDB_Jobs();
            CreateDB_JobAccounts();
            CreateDB_JobAccountActivities();
            CreateDB_JobBudgets();
            CreateDB_JobJournalRecords();
        }

        private void CreateDB_Jobs()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["ParentJobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["IsInactive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["JobName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_25];
            fields["JobNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_5];
            fields["IsHeader"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["JobLevel"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["IsTrackingReimburseable"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["JobDescription"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["ContactName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_25];
            fields["Manager"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_25];
            fields["PercentCompleted"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["StartDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["FinishDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["CustomerID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];

            /*
            foreignKeys["ParentJobID"] = "Jobs(ParentJobID)";
            foreignKeys["CustomerID"] = "Customers(CustomerID)";
             * */

            mDBMgr.CreateTable("Jobs", fields, "JobID", foreignKeys);
        }

        private void CreateDB_JobAccounts()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["JobAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["OpeningBalance"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["CurrentBalance"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["PreLastYearActivity"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["LastYearOpeningBalance"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["ThisYearOpeningBalance"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["PostThisYearActivity"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];

            /*
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";
             * */

            mDBMgr.CreateTable("JobAccounts", fields, "JobAccountID", foreignKeys);
        }

        private void CreateDB_JobAccountActivities()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["JobAccountActivityID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["FinancialYear"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Period"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Amount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];

            /*
           foreignKeys["JobID"] = "Jobs(JobID)";
           foreignKeys["AccountID"] = "Accounts(AccountID)";
            * */

            mDBMgr.CreateTable("JobAccountActivities", fields, "JobAccountActivityID", foreignKeys);
        }

        private void CreateDB_JobBudgets()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["JobBudgetID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Amount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];

            /*
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";
             * */

            mDBMgr.CreateTable("JobBudgets", fields, "JobBudgetID", foreignKeys);
        }

        private void CreateDB_JobJournalRecords()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["JobJournalRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["TransactionNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["Date"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["TransactionDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["IsThirteenthPeriod"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxExclusiveAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["JournalRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SalePurchaseLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["JournalTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3];
            fields["IsReimbursed"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["TransactionNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            /*
           foreignKeys["JobID"] = "Jobs(JobID)";
           foreignKeys["AccountID"] = "Accounts(AccountID)";
           foreignKeys["JournalRecordID"] = "JournalRecords(JournalRecordID)";
           foreignKeys["JournalTypeID"] = "JournalTypes(JournalTypeID)";
           //omit foreignKeys for SalePurchaseLineID
            * */

            mDBMgr.CreateTable("JobJournalRecords", fields, "JobJournalRecordID", foreignKeys);
        }

    }
}
