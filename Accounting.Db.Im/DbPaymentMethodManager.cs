using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Im
{
    using Accounting.Core;
    using Accounting.Core.Misc;
    using Accounting.Db.Elements;

    public class DbPaymentMethodManager : PaymentMethodManager
    {
        public DbPaymentMethodManager(DbManager mgr)
            : base(mgr)
        {

        }



        protected override void CreateTableCommands() //PaymentMethods()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["PaymentMethodID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["PaymentMethod"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["MethodType"] = DbManager.FIELDTYPE.VARCHAR_11;

            TableCommands["PaymentMethods"] = DbMgr.CreateTableCommand("PaymentMethods", fields, "PaymentMethodID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(PaymentMethod _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("PaymentMethods", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(PaymentMethod _obj)
        {
            return DbMgr.CreateUpdateClause("PaymentMethods", GetFields(_obj), "PaymentMethodID", _obj.PaymentMethodID);
        }

        protected override OpResult _Store(PaymentMethod _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "PaymentMethod object cannot be created as it is null");
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
