using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Sales;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbSaleLineManager : SaleLineManager
    {
        public DbSaleLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
