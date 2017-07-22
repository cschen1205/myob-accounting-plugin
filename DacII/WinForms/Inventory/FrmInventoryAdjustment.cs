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

    using Accounting.Core;
    using Accounting.Core.Inventory;
    using Accounting.Bll.Inventory;

    public partial class FrmInventoryAdjustment : BaseView
    {
        BOInventoryAdjustment mModel = null;
        private BOViewModel mViewModel = null;

        public FrmInventoryAdjustment(ApplicationPresenter ap, BOInventoryAdjustment model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;
            mViewModel = new BOViewModel(mModel);
            mViewModel.ErrorProvider = errorProvider;

            BindViews();
            RegisterEventHandlers();
        }

        protected override void BindViews()
        {
            base.BindViews();

            dgvAll.DataSource = mModel.Lines;

            mViewModel.BindView(BOInventoryAdjustment.INVENTORY_JOURNAL_NUMBER, lblJournalNumber, txtJournalNumber);
            mViewModel.BindView(BOInventoryAdjustment.ADJUSTMENT_DATE, lblAdjustmentDate, dtpAdjustmentDate);
            mViewModel.BindView(BOInventoryAdjustment.MEMO, lblMemo, txtMemo);

            mViewModel.BindView(BOInventoryAdjustment.PERSIST_OBJECT, btnRecord);
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void btnNewLine_Click(object sender, EventArgs e)
        {
            if (mApplicationController.CreateInventoryAdjustmentLine(mModel.Data))
            {
                UpdateInventoryAdjustmentLines();
            }
        }

        protected override void LoadView()
        {
            base.LoadView();

            mViewModel.UpdateView();
            UpdateInventoryAdjustmentLines();
        }

        private void UpdateInventoryAdjustmentLines()
        {
            dgvAll.DataSource = mModel.Lines;
            ConfigureDataGridView(dgvAll);
        }

        private void ConfigureDataGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            DataGridViewColumn c = null;

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "ItemName";
            c.HeaderText = "Item Name";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "ItemNumber";
            c.HeaderText = "Item Number";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "Quantity";
            c.HeaderText = "Quantity";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "_UnitCost";
            c.HeaderText = "Unit Cost";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "_Amount";
            c.HeaderText = "Amount";
            dgv.Columns.Add(c);


            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "AccountNumber";
            c.HeaderText = "Account";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "JobNumber";
            c.HeaderText = "Job";
            dgv.Columns.Add(c);


            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "Memo";
            c.HeaderText = "Memo";
            dgv.Columns.Add(c);

          

            DacII.Util.DataGridViewHelper.UpdateColumnHeaderStyles(dgv);
        }

        private void btnDelLine_Click(object sender, EventArgs e)
        {
            if (dgvAll.SelectedRows.Count == 0) return;
            mApplicationController.DeleteInventoryAdjustmentLine(dgvAll.SelectedRows[0].DataBoundItem as InventoryAdjustmentLine);
        }

        private void dgvAll_DoubleClick(object sender, EventArgs e)
        {
            if (dgvAll.SelectedRows.Count == 0) return;
            mApplicationController.OpenInventoryAdjustmentLine(dgvAll.SelectedRows[0].DataBoundItem as InventoryAdjustmentLine);
        }

        private void Record(object sender, EventArgs e)
        {
            if (mViewModel.ValidateModel())
            {
                OpResult result = mModel.Record();
                if (result.Status == OpResult.ResultStatus.UpdateFailedOnCriteria)
                {
                    MessageBox.Show(result.Error, "Update Inventory Adjustment Failed");
                    DialogResult = DialogResult.None;
                }
                else if (result.Status == OpResult.ResultStatus.CreateFailedOnCriteria)
                {
                    MessageBox.Show(result.Error, "Create Inventory Adjustment Failed");
                    DialogResult = DialogResult.None;
                }
                else
                {
                    string error = result.Error;
                    if (string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show("Inventory Adjustment Recorded!");
                    }
                    else
                    {
                        MessageBox.Show(error);
                    }
                }
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }
    }
}
