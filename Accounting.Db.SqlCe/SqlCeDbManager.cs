using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using Accounting.Core;
using Accounting.Util;
using System.IO;
using System.Data.Common;
using Accounting.Db.Im;
using Accounting.Db.Elements;
using Accounting.Db.SqlCe.Elements;

namespace Accounting.Db.SqlCe
{
    public class SqlCeDbManager : ImDbManager
    {
        public SqlCeDbManager(RepositoryManager mgr, string name)
            : base(mgr, name)
        {
        }

        protected override DbConnection CreateDbConnection()
        {
            string connectionString = string.Format("Data Source = {0};", Database);
            if (!DbPassword.Equals(""))
            {
                connectionString = string.Format("Data Source = {0}; Password = {1};", Database, DbPassword);
            }

            if (!File.Exists(Database))
            {
                SqlCeEngine engine = new SqlCeEngine(connectionString);
                engine.CreateDatabase();
            }
           

            SqlCeConnection conn = new SqlCeConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (SqlCeException ex)
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
            return new SqlCeDbDeleteStatement(this);
        }

        public override DbDataAdapter CreateDbDataAdapter(string _query)
        {
            return new SqlCeDataAdapter(_query, (SqlCeConnection)DbConnection);
        }

        public override DbDataAdapter CreateDbDataAdapter(DbSelectStatement _query)
        {
            return new SqlCeDataAdapter(_query.ToString(), (SqlCeConnection)DbConnection);
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
            return new SqlCeCommand(_query.ToString(), (SqlCeConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbSelectLastInsertIdStatement _query)
        {
            return new SqlCeCommand(_query.ToString(), (SqlCeConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbUpdateStatement _query)
        {
            return new SqlCeCommand(_query.ToString(), (SqlCeConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbInsertStatement _query)
        {
            return new SqlCeCommand(_query.ToString(), (SqlCeConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbDeleteStatement _query)
        {
            return new SqlCeCommand(_query.ToString(), (SqlCeConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbGenerateTableStatement _query)
        {
            return new SqlCeCommand(_query.ToString(), (SqlCeConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbDropTableStatement _query)
        {
            return new SqlCeCommand(_query.ToString(), (SqlCeConnection)DbConnection);
        }

        public override DbInsertStatement CreateInsertClause()
        {
            SqlCeDbInsertStatement clause = new SqlCeDbInsertStatement(this);
            return clause;
        }

        public override DbGenerateTableStatement CreateGenerateTableClause()
        {
            SqlCeDbGenerateTableStatement statement = new SqlCeDbGenerateTableStatement();
            statement.DbMgr = this;
            return statement;
        }

        public override string TranslateFieldType(DbManager.FIELDTYPE index)
        {
            if (index == DbManager.FIELDTYPE.INTEGER)
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
            SqlCeDbDateTimeFieldEntry fieldvalue= new SqlCeDbDateTimeFieldEntry(value);
            fieldvalue.DbMgr = this;
            return fieldvalue;
        }

        

    }
}
