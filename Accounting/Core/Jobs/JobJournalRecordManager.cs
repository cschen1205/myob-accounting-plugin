using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Jobs
{
    public abstract class JobJournalRecordManager : EntityManager<JobJournalRecord>
    {
        public JobJournalRecordManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override JobJournalRecord _CreateEntity()
        {
            return new JobJournalRecord(false, this);
        }
        protected override JobJournalRecord _CreateDbEntity()
        {
            return new JobJournalRecord(true, this);
        }
        #endregion

        protected override void LoadFromReader(JobJournalRecord _obj, DbDataReader reader)
        {
            _obj.JobJournalRecordID = GetInt32(reader, "JobJournalRecordID");
            _obj.IsReimbursed = GetString(reader, "IsReimbursed");
            _obj.AccountID = GetInt32(reader, "AccountID");
            _obj.IsThirteenthPeriod = GetString(reader, "IsThirteenthPeriod");
            _obj.JobID = GetInt32(reader, "JobID");
            _obj.JournalRecordID = GetInt32(reader, "JournalRecordID");
            _obj.JournalTypeID = GetString(reader, "JournalTypeID");
            _obj.SalePurchaseLineID = GetInt32(reader, "SalePurchaseLineID");
            _obj.TaxExclusiveAmount = GetDouble(reader, "TaxExclusiveAmount");
            _obj.TransactionDate = GetDateTime(reader, "TransactionDate");
            _obj.TransactionNumber = GetString(reader, "TransactionNumber");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(JobJournalRecord _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["JobJournalRecordID"] = DbMgr.CreateAutoIntFieldEntry(_obj.JobJournalRecordID);
            fields["JobID"] = DbMgr.CreateIntFieldEntry(_obj.JobID);
            fields["AccountID"] = DbMgr.CreateIntFieldEntry(_obj.AccountID);
            fields["JournalTypeID"] = DbMgr.CreateStringFieldEntry(_obj.JournalTypeID);
            fields["JournalRecordID"] = DbMgr.CreateIntFieldEntry(_obj.JournalRecordID);
            fields["SalePurchaseLineID"] = DbMgr.CreateIntFieldEntry(_obj.SalePurchaseLineID);
            fields["TaxExclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveAmount);
            fields["TransactionNumber"] = DbMgr.CreateStringFieldEntry(_obj.TransactionNumber);
            fields["IsThirteenthPeriod"] = DbMgr.CreateStringFieldEntry(_obj.IsThirteenthPeriod);
            fields["IsReimbursed"] = DbMgr.CreateStringFieldEntry(_obj.IsReimbursed);
            fields["TransactionDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.TransactionDate);
            fields["Date"] = DbMgr.CreateDateTimeFieldEntry(_obj.TransactionDate);

            return fields;
        }

        protected override object GetDbProperty(JobJournalRecord _obj, string property_name)
        {
            if (property_name.Equals("Account"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.AccountID);
            }
            else if (property_name.Equals("Job"))
            {
                return RepositoryMgr.JobMgr.FindById(_obj.JobID);
            }
            else if (property_name.Equals("JournalRecord"))
            {
                return RepositoryMgr.JournalRecordMgr.FindById(_obj.JournalRecordID);
            }
            else if (property_name.Equals("JournalType"))
            {
                return RepositoryMgr.JournalTypeMgr.FindById(_obj.JournalTypeID);
            }
            return null;
        }

        public override bool Exists(JobJournalRecord _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.JobJournalRecordID);
        }

        public bool Exists(int? JobJournalRecordID)
        {
            if (JobJournalRecordID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByJobJournalRecordID(JobJournalRecordID.Value)) != 0;
        }

        private DbSelectStatement GetQuery_SelectCountByJobJournalRecordID(int JobJournalRecordID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("JobJournalRecords")
                .Criteria
                    .IsEqual("JobJournalRecords", "JobJournalRecordID", JobJournalRecordID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll().From("JobJournalRecords");

            return clause;
        }

        protected override IList<JobJournalRecord>_FindAllCollection()
        {
            List<JobJournalRecord> _grp = new List<JobJournalRecord>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                JobJournalRecord _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
