using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Data;
using System.Data.Odbc;
using Accounting.Core;
using Accounting.Util;
using Accounting.Core.Cards;
using Accounting.Core.TaxCodes;
using Accounting.Core.Definitions;
using Accounting.Core.Currencies;
using Accounting.Core.Terms;
using Accounting.Core.Inventory;
using Accounting.Core.Accounts;
using Accounting.Core.Purchases;
using Accounting.Core.Misc;
using Accounting.Core.ShippingMethods;
using Accounting.Core.Sales;
using Accounting.Core.Jobs;
using Accounting.Core.JournalRecords;
using Accounting.Core.Transactions;
using Accounting.Core.Activities;
using Accounting.Core.Security;
using Accounting.Core.Payroll;
using Accounting.Core.CostCentres;
using Accounting.Db;
using Accounting.Db.Elements;
using System.Data.Common;
using Accounting.Db.Myob.Elements;

namespace Accounting.Db.Myob
{
    public class MyobDbManager : DbManager
    {
        public MyobDbManager(RepositoryManager mgr, string name)
            : base(mgr, name)
        {
            
        }

        public override bool AllowDelete
        {
            get
            {
                return false;
            }
        }

        public override bool AllowUpdate
        {
            get
            {
                return true;
            }
        }

        public override EmploymentClassificationManager CreateEmploymentClassificationMgr()
        {
            return new DbEmploymentClassificationManager(this);
        }

        public override EmploymentBasisManager CreateEmploymentBasisMgr()
        {
            return new DbEmploymentBasisManager(this);
        }

        public override CustomListManager CreateCustomListMgr()
        {
            return new DbCustomListManager(this);
        }

        public override ItemDataFieldEntryManager CreateItemDataFieldEntryMgr()
        {
            return new DbItemDataFieldEntryManager(this);
        }

        public override DataFieldManager CreateDataFieldMgr()
        {
            return new DbDataFieldManager(this);
        }

        public override MiscNumberManager CreateMiscNumberMgr()
        {
            return new DbMiscNumberManager(this);
        }

        public override ItemSizeManager CreateItemSizeMgr()
        {
            return new DbItemSizeManager(this);
        }

        public override GenderManager CreateGenderMgr()
        {
            return new DbGenderManager(this);
        }

        public override ItemAddOnManager CreateItemAddOnMgr()
        {
            return new DbItemAddOnManager(this);
        }

        public override WageHourHistoryManager CreateWageHourHistoryMgr()
        {
            return new DbWageHourHistoryManager(this);
        }

        public override WageDollarHistoryManager CreateWageDollarHistoryMgr()
        {
            return new DbWageDollarHistoryManager(this);
        }

        public override LinkedCategoryManager CreateLinkedCategoryMgr()
        {
            return new DbLinkedCategoryManager(this);
        }

        public override LinkedEmployeeManager CreateLinkedEmployeeMgr()
        {
            return new DbLinkedEmployeeManager(this);
        }


        public override CostCentreAccountManager CreateCostCentreAccountMgr()
        {
            return new DbCostCentreAccountManager(this);
        }

        public override CostCentreAccountActivityManager CreateCostCentreAccountActivityMgr()
        {
            return new DbCostCentreAccountActivityManager(this);
        }

        public override CostCentreJournalRecordManager CreateCostCentreJournalRecordMgr()
        {
            return new DbCostCentreJournalRecordManager(this);
        }

        public override CostCentreManager CreateCostCentreMgr()
        {
            return new DbCostCentreManager(this);
        }

        public override RecurringItemPurchaseLineManager CreateRecurringItemPurchaseLineMgr()
        {
            return new DbRecurringItemPurchaseLineManager(this);
        }

        public override RecurringMiscPurchaseLineManager CreateRecurringMiscPurchaseLineMgr()
        {
            return new DbRecurringMiscPurchaseLineManager(this);
        }

        public override RecurringProfessionalPurchaseLineManager CreateRecurringProfessionalPurchaseLineMgr()
        {
            return new DbRecurringProfessionalPurchaseLineManager(this);
        }

