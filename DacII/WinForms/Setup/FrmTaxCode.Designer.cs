namespace DacII.WinForms.Setup
{
    partial class FrmTaxCode
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
            this.cboTaxType = new System.Windows.Forms.ComboBox();
            this.txtSubTaxCode = new System.Windows.Forms.TextBox();
            this.txtTaxCodePercentage = new System.Windows.Forms.TextBox();
            this.txtTaxCodeDescription = new System.Windows.Forms.TextBox();
            this.lblPercentageSign = new System.Windows.Forms.Label();
            this.lblTaxType = new System.Windows.Forms.Label();
            this.lblSubTaxCode = new System.Windows.Forms.Label();
            this.lblTaxCodePercentage = new System.Windows.Forms.Label();
            this.lblTaxCodeDescription = new System.Windows.Forms.Label();
            this.txtTaxCode = new System.Windows.Forms.TextBox();
            this.lblTaxCode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboTaxType
            // 
            this.cboTaxType.FormattingEnabled = true;
            this.cboTaxType.Location = new System.Drawing.Point(145, 90);
            this.cboTaxType.Name = "cboTaxType";
            this.cboTaxType.Size = new System.Drawing.Size(183, 21);
            this.cboTaxType.TabIndex = 18;
            // 
            // txtSubTaxCode
            // 
            this.txtSubTaxCode.Location = new System.Drawing.Point(145, 120);
            this.txtSubTaxCode.Name = "txtSubTaxCode";
            this.txtSubTaxCode.Size = new System.Drawing.Size(63, 20);
            this.txtSubTaxCode.TabIndex = 14;
            // 
            // txtTaxCodePercentage
            // 
            this.txtTaxCodePercentage.Location = new System.Drawing.Point(145, 64);
            this.txtTaxCodePercentage.Name = "txtTaxCodePercentage";
            this.txtTaxCodePercentage.Size = new System.Drawing.Size(63, 20);
            this.txtTaxCodePercentage.TabIndex = 15;
            // 
            // txtTaxCodeDescription
            // 
            this.txtTaxCodeDescription.Location = new System.Drawing.Point(145, 38);
            this.txtTaxCodeDescription.Name = "txtTaxCodeDescription";
            this.txtTaxCodeDescription.Size = new System.Drawing.Size(183, 20);
            this.txtTaxCodeDescription.TabIndex = 16;
            // 
            // lblPercentageSign
            // 
            this.lblPercentageSign.AutoSize = true;
            this.lblPercentageSign.Location = new System.Drawing.Point(214, 67);
            this.lblPercentageSign.Name = "lblPercentageSign";
            this.lblPercentageSign.Size = new System.Drawing.Size(15, 13);
            this.lblPercentageSign.TabIndex = 13;
            this.lblPercentageSign.Text = "%";
            // 
            // lblTaxType
            // 
            this.lblTaxType.AutoSize = true;
            this.lblTaxType.Location = new System.Drawing.Point(20, 93);
            this.lblTaxType.Name = "lblTaxType";
            this.lblTaxType.Size = new System.Drawing.Size(52, 13);
            this.lblTaxType.TabIndex = 10;
            this.lblTaxType.Text = "Tax Type";
            // 
            // lblSubTaxCode
            // 
            this.lblSubTaxCode.AutoSize = true;
            this.lblSubTaxCode.Location = new System.Drawing.Point(20, 123);
            this.lblSubTaxCode.Name = "lblSubTaxCode";
            this.lblSubTaxCode.Size = new System.Drawing.Size(69, 13);
            this.lblSubTaxCode.TabIndex = 9;
            this.lblSubTaxCode.Text = "SubTaxCode";
            // 
            // lblTaxCodePercentage
            // 
            this.lblTaxCodePercentage.AutoSize = true;
            this.lblTaxCodePercentage.Location = new System.Drawing.Point(20, 67);
            this.lblTaxCodePercentage.Name = "lblTaxCodePercentage";
            this.lblTaxCodePercentage.Size = new System.Drawing.Size(62, 13);
            this.lblTaxCodePercentage.TabIndex = 12;
            this.lblTaxCodePercentage.Text = "Percentage";
            // 
            // lblTaxCodeDescription
            // 
            this.lblTaxCodeDescription.AutoSize = true;
            this.lblTaxCodeDescription.Location = new System.Drawing.Point(20, 41);
            this.lblTaxCodeDescription.Name = "lblTaxCodeDescription";
            this.lblTaxCodeDescription.Size = new System.Drawing.Size(60, 13);
            this.lblTaxCodeDescription.TabIndex = 11;
            this.lblTaxCodeDescription.Text = "Description";
            // 
            // txtTaxCode
            // 
            this.txtTaxCode.Location = new System.Drawing.Point(145, 12);
            this.txtTaxCode.Name = "txtTaxCode";
            this.txtTaxCode.Size = new System.Drawing.Size(183, 20);
            this.txtTaxCode.TabIndex = 17;
            // 
            // lblTaxCode
            // 
            this.lblTaxCode.AutoSize = true;
            this.lblTaxCode.Location = new System.Drawing.Point(20, 15);
            this.lblTaxCode.Name = "lblTaxCode";
            this.lblTaxCode.Size = new System.Drawing.Size(53, 13);
            this.lblTaxCode.TabIndex = 8;
            this.lblTaxCode.Text = "Tax Code";
            // 
            // FrmTaxCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 163);
            this.Controls.Add(this.cboTaxType);
            this.Controls.Add(this.txtSubTaxCode);
            this.Controls.Add(this.txtTaxCodePercentage);
            this.Controls.Add(this.txtTaxCodeDescription);
            this.Controls.Add(this.lblPercentageSign);
            this.Controls.Add(this.lblTaxType);
            this.Controls.Add(this.lblSubTaxCode);
            this.Controls.Add(this.lblTaxCodePercentage);
            this.Controls.Add(this.lblTaxCodeDescription);
            this.Controls.Add(this.txtTaxCode);
            this.Controls.Add(this.lblTaxCode);
            this.Name = "FrmTaxCode";
            this.Text = "Tax Code";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTaxType;
        private System.Windows.Forms.TextBox txtSubTaxCode;
        private System.Windows.Forms.TextBox txtTaxCodePercentage;
        private System.Windows.Forms.TextBox txtTaxCodeDescription;
        private System.Windows.Forms.Label lblPercentageSign;
        private System.Windows.Forms.Label lblTaxType;
        private System.Windows.Forms.Label lblSubTaxCode;
        private System.Windows.Forms.Label lblTaxCodePercentage;
        private System.Windows.Forms.Label lblTaxCodeDescription;
        private System.Windows.Forms.TextBox txtTaxCode;
        private System.Windows.Forms.Label lblTaxCode;
    }
}