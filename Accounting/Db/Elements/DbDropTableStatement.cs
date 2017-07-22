using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Elements
{
    public class DbDropTableStatement : DbStatement
    {
        public DbDropTableStatement()
        {

        }

        string mTablename;
        public DbDropTableStatement DropTable(string tablename)
        {
            mTablename=tablename;
            return this;
        }

        public string Tablename
        {
            get
            {
                return mTablename;
            }
        }

        public override string ToString()
        {
            return string.Format("DROP TABLE {0}", DbMgr.FieldAlias(mTablename));
        }
    }
}
