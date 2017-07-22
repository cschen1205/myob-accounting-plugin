using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Inventory;
using Accounting.Core.Cards;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbInventoryAdjustmentManager : InventoryAdjustmentManager
    {
        public DbInventoryAdjustmentManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //InventoryAdjustments()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["InventoryAdjustmentID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["InventoryJournalNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["TransactionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["IsTaxInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CostCentreID"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TransactionExchangeRate"] = DbManager.FIELDTYPE.DOUBLE;

            /*
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CategoryID"] = "Categories(CategoryID)";
            * */

            TableCommands["InventoryAdjustments"] = DbMgr.CreateTableCommand("InventoryAdjustments", fields, "InventoryAdjustmentID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(InventoryAdjustment _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
          
            return DbMgr.CreateInsertClause("InventoryAdjustments", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(InventoryAdjustment _obj)
        {
            return DbMgr.CreateUpdateClause("InventoryAdjustments", GetFields(_obj), "InventoryAdjustmentID", _obj.InventoryAdjustmentID);
        }

        protected override OpResult _Store(InventoryAdjustment _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "InventoryAdjustment object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.InventoryAdjustmentID == null)
            {
                _obj.InventoryAdjustmentID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

       
    }



}
