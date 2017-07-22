using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Inventory
{
    public abstract class NegativeInventoryManager : EntityManager<NegativeInventory>
    {
        public NegativeInventoryManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override NegativeInventory _CreateDbEntity()
        {
            return new NegativeInventory(true, this);
        }
        protected override NegativeInventory _CreateEntity()
        {
            return new NegativeInventory(false, this);
        }
        #endregion

        protected override void LoadFromReader(NegativeInventory _obj, DbDataReader reader)
        {
            _obj.ActualCost = GetDouble(reader, "ActualCost");
            _obj.BaseCost = GetDouble(reader, "BaseCost");
            _obj.IsCreditOffset = GetString(reader, "IsCreditOffset");
            _obj.ItemID = GetInt32(reader, "ItemID");
            _obj.JournalTypeID = GetString(reader, "JournalTypeID");
            _obj.LineCost = GetDouble(reader, "LineCost");
            _obj.LocationID = GetInt32(reader, "LocationID");
            _obj.NegativeInventoryID = GetInt32(reader, "NegativeInventoryID");
            _obj.Quantity = GetDouble(reader, "Quantity");
            _obj.SaleLineID = GetInt32(reader, "SaleLineID");
            _obj.SaleLineIsPurged = GetString(reader, "SaleLineIsPurged");
            _obj.TransactionID = GetInt32(reader, "TransactionID");
            _obj.TransactionIsPurged = GetString(reader, "TransactionIsPurged");
            _obj.UnitCost = GetDouble(reader, "UnitCost");
           
        }

        public override Dictionary<string, DbFieldEntry> GetFields(NegativeInventory _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["ActualCost"] = DbMgr.CreateDoubleFieldEntry(_obj.ActualCost); //GetDouble(reader, "");
            fields["BaseCost"] = DbMgr.CreateDoubleFieldEntry(_obj.BaseCost); //GetDouble(reader, "");
            fields["IsCreditOffset"] = DbMgr.CreateStringFieldEntry(_obj.IsCreditOffset); //GetString(reader, "");
            fields["ItemID"] = DbMgr.CreateIntFieldEntry(_obj.ItemID); //GetInt32(reader, "");
            fields["JournalTypeID"] = DbMgr.CreateStringFieldEntry(_obj.JournalTypeID); //GetString(reader, "");
            fields["LineCost"] = DbMgr.CreateDoubleFieldEntry(_obj.LineCost); //GetDouble(reader, "");
            fields["LocationID"] = DbMgr.CreateIntFieldEntry(_obj.LocationID); //GetInt32(reader, "");
            fields["NegativeInventoryID"] = DbMgr.CreateAutoIntFieldEntry(_obj.NegativeInventoryID); //GetInt32(reader, "");
            fields["Quantity"] = DbMgr.CreateDoubleFieldEntry(_obj.Quantity); //GetDouble(reader, "");
            fields["SaleLineID"] = DbMgr.CreateIntFieldEntry(_obj.SaleLineID); //GetInt32(reader, "");
            fields["SaleLineIsPurged"] = DbMgr.CreateStringFieldEntry(_obj.SaleLineIsPurged); //GetString(reader, "");
            fields["TransactionID"] = DbMgr.CreateIntFieldEntry(_obj.TransactionID); //GetInt32(reader, "");
            fields["TransactionIsPurged"] = DbMgr.CreateStringFieldEntry(_obj.TransactionIsPurged); //GetString(reader, "");
            fields["UnitCost"] = DbMgr.CreateDoubleFieldEntry(_obj.UnitCost); //GetDouble(reader, "");
           

            return fields;
        }

        protected override object GetDbProperty(NegativeInventory _obj, string property_name)
        {
            if (property_name.Equals("SaleLine"))
            {
                return RepositoryMgr.SaleLineMgr.FindById(_obj.SaleLineID);
            }
            else if (property_name.Equals("Item"))
            {
                return RepositoryMgr.ItemMgr.FindById(_obj.ItemID);
            }
            else if (property_name.Equals("Location"))
            {
                return RepositoryMgr.LocationMgr.FindByLocationID(_obj.LocationID);
            }
            else if (property_name.Equals("JournalType"))
            {
                return RepositoryMgr.JournalTypeMgr.FindById(_obj.JournalTypeID);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("NegativeInventory");
        }

        private DbSelectStatement GetQuery_SelectByNegativeInventoryID(int NegativeInventoryID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("NegativeInventory")
                .Criteria
                    .IsEqual("NegativeInventory", "NegativeInventoryID", NegativeInventoryID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByNegativeInventoryID(int NegativeInventoryID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("NegativeInventory")
                .Criteria
                    .IsEqual("NegativeInventory", "NegativeInventoryID", NegativeInventoryID);

            return clause;
        }

        public bool Exists(int? NegativeInventoryID)
        {
            if (NegativeInventoryID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByNegativeInventoryID(NegativeInventoryID.Value)) != 0;
        }

        public override bool Exists(NegativeInventory _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.NegativeInventoryID);
        }

        protected override NegativeInventory _FindByIntId(int? NegativeInventoryID)
        {
            NegativeInventory _obj = null;
            if (NegativeInventoryID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByNegativeInventoryID(NegativeInventoryID.Value));
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

        protected override IList<NegativeInventory>_FindAllCollection()
        {
            List<NegativeInventory> _grp = new List<NegativeInventory>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                NegativeInventory _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
