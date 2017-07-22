using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SyntechRpt.Util;
using Accounting.Core.Cards;
using Accounting.Core.Definitions;
using Accounting.Bll.Purchases;

namespace SyntechRpt.WinForms.Purchases
{
    public partial class FrmPurchaseRegister : Form
    {
        private BOListPurchase mModel;

        public BOListPurchase Model
        {
            set
            {
                mModel = value;
                mModel.Revised += new BOListPurchase.RevisedHandler(mModel_Revised);
            }
        }

        void mModel_Revised()
        {
            ViewModel();
        }

        public FrmPurchaseRegister()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPurchaseRegister_Load(object sender, EventArgs e)
        {
            DateTime end_date = DateTime.Now;
            DateTime start_date = new DateTime(DateTime.Now.Year, 1, 1);
            dtpEndDate.Value = end_date;
            dtpStartDate.Value = start_date;

           chkAllSuppliers.Checked = true;
           cboSupplierSearchCriteria.DataSource = mModel.List("Supplier");
           cboSupplierSearchCriteria.Enabled = !chkAllSuppliers.Checked;

           ViewModel();

           this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
           this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
           this.chkAllSuppliers.CheckedChanged += new System.EventHandler(this.chkAllSuppliers_CheckedChanged);

           btnDelQuote.Enabled = SecurityUtil.CheckAccessSilent("Purchase_DeletePurchaseQuote");
           btnDelOrder.Enabled = SecurityUtil.CheckAccessSilent("Purchase_DeletePurchaseOrder");
           btnDelOpenBill.Enabled = SecurityUtil.CheckAccessSilent("Purchase_DeletePurchaseOpenBill");
           btnChangeOrder2OpenBill.Enabled = SecurityUtil.CheckAccessSilent("Purchase_CreatePurchaseOpenBill");
           btnChangeQuote2OpenBill.Enabled = SecurityUtil.CheckAccessSilent("Purchase_CreatePurchaseOpenBill");
           btnChangeQuote2Order.Enabled = SecurityUtil.CheckAccessSilent("Purchase_CreatePurchaseOrder");
           btnCreateOrder.Enabled = SecurityUtil.CheckAccessSilent("Purchase_CreatePurchaseOrder");
           btnCreateQuote.Enabled = SecurityUtil.CheckAccessSilent("Purchase_CreatePurchaseQuote");
        }

        private void ViewModel()
        {
            StringBuilder sb = new StringBuilder();

            DateTime start = dtpStartDate.Value;
            DateTime end = dtpEndDate.Value;
            Supplier customer = null;
            if (!chkAllSuppliers.Checked)
            {
                customer=(Supplier)cboSupplierSearchCriteria.SelectedItem;
            }

            dgvAll.DataSource = mModel.DataGridView(start, end, customer, null);
            dgvQuote.DataSource = mModel.DataGridView(start, end, customer, mModel.InvoiceStatus_Quote);
            dgvOrder.DataSource = mModel.DataGridView(start, end, customer, mModel.InvoiceStatus_Order);
            dgvOpenInvoice.DataSource = mModel.DataGridView(start, end, customer, mModel.InvoiceStatus_OpenBill);
            dgvCreditReturn.DataSource = mModel.DataGridView(start, end, customer, mModel.InvoiceStatus_DebitReturn);
            dgvClosedInvoice.DataSource = mModel.DataGridView(start, end, customer, mModel.InvoiceStatus_ClosedBill);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            /*
            int PurchaseID = int.Parse(dgvAll.SelectedRows[0].Cells[0].Value.ToString());

            string reportname = "rptInvoice";

            Report.WinForms.FrmPurchaseOrder frm = new Dac.WinForms.Report.FrmPurchaseOrder(mModel.PrintPurchase(PurchaseID));
            frm.MdiParent = this.MdiParent;
            frm.LoadReport(string.Format("Dac.WinForms.Report.{0}.rdlc", reportname));
            frm.Show();
             */
        }

        private void btnGenReload_Click(object sender, EventArgs e)
        {
            ViewModel();
        }

        private void chkAllSuppliers_CheckedChanged(object sender, EventArgs e)
        {
            chkAllSuppliers.ImageIndex = chkAllSuppliers.Checked ? 0 : 1;
            cboSupplierSearchCriteria.Enabled = !chkAllSuppliers.Checked;
            ViewModel();
        }

        private void cboSupplierSearchCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewModel();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            ViewModel();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            ViewModel();
        }

