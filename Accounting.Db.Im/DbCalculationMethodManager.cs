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
    public class DbCalculationMethodManager : CalculationMethodManager
    {
        public DbCalculationMethodManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["CalculationMethodID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_255;

            TableCommands["CalculationMethod"] = DbMgr.CreateTableCommand("CalculationMethod", fields, "CalculationMethodID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(CalculationMethod _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("CalculationMethod", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(CalculationMethod _obj)
        {
            return DbMgr.CreateUpdateClause("CalculationMethod", GetFields(_obj), "CalculationMethodID", _obj.CalculationMethodID);
        }

        protected override OpResult _Store(CalculationMethod _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "CalculationMethod object cannot be created as it is null");
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