        public override RecurringServicePurchaseLineManager CreateRecurringServicePurchaseLineMgr()
        {
            return new DbRecurringServicePurchaseLineManager(this);
        }

        public override RecurringTimeBillingPurchaseLineManager CreateRecurringTimeBillingPurchaseLineMgr()
        {
            return new DbRecurringTimeBillingPurchaseLineManager(this);
        }

        public override RecurringPurchaseLineManager CreateRecurringPurchaseLineMgr()
        {
            return new DbRecurringPurchaseLineManager(this);
        }

        public override RecurringPurchaseManager CreateRecurringPurchaseMgr()
        {
            return new DbRecurringPurchaseManager(this);
        }

        public override PayrollInformationManager CreatePayrollInformationMgr()
        {
            return new DbPayrollInformationManager(this);
        }

        public override BASInformationManager CreateBASInformationMgr()
        {
            return new DbBASInformationManager(this);
        }

        public override PaySuperannuationLineManager CreatePaySuperannuationLineMgr()
        {
            return new DbPaySuperannuationLineManager(this);
        }

        public override PaySuperannuationManager CreatePaySuperannuationMgr()
        {
            return new DbPaySuperannuationManager(this);
        }

        public override SuperannuationFundManager CreateSuperannuationFundMgr()
        {
            return new DbSuperannuationFundManager(this);
        }

        public override PayLiabilityLineManager CreatePayLiabilityLineMgr()
        {
            return new DbPayLiabilityLineManager(this);
        }

        public override PayLiabilityManager CreatePayLiabilityMgr()
        {
            return new DbPayLiabilityManager(this);
        }

        public override WritePaychequeLineManager CreateWritePaychequeLineMgr()
        {
            return new DbWritePaychequeLineManager(this);
        }

        public override PayBasisManager CreatePayBasisMgr()
        {
            return new DbPayBasisManager(this);
        }

        public override CategoryTypeManager CreateCategoryTypeMgr()
        {
            return new DbCategoryTypeManager(this);
        }

        public override WritePaychequeManager CreateWritePaychequeMgr()
        {
            return new DbWritePaychequeManager(this);
        }

        public override BankingDetailManager CreateBankingDetailMgr()
        {
            return new DbBankingDetailManager(this);
        }

        public override PaymentTypeManager CreatePaymentTypeMgr()
        {
            return new DbPaymentTypeManager(this);
        }

        public override BankDepositLineManager CreateBankDepositLineMgr()
        {
            return new DbBankDepositLineManager(this);
        }

        public override BankDepositManager CreateBankDepositMgr()
        {
            return new DbBankDepositManager(this);
        }

        public override RecurringItemSaleLineManager CreateRecurringItemSaleLineMgr()
        {
            return new DbRecurringItemSaleLineManager(this);
        }

        public override RecurringMiscSaleLineManager CreateRecurringMiscSaleLineMgr()
        {
            return new DbRecurringMiscSaleLineManager(this);
        }

        public override RecurringProfessionalSaleLineManager CreateRecurringProfessionalSaleLineMgr()
        {
            return new DbRecurringProfessionalSaleLineManager(this);
        }

        public override RecurringServiceSaleLineManager CreateRecurringServiceSaleLineMgr()
        {
            return new DbRecurringServiceSaleLineManager(this);
        }

        public override RecurringTimeBillingSaleLineManager CreateRecurringTimeBillingSaleLineMgr()
        {
            return new DbRecurringTimeBillingSaleLineManager(this);
        }

        public override RecurringSaleLineManager CreateRecurringSaleLineMgr()
        {
            return new DbRecurringSaleLineManager(this);
        }

        public override RecurringSaleManager CreateRecurringSaleMgr()
        {
            return new DbRecurringSaleManager(this);
        }


        public override RecurringGeneralJournalLineManager CreateRecurringGeneralJournalLineMgr()
        {
            return new DbRecurringGeneralJournalLineManager(this);
        }

        public override RecurringGeneralJournalManager CreateRecurringGeneralJournalMgr()
        {
            return new DbRecurringGeneralJournalManager(this);
        }

        public override RecurringTransferMoneyManager CreateRecurringTransferMoneyMgr()
        {
            return new DbRecurringTransferMoneyManager(this);
        }

