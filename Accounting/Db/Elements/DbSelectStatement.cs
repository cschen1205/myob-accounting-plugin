using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Elements
{
    public class DbSelectStatement : DbStatement
    {
        private List<DbJoin> mJoins = new List<DbJoin>();
        private List<DbColumn> mColumns = new List<DbColumn>();
        private List<string> mTables = new List<string>();
        private List<DbOrderBy> mOrders = new List<DbOrderBy>();


        private bool mSelectCount = false;
        public DbSelectStatement SelectCount()
        {
            mSelectCount = true;
            return this;
        }

        private bool mSelectDistinct = false;
        public DbSelectStatement SelectDistinct()
        {
            mSelectDistinct = true;
            return this;
        }

        public DbSelectStatement(DbManager mgr)
        {
            DbMgr = mgr;
        }

        public DbSelectStatement Join(params string[] values)
        {
            DbJoin join= DbMgr.CreateJoin(values);
            mJoins.Add(join);
            return this;
        }

        public DbSelectStatement OrderBy(params string[] values)
        {
            DbOrderBy order = DbMgr.CreateOrderBy(values);
            mOrders.Add(order);
            return this;
        }

        public DbSelectStatement SelectColumn(params string[] values)
        {
            mColumns.Add(DbMgr.CreateColumn(values));
            return this;
        }

        public DbSelectStatement SelectCurrencyColumn(params string[] values)
        {
            mColumns.Add(DbMgr.CreateCurrencyColumn(values));
            return this;
        }

        public DbSelectStatement From(string table)
        {
            mTables.Add(table);
            return this;
        }

        public DbSelectStatement SelectAll()
        {
            mColumns = null;
            return this;
        }

        public DbSelectStatement SelectAll(string table)
        {
            return SelectColumn(table, "*");
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
                StringBuilder sb=new StringBuilder();
                int counter = 0;
                if (mJoins.Count != 0)
                {
                    for(int i=0; i != mJoins.Count; ++i)
                    {
                        if (counter == 0)
                        {
                            sb.Append(mJoins[i]);
                        }
                        else
                        {
                            sb.AppendFormat(" AND {0}", mJoins[i]);
                        }
                        counter++;
                    }
                }

                if(Criteria != null && Criteria.IsEmpty == false)
                {
                    if (counter == 0)
                    {
                        sb.Append(Criteria);
                    }
                    else
                    {
                        sb.AppendFormat(" AND {0}", Criteria);
                    }
                }

                return sb.ToString();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (mSelectCount)
            {
                sb.Append("SELECT COUNT(*)");
            }
            else
            {
                if (mColumns == null)
                {
                    sb.Append("SELECT *");
                }
                else
                {
                    sb.Append("SELECT");
                    if (mSelectDistinct)
                    {
                        sb.Append(" DISTINCT");
                    }

                    for (int i = 0; i != mColumns.Count; ++i)
                    {
                        if (i == 0)
                        {
                            sb.AppendFormat(" {0}", mColumns[i]);
                        }
                        else
                        {
                            sb.AppendFormat(", {0}", mColumns[i]);
                        }
                    }
                }
            }
           
            for (int i = 0; i != mTables.Count; ++i)
            {
                if (i == 0)
                {
                    sb.AppendFormat(" FROM {0}", DbMgr.FieldAlias(mTables[i]));
                }
                else
                {
                    sb.AppendFormat(", {0}", DbMgr.FieldAlias(mTables[i]));
                }
            }
            string where_text = WhereText;
            if (where_text != "")
            {
                sb.AppendFormat(" WHERE {0}", where_text);
            }

            for(int i=0; i != mOrders.Count; ++i)
            {
                if (i == 0)
                {
                    sb.AppendFormat(" ORDER BY {0}", mOrders[i]);
                }
                else
                {
                    sb.AppendFormat(" AND {0}", mOrders[i]);
                }
            }
            //sb.Append(";");

           

            return sb.ToString();
        }
    }
}
