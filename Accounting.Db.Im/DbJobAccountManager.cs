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

    public class DbJobAccountManager : JobAccountManager
    {
        public DbJobAccountManager(DbManager mgr)
            : base(mgr)
        {

        }
        
         protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["JobAccountID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["OpeningBalance"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CurrentBalance"] = DbManager.FIELDTYPE.DOUBLE;
            fields["PreLastYearActivity"] = DbManager.FIELDTYPE.DOUBLE;
            fields["LastYearOpeningBalance"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ThisYearOpeningBalance"] = DbManager.FIELDTYPE.DOUBLE;
            fields["PostThisYearActivity"] = DbManager.FIELDTYPE.DOUBLE;

            /*
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";
             * */

            TableCommands["JobAccounts"] = DbMgr.CreateTableCommand("JobAccounts", fields, "JobAccountID", foreignKeys);
        }

        

        private DbInsertStatement GetQuery_InsertQuery(JobAccount _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("JobAccounts", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(JobAccount _obj)
        {
            return DbMgr.CreateUpdateClause("JobAccounts", GetFields(_obj), "JobAccountID", _obj.JobAccountID);
        }

        protected override OpResult _Store(JobAccount _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "JobAccount object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.JobAccountID == null)
            {
                _obj.JobAccountID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
