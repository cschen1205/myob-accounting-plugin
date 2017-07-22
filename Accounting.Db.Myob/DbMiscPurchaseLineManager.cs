using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Purchases;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbMiscPurchaseLineManager : MiscPurchaseLineManager
    {
        public DbMiscPurchaseLineManager(DbManager mgr)
            :base(mgr)
        {
            
        }
    }
}
