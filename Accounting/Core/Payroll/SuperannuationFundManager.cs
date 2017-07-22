using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Payroll
{
    public abstract class SuperannuationFundManager : EntityManager<SuperannuationFund>
    {
        public SuperannuationFundManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override SuperannuationFund _CreateDbEntity()
        {
            return new SuperannuationFund(true, this);
        }
        protected override SuperannuationFund _CreateEntity()
        {
            return new SuperannuationFund(false, this);
        }
        #endregion

        protected override void LoadFromReader(SuperannuationFund _obj, DbDataReader reader)
        {
            _obj.EmployerMembershipNumber = GetString(reader, "EmployerMembershipNumber");
            _obj.IsPaid = GetString(reader, "IsPaid");
            _obj.SuperannuationFundID = GetInt32(reader, "SuperannuationFundID");
            _obj.SuperannuationFundName = GetString(reader, "SuperannuationFundName");
            _obj.SuperannuationFundNumber = GetString(reader, "SuperannuationFundNumber");
            _obj.SuperannuationFundToPay = GetString(reader, "SuperannuationFundToPay");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(SuperannuationFund _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["EmployerMembershipNumber"] = DbMgr.CreateStringFieldEntry(_obj.EmployerMembershipNumber); //GetString(reader, "");
            fields["IsPaid"] = DbMgr.CreateStringFieldEntry(_obj.IsPaid); //GetString(reader, "");
            fields["SuperannuationFundID"] = DbMgr.CreateAutoIntFieldEntry(_obj.SuperannuationFundID); //GetInt32(reader, "");
            fields["SuperannuationFundName"] = DbMgr.CreateStringFieldEntry(_obj.SuperannuationFundName); //GetString(reader, "");
            fields["SuperannuationFundNumber"] = DbMgr.CreateStringFieldEntry(_obj.SuperannuationFundNumber); //GetString(reader, "");
            fields["SuperannuationFundToPay"] = DbMgr.CreateStringFieldEntry(_obj.SuperannuationFundToPay); //GetString(reader, "");

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("SuperannuationFunds");
        }

        private DbSelectStatement GetQuery_SelectBySuperannuationFundID(int SuperannuationFundID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("SuperannuationFunds")
                .Criteria
                    .IsEqual("SuperannuationFunds", "SuperannuationFundID", SuperannuationFundID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountBySuperannuationFundID(int SuperannuationFundID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("SuperannuationFunds")
                .Criteria
                    .IsEqual("SuperannuationFunds", "SuperannuationFundID", SuperannuationFundID);

            return clause;
        }

        public bool Exists(int? SuperannuationFundID)
        {
            if (SuperannuationFundID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountBySuperannuationFundID(SuperannuationFundID.Value)) != 0;
        }

        public override bool Exists(SuperannuationFund _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.SuperannuationFundID);
        }

        protected override SuperannuationFund _FindByIntId(int? SuperannuationFundID)
        {
            if (SuperannuationFundID == null) return null;
            SuperannuationFund _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectBySuperannuationFundID(SuperannuationFundID.Value));
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

        protected override IList<SuperannuationFund>_FindAllCollection()
        {
            List<SuperannuationFund> _grp = new List<SuperannuationFund>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                SuperannuationFund _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
