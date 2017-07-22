using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Payroll;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbWageDollarHistoryManager : WageDollarHistoryManager
    {
        public DbWageDollarHistoryManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
