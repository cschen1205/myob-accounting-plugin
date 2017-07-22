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
    public sealed class DbInvoiceDeliveryManager : InvoiceDeliveryManager
    {
        public DbInvoiceDeliveryManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["InvoiceDeliveryID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_30;

            TableCommands["InvoiceDelivery"] = DbMgr.CreateTableCommand("InvoiceDelivery", fields, "InvoiceDeliveryID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(InvoiceDelivery _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("InvoiceDelivery", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(InvoiceDelivery _obj)
        {
            return DbMgr.CreateUpdateClause("InvoiceDelivery", GetFields(_obj), "InvoiceDeliveryID", _obj.InvoiceDeliveryID);
        }

        protected override OpResult _Store(InvoiceDelivery _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "InvoiceDelivery object cannot be created as it is null");
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
