using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Transactions
{
    public abstract class MoneySpentLineManager : EntityManager<MoneySpentLine>
    {
        public MoneySpentLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override MoneySpentLine _CreateDbEntity()
        {
            return new MoneySpentLine(true, this);
        }
        protected override MoneySpentLine _CreateEntity()
        {
            return new MoneySpentLine(false, this);
        }
        #endregion

        protected override void LoadFromReader(MoneySpentLine _obj, DbDataReader reader)
        {
            _obj.AccountID = GetInt32(reader, "AccountID");
            _obj.IsMultipleJob = GetString(reader, "IsMultipleJob");
            _obj.JobID = GetInt32(reader, "JobID");
            _obj.LineMemo = GetString(reader, "LineMemo");
            _obj.LineNumber = GetInt32(reader, "LineNumber");
            _obj.MoneySpentID = GetInt32(reader, "MoneySpentID");
            _obj.MoneySpentLineID = GetInt32(reader, "MoneySpentLineID");
            _obj.TaxCodeID = GetInt32(reader, "TaxCodeID");
            _obj.TaxExclusiveAmount = GetDouble(reader, "TaxExclusiveAmount");
            _obj.TaxInclusiveAmount = GetDouble(reader, "TaxInclusiveAmount");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(MoneySpentLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["AccountID"] = DbMgr.CreateIntFieldEntry(_obj.AccountID);
            fields["IsMultipleJob"] = DbMgr.CreateStringFieldEntry(_obj.IsMultipleJob);
            fields["JobID"] = DbMgr.CreateIntFieldEntry(_obj.JobID);
            fields["LineMemo"] = DbMgr.CreateStringFieldEntry(_obj.LineMemo);
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber);
            fields["MoneySpentID"] = DbMgr.CreateIntFieldEntry(_obj.MoneySpentID);
            fields["MoneySpentLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.MoneySpentLineID);
            fields["TaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.TaxCodeID);
            fields["TaxExclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveAmount);
            fields["TaxInclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveAmount);
            return fields;
        }

        protected override object GetDbProperty(MoneySpentLine _obj, string property_name)
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
            else if (property_name.Equals("MoneySpent"))
            {
                return RepositoryMgr.MoneySpentMgr.FindById(_obj.MoneySpentID);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectByMoneySpentLineID(int MoneySpentLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("MoneySpentLines")
                .Criteria
                    .IsEqual("MoneySpentLines", "MoneySpentLineID", MoneySpentLineID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByMoneySpentID(int MoneySpentID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("MoneySpentLines")
                .Criteria
                    .IsEqual("MoneySpentLines", "MoneSpentID", MoneySpentID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByMoneySpentLineID(int MoneySpentLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("MoneySpentLines")
                .Criteria
                    .IsEqual("MoneySpentLines", "MoneySpentLineID", MoneySpentLineID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("MoneySpentLines");
            return clause;
        }

        public bool Exists(int? MoneySpentLineID)
        {
            if (MoneySpentLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByMoneySpentLineID(MoneySpentLineID.Value)) != 0;
        }

        public override bool Exists(MoneySpentLine _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.MoneySpentLineID);
        }

        protected override MoneySpentLine _FindByIntId(int? MoneySpentLineID)
        {
            if (MoneySpentLineID == null) return null;

            MoneySpentLine _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByMoneySpentLineID(MoneySpentLineID.Value));
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

        protected override IList<MoneySpentLine>_FindAllCollection()
        {
            List<MoneySpentLine> _grp=new List<MoneySpentLine>();

            DbCommand _cmd=CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while(_reader.Read())
            {
                MoneySpentLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        public List<MoneySpentLine> List(int? MoneySpentID)
        {
            List<MoneySpentLine> _grp = new List<MoneySpentLine>();

            if (MoneySpentID == null) return _grp;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByMoneySpentID(MoneySpentID.Value));
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                MoneySpentLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
