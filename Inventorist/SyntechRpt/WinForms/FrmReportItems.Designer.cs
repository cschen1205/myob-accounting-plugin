namespace SyntechRpt.WinForms
{
    partial class FrmReportItems
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkGender = new System.Windows.Forms.CheckBox();
            this.chkSize = new System.Windows.Forms.CheckBox();
            this.chkColor = new System.Windows.Forms.CheckBox();
            this.chkBrand = new System.Windows.Forms.CheckBox();
            this.chkExpiryDate = new System.Windows.Forms.CheckBox();
            this.chkSerialNumber = new System.Windows.Forms.CheckBox();
            this.chkAverageCost = new System.Windows.Forms.CheckBox();
            this.chkBatchNumber = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtFromYear = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtToYear = new System.Windows.Forms.TextBox();
            this.chkSaleAmount = new System.Windows.Forms.CheckBox();
            this.chkCostOfSalesAmount = new System.Windows.Forms.CheckBox();
            this.chkGrossProfit = new System.Windows.Forms.CheckBox();
            this.chkProfitMargin = new System.Windows.Forms.CheckBox();
            this.chkUnitsSold = new System.Windows.Forms.CheckBox();
            this.chkItemName = new System.Windows.Forms.CheckBox();
            this.chkItemNumber = new System.Windows.Forms.CheckBox();
            this.btnGenerateAndEmail = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(289, 212);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(476, 194);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkGender);
            this.tabPage1.Controls.Add(this.chkSize);
            this.tabPage1.Controls.Add(this.chkColor);
            this.tabPage1.Controls.Add(this.chkBrand);
            this.tabPage1.Controls.Add(this.chkExpiryDate);
            this.tabPage1.Controls.Add(this.chkSerialNumber);
            this.tabPage1.Controls.Add(this.chkItemNumber);
            this.tabPage1.Controls.Add(this.chkItemName);
            this.tabPage1.Controls.Add(this.chkUnitsSold);
            this.tabPage1.Controls.Add(this.chkProfitMargin);
            this.tabPage1.Controls.Add(this.chkGrossProfit);
            this.tabPage1.Controls.Add(this.chkCostOfSalesAmount);
            this.tabPage1.Controls.Add(this.chkSaleAmount);
            this.tabPage1.Controls.Add(this.chkAverageCost);
            this.tabPage1.Controls.Add(this.chkBatchNumber);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(468, 168);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Include Fields:";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkGender
            // 
            this.chkGender.AutoSize = true;
            this.chkGender.Checked = true;
            this.chkGender.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGender.Location = new System.Drawing.Point(6, 144);
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
            this.chkSize.Location = new System.Drawing.Point(6, 121);
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
            this.chkColor.Location = new System.Drawing.Point(6, 98);
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
            this.chkBrand.Location = new System.Drawing.Point(6, 75);
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
            this.chkExpiryDate.Location = new System.Drawing.Point(6, 52);
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
            this.chkSerialNumber.Location = new System.Drawing.Point(6, 29);
            this.chkSerialNumber.Name = "chkSerialNumber";
            this.chkSerialNumber.Size = new System.Drawing.Size(62, 17);
            this.chkSerialNumber.TabIndex = 1;
            this.chkSerialNumber.Text = "Serial #";
            this.chkSerialNumber.UseVisualStyleBackColor = true;
            // 
            // chkAverageCost
            // 
            this.chkAverageCost.AutoSize = true;
            this.chkAverageCost.Checked = true;
            this.chkAverageCost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAverageCost.Location = new System.Drawing.Point(103, 29);
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
            this.chkBatchNumber.Location = new System.Drawing.Point(6, 6);
            this.chkBatchNumber.Name = "chkBatchNumber";
            this.chkBatchNumber.Size = new System.Drawing.Size(64, 17);
            this.chkBatchNumber.TabIndex = 3;
            this.chkBatchNumber.Text = "Batch #";
            this.chkBatchNumber.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtToYear);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txtFromYear);
            this.tabPage2.Controls.Add(this.lblFrom);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(468, 168);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Include Periods";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtFromYear
            // 
            this.txtFromYear.Location = new System.Drawing.Point(84, 16);
            this.txtFromYear.Name = "txtFromYear";
            this.txtFromYear.Size = new System.Drawing.Size(47, 20);
            this.txtFromYear.TabIndex = 1;
            this.txtFromYear.Text = "2010";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(12, 19);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(58, 13);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From Year:";
            this.lblFrom.Click += new System.EventHandler(this.lblFrom_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "To Year:";
            this.label2.Click += new System.EventHandler(this.lblFrom_Click);
            // 
            // txtToYear
            // 
            this.txtToYear.Location = new System.Drawing.Point(221, 16);
            this.txtToYear.Name = "txtToYear";
            this.txtToYear.Size = new System.Drawing.Size(47, 20);
            this.txtToYear.TabIndex = 1;
            this.txtToYear.Text = "2010";
            // 
            // chkSaleAmount
            // 
            this.chkSaleAmount.AutoSize = true;
            this.chkSaleAmount.Checked = true;
            this.chkSaleAmount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaleAmount.Location = new System.Drawing.Point(103, 52);
            this.chkSaleAmount.Name = "chkSaleAmount";
            this.chkSaleAmount.Size = new System.Drawing.Size(86, 17);
            this.chkSaleAmount.TabIndex = 4;
            this.chkSaleAmount.Text = "Sale Amount";
            this.chkSaleAmount.UseVisualStyleBackColor = true;
            // 
            // chkCostOfSalesAmount
            // 
            this.chkCostOfSalesAmount.AutoSize = true;
            this.chkCostOfSalesAmount.Checked = true;
            this.chkCostOfSalesAmount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCostOfSalesAmount.Location = new System.Drawing.Point(103, 75);
            this.chkCostOfSalesAmount.Name = "chkCostOfSalesAmount";
            this.chkCostOfSalesAmount.Size = new System.Drawing.Size(88, 17);
            this.chkCostOfSalesAmount.TabIndex = 4;
            this.chkCostOfSalesAmount.Text = "Cost of Sales";
            this.chkCostOfSalesAmount.UseVisualStyleBackColor = true;
            // 
            // chkGrossProfit
            // 
            this.chkGrossProfit.AutoSize = true;
            this.chkGrossProfit.Checked = true;
            this.chkGrossProfit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGrossProfit.Location = new System.Drawing.Point(103, 98);
            this.chkGrossProfit.Name = "chkGrossProfit";
            this.chkGrossProfit.Size = new System.Drawing.Size(80, 17);
            this.chkGrossProfit.TabIndex = 4;
            this.chkGrossProfit.Text = "Gross Profit";
            this.chkGrossProfit.UseVisualStyleBackColor = true;
            // 
            // chkProfitMargin
            // 
            this.chkProfitMargin.AutoSize = true;
            this.chkProfitMargin.Checked = true;
            this.chkProfitMargin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProfitMargin.Location = new System.Drawing.Point(103, 121);
            this.chkProfitMargin.Name = "chkProfitMargin";
            this.chkProfitMargin.Size = new System.Drawing.Size(85, 17);
            this.chkProfitMargin.TabIndex = 4;
            this.chkProfitMargin.Text = "Profit Margin";
            this.chkProfitMargin.UseVisualStyleBackColor = true;
            // 
            // chkUnitsSold
            // 
            this.chkUnitsSold.AutoSize = true;
            this.chkUnitsSold.Checked = true;
            this.chkUnitsSold.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUnitsSold.Location = new System.Drawing.Point(103, 144);
            this.chkUnitsSold.Name = "chkUnitsSold";
            this.chkUnitsSold.Size = new System.Drawing.Size(74, 17);
            this.chkUnitsSold.TabIndex = 4;
            this.chkUnitsSold.Text = "Units Sold";
            this.chkUnitsSold.UseVisualStyleBackColor = true;
            // 
            // chkItemName
            // 
            this.chkItemName.AutoSize = true;
            this.chkItemName.Checked = true;
            this.chkItemName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkItemName.Location = new System.Drawing.Point(103, 6);
            this.chkItemName.Name = "chkItemName";
            this.chkItemName.Size = new System.Drawing.Size(77, 17);
            this.chkItemName.TabIndex = 4;
            this.chkItemName.Text = "Item Name";
            this.chkItemName.UseVisualStyleBackColor = true;
            // 
            // chkItemNumber
            // 
            this.chkItemNumber.AutoSize = true;
            this.chkItemNumber.Checked = true;
            this.chkItemNumber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkItemNumber.Location = new System.Drawing.Point(206, 6);
            this.chkItemNumber.Name = "chkItemNumber";
            this.chkItemNumber.Size = new System.Drawing.Size(56, 17);
            this.chkItemNumber.TabIndex = 4;
            this.chkItemNumber.Text = "Item #";
            this.chkItemNumber.UseVisualStyleBackColor = true;
            // 
            // btnGenerateAndEmail
            // 
            this.btnGenerateAndEmail.Location = new System.Drawing.Point(370, 212);
            this.btnGenerateAndEmail.Name = "btnGenerateAndEmail";
            this.btnGenerateAndEmail.Size = new System.Drawing.Size(114, 23);
            this.btnGenerateAndEmail.TabIndex = 1;
            this.btnGenerateAndEmail.Text = "Generate && Email";
            this.btnGenerateAndEmail.UseVisualStyleBackColor = true;
            this.btnGenerateAndEmail.Click += new System.EventHandler(this.btnGenerateAndEmail_Click);
            // 
            // FrmReportItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 247);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnGenerateAndEmail);
            this.Controls.Add(this.btnGenerate);
            this.Name = "FrmReportItems";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Analyse Sales [Item]";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox chkGender;
        private System.Windows.Forms.CheckBox chkSize;
        private System.Windows.Forms.CheckBox chkColor;
        private System.Windows.Forms.CheckBox chkBrand;
        private System.Windows.Forms.CheckBox chkExpiryDate;
        private System.Windows.Forms.CheckBox chkSerialNumber;
        private System.Windows.Forms.CheckBox chkAverageCost;
        private System.Windows.Forms.CheckBox chkBatchNumber;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtFromYear;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.TextBox txtToYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkSaleAmount;
        private System.Windows.Forms.CheckBox chkCostOfSalesAmount;
        private System.Windows.Forms.CheckBox chkGrossProfit;
        private System.Windows.Forms.CheckBox chkProfitMargin;
        private System.Windows.Forms.CheckBox chkItemName;
        private System.Windows.Forms.CheckBox chkUnitsSold;
        private System.Windows.Forms.CheckBox chkItemNumber;
        private System.Windows.Forms.Button btnGenerateAndEmail;
    }
}