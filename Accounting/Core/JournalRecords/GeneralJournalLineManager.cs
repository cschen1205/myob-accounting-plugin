using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.JournalRecords
{
    public abstract class GeneralJournalLineManager : EntityManager<GeneralJournalLine>
    {
        public GeneralJournalLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        #region +(Factory Methods)
        protected override GeneralJournalLine _CreateDbEntity()
        {
            return new GeneralJournalLine(true, this);
        }

        protected override GeneralJournalLine _CreateEntity()
        {
            return new GeneralJournalLine(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(GeneralJournalLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["GeneralJournalLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.GeneralJournalLineID);
            fields["GeneralJournalLineID"] = DbMgr.CreateIntFieldEntry(_obj.GeneralJournalLineID);
            fields["AccountID"] = DbMgr.CreateIntFieldEntry(_obj.AccountID);
            fields["GeneralJournalID"] = DbMgr.CreateIntFieldEntry(_obj.GeneralJournalID);
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
                .From("GeneralJournalLines");
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByGeneralJournalLineID(int GeneralJournalLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll()
                .From("GeneralJournalLines")
                .Criteria.IsEqual("GeneralJournalLines", "GeneralJournalLineID", GeneralJournalLineID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByGeneralJournalLineID(int GeneralJournalLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectCount()
                .From("GeneralJournalLines")
                .Criteria.IsEqual("GeneralJournalLines", "GeneralJournalLineID", GeneralJournalLineID);
            return clause;
        }

        public override  bool Exists(GeneralJournalLine _obj)
        {
            return Exists (_obj.GeneralJournalLineID) ;
        }

        protected override void LoadFromReader(GeneralJournalLine _obj, DbDataReader _reader)
        {
            _obj.GeneralJournalLineID =GetInt32(_reader, ("GeneralJournalLineID"));
            _obj.AccountID =GetInt32(_reader, ("AccountID"));
            _obj.GeneralJournalID =GetInt32(_reader, ("GeneralJournalID"));
            _obj.IsMultipleJob =GetString(_reader, ("IsMultipleJob"));
            _obj.JobID =GetInt32(_reader, ("JobID"));
            _obj.LineMemo =GetString(_reader, ("LineMemo"));
            _obj.LineNumber =GetInt32(_reader, ("LineNumber"));
            _obj.TaxExclusiveAmount = GetDouble(_reader, ("TaxExclusiveAmount"));
            _obj.TaxInclusiveAmount = GetDouble(_reader, ("TaxInclusiveAmount"));
        }

        protected override object GetDbProperty(GeneralJournalLine _obj, string property_name)
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

        private bool Exists(int? GeneralJournalLineID)
        {
            if (GeneralJournalLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByGeneralJournalLineID(GeneralJournalLineID.Value)) != 0;
        }

        protected override GeneralJournalLine _FindByIntId(int? GeneralJournalLineID)
        {
            if (Exists(GeneralJournalLineID))
            {
                GeneralJournalLine _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByGeneralJournalLineID(GeneralJournalLineID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override IList<GeneralJournalLine>_FindAllCollection()
        {
            List<GeneralJournalLine> _employees = new List<GeneralJournalLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                GeneralJournalLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _employees.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _employees;
        }

        public List<GeneralJournalLine> List(int? GeneralJournalID)
        {
            List<GeneralJournalLine> _employees = new List<GeneralJournalLine>();

            if (GeneralJournalID == null) return _employees;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("GeneralJournalLines")
                .Criteria
                    .IsEqual("GeneralJournalLines", "GeneralJournalID", GeneralJournalID);

            

            

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                GeneralJournalLine _obj = CreateDbEntity();
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
                .SelectColumn("GeneralJournalLines", "LineNumber")
                .From("GeneralJournalLines");
            

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

        public GeneralJournalLine CreateOrRetrieve(int GeneralJournalLineID, out bool created)
        {
            GeneralJournalLine _obj = _FindByIntId(GeneralJournalLineID);
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

        public GeneralJournalLine CreateOrRetrieve(int GeneralJournalLineID)
        {
            bool created;
            return CreateOrRetrieve(GeneralJournalLineID, out created);
        }
    }
}
