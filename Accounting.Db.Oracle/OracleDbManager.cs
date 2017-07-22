using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core;
using Accounting.Util;
using System.IO;
using System.Data.Common;
using Accounting.Db.Im;
using Accounting.Db.Elements;
using Accounting.Db.Oracle.Elements;
using Oracle.DataAccess.Client; // ODP.NET Oracle managed provider
using Oracle.DataAccess.Types;

namespace Accounting.Db.Oracle
{
    public class OracleDbManager : ImDbManager
    {
        public OracleDbManager(RepositoryManager mgr, string name)
            : base(mgr, name)
        {
            RegisterFieldNameAlias("IComment", "Comment");
        }

        //first the user must create the oracle user account with DBA (DataBase Administrator)

        //to find the database name run SQL+ command window from Oracle
        //1. in the SQL+ command enter "connect system"
        //2. enter the password for system account
        //3. enter "select name from v$database" and press ENTER
        //4. on the second line enter "/" and press ENTER, the database name will be listed
        //3.a optionally enter "select * from global_name" and press ENTER
        //3.b another option is to enter "SELECT ora_database_name FROM dual" and press ENTER

        //traditionally oracle use the port 1521 for listening
        protected override DbConnection CreateDbConnection()
        {
            /*
            OracleConnectionStringBuilder connStrBuilder = new OracleConnectionStringBuilder();

            connStrBuilder.DataSource = Database;
            
            if (!DbUsername.Equals(""))
            {
                connStrBuilder.UserID = DbUsername;
                connStrBuilder.Password = DbPassword;
            }*/
            
            string connectionString = string.Format("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={2}))); User ID={3};Password={4};", HostExePath, Port, Database, DbUsername, DbPassword);
            //string connectionString = string.Format("Data Source={0}; User Id={1}; Password={2};", HostExePath, DbUsername, DbPassword);
            OracleConnection connection = new OracleConnection(connectionString);
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

            //select table_name from user_tables where table_name='MYTABLE';
            //select * from dba_tables where TABLE_NAME='xxx';

            /*
            clause
                .SelectCount()
                .From("dba_tables")
                .Criteria
                    .IsEqual("dba_tables", "TABLE_NAME", selected_tablename.ToUpper());*/

            clause
              .SelectCount()
              .From("user_tables")
              .Criteria
                  .IsEqual("user_tables", "TABLE_NAME", _selected_tablename);

            return ExecuteScalarInt(clause) != 0;
        }

        public override DbDateTimeFieldEntry CreateDateTimeFieldEntry(DateTime? value)
        {
            return new OracleDbDateTimeFieldEntry(value);
        }

        public override DbDataAdapter CreateDbDataAdapter(DbSelectStatement clause)
        {
            return new OracleDataAdapter(clause.ToString(), (OracleConnection)DbConnection);
        }

