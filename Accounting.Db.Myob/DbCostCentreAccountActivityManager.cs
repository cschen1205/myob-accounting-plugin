using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.CostCentres;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Myob
{
    public class DbCostCentreAccountActivityManager : CostCentreAccountActivityManager
    {
        public DbCostCentreAccountActivityManager(DbManager mgr)
            : base(mgr)
        {
            
        }

    }
}
