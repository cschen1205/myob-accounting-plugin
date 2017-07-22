using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Transactions
{
    public abstract class RecurringMoneyReceivedLineManager : EntityManager<RecurringMoneyReceivedLine>
    {
        public RecurringMoneyReceivedLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override RecurringMoneyReceivedLine _CreateDbEntity()
        {
            return new RecurringMoneyReceivedLine(true, this);
        }
        protected override RecurringMoneyReceivedLine _CreateEntity()
        {
            return new RecurringMoneyReceivedLine(false, this);
        }
        #endregion

        protected override void LoadFromReader(RecurringMoneyReceivedLine _obj, DbDataReader reader)
        {
            _obj.AccountID = GetInt32(reader, "AccountID");
            _obj.JobID = GetInt32(reader, "JobID");
            _obj.LineMemo = GetString(reader, "LineMemo");
            _obj.LineNumber = GetInt32(reader, "LineNumber");
            _obj.RecurringMoneyReceivedID = GetInt32(reader, "RecurringMoneyReceivedID");
            _obj.RecurringMoneyReceivedLineID = GetInt32(reader, "RecurringMoneyReceivedLineID");
            _obj.TaxCodeID = GetInt32(reader, "TaxCodeID");
            _obj.TaxExclusiveAmount = GetDouble(reader, "TaxExclusiveAmount");
            _obj.TaxInclusiveAmount = GetDouble(reader, "TaxInclusiveAmount");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(RecurringMoneyReceivedLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["AccountID"] = DbMgr.CreateIntFieldEntry(_obj.AccountID);
            fields["JobID"] = DbMgr.CreateIntFieldEntry(_obj.JobID);
            fields["LineMemo"] = DbMgr.CreateStringFieldEntry(_obj.LineMemo);
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber);
            fields["RecurringMoneyReceivedID"] = DbMgr.CreateIntFieldEntry(_obj.RecurringMoneyReceivedID);
            fields["RecurringMoneyReceivedLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.RecurringMoneyReceivedLineID);
            fields["TaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.TaxCodeID);
            fields["TaxExclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveAmount);
            fields["TaxInclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveAmount);
            return fields;
        }

        protected override object GetDbProperty(RecurringMoneyReceivedLine _obj, string property_name)
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
            else if (property_name.Equals("RecurringMoneyReceived"))
            {
                return RepositoryMgr.RecurringMoneyReceivedMgr.FindById(_obj.RecurringMoneyReceivedID);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectByRecurringMoneyReceivedLineID(int RecurringMoneyReceivedLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringMoneyReceivedLines")
                .Criteria
                    .IsEqual("RecurringMoneyReceivedLines", "RecurringMoneyReceivedLineID", RecurringMoneyReceivedLineID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByRecurringMoneyReceivedID(int RecurringMoneyReceivedID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringMoneyReceivedLines")
                .Criteria
                    .IsEqual("RecurringMoneyReceivedLines", "MoneReceivedID", RecurringMoneyReceivedID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByRecurringMoneyReceivedLineID(int RecurringMoneyReceivedLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("RecurringMoneyReceivedLines")
                .Criteria
                    .IsEqual("RecurringMoneyReceivedLines", "RecurringMoneyReceivedLineID", RecurringMoneyReceivedLineID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringMoneyReceivedLines");
            return clause;
        }

        public bool Exists(int? RecurringMoneyReceivedLineID)
        {
            if (RecurringMoneyReceivedLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByRecurringMoneyReceivedLineID(RecurringMoneyReceivedLineID.Value)) != 0;
        }

        public override bool Exists(RecurringMoneyReceivedLine _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.RecurringMoneyReceivedLineID);
        }

        protected override RecurringMoneyReceivedLine _FindByIntId(int? RecurringMoneyReceivedLineID)
        {
            if (RecurringMoneyReceivedLineID == null) return null;

            RecurringMoneyReceivedLine _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByRecurringMoneyReceivedLineID(RecurringMoneyReceivedLineID.Value));
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

        protected override IList<RecurringMoneyReceivedLine>_FindAllCollection()
        {
            List<RecurringMoneyReceivedLine> _grp=new List<RecurringMoneyReceivedLine>();

            DbCommand _cmd=CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while(_reader.Read())
            {
                RecurringMoneyReceivedLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        public List<RecurringMoneyReceivedLine> List(int? RecurringMoneyReceivedID)
        {
            List<RecurringMoneyReceivedLine> _grp = new List<RecurringMoneyReceivedLine>();

            if (RecurringMoneyReceivedID == null) return _grp;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByRecurringMoneyReceivedID(RecurringMoneyReceivedID.Value));
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringMoneyReceivedLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
