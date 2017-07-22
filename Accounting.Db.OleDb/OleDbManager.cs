using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Util;
using System.IO;
using System.Data.Common;
using Accounting.Db.Im;
using Accounting.Db.Elements;
using Accounting.Db.OleDb.Elements;

namespace Accounting.Db.OleDb
{
    public class OleDbManager : ImDbManager
    {
        public OleDbManager(RepositoryManager mgr, string name)
            : base(mgr, name)
        {
        }

        protected override DbConnection CreateDbConnection()
        {
            string connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password={1}", Database, DbPassword);
            OleDbConnection conn = new OleDbConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (OleDbException ex)
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

        public override DbDataAdapter CreateDbDataAdapter(DbSelectStatement _query)
        {
            return new OleDbDataAdapter(_query.ToString(), (OleDbConnection)DbConnection);
        }

        public override DbDataAdapter CreateDbDataAdapter(string _query)
        {
            return new OleDbDataAdapter(_query, (OleDbConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbSelectStatement _query)
        {
            return new OleDbCommand(_query.ToString(), (OleDbConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbSelectLastInsertIdStatement _query)
        {
            return new OleDbCommand(_query.ToString(), (OleDbConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbUpdateStatement _query)
        {
            return new OleDbCommand(_query.ToString(), (OleDbConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbInsertStatement _query)
        {
            return new OleDbCommand(_query.ToString(), (OleDbConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbDeleteStatement _query)
        {
            return new OleDbCommand(_query.ToString(), (OleDbConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbGenerateTableStatement _query)
        {
            return new OleDbCommand(_query.ToString(), (OleDbConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbDropTableStatement _query)
        {
            return new OleDbCommand(_query.ToString(), (OleDbConnection)DbConnection);
        }


        public override DbSelectTableCountStatement CreateSelectTableCountClause()
        {
            OleDbSelectTableCountStatement statement = new OleDbSelectTableCountStatement(this);
            statement.DbMgr = this;
            return statement;
        }
    }
}
