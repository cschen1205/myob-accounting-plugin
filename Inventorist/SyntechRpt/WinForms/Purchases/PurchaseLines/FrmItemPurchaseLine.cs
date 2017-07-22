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
using Accounting.Bll;
using Accounting.Bll.Purchases;
using Accounting.Bll.Purchases.PurchaseLines;

namespace SyntechRpt.WinForms.Purchases.PurchaseLines
{
    public partial class FrmItemPurchaseLine : Form
    {
        private BOItemPurchaseLine mModel = null;

        public FrmItemPurchaseLine()
        {
            InitializeComponent();
        }

        public BOItemPurchaseLine Model
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

        private void FrmItemPurchaseLine_Load(object sender, EventArgs e)
        {
            cboItem.DataSource = mModel.List("Item");
            cboTax.DataSource = mModel.List("TaxCode");
            cboJob.DataSource = mModel.List("Job");
            cboLocation.DataSource = mModel.List("Location");

            txtReceived.Visible = mModel.GetProperty(()=>mModel.Received).Visible;
            lblReceived.Visible = mModel.GetProperty(()=>mModel.Received).Visible;

            ViewModel();
        }

        private void ViewModel()
        {
            cboItem.SelectedItem = mModel.Item;
            cboTax.SelectedItem = mModel.TaxCode;
            cboJob.SelectedItem = mModel.Job;
            cboLocation.SelectedItem = mModel.Location;
            txtPrice.Text = string.Format("{0}", mModel.Price);
            txtQuantity.Text = string.Format("{0}", mModel.Quantity);
            txtDiscount.Text = string.Format("{0}", mModel.Discount);
            txtReceived.Text = mModel.Received.ToString();
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
            mModel.Item = (Item)cboItem.SelectedItem;
            mModel.Quantity = double.Parse(txtQuantity.Text);
            mModel.Price = double.Parse(txtPrice.Text);
            mModel.TaxCode = (TaxCode)cboTax.SelectedItem;
            mModel.Location = (Location)cboLocation.SelectedItem;
            mModel.Job = (Job)cboJob.SelectedItem;
            mModel.Received = double.Parse(txtReceived.Text);

            OpResult result = mModel.Revise();
            if(!result.IsValid)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(result.Error);
            }
        } 
    }
}