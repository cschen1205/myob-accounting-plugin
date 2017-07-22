using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
using System.Data;
using System.Data.Common;
using System.Collections;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Currencies
{
    public abstract class CurrencyManager : EntityManager<Currency>
    {
        public CurrencyManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override Currency _CreateDbEntity()
        {
            return new Currency(true, this);
        }

        protected override Currency _CreateEntity()
        {
            return new Currency(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(Currency _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["CurrencyID"] = DbMgr.CreateAutoIntFieldEntry(_obj.CurrencyID);
            fields["CurrencyName"] = DbMgr.CreateStringFieldEntry(_obj.CurrencyName);
            fields["CurrencyCode"] = DbMgr.CreateStringFieldEntry(_obj.CurrencyCode);
            fields["ExchangeRate"] = DbMgr.CreateDoubleFieldEntry(_obj.ExchangeRate);
            fields["CurrencySymbol"] = DbMgr.CreateStringFieldEntry(_obj.CurrencySymbol);
            fields["DigitGroupingSymbol"] = DbMgr.CreateStringFieldEntry(_obj.DigitGroupingSymbol);
            fields["DecimalPlaces"] = DbMgr.CreateIntFieldEntry(_obj.DecimalPlaces);
            fields["NumberDigitsInGroup"] = DbMgr.CreateIntFieldEntry(_obj.NumberDigitsInGroup);
            fields["DecimalPlaceSymbol"] = DbMgr.CreateStringFieldEntry(_obj.DecimalPlaceSymbol);
            fields["NegativeFormat"] = DbMgr.CreateStringFieldEntry(_obj.NegativeFormat);
            fields["UseLeadingZero"] = DbMgr.CreateStringFieldEntry(_obj.UseLeadingZero);
            fields["SymbolPosition"] = DbMgr.CreateStringFieldEntry(_obj.SymbolPosition);

            return fields;
        }


        private Currency mDefaultCurrency = null;

        public Currency DefaultCurrency
        {
            get
            {
                if (mDefaultCurrency == null)
                {
                    mDefaultCurrency = CreateEntity();
                }
                return mDefaultCurrency;
            }
        }

        public string Format(double amount)
        {
            return DefaultCurrency.Format(amount);
        }

        public string FormatPercent(double percent)
        {
            return DefaultCurrency.FormatPercent(percent);
        }

        private DbSelectStatement GetQuery_SelectByCurrencyCode(string CurrencyCode)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Currency")
                .Criteria.IsEqual("Currency", "CurrencyCode", CurrencyCode);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByCurrencyID(int CurrencyID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Currency")
                .Criteria.IsEqual("Currency", "CurrencyID", CurrencyID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByCurrencyCode(string CurrencyCode)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("Currency")
                .Criteria.IsEqual("Currency", "CurrencyCode", CurrencyCode);

            return clause;
        }

        public DbSelectStatement GetQuery_SelectCount()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("Currency");
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByCurrencyID(int CurrencyID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("Currency")
                .Criteria.IsEqual("Currency", "CurrencyID", CurrencyID);
            return clause;
        }

        public bool SupportMultiCurrency
        {
            get
            {
                return ExecuteScalarInt(GetQuery_SelectCount()) != 0;
            }
        }

        public DataTable Table()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectColumn("Currency", "CurrencyID", "ID")
                .SelectColumn("Currency", "CurrencyCode", "Code")
                .SelectColumn("Currency", "ExchangeRate", "ExchangeRate")
                .From("Currency");
            

           
            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Code");
            table.Columns.Add("Exchange Rate");

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                DataRow row = table.NewRow();
                row["ID"] = GetInt32(_reader, "ID");
                row["Code"] = GetString(_reader, "Code");
                row["Exchange Rate"] = GetDouble(_reader, "ExchangeRate");
                table.Rows.Add(row);
            }

            return table;
        }

        private bool Exists(int? CurrencyID)
        {
            if (CurrencyID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectByCurrencyID(CurrencyID.Value)) != 0;
        }

        private bool Exists(string CurrencyCode)
        {
            return ExecuteScalarInt(GetQuery_SelectByCurrencyCode(CurrencyCode)) != 0;
        }

        public override bool Exists(Currency _obj)
        {
            return Exists(_obj.CurrencyID);
        }

        protected override IList<Currency>_FindAllCollection()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Currency");

            

            List<Currency> currencys = new List<Currency>();
            if (SupportMultiCurrency)
            {
                DbCommand _cmd = CreateDbCommand(clause);
                DbDataReader _reader = _cmd.ExecuteReader();
                while (_reader.Read())
                {
                    Currency _obj = CreateDbEntity();
                    LoadFromReader(_obj, _reader);
                    currencys.Add(_obj);
                }
                _reader.Close();
                _cmd.Dispose();
            }
            else
            {
                currencys.Add(DefaultCurrency);
            }

            return currencys;
        }

        protected override void LoadFromReader(Currency _obj, DbDataReader reader)
        {
            _obj.CurrencyID =GetInt32(reader, ("CurrencyID")); 
            _obj.CurrencyName =GetString(reader, ("CurrencyName")); 
             _obj.CurrencyCode=GetString(reader, ("CurrencyCode"));
            _obj.ExchangeRate= GetDouble(reader, ("ExchangeRate"));
            _obj.CurrencySymbol=GetString(reader, ("CurrencySymbol"));
            _obj.DigitGroupingSymbol=GetString(reader, ("DigitGroupingSymbol")); 
            _obj.DecimalPlaces=GetInt32(reader, ("DecimalPlaces"));
            _obj.NumberDigitsInGroup=GetInt32(reader, ("NumberDigitsInGroup"));
            _obj.DecimalPlaceSymbol=GetString(reader, ("DecimalPlaceSymbol"));
            _obj.NegativeFormat=GetString(reader, ("NegativeFormat"));
            _obj.UseLeadingZero=GetString(reader, ("UseLeadingZero"));
            _obj.SymbolPosition= GetString(reader, ("SymbolPosition"));
        }

        protected override Currency _FindByIntId(int? CurrencyID)
        {
            if (Exists(CurrencyID))
            {
                Currency _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByCurrencyID(CurrencyID.Value));
                return _obj;
            }
            else
            {
                return DefaultCurrency;
            }
        }

        protected override Currency _FindByTextId(string CurrencyCode)
        {
            if (Exists(CurrencyCode))
            {
                Currency _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByCurrencyCode(CurrencyCode));
                return _obj;
            }
            else
            {
                return DefaultCurrency;
            }
        }
    }
}
