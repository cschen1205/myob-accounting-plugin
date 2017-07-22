using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Definitions;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbAccountingBasisManager : AccountingBasisManager
    {
        public DbAccountingBasisManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}