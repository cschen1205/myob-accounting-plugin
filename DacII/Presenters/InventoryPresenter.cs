using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacII.Presenters
{
    using DacII.WinForms;
    using DacII.WinForms.Inventory;

    using Accounting.Bll;
    using Accounting.Bll.Inventory;
    using DacII.WinForms.Reports.Inventory.Items;

    public class InventoryPresenter : ModulePresenter
    {
        public InventoryPresenter(ApplicationPresenter ap, FrmDac shell)
            : base(ap, shell)
        {
           
        }

        private DacII.WinForms.Inventory.FrmItemDataFieldEntry mFrmItemDataFieldEntry = null;
        public void ShowItemDataFieldEntry(BOItemDataFieldEntry dfe)
        {
            if (dfe == null) return;
            if (IsInvalid(mFrmItemDataFieldEntry))
            {
                mFrmItemDataFieldEntry = new FrmItemDataFieldEntry(mApplicationController, dfe);
            }
            else
            {
                mFrmItemDataFieldEntry.Model = dfe;
                mFrmItemDataFieldEntry.UpdateView();
            }
            SetCurrentDlg(mFrmItemDataFieldEntry);
        }

        private DacII.WinForms.Inventory.FrmItemsList mFrmItemsList = null;
        public void ShowItems(BOItemsList model)
        {
            if (IsInvalid(mFrmItemsList))
            {
                mFrmItemsList = new DacII.WinForms.Inventory.FrmItemsList(mApplicationController, model);
            }
            SetCurrentForm(mFrmItemsList);
        }

        private DacII.WinForms.Inventory.FrmItemInformation mFrmItem = null;
        public void ShowItem(BOItem model)
        {
            if (model == null) return;
            if (IsInvalid(mFrmItem))
            {
                mFrmItem = new DacII.WinForms.Inventory.FrmItemInformation(mApplicationController, model);
            }
            else
            {
                mFrmItem.Model = model;
                mFrmItem.UpdateView();
            }
            
            SetCurrentForm(mFrmItem);
        }

        private DacII.WinForms.Inventory.FrmItemRegister mItemsRegister = null;
        public void ShowRegisterForItems(BOItemsRegister model)
        {
            if (mApplicationController.CheckAccess(BOType.BOListItem, BOPropertyAttrType.Visible))
            {
                if (IsInvalid(mItemsRegister))
                {
                    mItemsRegister = new DacII.WinForms.Inventory.FrmItemRegister(mApplicationController, model);
                }
                SetCurrentForm(mItemsRegister);
            }
        }

        private FrmItemsListSummary mFrmItemsListSummary = null;
        internal void ShowItemsListSummaryRpt()
        {
            if (IsInvalid(mFrmItemsListSummary))
            {
                mFrmItemsListSummary = new FrmItemsListSummary(mApplicationController);
            }
            SetCurrentForm(mFrmItemsListSummary);
        }

        private FrmItemsRegisterSummary mFrmItemsRegisterSummary = null;
        internal void ShowItemsRegisterSummaryRpt()
        {
            if (IsInvalid(mFrmItemsRegisterSummary))
            {
                mFrmItemsRegisterSummary = new FrmItemsRegisterSummary(mApplicationController);
            }
            SetCurrentForm(mFrmItemsRegisterSummary);
        }

        private FrmInventoryAdjustment mFrmInventoryAdjustment = null;
        internal void ShowInventoryAdjustment(BOInventoryAdjustment model)
        {
            if (IsInvalid(mFrmInventoryAdjustment))
            {
                mFrmInventoryAdjustment = new FrmInventoryAdjustment(mApplicationController, model);
            }
            SetCurrentForm(mFrmInventoryAdjustment);
        }

        internal bool ShowInventoryAdjustmentLine(BOInventoryAdjustmentLine model)
        {
            FrmInventoryAdjustmentLine frm = new FrmInventoryAdjustmentLine(mApplicationController, model);
            return SetCurrentDlg(frm);
        }
    }
}
