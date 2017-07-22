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
    public class DbDayNameManager : DayNameManager
    {
        public DbDayNameManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["DayNameID"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_23;

            TableCommands["DayNames"] = DbMgr.CreateTableCommand("DayNames", fields, "DayNameID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(DayName _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("DayNames", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(DayName _obj)
        {
            return DbMgr.CreateUpdateClause("DayNames", GetFields(_obj), "DayNameID", _obj.DayNameID);
        }

        protected override OpResult _Store(DayName _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "DayName object cannot be created as it is null");
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
