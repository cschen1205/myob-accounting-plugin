namespace DacII.WinForms.Purchases.PurchaseLines
{
    partial class FrmMiscPurchaseLine
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
            this.gbMiscPurchaseLine = new System.Windows.Forms.CZRoundedGroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.cboJob = new System.Windows.Forms.ComboBox();
            this.cboTax = new System.Windows.Forms.ComboBox();
            this.lblJob = new System.Windows.Forms.Label();
            this.cboAccount = new System.Windows.Forms.ComboBox();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbMiscPurchaseLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMiscPurchaseLine
            // 
            this.gbMiscPurchaseLine.BackgroundColor = System.Drawing.Color.White;
            this.gbMiscPurchaseLine.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbMiscPurchaseLine.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbMiscPurchaseLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbMiscPurchaseLine.BorderWidth = 1F;
            this.gbMiscPurchaseLine.Caption = "";
            this.gbMiscPurchaseLine.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbMiscPurchaseLine.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbMiscPurchaseLine.CaptionHeight = 25;
            this.gbMiscPurchaseLine.CaptionVisible = true;
            this.gbMiscPurchaseLine.Controls.Add(this.txtDescription);
            this.gbMiscPurchaseLine.Controls.Add(this.txtAmount);
            this.gbMiscPurchaseLine.Controls.Add(this.lblDescription);
            this.gbMiscPurchaseLine.Controls.Add(this.lblAmount);
            this.gbMiscPurchaseLine.Controls.Add(this.cboJob);
            this.gbMiscPurchaseLine.Controls.Add(this.cboTax);
            this.gbMiscPurchaseLine.Controls.Add(this.lblJob);
            this.gbMiscPurchaseLine.Controls.Add(this.cboAccount);
            this.gbMiscPurchaseLine.Controls.Add(this.lblTax);
            this.gbMiscPurchaseLine.Controls.Add(this.lblAccount);
            this.gbMiscPurchaseLine.CornerRadius = 5;
            this.gbMiscPurchaseLine.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbMiscPurchaseLine.DropShadowThickness = 3;
            this.gbMiscPurchaseLine.DropShadowVisible = true;
            this.gbMiscPurchaseLine.Location = new System.Drawing.Point(12, 12);
            this.gbMiscPurchaseLine.Name = "gbMiscPurchaseLine";
            this.gbMiscPurchaseLine.Size = new System.Drawing.Size(356, 228);
            this.gbMiscPurchaseLine.TabIndex = 6;
            this.gbMiscPurchaseLine.TabStop = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(18, 126);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(316, 83);
            this.txtDescription.TabIndex = 6;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(86, 56);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 6;
            this.txtAmount.Text = "0";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Location = new System.Drawing.Point(15, 108);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblAmount.Location = new System.Drawing.Point(15, 59);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(46, 13);
            this.lblAmount.TabIndex = 4;
            this.lblAmount.Text = "Amount:";
            // 
            // cboJob
            // 
            this.cboJob.FormattingEnabled = true;
            this.cboJob.Location = new System.Drawing.Point(234, 56);
            this.cboJob.Name = "cboJob";
            this.cboJob.Size = new System.Drawing.Size(100, 21);
            this.cboJob.TabIndex = 5;
            // 
            // cboTax
            // 
            this.cboTax.FormattingEnabled = true;
            this.cboTax.Location = new System.Drawing.Point(86, 82);
            this.cboTax.Name = "cboTax";
            this.cboTax.Size = new System.Drawing.Size(100, 21);
            this.cboTax.TabIndex = 5;
            // 
            // lblJob
            // 
            this.lblJob.AutoSize = true;
            this.lblJob.BackColor = System.Drawing.Color.Transparent;
            this.lblJob.Location = new System.Drawing.Point(197, 59);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(27, 13);
            this.lblJob.TabIndex = 4;
            this.lblJob.Text = "Job:";
            // 
            // cboAccount
            // 
            this.cboAccount.FormattingEnabled = true;
            this.cboAccount.Location = new System.Drawing.Point(86, 29);
            this.cboAccount.Name = "cboAccount";
            this.cboAccount.Size = new System.Drawing.Size(248, 21);
            this.cboAccount.TabIndex = 5;
            this.cboAccount.SelectedIndexChanged += new System.EventHandler(this.OnAccountChanged);
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.BackColor = System.Drawing.Color.Transparent;
            this.lblTax.Location = new System.Drawing.Point(15, 85);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(28, 13);
            this.lblTax.TabIndex = 4;
            this.lblTax.Text = "Tax:";
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.BackColor = System.Drawing.Color.Transparent;
            this.lblAccount.Location = new System.Drawing.Point(15, 32);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(50, 13);
            this.lblAccount.TabIndex = 4;
            this.lblAccount.Text = "Account:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(293, 246);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOK.Location = new System.Drawing.Point(212, 246);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.Record);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FrmMiscPurchaseLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 280);
            this.Controls.Add(this.gbMiscPurchaseLine);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOK);
            this.Name = "FrmMiscPurchaseLine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Miscellaneous Purchase Line";
            this.gbMiscPurchaseLine.ResumeLayout(false);
            this.gbMiscPurchaseLine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CZRoundedGroupBox gbMiscPurchaseLine;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.ComboBox cboJob;
        private System.Windows.Forms.ComboBox cboTax;
        private System.Windows.Forms.Label lblJob;
        private System.Windows.Forms.ComboBox cboAccount;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}