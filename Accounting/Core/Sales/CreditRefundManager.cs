using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Sales
{
    public abstract class CreditRefundManager : EntityManager<CreditRefund>
    {
        public CreditRefundManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override CreditRefund _CreateDbEntity()
        {
            return new CreditRefund(true, this);
        }
        protected override CreditRefund _CreateEntity()
        {
            return new CreditRefund(false, this);
        }
        #endregion

        protected override void LoadFromReader(CreditRefund _obj, DbDataReader reader)
        {
            _obj.AmountRefunded = GetDouble(reader, "AmountRefunded");
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.ChequeNumber = GetString(reader, "ChequeNumber");
            _obj.CreditNoteID = GetInt32(reader, "CreditNoteID");
            _obj.CreditRefundID = GetInt32(reader, "CreditRefundID");
            _obj.CurrencyID = GetInt32(reader, "CurrencyID");
            _obj.TransactionDate = GetDateTime(reader, "TransactionDate");
            _obj.Date = _obj.TransactionDate;
            _obj.ExchangeGainLoss = GetDouble(reader, "ExchangeGainLoss");
            _obj.IsPrinted = GetString(reader, "IsPrinted");
            _obj.IssuingAccountID = GetInt32(reader, "IssuingAccountID");
            _obj.IsTaxInclusive = GetString(reader, "IsTaxInclusive");
            _obj.IsThirteenthPeriod = GetString(reader, "IsThirteenthPeriod");
            _obj.Memo = GetString(reader, "Memo");
            _obj.Payee = GetString(reader, "Payee");
            _obj.PaymentDeliveryID = GetString(reader, "PaymentDeliveryID");
            _obj.TransactionExchangeRate = GetDouble(reader, "TransactionExchangeRate");

        }

        public override Dictionary<string, DbFieldEntry> GetFields(CreditRefund _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["AmountRefunded"] = DbMgr.CreateDoubleFieldEntry(_obj.AmountRefunded); // = GetDouble(reader, "");
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID); // = GetInt32(reader, "");
            fields["ChequeNumber"] = DbMgr.CreateStringFieldEntry(_obj.ChequeNumber); // = GetString(reader, "");
            fields["CreditNoteID"] = DbMgr.CreateIntFieldEntry(_obj.CreditNoteID); // = GetInt32(reader, "");
            fields["CreditRefundID"] = DbMgr.CreateAutoIntFieldEntry(_obj.CreditRefundID); // = GetInt32(reader, "");
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID); // = GetInt32(reader, "");
            fields["TransactionDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.TransactionDate); // = GetDateTime(reader, "");
            fields["Date"] = DbMgr.CreateDateTimeFieldEntry(_obj.Date); // = fields[""]=DbMgr.CreateStringFieldEntry(_obj.TransactionDate;
            fields["ExchangeGainLoss"] = DbMgr.CreateDoubleFieldEntry(_obj.ExchangeGainLoss); // = GetDouble(reader, "");
            fields["IsPrinted"] = DbMgr.CreateStringFieldEntry(_obj.IsPrinted); // = GetString(reader, "");
            fields["IssuingAccountID"] = DbMgr.CreateIntFieldEntry(_obj.IssuingAccountID); // = GetInt32(reader, "");
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive); // = GetString(reader, "");
            fields["IsThirteenthPeriod"] = DbMgr.CreateStringFieldEntry(_obj.IsThirteenthPeriod); // = GetString(reader, "");
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo); // = GetString(reader, "");
            fields["Payee"] = DbMgr.CreateStringFieldEntry(_obj.Payee); // = GetString(reader, "");
            fields["PaymentDeliveryID"] = DbMgr.CreateStringFieldEntry(_obj.PaymentDeliveryID); // = GetString(reader, "");
            fields["TransactionExchangeRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TransactionExchangeRate); // = GetDouble(reader, "");

            return fields;
        }

        protected override object GetDbProperty(CreditRefund _obj, string property_name)
        {

            if (property_name.Equals("Currency"))
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }

            else if (property_name.Equals("PaymentDelivery"))
            {
                return RepositoryMgr.InvoiceDeliveryMgr.FindById(_obj.PaymentDeliveryID);
            }
            else if (property_name.Equals("Card"))
            {
                return RepositoryMgr.CardMgr.FindByCardId(_obj.CardRecordID, true);
            }
            else if (property_name.Equals("IssuingAccount"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.IssuingAccountID);
            }
            else if (property_name.Equals("CreditNote"))
            {
                return RepositoryMgr.SaleMgr.FindById(_obj.CreditNoteID);
            }
            return true;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("CreditRefunds");
        }

        private DbSelectStatement GetQuery_SelectByCreditRefundID(int CreditRefundID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("CreditRefunds")
                .Criteria
                    .IsEqual("CreditRefunds", "CreditRefundID", CreditRefundID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByCreditRefundID(int CreditRefundID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("CreditRefunds")
                .Criteria
                    .IsEqual("CreditRefunds", "CreditRefundID", CreditRefundID);
            return clause;
        }

        public bool Exists(int? CreditRefundID)
        {
            if (CreditRefundID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByCreditRefundID(CreditRefundID.Value)) != 0;
        }

        public override bool Exists(CreditRefund _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.CreditRefundID);
        }

        protected override CreditRefund _FindByIntId(int? CreditRefundID)
        {
            if (CreditRefundID == null) return null;
            CreditRefund _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByCreditRefundID(CreditRefundID.Value));
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

        protected override IList<CreditRefund>_FindAllCollection()
        {
            List<CreditRefund> _grp = new List<CreditRefund>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                CreditRefund _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

    }
}
