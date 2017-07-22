using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Payroll;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbLinkedEmployeeManager : LinkedEmployeeManager
    {
        public DbLinkedEmployeeManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
