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
    public class DbAccountClassificationManager : AccountClassificationManager
    {
        public DbAccountClassificationManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["AccountClassificationID"] = DbManager.FIELDTYPE.VARCHAR_4;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_13;

            TableCommands["AccountClassification"] = DbMgr.CreateTableCommand("AccountClassification", fields, "AccountClassificationID", foreignKeys);

        }


        private DbInsertStatement GetQuery_InsertQuery(AccountClassification _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("AccountClassification", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(AccountClassification _obj)
        {
            return DbMgr.CreateUpdateClause("AccountClassification", GetFields(_obj), "AccountClassificationID", _obj.AccountClassificationID);
        }

        protected override OpResult _Store(AccountClassification _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "AccountClassification object cannot be created as it is null");
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
