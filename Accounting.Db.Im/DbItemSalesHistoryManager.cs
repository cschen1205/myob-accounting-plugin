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
    public class DbItemSalesHistoryManager : ItemSalesHistoryManager
    {
        public DbItemSalesHistoryManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ItemSalesHistoryID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["ItemID"] = DbManager.FIELDTYPE.INTEGER;
            fields["FinancialYear"] = DbManager.FIELDTYPE.INTEGER;
            fields["Period"] = DbManager.FIELDTYPE.INTEGER;
            fields["UnitsSold"] = DbManager.FIELDTYPE.DOUBLE;
            fields["SaleAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CostOfSalesAmount"] = DbManager.FIELDTYPE.DOUBLE;

            /*
            foreignKeys["ItemID"] = "Items(ItemID)";
       
             * */

            TableCommands["ItemSalesHistory"] = DbMgr.CreateTableCommand("ItemSalesHistory", fields, "ItemSalesHistoryID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(ItemSalesHistory _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("ItemSalesHistory", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(ItemSalesHistory _obj)
        {
            return DbMgr.CreateUpdateClause("ItemSalesHistory", GetFields(_obj), "ItemSalesHistoryID", _obj.ItemSalesHistoryID);
        }

        protected override OpResult _Store(ItemSalesHistory _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ItemSalesHistory object cannot be created as it is null");
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
