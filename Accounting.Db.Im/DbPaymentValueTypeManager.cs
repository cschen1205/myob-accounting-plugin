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
    public class DbPaymentValueTypeManager : PaymentValueTypeManager
    {
        public DbPaymentValueTypeManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ValueTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_17;

            TableCommands["ValueTypes"] = DbMgr.CreateTableCommand("ValueTypes", fields, "ValueTypeID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(PaymentValueType _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("ValueTypes", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(PaymentValueType _obj)
        {
            return DbMgr.CreateUpdateClause("ValueTypes", GetFields(_obj), "ValueTypeID", _obj.ValueTypeID);
        }

        protected override OpResult _Store(PaymentValueType _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "PaymentValueType object cannot be created as it is null");
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
