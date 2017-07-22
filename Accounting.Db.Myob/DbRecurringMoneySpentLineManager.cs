using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Transactions;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Myob
{
    public class DbRecurringMoneySpentLineManager : RecurringMoneySpentLineManager
    {
        public DbRecurringMoneySpentLineManager(DbManager mgr)
            : base(mgr)
        {

        }
    }
}
