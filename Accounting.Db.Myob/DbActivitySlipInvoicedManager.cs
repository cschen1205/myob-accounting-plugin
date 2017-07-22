using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Activities;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbActivitySlipInvoicedManager : ActivitySlipInvoicedManager
    {
        public DbActivitySlipInvoicedManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
