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
    public class DbInventoryTransferManager : InventoryTransferManager
    {
        public DbInventoryTransferManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //InventoryTransfers()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["InventoryTransferID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["InventoryJournalNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["TransactionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["IsTaxInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TransactionExchangeRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CategoryID"] = DbManager.FIELDTYPE.DOUBLE;

            /*
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CategoryID"] = "Categories(CategoryID)";
             * */

            TableCommands["InventoryTransfers"] = DbMgr.CreateTableCommand("InventoryTransfers", fields, "InventoryTransferID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(InventoryTransfer _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
          
            return DbMgr.CreateInsertClause("InventoryTransfers", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(InventoryTransfer _obj)
        {
            return DbMgr.CreateUpdateClause("InventoryTransfers", GetFields(_obj), "InventoryTransferID", _obj.InventoryTransferID);
        }

        protected override OpResult _Store(InventoryTransfer _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "InventoryTransfer object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.InventoryTransferID == null)
            {
                _obj.InventoryTransferID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

       
    }



}
