using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Inventory
{
    public abstract class MoveItemManager : EntityManager<MoveItem>
    {
        public MoveItemManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override MoveItem _CreateDbEntity()
        {
            return new MoveItem(true, this);
        }
        protected override MoveItem _CreateEntity()
        {
            return new MoveItem(false, null);
        }
        #endregion

        protected override void LoadFromReader(MoveItem _obj, DbDataReader reader)
        {
            _obj.Description = GetString(reader, "Description");
            _obj.ItemID = GetInt32(reader, "ItemID");
            _obj.MoveDate = GetDateTime(reader, "MoveDate");
            _obj.UserID = GetInt32(reader, "UserID");
            _obj.MoveItemID = GetInt32(reader, "MoveItemID");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(MoveItem _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description); //GetString(reader, "");
            fields["ItemID"] = DbMgr.CreateIntFieldEntry(_obj.ItemID); //GetInt32(reader, "");
            fields["MoveDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.MoveDate); //GetDateTime(reader, "");
            fields["UserID"] = DbMgr.CreateIntFieldEntry(_obj.UserID); //GetInt32(reader, "");
            fields["MoveItemID"] = DbMgr.CreateAutoIntFieldEntry(_obj.MoveItemID); //GetInt32(reader, "");

            return fields;
        }

        protected override object GetDbProperty(MoveItem _obj, string property_name)
        {
            if (property_name.Equals("Item"))
            {
                return RepositoryMgr.ItemMgr.FindById(_obj.ItemID);
            }
            else if (property_name.Equals("User"))
            {
                return RepositoryMgr.AuthUserMgr.FindByUserID(_obj.UserID);
            }
            return false;
        }
        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("MoveItems");
        }
        private DbSelectStatement GetQuery_SelectByMoveItemID(int MoveItemID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("MoveItems")
                .Criteria
                    .IsEqual("MoveItems", "MoveItemID", MoveItemID);
            return clause;
        }
        private DbSelectStatement GetQuery_SelectCountByMoveItemID(int MoveItemID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("MoveItems")
                .Criteria
                    .IsEqual("MoveItems", "MoveItemID", MoveItemID);
            return clause;
        }
        public bool Exists(int? MoveItemID)
        {
            if (MoveItemID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByMoveItemID(MoveItemID.Value)) != 0;
        }
        public override bool Exists(MoveItem _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.MoveItemID);
        }

        protected override MoveItem _FindByIntId(int? MoveItemID)
        {
            if (MoveItemID == null) return null;
            MoveItem _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByMoveItemID(MoveItemID.Value));
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

        protected override IList<MoveItem>_FindAllCollection()
        {
            List<MoveItem> _grp = new List<MoveItem>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                MoveItem _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

    }
}
