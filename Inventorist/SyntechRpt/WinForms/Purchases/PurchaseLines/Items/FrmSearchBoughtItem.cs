using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.Bll.Util;
using Accounting.Core.Inventory;

namespace SyntechRpt.WinForms.Purchases.PurchaseLines.Items
{
    public partial class FrmSearchBoughtItem : Form
    {
        public FrmSearchBoughtItem()
        {
            InitializeComponent();
        }

        private void FrmSearchBoughtItem_Load(object sender, EventArgs e)
        {
            /*
            ItemPresentationManager ipm=ItemPresentationManager.Instance;
            cboSearchField.DataSource = ipm.ItemSearchFields;
           
            dgv.DataSource = ipm.ItemDataGridView_DataSource(true, false, false, "", "");
            foreach (string columnName in ipm.ItemDataGridView_Columns.Keys)
            {
                string headerText = ipm.ItemDataGridView_Columns[columnName];
                dgv.Columns[columnName].HeaderText=headerText;
            }
            dgv.Columns[ipm.ItemDataGridView_ColumnName_ItemID].Visible = false;
             * */
        }

        public Item SelectedItem
        {
            get;
            set;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            /*
            string searchField = (string)((UIItem)cboSearchField.SelectedItem).Value;
            dgv.DataSource = ItemPresentationManager.Instance.ItemDataGridView_DataSource(true, false, false, searchField, txtSearchValue.Text);
             * */
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            /*
            if (dgv.SelectedRows.Count == 0)
            {
                string errorText = "No item selected!";
                errorProvider.SetError(dgv, errorText);
                DialogResult = DialogResult.Cancel;
                return;
            }
            ItemPresentationManager ipm=ItemPresentationManager.Instance;
            SelectedItem = (Item)ipm.ItemWithID(dgv.SelectedRows[0].Cells[ipm.ItemDataGridView_ColumnName_ItemID].Value);
             * */
        }
    }
}
