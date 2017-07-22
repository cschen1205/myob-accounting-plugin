using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Transactions
{
    public abstract class WritePaychequeManager : EntityManager<WritePaycheque>
    {
        public WritePaychequeManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override WritePaycheque _CreateDbEntity()
        {
            return new WritePaycheque(true, this);
        }
        protected override WritePaycheque _CreateEntity()
        {
            return new WritePaycheque(false, this);
        }
        #endregion

        protected override void LoadFromReader(WritePaycheque _obj, DbDataReader reader)
        {
            _obj.BankingDetailsID = GetInt32(reader, "BankingDetailsID");
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.ChequeNumber = GetString(reader, "ChequeNumber");
            _obj.CostCentreID = GetInt32(reader, "CostCentreID");
            _obj.CurrencyID = GetInt32(reader, "CurrencyID");
            _obj.TransactionDate = GetDateTime(reader, "TransactionDate");
            _obj.Date = _obj.TransactionDate;
            _obj.IsPrinted = GetString(reader, "IsPrinted");
            _obj.IssuingAccountID = GetInt32(reader, "IssuingAccountID");
            _obj.IsTaxInclusive = GetString(reader, "IsTaxInclusive");
            _obj.IsThirteenthPeriod = GetString(reader, "IsThirteenthPeriod");
            _obj.Memo = GetString(reader, "Memo");
            _obj.NetPay = GetDouble(reader, "NetPay");
            _obj.NumberOfPayPeriods = GetDouble(reader, "NumberOfPayPeriods");
            _obj.Payee = GetString(reader, "Payee");
            _obj.PayeeLine1 = GetString(reader, "PayeeLine1");
            _obj.PayeeLine2 = GetString(reader, "PayeeLine2");
            _obj.PayeeLine3 = GetString(reader, "PayeeLine3");
            _obj.PayeeLine4 = GetString(reader, "PayeeLine4");
            _obj.PaymentTypeID = GetString(reader, "PaymentTypeID");
            _obj.PaymentStatusID = GetString(reader, "PaymentStatusID");
            _obj.PayPeriodEndingDate = GetDateTime(reader, "PayPeriodEndingDate");
            _obj.PayPeriodStartDate = GetDateTime(reader, "PayPeriodStartDate");
            _obj.StatementText = GetString(reader, "StatementText");
            _obj.TransactionExchangeRate = GetDouble(reader, "TransactionExchangeRate");
            _obj.WritePaychequeID = GetInt32(reader, "WritePaychequeID");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(WritePaycheque _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["BankingDetailsID"] = DbMgr.CreateIntFieldEntry(_obj.BankingDetailsID); //GetInt32(reader, "BankingDetailsID");
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID); //GetInt32(reader, "CardRecordID");
            fields["ChequeNumber"] = DbMgr.CreateStringFieldEntry(_obj.ChequeNumber); //GetString(reader, "ChequeNumber");
            fields["CostCentreID"] = DbMgr.CreateIntFieldEntry(_obj.CostCentreID); //GetInt32(reader, "CostCentreID");
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID); //GetInt32(reader, "CurrencyID");
            fields["TransactionDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.TransactionDate); //GetDateTime(reader, "TransactionDate");
            fields["Date"] = DbMgr.CreateDateTimeFieldEntry(_obj.Date); //fields[""]=DbMgr.CreateIntFieldEntry(_obj.TransactionDate;
            fields["IsPrinted"] = DbMgr.CreateStringFieldEntry(_obj.IsPrinted); //GetString(reader, "IsPrinted");
            fields["IssuingAccountID"] = DbMgr.CreateIntFieldEntry(_obj.IssuingAccountID); //GetInt32(reader, "IssuingAccountID");
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive); //GetString(reader, "IsTaxInclusive");
            fields["IsThirteenthPeriod"] = DbMgr.CreateStringFieldEntry(_obj.IsThirteenthPeriod); //GetString(reader, "");
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo); //GetString(reader, "Memo");
            fields["NetPay"] = DbMgr.CreateDoubleFieldEntry(_obj.NetPay); //GetDouble(reader, "NetPay");
            fields["NumberOfPayPeriods"] = DbMgr.CreateDoubleFieldEntry(_obj.NumberOfPayPeriods); //GetDouble(reader, "NumberOfPayPeriods");
            fields["Payee"] = DbMgr.CreateStringFieldEntry(_obj.Payee); //GetString(reader, "Payee");
            fields["PayeeLine1"] = DbMgr.CreateStringFieldEntry(_obj.PayeeLine1); //GetString(reader, "PayeeLine1");
            fields["PayeeLine2"] = DbMgr.CreateStringFieldEntry(_obj.PayeeLine2); //GetString(reader, "PayeeLine2");
            fields["PayeeLine3"] = DbMgr.CreateStringFieldEntry(_obj.PayeeLine3); //GetString(reader, "PayeeLine3");
            fields["PayeeLine4"] = DbMgr.CreateStringFieldEntry(_obj.PayeeLine4); //GetString(reader, "PayeeLine4");
            fields["PaymentTypeID"] = DbMgr.CreateStringFieldEntry(_obj.PaymentTypeID); //GetString(reader, "PaymentTypeID");
            fields["PaymentStatusID"] = DbMgr.CreateStringFieldEntry(_obj.PaymentStatusID); //GetString(reader, "PaymentStatusID");
            fields["PayPeriodEndingDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.PayPeriodEndingDate); //GetDateTime(reader, "PayPeriodEndingDate");
            fields["PayPeriodStartDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.PayPeriodStartDate); //GetDateTime(reader, "PayPeriodStartDate");
            fields["StatementText"] = DbMgr.CreateStringFieldEntry(_obj.StatementText); //GetString(reader, "StatementText");
            fields["TransactionExchangeRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TransactionExchangeRate); //GetDouble(reader, "TransactionExchangeRate");
            fields["WritePaychequeID"] = DbMgr.CreateAutoIntFieldEntry(_obj.WritePaychequeID); //GetInt32(reader, "WritePaychequeID");

            return fields;
        }

        protected override object GetDbProperty(WritePaycheque _obj, string property_name)
        {
            if (property_name.Equals("IssuingAccount"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.IssuingAccountID);
            }
            else if (property_name.Equals("CardRecordID"))
            {
                return RepositoryMgr.CardMgr.FindByCardId(_obj.CardRecordID, true);
            }
            else if (property_name.Equals("PaymentType"))
            {
                return RepositoryMgr.PaymentTypeMgr.FindById(_obj.PaymentTypeID);
            }
            else if (property_name.Equals("BankingDetails"))
            {
                return RepositoryMgr.BankingDetailMgr.FindById(_obj.BankingDetailsID);
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
            return clause.SelectAll().From("WritePaycheque");
        }

        private DbSelectStatement GetQuery_SelectByWritePaychequeID(int WritePaychequeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("WritePaycheque")
                .Criteria
                    .IsEqual("WritePaycheque", "WritePaychequeID", WritePaychequeID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByWritePaychequeID(int WritePaychequeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("WritePaycheque")
                .Criteria
                    .IsEqual("WritePaycheque", "WritePaychequeID", WritePaychequeID);

            return clause;
        }

        public bool Exists(int? WritePaychequeID)
        {
            if (WritePaychequeID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByWritePaychequeID(WritePaychequeID.Value)) != 0;
        }

        public override bool Exists(WritePaycheque _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.WritePaychequeID);
        }

        protected override WritePaycheque _FindByIntId(int? WritePaychequeID)
        {
            if (WritePaychequeID == null) return null;
            WritePaycheque _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByWritePaychequeID(WritePaychequeID.Value));
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

        protected override IList<WritePaycheque> _FindAllCollection()
        {
            List<WritePaycheque> _grp = new List<WritePaycheque>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                WritePaycheque _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

    }
}
