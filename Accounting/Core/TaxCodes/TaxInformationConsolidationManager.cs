using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.TaxCodes
{
    public abstract class TaxInformationConsolidationManager : EntityManager<TaxInformationConsolidation>
    {
        public TaxInformationConsolidationManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override TaxInformationConsolidation _CreateDbEntity()
        {
            return new TaxInformationConsolidation(true, this);
        }
        protected override TaxInformationConsolidation _CreateEntity()
        {
            return new TaxInformationConsolidation(false, this);
        }
        #endregion

        protected override void LoadFromReader(TaxInformationConsolidation _obj, DbDataReader reader)
        {
            _obj.ConsolidationTaxCodeID = GetInt32(reader, "ConsolidationTaxCodeID");
            _obj.ElementTaxableAmount = GetDouble(reader, "ElementTaxableAmount");
            _obj.ElementTaxableAmountAUS = GetDouble(reader, "ElementTaxableAmountAUS");
            _obj.ElementTaxAmount = GetDouble(reader, "ElementTaxAmount");
            _obj.ElementTaxAmountAUS = GetDouble(reader, "ElementTaxAmountAUS");
            _obj.ElementTaxBasisAmount = GetDouble(reader, "ElementTaxBasisAmount");
            _obj.ElementTaxBasisAmountAUS = GetDouble(reader, "ElementTaxBasisAmountAUS");
            _obj.ElementTaxCodeID = GetInt32(reader, "ElementTaxCodeID");
            _obj.JournalTypeID = GetString(reader, "JournalTypeID");
            _obj.TaxInformationConsolidationID = GetInt32(reader, "TaxInformationConsolidationID");
            _obj.TransactionID = GetInt32(reader, "TransactionID");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(TaxInformationConsolidation _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["ConsolidationTaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.ConsolidationTaxCodeID); //GetInt32(reader, "ConsolidationTaxCodeID");
            fields["ElementTaxableAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.ElementTaxableAmount); //GetDouble(reader, "ElementTaxableAmount");
            fields["ElementTaxableAmountAUS"] = DbMgr.CreateDoubleFieldEntry(_obj.ElementTaxableAmountAUS); //GetDouble(reader, "ElementTaxableAmountAUS");
            fields["ElementTaxAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.ElementTaxAmount); //GetDouble(reader, "ElementTaxAmount");
            fields["ElementTaxAmountAUS"] = DbMgr.CreateDoubleFieldEntry(_obj.ElementTaxAmountAUS); //GetDouble(reader, "ElementTaxAmountAUS");
            fields["ElementTaxBasisAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.ElementTaxBasisAmount); //GetDouble(reader, "ElementTaxBasisAmount");
            fields["ElementTaxBasisAmountAUS"] = DbMgr.CreateDoubleFieldEntry(_obj.ElementTaxBasisAmountAUS); //GetDouble(reader, "ElementTaxBasisAmountAUS");
            fields["ElementTaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.ElementTaxCodeID); //GetInt32(reader, "ElementTaxCodeID");
            fields["JournalTypeID"] = DbMgr.CreateStringFieldEntry(_obj.JournalTypeID); //GetString(reader, "JournalTypeID");
            fields["TaxInformationConsolidationID"] = DbMgr.CreateAutoIntFieldEntry(_obj.TaxInformationConsolidationID); //GetInt32(reader, "TaxInformationConsolidationID");
            fields["TransactionID"] = DbMgr.CreateIntFieldEntry(_obj.TransactionID); //GetInt32(reader, "TransactionID");

            return fields;
        }

        protected override object GetDbProperty(TaxInformationConsolidation _obj, string property_name)
        {
            if (property_name.Equals("JournalType"))
            {
                return RepositoryMgr.JournalTypeMgr.FindById(_obj.JournalTypeID);
            }
            else if (property_name.Equals("ConsolidationTaxCode"))
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.ConsolidationTaxCodeID);
            }
            else if (property_name.Equals("ElementTaxCode"))
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.ElementTaxCodeID);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("TaxInformationConsolidations");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByTaxInformationConsolidationID(int TaxInformationConsolidationID)
        {
            DbSelectStatement clause=DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("TaxInformationConsolidations")
                .Criteria
                    .IsEqual("TaxInformationConsolidations", "TaxInformationConsolidationID", TaxInformationConsolidationID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByTaxInformationConsolidationID(int TaxInformationConsolidationID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("TaxInformationConsolidations")
                .Criteria
                    .IsEqual("TaxInformationConsolidations", "TaxInformationConsolidationID", TaxInformationConsolidationID);

            return clause;
        }

        public bool Exists(int? TaxInformationConsolidationID)
        {
            if (TaxInformationConsolidationID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByTaxInformationConsolidationID(TaxInformationConsolidationID.Value)) != 0;
        }

        public override bool Exists(TaxInformationConsolidation _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.TaxInformationConsolidationID);
        }

        protected override TaxInformationConsolidation _FindByIntId(int? TaxInformationConsolidationID)
        {
            if (TaxInformationConsolidationID == null) return null;
            TaxInformationConsolidation _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByTaxInformationConsolidationID(TaxInformationConsolidationID.Value));
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

        protected override IList<TaxInformationConsolidation>_FindAllCollection()
        {
            List<TaxInformationConsolidation> _grp = new List<TaxInformationConsolidation>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                TaxInformationConsolidation _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
