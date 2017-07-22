using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.CostCentres
{
    public abstract class CostCentreAccountManager : EntityManager<CostCentreAccount>
    {
        public CostCentreAccountManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override CostCentreAccount _CreateDbEntity()
        {
            return new CostCentreAccount(true, this);
        }
        protected override CostCentreAccount _CreateEntity()
        {
            return new CostCentreAccount(false, this);
        }
        #endregion

        protected override void LoadFromReader(CostCentreAccount _obj, DbDataReader reader)
        {
            _obj.CostCentreAccountID = GetInt32(reader, "CostCentreAccountID");
            _obj.CostCentreID = GetInt32(reader, "CostCentreID");
            _obj.AccountID = GetInt32(reader, "AccountID");
            _obj.CurrentBalance = GetDouble(reader, "CurrentBalance");
            _obj.PreLastYearActivity = GetDouble(reader, "PreLastYearActivity");
            _obj.LastYearOpeningBalance = GetDouble(reader, "LastYearOpeningBalance");
            _obj.ThisYearOpeningBalance = GetDouble(reader, "ThisYearOpeningBalance");
            _obj.PostThisYearActivity = GetDouble(reader, "PostThisYearActivity");
        }

        protected override object GetDbProperty(CostCentreAccount _obj, string property_name)
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

        public override Dictionary<string, DbFieldEntry> GetFields(CostCentreAccount _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["CostCentreAccountID"] = DbMgr.CreateAutoIntFieldEntry(_obj.CostCentreAccountID); //GetInt32(reader, "CostCentreAccountID");
            fields["CostCentreID"] = DbMgr.CreateIntFieldEntry(_obj.CostCentreID); //GetInt32(reader, "CostCentreID");
            fields["AccountID"] = DbMgr.CreateIntFieldEntry(_obj.AccountID); //GetInt32(reader, "AccountID");
            fields["CurrentBalance"] = DbMgr.CreateDoubleFieldEntry(_obj.CurrentBalance); //GetDouble(reader, "CurrentBalance");
            fields["PreLastYearActivity"] = DbMgr.CreateDoubleFieldEntry(_obj.PreLastYearActivity); //GetDouble(reader, "PreLastYearActivity");
            fields["LastYearOpeningBalance"] = DbMgr.CreateDoubleFieldEntry(_obj.LastYearOpeningBalance); //GetDouble(reader, "LastYearOpeningBalance");
            fields["ThisYearOpeningBalance"] = DbMgr.CreateDoubleFieldEntry(_obj.ThisYearOpeningBalance); //GetDouble(reader, "ThisYearOpeningBalance");
            fields["PostThisYearActivity"] = DbMgr.CreateDoubleFieldEntry(_obj.PostThisYearActivity); //GetDouble(reader, "PostThisYearActivity");

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("CostCentreAccounts");
        }

        private DbSelectStatement GetQuery_SelectByCostCentreAccountID(int CostCentreAccountID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("CostCentreAccounts")
                .Criteria
                    .IsEqual("CostCentreAccounts", "CostCentreAccountID", CostCentreAccountID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByCostCentreAccountID(int CostCentreAccountID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("CostCentreAccounts")
                .Criteria
                    .IsEqual("CostCentreAccounts", "CostCentreAccountID", CostCentreAccountID);

            return clause;
        }

        public bool Exists(int? CostCentreAccountID)
        {
            if (CostCentreAccountID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByCostCentreAccountID(CostCentreAccountID.Value)) != 0;
        }

        public override bool Exists(CostCentreAccount _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.CostCentreAccountID);
        }

        protected override CostCentreAccount _FindByIntId(int? CostCentreAccountID)
        {
            if (CostCentreAccountID == null) return null;

            CostCentreAccount _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByCostCentreAccountID(CostCentreAccountID.Value));
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

        protected override IList<CostCentreAccount>_FindAllCollection()
        {
            List<CostCentreAccount> _grp = new List<CostCentreAccount>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                CostCentreAccount _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
