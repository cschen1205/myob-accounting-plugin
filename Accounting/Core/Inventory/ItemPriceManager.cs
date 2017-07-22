using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Inventory
{
    public abstract class ItemPriceManager : EntityManager<ItemPrice>
    {
        public ItemPriceManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override ItemPrice _CreateDbEntity()
        {
            return new ItemPrice(true, this);
        }
        protected override ItemPrice _CreateEntity()
        {
            return new ItemPrice(false, this);
        }
        #endregion

        protected override void LoadFromReader(ItemPrice _obj, DbDataReader reader)
        {
            _obj.ChangeControl = GetInt32(reader, "ChangeControl");
            _obj.ItemID = GetInt32(reader, "ItemID");
            _obj.ItemPriceID = GetInt32(reader, "ItemPriceID");
            _obj.PriceIsInclusive = GetString(reader, "PriceIsInclusive");
            _obj.PriceLevel = GetString(reader, "PriceLevel");
            _obj.PriceLevelNameID = GetString(reader, "PriceLevelNameID");
            _obj.QuantityBreak = GetInt32(reader, "QuantityBreak");
            _obj.QuantityBreakAmount = GetDouble(reader, "QuantityBreakAmount");
            _obj.SellingPrice = GetDouble(reader, "SellingPrice");
           
        }

        protected override object GetDbProperty(ItemPrice _obj, string property_name)
        {
            if (property_name.Equals("Item"))
            {
                return RepositoryMgr.ItemMgr.FindById(_obj.ItemID);
            }
            else if (property_name.Equals("PriceLevelName"))
            {
                return RepositoryMgr.PriceLevelMgr.FindById(_obj.PriceLevelNameID);
            }
            return null;
        }

        public override Dictionary<string, DbFieldEntry> GetFields(ItemPrice _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["ChangeControl"] = DbMgr.CreateIntFieldEntry(_obj.ChangeControl); //GetInt32(reader, "ChangeControl");
            fields["ItemID"] = DbMgr.CreateIntFieldEntry(_obj.ItemID); //GetInt32(reader, "ItemID");
            fields["ItemPriceID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ItemPriceID); //GetInt32(reader, "ItemPriceID");
            fields["PriceIsInclusive"] = DbMgr.CreateStringFieldEntry(_obj.PriceIsInclusive); //GetString(reader, "PriceIsInclusive");
            fields["PriceLevel"] = DbMgr.CreateStringFieldEntry(_obj.PriceLevel); //GetString(reader, "PriceLevel");
            fields["PriceLevelNameID"] = DbMgr.CreateStringFieldEntry(_obj.PriceLevelNameID); //GetString(reader, "PriceLevelNameID");
            fields["QuantityBreak"] = DbMgr.CreateIntFieldEntry(_obj.QuantityBreak); //GetInt32(reader, "QuantityBreak");
            fields["QuantityBreakAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.QuantityBreakAmount); //GetDouble(reader, "QuantityBreakAmount");
            fields["SellingPrice"] = DbMgr.CreateDoubleFieldEntry(_obj.SellingPrice); //GetDouble(reader, "SellingPrice");
            
            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("ItemPrices");
        }

        private DbSelectStatement GetQuery_SelectByItemPriceID(int ItemPriceID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("ItemPrices")
                .Criteria
                    .IsEqual("ItemPrices", "ItemPriceID", ItemPriceID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByItemPriceID(int ItemPriceID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("ItemPrices")
                .Criteria
                    .IsEqual("ItemPrices", "ItemPriceID", ItemPriceID);

            return clause;
        }

        public bool Exists(int? ItemPriceID)
        {
            if (ItemPriceID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByItemPriceID(ItemPriceID.Value)) != 0;
        }

        public override bool Exists(ItemPrice _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.ItemPriceID);
        }

        protected override ItemPrice _FindByIntId(int? ItemPriceID)
        {
            if (ItemPriceID == null) return null;
            ItemPrice _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByItemPriceID(ItemPriceID.Value));
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

        protected override IList<ItemPrice>_FindAllCollection()
        {
            List<ItemPrice> _grp = new List<ItemPrice>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                ItemPrice _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
