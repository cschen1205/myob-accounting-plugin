using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Elements
{
    public class DbUpdateStatement : DbStatement
    {
        private Dictionary<string, DbElement> mColumns = new Dictionary<string, DbElement>();
        private string mTable = null;

        public DbUpdateStatement(DbManager mgr)
        {
            DbMgr = mgr;
        }

        public DbUpdateStatement UpdateColumn(string columnname, DbElement fieldvalue)
        {
            mColumns[columnname]=fieldvalue;
            return this;
        }

        public DbUpdateStatement UpdateColumns(Dictionary<string, DbFieldEntry> fields)
        {
            foreach (string columnname in fields.Keys)
            {
                mColumns[columnname] = fields[columnname];
            }
            return this;
        }

        public DbUpdateStatement From(string table)
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

        private string WhereText
        {
            get
            {
                return Criteria.ToString();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("UPDATE {0} SET", DbMgr.FieldAlias(mTable));

            int column_counter = 0;
            foreach(string columnname in mColumns.Keys)
            {
                DbElement fieldvalue = mColumns[columnname];
                if (fieldvalue is DbFieldEntry)
                {
                    DbFieldEntry _fieldvalue = fieldvalue as DbFieldEntry;
                    if (! _fieldvalue.IsValidValue)
                    {
                        continue;
                    }
                    if (_fieldvalue.SkipOnUpdate)
                    {
                        continue;
                    }
                }
                if (column_counter == 0)
                {
                    sb.AppendFormat(" {0} = {1}", DbMgr.FieldAlias(columnname), fieldvalue);
                }
                else
                {
                    sb.AppendFormat(", {0} = {1}", DbMgr.FieldAlias(columnname), fieldvalue);
                }
                column_counter++;
            }

            string where_text = WhereText;
            if (where_text != "")
            {
                sb.AppendFormat(" WHERE {0}", where_text);
            }

            return sb.ToString();
        }
    }
}
