using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Db.Elements
{
    public class DbStringFieldEntry : DbFieldEntry
    {
        public DbStringFieldEntry(string _value)
        {
            if (_value == null)
            {
                mValidValue = false;
            }
            mValue = _value;
            mType = EntryType.Type_string;
        }

        public override string ToString()
        {
            string value = SafeSqlLiteral(mValue);
           return string.Format("'{0}'", value);
        }

        protected virtual string SafeSqlLiteral(string inputSQL)
        {
            if (string.IsNullOrEmpty(inputSQL)) return inputSQL;
            inputSQL = inputSQL.Trim();
            return inputSQL.Replace("'", "''");
        }
    }
}
