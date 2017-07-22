using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Elements
{
    public class DbColumn : DbElement
    {
        public DbColumn(params string[] values)
        {
            int i = 0;
            int pair_count = values.Length / 2;
            pair_count *= 2;
            for (; i < pair_count; i += 2)
            {
                mTables.Add(values[i]);
                mColumns.Add(values[i + 1]);
            }
            if (values.Length % 2 == 1)
            {
                FieldAlias = values[values.Length - 1];
                FieldAlias = FieldAlias.Replace(" ", "");
            }
        }

        protected List<string> mTables = new List<string>();
        protected List<string> mColumns = new List<string>();

        public string FieldAlias
        {
            get;
            set;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (mTables.Count > 1)
            {
                sb.Append("(");
            }
            for (int i = 0; i != mTables.Count; ++i)
            {
                if(i==0)
                {
                    sb.AppendFormat("{0}.{1}", DbMgr.FieldAlias(mTables[i]), DbMgr.FieldAlias(mColumns[i]));
                }
                else
                {
                    sb.AppendFormat(" & {0}.{1}", DbMgr.FieldAlias(mTables[i]), DbMgr.FieldAlias(mColumns[i]));
                }
            }
            if (mTables.Count > 1)
            {
                sb.Append(")");
            }
            if (FieldAlias != null)
            {
                sb.AppendFormat(" AS {0}", FieldAlias);
            }

            return sb.ToString();
        }
    }
}