        private void btnCreateQuote_Click(object sender, EventArgs e)
        {
            BOPurchase saleModel = mModel.CreateItem(Status.StatusType.Quote);
            OpenPurchaseDialog(saleModel);
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            BOPurchase saleModel = mModel.CreateItem(Status.StatusType.Order);
            OpenPurchaseDialog(saleModel);
        }

        private void OpenPurchaseDialog(BOPurchase model)
        {
            if (model is BOPurchaseQuote && SecurityUtil.CheckAccess("Purchase_ReadPurchaseQuote"))
            {
                FrmPurchaseQuote frm = new FrmPurchaseQuote();
                frm.Model = (BOPurchaseQuote)model;
                frm.ShowDialog();
            }
            else if (model is BOPurchaseOrder && SecurityUtil.CheckAccess("Purchase_ReadPurchaseOrder"))
            {
                FrmPurchaseOrder frm = new FrmPurchaseOrder();
                frm.Model = (BOPurchaseOrder)model;
                frm.ShowDialog();
            }
            else if (model is BOPurchaseOpenBill && SecurityUtil.CheckAccess("Purchase_ReadPurchaseOpenBill"))
            {
                FrmPurchaseOpenBill frm = new FrmPurchaseOpenBill();
                frm.Model = (BOPurchaseOpenBill)model;
                frm.ShowDialog();
            }
        }

        private void btnDelQuote_Click(object sender, EventArgs e)
        {
            DataGridView_Delete(dgvQuote);
        }

        private void btnDelOrder_Click(object sender, EventArgs e)
        {
            DataGridView_Delete(dgvOrder);
        }

        private void btnDelOpenInvoice_Click(object sender, EventArgs e)
        {
            DataGridView_Delete(dgvOpenInvoice);
        }

        private void DataGridView_Delete(DataGridView dgv)
        {
            int PurchaseID;
            if (DataGridView_ReadPurchaseID(dgv, out PurchaseID))
            {
                mModel.Delete(PurchaseID);
            }
        }

        private void DataGridView_DoubleClick(DataGridView dgv)
        {
            int PurchaseID;
            if (DataGridView_ReadPurchaseID(dgv, out PurchaseID))
            {
                BOPurchase saleModel = mModel.GetItem(PurchaseID);
                OpenPurchaseDialog(saleModel);
            }
        }

        private void dgvQuote_DoubleClick(object sender, EventArgs e)
        {
            DataGridView_DoubleClick(dgvQuote);
        }

        private void dgvAll_DoubleClick(object sender, EventArgs e)
        {
            DataGridView_DoubleClick(dgvAll);
        }

        private void dgvOrder_DoubleClick(object sender, EventArgs e)
        {
            DataGridView_DoubleClick(dgvOrder);
        }

        private void dgvOpenInvoice_DoubleClick(object sender, EventArgs e)
        {
            DataGridView_DoubleClick(dgvOpenInvoice);
        }

        private void dgvCreditReturn_DoubleClick(object sender, EventArgs e)
        {
            DataGridView_DoubleClick(dgvCreditReturn);
        }

        private void dgvClosedInvoice_DoubleClick(object sender, EventArgs e)
        {
            DataGridView_DoubleClick(dgvClosedInvoice);
        }

        private void btnChangeQuote2Order_Click(object sender, EventArgs e)
        {
            int PurchaseID;
            if (DataGridView_ReadPurchaseID(dgvQuote, out PurchaseID))
            {
                BOPurchase saleModel = mModel.ChangeQuote2Order(PurchaseID);
                OpenPurchaseDialog(saleModel);
            }
        }

        private void btnChangeQuote2OpenBill_Click(object sender, EventArgs e)
        {
            int PurchaseID;
            if (DataGridView_ReadPurchaseID(dgvQuote, out PurchaseID))
            {
                BOPurchase saleModel = mModel.ChangeQuote2OpenBill(PurchaseID);
                OpenPurchaseDialog(saleModel);
            }
        }

        private void btnChangeOrder2OpenBill_Click(object sender, EventArgs e)
        {
            int PurchaseID;
            if (DataGridView_ReadPurchaseID(dgvOrder, out PurchaseID))
            {
                BOPurchase saleModel = mModel.ChangeOrder2OpenBill(PurchaseID);
                OpenPurchaseDialog(saleModel);
            }
        }

        private bool DataGridView_ReadPurchaseID(DataGridView dgv, out int PurchaseID)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                PurchaseID = 0;
                return false;
            }
            PurchaseID = int.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());
            return true;
        }
    }
}