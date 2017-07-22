using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Misc;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbDataFileInformationManager : DataFileInformationManager
    {
        public DbDataFileInformationManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //DataFileInformation()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ABN"] = DbManager.FIELDTYPE.VARCHAR_14;
            fields["ABNBranch"] = DbManager.FIELDTYPE.VARCHAR_11;
            fields["GSTRegistrationNumber"] = DbManager.FIELDTYPE.VARCHAR_19;

            fields["ACN"] = DbManager.FIELDTYPE.VARCHAR_19;
            fields["ID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PostCode"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["WebSite"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["City"] = DbManager.FIELDTYPE.VARCHAR_25;
            fields["Province"] = DbManager.FIELDTYPE.VARCHAR_25;
            fields["Phone1"] = DbManager.FIELDTYPE.VARCHAR_20;
            fields["CompanyName"] = DbManager.FIELDTYPE.VARCHAR_40;
            fields["Address"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["Phone2"] = DbManager.FIELDTYPE.VARCHAR_20;
            fields["FaxNumber"] = DbManager.FIELDTYPE.VARCHAR_20;
            fields["IRDNumber"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["ServiceTaxNumber"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["BankCode"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["BankID"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["BSBCode"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["BankAccountNumber"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["BankAccountName"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["IsSelfBalancing"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["CompanyNumber"] = DbManager.FIELDTYPE.VARCHAR_19;
            fields["CompanyRegistrationNumber"] = DbManager.FIELDTYPE.VARCHAR_19;
            fields["CurrentFinancialYear"] = DbManager.FIELDTYPE.INTEGER;
            fields["LastMonthInFinancialYear"] = DbManager.FIELDTYPE.INTEGER;
            fields["SalesTaxNumber"] = DbManager.FIELDTYPE.VARCHAR_19;
            fields["Email"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["CurrentFinancialYear"] = DbManager.FIELDTYPE.INTEGER;
            fields["LastMonthInFinancialYear"] = DbManager.FIELDTYPE.INTEGER;
            fields["ConversionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["PeriodsPerYear"] = DbManager.FIELDTYPE.INTEGER;
            fields["LastPurgeDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["LastBackupDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["DatabaseVersion"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["DataFileCountry"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["DriverBuildNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["SerialNumber"] = DbManager.FIELDTYPE.VARCHAR_13;
            fields["UseRetailManagerLink"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["UseMultipleCurrencies"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["UseCategories"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CategoriesRequired"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["UseDailyAgeing"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["FirstAgeingPeriod"] = DbManager.FIELDTYPE.INTEGER;
            fields["SecondAgeingPeriod"] = DbManager.FIELDTYPE.INTEGER;
            fields["ThirdAgeingPeriod"] = DbManager.FIELDTYPE.INTEGER;
            fields["IdentifyAgeByName"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["LockPeriodIsActive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["LockPeriodDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["LockThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["DefaultCustomerTermsID"] = DbManager.FIELDTYPE.INTEGER;
            fields["DefaultCustomerPriceLevelID"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["DefaultCustomerTaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["DefaultUseCustomerTaxCode"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["DefaultCustomerFreightTaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["DefaultCustomerCreditLimit"] = DbManager.FIELDTYPE.DOUBLE;
            fields["DefaultSupplierTermsID"] = DbManager.FIELDTYPE.INTEGER;
            fields["DefaultSupplierTaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["DefaultUseSupplierTaxCode"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["DefaultSupplierFreightTaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["DefaultSupplierCreditLimit"] = DbManager.FIELDTYPE.DOUBLE;
            fields["InvoiceSubject"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["InvoiceMessage"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["IncludeInvoiceNumber"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["InvoiceQuoteSubject"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["InvoiceQuoteMessage"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["IncludeInvoiceQuoteNumber"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["InvoiceOrderSubject"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["InvoiceOrderMessage"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["IncludeInvoiceOrderNumber"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["PurchaseSubject"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PurchaseMessage"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PayeeNumber"] = DbManager.FIELDTYPE.VARCHAR_8;
            fields["IncludePurchaseNumber"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["PurchaseQuoteSubject"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PurchaseQuoteMessage"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["IncludePurchaseQuoteNumber"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["PurchaseOrderSubject"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PurchaseOrderMessage"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["IncludePurchaseOrderNumber"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["StatementSubject"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["StatementMessage"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PaymentSubject"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PaymentMessage"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["UseAuditTracking"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["UseCreditLimitWarning"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["LimitTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["ChangeControl"] = DbManager.FIELDTYPE.VARCHAR_15;
            fields["UseStandardCost"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["UseReceivablesFreight"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["UseReceivablesDeposits"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["UseReceivablesDiscounts"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["UseReceivablesLateFees"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["UsePayablesInventory"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["UsePayablesFreight"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["UsePayablesDeposits"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["UsePayablesDiscounts"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["UsePayablesLateFees"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["StatementParticulars"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["StatementCode"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["StatementReference"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["CompanyFileNumber"] = DbManager.FIELDTYPE.VARCHAR_13;
            fields["CostCentresRequired"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["UseCostCentres"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["UseSimplifiedTaxSystem"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["SimplifiedTaxSystemDate"] = DbManager.FIELDTYPE.DATETIME;

            /*
            foreignKeys["DefaultCustomerTermsID"] = "Terms(DefaultCustomerTermsID)";
            foreignKeys["DefaultCustomerPriceLevelID"] = "PriceLevels(DefaultCustomerPriceLevelID)";
            foreignKeys["DefaultCustomerTaxCodeID"] = "TaxCodes(DefaultCustomerTaxCodeID)";
            foreignKeys["DefaultCustomerFreightTaxCodeID"] = "TaxCodes(DefaultCustomerFreightTaxCodeID)";
            foreignKeys["DefaultSupplierTermsID"] = "Terms(DefaultSupplierTermsID)";
            foreignKeys["DefaultSupplierTaxCodeID"] = "TaxCodes(DefaultSupplierTaxCodeID)";
            foreignKeys["DefaultSupplierFreightTaxCodeID"] = "TaxCodes(DefaultSupplierFreightTaxCodeID)";
            foreignKeys["LimitTypeID"] = "LimitTypes(LimitTypeID)";
             * */

            TableCommands["DataFileInformation"] = DbMgr.CreateTableCommand("DataFileInformation", fields, "", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(DataFileInformation _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("DataFileInformation", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(DataFileInformation _obj)
        {
            return DbMgr.CreateUpdateClause("DataFileInformation", GetFields(_obj), "CompanyName", _obj.CompanyName);
        }



        protected override OpResult _Store(DataFileInformation _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "DataFileInformation object cannot be created as it is null");
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
