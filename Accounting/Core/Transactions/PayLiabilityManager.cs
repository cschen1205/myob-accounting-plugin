using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Transactions
{
    public abstract class PayLiabilityManager : EntityManager<PayLiability>
    {
        public PayLiabilityManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override PayLiability _CreateDbEntity()
        {
            return new PayLiability(true, this);
        }
        protected override PayLiability _CreateEntity()
        {
            return new PayLiability(false, this);
        }
        #endregion

        protected override void LoadFromReader(PayLiability _obj, DbDataReader reader)
        {
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.ChequeNumber = GetString(reader, "ChequeNumber");
            _obj.CurrencyID = GetInt32(reader, "CurrencyID");
            _obj.FromDate = GetDateTime(reader, "FromDate");
            _obj.IsPrinted = GetString(reader, "IsPrinted");
            _obj.IssuingAccountID = GetInt32(reader, "IssuingAccountID");
            _obj.IsTaxInclusive = GetString(reader, "IsTaxInclusive");
            _obj.IsThirteenthPeriod = GetString(reader, "IsThirteenthPeriod");
            _obj.Memo = GetString(reader, "Memo");
            _obj.Payee = GetString(reader, "Payee");
            _obj.PayeeLine1 = GetString(reader, "PayeeLine1");
            _obj.PayeeLine2 = GetString(reader, "PayeeLine2");
            _obj.PayeeLine3 = GetString(reader, "PayeeLine3");
            _obj.PayeeLine4 = GetString(reader, "PayeeLine4");
            _obj.PayLiabilityID = GetInt32(reader, "PayLiabilitiesID");
            _obj.PaymentDate = GetDateTime(reader, "PaymentDate");
            _obj.PaymentStatusID = GetString(reader, "PaymentStatusID");
            _obj.StatementText = GetString(reader, "StatementText");
            _obj.ToDate = GetDateTime(reader, "ToDate");
            _obj.TotalPayment = GetDouble(reader, "TotalPayment");
            _obj.TransactionExchangeRate = GetDouble(reader, "TransactionExchangeRate");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(PayLiability _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID); //GetInt32(reader, "CardRecordID");
            fields["ChequeNumber"] = DbMgr.CreateStringFieldEntry(_obj.ChequeNumber); //GetString(reader, "ChequeNumber");
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID); //GetInt32(reader, "CurrencyID");
            fields["FromDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.FromDate); //GetDateTime(reader, "FromDate");
            fields["IsPrinted"] = DbMgr.CreateStringFieldEntry(_obj.IsPrinted); //GetString(reader, "IsPrinted");
            fields["IssuingAccountID"] = DbMgr.CreateIntFieldEntry(_obj.IssuingAccountID); //GetInt32(reader, "IssuingAccountID");
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive); //GetString(reader, "IsTaxInclusive");
            fields["IsThirteenthPeriod"] = DbMgr.CreateStringFieldEntry(_obj.IsThirteenthPeriod); //GetString(reader, "IsThirteenthPeriod");
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo); //GetString(reader, "Memo");
            fields["Payee"] = DbMgr.CreateStringFieldEntry(_obj.Payee); //GetString(reader, "Payee");
            fields["PayeeLine1"] = DbMgr.CreateStringFieldEntry(_obj.PayeeLine1); //GetString(reader, "PayeeLine1");
            fields["PayeeLine2"] = DbMgr.CreateStringFieldEntry(_obj.PayeeLine2); //GetString(reader, "PayeeLine2");
            fields["PayeeLine3"] = DbMgr.CreateStringFieldEntry(_obj.PayeeLine3); //GetString(reader, "PayeeLine3");
            fields["PayeeLine4"] = DbMgr.CreateStringFieldEntry(_obj.PayeeLine4); //GetString(reader, "PayeeLine4");
            fields["PayLiabilitiesID"] = DbMgr.CreateAutoIntFieldEntry(_obj.PayLiabilityID); //GetInt32(reader, "PayLiabilitiesID");
            fields["PaymentDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.PaymentDate); //GetDateTime(reader, "PaymentDate");
            fields["PaymentStatusID"] = DbMgr.CreateStringFieldEntry(_obj.PaymentStatusID); //GetString(reader, "PaymentStatusID");
            fields["StatementText"] = DbMgr.CreateStringFieldEntry(_obj.StatementText); //GetString(reader, "StatementText");
            fields["ToDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.ToDate); //GetDateTime(reader, "ToDate");
            fields["TotalPayment"] = DbMgr.CreateDoubleFieldEntry(_obj.TotalPayment); //GetDouble(reader, "TotalPayment");
            fields["TransactionExchangeRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TransactionExchangeRate); //GetDouble(reader, "TransactionExchangeRate");

            return fields;
        }

        protected override object GetDbProperty(PayLiability _obj, string property_name)
        {
            if (property_name.Equals("IssuingAccount"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.IssuingAccountID);
            }
            else if (property_name.Equals("Card"))
            {
                return RepositoryMgr.CardMgr.FindByCardId(_obj.CardRecordID, true);
            }
            else if (property_name.Equals("Currency"))
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name.Equals("PaymentStatus"))
            {
                return RepositoryMgr.DepositStatusMgr.FindById(_obj.PaymentStatusID);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("PayLiabilities");
        }

        private DbSelectStatement GetQuery_SelectByPayLiabilityID(int PayLiabilityID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("PayLiabilities")
                .Criteria
                    .IsEqual("PayLiabilities", "PayLiabilitiesID", PayLiabilityID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByPayLiabilityID(int PayLiabilityID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("PayLiabilities")
                .Criteria
                    .IsEqual("PayLiabilities", "PayLiabilitiesID", PayLiabilityID);

            return clause;
        }

        public bool Exists(int? PayLiabilityID)
        {
            if (PayLiabilityID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByPayLiabilityID(PayLiabilityID.Value)) != 0;
        }

        public override bool Exists(PayLiability _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.PayLiabilityID);
        }

        protected override PayLiability _FindByIntId(int? PayLiabilityID)
        {
            if (PayLiabilityID == null) return null;
            PayLiability _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByPayLiabilityID(PayLiabilityID.Value));
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

        protected override IList<PayLiability>_FindAllCollection()
        {
            List<PayLiability> _grp = new List<PayLiability>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                PayLiability _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
