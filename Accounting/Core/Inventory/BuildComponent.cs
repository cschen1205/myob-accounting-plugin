using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Inventory
{
    public class BuildComponent : Entity
    {
        internal BuildComponent(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mBuildComponentID;
        public int? BuildComponentID
        {
            get { return mBuildComponentID; }
            set
            {
                mBuildComponentID = value;
                NotifyPropertyChanged("BuildComponentID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("BuildComponentID", BuildComponentID);
            }
        }

        #region BuiltItem
        private BuiltItem mBuiltItem = null;
        public BuiltItem BuiltItem
        {
            get
            {
                if (mBuiltItem == null) mBuiltItem = (BuiltItem)BuildProperty(this, "BuiltItem");
                return mBuiltItem;
            }
            set
            {
                mBuiltItem = value;
                NotifyPropertyChanged("BuiltItem");
            }
        }
        private int? mBuiltItemID;
        public int? BuiltItemID
        {
            get
            {
                if (mBuiltItem != null) return mBuiltItem.BuiltItemID;
                return mBuiltItemID;
            }
            set
            {
                mBuiltItemID = value;
                NotifyPropertyChanged("BuiltItemID");
            }
        }
        #endregion

        private int? mSequenceNumber;
        public int? SequenceNumber
        {
            get { return mSequenceNumber; }
            set
            {
                mSequenceNumber = value;
                NotifyPropertyChanged("SequenceNumber");
            }
        }

        #region Component
        private Item mComponent = null;
        public Item Component
        {
            get
            {
                if (mComponent == null) mComponent = (Item)BuildProperty(this, "Component");
                return mComponent;
            }
            set
            {
                mComponent = value;
                NotifyPropertyChanged("Component");
            }
        }
        private int? mComponentID;
        public int? ComponentID
        {
            get
            {
                if (mComponent != null) return mComponent.ItemID;
                return mComponentID;
            }
            set
            {
                mComponentID = value;
                NotifyPropertyChanged("ComponentID");
            }
        }
        #endregion

        public double QuantityNeeded;

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is BuildComponent)
            {
                BuildComponent _obj = obj as BuildComponent;
                return _obj.BuildComponentID == BuildComponentID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
