using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Misc;
using System.Data.Common;

namespace Accounting.Db.Im
{
    using Accounting.Core;
    using Accounting.Db;
    using Accounting.Db.Elements;

    public class DbConfigManager : ConfigManager
    {
        public DbConfigManager(DbManager mgr)
            : base(mgr)
        {

        }

        protected override OpResult _Delete(Config _obj)
        {
            if (Exists(_obj))
            {
                DbDeleteStatement clause = DbMgr.CreateDeleteClause();
                clause.DeleteFrom("Configs").Criteria
                    .IsEqual("Configs", "ConfigName", _obj.ConfigName);

                DbMgr.ExecuteNonQuery(clause);
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }
            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj);
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ConfigID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["ConfigName"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["ConfigValue"] = DbManager.FIELDTYPE.VARCHAR_255;

            TableCommands["Configs"] = DbMgr.CreateTableCommand("Configs", fields, "ConfigID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(Config _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("Configs", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(Config _obj)
        {
            return DbMgr.CreateUpdateClause("Configs", GetFields(_obj), "ConfigID", _obj.ConfigID);
        }

        protected override OpResult _Store(Config _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "The Config object is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.ConfigID == null)
            {
                _obj.ConfigID = DbMgr.GetLastInsertID();
            }

            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

    }
}
