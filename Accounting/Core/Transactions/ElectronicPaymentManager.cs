using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Transactions
{
    public abstract class ElectronicPaymentManager : EntityManager<ElectronicPayment>
    {
        public ElectronicPaymentManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override ElectronicPayment _CreateEntity()
        {
            return new ElectronicPayment(false, this);
        }
        protected override ElectronicPayment _CreateDbEntity()
        {
            return new ElectronicPayment(true, this);
        }
        #endregion

        protected override void LoadFromReader(ElectronicPayment _obj, DbDataReader reader)
        {
            _obj.CurrencyID = GetInt32(reader, "CurrencyID");
            _obj.TransactionDate = GetDateTime(reader, "TransactionDate");
            _obj.Date = _obj.TransactionDate;
            _obj.ElectronicPaymentID = GetInt32(reader, "ElectronicPaymentID");
            _obj.IssuingAccountID = GetInt32(reader, "IssuingAccountID");
            _obj.IsTaxInclusive = GetString(reader, "IsTaxInclusive");
            _obj.IsThirteenthPeriod = GetString(reader, "IsThirteenthPeriod");
            _obj.Memo = GetString(reader, "Memo");
            _obj.PaymentNumber = GetString(reader, "PaymentNumber");
            _obj.StatementText = GetString(reader, "StatementText");
            _obj.TotalPaymentAmount = GetDouble(reader, "TotalPaymentAmount");
            _obj.TransactionExchangeRate = GetDouble(reader, "TransactionExchangeRate");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(ElectronicPayment _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID); //GetInt32(reader, "");
            fields["TransactionDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.TransactionDate); //GetDateTime(reader, "");
            fields["Date"] = DbMgr.CreateDateTimeFieldEntry(_obj.Date); //fields[""]=DbMgr.CreateIntFieldEntry(_obj.TransactionDate;
            fields["ElectronicPaymentID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ElectronicPaymentID); //GetInt32(reader, "");
            fields["IssuingAccountID"] = DbMgr.CreateIntFieldEntry(_obj.IssuingAccountID); //GetInt32(reader, "");
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive); //GetString(reader, "");
            fields["IsThirteenthPeriod"] = DbMgr.CreateStringFieldEntry(_obj.IsThirteenthPeriod); //GetString(reader, "");
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo); //GetString(reader, "");
            fields["PaymentNumber"] = DbMgr.CreateStringFieldEntry(_obj.PaymentNumber); //GetString(reader, "");
            fields["StatementText"] = DbMgr.CreateStringFieldEntry(_obj.StatementText); //GetString(reader, "");
            fields["TotalPaymentAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TotalPaymentAmount); //GetDouble(reader, "");
            fields["TransactionExchangeRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TransactionExchangeRate); //GetDouble(reader, "");

            return fields;
        }

        protected override object GetDbProperty(ElectronicPayment _obj, string property_name)
        {
            if (property_name.Equals("Currency"))
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
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

            return clause.SelectAll().From("ElectronicPayments");
        }

        private DbSelectStatement GetQuery_SelectByElectronicPaymentID(int ElectronicPaymentID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("ElectronicPayments")
                .Criteria
                    .IsEqual("ElectronicPayments", "ElectronicPaymentID", ElectronicPaymentID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByElectronicPaymentID(int ElectronicPaymentID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("ElectronicPayments")
                .Criteria
                    .IsEqual("ElectronicPayments", "ElectronicPaymentID", ElectronicPaymentID);

            return clause;
        }

        public bool Exists(int? ElectronicPaymentID)
        {
            if (ElectronicPaymentID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByElectronicPaymentID(ElectronicPaymentID.Value)) != 0;
        }

        public override bool Exists(ElectronicPayment _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.ElectronicPaymentID);
        }

        protected override ElectronicPayment _FindByIntId(int? ElectronicPaymentID)
        {
            if (ElectronicPaymentID == null) return null;
            ElectronicPayment _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByElectronicPaymentID(ElectronicPaymentID.Value));
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

        protected override IList<ElectronicPayment>_FindAllCollection()
        {
            List<ElectronicPayment> _grp = new List<ElectronicPayment>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                ElectronicPayment _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