        public override DbDataAdapter CreateDbDataAdapter(string clause)
        {
            return new OracleDataAdapter(clause, (OracleConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbSelectStatement clause)
        {
            OracleCommand command = ((OracleConnection)DbConnection).CreateCommand();
            command.CommandText = clause.ToString();
            return command;
        }

        public override DbCommand CreateDbCommand(DbInsertStatement clause)
        {
            OracleCommand command = ((OracleConnection)DbConnection).CreateCommand();
            command.CommandText = clause.ToString();
            return command;
        }

        public override DbCommand CreateDbCommand(DbUpdateStatement clause)
        {
            OracleCommand command = ((OracleConnection)DbConnection).CreateCommand();
            command.CommandText = clause.ToString();
            return command;
        }

        public override DbCommand CreateDbCommand(DbDeleteStatement clause)
        {
            OracleCommand command = ((OracleConnection)DbConnection).CreateCommand();
            command.CommandText = clause.ToString();
            return command;
        }

        public override DbCommand CreateDbCommand(DbGenerateTableStatement clause)
        {
            OracleCommand command = ((OracleConnection)DbConnection).CreateCommand();
            command.CommandText = clause.ToString();
            return command;
        }

        public override DbCommand CreateDbCommand(DbDropTableStatement clause)
        {
            OracleCommand command = ((OracleConnection)DbConnection).CreateCommand();
            command.CommandText = clause.ToString();
            return command;
        }

        public override DbCommand CreateDbCommand(DbSelectLastInsertIdStatement clause)
        {
            OracleCommand command = ((OracleConnection)DbConnection).CreateCommand();
            command.CommandText = clause.ToString();
            return command;
        }

        public override string TranslateFieldType(DbManager.FIELDTYPE index)
        {
            if (index == DbManager.FIELDTYPE.DOUBLE)
            {
                //return "NUMBER";
                return "FLOAT(49)";
                //return "NUMBER(7,2)";
            }
            if (index == DbManager.FIELDTYPE.DATETIME)
            {
                return "DATE";
            }
            if (index == DbManager.FIELDTYPE.VARCHAR_256)
            {
                return "VARCHAR(256)";
            }
         
            return base.TranslateFieldType(index);
        }

        public override DbGenerateTableStatement CreateGenerateTableClause()
        {
            OracleDbGenerateTableStatement statement = new OracleDbGenerateTableStatement();
            statement.DbMgr = this;
            return statement;
        }

        public override DbInsertStatement CreateInsertClause()
        {
            OracleDbInsertStatement clause = new OracleDbInsertStatement(this);
            return clause;
        }


        private bool IsSequenceFound(string sequence_name)
        {
            string query = string.Format("SELECT COUNT(*) FROM user_sequences WHERE sequence_name='{0}'", sequence_name);
            OracleCommand _cmd = ((OracleConnection)DbConnection).CreateCommand();
            _cmd.CommandText = query;
            
            return Convert.ToInt32(_cmd.ExecuteScalar()) != 0;
        }

        private void CreateSequence(string sequence_name)
        {
            string query = string.Format("CREATE  SEQUENCE {0} START WITH 1 INCREMENT BY 1", sequence_name);
            //Log(query);
            OracleCommand _cmd = ((OracleConnection)DbConnection).CreateCommand();
            _cmd.CommandText = query;
            _cmd.ExecuteNonQuery();
            _cmd.Dispose();
        }

        /*
         BEGIN

          --Bye Sequences!
          FOR i IN (SELECT us.sequence_name
                      FROM USER_SEQUENCES us) LOOP
            EXECUTE IMMEDIATE 'drop sequence '|| i.sequence_name ||'';
          END LOOP;

          --Bye Tables!
          FOR i IN (SELECT ut.table_name
                      FROM USER_TABLES ut) LOOP
            EXECUTE IMMEDIATE 'drop table '|| i.table_name ||' CASCADE CONSTRAINTS ';
          END LOOP;

        END;
         */
        private void DropSequence(string sequence_name)
        {
            string query = string.Format("DROP SEQUENCE {0}", sequence_name);

            //Log(query);

            OracleCommand _cmd = ((OracleConnection)DbConnection).CreateCommand();
            _cmd.CommandText = query;
            _cmd.ExecuteNonQuery();
            _cmd.Dispose();
        }

        private int mLastInsertID;
        public override int GetLastInsertID()
        {
            return mLastInsertID;
        }

        public override int ExecuteNonQuery(DbInsertStatement clause)
        {
            OracleDbInsertStatement _clause = (OracleDbInsertStatement)clause;
            string sequence_name = string.Format("{0}Seq", _clause.Tablename);
            sequence_name = FieldAlias(sequence_name);
            _clause.SequenceNumber = string.Format("{0}.nextval", sequence_name);

            //in case the record is imported from another database which comes 
            //with its autoincrement value already attached, forced the
            //Oracle sequence follows sync with the imported data
            DbAutoIntFieldEntry autoinc_field=_clause.AutoIncrementField;
            if(autoinc_field != null)
            {
                if(autoinc_field.IsValidValue)
                {
                    string query = string.Format("select {0}.nextval from dual", sequence_name);
                    OracleCommand _cmd2 = ((OracleConnection)DbConnection).CreateCommand();
                    _cmd2.CommandText = query;
                    int autoinc_val = Convert.ToInt32(_cmd2.ExecuteScalar());
                    _cmd2.Dispose();

                    int current_autoinc_val=Int32.Parse(autoinc_field.Value);
                    while(autoinc_val < current_autoinc_val)
                    {
                        query = string.Format("select {0}.nextval from dual", sequence_name);
                        _cmd2 = ((OracleConnection)DbConnection).CreateCommand();
                        _cmd2.CommandText = query;
                        autoinc_val = Convert.ToInt32(_cmd2.ExecuteScalar());
                        _cmd2.Dispose();
                    }
                }
            }
            
            if (_clause.Tablename.Equals("Sales"))
            {
                Log(_clause.ToString());
            }

            int result = 0;
            DbCommand _cmd = CreateDbCommand(_clause);
            result = _cmd.ExecuteNonQuery();
            _cmd.Dispose();

            //this is the last inserted ID
            if (autoinc_field != null && (!autoinc_field.IsValidValue))
            {
                string query = string.Format("select {0}.currval from dual", sequence_name);
                OracleCommand _cmd2 = ((OracleConnection)DbConnection).CreateCommand();
                _cmd2.CommandText = query;
                mLastInsertID=Convert.ToInt32(_cmd2.ExecuteScalar());
                _cmd2.Dispose();
            }

            return result;
        }
            
        public override int ExecuteNonQuery(DbGenerateTableStatement clause)
        {
            string sequence_name = string.Format("{0}Seq", clause.Tablename);
            sequence_name = FieldAlias(sequence_name);
            bool sequence_found=IsSequenceFound(sequence_name);

            if (sequence_found == false)
            {
                CreateSequence(sequence_name);
            }

            //Log(clause.ToString());


            int result = 0;
            DbCommand _cmd = CreateDbCommand(clause);
            result = _cmd.ExecuteNonQuery();
            _cmd.Dispose();

            return result;
        }

        public override int ExecuteNonQuery(DbDropTableStatement clause)
        {
            string sequence_name = string.Format("{0}Seq", clause.Tablename);
            sequence_name = FieldAlias(sequence_name);
            bool sequence_found = IsSequenceFound(sequence_name);

            if (sequence_found)
            {
                DropSequence(sequence_name);
            }


            int result = 0;
            DbCommand _cmd = CreateDbCommand(clause);
            result = _cmd.ExecuteNonQuery();
            _cmd.Dispose();

            return result;
        }

        public override string FieldAlias(string alias)
        {
            string actual_name = base.FieldAlias(alias);
            if (actual_name.Length > 30)
            {
                string[] texts = Split(actual_name);
                actual_name="";
                foreach (string text in texts)
                {
                    if (text.Length > 3)
                    {
                        actual_name += text.Substring(0, 3);
                    }
                    else
                    {
                        actual_name += text;
                    }
                }
                //actual_name = actual_name.Substring(0, 30);
            }
            return actual_name.ToUpper();
        }

        private string[] Split(string input)
        {
            return System.Text.RegularExpressions.Regex.Replace(
                input,
                "([A-Z])",
                " $1",
                System.Text.RegularExpressions.RegexOptions.Compiled).Trim().Split(' ');
        }
    }
}
