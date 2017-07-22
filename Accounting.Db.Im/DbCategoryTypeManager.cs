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
    public class DbCategoryTypeManager : CategoryTypeManager
    {
        public DbCategoryTypeManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["CategoryTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_17;

            TableCommands["CategoryTypes"] = DbMgr.CreateTableCommand("CategoryTypes", fields, "CategoryTypeID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(CategoryType _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("CategoryTypes", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(CategoryType _obj)
        {
            return DbMgr.CreateUpdateClause("CategoryTypes", GetFields(_obj), "CategoryTypeID", _obj.CategoryTypeID);
        }

        protected override OpResult _Store(CategoryType _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "CategoryType object cannot be created as it is null");
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
