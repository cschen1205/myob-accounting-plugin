using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.TaxCodes
{
    public abstract class TaxInformationManager : EntityManager<TaxInformation>
    {
        public TaxInformationManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override TaxInformation _CreateDbEntity()
        {
            return new TaxInformation(true, this);
        }
        protected override TaxInformation _CreateEntity()
        {
            return new TaxInformation(false, this);
        }
        #endregion

        protected override void LoadFromReader(TaxInformation _obj, DbDataReader reader)
        {
            _obj.JournalTypeID = GetString(reader, "JournalTypeID");
            _obj.ReportTaxAsID = GetString(reader, "ReportTaxAsID");
            _obj.TaxableAmount = GetDouble(reader, "TaxableAmount");
            _obj.TaxAmount = GetDouble(reader, "TaxAmount");
            _obj.TaxAmountAUS = GetDouble(reader, "TaxAmountAUS");
            _obj.TaxAmountIsChanged = GetString(reader, "TaxAmountIsChanged");
            _obj.TaxBasisAmount = GetDouble(reader, "TaxBasisAmount");
            _obj.TaxBasisAmountAUS = GetDouble(reader, "TaxBasisAmountAUS");
            _obj.TaxCodeID = GetInt32(reader, "TaxCodeID");
            _obj.TaxInformationID = GetInt32(reader, "TaxInformationID");
            _obj.TaxPercentageRate = GetDouble(reader, "TaxPercentageRate");
            _obj.TransactionID = GetInt32(reader, "TransactionID");
           
        }

        public override Dictionary<string, DbFieldEntry> GetFields(TaxInformation _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["JournalTypeID"] = DbMgr.CreateStringFieldEntry(_obj.JournalTypeID); 
            fields["ReportTaxAsID"] = DbMgr.CreateStringFieldEntry(_obj.ReportTaxAsID); 
            fields["TaxableAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxableAmount); 
            fields["TaxAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxAmount); 
            fields["TaxAmountAUS"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxAmountAUS); 
            fields["TaxAmountIsChanged"] = DbMgr.CreateStringFieldEntry(_obj.TaxAmountIsChanged); 
            fields["TaxBasisAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxBasisAmount); 
            fields["TaxBasisAmountAUS"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxBasisAmountAUS); 
            fields["TaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.TaxCodeID); 
            fields["TaxInformationID"] = DbMgr.CreateAutoIntFieldEntry(_obj.TaxInformationID); 
            fields["TaxPercentageRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxPercentageRate); 
            fields["TransactionID"] = DbMgr.CreateIntFieldEntry(_obj.TransactionID); 
           

            return fields;
        }

        protected override object GetDbProperty(TaxInformation _obj, string property_name)
        {
            if (property_name.Equals("TaxCode"))
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.TaxCodeID);
            }
            else if (property_name.Equals("JournalType"))
            {
                return RepositoryMgr.JournalTypeMgr.FindById(_obj.JournalTypeID);
            }
            else if (property_name.Equals("ReportTaxAs"))
            {
                return RepositoryMgr.ReportingMethodMgr.FindById(_obj.ReportTaxAsID);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause.SelectAll().From("TaxInformation");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByTaxInformationID(int TaxInformationID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("TaxInformation")
                .Criteria
                    .IsEqual("TaxInformation", "TaxInformationID", TaxInformationID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByTaxInformationID(int TaxInformationID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("TaxInformation")
                .Criteria
                    .IsEqual("TaxInformation", "TaxInformationID", TaxInformationID);

            return clause;
        }

        public bool Exists(int? TaxInformationID)
        {
            if (TaxInformationID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByTaxInformationID(TaxInformationID.Value)) != 0;
        }

        public override bool Exists(TaxInformation _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.TaxInformationID);
        }

        protected override TaxInformation _FindByIntId(int? TaxInformationID)
        {
            if (TaxInformationID == null) return null;
            TaxInformation _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByTaxInformationID(TaxInformationID.Value));
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

        protected override IList<TaxInformation>_FindAllCollection()
        {
            List<TaxInformation> _grp = new List<TaxInformation>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                TaxInformation _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
