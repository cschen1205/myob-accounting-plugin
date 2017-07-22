using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Elements
{
    public class DbCurrencyColumn : DbColumn
    {
        public DbCurrencyColumn(params string[] values)
            : base(values)
        {

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("(\"$\"");
            
            for (int i = 0; i != mTables.Count; ++i)
            {
                sb.AppendFormat(" & {0}.{1}", DbMgr.FieldAlias(mTables[i]), DbMgr.FieldAlias(mColumns[i]));
            }
            sb.Append(")");

            if (FieldAlias != null)
            {
                sb.AppendFormat(" AS \"{0}\"", FieldAlias);
            }

            return sb.ToString();
        }
    }
}
