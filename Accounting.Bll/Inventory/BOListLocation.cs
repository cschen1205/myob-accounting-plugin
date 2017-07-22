using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core;
using Accounting.Core.Inventory;

namespace Accounting.Bll.Inventory
{
    public class BOListLocation : BOList<BOLocation>
    {
        public BOListLocation(Accountant accountant)
            : base(accountant)
        {
            mObjectID = BOType.BOListLocation;
        }
    }
}
