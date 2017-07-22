using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.JournalRecords
{
    public abstract class RecurringGeneralJournalManager : RecurringEntityManager<RecurringGeneralJournal>
    {
        public RecurringGeneralJournalManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        #region +(Factory Methods)
        protected override RecurringGeneralJournal _CreateDbEntity()
        {
            return new RecurringGeneralJournal(true, this);
        }

        protected override RecurringGeneralJournal _CreateEntity()
        {
            return new RecurringGeneralJournal(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(RecurringGeneralJournal _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetRecurringEntityFields(_obj);
            fields["RecurringGeneralJournalID"] = DbMgr.CreateAutoIntFieldEntry(_obj.RecurringGeneralJournalID);
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive);
            fields["GSTReportingMethodID"] = DbMgr.CreateStringFieldEntry(_obj.GSTReportingMethodID);
            fields["CostCentreID"] = DbMgr.CreateIntFieldEntry(_obj.CostCentreID);
            return fields;
        }


        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringGeneralJournals");
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByRecurringGeneralJournalNumber(string RecurringGeneralJournalNumber)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringGeneralJournals")
                .Criteria.IsEqual("RecurringGeneralJournals", "RecurringGeneralJournalNumber", RecurringGeneralJournalNumber);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByRecurringGeneralJournalID(int RecurringGeneralJournalID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringGeneralJournals")
                .Criteria.IsEqual("RecurringGeneralJournals", "RecurringGeneralJournalID", RecurringGeneralJournalID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByRecurringGeneralJournalNumber(string RecurringGeneralJournalNumber)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("RecurringGeneralJournals")
                .Criteria.IsEqual("RecurringGeneralJournals", "RecurringGeneralJournalNumber", RecurringGeneralJournalNumber);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByRecurringGeneralJournalID(int RecurringGeneralJournalID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringGeneralJournals")
                .Criteria.IsEqual("RecurringGeneralJournals", "RecurringGeneralJournalID", RecurringGeneralJournalID);
            return clause;
        }

        public override bool Exists(RecurringGeneralJournal _obj)
        {
            return Exists(_obj.RecurringGeneralJournalID);
        }

        protected override void LoadFromReader(RecurringGeneralJournal _obj, DbDataReader _reader)
        {
            LoadRecurringEntityFromReader(_obj, _reader);

            _obj.RecurringGeneralJournalID =GetInt32(_reader, ("RecurringGeneralJournalID"));
            _obj.Memo =GetString(_reader, ("Memo"));
            _obj.IsTaxInclusive =GetString(_reader, ("IsTaxInclusive"));
            _obj.CostCentreID = GetInt32(_reader, "CostCentreID");
            _obj.GSTReportingMethodID = GetString(_reader, "GSTReportingMethodID");
            _obj.CurrencyID =GetInt32(_reader, ("CurrencyID"));
        }

        protected override object GetDbProperty(RecurringGeneralJournal _obj, string property_name)
        {
            object returned_object = GetRecurringEntityDbProperty(_obj, property_name);
            if (returned_object != null) return returned_object;

            if (property_name == "Currency")
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name.Equals("RecurringGeneralJournalLines"))
            {
                return RepositoryMgr.RecurringGeneralJournalLineMgr.List(_obj.RecurringGeneralJournalID);
            }
            return null;
        }

        private bool Exists(int? RecurringGeneralJournalID)
        {
            if (RecurringGeneralJournalID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByRecurringGeneralJournalID(RecurringGeneralJournalID.Value)) != 0;
        }

        private bool Exists(string RecurringGeneralJournalNumber)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByRecurringGeneralJournalNumber(RecurringGeneralJournalNumber)) != 0;
        }

        protected override RecurringGeneralJournal _FindByIntId(int? RecurringGeneralJournalID)
        {
            if (Exists(RecurringGeneralJournalID))
            {
                RecurringGeneralJournal _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByRecurringGeneralJournalID(RecurringGeneralJournalID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override RecurringGeneralJournal _FindByTextId(string RecurringGeneralJournalNumber)
        {
            if (Exists(RecurringGeneralJournalNumber))
            {
                RecurringGeneralJournal _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByRecurringGeneralJournalNumber(RecurringGeneralJournalNumber));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override IList<RecurringGeneralJournal>_FindAllCollection()
        {
            List<RecurringGeneralJournal> _employees = new List<RecurringGeneralJournal>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringGeneralJournal _obj = CreateDbEntity();
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
                .SelectColumn("RecurringGeneralJournals", "RecurringGeneralJournalNumber", "RecurringGeneralJournalNumber")
                .From("RecurringGeneralJournals");
            

            DataTable table = new DataTable();
            table.Columns.Add("RecurringGeneralJournalNumber");

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                DataRow row = table.NewRow();
                row["RecurringGeneralJournalNumber"] = GetInt32(_reader, "RecurringGeneralJournalNumber");
                table.Rows.Add(row);
            }
            _reader.Close();
            _cmd.Dispose();

            return table;
        }

       

        public RecurringGeneralJournal CreateOrRetrieve(string RecurringGeneralJournalNumber, out bool created)
        {
            RecurringGeneralJournal _obj = _FindByTextId(RecurringGeneralJournalNumber);
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

        public RecurringGeneralJournal CreateOrRetrieve(string RecurringGeneralJournalNumber)
        {
            bool created;
            return CreateOrRetrieve(RecurringGeneralJournalNumber, out created);
        }
    }
}
