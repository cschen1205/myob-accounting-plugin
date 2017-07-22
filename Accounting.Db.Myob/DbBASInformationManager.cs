using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Misc;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbBASInformationManager : BASInformationManager
    {
        public DbBASInformationManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
