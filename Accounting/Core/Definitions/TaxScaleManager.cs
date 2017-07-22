using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class TaxScaleManager : EntityManager<TaxScale>
    {
        public TaxScaleManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override TaxScale _CreateDbEntity()
        {
            return new TaxScale(true, this);
        }
        protected override TaxScale _CreateEntity()
        {
            return new TaxScale(false, this);
        }
        #endregion

        protected override void LoadFromReader(TaxScale _obj, DbDataReader reader)
        {
            _obj.TaxScaleID = GetInt32(reader, "TaxScaleID");
            _obj.Description = GetString(reader, "Description");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(TaxScale _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["TaxScaleID"] = DbMgr.CreateAutoIntFieldEntry(_obj.TaxScaleID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("TaxScales");
        }

        private DbSelectStatement GetQuery_SelectByTaxScaleID(int TaxScaleID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("TaxScales")
                .Criteria
                    .IsEqual("TaxScales", "TaxScaleID", TaxScaleID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByTaxScaleID(int TaxScaleID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("TaxScales")
                .Criteria
                    .IsEqual("TaxScales", "TaxScaleID", TaxScaleID);

            return clause;
        }

        public bool Exists(int? TaxScaleID)
        {
            if (TaxScaleID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByTaxScaleID(TaxScaleID.Value)) != 0;
        }

        public override bool Exists(TaxScale _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.TaxScaleID);
        }

        protected override TaxScale _FindByIntId(int? TaxScaleID)
        {
            TaxScale _obj = null;
            if (TaxScaleID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByTaxScaleID(TaxScaleID.Value));
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

        protected override IList<TaxScale>_FindAllCollection()
        {
            List<TaxScale> _grp = new List<TaxScale>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                TaxScale _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
