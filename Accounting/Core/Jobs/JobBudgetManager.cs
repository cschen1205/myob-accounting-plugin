using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Jobs
{
    public abstract class JobBudgetManager : EntityManager<JobBudget>
    {
        public JobBudgetManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override JobBudget _CreateEntity()
        {
            return new JobBudget(false, this);
        }

        protected override JobBudget _CreateDbEntity()
        {
            return new JobBudget(true, this);
        }
        #endregion

        protected override void LoadFromReader(JobBudget _obj, DbDataReader _reader)
        {
            _obj.AccountID = GetInt32(_reader, "AccountID");
            _obj.JobID = GetInt32(_reader, "JobID");
            _obj.JobBudgetID = GetInt32(_reader, "JobBudgetID");
            _obj.Amount = GetDouble(_reader, "Amount");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(JobBudget _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["JobBudgetID"] = DbMgr.CreateAutoIntFieldEntry(_obj.JobBudgetID);
            fields["AccountID"] = DbMgr.CreateIntFieldEntry(_obj.AccountID);
            fields["JobID"] = DbMgr.CreateIntFieldEntry(_obj.JobID);
            fields["Amount"] = DbMgr.CreateDoubleFieldEntry(_obj.Amount);

            return fields;
        }

        protected override object GetDbProperty(JobBudget _obj, string property_name)
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

        public JobBudget FindByJobAccount(Job _job, Accounts.Account acc)
        {
            return _FindByJobAccount(_job, acc);
        }

        protected virtual JobBudget _FindByJobAccount(Job _job, Accounts.Account acc)
        {
            JobBudget _jb = null;
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll().From("JobBudgets").Criteria
                .IsEqual("JobBudgets", "JobID", _job.JobID)
                .IsEqual("JobBudgets", "AccountID", acc.AccountID);
            

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            if (_reader.Read())
            {
                _jb = CreateDbEntity();
                LoadFromReader(_jb, _reader);
            }
            _reader.Close();
            _cmd.Dispose();

            return _jb;

        }

        protected override IList<JobBudget>_FindAllCollection()
        {
            List<JobBudget> _grp = new List<JobBudget>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                JobBudget _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        public override bool Exists(JobBudget _obj)
        {
            if(_obj==null) return false;
            return Exists(_obj.JobBudgetID);
        }

        public bool Exists(int? JobBudgetID)
        {
            if (JobBudgetID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByJobBudgetID(JobBudgetID.Value)) != 0;
        }

        private DbSelectStatement GetQuery_SelectCountByJobBudgetID(int JobBudgetID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectCount()
                .From("JobBudgets")
                .Criteria
                    .IsEqual("JobBudgets", "JobBudgetID", JobBudgetID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll().From("JobBudgets");
            return clause;
        }
    }
}
