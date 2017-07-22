using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Im
{
    using Accounting.Core;
    using Accounting.Core.Definitions;
    using Accounting.Db.Elements;

    public class DbDataFieldManager : DataFieldManager
    {
        public DbDataFieldManager(DbManager mgr)
            : base(mgr)
        {
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["DataFieldID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["DataFieldName"] = DbManager.FIELDTYPE.VARCHAR_56;
            fields["DataFieldType"] = DbManager.FIELDTYPE.VARCHAR_30;

            TableCommands["DataFields"] = DbMgr.CreateTableCommand("DataFields", fields, "DataFieldID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(DataField _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("DataFields", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(DataField _obj)
        {
            return DbMgr.CreateUpdateClause("DataFields", GetFields(_obj), "DataFieldID", _obj.DataFieldID);
        }

        protected override OpResult _Delete(DataField _obj)
        {
            if (Exists(_obj))
            {
                DbDeleteStatement clause = DbMgr.CreateDeleteClause();
                clause.DeleteFrom("DataFields").Criteria.IsEqual("DataFields", "DataFieldID", _obj.DataFieldID);
                DbMgr.ExecuteNonQuery(clause);
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }
            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "DataField object does not exist");
        }

        protected override OpResult _Store(DataField _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "DataField object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.DataFieldID == null)
            {
                _obj.DataFieldID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
