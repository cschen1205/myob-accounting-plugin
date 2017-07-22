using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Payroll;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbBankingDetailManager : BankingDetailManager
    {
        public DbBankingDetailManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //BankingDetails()
        {
            //create table: Cards
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["BankingDetailsID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["JournalRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["WritePaychequeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["NumberBankAccounts"] = DbManager.FIELDTYPE.INTEGER;
            fields["BSBCode1"] = DbManager.FIELDTYPE.VARCHAR_9;
            fields["BankAccountNumber1"] = DbManager.FIELDTYPE.VARCHAR_19;
            fields["BankAccountName1"] = DbManager.FIELDTYPE.VARCHAR_32;
            fields["Bank1Value"] = DbManager.FIELDTYPE.DOUBLE;
            fields["Bank1ValueTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Bank1CalculatedAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["BSBCode2"] = DbManager.FIELDTYPE.VARCHAR_9;
            fields["BankAccountNumber2"] = DbManager.FIELDTYPE.VARCHAR_19;
            fields["BankAccountName2"] = DbManager.FIELDTYPE.VARCHAR_32;
            fields["Bank2Value"] = DbManager.FIELDTYPE.DOUBLE;
            fields["Bank2ValueTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Bank2CalculatedAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["BSBCode3"] = DbManager.FIELDTYPE.VARCHAR_9;
            fields["BankAccountNumber3"] = DbManager.FIELDTYPE.VARCHAR_19;
            fields["BankAccountName3"] = DbManager.FIELDTYPE.VARCHAR_32;
            fields["Bank3Value"] = DbManager.FIELDTYPE.DOUBLE;
            fields["Bank3ValueTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Bank3CalculatedAmount"] = DbManager.FIELDTYPE.DOUBLE;

            /*
            foreignKeys["OverideAccountID"] = "Accounts(AccountID)";
             * */

            TableCommands["BankingDetails"] = DbMgr.CreateTableCommand("BankingDetails", fields, "BankingDetailsID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(BankingDetail _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("BankingDetails", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(BankingDetail _obj)
        {
            return DbMgr.CreateUpdateClause("BankingDetails", GetFields(_obj), "BankingDetailsID", _obj.BankingDetailID);
        }

        protected override OpResult _Store(BankingDetail _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "BankingDetail object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
