using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Purchases
{
    public abstract class SupplierFinanceChargeManager : EntityManager<SupplierFinanceCharge>
    {
        public SupplierFinanceChargeManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override SupplierFinanceCharge _CreateDbEntity()
        {
            return new SupplierFinanceCharge(true, this);
        }
        protected override SupplierFinanceCharge _CreateEntity()
        {
            return new SupplierFinanceCharge(false, this);
        }
        #endregion

        protected override void LoadFromReader(SupplierFinanceCharge _obj, DbDataReader reader)
        {
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.CurrencyID = GetInt32(reader, "CurrencyID");
            _obj.SupplierFinanceChargeID = GetInt32(reader, "SupplierFinanceChargeID");
            _obj.SupplierFinanceChargeNumber = GetString(reader, "SupplierFinanceChargeNumber");
            _obj.TransactionDate = GetDateTime(reader, "TransactionDate");
            _obj.Date = _obj.TransactionDate;
            _obj.ExchangeGainLoss = GetDouble(reader, "ExchangeGainLoss");
            _obj.IsTaxInclusive = GetString(reader, "IsTaxInclusive");
            _obj.IsThirteenthPeriod = GetString(reader, "IsThirteenthPeriod");
            _obj.Memo = GetString(reader, "Memo");
            _obj.LateChargesAccountID = GetInt32(reader, "LateChargesAccountID");
            _obj.FinanceCharge = GetDouble(reader, "FinanceCharge");
            _obj.TransactionExchangeRate = GetDouble(reader, "TransactionExchangeRate");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(SupplierFinanceCharge _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["SupplierFinanceChargeID"] = DbMgr.CreateAutoIntFieldEntry(_obj.SupplierFinanceChargeID);
            fields["SupplierFinanceChargeNumber"] = DbMgr.CreateStringFieldEntry(_obj.SupplierFinanceChargeNumber);
            fields["TransactionDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.TransactionDate);
            fields["Date"] = DbMgr.CreateDateTimeFieldEntry(_obj.Date);
            fields["ExchangeGainLoss"] = DbMgr.CreateDoubleFieldEntry(_obj.ExchangeGainLoss);
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive);
            fields["IsThirteenthPeriod"] = DbMgr.CreateStringFieldEntry(_obj.IsThirteenthPeriod);
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo);
            fields["LateChargesAccountID"] = DbMgr.CreateIntFieldEntry(_obj.LateChargesAccountID);
            fields["FinanceCharge"] = DbMgr.CreateDoubleFieldEntry(_obj.FinanceCharge);
            fields["TransactionExchangeRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TransactionExchangeRate); 

            return fields;
        }

        protected override object GetDbProperty(SupplierFinanceCharge _obj, string property_name)
        {
            if (property_name.Equals("Currency"))
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name.Equals("Card"))
            {
                return RepositoryMgr.CardMgr.FindByCardId(_obj.CardRecordID, true);
            }
            else if (property_name.Equals("LateChargesAccount"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.LateChargesAccountID);
            }
            
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll().From("SupplierFinanceCharges");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectBySupplierFinanceChargeID(int? SupplierFinanceChargeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("SupplierFinanceCharges")
                .Criteria
                    .IsEqual("SupplierFinanceCharges", "SupplierFinanceChargeID", SupplierFinanceChargeID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountBySupplierFinanceChargeID(int? SupplierFinanceChargeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("SupplierFinanceCharges")
                .Criteria
                    .IsEqual("SupplierFinanceCharges", "SupplierFinanceChargeID", SupplierFinanceChargeID);
            return clause;
        }

        public bool Exists(int? SupplierFinanceChargeID)
        {
            if (SupplierFinanceChargeID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountBySupplierFinanceChargeID(SupplierFinanceChargeID.Value)) != 0;
        }

        public override bool Exists(SupplierFinanceCharge _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.SupplierFinanceChargeID);
        }

        protected override SupplierFinanceCharge _FindByIntId(int? SupplierFinanceChargeID)
        {
            if (SupplierFinanceChargeID == null) return null;

            SupplierFinanceCharge _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectBySupplierFinanceChargeID(SupplierFinanceChargeID.Value));
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

        protected override IList<SupplierFinanceCharge>_FindAllCollection()
        {
            List<SupplierFinanceCharge> _grp = new List<SupplierFinanceCharge>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                SupplierFinanceCharge _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
