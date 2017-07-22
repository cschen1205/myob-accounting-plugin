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
    public sealed class DbRecurringItemPurchaseLineManager : RecurringItemPurchaseLineManager
    {
        public DbRecurringItemPurchaseLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //RecurringItemPurchaseLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringItemPurchaseLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["RecurringPurchaseLineID"] = DbManager.FIELDTYPE.INTEGER;
            fields["RecurringPurchaseID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Quantity"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ItemID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["LocationID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxExclusiveUnitPrice"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveUnitPrice"] = DbManager.FIELDTYPE.DOUBLE;
            fields["Discount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxExclusiveTotal"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveTotal"] = DbManager.FIELDTYPE.DOUBLE;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxBasisAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxBasisAmountIsInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;

            /*
            foreignKeys["RecurringPurchaseLineID"] = "RecurringPurchaseLine(RecurringPurchaseLineID)";
            foreignKeys["RecurringPurchasesID"] = "RecurringPurchases(RecurringPurchasesID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";  
            foreignKeys["ItemID"] = "Items(ItemID)";
            foreignKeys["LocationID"] = "Locations(LocationID)";              
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)"       
             * */

            TableCommands["RecurringItemPurchaseLines"] = DbMgr.CreateTableCommand("RecurringItemPurchaseLines", fields, "RecurringItemPurchaseLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(RecurringItemPurchaseLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            
            return DbMgr.CreateInsertClause("RecurringItemPurchaseLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(RecurringItemPurchaseLine _obj)
        {
            return DbMgr.CreateUpdateClause("RecurringItemPurchaseLines", GetFields(_obj), "RecurringItemPurchaseLineID", _obj.RecurringItemPurchaseLineID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(RecurringItemPurchaseLine _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("RecurringItemPurchaseLines").Criteria.IsEqual("RecurringItemPurchaseLines", "RecurringItemPurchaseLineID", _obj.RecurringItemPurchaseLineID);
            
            return clause;
        }

        protected override OpResult _Store(RecurringItemPurchaseLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringItemPurchaseLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.RecurringItemPurchaseLineID == null)
            {
                _obj.RecurringItemPurchaseLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(RecurringItemPurchaseLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringItemPurchaseLine object cannot be deleted as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }

            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "RecurringItemPurchaseLine object cannot be deleted as it does not exist");
        }

    }
}