        public override RecurringMoneyReceivedLineManager CreateRecurringMoneyReceivedLineMgr()
        {
            return new DbRecurringMoneyReceivedLineManager(this);
        }

        public override RecurringMoneyReceivedManager CreateRecurringMoneyReceivedMgr()
        {
            return new DbRecurringMoneyReceivedManager(this);
        }

        public override RecurringMoneySpentLineManager CreateRecurringMoneySpentLineMgr()
        {
            return new DbRecurringMoneySpentLineManager(this);
        }

        public override RecurringMoneySpentManager CreateRecurringMoneySpentMgr()
        {
            return new DbRecurringMoneySpentManager(this);
        }

        public override NumberingTypeManager CreateNumberingTypeMgr()
        {
            return new DbNumberingTypeManager(this);
        }

        public override FrequencyManager CreateFrequencyMgr()
        {
            return new DbFrequencyManager(this);
        }

        public override ContributionTypeManager CreateContributionTypeMgr()
        {
            return new DbContributionTypeManager(this);
        }

        public override EmployerExpenseTypeManager CreateEmployerExpenseTypeMgr()
        {
            return new DbEmployerExpenseTypeManager(this);
        }

        public override CalculationMethodManager CreateCalculationMethodMgr()
        {
            return new DbCalculationMethodManager(this);
        }

        public override TerminationMethodManager CreateTerminationMethodMgr()
        {
            return new DbTerminationMethodManager(this);
        }
        public override DayNameManager CreateDayNameMgr()
        {
            return new DbDayNameManager(this);
        }

        public override EmploymentStatusManager CreateEmploymentStatusMgr()
        {
            return new DbEmploymentStatusManager(this);
        }

        public override AccountingBasisManager CreateAccountingBasisMgr()
        {
            return new DbAccountingBasisManager(this);
        }

        public override ImportantDatesManager CreateImportantDatesMgr()
        {
            return new DbImportantDatesManager(this);
        }

        public override AuditTrailManager CreateAuditTrailMgr()
        {
            return new DbAuditTrailManager(this);
        }

        public override ElectronicPaymentLineManager CreateElectronicPaymentLineMgr()
        {
            return new DbElectronicPaymentLineManager(this);
        }

        public override ElectronicPaymentManager CreateElectronicPaymentMgr()
        {
            return new DbElectronicPaymentManager(this);
        }

        public override ActivitySlipInvoicedManager CreateActivitySlipInvoicedMgr()
        {
            return new DbActivitySlipInvoicedManager(this);
        }

        public override WageManager CreateWageMgr()
        {
            return new DbWageManager(this);
        }

        public override ActivitySlipManager CreateActivitySlipMgr()
        {
            return new DbActivitySlipManager(this);
        }

        public override ActivitySalesHistoryManager CreateActivitySalesHistoryMgr()
        {
            return new DbActivitySalesHistoryManager(this);
        }

        public override NegativeInventoryManager CreateNegativeInventoryMgr()
        {
            return new DbNegativeInventoryManager(this);
        }

        public override BuildComponentManager CreateBuildComponentMgr()
        {
            return new DbBuildComponentManager(this);
        }

        public override BuiltItemManager CreateBuiltItemMgr()
        {
            return new DbBuiltItemManager(this);
        }

        public override ItemPurchasesHistoryManager CreateItemPurchasesHistoryMgr()
        {
            return new DbItemPurchasesHistoryManager(this);
        }

        public override ItemSalesHistoryManager CreateItemSalesHistoryMgr()
        {
            return new DbItemSalesHistoryManager(this);
        }

        public override ItemOpeningBalanceManager CreateItemOpeningBalanceMgr()
        {
            return new DbItemOpeningBalanceManager(this);
        }

        public override ItemMovementManager CreateItemMovementMgr()
        {
            return new DbItemMovementManager(this);
        }

        public override ItemPriceManager CreateItemPriceMgr()
        {
            return new DbItemPriceManager(this);
        }

        public override MoveItemManager CreateMoveItemMgr()
        {
            return new DbMoveItemManager(this);
        }

