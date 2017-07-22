using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Security;
using Accounting.Bll.Sales;
using Accounting.Bll.Purchases;
using Accounting.Bll.Inventory;
using Accounting.Bll.Jobs;
using Accounting.Bll.Accounts;
using Accounting.Bll.Journals;
using Accounting.Bll.Cards;

namespace Accounting.Bll.Security
{
    public sealed class BOAuthItemFactory
    {
        private List<AuthItem> roots;

        public List<AuthItem> AuthItemRoots
        {
            get { return roots; }
        }

        Accountant mAccountant;
        public BOAuthItemFactory(Accountant acc)
        {
            mAccountant = acc;
            Build();
        }

        private IList<AuthItem> Build()
        {
            roots = new List<AuthItem>();
            roots.Add(CreateBOAuthItem_Sales());
            roots.Add(CreateBOAuthItem_Purchases());
            roots.Add(CreateBOAuthItem_Accounts());
            roots.Add(CreateBOAuthItem_Inventory());
            roots.Add(CreateBOAuthItem_Jobs());
            roots.Add(CreateBOAuthItem_Cards());
            roots.Add(CreateBOAuthItem_Analysis());

            AuthItemManager aim = mAccountant.AuthItemMgr;
            foreach (AuthItem root in roots)
            {
                UpdateDb(root, aim);
            }
            return roots;
        }

        private void UpdateDb(AuthItem root, AuthItemManager aim)
        {
            //if (!aim.Exists(root))
            {
                    aim.Store(root);
               
            }
            foreach(AuthItem item in root.Children)
            {
                UpdateDb(item, aim);
            }
        }

        private void DecorateAuthItem(AuthItem root, string ItemName)
        {
            AuthItem item = mAccountant.AuthItemMgr.FindById(ItemName);
            if (item != null)
            {
                //if (item.ItemName.Equals("SaleQuote.PersistBusinessObject"))
                //{
                //    throw new NullReferenceException(item.ItemName);
                //}
                //if (item.ItemID == null)
                //{
                //    throw new NullReferenceException(string.Format("Item with name {0} has ItemID=null when fetched from Db!", ItemName));
                //}
                root.ItemID = item.ItemID;
            }
            //else
            //{
            //    throw new NullReferenceException(string.Format("Item with name {0} could not be found!", ItemName));
            //}
        }

        public AuthItem CreateBOAuthItem_Analysis()
        {
            AuthItem root = mAccountant.AuthItemMgr.CreateEntity();
            root.DisplayName = BOType.BOAnalysis;
            root.ItemName = BOType.BOAnalysis;
            root.Description = BOType.BOAnalysis;
            DecorateAuthItem(root, root.ItemName);

            CreateBOAuthItem(root, BOType.BOAnalysisCashFlow, "CashFlow");
            CreateBOAuthItem(root, BOType.BOAnalysisJobs, "Jobs");
            CreateBOAuthItem(root, BOType.BOAnalysisProfitAndLoss, "ProfitAndLoss");
            CreateBOAuthItem(root, BOType.BOAnalysisBalanceSheet, "BalanceSheet");

            return root;
        }

        public AuthItem CreateBOAuthItem(AuthItem parent_item, string ItemName, string DisplayName)
        {
            AuthItem _item = mAccountant.AuthItemMgr.CreateEntity();
            _item.Type = AuthItem.AuthItemType.Category;
            _item.ItemName = ItemName;
            _item.DisplayName = DisplayName;

            AuthItem child_item_attribute = mAccountant.AuthItemMgr.CreateEntity();
            child_item_attribute.Type = AuthItem.AuthItemType.Attribute;
            child_item_attribute.ItemName = string.Format("{0}.{1}", ItemName, BOPropertyAttrType.Visible);
            child_item_attribute.Description = child_item_attribute.ItemName;
            child_item_attribute.DisplayName = child_item_attribute.ItemName;
            child_item_attribute.ParentItem = _item;
            _item.Children.Add(child_item_attribute);
            DecorateAuthItem(child_item_attribute, child_item_attribute.ItemName);

            child_item_attribute = mAccountant.AuthItemMgr.CreateEntity();
            child_item_attribute.Type = AuthItem.AuthItemType.Attribute;
            child_item_attribute.ItemName = string.Format("{0}.{1}", ItemName, BOPropertyAttrType.Enabled);
            child_item_attribute.Description = child_item_attribute.ItemName;
            child_item_attribute.DisplayName = child_item_attribute.ItemName;
            child_item_attribute.ParentItem = _item;
            _item.Children.Add(child_item_attribute);
            DecorateAuthItem(child_item_attribute, child_item_attribute.ItemName);

            _item.ParentItem = parent_item;
            parent_item.Children.Add(_item);
            DecorateAuthItem(_item, ItemName);

            return _item;
        }

