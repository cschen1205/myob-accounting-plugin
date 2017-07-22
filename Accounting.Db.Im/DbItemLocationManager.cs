using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Im
{
    using Accounting.Core;
    using Accounting.Core.Inventory;
    using Accounting.Db;
    using Accounting.Db.Elements;

    public class DbItemLocationManager : ItemLocationManager
    {
        public DbItemLocationManager(DbManager mgr)
            : base(mgr)
        {

        }



        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ItemLocationID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["ItemID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LocationID"] = DbManager.FIELDTYPE.INTEGER;
            fields["QuantityOnHand"] = DbManager.FIELDTYPE.DOUBLE;
            fields["SellOnOrder"] = DbManager.FIELDTYPE.DOUBLE;
            fields["PurchaseOnOrder"] = DbManager.FIELDTYPE.DOUBLE;
            /*
            foreignKeys["ItemID"] = "Items(ItemID)";
            foreignKeys["LocationID"] = "Locations(LocationID)";         
             * */

            TableCommands["ItemLocations"] = DbMgr.CreateTableCommand("ItemLocations", fields, "ItemLocationID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(ItemLocation _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("ItemLocations", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(ItemLocation _obj)
        {
            return DbMgr.CreateUpdateClause("ItemLocations", GetFields(_obj), "ItemLocationID", _obj.ItemLocationID);
        }

        protected override OpResult _Store(ItemLocation _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ItemLocation object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj); ;
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.ItemLocationID == null)
            {
                _obj.ItemLocationID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
