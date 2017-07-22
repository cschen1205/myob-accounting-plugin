using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Inventory
{
    using System.ComponentModel;
    public abstract class InventoryAdjustmentManager : EntityManager<InventoryAdjustment>
    {
        public InventoryAdjustmentManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override InventoryAdjustment _CreateDbEntity()
        {
            return new InventoryAdjustment(true, this);
        }
        protected override InventoryAdjustment _CreateEntity()
        {
            return new InventoryAdjustment(false, this);
        }
        #endregion

        protected override void LoadFromReader(InventoryAdjustment _obj, DbDataReader reader)
        {
            _obj.CostCentreID = GetInt32(reader, "CostCentreID");
            _obj.CurrencyID = GetInt32(reader, "CurrencyID");
            _obj.TransactionDate = GetDateTime(reader, "TransactionDate");
            if (_obj.TransactionDate != null)
            {
                _obj.Date = _obj.TransactionDate;
            }
            else
            {
                _obj.TransactionDate = GetDateTime(reader, "Date");
            }
            _obj.InventoryAdjustmentID = GetInt32(reader, "InventoryAdjustmentID");
            _obj.InventoryJournalNumber = GetString(reader, "InventoryJournalNumber");
            _obj.IsTaxInclusive = GetString(reader, "IsTaxInclusive");
            _obj.IsThirteenthPeriod = GetString(reader, "IsThirteenthPeriod");
            _obj.Memo = GetString(reader, "Memo");
            _obj.TransactionExchangeRate = GetDouble(reader, "TransactionExchangeRate");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(InventoryAdjustment _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["CostCentreID"] = DbMgr.CreateIntFieldEntry(_obj.CostCentreID);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["TransactionDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.TransactionDate);
            fields["Date"] = DbMgr.CreateDateTimeFieldEntry(_obj.Date);
            fields["InventoryAdjustmentID"] = DbMgr.CreateAutoIntFieldEntry(_obj.InventoryAdjustmentID);
            fields["InventoryJournalNumber"] = DbMgr.CreateStringFieldEntry(_obj.InventoryJournalNumber);
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive);
            fields["IsThirteenthPeriod"] = DbMgr.CreateStringFieldEntry(_obj.IsThirteenthPeriod);
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo);
            fields["TransactionExchangeRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TransactionExchangeRate); 

            return fields;
        }

        protected override object GetDbProperty(InventoryAdjustment _obj, string property_name)
        {
            if (property_name.Equals("Currency"))
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("InventoryAdjustments");
        }

        private DbSelectStatement GetQuery_SelectByInventoryAdjustmentID(int InventoryAdjustmentID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("InventoryAdjustments")
                .Criteria
                    .IsEqual("InventoryAdjustments", "InventoryAdjustmentID", InventoryAdjustmentID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByInventoryJournalNumber(string InventoryJournalNumber)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("InventoryAdjustments")
                .Criteria
                    .IsEqual("InventoryAdjustments", "InventoryJournalNumber", InventoryJournalNumber);
            return clause;
        }

        

        private DbSelectStatement GetQuery_SelectCountByInventoryAdjustmentID(int InventoryAdjustmentID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("InventoryAdjustments")
                .Criteria
                    .IsEqual("InventoryAdjustments", "InventoryAdjustmentID", InventoryAdjustmentID);
            return clause;
        }

        public bool Exists(int? InventoryAdjustmentID)
        {
            if (InventoryAdjustmentID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByInventoryAdjustmentID(InventoryAdjustmentID.Value)) != 0;
        }

        public override bool Exists(InventoryAdjustment _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.InventoryAdjustmentID);
        }

        protected override InventoryAdjustment _FindByIntId(int? InventoryAdjustmentID)
        {
            InventoryAdjustment _obj = null;
            if (InventoryAdjustmentID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByInventoryAdjustmentID(InventoryAdjustmentID.Value));
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

        protected override IList<InventoryAdjustment>_FindAllCollection()
        {
            List<InventoryAdjustment> _grp = new List<InventoryAdjustment>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                InventoryAdjustment _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        public bool ExistsByInventoryJournalNumber(string InventoryJournalNumber)
        {
            if (string.IsNullOrEmpty(InventoryJournalNumber)) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByInventoryJournalNumber(InventoryJournalNumber)) != 0;
        }

        public IList<InventoryAdjustment> FindFilteredInventoryAdjustmentCollection(DateTime? start, DateTime? end, Item _item)
        {
            if (UseMemoryStore)
            {
                IList<InventoryAdjustment> store = DataStore;
                var result = from s in store
                             where s.Match(start, end) && s.IsHandlingItem(_item)
                             select s;
                return new BindingList<InventoryAdjustment>(result.ToList());
            }

            return _FindFilteredInventoryAdjustmentCollection(start, end, _item);
        }

        private IList<InventoryAdjustment> _FindFilteredInventoryAdjustmentCollection(DateTime? start, DateTime? end, Item _item)
        {
            DbCriteria criteria = CreateCriteria();
            criteria
                .IsGreaterEqual("InventoryAdjustments", "TransactionDate", start)
                .IsLessEqual("InventoryAdjustments", "TransactionDate", end);


            Currencies.CurrencyManager cm = RepositoryMgr.CurrencyMgr;
            bool support_multi_currency = cm.SupportMultiCurrency;
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                    .SelectAll()
                    .From("InventoryAdjustments")
                    .OrderBy("InventoryAdjustments", "TransactionDate", "ASC")
                    .Criteria.And(criteria);



            BindingList<InventoryAdjustment> purchases = new BindingList<InventoryAdjustment>();

            Dictionary<int, int> currencyIds = new Dictionary<int, int>();

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                InventoryAdjustment _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                if (_obj.IsHandlingItem(_item))
                {
                    purchases.Add(_obj);
                }
            }
            _reader.Close();
            _cmd.Dispose();

            return purchases;
        }
    }
}
