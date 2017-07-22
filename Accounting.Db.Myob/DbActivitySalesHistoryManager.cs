using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Activities;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbActivitySalesHistoryManager : ActivitySalesHistoryManager
    {
        public DbActivitySalesHistoryManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