        public override RoundingManager CreateRoundingMgr()
        {
            return new DbRoundingManager(this);
        }

        public override TaxInformationConsolidationManager CreateTaxInformationConsolidationMgr()
        {
            return new DbTaxInformationConsolidationManager(this);
        }

        public override TaxInformationManager CreateTaxInformationMgr()
        {
            return new DbTaxInformationManager(this);
        }

        public override TaxCodeConsolidationManager CreateTaxCodeConsolidationMgr()
        {
            return new DbTaxCodeConsolidationManager(this);
        }

        public override EmploymentCategoryManager CreateEmploymentCategoryMgr()
        {
            return new DbEmploymentCategoryManager(this);
        }

        public override ScheduleManager CreateScheduleMgr()
        {
            return new DbScheduleManager(this);
        }

        public override PaymentValueTypeManager CreatePaymentValueTypeMgr()
        {
            return new DbPaymentValueTypeManager(this);
        }

        public override TaxScaleManager CreateTaxScaleMgr()
        {
            return new DbTaxScaleManager(this);
        }

        public override AlertTypeManager CreateAlertTypeMgr()
        {
            return new DbAlertTypeManager(this);
        }

        public override AlertManager CreateAlertMgr()
        {
            return new DbAlertManager(this);
        }

        public override LimitTypeManager CreateLimitTypeMgr()
        {
            return new DbLimitTypeManager(this);
        }

        public override ReportingMethodManager CreateReportingMethodMgr()
        {
            return new DbReportingMethodManager(this);
        }

        public override ReconciliationStatusManager CreateReconciliationStatusMgr()
        {
            return new DbReconciliationStatusManager(this);
        }


        public override SalespersonHistoryManager CreateSalespersonHistoryMgr()
        {
            return new DbSalespersonHistoryManager(this);
        }

        public override InventoryTransferLineManager CreateInventoryTransferLineMgr()
        {
            return new DbInventoryTransferLineManager(this);
        }

        public override InventoryTransferManager CreateInventoryTransferMgr()
        {
            return new DbInventoryTransferManager(this);
        }

        public override InventoryAdjustmentLineManager CreateInventoryAdjustmentLineMgr()
        {
            return new DbInventoryAdjustmentLineManager(this);
        }

        public override InventoryAdjustmentManager CreateInventoryAdjustmentMgr()
        {
            return new DbInventoryAdjustmentManager(this);
        }

        public override DebitRefundManager CreateDebitRefundMgr()
        {
            return new DbDebitRefundManager(this);
        }

        public override SettledDebitLineManager CreateSettledDebitLineMgr()
        {
            return new DbSettledDebitLineManager(this);
        }

        public override SettledDebitManager CreateSettledDebitMgr()
        {
            return new DbSettledDebitManager(this);
        }

        public override CreditRefundManager CreateCreditRefundMgr()
        {
            return new DbCreditRefundManager(this);
        }

        public override SettledCreditLineManager CreateSettledCreditLineMgr()
        {
            return new DbSettledCreditLineManager(this);
        }

        public override SettledCreditManager CreateSettledCreditMgr()
        {
            return new DbSettledCreditManager(this);
        }

        public override SupplierFinanceChargeManager CreateSupplierFinanceChargeMgr()
        {
            return new DbSupplierFinanceChargeManager(this);
        }

        public override SupplierDepositManager CreateSupplierDepositMgr()
        {
            return new DbSupplierDepositManager(this);
        }

        public override SupplierDiscountLineManager CreateSupplierDiscountLineMgr()
        {
            return new DbSupplierDiscountLineManager(this);
        }

        public override SupplierDiscountManager CreateSupplierDiscountMgr()
        {
            return new DbSupplierDiscountManager(this);
        }

        public override SupplierPaymentLineManager CreateSupplierPaymentLineMgr()
        {
            return new DbSupplierPaymentLineManager(this);
        }

        public override SupplierPaymentManager CreateSupplierPaymentMgr()
        {
            return new DbSupplierPaymentManager(this);
        }

        public override CustomerFinanceChargeManager CreateCustomerFinanceChargeMgr()
        {
            return new DbCustomerFinanceChargeManager(this);
        }

