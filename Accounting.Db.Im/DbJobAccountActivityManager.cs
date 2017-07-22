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

    public class DbJobAccountActivityManager : JobAccountActivityManager
    {
        public DbJobAccountActivityManager(DbManager mgr)
            : base(mgr)
        {

        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["JobAccountActivityID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["FinancialYear"] = DbManager.FIELDTYPE.INTEGER;
            fields["Period"] = DbManager.FIELDTYPE.INTEGER;
            fields["Amount"] = DbManager.FIELDTYPE.DOUBLE;

            /*
           foreignKeys["JobID"] = "Jobs(JobID)";
           foreignKeys["AccountID"] = "Accounts(AccountID)";
            * */

            TableCommands["JobAccountActivities"] = DbMgr.CreateTableCommand("JobAccountActivities", fields, "JobAccountActivityID", foreignKeys);
        }

        

        private DbInsertStatement GetQuery_InsertQuery(JobAccountActivity _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("JobAccountActivities", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(JobAccountActivity _obj)
        {
            return DbMgr.CreateUpdateClause("JobAccountActivities", GetFields(_obj), "JobAccountActivityID", _obj.JobAccountActivityID);
        }

        protected override OpResult _Store(JobAccountActivity _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "JobAccountActivity object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.JobAccountActivityID == null)
            {
                _obj.JobAccountActivityID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
