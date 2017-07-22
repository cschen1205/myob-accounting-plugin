using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Elements
{
    public class DbInsertStatement : DbStatement
    {
        protected Dictionary<string, DbElement> mColumns = new Dictionary<string, DbElement>();
        protected string mTable = null;

        public string Tablename
        {
            get { return mTable; }
        }

        public DbInsertStatement(DbManager mgr)
        {
            DbMgr = mgr;
        }

        public DbInsertStatement InsertColumn(string columnname, DbElement fieldvalue)
        {
            mColumns[columnname]=fieldvalue;
            return this;
        }

        public DbInsertStatement InsertColumns(Dictionary<string, DbFieldEntry> fields)
        {
            foreach (string columnname in fields.Keys)
            {
                mColumns[columnname] = fields[columnname];
            }
            return this;
        }

        public DbInsertStatement Into(string table)
        {
            mTable = table;
            return this;
        }

        private DbCriteria mCriteria = null;
        public DbCriteria Criteria
        {
            get
            {
                if (mCriteria == null)
                {
                    mCriteria = DbMgr.CreateCriteria();
                }
                return mCriteria;
            }
        }

        protected string WhereText
        {
            get
            {
                return Criteria.ToString();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

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
                    values.Add(fieldvalue);
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

            return sb.ToString();
        }
    }
}
