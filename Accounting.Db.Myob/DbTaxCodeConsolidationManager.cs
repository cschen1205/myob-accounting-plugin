using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.TaxCodes;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbTaxCodeConsolidationManager : TaxCodeConsolidationManager
    {
        public DbTaxCodeConsolidationManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}