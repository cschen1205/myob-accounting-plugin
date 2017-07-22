using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Db;
using Accounting.Core.Cards;

namespace Accounting.Db.Myob
{
    public class DbContactLogManager : ContactLogManager
    {
        public DbContactLogManager(DbManager mgr)
            : base(mgr)
        {

        }
    }
}
