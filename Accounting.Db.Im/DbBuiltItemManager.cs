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
    public class DbBuiltItemManager : BuiltItemManager
    {
        public DbBuiltItemManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["BuiltItemID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["ItemID"] = DbManager.FIELDTYPE.INTEGER;
            fields["QuantityBuilt"] = DbManager.FIELDTYPE.DOUBLE;

            /*
            foreignKeys["ItemID"] = "Items(ItemID)";
     
             * */

            TableCommands["BuiltItems"] = DbMgr.CreateTableCommand("BuiltItems", fields, "BuiltItemID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(BuiltItem _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("BuiltItems", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(BuiltItem _obj)
        {
            return DbMgr.CreateUpdateClause("BuiltItems", GetFields(_obj), "BuiltItemID", _obj.BuiltItemID);
        }

        protected override OpResult _Store(BuiltItem _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "BuiltItem object cannot be created as it is null");
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
