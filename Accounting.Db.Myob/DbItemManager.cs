using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Db.Myob
{
    using Accounting.Core;
    using System.Data.Common;
    using System.Data.Odbc;
    using Accounting.Core.Inventory;
    using Accounting.Db;
    using Accounting.Db.Elements;

    public class DbItemManager : ItemManager
    {
        public DbItemManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override OpResult _Store(Item _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Item object cannot be created as it is null");
            }

            bool is_creating = !Exists(_obj);

            DbInsertStatement clause = DbMgr.CreateInsertClause();
            clause.InsertColumn("ItemNumber", DbMgr.CreateStringFieldEntry(_obj.ItemNumber));
            clause.InsertColumn("ItemName", DbMgr.CreateStringFieldEntry(_obj.ItemName));


            if (_obj.ItemIsBought == "Y")
            {
                clause.InsertColumn("Buy", DbMgr.CreateIntFieldEntry(1));

                string account_number_text = _obj.ExpenseAccount.AccountNumber;  //Xianshun: Defect 14 - 15
                account_number_text = account_number_text.Replace("-", "");
                //Console.WriteLine(account_number_text);
                int account_number;
                if (int.TryParse(account_number_text, out account_number))
                {
                    clause.InsertColumn("ExpenseAccount", DbMgr.CreateIntFieldEntry(account_number));
                }

                if (_obj.PrimarySupplier != null)
                {
                    clause.InsertColumn("PrimarySupplier", DbMgr.CreateStringFieldEntry(_obj.PrimarySupplier.Name));
                }

                clause.InsertColumn("SupplierItemNumber", DbMgr.CreateStringFieldEntry(_obj.SupplierItemNumber));

                if (_obj.BuyTaxCode != null)
                {
                    clause.InsertColumn("TaxCodeWhenBought", DbMgr.CreateStringFieldEntry(_obj.BuyTaxCode.Code));
                }

                clause.InsertColumn("BuyUnitMeasure", DbMgr.CreateStringFieldEntry(_obj.BuyUnitMeasure));
                clause.InsertColumn("NumberItemsBuyUnit", DbMgr.CreateIntFieldEntry(_obj.BuyUnitQuantity));
                clause.InsertColumn("ReorderQuantity", DbMgr.CreateDoubleFieldEntry(_obj.DefaultReorderQuantity));
                clause.InsertColumn("MinimumLevel", DbMgr.CreateDoubleFieldEntry(_obj.MinLevelBeforeReorder));
                clause.InsertColumn("StandardCost", DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveStandardCost));
            }

            
            if (_obj.ItemIsSold == "Y")
            {
                clause.InsertColumn("Sell", DbMgr.CreateIntFieldEntry(1));

                string account_number_text = _obj.IncomeAccount.AccountNumber;
                account_number_text = account_number_text.Replace("-", "");
                //Console.WriteLine(account_number_text);
                int account_number;
                if (int.TryParse(account_number_text, out account_number))
                {
                    clause.InsertColumn("IncomeAccount", DbMgr.CreateIntFieldEntry(account_number));
                }

                clause.InsertColumn("SellingPrice", DbMgr.CreateDoubleFieldEntry(_obj.BaseSellingPrice));
                clause.InsertColumn("SellUnitMeasure", DbMgr.CreateStringFieldEntry(_obj.SellUnitMeasure));

                if (_obj.SellTaxCode != null)
                {
                    clause.InsertColumn("TaxCodeWhenSold", DbMgr.CreateStringFieldEntry(_obj.SellTaxCode.Code));
                }

                if (_obj.PriceIsInclusive == "Y")
                {
                    clause.InsertColumn("SellPriceInclusive", DbMgr.CreateIntFieldEntry(1));
                }

                clause.InsertColumn("SalesTaxCalcMethod", DbMgr.CreateIntFieldEntry(_obj.SalesTaxCalcBasis.SalesTaxCalcMethod));
                clause.InsertColumn("NumberItemsSellUnit", DbMgr.CreateIntFieldEntry(_obj.SellUnitQuantity));

            }

           
            if (_obj.ItemIsInventoried == "Y")
            {
                clause.InsertColumn("Inventory", DbMgr.CreateIntFieldEntry(1));
                string account_number_text = _obj.InventoryAccount.AccountNumber;
                account_number_text = account_number_text.Replace("-", "");
                //Console.WriteLine(account_number_text);
                int account_number;
                if (int.TryParse(account_number_text, out account_number))
                {
                    clause.InsertColumn("AssetAccount", DbMgr.CreateIntFieldEntry(account_number));
                }
            }

            clause.InsertColumn("ItemPicture", DbMgr.CreateStringFieldEntry(_obj.Picture));
            clause.InsertColumn("Description", DbMgr.CreateStringFieldEntry(_obj.ItemDescription));
            if (_obj.UseDescription == "Y")
            {
                clause.InsertColumn("UseDescriptionOnSale", DbMgr.CreateIntFieldEntry(1));
            }

            clause.InsertColumn("CustomField1", DbMgr.CreateStringFieldEntry(_obj.CustomField1));
            clause.InsertColumn("CustomField2", DbMgr.CreateStringFieldEntry(_obj.CustomField2));
            clause.InsertColumn("CustomField3", DbMgr.CreateStringFieldEntry(_obj.CustomField3));


            clause.InsertColumn("InactiveItem", DbMgr.CreateStringFieldEntry(_obj.IsInactive));
            


            clause.Into("Import_Items");

            Console.Write(clause.ToString());


            OdbcConnection m_OdbcConnection = DbMgr.DbConnection as OdbcConnection;
            OdbcCommand cmdSQLInsert = m_OdbcConnection.CreateCommand();
            OdbcTransaction myTrans = m_OdbcConnection.BeginTransaction();
            try
            {
                cmdSQLInsert.CommandText = clause.ToString();
                cmdSQLInsert.Transaction = myTrans;
                cmdSQLInsert.ExecuteNonQuery();
                myTrans.Commit();
            }
            catch (OdbcException ex)
            {
                myTrans.Rollback();
                Log(ex.Message);
                Console.WriteLine(ex.ToString());
                if (is_creating)
                {
                    return OpResult.NotifyStoreAction(OpResult.ResultStatus.CreatedWithException, _obj, ex.ToString());
                }
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.UpdatedWithException, _obj, ex.ToString());
                
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                Console.WriteLine(ex.ToString());
                if (is_creating)
                {
                    return OpResult.NotifyStoreAction(OpResult.ResultStatus.CreatedWithException, _obj, ex.ToString());
                }
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.UpdatedWithException, _obj, ex.ToString());
            }

            if (is_creating)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
            }
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
        }
    }
}