        public AuthItem CreateBOAuthItem_Sales()
        {
            AuthItem root = mAccountant.AuthItemMgr.CreateEntity();
            root.DisplayName = BOType.BOSales;
            root.ItemName = BOType.BOSales;
            root.Description = BOType.BOSales;
            DecorateAuthItem(root, root.ItemName);

            CreateBOAuthItem(root, mAccountant.CreateSaleQuote());
            CreateBOAuthItem(root, mAccountant.CreateSaleOrder());
            CreateBOAuthItem(root, mAccountant.CreateSaleOpenInvoice());
            CreateBOAuthItem(root, mAccountant.CreateSaleCreditReturn());
            CreateBOAuthItem(root, mAccountant.CreateSaleClosedInvoice());

            CreateBOListAuthItem(root, mAccountant.Sales);

            return root;
        }

        public AuthItem CreateBOAuthItem_Purchases()
        {
            AuthItem root = mAccountant.AuthItemMgr.CreateEntity();
            root.DisplayName = BOType.BOPurchases;
            root.ItemName = BOType.BOPurchases;
            root.Description = BOType.BOPurchases;
            DecorateAuthItem(root, root.ItemName);

            CreateBOAuthItem(root, mAccountant.CreatePurchaseQuote());
            CreateBOAuthItem(root, mAccountant.CreatePurchaseOrder());
            CreateBOAuthItem(root, mAccountant.CreatePurchaseOpenBill());
            CreateBOAuthItem(root, mAccountant.CreatePurchaseDebitReturn());
            CreateBOAuthItem(root, mAccountant.CreatePurchaseClosedBill());

            CreateBOListAuthItem(root, mAccountant.Purchases);

            return root;
        }

        public AuthItem CreateBOAuthItem_Inventory()
        {
            AuthItem root = mAccountant.AuthItemMgr.CreateEntity();
            root.DisplayName = BOType.BOInventory;
            root.ItemName = BOType.BOInventory;
            root.Description = BOType.BOInventory;
            DecorateAuthItem(root, root.ItemName);
            
            CreateBOAuthItem(root, mAccountant.CreateItem());

            CreateBOListAuthItem(root, mAccountant.Items);

            return root;
        }

        public AuthItem CreateBOAuthItem_Accounts()
        {
            AuthItem root = mAccountant.AuthItemMgr.CreateEntity();
            root.DisplayName = BOType.BOAccounts;
            root.ItemName = BOType.BOAccounts;
            root.Description = BOType.BOAccounts;
            DecorateAuthItem(root, root.ItemName);

            CreateBOAuthItem(root, mAccountant.CreateAccount());

            CreateBOListAuthItem(root, mAccountant.TransactionJournals);
            CreateBOListAuthItem(root, mAccountant.Accounts);

            return root;
        }

        public AuthItem CreateBOAuthItem_Jobs()
        {
            AuthItem root = mAccountant.AuthItemMgr.CreateEntity();
            root.DisplayName = BOType.BOProject;
            root.ItemName = BOType.BOProject;
            root.Description = BOType.BOProject;
            DecorateAuthItem(root, root.ItemName);

            CreateBOAuthItem(root, mAccountant.CreateJob());

            CreateBOListAuthItem(root, mAccountant.Jobs);

            return root;
        }


        public AuthItem CreateBOAuthItem_Cards()
        {
            AuthItem root = mAccountant.AuthItemMgr.CreateEntity();
            root.DisplayName = BOType.BOCards;
            root.ItemName = BOType.BOCards;
            root.Description = BOType.BOCards;
            DecorateAuthItem(root, root.ItemName);

            CreateBOAuthItem(root, mAccountant.CreateCustomer());
            CreateBOAuthItem(root, mAccountant.CreateSupplier());
            CreateBOAuthItem(root, mAccountant.CreateEmployee());

            CreateBOListAuthItem(root, mAccountant.AllCards);

            return root;
        }

