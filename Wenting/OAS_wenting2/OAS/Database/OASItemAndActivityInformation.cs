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
    Public Class OASItemAndActivityInformation
    {
        DBManager mDBMgr;

        public OASItemAndActivityInformation(DBManager mgr)
        {
            mDBMgr = mgr;
        }

        public void CreateDBs()
        {

            CreateDB_Items();
            CreateDB_MoveItems();
            CreateDB_Locations();
            CreateDB_ItemLocations();   
            CreateDB_ItemPrices();
            CreateDB_ItemMovement();
            CreateDB_ItemOpeningBalance();
            CreateDB_ItemSalesHistory();
            CreateDB_ItemPurchasesHistory();
            CreateDB_BuiltItems();
            CreateDB_BuildComponents();
            CreateDB_NegativeInventory();
            CreateDB_Activities();
            CreateDB_ActivitySalesHistory();
            CreateDB_ActivitySlips();
            CreateDB_ActivitySlipInvoiced();
            CreateDB_CustomLists();
        }

        private void CreateDB_Items()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ItemID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["IsInactive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["ItemName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["ItemNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["QuantityOnHand"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["ValueOnHand"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["PositiveAverageCost"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["SellOnOrder"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["PurchaseOnOrder"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["ReceivedOnOrder"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["QuantityAvailable"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["LastUnitPrice"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["NegativeQuantityOnHand"] = mDBMgr[DBManager.FIELDTYPEDOUBLE.];
            fields["NegativeValueOnHand"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["NegativeAverageCost"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["ItemIsSold"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["ItemIsBought"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["ItemIsInventoried"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1]; 
            fields["IncomeAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ExpenseAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["InventoryAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ItemDescription"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["UseDescription"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CustomList1ID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];             
            fields["CustomList2ID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CustomList3ID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CustomField1"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["CustomField2"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["CustomField3"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30]; 
            fields["BaseSellingPrice"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["PriceIsInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["SellTaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SalesTaxCalcBasisID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3]; 
            fields["SellUnitMeasure"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_5];
            fields["SellUnitQuantity"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TaxInclusiveLastPurchasePrice"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxExclusiveLastPurchasePrice"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE]; 
            fields["TaxInclusiveStandardCost"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxExclusiveStandardCost"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["BuyTaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["BuyUnitMeasure"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_5]; 
            fields["BuyUnitQuantity"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["PrimarySupplierID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SupplierItemNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["MinLevelBeforeReorder"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];                        
            fields["DefaultReorderQuantity"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE]; 
            fields["DefaultSellLocationID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["DefaultReceiveLocationID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ChangeControl"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
            fields["Picture"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255]; 

            /*
            foreignKeys["IncomeAccountID"] = "Accounts(IncomeAccountID)";
            foreignKeys["ExpenseAccountID"] = "Accounts(ExpenseAccountID)";
            foreignKeys["InventoryAccountID"] = "Accounts(InventoryAccountID)";
            foreignKeys["CustomList1ID"] = "CustomLists(CustomList1ID)";                        
            foreignKeys["CustomList2ID"] = "CustomLists(CustomList2ID)";
            foreignKeys["CustomList3ID"] = "CustomLists(CustomList3ID)";
            foreignKeys["SellTaxCodeID"] = "TaxCodes(SellTaxCodeID)";
            foreignKeys["SalesTaxCalcBasisID"] = "PriceLevels(SalesTaxCalcBasisID)";
            foreignKeys["BuyTaxCodeID"] = "TaxCodes(BuyTaxCodeID)";
            foreignKeys["PrimarySupplierID"] = "Cards(PrimarySupplierID)";  
            foreignKeys["DefaultSellLocationID"] = "Locations(DefaultSellLocationID)";
            foreignKeys["DefaultReceiveLocationID"] = "Locations(DefaultReceiveLocationID)";           
             * */

            mDBMgr.CreateTable("Items", fields, "", foreignKeys);
        }

        private void CreateDB_MoveItems()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["MoveItemsID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["MoveDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["ItemID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Description"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["UserID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
           
            /*
            foreignKeys["ItemID"] = "Items(ItemID)";
            foreignKeys["UserID"] = "Users(UserID)";        
             * */

            mDBMgr.CreateTable("MoveItems", fields, "MoveItemsID", foreignKeys);
        }

        private void CreateDB_Locations()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["LocationID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["IsInactive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CanBeSold"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["LocationIdentification"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_0];
            fields["LocationName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["Street"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["City"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255]];
            fields["State"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["Postcode"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_11];
            fields["Country"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["Contact"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["ContactPhone"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_21];
            fields["Notes"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
      
            /*       
             * */

            mDBMgr.CreateTable("Locations", fields, "LocationID", foreignKeys);
        }

        private void CreateDB_ItemLocations()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ItemLocationID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["ItemID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LocationID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["QuantityOnHand"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["SellOnOrder"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["PurchaseOnOrder"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            /*
            foreignKeys["ItemID"] = "Items(ItemID)";
            foreignKeys["LocationID"] = "Locations(LocationID)";         
             * */

            mDBMgr.CreateTable("ItemLocations", fields, "ItemLocationID", foreignKeys);
        }

        private void CreateDB_ItemPrices()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ItemPriceID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["ItemID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["QuantityBreak"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["QuantityBreakAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["PriceLevel"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["PriceLevelNameID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3];
            fields["SellingPrice"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["PriceIsInclusive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["ChangeControl"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_5];

/*
            foreignKeys["ItemID"] = "Items(ItemID)";
            foreignKeys["PriceLevelNameID"] = "PriceLevels(PriceLevelNameID)";        
             * */

            mDBMgr.CreateTable("ItemPrices", fields, "ItemPriceID", foreignKeys);
        }

        private void CreateDB_ItemMovement()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ItemMovementID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["ItemID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["FinancialYear"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Period"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["UnitChange"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["DollarChange"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
           
            /*
            foreignKeys["ItemID"] = "Items(ItemID)";          
             * */

            mDBMgr.CreateTable("ItemMovement", fields, "ItemMovementID", foreignKeys);
        }

        private void CreateDB_ItemOpeningBalance()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ItemOpeningBalanceID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["ItemID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["FinancialYear"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Units"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["Dollars"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];

            /*
            foreignKeys["ItemID"] = "Items(ItemID)";
         
             * */

            mDBMgr.CreateTable("ItemOpeningBalance", fields, "ItemOpeningBalanceID", foreignKeys);
        }

        private void CreateDB_ItemSalesHistory()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ItemSalesHistoryID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["ItemID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["FinancialYear"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Period"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["UnitsSold"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["SaleAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["CostOfSalesAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];

            /*
            foreignKeys["ItemID"] = "Items(ItemID)";
       
             * */

            mDBMgr.CreateTable("ItemSalesHistory", fields, "ItemSalesHistoryID", foreignKeys);
        }

        private void CreateDB_ItemPurchasesHistory()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ItemPurchasesHistoryID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["ItemID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["FinancialYear"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Period"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["UnitsSold"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["UnitsBought"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["PurchaseAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];            
            /*
            foreignKeys["ItemID"] = "Items(ItemID)";    
             * */

            mDBMgr.CreateTable("ItemPurchasesHistory", fields, "ItemPurchasesHistoryID", foreignKeys);
        }

        private void CreateDB_BuiltItems()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["BuiltItemID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["ItemID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["QuantityBuilt"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
      
            /*
            foreignKeys["ItemID"] = "Items(ItemID)";
     
             * */

            mDBMgr.CreateTable("BuiltItems", fields, "BuiltItemID", foreignKeys);
        }

        private void CreateDB_BuildComponents()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["BuildComponentID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["BuiltItemID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SequenceNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ComponentID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["QuantityNeeded"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
      
            /*
            foreignKeys["BuiltItemID"] = "BuiltItems(BuiltItemID)";
            foreignKeys["ComponentID"] = "Items(ComponentID)";
      
             * */

            mDBMgr.CreateTable("BuildComponents", fields, "BuildComponentID", foreignKeys);
        }

        private void CreateDB_NegativeInventory()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["NegativeInventoryID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["SaleLineID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Quantity"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["IsCreditOffset"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["UnitCost"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["ActualCost"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["BaseCost"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["LineCost"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["ItemID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["LocationID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["TransactionID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SaleLineIsPurged"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["TransactionIsPurged"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["JournalTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_3];

            /*
            foreignKeys["SaleLineID"] = "SaleLines(SaleLineID)";
            foreignKeys["ItemID"] = "Items(ItemID)";
            foreignKeys["LocationID"] = "Locations(LocationID)";
            foreignKeys["TransactionID"] = "SaleLines(TransactionID)";
            foreignKeys["JournalTypeID"] = "JournalTypes(JournalTypeID)";                        
         
             * */

            mDBMgr.CreateTable("NegativeInventory", fields, "NegativeInventoryID", foreignKeys);
        }

        private void CreateDB_Activities()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ActivityID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["IsInactive"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["ActivityName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["ActivityNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["IncomeAccountID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["IsHourly"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["IsChargeable"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["BillingRateUsedID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["ActivityDescription"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["UseDescription"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["ActivityRate"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["TaxCodeID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SellUnitMeasure"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["ChangeControl"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
    
            /*
            foreignKeys["BillingRateUsedID"] = "BillingRateUsed(BillingRateUsedID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
            foreignKeys["IncomeAccountID"] = "Accounts(IncomeAccountID)";
         
             * */

            mDBMgr.CreateTable("Activities", fields, "ActivityID", foreignKeys);
        }

        private void CreateDB_ActivitySalesHistory()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ActivitySalesHistoryID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["ActivityID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["FinancialYear"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Period"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["UnitsSold"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["SaleAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["EstimatedCostOfSalesAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];

            /*
            foreignKeys["ActivityID"] = "Activities(ActivityID)";
           
             * */

            mDBMgr.CreateTable("ActivitySalesHistory", fields, "ActivitySalesHistoryID", foreignKeys);
        }

        private void CreateDB_ActivitySlips()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ActivitySlipID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["ActivityID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["EmployeeSupplierID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CardTypeID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
            fields["CustomerID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["ActivitySlipNumber"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_8];
            fields["Date"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["ActivityDate"] = mDBMgr[DBManager.FIELDTYPE.DATETIME];
            fields["Units"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["JobID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["Rate"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["AlreadyBilledUnits"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["AlreadyBilledAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["AdjustmentUnits"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["AdjustmentAmount"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["Notes"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_255];
            fields["StartTime"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_5];
            fields["StopTime"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_5]; 
            fields["ElapsedTime"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SlipStatusID"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_1];
   
            /*
            foreignKeys["ActivityID"] = "Activities(ActivityID)";
            foreignKeys["EmployeeSupplierID"] = "Cards(EmployeeSupplierID)";
            foreignKeys["CardTypeID"] = "CardTypes(CardTypeID)";
            foreignKeys["SlipStatusID"] = "Status(SlipStatusID)";
            foreignKeys["CustomerID"] = "Cards(CustomerID)";                        
            foreignKeys["JobID"] = "Jobs(JobID)";
        
             * */

            mDBMgr.CreateTable("ActivitySlips", fields, "ActivitySlipID", foreignKeys);
        }

        private void CreateDB_ActivitySlipInvoiced()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ActivitySlipInvoicedID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["ActivitySlipID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["SaleID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["InvoicedUnits"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
            fields["InvoicedDollars"] = mDBMgr[DBManager.FIELDTYPE.DOUBLE];
 
            /*
            foreignKeys["ActivitySlipID"] = "ActivitySlips(ActivitySlipID)";
            foreignKeys["SaleID"] = "Sales(SaleID)";
         
             * */

            mDBMgr.CreateTable("ActivitySlipInvoiced", fields, "ActivitySlipInvoicedID", foreignKeys);
        }

        private void CreateDB_CustomLists()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["CustomListID"] = mDBMgr[DBManager.FIELDTYPE.INTEGER_AUTOINC];
            fields["CustomListText"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["CustomListNumber"] = mDBMgr[DBManager.FIELDTYPE.INTEGER];
            fields["CustomListName"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_30];
            fields["ChangeControl"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_5];
            fields["CustomListType"] = mDBMgr[DBManager.FIELDTYPE.VARCHAR_10];
      
            /*         
             * */

            mDBMgr.CreateTable("CustomLists", fields, "CustomListID", foreignKeys);
        }
    }
}



