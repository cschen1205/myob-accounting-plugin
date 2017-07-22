using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.TaxCodes;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbTaxInformationManager : TaxInformationManager
    {
        public DbTaxInformationManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
