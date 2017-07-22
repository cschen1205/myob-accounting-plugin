using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Inventory;

namespace Accounting.Bll.Inventory
{
    public class BOLocation : BusinessObject
    {
        private Location mDataProxy;
        private Location mDataSource;

        public BOLocation(Accountant acc, Location _obj, BOContext state)
            : base(acc, state)
        {
            mObjectID = BOType.BOLocation;
            mDataProxy = _obj.Clone() as Location;
            mDataSource = _obj;
        }

        protected override Accounting.Core.OpResult _Delete()
        {
            return mAccountant.LocationMgr.Delete(mDataSource);
        }

        protected override Accounting.Core.OpResult _Record()
        {
            mDataSource.AssignFrom(mDataProxy);
            return mAccountant.LocationMgr.Store(mDataSource);
        }
    }
}
