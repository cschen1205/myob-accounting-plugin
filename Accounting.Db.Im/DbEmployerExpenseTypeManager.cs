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
    public class DbEmployerExpenseTypeManager : EmployerExpenseTypeManager
    {
        public DbEmployerExpenseTypeManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["EmployerExpenseTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_65;

            TableCommands["EmployerExpenseTypes"] = DbMgr.CreateTableCommand("EmployerExpenseTypes", fields, "EmployerExpenseTypeID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(EmployerExpenseType _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("EmployerExpenseTypes", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(EmployerExpenseType _obj)
        {
            return DbMgr.CreateUpdateClause("EmployerExpenseTypes", GetFields(_obj), "EmployerExpenseTypeID", _obj.EmployerExpenseTypeID);
        }

        protected override OpResult _Store(EmployerExpenseType _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "EmployerExpenseType object cannot be created as it is null");
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