        public void CreateBOListAuthItem(AuthItem parent_item, BusinessObject _obj)
        {
            AuthItem child_item = CreateBOListAuthItem(_obj);
            child_item.ParentItem = parent_item;
            parent_item.Children.Add(child_item);
            DecorateAuthItem(child_item, child_item.ItemName);
        }

        public AuthItem CreateBOListAuthItem(BusinessObject _obj)
        {
            AuthItem _item = mAccountant.AuthItemMgr.CreateEntity();
            _item.Type = AuthItem.AuthItemType.Category;
            _item.Tag = _obj;
            _item.GetItemNameFunc = delegate(object tag)
            {
                BusinessObject _tag = tag as BusinessObject;
                return _tag.ObjectID;
            };

            AuthItem child_item_attribute = mAccountant.AuthItemMgr.CreateEntity();
            child_item_attribute.Type = AuthItem.AuthItemType.Attribute;
            child_item_attribute.ItemName = string.Format("{0}.{1}", _obj.ObjectID, BOPropertyAttrType.Visible);
            child_item_attribute.Description = child_item_attribute.ItemName;
            child_item_attribute.DisplayName = child_item_attribute.ItemName;
            child_item_attribute.ParentItem = _item;
            _item.Children.Add(child_item_attribute);
            DecorateAuthItem(child_item_attribute, child_item_attribute.ItemName);

            child_item_attribute = mAccountant.AuthItemMgr.CreateEntity();
            child_item_attribute.Type = AuthItem.AuthItemType.Attribute;
            child_item_attribute.ItemName = string.Format("{0}.{1}", _obj.ObjectID, BOPropertyAttrType.Enabled);
            child_item_attribute.Description = child_item_attribute.ItemName;
            child_item_attribute.DisplayName = child_item_attribute.ItemName;
            child_item_attribute.ParentItem = _item;
            _item.Children.Add(child_item_attribute);
            DecorateAuthItem(child_item_attribute, child_item_attribute.ItemName);

            child_item_attribute = mAccountant.AuthItemMgr.CreateEntity();
            child_item_attribute.Type = AuthItem.AuthItemType.Attribute;
            child_item_attribute.ItemName = string.Format("{0}.{1}", _obj.ObjectID, BOPropertyAttrType.ViewAll);
            child_item_attribute.Description = child_item_attribute.ItemName;
            child_item_attribute.DisplayName = child_item_attribute.ItemName;
            child_item_attribute.ParentItem = _item;
            _item.Children.Add(child_item_attribute);
            DecorateAuthItem(child_item_attribute, child_item_attribute.ItemName);

            Dictionary<string, BOProperty> properties = _obj.Properties;
            foreach (BOProperty property in properties.Values)
            {
                if (property.PropertyName.Equals(BusinessObject.PERSIST_OBJECT)) continue;
                if (property.PropertyName.Equals(BusinessObject.DELETE_OBJECT)) continue;

                AuthItem child_item = mAccountant.AuthItemMgr.CreateEntity();
                child_item.Type = AuthItem.AuthItemType.Property;
                child_item.Tag = property;
                child_item.GetItemNameFunc = delegate(object tag)
                {
                    BOProperty _tag = tag as BOProperty;
                    return string.Format("{0}.{1}", _obj.ObjectID, _tag.PropertyName);
                };
                child_item.ParentItem = _item;
                _item.Children.Add(child_item);
                DecorateAuthItem(child_item, child_item.ItemName);

                child_item_attribute = mAccountant.AuthItemMgr.CreateEntity();
                child_item_attribute.Type = AuthItem.AuthItemType.Attribute;
                child_item_attribute.ItemName = string.Format("{0}.{1}.{2}", _obj.ObjectID, property.PropertyName, BOPropertyAttrType.Visible);
                child_item_attribute.Description = child_item_attribute.ItemName;
                child_item_attribute.DisplayName = BOPropertyAttrType.Visible;
                child_item_attribute.ParentItem = child_item;
                child_item.Children.Add(child_item_attribute);
                DecorateAuthItem(child_item_attribute, child_item_attribute.ItemName);

                child_item_attribute = mAccountant.AuthItemMgr.CreateEntity();
                child_item_attribute.Type = AuthItem.AuthItemType.Attribute;
                child_item_attribute.ItemName = string.Format("{0}.{1}.{2}", _obj.ObjectID, property.PropertyName, BOPropertyAttrType.Enabled);
                child_item_attribute.Description = child_item_attribute.ItemName;
                child_item_attribute.DisplayName = BOPropertyAttrType.Enabled;
                child_item_attribute.ParentItem = child_item;
                child_item.Children.Add(child_item_attribute);
                DecorateAuthItem(child_item_attribute, child_item_attribute.ItemName);
            }
            return _item;
        }

