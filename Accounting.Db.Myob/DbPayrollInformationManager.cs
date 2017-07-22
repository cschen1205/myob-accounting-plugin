using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Misc;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbPayrollInformationManager : PayrollInformationManager
    {
        public DbPayrollInformationManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}