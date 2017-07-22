using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Payroll;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbWageManager : WageManager
    {
        public DbWageManager(DbManager mgr)
            : base(mgr)
        {
            
        }


        protected override void CreateTableCommands() //Wages()
        {
            //create table: Cards
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["WageID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["WagesName"] = DbManager.FIELDTYPE.VARCHAR_31;
            fields["IsDummy"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IsHourly"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["UseFixedRate"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["RegularRateMultiplier"] = DbManager.FIELDTYPE.DOUBLE;
            fields["FixedHourlyRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["OverideAccountID"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["OverideAccountID"] = "Accounts(AccountID)";
             * */

            TableCommands["Wages"] = DbMgr.CreateTableCommand("Wages", fields, "WageID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(Wage _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("Wages", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(Wage _obj)
        {
            return DbMgr.CreateUpdateClause("Wages", GetFields(_obj), "WageID", _obj.WageID);
        }

        protected override OpResult _Store(Wage _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Wage object cannot be created as it is null");
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
