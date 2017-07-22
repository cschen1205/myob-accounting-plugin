using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Im
{
    using Accounting.Core;
    using Accounting.Core.Inventory;
    using Accounting.Db.Elements;

    public class DbItemDataFieldEntryManager : ItemDataFieldEntryManager
    {
        public DbItemDataFieldEntryManager(DbManager mgr)
            : base(mgr)
        {
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ItemDataFieldEntryID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["DataFieldID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Content"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["ItemNumber"] = DbManager.FIELDTYPE.VARCHAR_30;
            

            TableCommands["ItemDataFieldEntries"] = DbMgr.CreateTableCommand("ItemDataFieldEntries", fields, "ItemDataFieldEntryID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(ItemDataFieldEntry _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("ItemDataFieldEntries", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(ItemDataFieldEntry _obj)
        {
            return DbMgr.CreateUpdateClause("ItemDataFieldEntries", GetFields(_obj), "ItemDataFieldEntryID", _obj.ItemDataFieldEntryID);
        }

        protected override OpResult _Delete(ItemDataFieldEntry _obj)
        {
            if (Exists(_obj))
            {
                DbDeleteStatement clause = DbMgr.CreateDeleteClause();
                clause.DeleteFrom("ItemDataFieldEntries").Criteria.IsEqual("ItemDataFieldEntries", "ItemDataFieldEntryID", _obj.ItemDataFieldEntryID);
                DbMgr.ExecuteNonQuery(clause);
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }
            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj);
        }

        protected override OpResult _Store(ItemDataFieldEntry _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ItemDataFieldEntry object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                //Console.WriteLine("execute update...{0}", _obj.ItemDataFieldEntryID);
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            
            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.ItemDataFieldEntryID == null)
            {
                _obj.ItemDataFieldEntryID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            //Console.WriteLine("execute insert...{0}", _obj.ItemDataFieldEntryID);

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
        
    }
}
