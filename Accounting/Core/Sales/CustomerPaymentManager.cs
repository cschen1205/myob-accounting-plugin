using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Sales
{
    public abstract class CustomerPaymentManager : EntityManager<CustomerPayment>
    {
        public CustomerPaymentManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override CustomerPayment _CreateDbEntity()
        {
            return new CustomerPayment(true, this);
        }
        protected override CustomerPayment _CreateEntity()
        {
            return new CustomerPayment(false, this);
        }
        #endregion

        protected override void LoadFromReader(CustomerPayment _obj, DbDataReader reader)
        {
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.CurrencyID = GetInt32(reader, "CurrencyID");
            _obj.CustomerPaymentID = GetInt32(reader, "CustomerPaymentID");
            _obj.CustomerPaymentNumber = GetString(reader, "CustomerPaymentNumber");
            _obj.TransactionDate = GetDateTime(reader, "TransactionDate");
            _obj.Date = _obj.TransactionDate;
            _obj.DepositStatusID = GetString(reader, "DepositStatusID");
            _obj.ExchangeGainLoss = GetDouble(reader, "ExchangeGainLoss");
            _obj.FinanceCharge = GetDouble(reader, "FinanceCharge");
            _obj.IsTaxInclusive = GetString(reader, "IsTaxInclusive");
            _obj.IsThirteenthPeriod = GetString(reader, "IsThirteenthPeriod");
            _obj.Memo = GetString(reader, "Memo");
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
            _obj.TotalCustomerPayment = GetDouble(reader, "TotalCustomerPayment");
            _obj.TransactionExchangeRate = GetDouble(reader, "TransactionExchangeRate");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(CustomerPayment _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["CustomerPaymentID"] = DbMgr.CreateAutoIntFieldEntry(_obj.CustomerPaymentID);
            fields["CustomerPaymentNumber"] = DbMgr.CreateStringFieldEntry(_obj.CustomerPaymentNumber);
            fields["TransactionDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.TransactionDate);
            fields["Date"] = DbMgr.CreateDateTimeFieldEntry(_obj.Date);
            fields["DepositStatusID"] = DbMgr.CreateStringFieldEntry(_obj.DepositStatusID);
            fields["ExchangeGainLoss"] = DbMgr.CreateDoubleFieldEntry(_obj.ExchangeGainLoss);
            fields["FinanceCharge"] = DbMgr.CreateDoubleFieldEntry(_obj.FinanceCharge);
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive);
            fields["IsThirteenthPeriod"] = DbMgr.CreateStringFieldEntry(_obj.IsThirteenthPeriod);
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo);
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
            fields["TotalCustomerPayment"] = DbMgr.CreateDoubleFieldEntry(_obj.TotalCustomerPayment);
            fields["TransactionExchangeRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TransactionExchangeRate); 

            return fields;
        }

        protected override object GetDbProperty(CustomerPayment _obj, string property_name)
        {
            if (property_name.Equals("Currency"))
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name.Equals("Card"))
            {
                return RepositoryMgr.CardMgr.FindByCardId(_obj.CardRecordID, true);
            }
            else if (property_name.Equals("DepositStatus"))
            {
                return RepositoryMgr.DepositStatusMgr.FindById(_obj.DepositStatusID);
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
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll().From("CustomerPayments");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByCustomerPaymentID(int? CustomerPaymentID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("CustomerPayments")
                .Criteria
                    .IsEqual("CustomerPayments", "CustomerPaymentID", CustomerPaymentID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByCustomerPaymentID(int? CustomerPaymentID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("CustomerPayments")
                .Criteria
                    .IsEqual("CustomerPayments", "CustomerPaymentID", CustomerPaymentID);
            return clause;
        }

        public bool Exists(int? CustomerPaymentID)
        {
            if (CustomerPaymentID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByCustomerPaymentID(CustomerPaymentID.Value)) != 0;
        }

        public override bool Exists(CustomerPayment _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.CustomerPaymentID);
        }

        protected override CustomerPayment _FindByIntId(int? CustomerPaymentID)
        {
            if (CustomerPaymentID == null) return null;

            CustomerPayment _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByCustomerPaymentID(CustomerPaymentID.Value));
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

        protected override IList<CustomerPayment>_FindAllCollection()
        {
            List<CustomerPayment> _grp = new List<CustomerPayment>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                CustomerPayment _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
