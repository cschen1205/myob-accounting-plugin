using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Misc;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbCustomListManager : CustomListManager
    {
        public DbCustomListManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //CustomLists()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["CustomListID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CustomListText"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["CustomListNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["CustomListName"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["ChangeControl"] = DbManager.FIELDTYPE.VARCHAR_5;
            fields["CustomListType"] = DbManager.FIELDTYPE.VARCHAR_10;

            /*         
             * */

            TableCommands["CustomLists"] = DbMgr.CreateTableCommand("CustomLists", fields, "CustomListID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(CustomList _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
           
            return DbMgr.CreateInsertClause("CustomLists", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(CustomList _obj)
        {
            return DbMgr.CreateUpdateClause("CustomLists", GetFields(_obj), "CustomListID", _obj.CustomListID);
        }

        protected override OpResult _Store(CustomList _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "TaxCode object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.CustomListID == null)
            {
                _obj.CustomListID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
