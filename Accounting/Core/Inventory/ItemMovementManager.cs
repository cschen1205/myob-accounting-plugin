using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Inventory
{
    public abstract class ItemMovementManager : EntityManager<ItemMovement>
    {
        public ItemMovementManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Method)
        protected override ItemMovement _CreateDbEntity()
        {
            return new ItemMovement(true, this);
        }
        protected override ItemMovement _CreateEntity()
        {
            return new ItemMovement(false, this);
        }
        #endregion

        protected override void LoadFromReader(ItemMovement _obj, DbDataReader reader)
        {
            _obj.ItemMovementID = GetInt32(reader, "ItemMovementID");
            _obj.ItemID = GetInt32(reader, "ItemID");
            _obj.FinancialYear = GetInt32(reader, "FinancialYear");
            _obj.UnitChange = GetDouble(reader, "UnitChange");
            _obj.DollarChange = GetDouble(reader, "DollarChange");
            _obj.Period = GetInt32(reader, "Period");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(ItemMovement _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["ItemMovementID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ItemMovementID); //GetInt32(reader, "ItemMovementID");
            fields["ItemID"] = DbMgr.CreateIntFieldEntry(_obj.ItemID); //GetInt32(reader, "ItemID");
            fields["FinancialYear"] = DbMgr.CreateIntFieldEntry(_obj.FinancialYear); //GetInt32(reader, "FinancialYear");
            fields["UnitChange"] = DbMgr.CreateDoubleFieldEntry(_obj.UnitChange); //GetDouble(reader, "UnitChange");
            fields["DollarChange"] = DbMgr.CreateDoubleFieldEntry(_obj.DollarChange); //GetDouble(reader, "DollarChange");
            fields["Period"] = DbMgr.CreateIntFieldEntry(_obj.Period); //GetInt32(reader, "Period");

            return fields;
        }

        protected override object GetDbProperty(ItemMovement _obj, string property_name)
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

            return clause.SelectAll().From("ItemMovement");
        }

        private DbSelectStatement GetQuery_SelectByItemMovementID(int ItemMovementID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("ItemMovement")
                .Criteria
                    .IsEqual("ItemMovement", "ItemMovementID", ItemMovementID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByItemMovementID(int ItemMovementID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("ItemMovement")
                .Criteria
                    .IsEqual("ItemMovement", "ItemMovementID", ItemMovementID);

            return clause;
        }

        public bool Exists(int? ItemMovementID)
        {
            if (ItemMovementID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByItemMovementID(ItemMovementID.Value)) != 0;
        }

        public override bool Exists(ItemMovement _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.ItemMovementID);
        }

        protected override ItemMovement _FindByIntId(int? ItemMovementID)
        {
            if (ItemMovementID == null) return null;

            ItemMovement _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByItemMovementID(ItemMovementID.Value));
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

        protected override IList<ItemMovement>_FindAllCollection()
        {
            List<ItemMovement> _grp = new List<ItemMovement>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                ItemMovement _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

    }
}
