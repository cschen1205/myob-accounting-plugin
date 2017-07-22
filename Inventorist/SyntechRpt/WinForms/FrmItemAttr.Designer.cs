namespace SyntechRpt.WinForms
{
    partial class FrmItemAttr
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
            this.lvItems = new System.Windows.Forms.ListView();
            this.grp = new System.Windows.Forms.GroupBox();
            this.btnRecord = new System.Windows.Forms.Button();
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
            this.txtItemNumber = new System.Windows.Forms.TextBox();
            this.lblItemNumber = new System.Windows.Forms.Label();
            this.txtBatchNumber = new System.Windows.Forms.TextBox();
            this.lblBatchNumber = new System.Windows.Forms.Label();
            this.grp.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvItems
            // 
            this.lvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvItems.Location = new System.Drawing.Point(12, 12);
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(424, 291);
            this.lvItems.TabIndex = 0;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            this.lvItems.View = System.Windows.Forms.View.Details;
            this.lvItems.SelectedIndexChanged += new System.EventHandler(this.lvItems_SelectedIndexChanged);
            // 
            // grp
            // 
            this.grp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grp.Controls.Add(this.btnRecord);
            this.grp.Controls.Add(this.cboSize);
            this.grp.Controls.Add(this.cboGender);
            this.grp.Controls.Add(this.dpExpiryDate);
            this.grp.Controls.Add(this.lblExpiryDate);
            this.grp.Controls.Add(this.lblGender);
            this.grp.Controls.Add(this.txtColor);
            this.grp.Controls.Add(this.lblColor);
            this.grp.Controls.Add(this.lblSize);
            this.grp.Controls.Add(this.txtBrand);
            this.grp.Controls.Add(this.lblBrand);
            this.grp.Controls.Add(this.txtSerialNumber);
            this.grp.Controls.Add(this.lblSerialNumber);
            this.grp.Controls.Add(this.txtItemNumber);
            this.grp.Controls.Add(this.lblItemNumber);
            this.grp.Controls.Add(this.txtBatchNumber);
            this.grp.Controls.Add(this.lblBatchNumber);
            this.grp.Location = new System.Drawing.Point(442, 12);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(251, 291);
            this.grp.TabIndex = 1;
            this.grp.TabStop = false;
            this.grp.Text = "Item Attributes";
            // 
            // btnRecord
            // 
            this.btnRecord.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecord.Location = new System.Drawing.Point(124, 253);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(75, 23);
            this.btnRecord.TabIndex = 4;
            this.btnRecord.Text = "Record";
            this.btnRecord.UseVisualStyleBackColor = false;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // cboSize
            // 
            this.cboSize.FormattingEnabled = true;
            this.cboSize.Location = new System.Drawing.Point(70, 148);
            this.cboSize.Name = "cboSize";
            this.cboSize.Size = new System.Drawing.Size(129, 21);
            this.cboSize.TabIndex = 3;
            // 
            // cboGender
            // 
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Location = new System.Drawing.Point(70, 201);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(129, 21);
            this.cboGender.TabIndex = 3;
            // 
            // dpExpiryDate
            // 
            this.dpExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpExpiryDate.Location = new System.Drawing.Point(70, 97);
            this.dpExpiryDate.Name = "dpExpiryDate";
            this.dpExpiryDate.Size = new System.Drawing.Size(129, 20);
            this.dpExpiryDate.TabIndex = 2;
            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Location = new System.Drawing.Point(16, 100);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new System.Drawing.Size(45, 13);
            this.lblExpiryDate.TabIndex = 0;
            this.lblExpiryDate.Text = "Expired:";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(16, 204);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(45, 13);
            this.lblGender.TabIndex = 0;
            this.lblGender.Text = "Gender:";
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(70, 175);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(129, 20);
            this.txtColor.TabIndex = 1;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(16, 178);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(34, 13);
            this.lblColor.TabIndex = 0;
            this.lblColor.Text = "Color:";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(16, 152);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(30, 13);
            this.lblSize.TabIndex = 0;
            this.lblSize.Text = "Size:";
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(70, 123);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(129, 20);
            this.txtBrand.TabIndex = 1;
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(16, 126);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(38, 13);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "Brand:";
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Location = new System.Drawing.Point(70, 71);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(129, 20);
            this.txtSerialNumber.TabIndex = 1;
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.AutoSize = true;
            this.lblSerialNumber.Location = new System.Drawing.Point(16, 74);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Size = new System.Drawing.Size(46, 13);
            this.lblSerialNumber.TabIndex = 0;
            this.lblSerialNumber.Text = "Serial #:";
            // 
            // txtItemNumber
            // 
            this.txtItemNumber.Enabled = false;
            this.txtItemNumber.Location = new System.Drawing.Point(70, 19);
            this.txtItemNumber.Name = "txtItemNumber";
            this.txtItemNumber.Size = new System.Drawing.Size(129, 20);
            this.txtItemNumber.TabIndex = 1;
            // 
            // lblItemNumber
            // 
            this.lblItemNumber.AutoSize = true;
            this.lblItemNumber.Enabled = false;
            this.lblItemNumber.Location = new System.Drawing.Point(16, 22);
            this.lblItemNumber.Name = "lblItemNumber";
            this.lblItemNumber.Size = new System.Drawing.Size(40, 13);
            this.lblItemNumber.TabIndex = 0;
            this.lblItemNumber.Text = "Item #:";
            // 
            // txtBatchNumber
            // 
            this.txtBatchNumber.Location = new System.Drawing.Point(70, 45);
            this.txtBatchNumber.Name = "txtBatchNumber";
            this.txtBatchNumber.Size = new System.Drawing.Size(129, 20);
            this.txtBatchNumber.TabIndex = 1;
            // 
            // lblBatchNumber
            // 
            this.lblBatchNumber.AutoSize = true;
            this.lblBatchNumber.Location = new System.Drawing.Point(16, 48);
            this.lblBatchNumber.Name = "lblBatchNumber";
            this.lblBatchNumber.Size = new System.Drawing.Size(48, 13);
            this.lblBatchNumber.TabIndex = 0;
            this.lblBatchNumber.Text = "Batch #:";
            // 
            // FrmItemAttr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 315);
            this.Controls.Add(this.grp);
            this.Controls.Add(this.lvItems);
            this.Name = "FrmItemAttr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Attributes:";
            this.Load += new System.EventHandler(this.FrmItemAttr_Load);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvItems;
        private System.Windows.Forms.GroupBox grp;
        private System.Windows.Forms.Label lblBatchNumber;
        private System.Windows.Forms.TextBox txtBatchNumber;
        private System.Windows.Forms.DateTimePicker dpExpiryDate;
        private System.Windows.Forms.Label lblExpiryDate;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.TextBox txtItemNumber;
        private System.Windows.Forms.Label lblItemNumber;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.ComboBox cboSize;
    }
}