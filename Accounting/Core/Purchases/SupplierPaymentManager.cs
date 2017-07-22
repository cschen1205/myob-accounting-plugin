using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Purchases
{
    public abstract class SupplierPaymentManager : EntityManager<SupplierPayment>
    {
        public SupplierPaymentManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override SupplierPayment _CreateDbEntity()
        {
            return new SupplierPayment(true, this);
        }
        protected override SupplierPayment _CreateEntity()
        {
            return new SupplierPayment(false, this);
        }
        #endregion

        protected override void LoadFromReader(SupplierPayment _obj, DbDataReader reader)
        {
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.CurrencyID = GetInt32(reader, "CurrencyID");
            _obj.SupplierPaymentID = GetInt32(reader, "SupplierPaymentID");
            _obj.SupplierPaymentNumber = GetString(reader, "SupplierPaymentNumber");
            _obj.TransactionDate = GetDateTime(reader, "TransactionDate");
            _obj.Date = _obj.TransactionDate;
            _obj.PaymentStatusID = GetString(reader, "PaymentStatusID");
            _obj.ExchangeGainLoss = GetDouble(reader, "ExchangeGainLoss");
            _obj.FinanceCharge = GetDouble(reader, "FinanceCharge");
            _obj.IsTaxInclusive = GetString(reader, "IsTaxInclusive");
            _obj.IsThirteenthPeriod = GetString(reader, "IsThirteenthPeriod");
            _obj.Memo = GetString(reader, "Memo");
            _obj.IssuingAccountID = GetInt32(reader, "IssuingAccountID");
            _obj.TotalSupplierPayment = GetDouble(reader, "TotalSupplierPayment");
            _obj.TransactionExchangeRate = GetDouble(reader, "TransactionExchangeRate");
            _obj.Payee = GetString(reader, "Payee");
            _obj.PayeeLine1 = GetString(reader, "PayeeLine1");
            _obj.PayeeLine2 = GetString(reader, "PayeeLine2");
            _obj.PayeeLine3 = GetString(reader, "PayeeLine3");
            _obj.PayeeLine4 = GetString(reader, "PayeeLine4");
            _obj.StatementCode = GetString(reader, "StatementCode");
            _obj.StatementParticulars = GetString(reader, "StatementParticulars");
            _obj.StatementReference = GetString(reader, "StatementReference");
            _obj.StatementText = GetString(reader, "StatementText");
            _obj.IsPrinted = GetString(reader, "IsPrinted");
            _obj.PaymentDeliveryID = GetString(reader, "PaymentDeliveryID");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(SupplierPayment _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["SupplierPaymentID"] = DbMgr.CreateAutoIntFieldEntry(_obj.SupplierPaymentID);
            fields["SupplierPaymentNumber"] = DbMgr.CreateStringFieldEntry(_obj.SupplierPaymentNumber);
            fields["TransactionDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.TransactionDate);
            fields["Date"] = DbMgr.CreateDateTimeFieldEntry(_obj.Date);
            fields["PaymentStatusID"] = DbMgr.CreateStringFieldEntry(_obj.PaymentStatusID);
            fields["ExchangeGainLoss"] = DbMgr.CreateDoubleFieldEntry(_obj.ExchangeGainLoss);
            fields["FinanceCharge"] = DbMgr.CreateDoubleFieldEntry(_obj.FinanceCharge);
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive);
            fields["IsThirteenthPeriod"] = DbMgr.CreateStringFieldEntry(_obj.IsThirteenthPeriod);
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo);
            fields["IssuingAccountID"] = DbMgr.CreateIntFieldEntry(_obj.IssuingAccountID);
            fields["TotalSupplierPayment"] = DbMgr.CreateDoubleFieldEntry(_obj.TotalSupplierPayment);
            fields["TransactionExchangeRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TransactionExchangeRate);
            fields["Payee"] = DbMgr.CreateStringFieldEntry(_obj.Payee);
            fields["PayeeLine1"] = DbMgr.CreateStringFieldEntry(_obj.PayeeLine1);
            fields["PayeeLine2"] = DbMgr.CreateStringFieldEntry(_obj.PayeeLine2);
            fields["PayeeLine3"] = DbMgr.CreateStringFieldEntry(_obj.PayeeLine3);
            fields["PayeeLine4"] = DbMgr.CreateStringFieldEntry(_obj.PayeeLine4);
            fields["StatementCode"] = DbMgr.CreateStringFieldEntry(_obj.StatementCode);
            fields["StatementParticulars"] = DbMgr.CreateStringFieldEntry(_obj.StatementParticulars);
            fields["StatementReference"] = DbMgr.CreateStringFieldEntry(_obj.StatementReference);
            fields["StatementText"] = DbMgr.CreateStringFieldEntry(_obj.StatementText);
            fields["IsPrinted"] = DbMgr.CreateStringFieldEntry(_obj.IsPrinted);
            fields["PaymentDeliveryID"] = DbMgr.CreateStringFieldEntry(_obj.PaymentDeliveryID);

            return fields;
        }

        protected override object GetDbProperty(SupplierPayment _obj, string property_name)
        {
            if (property_name.Equals("Currency"))
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name.Equals("Card"))
            {
                return RepositoryMgr.CardMgr.FindByCardId(_obj.CardRecordID, true);
            }
            else if (property_name.Equals("PaymentStatus"))
            {
                return RepositoryMgr.DepositStatusMgr.FindById(_obj.PaymentStatusID);
            }
            else if (property_name.Equals("PaymentDelivery"))
            {
                return RepositoryMgr.InvoiceDeliveryMgr.FindById(_obj.PaymentDeliveryID);
            }
            else if (property_name.Equals("IssuingAccount"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.IssuingAccountID);
            }
           
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll().From("SupplierPayments");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectBySupplierPaymentID(int? SupplierPaymentID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("SupplierPayments")
                .Criteria
                    .IsEqual("SupplierPayments", "SupplierPaymentID", SupplierPaymentID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountBySupplierPaymentID(int? SupplierPaymentID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("SupplierPayments")
                .Criteria
                    .IsEqual("SupplierPayments", "SupplierPaymentID", SupplierPaymentID);
            return clause;
        }

        public bool Exists(int? SupplierPaymentID)
        {
            if (SupplierPaymentID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountBySupplierPaymentID(SupplierPaymentID.Value)) != 0;
        }

        public override bool Exists(SupplierPayment _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.SupplierPaymentID);
        }

        protected override SupplierPayment _FindByIntId(int? SupplierPaymentID)
        {
            if (SupplierPaymentID == null) return null;

            SupplierPayment _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectBySupplierPaymentID(SupplierPaymentID.Value));
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

        protected override IList<SupplierPayment>_FindAllCollection()
        {
            List<SupplierPayment> _grp = new List<SupplierPayment>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                SupplierPayment _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
