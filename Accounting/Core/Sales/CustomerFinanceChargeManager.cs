using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Sales
{
    public abstract class CustomerFinanceChargeManager : EntityManager<CustomerFinanceCharge>
    {
        public CustomerFinanceChargeManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override CustomerFinanceCharge _CreateDbEntity()
        {
            return new CustomerFinanceCharge(true, this);
        }
        protected override CustomerFinanceCharge _CreateEntity()
        {
            return new CustomerFinanceCharge(false, this);
        }
        #endregion

        protected override void LoadFromReader(CustomerFinanceCharge _obj, DbDataReader reader)
        {
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.CurrencyID = GetInt32(reader, "CurrencyID");
            _obj.CustomerFinanceChargeID = GetInt32(reader, "CustomerFinanceChargeID");
            _obj.CustomerFinanceChargeNumber = GetString(reader, "CustomerFinanceChargeNumber");
            _obj.TransactionDate = GetDateTime(reader, "TransactionDate");
            _obj.Date = _obj.TransactionDate;
            _obj.ExchangeGainLoss = GetDouble(reader, "ExchangeGainLoss");
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
            _obj.LateChargesAccountID = GetInt32(reader, "LateChargesAccountID");
            _obj.FinanceCharge = GetDouble(reader, "FinanceCharge");
            _obj.TransactionExchangeRate = GetDouble(reader, "TransactionExchangeRate");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(CustomerFinanceCharge _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["CustomerFinanceChargeID"] = DbMgr.CreateAutoIntFieldEntry(_obj.CustomerFinanceChargeID);
            fields["CustomerFinanceChargeNumber"] = DbMgr.CreateStringFieldEntry(_obj.CustomerFinanceChargeNumber);
            fields["TransactionDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.TransactionDate);
            fields["Date"] = DbMgr.CreateDateTimeFieldEntry(_obj.Date);
            fields["ExchangeGainLoss"] = DbMgr.CreateDoubleFieldEntry(_obj.ExchangeGainLoss);
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
            fields["LateChargesAccountID"] = DbMgr.CreateIntFieldEntry(_obj.LateChargesAccountID);
            fields["FinanceCharge"] = DbMgr.CreateDoubleFieldEntry(_obj.FinanceCharge);
            fields["TransactionExchangeRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TransactionExchangeRate); 

            return fields;
        }

        protected override object GetDbProperty(CustomerFinanceCharge _obj, string property_name)
        {
            if (property_name.Equals("Currency"))
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name.Equals("Card"))
            {
                return RepositoryMgr.CardMgr.FindByCardId(_obj.CardRecordID, true);
            }
            else if (property_name.Equals("LateChargesAccount"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.LateChargesAccountID);
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
            clause.SelectAll().From("CustomerFinanceCharges");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByCustomerFinanceChargeID(int? CustomerFinanceChargeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("CustomerFinanceCharges")
                .Criteria
                    .IsEqual("CustomerFinanceCharges", "CustomerFinanceChargeID", CustomerFinanceChargeID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByCustomerFinanceChargeID(int? CustomerFinanceChargeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("CustomerFinanceCharges")
                .Criteria
                    .IsEqual("CustomerFinanceCharges", "CustomerFinanceChargeID", CustomerFinanceChargeID);
            return clause;
        }

        public bool Exists(int? CustomerFinanceChargeID)
        {
            if (CustomerFinanceChargeID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByCustomerFinanceChargeID(CustomerFinanceChargeID.Value)) != 0;
        }

        public override bool Exists(CustomerFinanceCharge _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.CustomerFinanceChargeID);
        }

        protected override CustomerFinanceCharge _FindByIntId(int? CustomerFinanceChargeID)
        {
            if (CustomerFinanceChargeID == null) return null;

            CustomerFinanceCharge _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByCustomerFinanceChargeID(CustomerFinanceChargeID.Value));
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

        protected override IList<CustomerFinanceCharge>_FindAllCollection()
        {
            List<CustomerFinanceCharge> _grp = new List<CustomerFinanceCharge>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                CustomerFinanceCharge _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
