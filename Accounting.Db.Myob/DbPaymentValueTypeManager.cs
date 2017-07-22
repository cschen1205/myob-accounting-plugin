using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Definitions;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbPaymentValueTypeManager : PaymentValueTypeManager
    {
        public DbPaymentValueTypeManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
