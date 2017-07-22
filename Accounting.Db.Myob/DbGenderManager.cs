using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Definitions;

namespace Accounting.Db.Myob
{
    public class DbGenderManager : GenderManager
    {
        public DbGenderManager(DbManager mgr)
            : base(mgr)
        {
        }
    }
}
