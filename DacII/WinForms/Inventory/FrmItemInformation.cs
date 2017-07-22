using System;
using System.Windows.Forms;


namespace DacII.WinForms.Inventory
{
    using DacII.Presenters;
    using DacII.ViewModels;
    using Accounting.Core;
    using Accounting.Core.TaxCodes;
    using Accounting.Bll.Inventory;
    using Accounting.Bll;
    using Accounting.Core.Inventory;
    using DacII.WinForms.Util;

    public partial class FrmItemInformation : BaseView
    {
        private BOItem mModel = null;
        private BOViewModel mViewModel;

        private void Record(object sender, EventArgs args)
        {
            if (mViewModel.ValidateModel())
            {
                string item_number = mModel.Data.ItemNumber;
                if (item_number != txtItemNumber.Text)
                {
                    if (MessageBox.Show("You have modified the Item Number, this will create a number item with your entry, would you like proceed?", "Confirm Create New", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        DialogResult = DialogResult.None;
                    }
                    else
                    {
                        mModel.IsCreating = true;
                        OpResult result = mModel.Record();
                        if (result.Status == OpResult.ResultStatus.Created)
                        {
                            MessageBox.Show("Item Record Created!");
                        }
                        else if (result.Status == OpResult.ResultStatus.Updated)
                        {
                            MessageBox.Show("Item Record Updated!");
                        }
                        else
                        {
                            MessageBox.Show(result.Error);
                        }
                    }
                }
                else
                {
                    OpResult result = mModel.Record();
                    if (result.Status == OpResult.ResultStatus.Created)
                    {
                        MessageBox.Show("Item Record Created!");
                    }
                    else if (result.Status == OpResult.ResultStatus.Updated)
                    {
                        MessageBox.Show("Item Record Updated!");
                    }
                    else
                    {
                        MessageBox.Show(result.Error);
                    }
                }
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        private void OnItemIsSoldChanged(object sender, EventArgs args)
        {
            if (chkItemIsSold.Checked && !tabControlItemScreen.TabPages.Contains(tabPageSellingDetails))
            {
                tabControlItemScreen.TabPages.Add(tabPageSellingDetails);
            }
            else if (!chkItemIsSold.Checked && tabControlItemScreen.TabPages.Contains(tabPageSellingDetails))
            {
                tabControlItemScreen.TabPages.Remove(tabPageSellingDetails);
            }
            cboIncomeAccount.Visible = chkItemIsSold.Checked;
            lblIncomeAccount.Visible = cboIncomeAccount.Visible;
        }

        private void OnItemIsBoughtChanged(object sender, EventArgs args)
        {
            if (chkItemIsBought.Checked && !tabControlItemScreen.TabPages.Contains(tabPageBuyingDetails))
            {
                tabControlItemScreen.TabPages.Add(tabPageBuyingDetails);
            }
            else if (!chkItemIsBought.Checked && tabControlItemScreen.TabPages.Contains(tabPageBuyingDetails))
            {
                tabControlItemScreen.TabPages.Remove(tabPageBuyingDetails);
            }
            cboExpenseAccount.Visible = chkItemIsBought.Checked;
            lblExpenseAccount.Visible = cboExpenseAccount.Visible;
        }

        private void OnItemIsInventoriedChanged(object sender, EventArgs args)
        {
            cboInventoryAccount.Visible = chkItemIsInventoried.Checked;
            lblInventoryAccount.Visible = cboInventoryAccount.Visible;
        }

        private void OnBuyTaxCodeChanged(object sender, EventArgs args)
        {
            TaxCode item = (TaxCode)cboBuyTaxCode.SelectedItem;
            if (item == null) return;
            txtBuyTaxCodeID.Text = item.TaxCodeDescription;
        }

        private void OnSellTaxCodeChanged(object sender, EventArgs args)
        {
            TaxCode item = (TaxCode)cboSellTaxCode.SelectedItem;
            if (item == null) return;
            txtSellTaxCodeID.Text = item.TaxCodeDescription;
        }

        protected override void BindViews()
        {
            cboSellTaxCode.DataSource = mApplicationController.FindAllTaxCodes();
            cboPrimarySupplier.DataSource = mApplicationController.FindAllSuppliers();
            cboSalesTaxCalcBasis.DataSource = mApplicationController.FindAllTaxCodes();
            cboBuyTaxCode.DataSource = mApplicationController.FindAllTaxCodes();
            cboIncomeAccount.DataSource = mApplicationController.FindAllIncomeAccounts();
            cboExpenseAccount.DataSource = mApplicationController.FindAllExpenseAccounts();
            cboInventoryAccount.DataSource = mApplicationController.FindAllInventoryAccounts();
            cboGender.DataSource = mApplicationController.FindAllGendersForItemAddOn();
            cboSize.DataSource = mApplicationController.FindAllItemSizesForItemAddOn();

            mViewModel.BindView(BOItem.ITEM_NUMBER, lblItemNumber, txtItemNumber);
            mViewModel.BindView(BOItem.ITEM_NAME, lblItemName, txtItemName);
            mViewModel.BindView(BOItem.CUSTOM_FIELD1, lblCustomField1, txtCustomField1);
            mViewModel.BindView(BOItem.CUSTOM_FIELD2, lblCustomField2, txtCustomField2);
            mViewModel.BindView(BOItem.CUSTOM_FIELD3, lblCustomField3, txtCustomField3);

            mViewModel.BindView(BOItem.ITEM_IS_SOLD, chkItemIsSold);
            mViewModel.BindView(BOItem.ITEM_IS_BOUGHT, chkItemIsBought);
            mViewModel.BindView(BOItem.ITEM_IS_INVENTORIED, chkItemIsInventoried);

            mViewModel.BindView(BOItem.QUANTITY_ON_HAND, lblQtyOnHand, txtQtnOnHand);
            mViewModel.BindView(BOItem.VALUE_ON_HAND, lblValueOnHand, txtValueOnHand);
            mViewModel.BindView(BOItem.POSITIVE_AVERAGE_COST, lblPositiveAverageCost, txtPositiveAverageCost);
            mViewModel.BindView(BOItem.SELL_ON_ORDER, lblSellOnOrder, txtSellOnOrder);
            mViewModel.BindView(BOItem.PURCHASE_ON_ORDER, lblPurchaseOnOrder, txtPurchaseOnOrder);
            mViewModel.BindView(BOItem.QUANTITY_AVAILABLE, lblQuantityAvailable, txtQuantityAvailable);

            mViewModel.BindView(BOItem.LAST_UNIT_PRICE, lblLastUnitPrice, txtLastUnitPrice);
            mViewModel.BindView(BOItem.BUY_UNIT_MEASURE, lblBuyUnitMeasure, txtBuyUnitMeasure);
            mViewModel.BindView(BOItem.BUY_UNIT_QUANTITY, lblBuyUnitQuantity, txtBuyUnitQuantity);

            mViewModel.BindView(BOItem.BASE_SELLING_PRICE, lblBaseSellingPrice, txtBaseSellingPrice);
            mViewModel.BindView(BOItem.SELL_UNIT_QUANTITY, lblSellUnitQuantity, txtSellUnitQuantity);
            mViewModel.BindView(BOItem.SELL_UNIT_MEASURE, lblSellUnitMeasure, txtSellUnitMeasure);
            mViewModel.BindView(BOItem.PRICE_IS_INCLUSIVE, chkPriceIsInclusive);

            mViewModel.BindView(BOItem.DEFAULT_REORDER_QUANITTY, lblDefaultReoderQuantity, txtDefaultReoderQuantity);
            mViewModel.BindView(BOItem.MIN_LEVEL_BEFORE_REORDER, lblMinLevelBeforeReorder, txtMinLevelBeforeReorder);
            mViewModel.BindView(BOItem.SUPPLIER_ITEM_NUMBER, lblSupplierItemNumber, txtSupplierItemNumber);

            mViewModel.BindView(BOItem.ITEM_DESCRIPTION, lblDescription, txtDescription);
            mViewModel.BindView(BOItem.USE_DESCRIPTION, chkUseDescription);
            mViewModel.BindView(BOItem.PICTURE, lblPicture);

            mViewModel.BindView(BOItem.INCOME_ACCOUNT, lblIncomeAccount, cboIncomeAccount);
            mViewModel.BindView(BOItem.EXPENSE_ACCOUNT, lblExpenseAccount, cboExpenseAccount);
            mViewModel.BindView(BOItem.INVENTORY_ACCOUNT, lblInventoryAccount, cboInventoryAccount);

            mViewModel.BindView(BOItem.IS_INACTIVE, chkInactive);

            mViewModel.BindView(BOItem.BUY_TAXCODE, lblBuyTaxCode, cboBuyTaxCode);
            mViewModel.BindView(BOItem.SELL_TAXCODE, lblSellTaxCode, cboSellTaxCode);
            mViewModel.BindView(BOItem.PRIMARY_SUPPLIER, lblPrimarySupplier, cboPrimarySupplier);
            mViewModel.BindView(BOItem.SALES_TAX_CALC_BASIS, lblSalesTaxCalcBasis, cboSalesTaxCalcBasis);

            mViewModel.BindView(BOItem.BRAND, lblBrand, txtBrand);
            mViewModel.BindView(BOItem.BATCH_NUMBER, lblBatchNumber, txtBatchNumber);
            mViewModel.BindView(BOItem.SERIAL_NUMBER, lblSerialNumber, txtSerialNumber);
            mViewModel.BindView(BOItem.COLOR, lblColor, txtColor);
            mViewModel.BindView(BOItem.EXPIRY_DATE, lblExpiryDate, dpExpiryDate);
            mViewModel.BindView(BOItem.GENDER, lblGender, cboGender);
            mViewModel.BindView(BOItem.ITEM_SIZE, lblSize, cboSize);
            
            mViewModel.BindView(BOItem.PERSIST_OBJECT, btnRecord);
        }

        public BOItem Model
        {
            set
            {
                mModel = value;
                mViewModel.Model = mModel;
            }
        }

        public FrmItemInformation(ApplicationPresenter ap, BOItem model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;
            mViewModel = new BOViewModel(mModel);
            mViewModel.ErrorProvider = errorProvider;

            BindViews();
            RegisterEventHandlers();

            ConfigureDataGridView(dgvItemDataFields);
        }

        private void ConfigureDataGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            DataGridViewColumn c = null;

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "FieldName";
            c.HeaderText = "Name";
            dgv.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "Content";
            c.HeaderText = "Value";
            dgv.Columns.Add(c);

            DacII.Util.DataGridViewHelper.UpdateColumnHeaderStyles(dgv);
        }

        protected override void LoadView()
        {
            dgvItemDataFields.DataSource = mModel.ItemDataFieldEntries;
            mViewModel.UpdateView();
            

            if (!string.IsNullOrEmpty(mModel.DefaultPicturePath))
            {
                pbPicture.Load(mModel.DefaultPicturePath);
            }

            if (chkItemIsBought.Checked && !tabControlItemScreen.TabPages.Contains(tabPageBuyingDetails))
            {
                tabControlItemScreen.TabPages.Add(tabPageBuyingDetails);
            }
            else if (!chkItemIsBought.Checked && tabControlItemScreen.TabPages.Contains(tabPageBuyingDetails))
            {
                tabControlItemScreen.TabPages.Remove(tabPageBuyingDetails);
            }

            if (chkItemIsSold.Checked && !tabControlItemScreen.TabPages.Contains(tabPageSellingDetails))
            {
                tabControlItemScreen.TabPages.Add(tabPageSellingDetails);
            }
            else if (!chkItemIsSold.Checked && tabControlItemScreen.TabPages.Contains(tabPageSellingDetails))
            {
                tabControlItemScreen.TabPages.Remove(tabPageSellingDetails);
            }

            lblExpenseAccount.Visible = cboExpenseAccount.Visible = chkItemIsBought.Checked;
            lblIncomeAccount.Visible = cboIncomeAccount.Visible = chkItemIsSold.Checked;
            lblInventoryAccount.Visible = cboInventoryAccount.Visible = chkItemIsInventoried.Checked;

            if (mModel.IsCreating)
            {
                if (tabControlItemScreen.TabPages.Contains(tabPageCharacteristics))
                {
                    tabControlItemScreen.TabPages.Remove(tabPageCharacteristics);
                }
            }
            else
            {
                if (!tabControlItemScreen.TabPages.Contains(tabPageCharacteristics))
                {
                    tabControlItemScreen.TabPages.Add(tabPageCharacteristics);
                }
            }
        }

        private void pbItemPicture_DoubleClick(object sender, EventArgs e)
        {
            FrmPicture frm = new FrmPicture();
            frm.InitialPicture = mModel.DefaultPicturePath;
            frm.PictureDirectory = mModel.DefaultPictureDirectory;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                lblPicture.Text = frm.ResultantPictureName;
                mModel.SetPropertyValue(BOItem.PICTURE, lblPicture.Text);
                if (string.IsNullOrEmpty(mModel.DefaultPicturePath))
                {
                    pbPicture.Image = null;
                }
                else
                {
                    string picture_path = mModel.DefaultPicturePath;
                    if (System.IO.File.Exists(picture_path))
                    {
                        pbPicture.Load(picture_path);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            string barcode=txtItemNumber.Text;
            FrmGenBarcode frm = new FrmGenBarcode();
            frm.GenBarcode(barcode);
        }

        private void btnCreateItemDataField_Click(object sender, EventArgs e)
        {
            mApplicationController.CreateItemDataFieldEntry(mModel.Data);
        }

        private void btnDelItemDataField_Click(object sender, EventArgs e)
        {
            if (dgvItemDataFields.SelectedRows.Count == 0) return;
            mApplicationController.DeleteItemDataFieldEntry(dgvItemDataFields.SelectedRows[0].DataBoundItem as ItemDataFieldEntry, mModel.Data);
        }

        private void dgvItemDataFields_DoubleClick(object sender, EventArgs e)
        {
            if (dgvItemDataFields.SelectedRows.Count == 0) return;
            mApplicationController.OpenItemDataFieldEntry(dgvItemDataFields.SelectedRows[0].DataBoundItem as ItemDataFieldEntry, mModel.Data);
        }
    }
}
