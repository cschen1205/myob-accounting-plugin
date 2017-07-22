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
    public sealed class DbCustomerFinanceChargeManager : CustomerFinanceChargeManager
    {
        public DbCustomerFinanceChargeManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //CustomerFinanceCharges()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["CustomerFinanceChargeID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CustomerFinanceChargeNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["TransactionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TransactionExchangeRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["LateChargesAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["FinanceCharge"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ExchangeGainLoss"] = DbManager.FIELDTYPE.DOUBLE;
            fields["MethodOfPaymentID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PaymentCardNumber"] = DbManager.FIELDTYPE.VARCHAR_25;
            fields["PaymentNameOnCard"] = DbManager.FIELDTYPE.VARCHAR_50;
            fields["PaymentExpirationDate"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["PaymentAuthorisationNumber"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PaymentBankBranch"] = DbManager.FIELDTYPE.VARCHAR_7;
            fields["PaymentBSB"] = DbManager.FIELDTYPE.VARCHAR_7;
            fields["PaymentBankAccountNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["PaymentBankAccountName"] = DbManager.FIELDTYPE.VARCHAR_32;
            fields["PaymentChequeNumber"] = DbManager.FIELDTYPE.VARCHAR_25;
            fields["IsTaxInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["PaymentNotes"] = DbManager.FIELDTYPE.VARCHAR_255;

            /*
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["LateChargesAccountID"] = "Accounts(LateChargesAccountID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["PaymentMethodID"] = "PaymentMethods(PaymentMethodID)";
             * */

            TableCommands["CustomerFinanceCharges"] = DbMgr.CreateTableCommand("CustomerFinanceCharges", fields, "CustomerFinanceChargeID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(CustomerFinanceCharge _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("CustomerFinanceCharges", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(CustomerFinanceCharge _obj)
        {
            return DbMgr.CreateUpdateClause("CustomerFinanceCharges", GetFields(_obj), "CustomerFinanceChargeID", _obj.CustomerFinanceChargeID);
        }

       

        protected override OpResult _Store(CustomerFinanceCharge _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "CustomerFinanceCharge object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.CustomerFinanceChargeID == null)
            {
                _obj.CustomerFinanceChargeID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

    }
}
