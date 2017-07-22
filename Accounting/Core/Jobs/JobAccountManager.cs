using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Jobs
{
    public abstract class JobAccountManager : EntityManager<JobAccount>
    {
        public JobAccountManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override JobAccount _CreateEntity()
        {
            return new JobAccount(false, this);
        }
        protected override JobAccount _CreateDbEntity()
        {
            return new JobAccount(true, this);
        }
        #endregion

        public JobAccount FindByJobAccount(Job _job, Accounts.Account _acc)
        {
            return _FindByJobAccount(_job, _acc);
        }

        protected virtual JobAccount _FindByJobAccount(Job _job, Accounts.Account _acc)
        {
            JobAccount _jacc = null;
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll().From("JobAccounts").Criteria
                .IsEqual("JobAccounts", "JobID", _job.JobID)
                .IsEqual("JobAccounts", "AccountID", _acc.AccountID);


            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            if (_reader.Read())
            {
                _jacc = CreateDbEntity();
                LoadFromReader(_jacc, _reader);
            }
            _reader.Close();
            _cmd.Dispose();

            return _jacc;
        }

        protected override IList<JobAccount>_FindAllCollection()
        {
            List<JobAccount> _grp = new List<JobAccount>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                JobAccount _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        public DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll().From("JobAccounts");
            return clause;
        }


        public DbSelectStatement GetQuery_SelectCountByJobAccountID(int JobAccountID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("JobAccounts")
                .Criteria
                    .IsEqual("JobAccounts", "JobAccountID", JobAccountID);
            return clause;
        }

        public bool Exists(int? JobAccountID)
        {
            if (JobAccountID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByJobAccountID(JobAccountID.Value)) != 0;
        }

        public override bool Exists(JobAccount _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.JobAccountID);
        }

        protected override void LoadFromReader(JobAccount _obj, DbDataReader reader)
        {
            _obj.AccountID = GetInt32(reader, "AccountID");
            _obj.JobAccountID = GetInt32(reader, "JobAccountID");
            _obj.JobID = GetInt32(reader, "JobID");
            _obj.LastYearOpeningBalance = GetDouble(reader, "LastYearOpeningBalance");
            _obj.OpeningBalance = GetDouble(reader, "OpeningBalance");
            _obj.PostThisYearActivity = GetDouble(reader, "PostThisYearActivity");
            _obj.PreLastYearActivity = GetDouble(reader, "PreLastYearActivity");
            _obj.ThisYearOpeningBalance = GetDouble(reader, "ThisYearOpeningBalance");
            _obj.CurrentBalance = GetDouble(reader, "CurrentBalance");
        }

        protected override object GetDbProperty(JobAccount _obj, string property_name)
        {
            if(property_name.Equals("Job"))
            {
                return RepositoryMgr.JobMgr.FindById(_obj.JobID);
            }
            else if(property_name.Equals("Account"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.AccountID);
            }
            return null;
        }

        public override Dictionary<string, DbFieldEntry> GetFields(JobAccount _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["JobAccountID"] = DbMgr.CreateAutoIntFieldEntry(_obj.JobAccountID);
            fields["JobID"] = DbMgr.CreateIntFieldEntry(_obj.JobID);
            fields["AccountID"] = DbMgr.CreateIntFieldEntry(_obj.AccountID);
            fields["CurrentBalance"] = DbMgr.CreateDoubleFieldEntry(_obj.CurrentBalance);
            fields["LastYearOpeningBalance"] = DbMgr.CreateDoubleFieldEntry(_obj.LastYearOpeningBalance);
            fields["OpeningBalance"] = DbMgr.CreateDoubleFieldEntry(_obj.OpeningBalance);
            fields["PostThisYearActivity"] = DbMgr.CreateDoubleFieldEntry(_obj.PostThisYearActivity);
            fields["PreLastYearActivity"] = DbMgr.CreateDoubleFieldEntry(_obj.PreLastYearActivity);
            fields["ThisYearOpeningBalance"] = DbMgr.CreateDoubleFieldEntry(_obj.ThisYearOpeningBalance);

            return fields;
        }
    }
}
