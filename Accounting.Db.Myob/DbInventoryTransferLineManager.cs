using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Inventory;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbInventoryTransferLineManager : InventoryTransferLineManager
    {
        public DbInventoryTransferLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        
    }
}
