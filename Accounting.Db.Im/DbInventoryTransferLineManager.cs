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
    public class DbInventoryTransferLineManager : InventoryTransferLineManager
    {
        public DbInventoryTransferLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //InventoryTransferLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["InventoryTransferLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["InventoryTransferID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["ItemID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Quantity"] = DbManager.FIELDTYPE.DOUBLE;
            fields["UnitCost"] = DbManager.FIELDTYPE.DOUBLE;
            fields["Amount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["IsMultipleJob"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LocationID"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["InventoryTransferID"] = "InventoryTransfers(InventoryTransferID)";
            foreignKeys["ItemID"] = "Item(ItemID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["LocationID"] = "Locations(LocationID)";
             * */

            TableCommands["InventoryTransferLines"] = DbMgr.CreateTableCommand("InventoryTransferLines", fields, "InventoryTransferLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(InventoryTransferLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
          
            return DbMgr.CreateInsertClause("InventoryTransferLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(InventoryTransferLine _obj)
        {
            return DbMgr.CreateUpdateClause("InventoryTransferLines", GetFields(_obj), "InventoryTransferLineID", _obj.InventoryTransferLineID);
        }

        protected override OpResult _Store(InventoryTransferLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "InventoryTransferLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.InventoryTransferLineID == null)
            {
                _obj.InventoryTransferLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

       
    }



}
