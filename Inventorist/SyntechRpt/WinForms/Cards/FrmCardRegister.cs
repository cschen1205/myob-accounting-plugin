using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SyntechRpt.Util;
using Accounting;
using Accounting.Core.Cards;
using Accounting.Core.TaxCodes;
using Accounting.Core.Definitions;
using Accounting.Bll;
using Accounting.Bll.Cards;

namespace SyntechRpt.WinForms.Cards
{
    public partial class FrmCardRegister : Form
    {
        private BOListCard mModel=null;

        public BOListCard Model
        {
            get
            {
                return mModel;
            }
        }

        void mModel_Revised()
        {
            ViewModel();
        }

        public FrmCardRegister()
        {
            InitializeComponent();
            mModel = new BOListCard(AccountantPool.Instance.CurrentAccountant);
            mModel.Revised += new BOListCard.RevisedHandler(mModel_Revised);
        }

        private void DataGridView_DoubleClick(DataGridView dgv)
        {
            int CardRecordID;
            if (WinFormUtil.DataGridView_GetSelectedID(dgv, out CardRecordID))
            {
                BOCard cardModel = mModel.GetItem(CardRecordID);
                OpenCardDialog(cardModel);
            }
        }

        private void OpenCardDialog(BOCard cardModel)
        {
            if (cardModel is BOCustomer)
            {
                FrmCustomer frm = new FrmCustomer();
                frm.Model = (BOCustomer)cardModel;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    mModel.Revise();
                }
            }
            else if (cardModel is BOSupplier)
            {
                FrmSupplier frm = new FrmSupplier();
                frm.Model = (BOSupplier)cardModel;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    mModel.Revise();
                }
            }
            else if (cardModel is BOEmployee)
            {
                FrmEmployee frm = new FrmEmployee();
                frm.Model = (BOEmployee)cardModel;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    mModel.Revise();
                }
            }
        }


        private void FrmCards_Load(object sender, EventArgs e)
        {
            if (mModel.ActiveCardType == Accounting.Core.Cards.CardType.TypeID.Customer)
            {
                tc.TabPages.Remove(tpAll);
                tc.TabPages.Remove(tpSuppliers);
                tc.TabPages.Remove(tpEmployees);
                this.Text = "Customers";
            }
            else if (mModel.ActiveCardType == Accounting.Core.Cards.CardType.TypeID.Supplier)
            {
                tc.TabPages.Remove(tpAll);
                tc.TabPages.Remove(tpCustomers);
                tc.TabPages.Remove(tpEmployees);
                this.Text = "Suppliers";
            }
            else if (mModel.ActiveCardType == Accounting.Core.Cards.CardType.TypeID.Employee)
            {
                tc.TabPages.Remove(tpAll);
                tc.TabPages.Remove(tpSuppliers);
                tc.TabPages.Remove(tpCustomers);
                this.Text = "Employees";
            }
            else
            {
                this.Text = "Cards";
            }

            ViewModel();
        }

        private void ViewModel()
        {
            if (tc.TabPages.Contains(tpAll))
            {
                dgvAll.DataSource = mModel.DataGridView(Accounting.Core.Cards.CardType.TypeID.None);
                lblCountAll.Text = string.Format("# found: {0}", dgvAll.Rows.Count);
            }

            if (tc.TabPages.Contains(tpCustomers))
            {
                dgvCustomers.DataSource = mModel.DataGridView(Accounting.Core.Cards.CardType.TypeID.Customer);
                lblCountCustomers.Text = string.Format("# found: {0}", dgvCustomers.Rows.Count);
            }

            if (tc.TabPages.Contains(tpSuppliers))
            {
                dgvSuppliers.DataSource = mModel.DataGridView(Accounting.Core.Cards.CardType.TypeID.Supplier);
                lblCountSuppliers.Text = string.Format("# found: {0}", dgvSuppliers.Rows.Count);
            }

            if (tc.TabPages.Contains(tpEmployees))
            {
                dgvEmployees.DataSource = mModel.DataGridView(Accounting.Core.Cards.CardType.TypeID.Employee);
                lblCountEmployees.Text = string.Format("# found: {0}", dgvEmployees.Rows.Count);
            }
        }

        private void UI_Clear()
        {
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAll_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView_DoubleClick(dgvAll);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DataGridView_Delete(dgvAll);
        }

        private void DataGridView_Delete(DataGridView dgv)
        {
            int CardRecordID;
            if (WinFormUtil.DataGridView_GetSelectedID(dgv, out CardRecordID))
            {
                if (WinFormUtil.Confirm("Do you want to delete the card?", "Delete") == DialogResult.Yes)
                {
                    mModel.Delete(CardRecordID);
                }
            }
        }

        private void dgvCustomers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView_DoubleClick(dgvCustomers);
        }

        private void dgvSuppliers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView_DoubleClick(dgvSuppliers);
        }

        private void dgvEmployees_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView_DoubleClick(dgvEmployees);
        }

        private void btnDelCustomer_Click(object sender, EventArgs e)
        {
            DataGridView_Delete(dgvCustomers);
        }

        private void btnDelSupplier_Click(object sender, EventArgs e)
        {
            DataGridView_Delete(dgvSuppliers);
        }

        private void btnDelEmployee_Click(object sender, EventArgs e)
        {
            DataGridView_Delete(dgvEmployees);
        }

        private void btnCreateCustomer_Click(object sender, EventArgs e)
        {
            BOCard cardModel = mModel.CreateItem(CardType.TypeID.Customer);
            OpenCardDialog(cardModel);
        }

        private void btnCreateSupplier_Click(object sender, EventArgs e)
        {
            BOCard cardModel = mModel.CreateItem(CardType.TypeID.Supplier);
            OpenCardDialog(cardModel);
        }

        private void btnCreateEmployee_Click(object sender, EventArgs e)
        {
            BOCard cardModel = mModel.CreateItem(CardType.TypeID.Employee);
            OpenCardDialog(cardModel);
        }
    }
}