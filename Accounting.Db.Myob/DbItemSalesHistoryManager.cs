using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Inventory;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbItemSalesHistoryManager : ItemSalesHistoryManager
    {
        public DbItemSalesHistoryManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
