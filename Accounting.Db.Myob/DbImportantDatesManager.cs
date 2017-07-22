using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Misc;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbImportantDatesManager : ImportantDatesManager
    {
        public DbImportantDatesManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
