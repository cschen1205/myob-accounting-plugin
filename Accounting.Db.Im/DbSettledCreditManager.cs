using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Sales;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbSettledCreditManager : SettledCreditManager
    {
        public DbSettledCreditManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //SettledCredits()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["SettledCreditID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["SettledCreditNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["TransactionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CreditNoteID"] = DbManager.FIELDTYPE.INTEGER;
            fields["AmountSettled"] = DbManager.FIELDTYPE.DOUBLE;
            fields["IsDiscount"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["FinanceCharge"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ExchangeGainLoss"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CardRecordId"] = DbManager.FIELDTYPE.INTEGER;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["IsTaInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["TransactionExchangeRate"] = DbManager.FIELDTYPE.DOUBLE;

            /*
            foreignKeys["CreditNoteID"] = "Sales(CreditNoteID)";
            foreignKeys["CardRecordId"] = "Cards(CardRecordId)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
                * */

            TableCommands["SettledCredits"] = DbMgr.CreateTableCommand("SettledCredits", fields, "SettledCreditID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(SettledCredit _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("SettledCredits", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(SettledCredit _obj)
        {
            return DbMgr.CreateUpdateClause("SettledCredits", GetFields(_obj), "SettledCreditID", _obj.SettledCreditID);
        }

       

        protected override OpResult _Store(SettledCredit _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "SettledCredit object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.SettledCreditID == null)
            {
                _obj.SettledCreditID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

    }
}
