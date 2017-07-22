using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Accounts;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbAccountManager : AccountManager
    {
        public DbAccountManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //Accounts()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["ParentAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["IsInactive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["AccountName"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["AccountNumber"] = DbManager.FIELDTYPE.VARCHAR_256;
            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CurrencyExchangeAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["AccountClassificationID"] = DbManager.FIELDTYPE.VARCHAR_4;
            fields["SubAccountClassificationID"] = DbManager.FIELDTYPE.VARCHAR_4;
            fields["AccountLevel"] = DbManager.FIELDTYPE.INTEGER;
            fields["AccountTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["LastChequeNumber"] = DbManager.FIELDTYPE.VARCHAR_8;
            fields["IsReconciled"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["LastReconciledDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["StatementBalance"] = DbManager.FIELDTYPE.DOUBLE;
            fields["IsCreditBalance"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["OpeningAccountBalance"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CurrentAccountBalance"] = DbManager.FIELDTYPE.DOUBLE;
            fields["PreLastYearActivity"] = DbManager.FIELDTYPE.DOUBLE;
            fields["LastYearOpeningBalance"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ThisYearOpeningBalance"] = DbManager.FIELDTYPE.DOUBLE;
            fields["PostThisYearActivity"] = DbManager.FIELDTYPE.DOUBLE;
            fields["AccountDescription"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["IsTotal"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CashFlowClassificationID"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["BankAccountNumber"] = DbManager.FIELDTYPE.VARCHAR_20;
            fields["BankAccountName"] = DbManager.FIELDTYPE.VARCHAR_32;

            /*
            foreignKeys["ParentAccountID"] = "Accounts(ParentAccountID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CurrencyExchangeAccountID"] = "Accounts(CurrencyExchangeAccountID)";
            foreignKeys["AccountClassificationID"] = "AccountClassification(AccountClassificationID)";
            foreignKeys["SubAccountClassificationID"] = "SubAccountTypes(SubAccountClassificationID)";
            foreignKeys["CashFlowClassificationID"] = "CashFlowClassifications(CashFlowClassificationID)";
            foreignKeys["AccountTypeID"] = "AccountType(AccountTypeID)";
             * */

            TableCommands["Accounts"] = DbMgr.CreateTableCommand("Accounts", fields, "AccountID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(Account _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("Accounts", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(Account _obj)
        {
            return DbMgr.CreateUpdateClause("Accounts", GetFields(_obj), "AccountID", _obj.AccountID);
        }

       

        protected override OpResult _Store(Account _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Account object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.AccountID == null)
            {
                _obj.AccountID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

    }
}
