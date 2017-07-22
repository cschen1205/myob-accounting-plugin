using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Cards;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbCustomerManager : CustomerManager
    {
        public DbCustomerManager(DbManager mgr)
            : base(mgr)
        {
            
        }

         protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["CustomerID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
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
            fields["TermsID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PriceLevelID"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["TaxIDNumber"] = DbManager.FIELDTYPE.VARCHAR_19;
            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["FreightTaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["UseCustomerTaxCode"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CreditLimit"] = DbManager.FIELDTYPE.DOUBLE;
            fields["OnHold"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["VolumeDiscount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CurrentBalance"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TotalDeposits"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CustomerSince"] = DbManager.FIELDTYPE.DATETIME;
            fields["LastSaleDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["LastPaymentDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["TotalReceivableDays"] = DbManager.FIELDTYPE.INTEGER;
            fields["TotalPaidInvoices"] = DbManager.FIELDTYPE.INTEGER;
            fields["HighestInvoiceAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["HighestReceivableAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["MethodOfPaymentID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PaymentCardNumber"] = DbManager.FIELDTYPE.VARCHAR_25;
            fields["PaymentNameOnCard"] = DbManager.FIELDTYPE.VARCHAR_50;
            fields["PaymentExpiryDate"] = DbManager.FIELDTYPE.VARCHAR_10; //in MYOB is given by TEXT[yy/mm]
            fields["PaymentNotes"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["HourlyBillingRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["SaleLayoutID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["PrintedForm"] = DbManager.FIELDTYPE.VARCHAR_34;
            fields["InvoiceDeliveryID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IncomeAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ReceiptMemo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["SalespersonID"] = DbManager.FIELDTYPE.INTEGER;
            fields["SaleCommentID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ShippingMethodID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PaymentDeliveryID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["ChangeControl"] = DbManager.FIELDTYPE.VARCHAR_15;
            fields["ABN"] = DbManager.FIELDTYPE.VARCHAR_14;
            fields["ABNBranch"] = DbManager.FIELDTYPE.VARCHAR_11;
            fields["FirstName"] = DbManager.FIELDTYPE.VARCHAR_20;
            fields["IdentifierID"] = DbManager.FIELDTYPE.VARCHAR_26;
            fields["CustomList1ID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CustomList2ID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CustomList3ID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CustomField1"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["CustomField2"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["CustomField3"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["Identifiers"] = DbManager.FIELDTYPE.VARCHAR_26;
            fields["PaymentBSB"] = DbManager.FIELDTYPE.VARCHAR_7;
            fields["PaymentBankAccountName"] = DbManager.FIELDTYPE.VARCHAR_32;
            fields["PaymentBankAccountNumber"] = DbManager.FIELDTYPE.VARCHAR_11;

            /*
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["IdentifierID"] = "Identifiers(IdentifierID)";
            foreignKeys["CustomList1ID"] = "CustomLists(CustomList1ID)";
            foreignKeys["CustomList2ID"] = "CustomLists(CustomList2ID)";
            foreignKeys["CustomList3ID"] = "CustomLists(CustomList3ID)";
            foreignKeys["TermsID"] = "Terms(TermsID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
            foreignKeys["PaymentMethodID"] = "PaymentMethods(PaymentMethodID)";
            foreignKeys["CodeID"] = "TaxCodes(CodeID)";
            foreignKeys["SaleLayoutID"] = "InvoiceType(SaleLayoutID)";
            foreignKeys["PriceLevelID"] = "PriceLevels(PriceLevelID)";
            foreignKeys["SalespersonID"] = "Cards(SalespersonID)";
            //foreignKeys["SalespersonID"]="Employees(SalespersonID)";
            foreignKeys["SaleCommentID"] = "Comments(SaleCommentID)";
            foreignKeys["InvoiceDeliveryID"] = "InvoiceDelivery(InvoiceDeliveryID)";
            foreignKeys["IncomeAccountID"] = "Accounts(IncomeAccountID)";
            foreignKeys["ShippingMethodID"] = "Methods(ShippingMethodID)";
            foreignKeys["PaymentDeliveryID"] = "InvoiceDelivery(PaymentDeliveryID)";
            * */

            TableCommands["Customers"] = DbMgr.CreateTableCommand("Customers", fields, "CustomerID", foreignKeys);
        }

       

        private DbInsertStatement GetQuery_InsertQuery(Customer _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("Customers", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(Customer _obj)
        {
            return DbMgr.CreateUpdateClause("Customers", GetFields(_obj), "CustomerID", _obj.CustomerID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(Customer _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("Customers").Criteria.IsEqual("Customers", "CustomerID", _obj.CustomerID);
            
            return clause;
        }

        protected override OpResult _Store(Customer _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Customer object cannot be created as it is null");
            }

            RepositoryMgr.CardMgr.Store(_obj);
            _obj.CustomerID = _obj.CardRecordID;

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.CustomerID == null)
            {
                _obj.CustomerID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(Customer _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Customer object cannot be deleted as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));

                RepositoryMgr.CardMgr.Delete(_obj);
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }
            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "Customer object cannot be deleted as it is null") ;
        }

    }
}
