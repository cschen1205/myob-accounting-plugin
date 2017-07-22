using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Jobs;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbJobManager : JobManager
    {
        public DbJobManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["JobID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["ParentJobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["IsInactive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["JobName"] = DbManager.FIELDTYPE.VARCHAR_25;
            fields["JobNumber"] = DbManager.FIELDTYPE.VARCHAR_5;
            fields["IsHeader"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["JobLevel"] = DbManager.FIELDTYPE.INTEGER;
            fields["IsTrackingReimburseable"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["JobDescription"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["ContactName"] = DbManager.FIELDTYPE.VARCHAR_25;
            fields["Manager"] = DbManager.FIELDTYPE.VARCHAR_25;
            fields["PercentCompleted"] = DbManager.FIELDTYPE.DOUBLE;
            fields["StartDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["FinishDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["CustomerID"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["ParentJobID"] = "Jobs(ParentJobID)";
            foreignKeys["CustomerID"] = "Customers(CustomerID)";
             * */

            TableCommands["Jobs"] = DbMgr.CreateTableCommand("Jobs", fields, "JobID", foreignKeys);
        }

       

        private DbInsertStatement GetQuery_InsertQuery(Job _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("Jobs", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(Job _obj)
        {
            return DbMgr.CreateUpdateClause("Jobs", GetFields(_obj), "JobID", _obj.JobID);
        }

        protected override OpResult _Store(Job _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Job object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.JobID == null)
            {
                _obj.JobID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }

    
}
