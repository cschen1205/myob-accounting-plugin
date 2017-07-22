using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Transactions;

namespace Accounting.Db.Myob
{
    public class DbRecurringMoneyReceivedManager : RecurringMoneyReceivedManager
    {
        public DbRecurringMoneyReceivedManager(DbManager mgr)
            : base(mgr)
        {

        }
    }
}
