using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Elements
{
    public class DbDeleteStatement : DbStatement
    {
        protected string mTable = null;

        public DbDeleteStatement(DbManager mgr)
        {
            DbMgr = mgr;
        }

        public DbDeleteStatement DeleteFrom(string table)
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

            sb.AppendFormat("DELETE * FROM {0}", DbMgr.FieldAlias(mTable));

            string where_text = WhereText;
            if (where_text != "")
            {
                sb.AppendFormat(" WHERE {0}", where_text);
            }

            return sb.ToString();
        }
    }
}
