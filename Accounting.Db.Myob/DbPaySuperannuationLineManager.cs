using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Transactions;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbPaySuperannuationLineManager : PaySuperannuationLineManager
    {
        public DbPaySuperannuationLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
