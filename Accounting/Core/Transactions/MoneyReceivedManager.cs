using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Transactions
{
    public abstract class MoneyReceivedManager : EntityManager<MoneyReceived>
    {
        public MoneyReceivedManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override MoneyReceived _CreateDbEntity()
        {
            return new MoneyReceived(true, this);
        }
        protected override MoneyReceived _CreateEntity()
        {
            return new MoneyReceived(false, this);
        }
        #endregion

        protected override void LoadFromReader(MoneyReceived _obj, DbDataReader reader)
        {
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.CostCentreID = GetInt32(reader, "CostCentreID");
            _obj.CurrencyID = GetInt32(reader, "CurrencyID");
            _obj.TransactionDate = GetDateTime(reader, "TransactionDate");
            _obj.Date = _obj.TransactionDate;
            _obj.IsAutoRecorded = GetString(reader, "IsAutoRecorded");
            _obj.IsTaxInclusive = GetString(reader, "IsTaxInclusive");
            _obj.IsThirteenthPeriod = GetString(reader, "IsThirteenthPeriod");
            _obj.Memo = GetString(reader, "Memo");
            _obj.MoneyReceivedID = GetInt32(reader, "MoneyReceivedID");
            _obj.TransactionExchangeRate = GetDouble(reader, "TransactionExchangeRate");
            _obj.DepositNumber = GetString(reader, "DepositNumber");
            _obj.DepositStatusID = GetString(reader, "DepositStatusID");
            _obj.MethodOfPaymentID = GetInt32(reader, "MethodOfPaymentID", "PaymentMethodID");
            _obj.PaymentAuthorisationNumber = GetString(reader, "PaymentAuthorisationNumber");
            _obj.PaymentBankAccountName = GetString(reader, "PaymentBankAccountName");
            _obj.PaymentBankAccountNumber = GetString(reader, "PaymentBankAccountNumber");
            _obj.PaymentBankBranch = GetString(reader, "PaymentBankBranch");
            _obj.PaymentBSB = GetString(reader, "PaymentBSB");
            _obj.PaymentCardNumber = GetString(reader, "PaymentCardNumber");
            _obj.PaymentChequeNumber = GetString(reader, "PaymentChequeNumber");
            _obj.PaymentExpirationDate = GetString(reader, "PaymentExpirationDate");
            _obj.PaymentNameOnCard = GetString(reader, "PaymentNameOnCard");
            _obj.PaymentNotes = GetString(reader, "PaymentNotes");
            _obj.RecipientAccountID = GetInt32(reader, "RecipientAccountID");
            
        }

        public override Dictionary<string, DbFieldEntry> GetFields(MoneyReceived _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["MoneyReceivedID"] = DbMgr.CreateAutoIntFieldEntry(_obj.MoneyReceivedID);
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["CostCentreID"] = DbMgr.CreateIntFieldEntry(_obj.CostCentreID);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["Date"] = DbMgr.CreateDateTimeFieldEntry(_obj.Date);
            fields["IsAutoRecorded"] = DbMgr.CreateStringFieldEntry(_obj.IsAutoRecorded);
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive);
            fields["IsThirteenthPeriod"] = DbMgr.CreateStringFieldEntry(_obj.IsThirteenthPeriod);
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo);
            fields["TransactionDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.TransactionDate);
            fields["TransactionExchangeRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TransactionExchangeRate);
            fields["DepositNumber"] = DbMgr.CreateStringFieldEntry(_obj.DepositNumber);
            fields["DepositStatusID"] = DbMgr.CreateStringFieldEntry(_obj.DepositStatusID);
            fields["MethodOfPaymentID"] = DbMgr.CreateIntFieldEntry(_obj.MethodOfPaymentID);
            fields["PaymentAuthorisationNumber"] = DbMgr.CreateStringFieldEntry(_obj.PaymentAuthorisationNumber);
            fields["PaymentBankAccountName"] = DbMgr.CreateStringFieldEntry(_obj.PaymentBankAccountName);
            fields["PaymentBankAccountNumber"] = DbMgr.CreateStringFieldEntry(_obj.PaymentBankAccountNumber);
            fields["PaymentBankBranch"] = DbMgr.CreateStringFieldEntry(_obj.PaymentBankBranch);
            fields["PaymentBSB"] = DbMgr.CreateStringFieldEntry(_obj.PaymentBSB);
            fields["PaymentCardNumber"] = DbMgr.CreateStringFieldEntry(_obj.PaymentCardNumber);
            fields["PaymentChequeNumber"] = DbMgr.CreateStringFieldEntry(_obj.PaymentChequeNumber);
            fields["PaymentExpirationDate"] = DbMgr.CreateStringFieldEntry(_obj.PaymentExpirationDate);
            fields["PaymentNameOnCard"] = DbMgr.CreateStringFieldEntry(_obj.PaymentNameOnCard);
            fields["PaymentNotes"] = DbMgr.CreateStringFieldEntry(_obj.PaymentNotes);
            fields["RecipientAccountID"] = DbMgr.CreateIntFieldEntry(_obj.RecipientAccountID); 

            return fields;
        }

        protected override object GetDbProperty(MoneyReceived _obj, string property_name)
        {
            if (property_name.Equals("Card"))
            {
                return RepositoryMgr.CardMgr.FindByCardId(_obj.CardRecordID, true);
            }
            else if (property_name.Equals("Currency"))
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name.Equals("RecipientAccount"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.RecipientAccountID);
            }
            else if (property_name.Equals("MethodOfPayment"))
            {
                return RepositoryMgr.PaymentMethodMgr.FindById(_obj.MethodOfPaymentID);
            }

            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause=DbMgr.CreateSelectClause();
            clause.SelectAll().From("MoneyReceived");
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByMoneyReceivedID(int MoneyReceivedID)
        {
            DbSelectStatement clause=DbMgr.CreateSelectClause();
            clause.SelectAll()
                .From("MoneyReceived")
                .Criteria
                    .IsEqual("MoneyReceived", "MoneyReceivedID", MoneyReceivedID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByMoneyReceivedID(int MoneyReceivedID)
        {
            DbSelectStatement clause=DbMgr.CreateSelectClause();
            clause.SelectCount()
                .From("MoneyReceived")
                .Criteria
                    .IsEqual("MoneyReceived", "MoneyReceivedID", MoneyReceivedID);
            return clause;
        }

        public bool Exists(int? MoneyReceivedID)
        {
            if(MoneyReceivedID==null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByMoneyReceivedID(MoneyReceivedID.Value)) != 0;
        }

        public override bool  Exists(MoneyReceived _obj)
        {
 	         if(_obj==null) return false;
            return Exists(_obj.MoneyReceivedID);
        }

        protected override IList<MoneyReceived>_FindAllCollection()
        {
            List<MoneyReceived> _grp = new List<MoneyReceived>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                MoneyReceived _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override MoneyReceived _FindByIntId(int? MoneyReceivedID)
        {
            if (MoneyReceivedID == null) return null;

            MoneyReceived _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByMoneyReceivedID(MoneyReceivedID.Value));
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
