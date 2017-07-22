using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Misc;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbDataFileInformationManager : DataFileInformationManager
    {
        public DbDataFileInformationManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
