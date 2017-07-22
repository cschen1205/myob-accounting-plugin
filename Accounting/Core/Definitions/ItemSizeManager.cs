using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class ItemSizeManager : EntityManager<ItemSize>
    {
        public ItemSizeManager(DbManager mgr)
            : base(mgr)
        {
        }

        protected override ItemSize _CreateDbEntity()
        {
            return new ItemSize(true, this);
        }

        protected override ItemSize _CreateEntity()
        {
            return new ItemSize(false, this);
        }

        protected override void LoadFromReader(ItemSize _obj, DbDataReader reader)
        {
            _obj.ItemSizeID = GetString(reader, "ItemSizeID");
            _obj.Description = GetString(reader, "Description");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(ItemSize _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["ItemSizeID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.ItemSizeID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        public override bool Exists(ItemSize _obj)
        {
            if (_obj == null) return false;
            return ExistsByItemSizeID(_obj.ItemSizeID);
        }

        public bool ExistsByItemSizeID(string ItemSizeID)
        {
            if (string.IsNullOrEmpty(ItemSizeID)) return false;
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("ItemSize")
                .Criteria
                    .IsEqual("ItemSize", "ItemSizeID", ItemSizeID);

            return DbMgr.ExecuteScalarInt(clause) != 0;
        }

        public bool ExistsByDescription(string Description)
        {
            if (string.IsNullOrEmpty(Description)) return false;
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("ItemSize")
                .Criteria
                    .IsEqual("ItemSize", "Description", Description);

            return DbMgr.ExecuteScalarInt(clause) != 0;
        }

        protected override OpResult _Delete(ItemSize _obj)
        {
            if (Exists(_obj))
            {
                DbDeleteStatement clause = DbMgr.CreateDeleteClause();
                clause.DeleteFrom("ItemSize").Criteria
                    .IsEqual("ItemSize", "ItemSizeID", _obj.ItemSizeID);

                DbMgr.ExecuteNonQuery(clause);

                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }
            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj);
        }

        protected override IList<ItemSize>_FindAllCollection()
        {
            List<ItemSize> _grp = new List<ItemSize>();

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ItemSize");

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                ItemSize _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override ItemSize _FindByTextId(string ItemSizeID)
        {
            ItemSize _obj = null;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ItemSize")
                .Criteria
                    .IsEqual("ItemSize", "ItemSizeID", ItemSizeID);

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

        public ItemSize FindByDescription(string Description)
        {
            ItemSize _obj = null;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ItemSize")
                .Criteria
                    .IsEqual("ItemSize", "Description", Description);

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
    }
}
