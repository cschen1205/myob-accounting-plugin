using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Security;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbAuthItemManager : AuthItemManager
    {
        public DbAuthItemManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //AuthItems()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ItemID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["ItemName"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["ParentItemID"] = DbManager.FIELDTYPE.INTEGER;
            fields["DisplayName"] = DbManager.FIELDTYPE.VARCHAR_255;
            /*
            fields["CreateTime"] = DbManager.FIELDTYPE.DATETIME;
            fields["CreateUserID"] = DbManager.FIELDTYPE.INTEGER;
            fields["UpdateTime"] = DbManager.FIELDTYPE.DATETIME;
            fields["UpdateUserID"] = DbManager.FIELDTYPE.INTEGER;*/
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_255;

            TableCommands["AuthItem"] = DbMgr.CreateTableCommand("AuthItem", fields, "ItemID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(AuthItem _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("AuthItem", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(AuthItem _obj)
        {
            return DbMgr.CreateUpdateClause("AuthItem", GetFields(_obj), "ItemID", _obj.ItemID);
        }

        
        protected override OpResult _Store(AuthItem _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ItemOpeningBalance object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
              if (_obj.ItemID == null)
            {
                _obj.ItemID = DbMgr.GetLastInsertID();
            }

              foreach (AuthItem child_item in _obj.Children)
            {
                child_item.ParentItemID = _obj.ItemID;
                Store(child_item);
            }

            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

    }
}
