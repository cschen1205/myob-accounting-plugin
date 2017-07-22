using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.JournalRecords;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbJournalTypeManager : JournalTypeManager
    {
        public DbJournalTypeManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["JournalTypeID"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_23;

            TableCommands["JournalTypes"] = DbMgr.CreateTableCommand("JournalTypes", fields, "JournalTypeID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(JournalType _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            fields["JournalTypeID"] = DbMgr.CreateStringFieldEntry(_obj.JournalTypeID);
            return DbMgr.CreateInsertClause("JournalTypes", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(JournalType _obj)
        {
            return DbMgr.CreateUpdateClause("JournalTypes", GetFields(_obj), "JournalTypeID", _obj.JournalTypeID);
        }

        protected override OpResult _Store(JournalType _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "JournalType object cannot be created as it is null");
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
