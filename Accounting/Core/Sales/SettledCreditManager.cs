using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Sales
{
    public abstract class SettledCreditManager : EntityManager<SettledCredit>
    {
        public SettledCreditManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override SettledCredit _CreateDbEntity()
        {
            return new SettledCredit(true, this);
        }
        protected override SettledCredit _CreateEntity()
        {
            return new SettledCredit(false, this);
        }
        #endregion

        protected override void LoadFromReader(SettledCredit _obj, DbDataReader reader)
        {
            _obj.AmountSettled = GetDouble(reader, "AmountSettled");
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.CreditNoteID = GetInt32(reader, "CreditNoteID");
            _obj.CurrencyID = GetInt32(reader, "CurrencyID");
            _obj.TransactionDate = GetDateTime(reader, "TransactionDate");
            _obj.Date = _obj.TransactionDate;
            _obj.ExchangeGainLoss = GetDouble(reader, "ExchangeGainLoss");
            _obj.FinanceCharge = GetDouble(reader, "FinanceCharge");
            _obj.IsDiscount = GetString(reader, "IsDiscount");
            _obj.IsTaxInclusive = GetString(reader, "IsTaxInclusive");
            _obj.IsThirteenthPeriod = GetString(reader, "IsThirteenthPeriod");
            _obj.Memo = GetString(reader, "Memo");
            _obj.SettledCreditID = GetInt32(reader, "SettledCreditID");
            _obj.SettledCreditNumber = GetString(reader, "SettledCreditNumber");
            _obj.TransactionExchangeRate = GetDouble(reader, "TransactionExchangeRate");
            
        }

        public override Dictionary<string, DbFieldEntry> GetFields(SettledCredit _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["AmountSettled"] = DbMgr.CreateDoubleFieldEntry(_obj.AmountSettled);
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["CreditNoteID"] = DbMgr.CreateIntFieldEntry(_obj.CreditNoteID);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["TransactionDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.TransactionDate);
            fields["Date"] = DbMgr.CreateDateTimeFieldEntry(_obj.Date);
            fields["ExchangeGainLoss"] = DbMgr.CreateDoubleFieldEntry(_obj.ExchangeGainLoss);
            fields["FinanceCharge"] = DbMgr.CreateDoubleFieldEntry(_obj.FinanceCharge);
            fields["IsDiscount"] = DbMgr.CreateStringFieldEntry(_obj.IsDiscount);
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive);
            fields["IsThirteenthPeriod"] = DbMgr.CreateStringFieldEntry(_obj.IsThirteenthPeriod);
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo);
            fields["SettledCreditID"] = DbMgr.CreateAutoIntFieldEntry(_obj.SettledCreditID);
            fields["SettledCreditNumber"] = DbMgr.CreateStringFieldEntry(_obj.SettledCreditNumber);
            fields["TransactionExchangeRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TransactionExchangeRate);

            return fields;
        }

        protected override object GetDbProperty(SettledCredit _obj, string property_name)
        {
            if (property_name.Equals("Currency"))
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name.Equals("CreditNote"))
            {
                return RepositoryMgr.SaleMgr.FindById(_obj.CreditNoteID);
            }
            else if (property_name.Equals("Card"))
            {
                return RepositoryMgr.CardMgr.FindByCardId(_obj.CardRecordID, true);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("SettledCredits");
        }

        private DbSelectStatement GetQuery_SelectBySettledCreditID(int SettledCreditID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("SettledCredits")
                .Criteria
                    .IsEqual("SettledCredits", "SettledCreditID", SettledCreditID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountBySettledCreditID(int SettledCreditID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("SettledCredits")
                .Criteria
                    .IsEqual("SettledCredits", "SettledCreditID", SettledCreditID);
            return clause;
        }

        public bool Exists(int? SettledCreditID)
        {
            if (SettledCreditID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountBySettledCreditID(SettledCreditID.Value)) != 0;
        }

        public override bool Exists(SettledCredit _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.SettledCreditID);
        }

        protected override SettledCredit _FindByIntId(int? SettledCreditID)
        {
            if (SettledCreditID == null) return null;
            SettledCredit _obj = null;
            DbCommand _cmd = CreateDbCommand(GetQuery_SelectBySettledCreditID(SettledCreditID.Value));
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

        protected override IList<SettledCredit>_FindAllCollection()
        {
            List<SettledCredit> _grp = new List<SettledCredit>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                SettledCredit _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
