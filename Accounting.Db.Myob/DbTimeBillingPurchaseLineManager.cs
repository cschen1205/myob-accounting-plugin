using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.Odbc;
using Accounting.Db;
using Accounting.Core.Purchases;

namespace Accounting.Db.Myob
{
    public class DbTimeBillingPurchaseLineManager : TimeBillingPurchaseLineManager
    {
        public DbTimeBillingPurchaseLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
