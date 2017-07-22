using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Definitions;

namespace Accounting.Bll.Definitions
{
    using System.ComponentModel;

    public class BOListItemSize : BOList<BOItemSize>
    {
        private BindingList<ItemSize> mItemSizes = new BindingList<ItemSize>();

        public BOListItemSize(Accountant acc)
            : base(acc)
        {
            mObjectID = BOType.BOListItemSize;
            UpdateContent();
            mAccountant.ItemSizeMgr.PropertyChanged += new PropertyChangedEventHandler(ItemSizeMgr_PropertyChanged);
        }

        void ItemSizeMgr_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateContent();
            NotifyPropertyChanged(e.PropertyName);
        }

        protected override void UpdateContent()
        {
            mItemSizes.Clear();
            IList<ItemSize> itemsizes=mAccountant.ItemSizeMgr.FindAllCollection();
            foreach (ItemSize itemsize in itemsizes)
            {
                mItemSizes.Add(itemsize);
            }
        }

        public IList<ItemSize> DataSource
        {
            get
            {
                return mItemSizes;
            }
        }
    }
}
