using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Transactions;

namespace Accounting.Db.Myob
{
    public class DbMoneySpentManager : MoneySpentManager
    {
        public DbMoneySpentManager(DbManager mgr)
            : base(mgr)
        {

        }
    }
}
