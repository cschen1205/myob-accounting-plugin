using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.OleDb.Elements
{
    public class OleDbSelectTableCountStatement : DbSelectTableCountStatement
    {
        public OleDbSelectTableCountStatement(DbManager mgr)
            : base(mgr)
        {

        }

        public override DbSelectTableCountStatement SelectTableCount(string tablename)
        {
            SelectCount();
            From("MSysObjects");
            Criteria
                .IsEqual("MSysObjects", "Type ", 1)
                .IsEqual("MSysObjects", "[Name]", tablename);
            return this;
        }
    }
}
