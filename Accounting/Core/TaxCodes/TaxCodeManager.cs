using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.TaxCodes
{
    public abstract class TaxCodeManager : EntityManager<TaxCode>
    {
        public TaxCodeManager(DbManager mgr)
            : base(mgr)
        {

        }

        #region +(Factory Methods)
        protected override TaxCode _CreateDbEntity()
        {
            return new TaxCode(true, this);
        }

        protected override TaxCode _CreateEntity()
        {
            return new TaxCode(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(TaxCode _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["TaxCodeID"] = DbMgr.CreateAutoIntFieldEntry(_obj.TaxCodeID);
            fields["TaxCode"] = DbMgr.CreateStringFieldEntry(_obj.Code);
            fields["TaxCodeDescription"] = DbMgr.CreateStringFieldEntry(_obj.TaxCodeDescription);
            fields["TaxPercentageRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxPercentageRate);
            fields["TaxCodeTypeID"] = DbMgr.CreateStringFieldEntry(_obj.TaxCodeTypeID);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectByTaxCodeID(int TaxCodeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("TaxCodes")
                .Criteria
                    .IsEqual("TaxCodes", "TaxCodeID", TaxCodeID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
             DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("TaxCodes");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByTaxCode(string TaxCode)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("TaxCodes")
                .Criteria
                    .IsEqual("TaxCodes", "TaxCode", TaxCode);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByTaxCodeID(int TaxCodeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("TaxCodes")
                .Criteria
                    .IsEqual("TaxCodes", "TaxCodeID", TaxCodeID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByTaxCode(string _TaxCode)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("TaxCodes")
                .Criteria
                    .IsEqual("TaxCodes", "TaxCode", _TaxCode);

            return clause;
        }

        private bool Exists(int? TaxCodeID)
        {
            if (TaxCodeID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectByTaxCodeID(TaxCodeID.Value)) != 0;
        }

        private bool Exists(string _TaxCode)
        {
            return ExecuteScalarInt(GetQuery_SelectByTaxCode(_TaxCode)) != 0;
        }

        public override bool Exists(TaxCode _tax)
        {
            return Exists(_tax.TaxCodeID);
        }

        public List<string> SalesTaxCalcBasisList
        {
            get
            {
                DbSelectStatement clause = DbMgr.CreateSelectClause();
                clause
                    .SelectColumn("PriceLevels", "Description")
                    .From("PriceLevels");

                string query=clause.ToString();
                List<string> result = new List<string>();
                DbCommand _cmd = CreateDbCommand(clause);
                DbDataReader _reader = _cmd.ExecuteReader();
                while (_reader.Read())
                {
                    result.Add(_reader.GetString(0));
                }

                _reader.Close();
                _cmd.Dispose();

                return result;
            }
        }

        public string GetSalesTaxCalcBasis(string SalesTaxCalcBasisID)
        {
            string SalesTaxCalcBasis = "";

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                    .SelectColumn("PriceLevels", "Description")
                    .From("PriceLevels")
                    .Criteria
                        .IsEqual("PriceLevels", "PriceLevelID", SalesTaxCalcBasisID);
            
            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            if (_reader.Read())
            {
                SalesTaxCalcBasis=GetString(_reader, ("Description"));   
            }
            _reader.Close();
            _cmd.Dispose();

            return SalesTaxCalcBasis;
        }

        protected override void LoadFromReader(TaxCode _obj, DbDataReader _reader)
        {
            _obj.TaxCodeID =GetInt32(_reader, ("TaxCodeID"));
            _obj.Code=GetString(_reader, ("TaxCode"));
            _obj.TaxCodeDescription =GetString(_reader, ("TaxCodeDescription"));
            _obj.TaxPercentageRate = GetDouble(_reader, ("TaxPercentageRate"));
            _obj.TaxCodeTypeID =GetString(_reader, ("TaxCodeTypeID"));
        }

        protected override IList<TaxCode>_FindAllCollection()
        {
            List<TaxCode> codes = new List<TaxCode>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                TaxCode _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                
                codes.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return codes;
        }

        public DataTable Table()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectColumn("TaxCodes", "TaxCode")
                .SelectColumn("TaxCodes", "TaxCodeDescription")
                .SelectColumn("TaxCodes", "TaxPercentageRate")
                .From("TaxCodes");

            DataTable table = new DataTable();
            table.Columns.Add("Tax Code");
            table.Columns.Add("Description");
            table.Columns.Add("Percentage Rate");

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while(_reader.Read())
            {
                DataRow row = table.NewRow();
                row["Tax Code"] = GetString(_reader, "TaxCode");
                row["Description"] = GetString(_reader, "TaxCodeDescription");
                row["Percentage Rate"] = GetDouble(_reader, "TaxPercentageRate");
                table.Rows.Add(row);
            }
            _reader.Close();
            _cmd.Dispose();

            return table;
        }

        protected override TaxCode _FindByIntId(int? TaxCodeID)
        {
            if (Exists(TaxCodeID))
            {
                TaxCode _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByTaxCodeID(TaxCodeID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override TaxCode _FindByTextId(string _TaxCode)
        {
            if (Exists(_TaxCode))
            {
                TaxCode _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByTaxCode(_TaxCode));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        public int? GetTaxTypeFromTaxCodeTypeID(string TaxCodeTypeID)
        {
            int? ImportTaxType = 0;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectColumn("TaxCodeTypes", "ImportTaxType")
                .From("TaxCodeTypes")
                .Criteria
                    .IsEqual("TaxCodeTypes", "TaxCodeTypeID", TaxCodeTypeID);
           
            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            if (_reader.Read())
            {
                ImportTaxType =GetInt32(_reader, ("ImportTaxType"));
            }

            _reader.Close();
            _cmd.Dispose();

            return ImportTaxType;
        }

        public bool IsTaxCodeTypeConsolidated(string TaxCodeTypeID)
        {
            return TaxCodeTypeID == "C";
        }

        public List<string> TaxCodeTypeIDList
        {
            get
            {
                List<string> TaxCodeTypeIDs = new List<string>();

                DbSelectStatement clause = DbMgr.CreateSelectClause();
                clause
                    .SelectColumn("TaxCodeTypes", "TaxCodeTypeID")
                    .From("TaxCodeTypes");

                DbCommand _cmd = CreateDbCommand(clause);
                DbDataReader _reader = _cmd.ExecuteReader();

                while (_reader.Read())
                {
                    TaxCodeTypeIDs.Add(GetString(_reader, ("TaxCodeTypeID")));
                }

                _reader.Close();
                _cmd.Dispose();

                return TaxCodeTypeIDs;
            }
        }

        
    }
}
