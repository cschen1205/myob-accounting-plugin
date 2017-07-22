using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Accounts;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbAccountTypeManager : AccountTypeManager
    {
        public DbAccountTypeManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
