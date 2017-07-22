using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Transactions
{
    public abstract class MoneySpentManager : EntityManager<MoneySpent>
    {
        public MoneySpentManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override MoneySpent _CreateDbEntity()
        {
            return new MoneySpent(true, this);
        }
        protected override MoneySpent _CreateEntity()
        {
            return new MoneySpent(false, this);
        }
        #endregion

        protected override void LoadFromReader(MoneySpent _obj, DbDataReader reader)
        {
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.ChequeNumber = GetString(reader, "ChequeNumber");
            _obj.CostCentreID = GetInt32(reader, "CostCentreID");
            _obj.CurrencyID = GetInt32(reader, "CurrencyID");
            _obj.TransactionDate = GetDateTime(reader, "TransactionDate");
            _obj.Date = _obj.TransactionDate;
            _obj.IsAutoRecorded = GetString(reader, "IsAutoRecorded");
            _obj.IsPrinted = GetString(reader, "IsPrinted");
            _obj.IssuingAccountID = GetInt32(reader, "IssuingAccountID");
            _obj.IsTaxInclusive = GetString(reader, "IsTaxInclusive");
            _obj.IsThirteenthPeriod = GetString(reader, "IsThirteenthPeriod");
            _obj.Memo = GetString(reader, "Memo");
            _obj.MoneySpentID = GetInt32(reader, "MoneySpentID");
            _obj.Payee = GetString(reader, "Payee");
            _obj.PayeeLine1 = GetString(reader, "PayeeLine1");
            _obj.PayeeLine2 = GetString(reader, "PayeeLine2");
            _obj.PayeeLine3 = GetString(reader, "PayeeLine3");
            _obj.PayeeLine4 = GetString(reader, "PayeeLine4");
            _obj.PaymentDeliveryID = GetString(reader, "PaymentDeliveryID");
            _obj.PaymentStatusID = GetString(reader, "PaymentStatusID");
            _obj.StatementCode = GetString(reader, "StatementCode");
            _obj.StatementParticulars = GetString(reader, "StatementParticulars");
            _obj.StatementReference = GetString(reader, "StatementReference");
            _obj.StatementText = GetString(reader, "StatementText");
            _obj.TotalSpentAmount = GetDouble(reader, "TotalSpentAmount");
            _obj.TransactionExchangeRate = GetDouble(reader, "TransactionExchangeRate");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(MoneySpent _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["MoneySpentID"] = DbMgr.CreateAutoIntFieldEntry(_obj.MoneySpentID);
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["ChequeNumber"] = DbMgr.CreateStringFieldEntry(_obj.ChequeNumber);
            fields["CostCentreID"] = DbMgr.CreateIntFieldEntry(_obj.CostCentreID);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["Date"] = DbMgr.CreateDateTimeFieldEntry(_obj.Date);
            fields["IsAutoRecorded"] = DbMgr.CreateStringFieldEntry(_obj.IsAutoRecorded);
            fields["IsPrinted"] = DbMgr.CreateStringFieldEntry(_obj.IsPrinted);
            fields["IssuingAccountID"] = DbMgr.CreateIntFieldEntry(_obj.IssuingAccountID);
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive);
            fields["IsThirteenthPeriod"] = DbMgr.CreateStringFieldEntry(_obj.IsThirteenthPeriod);
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo);
            fields["Payee"] = DbMgr.CreateStringFieldEntry(_obj.Payee);
            fields["PayeeLine1"] = DbMgr.CreateStringFieldEntry(_obj.PayeeLine1);
            fields["PayeeLine2"] = DbMgr.CreateStringFieldEntry(_obj.PayeeLine2);
            fields["PayeeLine3"] = DbMgr.CreateStringFieldEntry(_obj.PayeeLine3);
            fields["PayeeLine4"] = DbMgr.CreateStringFieldEntry(_obj.PayeeLine4);
            fields["PaymentDeliveryID"] = DbMgr.CreateStringFieldEntry(_obj.PaymentDeliveryID);
            fields["PaymentStatusID"] = DbMgr.CreateStringFieldEntry(_obj.PaymentStatusID);
            fields["StatementCode"] = DbMgr.CreateStringFieldEntry(_obj.StatementCode);
            fields["StatementParticulars"] = DbMgr.CreateStringFieldEntry(_obj.StatementParticulars);
            fields["StatementReference"] = DbMgr.CreateStringFieldEntry(_obj.StatementReference);
            fields["StatementText"] = DbMgr.CreateStringFieldEntry(_obj.StatementText);
            fields["TotalSpentAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TotalSpentAmount);
            fields["TransactionDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.TransactionDate);
            fields["TransactionExchangeRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TransactionExchangeRate);

            return fields;
        }

        protected override object GetDbProperty(MoneySpent _obj, string property_name)
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
            else if (property_name.Equals("PaymentDelivery"))
            {
                return RepositoryMgr.InvoiceDeliveryMgr.FindById(_obj.PaymentDeliveryID);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause=DbMgr.CreateSelectClause();
            clause.SelectAll().From("MoneySpent");
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByMoneySpentID(int MoneySpentID)
        {
            DbSelectStatement clause=DbMgr.CreateSelectClause();
            clause.SelectAll()
                .From("MoneySpent")
                .Criteria
                    .IsEqual("MoneySpent", "MoneySpentID", MoneySpentID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByMoneySpentID(int MoneySpentID)
        {
            DbSelectStatement clause=DbMgr.CreateSelectClause();
            clause.SelectCount()
                .From("MoneySpent")
                .Criteria
                    .IsEqual("MoneySpent", "MoneySpentID", MoneySpentID);
            return clause;
        }

        public bool Exists(int? MoneySpentID)
        {
            if(MoneySpentID==null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByMoneySpentID(MoneySpentID.Value)) != 0;
        }

        public override bool  Exists(MoneySpent _obj)
        {
 	         if(_obj==null) return false;
            return Exists(_obj.MoneySpentID);
        }

        protected override IList<MoneySpent>_FindAllCollection()
        {
            List<MoneySpent> _grp = new List<MoneySpent>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                MoneySpent _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override MoneySpent _FindByIntId(int? MoneySpentID)
        {
            if (MoneySpentID == null) return null;

            MoneySpent _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByMoneySpentID(MoneySpentID.Value));
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

    }
}
