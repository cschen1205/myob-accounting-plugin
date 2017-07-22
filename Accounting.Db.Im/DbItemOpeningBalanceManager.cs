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
    public class DbItemOpeningBalanceManager : ItemOpeningBalanceManager
    {
        public DbItemOpeningBalanceManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ItemOpeningBalanceID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["ItemID"] = DbManager.FIELDTYPE.INTEGER;
            fields["FinancialYear"] = DbManager.FIELDTYPE.INTEGER;
            fields["Units"] = DbManager.FIELDTYPE.DOUBLE;
            fields["Dollars"] = DbManager.FIELDTYPE.DOUBLE;

            /*
            foreignKeys["ItemID"] = "Items(ItemID)";
         
             * */

            TableCommands["ItemOpeningBalance"] = DbMgr.CreateTableCommand("ItemOpeningBalance", fields, "ItemOpeningBalanceID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(ItemOpeningBalance _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("ItemOpeningBalance", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(ItemOpeningBalance _obj)
        {
            return DbMgr.CreateUpdateClause("ItemOpeningBalance", GetFields(_obj), "ItemOpeningBalanceID", _obj.ItemOpeningBalanceID);
        }

        protected override OpResult _Store(ItemOpeningBalance _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ItemOpeningBalance object cannot be created as it is null");
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
