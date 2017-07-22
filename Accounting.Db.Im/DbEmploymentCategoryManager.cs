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
    public class DbEmploymentCategoryManager : EmploymentCategoryManager
    {
        public DbEmploymentCategoryManager(DbManager mgr)
            : base(mgr)
        {

        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["EmploymentCategoryID"] = DbManager.FIELDTYPE.VARCHAR_2;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_14;

            TableCommands["EmploymentCategory"] = DbMgr.CreateTableCommand("EmploymentCategory", fields, "EmploymentCategoryID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(EmploymentCategory _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("EmploymentCategory", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(EmploymentCategory _obj)
        {
            return DbMgr.CreateUpdateClause("EmploymentCategory", GetFields(_obj), "EmploymentCategoryID", _obj.EmploymentCategoryID);
        }

        protected override OpResult _Store(EmploymentCategory _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "EmploymentCategory object cannot be created as it is null");
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
