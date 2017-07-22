using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Purchases
{
    public abstract class SupplierDiscountManager : EntityManager<SupplierDiscount>
    {
        public SupplierDiscountManager(DbManager mgr)
            : base(mgr)
        {
        }


        #region +(Factory Methods)
        protected override SupplierDiscount _CreateDbEntity()
        {
            return new SupplierDiscount(true, this);
        }
        protected override SupplierDiscount _CreateEntity()
        {
            return new SupplierDiscount(false, this);
        }
        #endregion

        protected override void LoadFromReader(SupplierDiscount _obj, DbDataReader reader)
        {
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.CurrencyID = GetInt32(reader, "CurrencyID");
            _obj.SupplierDiscountID = GetInt32(reader, "SupplierDiscountID");
            _obj.SupplierDiscountNumber = GetString(reader, "SupplierDiscountNumber");
            _obj.TransactionDate = GetDateTime(reader, "TransactionDate");
            _obj.Date = _obj.TransactionDate;
            _obj.ExchangeGainLoss = GetDouble(reader, "ExchangeGainLoss");
            _obj.IsTaxInclusive = GetString(reader, "IsTaxInclusive");
            _obj.IsThirteenthPeriod = GetString(reader, "IsThirteenthPeriod");
            _obj.Memo = GetString(reader, "Memo");
            _obj.DiscountAccountID = GetInt32(reader, "DiscountAccountID");
            _obj.TotalDiscount = GetDouble(reader, "TotalDiscount");
            _obj.TransactionExchangeRate = GetDouble(reader, "TransactionExchangeRate");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(SupplierDiscount _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["SupplierDiscountID"] = DbMgr.CreateAutoIntFieldEntry(_obj.SupplierDiscountID);
            fields["SupplierDiscountNumber"] = DbMgr.CreateStringFieldEntry(_obj.SupplierDiscountNumber);
            fields["TransactionDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.TransactionDate);
            fields["Date"] = DbMgr.CreateDateTimeFieldEntry(_obj.Date);
            fields["ExchangeGainLoss"] = DbMgr.CreateDoubleFieldEntry(_obj.ExchangeGainLoss);
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive);
            fields["IsThirteenthPeriod"] = DbMgr.CreateStringFieldEntry(_obj.IsThirteenthPeriod);
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo);
            fields["DiscountAccountID"] = DbMgr.CreateIntFieldEntry(_obj.DiscountAccountID);
            fields["TotalDiscount"] = DbMgr.CreateDoubleFieldEntry(_obj.TotalDiscount);
            fields["TransactionExchangeRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TransactionExchangeRate); 

            return fields;
        }

        protected override object GetDbProperty(SupplierDiscount _obj, string property_name)
        {
            if (property_name.Equals("Currency"))
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name.Equals("Card"))
            {
                return RepositoryMgr.CardMgr.FindByCardId(_obj.CardRecordID, true);
            }
            else if (property_name.Equals("DiscountAccount"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.DiscountAccountID);
            }
            
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll().From("SupplierDiscounts");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectBySupplierDiscountID(int? SupplierDiscountID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("SupplierDiscounts")
                .Criteria
                    .IsEqual("SupplierDiscounts", "SupplierDiscountID", SupplierDiscountID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountBySupplierDiscountID(int? SupplierDiscountID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("SupplierDiscounts")
                .Criteria
                    .IsEqual("SupplierDiscounts", "SupplierDiscountID", SupplierDiscountID);
            return clause;
        }

        public bool Exists(int? SupplierDiscountID)
        {
            if (SupplierDiscountID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountBySupplierDiscountID(SupplierDiscountID.Value)) != 0;
        }

        public override bool Exists(SupplierDiscount _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.SupplierDiscountID);
        }

        protected override SupplierDiscount _FindByIntId(int? SupplierDiscountID)
        {
            if (SupplierDiscountID == null) return null;

            SupplierDiscount _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectBySupplierDiscountID(SupplierDiscountID.Value));
            DbDataReader _reader = _cmd.ExecuteReader();
            if (_reader.Read())
            {
                _obj = SupplierDiscount.CreateDbSupplierDiscount(this);
                LoadFromReader(_obj, _reader);
            }
            _reader.Close();
            _cmd.Dispose();
            return _obj;
        }

        protected override IList<SupplierDiscount>_FindAllCollection()
        {
            List<SupplierDiscount> _grp = new List<SupplierDiscount>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                SupplierDiscount _obj = SupplierDiscount.CreateDbSupplierDiscount(this);
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
