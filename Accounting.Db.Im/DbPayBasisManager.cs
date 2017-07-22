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
    public class DbPayBasisManager : PayBasisManager
    {
        public DbPayBasisManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["PayBasisID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_7;

            TableCommands["PayBasis"] = DbMgr.CreateTableCommand("PayBasis", fields, "PayBasisID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(PayBasis _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("PayBasis", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(PayBasis _obj)
        {
            return DbMgr.CreateUpdateClause("PayBasis", GetFields(_obj), "PayBasisID", _obj.PayBasisID);
        }

        protected override OpResult _Store(PayBasis _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "PayBasis object cannot be created as it is null");
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