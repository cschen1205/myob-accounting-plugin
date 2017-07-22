using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Inventory
{
    public class ItemAddOnManager : EntityManager<ItemAddOn>
    {
        public ItemAddOnManager(DbManager mgr)
            : base(mgr)
        {

        }

        protected override ItemAddOn _CreateEntity()
        {
            return new ItemAddOn(false, this);
        }

        protected override ItemAddOn _CreateDbEntity()
        {
            return new ItemAddOn(true, this);
        }

        protected override void LoadFromReader(ItemAddOn _obj, DbDataReader reader)
        {
            _obj.ItemAddOnID = GetInt32(reader, "ItemAddOnID");
            _obj.Color = GetString(reader, "Color");
            _obj.Brand = GetString(reader, "Brand");
            _obj.ItemSizeID = GetString(reader, "ItemSizeID");
            _obj.BatchNumber = GetString(reader, "BatchNumber");
            _obj.SerialNumber = GetString(reader, "SerialNumber");
            _obj.GenderID = GetString(reader, "GenderID");
            _obj.ExpiryDate = GetDateTime(reader, "ExpiryDate");
            _obj.ItemNumber = GetString(reader, "ItemNumber");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(ItemAddOn _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["ItemAddOnID"]=DbMgr.CreateAutoIntFieldEntry(_obj.ItemAddOnID); 
            fields["Color"]=DbMgr.CreateStringFieldEntry(_obj.Color); 
            fields["Brand"]=DbMgr.CreateStringFieldEntry(_obj.Brand);
            fields["ItemSizeID"]=DbMgr.CreateStringFieldEntry(_obj.ItemSizeID); 
            fields["BatchNumber"]=DbMgr.CreateStringFieldEntry(_obj.BatchNumber); 
            fields["SerialNumber"]=DbMgr.CreateStringFieldEntry(_obj.SerialNumber); 
            fields["GenderID"] = DbMgr.CreateStringFieldEntry(_obj.GenderID);
            fields["ExpiryDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.ExpiryDate);
            fields["ItemNumber"] = DbMgr.CreateStringFieldEntry(_obj.ItemNumber);
            
            return fields;
        }

        protected override object GetDbProperty(ItemAddOn _obj, string property_name)
        {
            if (property_name.Equals("Item"))
            {
                Item _item = RepositoryMgr.ItemMgr.FindById(_obj.ItemNumber);
                return _item;
            }
            else if(property_name.Equals("ItemSize"))
            {
                return RepositoryMgr.ItemSizeMgr.FindById(_obj.ItemSizeID);
            }
            else if (property_name.Equals("Gender"))
            {
                return RepositoryMgr.GenderMgr.FindById(_obj.GenderID);
            }
            return null;
        }

        protected override IList<ItemAddOn>_FindAllCollection()
        {
            List<ItemAddOn> _grp = new List<ItemAddOn>();

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll()
                .From("ItemAddOn");

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                ItemAddOn _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        public ItemAddOn FindByItemNumber(string ItemNumber)
        {
            if (ItemNumber == null) return null;
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ItemAddOn")
                .Criteria
                    .IsEqual("ItemAddOn", "ItemNumber", ItemNumber);

            ItemAddOn _obj = CreateEntity();
            _obj.ItemNumber = ItemNumber;

            DbCommand _cmd = CreateDbCommand(clause);
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

        

        public override bool Exists(ItemAddOn _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.ItemAddOnID);
        }

        public bool Exists(int? ItemAddOnID)
        {
            if (ItemAddOnID == null) return false;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("ItemAddOn")
                .Criteria
                    .IsEqual("ItemAddOn", "ItemAddOnID", ItemAddOnID);

            return DbMgr.ExecuteScalarInt(clause) != 0;
        }
    }
}
