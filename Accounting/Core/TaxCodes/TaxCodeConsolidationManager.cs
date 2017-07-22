using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.TaxCodes
{
    public abstract class TaxCodeConsolidationManager : EntityManager<TaxCodeConsolidation>
    {
        public TaxCodeConsolidationManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override TaxCodeConsolidation _CreateDbEntity()
        {
            return new TaxCodeConsolidation(true, this);
        }
        protected override TaxCodeConsolidation _CreateEntity()
        {
            return new TaxCodeConsolidation(false, this);
        }
        #endregion

        protected override void LoadFromReader(TaxCodeConsolidation _obj, DbDataReader reader)
        {
            _obj.ConsolidatedTaxCodeID = GetInt32(reader, "ConsolidatedTaxCodeID");
            _obj.ElementTaxCodeID = GetInt32(reader, "ElementTaxCodeID");
            _obj.TaxCodeConsolidationID = GetInt32(reader, "TaxCodeConsolidationID");
        }

        protected override object GetDbProperty(TaxCodeConsolidation _obj, string property_name)
        {
            if (property_name.Equals("ElementTaxCode"))
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.ElementTaxCodeID);
            }
            else if (property_name.Equals("ConsolidatedTaxCode"))
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.ConsolidatedTaxCodeID);
            }
            return null;
        }

        public override Dictionary<string, DbFieldEntry> GetFields(TaxCodeConsolidation _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["TaxCodeConsolidationID"] = DbMgr.CreateAutoIntFieldEntry(_obj.TaxCodeConsolidationID);
            fields["ConsolidatedTaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.ConsolidatedTaxCodeID);
            fields["ElementTaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.ElementTaxCodeID);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("TaxCodeConsolidations");
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByTaxCodeConsolidationID(int TaxCodeConsolidationID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("TaxCodeConsolidations")
                .Criteria
                    .IsEqual("TaxCodeConsolidations", "TaxCodeConsolidationID", TaxCodeConsolidationID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByTaxCodeConsolidationID(int TaxCodeConsolidationID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("TaxCodeConsolidations")
                .Criteria
                    .IsEqual("TaxCodeConsolidations", "TaxCodeConsolidationID", TaxCodeConsolidationID);

            return clause;
        }

        public bool Exists(int? TaxCodeConsolidationID)
        {
            if (TaxCodeConsolidationID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByTaxCodeConsolidationID(TaxCodeConsolidationID.Value)) != 0;
        }

        public override bool Exists(TaxCodeConsolidation _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.TaxCodeConsolidationID);
        }

        protected override TaxCodeConsolidation _FindByIntId(int? TaxCodeConsolidationID)
        {
            if (TaxCodeConsolidationID == null) return null;
            TaxCodeConsolidation _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByTaxCodeConsolidationID(TaxCodeConsolidationID.Value));
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

        protected override IList<TaxCodeConsolidation>_FindAllCollection()
        {
            List<TaxCodeConsolidation> _grp = new List<TaxCodeConsolidation>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                TaxCodeConsolidation _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
