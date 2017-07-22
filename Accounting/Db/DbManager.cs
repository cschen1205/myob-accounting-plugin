using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core;
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
using Accounting.Core.Activities;
using Accounting.Core.Transactions;
using Accounting.Core.Security;
using Accounting.Core.Payroll;
using Accounting.Core.CostCentres;
using Accounting.Util;
using Accounting.Db.Elements;
using System.Data.Common;
using System.Data;

namespace Accounting.Db
{
    public abstract class DbManager
    {
        private Elements.SqlFieldAlias mDbFieldFormat = new Elements.SqlFieldAlias();
        private DbConnection mDbConnection = null;
        private RepositoryManager mRepositoryMgr = null;

        private string mName;
        public string Name { get { return mName; } }

        public RepositoryManager RepositoryMgr
        {
            get { return mRepositoryMgr; }
        }

        public virtual int GetLastInsertID()
        {
            return ExecuteScalarInt(CreateSelectLastInsertIdClause());
        }

        protected bool mAllowUpdate = true;
        public virtual bool AllowUpdate
        {
            get { return mAllowUpdate; }
        }

        protected bool mAllowCreate = true;
        public virtual bool AllowCreate
        {
            get { return mAllowCreate; }
        }

        protected bool mAllowDelete = true;
        public virtual bool AllowDelete
        {
            get { return mAllowDelete; }
        }

        public virtual void Release()
        {
            if (mDbConnection != null)
            {
                try
                {
                    mDbConnection.Close();
                    mDbConnection = null;
                }
                catch (Exception ex)
                {
                    Log(ex.Message);
                }
            }
        }

        #region -(Logging)
        public void Log(string message)
        {
            AppEnv.Instance.Log(message);
        }

        public void LogWithExit(string message)
        {
            AppEnv.Instance.LogWithExit(message);
        }
        #endregion

        public DbManager(RepositoryManager mgr, string name)
        {
            mName = name;
            mRepositoryMgr = mgr;
        }

        #region Configurations
        private string mDatabase;
        public string Database
        {
            get
            {
                return mDatabase;
                //return RepositoryMgr.ConfigMgr.GetParamValue(Name+"database");
            }
            set
            {
                mDatabase = value;
                //RepositoryMgr.ConfigMgr.SetParam(Name+"database", value);
            }
        }


        private string mDbUsername;
        public string DbUsername
        {
            get
            {
                return mDbUsername;
                //return RepositoryMgr.ConfigMgr.GetParamValue(Name+"dbusername");
            }
            set
            {
                mDbUsername = value;
                //RepositoryMgr.ConfigMgr.SetParam(Name+"dbusername", value);
            }
        }

        private string mDbPassword;
        public string DbPassword
        {
            get
            {
                return mDbPassword;
                //return RepositoryMgr.ConfigMgr.GetParamValue(Name+"dbpassword");
            }
            set
            {
                mDbPassword = value;
                //RepositoryMgr.ConfigMgr.SetParam(Name+"dbpassword", value);
            }
        }

        private string mPort;
        public string Port
        {
            get
            {
                return mPort;
                //return RepositoryMgr.ConfigMgr.GetParamValue(Name+"port");
            }
            set
            {
                mPort = value;
                //RepositoryMgr.ConfigMgr.SetParam(Name+"port", value);
            }
        }

       
        #endregion

        #region -(Field Alias)
        public virtual string FieldAlias(string alias)
        {
            return mDbFieldFormat[alias];
        }

        public void RegisterFieldNameAlias(string fieldname, string alias)
        {
            mDbFieldFormat[alias] = fieldname;
        }
        #endregion

        #region -(Element Factory Methods)
        public virtual DbDateTimeFieldEntry CreateDateTimeFieldEntry(Nullable<DateTime> value)
        {
            DbDateTimeFieldEntry fieldvalue = new DbDateTimeFieldEntry(value);
            fieldvalue.DbMgr = this;
            return fieldvalue;
        }

        public virtual DbStringFieldEntry CreateStringFieldEntry(string value)
        {
            DbStringFieldEntry fieldvalue = new DbStringFieldEntry(value);
            fieldvalue.DbMgr = this;
            return fieldvalue;
        }

        public virtual DbStringFieldEntry CreatePrimaryKeyStringFieldEntry(string value)
        {
            DbStringFieldEntry fieldvalue = CreateStringFieldEntry(value);
            fieldvalue.SkipOnUpdate = true;
            return fieldvalue;
        }

        public virtual DbIntFieldEntry CreateIntFieldEntry(int? value)
        {
            DbIntFieldEntry fieldvalue = new DbIntFieldEntry(value);
            fieldvalue.DbMgr = this;
            return fieldvalue;
        }

