using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Accounts;

namespace Accounting.Db.Myob
{
    public class DbLinkedAccountManager : LinkedAccountManager
    {
        public DbLinkedAccountManager(DbManager mgr)
            : base(mgr)
        {

        }
    }
}
