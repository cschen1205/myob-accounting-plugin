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
    Public Class OASSalesAndPurchasesInformation
    {
        DBManager mDBMgr;

        public OASSalesAndPurchasesInformation(DBManager mgr)
        {
            mDBMgr = mgr;
        }

        public void CreateDBs()
        {

            CreateDB_SalesHistory();
            CreateDB_PurchasesHistory();
            CreateDB_SalespersonHistory();
            CreateDB_Comments();   
            CreateDB_Methods();
        }

       private void CreateDB_SalesHistory()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["SalesHistoryID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["FinancialYear"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Period"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SaleAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];

/*
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";       
             * */

            mDBMgr.CreateTable("SalesHistory", fields, "SalesHistoryID", foreignKeys);
        }

        private void CreateDB_PurchasesHistory()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["PurchasesHistoryID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];            
            fields["FinancialYear"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Period"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PurchaseAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];          
            /*
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";        
             * */

            mDBMgr.CreateTable("PurchasesHistory", fields, "PurchasesHistoryID", foreignKeys);
        }

        private void CreateDB_SalespersonHistory()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["SalespersonHistoryID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];            
            fields["FinancialYear"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Period"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SoldAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];     

            /*
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";         
             * */

            mDBMgr.CreateTable("SalespersonHistory", fields, "SalespersonHistoryID", foreignKeys);
        }

        private void CreateDB_Comments()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["CommentID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["Comment"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];

            /*         
             * */

            mDBMgr.CreateTable("Comments", fields, "CommentID", foreignKeys);
        }

        private void CreateDB_Methods()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ShippingMethodID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["ShippingMethod"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
           
            /* 
             * */

            mDBMgr.CreateTable("Methods", fields, "ShippingMethodID", foreignKeys);
        }

        private void CreateDB_ReferralSources()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ReferralSourceID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["ReferralSource"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];

            /*         
             * */

            mDBMgr.CreateTable("ReferralSources", fields, "ReferralSourceID", foreignKeys);
        }
    }
}


