using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Inventory
{
    public abstract class ItemPurchasesHistoryManager : EntityManager<ItemPurchasesHistory>
    {
        public ItemPurchasesHistoryManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override ItemPurchasesHistory _CreateDbEntity()
        {
            return new ItemPurchasesHistory(true, this);
        }
        protected override ItemPurchasesHistory _CreateEntity()
        {
            return new ItemPurchasesHistory(false, this);
        }
        #endregion

        protected override void LoadFromReader(ItemPurchasesHistory _obj, DbDataReader reader)
        {
            _obj.ItemPurchasesHistoryID = GetInt32(reader, "ItemPurchasesHistoryID");
            _obj.ItemID = GetInt32(reader, "ItemID");
            _obj.FinancialYear = GetInt32(reader, "FinancialYear");
            _obj.Period = GetInt32(reader, "Period");
            _obj.UnitsBought = GetDouble(reader, "UnitsBought");
            _obj.PurchaseAmount = GetDouble(reader, "PurchaseAmount");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(ItemPurchasesHistory _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["ItemPurchasesHistoryID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ItemPurchasesHistoryID); //GetInt32(reader, "");
            fields["ItemID"] = DbMgr.CreateIntFieldEntry(_obj.ItemID); //GetInt32(reader, "");
            fields["FinancialYear"] = DbMgr.CreateIntFieldEntry(_obj.FinancialYear); //GetInt32(reader, "");
            fields["Period"] = DbMgr.CreateIntFieldEntry(_obj.Period); //GetInt32(reader, "");
            fields["UnitsBought"] = DbMgr.CreateDoubleFieldEntry(_obj.UnitsBought); //GetDouble(reader, "");
            fields["PurchaseAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.PurchaseAmount); //GetDouble(reader, "");
            

            return fields;
        }

        protected override object GetDbProperty(ItemPurchasesHistory _obj, string property_name)
        {
            if (property_name.Equals("Item"))
            {
                return RepositoryMgr.ItemMgr.FindById(_obj.ItemID);
            }

            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("ItemPurchasesHistory");
        }

        private DbSelectStatement GetQuery_SelectByItemPurchasesHistoryID(int ItemPurchasesHistoryID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ItemPurchasesHistory")
                .Criteria
                    .IsEqual("ItemPurchasesHistory", "ItemPurchasesHistoryID", ItemPurchasesHistoryID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByItemPurchasesHistoryID(int ItemPurchasesHistoryID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("ItemPurchasesHistory")
                .Criteria
                    .IsEqual("ItemPurchasesHistory", "ItemPurchasesHistoryID", ItemPurchasesHistoryID);

            return clause;
        }

        public bool Exists(int? ItemPurchasesHistoryID)
        {
            if (ItemPurchasesHistoryID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByItemPurchasesHistoryID(ItemPurchasesHistoryID.Value)) != 0;
        }

        public override bool Exists(ItemPurchasesHistory _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.ItemPurchasesHistoryID);
        }

        protected override ItemPurchasesHistory _FindByIntId(int? ItemPurchasesHistoryID)
        {
            if (ItemPurchasesHistoryID == null) return null;

            ItemPurchasesHistory _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByItemPurchasesHistoryID(ItemPurchasesHistoryID.Value));
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

        protected override IList<ItemPurchasesHistory>_FindAllCollection()
        {
            List<ItemPurchasesHistory> _grp = new List<ItemPurchasesHistory>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                ItemPurchasesHistory _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        public List<ItemPurchasesHistory> List(int? ItemID, int? year_from, int? year_to)
        {
            List<ItemPurchasesHistory> _grp = new List<ItemPurchasesHistory>();

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll()
                .From("ItemPurchasesHistory")
                .Criteria
                    .IsEqual("ItemPurchasesHistory", "ItemID", ItemID)
                    .IsGreaterEqual("ItemPurchasesHistory", "FinancialYear", year_from)
                    .IsLessEqual("ItemPurchasesHistory", "FinancialYear", year_to)
                    ;

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                ItemPurchasesHistory _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
