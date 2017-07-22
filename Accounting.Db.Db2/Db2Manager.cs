using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core;
using Accounting.Util;
using System.IO;
using System.Data.Common;
using Accounting.Db.Im;
using Accounting.Db.Elements;
using Accounting.Db.Db2.Elements;
using IBM.Data.DB2; 

namespace Accounting.Db.Db2
{
    public class Db2Manager : ImDbManager
    {
        public Db2Manager(RepositoryManager mgr, string name)
            : base(mgr, name)
        {
        }

        protected override DbConnection CreateDbConnection()
        {
            DB2ConnectionStringBuilder connStrBuilder = new DB2ConnectionStringBuilder();
            connStrBuilder.Server = HostExePath;
            connStrBuilder.Database = Database;
            connStrBuilder.UserID = DbUsername;
            connStrBuilder.Password = DbPassword;

            string connectionString = connStrBuilder.ConnectionString;

            /*
            string connectionString = string.Format("Server={0};Database={1};UID={2};PASSWORD={3};", HostExePath, Database, DbUsername, DbPassword);
            if (Port != null && !Port.Equals(""))
            {
                connectionString = string.Format("Server={0};Database={1};Port={2};UID={3};PASSWORD={4};", HostExePath, Database, Port, DbUsername, DbPassword);
            }*/


            DB2Connection connection = new DB2Connection(connectionString);
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
            string _selected_tablename = FieldAlias(selected_tablename);
            DbSelectStatement clause=CreateSelectClause();
            clause
                .SelectCount()
                .From("SYSCAT.TABLES")
                .Criteria
                    .IsEqual("SYSCAT.TABLES", "TABSCHEMA", DbUsername.ToUpper())
                    .IsEqual("SYSCAT.TABLES", "TABNAME", _selected_tablename.ToUpper());
            return ExecuteScalarInt(clause) != 0;
        }

        public override DbDateTimeFieldEntry CreateDateTimeFieldEntry(DateTime? value)
        {
            return new Db2DateTimeFieldEntry(value);
        }

        public override DbDataAdapter CreateDbDataAdapter(string _query)
        {
            return new DB2DataAdapter(_query, (DB2Connection)DbConnection);
        }

        public override DbDataAdapter CreateDbDataAdapter(DbSelectStatement _query)
        {
            return new DB2DataAdapter(_query.ToString(), (DB2Connection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbSelectStatement _query)
        {
            DB2Command command = ((DB2Connection)DbConnection).CreateCommand();
            command.CommandText = _query.ToString();
            return command;
        }

        public override DbCommand CreateDbCommand(DbSelectLastInsertIdStatement _query)
        {
            DB2Command command = ((DB2Connection)DbConnection).CreateCommand();
            command.CommandText = _query.ToString();
            return command;
        }

        public override DbCommand CreateDbCommand(DbInsertStatement _query)
        {
            DB2Command command = ((DB2Connection)DbConnection).CreateCommand();
            command.CommandText = _query.ToString();
            return command;
        }

        public override DbCommand CreateDbCommand(DbUpdateStatement _query)
        {
            DB2Command command = ((DB2Connection)DbConnection).CreateCommand();
            command.CommandText = _query.ToString();
            return command;
        }

        public override DbCommand CreateDbCommand(DbDeleteStatement _query)
        {
            DB2Command command = ((DB2Connection)DbConnection).CreateCommand();
            command.CommandText = _query.ToString();
            return command;
        }

        public override DbCommand CreateDbCommand(DbGenerateTableStatement _query)
        {
            DB2Command command = ((DB2Connection)DbConnection).CreateCommand();
            command.CommandText = _query.ToString();
            return command;
        }

        public override DbCommand CreateDbCommand(DbDropTableStatement _query)
        {
            DB2Command command = ((DB2Connection)DbConnection).CreateCommand();
            command.CommandText = _query.ToString();
            return command;
        }

        public override string TranslateFieldType(DbManager.FIELDTYPE index)
        {
            if (index == DbManager.FIELDTYPE.DATETIME)
            {
                return "DATE";
            }
            else if (index == DbManager.FIELDTYPE.VARCHAR_256)
            {
                return "VARCHAR(256)";
            }
         
            return base.TranslateFieldType(index);
        }

        public override DbGenerateTableStatement CreateGenerateTableClause()
        {
            Db2GenerateTableStatement statement = new Db2GenerateTableStatement();
            statement.DbMgr = this;
            return statement;
        }
    }
}
