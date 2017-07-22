using System;
using System.Collections.Generic;
using System.Text;


namespace Accounting.Db.Myob
{
    using Accounting.Core;
    using Accounting.Core.Accounts;
    using Accounting.Core.Currencies;
    using Accounting.Db;
    using Accounting.Db.Elements;
    using System.Data.Odbc;

    public class DbAccountManager : AccountManager
    {
        public DbAccountManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override OpResult _Store(Account _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Account object cannot be created as it is null");
            }

            bool is_creating = !Exists(_obj);

            DbInsertStatement clause = DbMgr.CreateInsertClause();
            clause.InsertColumn("AccountNumber", DbMgr.CreateStringFieldEntry(_obj.AccountNumber));
            clause.InsertColumn("AccountName", DbMgr.CreateStringFieldEntry(_obj.AccountName));

            if (_obj.IsHeader)
            {
                clause.InsertColumn("Header", DbMgr.CreateStringFieldEntry("1"));
            }
            else
            {
                clause.InsertColumn("Header", DbMgr.CreateStringFieldEntry("0"));
            }

            if (is_creating)
            {
                if (_obj.IsHeader)
                {
                    clause.InsertColumn("AccountType", DbMgr.CreateStringFieldEntry(_obj.AccountClassification.Description));
                }
                else
                {
                    clause.InsertColumn("AccountType", DbMgr.CreateStringFieldEntry(_obj.SubAccountClassification.Description));
                }
            }

            if (_obj.TaxCode != null)
            {
                clause.InsertColumn("TaxCode", DbMgr.CreateStringFieldEntry(_obj.TaxCode.Code));
            }

            bool support_multi_currency = _obj.RepositoryMgr.CurrencyMgr.SupportMultiCurrency;
            if (support_multi_currency)
            {
                if (_obj.Currency != null)
                {
                    clause.InsertColumn("CurrencyCode", DbMgr.CreateStringFieldEntry(_obj.Currency.CurrencyCode));
                }
                if (_obj.CurrencyExchangeAccount != null)
                {
                    clause.InsertColumn("ExchangeAccount", DbMgr.CreateStringFieldEntry(_obj.CurrencyExchangeAccount.AccountNumber));
                }
            }

            clause.InsertColumn("InactiveAccount", DbMgr.CreateStringFieldEntry(_obj.IsInactive));

            clause.InsertColumn("Description", DbMgr.CreateStringFieldEntry(_obj.AccountDescription));


            if (_obj.IsBank)
            {
                clause.InsertColumn("BSBNumber", DbMgr.CreateStringFieldEntry(_obj.BSBCode));
                clause.InsertColumn("BankAccountNumber", DbMgr.CreateStringFieldEntry(_obj.BankAccountNumber));
                clause.InsertColumn("BankAccountName", DbMgr.CreateStringFieldEntry(_obj.BankAccountName));
                clause.InsertColumn("TradingName", DbMgr.CreateStringFieldEntry(_obj.CompanyTradingName));
                clause.InsertColumn("CreateBankFile", DbMgr.CreateStringFieldEntry(_obj.CreateBankFiles));
                if (_obj.CreateBankFiles == "Y")
                {
                    clause.InsertColumn("BankCode", DbMgr.CreateStringFieldEntry(_obj.BankCode));
                    clause.InsertColumn("DirectEntryUserID", DbMgr.CreateStringFieldEntry(_obj.DirectEntryUserID));
                    clause.InsertColumn("SelfBalancing", DbMgr.CreateStringFieldEntry(_obj.IsSelfBalancing));
                }
            }

            if (!_obj.IsHeader)
            {
                clause.InsertColumn("ReportSubtotal", DbMgr.CreateStringFieldEntry(_obj.IsTotal));
            }
            else
            {
                clause.InsertColumn("CashFlowClassification", DbMgr.CreateStringFieldEntry(_obj.CashFlowClassificationID));
            }

            clause.Into("Import_Accounts");

            Console.Write(clause.ToString());


            OdbcConnection m_OdbcConnection = DbMgr.DbConnection as OdbcConnection;
            OdbcCommand cmdSQLInsert = m_OdbcConnection.CreateCommand();
            OdbcTransaction myTrans = m_OdbcConnection.BeginTransaction();
            try
            {
                cmdSQLInsert.CommandText = clause.ToString();
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

            if (is_creating)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
            }
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);

        }
    }
}
