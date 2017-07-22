using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Inventory;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    using Accounting.Core;
    using Accounting.Core.Inventory;
    using Accounting.Core.Accounts;
    using System.Data.Odbc;
    using System.Data.Common;
    using Accounting.Db;
    using Accounting.Db.Elements;

    public class DbInventoryAdjustmentManager : InventoryAdjustmentManager
    {
        public DbInventoryAdjustmentManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override OpResult _Store(InventoryAdjustment _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "InventoryAdjustment object cannot be deleted as it is null");
            }

            bool is_creating = !Exists(_obj);

            if (is_creating)
            {
                RepositoryMgr.MiscNumberMgr.SaveInvoiceNumber(_obj.InventoryJournalNumber);
            }

            string query = GetQuery_StoreItemInventoryAdjustmentLines(_obj);
            Console.WriteLine(query);

            if (string.IsNullOrEmpty(query))
            {
                if (is_creating)
                {
                    return OpResult.NotifyStoreAction(OpResult.ResultStatus.CreateFailedOnCriteria, _obj, "InventoryAdjustment object does not have any InventoryAdjustmentLines");
                }
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.UpdateFailedOnCriteria, _obj, "InventoryAdjustment object does not have any InventoryAdjustmentLines");
            }

            DbCommand cmdSQLInsert = new OdbcCommand(query, (OdbcConnection)DbMgr.DbConnection);
            DbTransaction myTrans = DbMgr.DbConnection.BeginTransaction();
            try
            {
                cmdSQLInsert.CommandText = query;
                cmdSQLInsert.Transaction = myTrans;
                cmdSQLInsert.ExecuteNonQuery();
                myTrans.Commit();
            }
            catch (OdbcException ex)
            {
                myTrans.Rollback();
                Log(ex.Message);
                Console.WriteLine(ex.ToString());
                if (is_creating)
                {
                    return OpResult.NotifyStoreAction(OpResult.ResultStatus.CreatedWithException, _obj, ex.ToString());
                }
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.UpdatedWithException, _obj, ex.ToString());
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                Console.WriteLine(ex.ToString());
                if (is_creating)
                {
                    return OpResult.NotifyStoreAction(OpResult.ResultStatus.CreatedWithException, _obj, ex.ToString());
                }
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.UpdatedWithException, _obj, ex.ToString());
            }

            _obj.FromDb = true;

            if (is_creating)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
            }
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
        }

        #region ItemInventoryAdjustmentLines
        private Dictionary<string, DbFieldEntry> GetQueryMap_StoreItemInventoryAdjustmentLines(InventoryAdjustment _sale, InventoryAdjustmentLine _line)
        {
            Dictionary<string, DbFieldEntry> query_map = new Dictionary<string, DbFieldEntry>();

            bool multi_currency_support = _sale.RepositoryMgr.CurrencyMgr.SupportMultiCurrency;

            query_map.Add("JournalNumber", DbMgr.CreateStringFieldEntry(_sale.InventoryJournalNumber));
            query_map.Add("AdjustmentDate", _sale.Date != null ? (DbFieldEntry)DbMgr.CreateDateTimeFieldEntry(_sale.Date) : (DbFieldEntry)DbMgr.CreateStringFieldEntry(""));
            query_map.Add("Memo", DbMgr.CreateStringFieldEntry(_sale.Memo));
            query_map.Add("ItemNumber", DbMgr.CreateStringFieldEntry(_line.ItemNumber));

            query_map.Add("Location", DbMgr.CreateStringFieldEntry(_line.Location != null ? _line.Location.ToString() : ""));
            query_map.Add("Quantity", DbMgr.CreateDoubleFieldEntry(_line.Quantity));
            query_map.Add("UnitCost", DbMgr.CreateDoubleFieldEntry(_line.UnitCost));
            query_map.Add("Amount", DbMgr.CreateDoubleFieldEntry(_line.Amount));

            if(_line.Account != null)
            {
                int account_number=0;
                if(AccountNumber2Int(_line.AccountNumber, out account_number))
                {
                    query_map.Add("Account", DbMgr.CreateIntFieldEntry(account_number));
                }
            }
            if(_line.Job != null)
            {
                query_map.Add("JobNumber", DbMgr.CreateStringFieldEntry(_line.JobNumber));
            }

           query_map.Add("AllocationMemo", DbMgr.CreateStringFieldEntry(_line.Memo));
            //query_map.Add("Category", DbMgr.CreateStringFieldEntry(""));
            
            return query_map;
        }

        private string GetQuery_StoreItemInventoryAdjustmentLines(InventoryAdjustment _sale)
        {
            List<Dictionary<string, DbFieldEntry>> query_matrix = new List<Dictionary<string, DbFieldEntry>>();
           

            foreach (InventoryAdjustmentLine _line in _sale.Lines)
            {
                    Dictionary<string, DbFieldEntry> query_map = GetQueryMap_StoreItemInventoryAdjustmentLines(_sale, _line);
                    query_matrix.Add(query_map);
            }

            string query = "";
            if (query_matrix.Count != 0)
            {
                 Dictionary<string, DbFieldEntry> query_header = query_matrix[0];
                query = GetQuery(query_header, query_matrix, "Import_Inventory_Adjustments");
            }
            return query;
        }
        #endregion

        #region Convert the string-version of AccountNumber to integer-version of AccountNumber
        public bool AccountNumber2Int(string account_number_text, out int account_number_numeric)
        {
            account_number_numeric=0;
            if(string.IsNullOrEmpty(account_number_text))
            {
                return false;
            }

            account_number_text = account_number_text.Replace("-", "");
            return int.TryParse(account_number_text, out account_number_numeric);
        }

        public DbFieldEntry GetAccountNumber(Account acc)
        {
             if(acc != null)
             {
                 int account_number=0;
                 if(AccountNumber2Int(acc.AccountNumber, out account_number))
                 {
                     return DbMgr.CreateIntFieldEntry(account_number);
                 }
                 else
                 {
                     return DbMgr.CreateStringFieldEntry("");
                 }
             }
             return DbMgr.CreateStringFieldEntry("");
        }
        #endregion

        private string GetQuery(Dictionary<string, DbFieldEntry> query_header, List<Dictionary<string, DbFieldEntry>> query_matrix, string table_name)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("INSERT INTO {0} (", DbMgr.FieldAlias(table_name));

            bool first_column = true;
            foreach (string columnname in query_header.Keys)
            {
                if (first_column)
                {
                    sb.AppendFormat("{0}", DbMgr.FieldAlias(columnname));
                    first_column = false;
                }
                else
                {
                    sb.AppendFormat(", {0}", DbMgr.FieldAlias(columnname));
                }
            }

            sb.Append(") VALUES (");

            first_column = true;
            //foreach (string columnname in query_header.Keys)
            //{
            //    if (first_column)
            //    {
            //        sb.AppendFormat("({0}", query_header[columnname]);
            //        first_column = false;
            //    }
            //    else
            //    {
            //        sb.AppendFormat(", {0}", query_header[columnname]);
            //    }
            //}
            //sb.Append(")");

            bool first_row = true;
            foreach (Dictionary<string, DbFieldEntry> query_map in query_matrix)
            {
                first_column = true;
                foreach (string columnname in query_map.Keys)
                {
                    if (first_column)
                    {
                        if (first_row)
                        {
                            sb.AppendFormat("({0}", query_map[columnname]);
                            first_row = false;
                        }
                        else
                        {
                            sb.AppendFormat(", ({0}", query_map[columnname]);
                        }
                        first_column = false;
                    }
                    else
                    {
                        sb.AppendFormat(", {0}", query_map[columnname]);
                    }
                }
                sb.Append(")");
            }

            sb.Append(")");

            return sb.ToString();
        }        
    }
}
