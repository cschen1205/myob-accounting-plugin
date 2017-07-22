namespace DacII.WinForms.Setup
{
    partial class FrmPreference
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
            this.tcPreference = new System.Windows.Forms.TabControl();
            this.tpSales = new System.Windows.Forms.TabPage();
            this.gbSales = new System.Windows.Forms.CZRoundedGroupBox();
            this.tlpSales = new System.Windows.Forms.TableLayoutPanel();
            this.gbSalesChkGroup = new System.Windows.Forms.CZRoundedGroupBox();
            this.rbSalesReturn = new System.Windows.Forms.RadioButton();
            this.rbDispatch = new System.Windows.Forms.RadioButton();
            this.rbOrderNo = new System.Windows.Forms.RadioButton();
            this.rbQuoteNo = new System.Windows.Forms.RadioButton();
            this.rbInvoiceNo = new System.Windows.Forms.RadioButton();
            this.lblPrefixDesign = new System.Windows.Forms.Label();
            this.tcSalesSettings = new System.Windows.Forms.TabControl();
            this.tpSaleCurrentSettings = new System.Windows.Forms.TabPage();
            this.txtSequenceNo = new System.Windows.Forms.TextBox();
            this.lblSequenceNo = new System.Windows.Forms.Label();
            this.txtSalesPrefix = new System.Windows.Forms.TextBox();
            this.lblSalesPrefix = new System.Windows.Forms.Label();
            this.tpNewSettings = new System.Windows.Forms.TabPage();
            this.chkAllowMoreThanOrderQty = new System.Windows.Forms.CheckBox();
            this.chkAllowOverCreditLimit = new System.Windows.Forms.CheckBox();
            this.chkKeepSellingPriceFixed = new System.Windows.Forms.CheckBox();
            this.tpPurchases = new System.Windows.Forms.TabPage();
            this.gbPurchases = new System.Windows.Forms.CZRoundedGroupBox();
            this.gbgbPurchases = new System.Windows.Forms.CZRoundedGroupBox();
            this.chkAllowMoreThanQty = new System.Windows.Forms.CheckBox();
            this.chkShowTheCostInGRN = new System.Windows.Forms.CheckBox();
            this.tpSecurity = new System.Windows.Forms.TabPage();
            this.gbSecurity = new System.Windows.Forms.CZRoundedGroupBox();
            this.btnDelSecurity = new System.Windows.Forms.Button();
            this.btnEditSecurity = new System.Windows.Forms.Button();
            this.btnNewSecurity = new System.Windows.Forms.Button();
            this.tcSecurity = new System.Windows.Forms.TabControl();
            this.tpSecurityList = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSecurityList = new System.Windows.Forms.DataGridView();
            this.tpSecurityDetail = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.lblPurchaseSequenceNo = new System.Windows.Forms.Label();
            this.txtPurchasePrefix = new System.Windows.Forms.TextBox();
            this.lblPurchasePrefix = new System.Windows.Forms.Label();
            this.cboSequenceNo = new System.Windows.Forms.ComboBox();
            this.txtSequenceFormat = new System.Windows.Forms.TextBox();
            this.lblSequenceFormat = new System.Windows.Forms.Label();
            this.tcPreference.SuspendLayout();
            this.tpSales.SuspendLayout();
            this.gbSales.SuspendLayout();
            this.tlpSales.SuspendLayout();
            this.gbSalesChkGroup.SuspendLayout();
            this.tcSalesSettings.SuspendLayout();
            this.tpSaleCurrentSettings.SuspendLayout();
            this.tpPurchases.SuspendLayout();
            this.gbPurchases.SuspendLayout();
            this.gbgbPurchases.SuspendLayout();
            this.tpSecurity.SuspendLayout();
            this.gbSecurity.SuspendLayout();
            this.tcSecurity.SuspendLayout();
            this.tpSecurityList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSecurityList)).BeginInit();
            this.SuspendLayout();
            // 
            // tcPreference
            // 
            this.tcPreference.Controls.Add(this.tpSales);
            this.tcPreference.Controls.Add(this.tpPurchases);
            this.tcPreference.Controls.Add(this.tpSecurity);
            this.tcPreference.Location = new System.Drawing.Point(12, 12);
            this.tcPreference.Name = "tcPreference";
            this.tcPreference.SelectedIndex = 0;
            this.tcPreference.Size = new System.Drawing.Size(638, 408);
            this.tcPreference.TabIndex = 0;
            // 
            // tpSales
            // 
            this.tpSales.Controls.Add(this.gbSales);
            this.tpSales.Location = new System.Drawing.Point(4, 22);
            this.tpSales.Name = "tpSales";
            this.tpSales.Padding = new System.Windows.Forms.Padding(3);
            this.tpSales.Size = new System.Drawing.Size(630, 382);
            this.tpSales.TabIndex = 0;
            this.tpSales.Text = "Sales";
            this.tpSales.UseVisualStyleBackColor = true;
            // 
            // gbSales
            // 
            this.gbSales.Controls.Add(this.tlpSales);
            this.gbSales.Controls.Add(this.chkAllowMoreThanOrderQty);
            this.gbSales.Controls.Add(this.chkAllowOverCreditLimit);
            this.gbSales.Controls.Add(this.chkKeepSellingPriceFixed);
            this.gbSales.Location = new System.Drawing.Point(6, 3);
            this.gbSales.Name = "gbSales";
            this.gbSales.Size = new System.Drawing.Size(618, 373);
            this.gbSales.TabIndex = 0;
            this.gbSales.TabStop = false;
            // 
            // tlpSales
            // 
            this.tlpSales.ColumnCount = 1;
            this.tlpSales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSales.Controls.Add(this.gbSalesChkGroup, 0, 0);
            this.tlpSales.Controls.Add(this.lblPrefixDesign, 0, 1);
            this.tlpSales.Controls.Add(this.tcSalesSettings, 0, 2);
            this.tlpSales.Location = new System.Drawing.Point(19, 42);
            this.tlpSales.Name = "tlpSales";
            this.tlpSales.RowCount = 3;
            this.tlpSales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.29167F));
            this.tlpSales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.70833F));
            this.tlpSales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 228F));
            this.tlpSales.Size = new System.Drawing.Size(580, 325);
            this.tlpSales.TabIndex = 1;
            // 
            // gbSalesChkGroup
            // 
            this.gbSalesChkGroup.Controls.Add(this.rbSalesReturn);
            this.gbSalesChkGroup.Controls.Add(this.rbDispatch);
            this.gbSalesChkGroup.Controls.Add(this.rbOrderNo);
            this.gbSalesChkGroup.Controls.Add(this.rbQuoteNo);
            this.gbSalesChkGroup.Controls.Add(this.rbInvoiceNo);
            this.gbSalesChkGroup.Location = new System.Drawing.Point(3, 3);
            this.gbSalesChkGroup.Name = "gbSalesChkGroup";
            this.gbSalesChkGroup.Size = new System.Drawing.Size(574, 46);
            this.gbSalesChkGroup.TabIndex = 0;
            this.gbSalesChkGroup.TabStop = false;
            // 
            // rbSalesReturn
            // 
            this.rbSalesReturn.AutoSize = true;
            this.rbSalesReturn.Location = new System.Drawing.Point(447, 19);
            this.rbSalesReturn.Name = "rbSalesReturn";
            this.rbSalesReturn.Size = new System.Drawing.Size(86, 17);
            this.rbSalesReturn.TabIndex = 1;
            this.rbSalesReturn.TabStop = true;
            this.rbSalesReturn.Text = "Sales Return";
            this.rbSalesReturn.UseVisualStyleBackColor = true;
            // 
            // rbDispatch
            // 
            this.rbDispatch.AutoSize = true;
            this.rbDispatch.Location = new System.Drawing.Point(344, 19);
            this.rbDispatch.Name = "rbDispatch";
            this.rbDispatch.Size = new System.Drawing.Size(67, 17);
            this.rbDispatch.TabIndex = 1;
            this.rbDispatch.TabStop = true;
            this.rbDispatch.Text = "Dispatch";
            this.rbDispatch.UseVisualStyleBackColor = true;
            // 
            // rbOrderNo
            // 
            this.rbOrderNo.AutoSize = true;
            this.rbOrderNo.Location = new System.Drawing.Point(240, 19);
            this.rbOrderNo.Name = "rbOrderNo";
            this.rbOrderNo.Size = new System.Drawing.Size(68, 17);
            this.rbOrderNo.TabIndex = 1;
            this.rbOrderNo.TabStop = true;
            this.rbOrderNo.Text = "Order No";
            this.rbOrderNo.UseVisualStyleBackColor = true;
            // 
            // rbQuoteNo
            // 
            this.rbQuoteNo.AutoSize = true;
            this.rbQuoteNo.Location = new System.Drawing.Point(133, 19);
            this.rbQuoteNo.Name = "rbQuoteNo";
            this.rbQuoteNo.Size = new System.Drawing.Size(71, 17);
            this.rbQuoteNo.TabIndex = 1;
            this.rbQuoteNo.TabStop = true;
            this.rbQuoteNo.Text = "Quote No";
            this.rbQuoteNo.UseVisualStyleBackColor = true;
            // 
            // rbInvoiceNo
            // 
            this.rbInvoiceNo.AutoSize = true;
            this.rbInvoiceNo.Checked = true;
            this.rbInvoiceNo.Location = new System.Drawing.Point(20, 19);
            this.rbInvoiceNo.Name = "rbInvoiceNo";
            this.rbInvoiceNo.Size = new System.Drawing.Size(77, 17);
            this.rbInvoiceNo.TabIndex = 1;
            this.rbInvoiceNo.TabStop = true;
            this.rbInvoiceNo.Text = "Invoice No";
            this.rbInvoiceNo.UseVisualStyleBackColor = true;
            // 
            // lblPrefixDesign
            // 
            this.lblPrefixDesign.BackColor = System.Drawing.Color.Turquoise;
            this.lblPrefixDesign.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPrefixDesign.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrefixDesign.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblPrefixDesign.Location = new System.Drawing.Point(3, 55);
            this.lblPrefixDesign.Name = "lblPrefixDesign";
            this.lblPrefixDesign.Size = new System.Drawing.Size(574, 41);
            this.lblPrefixDesign.TabIndex = 1;
            this.lblPrefixDesign.Text = "PREFIX DESIGN";
            this.lblPrefixDesign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tcSalesSettings
            // 
            this.tcSalesSettings.Controls.Add(this.tpSaleCurrentSettings);
            this.tcSalesSettings.Controls.Add(this.tpNewSettings);
            this.tcSalesSettings.Location = new System.Drawing.Point(3, 99);
            this.tcSalesSettings.Name = "tcSalesSettings";
            this.tcSalesSettings.SelectedIndex = 0;
            this.tcSalesSettings.Size = new System.Drawing.Size(574, 223);
            this.tcSalesSettings.TabIndex = 2;
            // 
            // tpSaleCurrentSettings
            // 
            this.tpSaleCurrentSettings.Controls.Add(this.txtSequenceNo);
            this.tpSaleCurrentSettings.Controls.Add(this.lblSequenceNo);
            this.tpSaleCurrentSettings.Controls.Add(this.txtSalesPrefix);
            this.tpSaleCurrentSettings.Controls.Add(this.lblSalesPrefix);
            this.tpSaleCurrentSettings.Location = new System.Drawing.Point(4, 22);
            this.tpSaleCurrentSettings.Name = "tpSaleCurrentSettings";
            this.tpSaleCurrentSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSaleCurrentSettings.Size = new System.Drawing.Size(566, 197);
            this.tpSaleCurrentSettings.TabIndex = 0;
            this.tpSaleCurrentSettings.Text = "Current Settings";
            this.tpSaleCurrentSettings.UseVisualStyleBackColor = true;
            // 
            // txtSequenceNo
            // 
            this.txtSequenceNo.Location = new System.Drawing.Point(107, 52);
            this.txtSequenceNo.Name = "txtSequenceNo";
            this.txtSequenceNo.Size = new System.Drawing.Size(356, 20);
            this.txtSequenceNo.TabIndex = 1;
            // 
            // lblSequenceNo
            // 
            this.lblSequenceNo.AutoSize = true;
            this.lblSequenceNo.Location = new System.Drawing.Point(13, 55);
            this.lblSequenceNo.Name = "lblSequenceNo";
            this.lblSequenceNo.Size = new System.Drawing.Size(76, 13);
            this.lblSequenceNo.TabIndex = 0;
            this.lblSequenceNo.Text = "Sequence No.";
            // 
            // txtSalesPrefix
            // 
            this.txtSalesPrefix.Location = new System.Drawing.Point(107, 26);
            this.txtSalesPrefix.Name = "txtSalesPrefix";
            this.txtSalesPrefix.Size = new System.Drawing.Size(356, 20);
            this.txtSalesPrefix.TabIndex = 1;
            // 
            // lblSalesPrefix
            // 
            this.lblSalesPrefix.AutoSize = true;
            this.lblSalesPrefix.Location = new System.Drawing.Point(13, 29);
            this.lblSalesPrefix.Name = "lblSalesPrefix";
            this.lblSalesPrefix.Size = new System.Drawing.Size(33, 13);
            this.lblSalesPrefix.TabIndex = 0;
            this.lblSalesPrefix.Text = "Prefix";
            // 
            // tpNewSettings
            // 
            this.tpNewSettings.Location = new System.Drawing.Point(4, 22);
            this.tpNewSettings.Name = "tpNewSettings";
            this.tpNewSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpNewSettings.Size = new System.Drawing.Size(566, 197);
            this.tpNewSettings.TabIndex = 1;
            this.tpNewSettings.Text = "New Settings";
            this.tpNewSettings.UseVisualStyleBackColor = true;
            // 
            // chkAllowMoreThanOrderQty
            // 
            this.chkAllowMoreThanOrderQty.AutoSize = true;
            this.chkAllowMoreThanOrderQty.Location = new System.Drawing.Point(365, 19);
            this.chkAllowMoreThanOrderQty.Name = "chkAllowMoreThanOrderQty";
            this.chkAllowMoreThanOrderQty.Size = new System.Drawing.Size(147, 17);
            this.chkAllowMoreThanOrderQty.TabIndex = 0;
            this.chkAllowMoreThanOrderQty.Text = "Allow more than order Qty";
            this.chkAllowMoreThanOrderQty.UseVisualStyleBackColor = true;
            // 
            // chkAllowOverCreditLimit
            // 
            this.chkAllowOverCreditLimit.AutoSize = true;
            this.chkAllowOverCreditLimit.Location = new System.Drawing.Point(194, 19);
            this.chkAllowOverCreditLimit.Name = "chkAllowOverCreditLimit";
            this.chkAllowOverCreditLimit.Size = new System.Drawing.Size(131, 17);
            this.chkAllowOverCreditLimit.TabIndex = 0;
            this.chkAllowOverCreditLimit.Text = "Allow Over Credit Limit";
            this.chkAllowOverCreditLimit.UseVisualStyleBackColor = true;
            // 
            // chkKeepSellingPriceFixed
            // 
            this.chkKeepSellingPriceFixed.AutoSize = true;
            this.chkKeepSellingPriceFixed.Location = new System.Drawing.Point(19, 19);
            this.chkKeepSellingPriceFixed.Name = "chkKeepSellingPriceFixed";
            this.chkKeepSellingPriceFixed.Size = new System.Drawing.Size(140, 17);
            this.chkKeepSellingPriceFixed.TabIndex = 0;
            this.chkKeepSellingPriceFixed.Text = "Keep Selling Price Fixed";
            this.chkKeepSellingPriceFixed.UseVisualStyleBackColor = true;
            // 
            // tpPurchases
            // 
            this.tpPurchases.Controls.Add(this.gbPurchases);
            this.tpPurchases.Location = new System.Drawing.Point(4, 22);
            this.tpPurchases.Name = "tpPurchases";
            this.tpPurchases.Padding = new System.Windows.Forms.Padding(3);
            this.tpPurchases.Size = new System.Drawing.Size(630, 382);
            this.tpPurchases.TabIndex = 1;
            this.tpPurchases.Text = "Purchases";
            this.tpPurchases.UseVisualStyleBackColor = true;
            // 
            // gbPurchases
            // 
            this.gbPurchases.Controls.Add(this.gbgbPurchases);
            this.gbPurchases.Controls.Add(this.chkAllowMoreThanQty);
            this.gbPurchases.Controls.Add(this.chkShowTheCostInGRN);
            this.gbPurchases.Location = new System.Drawing.Point(6, 6);
            this.gbPurchases.Name = "gbPurchases";
            this.gbPurchases.Size = new System.Drawing.Size(618, 370);
            this.gbPurchases.TabIndex = 0;
            this.gbPurchases.TabStop = false;
            // 
            // gbgbPurchases
            // 
            this.gbgbPurchases.Controls.Add(this.txtSequenceFormat);
            this.gbgbPurchases.Controls.Add(this.cboSequenceNo);
            this.gbgbPurchases.Controls.Add(this.lblSequenceFormat);
            this.gbgbPurchases.Controls.Add(this.lblPurchaseSequenceNo);
            this.gbgbPurchases.Controls.Add(this.txtPurchasePrefix);
            this.gbgbPurchases.Controls.Add(this.lblPurchasePrefix);
            this.gbgbPurchases.Location = new System.Drawing.Point(6, 19);
            this.gbgbPurchases.Name = "gbgbPurchases";
            this.gbgbPurchases.Size = new System.Drawing.Size(431, 148);
            this.gbgbPurchases.TabIndex = 2;
            this.gbgbPurchases.TabStop = false;
            this.gbgbPurchases.Text = "Purchase Number Generator";
            // 
            // chkAllowMoreThanQty
            // 
            this.chkAllowMoreThanQty.AutoSize = true;
            this.chkAllowMoreThanQty.Location = new System.Drawing.Point(457, 56);
            this.chkAllowMoreThanQty.Name = "chkAllowMoreThanQty";
            this.chkAllowMoreThanQty.Size = new System.Drawing.Size(148, 17);
            this.chkAllowMoreThanQty.TabIndex = 1;
            this.chkAllowMoreThanQty.Text = "Allow more than order Qtn";
            this.chkAllowMoreThanQty.UseVisualStyleBackColor = true;
            // 
            // chkShowTheCostInGRN
            // 
            this.chkShowTheCostInGRN.AutoSize = true;
            this.chkShowTheCostInGRN.Location = new System.Drawing.Point(457, 33);
            this.chkShowTheCostInGRN.Name = "chkShowTheCostInGRN";
            this.chkShowTheCostInGRN.Size = new System.Drawing.Size(132, 17);
            this.chkShowTheCostInGRN.TabIndex = 0;
            this.chkShowTheCostInGRN.Text = "Show the cost in GRN";
            this.chkShowTheCostInGRN.UseVisualStyleBackColor = true;
            // 
            // tpSecurity
            // 
            this.tpSecurity.Controls.Add(this.gbSecurity);
            this.tpSecurity.Controls.Add(this.tcSecurity);
            this.tpSecurity.Location = new System.Drawing.Point(4, 22);
            this.tpSecurity.Name = "tpSecurity";
            this.tpSecurity.Size = new System.Drawing.Size(630, 382);
            this.tpSecurity.TabIndex = 2;
            this.tpSecurity.Text = "Security";
            this.tpSecurity.UseVisualStyleBackColor = true;
            // 
            // gbSecurity
            // 
            this.gbSecurity.Controls.Add(this.btnDelSecurity);
            this.gbSecurity.Controls.Add(this.btnEditSecurity);
            this.gbSecurity.Controls.Add(this.btnNewSecurity);
            this.gbSecurity.Location = new System.Drawing.Point(476, 31);
            this.gbSecurity.Name = "gbSecurity";
            this.gbSecurity.Size = new System.Drawing.Size(140, 112);
            this.gbSecurity.TabIndex = 1;
            this.gbSecurity.TabStop = false;
            // 
            // btnDelSecurity
            // 
            this.btnDelSecurity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelSecurity.Location = new System.Drawing.Point(6, 77);
            this.btnDelSecurity.Name = "btnDelSecurity";
            this.btnDelSecurity.Size = new System.Drawing.Size(128, 23);
            this.btnDelSecurity.TabIndex = 0;
            this.btnDelSecurity.Text = "Delete";
            this.btnDelSecurity.UseVisualStyleBackColor = true;
            // 
            // btnEditSecurity
            // 
            this.btnEditSecurity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditSecurity.Location = new System.Drawing.Point(6, 48);
            this.btnEditSecurity.Name = "btnEditSecurity";
            this.btnEditSecurity.Size = new System.Drawing.Size(128, 23);
            this.btnEditSecurity.TabIndex = 0;
            this.btnEditSecurity.Text = "Edit";
            this.btnEditSecurity.UseVisualStyleBackColor = true;
            // 
            // btnNewSecurity
            // 
            this.btnNewSecurity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewSecurity.Location = new System.Drawing.Point(6, 19);
            this.btnNewSecurity.Name = "btnNewSecurity";
            this.btnNewSecurity.Size = new System.Drawing.Size(128, 23);
            this.btnNewSecurity.TabIndex = 0;
            this.btnNewSecurity.Text = "New";
            this.btnNewSecurity.UseVisualStyleBackColor = true;
            // 
            // tcSecurity
            // 
            this.tcSecurity.Controls.Add(this.tpSecurityList);
            this.tcSecurity.Controls.Add(this.tpSecurityDetail);
            this.tcSecurity.Location = new System.Drawing.Point(12, 18);
            this.tcSecurity.Name = "tcSecurity";
            this.tcSecurity.SelectedIndex = 0;
            this.tcSecurity.Size = new System.Drawing.Size(458, 262);
            this.tcSecurity.TabIndex = 0;
            // 
            // tpSecurityList
            // 
            this.tpSecurityList.Controls.Add(this.label1);
            this.tpSecurityList.Controls.Add(this.dgvSecurityList);
            this.tpSecurityList.Location = new System.Drawing.Point(4, 22);
            this.tpSecurityList.Name = "tpSecurityList";
            this.tpSecurityList.Padding = new System.Windows.Forms.Padding(3);
            this.tpSecurityList.Size = new System.Drawing.Size(450, 236);
            this.tpSecurityList.TabIndex = 0;
            this.tpSecurityList.Text = "List";
            this.tpSecurityList.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "[User Name] passowrd: \'[password]\'";
            // 
            // dgvSecurityList
            // 
            this.dgvSecurityList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSecurityList.Location = new System.Drawing.Point(6, 10);
            this.dgvSecurityList.Name = "dgvSecurityList";
            this.dgvSecurityList.Size = new System.Drawing.Size(438, 199);
            this.dgvSecurityList.TabIndex = 0;
            // 
            // tpSecurityDetail
            // 
            this.tpSecurityDetail.Location = new System.Drawing.Point(4, 22);
            this.tpSecurityDetail.Name = "tpSecurityDetail";
            this.tpSecurityDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tpSecurityDetail.Size = new System.Drawing.Size(450, 236);
            this.tpSecurityDetail.TabIndex = 1;
            this.tpSecurityDetail.Text = "Detail";
            this.tpSecurityDetail.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(77, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Invoice No";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // lblPurchaseSequenceNo
            // 
            this.lblPurchaseSequenceNo.AutoSize = true;
            this.lblPurchaseSequenceNo.Location = new System.Drawing.Point(18, 67);
            this.lblPurchaseSequenceNo.Name = "lblPurchaseSequenceNo";
            this.lblPurchaseSequenceNo.Size = new System.Drawing.Size(76, 13);
            this.lblPurchaseSequenceNo.TabIndex = 4;
            this.lblPurchaseSequenceNo.Text = "Sequence No.";
            // 
            // txtPurchasePrefix
            // 
            this.txtPurchasePrefix.Location = new System.Drawing.Point(151, 35);
            this.txtPurchasePrefix.Name = "txtPurchasePrefix";
            this.txtPurchasePrefix.Size = new System.Drawing.Size(254, 20);
            this.txtPurchasePrefix.TabIndex = 5;
            this.txtPurchasePrefix.Text = "P";
            // 
            // lblPurchasePrefix
            // 
            this.lblPurchasePrefix.AutoSize = true;
            this.lblPurchasePrefix.Location = new System.Drawing.Point(18, 38);
            this.lblPurchasePrefix.Name = "lblPurchasePrefix";
            this.lblPurchasePrefix.Size = new System.Drawing.Size(33, 13);
            this.lblPurchasePrefix.TabIndex = 3;
            this.lblPurchasePrefix.Text = "Prefix";
            // 
            // cboSequenceNo
            // 
            this.cboSequenceNo.FormattingEnabled = true;
            this.cboSequenceNo.Location = new System.Drawing.Point(151, 64);
            this.cboSequenceNo.Name = "cboSequenceNo";
            this.cboSequenceNo.Size = new System.Drawing.Size(254, 21);
            this.cboSequenceNo.TabIndex = 7;
            // 
            // txtSequenceFormat
            // 
            this.txtSequenceFormat.Location = new System.Drawing.Point(151, 91);
            this.txtSequenceFormat.Name = "txtSequenceFormat";
            this.txtSequenceFormat.Size = new System.Drawing.Size(254, 20);
            this.txtSequenceFormat.TabIndex = 8;
            // 
            // lblSequenceFormat
            // 
            this.lblSequenceFormat.AutoSize = true;
            this.lblSequenceFormat.Location = new System.Drawing.Point(18, 94);
            this.lblSequenceFormat.Name = "lblSequenceFormat";
            this.lblSequenceFormat.Size = new System.Drawing.Size(91, 13);
            this.lblSequenceFormat.TabIndex = 4;
            this.lblSequenceFormat.Text = "Sequence Format";
            // 
            // frmPreference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 432);
            this.Controls.Add(this.tcPreference);
            this.Name = "frmPreference";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preference";
            this.tcPreference.ResumeLayout(false);
            this.tpSales.ResumeLayout(false);
            this.gbSales.ResumeLayout(false);
            this.gbSales.PerformLayout();
            this.tlpSales.ResumeLayout(false);
            this.gbSalesChkGroup.ResumeLayout(false);
            this.gbSalesChkGroup.PerformLayout();
            this.tcSalesSettings.ResumeLayout(false);
            this.tpSaleCurrentSettings.ResumeLayout(false);
            this.tpSaleCurrentSettings.PerformLayout();
            this.tpPurchases.ResumeLayout(false);
            this.gbPurchases.ResumeLayout(false);
            this.gbPurchases.PerformLayout();
            this.gbgbPurchases.ResumeLayout(false);
            this.gbgbPurchases.PerformLayout();
            this.tpSecurity.ResumeLayout(false);
            this.gbSecurity.ResumeLayout(false);
            this.tcSecurity.ResumeLayout(false);
            this.tpSecurityList.ResumeLayout(false);
            this.tpSecurityList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSecurityList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcPreference;
        private System.Windows.Forms.TabPage tpSales;
        private System.Windows.Forms.TabPage tpPurchases;
        private System.Windows.Forms.TabPage tpSecurity;
        private System.Windows.Forms.CZRoundedGroupBox gbSales;
        private System.Windows.Forms.CheckBox chkKeepSellingPriceFixed;
        private System.Windows.Forms.CheckBox chkAllowMoreThanOrderQty;
        private System.Windows.Forms.CheckBox chkAllowOverCreditLimit;
        private System.Windows.Forms.TableLayoutPanel tlpSales;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CZRoundedGroupBox gbSalesChkGroup;
        private System.Windows.Forms.RadioButton rbSalesReturn;
        private System.Windows.Forms.RadioButton rbDispatch;
        private System.Windows.Forms.RadioButton rbOrderNo;
        private System.Windows.Forms.RadioButton rbQuoteNo;
        private System.Windows.Forms.RadioButton rbInvoiceNo;
        private System.Windows.Forms.Label lblPrefixDesign;
        private System.Windows.Forms.TabControl tcSalesSettings;
        private System.Windows.Forms.TabPage tpSaleCurrentSettings;
        private System.Windows.Forms.TabPage tpNewSettings;
        private System.Windows.Forms.TextBox txtSequenceNo;
        private System.Windows.Forms.Label lblSequenceNo;
        private System.Windows.Forms.TextBox txtSalesPrefix;
        private System.Windows.Forms.Label lblSalesPrefix;
        private System.Windows.Forms.CZRoundedGroupBox gbPurchases;
        private System.Windows.Forms.CZRoundedGroupBox gbgbPurchases;
        private System.Windows.Forms.CheckBox chkAllowMoreThanQty;
        private System.Windows.Forms.CheckBox chkShowTheCostInGRN;
        private System.Windows.Forms.CZRoundedGroupBox gbSecurity;
        private System.Windows.Forms.Button btnNewSecurity;
        private System.Windows.Forms.TabControl tcSecurity;
        private System.Windows.Forms.TabPage tpSecurityList;
        private System.Windows.Forms.TabPage tpSecurityDetail;
        private System.Windows.Forms.Button btnDelSecurity;
        private System.Windows.Forms.Button btnEditSecurity;
        private System.Windows.Forms.DataGridView dgvSecurityList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPurchaseSequenceNo;
        private System.Windows.Forms.TextBox txtPurchasePrefix;
        private System.Windows.Forms.Label lblPurchasePrefix;
        private System.Windows.Forms.ComboBox cboSequenceNo;
        private System.Windows.Forms.TextBox txtSequenceFormat;
        private System.Windows.Forms.Label lblSequenceFormat;
    }
}