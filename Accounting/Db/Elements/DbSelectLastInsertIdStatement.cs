using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Elements
{
    public class DbSelectLastInsertIdStatement : DbStatement
    {
        public DbSelectLastInsertIdStatement(DbManager mgr)
        {
            DbMgr = mgr;
        }

        public override string ToString()
        {
            return "SELECT @@IDENTITY";
        }
    }
}
