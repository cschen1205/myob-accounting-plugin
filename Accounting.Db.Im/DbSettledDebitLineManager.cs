using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Purchases;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbSettledDebitLineManager : SettledDebitLineManager
    {
        public DbSettledDebitLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //SettledDebitLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["SettledDebitLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["SettledDebitID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["PurchaseID"] = DbManager.FIELDTYPE.INTEGER;
            fields["AmountApplied"] = DbManager.FIELDTYPE.DOUBLE;
            fields["IsDepositPayment"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IsDiscount"] = DbManager.FIELDTYPE.VARCHAR_1;

            /*
            foreignKeys["SettledDebitID"] = "SettledDebits(SettledDebitID)";
            foreignKeys["PurchaseID"] = "Purchases(PurchaseID)";
             * */

            TableCommands["SettledDebitLines"] = DbMgr.CreateTableCommand("SettledDebitLines", fields, "SettledDebitLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(SettledDebitLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("SettledDebitLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(SettledDebitLine _obj)
        {
            return DbMgr.CreateUpdateClause("SettledDebitLines", GetFields(_obj), "SettledDebitLineID", _obj.SettledDebitLineID);
        }

       

        protected override OpResult _Store(SettledDebitLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "SettledDebitLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));

            if (_obj.SettledDebitLineID == null)
            {
                _obj.SettledDebitLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

    }
}
