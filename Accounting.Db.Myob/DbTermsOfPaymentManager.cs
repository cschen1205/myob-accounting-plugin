using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Terms;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbTermsOfPaymentManager : TermsOfPaymentManager
    {
        public DbTermsOfPaymentManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
