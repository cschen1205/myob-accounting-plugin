using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Db.Elements;

namespace Accounting.Db.SqlClient.Elements
{
    public class SqlClientDbInsertStatement : DbInsertStatement
    {
        public SqlClientDbInsertStatement(DbManager mgr)
            : base(mgr)
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            bool has_auto_int = false;
            foreach(DbElement element in mColumns.Values)
            {
                if (element is DbFieldEntry)
                {
                    DbFieldEntry fieldvalue = (DbFieldEntry)element;
                    if (fieldvalue.IsValidValue && fieldvalue.Type == DbFieldEntry.EntryType.Type_auto_int) 
                    {
                        has_auto_int = true;
                        break;
                    }
                }
            }

            if (has_auto_int)
            {
                sb.AppendFormat("SET IDENTITY_INSERT {0} ON ", DbMgr.FieldAlias(mTable));
            }

            sb.AppendFormat("INSERT INTO {0} (", DbMgr.FieldAlias(mTable));

            int column_counter = 0;
            List<DbElement> values = new List<DbElement>();
            foreach(string columnname in mColumns.Keys)
            {
                DbElement fieldvalue = mColumns[columnname];
                if (fieldvalue.IsValidValue)
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
                if (i == 0)
                {
                    sb.AppendFormat("{0}", values[i]);
                }
                else
                {
                    sb.AppendFormat(", {0}", values[i]);
                }
            }

            sb.Append(")");

            string where_text = WhereText;
            if (where_text != "")
            {
                sb.AppendFormat(" WHERE {0}", where_text);
            }

            if (has_auto_int)
            {
                sb.AppendFormat(" SET IDENTITY_INSERT {0} OFF ", DbMgr.FieldAlias(mTable));
            }

            return sb.ToString();
        }
    }
}
