using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Accounting.Db.Elements
{
    public class DbTableCommand 
    {
        private string mTablename;
        private Dictionary<string, DbManager.FIELDTYPE> mFields;
        private string mPrimaryKey;
        private Dictionary<string, string> mForeignKeys;
        private DbManager mDbMgr;

        public DbTableCommand(DbManager mgr, string tablename, Dictionary<string, DbManager.FIELDTYPE> fields, string primaryKey, Dictionary<string, string> foreignKeys)
        {
            mDbMgr = mgr;
            mTablename = tablename;
            mFields = fields;
            mPrimaryKey = primaryKey;
            mForeignKeys = foreignKeys;
        }

        protected virtual DbGenerateTableStatement BuildClause()
        {
            DbGenerateTableStatement clause = mDbMgr.CreateGenerateTableClause();

            clause
                .CreateTable(mTablename)
                .WithPrimaryKey(mPrimaryKey);

            foreach (string fieldname in mFields.Keys)
            {
                clause.WithField(fieldname, mFields[fieldname]);
            }

            foreach (string fieldname in mForeignKeys.Keys)
            {
                clause.WithReference(fieldname, mForeignKeys[fieldname]);
            }

            return clause;
        }

        public void RecreateTable()
        {
            if (mDbMgr.TableExists(mTablename))
            {
                mDbMgr.ExecuteNonQuery(mDbMgr.CreateDropTable().DropTable(mTablename));
            }

            DbGenerateTableStatement clause = BuildClause();

            mDbMgr.ExecuteNonQuery(clause);
        }

        public override string ToString()
        {
            DbGenerateTableStatement clause = BuildClause();

            return string.Format("TableCmd: {0}", clause.ToString());
        }

        public void CreateTable()
        {
            if (mDbMgr.TableExists(mTablename))
            {
                return;
            }

            DbGenerateTableStatement clause = mDbMgr.CreateGenerateTableClause();

            clause
                .CreateTable(mTablename)
                .WithPrimaryKey(mPrimaryKey);

            foreach (string fieldname in mFields.Keys)
            {
                clause.WithField(fieldname, mFields[fieldname]);
            }

            foreach (string fieldname in mForeignKeys.Keys)
            {
                clause.WithReference(fieldname, mForeignKeys[fieldname]);
            }

            mDbMgr.ExecuteNonQuery(clause);
        }

        /*
        public List<string> GetTables()
        {
            List<string> tables = new List<string>();

            DbSelectStatement clause = mDbMgr.CreateSelectClause();

            clause
                .SelectColumn("INFORMATION_SCHEMA.TABLES", "TABLE_NAME")
                .From("INFORMATION_SCHEMA.TABLES")
                .Criteria
                    .IsEqual("INFORMATION_SCHEMA.TABLES", "TABLE_TYPE", "BASE TABLE");

            //string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'";

            using (DbTableCommand cmm = mDbMgr.CreateDbCommand(clause))
            {
                DbDataReader dr = cmm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        tables.Add((string)dr["TABLE_NAME"]);
                    }
                }
                dr.Close();
            }

            return tables;
        }



        public Dictionary<string, string> GetColumnInfo(string tableName)
        {
            Dictionary<string, string> columns = new Dictionary<string, string>();

            DbSelectStatement clause = mDbMgr.CreateSelectClause();

            clause
                .SelectColumn("information_schema.columns", "")
                .SelectColumn("information_schema.columns", "")
                .From("information_schema.columns")
                .OrderBy("information_schema.columns", "ordinal_position")
                .Criteria
                    .IsEqual("information_schema.columns", "table_name", tableName);

            //string query = "select column_name, data_type from information_schema.columns where table_name = '" + tableName + "' order by ordinal_position";

            using (DbTableCommand cmm = mDbMgr.CreateDbCommand(clause))
            {
                DbDataReader dr = cmm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        columns.Add((string)dr["column_name"], (string)dr["data_type"]);
                    }
                }
                dr.Close();
            }

            return columns;
        }*/

    }
}
