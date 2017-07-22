using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Transactions
{
    public abstract class RecurringMoneySpentLineManager : EntityManager<RecurringMoneySpentLine>
    {
        public RecurringMoneySpentLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override RecurringMoneySpentLine _CreateDbEntity()
        {
            return new RecurringMoneySpentLine(true, this);
        }
        protected override RecurringMoneySpentLine _CreateEntity()
        {
            return new RecurringMoneySpentLine(false, this);
        }
        #endregion

        protected override void LoadFromReader(RecurringMoneySpentLine _obj, DbDataReader reader)
        {
            _obj.AccountID = GetInt32(reader, "AccountID");
            _obj.JobID = GetInt32(reader, "JobID");
            _obj.LineMemo = GetString(reader, "LineMemo");
            _obj.LineNumber = GetInt32(reader, "LineNumber");
            _obj.RecurringMoneySpentID = GetInt32(reader, "RecurringMoneySpentID");
            _obj.RecurringMoneySpentLineID = GetInt32(reader, "RecurringMoneySpentLineID");
            _obj.TaxCodeID = GetInt32(reader, "TaxCodeID");
            _obj.TaxExclusiveAmount = GetDouble(reader, "TaxExclusiveAmount");
            _obj.TaxInclusiveAmount = GetDouble(reader, "TaxInclusiveAmount");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(RecurringMoneySpentLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["AccountID"] = DbMgr.CreateIntFieldEntry(_obj.AccountID);
            fields["JobID"] = DbMgr.CreateIntFieldEntry(_obj.JobID);
            fields["LineMemo"] = DbMgr.CreateStringFieldEntry(_obj.LineMemo);
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber);
            fields["RecurringMoneySpentID"] = DbMgr.CreateIntFieldEntry(_obj.RecurringMoneySpentID);
            fields["RecurringMoneySpentLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.RecurringMoneySpentLineID);
            fields["TaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.TaxCodeID);
            fields["TaxExclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveAmount);
            fields["TaxInclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveAmount);
            return fields;
        }

        protected override object GetDbProperty(RecurringMoneySpentLine _obj, string property_name)
        {
            if (property_name.Equals("Job"))
            {
                return RepositoryMgr.JobMgr.FindById(_obj.JobID);
            }
            else if (property_name.Equals("Account"))
            {
                return RepositoryMgr.JobMgr.FindById(_obj.AccountID);
            }
            else if (property_name.Equals("TaxCode"))
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.TaxCodeID);
            }
            else if (property_name.Equals("RecurringMoneySpent"))
            {
                return RepositoryMgr.RecurringMoneySpentMgr.FindById(_obj.RecurringMoneySpentID);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectByRecurringMoneySpentLineID(int RecurringMoneySpentLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringMoneySpentLines")
                .Criteria
                    .IsEqual("RecurringMoneySpentLines", "RecurringMoneySpentLineID", RecurringMoneySpentLineID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByRecurringMoneySpentID(int RecurringMoneySpentID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringMoneySpentLines")
                .Criteria
                    .IsEqual("RecurringMoneySpentLines", "MoneSpentID", RecurringMoneySpentID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByRecurringMoneySpentLineID(int RecurringMoneySpentLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("RecurringMoneySpentLines")
                .Criteria
                    .IsEqual("RecurringMoneySpentLines", "RecurringMoneySpentLineID", RecurringMoneySpentLineID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringMoneySpentLines");
            return clause;
        }

        public bool Exists(int? RecurringMoneySpentLineID)
        {
            if (RecurringMoneySpentLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByRecurringMoneySpentLineID(RecurringMoneySpentLineID.Value)) != 0;
        }

        public override bool Exists(RecurringMoneySpentLine _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.RecurringMoneySpentLineID);
        }

        protected override RecurringMoneySpentLine _FindByIntId(int? RecurringMoneySpentLineID)
        {
            if (RecurringMoneySpentLineID == null) return null;

            RecurringMoneySpentLine _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByRecurringMoneySpentLineID(RecurringMoneySpentLineID.Value));
            DbDataReader _reader = _cmd.ExecuteReader();
            if (_reader.Read())
            {
                _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
            }
            _reader.Close();
            _cmd.Dispose();

            return _obj;
        }

        protected override IList<RecurringMoneySpentLine>_FindAllCollection()
        {
            List<RecurringMoneySpentLine> _grp=new List<RecurringMoneySpentLine>();

            DbCommand _cmd=CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while(_reader.Read())
            {
                RecurringMoneySpentLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        public List<RecurringMoneySpentLine> List(int? RecurringMoneySpentID)
        {
            List<RecurringMoneySpentLine> _grp = new List<RecurringMoneySpentLine>();

            if (RecurringMoneySpentID == null) return _grp;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByRecurringMoneySpentID(RecurringMoneySpentID.Value));
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringMoneySpentLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
