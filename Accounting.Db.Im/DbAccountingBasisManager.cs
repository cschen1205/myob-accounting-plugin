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
    public class DbAccountingBasisManager : AccountingBasisManager
    {
        public DbAccountingBasisManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["AccountingBasisID"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_255;

            TableCommands["AccountingBasis"] = DbMgr.CreateTableCommand("AccountingBasis", fields, "AccountingBasisID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(AccountingBasis _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("AccountingBasis", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(AccountingBasis _obj)
        {
            return DbMgr.CreateUpdateClause("AccountingBasis", GetFields(_obj), "AccountingBasisID", _obj.AccountingBasisID);
        }

        protected override OpResult _Store(AccountingBasis _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "AccountingBasis object cannot be created as it is null");
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