        public void CreateBOAuthItem(AuthItem parent_item, BusinessObject _obj)
        {
            AuthItem child_item = CreateBOAuthItem(_obj);
            child_item.ParentItem = parent_item;
            parent_item.Children.Add(child_item);
            DecorateAuthItem(child_item, child_item.ItemName);
        }

        public AuthItem CreateBOAuthItem(BusinessObject _obj)
        {
            AuthItem _item = mAccountant.AuthItemMgr.CreateEntity();
            _item.Type = AuthItem.AuthItemType.Category;

            AuthItem child_item_attribute = mAccountant.AuthItemMgr.CreateEntity();
            child_item_attribute.Type = AuthItem.AuthItemType.Attribute;
            child_item_attribute.ItemName = string.Format("{0}.{1}", _obj.ObjectID, BOPropertyAttrType.Visible);
            child_item_attribute.Description = child_item_attribute.ItemName;
            child_item_attribute.DisplayName = child_item_attribute.ItemName;
            child_item_attribute.ParentItem = _item;
            _item.Children.Add(child_item_attribute);
            DecorateAuthItem(child_item_attribute, child_item_attribute.ItemName);

            child_item_attribute = mAccountant.AuthItemMgr.CreateEntity();
            child_item_attribute.Type = AuthItem.AuthItemType.Attribute;
            child_item_attribute.ItemName = string.Format("{0}.{1}", _obj.ObjectID, BOPropertyAttrType.Enabled);
            child_item_attribute.Description = child_item_attribute.ItemName;
            child_item_attribute.DisplayName = child_item_attribute.ItemName;
            child_item_attribute.ParentItem = _item;
            _item.Children.Add(child_item_attribute);
            DecorateAuthItem(child_item_attribute, child_item_attribute.ItemName);

            _item.Tag = _obj;
            _item.GetItemNameFunc = delegate(object tag)
            {
                BusinessObject _tag = tag as BusinessObject;
                return _tag.ObjectID;
            };

            Dictionary<string, BOProperty> properties = _obj.Properties;
            foreach (BOProperty property in properties.Values)
            {
                AuthItem child_item = mAccountant.AuthItemMgr.CreateEntity();
                child_item.Type = AuthItem.AuthItemType.Property;
                child_item.Tag = property;
                child_item.GetItemNameFunc = delegate(object tag)
                {
                    BOProperty _tag = tag as BOProperty;
                    return string.Format("{0}.{1}", _obj.ObjectID, _tag.PropertyName);
                };
                child_item.ParentItem = _item;
                _item.Children.Add(child_item);
                DecorateAuthItem(child_item, child_item.ItemName);

                child_item_attribute = mAccountant.AuthItemMgr.CreateEntity();
                child_item_attribute.Type = AuthItem.AuthItemType.Attribute;
                child_item_attribute.ItemName = string.Format("{0}.{1}.{2}", _obj.ObjectID, property.PropertyName, BOPropertyAttrType.Visible);
                child_item_attribute.Description = child_item_attribute.ItemName;
                child_item_attribute.DisplayName = child_item_attribute.ItemName;
                child_item_attribute.ParentItem = child_item;
                child_item.Children.Add(child_item_attribute);
                DecorateAuthItem(child_item_attribute, child_item_attribute.ItemName);

                child_item_attribute = mAccountant.AuthItemMgr.CreateEntity();
                child_item_attribute.Type = AuthItem.AuthItemType.Attribute;
                child_item_attribute.ItemName = string.Format("{0}.{1}.{2}", _obj.ObjectID, property.PropertyName, BOPropertyAttrType.Enabled);
                child_item_attribute.Description = child_item_attribute.ItemName;
                child_item_attribute.DisplayName = child_item_attribute.ItemName;
                child_item_attribute.ParentItem = child_item;
                child_item.Children.Add(child_item_attribute);
                DecorateAuthItem(child_item_attribute, child_item_attribute.ItemName);
            }
            return _item;
        }
    }
}
