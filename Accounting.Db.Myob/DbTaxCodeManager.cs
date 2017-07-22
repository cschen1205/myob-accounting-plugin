using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.Odbc;
using Accounting.Core.TaxCodes;
using Accounting.Util;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbTaxCodeManager : TaxCodeManager
    {
        public DbTaxCodeManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        /*
        protected override OpResult _Store(TaxCode _obj)
        {
            if (_obj == null)
            {
                return false;
            }

            StringBuilder sb = new StringBuilder();
            if (IsTaxCodeTypeConsolidated(_obj.TaxCodeTypeID))
            {
                sb.Append("INSERT INTO Import_Consolidated_TaxCodes (");
                sb.Append("TaxCode");
                sb.Append(", Description");
                sb.Append(", SubTaxCode");
                sb.Append(") VALUES (");
                sb.AppendFormat("'{0}'", _obj.Code);
                sb.AppendFormat(", '{0}'", _obj.TaxCodeDescription);
                sb.AppendFormat(", '{0}'", _obj.SubTaxCode);
                sb.Append(");");
            }
            else
            {
                sb.Append("INSERT INTO Import_NonConsolidated_TaxCodes (");
                sb.Append("TaxCode");
                sb.Append(", Description");
                sb.Append(", Rate");
                sb.Append(", TaxType");
                sb.Append(") VALUES (");
                sb.AppendFormat("'{0}'", _obj.Code);
                sb.AppendFormat(", '{0}'", _obj.TaxCodeDescription);
                sb.AppendFormat(", {0}", _obj.TaxPercentageRate);
                sb.AppendFormat(", {0}", GetTaxTypeFromTaxCodeTypeID(_obj.TaxCodeTypeID));
                sb.Append(");");
            }

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
        }*/

    }
}
