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
    public sealed class DbCustomerDiscountManager : CustomerDiscountManager
    {
        public DbCustomerDiscountManager(DbManager mgr)
            : base(mgr)
        {
            
        }


        protected override void CreateTableCommands() //CustomerDiscounts()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["CustomerDiscountID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CustomerDiscountNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["TransactionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["ExchangeGainLoss"] = DbManager.FIELDTYPE.DOUBLE;
            fields["PaymentMethodID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PaymentCardNumber"] = DbManager.FIELDTYPE.VARCHAR_25;
            fields["PaymentNameOnCard"] = DbManager.FIELDTYPE.VARCHAR_50;
            fields["PaymentExpirationDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["PaymentAuthorisationNumber"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PaymentBSB"] = DbManager.FIELDTYPE.VARCHAR_7;
            fields["PaymentBankBranch"] = DbManager.FIELDTYPE.VARCHAR_7;
            fields["PaymentBankAccountNumber"] = DbManager.FIELDTYPE.VARCHAR_11;
            fields["PaymentBankAccountName"] = DbManager.FIELDTYPE.VARCHAR_32;
            fields["PaymentChequeNumber"] = DbManager.FIELDTYPE.VARCHAR_25;
            fields["PaymentNotes"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TransactionExchangeRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["DiscountAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TotalDiscount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["IsTaxInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["PaymentMethodID"] = "PaymentMethods(PaymentMethodID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["DiscountAccountID"] = "Accounts(DiscountAccountID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
             * */

            TableCommands["CustomerDiscounts"] = DbMgr.CreateTableCommand("CustomerDiscounts", fields, "CustomerDiscountID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(CustomerDiscount _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("CustomerDiscounts", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(CustomerDiscount _obj)
        {
            return DbMgr.CreateUpdateClause("CustomerDiscounts", GetFields(_obj), "CustomerDiscountID", _obj.CustomerDiscountID);
        }

       

        protected override OpResult _Store(CustomerDiscount _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "CustomerDiscount object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));

            if (_obj.CustomerDiscountID == null)
            {
                _obj.CustomerDiscountID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

    }
}
