using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Purchases;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Myob
{
    public sealed class DbSettledDebitLineManager : SettledDebitLineManager
    {
        public DbSettledDebitLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        
    }
}
