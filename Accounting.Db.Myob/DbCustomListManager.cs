using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Misc;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbCustomListManager : CustomListManager
    {
        public DbCustomListManager(DbManager mgr)
            : base(mgr)
        {
           
        }
    }
}
