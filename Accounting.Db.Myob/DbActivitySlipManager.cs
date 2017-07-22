using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Activities;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbActivitySlipManager : ActivitySlipManager
    {
        public DbActivitySlipManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
