using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Inventory
{
    using System.ComponentModel;
    public class InventoryAdjustment : Entity
    {
        internal InventoryAdjustment(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        internal bool Match(DateTime? start, DateTime? end)
        {
           
            if (Date != null)
            {
                if (start != null)
                {
                    if (Date.Value < start.Value)
                    {
                        return false;
                    }
                }
                if (end != null)
                {
                    if (Date.Value > end.Value)
                    {
                        return false;
                    }
                }
            }

            return true;

        }

        internal bool IsHandlingItem(Item _item)
        {
            if (_item == null) return true;
            foreach (InventoryAdjustmentLine _line in Lines)
            {
                if (_line.Item == _item)
                {
                    return true;
                }
            }
            return false;
        }

        

        private int? mInventoryAdjustmentID;
        public int? InventoryAdjustmentID
        {
            get { return mInventoryAdjustmentID; }
            set
            {
                mInventoryAdjustmentID = value;
                NotifyPropertyChanged("InventoryAdjustmentID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("InventoryAdjustmentID", InventoryAdjustmentID);
            }
        }

        private string mInventoryJournalNumber = "";
        public string InventoryJournalNumber
        {
            get { return mInventoryJournalNumber; }
            set
            {
                mInventoryJournalNumber = value;
                NotifyPropertyChanged("InventoryJournalNumber");
            }
        }

        private DateTime? mDate;
        public DateTime? Date
        {
            get { return mDate; }
            set
            {
                mDate = value;
                NotifyPropertyChanged("Date");
            }
        }

        private DateTime? mTransactionDate;
        public DateTime? TransactionDate
        {
            get { return mTransactionDate; }
            set
            {
                mTransactionDate = value;
                NotifyPropertyChanged("TransactionDate");
            }
        }

        private string mIsThirteenthPeriod = "N";
        public string IsThirteenthPeriod
        {
            get { return mIsThirteenthPeriod; }
            set
            {
                mIsThirteenthPeriod = value;
                NotifyPropertyChanged("IsThirteenthPeriod");
            }
        }

        private string mMemo = "";
        public string Memo
        {
            get { return mMemo; }
            set
            {
                mMemo = value;
                NotifyPropertyChanged("Memo");
            }
        }

        private string mIsTaxInclusive = "";
        public string IsTaxInclusive
        {
            get { return mIsTaxInclusive; }
            set
            {
                mIsTaxInclusive = value;
                NotifyPropertyChanged("IsTaxInclusive");
            }
        }

        #region Currency
        private Currencies.Currency mCurrency = null;
        public Currencies.Currency Currency
        {
            get
            {
                if (mCurrency == null)
                {
                    mCurrency = (Currencies.Currency)BuildProperty(this, "Currency");
                }
                return mCurrency;
            }
            set
            {
                mCurrency = value;
                NotifyPropertyChanged("Currency");
            }
        }
        private int? mCurrencyID;
        public int? CurrencyID
        {
            get
            {
                if (mCurrency != null)
                {
                    return mCurrency.CurrencyID;
                }
                return mCurrencyID;
            }
            set
            {
                mCurrencyID = value;
                NotifyPropertyChanged("CurrencyID");
            }
        }
        #endregion

        private int? mCostCentreID;
        public int? CostCentreID
        {
            get { return mCostCentreID; }
            set
            {
                mCostCentreID = value;
                NotifyPropertyChanged("CostCentreID");
            }
        }

        private double mTransactionExchangeRate;
        public double TransactionExchangeRate
        {
            get { return mTransactionExchangeRate; }
            set
            {
                mTransactionExchangeRate = value;
                NotifyPropertyChanged("TransactionExchangeRate");
            }
        }

        private BindingList<InventoryAdjustmentLine> mLines = null;
        public BindingList<InventoryAdjustmentLine> Lines
        {
            get
            {
                if (mLines == null)
                {
                    mLines = new BindingList<InventoryAdjustmentLine>();
                    IList<InventoryAdjustmentLine> _lines = RepositoryMgr.InventoryAdjustmentLineMgr.FindCollectionByInventoryAdjustment(this);
                    foreach (InventoryAdjustmentLine _line in _lines)
                    {
                        mLines.Add(_line);
                    }
                }
                return mLines;
            }
        }

        public override void AssignFrom(Accounting.Core.Entity rhs)
        {
            base.AssignFrom(rhs);

            InventoryAdjustment _obj = rhs as InventoryAdjustment;

            mLines = new BindingList<InventoryAdjustmentLine>();

            foreach (InventoryAdjustmentLine _line in _obj.Lines)
            {
                InventoryAdjustmentLine new_line = _line.Clone() as InventoryAdjustmentLine;
                new_line.InventoryAdjustment = this;
                mLines.Add(new_line);
            }
        }

        public void Evaluate()
        {

        }
    }
}
