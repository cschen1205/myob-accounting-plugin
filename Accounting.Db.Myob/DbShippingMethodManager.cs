using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.ShippingMethods;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbShippingMethodManager : ShippingMethodManager
    {
        public DbShippingMethodManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }


}
