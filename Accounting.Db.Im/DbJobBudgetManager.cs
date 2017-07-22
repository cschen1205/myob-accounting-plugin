using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Im
{
    using Accounting.Core;
    using Accounting.Core.Jobs;
    using Accounting.Db;
    using Accounting.Db.Elements;

    public class DbJobBudgetManager : JobBudgetManager
    {
        public DbJobBudgetManager(DbManager mgr)
            : base(mgr)
        {

        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["JobBudgetID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Amount"] = DbManager.FIELDTYPE.DOUBLE;

            /*
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";
             * */

            TableCommands["JobBudgets"] = DbMgr.CreateTableCommand("JobBudgets", fields, "JobBudgetID", foreignKeys);
        }

        

        private DbInsertStatement GetQuery_InsertQuery(JobBudget _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("JobBudgets", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(JobBudget _obj)
        {
            return DbMgr.CreateUpdateClause("JobBudgets", GetFields(_obj), "JobBudgetID", _obj.JobBudgetID);
        }

        protected override OpResult _Store(JobBudget _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "JobBudget object is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.JobBudgetID == null)
            {
                _obj.JobBudgetID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
