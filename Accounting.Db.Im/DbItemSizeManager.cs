using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Im
{
    using Accounting.Core;
    using Accounting.Core.Definitions;
    using Accounting.Db.Elements;

    public class DbItemSizeManager : ItemSizeManager
    {
        public DbItemSizeManager(DbManager mgr)
            : base(mgr)
        {
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ItemSizeID"] = DbManager.FIELDTYPE.VARCHAR_5;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_255;

            TableCommands["ItemSize"] = DbMgr.CreateTableCommand("ItemSize", fields, "ItemSizeID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(ItemSize _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);

            return DbMgr.CreateInsertClause("ItemSize", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(ItemSize _obj)
        {
            return DbMgr.CreateUpdateClause("ItemSize", GetFields(_obj), "ItemSizeID", _obj.ItemSizeID);
        }

        protected override OpResult _Store(ItemSize _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ItemSize object is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
