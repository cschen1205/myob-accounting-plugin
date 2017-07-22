using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Jobs
{
    public abstract class JobAccountActivityManager : EntityManager<JobAccountActivity>
    {
        public JobAccountActivityManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override JobAccountActivity _CreateEntity()
        {
            return new JobAccountActivity(false, this);
        }
        protected override JobAccountActivity _CreateDbEntity()
        {
            return new JobAccountActivity(true, this);
        }
        #endregion

        protected override IList<JobAccountActivity>_FindAllCollection()
        {
            List<JobAccountActivity> _grp = new List<JobAccountActivity>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                JobAccountActivity _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override void LoadFromReader(JobAccountActivity _obj, DbDataReader reader)
        {
            _obj.AccountID = GetInt32(reader, "AccountID");
            _obj.Amount = GetDouble(reader, "Amount");
            _obj.FinancialYear = GetInt32(reader, "FinancialYear");
            _obj.JobAccountActivityID = GetInt32(reader, "JobAccountActivityID");
            _obj.JobID = GetInt32(reader, "JobID");
            _obj.Period = GetInt32(reader, "Period");
        }

        protected override object GetDbProperty(JobAccountActivity _obj, string property_name)
        {
            if (property_name.Equals("Account"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.AccountID);
            }
            else if (property_name.Equals("Job"))
            {
                return RepositoryMgr.JobMgr.FindById(_obj.JobID);
            }
            return null;
        }

        public override Dictionary<string, DbFieldEntry> GetFields(JobAccountActivity _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["JobAccountActivityID"] = DbMgr.CreateAutoIntFieldEntry(_obj.JobAccountActivityID);
            fields["JobID"] = DbMgr.CreateIntFieldEntry(_obj.JobID);
            fields["AccountID"] = DbMgr.CreateIntFieldEntry(_obj.AccountID);
            fields["Amount"] = DbMgr.CreateDoubleFieldEntry(_obj.Amount);
            fields["FinancialYear"] = DbMgr.CreateIntFieldEntry(_obj.FinancialYear);
            fields["Period"] = DbMgr.CreateIntFieldEntry(_obj.Period);
            return fields;
        }

        public override bool Exists(JobAccountActivity _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.JobAccountActivityID);
        }

        public bool Exists(int? JobAccountActivityID)
        {
            if (JobAccountActivityID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByJobAccountActivityID(JobAccountActivityID.Value)) != 0;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll().From("JobAccountActivities");
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByJobAccountActivityID(int JobAccountActivityID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("JobAccountActivities")
                .Criteria
                    .IsEqual("JobAccountActivities", "JobAccountActivityID", JobAccountActivityID);
            return clause;
        }
    }
}
