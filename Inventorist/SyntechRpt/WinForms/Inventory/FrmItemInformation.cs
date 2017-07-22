using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using Accounting.Core.TaxCodes;
using Accounting.Core.Cards;
using Accounting.Core.Definitions;
using Accounting.Core.Accounts;
using Accounting.Bll;
using Accounting.Bll.Inventory;
using SyntechRpt.WinForms.Util;

namespace SyntechRpt.WinForms.Inventory
{
    public partial class FrmItemInformation : Form
    {
        private BOItem mModel = null;
        public BOItem Model
        {
            get
            {
                return mModel;
            }
            set
            {
                mModel = value;
                mModel.Revised += new BOItem.RevisedHandler(Model_Revised);
            }
        }

        void Model_Revised()
        {
            ViewModel();
        }

        public FrmItemInformation()
        {
            InitializeComponent();
        }

        private void frmItemInformation_Load(object sender, EventArgs e)
        {
            cboSellTaxCode.DataSource = mModel.List("TaxCode");
            cboPrimarySupplier.DataSource = mModel.List("Supplier");
            cboSalesTaxCalcBasis.DataSource = mModel.List("PriceLevel");
            cboBuyTaxCode.DataSource = mModel.List("TaxCode");
            cboIncomeAccount.DataSource = mModel.List("IncomeAccount");
            cboExpenseAccount.DataSource = mModel.List("ExpenseAccount");
            cboInventoryAccount.DataSource = mModel.List("InventoryAccount");

            ViewModel();

            this.chkItemIsInventoried.CheckedChanged += new System.EventHandler(this.chkItemIsInventoried_CheckedChanged);
            this.chkItemIsSold.CheckedChanged += new System.EventHandler(this.chkItemIsSold_CheckedChanged);
            this.chkItemIsBought.CheckedChanged += new System.EventHandler(this.chkItemIsBought_CheckedChanged);
        }

