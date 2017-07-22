using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Db.Elements;

namespace Accounting.Db.Oracle.Elements
{
    public class OracleDbGenerateTableStatement : DbGenerateTableStatement
    {
        public bool HasAutoInt
        {
            get
            {
                foreach (string fieldname in mFields.Keys)
                {
                    if (mPrimaryKeys.ContainsKey(fieldname))
                    {
                        DbManager.FIELDTYPE fieldtype = mFields[fieldname];
                        if (fieldtype == DbManager.FIELDTYPE.INTEGER_INDEXED)
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
 
            sb.AppendFormat("CREATE TABLE {0} (", mDbMgr.FieldAlias(mTablename));

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
                        sb.AppendFormat("{0} INTEGER PRIMARY KEY", mDbMgr.FieldAlias(fieldname));
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

            sb.Append(")");
            

            return sb.ToString();
        }

        /*
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("BEGIN ");
            sb.Append("execute immediate '");

            sb.AppendFormat("CREATE TABLE {0} (", mTablename);

            bool auto_increment_field_found = false;

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
                        sb.AppendFormat("{0} INTEGER PRIMARY KEY", mDbMgr.FieldAlias(fieldname));
                        auto_increment_field_found = true;
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

            sb.Append(")");
            sb.Append("'; ");

            if (auto_increment_field_found)
            {
               

                //create sequence for autoincrement
                sb.Append("execute immediate '");
                sb.AppendFormat("CREATE  SEQUENCE {0}_sequence START WITH 1 INCREMENT BY 1", mTablename);
                sb.Append("'; ");

               

                //create trigger for autoincrement field on insert
                sb.Append("execute immediate '");
                sb.AppendFormat("CREATE OR REPLACE TRIGGER {0}_trigger", mTablename);
                sb.AppendFormat(" BEFORE INSERT ON {0}", mTablename);
                sb.Append(" REFERENCING NEW AS NEW FOR EACH ROW ");
                sb.AppendFormat(" BEGIN SELECT {0}_sequence.nextval INTO :NEW.ID FROM dual; END", mTablename);
                sb.Append("'; ");
            }

            sb.Append(" END; ");

            //DbMgr.Log(sb.ToString());

            return sb.ToString();
        }
        */
    }
}
