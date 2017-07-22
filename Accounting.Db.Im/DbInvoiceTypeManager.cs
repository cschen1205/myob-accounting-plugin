using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Definitions;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbInvoiceTypeManager : InvoiceTypeManager
    {
        public DbInvoiceTypeManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["InvoiceTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_13;

            TableCommands["InvoiceType"] = DbMgr.CreateTableCommand("InvoiceType", fields, "InvoiceTypeID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(InvoiceType _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("InvoiceType", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(InvoiceType _obj)
        {
            return DbMgr.CreateUpdateClause("InvoiceType", GetFields(_obj), "InvoiceTypeID", _obj.InvoiceTypeID);
        }

        protected override OpResult _Store(InvoiceType _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "InvoiceType object cannot be created as it is null");
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
