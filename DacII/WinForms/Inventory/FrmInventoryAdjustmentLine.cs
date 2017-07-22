using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DacII.WinForms.Inventory
{
    using DacII.Presenters;
    using DacII.ViewModels;
    using Accounting.Bll.Inventory;
    using Accounting.Core.Inventory;

    public partial class FrmInventoryAdjustmentLine : BaseView
    {
        private BOInventoryAdjustmentLine mModel = null;
        private BOViewModel mViewModel;

        public FrmInventoryAdjustmentLine(ApplicationPresenter ap, BOInventoryAdjustmentLine model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;
            mViewModel = new BOViewModel(mModel);
            mViewModel.ErrorProvider = errorProvider;

            BindViews();
            RegisterEventHandlers();
        }

        public BOInventoryAdjustmentLine Model
        {
            set
            {
                mModel = value;
                mViewModel.Model = value;
            }
        }

        protected override void BindViews()
        {
            base.BindViews();

            cboItem.DataSource = mApplicationController.FindAllSoldItems();
            cboAccount.DataSource = mApplicationController.FindAllAccounts();
            cboJob.DataSource = mApplicationController.FindAllJobs();

            mViewModel.BindView(BOInventoryAdjustmentLine.ITEM, lblItem, cboItem);
            mViewModel.BindView(BOInventoryAdjustmentLine.ACCOUNT, lblAccount, cboAccount);
            mViewModel.BindView(BOInventoryAdjustmentLine.JOB, lblJob, cboJob);
            mViewModel.BindView(BOInventoryAdjustmentLine.UNIT_COST, lblUnitCost, txtUnitCost);
            mViewModel.BindView(BOInventoryAdjustmentLine.QUANTITY, lblQuantity, txtQuantity);
            mViewModel.BindView(BOInventoryAdjustmentLine.MEMO, lblMemo, txtMemo);
            mViewModel.BindView(BOInventoryAdjustmentLine.PERSIST_OBJECT, btnOK);
            mViewModel.BindView(BOInventoryAdjustmentLine.AMOUNT, lblAmount, txtAmount);
        }

        private void OnItemChanged(object sender, EventArgs args)
        {
            if (cboItem.SelectedIndex == -1)
            {
                return;
            }
            Item _obj = (Item)cboItem.SelectedItem;
            cboAccount.SelectedItem = _obj.InventoryAccount;
            cboJob.SelectedItem = null;
            txtUnitCost.Text = string.Format("{0}", _obj.LastUnitPrice);
            txtQuantity.Text = "1";
            txtMemo.Text = _obj.ItemDescription;
        }

        private void Record(object sender, EventArgs args)
        {
            if (mViewModel.ValidateModel())
            {
                mModel.Update();
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        protected override void LoadView()
        {
            base.LoadView();
            mViewModel.UpdateView();
        }
    }
}
