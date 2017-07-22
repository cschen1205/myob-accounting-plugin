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
    public class DbFrequencyManager : FrequencyManager
    {
        public DbFrequencyManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["FrequencyID"] = DbManager.FIELDTYPE.VARCHAR_2;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_19;

            TableCommands["Frequencies"] = DbMgr.CreateTableCommand("Frequencies", fields, "FrequencyID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(Frequency _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("Frequencies", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(Frequency _obj)
        {
            return DbMgr.CreateUpdateClause("Frequencies", GetFields(_obj), "FrequencyID", _obj.FrequencyID);
        }

        protected override OpResult _Store(Frequency _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Frequency object cannot be created as it is null");
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
