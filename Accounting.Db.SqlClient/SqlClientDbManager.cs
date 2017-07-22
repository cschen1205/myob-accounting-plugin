using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Accounting.Core;
using Accounting.Util;
using System.IO;
using System.Data.Common;
using Accounting.Db.Im;
using Accounting.Db.Elements;
using Accounting.Db.SqlClient.Elements;

namespace Accounting.Db.SqlClient
{
    public class SqlClientDbManager : ImDbManager
    {
        public SqlClientDbManager(RepositoryManager mgr, string name)
            : base(mgr, name)
        {
        }

        protected override DbConnection CreateDbConnection()
        {
            SqlConnectionStringBuilder cnStrBuilder = new SqlConnectionStringBuilder();
            
            cnStrBuilder.InitialCatalog = Database;
            cnStrBuilder.DataSource = HostExePath;

            if (DbUsername.Equals(""))
            {
                cnStrBuilder.IntegratedSecurity = true;
            }
            else
            {
                cnStrBuilder.UserID = DbUsername;
                cnStrBuilder.Password = DbPassword;
            }
            //cnStrBuilder.Pooling = false;

            string connectionString = cnStrBuilder.ConnectionString;

            //Log(connectionString);

            /*
            string connectionString = string.Format("Data Source = {0}; Initial Catalog = {1}; Integrated Security = True;", HostExePath, Database);
            if (!DbUsername.Equals("") && !DbPassword.Equals(""))
            {
                connectionString = string.Format("Data Source = {0}; Initial Catalog = {1}; User Id = {2}; Password = {3};", HostExePath, Database, DbUsername, DbPassword);
            }
            else if (!DbUsername.Equals(""))
            {
                connectionString = string.Format("Data Source = {0}; Initial Catalog = {1}; User Id = {2};", HostExePath, Database, DbUsername);
            }*/

            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                Log(ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                return null;
            }

            return conn;
        }

        public override DbDeleteStatement CreateDeleteClause()
        {
            return new SqlClientDbDeleteStatement(this);
        }

        public override DbDataAdapter CreateDbDataAdapter(string _query)
        {
            return new SqlDataAdapter(_query, (SqlConnection)DbConnection);
        }

        public override DbDataAdapter CreateDbDataAdapter(DbSelectStatement _query)
        {
            return new SqlDataAdapter(_query.ToString(), (SqlConnection)DbConnection);
        }

        public override bool TableExists(string selected_tablename)
        {
            DbSelectStatement clause = CreateSelectClause();
            clause
                .SelectCount()
                .From("information_schema.tables")
                .Criteria
                    //.IsEqual("information_schema.tables", "table_schema", Database)
                    .IsEqual("information_schema.tables", "table_name", FieldAlias(selected_tablename));
            return ExecuteScalarInt(clause) != 0;
        }

        public override DbCommand CreateDbCommand(DbSelectStatement _query)
        {
            return new SqlCommand(_query.ToString(), (SqlConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbSelectLastInsertIdStatement _query)
        {
            return new SqlCommand(_query.ToString(), (SqlConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbUpdateStatement _query)
        {
            return new SqlCommand(_query.ToString(), (SqlConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbInsertStatement _query)
        {
            return new SqlCommand(_query.ToString(), (SqlConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbDeleteStatement _query)
        {
            return new SqlCommand(_query.ToString(), (SqlConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbGenerateTableStatement _query)
        {
            return new SqlCommand(_query.ToString(), (SqlConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbDropTableStatement _query)
        {
            return new SqlCommand(_query.ToString(), (SqlConnection)DbConnection);
        }

        public override DbInsertStatement CreateInsertClause()
        {
            SqlClientDbInsertStatement clause = new SqlClientDbInsertStatement(this);
            return clause;
        }

        public override DbGenerateTableStatement CreateGenerateTableClause()
        {
            SqlClientDbGenerateTableStatement statement = new SqlClientDbGenerateTableStatement();
            statement.DbMgr = this;
            return statement;
        }



        public override string TranslateFieldType(DbManager.FIELDTYPE index)
        {
            if (index == DbManager.FIELDTYPE.INTEGER)
            {
                return "int";
            }
            else if (index == DbManager.FIELDTYPE.INTEGER_INDEXED)
            {
                return "int";
            }
            else if (index == DbManager.FIELDTYPE.DOUBLE)
            {
                return "float";
            }
            return base.TranslateFieldType(index);
        }

        public override DbDateTimeFieldEntry CreateDateTimeFieldEntry(DateTime? value)
        {
            SqlClientDbDateTimeFieldEntry fieldvalue= new SqlClientDbDateTimeFieldEntry(value);
            fieldvalue.DbMgr = this;
            return fieldvalue;
        }
    }
}
