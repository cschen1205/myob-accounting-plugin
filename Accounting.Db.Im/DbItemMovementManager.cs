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
    public class DbItemMovementManager : ItemMovementManager
    {
        public DbItemMovementManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ItemMovementID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["ItemID"] = DbManager.FIELDTYPE.INTEGER;
            fields["FinancialYear"] = DbManager.FIELDTYPE.INTEGER;
            fields["Period"] = DbManager.FIELDTYPE.INTEGER;
            fields["UnitChange"] = DbManager.FIELDTYPE.DOUBLE;
            fields["DollarChange"] = DbManager.FIELDTYPE.DOUBLE;

            /*
            foreignKeys["ItemID"] = "Items(ItemID)";          
             * */

            TableCommands["ItemMovement"] = DbMgr.CreateTableCommand("ItemMovement", fields, "ItemMovementID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(ItemMovement _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("ItemMovement", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(ItemMovement _obj)
        {
            return DbMgr.CreateUpdateClause("ItemMovement", GetFields(_obj), "ItemMovementID", _obj.ItemMovementID);
        }

        protected override OpResult _Store(ItemMovement _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ItemMovement object cannot be created as it is null");
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