        public override CustomerDepositManager CreateCustomerDepositMgr()
        {
            return new DbCustomerDepositManager(this);
        }

        public override CustomerDiscountLineManager CreateCustomerDiscountLineMgr()
        {
            return new DbCustomerDiscountLineManager(this);
        }

        public override CustomerDiscountManager CreateCustomerDiscountMgr()
        {
            return new DbCustomerDiscountManager(this);
        }

        public override CustomerPaymentLineManager CreateCustomerPaymentLineMgr()
        {
            return new DbCustomerPaymentLineManager(this);
        }

        public override CustomerPaymentManager CreateCustomerPaymentMgr()
        {
            return new DbCustomerPaymentManager(this);
        }


        public override MoneySpentLineManager CreateMoneySpentLineMgr()
        {
            return new DbMoneySpentLineManager(this);
        }

        public override MoneyReceivedLineManager CreateMoneyReceivedLineMgr()
        {
            return new DbMoneyReceivedLineManager(this);
        }

        public override MoneyReceivedManager CreateMoneyReceivedMgr()
        {
            return new DbMoneyReceivedManager(this);
        }

        public override PurchasesHistoryManager CreatePurchasesHistoryMgr()
        {
            return new DbPurchasesHistoryManager(this);
        }

        public override SalesHistoryManager CreateSalesHistoryMgr()
        {
            return new DbSalesHistoryManager(this);
        }

        public override CardActivityManager CreateCardActivityMgr()
        {
            return new DbCardActivityManager(this);
        }

        public override PersonalCardManager CreatePersonalCardMgr()
        {
            return new DbPersonalCardManager(this);
        }

        public override MoneySpentManager CreateMoneySpentMgr()
        {
            return new DbMoneySpentManager(this);
        }

        public override DepositStatusManager CreateDepositStatusMgr()
        {
            return new DbDepositStatusManager(this);
        }

        public override JobJournalRecordManager CreateJobJournalRecordMgr()
        {
            return new DbJobJournalRecordManager(this);
        }

        public override JobBudgetManager CreateJobBudgetMgr()
        {
            return new DbJobBudgetManager(this);
        }

        public override JobAccountActivityManager CreateJobAccountActivityMgr()
        {
            return new DbJobAccountActivityManager(this);
        }

        public override JobAccountManager CreateJobAccountMgr()
        {
            return new DbJobAccountManager(this);
        }

        public override ItemLocationManager CreateItemLocationMgr()
        {
            return new DbItemLocationManager(this);
        }

        public override LinkedAccountManager CreateLinkedAccountMgr()
        {
            return new DbLinkedAccountManager(this);
        }

        public override DbDateTimeFieldEntry CreateDateTimeFieldEntry(DateTime? value)
        {
            return new MyobDbDateTimeFieldEntry(value);
        }

        private string GetADONETError(OdbcException ex)
        {
            //string sQuery;
            long lNativeError = 0;

            string sErrorDesc = "";
            if (ex.Errors.Count == 0)
                return sErrorDesc;

            foreach (OdbcError oErr in ex.Errors)
            {
                sErrorDesc = oErr.Message;

                if (sErrorDesc.EndsWith("Transaction rollback"))
                {
                    lNativeError = oErr.NativeError;
                    break;
                }
            }

            DbSelectStatement clause = CreateSelectClause();

            if ((lNativeError >= 10000) && (lNativeError < 20000)) // 'Error
            {
                sErrorDesc = "Error: " + lNativeError.ToString() + " ";
                lNativeError = lNativeError - 10000;
                clause
                    .SelectColumn("ImportErrors", "Description")
                    .From("ImportErrors")
                    .Criteria
                        .IsEqual("ImportErrors", "ImportErrorID", (int)lNativeError);
                //sQuery = "Select Description from ImportErrors where ImportErrorID = " + lNativeError.ToString();
            }
            else if ((lNativeError >= 1) && (lNativeError < 10000)) // 'Warning
            {
                clause
                    .SelectColumn("ImportWarnings", "Description")
                    .From("ImportWarnings")
                    .Criteria
                        .IsEqual("ImportWarnings", "ImportWarningID", (int)lNativeError);
                //sQuery = "Select Description from ImportWarnings where ImportWarningID = " + lNativeError.ToString();
                sErrorDesc = "Warning: " + lNativeError.ToString() + " ";
            }
            else if (lNativeError >= 20000)
            {
                clause
                   .SelectColumn("InternalODBCErrors", "Description")
                   .From("InternalODBCErrors")
                   .Criteria
                       .IsEqual("InternalODBCErrors", "NativeErrorNumber", (int)lNativeError);
                //sQuery = "Select Description from InternalODBCErrors where NativeErrorNumber = " + lNativeError.ToString();
                sErrorDesc = lNativeError.ToString() + " ";
            }
            else
            {
                // return first error in the list
                foreach (OdbcError oErr in ex.Errors)
                {
                    sErrorDesc = oErr.Message;
                    break;
                }
                return sErrorDesc;
            }

            DbDataAdapter adapter = CreateDbDataAdapter(clause);
            DataSet ADORecordset = new DataSet();
            adapter.Fill(ADORecordset, "ImportWarnings");

            foreach (DataRow drow in ADORecordset.Tables["ImportWarnings"].Rows)
            {
                sErrorDesc += drow["Description"];
            }
            return sErrorDesc;
        }

