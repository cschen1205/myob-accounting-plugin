using System;
using System.Collections.Generic;
using System.Text;


namespace Accounting.Core.Inventory
{
    using System.ComponentModel;
    using System.Data;
    using System.Data.Common;
    using System.Linq;
    using Accounting.Db;
    using Accounting.Db.Elements;

    public abstract class ItemManager : EntityManager<Item>
    {
        public ItemManager(DbManager mgr) 
            : base(mgr)
        {
            
        }

        protected override Item _GetDbEntity(Item _obj)
        {
            return _FindByTextId(_obj.ItemNumber);
        }

        #region +(Factory Methods)
        protected override Item _CreateDbEntity()
        {
            return new Item(true, this);
        }

        protected override Item _CreateEntity()
        {
            return new Item(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(Item _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["ItemID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ItemID);
            fields["PriceIsInclusive"] = DbMgr.CreateStringFieldEntry(_obj.PriceIsInclusive);
            fields["BaseSellingPrice"] = DbMgr.CreateDoubleFieldEntry(_obj.BaseSellingPrice);
            fields["BuyTaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.BuyTaxCodeID);
            fields["BuyUnitMeasure"] = DbMgr.CreateStringFieldEntry(_obj.BuyUnitMeasure);
            fields["BuyUnitQuantity"] = DbMgr.CreateIntFieldEntry(_obj.BuyUnitQuantity);
            fields["ChangeControl"] = DbMgr.CreateStringFieldEntry(_obj.ChangeControl);
            fields["DefaultReceiveLocationID"] = DbMgr.CreateIntFieldEntry(_obj.DefaultReceiveLocationID);
            fields["DefaultReorderQuantity"] = DbMgr.CreateDoubleFieldEntry(_obj.DefaultReorderQuantity);
            fields["DefaultSellLocationID"] = DbMgr.CreateIntFieldEntry(_obj.DefaultSellLocationID);
            fields["ExpenseAccountID"] = DbMgr.CreateIntFieldEntry(_obj.ExpenseAccountID);
            fields["IncomeAccountID"] = DbMgr.CreateIntFieldEntry(_obj.IncomeAccountID);
            fields["InventoryAccountID"] = DbMgr.CreateIntFieldEntry(_obj.InventoryAccountID);
            fields["ItemDescription"] = DbMgr.CreateStringFieldEntry(_obj.ItemDescription);
            fields["ItemIsBought"] = DbMgr.CreateStringFieldEntry(_obj.ItemIsBought);
            fields["ItemIsInventoried"] = DbMgr.CreateStringFieldEntry(_obj.ItemIsInventoried);
            fields["ItemIsSold"] = DbMgr.CreateStringFieldEntry(_obj.ItemIsSold);
            fields["ItemName"] = DbMgr.CreateStringFieldEntry(_obj.ItemName);
            fields["ItemNumber"] = DbMgr.CreateStringFieldEntry(_obj.ItemNumber);
            fields["LastUnitPrice"] = DbMgr.CreateDoubleFieldEntry(_obj.LastUnitPrice);
            fields["MinLevelBeforeReorder"] = DbMgr.CreateDoubleFieldEntry(_obj.MinLevelBeforeReorder);
            fields["NegativeAverageCost"] = DbMgr.CreateDoubleFieldEntry(_obj.NegativeAverageCost);
            fields["NegativeQuantityOnHand"] = DbMgr.CreateDoubleFieldEntry(_obj.NegativeQuantityOnHand);
            fields["Picture"] = DbMgr.CreateStringFieldEntry(_obj.Picture);
            fields["PositiveAverageCost"] = DbMgr.CreateDoubleFieldEntry(_obj.PositiveAverageCost);
            fields["PrimarySupplierID"] = DbMgr.CreateIntFieldEntry(_obj.PrimarySupplierID);
            fields["PurchaseOnOrder"] = DbMgr.CreateDoubleFieldEntry(_obj.PurchaseOnOrder);
            fields["QuantityAvailable"] = DbMgr.CreateDoubleFieldEntry(_obj.QuantityAvailable);
            fields["QuantityOnHand"] = DbMgr.CreateDoubleFieldEntry(_obj.QuantityOnHand);
            fields["ReceivedOnOrder"] = DbMgr.CreateDoubleFieldEntry(_obj.ReceivedOnOrder);
            fields["SalesTaxCalcBasisID"] = DbMgr.CreateStringFieldEntry(_obj.SalesTaxCalcBasisID);
            fields["SellOnOrder"] = DbMgr.CreateDoubleFieldEntry(_obj.SellOnOrder);
            fields["SellTaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.SellTaxCodeID);
            fields["SellUnitMeasure"] = DbMgr.CreateStringFieldEntry(_obj.SellUnitMeasure);
            fields["SellUnitQuantity"] = DbMgr.CreateIntFieldEntry(_obj.SellUnitQuantity);
            fields["SupplierItemNumber"] = DbMgr.CreateStringFieldEntry(_obj.SupplierItemNumber);
            fields["TaxExclusiveLastPurchasePrice"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveLastPurchasePrice);
            fields["TaxExclusiveStandardCost"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveStandardCost);
            fields["TaxInclusiveLastPurchasePrice"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveLastPurchasePrice);
            fields["TaxInclusiveStandardCost"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveStandardCost);
            fields["UseDescription"] = DbMgr.CreateStringFieldEntry(_obj.UseDescription);
            fields["ValueOnHand"] = DbMgr.CreateDoubleFieldEntry(_obj.ValueOnHand);
            fields["IsInactive"] = DbMgr.CreateStringFieldEntry(_obj.IsInactive);
            fields["CustomField1"] = DbMgr.CreateStringFieldEntry(_obj.CustomField1);
            fields["CustomList1ID"] = DbMgr.CreateIntFieldEntry(_obj.CustomList1ID);
            fields["CustomField2"] = DbMgr.CreateStringFieldEntry(_obj.CustomField2);
            fields["CustomList2ID"] = DbMgr.CreateIntFieldEntry(_obj.CustomList2ID);
            fields["CustomField3"] = DbMgr.CreateStringFieldEntry(_obj.CustomField3);
            fields["CustomList3ID"] = DbMgr.CreateIntFieldEntry(_obj.CustomList3ID);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause.SelectAll()
                .From("Items");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByItemNumber(string ItemNumber)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause.SelectAll()
                .From("Items")
                .Criteria.IsEqual("Items", "ItemNumber", ItemNumber);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByItemName(string ItemName)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause.SelectAll()
                .From("Items")
                .Criteria.IsEqual("Items", "ItemName", ItemName);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByItemNumber(string ItemNumber)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause.SelectCount()
                .From("Items")
                .Criteria.IsEqual("Items", "ItemNumber", ItemNumber);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByItemName(string ItemName)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause.SelectCount()
                .From("Items")
                .Criteria.IsEqual("Items", "ItemName", ItemName);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByItemID(int ItemID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause.SelectAll()
                .From("Items")
                .Criteria.IsEqual("Items", "ItemID", ItemID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByItemID(int ItemID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause.SelectCount()
                .From("Items")
                .Criteria.IsEqual("Items", "ItemID", ItemID);

            return clause;
        }

        public bool ExistsByItemNumber(string ItemNumber)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByItemNumber(ItemNumber)) != 0;
        }

        public bool ExistsByItemName(string ItemName)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByItemName(ItemName)) != 0;
        }

        public bool ExistsByItemID(int? ItemID)
        {
            if (ItemID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByItemID(ItemID.Value)) != 0;
        }

        public override bool Exists(Item _obj)
        {
            return ExistsByItemID(_obj.ItemID);
        }

     

        

        protected override Item _FindByTextId(string ItemNumber)
        {
            if (ExistsByItemNumber(ItemNumber))
            {
                Item _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByItemNumber(ItemNumber));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        public Item FindByItemName(string ItemName)
        {
            if (ExistsByItemName(ItemName))
            {
                Item _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByItemName(ItemName));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override Item _FindByIntId(int? ItemID)
        {
            if(ExistsByItemID(ItemID))
            {
                Item _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByItemID(ItemID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override IList<Item>_FindAllCollection()
        {
            List<Item> items = new List<Item>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Item _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                items.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return items;
        }

        public IList<Item> FindFilteredCollection(bool sold, bool bought, bool inventoried, Dictionary<string, string> keywords)
        {
            if (UseMemoryStore)
            {
                var result = from i in DataStore
                             where i.Match(sold, bought, inventoried, keywords)
                             select i;

                return new BindingList<Item>(result.ToList());
            }
            
            return _FindFilteredCollection(sold, bought, inventoried, keywords);
            
        }

        public IList<Item> FindSoldItemCollection()
        {
            if (UseMemoryStore)
            {
                var result = from i in DataStore
                             where i.ItemIsSold == "Y"
                             select i;
            }

            return _FindFilteredCollection(true, false, false, new Dictionary<string, string>());
        }

        public IList<Item> FindBoughtItemCollection()
        {
            if (UseMemoryStore)
            {
                var result = from i in DataStore
                             where i.ItemIsBought == "Y"
                             select i;
            }

            return _FindFilteredCollection(false, true, false, new Dictionary<string, string>());
        }

        private IList<Item> _FindFilteredCollection(bool sold, bool bought, bool inventoried, Dictionary<string, string> keywords)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
               .SelectAll()
                .From("Items");

            DbCriteria criteria = clause.Criteria;

            if (sold) criteria.IsEqual("Items", "ItemIsSold", "Y");
            if (bought) criteria.IsEqual("Items", "ItemIsBought", "Y");
            if (inventoried) criteria.IsEqual("Items", "ItemIsInventoried", "Y");

            foreach (string key in keywords.Keys)
            {
                criteria.Like("Items", key, keywords[key]);
            }

            BindingList<Item> _grp = new BindingList<Item>();

            Currencies.CurrencyManager cm = RepositoryMgr.CurrencyMgr;

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Item _obj=CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();


            return _grp;
        }

        protected override void LoadFromReader(Item _obj, DbDataReader _reader)
        {
            _obj.PriceIsInclusive = GetString(_reader, ("PriceIsInclusive"));
            _obj.BaseSellingPrice = GetDouble(_reader, ("BaseSellingPrice"));
            _obj.BuyTaxCodeID = GetInt32(_reader, ("BuyTaxCodeID"));
            _obj.BuyUnitMeasure = GetString(_reader, ("BuyUnitMeasure"));
            _obj.BuyUnitQuantity = GetInt32(_reader, ("BuyUnitQuantity"));
            _obj.ChangeControl = GetString(_reader, ("ChangeControl"));
            _obj.DefaultReceiveLocationID = GetInt32(_reader, ("DefaultReceiveLocationID"));
            _obj.DefaultReorderQuantity = GetDouble(_reader, ("DefaultReorderQuantity"));
            _obj.DefaultSellLocationID = GetInt32(_reader, ("DefaultSellLocationID"));
            _obj.ExpenseAccountID = GetInt32(_reader, ("ExpenseAccountID"));
            _obj.IncomeAccountID = GetInt32(_reader, ("IncomeAccountID"));
            _obj.InventoryAccountID = GetInt32(_reader, ("InventoryAccountID"));
            _obj.ItemDescription = GetString(_reader, ("ItemDescription"));
            _obj.ItemID = GetInt32(_reader, ("ItemID"));
            _obj.ItemIsBought = GetString(_reader, ("ItemIsBought"));
            _obj.ItemIsInventoried = GetString(_reader, ("ItemIsInventoried"));
            _obj.ItemIsSold = GetString(_reader, ("ItemIsSold"));
            _obj.ItemName = GetString(_reader, ("ItemName"));
            _obj.ItemNumber = GetString(_reader, ("ItemNumber"));
            _obj.LastUnitPrice = GetDouble(_reader, ("LastUnitPrice"));
            _obj.MinLevelBeforeReorder = GetDouble(_reader, ("MinLevelBeforeReorder"));
            _obj.NegativeAverageCost = GetDouble(_reader, ("NegativeAverageCost"));
            _obj.NegativeQuantityOnHand = GetDouble(_reader, ("NegativeQuantityOnHand"));
            _obj.Picture = GetString(_reader, ("Picture"));
            _obj.PositiveAverageCost = GetDouble(_reader, ("PositiveAverageCost"));
            _obj.PrimarySupplierID = GetInt32(_reader, ("PrimarySupplierID"));
            _obj.PurchaseOnOrder = GetDouble(_reader, ("PurchaseOnOrder"));
            _obj.QuantityAvailable = GetDouble(_reader, ("QuantityAvailable"));
            _obj.QuantityOnHand = GetDouble(_reader, ("QuantityOnHand"));
            _obj.ReceivedOnOrder = GetDouble(_reader, ("ReceivedOnOrder"));
            _obj.SalesTaxCalcBasisID = GetString(_reader, ("SalesTaxCalcBasisID"));
            _obj.SellOnOrder = GetDouble(_reader, ("SellOnOrder"));
            _obj.SellTaxCodeID = GetInt32(_reader, ("SellTaxCodeID"));
            _obj.SellUnitMeasure = GetString(_reader, ("SellUnitMeasure"));
            try
            {
                _obj.SellUnitQuantity = GetInt16(_reader, ("SellUnitQuantity"));
            }
            catch
            {
                _obj.SellUnitQuantity = GetInt32(_reader, ("SellUnitQuantity"));
            }
            _obj.SupplierItemNumber = GetString(_reader, ("SupplierItemNumber"));
            _obj.TaxExclusiveLastPurchasePrice = GetDouble(_reader, ("TaxExclusiveLastPurchasePrice"));
            _obj.TaxExclusiveStandardCost = GetDouble(_reader, ("TaxExclusiveStandardCost"));
            _obj.TaxInclusiveLastPurchasePrice = GetDouble(_reader, ("TaxInclusiveLastPurchasePrice"));
            _obj.TaxInclusiveStandardCost = GetDouble(_reader, ("TaxInclusiveStandardCost"));
            _obj.UseDescription = GetString(_reader, ("UseDescription"));
            _obj.ValueOnHand = GetDouble(_reader, ("ValueOnHand"));
            _obj.IsInactive = GetString(_reader, ("IsInactive"));
            _obj.CustomList1ID = GetInt32(_reader, "CustomList1ID");
            _obj.CustomField1 = GetString(_reader, "CustomField1");
            _obj.CustomList2ID = GetInt32(_reader, "CustomList2ID");
            _obj.CustomField2 = GetString(_reader, "CustomField2");
            _obj.CustomList3ID = GetInt32(_reader, "CustomList3ID");
            _obj.CustomField3 = GetString(_reader, "CustomField3");
        }

        protected override object GetDbProperty(Item _obj, string property_name)
        {
            if (property_name == "SellTaxCode")
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.SellTaxCodeID);
            }
            else if (property_name == "BuyTaxCode")
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.BuyTaxCodeID);
            }
            else if (property_name == "PrimarySupplier")
            {
                return RepositoryMgr.SupplierMgr.FindById(_obj.PrimarySupplierID);
            }
            else if (property_name == "SalesTaxCalcBasis")
            {
                return RepositoryMgr.PriceLevelMgr.FindById(_obj.SalesTaxCalcBasisID);
            }
            else if (property_name == "IncomeAccount")
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.IncomeAccountID);
            }
            else if (property_name == "InventoryAccount")
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.InventoryAccountID);
            }
            else if (property_name == "ExpenseAccount")
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.ExpenseAccountID);
            }
            else if (property_name == "DefaultReceiveLocation")
            {
                return RepositoryMgr.LocationMgr.FindByLocationID(_obj.DefaultReceiveLocationID);
            }
            else if (property_name == "DefaultSellLocation")
            {
                return RepositoryMgr.LocationMgr.FindByLocationID(_obj.DefaultSellLocationID);
            }
            else if (property_name.Equals("ItemAddOn"))
            {
                ItemAddOn _addon=RepositoryMgr.ItemAddOnMgr.FindByItemNumber(_obj.ItemNumber);
                
                return _addon;
                //return RepositoryMgr.ItemAddOnMgr.FindByItemID(_obj.ItemID);
            }
            return null;
        }
    }
}
