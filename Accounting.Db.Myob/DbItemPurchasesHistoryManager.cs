using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Inventory;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbItemPurchasesHistoryManager : ItemPurchasesHistoryManager
    {
        public DbItemPurchasesHistoryManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
