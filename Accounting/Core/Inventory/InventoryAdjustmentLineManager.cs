using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Inventory
{
    public abstract class InventoryAdjustmentLineManager : EntityManager<InventoryAdjustmentLine>
    {
        public InventoryAdjustmentLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override InventoryAdjustmentLine _CreateDbEntity()
        {
            return new InventoryAdjustmentLine(true, this);
        }
        protected override InventoryAdjustmentLine _CreateEntity()
        {
            return new InventoryAdjustmentLine(false, this);
        }
        #endregion

        protected override void LoadFromReader(InventoryAdjustmentLine _obj, DbDataReader reader)
        {
            _obj.AccountID = GetInt32(reader, "AccountID");
            _obj.Amount = GetDouble(reader, "Amount");
            _obj.InventoryAdjustmentID = GetInt32(reader, "InventoryAdjustmentID");
            _obj.InventoryAdjustmentLineID = GetInt32(reader, "InventoryAdjustmentLineID");
            _obj.IsCOGSAdjustment = GetString(reader, "IsCOGSAdjustment");
            _obj.IsMultipleJob = GetString(reader, "IsMultipleJob");
            _obj.ItemID = GetInt32(reader, "ItemID");
            _obj.JobID = GetInt32(reader, "JobID");
            _obj.LineNumber = GetInt32(reader, "LineNumber");
            _obj.LocationID = GetInt32(reader, "LocationID");
            _obj.Quantity = GetDouble(reader, "Quantity");
            _obj.SaleID = GetInt32(reader, "SaleID");
            _obj.SaleLineID = GetInt32(reader, "SaleLineID");
            _obj.UnitCost = GetDouble(reader, "UnitCost");
            
        }

        public override Dictionary<string, DbFieldEntry> GetFields(InventoryAdjustmentLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["AccountID"] = DbMgr.CreateIntFieldEntry(_obj.AccountID);
            fields["Amount"] = DbMgr.CreateDoubleFieldEntry(_obj.Amount);
            fields["InventoryAdjustmentID"] = DbMgr.CreateIntFieldEntry(_obj.InventoryAdjustmentID);
            fields["InventoryAdjustmentLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.InventoryAdjustmentLineID);
            fields["IsCOGSAdjustment"] = DbMgr.CreateStringFieldEntry(_obj.IsCOGSAdjustment);
            fields["IsMultipleJob"] = DbMgr.CreateStringFieldEntry(_obj.IsMultipleJob);
            fields["ItemID"] = DbMgr.CreateIntFieldEntry(_obj.ItemID);
            fields["JobID"] = DbMgr.CreateIntFieldEntry(_obj.JobID);
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber);
            fields["LocationID"] = DbMgr.CreateIntFieldEntry(_obj.LocationID);
            fields["Quantity"] = DbMgr.CreateDoubleFieldEntry(_obj.Quantity);
            fields["SaleID"] = DbMgr.CreateIntFieldEntry(_obj.SaleID);
            fields["SaleLineID"] = DbMgr.CreateIntFieldEntry(_obj.SaleLineID);
            fields["UnitCost"] = DbMgr.CreateDoubleFieldEntry(_obj.UnitCost);

            return fields;
        }

        protected override object GetDbProperty(InventoryAdjustmentLine _obj, string property_name)
        {
            if (property_name.Equals("InventoryAdjustment"))
            {
                return RepositoryMgr.InventoryAdjustmentMgr.FindById(_obj.InventoryAdjustmentID);
            }
            else if (property_name.Equals("Item"))
            {
                return RepositoryMgr.ItemMgr.FindById(_obj.ItemID);
            }
            else if (property_name.Equals("Account"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.AccountID);
            }
            else if (property_name.Equals("Sale"))
            {
                return RepositoryMgr.SaleMgr.FindById(_obj.SaleID);
            }
            else if (property_name.Equals("SaleLine"))
            {
                return RepositoryMgr.SaleLineMgr.FindById(_obj.SaleLineID);
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
            return clause.SelectAll().From("InventoryAdjustmentLines");
        }

        private DbSelectStatement GetQuery_SelectByInventoryAdjustmentLineID(int InventoryAdjustmentLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("InventoryAdjustmentLines")
                .Criteria
                    .IsEqual("InventoryAdjustmentLines", "InventoryAdjustmentLineID", InventoryAdjustmentLineID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByInventoryAdjustmentLineID(int InventoryAdjustmentLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("InventoryAdjustmentLines")
                .Criteria
                    .IsEqual("InventoryAdjustmentLines", "InventoryAdjustmentLineID", InventoryAdjustmentLineID);

            return clause;
        }

        public bool Exists(int? InventoryAdjustmentLineID)
        {
            if (InventoryAdjustmentLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByInventoryAdjustmentLineID(InventoryAdjustmentLineID.Value)) != 0;
        }

        public override bool Exists(InventoryAdjustmentLine _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.InventoryAdjustmentLineID);
        }

        protected override InventoryAdjustmentLine _FindByIntId(int? InventoryAdjustmentLineID)
        {
            InventoryAdjustmentLine _obj = null;
            if (InventoryAdjustmentLineID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByInventoryAdjustmentLineID(InventoryAdjustmentLineID.Value));
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

        internal IList<InventoryAdjustmentLine> FindCollectionByInventoryAdjustment(InventoryAdjustment ia)
        {
            if (UseMemoryStore)
            {
                IList<InventoryAdjustmentLine> store = DataStore;
                var result = from s in store
                             where s.InventoryAdjustmentID == ia.InventoryAdjustmentID
                             select s;
                return result.ToList();
            }
            return _FindCollectionByInventoryAdjustment(ia);
        }

        protected IList<InventoryAdjustmentLine> _FindCollectionByInventoryAdjustment(InventoryAdjustment ia)
        {
            List<InventoryAdjustmentLine> _grp = new List<InventoryAdjustmentLine>();

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll().From("InventoryAdjustmentLines").Criteria.IsEqual("InventoryAdjustmentLines", "InventoryAdjustmentID", ia.InventoryAdjustmentID);

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                InventoryAdjustmentLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override IList<InventoryAdjustmentLine>_FindAllCollection()
        {
            List<InventoryAdjustmentLine> _grp = new List<InventoryAdjustmentLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                InventoryAdjustmentLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
