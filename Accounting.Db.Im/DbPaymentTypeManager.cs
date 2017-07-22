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
    public class DbPaymentTypeManager : PaymentTypeManager
    {
        public DbPaymentTypeManager(DbManager mgr)
            : base(mgr)
        {
            
        }


        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["PaymentTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_30;

            TableCommands["PaymentTypes"] = DbMgr.CreateTableCommand("PaymentTypes", fields, "PaymentTypeID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(PaymentType _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("PaymentTypes", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(PaymentType _obj)
        {
            return DbMgr.CreateUpdateClause("PaymentTypes", GetFields(_obj), "PaymentTypeID", _obj.PaymentTypeID);
        }

        protected override OpResult _Store(PaymentType _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "PaymentType object cannot be created as it is null");
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
