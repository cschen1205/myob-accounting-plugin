using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Purchases;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbSettledDebitManager : SettledDebitManager
    {
        public DbSettledDebitManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //SettledDebits()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["SettledDebitID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["SettledDebitNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["TransactionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["DebitNoteID"] = DbManager.FIELDTYPE.INTEGER;
            fields["AmountSettled"] = DbManager.FIELDTYPE.DOUBLE;
            fields["IsDiscount"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["FinanceCharge"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ExchangeGainLoss"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["IsTaxInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TransactionExchangeRate"] = DbManager.FIELDTYPE.DOUBLE;

            /*
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["DebitNoteID"] = "Purchases(DebitNoteID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
             * */

            TableCommands["SettledDebits"] = DbMgr.CreateTableCommand("SettledDebits", fields, "SettledDebitID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(SettledDebit _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("SettledDebits", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(SettledDebit _obj)
        {
            return DbMgr.CreateUpdateClause("SettledDebits", GetFields(_obj), "SettledDebitID", _obj.SettledDebitID);
        }

       

        protected override OpResult _Store(SettledDebit _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "SettledDebit object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.SettledDebitID == null)
            {
                _obj.SettledDebitID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

    }
}
