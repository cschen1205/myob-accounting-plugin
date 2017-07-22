using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Db2.Elements
{
    public class Db2InsertStatement : DbInsertStatement
    {
        public Db2InsertStatement(DbManager mgr)
            : base(mgr)
        {

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("INSERT INTO {0} (", DbMgr.FieldAlias(mTable));

            int column_counter = 0;
            List<DbElement> values = new List<DbElement>();
            foreach (string columnname in mColumns.Keys)
            {
                DbElement fieldvalue = mColumns[columnname];
                if (fieldvalue.IsValidValue && !(fieldvalue is DbAutoIntFieldEntry))
                {
                    if (column_counter == 0)
                    {
                        sb.AppendFormat("{0}", DbMgr.FieldAlias(columnname));
                    }
                    else
                    {
                        sb.AppendFormat(", {0}", DbMgr.FieldAlias(columnname));
                    }
                    values.Add(mColumns[columnname]);
                    column_counter++;
                }
            }

            sb.Append(") VALUES (");

            for (int i = 0; i != values.Count; ++i)
            {
                DbElement fieldvalue = values[i];
                if (fieldvalue is DbAutoIntFieldEntry)
                {
                    if (i == 0)
                    {
                        sb.AppendFormat("{0}", values[i]);
                    }
                    else
                    {
                        sb.AppendFormat(", {0}", values[i]);
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        sb.AppendFormat("{0}", values[i]);
                    }
                    else
                    {
                        sb.AppendFormat(", {0}", values[i]);
                    }
                }
            }

            sb.Append(")");

            string where_text = WhereText;
            if (where_text != "")
            {
                sb.AppendFormat(" WHERE {0}", where_text);
            }

            return sb.ToString();
        }
    }
}
