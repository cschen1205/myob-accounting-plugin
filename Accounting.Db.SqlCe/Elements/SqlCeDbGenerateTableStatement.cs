using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Db.Elements;

namespace Accounting.Db.SqlCe.Elements
{
    public class SqlCeDbGenerateTableStatement : DbGenerateTableStatement
    {
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CREATE TABLE {0} (", DbMgr.FieldAlias(mTablename));

            int counter = 0;
            foreach (string fieldname in mFields.Keys)
            {
                if (counter == 0)
                {
                    counter++;
                }
                else
                {
                    sb.Append(", ");
                }
                if (mPrimaryKeys.ContainsKey(fieldname))
                {
                    DbManager.FIELDTYPE fieldtype = mFields[fieldname];
                    if (fieldtype == DbManager.FIELDTYPE.INTEGER_INDEXED)
                    {
                        //INTEGER NOT NULL PRIMARY KEY AUTO_INCREMENT
                        sb.AppendFormat("{0}  INT IDENTITY(1, 1) PRIMARY KEY CLUSTERED", mDbMgr.FieldAlias(fieldname));
                    }
                    else
                    {
                        string fieldtype_name = mDbMgr.TranslateFieldType(fieldtype);
                        sb.AppendFormat("{0}  {1} PRIMARY KEY", mDbMgr.FieldAlias(fieldname), fieldtype_name);
                    }
                }
                else
                {
                    if (mReferences.ContainsKey(fieldname))
                    {
                        sb.AppendFormat("{0} {1} REFERENCES {2}", mDbMgr.FieldAlias(fieldname), mFields[fieldname], mDbMgr.FieldAlias(mReferences[fieldname]));
                    }
                    else
                    {
                        sb.AppendFormat("{0} {1}", mDbMgr.FieldAlias(fieldname), mDbMgr.TranslateFieldType(mFields[fieldname]));
                    }
                }
            }

            sb.Append(");");

            return sb.ToString();
        }
    }
}
