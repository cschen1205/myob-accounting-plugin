using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Misc;

namespace Accounting.Db.Myob
{
    public class DbMiscNumberManager : MiscNumberManager
    {
        public DbMiscNumberManager(DbManager mgr)
            : base(mgr)
        {
        }
    }
}
