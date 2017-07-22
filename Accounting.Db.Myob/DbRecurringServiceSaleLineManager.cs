using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Sales;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbRecurringServiceSaleLineManager : RecurringServiceSaleLineManager
    {
        public DbRecurringServiceSaleLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
