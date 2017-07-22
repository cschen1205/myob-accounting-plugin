using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Inventory
{
    public abstract class ItemSalesHistoryManager : EntityManager<ItemSalesHistory>
    {
        public ItemSalesHistoryManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override ItemSalesHistory _CreateDbEntity()
        {
            return new ItemSalesHistory(true, this);
        }
        protected override ItemSalesHistory _CreateEntity()
        {
            return new ItemSalesHistory(false, this);
        }
        #endregion

        protected override void LoadFromReader(ItemSalesHistory _obj, DbDataReader reader)
        {
            _obj.ItemSalesHistoryID = GetInt32(reader, "ItemSalesHistoryID");
            _obj.ItemID = GetInt32(reader, "ItemID");
            _obj.FinancialYear = GetInt32(reader, "FinancialYear");
            _obj.Period = GetInt32(reader, "Period");
            _obj.UnitsSold = GetDouble(reader, "UnitsSold");
            _obj.SaleAmount = GetDouble(reader, "SaleAmount");
            _obj.CostOfSalesAmount = GetDouble(reader, "CostOfSalesAmount");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(ItemSalesHistory _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["ItemSalesHistoryID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ItemSalesHistoryID); //GetInt32(reader, "");
            fields["ItemID"] = DbMgr.CreateIntFieldEntry(_obj.ItemID); //GetInt32(reader, "");
            fields["FinancialYear"] = DbMgr.CreateIntFieldEntry(_obj.FinancialYear); //GetInt32(reader, "");
            fields["Period"] = DbMgr.CreateIntFieldEntry(_obj.Period); //GetInt32(reader, "");
            fields["UnitsSold"] = DbMgr.CreateDoubleFieldEntry(_obj.UnitsSold); //GetDouble(reader, "");
            fields["SaleAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.SaleAmount); //GetDouble(reader, "");
            fields["CostOfSalesAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.CostOfSalesAmount); //GetDouble(reader, "");

            return fields;
        }

        protected override object GetDbProperty(ItemSalesHistory _obj, string property_name)
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
            return clause.SelectAll().From("ItemSalesHistory");
        }

        private DbSelectStatement GetQuery_SelectByItemSalesHistoryID(int ItemSalesHistoryID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ItemSalesHistory")
                .Criteria
                    .IsEqual("ItemSalesHistory", "ItemSalesHistoryID", ItemSalesHistoryID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByItemSalesHistoryID(int ItemSalesHistoryID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("ItemSalesHistory")
                .Criteria
                    .IsEqual("ItemSalesHistory", "ItemSalesHistoryID", ItemSalesHistoryID);

            return clause;
        }

        public bool Exists(int? ItemSalesHistoryID)
        {
            if (ItemSalesHistoryID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByItemSalesHistoryID(ItemSalesHistoryID.Value)) != 0;
        }

        public override bool Exists(ItemSalesHistory _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.ItemSalesHistoryID);
        }

        protected override ItemSalesHistory _FindByIntId(int? ItemSalesHistoryID)
        {
            if (ItemSalesHistoryID == null) return null;

            ItemSalesHistory _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByItemSalesHistoryID(ItemSalesHistoryID.Value));
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

        public List<ItemSalesHistory> List(int? ItemID, int? year_from, int? year_to)
        {
            List<ItemSalesHistory> _grp = new List<ItemSalesHistory>();

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll()
                .From("ItemSalesHistory")
                .Criteria
                    .IsEqual("ItemSalesHistory", "ItemID", ItemID)
                    .IsGreaterEqual("ItemSalesHistory", "FinancialYear", year_from)
                    .IsLessEqual("ItemSalesHistory", "FinancialYear", year_to)
                    ;

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                ItemSalesHistory _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override IList<ItemSalesHistory>_FindAllCollection()
        {
            List<ItemSalesHistory> _grp = new List<ItemSalesHistory>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                ItemSalesHistory _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

    }
}
