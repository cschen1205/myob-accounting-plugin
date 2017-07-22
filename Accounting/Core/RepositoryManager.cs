using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core
{
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
    using Accounting.Db;

    public abstract class RepositoryManager
    {
        private Dictionary<string, DbManager> mMgrFactories = new Dictionary<string, DbManager>();
        private List<IRepository> mRepositories = new List<IRepository>();

        public DbManager DefaultMgrFactory { get; set; }
        protected IList<IRepository> Repositories { get { return mRepositories; } }

        public delegate void DataStoreInvalidatedHandler();
        public event DataStoreInvalidatedHandler DataStoreInvalidated;

        private void OnDataStoreInvalidated()
        {
            if (DataStoreInvalidated != null)
            {
                DataStoreInvalidated();
            }
        }

        public void InvalidateDataStore()
        {
            foreach (IRepository repository in mRepositories)
            {
                repository.InvalidateDataStore();
            }
            OnDataStoreInvalidated();
        }

        public virtual bool IsMultiUserVersion
        {
            get
            {
                return true;
            }
        }

        public DbManager this[string index]
        {
            get
            {
                if (mMgrFactories.ContainsKey(index))
                {
                    return mMgrFactories[index];
                }
                return null;
            }
        }

        public void AddMgrFactory(DbManager mgr)
        {
            mMgrFactories[mgr.Name] = mgr;
        }

        public virtual void Release()
        {
            DefaultMgrFactory.Release();

            foreach (DbManager mgr in mMgrFactories.Values)
            {
                mgr.Release();
            }
        }

        public void RegisterRepository(IRepository tcs)
        {
            mRepositories.Add(tcs);
        }

        public bool ConnectMgrFactories(out string error)
        {
            error = "";
            if (DefaultMgrFactory.DbConnection == null)
            {
                error = string.Format("Failed to connect to Default Mgr Factory\r\n{0}", DefaultMgrFactory.DbConnectionError);
                return false;
            }
            foreach (string key in mMgrFactories.Keys)
            {
                DbManager mgr=mMgrFactories[key];
                if (mgr.DbConnection == null)
                {
                    error = "Failed to connect to Factory [" + key + "]";
                    return false;
                }
            }
            return true;
        }

        public enum MgrState
        {
            Normal,
            Importing,
            Exporting
        }

        private MgrState mState = MgrState.Normal;
        public MgrState State
        {
            get { return mState; }
        }

        public void BeginImporting() { mState = MgrState.Importing; }
        public void BeginExporting() { mState = MgrState.Exporting; }
        public void EndImporting() { mState = MgrState.Normal; }
        public void EndExporting() { mState = MgrState.Normal; }

        #region DataFieldManager
        private DataFieldManager mDataFieldMgr = null;
        public DataFieldManager DataFieldMgr
        {
            get
            {
                if (mDataFieldMgr == null)
                {
                    DbManager factory = DataFieldMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mDataFieldMgr = factory.CreateDataFieldMgr();
                }
                return mDataFieldMgr;
            }
        }
        public DbManager DataFieldMgrFactory { get; set; }
        #endregion

        #region ItemDataFieldEntryManager
        private ItemDataFieldEntryManager mItemDataFieldEntryMgr = null;
        public ItemDataFieldEntryManager ItemDataFieldEntryMgr
        {
            get
            {
                if (mItemDataFieldEntryMgr == null)
                {
                    DbManager factory = ItemDataFieldEntryMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mItemDataFieldEntryMgr = factory.CreateItemDataFieldEntryMgr();
                }
                return mItemDataFieldEntryMgr;
            }
        }
        public DbManager ItemDataFieldEntryMgrFactory { get; set; }
        #endregion

        #region ItemSizeManager
        private ItemSizeManager mItemSizeMgr = null;
        public ItemSizeManager ItemSizeMgr
        {
            get
            {
                if (mItemSizeMgr == null)
                {
                    DbManager factory = ItemSizeMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mItemSizeMgr = factory.CreateItemSizeMgr();
                }
                return mItemSizeMgr;
            }
        }
        public DbManager ItemSizeMgrFactory { get; set; }
        #endregion

        #region WageDollarHistoryManager
        private WageDollarHistoryManager mWageDollarHistoryMgr = null;
        public WageDollarHistoryManager WageDollarHistoryMgr
        {
            get
            {
                if (mWageDollarHistoryMgr == null)
                {
                    DbManager factory = WageDollarHistoryMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mWageDollarHistoryMgr = factory.CreateWageDollarHistoryMgr();
                }
                return mWageDollarHistoryMgr;
            }
        }
        public DbManager WageDollarHistoryMgrFactory { get; set; } 
        #endregion

        #region WageHourHistoryManager
        private WageHourHistoryManager mWageHourHistoryMgr = null;
        public WageHourHistoryManager WageHourHistoryMgr
        {
            get
            {
                if (mWageHourHistoryMgr == null)
                {
                    DbManager factory = WageHourHistoryMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mWageHourHistoryMgr = factory.CreateWageHourHistoryMgr();
                }
                return mWageHourHistoryMgr;
            }
        }
        public DbManager WageHourHistoryMgrFactory { get; set; } 
        #endregion

        #region LinkedCategoryManager
        private LinkedCategoryManager mLinkedCategoryMgr = null;
        public LinkedCategoryManager LinkedCategoryMgr
        {
            get
            {
                if (mLinkedCategoryMgr == null)
                {
                    DbManager factory = LinkedCategoryMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mLinkedCategoryMgr = factory.CreateLinkedCategoryMgr();
                }
                return mLinkedCategoryMgr;
            }
        }
        public DbManager LinkedCategoryMgrFactory { get; set; } 
        #endregion

        #region LinkedEmployeeManager
        private LinkedEmployeeManager mLinkedEmployeeMgr = null;
        public LinkedEmployeeManager LinkedEmployeeMgr
        {
            get
            {
                if (mLinkedEmployeeMgr == null)
                {
                    DbManager factory = LinkedEmployeeMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mLinkedEmployeeMgr = factory.CreateLinkedEmployeeMgr();
                }
                return mLinkedEmployeeMgr;
            }
        }
        public DbManager LinkedEmployeeMgrFactory { get; set; } 
        #endregion

        #region PayrollInformationManager
        private PayrollInformationManager mPayrollInformationMgr = null;
        public PayrollInformationManager PayrollInformationMgr
        {
            get
            {
                if (mPayrollInformationMgr == null)
                {
                    DbManager factory = PayrollInformationMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mPayrollInformationMgr = factory.CreatePayrollInformationMgr();
                }
                return mPayrollInformationMgr;
            }
        }
        public DbManager PayrollInformationMgrFactory { get; set; } 
        #endregion

        #region BASInformationManager
        private BASInformationManager mBASInformationMgr = null;
        public BASInformationManager BASInformationMgr
        {
            get
            {
                if (mBASInformationMgr == null)
                {
                    DbManager factory = BASInformationMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mBASInformationMgr = factory.CreateBASInformationMgr();
                }
                return mBASInformationMgr;
            }
        }
        public DbManager BASInformationMgrFactory { get; set; } 
        #endregion

        #region GenderManager
        private GenderManager mGenderMgr = null;
        public GenderManager GenderMgr
        {
            get
            {
                if (mGenderMgr == null)
                {
                    DbManager factory = GenderMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mGenderMgr = factory.CreateGenderMgr();
                }
                return mGenderMgr;
            }
        }
        public DbManager GenderMgrFactory { get; set; }
        #endregion

        #region ItemAddOnManager
        private ItemAddOnManager mItemAddOnMgr = null;
        public ItemAddOnManager ItemAddOnMgr
        {
            get
            {
                if (mItemAddOnMgr == null)
                {
                    DbManager factory = ItemAddOnMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mItemAddOnMgr = factory.CreateItemAddOnMgr();
                }
                return mItemAddOnMgr;
            }
        }
        public DbManager ItemAddOnMgrFactory { get; set; }
        #endregion

        #region PaySuperannuationLineManager
        private PaySuperannuationLineManager mPaySuperannuationLineMgr = null;
        public PaySuperannuationLineManager PaySuperannuationLineMgr
        {
            get
            {
                if (mPaySuperannuationLineMgr == null)
                {
                    DbManager factory = PaySuperannuationLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mPaySuperannuationLineMgr = factory.CreatePaySuperannuationLineMgr();
                }
                return mPaySuperannuationLineMgr;
            }
        }
        public DbManager PaySuperannuationLineMgrFactory { get; set; } 
        #endregion

        #region PaySuperannuationManager
        private PaySuperannuationManager mPaySuperannuationMgr = null;
        public PaySuperannuationManager PaySuperannuationMgr
        {
            get
            {
                if (mPaySuperannuationMgr == null)
                {
                    DbManager factory = PaySuperannuationMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mPaySuperannuationMgr = factory.CreatePaySuperannuationMgr();
                }
                return mPaySuperannuationMgr;
            }
        }
        public DbManager PaySuperannuationMgrFactory { get; set; } 
        #endregion

        #region SuperannuationFundManager
        private SuperannuationFundManager mSuperannuationFundMgr = null;
        public SuperannuationFundManager SuperannuationFundMgr
        {
            get
            {
                if (mSuperannuationFundMgr == null)
                {
                    DbManager factory = SuperannuationFundMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mSuperannuationFundMgr = factory.CreateSuperannuationFundMgr();
                }
                return mSuperannuationFundMgr;
            }
        }
        public DbManager SuperannuationFundMgrFactory { get; set; } 
        #endregion

        #region PayLiabilityLineManager
        private PayLiabilityLineManager mPayLiabilityLineMgr = null;
        public PayLiabilityLineManager PayLiabilityLineMgr
        {
            get
            {
                if (mPayLiabilityLineMgr == null)
                {
                    DbManager factory = PayLiabilityLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mPayLiabilityLineMgr = factory.CreatePayLiabilityLineMgr();
                }
                return mPayLiabilityLineMgr;
            }
        }
        public DbManager PayLiabilityLineMgrFactory { get; set; } 
        #endregion

        #region CostCentreJournalRecordManager
        private CostCentreJournalRecordManager mCostCentreJournalRecordMgr = null;
        public CostCentreJournalRecordManager CostCentreJournalRecordMgr
        {
            get
            {
                if (mCostCentreJournalRecordMgr == null)
                {
                    DbManager factory = CostCentreJournalRecordMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mCostCentreJournalRecordMgr = factory.CreateCostCentreJournalRecordMgr();
                }
                return mCostCentreJournalRecordMgr;
            }
        }
        public DbManager CostCentreJournalRecordMgrFactory { get; set; } 
        #endregion

        #region CostCentreAccountActivityManager
        private CostCentreAccountActivityManager mCostCentreAccountActivityMgr = null;
        public CostCentreAccountActivityManager CostCentreAccountActivityMgr
        {
            get
            {
                if (mCostCentreAccountActivityMgr == null)
                {
                    DbManager factory = CostCentreAccountActivityMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mCostCentreAccountActivityMgr = factory.CreateCostCentreAccountActivityMgr();
                }
                return mCostCentreAccountActivityMgr;
            }
        }
        public DbManager CostCentreAccountActivityMgrFactory { get; set; } 
        #endregion

        #region CostCentreAccountManager
        private CostCentreAccountManager mCostCentreAccountMgr = null;
        public CostCentreAccountManager CostCentreAccountMgr
        {
            get
            {
                if (mCostCentreAccountMgr == null)
                {
                    DbManager factory = CostCentreAccountMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mCostCentreAccountMgr = factory.CreateCostCentreAccountMgr();
                }
                return mCostCentreAccountMgr;
            }
        }
        public DbManager CostCentreAccountMgrFactory { get; set; } 
        #endregion

        #region CostCentreManager
        private CostCentreManager mCostCentreMgr = null;
        public CostCentreManager CostCentreMgr
        {
            get
            {
                if (mCostCentreMgr == null)
                {
                    DbManager factory = CostCentreMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mCostCentreMgr = factory.CreateCostCentreMgr();
                }
                return mCostCentreMgr;
            }
        }
        public DbManager CostCentreMgrFactory { get; set; } 
        #endregion

        #region PayLiabilityManager
        private PayLiabilityManager mPayLiabilityMgr = null;
        public PayLiabilityManager PayLiabilityMgr
        {
            get
            {
                if (mPayLiabilityMgr == null)
                {
                    DbManager factory = PayLiabilityMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mPayLiabilityMgr = factory.CreatePayLiabilityMgr();
                }
                return mPayLiabilityMgr;
            }
        }
        public DbManager PayLiabilityMgrFactory { get; set; } 
        #endregion

        #region WritePaychequeLineManager
        private WritePaychequeLineManager mWritePaychequeLineMgr = null;
        public WritePaychequeLineManager WritePaychequeLineMgr
        {
            get
            {
                if (mWritePaychequeLineMgr == null)
                {
                    DbManager factory = WritePaychequeLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mWritePaychequeLineMgr = factory.CreateWritePaychequeLineMgr();
                }
                return mWritePaychequeLineMgr;
            }
        }
        public DbManager WritePaychequeLineMgrFactory { get; set; } 
        #endregion

        #region PayBasisManager
        private PayBasisManager mPayBasisMgr = null;
        public PayBasisManager PayBasisMgr
        {
            get
            {
                if (mPayBasisMgr == null)
                {
                    DbManager factory = PayBasisMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mPayBasisMgr = factory.CreatePayBasisMgr();
                }
                return mPayBasisMgr;
            }
        }
        public DbManager PayBasisMgrFactory { get; set; } 
        #endregion

        #region CategoryTypeManager
        private CategoryTypeManager mCategoryTypeMgr = null;
        public CategoryTypeManager CategoryTypeMgr
        {
            get
            {
                if (mCategoryTypeMgr == null)
                {
                    DbManager factory = CategoryTypeMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mCategoryTypeMgr = factory.CreateCategoryTypeMgr();
                }
                return mCategoryTypeMgr;
            }
        }
        public DbManager CategoryTypeMgrFactory { get; set; } 
        #endregion

        #region WritePaychequeManager
        private WritePaychequeManager mWritePaychequeMgr = null;
        public WritePaychequeManager WritePaychequeMgr
        {
            get
            {
                if (mWritePaychequeMgr == null)
                {
                    DbManager factory = WritePaychequeMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mWritePaychequeMgr = factory.CreateWritePaychequeMgr();
                }
                return mWritePaychequeMgr;
            }
        }
        public DbManager WritePaychequeMgrFactory { get; set; } 
        #endregion

        #region BankingDetailManager
        private BankingDetailManager mBankingDetailMgr = null;
        public BankingDetailManager BankingDetailMgr
        {
            get
            {
                if (mBankingDetailMgr == null)
                {
                    DbManager factory = BankingDetailMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mBankingDetailMgr = factory.CreateBankingDetailMgr();
                }
                return mBankingDetailMgr;
            }
        }
        public DbManager BankingDetailMgrFactory { get; set; } 
        #endregion

        #region PaymentTypeManager
        private PaymentTypeManager mPaymentTypeMgr = null;
        public PaymentTypeManager PaymentTypeMgr
        {
            get
            {
                if (mPaymentTypeMgr == null)
                {
                    DbManager factory = PaymentTypeMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mPaymentTypeMgr = factory.CreatePaymentTypeMgr();
                }
                return mPaymentTypeMgr;
            }
        }
        public DbManager PaymentTypeMgrFactory { get; set; } 
        #endregion


        #region BankDepositLineManager
        private BankDepositLineManager mBankDepositLineMgr = null;
        public BankDepositLineManager BankDepositLineMgr
        {
            get
            {
                if (mBankDepositLineMgr == null)
                {
                    DbManager factory = BankDepositLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mBankDepositLineMgr = factory.CreateBankDepositLineMgr();
                }
                return mBankDepositLineMgr;
            }
        }
        public DbManager BankDepositLineMgrFactory { get; set; } 
        #endregion

        #region BankDepositManager
        private BankDepositManager mBankDepositMgr = null;
        public BankDepositManager BankDepositMgr
        {
            get
            {
                if (mBankDepositMgr == null)
                {
                    DbManager factory = BankDepositMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mBankDepositMgr = factory.CreateBankDepositMgr();
                }
                return mBankDepositMgr;
            }
        }
        public DbManager BankDepositMgrFactory { get; set; } 
        #endregion

        #region RecurringGeneralJournalLineManager
        private RecurringGeneralJournalLineManager mRecurringGeneralJournalLineMgr = null;
        public RecurringGeneralJournalLineManager RecurringGeneralJournalLineMgr
        {
            get
            {
                if (mRecurringGeneralJournalLineMgr == null)
                {
                    DbManager factory = RecurringGeneralJournalLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mRecurringGeneralJournalLineMgr = factory.CreateRecurringGeneralJournalLineMgr();
                }
                return mRecurringGeneralJournalLineMgr;
            }
        }
        public DbManager RecurringGeneralJournalLineMgrFactory { get; set; } 
        #endregion

        #region RecurringGeneralJournalManager
        private RecurringGeneralJournalManager mRecurringGeneralJournalMgr = null;
        public RecurringGeneralJournalManager RecurringGeneralJournalMgr
        {
            get
            {
                if (mRecurringGeneralJournalMgr == null)
                {
                    DbManager factory = RecurringGeneralJournalMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mRecurringGeneralJournalMgr = factory.CreateRecurringGeneralJournalMgr();
                }
                return mRecurringGeneralJournalMgr;
            }
        }
        public DbManager RecurringGeneralJournalMgrFactory { get; set; } 
        #endregion

        #region RecurringTransferMoneyManager
        private RecurringTransferMoneyManager mRecurringTransferMoneyMgr = null;
        public RecurringTransferMoneyManager RecurringTransferMoneyMgr
        {
            get
            {
                if (mRecurringTransferMoneyMgr == null)
                {
                    DbManager factory = RecurringTransferMoneyMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mRecurringTransferMoneyMgr = factory.CreateRecurringTransferMoneyMgr();
                }
                return mRecurringTransferMoneyMgr;
            }
        }
        public DbManager RecurringTransferMoneyMgrFactory { get; set; } 
        #endregion

        #region RecurringMoneyReceivedLineManager
        private RecurringMoneyReceivedLineManager mRecurringMoneyReceivedLineMgr = null;
        public RecurringMoneyReceivedLineManager RecurringMoneyReceivedLineMgr
        {
            get
            {
                if (mRecurringMoneyReceivedLineMgr == null)
                {
                    DbManager factory = RecurringMoneyReceivedLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mRecurringMoneyReceivedLineMgr = factory.CreateRecurringMoneyReceivedLineMgr();
                }
                return mRecurringMoneyReceivedLineMgr;
            }
        }
        public DbManager RecurringMoneyReceivedLineMgrFactory { get; set; } 
        #endregion

        #region RecurringMoneyReceivedManager
        private RecurringMoneyReceivedManager mRecurringMoneyReceivedMgr = null;
        public RecurringMoneyReceivedManager RecurringMoneyReceivedMgr
        {
            get
            {
                if (mRecurringMoneyReceivedMgr == null)
                {
                    DbManager factory = RecurringMoneyReceivedMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mRecurringMoneyReceivedMgr = factory.CreateRecurringMoneyReceivedMgr();
                }
                return mRecurringMoneyReceivedMgr;
            }
        }
        public DbManager RecurringMoneyReceivedMgrFactory { get; set; } 
        #endregion


        #region RecurringMoneySpentLineManager
        private RecurringMoneySpentLineManager mRecurringMoneySpentLineMgr = null;
        public RecurringMoneySpentLineManager RecurringMoneySpentLineMgr
        {
            get
            {
                if (mRecurringMoneySpentLineMgr == null)
                {
                    DbManager factory = RecurringMoneySpentLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mRecurringMoneySpentLineMgr = factory.CreateRecurringMoneySpentLineMgr();
                }
                return mRecurringMoneySpentLineMgr;
            }
        }
        public DbManager RecurringMoneySpentLineMgrFactory { get; set; } 
        #endregion

        #region RecurringMoneySpentManager
        private RecurringMoneySpentManager mRecurringMoneySpentMgr = null;
        public RecurringMoneySpentManager RecurringMoneySpentMgr
        {
            get
            {
                if (mRecurringMoneySpentMgr == null)
                {
                    DbManager factory = RecurringMoneySpentMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mRecurringMoneySpentMgr = factory.CreateRecurringMoneySpentMgr();
                }
                return mRecurringMoneySpentMgr;
            }
        }
        public DbManager RecurringMoneySpentMgrFactory { get; set; } 
        #endregion

        #region NumberingTypeManager
        private NumberingTypeManager mNumberingTypeMgr = null;
        public NumberingTypeManager NumberingTypeMgr
        {
            get
            {
                if (mNumberingTypeMgr == null)
                {
                    DbManager factory = NumberingTypeMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mNumberingTypeMgr = factory.CreateNumberingTypeMgr();
                }
                return mNumberingTypeMgr;
            }
        }
        public DbManager NumberingTypeMgrFactory { get; set; } 
        #endregion

        #region FrequencyManager
        private FrequencyManager mFrequencyMgr = null;
        public FrequencyManager FrequencyMgr
        {
            get
            {
                if (mFrequencyMgr == null)
                {
                    DbManager factory = FrequencyMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mFrequencyMgr = factory.CreateFrequencyMgr();
                }
                return mFrequencyMgr;
            }
        }
        public DbManager FrequencyMgrFactory { get; set; } 
        #endregion

        #region EmployerExpenseTypeManager
        private EmployerExpenseTypeManager mEmployerExpenseTypeMgr = null;
        public EmployerExpenseTypeManager EmployerExpenseTypeMgr
        {
            get
            {
                if (mEmployerExpenseTypeMgr == null)
                {
                    DbManager factory = EmployerExpenseTypeMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mEmployerExpenseTypeMgr = factory.CreateEmployerExpenseTypeMgr();
                }
                return mEmployerExpenseTypeMgr;
            }
        }
        public DbManager EmployerExpenseTypeMgrFactory { get; set; } 
        #endregion

        #region ContributionTypeManager
        private ContributionTypeManager mContributionTypeMgr = null;
        public ContributionTypeManager ContributionTypeMgr
        {
            get
            {
                if (mContributionTypeMgr == null)
                {
                    DbManager factory = ContributionTypeMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mContributionTypeMgr = factory.CreateContributionTypeMgr();
                }
                return mContributionTypeMgr;
            }
        }
        public DbManager ContributionTypeMgrFactory { get; set; } 
        #endregion

        #region CalculationMethodManager
        private CalculationMethodManager mCalculationMethodMgr = null;
        public CalculationMethodManager CalculationMethodMgr
        {
            get
            {
                if (mCalculationMethodMgr == null)
                {
                    DbManager factory = CalculationMethodMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mCalculationMethodMgr = factory.CreateCalculationMethodMgr();
                }
                return mCalculationMethodMgr;
            }
        }
        public DbManager CalculationMethodMgrFactory { get; set; } 
        #endregion

        #region TerminationMethodManager
        private TerminationMethodManager mTerminationMethodMgr = null;
        public TerminationMethodManager TerminationMethodMgr
        {
            get
            {
                if (mTerminationMethodMgr == null)
                {
                    DbManager factory = TerminationMethodMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mTerminationMethodMgr = factory.CreateTerminationMethodMgr();
                }
                return mTerminationMethodMgr;
            }
        }
        public DbManager TerminationMethodMgrFactory { get; set; } 
        #endregion

        #region DayNameManager
        private DayNameManager mDayNameMgr = null;
        public DayNameManager DayNameMgr
        {
            get
            {
                if (mDayNameMgr == null)
                {
                    DbManager factory = DayNameMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mDayNameMgr = factory.CreateDayNameMgr();
                }
                return mDayNameMgr;
            }
        }
        public DbManager DayNameMgrFactory { get; set; } 
        #endregion

        #region EmploymentStatusManager
        private EmploymentStatusManager mEmploymentStatusMgr = null;
        public EmploymentStatusManager EmploymentStatusMgr
        {
            get
            {
                if (mEmploymentStatusMgr == null)
                {
                    DbManager factory = EmploymentStatusMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mEmploymentStatusMgr = factory.CreateEmploymentStatusMgr();
                }
                return mEmploymentStatusMgr;
            }
        }
        public DbManager EmploymentStatusMgrFactory { get; set; } 
        #endregion

        #region EmploymentClassificationManager
        private EmploymentClassificationManager mEmploymentClassificationMgr = null;
        public EmploymentClassificationManager EmploymentClassificationMgr
        {
            get
            {
                if (mEmploymentClassificationMgr == null)
                {
                    DbManager factory = EmploymentClassificationMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mEmploymentClassificationMgr = factory.CreateEmploymentClassificationMgr();
                }
                return mEmploymentClassificationMgr;
            }
        }
        public DbManager EmploymentClassificationMgrFactory { get; set; }
        #endregion

        #region EmploymentBasisManager
        private EmploymentBasisManager mEmploymentBasisMgr = null;
        public EmploymentBasisManager EmploymentBasisMgr
        {
            get
            {
                if (mEmploymentBasisMgr == null)
                {
                    DbManager factory = EmploymentBasisMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mEmploymentBasisMgr = factory.CreateEmploymentBasisMgr();
                }
                return mEmploymentBasisMgr;
            }
        }
        public DbManager EmploymentBasisMgrFactory { get; set; }
        #endregion

        #region AccountingBasisManager
        private AccountingBasisManager mAccountingBasisMgr = null;
        public AccountingBasisManager AccountingBasisMgr
        {
            get
            {
                if (mAccountingBasisMgr == null)
                {
                    DbManager factory = AccountingBasisMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mAccountingBasisMgr = factory.CreateAccountingBasisMgr();
                }
                return mAccountingBasisMgr;
            }
        }
        public DbManager AccountingBasisMgrFactory { get; set; } 
        #endregion

        #region ImportantDatesManager
        private ImportantDatesManager mImportantDatesMgr = null;
        public ImportantDatesManager ImportantDatesMgr
        {
            get
            {
                if (mImportantDatesMgr == null)
                {
                    DbManager factory = ImportantDatesMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mImportantDatesMgr = factory.CreateImportantDatesMgr();
                }
                return mImportantDatesMgr;
            }
        }
        public DbManager ImportantDatesMgrFactory { get; set; } 
        #endregion

        #region AuditTrailManager
        private AuditTrailManager mAuditTrailMgr = null;
        public AuditTrailManager AuditTrailMgr
        {
            get
            {
                if (mAuditTrailMgr == null)
                {
                    DbManager factory = AuditTrailMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mAuditTrailMgr = factory.CreateAuditTrailMgr();
                }
                return mAuditTrailMgr;
            }
        }
        public DbManager AuditTrailMgrFactory { get; set; } 
        #endregion

        #region ElectronicPaymentLineManager
        private ElectronicPaymentLineManager mElectronicPaymentLineMgr = null;
        public ElectronicPaymentLineManager ElectronicPaymentLineMgr
        {
            get
            {
                if (mElectronicPaymentLineMgr == null)
                {
                    DbManager factory = ElectronicPaymentLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mElectronicPaymentLineMgr = factory.CreateElectronicPaymentLineMgr();
                }
                return mElectronicPaymentLineMgr;
            }
        }
        public DbManager ElectronicPaymentLineMgrFactory { get; set; } 
        #endregion

        #region ElectronicPaymentManager
        private ElectronicPaymentManager mElectronicPaymentMgr = null;
        public ElectronicPaymentManager ElectronicPaymentMgr
        {
            get
            {
                if (mElectronicPaymentMgr == null)
                {
                    DbManager factory = ElectronicPaymentMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mElectronicPaymentMgr = factory.CreateElectronicPaymentMgr();
                }
                return mElectronicPaymentMgr;
            }
        }
        public DbManager ElectronicPaymentMgrFactory { get; set; } 
        #endregion

        #region ActivitySlipInvoicedManager
        private ActivitySlipInvoicedManager mActivitySlipInvoicedMgr = null;
        public ActivitySlipInvoicedManager ActivitySlipInvoicedMgr
        {
            get
            {
                if (mActivitySlipInvoicedMgr == null)
                {
                    DbManager factory = ActivitySlipInvoicedMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mActivitySlipInvoicedMgr = factory.CreateActivitySlipInvoicedMgr();
                }
                return mActivitySlipInvoicedMgr;
            }
        }
        public DbManager ActivitySlipInvoicedMgrFactory { get; set; } 
        #endregion

        #region ActivitySlipManager
        private ActivitySlipManager mActivitySlipMgr = null;
        public ActivitySlipManager ActivitySlipMgr
        {
            get
            {
                if (mActivitySlipMgr == null)
                {
                    DbManager factory = ActivitySlipMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mActivitySlipMgr = factory.CreateActivitySlipMgr();
                }
                return mActivitySlipMgr;
            }
        }
        public DbManager ActivitySlipMgrFactory { get; set; } 
        #endregion

        #region WageManager
        private WageManager mWageMgr = null;
        public WageManager WageMgr
        {
            get
            {
                if (mWageMgr == null)
                {
                    DbManager factory = WageMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mWageMgr = factory.CreateWageMgr();
                }
                return mWageMgr;
            }
        }
        public DbManager WageMgrFactory { get; set; } 
        #endregion

        #region ActivitySalesHistoryManager
        private ActivitySalesHistoryManager mActivitySalesHistoryMgr = null;
        public ActivitySalesHistoryManager ActivitySalesHistoryMgr
        {
            get
            {
                if (mActivitySalesHistoryMgr == null)
                {
                    DbManager factory = ActivitySalesHistoryMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mActivitySalesHistoryMgr = factory.CreateActivitySalesHistoryMgr();
                }
                return mActivitySalesHistoryMgr;
            }
        }
        public DbManager ActivitySalesHistoryMgrFactory { get; set; } 
        #endregion

        #region NegativeInventoryManager
        private NegativeInventoryManager mNegativeInventoryMgr = null;
        public NegativeInventoryManager NegativeInventoryMgr
        {
            get
            {
                if (mNegativeInventoryMgr == null)
                {
                    DbManager factory = NegativeInventoryMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mNegativeInventoryMgr = factory.CreateNegativeInventoryMgr();
                }
                return mNegativeInventoryMgr;
            }
        }
        public DbManager NegativeInventoryMgrFactory { get; set; } 
        #endregion

        #region BuildComponentManager
        private BuildComponentManager mBuildComponentMgr = null;
        public BuildComponentManager BuildComponentMgr
        {
            get
            {
                if (mBuildComponentMgr == null)
                {
                    DbManager factory = BuildComponentMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mBuildComponentMgr = factory.CreateBuildComponentMgr();
                }
                return mBuildComponentMgr;
            }
        }
        public DbManager BuildComponentMgrFactory { get; set; } 
        #endregion

        #region BuiltItemManager
        private BuiltItemManager mBuiltItemMgr = null;
        public BuiltItemManager BuiltItemMgr
        {
            get
            {
                if (mBuiltItemMgr == null)
                {
                    DbManager factory = BuiltItemMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mBuiltItemMgr = factory.CreateBuiltItemMgr();
                }
                return mBuiltItemMgr;
            }
        }
        public DbManager BuiltItemMgrFactory { get; set; } 
        #endregion

        #region ItemPurchasesHistoryManager
        private ItemPurchasesHistoryManager mItemPurchasesHistoryMgr = null;
        public ItemPurchasesHistoryManager ItemPurchasesHistoryMgr
        {
            get
            {
                if (mItemPurchasesHistoryMgr == null)
                {
                    DbManager factory = ItemPurchasesHistoryMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mItemPurchasesHistoryMgr = factory.CreateItemPurchasesHistoryMgr();
                }
                return mItemPurchasesHistoryMgr;
            }
        }
        public DbManager ItemPurchasesHistoryMgrFactory { get; set; } 
        #endregion

        #region ItemSalesHistoryManager
        private ItemSalesHistoryManager mItemSalesHistoryMgr = null;
        public ItemSalesHistoryManager ItemSalesHistoryMgr
        {
            get
            {
                if (mItemSalesHistoryMgr == null)
                {
                    DbManager factory = ItemSalesHistoryMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mItemSalesHistoryMgr = factory.CreateItemSalesHistoryMgr();
                }
                return mItemSalesHistoryMgr;
            }
        }
        public DbManager ItemSalesHistoryMgrFactory { get; set; } 
        #endregion

        #region ItemOpeningBalanceManager
        private ItemOpeningBalanceManager mItemOpeningBalanceMgr = null;
        public ItemOpeningBalanceManager ItemOpeningBalanceMgr
        {
            get
            {
                if (mItemOpeningBalanceMgr == null)
                {
                    DbManager factory = ItemOpeningBalanceMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mItemOpeningBalanceMgr = factory.CreateItemOpeningBalanceMgr();
                }
                return mItemOpeningBalanceMgr;
            }
        }
        public DbManager ItemOpeningBalanceMgrFactory { get; set; } 
        #endregion

        #region ItemMovementManager
        private ItemMovementManager mItemMovementMgr = null;
        public ItemMovementManager ItemMovementMgr
        {
            get
            {
                if (mItemMovementMgr == null)
                {
                    DbManager factory = ItemMovementMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mItemMovementMgr = factory.CreateItemMovementMgr();
                }
                return mItemMovementMgr;
            }
        }
        public DbManager ItemMovementMgrFactory { get; set; } 
        #endregion

        #region ItemPriceManager
        private ItemPriceManager mItemPriceMgr = null;
        public ItemPriceManager ItemPriceMgr
        {
            get
            {
                if (mItemPriceMgr == null)
                {
                    DbManager factory = ItemPriceMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mItemPriceMgr = factory.CreateItemPriceMgr();
                }
                return mItemPriceMgr;
            }
        }
        public DbManager ItemPriceMgrFactory { get; set; } 
        #endregion

        #region MoveItemManager
        private MoveItemManager mMoveItemMgr = null;
        public MoveItemManager MoveItemMgr
        {
            get
            {
                if (mMoveItemMgr == null)
                {
                    DbManager factory = MoveItemMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mMoveItemMgr = factory.CreateMoveItemMgr();
                }
                return mMoveItemMgr;
            }
        }
        public DbManager MoveItemMgrFactory { get; set; } 
        #endregion

        #region RoundingManager
        private RoundingManager mRoundingMgr = null;
        public RoundingManager RoundingMgr
        {
            get
            {
                if (mRoundingMgr == null)
                {
                    DbManager factory = RoundingMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mRoundingMgr = factory.CreateRoundingMgr();
                }
                return mRoundingMgr;
            }
        }
        public DbManager RoundingMgrFactory { get; set; } 
        #endregion

        #region TaxInformationConsolidationManager
        private TaxInformationConsolidationManager mTaxInformationConsolidationMgr = null;
        public TaxInformationConsolidationManager TaxInformationConsolidationMgr
        {
            get
            {
                if (mTaxInformationConsolidationMgr == null)
                {
                    DbManager factory = TaxInformationConsolidationMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mTaxInformationConsolidationMgr = factory.CreateTaxInformationConsolidationMgr();
                }
                return mTaxInformationConsolidationMgr;
            }
        }
        public DbManager TaxInformationConsolidationMgrFactory { get; set; } 
        #endregion

        #region TaxInformationManager
        private TaxInformationManager mTaxInformationMgr = null;
        public TaxInformationManager TaxInformationMgr
        {
            get
            {
                if (mTaxInformationMgr == null)
                {
                    DbManager factory = TaxInformationMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mTaxInformationMgr = factory.CreateTaxInformationMgr();
                }
                return mTaxInformationMgr;
            }
        }
        public DbManager TaxInformationMgrFactory { get; set; } 
        #endregion

        #region TaxCodeConsolidationManager
        private TaxCodeConsolidationManager mTaxCodeConsolidationMgr = null;
        public TaxCodeConsolidationManager TaxCodeConsolidationMgr
        {
            get
            {
                if (mTaxCodeConsolidationMgr == null)
                {
                    DbManager factory = TaxCodeConsolidationMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mTaxCodeConsolidationMgr = factory.CreateTaxCodeConsolidationMgr();
                }
                return mTaxCodeConsolidationMgr;
            }
        }
        public DbManager TaxCodeConsolidationMgrFactory { get; set; } 
        #endregion

        #region EmploymentCategoryManager
        private EmploymentCategoryManager mEmploymentCategoryMgr = null;
        public EmploymentCategoryManager EmploymentCategoryMgr
        {
            get
            {
                if (mEmploymentCategoryMgr == null)
                {
                    DbManager factory = EmploymentCategoryMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mEmploymentCategoryMgr = factory.CreateEmploymentCategoryMgr();
                }
                return mEmploymentCategoryMgr;
            }
        }
        public DbManager EmploymentCategoryMgrFactory { get; set; } 
        #endregion

        #region ScheduleManager
        private ScheduleManager mScheduleMgr = null;
        public ScheduleManager ScheduleMgr
        {
            get
            {
                if (mScheduleMgr == null)
                {
                    DbManager factory = ScheduleMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mScheduleMgr = factory.CreateScheduleMgr();
                }
                return mScheduleMgr;
            }
        }
        public DbManager ScheduleMgrFactory { get; set; } 
        #endregion

        #region ValueTypeManager
        private PaymentValueTypeManager mPaymentValueTypeMgr = null;
        public PaymentValueTypeManager PaymentValueTypeMgr
        {
            get
            {
                if (mPaymentValueTypeMgr == null)
                {
                    DbManager factory = PaymentValueTypeMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mPaymentValueTypeMgr = factory.CreatePaymentValueTypeMgr();
                }
                return mPaymentValueTypeMgr;
            }
        }
        public DbManager PaymentValueTypeMgrFactory { get; set; } 
        #endregion

        #region TaxScaleManager
        private TaxScaleManager mTaxScaleMgr = null;
        public TaxScaleManager TaxScaleMgr
        {
            get
            {
                if (mTaxScaleMgr == null)
                {
                    DbManager factory = TaxScaleMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mTaxScaleMgr = factory.CreateTaxScaleMgr();
                }
                return mTaxScaleMgr;
            }
        }
        public DbManager TaxScaleMgrFactory { get; set; } 
        #endregion

        #region AlertTypeManager
        private AlertTypeManager mAlertTypeMgr = null;
        public AlertTypeManager AlertTypeMgr
        {
            get
            {
                if (mAlertTypeMgr == null)
                {
                    DbManager factory = AlertTypeMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mAlertTypeMgr = factory.CreateAlertTypeMgr();
                }
                return mAlertTypeMgr;
            }
        }
        public DbManager AlertTypeMgrFactory { get; set; } 
        #endregion

        #region AlertManager
        private AlertManager mAlertMgr = null;
        public AlertManager AlertMgr
        {
            get
            {
                if (mAlertMgr == null)
                {
                    DbManager factory = AlertMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mAlertMgr = factory.CreateAlertMgr();
                }
                return mAlertMgr;
            }
        }
        public DbManager AlertMgrFactory { get; set; } 
        #endregion

        #region LimitTypeManager
        private LimitTypeManager mLimitTypeMgr = null;
        public LimitTypeManager LimitTypeMgr
        {
            get
            {
                if (mLimitTypeMgr == null)
                {
                    DbManager factory = LimitTypeMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mLimitTypeMgr = factory.CreateLimitTypeMgr();
                }
                return mLimitTypeMgr;
            }
        }
        public DbManager LimitTypeMgrFactory { get; set; } 
        #endregion

        #region ReportingMethodManager
        private ReportingMethodManager mReportingMethodMgr = null;
        public ReportingMethodManager ReportingMethodMgr
        {
            get
            {
                if (mReportingMethodMgr == null)
                {
                    DbManager factory = ReportingMethodMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mReportingMethodMgr = factory.CreateReportingMethodMgr();
                }
                return mReportingMethodMgr;
            }
        }
        public DbManager ReportingMethodMgrFactory { get; set; } 
        #endregion

        #region ReconciliationStatusManager
        private ReconciliationStatusManager mReconciliationStatusMgr = null;
        public ReconciliationStatusManager ReconciliationStatusMgr
        {
            get
            {
                if (mReconciliationStatusMgr == null)
                {
                    DbManager factory = ReconciliationStatusMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mReconciliationStatusMgr = factory.CreateReconciliationStatusMgr();
                }
                return mReconciliationStatusMgr;
            }
        }
        public DbManager ReconciliationStatusMgrFactory { get; set; } 
        #endregion

        #region SalespersonHistoryManager
        private SalespersonHistoryManager mSalespersonHistoryMgr = null;
        public SalespersonHistoryManager SalespersonHistoryMgr
        {
            get
            {
                if (mSalespersonHistoryMgr == null)
                {
                    DbManager factory = SalespersonHistoryMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mSalespersonHistoryMgr = factory.CreateSalespersonHistoryMgr();
                }
                return mSalespersonHistoryMgr;
            }
        }
        public DbManager SalespersonHistoryMgrFactory { get; set; } 
        #endregion

        #region InventoryTransferLineManager
        private InventoryTransferLineManager mInventoryTransferLineMgr = null;
        public InventoryTransferLineManager InventoryTransferLineMgr
        {
            get
            {
                if (mInventoryTransferLineMgr == null)
                {
                    DbManager factory = InventoryTransferLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mInventoryTransferLineMgr = factory.CreateInventoryTransferLineMgr();
                }
                return mInventoryTransferLineMgr;
            }
        }
        public DbManager InventoryTransferLineMgrFactory { get; set; } 
        #endregion

        #region InventoryTransferManager
        private InventoryTransferManager mInventoryTransferMgr = null;
        public InventoryTransferManager InventoryTransferMgr
        {
            get
            {
                if (mInventoryTransferMgr == null)
                {
                    DbManager factory = InventoryTransferMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mInventoryTransferMgr = factory.CreateInventoryTransferMgr();
                }
                return mInventoryTransferMgr;
            }
        }
        public DbManager InventoryTransferMgrFactory { get; set; } 
        #endregion

        #region InventoryAdjustmentLineManager
        private InventoryAdjustmentLineManager mInventoryAdjustmentLineMgr = null;
        public InventoryAdjustmentLineManager InventoryAdjustmentLineMgr
        {
            get
            {
                if (mInventoryAdjustmentLineMgr == null)
                {
                    DbManager factory = InventoryAdjustmentLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mInventoryAdjustmentLineMgr = factory.CreateInventoryAdjustmentLineMgr();
                }
                return mInventoryAdjustmentLineMgr;
            }
        }
        public DbManager InventoryAdjustmentLineMgrFactory { get; set; } 
        #endregion

        #region InventoryAdjustmentManager
        private InventoryAdjustmentManager mInventoryAdjustmentMgr = null;
        public InventoryAdjustmentManager InventoryAdjustmentMgr
        {
            get
            {
                if (mInventoryAdjustmentMgr == null)
                {
                    DbManager factory = InventoryAdjustmentMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mInventoryAdjustmentMgr = factory.CreateInventoryAdjustmentMgr();
                }
                return mInventoryAdjustmentMgr;
            }
        }
        public DbManager InventoryAdjustmentMgrFactory { get; set; } 
        #endregion

        #region DebitRefundManager
        private DebitRefundManager mDebitRefundMgr = null;
        public DebitRefundManager DebitRefundMgr
        {
            get
            {
                if (mDebitRefundMgr == null)
                {
                    DbManager factory = DebitRefundMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mDebitRefundMgr = factory.CreateDebitRefundMgr();
                }
                return mDebitRefundMgr;
            }
        }
        public DbManager DebitRefundMgrFactory { get; set; } 
        #endregion

        #region SettledDebitLineManager
        private SettledDebitLineManager mSettledDebitLineMgr = null;
        public SettledDebitLineManager SettledDebitLineMgr
        {
            get
            {
                if (mSettledDebitLineMgr == null)
                {
                    DbManager factory = SettledDebitLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mSettledDebitLineMgr = factory.CreateSettledDebitLineMgr();
                }
                return mSettledDebitLineMgr;
            }
        }
        public DbManager SettledDebitLineMgrFactory { get; set; } 
        #endregion

        #region SettledDebitManager
        private SettledDebitManager mSettledDebitMgr = null;
        public SettledDebitManager SettledDebitMgr
        {
            get
            {
                if (mSettledDebitMgr == null)
                {
                    DbManager factory = SettledDebitMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mSettledDebitMgr = factory.CreateSettledDebitMgr();
                }
                return mSettledDebitMgr;
            }
        }
        public DbManager SettledDebitMgrFactory { get; set; } 
        #endregion

        #region CreditFundManager
        private CreditRefundManager mCreditRefundMgr = null;
        public CreditRefundManager CreditRefundMgr
        {
            get
            {
                if (mCreditRefundMgr == null)
                {
                    DbManager factory = CreditRefundMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mCreditRefundMgr = factory.CreateCreditRefundMgr();
                }
                return mCreditRefundMgr;
            }
        }
        public DbManager CreditRefundMgrFactory { get; set; }
        #endregion

        private SettledCreditLineManager mSettledCreditLineMgr = null;
        public SettledCreditLineManager SettledCreditLineMgr
        {
            get
            {
                if (mSettledCreditLineMgr == null)
                {
                    DbManager factory = SettledCreditLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mSettledCreditLineMgr = factory.CreateSettledCreditLineMgr();
                }
                return mSettledCreditLineMgr;
            }
        }
        public DbManager SettledCreditLineMgrFactory { get; set; } 

        private SettledCreditManager mSettledCreditMgr = null;
        public SettledCreditManager SettledCreditMgr
        {
            get
            {
                if (mSettledCreditMgr == null)
                {
                    DbManager factory = SettledCreditMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mSettledCreditMgr = factory.CreateSettledCreditMgr();
                }
                return mSettledCreditMgr;
            }
        }
        public DbManager SettledCreditMgrFactory { get; set; } 

        private SupplierFinanceChargeManager mSupplierFinanceChargeMgr = null;
        public SupplierFinanceChargeManager SupplierFinanceChargeMgr
        {
            get
            {
                if (mSupplierFinanceChargeMgr == null)
                {
                    DbManager factory = SupplierFinanceChargeMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mSupplierFinanceChargeMgr = factory.CreateSupplierFinanceChargeMgr();
                }
                return mSupplierFinanceChargeMgr;
            }
        }
        public DbManager SupplierFinanceChargeMgrFactory { get; set; } 

        private SupplierDepositManager mSupplierDepositMgr = null;
        public SupplierDepositManager SupplierDepositMgr
        {
            get
            {
                if (mSupplierDepositMgr == null)
                {
                    DbManager factory = SupplierDepositMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mSupplierDepositMgr = factory.CreateSupplierDepositMgr();
                }
                return mSupplierDepositMgr;
            }
        }
        public DbManager SupplierDepositMgrFactory { get; set; } 

        private SupplierDiscountLineManager mSupplierDiscountLineMgr = null;
        public SupplierDiscountLineManager SupplierDiscountLineMgr
        {
            get
            {
                if (mSupplierDiscountLineMgr == null)
                {
                    DbManager factory = SupplierDiscountLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mSupplierDiscountLineMgr = factory.CreateSupplierDiscountLineMgr();
                }
                return mSupplierDiscountLineMgr;
            }
        }
        public DbManager SupplierDiscountLineMgrFactory { get; set; } 

        private SupplierDiscountManager mSupplierDiscountMgr = null;
        public SupplierDiscountManager SupplierDiscountMgr
        {
            get
            {
                if (mSupplierDiscountMgr == null)
                {
                    DbManager factory = SupplierDiscountMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mSupplierDiscountMgr = factory.CreateSupplierDiscountMgr();
                }
                return mSupplierDiscountMgr;
            }
        }
        public DbManager SupplierDiscountMgrFactory { get; set; } 

        private SupplierPaymentLineManager mSupplierPaymentLineMgr = null;
        public SupplierPaymentLineManager SupplierPaymentLineMgr
        {
            get
            {
                if (mSupplierPaymentLineMgr == null)
                {
                    DbManager factory = SupplierPaymentLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mSupplierPaymentLineMgr = factory.CreateSupplierPaymentLineMgr();
                }
                return mSupplierPaymentLineMgr;
            }
        }
        public DbManager SupplierPaymentLineMgrFactory { get; set; } 

        private SupplierPaymentManager mSupplierPaymentMgr = null;
        public SupplierPaymentManager SupplierPaymentMgr
        {
            get
            {
                if (mSupplierPaymentMgr == null)
                {
                    DbManager factory = SupplierPaymentMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mSupplierPaymentMgr = factory.CreateSupplierPaymentMgr();
                }
                return mSupplierPaymentMgr;
            }
        }
        public DbManager SupplierPaymentMgrFactory { get; set; } 

        private CustomerFinanceChargeManager mCustomerFinanceChargeMgr = null;
        public CustomerFinanceChargeManager CustomerFinanceChargeMgr
        {
            get
            {
                if (mCustomerFinanceChargeMgr == null)
                {
                    DbManager factory = CustomerFinanceChargeMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mCustomerFinanceChargeMgr = factory.CreateCustomerFinanceChargeMgr();
                }
                return mCustomerFinanceChargeMgr;
            }
        }
        public DbManager CustomerFinanceChargeMgrFactory { get; set; } 

        private CustomerDepositManager mCustomerDepositMgr = null;
        public CustomerDepositManager CustomerDepositMgr
        {
            get
            {
                if (mCustomerDepositMgr == null)
                {
                    DbManager factory = CustomerDepositMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mCustomerDepositMgr = factory.CreateCustomerDepositMgr();
                }
                return mCustomerDepositMgr;
            }
        }
        public DbManager CustomerDepositMgrFactory { get; set; } 

        private CustomerDiscountLineManager mCustomerDiscountLineMgr = null;
        public CustomerDiscountLineManager CustomerDiscountLineMgr
        {
            get
            {
                if (mCustomerDiscountLineMgr == null)
                {
                    DbManager factory = CustomerDiscountLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mCustomerDiscountLineMgr = factory.CreateCustomerDiscountLineMgr();
                }
                return mCustomerDiscountLineMgr;
            }
        }
        public DbManager CustomerDiscountLineMgrFactory { get; set; } 

        private CustomerDiscountManager mCustomerDiscountMgr = null;
        public CustomerDiscountManager CustomerDiscountMgr
        {
            get
            {
                if (mCustomerDiscountMgr == null)
                {
                    DbManager factory = CustomerDiscountMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mCustomerDiscountMgr = factory.CreateCustomerDiscountMgr();
                }
                return mCustomerDiscountMgr;
            }
        }
        public DbManager CustomerDiscountMgrFactory { get; set; } 

        private CustomerPaymentLineManager mCustomerPaymentLineMgr = null;
        public CustomerPaymentLineManager CustomerPaymentLineMgr
        {
            get
            {
                if (mCustomerPaymentLineMgr == null)
                {
                    DbManager factory = CustomerPaymentLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mCustomerPaymentLineMgr = factory.CreateCustomerPaymentLineMgr();
                }
                return mCustomerPaymentLineMgr;
            }
        }
        public DbManager CustomerPaymentLineMgrFactory { get; set; } 

        private CustomerPaymentManager mCustomerPaymentMgr = null;
        public CustomerPaymentManager CustomerPaymentMgr
        {
            get
            {
                if (mCustomerPaymentMgr == null)
                {
                    DbManager factory = CustomerPaymentMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mCustomerPaymentMgr = factory.CreateCustomerPaymentMgr();
                }
                return mCustomerPaymentMgr;
            }
        }
        public DbManager CustomerPaymentMgrFactory { get; set; } 

        private MoneyReceivedManager mMoneyReceivedMgr = null;
        public MoneyReceivedManager MoneyReceivedMgr
        {
            get
            {
                if (mMoneyReceivedMgr == null)
                {
                    DbManager factory = MoneyReceivedMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mMoneyReceivedMgr = factory.CreateMoneyReceivedMgr();
                }
                return mMoneyReceivedMgr;
            }
        }
        public DbManager MoneyReceivedMgrFactory { get; set; } 

        private MoneyReceivedLineManager mMoneyReceivedLineMgr = null;
        public MoneyReceivedLineManager MoneyReceivedLineMgr
        {
            get
            {
                if (mMoneyReceivedLineMgr == null)
                {
                    DbManager factory = MoneyReceivedLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mMoneyReceivedLineMgr = factory.CreateMoneyReceivedLineMgr();
                }
                return mMoneyReceivedLineMgr;
            }
        }
        public DbManager MoneyReceivedLineMgrFactory { get; set; } 

        private MoneySpentLineManager mMoneySpentLineMgr = null;
        public MoneySpentLineManager MoneySpentLineMgr
        {
            get
            {
                if (mMoneySpentLineMgr == null)
                {
                    DbManager factory = MoneySpentLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mMoneySpentLineMgr = factory.CreateMoneySpentLineMgr();
                }
                return mMoneySpentLineMgr;
            }
        }
        public DbManager MoneySpentLineMgrFactory { get; set; } 

        private PurchasesHistoryManager mPurchasesHistoryMgr = null;
        public PurchasesHistoryManager PurchasesHistoryMgr
        {
            get
            {
                if (mPurchasesHistoryMgr == null)
                {
                    DbManager factory = PurchasesHistoryMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mPurchasesHistoryMgr = factory.CreatePurchasesHistoryMgr();
                }
                return mPurchasesHistoryMgr;
            }
        }
        public DbManager PurchasesHistoryMgrFactory { get; set; } 

        private SalesHistoryManager mSalesHistoryMgr = null;
        public SalesHistoryManager SalesHistoryMgr
        {
            get
            {
                if (mSalesHistoryMgr == null)
                {
                    DbManager factory = SalesHistoryMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mSalesHistoryMgr = factory.CreateSalesHistoryMgr();
                }
                return mSalesHistoryMgr;
            }
        }
        public DbManager SalesHistoryMgrFactory { get; set; } 

        private CardActivityManager mCardActivityMgr = null;
        public CardActivityManager CardActivityMgr
        {
            get
            {
                if (mCardActivityMgr == null)
                {
                    DbManager factory = CardActivityMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mCardActivityMgr = factory.CreateCardActivityMgr();
                }
                return mCardActivityMgr;
            }
        }
        public DbManager CardActivityMgrFactory { get; set; } 

        private PersonalCardManager mPersonalCardMgr = null;
        public PersonalCardManager PersonalCardMgr
        {
            get
            {
                if (mPersonalCardMgr == null)
                {
                    DbManager factory = PersonalCardMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mPersonalCardMgr = factory.CreatePersonalCardMgr();
                }
                return mPersonalCardMgr;
            }
        }
        public DbManager PersonalCardMgrFactory { get; set; } 

        private DepositStatusManager mDepositStatusMgr = null;
        public DepositStatusManager DepositStatusMgr
        {
            get
            {
                if (mDepositStatusMgr == null)
                {
                    DbManager factory = DepositStatusMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mDepositStatusMgr = factory.CreateDepositStatusMgr();
                }
                return mDepositStatusMgr;
            }
        }
        public DbManager DepositStatusMgrFactory { get; set; } 

        private MoneySpentManager mMoneySpentMgr = null;
        public MoneySpentManager MoneySpentMgr
        {
            get
            {
                if (mMoneySpentMgr == null)
                {
                    DbManager factory = MoneySpentMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mMoneySpentMgr = factory.CreateMoneySpentMgr();
                }
                return mMoneySpentMgr;
            }
        }
        public DbManager MoneySpentMgrFactory { get; set; } 

        private JobJournalRecordManager mJobJournalRecordMgr = null;
        public JobJournalRecordManager JobJournalRecordMgr
        {
            get
            {
                if (mJobJournalRecordMgr == null)
                {
                    DbManager factory = JobJournalRecordMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mJobJournalRecordMgr = factory.CreateJobJournalRecordMgr();
                }
                return mJobJournalRecordMgr;
            }
        }
        public DbManager JobJournalRecordMgrFactory { get; set; } 

        private JobBudgetManager mJobBudgetMgr = null;
        public JobBudgetManager JobBudgetMgr
        {
            get
            {
                if (mJobBudgetMgr == null)
                {
                    DbManager factory = JobBudgetMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mJobBudgetMgr = factory.CreateJobBudgetMgr();
                }
                return mJobBudgetMgr;
            }
        }
        public DbManager JobBudgetMgrFactory { get; set; } 

        private JobAccountActivityManager mJobAccountActivityMgr = null;
        public JobAccountActivityManager JobAccountActivityMgr
        {
            get
            {
                if (mJobAccountActivityMgr == null)
                {
                    DbManager factory = JobAccountActivityMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mJobAccountActivityMgr = factory.CreateJobAccountActivityMgr();
                }
                return mJobAccountActivityMgr;
            }
        }
        public DbManager JobAccountActivityMgrFactory { get; set; } 

        private JobAccountManager mJobAccountMgr = null;
        public JobAccountManager JobAccountMgr
        {
            get
            {
                if (mJobAccountMgr == null)
                {
                    DbManager factory = JobAccountMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mJobAccountMgr = factory.CreateJobAccountMgr();
                }
                return mJobAccountMgr;
            }
        }
        public DbManager JobAccountMgrFactory { get; set; } 

        private ItemLocationManager mItemLocationMgr = null;
        public ItemLocationManager ItemLocationMgr
        {
            get
            {
                if (mItemLocationMgr == null)
                {
                    DbManager factory = ItemLocationMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mItemLocationMgr = factory.CreateItemLocationMgr();
                }
                return mItemLocationMgr;
            }
        }
        public DbManager ItemLocationMgrFactory { get; set; } 

        private LinkedAccountManager mLinkedAccountMgr = null;
        public LinkedAccountManager LinkedAccountMgr
        {
            get
            {
                if (mLinkedAccountMgr == null)
                {
                    DbManager factory = LinkedAccountMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mLinkedAccountMgr = factory.CreateLinkedAccountMgr();
                }
                return mLinkedAccountMgr;
            }
        }
        public DbManager LinkedAccountMgrFactory { get; set; } 

        private DataFileInformationManager mDataFileInformationMgr = null;
        public DataFileInformationManager DataFileInformationMgr
        {
            get
            {
                if (mDataFileInformationMgr == null)
                {
                    DbManager factory = DataFileInformationMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mDataFileInformationMgr = factory.CreateDataFileInformationMgr();
                }
                return mDataFileInformationMgr;
            }
        }
        public DbManager DataFileInformationMgrFactory { get; set; } 

        private AccountBudgetManager mAccountBudgetMgr = null;
        public AccountBudgetManager AccountBudgetMgr
        {
            get
            {
                if (mAccountBudgetMgr == null)
                {
                    DbManager factory = AccountBudgetMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mAccountBudgetMgr = factory.CreateAccountBudgetMgr();
                }
                return mAccountBudgetMgr;
            }
        }
        public DbManager AccountBudgetMgrFactory { get; set; } 

        private AccountActivityManager mAccountActivityMgr = null;
        public AccountActivityManager AccountActivityMgr
        {
            get
            {
                if (mAccountActivityMgr == null)
                {
                    DbManager factory = AccountActivityMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mAccountActivityMgr = factory.CreateAccountActivityMgr();
                }
                return mAccountActivityMgr;
            }
        }
        public DbManager AccountActivityMgrFactory { get; set; } 

        private ContactLogManager mContactLogMgr = null;
        public ContactLogManager ContactLogMgr
        {
            get
            {
                if (mContactLogMgr == null)
                {
                    DbManager factory = ContactLogMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mContactLogMgr = factory.CreateContactLogMgr();
                }
                return mContactLogMgr;
            }
        }
        public DbManager ContactLogMgrFactory { get; set; } 

        private PaymentMethodManager mPaymentMethodMgr = null;
        public PaymentMethodManager PaymentMethodMgr
        {
            get
            {
                if (mPaymentMethodMgr == null)
                {
                    DbManager factory = PaymentMethodMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mPaymentMethodMgr = factory.CreatePaymentMethodMgr();
                }
                return mPaymentMethodMgr;
            }
        }
        public DbManager PaymentMethodMgrFactory { get; set; } 

        private JournalSetManager mJournalSetMgr = null;
        public JournalSetManager JournalSetMgr
        {
            get
            {
                if (mJournalSetMgr == null)
                {
                    DbManager factory = JournalSetMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mJournalSetMgr = factory.CreateJournalSetMgr();
                }
                return mJournalSetMgr;
            }
        }
        public DbManager JournalSetMgrFactory { get; set; } 

        private JournalRecordManager mJournalRecordMgr = null;
        public JournalRecordManager JournalRecordMgr
        {
            get
            {
                if (mJournalRecordMgr == null)
                {
                    DbManager factory = JournalRecordMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mJournalRecordMgr = factory.CreateJournalRecordMgr();
                }
                return mJournalRecordMgr;
            }
        }
        public DbManager JournalRecordMgrFactory { get; set; } 

        private GeneralJournalManager mGeneralJournalMgr = null;
        public GeneralJournalManager GeneralJournalMgr
        {
            get
            {
                if (mGeneralJournalMgr == null)
                {
                    DbManager factory = GeneralJournalMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mGeneralJournalMgr = factory.CreateGeneralJournalMgr();
                }
                return mGeneralJournalMgr;
            }
        }
        public DbManager GeneralJournalMgrFactory { get; set; } 

        private JobManager mJobMgr = null;
        public JobManager JobMgr
        {
            get
            {
                if (mJobMgr == null)
                {
                    DbManager factory = JobMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mJobMgr = factory.CreateJobMgr();
                }
                return mJobMgr;
            }
        }
        public DbManager JobMgrFactory { get; set; } 



        private ReferralSourceManager mReferralSourceMgr = null;
        public ReferralSourceManager ReferralSourceMgr
        {
            get
            {
                if (mReferralSourceMgr == null)
                {
                    DbManager factory = ReferralSourceMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mReferralSourceMgr = factory.CreateReferralSourceMgr();
                }
                return mReferralSourceMgr;
            }
        }
        public DbManager ReferralSourceMgrFactory { get; set; } 

        private TransferMoneyManager mTransferMoneyMgr;
        public TransferMoneyManager TransferMoneyMgr
        {
            get
            {
                if (mTransferMoneyMgr == null)
                {
                    DbManager factory = TransferMoneyMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mTransferMoneyMgr = factory.CreateTransferMoneyMgr();
                }
                return mTransferMoneyMgr;
            }
        }
        public DbManager TransferMoneyMgrFactory { get; set; } 

        private ActivityManager mActivityMgr = null;
        public ActivityManager ActivityMgr
        {
            get
            {
                if (mActivityMgr == null)
                {
                    DbManager factory = ActivityMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mActivityMgr = factory.CreateActivityMgr();
                }
                return mActivityMgr;
            }
        }
        public DbManager ActivityMgrFactory { get; set; } 

        private BillingRateUsedManager mBillingRateUsedMgr = null;
        public BillingRateUsedManager BillingRateUsedMgr
        {
            get
            {
                if (mBillingRateUsedMgr == null)
                {
                    DbManager factory = BillingRateUsedMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mBillingRateUsedMgr = factory.CreateBillingRateUsedMgr();
                }
                return mBillingRateUsedMgr;
            }
        }
        public DbManager BillingRateUsedMgrFactory { get; set; } 

        private CardManager mCardMgr = null;
        public CardManager CardMgr
        {
            get
            {
                if (mCardMgr == null)
                {
                    DbManager factory = CardMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mCardMgr = factory.CreateCardMgr();
                }
                return mCardMgr;
            }
        }
        public DbManager CardMgrFactory { get; set; }

        #region MiscNumber
        private MiscNumberManager mMiscNumberMgr = null;
        public MiscNumberManager MiscNumberMgr
        {
            get
            {
                if (mMiscNumberMgr == null)
                {
                    DbManager factory = MiscNumberMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mMiscNumberMgr = factory.CreateMiscNumberMgr();
                }
                return mMiscNumberMgr;
            }
        }
        public DbManager MiscNumberMgrFactory { get; set; }
        #endregion

        #region Config
        private ConfigManager mConfigMgr = null;
        public ConfigManager ConfigMgr
        {
            get
            {
                if (mConfigMgr == null)
                {
                    DbManager factory = ConfigMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mConfigMgr = factory.CreateConfigMgr();
                }
                return mConfigMgr;
            }
        }
        public DbManager ConfigMgrFactory { get; set; }
        #endregion

        #region Sales
        #region SaleManager
        private SaleManager mSaleMgr = null;
        public SaleManager SaleMgr
        {
            get
            {
                if (mSaleMgr == null)
                {
                    DbManager factory = SaleMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mSaleMgr = factory.CreateSaleMgr();
                }
                return mSaleMgr;
            }
        }
        public DbManager SaleMgrFactory { get; set; } 
        #endregion

        #region SaleLineManager
        private SaleLineManager mSaleLineMgr = null;
        public SaleLineManager SaleLineMgr
        {
            get
            {
                if (mSaleLineMgr == null)
                {
                    DbManager factory = SaleLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mSaleLineMgr = factory.CreateSaleLineMgr();
                }
                return mSaleLineMgr;
            }
        }
        public DbManager SaleLineMgrFactory { get; set; } 
        #endregion

        #region MiscSaleLineManager
        private MiscSaleLineManager mMiscSaleLineMgr = null;
        public MiscSaleLineManager MiscSaleLineMgr
        {
            get
            {
                if (mMiscSaleLineMgr == null)
                {
                    DbManager factory = MiscSaleLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mMiscSaleLineMgr = factory.CreateMiscSaleLineMgr();
                }
                return mMiscSaleLineMgr;
            }
        }
        public DbManager MiscSaleLineMgrFactory { get; set; } 
        #endregion

        #region ProfessionalSaleLineManager
        private ProfessionalSaleLineManager mProfessionalSaleLineMgr = null;
        public ProfessionalSaleLineManager ProfessionalSaleLineMgr
        {
            get
            {
                if (mProfessionalSaleLineMgr == null)
                {
                    DbManager factory = ProfessionalSaleLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mProfessionalSaleLineMgr = factory.CreateProfessionalSaleLineMgr();
                }
                return mProfessionalSaleLineMgr;
            }
        }
        public DbManager ProfessionalSaleLineMgrFactory { get; set; } 
        #endregion

        #region ServiceSaleLineManager
        private ServiceSaleLineManager mServiceSaleLineMgr = null;
        public ServiceSaleLineManager ServiceSaleLineMgr
        {
            get
            {
                if (mServiceSaleLineMgr == null)
                {
                    DbManager factory = ServiceSaleLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mServiceSaleLineMgr = factory.CreateServiceSaleLineMgr();
                }
                return mServiceSaleLineMgr;
            }
        }
        public DbManager ServiceSaleLineMgrFactory { get; set; } 
        #endregion

        #region TimeBillingSaleLineManager
        private TimeBillingSaleLineManager mTimeBillingSaleLineMgr = null;
        public TimeBillingSaleLineManager TimeBillingSaleLineMgr
        {
            get
            {
                if (mTimeBillingSaleLineMgr == null)
                {
                    DbManager factory = TimeBillingSaleLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mTimeBillingSaleLineMgr = factory.CreateTimeBillingSaleLineMgr();
                }
                return mTimeBillingSaleLineMgr;
            }
        }
        public DbManager TimeBillingSaleLineMgrFactory { get; set; } 
        #endregion

        #region ItemSaleLineManager
        private ItemSaleLineManager mItemSaleLineMgr = null;
        public ItemSaleLineManager ItemSaleLineMgr
        {
            get
            {
                if (mItemSaleLineMgr == null)
                {
                    DbManager factory = ItemSaleLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mItemSaleLineMgr = factory.CreateItemSaleLineMgr();
                }
                return mItemSaleLineMgr;
            }
        }
        public DbManager ItemSaleLineMgrFactory { get; set; } 
        #endregion
        #endregion

        #region RecurringSales
        #region RecurringSaleManager
        private RecurringSaleManager mRecurringSaleMgr = null;
        public RecurringSaleManager RecurringSaleMgr
        {
            get
            {
                if (mRecurringSaleMgr == null)
                {
                    DbManager factory = RecurringSaleMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mRecurringSaleMgr = factory.CreateRecurringSaleMgr();
                }
                return mRecurringSaleMgr;
            }
        }
        public DbManager RecurringSaleMgrFactory { get; set; } 
        #endregion

        #region RecurringSaleLineManager
        private RecurringSaleLineManager mRecurringSaleLineMgr = null;
        public RecurringSaleLineManager RecurringSaleLineMgr
        {
            get
            {
                if (mRecurringSaleLineMgr == null)
                {
                    DbManager factory = RecurringSaleLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mRecurringSaleLineMgr = factory.CreateRecurringSaleLineMgr();
                }
                return mRecurringSaleLineMgr;
            }
        }
        public DbManager RecurringSaleLineMgrFactory { get; set; } 
        #endregion

        #region RecurringMiscSaleLineManager
        private RecurringMiscSaleLineManager mRecurringMiscSaleLineMgr = null;
        public RecurringMiscSaleLineManager RecurringMiscSaleLineMgr
        {
            get
            {
                if (mRecurringMiscSaleLineMgr == null)
                {
                    DbManager factory = RecurringMiscSaleLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mRecurringMiscSaleLineMgr = factory.CreateRecurringMiscSaleLineMgr();
                }
                return mRecurringMiscSaleLineMgr;
            }
        }
        public DbManager RecurringMiscSaleLineMgrFactory { get; set; } 
        #endregion

        #region RecurringProfessionalSaleLineManager
        private RecurringProfessionalSaleLineManager mRecurringProfessionalSaleLineMgr = null;
        public RecurringProfessionalSaleLineManager RecurringProfessionalSaleLineMgr
        {
            get
            {
                if (mRecurringProfessionalSaleLineMgr == null)
                {
                    DbManager factory = RecurringProfessionalSaleLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mRecurringProfessionalSaleLineMgr = factory.CreateRecurringProfessionalSaleLineMgr();
                }
                return mRecurringProfessionalSaleLineMgr;
            }
        }
        public DbManager RecurringProfessionalSaleLineMgrFactory { get; set; } 
        #endregion

        #region RecurringServiceSaleLineManager
        private RecurringServiceSaleLineManager mRecurringServiceSaleLineMgr = null;
        public RecurringServiceSaleLineManager RecurringServiceSaleLineMgr
        {
            get
            {
                if (mRecurringServiceSaleLineMgr == null)
                {
                    DbManager factory = RecurringServiceSaleLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mRecurringServiceSaleLineMgr = factory.CreateRecurringServiceSaleLineMgr();
                }
                return mRecurringServiceSaleLineMgr;
            }
        }
        public DbManager RecurringServiceSaleLineMgrFactory { get; set; } 
        #endregion

        #region RecurringTimeBillingSaleLineManager
        private RecurringTimeBillingSaleLineManager mRecurringTimeBillingSaleLineMgr = null;
        public RecurringTimeBillingSaleLineManager RecurringTimeBillingSaleLineMgr
        {
            get
            {
                if (mRecurringTimeBillingSaleLineMgr == null)
                {
                    DbManager factory = RecurringTimeBillingSaleLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mRecurringTimeBillingSaleLineMgr = factory.CreateRecurringTimeBillingSaleLineMgr();
                }
                return mRecurringTimeBillingSaleLineMgr;
            }
        }
        public DbManager RecurringTimeBillingSaleLineMgrFactory { get; set; } 
        #endregion

        #region RecurringItemSaleLineManager
        private RecurringItemSaleLineManager mRecurringItemSaleLineMgr = null;
        public RecurringItemSaleLineManager RecurringItemSaleLineMgr
        {
            get
            {
                if (mRecurringItemSaleLineMgr == null)
                {
                    DbManager factory = RecurringItemSaleLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mRecurringItemSaleLineMgr = factory.CreateRecurringItemSaleLineMgr();
                }
                return mRecurringItemSaleLineMgr;
            }
        }
        public DbManager RecurringItemSaleLineMgrFactory { get; set; } 
        #endregion
        #endregion

        #region Purchases
        #region PurchaseManager
        private PurchaseManager mPurchaseMgr = null;
        public PurchaseManager PurchaseMgr
        {
            get
            {
                if (mPurchaseMgr == null)
                {
                    DbManager factory = PurchaseMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mPurchaseMgr = factory.CreatePurchaseMgr();
                }
                return mPurchaseMgr;
            }
        }
        public DbManager PurchaseMgrFactory { get; set; } 
        #endregion

        #region PurchaseLineManager
        private PurchaseLineManager mPurchaseLineMgr = null;
        public PurchaseLineManager PurchaseLineMgr
        {
            get
            {
                if (mPurchaseLineMgr == null)
                {
                    DbManager factory = PurchaseLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mPurchaseLineMgr = factory.CreatePurchaseLineMgr();
                }
                return mPurchaseLineMgr;
            }
        }
        public DbManager PurchaseLineMgrFactory { get; set; } 
        #endregion

        #region ItemPurchaseLineManager
        private ItemPurchaseLineManager mItemPurchaseLineMgr = null;
        public ItemPurchaseLineManager ItemPurchaseLineMgr
        {
            get
            {
                if (mItemPurchaseLineMgr == null)
                {
                    DbManager factory = ItemPurchaseLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mItemPurchaseLineMgr = factory.CreateItemPurchaseLineMgr();
                }
                return mItemPurchaseLineMgr;
            }
        }
        public DbManager ItemPurchaseLineMgrFactory { get; set; } 
        #endregion

        #region MiscPurchaseLineManager
        private MiscPurchaseLineManager mMiscPurchaseLineMgr = null;
        public MiscPurchaseLineManager MiscPurchaseLineMgr
        {
            get
            {
                if (mMiscPurchaseLineMgr == null)
                {
                    DbManager factory = MiscPurchaseLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mMiscPurchaseLineMgr = factory.CreateMiscPurchaseLineMgr();
                }
                return mMiscPurchaseLineMgr;
            }
        }
        public DbManager MiscPurchaseLineMgrFactory { get; set; } 
        #endregion

        #region ProfessionalPurchaseLineManager
        private ProfessionalPurchaseLineManager mProfessionalPurchaseLineMgr = null;
        public ProfessionalPurchaseLineManager ProfessionalPurchaseLineMgr
        {
            get
            {
                if (mProfessionalPurchaseLineMgr == null)
                {
                    DbManager factory = ProfessionalPurchaseLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mProfessionalPurchaseLineMgr = factory.CreateProfessionalPurchaseLineMgr();
                }
                return mProfessionalPurchaseLineMgr;
            }
        }
        public DbManager ProfessionalPurchaseLineMgrFactory { get; set; } 
        #endregion

        #region ServicePurchaseLineManager
        private ServicePurchaseLineManager mServicePurchaseLineMgr = null;
        public ServicePurchaseLineManager ServicePurchaseLineMgr
        {
            get
            {
                if (mServicePurchaseLineMgr == null)
                {
                    DbManager factory = ServicePurchaseLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mServicePurchaseLineMgr = factory.CreateServicePurchaseLineMgr();
                }
                return mServicePurchaseLineMgr;
            }
        }
        public DbManager ServicePurchaseLineMgrFactory { get; set; } 
        #endregion

        #region TimeBillingPurchaseLineManager
        private TimeBillingPurchaseLineManager mTimeBillingPurchaseLineMgr = null;
        public TimeBillingPurchaseLineManager TimeBillingPurchaseLineMgr
        {
            get
            {
                if (mTimeBillingPurchaseLineMgr == null)
                {
                    DbManager factory = TimeBillingPurchaseLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mTimeBillingPurchaseLineMgr = factory.CreateTimeBillingPurchaseLineMgr();
                }
                return mTimeBillingPurchaseLineMgr;
            }
        }
        public DbManager TimeBillingPurchaseLineMgrFactory { get; set; } 
        #endregion
        #endregion

        #region RecurringPurchases
        #region RecurringPurchaseManager
        private RecurringPurchaseManager mRecurringPurchaseMgr = null;
        public RecurringPurchaseManager RecurringPurchaseMgr
        {
            get
            {
                if (mRecurringPurchaseMgr == null)
                {
                    DbManager factory = RecurringPurchaseMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mRecurringPurchaseMgr = factory.CreateRecurringPurchaseMgr();
                }
                return mRecurringPurchaseMgr;
            }
        }
        public DbManager RecurringPurchaseMgrFactory { get; set; } 
        #endregion

        #region RecurringPurchaseLineManager
        private RecurringPurchaseLineManager mRecurringPurchaseLineMgr = null;
        public RecurringPurchaseLineManager RecurringPurchaseLineMgr
        {
            get
            {
                if (mRecurringPurchaseLineMgr == null)
                {
                    DbManager factory = RecurringPurchaseLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mRecurringPurchaseLineMgr = factory.CreateRecurringPurchaseLineMgr();
                }
                return mRecurringPurchaseLineMgr;
            }
        }
        public DbManager RecurringPurchaseLineMgrFactory { get; set; } 
        #endregion

        #region RecurringMiscPurchaseLineManager
        private RecurringMiscPurchaseLineManager mRecurringMiscPurchaseLineMgr = null;
        public RecurringMiscPurchaseLineManager RecurringMiscPurchaseLineMgr
        {
            get
            {
                if (mRecurringMiscPurchaseLineMgr == null)
                {
                    DbManager factory = RecurringMiscPurchaseLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mRecurringMiscPurchaseLineMgr = factory.CreateRecurringMiscPurchaseLineMgr();
                }
                return mRecurringMiscPurchaseLineMgr;
            }
        }
        public DbManager RecurringMiscPurchaseLineMgrFactory { get; set; } 
        #endregion

        #region RecurringProfessionalPurchaseLineManager
        private RecurringProfessionalPurchaseLineManager mRecurringProfessionalPurchaseLineMgr = null;
        public RecurringProfessionalPurchaseLineManager RecurringProfessionalPurchaseLineMgr
        {
            get
            {
                if (mRecurringProfessionalPurchaseLineMgr == null)
                {
                    DbManager factory = RecurringProfessionalPurchaseLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mRecurringProfessionalPurchaseLineMgr = factory.CreateRecurringProfessionalPurchaseLineMgr();
                }
                return mRecurringProfessionalPurchaseLineMgr;
            }
        }
        public DbManager RecurringProfessionalPurchaseLineMgrFactory { get; set; } 
        #endregion

        #region RecurringServicePurchaseLineManager
        private RecurringServicePurchaseLineManager mRecurringServicePurchaseLineMgr = null;
        public RecurringServicePurchaseLineManager RecurringServicePurchaseLineMgr
        {
            get
            {
                if (mRecurringServicePurchaseLineMgr == null)
                {
                    DbManager factory = RecurringServicePurchaseLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mRecurringServicePurchaseLineMgr = factory.CreateRecurringServicePurchaseLineMgr();
                }
                return mRecurringServicePurchaseLineMgr;
            }
        }
        public DbManager RecurringServicePurchaseLineMgrFactory { get; set; } 
        #endregion

        #region RecurringTimeBillingPurchaseLineManager
        private RecurringTimeBillingPurchaseLineManager mRecurringTimeBillingPurchaseLineMgr = null;
        public RecurringTimeBillingPurchaseLineManager RecurringTimeBillingPurchaseLineMgr
        {
            get
            {
                if (mRecurringTimeBillingPurchaseLineMgr == null)
                {
                    DbManager factory = RecurringTimeBillingPurchaseLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mRecurringTimeBillingPurchaseLineMgr = factory.CreateRecurringTimeBillingPurchaseLineMgr();
                }
                return mRecurringTimeBillingPurchaseLineMgr;
            }
        }
        public DbManager RecurringTimeBillingPurchaseLineMgrFactory { get; set; } 
        #endregion

        #region RecurringItemPurchaseLineManager
        private RecurringItemPurchaseLineManager mRecurringItemPurchaseLineMgr = null;
        public RecurringItemPurchaseLineManager RecurringItemPurchaseLineMgr
        {
            get
            {
                if (mRecurringItemPurchaseLineMgr == null)
                {
                    DbManager factory = RecurringItemPurchaseLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mRecurringItemPurchaseLineMgr = factory.CreateRecurringItemPurchaseLineMgr();
                }
                return mRecurringItemPurchaseLineMgr;
            }
        }
        public DbManager RecurringItemPurchaseLineMgrFactory { get; set; } 
        #endregion
        #endregion

        #region TermsOfPaymentManager
        private TermsOfPaymentManager mTermsOfPaymentMgr = null;
        public TermsOfPaymentManager TermsOfPaymentMgr
        {
            get
            {
                if (mTermsOfPaymentMgr == null)
                {
                    DbManager factory = TermsOfPaymentMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mTermsOfPaymentMgr = factory.CreateTermsOfPaymentMgr();
                }
                return mTermsOfPaymentMgr;
            }
        }
        public DbManager TermsOfPaymentMgrFactory { get; set; } 
        #endregion

        private ShippingMethodManager mShippingMethodMgr = null;
        public ShippingMethodManager ShippingMethodMgr
        {
            get
            {
                if (mShippingMethodMgr == null)
                {
                    DbManager factory = ShippingMethodMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mShippingMethodMgr = factory.CreateShippingMethodMgr();
                }
                return mShippingMethodMgr;
            }
        }
        public DbManager ShippingMethodMgrFactory { get; set; } 

        private CurrencyManager mCurrencyMgr = null;
        public CurrencyManager CurrencyMgr
        {
            get
            {
                if (mCurrencyMgr == null)
                {
                    DbManager factory = CurrencyMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mCurrencyMgr = factory.CreateCurrencyMgr();
                }
                return mCurrencyMgr;
            }
        }
        public DbManager CurrencyMgrFactory { get; set; } 

        private JournalTypeManager mJournalTypeMgr = null;
        public JournalTypeManager JournalTypeMgr
        {
            get
            {
                if (mJournalTypeMgr == null)
                {
                    DbManager factory = JournalTypeMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mJournalTypeMgr = factory.CreateJournalTypeMgr();
                }
                return mJournalTypeMgr;
            }
        }
        public DbManager JournalTypeMgrFactory { get; set; } 

        private LocationManager mLocationMgr = null;
        public LocationManager LocationMgr
        {
            get
            {
                if (mLocationMgr == null)
                {
                    DbManager factory = LocationMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mLocationMgr = factory.CreateLocationMgr();
                }
                return mLocationMgr;
            }
        }
        public DbManager LocationMgrFactory { get; set; } 

        private CommentManager mCommentMgr = null;
        public CommentManager CommentMgr
        {
            get
            {
                if (mCommentMgr == null)
                {
                    DbManager factory = CommentMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mCommentMgr = factory.CreateCommentMgr();
                }
                return mCommentMgr;
            }
        }
        public DbManager CommentMgrFactory { get; set; }

        private CustomListManager mCustomListMgr = null;
        public CustomListManager CustomListMgr
        {
            get
            {
                if (mCustomListMgr == null)
                {
                    DbManager factory = CustomListMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mCustomListMgr = factory.CreateCustomListMgr();
                }
                return mCustomListMgr;
            }
        }
        public DbManager CustomListMgrFactory { get; set; } 

        private SupplierManager mSupplierMgr = null;
        public SupplierManager SupplierMgr
        {
            get
            {
                if (mSupplierMgr == null)
                {
                    DbManager factory = SupplierMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mSupplierMgr = factory.CreateSupplierMgr();
                }
                return mSupplierMgr;
            }
        }
        public DbManager SupplierMgrFactory { get; set; } 

        private TermsManager mTermsMgr = null;
        public TermsManager TermsMgr
        {
            get
            {
                if (mTermsMgr == null)
                {
                    DbManager factory = TermsMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mTermsMgr = factory.CreateTermsMgr();
                }
                return mTermsMgr;
            }
        }
        public DbManager TermsMgrFactory { get; set; } 



        private StatusManager mStatusMgr = null;
        public StatusManager StatusMgr
        {
            get
            {
                if (mStatusMgr == null)
                {
                    DbManager factory = StatusMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mStatusMgr = factory.CreateStatusMgr();
                }
                return mStatusMgr;
            }
        }
        public DbManager StatusMgrFactory { get; set; } 

        private InvoiceDeliveryManager mInvoiceDeliveryMgr = null;
        public InvoiceDeliveryManager InvoiceDeliveryMgr
        {
            get
            {
                if (mInvoiceDeliveryMgr == null)
                {
                    DbManager factory = InvoiceDeliveryMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mInvoiceDeliveryMgr = factory.CreateInvoiceDeliveryMgr();
                }
                return mInvoiceDeliveryMgr;
            }
        }
        public DbManager InvoiceDeliveryMgrFactory { get; set; } 

        private ItemManager mItemMgr = null;
        public ItemManager ItemMgr
        {
            get
            {
                if (mItemMgr == null)
                {
                    DbManager factory = ItemMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mItemMgr = factory.CreateItemMgr();
                }
                return mItemMgr;
            }
        }
        public DbManager ItemMgrFactory { get; set; } 

        private AuthRoleManager mAuthRoleMgr = null;
        public AuthRoleManager AuthRoleMgr
        {
            get
            {
                if (mAuthRoleMgr == null)
                {
                    DbManager factory = AuthRoleMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mAuthRoleMgr = factory.CreateAuthRoleMgr();
                }
                return mAuthRoleMgr;
            }
        }
        public DbManager AuthRoleMgrFactory { get; set; } 

        private AuthUserManager mAuthUserMgr = null;
        public AuthUserManager AuthUserMgr
        {
            get
            {
                if (mAuthUserMgr == null)
                {
                    DbManager factory = AuthUserMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mAuthUserMgr = factory.CreateAuthUserMgr();
                }
                return mAuthUserMgr;
            }
        }
        public DbManager AuthUserMgrFactory { get; set; } 

        private AuthItemManager mAuthItemMgr = null;
        public AuthItemManager AuthItemMgr
        {
            get
            {
                if (mAuthItemMgr == null)
                {
                    DbManager factory = AuthItemMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mAuthItemMgr = factory.CreateAuthItemMgr();
                }
                return mAuthItemMgr;
            }
        }
        public DbManager AuthItemMgrFactory { get; set; } 

        private TaxCodeManager mTaxCodeMgr = null;
        public TaxCodeManager TaxCodeMgr
        {
            get
            {
                if (mTaxCodeMgr == null)
                {
                    DbManager factory = TaxCodeMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mTaxCodeMgr = factory.CreateTaxCodeMgr();
                }
                return mTaxCodeMgr;
            }
        }
        public DbManager TaxCodeMgrFactory { get; set; } 

        private CustomerManager mCustomerMgr = null;
        public CustomerManager CustomerMgr
        {
            get
            {
                if (mCustomerMgr == null)
                {
                    DbManager factory = CustomerMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mCustomerMgr = factory.CreateCustomerMgr();
                }
                return mCustomerMgr;
            }
        }
        public DbManager CustomerMgrFactory { get; set; } 

        private AccountTypeManager mAccountTypeMgr = null;
        public AccountTypeManager AccountTypeMgr
        {
            get
            {
                if (mAccountTypeMgr == null)
                {
                    DbManager factory = AccountTypeMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mAccountTypeMgr = factory.CreateAccountTypeMgr();
                }
                return mAccountTypeMgr;
            }
        }
        public DbManager AccountTypeMgrFactory { get; set; } 

        private SubAccountTypeManager mSubAccountTypeMgr = null;
        public SubAccountTypeManager SubAccountTypeMgr
        {
            get
            {
                if (mSubAccountTypeMgr == null)
                {
                    DbManager factory = SubAccountTypeMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mSubAccountTypeMgr = factory.CreateSubAccountTypeMgr();
                }
                return mSubAccountTypeMgr;
            }
        }
        public DbManager SubAccountTypeMgrFactory { get; set; } 

        private AccountClassificationManager mAccountClassificationMgr = null;
        public AccountClassificationManager AccountClassificationMgr
        {
            get
            {
                if (mAccountClassificationMgr == null)
                {
                    DbManager factory = AccountClassificationMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mAccountClassificationMgr = factory.CreateAccountClassificationMgr();
                }
                return mAccountClassificationMgr;
            }
        }
        public DbManager AccountClassificationMgrFactory { get; set; } 

        private CashFlowClassificationManager mCashFlowClassificationMgr = null;
        public CashFlowClassificationManager CashFlowClassificationMgr
        {
            get
            {
                if (mCashFlowClassificationMgr == null)
                {
                    DbManager factory = CashFlowClassificationMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mCashFlowClassificationMgr = factory.CreateCashFlowClassificationMgr();
                }
                return mCashFlowClassificationMgr;
            }
        }
        public DbManager CashFlowClassificationMgrFactory { get; set; } 

        private GeneralJournalLineManager mGeneralJournalLineMgr = null;
        public GeneralJournalLineManager GeneralJournalLineMgr
        {
            get
            {
                if (mGeneralJournalLineMgr == null)
                {
                    DbManager factory = GeneralJournalLineMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mGeneralJournalLineMgr = factory.CreateGeneralJournalLineMgr();
                }
                return mGeneralJournalLineMgr;
            }
        }
        public DbManager GeneralJournalLineMgrFactory { get; set; } 

        private EmployeeManager mEmployeeMgr = null;
        public EmployeeManager EmployeeMgr
        {
            get
            {
                if (mEmployeeMgr == null)
                {
                    DbManager factory = EmployeeMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mEmployeeMgr = factory.CreateEmployeeMgr();
                }
                return mEmployeeMgr;
            }
        }
        public DbManager EmployeeMgrFactory { get; set; } 

        private PriceLevelManager mPriceLevelMgr = null;
        public PriceLevelManager PriceLevelMgr
        {
            get
            {
                if (mPriceLevelMgr == null)
                {
                    DbManager factory = PriceLevelMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mPriceLevelMgr = factory.CreatePriceLevelMgr();
                }
                return mPriceLevelMgr;
            }
        }
        public DbManager PriceLevelMgrFactory { get; set; } 

        private AccountManager mAccountMgr = null;
        public AccountManager AccountMgr
        {
            get
            {
                if (mAccountMgr == null)
                {
                    DbManager factory = AccountMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mAccountMgr = factory.CreateAccountMgr();
                }
                return mAccountMgr;
            }
        }
        public DbManager AccountMgrFactory { get; set; } 

        private InvoiceTypeManager mInvoiceTypeMgr = null;
        public InvoiceTypeManager InvoiceTypeMgr
        {
            get
            {
                if (mInvoiceTypeMgr == null)
                {
                    DbManager factory = InvoiceTypeMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mInvoiceTypeMgr = factory.CreateInvoiceTypeMgr();
                }
                return mInvoiceTypeMgr;
            }
        }
        public DbManager InvoiceTypeMgrFactory { get; set; } 



        private AddressManager mAddressMgr = null;
        public AddressManager AddressMgr
        {
            get
            {
                if (mAddressMgr == null)
                {
                    DbManager factory = AddressMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mAddressMgr = factory.CreateAddressMgr();
                }
                return mAddressMgr;
            }
        }
        public DbManager AddressMgrFactory { get; set; } 

        private CardTypeManager mCardTypeMgr = null;
        public CardTypeManager CardTypeMgr
        {
            get
            {
                if (mCardTypeMgr == null)
                {
                    DbManager factory = CardTypeMgrFactory;
                    factory = (factory == null ? DefaultMgrFactory : factory);
                    mCardTypeMgr = factory.CreateCardTypeMgr();
                }
                return mCardTypeMgr;
            }
        }
        public DbManager CardTypeMgrFactory { get; set; } 
    }
}
