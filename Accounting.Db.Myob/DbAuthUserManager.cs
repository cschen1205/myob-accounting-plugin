using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Security;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbAuthUserManager : AuthUserManager
    {
        public DbAuthUserManager(DbManager mgr)
            : base(mgr)
        {
        }
    }
}
