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
    public sealed class DbSupplierPaymentManager : SupplierPaymentManager
    {
        public DbSupplierPaymentManager(DbManager mgr)
            : base(mgr)
        {
            
        }

       

    }
}
