using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Cards;

namespace Accounting.Db.Myob
{
    public class DbCardActivityManager : CardActivityManager
    {
        public DbCardActivityManager(DbManager mgr)
            : base(mgr)
        {

        }
    }
}
