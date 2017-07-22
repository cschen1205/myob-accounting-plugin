using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.JournalRecords
{
    public abstract class RecurringGeneralJournalLineManager : EntityManager<RecurringGeneralJournalLine>
    {
        public RecurringGeneralJournalLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        #region +(Factory Methods)
        protected override RecurringGeneralJournalLine _CreateDbEntity()
        {
            return new RecurringGeneralJournalLine(true, this);
        }

        protected override RecurringGeneralJournalLine _CreateEntity()
        {
            return new RecurringGeneralJournalLine(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(RecurringGeneralJournalLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["RecurringGeneralJournalLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.RecurringGeneralJournalLineID);
            fields["RecurringGeneralJournalLineID"] = DbMgr.CreateIntFieldEntry(_obj.RecurringGeneralJournalLineID);
            fields["AccountID"] = DbMgr.CreateIntFieldEntry(_obj.AccountID);
            fields["RecurringGeneralJournalID"] = DbMgr.CreateIntFieldEntry(_obj.RecurringGeneralJournalID);
            fields["IsMultipleJob"] = DbMgr.CreateStringFieldEntry(_obj.IsMultipleJob);
            fields["JobID"] = DbMgr.CreateIntFieldEntry(_obj.JobID);
            fields["LineMemo"] = DbMgr.CreateStringFieldEntry(_obj.LineMemo);
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber);
            fields["TaxExclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveAmount);
            fields["TaxInclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveAmount);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll()
                .From("RecurringGeneralJournalLines");
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByRecurringGeneralJournalLineID(int RecurringGeneralJournalLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll()
                .From("RecurringGeneralJournalLines")
                .Criteria.IsEqual("RecurringGeneralJournalLines", "RecurringGeneralJournalLineID", RecurringGeneralJournalLineID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByRecurringGeneralJournalLineID(int RecurringGeneralJournalLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectCount()
                .From("RecurringGeneralJournalLines")
                .Criteria.IsEqual("RecurringGeneralJournalLines", "RecurringGeneralJournalLineID", RecurringGeneralJournalLineID);
            return clause;
        }

        public override  bool Exists(RecurringGeneralJournalLine _obj)
        {
            return Exists (_obj.RecurringGeneralJournalLineID) ;
        }

        protected override void LoadFromReader(RecurringGeneralJournalLine _obj, DbDataReader _reader)
        {
            _obj.RecurringGeneralJournalLineID =GetInt32(_reader, ("RecurringGeneralJournalLineID"));
            _obj.AccountID =GetInt32(_reader, ("AccountID"));
            _obj.RecurringGeneralJournalID =GetInt32(_reader, ("RecurringGeneralJournalID"));
            _obj.IsMultipleJob =GetString(_reader, ("IsMultipleJob"));
            _obj.JobID =GetInt32(_reader, ("JobID"));
            _obj.LineMemo =GetString(_reader, ("LineMemo"));
            _obj.LineNumber =GetInt32(_reader, ("LineNumber"));
            _obj.TaxExclusiveAmount = GetDouble(_reader, ("TaxExclusiveAmount"));
            _obj.TaxInclusiveAmount = GetDouble(_reader, ("TaxInclusiveAmount"));
        }

        protected override object GetDbProperty(RecurringGeneralJournalLine _obj, string property_name)
        {
            if (property_name == "Account")
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.AccountID);
            }
            else if (property_name == "Job")
            {
                return RepositoryMgr.JobMgr.FindById(_obj.JobID);
            }
            return null;
        }

        private bool Exists(int? RecurringGeneralJournalLineID)
        {
            if (RecurringGeneralJournalLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByRecurringGeneralJournalLineID(RecurringGeneralJournalLineID.Value)) != 0;
        }

        protected override RecurringGeneralJournalLine _FindByIntId(int? RecurringGeneralJournalLineID)
        {
            if (Exists(RecurringGeneralJournalLineID))
            {
                RecurringGeneralJournalLine _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByRecurringGeneralJournalLineID(RecurringGeneralJournalLineID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override IList<RecurringGeneralJournalLine>_FindAllCollection()
        {
            List<RecurringGeneralJournalLine> _employees = new List<RecurringGeneralJournalLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringGeneralJournalLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _employees.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _employees;
        }

        public List<RecurringGeneralJournalLine> List(int? RecurringGeneralJournalID)
        {
            List<RecurringGeneralJournalLine> _employees = new List<RecurringGeneralJournalLine>();

            if (RecurringGeneralJournalID == null) return _employees;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringGeneralJournalLines")
                .Criteria
                    .IsEqual("RecurringGeneralJournalLines", "RecurringGeneralJournalID", RecurringGeneralJournalID);

            

            

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringGeneralJournalLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _employees.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _employees;
        }


        public DataTable Table()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectColumn("RecurringGeneralJournalLines", "LineNumber")
                .From("RecurringGeneralJournalLines");
            

            DataTable table = new DataTable();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                DataRow row = table.NewRow();
                row["LineNumber"] = GetInt32(_reader, "LineNumber");
                table.Rows.Add(row);
            }
            _reader.Close();
            _cmd.Dispose();
             
            return table;
        }

        public RecurringGeneralJournalLine CreateOrRetrieve(int RecurringGeneralJournalLineID, out bool created)
        {
            RecurringGeneralJournalLine _obj = _FindByIntId(RecurringGeneralJournalLineID);
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

        public RecurringGeneralJournalLine CreateOrRetrieve(int RecurringGeneralJournalLineID)
        {
            bool created;
            return CreateOrRetrieve(RecurringGeneralJournalLineID, out created);
        }
    }
}
