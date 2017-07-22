using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data.Common;
using System.Data;
using Accounting.Core;
using Accounting.Core.Cards;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbSupplierManager : SupplierManager
    {
        public DbSupplierManager(DbManager mgr)
            : base(mgr)
        {

        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["SupplierID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CardIdentification"] = DbManager.FIELDTYPE.VARCHAR_16;
            fields["Name"] = DbManager.FIELDTYPE.VARCHAR_52;
            fields["LastName"] = DbManager.FIELDTYPE.VARCHAR_52;
            fields["FirstName"] = DbManager.FIELDTYPE.VARCHAR_20;
            fields["IsIndividual"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IsInactive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Picture"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["Notes"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["IdentifierID"] = DbManager.FIELDTYPE.VARCHAR_26;
            fields["CustomList1ID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CustomList2ID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CustomList3ID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CustomField1"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["CustomField2"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["CustomField3"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["TermsID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxIDNumber"] = DbManager.FIELDTYPE.VARCHAR_19;
            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["FreightTaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["UseSupplierTaxCode"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CreditLimit"] = DbManager.FIELDTYPE.DOUBLE;
            fields["VolumeDiscount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CurrentBalance"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TotalDeposits"] = DbManager.FIELDTYPE.DOUBLE;
            fields["SupplierSince"] = DbManager.FIELDTYPE.DATETIME;
            fields["LastPurchaseDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["LastPaymentDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["TotalPayableDays"] = DbManager.FIELDTYPE.INTEGER;
            fields["TotalPaidPurchases"] = DbManager.FIELDTYPE.INTEGER;
            fields["HighestPurchaseAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["HighestPayableAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["EstimatedCostPerHour"] = DbManager.FIELDTYPE.DOUBLE;
            fields["HourlyBillingRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["PurchaseLayoutID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["PrintedForm"] = DbManager.FIELDTYPE.VARCHAR_34;
            fields["InvoiceDeliveryID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["ExpenseAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PaymentMemo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PaymentCardNumber"] = DbManager.FIELDTYPE.VARCHAR_25;
            fields["PaymentNameOnCard"] = DbManager.FIELDTYPE.VARCHAR_50;
            fields["PaymentExpiryDate"] = DbManager.FIELDTYPE.VARCHAR_10; //in MYOB is given by TEXT[yy/mm]
            fields["PaymentNotes"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PurchaseCommentID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ShippingMethodID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PaymentDeliveryID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["ChangeControl"] = DbManager.FIELDTYPE.INTEGER;
            fields["MethodOfPaymentID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ABN"] = DbManager.FIELDTYPE.VARCHAR_14;
            fields["ABNBranch"] = DbManager.FIELDTYPE.VARCHAR_11;
            fields["BSBCode"] = DbManager.FIELDTYPE.VARCHAR_9;
            fields["BankAccountNumber"] = DbManager.FIELDTYPE.VARCHAR_19;
            fields["BankAccountName"] = DbManager.FIELDTYPE.VARCHAR_26;
            fields["Identifiers"] = DbManager.FIELDTYPE.VARCHAR_26;

            /*
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["IdentifierID"] = "Identifiers(IdentifierID)";
            foreignKeys["CustomList1ID"] = "CustomLists(CustomList1ID)";
            foreignKeys["CustomList2ID"] = "CustomLists(CustomList2ID)";
            foreignKeys["CustomList3ID"] = "CustomLists(CustomList3ID)";
            foreignKeys["TermsID"] = "Terms(TermsID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
            foreignKeys["PurchaseLayoutID"] = "InvoiceType(PurchaseLayoutID)";
            foreignKeys["PurchaseCommentID"] = "Comments(PurchaseCommentID)";
            foreignKeys["InvoiceDeliveryID"] = "InvoiceDelivery(InvoiceDeliveryID)";
            foreignKeys["ExpenseAccountID"] = "Accounts(ExpenseAccountID)";
            foreignKeys["ShippingMethodID"] = "Methods(ShippingMethodID)";
            foreignKeys["PaymentDeliveryID"] = "InvoiceDelivery(PaymentDeliveryID)";
             * */

            TableCommands["Suppliers"] = DbMgr.CreateTableCommand("Suppliers", fields, "SupplierID", foreignKeys);
        }

        

        private DbInsertStatement GetQuery_InsertQuery(Supplier _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("Suppliers", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(Supplier _obj)
        {
            return DbMgr.CreateUpdateClause("Suppliers", GetFields(_obj), "SupplierID", _obj.SupplierID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(Supplier _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("Suppliers").Criteria.IsEqual("Suppliers", "SupplierID", _obj.SupplierID);
            
            return clause;
        }

        

        protected override OpResult _Store(Supplier _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Supplier object cannot be created as it is null");
            }

            RepositoryMgr.CardMgr.Store(_obj);
            _obj.SupplierID = _obj.CardRecordID;

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.SupplierID == null)
            {
                _obj.SupplierID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(Supplier _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Supplier object cannot be deleted as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                RepositoryMgr.CardMgr.Delete(_obj);
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }
            else
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "Supplier object cannot be deleted as it does not exist");
            }
        }
    }
}
