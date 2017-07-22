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
    public sealed class DbTermsManager : TermsManager
    {
        public DbTermsManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //Terms()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["TermsID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["LatePaymentChargePercent"] = DbManager.FIELDTYPE.DOUBLE;
            fields["EarlyPaymentDiscountPercent"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TermsOfPaymentID"] = DbManager.FIELDTYPE.VARCHAR_4;
            fields["DiscountDays"] = DbManager.FIELDTYPE.INTEGER;
            fields["BalanceDueDays"] = DbManager.FIELDTYPE.INTEGER;
            fields["ImportPaymentIsDue"] = DbManager.FIELDTYPE.INTEGER;
            fields["DiscountDate"] = DbManager.FIELDTYPE.VARCHAR_2;
            fields["BalanceDueDate"] = DbManager.FIELDTYPE.VARCHAR_2;

            //foreignKeys["TermsOfPaymentID"] = "TermsOfPayment(TermsOfPaymentID)";

            TableCommands["Terms"] = DbMgr.CreateTableCommand("Terms", fields, "TermsID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(Terms _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("Terms", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(Terms _obj)
        {
            return DbMgr.CreateUpdateClause("Terms", GetFields(_obj), "TermsID", _obj.TermsID);
        }

       
        protected override OpResult _Store(Terms _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Terms object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.TermsID == null)
            {
                _obj.TermsID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

    }
}
