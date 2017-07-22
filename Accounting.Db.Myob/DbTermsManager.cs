using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Terms;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbTermsManager : TermsManager
    {
        public DbTermsManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
