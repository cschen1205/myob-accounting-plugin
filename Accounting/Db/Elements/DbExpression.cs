using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core;
using Accounting.Db.Elements;

namespace Accounting.Db.Elements
{
    public class DbExpression : DbElement
    {
        private DbColumn mColumn;
        private DbElement mFieldvalue;
        private SqlCondition mCondition;

        private Dictionary<SqlCondition, string> mConditionMapping = new Dictionary<SqlCondition, string>();
        public enum SqlCondition
        {
            IsEqual,
            IsLessEqual,
            IsGreaterEqual,
            Like,
            IsLess,
            IsGreater
        };

        public string this[SqlCondition index]
        {
            get
            {
                return mConditionMapping[index];
            }
            set
            {
                mConditionMapping[index] = value;
            }
        }

        public DbExpression(DbColumn column, DbFieldEntry fieldvalue, SqlCondition condition)
        {
            mColumn = column;
            mFieldvalue = fieldvalue;
            mCondition = condition;

            this[SqlCondition.IsEqual] = "=";
            this[SqlCondition.IsLessEqual] = "<=";
            this[SqlCondition.IsGreaterEqual] = ">=";
            this[SqlCondition.IsLess] = "<";
            this[SqlCondition.IsGreater] = ">";
            this[SqlCondition.Like] = "LIKE";
        }

        public DbExpression(DbColumn column, DbSelectStatement select_clause, SqlCondition condition)
        {
            mColumn = column;
            mFieldvalue = select_clause;
            mCondition = condition;

            this[SqlCondition.IsEqual] = "=";
            this[SqlCondition.IsLessEqual] = "<=";
            this[SqlCondition.IsGreaterEqual] = ">=";
            this[SqlCondition.IsLess] = "<";
            this[SqlCondition.IsGreater] = ">";
            this[SqlCondition.Like] = "LIKE";
        }

        public override string ToString()
        {
            if (mFieldvalue is DbStringFieldEntry && mCondition == SqlCondition.Like)
            {
                return string.Format("{0} {1} \'%{2}%\'", mColumn, this[mCondition], ((DbStringFieldEntry)mFieldvalue).Value);
            }
            else if (mFieldvalue is DbSelectStatement)
            {
                return string.Format("{0} {1} ({2})", mColumn, this[mCondition], mFieldvalue);
            }
            if (mFieldvalue.IsValidValue)
            {
                return string.Format("{0} {1} {2}", mColumn, this[mCondition], mFieldvalue.SelectExpression);
            }
            return "";
        }
    }
}
