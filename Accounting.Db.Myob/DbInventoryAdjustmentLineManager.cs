using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Inventory;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbInventoryAdjustmentLineManager : InventoryAdjustmentLineManager
    {
        public DbInventoryAdjustmentLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        
    }
}
