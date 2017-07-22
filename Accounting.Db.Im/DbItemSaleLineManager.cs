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
    public sealed class DbItemSaleLineManager : ItemSaleLineManager
    {
        public DbItemSaleLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //ItemSaleLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["ItemSaleLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["SaleLineID"] = DbManager.FIELDTYPE.INTEGER;
            fields["SaleID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["TaxExclusiveTotal"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveTotal"] = DbManager.FIELDTYPE.DOUBLE;
            fields["IsMultipleJob"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxBasisAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxBasisAmountIsInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Quantity"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ItemID"] = DbManager.FIELDTYPE.INTEGER;
            fields["SalesTaxCalBasisID"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["TaxExclusiveUnitPrice"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveUnitPrice"] = DbManager.FIELDTYPE.DOUBLE;
            fields["Discount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CostOfGoodsSoldAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["LocationID"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["SaleID"] = "Sales(SaleID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
            foreignKeys["SaleLineID"] = "SaleLines(SaleLineID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";
            foreignKeys["ItemID"] = "Items(ItemID)";
            foreignKeys["SalesTaxCalBasisID"] = "PriceLevels(SalesTaxCalBasisID)";
            foreignKeys["LocationID"] = "Locations(LocationID)";
             * */

            TableCommands["ItemSaleLines"] = DbMgr.CreateTableCommand("ItemSaleLines", fields, "ItemSaleLineID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(ItemSaleLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            
            return DbMgr.CreateInsertClause("ItemSaleLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(ItemSaleLine _obj)
        {
            return DbMgr.CreateUpdateClause("ItemSaleLines", GetFields(_obj), "ItemSaleLineID", _obj.ItemSaleLineID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(ItemSaleLine _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("ItemSaleLines").Criteria.IsEqual("ItemSaleLines", "ItemSaleLineID", _obj.ItemSaleLineID);
            
            return clause;
        }

        protected override OpResult _Store(ItemSaleLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ItemSaleLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.ItemSaleLineID == null)
            {
                _obj.ItemSaleLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(ItemSaleLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ItemSaleLine object cannot be deleted as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }

            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "ItemSaleLine object cannot be deleted as it does not exist");
        }

    }
}
