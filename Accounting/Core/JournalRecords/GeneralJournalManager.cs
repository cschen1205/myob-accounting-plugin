using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.JournalRecords
{
    public abstract class GeneralJournalManager : EntityManager<GeneralJournal>
    {
        public GeneralJournalManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        #region +(Factory Methods)
        protected override GeneralJournal _CreateDbEntity()
        {
            return new GeneralJournal(true, this);
        }

        protected override GeneralJournal _CreateEntity()
        {
            return new GeneralJournal(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(GeneralJournal _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["GeneralJournalID"] = DbMgr.CreateAutoIntFieldEntry(_obj.GeneralJournalID);
            fields["GeneralJournalID"] = DbMgr.CreateIntFieldEntry(_obj.GeneralJournalID);
            fields["GeneralJournalNumber"] = DbMgr.CreateStringFieldEntry(_obj.GeneralJournalNumber);
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo);
            if (_obj.TransactionDate != null) fields["TransactionDate"] = DbMgr.CreateStringFieldEntry(Convert.ToString(_obj.TransactionDate));
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["IsThirteenthPeriod"] = DbMgr.CreateStringFieldEntry(_obj.IsThirteenthPeriod);
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive);
            fields["IsAutoRecorded"] = DbMgr.CreateStringFieldEntry(_obj.IsAutoRecorded);
            fields["TransactionExchangeRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TransactionExchangeRate);

            return fields;
        }


        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("GeneralJournals");
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByGeneralJournalNumber(string GeneralJournalNumber)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("GeneralJournals")
                .Criteria.IsEqual("GeneralJournals", "GeneralJournalNumber", GeneralJournalNumber);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByGeneralJournalID(int GeneralJournalID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("GeneralJournals")
                .Criteria.IsEqual("GeneralJournals", "GeneralJournalID", GeneralJournalID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByGeneralJournalNumber(string GeneralJournalNumber)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("GeneralJournals")
                .Criteria.IsEqual("GeneralJournals", "GeneralJournalNumber", GeneralJournalNumber);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByGeneralJournalID(int GeneralJournalID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("GeneralJournals")
                .Criteria.IsEqual("GeneralJournals", "GeneralJournalID", GeneralJournalID);
            return clause;
        }

        public override bool Exists(GeneralJournal _obj)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByGeneralJournalNumber(_obj.GeneralJournalNumber)) != 0;
        }

        protected override void LoadFromReader(GeneralJournal _obj, DbDataReader _reader)
        {
            _obj.GeneralJournalID =GetInt32(_reader, ("GeneralJournalID"));
            _obj.GeneralJournalNumber =GetString(_reader, ("GeneralJournalNumber"));
            _obj.TransactionDate = GetDateTime(_reader, ("TransactionDate"));
            _obj.IsThirteenthPeriod =GetString(_reader, ("IsThirteenthPeriod"));
            _obj.Memo =GetString(_reader, ("Memo"));
            _obj.IsTaxInclusive =GetString(_reader, ("IsTaxInclusive"));
            _obj.IsAutoRecorded =GetString(_reader, ("IsAutoRecorded"));
            _obj.CurrencyID =GetInt32(_reader, ("CurrencyID"));
            _obj.TransactionExchangeRate = GetDouble(_reader, ("TransactionExchangeRate"));
        }

        protected override object GetDbProperty(GeneralJournal _obj, string property_name)
        {
            if (property_name == "Currency")
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name.Equals("GeneralJournalLines"))
            {
                return RepositoryMgr.GeneralJournalLineMgr.List(_obj.GeneralJournalID);
            }
            return null;
        }

        private bool Exists(int? GeneralJournalID)
        {
            if (GeneralJournalID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByGeneralJournalID(GeneralJournalID.Value)) != 0;
        }

        private bool Exists(string GeneralJournalNumber)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByGeneralJournalNumber(GeneralJournalNumber)) != 0;
        }

        protected override GeneralJournal _FindByIntId(int? GeneralJournalID)
        {
            if (Exists(GeneralJournalID))
            {
                GeneralJournal _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByGeneralJournalID(GeneralJournalID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override GeneralJournal _FindByTextId(string GeneralJournalNumber)
        {
            if (Exists(GeneralJournalNumber))
            {
                GeneralJournal _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByGeneralJournalNumber(GeneralJournalNumber));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override IList<GeneralJournal>_FindAllCollection()
        {
            List<GeneralJournal> _employees = new List<GeneralJournal>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                GeneralJournal _obj = CreateDbEntity();
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
                .SelectColumn("GeneralJournals", "GeneralJournalNumber", "GeneralJournalNumber")
                .From("GeneralJournals");
            

            DataTable table = new DataTable();
            table.Columns.Add("GeneralJournalNumber");

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                DataRow row = table.NewRow();
                row["GeneralJournalNumber"] = GetInt32(_reader, "GeneralJournalNumber");
                table.Rows.Add(row);
            }
            _reader.Close();
            _cmd.Dispose();

            return table;
        }

       

        public GeneralJournal CreateOrRetrieve(string GeneralJournalNumber, out bool created)
        {
            GeneralJournal _obj = _FindByTextId(GeneralJournalNumber);
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

        public GeneralJournal CreateOrRetrieve(string GeneralJournalNumber)
        {
            bool created;
            return CreateOrRetrieve(GeneralJournalNumber, out created);
        }
    }
}
