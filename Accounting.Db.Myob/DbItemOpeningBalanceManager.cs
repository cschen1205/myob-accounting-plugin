using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Inventory;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbItemOpeningBalanceManager : ItemOpeningBalanceManager
    {
        public DbItemOpeningBalanceManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
