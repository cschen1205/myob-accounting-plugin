using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Inventory
{
    public abstract class InventoryTransferLineManager : EntityManager<InventoryTransferLine>
    {
        public InventoryTransferLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override InventoryTransferLine _CreateDbEntity()
        {
            return new InventoryTransferLine(true, this);
        }
        protected override InventoryTransferLine _CreateEntity()
        {
            return new InventoryTransferLine(false, this);
        }
        #endregion

        protected override void LoadFromReader(InventoryTransferLine _obj, DbDataReader reader)
        {
            _obj.Amount = GetDouble(reader, "Amount");
            _obj.InventoryTransferID = GetInt32(reader, "InventoryTransferID");
            _obj.InventoryTransferLineID = GetInt32(reader, "InventoryTransferLineID");
            _obj.IsMultipleJob = GetString(reader, "IsMultipleJob");
            _obj.ItemID = GetInt32(reader, "ItemID");
            _obj.JobID = GetInt32(reader, "JobID");
            _obj.LineNumber = GetInt32(reader, "LineNumber");
            _obj.LocationID = GetInt32(reader, "LocationID");
            _obj.Quantity = GetDouble(reader, "Quantity");
            _obj.UnitCost = GetDouble(reader, "UnitCost");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(InventoryTransferLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["Amount"] = DbMgr.CreateDoubleFieldEntry(_obj.Amount); //GetDouble(reader, "");
            fields["InventoryTransferID"] = DbMgr.CreateIntFieldEntry(_obj.InventoryTransferID); //GetInt32(reader, "");
            fields["InventoryTransferLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.InventoryTransferLineID); //GetInt32(reader, "");
            fields["IsMultipleJob"] = DbMgr.CreateStringFieldEntry(_obj.IsMultipleJob); //GetString(reader, "");
            fields["ItemID"] = DbMgr.CreateIntFieldEntry(_obj.ItemID); //GetInt32(reader, "");
            fields["JobID"] = DbMgr.CreateIntFieldEntry(_obj.JobID); //GetInt32(reader, "");
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber); //GetInt32(reader, "");
            fields["LocationID"] = DbMgr.CreateIntFieldEntry(_obj.LocationID); //GetInt32(reader, "");
            fields["Quantity"] = DbMgr.CreateDoubleFieldEntry(_obj.Quantity); //GetDouble(reader, "");
            fields["UnitCost"] = DbMgr.CreateDoubleFieldEntry(_obj.UnitCost); //GetDouble(reader, "");

            return fields;
        }

        protected override object GetDbProperty(InventoryTransferLine _obj, string property_name)
        {
            if (property_name.Equals("Item"))
            {
                return RepositoryMgr.ItemMgr.FindById(_obj.ItemID);
            }
            else if (property_name.Equals("InventoryTransfer"))
            {
                return RepositoryMgr.InventoryTransferMgr.FindById(_obj.InventoryTransferID);
            }
            else if (property_name.Equals("Job"))
            {
                return RepositoryMgr.JobMgr.FindById(_obj.JobID);
            }
            else if (property_name.Equals("Location"))
            {
                return RepositoryMgr.LocationMgr.FindByLocationID(_obj.LocationID);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("InventoryTransferLines");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByInventoryTransferLineID(int InventoryTransferLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("InventoryTransferLines")
                .Criteria
                    .IsEqual("InventoryTransferLines", "InventoryTransferLineID", InventoryTransferLineID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByInventoryTransferLineID(int InventoryTransferLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("InventoryTransferLines")
                .Criteria
                    .IsEqual("InventoryTransferLines", "InventoryTransferLineID", InventoryTransferLineID);

            return clause;
        }

        public bool Exists(int? InventoryTransferLineID)
        {
            if (InventoryTransferLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByInventoryTransferLineID(InventoryTransferLineID.Value)) != 0;
        }

        public override bool Exists(InventoryTransferLine _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.InventoryTransferLineID);
        }

        protected override InventoryTransferLine _FindByIntId(int? InventoryTransferLineID)
        {
            if (InventoryTransferLineID == null) return null;
            InventoryTransferLine _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByInventoryTransferLineID(InventoryTransferLineID.Value));
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

        protected override IList<InventoryTransferLine>_FindAllCollection()
        {
            List<InventoryTransferLine> _grp = new List<InventoryTransferLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                InventoryTransferLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
