using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.CostCentres
{
    public abstract class CostCentreManager : EntityManager<CostCentre>
    {
        public CostCentreManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override CostCentre _CreateDbEntity()
        {
            return new CostCentre(true, this);
        }
        protected override CostCentre _CreateEntity()
        {
            return new CostCentre(false, this);
        }
        #endregion

        protected override void LoadFromReader(CostCentre _obj, DbDataReader reader)
        {
            _obj.CostCentreDescription = GetString(reader, "CostCentreDescription");
            _obj.CostCentreID = GetInt32(reader, "CostCentreID");
            _obj.CostCentreIdentification = GetString(reader, "CostCentreIdentification");
            _obj.CostCentreName = GetString(reader, "CostCentreName");
            _obj.IsInactive = GetString(reader, "IsInactive");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(CostCentre _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["CostCentreDescription"] = DbMgr.CreateStringFieldEntry(_obj.CostCentreDescription); //GetString(reader, "CostCentreDescription");
            fields["CostCentreID"] = DbMgr.CreateAutoIntFieldEntry(_obj.CostCentreID); //GetInt32(reader, "CostCentreID");
            fields["CostCentreIdentification"] = DbMgr.CreateStringFieldEntry(_obj.CostCentreIdentification); //GetString(reader, "CostCentreIdentification");
            fields["CostCentreName"] = DbMgr.CreateStringFieldEntry(_obj.CostCentreName); //GetString(reader, "CostCentreName");
            fields["IsInactive"] = DbMgr.CreateStringFieldEntry(_obj.IsInactive); //GetString(reader, "IsInactive");

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("CostCentres");
        }

        private DbSelectStatement GetQuery_SelectByCostCentreID(int CostCentreID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("CostCentres")
                .Criteria
                    .IsEqual("CostCentres", "CostCentreID", CostCentreID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByCostCentreID(int CostCentreID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("CostCentres")
                .Criteria
                    .IsEqual("CostCentres", "CostCentreID", CostCentreID);

            return clause;
        }

        public bool Exists(int? CostCentreID)
        {
            if (CostCentreID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByCostCentreID(CostCentreID.Value)) != 0;
        }

        public override bool Exists(CostCentre _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.CostCentreID);
        }

        protected override CostCentre _FindByIntId(int? CostCentreID)
        {
            if (CostCentreID == null) return null;

            CostCentre _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByCostCentreID(CostCentreID.Value));
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

        protected override IList<CostCentre>_FindAllCollection()
        {
            List<CostCentre> _grp = new List<CostCentre>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                CostCentre _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
