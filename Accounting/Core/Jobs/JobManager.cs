using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Core.Data;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Jobs
{
    public abstract class JobManager : EntityManager<Job>
    {
        public JobManager(DbManager mgr)
            : base(mgr)
        {

        }

        #region +(Factory Methods)
        protected override Job _CreateDbEntity()
        {
            return new Job(true, this);
        }

        protected override Job _CreateEntity()
        {
            return new Job(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(Job _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["JobID"] = DbMgr.CreateAutoIntFieldEntry(_obj.JobID);
            fields["ParentJobID"] = DbMgr.CreateIntFieldEntry(_obj.ParentJobID);
            fields["IsInactive"] = DbMgr.CreateStringFieldEntry(_obj.IsInactive);
            fields["JobName"] = DbMgr.CreateStringFieldEntry(_obj.JobName);
            fields["JobNumber"] = DbMgr.CreateStringFieldEntry(_obj.JobNumber);
            fields["IsHeader"] = DbMgr.CreateStringFieldEntry(_obj._IsHeader);
            fields["JobLevel"] = DbMgr.CreateIntFieldEntry(_obj.JobLevel);
            fields["IsTrackingReimburseable"] = DbMgr.CreateStringFieldEntry(_obj.IsTrackingReimburseable);
            fields["JobDescription"] = DbMgr.CreateStringFieldEntry(_obj.JobDescription);
            fields["ContactName"] = DbMgr.CreateStringFieldEntry(_obj.ContactName);
            fields["Manager"] = DbMgr.CreateStringFieldEntry(_obj.Manager);
            fields["PercentCompleted"] = DbMgr.CreateDoubleFieldEntry(_obj.PercentCompleted);
            fields["StartDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.StartDate);
            fields["FinishDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.FinishDate);
            fields["CustomerID"] = DbMgr.CreateIntFieldEntry(_obj.CustomerID);

            return fields;
        }

        public int GetJobLevel(Job _obj)
        {
            return _obj.JobLevel.Value;
        }

        public bool IsParentJob(Job parent, Job child)
        {
            return parent.JobID == child.ParentJobID;
        }

        public double GetJob(Job _obj)
        {
            return _obj.PercentCompleted;
        }

        public Hierarchy<Job> Hierarchy
        {
            get
            {
                Hierarchy<Job> h = new Hierarchy<Job>(
                    this.FindAllCollection(),
                    1,
                    new Hierarchy<Job>.GetLevelDelegate(GetJobLevel),
                    new Hierarchy<Job>.IsParentDelegate(IsParentJob),
                    null);

                return h;
            }
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll().From("Jobs");
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByJobID(int JobID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Jobs")
                .Criteria.IsEqual("Jobs", "JobID", JobID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByJobID(int JobID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("Jobs")
                .Criteria.IsEqual("Jobs", "JobID", JobID);
            return clause;
        }

        private bool Exists(int? JobID)
        {
            if (JobID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByJobID(JobID.Value)) != 0;
        }

        public override bool Exists(Job _obj)
        {
            return Exists(_obj.JobID);
        }

        protected override void LoadFromReader(Job _obj, DbDataReader _reader)
        {
            _obj.JobID =GetInt32(_reader, ("JobID"));
            _obj.ParentJobID =GetInt32(_reader, ("ParentJobID"));
            _obj.IsInactive =GetString(_reader, ("IsInactive"));
            _obj.JobName =GetString(_reader, ("JobName"));
            _obj.JobNumber =GetString(_reader, ("JobNumber"));
            _obj._IsHeader =GetString(_reader, ("IsHeader"));
            try
            {
                _obj.JobLevel = GetInt16(_reader, ("JobLevel"));
            }
            catch
            {
                _obj.JobLevel =GetInt32(_reader, ("JobLevel"));
            }
            _obj.IsTrackingReimburseable =GetString(_reader, ("IsTrackingReimburseable"));
            _obj.JobDescription =GetString(_reader, ("JobDescription"));
            _obj.ContactName =GetString(_reader, ("ContactName"));
            _obj.Manager =GetString(_reader, ("Manager"));
            _obj.PercentCompleted = GetDouble(_reader, ("PercentCompleted"));
            _obj.StartDate = GetDateTime(_reader, ("StartDate"));
            _obj.FinishDate = GetDateTime(_reader, ("FinishDate"));
            _obj.CustomerID =GetInt32(_reader, ("CustomerID"));
        }

        protected override object GetDbProperty(Job _obj, string property_name)
        {
            if (property_name == "Customer")
            {
                return RepositoryMgr.CustomerMgr.FindById(_obj.CustomerID);
            }
            else if (property_name == "ParentJob")
            {
                return RepositoryMgr.JobMgr.FindById(_obj.ParentJobID);
            }
            return null;
        }

        public Job CreateOrRetrieve(int JobID)
        {
            bool created;
            return CreateOrRetrieve(JobID, out created);
        }

        public Job CreateOrRetrieve(int JobID, out bool created)
        {
            Job _obj = _FindByIntId(JobID);
            if (_obj != null)
            {
                created = false;
                return _obj;
            }
            else
            {
                created = true;
                return CreateEntity();
            }
        }

        protected override Job _FindByIntId(int? JobID)
        {
            if (Exists(JobID))
            {
                Job _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByJobID(JobID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override IList<Job>_FindAllCollection()
        {
            List<Job> objs = new List<Job>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Job _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                objs.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return objs;
        }

        public DataTable Table()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectColumn("Jobs", "JobID", "ID")
                .SelectColumn("Jobs", "JobNumber", "JobNumber")
                .SelectColumn("Jobs", "JobName", "Name")
                .SelectColumn("Jobs", "JobDescription", "Description")
                .From("Jobs");
            

            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Job #");
            table.Columns.Add("Name");
            table.Columns.Add("Description");

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                DataRow row = table.NewRow();
                row["ID"] = GetInt32(_reader, "ID");
                row["Job #"] = GetString(_reader, "JobNumber");
                row["Name"] = GetString(_reader, "Name");
                row["Description"] = GetString(_reader, "Description");
                table.Rows.Add(row);
            }
            _reader.Close();
            _cmd.Dispose();

            return table;
        }

    }
}
