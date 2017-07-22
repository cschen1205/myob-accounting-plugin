using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Definitions;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbOrderStatusManager : OrderStatusManager
    {
        public DbOrderStatusManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["OrderStatusID"] = DbManager.FIELDTYPE.VARCHAR_2;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_14;

            TableCommands["OrderStatus"] = DbMgr.CreateTableCommand("OrderStatus", fields, "OrderStatusID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(OrderStatus _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("OrderStatus", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(OrderStatus _obj)
        {
            return DbMgr.CreateUpdateClause("OrderStatus", GetFields(_obj), "OrderStatusID", _obj.OrderStatusID);
        }

        protected override OpResult _Store(OrderStatus _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "OrderStatus object cannot be created as it is null");
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
