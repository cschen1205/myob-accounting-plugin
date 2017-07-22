using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Transactions;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbPayLiabilityLineManager : PayLiabilityLineManager
    {
        public DbPayLiabilityLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
