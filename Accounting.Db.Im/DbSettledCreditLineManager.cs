using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Sales;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbSettledCreditLineManager : SettledCreditLineManager
    {
        public DbSettledCreditLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //SettledCreditLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["SettledCreditLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["SettledCreditID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["SaleID"] = DbManager.FIELDTYPE.INTEGER;
            fields["AmountApplied"] = DbManager.FIELDTYPE.DOUBLE;
            fields["IsDepositPayment"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IsDiscount"] = DbManager.FIELDTYPE.VARCHAR_1;

            /*
            foreignKeys["SettledCreditID"] = "SettledCredits(SettledCreditID)";
            foreignKeys["SaleID"] = "Sales(SaleID)";
             * */

            TableCommands["SettledCreditLines"] = DbMgr.CreateTableCommand("SettledCreditLines", fields, "SettledCreditLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(SettledCreditLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("SettledCreditLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(SettledCreditLine _obj)
        {
            return DbMgr.CreateUpdateClause("SettledCreditLines", GetFields(_obj), "SettledCreditLineID", _obj.SettledCreditLineID);
        }

       

        protected override OpResult _Store(SettledCreditLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "SettledCreditLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.SettledCreditLineID == null)
            {
                _obj.SettledCreditLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

    }
}