        public virtual DbDoubleFieldEntry CreateDoubleFieldEntry(double value)
        {
            DbDoubleFieldEntry fieldvalue = new DbDoubleFieldEntry(value);
            fieldvalue.DbMgr = this;
            return fieldvalue;
        }

        public virtual DbAutoIntFieldEntry CreateAutoIntFieldEntry(int? value)
        {
            DbAutoIntFieldEntry fieldvalue = new DbAutoIntFieldEntry(value);
            fieldvalue.DbMgr = this;
            return fieldvalue;
        }

        #endregion

        #region -(SqlStatement Factory Methods)
        public virtual DbSelectStatement CreateSelectClause()
        {
            DbSelectStatement clause=new DbSelectStatement(this);
            return clause;
        }

        public virtual DbInsertStatement CreateInsertClause()
        {
            DbInsertStatement clause = new DbInsertStatement(this);
            return clause;
        }

        public virtual DbInsertStatement CreateInsertClause(string table, Dictionary<string, DbFieldEntry> fields)
        {
            DbInsertStatement clause = CreateInsertClause();
            clause
                .InsertColumns(fields)
                .Into(table);
            return clause;
        }

        public virtual DbUpdateStatement CreateUpdateClause(string table, Dictionary<string, DbFieldEntry> fields, string fieldname, int? fieldvalue)
        {
            if (fieldvalue == null)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string key in fields.Keys)
                {
                    sb.AppendFormat("\r\n{0}: {1}", key, fields[key]);
                }
                throw new NullReferenceException(string.Format("{0} cannot be null before update:\r\n{1}", fieldname, sb.ToString()));
            }
            DbUpdateStatement clause = CreateUpdateClause();
            clause
                .UpdateColumns(fields)
                .From(table)
                .Criteria
                    .IsEqual(table, fieldname, fieldvalue);
            return clause;
        }

        public virtual DbUpdateStatement CreateUpdateClause(string table, Dictionary<string, DbFieldEntry> fields, string fieldname, string fieldvalue)
        {
            DbUpdateStatement clause = CreateUpdateClause();
            clause
                .UpdateColumns(fields)
                .From(table)
                .Criteria
                    .IsEqual(table, fieldname, fieldvalue);
            return clause;
        }

        public virtual DbUpdateStatement CreateUpdateClause()
        {
            DbUpdateStatement clause = new DbUpdateStatement(this);
            return clause;
        }

        public virtual DbDeleteStatement CreateDeleteClause()
        {
            DbDeleteStatement clause = new DbDeleteStatement(this);
            return clause;
        }

        public virtual DbExpression CreateExpression(DbColumn column, DbFieldEntry fieldvalue, DbExpression.SqlCondition condition)
        {
            DbExpression expression = new DbExpression(column, fieldvalue, condition);
            expression.DbMgr = this;
            return expression;
        }

        public virtual DbExpression CreateExpression(DbColumn column, DbSelectStatement select_clause, DbExpression.SqlCondition condition)
        {
            DbExpression expression = new DbExpression(column, select_clause, condition);
            expression.DbMgr = this;
            return expression;
        }


        public virtual DbCriteria CreateCriteria()
        {
            DbCriteria criteria=new DbCriteria();
            criteria.DbMgr = this;
            return criteria;
        }

        public virtual DbSelectLastInsertIdStatement CreateSelectLastInsertIdClause()
        {
            DbSelectLastInsertIdStatement clause = new DbSelectLastInsertIdStatement(this);
            return clause;
        }

        public virtual DbColumn CreateColumn(params string[] values)
        {
            DbColumn column=new DbColumn(values);
            column.DbMgr = this;
            return column;
        }

        public virtual DbCurrencyColumn CreateCurrencyColumn(params string[] values)
        {
            DbCurrencyColumn column = new DbCurrencyColumn(values);
            column.DbMgr = this;
            return column;
        }

        public virtual DbJoin CreateJoin(params string[] values)
        {
            DbJoin join = new DbJoin();
            join.Column1 = CreateColumn(values[0], values[1]);
            join.Column2 = CreateColumn(values[2], values[3]);
            join.DbMgr = this;
            return join;
        }

        public virtual DbOrderBy CreateOrderBy(params string[] values)
        {
            DbOrderBy order = new DbOrderBy();
            order.DbMgr = this;
            order.Column = CreateColumn(values[0], values[1]);
            if (values.Length == 2 || values[2] == "ASC")
            {
                order.Order = DbOrderBy.OrderMode.ASC;
            }
            else
            {
                order.Order = DbOrderBy.OrderMode.DESC;
            }
            return order;
        }

        public virtual DbGenerateTableStatement CreateGenerateTableClause()
        {
            DbGenerateTableStatement statement = new DbGenerateTableStatement();
            statement.DbMgr = this;
            return statement;
        }

        public virtual DbDropTableStatement CreateDropTable()
        {
            DbDropTableStatement statement = new DbDropTableStatement();
            statement.DbMgr = this;
            return statement;
        }

        public virtual DbSelectTableCountStatement CreateSelectTableCountClause()
        {
            DbSelectTableCountStatement statement=new DbSelectTableCountStatement(this);
            statement.DbMgr = this;
            return statement;
        }
        #endregion

        public abstract DataFieldManager CreateDataFieldMgr();
        public abstract ItemDataFieldEntryManager CreateItemDataFieldEntryMgr();
        public abstract MiscNumberManager CreateMiscNumberMgr();
        public abstract ItemSizeManager CreateItemSizeMgr();
        public abstract GenderManager CreateGenderMgr();
        public abstract ItemAddOnManager CreateItemAddOnMgr();
        public abstract WageDollarHistoryManager CreateWageDollarHistoryMgr();
        public abstract WageHourHistoryManager CreateWageHourHistoryMgr();
        public abstract LinkedCategoryManager CreateLinkedCategoryMgr();
        public abstract LinkedEmployeeManager CreateLinkedEmployeeMgr();
        public abstract PayrollInformationManager CreatePayrollInformationMgr();
        public abstract BASInformationManager CreateBASInformationMgr();
        public abstract PaySuperannuationLineManager CreatePaySuperannuationLineMgr();
        public abstract PaySuperannuationManager CreatePaySuperannuationMgr();
        public abstract SuperannuationFundManager CreateSuperannuationFundMgr();
        public abstract PayLiabilityLineManager CreatePayLiabilityLineMgr();
        public abstract CostCentreJournalRecordManager CreateCostCentreJournalRecordMgr();
        public abstract CostCentreAccountActivityManager CreateCostCentreAccountActivityMgr();
        public abstract CostCentreAccountManager CreateCostCentreAccountMgr();
        public abstract CostCentreManager CreateCostCentreMgr();
        public abstract PayLiabilityManager CreatePayLiabilityMgr();
        public abstract WritePaychequeLineManager CreateWritePaychequeLineMgr();
        public abstract PayBasisManager CreatePayBasisMgr();
        public abstract CategoryTypeManager CreateCategoryTypeMgr();
        public abstract WritePaychequeManager CreateWritePaychequeMgr();
        public abstract BankingDetailManager CreateBankingDetailMgr();
        public abstract PaymentTypeManager CreatePaymentTypeMgr();
        public abstract BankDepositLineManager CreateBankDepositLineMgr();
        public abstract BankDepositManager CreateBankDepositMgr();
        public abstract RecurringGeneralJournalLineManager CreateRecurringGeneralJournalLineMgr();
        public abstract RecurringGeneralJournalManager CreateRecurringGeneralJournalMgr();
        public abstract RecurringTransferMoneyManager CreateRecurringTransferMoneyMgr();
        public abstract RecurringMoneyReceivedLineManager CreateRecurringMoneyReceivedLineMgr();
        public abstract RecurringMoneyReceivedManager CreateRecurringMoneyReceivedMgr();
        public abstract RecurringMoneySpentLineManager CreateRecurringMoneySpentLineMgr();
        public abstract RecurringMoneySpentManager CreateRecurringMoneySpentMgr();
        public abstract NumberingTypeManager CreateNumberingTypeMgr();
        public abstract FrequencyManager CreateFrequencyMgr();
        public abstract EmployerExpenseTypeManager CreateEmployerExpenseTypeMgr();
        public abstract ContributionTypeManager CreateContributionTypeMgr();
        public abstract CalculationMethodManager CreateCalculationMethodMgr();
        public abstract TerminationMethodManager CreateTerminationMethodMgr();
        public abstract DayNameManager CreateDayNameMgr();
        public abstract EmploymentStatusManager CreateEmploymentStatusMgr();
        public abstract EmploymentClassificationManager CreateEmploymentClassificationMgr();
        public abstract EmploymentBasisManager CreateEmploymentBasisMgr();
        public abstract AccountingBasisManager CreateAccountingBasisMgr();
        public abstract ImportantDatesManager CreateImportantDatesMgr();
        public abstract AuditTrailManager CreateAuditTrailMgr();
        public abstract ElectronicPaymentLineManager CreateElectronicPaymentLineMgr();
        public abstract ElectronicPaymentManager CreateElectronicPaymentMgr();
        public abstract ActivitySlipInvoicedManager CreateActivitySlipInvoicedMgr();
        public abstract ActivitySlipManager CreateActivitySlipMgr();
        public abstract WageManager CreateWageMgr();
        public abstract ActivitySalesHistoryManager CreateActivitySalesHistoryMgr();
        public abstract NegativeInventoryManager CreateNegativeInventoryMgr();
        public abstract BuildComponentManager CreateBuildComponentMgr();
        public abstract BuiltItemManager CreateBuiltItemMgr();
        public abstract ItemPurchasesHistoryManager CreateItemPurchasesHistoryMgr();
        public abstract ItemSalesHistoryManager CreateItemSalesHistoryMgr();
        public abstract ItemOpeningBalanceManager CreateItemOpeningBalanceMgr();
        public abstract ItemMovementManager CreateItemMovementMgr();
        public abstract ItemPriceManager CreateItemPriceMgr();
        public abstract MoveItemManager CreateMoveItemMgr();
        public abstract RoundingManager CreateRoundingMgr();
        public abstract TaxInformationConsolidationManager CreateTaxInformationConsolidationMgr();
        public abstract TaxInformationManager CreateTaxInformationMgr();
        public abstract TaxCodeConsolidationManager CreateTaxCodeConsolidationMgr();
        public abstract EmploymentCategoryManager CreateEmploymentCategoryMgr();
        public abstract ScheduleManager CreateScheduleMgr();
        public abstract PaymentValueTypeManager CreatePaymentValueTypeMgr();
        public abstract TaxScaleManager CreateTaxScaleMgr();
        public abstract AlertTypeManager CreateAlertTypeMgr();
        public abstract AlertManager CreateAlertMgr();
        public abstract LimitTypeManager CreateLimitTypeMgr();
        public abstract ReportingMethodManager CreateReportingMethodMgr();
        public abstract ReconciliationStatusManager CreateReconciliationStatusMgr();
        public abstract SalespersonHistoryManager CreateSalespersonHistoryMgr();
        public abstract InventoryTransferLineManager CreateInventoryTransferLineMgr();
        public abstract InventoryTransferManager CreateInventoryTransferMgr();
        public abstract InventoryAdjustmentLineManager CreateInventoryAdjustmentLineMgr();
        public abstract InventoryAdjustmentManager CreateInventoryAdjustmentMgr();
        public abstract DebitRefundManager CreateDebitRefundMgr();
        public abstract SettledDebitManager CreateSettledDebitMgr();
        public abstract CreditRefundManager CreateCreditRefundMgr();
        public abstract SettledCreditLineManager CreateSettledCreditLineMgr();
        public abstract SettledCreditManager CreateSettledCreditMgr();
        public abstract SupplierFinanceChargeManager CreateSupplierFinanceChargeMgr();
        public abstract SupplierDepositManager CreateSupplierDepositMgr();
        public abstract SupplierDiscountLineManager CreateSupplierDiscountLineMgr();
        public abstract SupplierDiscountManager CreateSupplierDiscountMgr();
        public abstract SupplierPaymentLineManager CreateSupplierPaymentLineMgr();
        public abstract SupplierPaymentManager CreateSupplierPaymentMgr();
        public abstract CustomerFinanceChargeManager CreateCustomerFinanceChargeMgr();
        public abstract CustomerDepositManager CreateCustomerDepositMgr();
        public abstract CustomerDiscountLineManager CreateCustomerDiscountLineMgr();
        public abstract CustomerDiscountManager CreateCustomerDiscountMgr();
        public abstract CustomerPaymentLineManager CreateCustomerPaymentLineMgr();
        public abstract CustomerPaymentManager CreateCustomerPaymentMgr();
        public abstract MoneyReceivedManager CreateMoneyReceivedMgr();
        public abstract MoneyReceivedLineManager CreateMoneyReceivedLineMgr();
        public abstract MoneySpentLineManager CreateMoneySpentLineMgr();
        public abstract PurchasesHistoryManager CreatePurchasesHistoryMgr();
        public abstract SalesHistoryManager CreateSalesHistoryMgr();
        public abstract CardActivityManager CreateCardActivityMgr();
        public abstract PersonalCardManager CreatePersonalCardMgr();
        public abstract DepositStatusManager CreateDepositStatusMgr();
        public abstract MoneySpentManager CreateMoneySpentMgr();
        public abstract JobJournalRecordManager CreateJobJournalRecordMgr();
        public abstract JobBudgetManager CreateJobBudgetMgr();
        public abstract JobAccountActivityManager CreateJobAccountActivityMgr();
        public abstract JobAccountManager CreateJobAccountMgr();
        public abstract ItemLocationManager CreateItemLocationMgr();
        public abstract LinkedAccountManager CreateLinkedAccountMgr();
        public abstract DataFileInformationManager CreateDataFileInformationMgr();
        public abstract AccountBudgetManager CreateAccountBudgetMgr();
        public abstract AccountActivityManager CreateAccountActivityMgr();
        public abstract ContactLogManager CreateContactLogMgr();
        public abstract PaymentMethodManager CreatePaymentMethodMgr();
        public abstract JournalSetManager CreateJournalSetMgr();
        public abstract JournalRecordManager CreateJournalRecordMgr();
        public abstract GeneralJournalManager CreateGeneralJournalMgr();
        public abstract JobManager CreateJobMgr();
        public abstract ReferralSourceManager CreateReferralSourceMgr();
        public abstract TransferMoneyManager CreateTransferMoneyMgr();
        public abstract ActivityManager CreateActivityMgr();
        public abstract BillingRateUsedManager CreateBillingRateUsedMgr();
        public abstract CardManager CreateCardMgr();
        public abstract ConfigManager CreateConfigMgr();
        public abstract SaleManager CreateSaleMgr();
        public abstract SaleLineManager CreateSaleLineMgr();
        public abstract MiscSaleLineManager CreateMiscSaleLineMgr();
        public abstract ProfessionalSaleLineManager CreateProfessionalSaleLineMgr();
        public abstract ServiceSaleLineManager CreateServiceSaleLineMgr();
        public abstract TimeBillingSaleLineManager CreateTimeBillingSaleLineMgr();
        public abstract ItemSaleLineManager CreateItemSaleLineMgr();
        public abstract RecurringSaleManager CreateRecurringSaleMgr();
        public abstract RecurringSaleLineManager CreateRecurringSaleLineMgr();
        public abstract RecurringMiscSaleLineManager CreateRecurringMiscSaleLineMgr();
        public abstract RecurringProfessionalSaleLineManager CreateRecurringProfessionalSaleLineMgr();
        public abstract RecurringServiceSaleLineManager CreateRecurringServiceSaleLineMgr();
        public abstract RecurringTimeBillingSaleLineManager CreateRecurringTimeBillingSaleLineMgr();
        public abstract RecurringItemSaleLineManager CreateRecurringItemSaleLineMgr();
        public abstract PurchaseManager CreatePurchaseMgr();
        public abstract PurchaseLineManager CreatePurchaseLineMgr();
        public abstract ItemPurchaseLineManager CreateItemPurchaseLineMgr();
        public abstract MiscPurchaseLineManager CreateMiscPurchaseLineMgr();
        public abstract ProfessionalPurchaseLineManager CreateProfessionalPurchaseLineMgr();
        public abstract ServicePurchaseLineManager CreateServicePurchaseLineMgr();
        public abstract TimeBillingPurchaseLineManager CreateTimeBillingPurchaseLineMgr();
        public abstract RecurringPurchaseManager CreateRecurringPurchaseMgr();
        public abstract RecurringPurchaseLineManager CreateRecurringPurchaseLineMgr();
        public abstract RecurringMiscPurchaseLineManager CreateRecurringMiscPurchaseLineMgr();
        public abstract RecurringProfessionalPurchaseLineManager CreateRecurringProfessionalPurchaseLineMgr();
        public abstract RecurringServicePurchaseLineManager CreateRecurringServicePurchaseLineMgr();
        public abstract RecurringTimeBillingPurchaseLineManager CreateRecurringTimeBillingPurchaseLineMgr();
        public abstract RecurringItemPurchaseLineManager CreateRecurringItemPurchaseLineMgr();
        public abstract TermsOfPaymentManager CreateTermsOfPaymentMgr();
        public abstract ShippingMethodManager CreateShippingMethodMgr();
        public abstract CurrencyManager CreateCurrencyMgr();
        public abstract JournalTypeManager CreateJournalTypeMgr();
        public abstract LocationManager CreateLocationMgr();
        public abstract CommentManager CreateCommentMgr();
        public abstract CustomListManager CreateCustomListMgr();
        public abstract SupplierManager CreateSupplierMgr();
        public abstract TermsManager CreateTermsMgr();
        public abstract StatusManager CreateStatusMgr();
        public abstract InvoiceDeliveryManager CreateInvoiceDeliveryMgr();
        public abstract ItemManager CreateItemMgr();
        public abstract AuthRoleManager CreateAuthRoleMgr();
        public abstract AuthUserManager CreateAuthUserMgr();
        public abstract AuthItemManager CreateAuthItemMgr();
        public abstract TaxCodeManager CreateTaxCodeMgr();
        public abstract CustomerManager CreateCustomerMgr();
        public abstract AccountTypeManager CreateAccountTypeMgr();
        public abstract SubAccountTypeManager CreateSubAccountTypeMgr();
        public abstract AccountClassificationManager CreateAccountClassificationMgr();
        public abstract CashFlowClassificationManager CreateCashFlowClassificationMgr();
        public abstract GeneralJournalLineManager CreateGeneralJournalLineMgr();
        public abstract EmployeeManager CreateEmployeeMgr();
        public abstract PriceLevelManager CreatePriceLevelMgr();
        public abstract AccountManager CreateAccountMgr();
        public abstract InvoiceTypeManager CreateInvoiceTypeMgr();
        public abstract AddressManager CreateAddressMgr();
        public abstract CardTypeManager CreateCardTypeMgr();
        public abstract SettledDebitLineManager CreateSettledDebitLineMgr();

        public abstract DbCommand CreateDbCommand(DbSelectStatement clause);
        public abstract DbCommand CreateDbCommand(DbDeleteStatement clause);
        public abstract DbCommand CreateDbCommand(DbInsertStatement clause);
        public abstract DbCommand CreateDbCommand(DbUpdateStatement clause);
        public abstract DbCommand CreateDbCommand(DbDropTableStatement clause);
        public abstract DbCommand CreateDbCommand(DbGenerateTableStatement clause);
        public abstract DbCommand CreateDbCommand(DbSelectLastInsertIdStatement clause);

        public abstract DbDataAdapter CreateDbDataAdapter(DbSelectStatement clause);
        public abstract DbDataAdapter CreateDbDataAdapter(string query);

        protected abstract DbConnection CreateDbConnection();

        public DbTableCommand CreateTableCommand(string tablename, Dictionary<string, FIELDTYPE> fields, string primaryKey, Dictionary<string, string> foreignKeys)
        {
            return new DbTableCommand(this, tablename, fields, primaryKey, foreignKeys);
        }

        private string mDriver;
        public string Driver
        {
            set
            {
                mDriver=value;
                //RepositoryMgr.ConfigMgr.SetParam("driver", value);
            }
            get
            {
                return mDriver;
                //return RepositoryMgr.ConfigMgr.GetParamValue("driver");
            }
        }

        private string mKey;
        public string Key
        {
            get
            {
                return mKey;
                //return RepositoryMgr.ConfigMgr.GetParamValue("key");
            }
            set
            {
                mKey = value;
                //RepositoryMgr.ConfigMgr.SetParam("key", value);
            }
        }

        private string mHostExePath;
        public string HostExePath
        {
            get
            {
                return mHostExePath;
                //return RepositoryMgr.ConfigMgr.GetParamValue(Name+"host_exe_path");
            }
            set
            {
                mHostExePath = value;
                //RepositoryMgr.ConfigMgr.SetParam(Name+"host_exe_path", value);
            }
        }

        protected string mDbConnectionError = "";
        public string DbConnectionError { get { return mDbConnectionError; } }

        public DbConnection DbConnection
        {
            get
            {
                if (mDbConnection == null)
                {
                    mDbConnection = CreateDbConnection();
                }
                return mDbConnection;
            }
        }

        public enum FIELDTYPE
        {
            INTEGER_INDEXED,
            VARCHAR_1,
            VARCHAR_2,
            VARCHAR_3,
            VARCHAR_4,
            VARCHAR_5,
            VARCHAR_6,
            VARCHAR_7,
            VARCHAR_8,
            VARCHAR_9,
            VARCHAR_10,
            VARCHAR_11,
            VARCHAR_12,
            VARCHAR_13,
            VARCHAR_14,
            VARCHAR_15,
            VARCHAR_16,
            VARCHAR_17,
            VARCHAR_18,
            VARCHAR_19,
            VARCHAR_20,
            VARCHAR_21,
            VARCHAR_22,
            VARCHAR_23,
            VARCHAR_24,
            VARCHAR_25,
            VARCHAR_26,
            VARCHAR_30,
            VARCHAR_31,
            VARCHAR_32,
            VARCHAR_34,
            VARCHAR_35,
            VARCHAR_40,
            VARCHAR_50,
            VARCHAR_52,
            VARCHAR_56,
            VARCHAR_65,
            VARCHAR_76,
            VARCHAR_255,
            VARCHAR_256,
            DATETIME,
            INTEGER,
            DOUBLE
        };

        public FIELDTYPE this[FIELDTYPE index]
        {
            get
            {
                return index;
            }
        }

        public virtual string TranslateFieldType(FIELDTYPE index)
        {
                switch (index)
                {
                    case FIELDTYPE.INTEGER_INDEXED:
                        return "AUTOINCREMENT"; //"INTEGER  NOT NULL";
                    case FIELDTYPE.VARCHAR_1:
                        return "VARCHAR(1)";
                    case FIELDTYPE.VARCHAR_2:
                        return "VARCHAR(2)";
                    case FIELDTYPE.VARCHAR_3:
                        return "VARCHAR(3)";
                    case FIELDTYPE.VARCHAR_4:
                        return "VARCHAR(4)";
                    case FIELDTYPE.VARCHAR_5:
                        return "VARCHAR(5)";
                    case FIELDTYPE.VARCHAR_6:
                        return "VARCHAR(6)";
                    case FIELDTYPE.VARCHAR_7:
                        return "VARCHAR(7)";
                    case FIELDTYPE.VARCHAR_8:
                        return "VARCHAR(8)";
                    case FIELDTYPE.VARCHAR_9:
                        return "VARCHAR(9)";
                    case FIELDTYPE.VARCHAR_10:
                        return "VARCHAR(10)";
                    case FIELDTYPE.VARCHAR_11:
                        return "VARCHAR(11)";
                    case FIELDTYPE.VARCHAR_12:
                        return "VARCHAR(12)";
                    case FIELDTYPE.VARCHAR_13:
                        return "VARCHAR(13)";
                    case FIELDTYPE.VARCHAR_14:
                        return "VARCHAR(14)";
                    case FIELDTYPE.VARCHAR_15:
                        return "VARCHAR(15)";
                    case FIELDTYPE.VARCHAR_16:
                        return "VARCHAR(16)";
                    case FIELDTYPE.VARCHAR_17:
                        return "VARCHAR(17)";
                    case FIELDTYPE.VARCHAR_18:
                        return "VARCHAR(18)";
                    case FIELDTYPE.VARCHAR_19:
                        return "VARCHAR(19)";
                    case FIELDTYPE.VARCHAR_20:
                        return "VARCHAR(20)";
                    case FIELDTYPE.VARCHAR_21:
                        return "VARCHAR(21)";
                    case FIELDTYPE.VARCHAR_22:
                        return "VARCHAR(22)";
                    case FIELDTYPE.VARCHAR_23:
                        return "VARCHAR(23)";
                    case FIELDTYPE.VARCHAR_24:
                        return "VARCHAR(24)";
                    case FIELDTYPE.VARCHAR_25:
                        return "VARCHAR(25)";
                    case FIELDTYPE.VARCHAR_26:
                        return "VARCHAR(26)";
                    case FIELDTYPE.VARCHAR_30:
                        return "VARCHAR(30)";
                    case FIELDTYPE.VARCHAR_31:
                        return "VARCHAR(31)";
                    case FIELDTYPE.VARCHAR_32:
                        return "VARCHAR(32)";
                    case FIELDTYPE.VARCHAR_34:
                        return "VARCHAR(34)";
                    case FIELDTYPE.VARCHAR_35:
                        return "VARCHAR(35)";
                    case FIELDTYPE.VARCHAR_40:
                        return "VARCHAR(40)";
                    case FIELDTYPE.VARCHAR_50:
                        return "VARCHAR(50)";
                    case FIELDTYPE.VARCHAR_52:
                        return "VARCHAR(52)";
                    case FIELDTYPE.VARCHAR_56:
                        return "VARCHAR(56)";
                    case FIELDTYPE.VARCHAR_65:
                        return "VARCHAR(65)";
                    case FIELDTYPE.VARCHAR_76:
                        return "VARCHAR(76)";
                    case FIELDTYPE.VARCHAR_255:
                        return "VARCHAR(255)";
                    case FIELDTYPE.VARCHAR_256:
                        return "TEXT";
                    case FIELDTYPE.DATETIME:
                        return "DATETIME";
                    case FIELDTYPE.INTEGER:
                        return "INTEGER";
                    case FIELDTYPE.DOUBLE:
                        return "DOUBLE";
                    default:
                        return "VARCHAR(255)";
            }
        }

        public virtual bool TableExists(string selected_tablename)
        {
            string _selected_tablename = FieldAlias(selected_tablename);
            string tablename;
            try
            {
                string[] restrictionValues = new string[4] { null, null, null, "TABLE" };
                DataTable schemaInformation = DbConnection.GetSchema("Tables", restrictionValues);

                foreach (DataRow row in schemaInformation.Rows)
                {
                    tablename = row.ItemArray[2].ToString();
                    if (tablename.Equals(_selected_tablename))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {

            }
            return false;
        }

        public virtual int? GetInt16(DbDataReader reader, params string[] columnNames)
        {
            int ordinal;
            if (GetOrdinal(reader, columnNames, out ordinal))
            {
                if (!reader.IsDBNull(ordinal))
                {
                    try
                    {
                        return reader.GetInt16(ordinal);
                    }
                    catch (InvalidCastException)
                    {
                        return Convert.ToInt32(reader.GetValue(ordinal));
                    }
                }
            }
            return null;
        }

        public virtual int? GetInt32(DbDataReader reader, params string[] columnNames)
        {
            int ordinal;

            if (GetOrdinal(reader, columnNames, out ordinal))
            {
                if (!reader.IsDBNull(ordinal))
                {
                    try
                    {
                        return reader.GetInt32(ordinal);
                    }
                    catch (InvalidCastException)
                    {
                        return Convert.ToInt32(reader.GetValue(ordinal));
                    }
                }
            }

            return null;
        }

        public virtual string GetString(DbDataReader reader, params string[] columnNames)
        {
            int ordinal;
            if (GetOrdinal(reader, columnNames, out ordinal))
            {
                if (!reader.IsDBNull(ordinal))
                {
                    return reader.GetString(ordinal);
                }
            }
            return "";
        }

        public virtual double GetDouble(DbDataReader reader, params string[] columnNames)
        {
            int ordinal;
            if (GetOrdinal(reader, columnNames, out ordinal))
            {
                if (!reader.IsDBNull(ordinal))
                {
                    return reader.GetDouble(ordinal);
                }
            }
            return 0;
        }

        public virtual Nullable<DateTime> GetDateTime(DbDataReader reader, params string[] columnNames)
        {
            int ordinal;
            if (GetOrdinal(reader, columnNames, out ordinal))
            {
                try
                {
                    if (!reader.IsDBNull(ordinal))
                    {
                        return reader.GetDateTime(ordinal);
                    }
                }
                catch
                {

                }
            }
            return null;
        }

        public virtual bool GetOrdinal(DbDataReader reader, string[] columnNames, out int ordinal)
        {
            ordinal = -1;

            foreach (string _columnName in columnNames)
            {
                string columnName = FieldAlias(_columnName);
                if (ColumnExists(reader, columnName))
                {
                    ordinal = reader.GetOrdinal(columnName);
                    return true;
                }
            }
            return false;
        }
        

        public virtual bool ColumnExists(DbDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName))
                {
                    return true;
                }
            }

            return false;
        }

      
        public object ExecuteScalar(DbSelectStatement clause)
        {
            DbCommand _cmd = CreateDbCommand(clause);
            //try
            //{
                object _obj = _cmd.ExecuteScalar();
            //}
            //catch (Exception e)
            //{
            //    //clause.ToString()
            //}
            _cmd.Dispose();

            return _obj;
        }

        public object ExecuteScalar(DbSelectLastInsertIdStatement clause)
        {
            DbCommand _cmd = CreateDbCommand(clause);
            object _obj = _cmd.ExecuteScalar();
            _cmd.Dispose();

            return _obj;
        }

        public int ExecuteNonQuery(DbUpdateStatement clause)
        {
            int result = 0;
            DbCommand _cmd = CreateDbCommand(clause);
            result = _cmd.ExecuteNonQuery();
            _cmd.Dispose();

            return result;
        }

        public virtual int ExecuteNonQuery(DbGenerateTableStatement clause)
        {
            int result = 0;
            DbCommand _cmd = CreateDbCommand(clause);
            result = _cmd.ExecuteNonQuery();
            _cmd.Dispose();

            return result;
        }

        public virtual int ExecuteNonQuery(DbDropTableStatement clause)
        {
            int result = 0;
            DbCommand _cmd = CreateDbCommand(clause);
            result = _cmd.ExecuteNonQuery();
            _cmd.Dispose();

            return result;
        }

        public virtual int ExecuteNonQuery(DbInsertStatement clause)
        {
            int result = 0;
            DbCommand _cmd = CreateDbCommand(clause);
            result = _cmd.ExecuteNonQuery();
            _cmd.Dispose();

            return result;
        }

        public int ExecuteNonQuery(DbDeleteStatement clause)
        {
            int result = 0;
            DbCommand _cmd = CreateDbCommand(clause);
            result = _cmd.ExecuteNonQuery();
            _cmd.Dispose();

            return result;
        }

        public int ExecuteScalarInt(DbSelectStatement clause)
        {
            return Convert.ToInt32(ExecuteScalar(clause));
        }

        public int ExecuteScalarInt(DbSelectLastInsertIdStatement clause)
        {
            return Convert.ToInt32(ExecuteScalar(clause));
        }

    }
}