        public override DbDataAdapter CreateDbDataAdapter(string _query)
        {
            return new OdbcDataAdapter(_query, (OdbcConnection)DbConnection);
        }

        public override DbDataAdapter CreateDbDataAdapter(DbSelectStatement _query)
        {
            return new OdbcDataAdapter(_query.ToString(), (OdbcConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbSelectStatement _query)
        {
            return new OdbcCommand(_query.ToString(), (OdbcConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbSelectLastInsertIdStatement _query)
        {
            return new OdbcCommand(_query.ToString(), (OdbcConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbUpdateStatement _query)
        {
            return new OdbcCommand(_query.ToString(), (OdbcConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbInsertStatement _query)
        {
            return new OdbcCommand(_query.ToString(), (OdbcConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbDeleteStatement _query)
        {
            return new OdbcCommand(_query.ToString(), (OdbcConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbGenerateTableStatement _query)
        {
            return new OdbcCommand(_query.ToString(), (OdbcConnection)DbConnection);
        }

        public override DbCommand CreateDbCommand(DbDropTableStatement _query)
        {
            return new OdbcCommand(_query.ToString(), (OdbcConnection)DbConnection);
        }

        protected override DbConnection CreateDbConnection()
        {
            /*
            string sConn = "Driver={" + config.GetParamValue("MYOBDBDRIVER") + "};" +
            "Database=" + config.GetParamValue("MYOBDB") + ";" +
            "TYPE=MYOB;UID=" + config.GetParamValue("username") + ";PWD=" + config.GetParamValue("password") + ";" +
            "KEY=" + config.GetParamValue("key") + ";ACCESS_TYPE=READ_WRITE;" +
            "HOST_EXE_PATH=" + config.GetParamValue("MYOBAPP") + ";" +
            "DRIVER_COMPLETION=DRIVER_PROMPT;SQL_LOGIN_TIMEOUT=30;" +
            "SUPPRESS_WARNINGS=false;";
            */
            DbConnection conn = CreateReadWriteDbConnection();

            ///*
            if (conn == null)
            {
                conn = CreateReadOnlyDbConnection();
                mAllowCreate = false;
            }
            //*/
            return conn;
        }

        private DbConnection CreateReadOnlyDbConnection()
        {
            string sConn = "Driver={" + Driver + "};" +
            "Database=" + Database + ";" +
            "TYPE=MYOB;UID=" + DbUsername + ";PWD=" + DbPassword + ";" +
            "KEY=" + Key + ";ACCESS_TYPE=READ;" +
            "HOST_EXE_PATH=" + HostExePath + ";" +
            "DRIVER_COMPLETION=DRIVER_PROMPT;SQL_LOGIN_TIMEOUT=30;" +
            "SUPPRESS_WARNINGS=false;";

            mDbConnectionError = "";
            try
            {
                OdbcConnection conn = new OdbcConnection(sConn);
                conn.Open();
                return conn;
            }
            catch (OdbcException ex)
            {
                mDbConnectionError = GetADONETError(ex);
                AppEnv.Instance.Log(mDbConnectionError);
                return null;
            }
            catch (Exception ex)
            {
                AppEnv.Instance.Log(ex.Message);
                return null;
            }
        }


        private DbConnection CreateReadWriteDbConnection()
        {
            string sConn = "Driver={" + Driver + "};" +
            "Database=" + Database + ";" +
            "TYPE=MYOB;UID=" + DbUsername + ";PWD=" + DbPassword + ";" +
            "KEY=" + Key + ";ACCESS_TYPE=READ_WRITE;" +
            "HOST_EXE_PATH=" + HostExePath + ";" +
            "DRIVER_COMPLETION=DRIVER_PROMPT;SQL_LOGIN_TIMEOUT=30;" +
            "SUPPRESS_WARNINGS=false;";

            mDbConnectionError = "";
            try
            {
                OdbcConnection conn = new OdbcConnection(sConn);
                conn.Open();
                return conn;
            }
            catch (OdbcException ex)
            {
                mDbConnectionError = GetADONETError(ex);
                AppEnv.Instance.Log(mDbConnectionError);
                return null;
            }
            catch (Exception ex)
            {
                AppEnv.Instance.Log(ex.Message);
                return null;
            }
        }

        public override DataFileInformationManager CreateDataFileInformationMgr()
        {
            return new DbDataFileInformationManager(this);
        }

        public override AccountBudgetManager CreateAccountBudgetMgr()
        {
            return new DbAccountBudgetManager(this);
        }

        public override AccountActivityManager CreateAccountActivityMgr()
        {
            return new DbAccountActivityManager(this);
        }

        public override ContactLogManager CreateContactLogMgr()
        {
            return new DbContactLogManager(this);
        }

        public override PaymentMethodManager CreatePaymentMethodMgr()
        {
            return new DbPaymentMethodManager(this);
        }

        public override JobManager CreateJobMgr()
        {
            return new DbJobManager(this);
        }

        public override ConfigManager CreateConfigMgr()
        {
            return new DbConfigManager(this);
        }

        public override TermsOfPaymentManager CreateTermsOfPaymentMgr()
        {
            return new DbTermsOfPaymentManager(this);
        }

        public override CardTypeManager CreateCardTypeMgr()
        {
            return new DbCardTypeManager(this);
        }

        public override JournalTypeManager CreateJournalTypeMgr()
        {
            return new DbJournalTypeManager(this);
        }

        public override AccountClassificationManager CreateAccountClassificationMgr()
        {
            return new DbAccountClassificationManager(this);
        }

        public override AccountTypeManager CreateAccountTypeMgr()
        {
            return new DbAccountTypeManager(this);
        }

        public override CashFlowClassificationManager CreateCashFlowClassificationMgr()
        {
            return new DbCashFlowClassificationManager(this);
        }

        public override GeneralJournalLineManager CreateGeneralJournalLineMgr()
        {
            return new DbGeneralJournalLineManager(this);
        }

        public override SubAccountTypeManager CreateSubAccountTypeMgr()
        {
            return new DbSubAccountTypeManager(this);
        }

        public override AddressManager CreateAddressMgr()
        {
            return new DbAddressManager(this);
        }

        public override JournalSetManager CreateJournalSetMgr()
        {
            return new DbJournalSetManager(this);
        }

        public override JournalRecordManager CreateJournalRecordMgr()
        {
            return new DbJournalRecordManager(this);
        }

        public override GeneralJournalManager CreateGeneralJournalMgr()
        {
            return new DbGeneralJournalManager(this);
        }

        public override TransferMoneyManager CreateTransferMoneyMgr()
        {
            return new DbTransferMoneyManager(this);
        }

        public override PurchaseLineManager CreatePurchaseLineMgr()
        {
            return new DbPurchaseLineManager(this);
        }

        public override CardManager CreateCardMgr()
        {
            return new DbCardManager(this);
        }

        public override SaleLineManager CreateSaleLineMgr()
        {
            return new DbSaleLineManager(this);
        }

        public override ActivityManager CreateActivityMgr()
        {
            return new DbActivityManager(this);
        }

        public override BillingRateUsedManager CreateBillingRateUsedMgr()
        {
            return new DbBillingRateUsedManager(this);
        }

        public override ItemPurchaseLineManager CreateItemPurchaseLineMgr()
        {
            return new DbItemPurchaseLineManager(this);
        }

        public override ItemSaleLineManager CreateItemSaleLineMgr()
        {
            return new DbItemSaleLineManager(this);
        }

        public override MiscPurchaseLineManager CreateMiscPurchaseLineMgr()
        {
            return new DbMiscPurchaseLineManager(this);
        }

        public override MiscSaleLineManager CreateMiscSaleLineMgr()
        {
            return new DbMiscSaleLineManager(this);
        }

        public override ProfessionalPurchaseLineManager CreateProfessionalPurchaseLineMgr()
        {
            return new DbProfessionalPurchaseLineManager(this);
        }

        public override ProfessionalSaleLineManager CreateProfessionalSaleLineMgr()
        {
            return new DbProfessionalSaleLineManager(this);
        }

        public override ServicePurchaseLineManager CreateServicePurchaseLineMgr()
        {
            return new DbServicePurchaseLineManager(this);
        }

        public override ServiceSaleLineManager CreateServiceSaleLineMgr()
        {
            return new DbServiceSaleLineManager(this);
        }

        public override TimeBillingPurchaseLineManager CreateTimeBillingPurchaseLineMgr()
        {
            return new DbTimeBillingPurchaseLineManager(this);
        }

        public override TimeBillingSaleLineManager CreateTimeBillingSaleLineMgr()
        {
            return new DbTimeBillingSaleLineManager(this);
        }

        public override ShippingMethodManager CreateShippingMethodMgr()
        {
            return new DbShippingMethodManager(this);
        }

        public override ReferralSourceManager CreateReferralSourceMgr()
        {
            return new DbReferralSourceManager(this);
        }

        public override CurrencyManager CreateCurrencyMgr()
        {
            return new DbCurrencyManager(this);
        }

        public override LocationManager CreateLocationMgr()
        {
            return new DbLocationManager(this);
        }

        public override CommentManager CreateCommentMgr()
        {
            return new DbCommentManager(this);
        }
        public override SupplierManager CreateSupplierMgr()
        {
            return new DbSupplierManager(this);
        }
        public override TermsManager CreateTermsMgr()
        {
            return new DbTermsManager(this);
        }
        public override PurchaseManager CreatePurchaseMgr()
        {
            return new DbPurchaseManager(this);
        }
        public override StatusManager CreateStatusMgr()
        {
            return new DbStatusManager(this);
        }
        public override InvoiceDeliveryManager CreateInvoiceDeliveryMgr()
        {
            return new DbInvoiceDeliveryManager(this);
        }
        public override ItemManager CreateItemMgr()
        {
            return new DbItemManager(this);
        }
        public override TaxCodeManager CreateTaxCodeMgr()
        {
            return new DbTaxCodeManager(this);
        }
        public override CustomerManager CreateCustomerMgr()
        {
            return new DbCustomerManager(this);
        }
        public override EmployeeManager CreateEmployeeMgr()
        {
            return new DbEmployeeManager(this);
        }

        public override PriceLevelManager CreatePriceLevelMgr()
        {
            return new DbPriceLevelManager(this);
        }
        public override AccountManager CreateAccountMgr()
        {
            return new DbAccountManager(this);
        }
        public override InvoiceTypeManager CreateInvoiceTypeMgr()
        {
            return new DbInvoiceTypeManager(this);
        }
        public override SaleManager CreateSaleMgr()
        {
            return new DbSaleManager(this);
        }
        public override AuthItemManager CreateAuthItemMgr()
        {
            return new DbAuthItemManager(this);
        }
        public override AuthRoleManager CreateAuthRoleMgr()
        {
            return new DbAuthRoleManager(this);
        }

        public override AuthUserManager CreateAuthUserMgr()
        {
            return new DbAuthUserManager(this);
        }
        
    }
}
