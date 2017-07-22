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
    public class DbEmploymentClassificationManager : EmploymentClassificationManager
    {
        public DbEmploymentClassificationManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["EmploymentClassificationID"] = DbManager.FIELDTYPE.INTEGER;
            fields["EmploymentClassificationName"] = DbManager.FIELDTYPE.VARCHAR_14;

            TableCommands["EmploymentClassifications"] = DbMgr.CreateTableCommand("EmploymentClassifications", fields, "EmploymentClassificationID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(EmploymentClassification _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("EmploymentClassifications", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(EmploymentClassification _obj)
        {
            return DbMgr.CreateUpdateClause("EmploymentClassifications", GetFields(_obj), "EmploymentClassificationID", _obj.EmploymentClassificationID);
        }

        protected override OpResult _Store(EmploymentClassification _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "EmploymentClassification object cannot be created as it is null");
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
