using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Elements
{
    public class DbSelectTableCountStatement : DbSelectStatement
    {
        public DbSelectTableCountStatement(DbManager mgr)
            : base(mgr)
        {
            
        }

        public virtual DbSelectTableCountStatement SelectTableCount(string tablename)
        {
            SelectCount();
            From("INFORMATION_SCHEMA");
            Criteria
                .IsEqual("INFORMATION_SCHEMA", "TABLE_TYPE", "BASE TABLE")
                .IsEqual("INFORMATION_SCHEMA", "TABLE_NAME", tablename);
            return this;
        }
    }
}
