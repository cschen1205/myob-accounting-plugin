namespace DacII.WinForms.Journals
{
    partial class FrmRecordJournalEntry
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
            this.gpGeneralJournalInfo = new System.Windows.Forms.CZRoundedGroupBox();
            this.chkIsTaxInclusive = new System.Windows.Forms.CheckBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.lblMemo = new System.Windows.Forms.Label();
            this.txtGeneralJournalNo = new System.Windows.Forms.TextBox();
            this.lblGeneralJournalNo = new System.Windows.Forms.Label();
            this.gpJournalLines = new System.Windows.Forms.CZRoundedGroupBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvJournalLines = new System.Windows.Forms.DataGridView();
            this.lblTotalDebit = new System.Windows.Forms.Label();
            this.txtTotalDebit = new System.Windows.Forms.TextBox();
            this.txtTotalCredit = new System.Windows.Forms.TextBox();
            this.lblTotalCredit = new System.Windows.Forms.Label();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.txtOutOfBalance = new System.Windows.Forms.TextBox();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblOutOfBalance = new System.Windows.Forms.Label();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.cboCurrency = new System.Windows.Forms.ComboBox();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gpGeneralJournalInfo.SuspendLayout();
            this.gpJournalLines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJournalLines)).BeginInit();
            this.SuspendLayout();
            // 
            // gpGeneralJournalInfo
            // 
            this.gpGeneralJournalInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpGeneralJournalInfo.BackgroundColor = System.Drawing.Color.White;
            this.gpGeneralJournalInfo.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gpGeneralJournalInfo.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gpGeneralJournalInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gpGeneralJournalInfo.BorderWidth = 1F;
            this.gpGeneralJournalInfo.Caption = "";
            this.gpGeneralJournalInfo.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gpGeneralJournalInfo.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gpGeneralJournalInfo.CaptionHeight = 25;
            this.gpGeneralJournalInfo.CaptionVisible = true;
            this.gpGeneralJournalInfo.Controls.Add(this.chkIsTaxInclusive);
            this.gpGeneralJournalInfo.Controls.Add(this.dtpDate);
            this.gpGeneralJournalInfo.Controls.Add(this.lblDate);
            this.gpGeneralJournalInfo.Controls.Add(this.txtMemo);
            this.gpGeneralJournalInfo.Controls.Add(this.lblMemo);
            this.gpGeneralJournalInfo.Controls.Add(this.txtGeneralJournalNo);
            this.gpGeneralJournalInfo.Controls.Add(this.lblGeneralJournalNo);
            this.gpGeneralJournalInfo.CornerRadius = 5;
            this.gpGeneralJournalInfo.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gpGeneralJournalInfo.DropShadowThickness = 3;
            this.gpGeneralJournalInfo.DropShadowVisible = true;
            this.gpGeneralJournalInfo.Location = new System.Drawing.Point(12, 12);
            this.gpGeneralJournalInfo.Name = "gpGeneralJournalInfo";
            this.gpGeneralJournalInfo.Size = new System.Drawing.Size(562, 104);
            this.gpGeneralJournalInfo.TabIndex = 0;
            this.gpGeneralJournalInfo.TabStop = false;
            // 
            // chkIsTaxInclusive
            // 
            this.chkIsTaxInclusive.AutoSize = true;
            this.chkIsTaxInclusive.BackColor = System.Drawing.Color.Transparent;
            this.chkIsTaxInclusive.Location = new System.Drawing.Point(450, 78);
            this.chkIsTaxInclusive.Name = "chkIsTaxInclusive";
            this.chkIsTaxInclusive.Size = new System.Drawing.Size(100, 17);
            this.chkIsTaxInclusive.TabIndex = 4;
            this.chkIsTaxInclusive.Text = "Is Tax Inclusive";
            this.chkIsTaxInclusive.UseVisualStyleBackColor = false;
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(113, 52);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(100, 20);
            this.dtpDate.TabIndex = 3;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Location = new System.Drawing.Point(13, 56);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date:";
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(113, 75);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(317, 20);
            this.txtMemo.TabIndex = 1;
            // 
            // lblMemo
            // 
            this.lblMemo.AutoSize = true;
            this.lblMemo.BackColor = System.Drawing.Color.Transparent;
            this.lblMemo.Location = new System.Drawing.Point(13, 78);
            this.lblMemo.Name = "lblMemo";
            this.lblMemo.Size = new System.Drawing.Size(39, 13);
            this.lblMemo.TabIndex = 0;
            this.lblMemo.Text = "Memo:";
            // 
            // txtGeneralJournalNo
            // 
            this.txtGeneralJournalNo.Location = new System.Drawing.Point(113, 28);
            this.txtGeneralJournalNo.Name = "txtGeneralJournalNo";
            this.txtGeneralJournalNo.Size = new System.Drawing.Size(100, 20);
            this.txtGeneralJournalNo.TabIndex = 1;
            // 
            // lblGeneralJournalNo
            // 
            this.lblGeneralJournalNo.AutoSize = true;
            this.lblGeneralJournalNo.BackColor = System.Drawing.Color.Transparent;
            this.lblGeneralJournalNo.Location = new System.Drawing.Point(13, 31);
            this.lblGeneralJournalNo.Name = "lblGeneralJournalNo";
            this.lblGeneralJournalNo.Size = new System.Drawing.Size(94, 13);
            this.lblGeneralJournalNo.TabIndex = 0;
            this.lblGeneralJournalNo.Text = "General Journal #:";
            // 
            // gpJournalLines
            // 
            this.gpJournalLines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpJournalLines.BackgroundColor = System.Drawing.Color.White;
            this.gpJournalLines.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gpJournalLines.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gpJournalLines.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gpJournalLines.BorderWidth = 1F;
            this.gpJournalLines.Caption = "";
            this.gpJournalLines.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gpJournalLines.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gpJournalLines.CaptionHeight = 25;
            this.gpJournalLines.CaptionVisible = true;
            this.gpJournalLines.Controls.Add(this.btnDel);
            this.gpJournalLines.Controls.Add(this.btnEdit);
            this.gpJournalLines.Controls.Add(this.btnAdd);
            this.gpJournalLines.Controls.Add(this.dgvJournalLines);
            this.gpJournalLines.CornerRadius = 5;
            this.gpJournalLines.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gpJournalLines.DropShadowThickness = 3;
            this.gpJournalLines.DropShadowVisible = true;
            this.gpJournalLines.Location = new System.Drawing.Point(12, 122);
            this.gpJournalLines.Name = "gpJournalLines";
            this.gpJournalLines.Size = new System.Drawing.Size(562, 203);
            this.gpJournalLines.TabIndex = 1;
            this.gpJournalLines.TabStop = false;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Location = new System.Drawing.Point(491, 87);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(54, 23);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "Del";
            this.btnDel.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(491, 58);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(54, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(491, 29);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(54, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // dgvJournalLines
            // 
            this.dgvJournalLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvJournalLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJournalLines.Location = new System.Drawing.Point(11, 29);
            this.dgvJournalLines.Name = "dgvJournalLines";
            this.dgvJournalLines.Size = new System.Drawing.Size(470, 161);
            this.dgvJournalLines.TabIndex = 0;
            // 
            // lblTotalDebit
            // 
            this.lblTotalDebit.AutoSize = true;
            this.lblTotalDebit.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalDebit.Location = new System.Drawing.Point(13, 340);
            this.lblTotalDebit.Name = "lblTotalDebit";
            this.lblTotalDebit.Size = new System.Drawing.Size(62, 13);
            this.lblTotalDebit.TabIndex = 0;
            this.lblTotalDebit.Text = "Total Debit:";
            // 
            // txtTotalDebit
            // 
            this.txtTotalDebit.Enabled = false;
            this.txtTotalDebit.Location = new System.Drawing.Point(113, 337);
            this.txtTotalDebit.Name = "txtTotalDebit";
            this.txtTotalDebit.Size = new System.Drawing.Size(100, 20);
            this.txtTotalDebit.TabIndex = 1;
            // 
            // txtTotalCredit
            // 
            this.txtTotalCredit.Enabled = false;
            this.txtTotalCredit.Location = new System.Drawing.Point(113, 363);
            this.txtTotalCredit.Name = "txtTotalCredit";
            this.txtTotalCredit.Size = new System.Drawing.Size(100, 20);
            this.txtTotalCredit.TabIndex = 1;
            // 
            // lblTotalCredit
            // 
            this.lblTotalCredit.AutoSize = true;
            this.lblTotalCredit.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalCredit.Location = new System.Drawing.Point(13, 366);
            this.lblTotalCredit.Name = "lblTotalCredit";
            this.lblTotalCredit.Size = new System.Drawing.Size(64, 13);
            this.lblTotalCredit.TabIndex = 0;
            this.lblTotalCredit.Text = "Total Credit:";
            // 
            // txtTax
            // 
            this.txtTax.Enabled = false;
            this.txtTax.Location = new System.Drawing.Point(113, 390);
            this.txtTax.Name = "txtTax";
            this.txtTax.Size = new System.Drawing.Size(100, 20);
            this.txtTax.TabIndex = 1;
            // 
            // txtOutOfBalance
            // 
            this.txtOutOfBalance.Enabled = false;
            this.txtOutOfBalance.Location = new System.Drawing.Point(113, 416);
            this.txtOutOfBalance.Name = "txtOutOfBalance";
            this.txtOutOfBalance.Size = new System.Drawing.Size(100, 20);
            this.txtOutOfBalance.TabIndex = 1;
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.BackColor = System.Drawing.Color.Transparent;
            this.lblTax.Location = new System.Drawing.Point(13, 393);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(28, 13);
            this.lblTax.TabIndex = 0;
            this.lblTax.Text = "Tax:";
            // 
            // lblOutOfBalance
            // 
            this.lblOutOfBalance.AutoSize = true;
            this.lblOutOfBalance.BackColor = System.Drawing.Color.Transparent;
            this.lblOutOfBalance.Location = new System.Drawing.Point(13, 419);
            this.lblOutOfBalance.Name = "lblOutOfBalance";
            this.lblOutOfBalance.Size = new System.Drawing.Size(81, 13);
            this.lblOutOfBalance.TabIndex = 0;
            this.lblOutOfBalance.Text = "Out of Balance:";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(427, 337);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(52, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Currency:";
            // 
            // cboCurrency
            // 
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.Location = new System.Drawing.Point(485, 334);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(89, 21);
            this.cboCurrency.TabIndex = 2;
            this.cboCurrency.SelectedIndexChanged += new System.EventHandler(this.cboCurrency_SelectedIndexChanged);
            // 
            // btnRecord
            // 
            this.btnRecord.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecord.Location = new System.Drawing.Point(499, 384);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(75, 23);
            this.btnRecord.TabIndex = 3;
            this.btnRecord.Text = "Record";
            this.btnRecord.UseVisualStyleBackColor = false;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(499, 413);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmRecordJournalEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(586, 451);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.gpJournalLines);
            this.Controls.Add(this.gpGeneralJournalInfo);
            this.Controls.Add(this.lblOutOfBalance);
            this.Controls.Add(this.lblTotalCredit);
            this.Controls.Add(this.lblTax);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.lblTotalDebit);
            this.Controls.Add(this.txtOutOfBalance);
            this.Controls.Add(this.txtTax);
            this.Controls.Add(this.txtTotalCredit);
            this.Controls.Add(this.txtTotalDebit);
            this.Name = "FrmRecordJournalEntry";
            this.Text = "Record Journal Entry";
            this.Load += new System.EventHandler(this.frmRecordJournalEntry_Load);
            this.gpGeneralJournalInfo.ResumeLayout(false);
            this.gpGeneralJournalInfo.PerformLayout();
            this.gpJournalLines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJournalLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CZRoundedGroupBox gpGeneralJournalInfo;
        private System.Windows.Forms.Label lblGeneralJournalNo;
        private System.Windows.Forms.TextBox txtGeneralJournalNo;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.Label lblMemo;
        private System.Windows.Forms.CheckBox chkIsTaxInclusive;
        private System.Windows.Forms.CZRoundedGroupBox gpJournalLines;
        private System.Windows.Forms.DataGridView dgvJournalLines;
        private System.Windows.Forms.Label lblTotalDebit;
        private System.Windows.Forms.TextBox txtTotalDebit;
        private System.Windows.Forms.TextBox txtTotalCredit;
        private System.Windows.Forms.Label lblTotalCredit;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.TextBox txtOutOfBalance;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblOutOfBalance;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.ComboBox cboCurrency;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDel;
    }
}