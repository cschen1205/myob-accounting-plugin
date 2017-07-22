using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Purchases
{
    public abstract class SettledDebitManager : EntityManager<SettledDebit>
    {
        public SettledDebitManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override SettledDebit _CreateDbEntity()
        {
            return new SettledDebit(true, this);
        }
        protected override SettledDebit _CreateEntity()
        {
            return new SettledDebit(false, this);
        }
        #endregion

        protected override void LoadFromReader(SettledDebit _obj, DbDataReader reader)
        {
            _obj.AmountSettled = GetDouble(reader, "AmountSettled");
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.DebitNoteID = GetInt32(reader, "DebitNoteID");
            _obj.CurrencyID = GetInt32(reader, "CurrencyID");
            _obj.TransactionDate = GetDateTime(reader, "TransactionDate");
            _obj.Date = _obj.TransactionDate;
            _obj.ExchangeGainLoss = GetDouble(reader, "ExchangeGainLoss");
            _obj.FinanceCharge = GetDouble(reader, "FinanceCharge");
            _obj.IsDiscount = GetString(reader, "IsDiscount");
            _obj.IsTaxInclusive = GetString(reader, "IsTaxInclusive");
            _obj.IsThirteenthPeriod = GetString(reader, "IsThirteenthPeriod");
            _obj.Memo = GetString(reader, "Memo");
            _obj.SettledDebitID = GetInt32(reader, "SettledDebitID");
            _obj.SettledDebitNumber = GetString(reader, "SettledDebitNumber");
            _obj.TransactionExchangeRate = GetDouble(reader, "TransactionExchangeRate");
            
        }

        public override Dictionary<string, DbFieldEntry> GetFields(SettledDebit _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["AmountSettled"] = DbMgr.CreateDoubleFieldEntry(_obj.AmountSettled);
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["DebitNoteID"] = DbMgr.CreateIntFieldEntry(_obj.DebitNoteID);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["TransactionDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.TransactionDate);
            fields["Date"] = DbMgr.CreateDateTimeFieldEntry(_obj.Date);
            fields["ExchangeGainLoss"] = DbMgr.CreateDoubleFieldEntry(_obj.ExchangeGainLoss);
            fields["FinanceCharge"] = DbMgr.CreateDoubleFieldEntry(_obj.FinanceCharge);
            fields["IsDiscount"] = DbMgr.CreateStringFieldEntry(_obj.IsDiscount);
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive);
            fields["IsThirteenthPeriod"] = DbMgr.CreateStringFieldEntry(_obj.IsThirteenthPeriod);
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo);
            fields["SettledDebitID"] = DbMgr.CreateAutoIntFieldEntry(_obj.SettledDebitID);
            fields["SettledDebitNumber"] = DbMgr.CreateStringFieldEntry(_obj.SettledDebitNumber);
            fields["TransactionExchangeRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TransactionExchangeRate);

            return fields;
        }

        protected override object GetDbProperty(SettledDebit _obj, string property_name)
        {
            if (property_name.Equals("Currency"))
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name.Equals("DebitNote"))
            {
                return RepositoryMgr.PurchaseMgr.FindById(_obj.DebitNoteID);
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
            return clause.SelectAll().From("SettledDebits");
        }

        private DbSelectStatement GetQuery_SelectBySettledDebitID(int SettledDebitID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("SettledDebits")
                .Criteria
                    .IsEqual("SettledDebits", "SettledDebitID", SettledDebitID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountBySettledDebitID(int SettledDebitID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("SettledDebits")
                .Criteria
                    .IsEqual("SettledDebits", "SettledDebitID", SettledDebitID);
            return clause;
        }

        public bool Exists(int? SettledDebitID)
        {
            if (SettledDebitID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountBySettledDebitID(SettledDebitID.Value)) != 0;
        }

        public override bool Exists(SettledDebit _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.SettledDebitID);
        }

        protected override SettledDebit _FindByIntId(int? SettledDebitID)
        {
            if (SettledDebitID == null) return null;
            SettledDebit _obj = null;
            DbCommand _cmd = CreateDbCommand(GetQuery_SelectBySettledDebitID(SettledDebitID.Value));
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

        protected override IList<SettledDebit>_FindAllCollection()
        {
            List<SettledDebit> _grp = new List<SettledDebit>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                SettledDebit _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
