using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Sales;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Myob
{
    public sealed class DbCustomerDepositManager : CustomerDepositManager
    {
        public DbCustomerDepositManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        
    }
}
