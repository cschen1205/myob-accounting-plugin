using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.JournalRecords
{
    public abstract class JournalRecordManager : EntityManager<JournalRecord>
    {
        public JournalRecordManager(DbManager mgr)
            : base(mgr)
        {

        }

        #region +(Factory Methods)
        protected override JournalRecord _CreateDbEntity()
        {
            return new JournalRecord(true, this);
        }

        protected override JournalRecord _CreateEntity()
        {
            return new JournalRecord(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(JournalRecord _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["JournalRecordID"] = DbMgr.CreateAutoIntFieldEntry(_obj.JournalRecordID);
            fields["RecordSessionDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.RecordSessionDate);
            fields["TransactionDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.TransactionDate);
            fields["DateReconciled"] = DbMgr.CreateDateTimeFieldEntry(_obj.DateReconciled);
            fields["JobID"] = DbMgr.CreateIntFieldEntry(_obj.JobID);
            fields["RecordSessionTime"] = DbMgr.CreateStringFieldEntry(_obj.RecordSessionTime);
            fields["UserID"] = DbMgr.CreateIntFieldEntry(_obj.UserID);
            fields["ReconciliationStatusID"] = DbMgr.CreateStringFieldEntry(_obj.ReconciliationStatusID);
            fields["IsExchangeConversion"] = DbMgr.CreateStringFieldEntry(_obj.IsExchangeConversion);
            fields["IsForeignTransaction"] = DbMgr.CreateStringFieldEntry(_obj.IsForeignTransaction);
            fields["EntryIsPurged"] = DbMgr.CreateStringFieldEntry(_obj.EntryIsPurged);
            fields["IsMultipleJob"] = DbMgr.CreateStringFieldEntry(_obj.IsMultipleJob);
            fields["TaxExclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveAmount);
            fields["AccountID"] = DbMgr.CreateIntFieldEntry(_obj.AccountID);
            fields["IsThirteenthPeriod"] = DbMgr.CreateStringFieldEntry(_obj.IsThirteenthPeriod);
            fields["SetID"] = DbMgr.CreateIntFieldEntry(_obj.SetID);
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll()
                .From("JournalRecords");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByJournalRecordID(int JournalRecordID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll()
                .From("JournalRecords")
                .Criteria.IsEqual("JournalRecords", "JournalRecordID", JournalRecordID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByJournalRecordID(int JournalRecordID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("JournalRecords")
                .Criteria.IsEqual("JournalRecords", "JournalRecordID", JournalRecordID);
            return clause;
        }

        private bool Exists(int? JournalRecordID)
        {
            if (JournalRecordID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByJournalRecordID(JournalRecordID.Value)) != 0;
        }

        public override bool Exists(JournalRecord _obj)
        {
            return Exists(_obj.JournalRecordID);
        }

        protected override void LoadFromReader(JournalRecord _obj, DbDataReader _reader)
        {
            _obj.JournalRecordID =GetInt32(_reader, ("JournalRecordID"));
            _obj.RecordSessionDate = GetDateTime(_reader, ("RecordSessionDate"));
            _obj.TransactionDate = GetDateTime(_reader, ("TransactionDate"));
            _obj.DateReconciled = GetDateTime(_reader, ("DateReconciled"));
            _obj.JobID =GetInt32(_reader, ("JobID"));
            _obj.RecordSessionTime =GetString(_reader, ("RecordSessionTime"));
            _obj.UserID =GetInt32(_reader, ("UserID"));
            _obj.ReconciliationStatusID =GetString(_reader, ("ReconciliationStatusID"));
            _obj.IsExchangeConversion =GetString(_reader, ("IsExchangeConversion"));
            _obj.IsForeignTransaction =GetString(_reader, ("IsForeignTransaction"));
            _obj.EntryIsPurged =GetString(_reader, ("EntryIsPurged"));
            _obj.IsMultipleJob =GetString(_reader, ("IsMultipleJob"));
            _obj.TaxExclusiveAmount = GetDouble(_reader, ("TaxExclusiveAmount"));
            _obj.AccountID =GetInt32(_reader, ("AccountID"));
            _obj.IsThirteenthPeriod =GetString(_reader, ("IsThirteenthPeriod"));
            _obj.SetID =GetInt32(_reader, ("SetID"));
            _obj.LineNumber =GetInt32(_reader, ("LineNumber"));
        }

        protected override object GetDbProperty(JournalRecord _obj, string property_name)
        {
            if (property_name.Equals("Job"))
            {
                return RepositoryMgr.JobMgr.FindById(_obj.JobID);
            }
            else if (property_name.Equals("Account"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.AccountID);
            }
            return null;
        }

        public JournalRecord CreateOrRetrieve(int JournalRecordID)
        {
            bool created;
            return CreateOrRetrieve(JournalRecordID, out created);
        }

        public JournalRecord CreateOrRetrieve(int JournalRecordID, out bool created)
        {
            JournalRecord _obj = _FindByIntId(JournalRecordID);
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

        protected override JournalRecord _FindByIntId(int? JournalRecordID)
        {
            if (Exists(JournalRecordID))
            {
                JournalRecord _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByJournalRecordID(JournalRecordID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override IList<JournalRecord>_FindAllCollection()
        {
            List<JournalRecord> objs = new List<JournalRecord>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                JournalRecord _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                objs.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return objs;
        }

        public List<JournalRecord> List(int? SetID)
        {
           

            List<JournalRecord> objs = new List<JournalRecord>();
            if (SetID == null) return objs;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("JournalRecords")
                .Criteria.IsEqual("JournalRecords", "SetID", SetID);
            

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                JournalRecord _obj = CreateDbEntity();
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
                .SelectColumn("JournalRecords", "JournalRecordID", "ID")
                .From("JournalRecords");
            

            DataTable table=new DataTable();
            table.Columns.Add("ID");

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                DataRow row = table.NewRow();
                row["ID"] = GetInt32(_reader, "ID");
                table.Rows.Add(row);
            }
            _reader.Close();
            _cmd.Dispose();

            return table;
        }

    }
}
