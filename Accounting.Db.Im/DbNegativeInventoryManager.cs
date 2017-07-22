using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Inventory;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbNegativeInventoryManager : NegativeInventoryManager
    {
        public DbNegativeInventoryManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["NegativeInventoryID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["SaleLineID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Quantity"] = DbManager.FIELDTYPE.DOUBLE;
            fields["IsCreditOffset"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["UnitCost"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ActualCost"] = DbManager.FIELDTYPE.DOUBLE;
            fields["BaseCost"] = DbManager.FIELDTYPE.DOUBLE;
            fields["LineCost"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ItemID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LocationID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TransactionID"] = DbManager.FIELDTYPE.INTEGER;
            fields["SaleLineIsPurged"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["TransactionIsPurged"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["JournalTypeID"] = DbManager.FIELDTYPE.VARCHAR_3;

            /*
            foreignKeys["SaleLineID"] = "SaleLines(SaleLineID)";
            foreignKeys["ItemID"] = "Items(ItemID)";
            foreignKeys["LocationID"] = "Locations(LocationID)";
            foreignKeys["TransactionID"] = "SaleLines(TransactionID)";
            foreignKeys["JournalTypeID"] = "JournalTypes(JournalTypeID)";                        
         
             * */

            TableCommands["NegativeInventory"] = DbMgr.CreateTableCommand("NegativeInventory", fields, "NegativeInventoryID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(NegativeInventory _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("NegativeInventory", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(NegativeInventory _obj)
        {
            return DbMgr.CreateUpdateClause("NegativeInventory", GetFields(_obj), "NegativeInventoryID", _obj.NegativeInventoryID);
        }

        protected override OpResult _Store(NegativeInventory _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "NegativeInventory object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
