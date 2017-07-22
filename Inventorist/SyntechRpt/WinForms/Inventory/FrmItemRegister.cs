using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.Core.Inventory;
using Accounting.Bll.Inventory;
using Accounting.Bll.Purchases;
using Accounting.Bll.Sales;
using Accounting.Bll;
using SyntechRpt.WinForms.Purchases;
using SyntechRpt.WinForms.Sales;

namespace SyntechRpt.WinForms.Inventory
{
    public partial class FrmItemRegister : Form
    {
        private BOListItemRegister mModel = new BOListItemRegister(AccountantPool.Instance.CurrentAccountant);

        public FrmItemRegister()
        {
            InitializeComponent();
            mModel.Revised += new Accounting.Bll.BusinessObject.RevisedHandler(mModel_Revised);
        }

        void mModel_Revised()
        {
            throw new NotImplementedException();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkAllItems_CheckedChanged(object sender, EventArgs e)
        {
            chkAllItems.ImageIndex = chkAllItems.Checked ? 0 : 1;
            txtItemSearchCriteria.Text = chkAllItems.Checked ? "" : txtItemSearchCriteria.Text;
            txtItemSearchCriteria.Enabled = !chkAllItems.Checked;
            ViewModel();
        }

        private void ViewModel()
        {
            StringBuilder sb = new StringBuilder();

            DateTime start = dtpStartDate.Value;
            DateTime end = dtpEndDate.Value;
            string keywords = "";
            if (!chkAllItems.Checked)
            {
                keywords = txtItemSearchCriteria.Text;
            }

            dgvAll.DataSource = mModel.DataGridView(start, end, keywords);
        }

        private void FrmItemRegister_Load(object sender, EventArgs e)
        {
            ViewModel();

            this.dtpEndDate.ValueChanged += new EventHandler(dtpEndDate_ValueChanged);
            this.dtpStartDate.ValueChanged += new EventHandler(dtpStartDate_ValueChanged);
            this.chkAllItems.CheckedChanged += new System.EventHandler(this.chkAllItems_CheckedChanged);
        }

        void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            ViewModel();
        }

        void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            ViewModel();
        }

        private void dgvAll_DoubleClick(object sender, EventArgs e)
        {
            int ID;
            string Src;
            if (DataGridView_ReadID(dgvAll, out ID, out Src))
            {
                OpenJournalDialog(mModel.GetItem(ID, Src));
            }
        }

        private void OpenJournalDialog(BusinessObject model)
        {
            if (model is BOSaleQuote)
            {
                FrmSaleQuote frm = new FrmSaleQuote();
                frm.Model = (BOSaleQuote)model;
                frm.ShowDialog();
            }
            else if (model is BOSaleOrder)
            {
                FrmSaleOrder frm = new FrmSaleOrder();
                frm.Model = (BOSaleOrder)model;
                frm.ShowDialog();
            }
            else if (model is BOSaleOpenInvoice)
            {
                FrmSaleOpenInvoice frm = new FrmSaleOpenInvoice();
                frm.Model = (BOSaleOpenInvoice)model;
                frm.ShowDialog();
            }
            else if (model is BOPurchaseQuote)
            {
                FrmPurchaseQuote frm = new FrmPurchaseQuote();
                frm.Model = (BOPurchaseQuote)model;
                frm.ShowDialog();
            }
            else if (model is BOPurchaseOrder)
            {
                FrmPurchaseOrder frm = new FrmPurchaseOrder();
                frm.Model = (BOPurchaseOrder)model;
                frm.ShowDialog();
            }
            else if (model is BOPurchaseOpenBill)
            {
                FrmPurchaseOpenBill frm = new FrmPurchaseOpenBill();
                frm.Model = (BOPurchaseOpenBill)model;
                frm.ShowDialog();
            }
        }

        private bool DataGridView_ReadID(DataGridView dgv, out int ID, out string Src)
        {
            if (dgv.SelectedRows.Count == 0) 
            {
                ID = 0;
                Src = "";
                return false;
            }

            ID = int.Parse(dgv.SelectedRows[0].Cells["ID"].Value.ToString());
            Src = dgv.SelectedRows[0].Cells["Src"].Value.ToString();
            return true;
        }
    }
}
