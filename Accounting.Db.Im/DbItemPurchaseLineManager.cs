using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Purchases;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbItemPurchaseLineManager : ItemPurchaseLineManager
    {
        public DbItemPurchaseLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //ItemPurchaseLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["ItemPurchaseLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["PurchaseLineID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PurchaseID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["ItemID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["Quantity"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxExclusiveUnitPrice"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveUnitPrice"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxExclusiveTotal"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveTotal"] = DbManager.FIELDTYPE.DOUBLE;
            fields["Discount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["IsMultipleJob"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxBasisAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxBasisAmountIsInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Received"] = DbManager.FIELDTYPE.DOUBLE;
            fields["LocationID"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["PurchaseLineID"] = "(PurchaseLineID)";
            foreignKeys["PurchaseID"] = "(PurchaseID)";
            foreignKeys["LineTypeID"] = "(LineTypeID)";
            foreignKeys["ItemID"] = "(ItemID)";
            foreignKeys["JobID"] = "(JobID)";
            foreignKeys["TaxCodeID"] = "(TaxCodeID)";            
            foreignKeys["LocationID"] = "(LocationID)";
             * */

            TableCommands["ItemPurchaseLines"] = DbMgr.CreateTableCommand("ItemPurchaseLines", fields, "ItemPurchaseLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(ItemPurchaseLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
           
            return DbMgr.CreateInsertClause("ItemPurchaseLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(ItemPurchaseLine _obj)
        {
            return DbMgr.CreateUpdateClause("ItemPurchaseLines", GetFields(_obj), "ItemPurchaseLineID", _obj.ItemPurchaseLineID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(ItemPurchaseLine _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("ItemPurchaseLines").Criteria.IsEqual("ItemPurchaseLines", "ItemPurchaseLineID", _obj.ItemPurchaseLineID);
            
            return clause;
        }

        

        protected override OpResult _Store(ItemPurchaseLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ItemPurchaseLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.ItemPurchaseLineID == null)
            {
                _obj.ItemPurchaseLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(ItemPurchaseLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ItemPurchaseLine object cannot be deleted as it is null");
            }
            if(Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }
            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "ItemPurchaseLine object cannot be deleted as it does not exist");
        }

    }
}
