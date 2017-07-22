
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Inventory
{
    using Accounting.Core;
    using Accounting.Core.Inventory;
    public class BOInventoryAdjustment : BusinessObject
    {
        private InventoryAdjustment mDataProxy = null;
        private InventoryAdjustment mDataSource = null;

        public static readonly string INVENTORY_JOURNAL_NUMBER="InventoryJournalNumber";
        public static readonly string ADJUSTMENT_DATE = "AdjustmentDate";
        public static readonly string MEMO = "Memo";

        public bool Memo_Validate(object value, ref string error)
        {
            if (value is string)
            {
                string _obj = value as string;
                if (IsWithinRange(MEMO, 0, 255, out error))
                {
                    return true;
                }
                error = DecorateError(MEMO, error);
            }
            else
            {
                error = DecorateTypeMismatchError(MEMO, "string");
            }
            return true;
        }

        #region AdjustmentDate
        public bool AdjustmentDate_Validate(object value, ref string error)
        {
            if (value == null)
            {
                return true;
            }
            else if (value is DateTime?)
            {
                return true;
            }

            error = DecorateTypeMismatchError(ADJUSTMENT_DATE, "DateTime?");
            return false;
        }
        public bool AdjustmentDate_IsVisible()
        {
            return true;
        }

        public void AdjustmentDate_Set(object value)
        {
            if (value == null)
            {
                mDataProxy.Date = null;
            }
            else
            {
                mDataProxy.Date = (DateTime?)value;
            }
        }
        public object AdjustmentDate_Get()
        {
            return mDataProxy.Date;
        }
        public bool AdjustmentDate_IsEnabled()
        {
            return CanEdit;
        }
        #endregion

        #region InventoryJournalNumber
        public object InventoryJournalNumber_Get()
        {
            if (this.RecordContext == BusinessObject.BOContext.Record_Create)
            {
                return mAccountant.GenerateInventoryJournalNumber();
            }
            return mDataProxy.InventoryJournalNumber;
        }
        public bool InventoryJournalNumber_Validate(object value, ref string error)
        {
            if (value is string)
            {
                if (IsAlphaNumeric(value as string, 1, 8, out error))
                {
                    if (this.RecordContext == BOContext.Record_Create)
                    {
                        if (mAccountant.InventoryAdjustmentMgr.ExistsByInventoryJournalNumber(value as string))
                        {
                            error = DecorateEntityAlreadyExistError(INVENTORY_JOURNAL_NUMBER, value as string);
                            return false;
                        }
                    }
                    return true;
                }
                error = DecorateError(INVENTORY_JOURNAL_NUMBER, error);
                return false;
            }
            else
            {
                error = DecorateTypeMismatchError(INVENTORY_JOURNAL_NUMBER, "string");
                return false;
            }
        }
        public bool InventoryJournalNumber_IsVisible()
        {
            return true;
        }
        public void InventoryJournalNumber_Set(object value)
        {
            mDataProxy.InventoryJournalNumber = (string)value;
        }
        public bool InventoryJournalNumber_IsEnabled()
        {
            return CanEdit;
        }
        #endregion

        public BOInventoryAdjustment(Accountant accountant, InventoryAdjustment data, BOContext _state)
            : base(accountant, _state)
        {
            mObjectID = BOType.BOAdjustInventory;
            mDataSource = data;
            mDataProxy = mDataSource.Clone() as InventoryAdjustment;
            mAccountant.InventoryAdjustmentMgr.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(InventoryAdjustmentMgr_PropertyChanged);
        }

        protected override void InitializeProperties()
        {
            base.InitializeProperties();

            AddProperty(MEMO,
              MEMO,
              delegate() { return mDataProxy.Memo; },
              delegate(object value) { mDataProxy.Memo = (string)value; },
              delegate() { return CanEdit; },
              delegate() { return true; },
              Memo_Validate);

            AddProperty(ADJUSTMENT_DATE,
             ADJUSTMENT_DATE,
             AdjustmentDate_Get,
             AdjustmentDate_Set,
             AdjustmentDate_IsEnabled,
             AdjustmentDate_IsVisible,
             AdjustmentDate_Validate);

            AddProperty(INVENTORY_JOURNAL_NUMBER,
              INVENTORY_JOURNAL_NUMBER,
              InventoryJournalNumber_Get,
              InventoryJournalNumber_Set,
              InventoryJournalNumber_IsEnabled,
              InventoryJournalNumber_IsVisible,
              InventoryJournalNumber_Validate);
        }

        void InventoryAdjustmentMgr_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateContent();
            NotifyPropertyChanged(e.PropertyName);
        }

        protected override void UpdateContent()
        {
            InventoryAdjustment discovered = mDataSource.Discover() as InventoryAdjustment;
            if (discovered != null)
            {
                mDataSource = discovered;
                mDataProxy = mDataSource.Clone() as InventoryAdjustment;
                mDataProxy.Evaluate();
            }
        }

        protected override OpResult _Record()
        {
            mDataSource.AssignFrom(mDataProxy);
            OpResult result = mAccountant.InventoryAdjustmentMgr.Store(mDataSource);
            return result;
        }


        public IList<InventoryAdjustmentLine> Lines
        {
            get { return mDataProxy.Lines; }
        }

        public InventoryAdjustment Data
        {
            get { return mDataProxy; }
        }
    }
}
