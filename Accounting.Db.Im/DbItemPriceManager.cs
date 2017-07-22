using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Inventory;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbItemPriceManager : ItemPriceManager
    {
        public DbItemPriceManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ItemPriceID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["ItemID"] = DbManager.FIELDTYPE.INTEGER;
            fields["QuantityBreak"] = DbManager.FIELDTYPE.INTEGER;
            fields["QuantityBreakAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["PriceLevel"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["PriceLevelNameID"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["SellingPrice"] = DbManager.FIELDTYPE.DOUBLE;
            fields["PriceIsInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["ChangeControl"] = DbManager.FIELDTYPE.VARCHAR_5;

            /*
                        foreignKeys["ItemID"] = "Items(ItemID)";
                        foreignKeys["PriceLevelNameID"] = "PriceLevels(PriceLevelNameID)";        
                         * */

            TableCommands["ItemPrices"] = DbMgr.CreateTableCommand("ItemPrices", fields, "ItemPriceID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(ItemPrice _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("ItemPrices", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(ItemPrice _obj)
        {
            return DbMgr.CreateUpdateClause("ItemPrices", GetFields(_obj), "ItemPriceID", _obj.ItemPriceID);
        }

        protected override OpResult _Store(ItemPrice _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ItemPrice object cannot be created as it is null");
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
