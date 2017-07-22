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
    public class DbInventoryAdjustmentLineManager : InventoryAdjustmentLineManager
    {
        public DbInventoryAdjustmentLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //InventoryAdjustmentLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["InventoryAdjustmentLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["InventoryAdjustmentID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["ItemID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Quantity"] = DbManager.FIELDTYPE.DOUBLE;
            fields["UnitCost"] = DbManager.FIELDTYPE.DOUBLE;
            fields["Amount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["IsMultipleJob"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IsCOGSAdjustment"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["SaleID"] = DbManager.FIELDTYPE.INTEGER;
            fields["SaleLineID"] = DbManager.FIELDTYPE.INTEGER;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LocationID"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["ItemID"] = "Items(ItemID)";
            foreignKeys["AccountID"] = "Account(AccountID)";
            foreignKeys["SaleID"] = "Sales(SaleID)";
            foreignKeys["SaleLineID"] = "SaleLines(SaleLineID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["LocationID"] = "Locations(LocationID)";            
            foreignKeys["InventoryAdjustmentID"] = "InventoryAdjustment(InventoryAdjustmentID)";
             * */

            TableCommands["InventoryAdjustmentLines"] = DbMgr.CreateTableCommand("InventoryAdjustmentLines", fields, "InventoryAdjustmentLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(InventoryAdjustmentLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
          
            return DbMgr.CreateInsertClause("InventoryAdjustmentLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(InventoryAdjustmentLine _obj)
        {
            return DbMgr.CreateUpdateClause("InventoryAdjustmentLines", GetFields(_obj), "InventoryAdjustmentLineID", _obj.InventoryAdjustmentLineID);
        }

        protected override OpResult _Store(InventoryAdjustmentLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "InventoryAdjustmentLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.InventoryAdjustmentLineID == null)
            {
                _obj.InventoryAdjustmentLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

       
    }



}
