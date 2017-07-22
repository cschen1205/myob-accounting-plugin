using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Sales
{
    public abstract class RecurringSaleLineManager : RecurringEntityManager<RecurringSaleLine>
    {
        public RecurringSaleLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override RecurringSaleLine _CreateDbEntity()
        {
            return new RecurringSaleLine(true, this);
        }

        protected override RecurringSaleLine _CreateEntity()
        {
            return new RecurringSaleLine(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(RecurringSaleLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["RecurringSaleLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.RecurringSaleLineID);
            fields["RecurringSaleID"] = DbMgr.CreateIntFieldEntry(_obj.RecurringSaleID);
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber);
            fields["LineTypeID"] = DbMgr.CreateStringFieldEntry(_obj.LineTypeID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);
            fields["TaxExclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveAmount);
            fields["TaxInclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveAmount);
            fields["JobID"] = DbMgr.CreateIntFieldEntry(_obj.JobID);
            fields["TaxBasisAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxBasisAmount);
            fields["TaxBasisAmountIsInclusive"] = DbMgr.CreateStringFieldEntry(_obj.TaxBasisAmountIsInclusive);
            fields["TaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.TaxCodeID);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("RecurringSaleLines");
        }

        private DbSelectStatement GetQuery_SelectByRecurringSaleLineID(int RecurringSaleLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringSaleLines")
                .Criteria
                    .IsEqual("RecurringSaleLines", "RecurringSaleLineID", RecurringSaleLineID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByRecurringSaleLineID(int RecurringSaleLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("RecurringSaleLines")
                .Criteria
                    .IsEqual("RecurringSaleLines", "RecurringSaleLineID", RecurringSaleLineID);

            return clause;
        }

        private bool Exists(int? RecurringSaleLineID)
        {
            if (RecurringSaleLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByRecurringSaleLineID(RecurringSaleLineID.Value)) != 0;
        }

        public override bool Exists(RecurringSaleLine _obj)
        {
            return Exists(_obj.RecurringSaleLineID);
        }

        public List<RecurringSaleLine> List(int? RecurringSaleID)
        {
            List<RecurringSaleLine> _grp = new List<RecurringSaleLine>();

            if (RecurringSaleID == null) return _grp;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringSaleLines")
                .Criteria
                    .IsEqual("RecurringSaleLines", "RecurringSaleID", RecurringSaleID.Value);

            

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringSaleLine _obj =CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override RecurringSaleLine _FindByIntId(int? RecurringSaleLineID)
        {
            if (Exists(RecurringSaleLineID))
            {
                RecurringSaleLine _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByRecurringSaleLineID(RecurringSaleLineID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override void LoadFromReader(RecurringSaleLine _obj, DbDataReader _reader)
        {
            _obj.RecurringSaleLineID =GetInt32(_reader, ("RecurringSaleLineID"));
            _obj.RecurringSaleID =GetInt32(_reader, ("RecurringSaleID"));
            _obj.LineNumber =GetInt32(_reader, ("LineNumber"));
            _obj.LineTypeID =GetString(_reader, ("LineTypeID"));
            _obj.Description =GetString(_reader, ("Description"));
            _obj.TaxExclusiveAmount = GetDouble(_reader, ("TaxExclusiveAmount"));
            _obj.TaxInclusiveAmount = GetDouble(_reader, ("TaxInclusiveAmount"));
            _obj.JobID =GetInt32(_reader, ("JobID"));
            _obj.TaxBasisAmount = GetDouble(_reader, ("TaxBasisAmount"));
            _obj.TaxBasisAmountIsInclusive =GetString(_reader, ("TaxBasisAmountIsInclusive"));
            _obj.TaxCodeID =GetInt32(_reader, ("TaxCodeID"));
        }

        protected override object GetDbProperty(RecurringSaleLine _obj, string property_name)
        {
            if (property_name.Equals("TaxCode"))
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.TaxCodeID);
            }
            else if (property_name.Equals("Job"))
            {
                return RepositoryMgr.JobMgr.FindById(_obj.JobID);
            }
            else if(property_name.Equals("RecurringSale"))
            {
                return RepositoryMgr.RecurringSaleMgr.FindById(_obj.RecurringSaleID);
            }
            return null;
        }

        protected override IList<RecurringSaleLine>_FindAllCollection()
        {
            List<RecurringSaleLine> _grp = new List<RecurringSaleLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringSaleLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

    }
}
