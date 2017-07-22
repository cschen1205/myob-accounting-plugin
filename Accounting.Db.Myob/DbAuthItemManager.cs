using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Security;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbAuthItemManager : AuthItemManager
    {
        public DbAuthItemManager(DbManager mgr)
            : base(mgr)
        {
        }
    }
}
