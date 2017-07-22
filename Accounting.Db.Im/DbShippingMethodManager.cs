using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.ShippingMethods;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbShippingMethodManager : ShippingMethodManager
    {
        public DbShippingMethodManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //Methods()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ShippingMethodID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["ShippingMethod"] = DbManager.FIELDTYPE.VARCHAR_255;

            /* 
             * */

            TableCommands["ShippingMethods"] = DbMgr.CreateTableCommand("ShippingMethods", fields, "ShippingMethodID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(ShippingMethod _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
           
            return DbMgr.CreateInsertClause("ShippingMethods", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(ShippingMethod _obj)
        {
            return DbMgr.CreateUpdateClause("ShippingMethods", GetFields(_obj), "ShippingMethodID", _obj.ShippingMethodID);
        }

        protected override OpResult _Store(ShippingMethod _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "CostCentreAccountActivity object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.ShippingMethodID == null)
            {
                _obj.ShippingMethodID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }

    
}
