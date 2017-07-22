using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Sales
{
    public abstract class CustomerDepositManager : EntityManager<CustomerDeposit>
    {
        public CustomerDepositManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override CustomerDeposit _CreateDbEntity()
        {
            return new CustomerDeposit(true, this);
        }
        protected override CustomerDeposit _CreateEntity()
        {
            return new CustomerDeposit(false, this);
        }
        #endregion

        protected override void LoadFromReader(CustomerDeposit _obj, DbDataReader reader)
        {
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.CurrencyID = GetInt32(reader, "CurrencyID");
            _obj.CustomerDepositID = GetInt32(reader, "CustomerDepositID");
            _obj.CustomerDepositNumber = GetString(reader, "CustomerDepositNumber");
            _obj.CustomerDepositsAccountID = GetInt32(reader, "CustomerDepositsAccountID");
            _obj.TransactionDate = GetDateTime(reader, "TransactionDate");
            _obj.Date = _obj.TransactionDate;
            _obj.DepositApplied = GetDouble(reader, "DepositApplied");
            _obj.ExchangeGainLoss = GetDouble(reader, "ExchangeGainLoss");
            _obj.IsTaxInclusive = GetString(reader, "IsTaxInclusive");
            _obj.IsThirteenthPeriod = GetString(reader, "IsThirteenthPeriod");
            _obj.Memo = GetString(reader, "Memo");
            _obj.SaleID = GetInt32(reader, "SaleID");
            _obj.TransactionExchangeRate = GetDouble(reader, "TransactionExchangeRate");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(CustomerDeposit _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID); 
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["CustomerDepositID"] = DbMgr.CreateAutoIntFieldEntry(_obj.CustomerDepositID); 
            fields["CustomerDepositNumber"] = DbMgr.CreateStringFieldEntry(_obj.CustomerDepositNumber); 
            fields["CustomerDepositsAccountID"] = DbMgr.CreateIntFieldEntry(_obj.CustomerDepositsAccountID); 
            fields["TransactionDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.TransactionDate); 
            fields["Date"] = DbMgr.CreateDateTimeFieldEntry(_obj.Date); 
            fields["DepositApplied"] = DbMgr.CreateDoubleFieldEntry(_obj.DepositApplied); 
            fields["ExchangeGainLoss"] = DbMgr.CreateDoubleFieldEntry(_obj.ExchangeGainLoss); 
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive); 
            fields["IsThirteenthPeriod"] = DbMgr.CreateStringFieldEntry(_obj.IsThirteenthPeriod); 
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo); 
            fields["SaleID"] = DbMgr.CreateIntFieldEntry(_obj.SaleID);
            fields["TransactionExchangeRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TransactionExchangeRate);

            return fields;
        }

        protected override object GetDbProperty(CustomerDeposit _obj, string property_name)
        {
            if (property_name.Equals("Card"))
            {
                return RepositoryMgr.CardMgr.FindByCardId(_obj.CardRecordID, true);
            }
            else if (property_name.Equals("Sale"))
            {
                return RepositoryMgr.SaleMgr.FindById(_obj.SaleID);
            }
            else if (property_name.Equals("Currency"))
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name.Equals("CustomerDepositsAccount"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.CustomerDepositsAccountID);
            }
            return null;

        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll().From("CustomerDeposits");
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByCustomerDepositID(int CustomerDepositID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("CustomerDeposits")
                .Criteria
                    .IsEqual("CustomerDeposits", "CustomerDepositID", CustomerDepositID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByCustomerDepositID(int CustomerDepositID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("CustomerDeposits")
                .Criteria
                    .IsEqual("CustomerDeposits", "CustomerDepositID", CustomerDepositID);
            return clause;
        }

        public bool Exists(int? CustomerDepositID)
        {
            if (CustomerDepositID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByCustomerDepositID(CustomerDepositID.Value)) != 0;
        }

        public override bool Exists(CustomerDeposit _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.CustomerDepositID);
        }

        protected override CustomerDeposit _FindByIntId(int? CustomerDepositID)
        {
            if (CustomerDepositID == null) return null;

            CustomerDeposit _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByCustomerDepositID(CustomerDepositID.Value));
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

        protected override IList<CustomerDeposit>_FindAllCollection()
        {
            List<CustomerDeposit> _grp = new List<CustomerDeposit>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                CustomerDeposit _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

    }
}
