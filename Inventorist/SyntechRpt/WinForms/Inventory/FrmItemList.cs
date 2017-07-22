using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Accounting.Bll.Inventory;
using Accounting.Bll;
using Accounting.Bll.Rules;

namespace SyntechRpt.WinForms.Inventory
{
    public partial class FrmItemList : Form
    {
        private BOListItem mModel=null;

        public BOListItem Model
        {
            get { return mModel; }
        }

        void mModel_Revised()
        {
            ViewModel();
        }

        public FrmItemList()
        {
            InitializeComponent();
            dgvAll.ColumnHeadersBorderStyle = ProperColumnHeadersBorderStyle;
            mModel = new BOListItem(AccountantPool.Instance.CurrentAccountant);
            mModel.Revised += new BOListItem.RevisedHandler(mModel_Revised);
        }

        private void btnCreateItem_Click(object sender, EventArgs e)
        {
            BOItem itemModel=mModel.CreateItem();
            FrmItemInformation frm = new FrmItemInformation();
            frm.Model = itemModel;
            frm.MdiParent=this.MdiParent;
            frm.Show();
        }

        private void ViewModel()
        {
            BOProperty _obj = (BOProperty)cboSearchFieldName.SelectedItem;
            string fieldname = "", fieldvalue = "";
            if (_obj != null)
            {
                fieldname = (string)_obj.Value;
                fieldvalue = txtSearchFieldValue.Text;
            }

            this.dgvAll.DataSource = mModel.ItemDataGridView(false, false, false, fieldname, fieldvalue);
            lblCountAll.Text = string.Format("# Records Found: {0}", dgvAll.Rows.Count);

            this.dgvSold.DataSource = mModel.ItemDataGridView(true, false, false, fieldname, fieldvalue);
            this.lblCountSold.Text = string.Format("# Records Found: {0}", dgvSold.Rows.Count);

            this.dgvBought.DataSource = mModel.ItemDataGridView(false, true, false, fieldname, fieldvalue);
            this.lblCountBought.Text = string.Format("# Records Found: {0}", dgvBought.Rows.Count);

            this.dgvInventoried.DataSource = mModel.ItemDataGridView(false, false, true, fieldname, fieldvalue);
            this.lblCountInventoried.Text = string.Format("# Records Found: {0}", dgvInventoried.Rows.Count);
        }

        static DataGridViewHeaderBorderStyle ProperColumnHeadersBorderStyle
        {
            get
            {
                return (SystemFonts.MessageBoxFont.Name == "Segoe UI") ?
                    DataGridViewHeaderBorderStyle.None :
                    DataGridViewHeaderBorderStyle.Raised;
            }
        }

        private void frmItemScreen_Load(object sender, EventArgs e)
        {
            cboSearchFieldName.DataSource = mModel.List("SearchField");
            ViewModel();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ViewModel();
        }

        private void DataGridView_DoubleClick(DataGridView dgv)
        {
            int ItemID;
            if (DataGridView_ReadItemID(dgv, out ItemID))
            {
                BOItem itemModel = mModel.GetItem(ItemID);
                OpenItemDialog(itemModel);
            }
        }

        private void OpenItemDialog(BOItem itemModel)
        {
            FrmItemInformation frm = new FrmItemInformation();
            frm.Model = itemModel;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                mModel.Revise();
            }
        }

        private bool DataGridView_ReadItemID(DataGridView dgv, out int ItemID)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                ItemID = 0;
                return false;
            }
            ItemID = int.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());
            return true;
        }

        private void btnDelItem_Click(object sender, EventArgs e)
        {
          
        }

        private void dgvSold_DoubleClick(object sender, EventArgs e)
        {
            DataGridView_DoubleClick(dgvSold);
        }

        private void dgvBought_DoubleClick(object sender, EventArgs e)
        {
            DataGridView_DoubleClick(dgvBought);
        }

        private void dgvInventoried_DoubleClick(object sender, EventArgs e)
        {
            DataGridView_DoubleClick(dgvInventoried);
        }

        private void btnSearchItem_Click(object sender, EventArgs e)
        {
            ViewModel();
        }

        private void dgvAll_DoubleClick(object sender, EventArgs e)
        {
            DataGridView_DoubleClick(dgvAll);
        }
    }
}
