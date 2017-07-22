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
    public class DbWageDollarHistoryManager : WageDollarHistoryManager
    {
        public DbWageDollarHistoryManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands() //WageDollarHistory()
        {
            //create table: Cards
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["WageDollarHistoryID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["WageID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Period"] = DbManager.FIELDTYPE.INTEGER;
            fields["PayrollYear"] = DbManager.FIELDTYPE.INTEGER;
            fields["Dollars"] = DbManager.FIELDTYPE.DOUBLE;

            TableCommands["WageDollarHistory"] = DbMgr.CreateTableCommand("WageDollarHistory", fields, "WageDollarHistoryID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(WageDollarHistory _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("WageDollarHistory", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(WageDollarHistory _obj)
        {
            return DbMgr.CreateUpdateClause("WageDollarHistory", GetFields(_obj), "WageDollarHistoryID", _obj.WageDollarHistoryID);
        }

        protected override OpResult _Store(WageDollarHistory _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "WageDollarHistory object cannot be created as it is null");
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