        public void ViewModel()
        {
            txtItemNumber.Text = mModel.GetPropertyValue<string>(BOItem.ITEM_NUMBER);
            txtItemName.Text = mModel.GetPropertyValue<string>(BOItem.ITEM_NAME);

            chkItemIsSold.Checked = mModel.GetPropertyValue<bool>(BOItem.ITEM_IS_SOLD);
            chkItemIsBought.Checked = mModel.GetPropertyValue<bool>(BOItem.ITEM_IS_BOUGHT);
            chkItemIsInventoried.Checked = mModel.GetPropertyValue<bool>(BOItem.ITEM_IS_INVENTORIED);
            cboExpenseAccount.Enabled = chkItemIsBought.Checked;
            cboIncomeAccount.Enabled = chkItemIsSold.Checked;
            cboInventoryAccount.Enabled = chkItemIsInventoried.Checked;

            txtQtnOnHand.Text = mModel.GetPropertyValue<string>(BOItem.QUANTITY_ON_HAND);
            txtValueOnHand.Text = mModel.GetPropertyValue<string>(BOItem.VALUE_ON_HAND);
            txtPositiveAverageCost.Text =mModel.GetPropertyValue<string>(BOItem.POSITIVE_AVERAGE_COST);
            txtSellOnOrder.Text = mModel.GetPropertyValue<string>(BOItem.SELL_ON_ORDER);
            txtPurchaseOnOrder.Text = mModel.GetPropertyValue<string>(BOItem.PURCHASE_ON_ORDER);
            txtQuantityAvailable.Text = string.Format("{0}", mModel.QuantityAvailable);

            txtLastUnitPrice.Text = string.Format("{0}", mModel.LastUnitPrice);
            txtBuyUnitMeasure.Text = mModel.BuyUnitMeasure;
            txtBuyUnitQuantity.Text = string.Format("{0}", mModel.BuyUnitQuantity);

            txtBaseSellingPrice.Text = string.Format("{0}", mModel.BaseSellingPrice);
            txtSellUnitQuantity.Text = string.Format("{0}", mModel.SellUnitQuantity);
            txtSellUnitMeasure.Text = mModel.SellUnitMeasure;
             chkPriceIsInclusive.Checked = mModel.PriceIsInclusive;

            txtDefaultReoderQuantity.Text =string.Format("{0}", mModel.DefaultReorderQuantity);
            txtMinLevelBeforeReorder.Text = string.Format("{0}", mModel.MinLevelBeforeReorder);
            txtSupplierItemNumber.Text = mModel.SupplierItemNumber;

            txtDescription.Text = mModel.ItemDescription;
            chkUseDescription.Checked = mModel.UseDescription;
            if (mModel.GetPropertyValue<string>(BOItem.PICTURE_PATH) != null)
            {
                pbItemPicture.Load(mModel.GetPropertyValue<string>(BOItem.PICTURE_PATH));   
            }
            lblItemPicture.Text = mModel.GetPropertyValue<string>(BOItem.PICTURE);

            cboIncomeAccount.SelectedItem = mModel.IncomeAccount;
            cboExpenseAccount.SelectedItem = mModel.ExpenseAccount;
            cboInventoryAccount.SelectedItem = mModel.InventoryAccount;

            chkInactive.Checked = mModel.IsInactive;

            cboBuyTaxCode.SelectedItem = mModel.BuyTaxCode;
            cboSellTaxCode.SelectedItem = mModel.SellTaxCode;
            cboPrimarySupplier.SelectedItem = mModel.PrimarySupplier;
            cboSalesTaxCalcBasis.SelectedItem = mModel.SalesTaxCalcBasis;

            if (chkItemIsBought.Checked)
            {
                if (!tabControlItemScreen.TabPages.Contains(tabPageBuyingDetails))
                {
                    tabControlItemScreen.TabPages.Add(tabPageBuyingDetails);
                }
            }
            else
            {
                tabControlItemScreen.TabPages.Remove(tabPageBuyingDetails);
            }

            if (chkItemIsSold.Checked)
            {
                if (!tabControlItemScreen.TabPages.Contains(tabPageSellingDetails))
                {
                    tabControlItemScreen.TabPages.Add(tabPageSellingDetails);
                }
            }
            else
            {
                tabControlItemScreen.TabPages.Remove(tabPageSellingDetails);
            }

            lblItemNameBuyingDetails.Text = txtItemName.Text;
            lblItemNameSellingDetails.Text = txtItemName.Text;
            lblItemNameItemDetails.Text = txtItemName.Text;
            lblItemNameExtraDetail.Text = txtItemName.Text;

            lblItemNumberBuyingDetails.Text = txtItemNumber.Text;
            lblItemNumberItemDetails.Text = txtItemNumber.Text;
            lblItemNumberSellingDetails.Text = txtItemNumber.Text;
            lblItemNumberExtraDetail.Text = txtItemNumber.Text;
        }

        private void cboSellTaxCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaxCode item=(TaxCode)cboSellTaxCode.SelectedItem;
            txtSellTaxCodeID.Text = ""+item.TaxCodeID;
        }

        private void cboBuyTaxCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaxCode item = (TaxCode)cboBuyTaxCode.SelectedItem;
            txtBuyTaxCodeID.Text = ""+item.TaxCodeID;
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            ReviseModel();

