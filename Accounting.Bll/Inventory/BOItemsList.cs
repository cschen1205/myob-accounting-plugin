using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Accounting.Bll.Inventory
{
    using System.ComponentModel;
    using Accounting.Core;
    using Accounting.Core.Inventory;

    public class BOItemsList : BOList<BOItem>
    {
        private BindingList<Item> mAllItems = new BindingList<Item>();
        private BindingList<Item> mSoldItems = new BindingList<Item>();
        private BindingList<Item> mBoughtItems = new BindingList<Item>();
        private BindingList<Item> mInventoriedItems = new BindingList<Item>();

        public IList<Item> AllItems { get { return mAllItems; } }
        public IList<Item> SoldItems { get { return mSoldItems; } }
        public IList<Item> BoughtItems { get { return mBoughtItems; } }
        public IList<Item> InventoriedItems { get { return mInventoriedItems; } }

        private string mSearchField = "ItemNumber";
        private string mSearchValue = null;

        public static readonly string SEARCH_FIELD="SearchField";
        public static readonly string SEARCH_VALUE="SearchValue";
        public static readonly string ALL_ITEMS_INFORMATION = "AllItemsInformation";
        public static readonly string SOLD_ITEMS_INFORMATION = "SoldItemsInformation";
        public static readonly string BOUGHT_ITEMS_INFORMATION = "BoughtItemsInformation";
        public static readonly string INVENTORIED_ITEMS_INFORMATION = "InventoriedItemsInformation";

        public BOItemsList(Accountant accountant)
            : base(accountant)
        {
            mObjectID = BOType.BOListItem;
            UpdateContent();
            mAccountant.ItemMgr.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(ItemMgr_PropertyChanged);
        }

        protected override void UpdateContent()
        {
            AllItems.Clear();
            IList<Item> all_items = FindAllItems(mSearchField, mSearchValue);
            foreach (Item item in all_items)
            {
                AllItems.Add(item);
            }

            SoldItems.Clear();
            IList<Item> sold_items = FindSoldItems(mSearchField, mSearchValue);
            foreach (Item item in sold_items)
            {
                SoldItems.Add(item);
            }

            BoughtItems.Clear();
            IList<Item> bought_items = FindBoughtItems(mSearchField, mSearchValue);
            foreach (Item item in bought_items)
            {
                BoughtItems.Add(item);
            }

            InventoriedItems.Clear();
            IList<Item> inventoried_items = FindInventoriedItems(mSearchField, mSearchValue);
            foreach (Item item in inventoried_items)
            {
                InventoriedItems.Add(item);
            }
        }
       
        void ItemMgr_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateContent();
            NotifyPropertyChanged(e.PropertyName);
        }

        protected override void InitializeProperties()
        {
            base.InitializeProperties();

            AddProperty(SEARCH_FIELD,
                SEARCH_FIELD,
                SearchField_Get,
                SearchField_Set,
                SearchField_IsEnabled,
                SearchField_IsVisible,
                SearchField_Validate);

            AddProperty(SEARCH_VALUE,
                SEARCH_VALUE,
                SearchValue_Get,
                SearchValue_Set,
                SearchValue_IsEnabled,
                SearchValue_IsVisible,
                SearchValue_Validate);

            AddProperty(ALL_ITEMS_INFORMATION,
                ALL_ITEMS_INFORMATION,
                delegate() { return string.Format("# Records Found: {0}", mAllItems.Count); },
                delegate(object value) { },
                delegate() { return true; },
                delegate() { return true; },
                delegate(object value, ref string error) { return true; });

            AddProperty(SOLD_ITEMS_INFORMATION,
                SOLD_ITEMS_INFORMATION,
                delegate() { return string.Format("# Records Found: {0}", mSoldItems.Count); },
                delegate(object value) { },
                delegate() { return true; },
                delegate() { return true; },
                delegate(object value, ref string error) { return true; });

            AddProperty(BOUGHT_ITEMS_INFORMATION,
                BOUGHT_ITEMS_INFORMATION,
                delegate() { return string.Format("# Records Found: {0}", mBoughtItems.Count); },
                delegate(object value) { },
                delegate() { return true; },
                delegate() { return true; },
                delegate(object value, ref string error) { return true; });

            AddProperty(INVENTORIED_ITEMS_INFORMATION,
                INVENTORIED_ITEMS_INFORMATION,
                delegate() { return string.Format("# Records Found: {0}", mInventoriedItems.Count); },
                delegate(object value) { },
                delegate() { return true; },
                delegate() { return true; },
                delegate(object value, ref string error) { return true; });
        }

        public object SearchField_Get()
        {
            return mSearchField;
        }

        public void SearchField_Set(object value)
        {
            mSearchField = value as string;
        }

        public bool SearchField_IsEnabled()
        {
            return true;
        }

        public bool SearchField_IsVisible()
        {
            return true;
        }

        public bool SearchField_Validate(object value, ref string error)
        {
            return true;
        }

        public object SearchValue_Get()
        {
            return mSearchValue;
        }

        public void SearchValue_Set(object value)
        {
            if(value==null) return;
            string _rhs=value as string;
            if (mSearchValue != _rhs)
            {
                mSearchValue = _rhs;
                UpdateContent();
                NotifyPropertyChanged(ALL_ITEMS_INFORMATION);
                NotifyPropertyChanged(SOLD_ITEMS_INFORMATION);
                NotifyPropertyChanged(BOUGHT_ITEMS_INFORMATION);
                NotifyPropertyChanged(INVENTORIED_ITEMS_INFORMATION);
            }
        }

        public bool SearchValue_IsEnabled()
        {
            return true;
        }

        public bool SearchValue_IsVisible()
        {
            return true;
        }

        public bool SearchValue_Validate(object value, ref string error)
        {
            return true;
        }

        private IList<Item> FindInventoriedItems(string searchField, string searchValue)
        {
            return FindFilteredCollection(false, false, true, searchField, searchValue);
        }

        private IList<Item> FindBoughtItems(string searchField, string searchValue)
        {
            return FindFilteredCollection(false, true, false, searchField, searchValue);
        }

        private IList<Item> FindSoldItems(string searchField, string searchValue)
        {
            return FindFilteredCollection(true, false, false, searchField, searchValue);
        }

        private IList<Item> FindAllItems(string searchField, string searchValue)
        {
            return FindFilteredCollection(false, false, false, searchField, searchValue);
        }

        private IList<Item> FindFilteredCollection(bool sold, bool bought, bool inventoried, string searchField, string searchValue)
        {
            Dictionary<string, string> searchCriteria = new Dictionary<string, string>();
            if (searchValue != null && searchValue != "")
            {
                searchCriteria[searchField] = searchValue;
            }

            return mAccountant.ItemMgr.FindFilteredCollection(sold, bought, inventoried, searchCriteria);
        }
    }
}
