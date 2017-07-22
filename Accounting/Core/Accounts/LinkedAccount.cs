using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Accounts
{
    public class LinkedAccount : Entity
    {
        public enum LinkAccountType
        {
            Unlinked,
            CurrentEarnings,
            RetainedEarnings,
            HistoricalBalancing,
            ElectronicPayments,
            UndepositedFunds,
            CurrencyGainLoss,
            ReceivablesAccount,
            ReceivablesFreight,
            ReceivablesDeposits,
            ReceivablesDiscounts,
            ReceivablesLateFees,
            PayablesAccount,
            PayablesCheque,
            PayablesFreight,
            PayablesDeposits,
            PayablesDiscounts,
            PayablesLateFees,
            PayrollCash,
            PayrollCheque,
            EmployerExpense,
            WagesExpense,
            WithholdingPayable,
            PayablesInventory
        }

        private Dictionary<int?, LinkAccountType> mLinkedAccounts = new Dictionary<int?, LinkAccountType>();

        public Account GetAccount(LinkAccountType type)
        {
            return RepositoryMgr.AccountMgr.GetLinkedAccount(type.ToString());
        }

        public bool Contains(Account acc, out LinkAccountType type)
        {
            type = LinkAccountType.Unlinked;
            bool contained = mLinkedAccounts.ContainsKey(acc.AccountID);
            if (contained)
            {
                type = mLinkedAccounts[acc.AccountID];
            }
            return contained;
        }

        internal LinkedAccount(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

      

        private int? mLinkedAccountID;
        private int? mCurrentEarningsID;
        private int? mRetainedEarningsID;
        private int? mHistoricalBalancingID;
        private int? mElectronicPaymentsID;
        private int? mUndepositedFundsID;
        private int? mCurrencyGainLossID;
        private int? mReceivablesAccountID;
        private int? mReceivablesFreightID;
        private int? mReceivablesDepositsID;
        private int? mReceivablesDiscountsID;
        private int? mReceivablesLateFeesID;
        private int? mPayablesAccountID;
        private int? mPayablesChequeID;
        private int? mPayablesFreightID;
        private int? mPayablesDepositsID;
        private int? mPayablesDiscountsID;
        private int? mPayablesLateFeesID;
        private int? mPayrollCashID;
        private int? mPayrollChequeID;
        private int? mEmployerExpenseID;
        private int? mWagesExpenseID;
        private int? mWithholdingPayableID;
        public string ChangeControl;
        private int? mPayablesInventoryID;

        public int? LinkedAccountID
        {
            get { return mLinkedAccountID; }
            set 
            { 
                mLinkedAccountID = value;
                NotifyPropertyChanged("LinkedAccountID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("LinkedAccountID", LinkedAccountID);
            }
        }

        public int? CurrentEarningsID
        {
            get { return mCurrentEarningsID; }
            set
            {
                if (value != null)
                {
                    mLinkedAccounts[value] = LinkAccountType.CurrentEarnings;
                }
                mCurrentEarningsID = value;
                NotifyPropertyChanged("CurrentEarningsID");
            }
        }

        public int? RetainedEarningsID
        {
            get { return mRetainedEarningsID; }
            set
            {
                if (value != null)
                {
                    mLinkedAccounts[value] = LinkAccountType.RetainedEarnings;
                }
                mRetainedEarningsID = value;
                NotifyPropertyChanged("RetainedEarningsID");
            }
        }



        public int? HistoricalBalancingID
        {
            get { return mHistoricalBalancingID; }
            set
            {
                if (value != null)
                {
                    mLinkedAccounts[value] = LinkAccountType.HistoricalBalancing;
                }
                mHistoricalBalancingID = value;
                NotifyPropertyChanged("HistoricalBalancingID");
            }
        }

        public int? ElectronicPaymentsID
        {
            get { return mElectronicPaymentsID; }
            set
            {
                if (value != null)
                {
                    mLinkedAccounts[value] = LinkAccountType.ElectronicPayments;
                }
                mElectronicPaymentsID = value;
                NotifyPropertyChanged("ElectronicPaymentsID");
            }
        }

        public int? UndepositedFundsID
        {
            get { return mUndepositedFundsID; }
            set
            {
                if (value != null)
                {
                    mLinkedAccounts[value] = LinkAccountType.UndepositedFunds;
                }
                mUndepositedFundsID = value;
                NotifyPropertyChanged("UndepositedFundsID");
            }
        }

        public int? CurrencyGainLossID
        {
            get { return mCurrencyGainLossID; }
            set
            {
                if (value != null)
                {
                    mLinkedAccounts[value] = LinkAccountType.CurrencyGainLoss;
                }
                mCurrencyGainLossID = value;
                NotifyPropertyChanged("CurrencyGainLossID");
            }
        }

        public int? ReceivablesAccountID
        {
            get { return mReceivablesAccountID; }
            set
            {
                if (value != null)
                {
                    mLinkedAccounts[value] = LinkAccountType.ReceivablesAccount;
                }
                mReceivablesAccountID = value;
                NotifyPropertyChanged("ReceivablesAccountID");
            }
        }

        public int? ReceivablesFreightID
        {
            get { return mReceivablesFreightID; }
            set
            {
                if (value != null)
                {
                    mLinkedAccounts[value] = LinkAccountType.ReceivablesFreight;
                }
                mReceivablesFreightID = value;
                NotifyPropertyChanged("ReceivablesFreightID");
            }
        }

        public int? ReceivablesDepositsID
        {
            get { return mReceivablesDepositsID; }
            set
            {
                if (value != null)
                {
                    mLinkedAccounts[value] = LinkAccountType.ReceivablesDeposits;
                }
                mReceivablesDepositsID = value;
                NotifyPropertyChanged("ReceivablesDepositsID");
            }
        }

        public int? ReceivablesDiscountsID
        {
            get { return mReceivablesDiscountsID; }
            set
            {
                if (value != null)
                {
                    mLinkedAccounts[value] = LinkAccountType.ReceivablesDiscounts;
                }
                mReceivablesDiscountsID = value;
                NotifyPropertyChanged("ReceivablesDiscountsID");
            }
        }

        public int? ReceivablesLateFeesID
        {
            get { return mReceivablesLateFeesID; }
            set
            {
                if (value != null)
                {
                    mLinkedAccounts[value] = LinkAccountType.ReceivablesLateFees;
                }
                mReceivablesLateFeesID = value;
                NotifyPropertyChanged("ReceivablesLateFeesID");
            }
        }

        public int? PayablesAccountID
        {
            get { return mPayablesAccountID; }
            set
            {
                if (value != null)
                {
                    mLinkedAccounts[value] = LinkAccountType.PayablesAccount;
                }
                mPayablesAccountID = value;
                NotifyPropertyChanged("PayablesAccountID");
                
            }
        }

        public int? PayablesChequeID
        {
            get { return mPayablesChequeID; }
            set
            {
                mPayablesChequeID = value;
                if (value != null)
                {
                    mLinkedAccounts[value] = LinkAccountType.PayablesCheque;
                }
                NotifyPropertyChanged("PayablesChequeID");
            }
        }

        public int? PayablesFreightID
        {
            get { return mPayablesFreightID; }
            set
            {
                if (value != null)
                {
                    mLinkedAccounts[value] = LinkAccountType.PayablesFreight;
                }
                mPayablesFreightID = value;
                NotifyPropertyChanged("PayablesFreightID");
            }
        }

        public int? PayablesDepositsID
        {
            get { return mPayablesDepositsID; }
            set
            {
                mPayablesDepositsID = value;
                if (value != null)
                {
                    mLinkedAccounts[value] = LinkAccountType.PayablesDeposits;
                }
                NotifyPropertyChanged("PayablesDepositsID");
            }
        }

        public int? PayablesDiscountsID
        {
            get { return mPayablesDiscountsID; }
            set
            {
                mPayablesDiscountsID = value;
                if (value != null)
                {
                    mLinkedAccounts[value] = LinkAccountType.PayablesDiscounts;
                }
                NotifyPropertyChanged("PayablesDiscountsID");
            }
        }

        public int? PayablesLateFeesID
        {
            get { return mPayablesLateFeesID; }
            set
            {
                if (value != null)
                {
                    mLinkedAccounts[value] = LinkAccountType.PayablesLateFees;
                }
                mPayablesLateFeesID = value;
                NotifyPropertyChanged("PayablesLateFeesID");
            }
        }

        public int? PayrollCashID
        {
            get { return mPayrollCashID; }
            set
            {
                mPayrollCashID = value;
                if (value != null)
                {
                    mLinkedAccounts[value] = LinkAccountType.PayrollCash;
                }
                NotifyPropertyChanged("PayrollCashID");
            }
        }

        public int? PayrollChequeID
        {
            get { return mPayrollChequeID; }
            set
            {
                mPayrollChequeID = value;
                if (value != null)
                {
                    mLinkedAccounts[value] = LinkAccountType.PayrollCheque;
                }
                NotifyPropertyChanged("PayrollChequeID");
            }
        }

        public int? EmployerExpenseID
        {
            get { return mEmployerExpenseID; }
            set
            {
                mEmployerExpenseID = value;
                if (value != null)
                {
                    mLinkedAccounts[value] = LinkAccountType.EmployerExpense;
                }
                NotifyPropertyChanged("EmployerExpenseID");
            }
        }

        public int? WagesExpenseID
        {
            get { return mWagesExpenseID; }
            set
            {
                mWagesExpenseID = value;
                if (value != null)
                {
                    mLinkedAccounts[value] = LinkAccountType.WagesExpense;
                }
                NotifyPropertyChanged("WagesExpenseID");
            }
        }

        public int? WithholdingPayableID
        {
            get { return mWithholdingPayableID; }
            set
            {
                mWithholdingPayableID = value;
                if (value != null)
                {
                    mLinkedAccounts[value] = LinkAccountType.WithholdingPayable;
                }
                NotifyPropertyChanged("WithholdingPayableID");
            }
        }

        public int? PayablesInventoryID
        {
            get { return mPayablesInventoryID; }
            set
            {
                mPayablesInventoryID = value;
                if (value != null)
                {
                    mLinkedAccounts[value] = LinkAccountType.PayablesInventory;
                }
                NotifyPropertyChanged("PayablesInventoryID");
            }
        }
    }
}
