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
using Accounting.Bll.Sales;

namespace SyntechRpt.WinForms.Sales
{
    public partial class FrmSaleRegister : Form
    {
        private BOListSale mModel;

        public BOListSale Model
        {
            set
            {
                mModel = value;
                mModel.Revised += new BOListSale.RevisedHandler(mModel_Revised);
            }
        }

        void mModel_Revised()
        {
            ViewModel();
        }

        public FrmSaleRegister()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSaleRegister_Load(object sender, EventArgs e)
        {
            DateTime end_date = DateTime.Now;
            DateTime start_date = new DateTime(DateTime.Now.Year, 1, 1);
            dtpEndDate.Value = end_date;
            dtpStartDate.Value = start_date;

           chkAllCustomers.Checked = true;
           cboCustomerSearchCriteria.DataSource = mModel.List("Customer");
           cboCustomerSearchCriteria.Enabled = !chkAllCustomers.Checked;

           ViewModel();

           this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
           this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
           this.chkAllCustomers.CheckedChanged += new System.EventHandler(this.chkAllCustomers_CheckedChanged);

            btnDelQuote.Enabled = SecurityUtil.CheckAccessSilent("Sale_DeleteSaleQuote");
            btnDelOrder.Enabled = SecurityUtil.CheckAccessSilent("Sale_DeleteSaleOrder");
            btnDelOpenInvoice.Enabled = SecurityUtil.CheckAccessSilent("Sale_DeleteSaleOpenInvoice");
            btnChangeOrder2OpenInvoice.Enabled = SecurityUtil.CheckAccessSilent("Sale_CreateSaleOpenInvoice");
            btnChangeQuote2OpenInvoice.Enabled = SecurityUtil.CheckAccessSilent("Sale_CreateSaleOpenInvoice");
            btnChangeQuote2Order.Enabled = SecurityUtil.CheckAccessSilent("Sale_CreateSaleOrder");
            btnCreateOrder.Enabled = SecurityUtil.CheckAccessSilent("Sale_CreateSaleOrder");
            btnCreateQuote.Enabled = SecurityUtil.CheckAccessSilent("Sale_CreateSaleQuote");
        }

        private void ViewModel()
        {
            StringBuilder sb = new StringBuilder();

            DateTime start = dtpStartDate.Value;
            DateTime end = dtpEndDate.Value;
            Customer customer = null;
            if (!chkAllCustomers.Checked)
            {
                customer=(Customer)cboCustomerSearchCriteria.SelectedItem;
            }

            dgvAll.DataSource = mModel.DataGridView(start, end, customer, null);
            dgvQuote.DataSource = mModel.DataGridView(start, end, customer, mModel.InvoiceStatus_Quote);
            dgvOrder.DataSource = mModel.DataGridView(start, end, customer, mModel.InvoiceStatus_Order);
            dgvOpenInvoice.DataSource = mModel.DataGridView(start, end, customer, mModel.InvoiceStatus_OpenInvoice);
            dgvCreditReturn.DataSource = mModel.DataGridView(start, end, customer, mModel.InvoiceStatus_CreditReturn);
            dgvClosedInvoice.DataSource = mModel.DataGridView(start, end, customer, mModel.InvoiceStatus_ClosedInvoice);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            /*
            int SaleID = int.Parse(dgvAll.SelectedRows[0].Cells[0].Value.ToString());

            string reportname = "rptInvoice";

            Report.WinForms.FrmInvoice frm = new Dac.WinForms.Report.FrmInvoice(mModel.PrintSale(SaleID));
            frm.MdiParent = this.MdiParent;
            frm.LoadReport(string.Format("Dac.WinForms.Report.{0}.rdlc", reportname));
            frm.Show();
             */
        }

        private void btnGenReload_Click(object sender, EventArgs e)
        {
            ViewModel();
        }

        private void chkAllCustomers_CheckedChanged(object sender, EventArgs e)
        {
            chkAllCustomers.ImageIndex = chkAllCustomers.Checked ? 0 : 1;
            cboCustomerSearchCriteria.Enabled = !chkAllCustomers.Checked;
            ViewModel();
        }

        private void cboCustomerSearchCriteria_SelectedIndexChanged(object sender, EventArgs e)
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
            BOSale saleModel = mModel.CreateItem(Status.StatusType.Quote);
            OpenSaleDialog(saleModel);
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            BOSale saleModel = mModel.CreateItem(Status.StatusType.Order);
            OpenSaleDialog(saleModel);
        }

        private void OpenSaleDialog(BOSale saleModel)
        {
            if (saleModel is BOSaleQuote && SecurityUtil.CheckAccess("Sale_ReadSaleQuote"))
            {
                FrmSaleQuote frm = new FrmSaleQuote();
                frm.Model = (BOSaleQuote)saleModel;
                frm.ShowDialog();
            }
            else if (saleModel is BOSaleOrder && SecurityUtil.CheckAccess("Sale_ReadSaleOrder"))
            {
                FrmSaleOrder frm = new FrmSaleOrder();
                frm.Model = (BOSaleOrder)saleModel;
                frm.ShowDialog();
            }
            else if (saleModel is BOSaleOpenInvoice && SecurityUtil.CheckAccess("Sale_ReadSaleOpenInvoice"))
            {
                FrmSaleOpenInvoice frm = new FrmSaleOpenInvoice();
                frm.Model = (BOSaleOpenInvoice)saleModel;
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
            int SaleID;
            if (DataGridView_ReadSaleID(dgv, out SaleID))
            {
                mModel.Delete(SaleID);
            }
        }

        private void DataGridView_DoubleClick(DataGridView dgv)
        {
            int SaleID;
            if (DataGridView_ReadSaleID(dgv, out SaleID))
            {
                BOSale saleModel = mModel.GetItem(SaleID);
                OpenSaleDialog(saleModel);
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
            int SaleID;
            if (DataGridView_ReadSaleID(dgvQuote, out SaleID))
            {
                BOSale saleModel = mModel.ChangeQuote2Order(SaleID);
                OpenSaleDialog(saleModel);
            }
        }

        private void btnChangeQuote2OpenInvoice_Click(object sender, EventArgs e)
        {
            int SaleID;
            if (DataGridView_ReadSaleID(dgvQuote, out SaleID))
            {
                BOSale saleModel = mModel.ChangeQuote2OpenInvoice(SaleID);
                OpenSaleDialog(saleModel);
            }
        }

        private void btnChangeOrder2OpenInvoice_Click(object sender, EventArgs e)
        {
            int SaleID;
            if (DataGridView_ReadSaleID(dgvOrder, out SaleID))
            {
                BOSale saleModel = mModel.ChangeOrder2OpenInvoice(SaleID);
                OpenSaleDialog(saleModel);
            }
        }

        private bool DataGridView_ReadSaleID(DataGridView dgv, out int SaleID)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                SaleID = 0;
                return false;
            }
            SaleID = int.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());
            return true;
        }

    }
}