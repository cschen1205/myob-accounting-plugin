using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Purchases
{
    public abstract class DebitRefundManager : EntityManager<DebitRefund>
    {
        public DebitRefundManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override DebitRefund _CreateDbEntity()
        {
            return new DebitRefund(true, this);
        }
        protected override DebitRefund _CreateEntity()
        {
            return new DebitRefund(false, this);
        }
        #endregion

        protected override void LoadFromReader(DebitRefund _obj, DbDataReader reader)
        {
            _obj.AmountRefunded = GetDouble(reader, "AmountRefunded");
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.DebitNoteID = GetInt32(reader, "DebitNoteID");
            _obj.DebitRefundID = GetInt32(reader, "DebitRefundID");
            _obj.CurrencyID = GetInt32(reader, "CurrencyID");
            _obj.TransactionDate = GetDateTime(reader, "TransactionDate");
            _obj.Date = _obj.TransactionDate;
            _obj.ExchangeGainLoss = GetDouble(reader, "ExchangeGainLoss");
            _obj.RecipientAccountID = GetInt32(reader, "RecipientAccountID");
            _obj.IsTaxInclusive = GetString(reader, "IsTaxInclusive");
            _obj.IsThirteenthPeriod = GetString(reader, "IsThirteenthPeriod");
            _obj.Memo = GetString(reader, "Memo");
            _obj.DepositStatusID = GetString(reader, "DepositStatusID");
            _obj.MethodOfPaymentID = GetInt32(reader, "MethodOfPaymentID", "PaymentMethodID");
            _obj.TransactionExchangeRate = GetDouble(reader, "TransactionExchangeRate");
            _obj.PaymentAuthorisationNumber = GetString(reader, "PaymentAuthorisationNumber");
            _obj.PaymentBankAccountName = GetString(reader, "PaymentBankAccountName");
            _obj.PaymentBankAccountNumber = GetString(reader, "PaymentBankAccountNumber");
            _obj.PaymentBSB = GetString(reader, "PaymentBSB");
            _obj.PaymentCardNumber = GetString(reader, "PaymentCardNumber");
            _obj.PaymentChequeNumber = GetString(reader, "PaymentChequeNumber");
            _obj.PaymentExpirationDate = GetString(reader, "PaymentExpirationDate");
            _obj.PaymentNameOnCard = GetString(reader, "PaymentNameOnCard");
            _obj.PaymentNotes = GetString(reader, "PaymentNotes");

        }

        public override Dictionary<string, DbFieldEntry> GetFields(DebitRefund _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["AmountRefunded"] = DbMgr.CreateDoubleFieldEntry(_obj.AmountRefunded); 
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID); 
            fields["DebitNoteID"] = DbMgr.CreateIntFieldEntry(_obj.DebitNoteID); 
            fields["DebitRefundID"] = DbMgr.CreateAutoIntFieldEntry(_obj.DebitRefundID); 
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID); 
            fields["TransactionDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.TransactionDate);
            fields["Date"] = DbMgr.CreateDateTimeFieldEntry(_obj.Date); 
            fields["ExchangeGainLoss"] = DbMgr.CreateDoubleFieldEntry(_obj.ExchangeGainLoss); 
            fields["MethodOfPaymentID"] = DbMgr.CreateIntFieldEntry(_obj.MethodOfPaymentID);
            fields["RecipientAccountID"] = DbMgr.CreateIntFieldEntry(_obj.RecipientAccountID); 
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive); 
            fields["IsThirteenthPeriod"] = DbMgr.CreateStringFieldEntry(_obj.IsThirteenthPeriod); 
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo); 
            fields["DepositStatusID"] = DbMgr.CreateStringFieldEntry(_obj.DepositStatusID); 
            fields["TransactionExchangeRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TransactionExchangeRate);
            fields["PaymentAuthorisationNumber"] = DbMgr.CreateStringFieldEntry(_obj.PaymentAuthorisationNumber);
            fields["PaymentBankAccountName"] = DbMgr.CreateStringFieldEntry(_obj.PaymentBankAccountName);
            fields["PaymentBankAccountNumber"] = DbMgr.CreateStringFieldEntry(_obj.PaymentBankAccountNumber);
            fields["PaymentBSB"] = DbMgr.CreateStringFieldEntry(_obj.PaymentBSB);
            fields["PaymentCardNumber"] = DbMgr.CreateStringFieldEntry(_obj.PaymentCardNumber);
            fields["PaymentChequeNumber"] = DbMgr.CreateStringFieldEntry(_obj.PaymentChequeNumber);
            fields["PaymentExpirationDate"] = DbMgr.CreateStringFieldEntry(_obj.PaymentExpirationDate);
            fields["PaymentNameOnCard"] = DbMgr.CreateStringFieldEntry(_obj.PaymentNameOnCard);
            fields["PaymentNotes"] = DbMgr.CreateStringFieldEntry(_obj.PaymentNotes);

            return fields;
        }

        protected override object GetDbProperty(DebitRefund _obj, string property_name)
        {

            if (property_name.Equals("Currency"))
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }

            else if (property_name.Equals("DepositStatus"))
            {
                return RepositoryMgr.DepositStatusMgr.FindById(_obj.DepositStatusID);
            }
            else if (property_name.Equals("Card"))
            {
                return RepositoryMgr.CardMgr.FindByCardId(_obj.CardRecordID, true);
            }
            else if (property_name.Equals("RecipientAccount"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.RecipientAccountID);
            }
            else if (property_name.Equals("DebitNote"))
            {
                return RepositoryMgr.PurchaseMgr.FindById(_obj.DebitNoteID);
            }
            return true;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("DebitRefunds");
        }

        private DbSelectStatement GetQuery_SelectByDebitRefundID(int DebitRefundID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("DebitRefunds")
                .Criteria
                    .IsEqual("DebitRefunds", "DebitRefundID", DebitRefundID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByDebitRefundID(int DebitRefundID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("DebitRefunds")
                .Criteria
                    .IsEqual("DebitRefunds", "DebitRefundID", DebitRefundID);
            return clause;
        }

        public bool Exists(int? DebitRefundID)
        {
            if (DebitRefundID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByDebitRefundID(DebitRefundID.Value)) != 0;
        }

        public override bool Exists(DebitRefund _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.DebitRefundID);
        }

        protected override DebitRefund _FindByIntId(int? DebitRefundID)
        {
            if (DebitRefundID == null) return null;
            DebitRefund _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByDebitRefundID(DebitRefundID.Value));
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

        protected override IList<DebitRefund>_FindAllCollection()
        {
            List<DebitRefund> _grp = new List<DebitRefund>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                DebitRefund _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

    }
}
