using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Elements
{
    public class DbGenerateTableStatement : DbStatement
    {
        protected string mTablename;
        protected Dictionary<string, string> mPrimaryKeys = new Dictionary<string, string>();
        protected Dictionary<string, DbManager.FIELDTYPE> mFields = new Dictionary<string, DbManager.FIELDTYPE>();
        protected Dictionary<string, string> mReferences = new Dictionary<string, string>();

        public DbGenerateTableStatement CreateTable(string tablename)
        {
            mTablename = tablename;
            return this;
        }

        public string Tablename
        {
            get { return mTablename; }
        }

        public DbGenerateTableStatement WithPrimaryKey(string fieldname)
        {
            mPrimaryKeys[fieldname]=fieldname;
            return this;
        }

        public DbGenerateTableStatement WithField(string fieldname, DbManager.FIELDTYPE fieldtype)
        {
            mFields[fieldname] = fieldtype;
            return this;
        }

        public DbGenerateTableStatement WithReference(string tablename, string foreignkey)
        {
            mReferences[foreignkey] = tablename;
            return this;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CREATE TABLE {0} (", mDbMgr.FieldAlias(mTablename));

            int counter=0;
            foreach (string fieldname in mFields.Keys)
            {
                if(counter==0)
                {
                    counter++;
                }
                else
                {
                    sb.Append(", ");
                }
                if (mPrimaryKeys.ContainsKey(fieldname))
                {
                    sb.AppendFormat("{0}  {1} PRIMARY KEY",  mDbMgr.FieldAlias(fieldname), mDbMgr.TranslateFieldType(mFields[fieldname]));
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
