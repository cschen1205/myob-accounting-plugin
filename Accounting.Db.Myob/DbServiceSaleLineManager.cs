using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Sales;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbServiceSaleLineManager : ServiceSaleLineManager
    {
        public DbServiceSaleLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
