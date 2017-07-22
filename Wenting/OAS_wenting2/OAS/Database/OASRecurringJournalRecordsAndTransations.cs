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
    Public Class OASRecurringJournalRecordsAndTransations
    {
        DBManager mDBMgr;

        public OASRecurringJournalRecordsAndTransations(DBManager mgr)
        {
            mDBMgr = mgr;
        }

        public void CreateDBs()
        {
            CreateDB_RecurringMoneySpent();
            CreateDB_RecurringMoneySpentLines();
            CreateDB_RecurringMoneyReceived();
            CreateDB_RecurringMoneyReceivedLines();
            CreateDB_RecurringTransferMoney();
            CreateDB_RecurringGeneralJournals();
            CreateDB_RecurringGeneralJournalLines();
            CreateDB_RecurringSales();
            CreateDB_RecurringSaleLines();
            CreateDB_RecurringServiceSaleLines();
            CreateDB_RecurringItemSaleLines();
            CreateDB_RecurringProfessionalSaleLines();            
            CreateDB_RecurringTimeBillingSaleLines();
            CreateDB_RecurringMiscSaleLines();       
            CreateDB_RecurringPurchases();
            CreateDB_RecurringPurchaseLines();
            CreateDB_RecurringServicePurchaseLines();
            CreateDB_RecurringItemPurchaseLines();
            CreateDB_RecurringProfessionalPurchaseLines();
            CreateDB_RecurringMiscPurchaseLines();           
        }

        private void CreateDB_RecurringMoneySpent()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringMoneySpentID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
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
            fields["PaymentDeliveryID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];            
            fields["CategoryID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];   
            fields["RecurringName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["FrequencyID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_2];
            fields["StartingOn"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["NextDue"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["RepeatedOn"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["ScheduleID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["ContinueUntil"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["PerformTimes"] = mDBMgr[DBManager.FIELDTYPE.INTEGER]; 
            fields["RemainingTime"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AlertID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["AlertUserID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AlertTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["DaysInAdvance"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["NumberingTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];             
            fields["AppliedNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_8];
            fields["RetainChanges"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["LastPosted"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];

            /*
            foreignKeys["IssuingAccountID"] = "Accounts(IssuingAccountID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["PaymentDeliveryID"] = "InvoiceDelivery(PaymentDeliveryID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CategoryID"] = "Categories(CategoryID)";                        
            foreignKeys["FrequencyID"] = "Frequencies(FrequencyID)";
            foreignKeys["ScheduleID"] = "Schedule(ScheduleID)";
            foreignKeys["AlertID"] = "Alerts(AlertID)";
            foreignKeys["AlertUserID"] = "Users(AlertUserID)";
            foreignKeys["AlertTypeID"] = "AlertTypes(AlertTypeID)";
            foreignKeys["NumberingTypeID"] = "NumberingTypes(NumberingTypeID)";            
             * */

            mDBMgr.CreateTable("RecurringMoneySpent", fields, "RecurringMoneySpentID", foreignKeys);
        }

        private void CreateDB_RecurringMoneySpentLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringMoneySpentLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["RecurringMoneySpentID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxExclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineMemo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];            
            fields["TaxCodeID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];          
            /*
            foreignKeys["RecurringMoneySpentID"] = "RecurringMoneySpent(RecurringMoneySpentID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";          
            * */

            mDBMgr.CreateTable("RecurringMoneySpentLines", fields, "RecurringMoneySpentLineID", foreignKeys);
        }

        private void CreateDB_RecurringMoneyReceived()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringMoneyReceivedID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["RecipientAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TotalAmountReceived"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["MethodOfPaymentID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PaymentCardNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_25];
            fields["PaymentNameOnCard"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_50];
            fields["PaymentExpirationDate"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_5];
            fields["PaymentNotes"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Memo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IsTaxInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];            
            fields["CategoryID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];  
            fields["RecurringName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["FrequencyID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_2];
            fields["StartingOn"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["NextDue"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["RepeatedOn"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["ScheduleID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["ContinueUntil"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["PerformTimes"] = mDBMgr[DBManager.FIELDTYPE.INTEGER]; 
            fields["RemainingTime"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AlertID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["AlertUserID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AlertTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["DaysInAdvance"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["NumberingTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];             
            fields["AppliedNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_8];
            fields["RetainChanges"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["LastPosted"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];            

/*
            foreignKeys["RecipientAccountID"] = "Accounts(RecipientAccountID)";
            foreignKeys["MethodOfPaymentID"] = "PaymentMethods(MethodOfPaymentID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CategoryID"] = "Categories(CategoryID)";                        
            foreignKeys["FrequencyID"] = "Frequencies(FrequencyID)";
            foreignKeys["ScheduleID"] = "Schedule(ScheduleID)";
            foreignKeys["AlertID"] = "Alerts(AlertID)";
            foreignKeys["AlertUserID"] = "Users(AlertUserID)";
            foreignKeys["AlertTypeID"] = "AlertTypes(AlertTypeID)";
            foreignKeys["NumberingTypeID"] = "NumberingTypes(NumberingTypeID)";               
             * */

            mDBMgr.CreateTable("RecurringMoneyReceived", fields, "RecurringMoneyReceivedID", foreignKeys);
        }

        private void CreateDB_RecurringMoneyReceivedLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringMoneyReceivedLines"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["RecurringMoneyReceivedID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxExclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineMemo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];            
            fields["TaxCodeID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];          

            /*
            foreignKeys["RecurringMoneyReceivedID"] = "RecurringMoneyReceived(RecurringMoneyReceivedID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";                  
             * */

            mDBMgr.CreateTable("RecurringMoneyReceivedLines", fields, "RecurringMoneyReceivedLines", foreignKeys);
        }

        private void CreateDB_RecurringTransferMoney()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringTransferMoneyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["FromAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ToAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Amount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["Memo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IsTaxInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];            
            fields["CategoryID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];  
            fields["RecurringName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["FrequencyID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_2];
            fields["StartingOn"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["NextDue"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["RepeatedOn"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["ScheduleID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["ContinueUntil"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["PerformTimes"] = mDBMgr[DBManager.FIELDTYPE.INTEGER]; 
            fields["RemainingTime"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AlertID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["AlertUserID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AlertTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["DaysInAdvance"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["NumberingTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];             
            fields["AppliedNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_8];
            fields["RetainChanges"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["LastPosted"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];     

            /*
            foreignKeys["FromAccountID"] = "Accounts(FromAccountID)";
            foreignKeys["ToAccountID"] = "Accounts(ToAccountID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CategoryID"] = "Categories(CategoryID)";                        
            foreignKeys["FrequencyID"] = "Frequencies(FrequencyID)";
            foreignKeys["ScheduleID"] = "Schedule(ScheduleID)";
            foreignKeys["AlertID"] = "Alerts(AlertID)";
            foreignKeys["AlertUserID"] = "Users(AlertUserID)";
            foreignKeys["AlertTypeID"] = "AlertTypes(AlertTypeID)";
            foreignKeys["NumberingTypeID"] = "NumberingTypes(NumberingTypeID)";              
             * */

            mDBMgr.CreateTable("RecurringTransferMoney", fields, "RecurringTransferMoneyID", foreignKeys);
        }

        private void CreateDB_RecurringGeneralJournals()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringGeneralJournalID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["Memo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["IsTaxInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];            
            fields["CategoryID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];  
            fields["RecurringName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["FrequencyID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_2];
            fields["StartingOn"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["NextDue"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["RepeatedOn"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["ScheduleID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["ContinueUntil"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["PerformTimes"] = mDBMgr[DBManager.FIELDTYPE.INTEGER]; 
            fields["RemainingTime"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AlertID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["AlertUserID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AlertTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["DaysInAdvance"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["NumberingTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];             
            /*
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CategoryID"] = "Categories(CategoryID)";                        
            foreignKeys["FrequencyID"] = "Frequencies(FrequencyID)";
            foreignKeys["ScheduleID"] = "Schedule(ScheduleID)";
            foreignKeys["AlertID"] = "Alerts(AlertID)";
            foreignKeys["AlertUserID"] = "Users(AlertUserID)";
            foreignKeys["AlertTypeID"] = "AlertTypes(AlertTypeID)";
            foreignKeys["NumberingTypeID"] = "NumberingTypes(NumberingTypeID)";               
             * */

            mDBMgr.CreateTable("RecurringGeneralJournals", fields, "RecurringGeneralJournalID", foreignKeys);
        }

        private void CreateDB_RecurringGeneralJournalLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringGeneralJournalLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["RecurringGeneralJournalID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxExclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineMemo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];            
            fields["TaxCodeID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];               
            /*
            foreignKeys["RecurringGeneralJournalID"] = "RecurringGeneralJournals(RecurringGeneralJournalID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";                 
             * */

            mDBMgr.CreateTable("RecurringGeneralJournalLines", fields, "RecurringGeneralJournalLineID", foreignKeys);
        }

        private void CreateDB_RecurringSales()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringSaleID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ShipToAddress"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["ShipToAddressLine1"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["ShipToAddressLine2"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["ShipToAddressLine3"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["ShipToAddressLine4"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["InvoiceTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["InvoiceStatusID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_2];
            fields["TermsID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxExclusiveFreight"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveFreight"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["FreightTaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SalesPersonID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Memo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["Comment"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["ShippingMethodID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ReferralSourceID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["IsTaxInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["InvoiceDeliveryID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];            
            fields["CategoryID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];  
            fields["RecurringName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["FrequencyID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_2];
            fields["StartingOn"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["NextDue"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["RepeatedOn"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["ScheduleID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["ContinueUntil"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["PerformTimes"] = mDBMgr[DBManager.FIELDTYPE.INTEGER]; 
            fields["RemainingTime"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AlertID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["AlertUserID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AlertTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["DaysInAdvance"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["NumberingTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];   
            fields["AppliedNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_8];
            fields["RetainChanges"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["LastPosted"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];                 
            /*
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["InvoiceTypeID"] = "InvoiceType(InvoiceTypeID)";
            foreignKeys["InvoiceStatusID"] = "Status(InvoiceStatusID)";
            foreignKeys["TermsID"] = "Terms(TermsID)";
            foreignKeys["FreightTaxCodeID"] = "TaxCodes(FreightTaxCodeID)";                        
            foreignKeys["SalesPersonID"] = "Cards(SalesPersonID)";
            foreignKeys["ShippingMethodID"] = "Methods(ShippingMethodID)";
            foreignKeys["ReferralSourceID"] = "ReferralSources(ReferralSourceID)";
            foreignKeys["InvoiceDeliveryID"] = "InvoiceDelivery(InvoiceDeliveryID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CategoryID"] = "Categories(CategoryID)";                        
            foreignKeys["FrequencyID"] = "Frequencies(FrequencyID)";
            foreignKeys["ScheduleID"] = "Schedule(ScheduleID)";
            foreignKeys["AlertID"] = "Alerts(AlertID)";
            foreignKeys["AlertUserID"] = "Users(AlertUserID)";
            foreignKeys["AlertTypeID"] = "AlertTypes(AlertTypeID)";
            foreignKeys["NumberingTypeID"] = "NumberingTypes(NumberingTypeID)";                                 
             * */

            mDBMgr.CreateTable("RecurringSales", fields, "RecurringSaleID", foreignKeys);
        }

        private void CreateDB_RecurringSaleLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringSaleLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["RecurringSaleID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["TaxExclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineMemo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];            
            fields["TaxCodeID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];  
            fields["TaxBasisAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxBasisAmountIsInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];

            /*
            foreignKeys["RecurringSaleID"] = "RecurringSales(RecurringSaleID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";                 
             * */

            mDBMgr.CreateTable("RecurringSaleLines", fields, "RecurringSaleLineID", foreignKeys);
        }

        private void CreateDB_RecurringServiceSaleLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringServiceSaleLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["RecurringSaleLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["RecurringSaleID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["TaxExclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];      
            fields["TaxCodeID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];  
            fields["TaxBasisAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxBasisAmountIsInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];           

            /*
            foreignKeys["RecurringSaleLineID"] = "RecurringSaleLines(RecurringSaleLineID)";
            foreignKeys["AccountID"] = "Account(AccountID)";
            foreignKeys["RecurringSaleID"] = "RecurringSales(RecurringSaleID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";          
             * */

            mDBMgr.CreateTable("RecurringServiceSaleLines", fields, "RecurringServiceSaleLineID", foreignKeys);
        }

        private void CreateDB_RecurringItemSaleLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringItemSaleLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["RecurringSaleLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["RecurringSaleID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["Quantity"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["ItemID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["LocationID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxExclusiveUnitPrice"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveUnitPrice"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["Discount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxExclusiveTotal"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveTotal"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];      
            fields["TaxCodeID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];  
            fields["SalesTaxCalBasisID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3];
            fields["TaxBasisAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            /*
            foreignKeys["ItemID"] = "Items(ItemID)";
            foreignKeys["LocationID"] = "Locations(LocationID)";
            foreignKeys["SalesTaxCalBasisID"] = "PriceLevels(SalesTaxCalBasisID)";
            foreignKeys["RecurringSaleLineID"] = "RecurringSaleLines(RecurringSaleLineID)";
            foreignKeys["RecurringSaleID"] = "RecurringSales(RecurringSaleID)";          
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";                        
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";              
             * */

            mDBMgr.CreateTable("RecurringItemSaleLines", fields, "RecurringItemSaleLineID", foreignKeys);
        }

        private void CreateDB_RecurringProfessionalSaleLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringProfessionalSaleLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["RecurringSaleLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["RecurringSaleID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["LineDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];      
            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxExclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];      
            fields["TaxCodeID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];  
            fields["TaxBasisAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxBasisAmountIsInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];             
            /*
            foreignKeys["RecurringSaleLineID"] = "RecurringSaleLines(RecurringSaleLineID)";
            foreignKeys["RecurringSaleID"] = "RecurringSales(RecurringSaleID)";          
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";                        
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";      
            foreignKeys["AccountID"] = "Account(AccountID)";         
             * */

            mDBMgr.CreateTable("RecurringProfessionalSaleLines", fields, "RecurringProfessionalSaleLineID", foreignKeys);
        }

        private void CreateDB_RecurringTimeBillingSaleLine()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringTimeBillingSaleLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["RecurringSaleLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["RecurringSaleID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["LineDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["HoursUnits"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE]];
            fields["ActivityID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LocationID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxExclusiveRate"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE]];
            fields["TaxInclusiveRate"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE]];
            fields["TaxExclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineMemo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];            
            fields["TaxCodeID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];  
            fields["TaxBasisAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxBasisAmountIsInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];           
            /*
            foreignKeys["RecurringSaleLineID"] = "RecurringSaleLines(RecurringSaleLineID)";
            foreignKeys["RecurringSaleID"] = "RecurringSales(RecurringSaleID)";          
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";   
            foreignKeys["ActivityID"] = "Activity(ActivityID)";
            foreignKeys["LocationID"] = "Locations(LocationID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";           
             * */

            mDBMgr.CreateTable("RecurringTimeBillingSaleLine", fields, "RecurringTimeBillingSaleLineID", foreignKeys);
        }

        private void CreateDB_RecurringMiscSaleLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringMiscSaleLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["RecurringSaleLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["RecurringSaleID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];      
            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxExclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];      
            fields["TaxCodeID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];  
            fields["TaxBasisAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxBasisAmountIsInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];             

            /*
            foreignKeys["RecurringSaleLineID"] = "RecurringSaleLines(RecurringSaleLineID)";
            foreignKeys["RecurringSaleID"] = "RecurringSales(RecurringSaleID)";          
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";                        
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";      
            foreignKeys["AccountID"] = "Account(AccountID)";              
             * */

            mDBMgr.CreateTable("RecurringMiscSaleLines", fields, "RecurringMiscSaleLineID", foreignKeys);
        }

        private void CreateDB_RecurringPurchases()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringPurchaseID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CardRecordID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ShipToAddress"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["ShipToAddressLine1"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["ShipToAddressLine2"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["ShipToAddressLine3"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["ShipToAddressLine4"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];          
            fields["PurchaseTypeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TermsID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxExclusiveFreight"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveFreight"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["FreightTaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Memo"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["Comment"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["ShippingMethodID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["IsTaxInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["InvoiceDeliveryID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CurrencyID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];            
            fields["CategoryID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];  
            fields["RecurringName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["FrequencyID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_2];
            fields["StartingOn"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["NextDue"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["RepeatedOn"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["ScheduleID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["ContinueUntil"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["PerformTimes"] = mDBMgr[DBManager.FIELDTYPE.INTEGER]; 
            fields["RemainingTime"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AlertID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["AlertUserID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["AlertTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["DaysInAdvance"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["NumberingTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];   
            fields["AppliedNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_8];
            fields["RetainChanges"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["LastPosted"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];                 

            /*
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["PurchaseTypeID"] = "InvoiceType(PurchaseTypeID)";
            foreignKeys["PurchaseStatusID"] = "Status(PurchaseStatusID)";
            foreignKeys["TermsID"] = "Terms(TermsID)";
            foreignKeys["FreightTaxCodeID"] = "TaxCodes(FreightTaxCodeID)";                        
            foreignKeys["SalesPersonID"] = "Cards(SalesPersonID)";
            foreignKeys["ShippingMethodID"] = "Methods(ShippingMethodID)";
            foreignKeys["InvoiceDeliveryID"] = "InvoiceDelivery(InvoiceDeliveryID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CategoryID"] = "Categories(CategoryID)";                        
            foreignKeys["FrequencyID"] = "Frequencies(FrequencyID)";
            foreignKeys["ScheduleID"] = "Schedule(ScheduleID)";
            foreignKeys["AlertID"] = "Alerts(AlertID)";
            foreignKeys["AlertUserID"] = "Users(AlertUserID)";
            foreignKeys["AlertTypeID"] = "AlertTypes(AlertTypeID)";
            foreignKeys["NumberingTypeID"] = "NumberingTypes(NumberingTypeID)";                
             * */

            mDBMgr.CreateTable("RecurringPurchases", fields, "RecurringPurchaseID", foreignKeys);
        }

        private void CreateDB_RecurringPurchaseLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringPurchaseLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["RecurringPurchaseID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];          
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];      
            fields["TaxExclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];      
            fields["TaxCodeID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];  
            fields["TaxBasisAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxBasisAmountIsInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];     

            /*
            foreignKeys["RecurringPurchasesID"] = "RecurringPurchases(RecurringPurchasesID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";                        
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";           
             * */

            mDBMgr.CreateTable("RecurringPurchaseLines", fields, "RecurringPurchaseLineID", foreignKeys);
        }

        private void CreateDB_RecurringServicePurchaseLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringServicePurchaseLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["RecurringPurchaseLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["RecurringPurchaseID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER]; 
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];      
            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxExclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];      
            fields["TaxCodeID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];  
            fields["TaxBasisAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxBasisAmountIsInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];                
            /*
            foreignKeys["RecurringPurchaseLineID"] = "RecurringPurchaseLine(RecurringPurchaseLineID)";
            foreignKeys["RecurringPurchasesID"] = "RecurringPurchases(RecurringPurchasesID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";                        
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)"; 
            foreignKeys["AccountID"] = "Account(AccountID)";              
             * */

            mDBMgr.CreateTable("RecurringServicePurchaseLines", fields, "RecurringServicePurchaseLineID", foreignKeys);
        }

        private void CreateDB_RecurringItemPurchaseLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringItemPurchaseLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["RecurringPurchaseLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["RecurringPurchaseID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER]; 
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["Quantity"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["ItemID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["LocationID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxExclusiveUnitPrice"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveUnitPrice"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["Discount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxExclusiveTotal"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveTotal"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];      
            fields["TaxCodeID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxBasisAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxBasisAmountIsInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
          
            /*
            foreignKeys["RecurringPurchaseLineID"] = "RecurringPurchaseLine(RecurringPurchaseLineID)";
            foreignKeys["RecurringPurchasesID"] = "RecurringPurchases(RecurringPurchasesID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";  
            foreignKeys["ItemID"] = "Items(ItemID)";
            foreignKeys["LocationID"] = "Locations(LocationID)";              
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)"       
             * */

            mDBMgr.CreateTable("RecurringItemPurchaseLines", fields, "RecurringItemPurchaseLineID", foreignKeys);
        }

        private void CreateDB_RecurringProfessionalPurchaseLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringProfessionalPurchaseLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["RecurringPurchaseLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["RecurringPurchaseID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER]; 
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["LineDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];      
            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxExclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];      
            fields["TaxCodeID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];  
            fields["TaxBasisAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxBasisAmountIsInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1]; 

            /*
            foreignKeys["RecurringPurchaseLineID"] = "RecurringPurchaseLine(RecurringPurchaseLineID)";
            foreignKeys["RecurringPurchasesID"] = "RecurringPurchases(RecurringPurchasesID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";  
            foreignKeys["AccountID"] = "Accounts(AccountID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)"             
             * */

            mDBMgr.CreateTable("RecurringProfessionalPurchaseLines", fields, "RecurringProfessionalPurchaseLineID", foreignKeys);
        }

        private void CreateDB_RecurringMiscPurchaseLines()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringMiscPurchaseLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["RecurringPurchaseLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["RecurringPurchaseID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER]; 
            fields["LineNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LineTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];      
            fields["AccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxExclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxInclusiveAmount"]=mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];      
            fields["TaxCodeID"]=mDBMgr[DBManager.FIELDTYPE.INTEGER];  
            fields["TaxBasisAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxBasisAmountIsInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];            
            /*
            foreignKeys["RecurringPurchaseLineID"] = "RecurringPurchaseLine(RecurringPurchaseLineID)";
            foreignKeys["RecurringPurchasesID"] = "RecurringPurchases(RecurringPurchasesID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";  
            foreignKeys["AccountID"] = "Accounts(AccountID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)"               
             * */

            mDBMgr.CreateTable("RecurringMiscPurchaseLines", fields, "RecurringMiscPurchaseLineID", foreignKeys);
        }
    }
}

