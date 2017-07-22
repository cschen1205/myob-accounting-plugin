using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Inventory;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbBuiltItemManager : BuiltItemManager
    {
        public DbBuiltItemManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
