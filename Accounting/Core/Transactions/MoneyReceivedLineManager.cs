using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Transactions
{
    public abstract class MoneyReceivedLineManager : EntityManager<MoneyReceivedLine>
    {
        public MoneyReceivedLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override MoneyReceivedLine _CreateDbEntity()
        {
            return new MoneyReceivedLine(true, this);
        }
        protected override MoneyReceivedLine _CreateEntity()
        {
            return new MoneyReceivedLine(false, this);
        }
        #endregion

        protected override void LoadFromReader(MoneyReceivedLine _obj, DbDataReader reader)
        {
            _obj.AccountID = GetInt32(reader, "AccountID");
            _obj.IsMultipleJob = GetString(reader, "IsMultipleJob");
            _obj.JobID = GetInt32(reader, "JobID");
            _obj.LineMemo = GetString(reader, "LineMemo");
            _obj.LineNumber = GetInt32(reader, "LineNumber");
            _obj.MoneyReceivedID = GetInt32(reader, "MoneyReceivedID");
            _obj.MoneyReceivedLineID = GetInt32(reader, "MoneyReceivedLineID");
            _obj.TaxCodeID = GetInt32(reader, "TaxCodeID");
            _obj.TaxExclusiveAmount = GetDouble(reader, "TaxExclusiveAmount");
            _obj.TaxInclusiveAmount = GetDouble(reader, "TaxInclusiveAmount");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(MoneyReceivedLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["AccountID"] = DbMgr.CreateIntFieldEntry(_obj.AccountID);
            fields["IsMultipleJob"] = DbMgr.CreateStringFieldEntry(_obj.IsMultipleJob);
            fields["JobID"] = DbMgr.CreateIntFieldEntry(_obj.JobID);
            fields["LineMemo"] = DbMgr.CreateStringFieldEntry(_obj.LineMemo);
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber);
            fields["MoneyReceivedID"] = DbMgr.CreateIntFieldEntry(_obj.MoneyReceivedID);
            fields["MoneyReceivedLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.MoneyReceivedLineID);
            fields["TaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.TaxCodeID);
            fields["TaxExclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveAmount);
            fields["TaxInclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveAmount);
            return fields;
        }

        protected override object GetDbProperty(MoneyReceivedLine _obj, string property_name)
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
            else if (property_name.Equals("MoneyReceived"))
            {
                return RepositoryMgr.MoneyReceivedMgr.FindById(_obj.MoneyReceivedID);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectByMoneyReceivedLineID(int MoneyReceivedLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("MoneyReceivedLines")
                .Criteria
                    .IsEqual("MoneyReceivedLines", "MoneyReceivedLineID", MoneyReceivedLineID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByMoneyReceivedID(int MoneyReceivedID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("MoneyReceivedLines")
                .Criteria
                    .IsEqual("MoneyReceivedLines", "MoneReceivedID", MoneyReceivedID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByMoneyReceivedLineID(int MoneyReceivedLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("MoneyReceivedLines")
                .Criteria
                    .IsEqual("MoneyReceivedLines", "MoneyReceivedLineID", MoneyReceivedLineID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("MoneyReceivedLines");
            return clause;
        }

        public bool Exists(int? MoneyReceivedLineID)
        {
            if (MoneyReceivedLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByMoneyReceivedLineID(MoneyReceivedLineID.Value)) != 0;
        }

        public override bool Exists(MoneyReceivedLine _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.MoneyReceivedLineID);
        }

        protected override MoneyReceivedLine _FindByIntId(int? MoneyReceivedLineID)
        {
            if (MoneyReceivedLineID == null) return null;

            MoneyReceivedLine _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByMoneyReceivedLineID(MoneyReceivedLineID.Value));
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

        protected override IList<MoneyReceivedLine>_FindAllCollection()
        {
            List<MoneyReceivedLine> _grp=new List<MoneyReceivedLine>();

            DbCommand _cmd=CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while(_reader.Read())
            {
                MoneyReceivedLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        public List<MoneyReceivedLine> List(int? MoneyReceivedID)
        {
            List<MoneyReceivedLine> _grp = new List<MoneyReceivedLine>();

            if (MoneyReceivedID == null) return _grp;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByMoneyReceivedID(MoneyReceivedID.Value));
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                MoneyReceivedLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
