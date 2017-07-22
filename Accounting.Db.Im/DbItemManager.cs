using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Inventory;
using Accounting.Core.Cards;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbItemManager : ItemManager
    {
        public DbItemManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ItemID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["IsInactive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["ItemName"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["ItemNumber"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["QuantityOnHand"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ValueOnHand"] = DbManager.FIELDTYPE.DOUBLE;
            fields["PositiveAverageCost"] = DbManager.FIELDTYPE.DOUBLE;
            fields["SellOnOrder"] = DbManager.FIELDTYPE.DOUBLE;
            fields["PurchaseOnOrder"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ReceivedOnOrder"] = DbManager.FIELDTYPE.DOUBLE;
            fields["QuantityAvailable"] = DbManager.FIELDTYPE.DOUBLE;
            fields["LastUnitPrice"] = DbManager.FIELDTYPE.DOUBLE;
            fields["NegativeQuantityOnHand"] = DbManager.FIELDTYPE.DOUBLE;
            fields["NegativeValueOnHand"] = DbManager.FIELDTYPE.DOUBLE;
            fields["NegativeAverageCost"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ItemIsSold"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["ItemIsBought"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["ItemIsInventoried"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IncomeAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ExpenseAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["InventoryAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ItemDescription"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["UseDescription"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CustomList1ID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CustomList2ID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CustomList3ID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CustomField1"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["CustomField2"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["CustomField3"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["BaseSellingPrice"] = DbManager.FIELDTYPE.DOUBLE;
            fields["PriceIsInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["SellTaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["SalesTaxCalcBasisID"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["SellUnitMeasure"] = DbManager.FIELDTYPE.VARCHAR_5;
            fields["SellUnitQuantity"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxInclusiveLastPurchasePrice"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxExclusiveLastPurchasePrice"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveStandardCost"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxExclusiveStandardCost"] = DbManager.FIELDTYPE.DOUBLE;
            fields["BuyTaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["BuyUnitMeasure"] = DbManager.FIELDTYPE.VARCHAR_5;
            fields["BuyUnitQuantity"] = DbManager.FIELDTYPE.INTEGER;
            fields["PrimarySupplierID"] = DbManager.FIELDTYPE.INTEGER;
            fields["SupplierItemNumber"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["MinLevelBeforeReorder"] = DbManager.FIELDTYPE.DOUBLE;
            fields["DefaultReorderQuantity"] = DbManager.FIELDTYPE.DOUBLE;
            fields["DefaultSellLocationID"] = DbManager.FIELDTYPE.INTEGER;
            fields["DefaultReceiveLocationID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ChangeControl"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["Picture"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["CustomList1ID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CustomList2ID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CustomList3ID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CustomField1"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["CustomField2"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["CustomField3"] = DbManager.FIELDTYPE.VARCHAR_30;

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

            TableCommands["Items"] = DbMgr.CreateTableCommand("Items", fields, "ItemID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(Item _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
          
            return DbMgr.CreateInsertClause("Items", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(Item _obj)
        {
            return DbMgr.CreateUpdateClause("Items", GetFields(_obj), "ItemID", _obj.ItemID);
        }

        protected override OpResult _Store(Item _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Item object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.ItemID == null)
            {
                _obj.ItemID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

       
    }



}
