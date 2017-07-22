namespace DacII.WinForms.Analysis
{
    partial class FrmBalanceSheet
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
            this.tgvBalanceSheet = new AdvancedDataGridView.TreeGridView();
            this.colAccountName = new AdvancedDataGridView.TreeGridColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbFilter = new System.Windows.Forms.CZRoundedGroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.chkAllCustomers = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.czRoundedGroupBox1 = new System.Windows.Forms.CZRoundedGroupBox();
            this.btnClose2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tgvBalanceSheet)).BeginInit();
            this.gbFilter.SuspendLayout();
            this.czRoundedGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tgvBalanceSheet
            // 
            this.tgvBalanceSheet.AllowUserToAddRows = false;
            this.tgvBalanceSheet.AllowUserToDeleteRows = false;
            this.tgvBalanceSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tgvBalanceSheet.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tgvBalanceSheet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tgvBalanceSheet.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.tgvBalanceSheet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAccountName,
            this.colAmount,
            this.colPercent});
            this.tgvBalanceSheet.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tgvBalanceSheet.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tgvBalanceSheet.ImageList = null;
            this.tgvBalanceSheet.Location = new System.Drawing.Point(7, 31);
            this.tgvBalanceSheet.Name = "tgvBalanceSheet";
            this.tgvBalanceSheet.ReadOnly = true;
            this.tgvBalanceSheet.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.tgvBalanceSheet.RowHeadersVisible = false;
            this.tgvBalanceSheet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tgvBalanceSheet.ShowCellErrors = false;
            this.tgvBalanceSheet.ShowCellToolTips = false;
            this.tgvBalanceSheet.ShowEditingIcon = false;
            this.tgvBalanceSheet.ShowLines = false;
            this.tgvBalanceSheet.ShowRowErrors = false;
            this.tgvBalanceSheet.Size = new System.Drawing.Size(550, 407);
            this.tgvBalanceSheet.TabIndex = 1;
            // 
            // colAccountName
            // 
            this.colAccountName.DefaultNodeImage = null;
            this.colAccountName.Frozen = true;
            this.colAccountName.HeaderText = "Account";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.ReadOnly = true;
            this.colAccountName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAccountName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAccountName.Width = 300;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAmount.Width = 150;
            // 
            // colPercent
            // 
            this.colPercent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPercent.HeaderText = "Percent";
            this.colPercent.Name = "colPercent";
            this.colPercent.ReadOnly = true;
            this.colPercent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gbFilter
            // 
            this.gbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFilter.BackgroundColor = System.Drawing.Color.White;
            this.gbFilter.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbFilter.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbFilter.BorderWidth = 1F;
            this.gbFilter.Caption = "";
            this.gbFilter.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbFilter.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbFilter.CaptionHeight = 25;
            this.gbFilter.CaptionVisible = true;
            this.gbFilter.Controls.Add(this.btnPrint);
            this.gbFilter.Controls.Add(this.chkAllCustomers);
            this.gbFilter.Controls.Add(this.btnClose);
            this.gbFilter.CornerRadius = 5;
            this.gbFilter.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbFilter.DropShadowThickness = 3;
            this.gbFilter.DropShadowVisible = false;
            this.gbFilter.Location = new System.Drawing.Point(580, 7);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(89, 121);
            this.gbFilter.TabIndex = 10;
            this.gbFilter.TabStop = false;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrint.Location = new System.Drawing.Point(11, 34);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(70, 32);
            this.btnPrint.TabIndex = 92;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // chkAllCustomers
            // 
            this.chkAllCustomers.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAllCustomers.AutoSize = true;
            this.chkAllCustomers.BackColor = System.Drawing.Color.Transparent;
            this.chkAllCustomers.FlatAppearance.BorderSize = 0;
            this.chkAllCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAllCustomers.ImageIndex = 0;
            this.chkAllCustomers.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkAllCustomers.Location = new System.Drawing.Point(308, 35);
            this.chkAllCustomers.Name = "chkAllCustomers";
            this.chkAllCustomers.Size = new System.Drawing.Size(6, 6);
            this.chkAllCustomers.TabIndex = 14;
            this.chkAllCustomers.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(11, 72);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 32);
            this.btnClose.TabIndex = 91;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // czRoundedGroupBox1
            // 
            this.czRoundedGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.czRoundedGroupBox1.BackgroundColor = System.Drawing.Color.White;
            this.czRoundedGroupBox1.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.czRoundedGroupBox1.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.czRoundedGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.czRoundedGroupBox1.BorderWidth = 1F;
            this.czRoundedGroupBox1.Caption = "Accounts --> Balance Sheet";
            this.czRoundedGroupBox1.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.czRoundedGroupBox1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.czRoundedGroupBox1.CaptionHeight = 25;
            this.czRoundedGroupBox1.CaptionVisible = true;
            this.czRoundedGroupBox1.Controls.Add(this.btnClose2);
            this.czRoundedGroupBox1.Controls.Add(this.tgvBalanceSheet);
            this.czRoundedGroupBox1.CornerRadius = 5;
            this.czRoundedGroupBox1.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.czRoundedGroupBox1.DropShadowThickness = 3;
            this.czRoundedGroupBox1.DropShadowVisible = true;
            this.czRoundedGroupBox1.Location = new System.Drawing.Point(6, 7);
            this.czRoundedGroupBox1.Name = "czRoundedGroupBox1";
            this.czRoundedGroupBox1.Size = new System.Drawing.Size(571, 459);
            this.czRoundedGroupBox1.TabIndex = 11;
            // 
            // btnClose2
            // 
            this.btnClose2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose2.BackgroundImage = global::DacII.Properties.Resources.cancel_16x16;
            this.btnClose2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose2.FlatAppearance.BorderSize = 0;
            this.btnClose2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose2.Location = new System.Drawing.Point(541, 4);
            this.btnClose2.Name = "btnClose2";
            this.btnClose2.Size = new System.Drawing.Size(16, 16);
            this.btnClose2.TabIndex = 94;
            this.btnClose2.UseVisualStyleBackColor = false;
            this.btnClose2.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmBalanceSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(673, 473);
            this.Controls.Add(this.czRoundedGroupBox1);
            this.Controls.Add(this.gbFilter);
            this.Name = "FrmBalanceSheet";
            this.Text = "Balance Sheet";
            ((System.ComponentModel.ISupportInitialize)(this.tgvBalanceSheet)).EndInit();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.czRoundedGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AdvancedDataGridView.TreeGridView tgvBalanceSheet;
        private AdvancedDataGridView.TreeGridColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPercent;
        private System.Windows.Forms.CZRoundedGroupBox gbFilter;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.CheckBox chkAllCustomers;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CZRoundedGroupBox czRoundedGroupBox1;
        private System.Windows.Forms.Button btnClose2;

    }
}