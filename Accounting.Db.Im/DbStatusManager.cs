using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Definitions;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbStatusManager : StatusManager
    {
        public DbStatusManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["StatusID"] = DbManager.FIELDTYPE.VARCHAR_2;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_14;

            TableCommands["Status"] = DbMgr.CreateTableCommand("Status", fields, "StatusID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(Status _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            fields["StatusID"] = DbMgr.CreateStringFieldEntry(_obj.StatusID);
            return DbMgr.CreateInsertClause("Status", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(Status _obj)
        {
            return DbMgr.CreateUpdateClause("Status", GetFields(_obj), "StatusID", _obj.StatusID);
        }

        protected override OpResult _Store(Status _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Status object cannot be created as it is null");
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
