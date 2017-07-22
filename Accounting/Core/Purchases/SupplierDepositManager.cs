using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Purchases
{
    public abstract class SupplierDepositManager : EntityManager<SupplierDeposit>
    {
        public SupplierDepositManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override SupplierDeposit _CreateDbEntity()
        {
            return new SupplierDeposit(true, this);
        }
        protected override SupplierDeposit _CreateEntity()
        {
            return new SupplierDeposit(false, this);
        }
        #endregion

        protected override void LoadFromReader(SupplierDeposit _obj, DbDataReader reader)
        {
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.CurrencyID = GetInt32(reader, "CurrencyID");
            _obj.SupplierDepositID = GetInt32(reader, "SupplierDepositID");
            _obj.SupplierDepositNumber = GetString(reader, "SupplierDepositNumber");
            _obj.SupplierDepositsAccountID = GetInt32(reader, "SupplierDepositsAccountID");
            _obj.TransactionDate = GetDateTime(reader, "TransactionDate");
            _obj.Date = _obj.TransactionDate;
            _obj.DepositApplied = GetDouble(reader, "DepositApplied");
            _obj.ExchangeGainLoss = GetDouble(reader, "ExchangeGainLoss");
            _obj.IsTaxInclusive = GetString(reader, "IsTaxInclusive");
            _obj.IsThirteenthPeriod = GetString(reader, "IsThirteenthPeriod");
            _obj.Memo = GetString(reader, "Memo");
            _obj.PurchaseID = GetInt32(reader, "PurchaseID");
            _obj.TransactionExchangeRate = GetDouble(reader, "TransactionExchangeRate");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(SupplierDeposit _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID); 
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["SupplierDepositID"] = DbMgr.CreateAutoIntFieldEntry(_obj.SupplierDepositID); 
            fields["SupplierDepositNumber"] = DbMgr.CreateStringFieldEntry(_obj.SupplierDepositNumber); 
            fields["SupplierDepositsAccountID"] = DbMgr.CreateIntFieldEntry(_obj.SupplierDepositsAccountID); 
            fields["TransactionDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.TransactionDate); 
            fields["Date"] = DbMgr.CreateDateTimeFieldEntry(_obj.Date); 
            fields["DepositApplied"] = DbMgr.CreateDoubleFieldEntry(_obj.DepositApplied); 
            fields["ExchangeGainLoss"] = DbMgr.CreateDoubleFieldEntry(_obj.ExchangeGainLoss); 
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive); 
            fields["IsThirteenthPeriod"] = DbMgr.CreateStringFieldEntry(_obj.IsThirteenthPeriod); 
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo); 
            fields["PurchaseID"] = DbMgr.CreateIntFieldEntry(_obj.PurchaseID);
            fields["TransactionExchangeRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TransactionExchangeRate);

            return fields;
        }

        protected override object GetDbProperty(SupplierDeposit _obj, string property_name)
        {
            if (property_name.Equals("Card"))
            {
                return RepositoryMgr.CardMgr.FindByCardId(_obj.CardRecordID, true);
            }
            else if (property_name.Equals("Purchase"))
            {
                return RepositoryMgr.PurchaseMgr.FindById(_obj.PurchaseID);
            }
            else if (property_name.Equals("Currency"))
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name.Equals("SupplierDepositsAccount"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.SupplierDepositsAccountID);
            }
            return null;

        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll().From("SupplierDeposits");
            return clause;
        }

        private DbSelectStatement GetQuery_SelectBySupplierDepositID(int SupplierDepositID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("SupplierDeposits")
                .Criteria
                    .IsEqual("SupplierDeposits", "SupplierDepositID", SupplierDepositID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountBySupplierDepositID(int SupplierDepositID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("SupplierDeposits")
                .Criteria
                    .IsEqual("SupplierDeposits", "SupplierDepositID", SupplierDepositID);
            return clause;
        }

        public bool Exists(int? SupplierDepositID)
        {
            if (SupplierDepositID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountBySupplierDepositID(SupplierDepositID.Value)) != 0;
        }

        public override bool Exists(SupplierDeposit _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.SupplierDepositID);
        }

        protected override SupplierDeposit _FindByIntId(int? SupplierDepositID)
        {
            if (SupplierDepositID == null) return null;

            SupplierDeposit _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectBySupplierDepositID(SupplierDepositID.Value));
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

        protected override IList<SupplierDeposit>_FindAllCollection()
        {
            List<SupplierDeposit> _grp = new List<SupplierDeposit>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                SupplierDeposit _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

    }
}
