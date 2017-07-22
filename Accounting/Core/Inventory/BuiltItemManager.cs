using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Inventory
{
    public abstract class BuiltItemManager : EntityManager<BuiltItem>
    {
        public BuiltItemManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override BuiltItem _CreateDbEntity()
        {
            return new BuiltItem(true, this);
        }
        protected override BuiltItem _CreateEntity()
        {
            return new BuiltItem(false, this);
        }
        #endregion 

        protected override void LoadFromReader(BuiltItem _obj, DbDataReader reader)
        {
            _obj.BuiltItemID = GetInt32(reader, "BuiltItemID");
            _obj.ItemID = GetInt32(reader, "ItemID");
            _obj.QuantityBuilt = GetDouble(reader, "QuantityBuilt");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(BuiltItem _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["BuiltItemID"] = DbMgr.CreateAutoIntFieldEntry(_obj.BuiltItemID);
            fields["ItemID"] = DbMgr.CreateIntFieldEntry(_obj.ItemID);
            fields["QuantityBuilt"] = DbMgr.CreateDoubleFieldEntry(_obj.QuantityBuilt);

            return fields;
        }

        protected override object GetDbProperty(BuiltItem _obj, string property_name)
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

            return clause.SelectAll().From("BuiltItems");
        }

        private DbSelectStatement GetQuery_SelectByBuiltItemID(int BuiltItemID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("BuiltItems")
                .Criteria
                    .IsEqual("BuiltItems", "BuiltItemID", BuiltItemID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByBuiltItemID(int BuiltItemID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("BuiltItems")
                .Criteria
                    .IsEqual("BuiltItems", "BuiltItemID", BuiltItemID);

            return clause;
        }

        public bool Exists(int? BuiltItemID)
        {
            if (BuiltItemID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByBuiltItemID(BuiltItemID.Value)) != 0;
        }

        public override bool Exists(BuiltItem _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.BuiltItemID);
        }

        protected override BuiltItem _FindByIntId(int? BuiltItemID)
        {
            if (BuiltItemID == null) return null;
            BuiltItem _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByBuiltItemID(BuiltItemID.Value));
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

        protected override IList<BuiltItem>_FindAllCollection()
        {
            List<BuiltItem> _grp = new List<BuiltItem>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                BuiltItem _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
