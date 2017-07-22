using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Db.Elements;

namespace Accounting.Db.Oracle.Elements
{
    public class OracleDbInsertStatement : DbInsertStatement
    {
        public OracleDbInsertStatement(DbManager mgr)
            : base(mgr)
        {
            
        }

        private string mSequenceNumber;
        public string SequenceNumber
        {
            get
            {
                return mSequenceNumber;
            }
            set
            {
                mSequenceNumber = value;
            }
        }

        public DbAutoIntFieldEntry AutoIncrementField
        {
            get
            {
                foreach (string columnname in mColumns.Keys)
                {
                    DbElement fieldvalue = mColumns[columnname];

                   
                    if (fieldvalue is DbAutoIntFieldEntry)
                    {
                        return (DbAutoIntFieldEntry)fieldvalue;
                    }
                }
                return null;
            }
        }

        public bool RequireSequenceNumber
        {
            get
            {
                foreach (string columnname in mColumns.Keys)
                {
                    DbElement fieldvalue = mColumns[columnname];

                    bool isValid = fieldvalue.IsValidValue;
                    if (isValid == false)
                    {
                        if (fieldvalue is DbAutoIntFieldEntry)
                        {
                            return true;
                        }
                    }
                }
                return false;
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

                bool isValid = fieldvalue.IsValidValue;
                if (isValid == false)
                {
                    if (fieldvalue is DbAutoIntFieldEntry)
                    {
                        isValid = true;
                    }
                }
                if (isValid)
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
                bool isValid=values[i].IsValidValue;
                if (isValid)
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
                        sb.AppendFormat("{0}", SequenceNumber);
                    }
                    else
                    {
                        sb.AppendFormat(", {0}", SequenceNumber);
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
