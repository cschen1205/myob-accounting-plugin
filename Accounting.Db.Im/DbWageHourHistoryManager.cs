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
    public class DbWageHourHistoryManager : WageHourHistoryManager
    {
        public DbWageHourHistoryManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //WageHourHistory()
        {
            //create table: Cards
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["WageHourHistoryID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["WageID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Period"] = DbManager.FIELDTYPE.INTEGER;
            fields["PayrollYear"] = DbManager.FIELDTYPE.INTEGER;
            fields["Hours"] = DbManager.FIELDTYPE.DOUBLE;

            TableCommands["WageHourHistory"] = DbMgr.CreateTableCommand("WageHourHistory", fields, "WageHourHistoryID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(WageHourHistory _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("WageHourHistory", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(WageHourHistory _obj)
        {
            return DbMgr.CreateUpdateClause("WageHourHistory", GetFields(_obj), "WageHourHistoryID", _obj.WageHourHistoryID);
        }

        protected override OpResult _Store(WageHourHistory _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "WageHourHistory object cannot be created as it is null");
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
