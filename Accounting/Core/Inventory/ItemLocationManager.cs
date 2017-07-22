using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Inventory
{
    public abstract class ItemLocationManager : EntityManager<ItemLocation>
    {
        public ItemLocationManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override ItemLocation _CreateEntity()
        {
            return new ItemLocation(false, this);
        }

        protected override ItemLocation _CreateDbEntity()
        {
            return new ItemLocation(true, this);
        }
        #endregion

        private DbSelectStatement GetQuery_SelectCountByItemLocationID(int ItemLocationID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectCount()
                .From("ItemLocations")
                .Criteria
                    .IsEqual("ItemLocations", "ItemLocationID", ItemLocationID);
            return clause;
        }

        public bool Exists(int? ItemLocationID)
        {
            if (ItemLocationID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByItemLocationID(ItemLocationID.Value)) != 0;
        }

        public override bool Exists(ItemLocation _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.ItemLocationID);
        }

        protected override IList<ItemLocation>_FindAllCollection()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll().From("ItemLocations");
            

            List<ItemLocation> _grp = new List<ItemLocation>();
            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                ItemLocation _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override void LoadFromReader(ItemLocation _obj, DbDataReader reader)
        {
            _obj.ItemID = GetInt32(reader, "ItemID");
            _obj.ItemLocationID = GetInt32(reader, "ItemLocationID");
            _obj.LocationID = GetInt32(reader, "LocationID");
            _obj.PurchaseOnOrder = GetDouble(reader, "PurchaseOnOrder");
            _obj.QuantityOnHand = GetDouble(reader, "QuantityOnHand");
            _obj.SellOnOrder = GetDouble(reader, "SellOnOrder");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(ItemLocation _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["ItemLocationID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ItemLocationID);
            fields["ItemID"] = DbMgr.CreateIntFieldEntry(_obj.ItemID);
            fields["LocationID"] = DbMgr.CreateIntFieldEntry(_obj.LocationID);
            fields["PurchaseOnOrder"] = DbMgr.CreateDoubleFieldEntry(_obj.PurchaseOnOrder);
            fields["SellOnOrder"] = DbMgr.CreateDoubleFieldEntry(_obj.SellOnOrder);
            fields["QuantityOnHand"] = DbMgr.CreateDoubleFieldEntry(_obj.QuantityOnHand);

            return fields;
        }

        protected override object GetDbProperty(ItemLocation _obj, string property_name)
        {
            if (property_name.Equals("Item"))
            {
                return RepositoryMgr.ItemMgr.FindById(_obj.ItemID);
            }
            else if (property_name.Equals("Location"))
            {
                return RepositoryMgr.LocationMgr.FindByLocationID(_obj.LocationID);
            }
            return null;
        }
    }
}
