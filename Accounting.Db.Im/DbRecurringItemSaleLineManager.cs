using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Sales;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbRecurringItemSaleLineManager : RecurringItemSaleLineManager
    {
        public DbRecurringItemSaleLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //RecurringItemSaleLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringItemSaleLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["RecurringSaleLineID"] = DbManager.FIELDTYPE.INTEGER;
            fields["RecurringSaleID"] = DbManager.FIELDTYPE.INTEGER;
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
            fields["SalesTaxCalBasisID"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["TaxBasisAmount"] = DbManager.FIELDTYPE.DOUBLE;
            /*
            foreignKeys["ItemID"] = "Items(ItemID)";
            foreignKeys["LocationID"] = "Locations(LocationID)";
            foreignKeys["SalesTaxCalBasisID"] = "PriceLevels(SalesTaxCalBasisID)";
            foreignKeys["RecurringSaleLineID"] = "RecurringSaleLines(RecurringSaleLineID)";
            foreignKeys["RecurringSaleID"] = "RecurringSales(RecurringSaleID)";          
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";                        
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";              
             * */

            TableCommands["RecurringItemSaleLines"] = DbMgr.CreateTableCommand("RecurringItemSaleLines", fields, "RecurringItemSaleLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(RecurringItemSaleLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            
            return DbMgr.CreateInsertClause("RecurringItemSaleLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(RecurringItemSaleLine _obj)
        {
            return DbMgr.CreateUpdateClause("RecurringItemSaleLines", GetFields(_obj), "RecurringItemSaleLineID", _obj.RecurringItemSaleLineID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(RecurringItemSaleLine _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("RecurringItemSaleLines").Criteria.IsEqual("RecurringItemSaleLines", "RecurringItemSaleLineID", _obj.RecurringItemSaleLineID);
            
            return clause;
        }

        protected override OpResult _Store(RecurringItemSaleLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringItemSaleLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.RecurringItemSaleLineID == null)
            {
                _obj.RecurringItemSaleLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(RecurringItemSaleLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringItemSaleLine object cannot be deleted as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }

            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "RecurringItemSaleLine object cannot be deleted as it does not exist"); ;
        }

    }
}
