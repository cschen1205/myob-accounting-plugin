using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Cards;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbCardManager : CardManager
    {
        public DbCardManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
