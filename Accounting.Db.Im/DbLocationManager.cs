using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Inventory;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbLocationManager : LocationManager
    {
        public DbLocationManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["LocationID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["IsInactive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CanBeSold"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["LocationIdentification"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["LocationName"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["Street"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["City"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["State"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["Postcode"] = DbManager.FIELDTYPE.VARCHAR_11;
            fields["Country"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["Contact"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["ContactPhone"] = DbManager.FIELDTYPE.VARCHAR_21;
            fields["Notes"] = DbManager.FIELDTYPE.VARCHAR_255;

            /*       
             * */

            TableCommands["Locations"] = DbMgr.CreateTableCommand("Locations", fields, "LocationID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(Location _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            
            return DbMgr.CreateInsertClause("Locations", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(Location _obj)
        {
            return DbMgr.CreateUpdateClause("Locations", GetFields(_obj), "LocationID", _obj.LocationID);
        }

        

        protected override OpResult _Store(Location _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Location object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.LocationID == null)
            {
                _obj.LocationID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
