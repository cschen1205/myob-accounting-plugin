using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Sales;

namespace Accounting.Db.Myob
{
    public class DbSalesHistoryManager : SalesHistoryManager
    {
        public DbSalesHistoryManager(DbManager mgr)
            : base(mgr)
        {

        }
    }
}
