namespace DacII.WinForms.Inventory
{
    partial class FrmItemInformation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmItemInformation));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlItemScreen = new System.Windows.Forms.TabControl();
            this.tabPageItemProfile = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.CZRoundedGroupBox();
            this.cboIncomeAccount = new System.Windows.Forms.ComboBox();
            this.cboInventoryAccount = new System.Windows.Forms.ComboBox();
            this.cboExpenseAccount = new System.Windows.Forms.ComboBox();
            this.lblInventoryAccount = new System.Windows.Forms.Label();
            this.lblIncomeAccount = new System.Windows.Forms.Label();
            this.lblExpenseAccount = new System.Windows.Forms.Label();
            this.chkItemIsInventoried = new System.Windows.Forms.CheckBox();
            this.chkItemIsSold = new System.Windows.Forms.CheckBox();
            this.chkItemIsBought = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.CZRoundedGroupBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.chkInactive = new System.Windows.Forms.CheckBox();
            this.lblValueOnHand = new System.Windows.Forms.Label();
            this.lblQuantityAvailable = new System.Windows.Forms.Label();
            this.lblPurchaseOnOrder = new System.Windows.Forms.Label();
            this.lblSellOnOrder = new System.Windows.Forms.Label();
            this.lblPositiveAverageCost = new System.Windows.Forms.Label();
            this.txtValueOnHand = new System.Windows.Forms.TextBox();
            this.txtQuantityAvailable = new System.Windows.Forms.TextBox();
            this.txtPurchaseOnOrder = new System.Windows.Forms.TextBox();
            this.txtSellOnOrder = new System.Windows.Forms.TextBox();
            this.txtPositiveAverageCost = new System.Windows.Forms.TextBox();
            this.txtQtnOnHand = new System.Windows.Forms.TextBox();
            this.lblQtyOnHand = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.tabPageItemDetails = new System.Windows.Forms.TabPage();
            this.txtCustomField3 = new System.Windows.Forms.TextBox();
            this.lblCustomField3 = new System.Windows.Forms.Label();
            this.txtCustomField2 = new System.Windows.Forms.TextBox();
            this.lblCustomField2 = new System.Windows.Forms.Label();
            this.txtCustomField1 = new System.Windows.Forms.TextBox();
            this.lblCustomField1 = new System.Windows.Forms.Label();
            this.gbLocation = new System.Windows.Forms.CZRoundedGroupBox();
            this.txtLocationDescription = new System.Windows.Forms.TextBox();
            this.cboLocation = new System.Windows.Forms.ComboBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.gbItemDetails = new System.Windows.Forms.CZRoundedGroupBox();
            this.lblPicture = new System.Windows.Forms.Label();
            this.pbPicture = new System.Windows.Forms.PictureBox();
            this.chkUseDescription = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tabPageCharacteristics = new System.Windows.Forms.TabPage();
            this.grpCustomCharacteristics = new System.Windows.Forms.CZRoundedGroupBox();
            this.btnDelItemDataField = new System.Windows.Forms.Button();
            this.btnCreateItemDataField = new System.Windows.Forms.Button();
            this.dgvItemDataFields = new System.Windows.Forms.DataGridView();
            this.gbCharacteristics = new System.Windows.Forms.CZRoundedGroupBox();
            this.cboSize = new System.Windows.Forms.ComboBox();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.dpExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.lblSerialNumber = new System.Windows.Forms.Label();
            this.txtBatchNumber = new System.Windows.Forms.TextBox();
            this.lblBatchNumber = new System.Windows.Forms.Label();
            this.tabPageBuyingDetails = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.CZRoundedGroupBox();
            this.txtDefaultReoderQuantity = new System.Windows.Forms.TextBox();
            this.cboPrimarySupplier = new System.Windows.Forms.ComboBox();
            this.lblDefaultReoderQuantity = new System.Windows.Forms.Label();
            this.txtSupplierItemNumber = new System.Windows.Forms.TextBox();
            this.lblSupplierItemNumber = new System.Windows.Forms.Label();
            this.lblPrimarySupplier = new System.Windows.Forms.Label();
            this.txtMinLevelBeforeReorder = new System.Windows.Forms.TextBox();
            this.lblMinLevelBeforeReorder = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.CZRoundedGroupBox();
            this.txtBuyTaxCodeID = new System.Windows.Forms.TextBox();
            this.cboBuyTaxCode = new System.Windows.Forms.ComboBox();
            this.lblBuyTaxCode = new System.Windows.Forms.Label();
            this.txtBuyUnitQuantity = new System.Windows.Forms.TextBox();
            this.lblBuyUnitQuantity = new System.Windows.Forms.Label();
            this.txtBuyUnitMeasure = new System.Windows.Forms.TextBox();
            this.lblBuyUnitMeasure = new System.Windows.Forms.Label();
            this.txtStandardCost = new System.Windows.Forms.TextBox();
            this.lblStandardCost = new System.Windows.Forms.Label();
            this.txtLastUnitPrice = new System.Windows.Forms.TextBox();
            this.lblLastUnitPrice = new System.Windows.Forms.Label();
            this.tabPageSellingDetails = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.CZRoundedGroupBox();
            this.chkPriceIsInclusive = new System.Windows.Forms.CheckBox();
            this.txtSellTaxCodeID = new System.Windows.Forms.TextBox();
            this.cboSalesTaxCalcBasis = new System.Windows.Forms.ComboBox();
            this.cboSellTaxCode = new System.Windows.Forms.ComboBox();
            this.lblBaseSellingPrice = new System.Windows.Forms.Label();
            this.lblSalesTaxCalcBasis = new System.Windows.Forms.Label();
            this.txtBaseSellingPrice = new System.Windows.Forms.TextBox();
            this.lblSellTaxCode = new System.Windows.Forms.Label();
            this.txtSellUnitQuantity = new System.Windows.Forms.TextBox();
            this.lblSellUnitQuantity = new System.Windows.Forms.Label();
            this.txtSellUnitMeasure = new System.Windows.Forms.TextBox();
            this.lblSellUnitMeasure = new System.Windows.Forms.Label();
            this.txtItemNumber = new System.Windows.Forms.TextBox();
            this.lblItemNumber = new System.Windows.Forms.Label();
            this.gbItemSummary = new System.Windows.Forms.CZRoundedGroupBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.czRoundedGroupBox1 = new System.Windows.Forms.CZRoundedGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlItemScreen.SuspendLayout();
            this.tabPageItemProfile.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPageItemDetails.SuspendLayout();
            this.gbLocation.SuspendLayout();
            this.gbItemDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).BeginInit();
            this.tabPageCharacteristics.SuspendLayout();
            this.grpCustomCharacteristics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemDataFields)).BeginInit();
            this.gbCharacteristics.SuspendLayout();
            this.tabPageBuyingDetails.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPageSellingDetails.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.gbItemSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.czRoundedGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlItemScreen
            // 
            resources.ApplyResources(this.tabControlItemScreen, "tabControlItemScreen");
            this.tabControlItemScreen.Controls.Add(this.tabPageItemProfile);
            this.tabControlItemScreen.Controls.Add(this.tabPageItemDetails);
            this.tabControlItemScreen.Controls.Add(this.tabPageCharacteristics);
            this.tabControlItemScreen.Controls.Add(this.tabPageBuyingDetails);
            this.tabControlItemScreen.Controls.Add(this.tabPageSellingDetails);
            this.tabControlItemScreen.HotTrack = true;
            this.tabControlItemScreen.Name = "tabControlItemScreen";
            this.tabControlItemScreen.SelectedIndex = 0;
            // 
            // tabPageItemProfile
            // 
            this.tabPageItemProfile.Controls.Add(this.groupBox6);
            this.tabPageItemProfile.Controls.Add(this.groupBox4);
            resources.ApplyResources(this.tabPageItemProfile, "tabPageItemProfile");
            this.tabPageItemProfile.Name = "tabPageItemProfile";
            this.tabPageItemProfile.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.BackgroundColor = System.Drawing.Color.White;
            this.groupBox6.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.groupBox6.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.groupBox6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.groupBox6.BorderWidth = 1F;
            this.groupBox6.Caption = "";
            this.groupBox6.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.groupBox6.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.groupBox6.CaptionHeight = 25;
            this.groupBox6.CaptionVisible = true;
            this.groupBox6.Controls.Add(this.cboIncomeAccount);
            this.groupBox6.Controls.Add(this.cboInventoryAccount);
            this.groupBox6.Controls.Add(this.cboExpenseAccount);
            this.groupBox6.Controls.Add(this.lblInventoryAccount);
            this.groupBox6.Controls.Add(this.lblIncomeAccount);
            this.groupBox6.Controls.Add(this.lblExpenseAccount);
            this.groupBox6.Controls.Add(this.chkItemIsInventoried);
            this.groupBox6.Controls.Add(this.chkItemIsSold);
            this.groupBox6.Controls.Add(this.chkItemIsBought);
            this.groupBox6.CornerRadius = 5;
            this.groupBox6.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.groupBox6.DropShadowThickness = 3;
            this.groupBox6.DropShadowVisible = false;
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // cboIncomeAccount
            // 
            this.cboIncomeAccount.FormattingEnabled = true;
            resources.ApplyResources(this.cboIncomeAccount, "cboIncomeAccount");
            this.cboIncomeAccount.Name = "cboIncomeAccount";
            // 
            // cboInventoryAccount
            // 
            this.cboInventoryAccount.FormattingEnabled = true;
            resources.ApplyResources(this.cboInventoryAccount, "cboInventoryAccount");
            this.cboInventoryAccount.Name = "cboInventoryAccount";
            // 
            // cboExpenseAccount
            // 
            this.cboExpenseAccount.FormattingEnabled = true;
            resources.ApplyResources(this.cboExpenseAccount, "cboExpenseAccount");
            this.cboExpenseAccount.Name = "cboExpenseAccount";
            // 
            // lblInventoryAccount
            // 
            resources.ApplyResources(this.lblInventoryAccount, "lblInventoryAccount");
            this.lblInventoryAccount.Name = "lblInventoryAccount";
            // 
            // lblIncomeAccount
            // 
            resources.ApplyResources(this.lblIncomeAccount, "lblIncomeAccount");
            this.lblIncomeAccount.Name = "lblIncomeAccount";
            // 
            // lblExpenseAccount
            // 
            resources.ApplyResources(this.lblExpenseAccount, "lblExpenseAccount");
            this.lblExpenseAccount.Name = "lblExpenseAccount";
            // 
            // chkItemIsInventoried
            // 
            resources.ApplyResources(this.chkItemIsInventoried, "chkItemIsInventoried");
            this.chkItemIsInventoried.Name = "chkItemIsInventoried";
            this.chkItemIsInventoried.UseVisualStyleBackColor = true;
            this.chkItemIsInventoried.CheckedChanged += new System.EventHandler(this.OnItemIsInventoriedChanged);
            // 
            // chkItemIsSold
            // 
            resources.ApplyResources(this.chkItemIsSold, "chkItemIsSold");
            this.chkItemIsSold.Name = "chkItemIsSold";
            this.chkItemIsSold.UseVisualStyleBackColor = true;
            this.chkItemIsSold.CheckedChanged += new System.EventHandler(this.OnItemIsSoldChanged);
            // 
            // chkItemIsBought
            // 
            resources.ApplyResources(this.chkItemIsBought, "chkItemIsBought");
            this.chkItemIsBought.Name = "chkItemIsBought";
            this.chkItemIsBought.UseVisualStyleBackColor = true;
            this.chkItemIsBought.CheckedChanged += new System.EventHandler(this.OnItemIsBoughtChanged);
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.BackgroundColor = System.Drawing.Color.White;
            this.groupBox4.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.groupBox4.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.groupBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.groupBox4.BorderWidth = 1F;
            this.groupBox4.Caption = "";
            this.groupBox4.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.groupBox4.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.groupBox4.CaptionHeight = 25;
            this.groupBox4.CaptionVisible = true;
            this.groupBox4.Controls.Add(this.cboCategory);
            this.groupBox4.Controls.Add(this.chkInactive);
            this.groupBox4.Controls.Add(this.lblValueOnHand);
            this.groupBox4.Controls.Add(this.lblQuantityAvailable);
            this.groupBox4.Controls.Add(this.lblPurchaseOnOrder);
            this.groupBox4.Controls.Add(this.lblSellOnOrder);
            this.groupBox4.Controls.Add(this.lblPositiveAverageCost);
            this.groupBox4.Controls.Add(this.txtValueOnHand);
            this.groupBox4.Controls.Add(this.txtQuantityAvailable);
            this.groupBox4.Controls.Add(this.txtPurchaseOnOrder);
            this.groupBox4.Controls.Add(this.txtSellOnOrder);
            this.groupBox4.Controls.Add(this.txtPositiveAverageCost);
            this.groupBox4.Controls.Add(this.txtQtnOnHand);
            this.groupBox4.Controls.Add(this.lblQtyOnHand);
            this.groupBox4.Controls.Add(this.lblCategory);
            this.groupBox4.CornerRadius = 5;
            this.groupBox4.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.groupBox4.DropShadowThickness = 3;
            this.groupBox4.DropShadowVisible = false;
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            resources.ApplyResources(this.cboCategory, "cboCategory");
            this.cboCategory.Name = "cboCategory";
            // 
            // chkInactive
            // 
            resources.ApplyResources(this.chkInactive, "chkInactive");
            this.chkInactive.Name = "chkInactive";
            this.chkInactive.UseVisualStyleBackColor = true;
            // 
            // lblValueOnHand
            // 
            resources.ApplyResources(this.lblValueOnHand, "lblValueOnHand");
            this.lblValueOnHand.Name = "lblValueOnHand";
            // 
            // lblQuantityAvailable
            // 
            resources.ApplyResources(this.lblQuantityAvailable, "lblQuantityAvailable");
            this.lblQuantityAvailable.Name = "lblQuantityAvailable";
            // 
            // lblPurchaseOnOrder
            // 
            resources.ApplyResources(this.lblPurchaseOnOrder, "lblPurchaseOnOrder");
            this.lblPurchaseOnOrder.Name = "lblPurchaseOnOrder";
            // 
            // lblSellOnOrder
            // 
            resources.ApplyResources(this.lblSellOnOrder, "lblSellOnOrder");
            this.lblSellOnOrder.Name = "lblSellOnOrder";
            // 
            // lblPositiveAverageCost
            // 
            resources.ApplyResources(this.lblPositiveAverageCost, "lblPositiveAverageCost");
            this.lblPositiveAverageCost.Name = "lblPositiveAverageCost";
            // 
            // txtValueOnHand
            // 
            resources.ApplyResources(this.txtValueOnHand, "txtValueOnHand");
            this.txtValueOnHand.Name = "txtValueOnHand";
            // 
            // txtQuantityAvailable
            // 
            resources.ApplyResources(this.txtQuantityAvailable, "txtQuantityAvailable");
            this.txtQuantityAvailable.Name = "txtQuantityAvailable";
            // 
            // txtPurchaseOnOrder
            // 
            resources.ApplyResources(this.txtPurchaseOnOrder, "txtPurchaseOnOrder");
            this.txtPurchaseOnOrder.Name = "txtPurchaseOnOrder";
            // 
            // txtSellOnOrder
            // 
            resources.ApplyResources(this.txtSellOnOrder, "txtSellOnOrder");
            this.txtSellOnOrder.Name = "txtSellOnOrder";
            // 
            // txtPositiveAverageCost
            // 
            resources.ApplyResources(this.txtPositiveAverageCost, "txtPositiveAverageCost");
            this.txtPositiveAverageCost.Name = "txtPositiveAverageCost";
            // 
            // txtQtnOnHand
            // 
            resources.ApplyResources(this.txtQtnOnHand, "txtQtnOnHand");
            this.txtQtnOnHand.Name = "txtQtnOnHand";
            // 
            // lblQtyOnHand
            // 
            resources.ApplyResources(this.lblQtyOnHand, "lblQtyOnHand");
            this.lblQtyOnHand.Name = "lblQtyOnHand";
            // 
            // lblCategory
            // 
            resources.ApplyResources(this.lblCategory, "lblCategory");
            this.lblCategory.Name = "lblCategory";
            // 
            // tabPageItemDetails
            // 
            this.tabPageItemDetails.Controls.Add(this.txtCustomField3);
            this.tabPageItemDetails.Controls.Add(this.lblCustomField3);
            this.tabPageItemDetails.Controls.Add(this.txtCustomField2);
            this.tabPageItemDetails.Controls.Add(this.lblCustomField2);
            this.tabPageItemDetails.Controls.Add(this.txtCustomField1);
            this.tabPageItemDetails.Controls.Add(this.lblCustomField1);
            this.tabPageItemDetails.Controls.Add(this.gbLocation);
            this.tabPageItemDetails.Controls.Add(this.gbItemDetails);
            resources.ApplyResources(this.tabPageItemDetails, "tabPageItemDetails");
            this.tabPageItemDetails.Name = "tabPageItemDetails";
            this.tabPageItemDetails.UseVisualStyleBackColor = true;
            // 
            // txtCustomField3
            // 
            resources.ApplyResources(this.txtCustomField3, "txtCustomField3");
            this.txtCustomField3.Name = "txtCustomField3";
            // 
            // lblCustomField3
            // 
            resources.ApplyResources(this.lblCustomField3, "lblCustomField3");
            this.lblCustomField3.Name = "lblCustomField3";
            // 
            // txtCustomField2
            // 
            resources.ApplyResources(this.txtCustomField2, "txtCustomField2");
            this.txtCustomField2.Name = "txtCustomField2";
            // 
            // lblCustomField2
            // 
            resources.ApplyResources(this.lblCustomField2, "lblCustomField2");
            this.lblCustomField2.Name = "lblCustomField2";
            // 
            // txtCustomField1
            // 
            resources.ApplyResources(this.txtCustomField1, "txtCustomField1");
            this.txtCustomField1.Name = "txtCustomField1";
            // 
            // lblCustomField1
            // 
            resources.ApplyResources(this.lblCustomField1, "lblCustomField1");
            this.lblCustomField1.Name = "lblCustomField1";
            // 
            // gbLocation
            // 
            resources.ApplyResources(this.gbLocation, "gbLocation");
            this.gbLocation.BackgroundColor = System.Drawing.Color.White;
            this.gbLocation.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbLocation.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbLocation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbLocation.BorderWidth = 1F;
            this.gbLocation.Caption = "";
            this.gbLocation.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbLocation.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbLocation.CaptionHeight = 25;
            this.gbLocation.CaptionVisible = true;
            this.gbLocation.Controls.Add(this.txtLocationDescription);
            this.gbLocation.Controls.Add(this.cboLocation);
            this.gbLocation.Controls.Add(this.lblLocation);
            this.gbLocation.CornerRadius = 5;
            this.gbLocation.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbLocation.DropShadowThickness = 3;
            this.gbLocation.DropShadowVisible = false;
            this.gbLocation.Name = "gbLocation";
            this.gbLocation.TabStop = false;
            // 
            // txtLocationDescription
            // 
            resources.ApplyResources(this.txtLocationDescription, "txtLocationDescription");
            this.txtLocationDescription.Name = "txtLocationDescription";
            // 
            // cboLocation
            // 
            this.cboLocation.FormattingEnabled = true;
            resources.ApplyResources(this.cboLocation, "cboLocation");
            this.cboLocation.Name = "cboLocation";
            // 
            // lblLocation
            // 
            resources.ApplyResources(this.lblLocation, "lblLocation");
            this.lblLocation.Name = "lblLocation";
            // 
            // gbItemDetails
            // 
            resources.ApplyResources(this.gbItemDetails, "gbItemDetails");
            this.gbItemDetails.BackgroundColor = System.Drawing.Color.White;
            this.gbItemDetails.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbItemDetails.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbItemDetails.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbItemDetails.BorderWidth = 1F;
            this.gbItemDetails.Caption = "";
            this.gbItemDetails.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbItemDetails.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbItemDetails.CaptionHeight = 25;
            this.gbItemDetails.CaptionVisible = true;
            this.gbItemDetails.Controls.Add(this.label1);
            this.gbItemDetails.Controls.Add(this.lblPicture);
            this.gbItemDetails.Controls.Add(this.pbPicture);
            this.gbItemDetails.Controls.Add(this.chkUseDescription);
            this.gbItemDetails.Controls.Add(this.txtDescription);
            this.gbItemDetails.Controls.Add(this.lblDescription);
            this.gbItemDetails.CornerRadius = 5;
            this.gbItemDetails.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbItemDetails.DropShadowThickness = 3;
            this.gbItemDetails.DropShadowVisible = false;
            this.gbItemDetails.Name = "gbItemDetails";
            this.gbItemDetails.TabStop = false;
            // 
            // lblPicture
            // 
            resources.ApplyResources(this.lblPicture, "lblPicture");
            this.lblPicture.Name = "lblPicture";
            // 
            // pbPicture
            // 
            this.pbPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pbPicture, "pbPicture");
            this.pbPicture.Name = "pbPicture";
            this.pbPicture.TabStop = false;
            this.pbPicture.DoubleClick += new System.EventHandler(this.pbItemPicture_DoubleClick);
            // 
            // chkUseDescription
            // 
            resources.ApplyResources(this.chkUseDescription, "chkUseDescription");
            this.chkUseDescription.Name = "chkUseDescription";
            this.chkUseDescription.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            resources.ApplyResources(this.txtDescription, "txtDescription");
            this.txtDescription.Name = "txtDescription";
            // 
            // lblDescription
            // 
            resources.ApplyResources(this.lblDescription, "lblDescription");
            this.lblDescription.Name = "lblDescription";
            // 
            // tabPageCharacteristics
            // 
            this.tabPageCharacteristics.Controls.Add(this.grpCustomCharacteristics);
            this.tabPageCharacteristics.Controls.Add(this.gbCharacteristics);
            resources.ApplyResources(this.tabPageCharacteristics, "tabPageCharacteristics");
            this.tabPageCharacteristics.Name = "tabPageCharacteristics";
            this.tabPageCharacteristics.UseVisualStyleBackColor = true;
            // 
            // grpCustomCharacteristics
            // 
            resources.ApplyResources(this.grpCustomCharacteristics, "grpCustomCharacteristics");
            this.grpCustomCharacteristics.BackgroundColor = System.Drawing.Color.White;
            this.grpCustomCharacteristics.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.grpCustomCharacteristics.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.grpCustomCharacteristics.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.grpCustomCharacteristics.BorderWidth = 1F;
            this.grpCustomCharacteristics.Caption = "";
            this.grpCustomCharacteristics.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.grpCustomCharacteristics.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.grpCustomCharacteristics.CaptionHeight = 25;
            this.grpCustomCharacteristics.CaptionVisible = true;
            this.grpCustomCharacteristics.Controls.Add(this.btnDelItemDataField);
            this.grpCustomCharacteristics.Controls.Add(this.btnCreateItemDataField);
            this.grpCustomCharacteristics.Controls.Add(this.dgvItemDataFields);
            this.grpCustomCharacteristics.CornerRadius = 5;
            this.grpCustomCharacteristics.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.grpCustomCharacteristics.DropShadowThickness = 3;
            this.grpCustomCharacteristics.DropShadowVisible = false;
            this.grpCustomCharacteristics.Name = "grpCustomCharacteristics";
            this.grpCustomCharacteristics.TabStop = false;
            // 
            // btnDelItemDataField
            // 
            resources.ApplyResources(this.btnDelItemDataField, "btnDelItemDataField");
            this.btnDelItemDataField.BackgroundImage = global::DacII.Properties.Resources.delete_16x16;
            this.btnDelItemDataField.Name = "btnDelItemDataField";
            this.btnDelItemDataField.Click += new System.EventHandler(this.btnDelItemDataField_Click);
            // 
            // btnCreateItemDataField
            // 
            resources.ApplyResources(this.btnCreateItemDataField, "btnCreateItemDataField");
            this.btnCreateItemDataField.Name = "btnCreateItemDataField";
            this.btnCreateItemDataField.Click += new System.EventHandler(this.btnCreateItemDataField_Click);
            // 
            // dgvItemDataFields
            // 
            this.dgvItemDataFields.AllowUserToAddRows = false;
            this.dgvItemDataFields.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvItemDataFields.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.dgvItemDataFields, "dgvItemDataFields");
            this.dgvItemDataFields.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItemDataFields.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvItemDataFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemDataFields.MultiSelect = false;
            this.dgvItemDataFields.Name = "dgvItemDataFields";
            this.dgvItemDataFields.RowHeadersVisible = false;
            this.dgvItemDataFields.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItemDataFields.DoubleClick += new System.EventHandler(this.dgvItemDataFields_DoubleClick);
            // 
            // gbCharacteristics
            // 
            resources.ApplyResources(this.gbCharacteristics, "gbCharacteristics");
            this.gbCharacteristics.BackgroundColor = System.Drawing.Color.White;
            this.gbCharacteristics.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbCharacteristics.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbCharacteristics.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbCharacteristics.BorderWidth = 1F;
            this.gbCharacteristics.Caption = "";
            this.gbCharacteristics.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbCharacteristics.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbCharacteristics.CaptionHeight = 25;
            this.gbCharacteristics.CaptionVisible = true;
            this.gbCharacteristics.Controls.Add(this.cboSize);
            this.gbCharacteristics.Controls.Add(this.cboGender);
            this.gbCharacteristics.Controls.Add(this.dpExpiryDate);
            this.gbCharacteristics.Controls.Add(this.lblExpiryDate);
            this.gbCharacteristics.Controls.Add(this.lblGender);
            this.gbCharacteristics.Controls.Add(this.txtColor);
            this.gbCharacteristics.Controls.Add(this.lblColor);
            this.gbCharacteristics.Controls.Add(this.lblSize);
            this.gbCharacteristics.Controls.Add(this.txtBrand);
            this.gbCharacteristics.Controls.Add(this.lblBrand);
            this.gbCharacteristics.Controls.Add(this.txtSerialNumber);
            this.gbCharacteristics.Controls.Add(this.lblSerialNumber);
            this.gbCharacteristics.Controls.Add(this.txtBatchNumber);
            this.gbCharacteristics.Controls.Add(this.lblBatchNumber);
            this.gbCharacteristics.CornerRadius = 5;
            this.gbCharacteristics.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbCharacteristics.DropShadowThickness = 3;
            this.gbCharacteristics.DropShadowVisible = false;
            this.gbCharacteristics.Name = "gbCharacteristics";
            this.gbCharacteristics.TabStop = false;
            // 
            // cboSize
            // 
            this.cboSize.FormattingEnabled = true;
            resources.ApplyResources(this.cboSize, "cboSize");
            this.cboSize.Name = "cboSize";
            // 
            // cboGender
            // 
            this.cboGender.FormattingEnabled = true;
            resources.ApplyResources(this.cboGender, "cboGender");
            this.cboGender.Name = "cboGender";
            // 
            // dpExpiryDate
            // 
            this.dpExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dpExpiryDate, "dpExpiryDate");
            this.dpExpiryDate.Name = "dpExpiryDate";
            this.dpExpiryDate.ShowCheckBox = true;
            // 
            // lblExpiryDate
            // 
            resources.ApplyResources(this.lblExpiryDate, "lblExpiryDate");
            this.lblExpiryDate.Name = "lblExpiryDate";
            // 
            // lblGender
            // 
            resources.ApplyResources(this.lblGender, "lblGender");
            this.lblGender.Name = "lblGender";
            // 
            // txtColor
            // 
            resources.ApplyResources(this.txtColor, "txtColor");
            this.txtColor.Name = "txtColor";
            // 
            // lblColor
            // 
            resources.ApplyResources(this.lblColor, "lblColor");
            this.lblColor.Name = "lblColor";
            // 
            // lblSize
            // 
            resources.ApplyResources(this.lblSize, "lblSize");
            this.lblSize.Name = "lblSize";
            // 
            // txtBrand
            // 
            resources.ApplyResources(this.txtBrand, "txtBrand");
            this.txtBrand.Name = "txtBrand";
            // 
            // lblBrand
            // 
            resources.ApplyResources(this.lblBrand, "lblBrand");
            this.lblBrand.Name = "lblBrand";
            // 
            // txtSerialNumber
            // 
            resources.ApplyResources(this.txtSerialNumber, "txtSerialNumber");
            this.txtSerialNumber.Name = "txtSerialNumber";
            // 
            // lblSerialNumber
            // 
            resources.ApplyResources(this.lblSerialNumber, "lblSerialNumber");
            this.lblSerialNumber.Name = "lblSerialNumber";
            // 
            // txtBatchNumber
            // 
            resources.ApplyResources(this.txtBatchNumber, "txtBatchNumber");
            this.txtBatchNumber.Name = "txtBatchNumber";
            // 
            // lblBatchNumber
            // 
            resources.ApplyResources(this.lblBatchNumber, "lblBatchNumber");
            this.lblBatchNumber.Name = "lblBatchNumber";
            // 
            // tabPageBuyingDetails
            // 
            this.tabPageBuyingDetails.Controls.Add(this.groupBox7);
            this.tabPageBuyingDetails.Controls.Add(this.groupBox5);
            resources.ApplyResources(this.tabPageBuyingDetails, "tabPageBuyingDetails");
            this.tabPageBuyingDetails.Name = "tabPageBuyingDetails";
            this.tabPageBuyingDetails.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            resources.ApplyResources(this.groupBox7, "groupBox7");
            this.groupBox7.BackgroundColor = System.Drawing.Color.White;
            this.groupBox7.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.groupBox7.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.groupBox7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.groupBox7.BorderWidth = 1F;
            this.groupBox7.Caption = "";
            this.groupBox7.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.groupBox7.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.groupBox7.CaptionHeight = 25;
            this.groupBox7.CaptionVisible = true;
            this.groupBox7.Controls.Add(this.txtDefaultReoderQuantity);
            this.groupBox7.Controls.Add(this.cboPrimarySupplier);
            this.groupBox7.Controls.Add(this.lblDefaultReoderQuantity);
            this.groupBox7.Controls.Add(this.txtSupplierItemNumber);
            this.groupBox7.Controls.Add(this.lblSupplierItemNumber);
            this.groupBox7.Controls.Add(this.lblPrimarySupplier);
            this.groupBox7.Controls.Add(this.txtMinLevelBeforeReorder);
            this.groupBox7.Controls.Add(this.lblMinLevelBeforeReorder);
            this.groupBox7.CornerRadius = 5;
            this.groupBox7.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.groupBox7.DropShadowThickness = 3;
            this.groupBox7.DropShadowVisible = false;
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.TabStop = false;
            // 
            // txtDefaultReoderQuantity
            // 
            resources.ApplyResources(this.txtDefaultReoderQuantity, "txtDefaultReoderQuantity");
            this.txtDefaultReoderQuantity.Name = "txtDefaultReoderQuantity";
            // 
            // cboPrimarySupplier
            // 
            this.cboPrimarySupplier.FormattingEnabled = true;
            resources.ApplyResources(this.cboPrimarySupplier, "cboPrimarySupplier");
            this.cboPrimarySupplier.Name = "cboPrimarySupplier";
            // 
            // lblDefaultReoderQuantity
            // 
            resources.ApplyResources(this.lblDefaultReoderQuantity, "lblDefaultReoderQuantity");
            this.lblDefaultReoderQuantity.Name = "lblDefaultReoderQuantity";
            // 
            // txtSupplierItemNumber
            // 
            resources.ApplyResources(this.txtSupplierItemNumber, "txtSupplierItemNumber");
            this.txtSupplierItemNumber.Name = "txtSupplierItemNumber";
            // 
            // lblSupplierItemNumber
            // 
            resources.ApplyResources(this.lblSupplierItemNumber, "lblSupplierItemNumber");
            this.lblSupplierItemNumber.Name = "lblSupplierItemNumber";
            // 
            // lblPrimarySupplier
            // 
            resources.ApplyResources(this.lblPrimarySupplier, "lblPrimarySupplier");
            this.lblPrimarySupplier.Name = "lblPrimarySupplier";
            // 
            // txtMinLevelBeforeReorder
            // 
            resources.ApplyResources(this.txtMinLevelBeforeReorder, "txtMinLevelBeforeReorder");
            this.txtMinLevelBeforeReorder.Name = "txtMinLevelBeforeReorder";
            // 
            // lblMinLevelBeforeReorder
            // 
            resources.ApplyResources(this.lblMinLevelBeforeReorder, "lblMinLevelBeforeReorder");
            this.lblMinLevelBeforeReorder.Name = "lblMinLevelBeforeReorder";
            // 
            // groupBox5
            // 
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.BackgroundColor = System.Drawing.Color.White;
            this.groupBox5.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.groupBox5.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.groupBox5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.groupBox5.BorderWidth = 1F;
            this.groupBox5.Caption = "";
            this.groupBox5.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.groupBox5.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.groupBox5.CaptionHeight = 25;
            this.groupBox5.CaptionVisible = true;
            this.groupBox5.Controls.Add(this.txtBuyTaxCodeID);
            this.groupBox5.Controls.Add(this.cboBuyTaxCode);
            this.groupBox5.Controls.Add(this.lblBuyTaxCode);
            this.groupBox5.Controls.Add(this.txtBuyUnitQuantity);
            this.groupBox5.Controls.Add(this.lblBuyUnitQuantity);
            this.groupBox5.Controls.Add(this.txtBuyUnitMeasure);
            this.groupBox5.Controls.Add(this.lblBuyUnitMeasure);
            this.groupBox5.Controls.Add(this.txtStandardCost);
            this.groupBox5.Controls.Add(this.lblStandardCost);
            this.groupBox5.Controls.Add(this.txtLastUnitPrice);
            this.groupBox5.Controls.Add(this.lblLastUnitPrice);
            this.groupBox5.CornerRadius = 5;
            this.groupBox5.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.groupBox5.DropShadowThickness = 3;
            this.groupBox5.DropShadowVisible = false;
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // txtBuyTaxCodeID
            // 
            resources.ApplyResources(this.txtBuyTaxCodeID, "txtBuyTaxCodeID");
            this.txtBuyTaxCodeID.Name = "txtBuyTaxCodeID";
            // 
            // cboBuyTaxCode
            // 
            this.cboBuyTaxCode.FormattingEnabled = true;
            resources.ApplyResources(this.cboBuyTaxCode, "cboBuyTaxCode");
            this.cboBuyTaxCode.Name = "cboBuyTaxCode";
            this.cboBuyTaxCode.SelectedIndexChanged += new System.EventHandler(this.OnBuyTaxCodeChanged);
            // 
            // lblBuyTaxCode
            // 
            resources.ApplyResources(this.lblBuyTaxCode, "lblBuyTaxCode");
            this.lblBuyTaxCode.Name = "lblBuyTaxCode";
            // 
            // txtBuyUnitQuantity
            // 
            resources.ApplyResources(this.txtBuyUnitQuantity, "txtBuyUnitQuantity");
            this.txtBuyUnitQuantity.Name = "txtBuyUnitQuantity";
            // 
            // lblBuyUnitQuantity
            // 
            resources.ApplyResources(this.lblBuyUnitQuantity, "lblBuyUnitQuantity");
            this.lblBuyUnitQuantity.Name = "lblBuyUnitQuantity";
            // 
            // txtBuyUnitMeasure
            // 
            resources.ApplyResources(this.txtBuyUnitMeasure, "txtBuyUnitMeasure");
            this.txtBuyUnitMeasure.Name = "txtBuyUnitMeasure";
            // 
            // lblBuyUnitMeasure
            // 
            resources.ApplyResources(this.lblBuyUnitMeasure, "lblBuyUnitMeasure");
            this.lblBuyUnitMeasure.Name = "lblBuyUnitMeasure";
            // 
            // txtStandardCost
            // 
            resources.ApplyResources(this.txtStandardCost, "txtStandardCost");
            this.txtStandardCost.Name = "txtStandardCost";
            // 
            // lblStandardCost
            // 
            resources.ApplyResources(this.lblStandardCost, "lblStandardCost");
            this.lblStandardCost.Name = "lblStandardCost";
            // 
            // txtLastUnitPrice
            // 
            resources.ApplyResources(this.txtLastUnitPrice, "txtLastUnitPrice");
            this.txtLastUnitPrice.Name = "txtLastUnitPrice";
            // 
            // lblLastUnitPrice
            // 
            resources.ApplyResources(this.lblLastUnitPrice, "lblLastUnitPrice");
            this.lblLastUnitPrice.Name = "lblLastUnitPrice";
            // 
            // tabPageSellingDetails
            // 
            this.tabPageSellingDetails.Controls.Add(this.groupBox10);
            resources.ApplyResources(this.tabPageSellingDetails, "tabPageSellingDetails");
            this.tabPageSellingDetails.Name = "tabPageSellingDetails";
            this.tabPageSellingDetails.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            resources.ApplyResources(this.groupBox10, "groupBox10");
            this.groupBox10.BackgroundColor = System.Drawing.Color.White;
            this.groupBox10.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.groupBox10.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.groupBox10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.groupBox10.BorderWidth = 1F;
            this.groupBox10.Caption = "";
            this.groupBox10.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.groupBox10.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.groupBox10.CaptionHeight = 25;
            this.groupBox10.CaptionVisible = true;
            this.groupBox10.Controls.Add(this.chkPriceIsInclusive);
            this.groupBox10.Controls.Add(this.txtSellTaxCodeID);
            this.groupBox10.Controls.Add(this.cboSalesTaxCalcBasis);
            this.groupBox10.Controls.Add(this.cboSellTaxCode);
            this.groupBox10.Controls.Add(this.lblBaseSellingPrice);
            this.groupBox10.Controls.Add(this.lblSalesTaxCalcBasis);
            this.groupBox10.Controls.Add(this.txtBaseSellingPrice);
            this.groupBox10.Controls.Add(this.lblSellTaxCode);
            this.groupBox10.Controls.Add(this.txtSellUnitQuantity);
            this.groupBox10.Controls.Add(this.lblSellUnitQuantity);
            this.groupBox10.Controls.Add(this.txtSellUnitMeasure);
            this.groupBox10.Controls.Add(this.lblSellUnitMeasure);
            this.groupBox10.CornerRadius = 5;
            this.groupBox10.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.groupBox10.DropShadowThickness = 3;
            this.groupBox10.DropShadowVisible = false;
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.TabStop = false;
            // 
            // chkPriceIsInclusive
            // 
            resources.ApplyResources(this.chkPriceIsInclusive, "chkPriceIsInclusive");
            this.chkPriceIsInclusive.Name = "chkPriceIsInclusive";
            this.chkPriceIsInclusive.UseVisualStyleBackColor = true;
            // 
            // txtSellTaxCodeID
            // 
            resources.ApplyResources(this.txtSellTaxCodeID, "txtSellTaxCodeID");
            this.txtSellTaxCodeID.Name = "txtSellTaxCodeID";
            // 
            // cboSalesTaxCalcBasis
            // 
            this.cboSalesTaxCalcBasis.FormattingEnabled = true;
            resources.ApplyResources(this.cboSalesTaxCalcBasis, "cboSalesTaxCalcBasis");
            this.cboSalesTaxCalcBasis.Name = "cboSalesTaxCalcBasis";
            // 
            // cboSellTaxCode
            // 
            this.cboSellTaxCode.FormattingEnabled = true;
            resources.ApplyResources(this.cboSellTaxCode, "cboSellTaxCode");
            this.cboSellTaxCode.Name = "cboSellTaxCode";
            this.cboSellTaxCode.SelectedIndexChanged += new System.EventHandler(this.OnSellTaxCodeChanged);
            // 
            // lblBaseSellingPrice
            // 
            resources.ApplyResources(this.lblBaseSellingPrice, "lblBaseSellingPrice");
            this.lblBaseSellingPrice.Name = "lblBaseSellingPrice";
            // 
            // lblSalesTaxCalcBasis
            // 
            resources.ApplyResources(this.lblSalesTaxCalcBasis, "lblSalesTaxCalcBasis");
            this.lblSalesTaxCalcBasis.Name = "lblSalesTaxCalcBasis";
            // 
            // txtBaseSellingPrice
            // 
            resources.ApplyResources(this.txtBaseSellingPrice, "txtBaseSellingPrice");
            this.txtBaseSellingPrice.Name = "txtBaseSellingPrice";
            // 
            // lblSellTaxCode
            // 
            resources.ApplyResources(this.lblSellTaxCode, "lblSellTaxCode");
            this.lblSellTaxCode.Name = "lblSellTaxCode";
            // 
            // txtSellUnitQuantity
            // 
            resources.ApplyResources(this.txtSellUnitQuantity, "txtSellUnitQuantity");
            this.txtSellUnitQuantity.Name = "txtSellUnitQuantity";
            // 
            // lblSellUnitQuantity
            // 
            resources.ApplyResources(this.lblSellUnitQuantity, "lblSellUnitQuantity");
            this.lblSellUnitQuantity.Name = "lblSellUnitQuantity";
            // 
            // txtSellUnitMeasure
            // 
            resources.ApplyResources(this.txtSellUnitMeasure, "txtSellUnitMeasure");
            this.txtSellUnitMeasure.Name = "txtSellUnitMeasure";
            // 
            // lblSellUnitMeasure
            // 
            resources.ApplyResources(this.lblSellUnitMeasure, "lblSellUnitMeasure");
            this.lblSellUnitMeasure.Name = "lblSellUnitMeasure";
            // 
            // txtItemNumber
            // 
            resources.ApplyResources(this.txtItemNumber, "txtItemNumber");
            this.txtItemNumber.Name = "txtItemNumber";
            // 
            // lblItemNumber
            // 
            resources.ApplyResources(this.lblItemNumber, "lblItemNumber");
            this.lblItemNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblItemNumber.Name = "lblItemNumber";
            // 
            // gbItemSummary
            // 
            resources.ApplyResources(this.gbItemSummary, "gbItemSummary");
            this.gbItemSummary.BackgroundColor = System.Drawing.Color.White;
            this.gbItemSummary.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbItemSummary.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbItemSummary.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbItemSummary.BorderWidth = 1F;
            this.gbItemSummary.Caption = "";
            this.gbItemSummary.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbItemSummary.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbItemSummary.CaptionHeight = 25;
            this.gbItemSummary.CaptionVisible = true;
            this.gbItemSummary.Controls.Add(this.txtItemName);
            this.gbItemSummary.Controls.Add(this.lblItemName);
            this.gbItemSummary.Controls.Add(this.txtItemNumber);
            this.gbItemSummary.Controls.Add(this.lblItemNumber);
            this.gbItemSummary.CornerRadius = 5;
            this.gbItemSummary.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbItemSummary.DropShadowThickness = 3;
            this.gbItemSummary.DropShadowVisible = true;
            this.gbItemSummary.Name = "gbItemSummary";
            this.gbItemSummary.TabStop = false;
            // 
            // txtItemName
            // 
            resources.ApplyResources(this.txtItemName, "txtItemName");
            this.txtItemName.Name = "txtItemName";
            // 
            // lblItemName
            // 
            resources.ApplyResources(this.lblItemName, "lblItemName");
            this.lblItemName.BackColor = System.Drawing.Color.Transparent;
            this.lblItemName.Name = "lblItemName";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrint.Image = global::DacII.Properties.Resources.print_32x32;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::DacII.Properties.Resources.cancel_24x24;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRecord
            // 
            resources.ApplyResources(this.btnRecord, "btnRecord");
            this.btnRecord.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRecord.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRecord.Image = global::DacII.Properties.Resources.save_32x32;
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.UseVisualStyleBackColor = false;
            this.btnRecord.Click += new System.EventHandler(this.Record);
            // 
            // btnBarcode
            // 
            resources.ApplyResources(this.btnBarcode, "btnBarcode");
            this.btnBarcode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBarcode.BackgroundImage = global::DacII.Properties.Resources.barcode_48x48;
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.UseVisualStyleBackColor = false;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // czRoundedGroupBox1
            // 
            resources.ApplyResources(this.czRoundedGroupBox1, "czRoundedGroupBox1");
            this.czRoundedGroupBox1.BackgroundColor = System.Drawing.Color.White;
            this.czRoundedGroupBox1.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.czRoundedGroupBox1.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.czRoundedGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.czRoundedGroupBox1.BorderWidth = 1F;
            this.czRoundedGroupBox1.Caption = "Items --> Item Information";
            this.czRoundedGroupBox1.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.czRoundedGroupBox1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.czRoundedGroupBox1.CaptionHeight = 25;
            this.czRoundedGroupBox1.CaptionVisible = true;
            this.czRoundedGroupBox1.Controls.Add(this.tabControlItemScreen);
            this.czRoundedGroupBox1.CornerRadius = 5;
            this.czRoundedGroupBox1.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.czRoundedGroupBox1.DropShadowThickness = 3;
            this.czRoundedGroupBox1.DropShadowVisible = true;
            this.czRoundedGroupBox1.Name = "czRoundedGroupBox1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // FrmItemInformation
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.Controls.Add(this.czRoundedGroupBox1);
            this.Controls.Add(this.btnBarcode);
            this.Controls.Add(this.gbItemSummary);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRecord);
            this.Name = "FrmItemInformation";
            this.tabControlItemScreen.ResumeLayout(false);
            this.tabPageItemProfile.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPageItemDetails.ResumeLayout(false);
            this.tabPageItemDetails.PerformLayout();
            this.gbLocation.ResumeLayout(false);
            this.gbLocation.PerformLayout();
            this.gbItemDetails.ResumeLayout(false);
            this.gbItemDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).EndInit();
            this.tabPageCharacteristics.ResumeLayout(false);
            this.grpCustomCharacteristics.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemDataFields)).EndInit();
            this.gbCharacteristics.ResumeLayout(false);
            this.gbCharacteristics.PerformLayout();
            this.tabPageBuyingDetails.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPageSellingDetails.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.gbItemSummary.ResumeLayout(false);
            this.gbItemSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.czRoundedGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlItemScreen;
        private System.Windows.Forms.TabPage tabPageItemProfile;
        private System.Windows.Forms.TabPage tabPageItemDetails;
        private System.Windows.Forms.TabPage tabPageBuyingDetails;
        private System.Windows.Forms.TabPage tabPageSellingDetails;
        private System.Windows.Forms.CZRoundedGroupBox groupBox6;
        private System.Windows.Forms.Label lblInventoryAccount;
        private System.Windows.Forms.Label lblIncomeAccount;
        private System.Windows.Forms.Label lblExpenseAccount;
        private System.Windows.Forms.CheckBox chkItemIsInventoried;
        private System.Windows.Forms.CheckBox chkItemIsSold;
        private System.Windows.Forms.CheckBox chkItemIsBought;
        private System.Windows.Forms.CZRoundedGroupBox groupBox4;
        private System.Windows.Forms.Label lblPositiveAverageCost;
        private System.Windows.Forms.TextBox txtPositiveAverageCost;
        private System.Windows.Forms.TextBox txtQtnOnHand;
        private System.Windows.Forms.Label lblQtyOnHand;
        private System.Windows.Forms.TextBox txtItemNumber;
        private System.Windows.Forms.Label lblItemNumber;
        private System.Windows.Forms.CZRoundedGroupBox gbItemDetails;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.CZRoundedGroupBox groupBox5;
        private System.Windows.Forms.TextBox txtLastUnitPrice;
        private System.Windows.Forms.Label lblLastUnitPrice;
        private System.Windows.Forms.Label lblValueOnHand;
        private System.Windows.Forms.TextBox txtValueOnHand;
        private System.Windows.Forms.Label lblQuantityAvailable;
        private System.Windows.Forms.Label lblPurchaseOnOrder;
        private System.Windows.Forms.Label lblSellOnOrder;
        private System.Windows.Forms.TextBox txtQuantityAvailable;
        private System.Windows.Forms.TextBox txtPurchaseOnOrder;
        private System.Windows.Forms.TextBox txtSellOnOrder;
        private System.Windows.Forms.CheckBox chkUseDescription;
        private System.Windows.Forms.TextBox txtBuyUnitQuantity;
        private System.Windows.Forms.Label lblBuyUnitQuantity;
        private System.Windows.Forms.TextBox txtBuyUnitMeasure;
        private System.Windows.Forms.Label lblBuyUnitMeasure;
        private System.Windows.Forms.TextBox txtStandardCost;
        private System.Windows.Forms.Label lblStandardCost;
        private System.Windows.Forms.Label lblBaseSellingPrice;
        private System.Windows.Forms.TextBox txtBaseSellingPrice;
        private System.Windows.Forms.TextBox txtBuyTaxCodeID;
        private System.Windows.Forms.ComboBox cboBuyTaxCode;
        private System.Windows.Forms.Label lblBuyTaxCode;
        private System.Windows.Forms.CZRoundedGroupBox groupBox10;
        private System.Windows.Forms.TextBox txtSellTaxCodeID;
        private System.Windows.Forms.ComboBox cboSellTaxCode;
        private System.Windows.Forms.Label lblSellTaxCode;
        private System.Windows.Forms.TextBox txtSellUnitQuantity;
        private System.Windows.Forms.Label lblSellUnitQuantity;
        private System.Windows.Forms.TextBox txtSellUnitMeasure;
        private System.Windows.Forms.Label lblSellUnitMeasure;
        private System.Windows.Forms.CZRoundedGroupBox groupBox7;
        private System.Windows.Forms.TextBox txtDefaultReoderQuantity;
        private System.Windows.Forms.Label lblDefaultReoderQuantity;
        private System.Windows.Forms.TextBox txtSupplierItemNumber;
        private System.Windows.Forms.Label lblSupplierItemNumber;
        private System.Windows.Forms.Label lblPrimarySupplier;
        private System.Windows.Forms.TextBox txtMinLevelBeforeReorder;
        private System.Windows.Forms.Label lblMinLevelBeforeReorder;
        private System.Windows.Forms.ComboBox cboPrimarySupplier;
        private System.Windows.Forms.CheckBox chkPriceIsInclusive;
        private System.Windows.Forms.ComboBox cboSalesTaxCalcBasis;
        private System.Windows.Forms.Label lblSalesTaxCalcBasis;
        private System.Windows.Forms.TabPage tabPageCharacteristics;
        private System.Windows.Forms.CheckBox chkInactive;
        private System.Windows.Forms.PictureBox pbPicture;
        private System.Windows.Forms.Label lblPicture;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.CZRoundedGroupBox gbLocation;
        private System.Windows.Forms.TextBox txtLocationDescription;
        private System.Windows.Forms.ComboBox cboLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.ComboBox cboIncomeAccount;
        private System.Windows.Forms.ComboBox cboInventoryAccount;
        private System.Windows.Forms.ComboBox cboExpenseAccount;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.CZRoundedGroupBox gbItemSummary;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.CZRoundedGroupBox gbCharacteristics;
        private System.Windows.Forms.ComboBox cboSize;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.DateTimePicker dpExpiryDate;
        private System.Windows.Forms.Label lblExpiryDate;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.TextBox txtBatchNumber;
        private System.Windows.Forms.Label lblBatchNumber;
        private System.Windows.Forms.CZRoundedGroupBox grpCustomCharacteristics;
        private System.Windows.Forms.DataGridView dgvItemDataFields;
        private System.Windows.Forms.Button btnDelItemDataField;
        private System.Windows.Forms.Button btnCreateItemDataField;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox txtCustomField3;
        private System.Windows.Forms.Label lblCustomField3;
        private System.Windows.Forms.TextBox txtCustomField2;
        private System.Windows.Forms.Label lblCustomField2;
        private System.Windows.Forms.TextBox txtCustomField1;
        private System.Windows.Forms.Label lblCustomField1;
        private System.Windows.Forms.Button btnBarcode;
        private System.Windows.Forms.CZRoundedGroupBox czRoundedGroupBox1;
        private System.Windows.Forms.Label label1;
    }
}