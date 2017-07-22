using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using Accounting.Core.Inventory;
using Accounting.Core.TaxCodes;
using Accounting.Core.Jobs;
using Accounting;
using Accounting.Bll.Sales.SaleLines;

namespace SyntechRpt.WinForms.Sales.SaleLines
{
    public partial class FrmItemSaleLine : Form
    {
        private BOItemSaleLine mModel = null;


        public FrmItemSaleLine()
        {
            InitializeComponent();
        }

        public BOItemSaleLine Model
        {
            get
            {
                return mModel;
            }
            set
            {
                mModel = value;
            }
        }

        private void FrmItemSaleLine_Load(object sender, EventArgs e)
        {
            cboItem.DataSource = mModel.List("Item");
            cboTax.DataSource = mModel.List("TaxCode");
            cboJob.DataSource = mModel.List("Job");
            cboLocation.DataSource = mModel.List("Location");

            cboItem.SelectedItem=mModel.Item;
            cboTax.SelectedItem = mModel.TaxCode;
            cboJob.SelectedItem =mModel.Job;
            cboLocation.SelectedItem = mModel.Location;
            txtPrice.Text = string.Format("{0}", mModel.Price);
            txtQuantity.Text = string.Format("{0}", mModel.Quantity);
            txtDiscount.Text = string.Format("{0}", mModel.Discount);
        }

        private void ClearRendering()
        {
            cboItem.SelectedIndex = -1;
            cboTax.SelectedIndex = -1;
            cboJob.SelectedIndex = -1;
            cboLocation.SelectedIndex = -1;
        }

        private void cboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboItem.SelectedIndex ==-1)
            {
                return;
            }
            Item _obj = (Item)cboItem.SelectedItem;
            cboTax.SelectedItem = _obj.SellTaxCode;
            cboJob.SelectedItem = null;
            cboLocation.SelectedItem = _obj.DefaultSellLocation;
            txtPrice.Text = string.Format("{0}", _obj.BaseSellingPrice);
            txtQuantity.Text = "1";
            txtDiscount.Text = "0";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string errorText = "";
            if (cboItem.SelectedIndex == -1)
            {
                errorText="No item selected!";
                errorProvider.SetError(cboItem, errorText);
                DialogResult=DialogResult.None;
                return;
            }

            mModel.Item = (Item)cboItem.SelectedItem;
            mModel.Quantity = double.Parse(txtQuantity.Text);
            mModel.Price = double.Parse(txtPrice.Text);
            mModel.TaxCode = (TaxCode)cboTax.SelectedItem;
            mModel.Location = (Location)cboLocation.SelectedItem;
            mModel.Job = (Job)cboJob.SelectedItem;

            mModel.Revise();
        } 
    }
}