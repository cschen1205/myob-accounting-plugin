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
    public class DbMoveItemManager : MoveItemManager
    {
        public DbMoveItemManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["MoveItemsID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["MoveDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["ItemID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["UserID"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["ItemID"] = "Items(ItemID)";
            foreignKeys["UserID"] = "Users(UserID)";        
             * */

            TableCommands["MoveItems"] = DbMgr.CreateTableCommand("MoveItems", fields, "MoveItemsID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(MoveItem _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("MoveItems", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(MoveItem _obj)
        {
            return DbMgr.CreateUpdateClause("MoveItems", GetFields(_obj), "MoveItemID", _obj.MoveItemID);
        }

        protected override OpResult _Store(MoveItem _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "MoveItem object cannot be created as it is null");
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
