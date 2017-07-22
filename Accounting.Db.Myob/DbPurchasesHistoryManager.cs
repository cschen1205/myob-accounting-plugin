using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Purchases;

namespace Accounting.Db.Myob
{
    public class DbPurchasesHistoryManager : PurchasesHistoryManager
    {
        public DbPurchasesHistoryManager(DbManager mgr)
            : base(mgr)
        {

        }
    }
}
