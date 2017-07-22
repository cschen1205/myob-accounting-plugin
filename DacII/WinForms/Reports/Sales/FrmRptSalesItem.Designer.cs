namespace DacII.WinForms.Reports.Sales
{
    partial class FrmRptSalesItem
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
            this.btnGenerate = new System.Windows.Forms.VistaButton();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.cboItemNumber = new System.Windows.Forms.ComboBox();
            this.cboUnitsSold = new System.Windows.Forms.ComboBox();
            this.cboGrossProfit = new System.Windows.Forms.ComboBox();
            this.cboCostOfSales = new System.Windows.Forms.ComboBox();
            this.cboAverageCost = new System.Windows.Forms.ComboBox();
            this.cboItemName = new System.Windows.Forms.ComboBox();
            this.cboProfitMargin = new System.Windows.Forms.ComboBox();
            this.cboSize = new System.Windows.Forms.ComboBox();
            this.cboSaleAmount = new System.Windows.Forms.ComboBox();
            this.cboColor = new System.Windows.Forms.ComboBox();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.cboExpiryDate = new System.Windows.Forms.ComboBox();
            this.cboBrand = new System.Windows.Forms.ComboBox();
            this.cboSerialNumber = new System.Windows.Forms.ComboBox();
            this.cboBatchNumber = new System.Windows.Forms.ComboBox();
            this.chkGender = new System.Windows.Forms.CheckBox();
            this.chkSize = new System.Windows.Forms.CheckBox();
            this.chkColor = new System.Windows.Forms.CheckBox();
            this.chkBrand = new System.Windows.Forms.CheckBox();
            this.chkExpiryDate = new System.Windows.Forms.CheckBox();
            this.chkSerialNumber = new System.Windows.Forms.CheckBox();
            this.chkItemNumber = new System.Windows.Forms.CheckBox();
            this.chkItemName = new System.Windows.Forms.CheckBox();
            this.chkUnitsSold = new System.Windows.Forms.CheckBox();
            this.chkProfitMargin = new System.Windows.Forms.CheckBox();
            this.chkGrossProfit = new System.Windows.Forms.CheckBox();
            this.chkCostOfSales = new System.Windows.Forms.CheckBox();
            this.chkSaleAmount = new System.Windows.Forms.CheckBox();
            this.chkAverageCost = new System.Windows.Forms.CheckBox();
            this.chkBatchNumber = new System.Windows.Forms.CheckBox();
            this.txtToYear = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFromYear = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.btnGenerateAndEmail = new System.Windows.Forms.VistaButton();
            this.RptViewer = new System.Windows.Forms.WebBrowser();
            this.BtnSave = new System.Windows.Forms.VistaButton();
            this.btnClose = new System.Windows.Forms.VistaButton();
            this.panelMenu = new BSE.Windows.Forms.Panel();
            this.xPanderPanelList1 = new BSE.Windows.Forms.XPanderPanelList();
            this.xPanderPanelMain = new BSE.Windows.Forms.XPanderPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.xPanderPanelCache = new BSE.Windows.Forms.XPanderPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.xPanderPanelLive = new BSE.Windows.Forms.XPanderPanel();
            this.chkIncludeReportDateAndTime = new System.Windows.Forms.CheckBox();
            this.chkIncludeCompanyAddress = new System.Windows.Forms.CheckBox();
            this.chkIncludeCompanyName = new System.Windows.Forms.CheckBox();
            this.panelMenu.SuspendLayout();
            this.xPanderPanelList1.SuspendLayout();
            this.xPanderPanelMain.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.xPanderPanelCache.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.xPanderPanelLive.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerate.BaseColor = System.Drawing.Color.Transparent;
            this.btnGenerate.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnGenerate.ButtonText = "Generate";
            this.btnGenerate.Location = new System.Drawing.Point(22, 220);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(194, 30);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // cboItemNumber
            // 
            this.cboItemNumber.FormattingEnabled = true;
            this.cboItemNumber.Location = new System.Drawing.Point(103, 339);
            this.cboItemNumber.Name = "cboItemNumber";
            this.cboItemNumber.Size = new System.Drawing.Size(35, 21);
            this.cboItemNumber.TabIndex = 9;
            // 
            // cboUnitsSold
            // 
            this.cboUnitsSold.FormattingEnabled = true;
            this.cboUnitsSold.Location = new System.Drawing.Point(103, 315);
            this.cboUnitsSold.Name = "cboUnitsSold";
            this.cboUnitsSold.Size = new System.Drawing.Size(35, 21);
            this.cboUnitsSold.TabIndex = 9;
            // 
            // cboGrossProfit
            // 
            this.cboGrossProfit.FormattingEnabled = true;
            this.cboGrossProfit.Location = new System.Drawing.Point(103, 267);
            this.cboGrossProfit.Name = "cboGrossProfit";
            this.cboGrossProfit.Size = new System.Drawing.Size(35, 21);
            this.cboGrossProfit.TabIndex = 9;
            // 
            // cboCostOfSales
            // 
            this.cboCostOfSales.FormattingEnabled = true;
            this.cboCostOfSales.Location = new System.Drawing.Point(103, 243);
            this.cboCostOfSales.Name = "cboCostOfSales";
            this.cboCostOfSales.Size = new System.Drawing.Size(35, 21);
            this.cboCostOfSales.TabIndex = 9;
            // 
            // cboAverageCost
            // 
            this.cboAverageCost.FormattingEnabled = true;
            this.cboAverageCost.Location = new System.Drawing.Point(103, 195);
            this.cboAverageCost.Name = "cboAverageCost";
            this.cboAverageCost.Size = new System.Drawing.Size(35, 21);
            this.cboAverageCost.TabIndex = 9;
            // 
            // cboItemName
            // 
            this.cboItemName.FormattingEnabled = true;
            this.cboItemName.Location = new System.Drawing.Point(103, 171);
            this.cboItemName.Name = "cboItemName";
            this.cboItemName.Size = new System.Drawing.Size(35, 21);
            this.cboItemName.TabIndex = 9;
            // 
            // cboProfitMargin
            // 
            this.cboProfitMargin.FormattingEnabled = true;
            this.cboProfitMargin.Location = new System.Drawing.Point(103, 291);
            this.cboProfitMargin.Name = "cboProfitMargin";
            this.cboProfitMargin.Size = new System.Drawing.Size(35, 21);
            this.cboProfitMargin.TabIndex = 9;
            // 
            // cboSize
            // 
            this.cboSize.FormattingEnabled = true;
            this.cboSize.Location = new System.Drawing.Point(103, 123);
            this.cboSize.Name = "cboSize";
            this.cboSize.Size = new System.Drawing.Size(35, 21);
            this.cboSize.TabIndex = 9;
            // 
            // cboSaleAmount
            // 
            this.cboSaleAmount.FormattingEnabled = true;
            this.cboSaleAmount.Location = new System.Drawing.Point(103, 219);
            this.cboSaleAmount.Name = "cboSaleAmount";
            this.cboSaleAmount.Size = new System.Drawing.Size(35, 21);
            this.cboSaleAmount.TabIndex = 9;
            // 
            // cboColor
            // 
            this.cboColor.FormattingEnabled = true;
            this.cboColor.Location = new System.Drawing.Point(103, 99);
            this.cboColor.Name = "cboColor";
            this.cboColor.Size = new System.Drawing.Size(35, 21);
            this.cboColor.TabIndex = 9;
            // 
            // cboGender
            // 
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Location = new System.Drawing.Point(103, 147);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(35, 21);
            this.cboGender.TabIndex = 9;
            // 
            // cboExpiryDate
            // 
            this.cboExpiryDate.FormattingEnabled = true;
            this.cboExpiryDate.Location = new System.Drawing.Point(103, 51);
            this.cboExpiryDate.Name = "cboExpiryDate";
            this.cboExpiryDate.Size = new System.Drawing.Size(35, 21);
            this.cboExpiryDate.TabIndex = 9;
            // 
            // cboBrand
            // 
            this.cboBrand.FormattingEnabled = true;
            this.cboBrand.Location = new System.Drawing.Point(103, 75);
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(35, 21);
            this.cboBrand.TabIndex = 9;
            // 
            // cboSerialNumber
            // 
            this.cboSerialNumber.FormattingEnabled = true;
            this.cboSerialNumber.Location = new System.Drawing.Point(103, 27);
            this.cboSerialNumber.Name = "cboSerialNumber";
            this.cboSerialNumber.Size = new System.Drawing.Size(35, 21);
            this.cboSerialNumber.TabIndex = 9;
            // 
            // cboBatchNumber
            // 
            this.cboBatchNumber.FormattingEnabled = true;
            this.cboBatchNumber.Location = new System.Drawing.Point(103, 3);
            this.cboBatchNumber.Name = "cboBatchNumber";
            this.cboBatchNumber.Size = new System.Drawing.Size(35, 21);
            this.cboBatchNumber.TabIndex = 9;
            // 
            // chkGender
            // 
            this.chkGender.AutoSize = true;
            this.chkGender.Checked = true;
            this.chkGender.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGender.Location = new System.Drawing.Point(3, 147);
            this.chkGender.Name = "chkGender";
            this.chkGender.Size = new System.Drawing.Size(61, 17);
            this.chkGender.TabIndex = 6;
            this.chkGender.Text = "Gender";
            this.chkGender.UseVisualStyleBackColor = true;
            // 
            // chkSize
            // 
            this.chkSize.AutoSize = true;
            this.chkSize.Checked = true;
            this.chkSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSize.Location = new System.Drawing.Point(3, 123);
            this.chkSize.Name = "chkSize";
            this.chkSize.Size = new System.Drawing.Size(46, 17);
            this.chkSize.TabIndex = 5;
            this.chkSize.Text = "Size";
            this.chkSize.UseVisualStyleBackColor = true;
            // 
            // chkColor
            // 
            this.chkColor.AutoSize = true;
            this.chkColor.Checked = true;
            this.chkColor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkColor.Location = new System.Drawing.Point(3, 99);
            this.chkColor.Name = "chkColor";
            this.chkColor.Size = new System.Drawing.Size(50, 17);
            this.chkColor.TabIndex = 8;
            this.chkColor.Text = "Color";
            this.chkColor.UseVisualStyleBackColor = true;
            // 
            // chkBrand
            // 
            this.chkBrand.AutoSize = true;
            this.chkBrand.Checked = true;
            this.chkBrand.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBrand.Location = new System.Drawing.Point(3, 75);
            this.chkBrand.Name = "chkBrand";
            this.chkBrand.Size = new System.Drawing.Size(54, 17);
            this.chkBrand.TabIndex = 7;
            this.chkBrand.Text = "Brand";
            this.chkBrand.UseVisualStyleBackColor = true;
            // 
            // chkExpiryDate
            // 
            this.chkExpiryDate.AutoSize = true;
            this.chkExpiryDate.Checked = true;
            this.chkExpiryDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExpiryDate.Location = new System.Drawing.Point(3, 51);
            this.chkExpiryDate.Name = "chkExpiryDate";
            this.chkExpiryDate.Size = new System.Drawing.Size(80, 17);
            this.chkExpiryDate.TabIndex = 2;
            this.chkExpiryDate.Text = "Expiry Date";
            this.chkExpiryDate.UseVisualStyleBackColor = true;
            // 
            // chkSerialNumber
            // 
            this.chkSerialNumber.AutoSize = true;
            this.chkSerialNumber.Checked = true;
            this.chkSerialNumber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSerialNumber.Location = new System.Drawing.Point(3, 27);
            this.chkSerialNumber.Name = "chkSerialNumber";
            this.chkSerialNumber.Size = new System.Drawing.Size(62, 17);
            this.chkSerialNumber.TabIndex = 1;
            this.chkSerialNumber.Text = "Serial #";
            this.chkSerialNumber.UseVisualStyleBackColor = true;
            // 
            // chkItemNumber
            // 
            this.chkItemNumber.AutoSize = true;
            this.chkItemNumber.Checked = true;
            this.chkItemNumber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkItemNumber.Location = new System.Drawing.Point(3, 339);
            this.chkItemNumber.Name = "chkItemNumber";
            this.chkItemNumber.Size = new System.Drawing.Size(56, 17);
            this.chkItemNumber.TabIndex = 4;
            this.chkItemNumber.Text = "Item #";
            this.chkItemNumber.UseVisualStyleBackColor = true;
            // 
            // chkItemName
            // 
            this.chkItemName.AutoSize = true;
            this.chkItemName.Checked = true;
            this.chkItemName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkItemName.Location = new System.Drawing.Point(3, 171);
            this.chkItemName.Name = "chkItemName";
            this.chkItemName.Size = new System.Drawing.Size(77, 17);
            this.chkItemName.TabIndex = 4;
            this.chkItemName.Text = "Item Name";
            this.chkItemName.UseVisualStyleBackColor = true;
            // 
            // chkUnitsSold
            // 
            this.chkUnitsSold.AutoSize = true;
            this.chkUnitsSold.Checked = true;
            this.chkUnitsSold.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUnitsSold.Location = new System.Drawing.Point(3, 315);
            this.chkUnitsSold.Name = "chkUnitsSold";
            this.chkUnitsSold.Size = new System.Drawing.Size(74, 17);
            this.chkUnitsSold.TabIndex = 4;
            this.chkUnitsSold.Text = "Units Sold";
            this.chkUnitsSold.UseVisualStyleBackColor = true;
            // 
            // chkProfitMargin
            // 
            this.chkProfitMargin.AutoSize = true;
            this.chkProfitMargin.Checked = true;
            this.chkProfitMargin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProfitMargin.Location = new System.Drawing.Point(3, 291);
            this.chkProfitMargin.Name = "chkProfitMargin";
            this.chkProfitMargin.Size = new System.Drawing.Size(85, 17);
            this.chkProfitMargin.TabIndex = 4;
            this.chkProfitMargin.Text = "Profit Margin";
            this.chkProfitMargin.UseVisualStyleBackColor = true;
            // 
            // chkGrossProfit
            // 
            this.chkGrossProfit.AutoSize = true;
            this.chkGrossProfit.Checked = true;
            this.chkGrossProfit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGrossProfit.Location = new System.Drawing.Point(3, 267);
            this.chkGrossProfit.Name = "chkGrossProfit";
            this.chkGrossProfit.Size = new System.Drawing.Size(80, 17);
            this.chkGrossProfit.TabIndex = 4;
            this.chkGrossProfit.Text = "Gross Profit";
            this.chkGrossProfit.UseVisualStyleBackColor = true;
            // 
            // chkCostOfSales
            // 
            this.chkCostOfSales.AutoSize = true;
            this.chkCostOfSales.Checked = true;
            this.chkCostOfSales.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCostOfSales.Location = new System.Drawing.Point(3, 243);
            this.chkCostOfSales.Name = "chkCostOfSales";
            this.chkCostOfSales.Size = new System.Drawing.Size(88, 17);
            this.chkCostOfSales.TabIndex = 4;
            this.chkCostOfSales.Text = "Cost of Sales";
            this.chkCostOfSales.UseVisualStyleBackColor = true;
            // 
            // chkSaleAmount
            // 
            this.chkSaleAmount.AutoSize = true;
            this.chkSaleAmount.Checked = true;
            this.chkSaleAmount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaleAmount.Location = new System.Drawing.Point(3, 219);
            this.chkSaleAmount.Name = "chkSaleAmount";
            this.chkSaleAmount.Size = new System.Drawing.Size(86, 17);
            this.chkSaleAmount.TabIndex = 4;
            this.chkSaleAmount.Text = "Sale Amount";
            this.chkSaleAmount.UseVisualStyleBackColor = true;
            // 
            // chkAverageCost
            // 
            this.chkAverageCost.AutoSize = true;
            this.chkAverageCost.Checked = true;
            this.chkAverageCost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAverageCost.Location = new System.Drawing.Point(3, 195);
            this.chkAverageCost.Name = "chkAverageCost";
            this.chkAverageCost.Size = new System.Drawing.Size(90, 17);
            this.chkAverageCost.TabIndex = 4;
            this.chkAverageCost.Text = "Average Cost";
            this.chkAverageCost.UseVisualStyleBackColor = true;
            // 
            // chkBatchNumber
            // 
            this.chkBatchNumber.AutoSize = true;
            this.chkBatchNumber.Checked = true;
            this.chkBatchNumber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBatchNumber.Location = new System.Drawing.Point(3, 3);
            this.chkBatchNumber.Name = "chkBatchNumber";
            this.chkBatchNumber.Size = new System.Drawing.Size(64, 17);
            this.chkBatchNumber.TabIndex = 3;
            this.chkBatchNumber.Text = "Batch #";
            this.chkBatchNumber.UseVisualStyleBackColor = true;
            // 
            // txtToYear
            // 
            this.txtToYear.Location = new System.Drawing.Point(103, 27);
            this.txtToYear.Name = "txtToYear";
            this.txtToYear.Size = new System.Drawing.Size(47, 20);
            this.txtToYear.TabIndex = 1;
            this.txtToYear.Text = "2010";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "To Year:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFromYear
            // 
            this.txtFromYear.Location = new System.Drawing.Point(103, 3);
            this.txtFromYear.Name = "txtFromYear";
            this.txtFromYear.Size = new System.Drawing.Size(47, 20);
            this.txtFromYear.TabIndex = 1;
            this.txtFromYear.Text = "2010";
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(3, 0);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(58, 20);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From Year:";
            this.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGenerateAndEmail
            // 
            this.btnGenerateAndEmail.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerateAndEmail.BaseColor = System.Drawing.Color.Transparent;
            this.btnGenerateAndEmail.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnGenerateAndEmail.ButtonText = "Email";
            this.btnGenerateAndEmail.Location = new System.Drawing.Point(22, 295);
            this.btnGenerateAndEmail.Name = "btnGenerateAndEmail";
            this.btnGenerateAndEmail.Size = new System.Drawing.Size(194, 30);
            this.btnGenerateAndEmail.TabIndex = 1;
            this.btnGenerateAndEmail.Click += new System.EventHandler(this.btnGenerateAndEmail_Click);
            // 
            // RptViewer
            // 
            this.RptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RptViewer.Location = new System.Drawing.Point(0, 0);
            this.RptViewer.MinimumSize = new System.Drawing.Size(20, 20);
            this.RptViewer.Name = "RptViewer";
            this.RptViewer.Size = new System.Drawing.Size(562, 490);
            this.RptViewer.TabIndex = 3;
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.Transparent;
            this.BtnSave.BaseColor = System.Drawing.Color.Transparent;
            this.BtnSave.ButtonColor = System.Drawing.Color.SteelBlue;
            this.BtnSave.ButtonText = "Save";
            this.BtnSave.Location = new System.Drawing.Point(22, 256);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(194, 30);
            this.BtnSave.TabIndex = 1;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BaseColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnClose.ButtonText = "Close";
            this.btnClose.Location = new System.Drawing.Point(22, 331);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(194, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.AssociatedSplitter = null;
            this.panelMenu.BackColor = System.Drawing.Color.Transparent;
            this.panelMenu.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelMenu.CaptionHeight = 27;
            this.panelMenu.Controls.Add(this.xPanderPanelList1);
            this.panelMenu.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.panelMenu.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.panelMenu.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.panelMenu.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panelMenu.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.panelMenu.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.panelMenu.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelMenu.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelMenu.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.panelMenu.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.panelMenu.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.panelMenu.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panelMenu.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelMenu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelMenu.Image = null;
            this.panelMenu.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panelMenu.Location = new System.Drawing.Point(562, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(2);
            this.panelMenu.MinimumSize = new System.Drawing.Size(27, 27);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.panelMenu.ShowExpandIcon = true;
            this.panelMenu.Size = new System.Drawing.Size(228, 490);
            this.panelMenu.TabIndex = 41;
            this.panelMenu.Text = "Menu";
            this.panelMenu.ToolTipTextCloseIcon = null;
            this.panelMenu.ToolTipTextExpandIconPanelCollapsed = "maximize";
            this.panelMenu.ToolTipTextExpandIconPanelExpanded = "minimize";
            // 
            // xPanderPanelList1
            // 
            this.xPanderPanelList1.CaptionStyle = BSE.Windows.Forms.CaptionStyle.Flat;
            this.xPanderPanelList1.Controls.Add(this.xPanderPanelMain);
            this.xPanderPanelList1.Controls.Add(this.xPanderPanelCache);
            this.xPanderPanelList1.Controls.Add(this.xPanderPanelLive);
            this.xPanderPanelList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanderPanelList1.GradientBackground = System.Drawing.Color.Empty;
            this.xPanderPanelList1.Location = new System.Drawing.Point(0, 28);
            this.xPanderPanelList1.Margin = new System.Windows.Forms.Padding(2);
            this.xPanderPanelList1.Name = "xPanderPanelList1";
            this.xPanderPanelList1.PanelColors = null;
            this.xPanderPanelList1.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanelList1.ShowExpandIcon = true;
            this.xPanderPanelList1.Size = new System.Drawing.Size(228, 461);
            this.xPanderPanelList1.TabIndex = 0;
            this.xPanderPanelList1.Text = "xPanderPanelList1";
            // 
            // xPanderPanelMain
            // 
            this.xPanderPanelMain.CaptionFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xPanderPanelMain.Controls.Add(this.tableLayoutPanel4);
            this.xPanderPanelMain.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanelMain.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.xPanderPanelMain.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty;
            this.xPanderPanelMain.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty;
            this.xPanderPanelMain.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty;
            this.xPanderPanelMain.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelMain.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelMain.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanelMain.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.xPanderPanelMain.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanelMain.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanderPanelMain.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanderPanelMain.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanderPanelMain.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanderPanelMain.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanderPanelMain.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanderPanelMain.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelMain.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelMain.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanelMain.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanelMain.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.xPanderPanelMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelMain.Image = null;
            this.xPanderPanelMain.IsClosable = false;
            this.xPanderPanelMain.Margin = new System.Windows.Forms.Padding(2);
            this.xPanderPanelMain.Name = "xPanderPanelMain";
            this.xPanderPanelMain.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanelMain.Size = new System.Drawing.Size(228, 25);
            this.xPanderPanelMain.TabIndex = 0;
            this.xPanderPanelMain.Text = "Report Fields";
            this.xPanderPanelMain.ToolTipTextCloseIcon = null;
            this.xPanderPanelMain.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanelMain.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.27536F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(1, 25);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(226, 0);
            this.tableLayoutPanel4.TabIndex = 38;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoScroll = true;
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel5.Controls.Add(this.cboItemNumber, 1, 14);
            this.tableLayoutPanel5.Controls.Add(this.chkBatchNumber, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.chkItemNumber, 0, 14);
            this.tableLayoutPanel5.Controls.Add(this.cboUnitsSold, 1, 13);
            this.tableLayoutPanel5.Controls.Add(this.cboBatchNumber, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.cboProfitMargin, 1, 12);
            this.tableLayoutPanel5.Controls.Add(this.chkUnitsSold, 0, 13);
            this.tableLayoutPanel5.Controls.Add(this.cboGrossProfit, 1, 11);
            this.tableLayoutPanel5.Controls.Add(this.chkSerialNumber, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.cboCostOfSales, 1, 10);
            this.tableLayoutPanel5.Controls.Add(this.chkProfitMargin, 0, 12);
            this.tableLayoutPanel5.Controls.Add(this.cboSerialNumber, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.cboAverageCost, 1, 8);
            this.tableLayoutPanel5.Controls.Add(this.cboSaleAmount, 1, 9);
            this.tableLayoutPanel5.Controls.Add(this.chkGrossProfit, 0, 11);
            this.tableLayoutPanel5.Controls.Add(this.chkExpiryDate, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.cboItemName, 1, 7);
            this.tableLayoutPanel5.Controls.Add(this.cboExpiryDate, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.chkCostOfSales, 0, 10);
            this.tableLayoutPanel5.Controls.Add(this.chkBrand, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.cboSize, 1, 5);
            this.tableLayoutPanel5.Controls.Add(this.cboGender, 1, 6);
            this.tableLayoutPanel5.Controls.Add(this.chkSaleAmount, 0, 9);
            this.tableLayoutPanel5.Controls.Add(this.chkItemName, 0, 7);
            this.tableLayoutPanel5.Controls.Add(this.cboBrand, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.chkGender, 0, 6);
            this.tableLayoutPanel5.Controls.Add(this.chkAverageCost, 0, 8);
            this.tableLayoutPanel5.Controls.Add(this.chkColor, 0, 4);
            this.tableLayoutPanel5.Controls.Add(this.cboColor, 1, 4);
            this.tableLayoutPanel5.Controls.Add(this.chkSize, 0, 5);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 15;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(222, 1);
            this.tableLayoutPanel5.TabIndex = 30;
            // 
            // xPanderPanelCache
            // 
            this.xPanderPanelCache.CaptionFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xPanderPanelCache.Controls.Add(this.tableLayoutPanel1);
            this.xPanderPanelCache.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanelCache.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.xPanderPanelCache.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty;
            this.xPanderPanelCache.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty;
            this.xPanderPanelCache.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty;
            this.xPanderPanelCache.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelCache.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelCache.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanelCache.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.xPanderPanelCache.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanelCache.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanderPanelCache.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanderPanelCache.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanderPanelCache.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanderPanelCache.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanderPanelCache.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanderPanelCache.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelCache.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelCache.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanelCache.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanelCache.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.xPanderPanelCache.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelCache.Image = null;
            this.xPanderPanelCache.IsClosable = false;
            this.xPanderPanelCache.Margin = new System.Windows.Forms.Padding(2);
            this.xPanderPanelCache.Name = "xPanderPanelCache";
            this.xPanderPanelCache.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanelCache.Size = new System.Drawing.Size(228, 25);
            this.xPanderPanelCache.TabIndex = 1;
            this.xPanderPanelCache.Text = "Advanced Filters";
            this.xPanderPanelCache.ToolTipTextCloseIcon = null;
            this.xPanderPanelCache.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanelCache.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtToYear, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFrom, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtFromYear, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 25);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(226, 0);
            this.tableLayoutPanel1.TabIndex = 41;
            // 
            // xPanderPanelLive
            // 
            this.xPanderPanelLive.CaptionFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xPanderPanelLive.Controls.Add(this.chkIncludeReportDateAndTime);
            this.xPanderPanelLive.Controls.Add(this.chkIncludeCompanyAddress);
            this.xPanderPanelLive.Controls.Add(this.chkIncludeCompanyName);
            this.xPanderPanelLive.Controls.Add(this.btnClose);
            this.xPanderPanelLive.Controls.Add(this.btnGenerate);
            this.xPanderPanelLive.Controls.Add(this.btnGenerateAndEmail);
            this.xPanderPanelLive.Controls.Add(this.BtnSave);
            this.xPanderPanelLive.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanelLive.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.xPanderPanelLive.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty;
            this.xPanderPanelLive.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty;
            this.xPanderPanelLive.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty;
            this.xPanderPanelLive.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelLive.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelLive.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanelLive.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.xPanderPanelLive.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanelLive.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanderPanelLive.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanderPanelLive.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanderPanelLive.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanderPanelLive.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanderPanelLive.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanderPanelLive.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelLive.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelLive.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanelLive.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanelLive.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.xPanderPanelLive.Expand = true;
            this.xPanderPanelLive.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelLive.Image = null;
            this.xPanderPanelLive.IsClosable = false;
            this.xPanderPanelLive.Margin = new System.Windows.Forms.Padding(2);
            this.xPanderPanelLive.Name = "xPanderPanelLive";
            this.xPanderPanelLive.Padding = new System.Windows.Forms.Padding(0, 0, 0, 24);
            this.xPanderPanelLive.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanelLive.Size = new System.Drawing.Size(228, 411);
            this.xPanderPanelLive.TabIndex = 2;
            this.xPanderPanelLive.Text = "Finishing";
            this.xPanderPanelLive.ToolTipTextCloseIcon = null;
            this.xPanderPanelLive.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanelLive.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // chkIncludeReportDateAndTime
            // 
            this.chkIncludeReportDateAndTime.AutoSize = true;
            this.chkIncludeReportDateAndTime.Checked = true;
            this.chkIncludeReportDateAndTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeReportDateAndTime.Location = new System.Drawing.Point(22, 79);
            this.chkIncludeReportDateAndTime.Name = "chkIncludeReportDateAndTime";
            this.chkIncludeReportDateAndTime.Size = new System.Drawing.Size(169, 17);
            this.chkIncludeReportDateAndTime.TabIndex = 5;
            this.chkIncludeReportDateAndTime.Text = "Include Report Date and Time";
            this.chkIncludeReportDateAndTime.UseVisualStyleBackColor = true;
            // 
            // chkIncludeCompanyAddress
            // 
            this.chkIncludeCompanyAddress.AutoSize = true;
            this.chkIncludeCompanyAddress.Checked = true;
            this.chkIncludeCompanyAddress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeCompanyAddress.Location = new System.Drawing.Point(22, 56);
            this.chkIncludeCompanyAddress.Name = "chkIncludeCompanyAddress";
            this.chkIncludeCompanyAddress.Size = new System.Drawing.Size(149, 17);
            this.chkIncludeCompanyAddress.TabIndex = 4;
            this.chkIncludeCompanyAddress.Text = "Include Company Address";
            this.chkIncludeCompanyAddress.UseVisualStyleBackColor = true;
            // 
            // chkIncludeCompanyName
            // 
            this.chkIncludeCompanyName.AutoSize = true;
            this.chkIncludeCompanyName.Checked = true;
            this.chkIncludeCompanyName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeCompanyName.Location = new System.Drawing.Point(22, 32);
            this.chkIncludeCompanyName.Name = "chkIncludeCompanyName";
            this.chkIncludeCompanyName.Size = new System.Drawing.Size(139, 17);
            this.chkIncludeCompanyName.TabIndex = 3;
            this.chkIncludeCompanyName.Text = "Include Company Name";
            this.chkIncludeCompanyName.UseVisualStyleBackColor = true;
            // 
            // FrmRptSalesItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(790, 490);
            this.Controls.Add(this.RptViewer);
            this.Controls.Add(this.panelMenu);
            this.Name = "FrmRptSalesItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Analyse Sales [Item]";
            this.panelMenu.ResumeLayout(false);
            this.xPanderPanelList1.ResumeLayout(false);
            this.xPanderPanelMain.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.xPanderPanelCache.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.xPanderPanelLive.ResumeLayout(false);
            this.xPanderPanelLive.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VistaButton btnGenerate;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.CheckBox chkGender;
        private System.Windows.Forms.CheckBox chkSize;
        private System.Windows.Forms.CheckBox chkColor;
        private System.Windows.Forms.CheckBox chkBrand;
        private System.Windows.Forms.CheckBox chkExpiryDate;
        private System.Windows.Forms.CheckBox chkSerialNumber;
        private System.Windows.Forms.CheckBox chkAverageCost;
        private System.Windows.Forms.CheckBox chkBatchNumber;
        private System.Windows.Forms.TextBox txtFromYear;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.TextBox txtToYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkSaleAmount;
        private System.Windows.Forms.CheckBox chkCostOfSales;
        private System.Windows.Forms.CheckBox chkGrossProfit;
        private System.Windows.Forms.CheckBox chkProfitMargin;
        private System.Windows.Forms.CheckBox chkItemName;
        private System.Windows.Forms.CheckBox chkUnitsSold;
        private System.Windows.Forms.CheckBox chkItemNumber;
        private System.Windows.Forms.VistaButton btnGenerateAndEmail;
        private System.Windows.Forms.WebBrowser RptViewer;
        private System.Windows.Forms.VistaButton BtnSave;
        private System.Windows.Forms.ComboBox cboExpiryDate;
        private System.Windows.Forms.ComboBox cboSerialNumber;
        private System.Windows.Forms.ComboBox cboBatchNumber;
        private System.Windows.Forms.ComboBox cboItemNumber;
        private System.Windows.Forms.ComboBox cboUnitsSold;
        private System.Windows.Forms.ComboBox cboGrossProfit;
        private System.Windows.Forms.ComboBox cboCostOfSales;
        private System.Windows.Forms.ComboBox cboAverageCost;
        private System.Windows.Forms.ComboBox cboItemName;
        private System.Windows.Forms.ComboBox cboProfitMargin;
        private System.Windows.Forms.ComboBox cboSize;
        private System.Windows.Forms.ComboBox cboSaleAmount;
        private System.Windows.Forms.ComboBox cboColor;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.ComboBox cboBrand;
        private System.Windows.Forms.VistaButton btnClose;
        private BSE.Windows.Forms.Panel panelMenu;
        private BSE.Windows.Forms.XPanderPanelList xPanderPanelList1;
        private BSE.Windows.Forms.XPanderPanel xPanderPanelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private BSE.Windows.Forms.XPanderPanel xPanderPanelCache;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private BSE.Windows.Forms.XPanderPanel xPanderPanelLive;
        private System.Windows.Forms.CheckBox chkIncludeReportDateAndTime;
        private System.Windows.Forms.CheckBox chkIncludeCompanyAddress;
        private System.Windows.Forms.CheckBox chkIncludeCompanyName;
    }
}