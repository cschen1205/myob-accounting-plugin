using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Currencies;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbCurrencyManager : CurrencyManager
    {
        private DbInsertStatement GetQuery_InsertQuery(Currency _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("Currency", fields);
        }



        protected override void CreateTableCommands() //Currency()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CurrencyCode"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["CurrencyName"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["ExchangeRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CurrencySymbol"] = DbManager.FIELDTYPE.VARCHAR_4;
            fields["DigitGroupingSymbol"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["SymbolPosition"] = DbManager.FIELDTYPE.VARCHAR_13;
            fields["DecimalPlaces"] = DbManager.FIELDTYPE.INTEGER;
            fields["NumberDigitsInGroup"] = DbManager.FIELDTYPE.INTEGER;
            fields["DecimalPlaceSymbol"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["NegativeFormat"] = DbManager.FIELDTYPE.VARCHAR_25;
            fields["UseLeadingZero"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["LinkedReceivablesAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LinkedReceivablesChequeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LinkedReceivablesFreightID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LinkedReceivablesDepositsID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LinkedReceivablesDiscountsID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LinkedReceivablesLateFeesID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LinkedPayablesAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LinkedPayablesChequeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LinkedPayablesFreightID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LinkedPayablesDepositsID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LinkedPayablesDiscountsID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LinkedPayablesLateFeesID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LinkedPayablesInventoryID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ERJan"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ERFeb"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ERMar"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ERApr"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ERMay"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ERJun"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ERJul"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ERAug"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ERSep"] = DbManager.FIELDTYPE.DOUBLE;
            fields["EROct"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ERNov"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ERDec"] = DbManager.FIELDTYPE.DOUBLE;

            /*
            foreignKeys["LinkedReceivablesAccountID"] = "Accounts(LinkedReceivablesAccountID)";
            foreignKeys["LinkedReceivablesChequeID"] = "Accounts(LinkedReceivablesChequeID)";
            foreignKeys["LinkedReceivablesFreightID"] = "Accounts(LinkedReceivablesFreightID)";
            foreignKeys["LinkedReceivablesDepositsID"] = "Accounts(LinkedReceivablesDepositsID)";
            foreignKeys["LinkedReceivablesDiscountsID"] = "Accounts(LinkedReceivablesDiscountsID)";
            foreignKeys["LinkedReceivablesLateFeesID"] = "Accounts(LinkedReceivablesLateFeesID)";
            foreignKeys["LinkedPayablesAccountID"] = "Accounts(LinkedPayablesAccountID)";
            foreignKeys["LinkedPayablesChequeID"] = "Accounts(LinkedPayablesChequeID)";
            foreignKeys["LinkedPayablesFreightID"] = "Accounts(LinkedPayablesFreightID)";
            foreignKeys["LinkedPayablesDepositsID"] = "Accounts(LinkedPayablesDepositsID)";
            foreignKeys["LinkedPayablesDiscountsID"] = "Accounts(LinkedPayablesDiscountsID)";
            foreignKeys["LinkedPayablesLateFeesID"] = "Accounts(LinkedPayablesLateFeesID)";
            foreignKeys["LinkedPayablesInventoryID"] = "Accounts(LinkedPayablesInventoryID)";
             * */

            TableCommands["Currency"] = DbMgr.CreateTableCommand("Currency", fields, "CurrencyID", foreignKeys);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(Currency _obj)
        {
            DbUpdateStatement clause = DbMgr.CreateUpdateClause();
            clause
                .UpdateColumns(GetFields(_obj))
                .From("Currency")
                .Criteria.IsEqual("Currency", "CurrencyID", _obj.CurrencyID);

            return clause;
        }

        
        protected override OpResult _Store(Currency _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Currency object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.CurrencyID == null)
            {
                _obj.CurrencyID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        public DbCurrencyManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
