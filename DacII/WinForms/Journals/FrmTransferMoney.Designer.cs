namespace DacII.WinForms.Journals
{
    partial class FrmTransferMoney
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
            this.gpTransferMoney = new System.Windows.Forms.CZRoundedGroupBox();
            this.cboToAccount = new System.Windows.Forms.ComboBox();
            this.cboFromAccount = new System.Windows.Forms.ComboBox();
            this.lblMemo = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblTransferMoneyTo = new System.Windows.Forms.Label();
            this.lblTransferMoneyFrom = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtJournalMemo = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblTransferDate = new System.Windows.Forms.Label();
            this.txtTransferNo = new System.Windows.Forms.TextBox();
            this.lblTransferNo = new System.Windows.Forms.Label();
            this.lblFromAccountName = new System.Windows.Forms.Label();
            this.lblToAccountName = new System.Windows.Forms.Label();
            this.lblCurrentBalance = new System.Windows.Forms.Label();
            this.lblBalanceAfterTransfer = new System.Windows.Forms.Label();
            this.lblFromAccountCurrentBalance = new System.Windows.Forms.Label();
            this.lblToAccountCurrentBalance = new System.Windows.Forms.Label();
            this.lblFromAccountBalanceAfterTransfer = new System.Windows.Forms.Label();
            this.lblToAccountBalanceAfterTransfer = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.gpTransferMoney.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpTransferMoney
            // 
            this.gpTransferMoney.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpTransferMoney.BackgroundColor = System.Drawing.Color.White;
            this.gpTransferMoney.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gpTransferMoney.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gpTransferMoney.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gpTransferMoney.BorderWidth = 1F;
            this.gpTransferMoney.Caption = "";
            this.gpTransferMoney.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gpTransferMoney.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gpTransferMoney.CaptionHeight = 25;
            this.gpTransferMoney.CaptionVisible = true;
            this.gpTransferMoney.Controls.Add(this.cboToAccount);
            this.gpTransferMoney.Controls.Add(this.cboFromAccount);
            this.gpTransferMoney.Controls.Add(this.lblMemo);
            this.gpTransferMoney.Controls.Add(this.lblAmount);
            this.gpTransferMoney.Controls.Add(this.lblTransferMoneyTo);
            this.gpTransferMoney.Controls.Add(this.lblTransferMoneyFrom);
            this.gpTransferMoney.Controls.Add(this.dtpDate);
            this.gpTransferMoney.Controls.Add(this.txtJournalMemo);
            this.gpTransferMoney.Controls.Add(this.txtAmount);
            this.gpTransferMoney.Controls.Add(this.lblTransferDate);
            this.gpTransferMoney.Controls.Add(this.txtTransferNo);
            this.gpTransferMoney.Controls.Add(this.lblTransferNo);
            this.gpTransferMoney.CornerRadius = 5;
            this.gpTransferMoney.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gpTransferMoney.DropShadowThickness = 3;
            this.gpTransferMoney.DropShadowVisible = true;
            this.gpTransferMoney.Location = new System.Drawing.Point(12, 12);
            this.gpTransferMoney.Name = "gpTransferMoney";
            this.gpTransferMoney.Size = new System.Drawing.Size(760, 264);
            this.gpTransferMoney.TabIndex = 0;
            this.gpTransferMoney.TabStop = false;
            // 
            // cboToAccount
            // 
            this.cboToAccount.FormattingEnabled = true;
            this.cboToAccount.Location = new System.Drawing.Point(158, 170);
            this.cboToAccount.Name = "cboToAccount";
            this.cboToAccount.Size = new System.Drawing.Size(241, 21);
            this.cboToAccount.TabIndex = 4;
            this.cboToAccount.SelectedIndexChanged += new System.EventHandler(this.cboToAccount_SelectedIndexChanged);
            // 
            // cboFromAccount
            // 
            this.cboFromAccount.FormattingEnabled = true;
            this.cboFromAccount.Location = new System.Drawing.Point(158, 140);
            this.cboFromAccount.Name = "cboFromAccount";
            this.cboFromAccount.Size = new System.Drawing.Size(241, 21);
            this.cboFromAccount.TabIndex = 4;
            this.cboFromAccount.SelectedIndexChanged += new System.EventHandler(this.cboFromAccount_SelectedIndexChanged);
            // 
            // lblMemo
            // 
            this.lblMemo.AutoSize = true;
            this.lblMemo.BackColor = System.Drawing.Color.Transparent;
            this.lblMemo.Location = new System.Drawing.Point(35, 227);
            this.lblMemo.Name = "lblMemo";
            this.lblMemo.Size = new System.Drawing.Size(39, 13);
            this.lblMemo.TabIndex = 3;
            this.lblMemo.Text = "Memo:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblAmount.Location = new System.Drawing.Point(35, 202);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(46, 13);
            this.lblAmount.TabIndex = 3;
            this.lblAmount.Text = "Amount:";
            // 
            // lblTransferMoneyTo
            // 
            this.lblTransferMoneyTo.AutoSize = true;
            this.lblTransferMoneyTo.BackColor = System.Drawing.Color.Transparent;
            this.lblTransferMoneyTo.Location = new System.Drawing.Point(35, 173);
            this.lblTransferMoneyTo.Name = "lblTransferMoneyTo";
            this.lblTransferMoneyTo.Size = new System.Drawing.Size(100, 13);
            this.lblTransferMoneyTo.TabIndex = 3;
            this.lblTransferMoneyTo.Text = "Transfer Money To:";
            // 
            // lblTransferMoneyFrom
            // 
            this.lblTransferMoneyFrom.AutoSize = true;
            this.lblTransferMoneyFrom.BackColor = System.Drawing.Color.Transparent;
            this.lblTransferMoneyFrom.Location = new System.Drawing.Point(35, 143);
            this.lblTransferMoneyFrom.Name = "lblTransferMoneyFrom";
            this.lblTransferMoneyFrom.Size = new System.Drawing.Size(110, 13);
            this.lblTransferMoneyFrom.TabIndex = 3;
            this.lblTransferMoneyFrom.Text = "Transfer Money From:";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(644, 64);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(100, 20);
            this.dtpDate.TabIndex = 2;
            // 
            // txtJournalMemo
            // 
            this.txtJournalMemo.Location = new System.Drawing.Point(158, 225);
            this.txtJournalMemo.Name = "txtJournalMemo";
            this.txtJournalMemo.Size = new System.Drawing.Size(375, 20);
            this.txtJournalMemo.TabIndex = 1;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(158, 199);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 1;
            this.txtAmount.Text = "0";
            // 
            // lblTransferDate
            // 
            this.lblTransferDate.AutoSize = true;
            this.lblTransferDate.BackColor = System.Drawing.Color.Transparent;
            this.lblTransferDate.Location = new System.Drawing.Point(563, 64);
            this.lblTransferDate.Name = "lblTransferDate";
            this.lblTransferDate.Size = new System.Drawing.Size(75, 13);
            this.lblTransferDate.TabIndex = 0;
            this.lblTransferDate.Text = "Transfer Date:";
            // 
            // txtTransferNo
            // 
            this.txtTransferNo.Location = new System.Drawing.Point(644, 35);
            this.txtTransferNo.Name = "txtTransferNo";
            this.txtTransferNo.Size = new System.Drawing.Size(100, 20);
            this.txtTransferNo.TabIndex = 1;
            // 
            // lblTransferNo
            // 
            this.lblTransferNo.AutoSize = true;
            this.lblTransferNo.BackColor = System.Drawing.Color.Transparent;
            this.lblTransferNo.Location = new System.Drawing.Point(579, 38);
            this.lblTransferNo.Name = "lblTransferNo";
            this.lblTransferNo.Size = new System.Drawing.Size(59, 13);
            this.lblTransferNo.TabIndex = 0;
            this.lblTransferNo.Text = "Transfer #:";
            // 
            // lblFromAccountName
            // 
            this.lblFromAccountName.AutoSize = true;
            this.lblFromAccountName.Location = new System.Drawing.Point(42, 341);
            this.lblFromAccountName.Name = "lblFromAccountName";
            this.lblFromAccountName.Size = new System.Drawing.Size(104, 13);
            this.lblFromAccountName.TabIndex = 1;
            this.lblFromAccountName.Text = "From Account Name";
            // 
            // lblToAccountName
            // 
            this.lblToAccountName.AutoSize = true;
            this.lblToAccountName.Location = new System.Drawing.Point(42, 367);
            this.lblToAccountName.Name = "lblToAccountName";
            this.lblToAccountName.Size = new System.Drawing.Size(94, 13);
            this.lblToAccountName.TabIndex = 1;
            this.lblToAccountName.Text = "To Account Name";
            // 
            // lblCurrentBalance
            // 
            this.lblCurrentBalance.AutoSize = true;
            this.lblCurrentBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCurrentBalance.Location = new System.Drawing.Point(191, 302);
            this.lblCurrentBalance.Name = "lblCurrentBalance";
            this.lblCurrentBalance.Size = new System.Drawing.Size(98, 13);
            this.lblCurrentBalance.TabIndex = 2;
            this.lblCurrentBalance.Text = "Current Balance";
            // 
            // lblBalanceAfterTransfer
            // 
            this.lblBalanceAfterTransfer.AutoSize = true;
            this.lblBalanceAfterTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBalanceAfterTransfer.Location = new System.Drawing.Point(447, 302);
            this.lblBalanceAfterTransfer.Name = "lblBalanceAfterTransfer";
            this.lblBalanceAfterTransfer.Size = new System.Drawing.Size(135, 13);
            this.lblBalanceAfterTransfer.TabIndex = 2;
            this.lblBalanceAfterTransfer.Text = "Balance After Transfer";
            // 
            // lblFromAccountCurrentBalance
            // 
            this.lblFromAccountCurrentBalance.AutoSize = true;
            this.lblFromAccountCurrentBalance.Location = new System.Drawing.Point(191, 341);
            this.lblFromAccountCurrentBalance.Name = "lblFromAccountCurrentBalance";
            this.lblFromAccountCurrentBalance.Size = new System.Drawing.Size(152, 13);
            this.lblFromAccountCurrentBalance.TabIndex = 1;
            this.lblFromAccountCurrentBalance.Text = "From Account Current Balance";
            // 
            // lblToAccountCurrentBalance
            // 
            this.lblToAccountCurrentBalance.AutoSize = true;
            this.lblToAccountCurrentBalance.Location = new System.Drawing.Point(191, 367);
            this.lblToAccountCurrentBalance.Name = "lblToAccountCurrentBalance";
            this.lblToAccountCurrentBalance.Size = new System.Drawing.Size(142, 13);
            this.lblToAccountCurrentBalance.TabIndex = 1;
            this.lblToAccountCurrentBalance.Text = "To Account Current Balance";
            // 
            // lblFromAccountBalanceAfterTransfer
            // 
            this.lblFromAccountBalanceAfterTransfer.AutoSize = true;
            this.lblFromAccountBalanceAfterTransfer.Location = new System.Drawing.Point(447, 341);
            this.lblFromAccountBalanceAfterTransfer.Name = "lblFromAccountBalanceAfterTransfer";
            this.lblFromAccountBalanceAfterTransfer.Size = new System.Drawing.Size(182, 13);
            this.lblFromAccountBalanceAfterTransfer.TabIndex = 1;
            this.lblFromAccountBalanceAfterTransfer.Text = "From Account Balance After Transfer";
            // 
            // lblToAccountBalanceAfterTransfer
            // 
            this.lblToAccountBalanceAfterTransfer.AutoSize = true;
            this.lblToAccountBalanceAfterTransfer.Location = new System.Drawing.Point(447, 367);
            this.lblToAccountBalanceAfterTransfer.Name = "lblToAccountBalanceAfterTransfer";
            this.lblToAccountBalanceAfterTransfer.Size = new System.Drawing.Size(172, 13);
            this.lblToAccountBalanceAfterTransfer.TabIndex = 1;
            this.lblToAccountBalanceAfterTransfer.Text = "To Account Balance After Transfer";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(697, 422);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRecord
            // 
            this.btnRecord.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecord.Location = new System.Drawing.Point(697, 393);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(75, 23);
            this.btnRecord.TabIndex = 4;
            this.btnRecord.Text = "Record";
            this.btnRecord.UseVisualStyleBackColor = false;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // FrmTransferMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.lblBalanceAfterTransfer);
            this.Controls.Add(this.lblCurrentBalance);
            this.Controls.Add(this.lblToAccountName);
            this.Controls.Add(this.lblToAccountBalanceAfterTransfer);
            this.Controls.Add(this.lblFromAccountBalanceAfterTransfer);
            this.Controls.Add(this.lblToAccountCurrentBalance);
            this.Controls.Add(this.lblFromAccountCurrentBalance);
            this.Controls.Add(this.lblFromAccountName);
            this.Controls.Add(this.gpTransferMoney);
            this.Name = "FrmTransferMoney";
            this.Text = "Transfer Money";
            this.Load += new System.EventHandler(this.frmTransferMoney_Load);
            this.gpTransferMoney.ResumeLayout(false);
            this.gpTransferMoney.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CZRoundedGroupBox gpTransferMoney;
        private System.Windows.Forms.Label lblTransferNo;
        private System.Windows.Forms.TextBox txtTransferNo;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblTransferDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblTransferMoneyTo;
        private System.Windows.Forms.Label lblTransferMoneyFrom;
        private System.Windows.Forms.Label lblMemo;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtJournalMemo;
        private System.Windows.Forms.ComboBox cboFromAccount;
        private System.Windows.Forms.ComboBox cboToAccount;
        private System.Windows.Forms.Label lblFromAccountName;
        private System.Windows.Forms.Label lblToAccountName;
        private System.Windows.Forms.Label lblCurrentBalance;
        private System.Windows.Forms.Label lblBalanceAfterTransfer;
        private System.Windows.Forms.Label lblFromAccountCurrentBalance;
        private System.Windows.Forms.Label lblToAccountCurrentBalance;
        private System.Windows.Forms.Label lblFromAccountBalanceAfterTransfer;
        private System.Windows.Forms.Label lblToAccountBalanceAfterTransfer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRecord;
    }
}