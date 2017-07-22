using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DacII.WinForms.Inventory
{
    using DacII.Presenters;
    using DacII.ViewModels;
    using Accounting.Bll.Inventory;
    using Accounting.Bll;
    using Accounting.Core.Inventory;
    using Accounting.Core.Currencies;
    
    public partial class FrmItemsList : BaseView
    {
        private BOItemsList mModel=null;
        private BOViewModel mViewModel = null;

        public FrmItemsList(ApplicationPresenter ap, BOItemsList model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;
            mViewModel = new BOViewModel(model);

            BindViews();
            RegisterEventHandlers();

            ConfigureDataGridView(dgvAll);
            ConfigureDataGridView(dgvSold);
            ConfigureDataGridView(dgvBought);
            ConfigureDataGridView(dgvInventoried);
        }

        protected override void BindViews()
        {
            string[] search_fields=new string[] {"ItemNumber", "ItemName", "ItemDescription"};
            cboSearchFieldName.DataSource = search_fields;

            dgvAll.DataSource = mModel.AllItems;
            dgvSold.DataSource = mModel.SoldItems;
            dgvBought.DataSource = mModel.BoughtItems;
            dgvInventoried.DataSource = mModel.InventoriedItems;

            mViewModel.BindView(BOItemsList.ALL_ITEMS_INFORMATION, lblCountAll);
            mViewModel.BindView(BOItemsList.SOLD_ITEMS_INFORMATION, lblCountSold);
            mViewModel.BindView(BOItemsList.BOUGHT_ITEMS_INFORMATION, lblCountBought);
            mViewModel.BindView(BOItemsList.INVENTORIED_ITEMS_INFORMATION, lblCountInventoried);

            mViewModel.BindView(BOItemsList.SEARCH_FIELD, null, cboSearchFieldName);
            mViewModel.BindView(BOItemsList.SEARCH_VALUE, null, txtSearchFieldValue);
        }

        private void OpenFrom_InventoriedItems(object sender, EventArgs args)
        {
            if (dgvInventoried.SelectedRows.Count == 0) return;
            mApplicationController.OpenItem(dgvInventoried.SelectedRows[0].DataBoundItem as Item);
        }

        private void OpenFrom_SoldItems(object sender, EventArgs args)
        {
            if (dgvSold.SelectedRows.Count == 0) return;
            mApplicationController.OpenItem(dgvSold.SelectedRows[0].DataBoundItem as Item);
        }

        private void OpenFrom_AllItems(object sender, EventArgs args)
        {
            if (dgvAll.SelectedRows.Count == 0) return;
            mApplicationController.OpenItem(dgvAll.SelectedRows[0].DataBoundItem as Item);
        }

        private void OpenFrom_BoughtItems(object sender, EventArgs args)
        {
            if (dgvBought.SelectedRows.Count == 0) return;
            mApplicationController.OpenItem(dgvBought.SelectedRows[0].DataBoundItem as Item);
        }

        private void ConfigureDataGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            DataGridViewColumn c = null;
            
            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "ItemNumber";
            c.HeaderText = "Item #";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "ItemName";
            c.HeaderText = "Name";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "QuantityOnHand";
            c.HeaderText = "On Hand";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "LastCostText";
            c.HeaderText = "Last Cost";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "SellPriceText";
            c.HeaderText = "Sell Price";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "ItemSize";
            c.HeaderText = "Item Size";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "Gender";
            c.HeaderText = "Gender";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "Color";
            c.HeaderText = "Color";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "SerialNumber";
            c.HeaderText = "Serial #";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "BatchNumber";
            c.HeaderText = "Batch #";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "Brand";
            c.HeaderText = "Brand";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "ExpiryDateText";
            c.HeaderText = "Expired";
            dgv.Columns.Add(c);

            DacII.Util.DataGridViewHelper.UpdateColumnHeaderStyles(dgv);
        }

        protected override void LoadView()
        {
            mViewModel.UpdateView();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            mModel.InvalidateDataStore();
        }

        private class SearchFieldItem
        {
            private string mName;
            private string mValue;
            public SearchFieldItem(string name, string value)
            {
                mName = name;
                mValue = value;
            }
            public override string ToString()
            {
                return mName;
            }
            public string Value
            {
                get { return mValue; }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void btnCreateItem_Click(object sender, EventArgs e)
        {
            mApplicationController.CreateItem();
        }

        private void btnPrintItemsListSummary_Click(object sender, EventArgs e)
        {
            mApplicationController.ShowItemsListSummaryRpt();
        }
    }
}
