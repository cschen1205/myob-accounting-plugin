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
    public class DbRoundingManager : RoundingManager
    {
        public DbRoundingManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RoundingID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_255;

            TableCommands["Rounding"] = DbMgr.CreateTableCommand("Rounding", fields, "RoundingID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(Rounding _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("Rounding", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(Rounding _obj)
        {
            return DbMgr.CreateUpdateClause("Rounding", GetFields(_obj), "RoundingID", _obj.RoundingID);
        }

        protected override OpResult _Store(Rounding _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Rounding object cannot be created as it is null");
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
