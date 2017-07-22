using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.CostCentres
{
    public abstract class CostCentreAccountActivityManager : EntityManager<CostCentreAccountActivity>
    {
        public CostCentreAccountActivityManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override CostCentreAccountActivity _CreateDbEntity()
        {
            return new CostCentreAccountActivity(true, this);
        }
        protected override CostCentreAccountActivity _CreateEntity()
        {
            return new CostCentreAccountActivity(false, this);
        }
        #endregion

        protected override void LoadFromReader(CostCentreAccountActivity _obj, DbDataReader reader)
        {
            _obj.CostCentreAccountActivityID = GetInt32(reader, "CostCentreAccountActivityID");
            _obj.CostCentreID = GetInt32(reader, "CostCentreID");
            _obj.AccountID = GetInt32(reader, "AccountID");
            _obj.FinancialYear = GetInt32(reader, "FinancialYear");
            _obj.Period = GetInt32(reader, "Period");
            _obj.Amount = GetDouble(reader, "Amount");
        }

        protected override object GetDbProperty(CostCentreAccountActivity _obj, string property_name)
        {
            if (property_name.Equals("Account"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.AccountID);
            }
            else if (property_name.Equals("CostCentre"))
            {
                return RepositoryMgr.CostCentreMgr.FindById(_obj.CostCentreID);
            }
            return null;
        }

        public override Dictionary<string, DbFieldEntry> GetFields(CostCentreAccountActivity _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["CostCentreAccountActivityID"] = DbMgr.CreateAutoIntFieldEntry(_obj.CostCentreAccountActivityID); //GetInt32(reader, "CostCentreAccountActivityID");
            fields["CostCentreID"] = DbMgr.CreateIntFieldEntry(_obj.CostCentreID); //GetInt32(reader, "CostCentreID");
            fields["AccountID"] = DbMgr.CreateIntFieldEntry(_obj.AccountID); //GetInt32(reader, "AccountID");
            fields["FinancialYear"] = DbMgr.CreateIntFieldEntry(_obj.FinancialYear); //GetInt32(reader, "FinancialYear");
            fields["Period"] = DbMgr.CreateIntFieldEntry(_obj.Period); //GetInt32(reader, "Period");
            fields["Amount"] = DbMgr.CreateDoubleFieldEntry(_obj.Amount); //GetDouble(reader, "Amount");

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("CostCentreAccountActivities");
        }

        private DbSelectStatement GetQuery_SelectByCostCentreAccountActivityID(int CostCentreAccountActivityID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("CostCentreAccountActivities")
                .Criteria
                    .IsEqual("CostCentreAccountActivities", "CostCentreAccountActivityID", CostCentreAccountActivityID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByCostCentreAccountActivityID(int CostCentreAccountActivityID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("CostCentreAccountActivities")
                .Criteria
                    .IsEqual("CostCentreAccountActivities", "CostCentreAccountActivityID", CostCentreAccountActivityID);

            return clause;
        }

        public bool Exists(int? CostCentreAccountActivityID)
        {
            if (CostCentreAccountActivityID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByCostCentreAccountActivityID(CostCentreAccountActivityID.Value)) != 0;
        }

        public override bool Exists(CostCentreAccountActivity _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.CostCentreAccountActivityID);
        }

        protected override CostCentreAccountActivity _FindByIntId(int? CostCentreAccountActivityID)
        {
            if (CostCentreAccountActivityID == null) return null;

            CostCentreAccountActivity _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByCostCentreAccountActivityID(CostCentreAccountActivityID.Value));
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

        protected override IList<CostCentreAccountActivity>_FindAllCollection()
        {
            List<CostCentreAccountActivity> _grp = new List<CostCentreAccountActivity>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                CostCentreAccountActivity _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
