using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Purchases;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbProfessionalPurchaseLineManager : ProfessionalPurchaseLineManager
    {
        public DbProfessionalPurchaseLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
