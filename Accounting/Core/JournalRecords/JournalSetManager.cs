using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.JournalRecords
{
    public abstract class JournalSetManager : EntityManager<JournalSet>
    {
        public JournalSetManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        #region +(Factory Methods)
        protected override JournalSet _CreateDbEntity()
        {
            return new JournalSet(true, this);
        }

        protected override JournalSet _CreateEntity()
        {
            return new JournalSet(false, this);
        }
        #endregion

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("JournalSets");
            return clause;
        }

        public override Dictionary<string, DbFieldEntry> GetFields(JournalSet _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["SetID"] = DbMgr.CreateAutoIntFieldEntry(_obj.SetID);
            fields["JournalTypeID"] = DbMgr.CreateStringFieldEntry(_obj.JournalTypeID);
            fields["TransactionExchangeRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TransactionExchangeRate);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo);
            fields["TransactionNumber"] = DbMgr.CreateStringFieldEntry(_obj.TransactionNumber);
            fields["SourceID"] = DbMgr.CreateIntFieldEntry(_obj.SourceID);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectByTransactionDates(DateTime start_date, DateTime end_date)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll("JournalSets")
                .From("JournalSets")
                .From("JournalRecords")
                .Join("JournalRecords", "SetID", "JournalSets", "SetID")
                .Criteria
                    .IsGreaterEqual("JournalRecords", "TransactionDate", start_date)
                    .IsLessEqual("JournalRecords", "TransactionDate", end_date);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectBySetID(int SetID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("JournalSets")
                .Criteria
                    .IsEqual("JournalSets", "SetID", SetID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountBySetID(int SetID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("JournalSets")
                .Criteria
                    .IsEqual("JournalSets", "SetID", SetID);

            return clause;
        }

        private bool Exists(int? SetID)
        {
            if (SetID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountBySetID(SetID.Value)) != 0;
        }

        public override bool Exists(JournalSet _obj)
        {
            return Exists(_obj.SetID);
        }

        protected override void LoadFromReader(JournalSet _obj, DbDataReader reader)
        {
            _obj.SetID =GetInt32(reader, ("SetID"));
            _obj.JournalTypeID =GetString(reader, ("JournalTypeID"));
            _obj.TransactionExchangeRate = GetDouble(reader, ("TransactionExchangeRate"));
            _obj.CurrencyID =GetInt32(reader, ("CurrencyID"));
            _obj.Memo =GetString(reader, ("Memo"));
            _obj.TransactionNumber =GetString(reader, ("TransactionNumber"));
            _obj.SourceID =GetInt32(reader, ("SourceID"));
        }

        protected override object GetDbProperty(JournalSet _obj, string property_name)
        {
            if (property_name.Equals("Currency"))
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name.Equals("JournalType"))
            {
                return RepositoryMgr.JournalTypeMgr.FindById(_obj.JournalTypeID);
            }
            else if (property_name.Equals("JournalRecords"))
            {
                return RepositoryMgr.JournalRecordMgr.List(_obj.SetID);
            }
            return null;
        }


        public JournalSet CreateOrRetrieve(int SetID)
        {
            bool created;
            return CreateOrRetrieve(SetID, out created);
        }

        public JournalSet CreateOrRetrieve(int SetID, out bool created)
        {
            JournalSet _obj = _FindByIntId(SetID);
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

        protected override JournalSet _FindByIntId(int? SetID)
        {
            if (Exists(SetID))
            {
                JournalSet _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectBySetID(SetID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override IList<JournalSet>_FindAllCollection()
        {
            List<JournalSet> objs = new List<JournalSet>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                JournalSet _obj = CreateDbEntity();
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
                .SelectColumn("JournalSets", "SetID", "ID")
                .From("JournalSets");
            

            DataTable table = new DataTable();
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

        public List<JournalSet> RetrieveByTransactionDates(DateTime start_date, DateTime end_date)
        {
            List<JournalSet> objs = new List<JournalSet>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByTransactionDates(start_date, end_date));
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                JournalSet _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                objs.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            objs.Sort(new Comparison<JournalSet>(Compare));

            return objs;
        }

        public int Compare(JournalSet a, JournalSet b)
        {
            if (a.TransactionDate.HasValue && b.TransactionDate.HasValue)
            {
                
                
                if (a.TransactionDate == b.TransactionDate)
                {
                    return 0;
                }
                else if (a.TransactionDate > b.TransactionDate)
                {
                    return 1;
                }
                return -1;
            }
            return -1;
        }
    }
}
