using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using Accounting.Core;
using Accounting.Util;
using System.IO;
using System.Data.Common;
using Accounting.Db.Im;
using Accounting.Db.Elements;
using Accounting.Db.MySQL.Elements;

namespace Accounting.Db.MySQL
{
    public class MySQLDbManager : ImDbManager
    {
        public MySQLDbManager(RepositoryManager mgr, string name)
            : base(mgr, name)
        {
        }

        protected override DbConnection CreateDbConnection()
        {
            MySqlConnectionStringBuilder sqlConnBuilder = new MySqlConnectionStringBuilder();
            sqlConnBuilder.UserID = DbUsername;
            sqlConnBuilder.Password = DbPassword;

            if (!Port.Equals(""))
            {
                sqlConnBuilder.Port = uint.Parse(Port);
            }

            sqlConnBuilder.Server = HostExePath;
            sqlConnBuilder.Database = Database;
            //sqlConnBuilder.ConnectionTimeout = 5;

            /*
            string connectionString = string.Format("SERVER={0};DATABASE={1};UID={2};PASSWORD={3};", HostExePath, Database, DbUsername, DbPassword);
            if (Port != null && !Port.Equals(""))
            {
                connectionString = string.Format("SERVER={0};DATABASE={1};Port={2};UID={3};PASSWORD={4};", HostExePath, Database, Port, DbUsername, DbPassword);
            }*/
            MySqlConnection connection = new MySqlConnection(sqlConnBuilder.ConnectionString);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                return null;
            }

            return connection;
        }

        public override bool TableExists(string selected_tablename)
        {
            
            DbSelectStatement clause=CreateSelectClause();
            clause
                .SelectCount()
                .From("information_schema.tables")
                .Criteria
                    .IsEqual("information_schema.tables", "table_schema", Database)
                    .IsEqual("information_schema.tables", "table_name", FieldAlias(selected_tablename));
            bool exists = (ExecuteScalarInt(clause) != 0);

            if (!exists)
            {
                clause = CreateSelectClause();
                clause
                    .SelectCount()
                    .From("information_schema.tables")
                    .Criteria
                        .IsEqual("information_schema.tables", "table_schema", Database.ToLower())
                        .IsEqual("information_schema.tables", "table_name", FieldAlias(selected_tablename).ToLower());
                exists = (ExecuteScalarInt(clause) != 0);
            }
            
            /*
            if (selected_tablename.ToLower().Equals("authuser"))
            {
                LogWithExit(clause.ToString());
                string result = string.Format("count: {0}", ExecuteScalarInt(clause));
                LogWithExit(result);
                LogWithExit(exists ? "exists==true" : "exists==false");
                LogWithExit(string.Format("db: {0}", Database));
            }
            //*/

            return exists;
        }

        public override DbDateTimeFieldEntry CreateDateTimeFieldEntry(DateTime? value)
        {
            return new MySQLDbDateTimeFieldEntry(value);
        }

        public override DbDataAdapter CreateDbDataAdapter(string _query)
        {
            return new MySqlDataAdapter(_query, (MySqlConnection)DbConnection);
        }

        public override DbDataAdapter CreateDbDataAdapter(DbSelectStatement _query)
        {
            return new MySqlDataAdapter(_query.ToString(), (MySqlConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbSelectStatement _query)
        {
            MySqlCommand command = ((MySqlConnection)DbConnection).CreateCommand();
            command.CommandText = _query.ToString();
            return command;
        }

        public override DbCommand CreateDbCommand(DbSelectLastInsertIdStatement _query)
        {
            MySqlCommand command = ((MySqlConnection)DbConnection).CreateCommand();
            command.CommandText = _query.ToString();
            return command;
        }

        public override DbCommand CreateDbCommand(DbUpdateStatement _query)
        {
            MySqlCommand command = ((MySqlConnection)DbConnection).CreateCommand();
            command.CommandText = _query.ToString();
            return command;
        }

        public override DbCommand CreateDbCommand(DbInsertStatement _query)
        {
            MySqlCommand command = ((MySqlConnection)DbConnection).CreateCommand();
            command.CommandText = _query.ToString();
            return command;
        }

        public override DbCommand CreateDbCommand(DbDeleteStatement _query)
        {
            MySqlCommand command = ((MySqlConnection)DbConnection).CreateCommand();
            command.CommandText = _query.ToString();
            return command;
        }

        public override DbCommand CreateDbCommand(DbGenerateTableStatement _query)
        {
            MySqlCommand command = ((MySqlConnection)DbConnection).CreateCommand();
            command.CommandText = _query.ToString();
            return command;
        }

        public override DbCommand CreateDbCommand(DbDropTableStatement _query)
        {
            MySqlCommand command = ((MySqlConnection)DbConnection).CreateCommand();
            command.CommandText = _query.ToString();
            return command;
        }

        public override DbGenerateTableStatement CreateGenerateTableClause()
        {
            MySQLDbGenerateTableStatement statement = new MySQLDbGenerateTableStatement();
            statement.DbMgr = this;
            return statement;
        }

        public override DbDeleteStatement CreateDeleteClause()
        {
            MySQLDbDeleteStatement statement = new MySQLDbDeleteStatement(this);
            return statement;
        }
    }
}
