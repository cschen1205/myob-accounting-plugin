using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace Accounting.Db.Im
{
    using Accounting.Core;
    using Accounting.Core.Definitions;
    using Accounting.Db;
    using Accounting.Db.Elements;

    public class DbAlertManager : AlertManager
    {
        public DbAlertManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override OpResult _Delete(Alert _obj)
        {
            if (Exists(_obj))
            {
                DbDeleteStatement clause = DbMgr.CreateDeleteClause();
                clause.DeleteFrom("Alerts").Criteria
                    .IsEqual("Alerts", "AlertID", _obj.AlertID);

                DbMgr.ExecuteNonQuery(clause);
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }
            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "Alert object cannot be deleted as it does not exist");
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["AlertID"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_255;

            TableCommands["Alerts"] = DbMgr.CreateTableCommand("Alerts", fields, "AlertID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(Alert _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("Alerts", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(Alert _obj)
        {
            return DbMgr.CreateUpdateClause("Alerts", GetFields(_obj), "AlertID", _obj.AlertID);
        }

        protected override OpResult _Store(Alert _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Alert object cannot be created as it is null");
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