            OpResult result = mModel.Record();
            if (!result.IsValid)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(result.Error);
            }
        }


        public void ReviseModel()
        {
            mModel.SetPropertyValue<string>(BOItem.ITEM_NUMBER, txtItemNumber.Text);
            mModel.SetPropertyValue<string>(BOItem.ITEM_NAME, txtItemName.Text);
            mModel.SetPropertyValue<bool>(BOItem.ITEM_IS_SOLD, chkItemIsSold.Checked);
            mModel.SetPropertyValue<bool>(BOItem.ITEM_IS_BOUGHT, chkItemIsBought.Checked);
            mModel.SetPropertyValue<bool>(BOItem.ITEM_IS_INVENTORIED, chkItemIsInventoried.Checked);

            if(chkItemIsBought.Checked)
            {
                mModel.ExpenseAccount = (Account) cboExpenseAccount.SelectedItem;
            }
            else
            {
                mModel.ExpenseAccount=null;
            }
            if(chkItemIsSold.Checked)
            {
                mModel.IncomeAccount = (Account)cboIncomeAccount.SelectedItem;
            }
            else
            {
                mModel.IncomeAccount=null;
            }
            if(chkItemIsInventoried.Checked)
            {
                mModel.InventoryAccount =(Account)cboInventoryAccount.SelectedItem;
            }
            else
            {
                mModel.IncomeAccount=null;
            }
            
            mModel.SetPropertyValue<string>(BOItem.QUANTITY_ON_HAND, txtQtnOnHand.Text);
            mModel.LastUnitPrice = double.Parse(txtLastUnitPrice.Text);

            mModel.GetPropertyValue<string>(BOItem.PICTURE) = lblItemPicture.Text;
            mModel.ItemDescription = txtDescription.Text;
            mModel.UseDescription = chkUseDescription.Checked;

            mModel.PrimarySupplier = (Supplier)cboPrimarySupplier.SelectedItem;
            mModel.SupplierItemNumber = txtSupplierItemNumber.Text;

            mModel.BuyTaxCode = (TaxCode)cboBuyTaxCode.SelectedItem;
            mModel.BuyUnitMeasure = txtBuyUnitMeasure.Text;
            mModel.BuyUnitQuantity = int.Parse(txtBuyUnitQuantity.Text);

            mModel.DefaultReorderQuantity = double.Parse(txtDefaultReoderQuantity.Text);
            mModel.MinLevelBeforeReorder = double.Parse(txtMinLevelBeforeReorder.Text);
            mModel.BaseSellingPrice = double.Parse(txtBaseSellingPrice.Text);
            mModel.SellUnitMeasure = txtSellUnitMeasure.Text;

            mModel.SellTaxCode = (TaxCode)cboSellTaxCode.SelectedItem;
            mModel.PriceIsInclusive = chkPriceIsInclusive.Checked;

            mModel.SalesTaxCalcBasis = (PriceLevel) cboSalesTaxCalcBasis.SelectedItem;

            mModel.SellUnitQuantity = int.Parse(txtSellUnitQuantity.Text);

            mModel.IsInactive = chkInactive.Checked;

            mModel.StandardCost = double.Parse(txtStandardCost.Text);

            mModel.Revise();
        }

        private void pbItemPicture_DoubleClick(object sender, EventArgs e)
        {
            FrmPicture frm = new FrmPicture();
            frm.Model.Picture = lblItemPicture.Text;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                mModel.GetPropertyValue<string>(BOItem.PICTURE) = frm.Model.Picture; 
                lblItemPicture.Text = mModel.GetPropertyValue<string>(BOItem.PICTURE);
                if (frm.Model.Picture.Equals(""))
                {
                    pbItemPicture.Image = null;
                }
                else
                {
                    string picture_path = mModel.GetPropertyValue<string>(BOItem.PICTURE_PATH);
                    if (System.IO.File.Exists(picture_path))
                    {
                        pbItemPicture.Load(picture_path);
                    }
                }
            }
        }

        private void btnNewCharacteristic_Click(object sender, EventArgs e)
        {
            cboCharacteristicName.Text = "";
            txtCharacteristicValue.Text = "";
            tcCharacteristics.SelectedIndex = 1;
        }

        private bool isRowSelected(DataGridView dgv)
        {
            return !(dgv.SelectedRows == null || dgv.SelectedRows.Count == 0 || dgv.SelectedRows[0].Cells == null || dgv.SelectedRows[0].Cells.Count == 0 || dgv.SelectedRows[0].Cells[0].Value == null);
        }

        private void update_detailCharacteristic()
        {
            if (!(isRowSelected(dgvCharacteristics)))
            {
                return;
            }

            string name = this.dgvCharacteristics.SelectedRows[0].Cells["name"].Value.ToString();
            string value = this.dgvCharacteristics.SelectedRows[0].Cells["value"].Value.ToString();

            cboCharacteristicName.Text = name;
            txtCharacteristicValue.Text = value;
        }

        private void chkItemIsBought_CheckedChanged(object sender, EventArgs e)
        {
            cboExpenseAccount.Enabled = chkItemIsBought.Enabled;
            ReviseModel();
        }

        private void chkItemIsSold_CheckedChanged(object sender, EventArgs e)
        {
            cboIncomeAccount.Enabled = chkItemIsSold.Enabled;
            ReviseModel();
        }

        private void chkItemIsInventoried_CheckedChanged(object sender, EventArgs e)
        {
            cboInventoryAccount.Enabled = chkItemIsInventoried.Enabled;
            ReviseModel();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
