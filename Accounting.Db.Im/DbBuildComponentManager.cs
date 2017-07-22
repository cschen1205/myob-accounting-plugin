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
    public class DbBuildComponentManager : BuildComponentManager
    {
        public DbBuildComponentManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["BuildComponentID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["BuiltItemID"] = DbManager.FIELDTYPE.INTEGER;
            fields["SequenceNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["ComponentID"] = DbManager.FIELDTYPE.INTEGER;
            fields["QuantityNeeded"] = DbManager.FIELDTYPE.DOUBLE;

            /*
            foreignKeys["BuiltItemID"] = "BuiltItems(BuiltItemID)";
            foreignKeys["ComponentID"] = "Items(ComponentID)";
      
             * */

            TableCommands["BuildComponents"] = DbMgr.CreateTableCommand("BuildComponents", fields, "BuildComponentID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(BuildComponent _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("BuildComponents", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(BuildComponent _obj)
        {
            return DbMgr.CreateUpdateClause("BuildComponents", GetFields(_obj), "BuildComponentID", _obj.BuildComponentID);
        }

        protected override OpResult _Store(BuildComponent _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "BuildComponent object cannot be created as it is null");
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
