using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Currencies;
using Accounting.Util;
using Accounting.Db;
using System.Data.Common;
using System.Data.Odbc;

namespace Accounting.Db.Myob
{
    public class DbCurrencyManager : CurrencyManager
    {
        public DbCurrencyManager(DbManager mgr)
            : base(mgr)
        {
           
        }

        /*
        protected override OpResult _Store(Currency _obj)
        {
            if (_obj == null)
            {
                return false;
            }

            StringBuilder sb = new StringBuilder();
            

            string query = sb.ToString();

            DbCommand cmdSQLInsert = CreateDbCommand(query);
            DbTransaction myTrans = DbMgr.DbConnection.BeginTransaction();
            try
            {
                cmdSQLInsert.CommandText = query;
                cmdSQLInsert.Transaction = myTrans;
                cmdSQLInsert.ExecuteNonQuery();
                myTrans.Commit();
                return true;
            }
            catch (OdbcException ex)
            {
                AppEnv.Instance.Log(ex.Message);
                myTrans.Rollback();
                return false;
            }
            catch (Exception ex)
            {
                AppEnv.Instance.Log(ex.Message);
                return false;
            }
        }
         * */

    }
}
