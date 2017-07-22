using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Transactions
{
    public class BankDepositManager : EntityManager<BankDeposit>
    {
        public BankDepositManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override BankDeposit _CreateDbEntity()
        {
            return new BankDeposit(true, this);
        }
        protected override BankDeposit _CreateEntity()
        {
            return new BankDeposit(false, this);
        }
        #endregion

        protected override void LoadFromReader(BankDeposit _obj, DbDataReader reader)
        {
            _obj.AmountDeposited = GetDouble(reader, "AmountDeposited");
            _obj.BankDepositID = GetInt32(reader, "BankDepositID");
            _obj.BankDepositNumber = GetString(reader, "BankDepositNumber");
            _obj.CurrencyID = GetInt32(reader, "CurrencyID");
            _obj.TransactionDate = GetDateTime(reader, "TransactionDate");
            _obj.Date = _obj.TransactionDate;
            _obj.IsTaxInclusive = GetString(reader, "IsTaxInclusive");
            _obj.IsThirteenthPeriod = GetString(reader, "IsThirteenthPeriod");
            _obj.Memo = GetString(reader, "Memo");
            _obj.RecipientAccountID = GetInt32(reader, "RecipientAccountID");
            _obj.TransactionExchangeRate = GetDouble(reader, "TransactionExchangeRate");
            
        }

        protected override object GetDbProperty(BankDeposit _obj, string property_name)
        {
            if (property_name.Equals("Currency"))
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name.Equals("RecipientAccount"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.RecipientAccountID);
            }
            return null;
        }

        public override Dictionary<string, DbFieldEntry> GetFields(BankDeposit _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["AmountDeposited"] = DbMgr.CreateDoubleFieldEntry(_obj.AmountDeposited); //GetDouble(reader, "AmountDeposited");
            fields["BankDepositID"] = DbMgr.CreateAutoIntFieldEntry(_obj.BankDepositID); //GetInt32(reader, "BankDepositID");
            fields["BankDepositNumber"] = DbMgr.CreateStringFieldEntry(_obj.BankDepositNumber); //GetString(reader, "BankDepositNumber");
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID); //GetInt32(reader, "CurrencyID");
            fields["TransactionDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.TransactionDate); //GetDateTime(reader, "TransactionDate");
            fields["Date"] = DbMgr.CreateDateTimeFieldEntry(_obj.Date); //fields[""]=DbMgr.CreateIntFieldEntry(_obj.TransactionDate;
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive); //GetString(reader, "IsTaxInclusive");
            fields["IsThirteenthPeriod"] = DbMgr.CreateStringFieldEntry(_obj.IsThirteenthPeriod); //GetString(reader, "IsThirteenthPeriod");
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo); //GetString(reader, "Memo");
            fields["RecipientAccountID"] = DbMgr.CreateIntFieldEntry(_obj.RecipientAccountID); //GetInt32(reader, "RecipientAccountID");
            fields["TransactionExchangeRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TransactionExchangeRate); //GetDouble(reader, "TransactionExchangeRate");
            

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("BankDeposits");
        }

        private DbSelectStatement GetQuery_SelectByBankDepositID(int BankDepositID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("BankDeposits")
                .Criteria
                    .IsEqual("BankDeposits", "BankDepositID", BankDepositID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByBankDepositID(int BankDepositID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("BankDeposits")
                .Criteria
                    .IsEqual("BankDeposits", "BankDepositID", BankDepositID);

            return clause;
        }

        public bool Exists(int? BankDepositID)
        {
            if (BankDepositID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByBankDepositID(BankDepositID.Value)) != 0;
        }

        public override bool Exists(BankDeposit _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.BankDepositID);
        }

        protected override BankDeposit _FindByIntId(int? BankDepositID)
        {
            if (BankDepositID == null) return null;
            BankDeposit _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByBankDepositID(BankDepositID.Value));
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

        protected override IList<BankDeposit>_FindAllCollection()
        {
            List<BankDeposit> _grp = new List<BankDeposit>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                BankDeposit _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
