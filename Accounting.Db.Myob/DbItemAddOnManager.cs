using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Inventory;

namespace Accounting.Db.Myob
{
    public class DbItemAddOnManager : ItemAddOnManager
    {
        public DbItemAddOnManager(DbManager mgr)
            : base(mgr)
        {
        }
    }
}
