using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Terms;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbTermsOfPaymentManager : TermsOfPaymentManager
    {
        public DbTermsOfPaymentManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["TermsOfPaymentID"] = DbManager.FIELDTYPE.VARCHAR_4;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_52;

            TableCommands["TermsOfPayment"] = DbMgr.CreateTableCommand("TermsOfPayment", fields, "TermsOfPaymentID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(TermsOfPayment _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("TermsOfPayment", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(TermsOfPayment _obj)
        {
            return DbMgr.CreateUpdateClause("TermsOfPayment", GetFields(_obj), "TermsOfPaymentID", _obj.TermsOfPaymentID);
        }


        protected override OpResult _Store(TermsOfPayment _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "TermsOfPayment object cannot be created as it is null");
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
