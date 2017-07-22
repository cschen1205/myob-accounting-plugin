using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Inventory
{
    public class ItemOpeningBalanceManager : EntityManager<ItemOpeningBalance>
    {
        public ItemOpeningBalanceManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override ItemOpeningBalance _CreateEntity()
        {
            return new ItemOpeningBalance(false, this);
        }
        protected override ItemOpeningBalance _CreateDbEntity()
        {
            return new ItemOpeningBalance(true, this);
        }
        #endregion

        protected override void LoadFromReader(ItemOpeningBalance _obj, DbDataReader reader)
        {
            _obj.ItemOpeningBalanceID = GetInt32(reader, "ItemOpeningBalanceID");
            _obj.ItemID = GetInt32(reader, "ItemID");
            _obj.FinancialYear = GetInt32(reader, "FinancialYear");
            _obj.Units = GetDouble(reader, "Units");
            _obj.Dollars = GetDouble(reader, "Dollars");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(ItemOpeningBalance _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["ItemOpeningBalanceID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ItemOpeningBalanceID); //GetInt32(reader, "");
            fields["ItemID"] = DbMgr.CreateIntFieldEntry(_obj.ItemID); //GetInt32(reader, "");
            fields["FinancialYear"] = DbMgr.CreateIntFieldEntry(_obj.FinancialYear); //GetInt32(reader, "");
            fields["Units"] = DbMgr.CreateDoubleFieldEntry(_obj.Units); //GetDouble(reader, "");
            fields["Dollars"] = DbMgr.CreateDoubleFieldEntry(_obj.Dollars); //GetDouble(reader, "");

            return fields;
        }

        protected override object GetDbProperty(ItemOpeningBalance _obj, string property_name)
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

            return clause.SelectAll().From("ItemOpeningBalance");
        }

        private DbSelectStatement GetQuery_SelectByItemOpeningBalanceID(int ItemOpeningBalanceID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("ItemOpeningBalance")
                .Criteria
                    .IsEqual("ItemOpeningBalance", "ItemOpeningBalanceID", ItemOpeningBalanceID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByItemOpeningBalanceID(int ItemOpeningBalanceID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("ItemOpeningBalance")
                .Criteria
                    .IsEqual("ItemOpeningBalance", "ItemOpeningBalanceID", ItemOpeningBalanceID);

            return clause;
        }

        public bool Exists(int? ItemOpeningBalanceID)
        {
            if (ItemOpeningBalanceID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByItemOpeningBalanceID(ItemOpeningBalanceID.Value)) != 0;
        }

        public override bool Exists(ItemOpeningBalance _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.ItemOpeningBalanceID);
        }

        protected override ItemOpeningBalance _FindByIntId(int? ItemOpeningBalanceID)
        {
            if (ItemOpeningBalanceID == null) return null;
            ItemOpeningBalance _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByItemOpeningBalanceID(ItemOpeningBalanceID.Value));
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

        protected override IList<ItemOpeningBalance>_FindAllCollection()
        {
            List<ItemOpeningBalance> _grp = new List<ItemOpeningBalance>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                ItemOpeningBalance _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
