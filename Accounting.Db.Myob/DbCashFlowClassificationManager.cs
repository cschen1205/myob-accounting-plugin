using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
using System.Data.Common;
using Accounting.Core.Accounts;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbCashFlowClassificationManager : CashFlowClassificationManager
    {
        public DbCashFlowClassificationManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
