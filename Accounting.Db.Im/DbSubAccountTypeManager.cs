using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Accounts;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbSubAccountTypeManager : SubAccountTypeManager
    {
        public DbSubAccountTypeManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["SubAccountTypeID"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_23;

            TableCommands["SubAccountTypes"] = DbMgr.CreateTableCommand("SubAccountTypes", fields, "SubAccountTypeID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(SubAccountType _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("SubAccountTypes", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(SubAccountType _obj)
        {
            return DbMgr.CreateUpdateClause("SubAccountTypes", GetFields(_obj), "SubAccountTypeID", _obj.SubAccountTypeID);
        }

        

        protected override OpResult _Store(SubAccountType _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "SubAccountType object cannot be created as it is null");
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
