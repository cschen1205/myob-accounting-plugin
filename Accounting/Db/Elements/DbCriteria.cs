using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Elements
{
    public class DbCriteria : DbElement
    {
        private List<DbExpression> mANDClauses=new List<DbExpression>();
        private List<DbExpression> mORClauses = new List<DbExpression>();
        private List<DbCriteria> mANDCriteria = new List<DbCriteria>();
        private List<DbCriteria> mORCriteria = new List<DbCriteria>();
        public enum ConcatMode
        {
            AND,
            OR
        };

        public bool IsEmpty
        {
            get
            {
                return mANDClauses.Count == 0 && mORClauses.Count == 0 && mANDCriteria.Count == 0 && mORCriteria.Count == 0;
            }
        }

        public DbCriteria And(params DbCriteria[] criteria)
        {
            foreach (DbCriteria criterion in criteria)
            {
                mANDCriteria.Add(criterion);
            }
            return this;
        }

        public DbCriteria Or(params DbCriteria[] criteria)
        {
            foreach (DbCriteria criterion in criteria)
            {
                mORCriteria.Add(criterion);
            }
            return this;
        }

        public DbCriteria And(params DbExpression[] clauses)
        {
            foreach (DbExpression clause in clauses)
            {
                mANDClauses.Add(clause);
            }
            return this;
        }

        public virtual DbExpression CreateExpression(string table, string fieldname, DbFieldEntry fieldvalue, DbExpression.SqlCondition condition)
        {
            return DbMgr.CreateExpression(DbMgr.CreateColumn(table, fieldname), fieldvalue, condition);
        }

        public virtual DbExpression CreateExpression(string table, string fieldname, DbSelectStatement select_clause, DbExpression.SqlCondition condition)
        {
            return DbMgr.CreateExpression(DbMgr.CreateColumn(table, fieldname), select_clause, condition);
        }

        public DbCriteria IsGreaterEqual(string table, string fieldname, int? fieldvalue, ConcatMode mode)
        {
            return Add(table, fieldname, DbMgr.CreateIntFieldEntry(fieldvalue), DbExpression.SqlCondition.IsGreaterEqual, mode);
        }

        public DbCriteria IsLessEqual(string table, string fieldname, int? fieldvalue, ConcatMode mode)
        {
            return Add(table, fieldname, DbMgr.CreateIntFieldEntry(fieldvalue), DbExpression.SqlCondition.IsLessEqual, mode);
        }

        public DbCriteria IsGreaterEqual(string table, string fieldname, DateTime fieldvalue, ConcatMode mode)
        {
            return Add(table, fieldname, DbMgr.CreateDateTimeFieldEntry(fieldvalue), DbExpression.SqlCondition.IsGreaterEqual, mode);
        }

        public DbCriteria IsLessEqual(string table, string fieldname, DateTime fieldvalue, ConcatMode mode)
        {
            return Add(table, fieldname, DbMgr.CreateDateTimeFieldEntry(fieldvalue), DbExpression.SqlCondition.IsLessEqual, mode);
        }

        public DbCriteria IsEqual(string table, string fieldname, int? fieldvalue, ConcatMode mode)
        {
            return Add(table, fieldname, DbMgr.CreateIntFieldEntry(fieldvalue), DbExpression.SqlCondition.IsEqual, mode);
        }

        public DbCriteria IsEqual(string table, string fieldname, string fieldvalue, ConcatMode mode)
        {
            return Add(table, fieldname, DbMgr.CreateStringFieldEntry(fieldvalue), DbExpression.SqlCondition.IsEqual, mode);
        }

        public DbCriteria Like(string table, string fieldname, string fieldvalue, ConcatMode mode)
        {
            return Add(table, fieldname, DbMgr.CreateStringFieldEntry(fieldvalue), DbExpression.SqlCondition.Like, mode);
        }

        public DbCriteria IsEqual(string table, string fieldname, int? fieldvalue)
        {
            return Add(table, fieldname, DbMgr.CreateIntFieldEntry(fieldvalue), DbExpression.SqlCondition.IsEqual, ConcatMode.AND);
        }

        public DbCriteria IsEqual(string table, string fieldname, DbSelectStatement select_clause)
        {
            return Add(table, fieldname, select_clause, DbExpression.SqlCondition.IsEqual, ConcatMode.AND);
        }
        public DbCriteria IsEqual(string table, string fieldname, string fieldvalue)
        {
            return Add(table, fieldname, DbMgr.CreateStringFieldEntry(fieldvalue), DbExpression.SqlCondition.IsEqual, ConcatMode.AND);
        }

        public DbCriteria IsGreaterEqual(string table, string fieldname, int? fieldvalue)
        {
            return Add(table, fieldname, DbMgr.CreateIntFieldEntry(fieldvalue), DbExpression.SqlCondition.IsGreaterEqual, ConcatMode.AND);
        }

        public DbCriteria IsLessEqual(string table, string fieldname, int? fieldvalue)
        {
            return Add(table, fieldname, DbMgr.CreateIntFieldEntry(fieldvalue), DbExpression.SqlCondition.IsLessEqual, ConcatMode.AND);
        }

        public DbCriteria IsGreaterEqual(string table, string fieldname, DateTime? fieldvalue)
        {
            return Add(table, fieldname, DbMgr.CreateDateTimeFieldEntry(fieldvalue), DbExpression.SqlCondition.IsGreaterEqual, ConcatMode.AND);
        }

        public DbCriteria IsLessEqual(string table, string fieldname, DateTime? fieldvalue)
        {
            return Add(table, fieldname, DbMgr.CreateDateTimeFieldEntry(fieldvalue), DbExpression.SqlCondition.IsLessEqual, ConcatMode.AND);
        }

        public DbCriteria Like(string table, string fieldname, string fieldvalue)
        {
            return Add(table, fieldname, DbMgr.CreateStringFieldEntry(fieldvalue), DbExpression.SqlCondition.Like, ConcatMode.AND);
        }

        public DbCriteria Add(string table, string fieldname, DbFieldEntry fieldvalue, DbExpression.SqlCondition condition, ConcatMode mode)
        {
            if (mode == ConcatMode.AND)
            {
                And(CreateExpression(table, fieldname, fieldvalue, condition));
            }
            else if(mode==ConcatMode.OR)
            {
                Or(CreateExpression(table, fieldname, fieldvalue, condition));
            }
            return this;
        }

        public DbCriteria Add(string table, string fieldname, DbSelectStatement select_clause, DbExpression.SqlCondition condition, ConcatMode mode)
        {
            if (mode == ConcatMode.AND)
            {
                And(CreateExpression(table, fieldname, select_clause, condition));
            }
            else if (mode == ConcatMode.OR)
            {
                Or(CreateExpression(table, fieldname, select_clause, condition));
            }
            return this;
        }
       
        public DbCriteria Or(params DbExpression[] clauses)
        {
            foreach (DbExpression clause in clauses)
            {
                mORClauses.Add(clause);
            }
            return this;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int counter = 0;
            string exp;
            for(int i=0; i != mANDClauses.Count; ++i)
            {
                exp=mANDClauses[i].ToString();
                if (string.IsNullOrEmpty(exp)) continue;
                if (counter == 0)
                {
                    sb.AppendFormat("({0})", exp);
                }
                else
                {
                    sb.AppendFormat(" AND ({0})", exp);
                }
                counter++;
            }
            for (int i = 0; i != mORClauses.Count; ++i)
            {
                exp = mORClauses[i].ToString();
                if (string.IsNullOrEmpty(exp)) continue;
                if (counter == 0)
                {
                    sb.AppendFormat("({0})", exp);
                }
                else
                {
                    sb.AppendFormat(" OR ({0})", exp);
                }
                counter++;
            }
            for (int i = 0; i != mANDCriteria.Count; ++i)
            {
                if (mANDCriteria[i].IsEmpty) continue;
                if (counter == 0)
                {
                    sb.AppendFormat("({0})", mANDCriteria[i]);
                }
                else
                {
                    sb.AppendFormat(" AND ({0})", mANDCriteria[i]);
                }
                counter++;
            }
            for (int i = 0; i != mORCriteria.Count; ++i)
            {
                if (mORCriteria[i].IsEmpty) continue;
                if (counter == 0)
                {
                    sb.AppendFormat("({0})", mORCriteria[i]);
                }
                else
                {
                    sb.AppendFormat(" OR ({0})", mORCriteria[i]);
                }
                counter++;
            }

            return sb.ToString();
        }

    }
}
