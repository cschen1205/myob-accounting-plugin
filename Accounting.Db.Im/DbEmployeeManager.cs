using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using System.Data;
using Accounting.Core;
using Accounting.Core.Cards;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbEmployeeManager : EmployeeManager
    {
        public DbEmployeeManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["EmployeeID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CardIdentification"] = DbManager.FIELDTYPE.VARCHAR_16;
            fields["Name"] = DbManager.FIELDTYPE.VARCHAR_52;
            fields["Gender"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["LastName"] = DbManager.FIELDTYPE.VARCHAR_52;
            fields["FirstName"] = DbManager.FIELDTYPE.VARCHAR_20;
            fields["IsIndividual"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IsInactive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["BasePay"] = DbManager.FIELDTYPE.DOUBLE;
            fields["Picture"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["Notes"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["HourlyBillingRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["EstimatedCostPerHour"] = DbManager.FIELDTYPE.DOUBLE;
            fields["PaymentDeliveryID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["ChangeControl"] = DbManager.FIELDTYPE.VARCHAR_20;
            fields["DateOfBirth"] = DbManager.FIELDTYPE.DATETIME;
            fields["IdentifierID"] = DbManager.FIELDTYPE.VARCHAR_26;
            fields["CustomList1ID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CustomList2ID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CustomList3ID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CustomField1"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["CustomField2"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["CustomField3"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["Identifiers"] = DbManager.FIELDTYPE.VARCHAR_26;
            fields["BSBCode"] = DbManager.FIELDTYPE.VARCHAR_9;
            fields["BankAccountName"] = DbManager.FIELDTYPE.VARCHAR_32;
            fields["BankAccountNumber"] = DbManager.FIELDTYPE.VARCHAR_19;
            fields["NumberOfBankAccounts"] = DbManager.FIELDTYPE.INTEGER;
            fields["BSBCode2"] = DbManager.FIELDTYPE.VARCHAR_9;
            fields["BankAccountName2"] = DbManager.FIELDTYPE.VARCHAR_32;
            fields["BankAccountNumber2"] = DbManager.FIELDTYPE.VARCHAR_19;
            fields["BSBCode3"] = DbManager.FIELDTYPE.VARCHAR_9;
            fields["BankAccountName3"] = DbManager.FIELDTYPE.VARCHAR_32;
            fields["BankAccountNumber3"] = DbManager.FIELDTYPE.VARCHAR_19;
            fields["Bank1ValueTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Bank2ValueTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Bank3ValueTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Bank1Value"] = DbManager.FIELDTYPE.DOUBLE;
            fields["Bank2Value"] = DbManager.FIELDTYPE.DOUBLE;
            fields["Bank3Value"] = DbManager.FIELDTYPE.DOUBLE;
            fields["StatementText"] = DbManager.FIELDTYPE.VARCHAR_18;
            fields["EmploymentBasisID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["PaymentTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["EmploymentClassificationID"] = DbManager.FIELDTYPE.INTEGER;
            fields["StartDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["TerminationDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["PayBasisID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["PayFrequencyID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["HoursInPayPeriod"] = DbManager.FIELDTYPE.DOUBLE;
            fields["WagesExpenseAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["SuperannuationFundID"] = DbManager.FIELDTYPE.INTEGER;
            fields["SuperannuationMembershipNumber"] = DbManager.FIELDTYPE.VARCHAR_16;
            fields["TaxFileNumber"] = DbManager.FIELDTYPE.VARCHAR_11;
            fields["TaxScaleID"] = DbManager.FIELDTYPE.INTEGER;
            fields["WithholdingVariationRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TotalRebates"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ExtraTax"] = DbManager.FIELDTYPE.DOUBLE;
            fields["EmploymentStatusID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["EmploymentCategoryID"] = DbManager.FIELDTYPE.VARCHAR_1;

            /*
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["IdentifierID"] = "Identifiers(IdentifierID)";
            foreignKeys["CustomList1ID"] = "CustomLists(CustomList1ID)";
            foreignKeys["CustomList2ID"] = "CustomLists(CustomList2ID)";
            foreignKeys["CustomList3ID"] = "CustomLists(CustomList3ID)";
            foreignKeys["PaymentDeliveryID"] = "InvoiceDelivery(PaymentDeliveryID)";
             * */

            TableCommands["Employees"] = DbMgr.CreateTableCommand("Employees", fields, "EmployeeID", foreignKeys);
        }

       

        private DbInsertStatement GetQuery_InsertQuery(Employee _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
           
            return DbMgr.CreateInsertClause("Employees", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(Employee _obj)
        {
            return DbMgr.CreateUpdateClause("Employees", GetFields(_obj), "EmployeeID", _obj.EmployeeID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(Employee _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("Employees").Criteria.IsEqual("Employees", "EmployeeID", _obj.EmployeeID);
            
            return clause;
        }

       

        protected override OpResult _Store(Employee _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Employee object cannot be created as it is null");
            }

            RepositoryMgr.CardMgr.Store(_obj);
            _obj.EmployeeID = _obj.CardRecordID;

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.EmployeeID == null)
            {
                _obj.EmployeeID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(Employee _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Employee object cannot be deleted as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));

                RepositoryMgr.CardMgr.Delete(_obj);

                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }
            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "Employee object cannot be deleted as it does not exist");
        }
    }
}
