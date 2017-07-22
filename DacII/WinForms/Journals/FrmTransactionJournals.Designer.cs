namespace DacII.WinForms.Journals
{
    partial class FrmTransactionJournals
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
            this.gp = new System.Windows.Forms.CZRoundedGroupBox();
            this.btnGenReload = new System.Windows.Forms.Button();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.tc = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.tgvGeneral = new AdvancedDataGridView.TreeGridView();
            this.genDateOrID = new AdvancedDataGridView.TreeGridColumn();
            this.genAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genJob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpDisbursements = new System.Windows.Forms.TabPage();
            this.tgvDisbursements = new AdvancedDataGridView.TreeGridView();
            this.disbDateOrID = new AdvancedDataGridView.TreeGridColumn();
            this.disbAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disbDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disbCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disbJob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpReceipts = new System.Windows.Forms.TabPage();
            this.tgvReceipts = new AdvancedDataGridView.TreeGridView();
            this.recDateOrID = new AdvancedDataGridView.TreeGridColumn();
            this.recAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recJob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpPurchases = new System.Windows.Forms.TabPage();
            this.tgvPurchases = new AdvancedDataGridView.TreeGridView();
            this.purDateOrID = new AdvancedDataGridView.TreeGridColumn();
            this.purAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purJob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpSales = new System.Windows.Forms.TabPage();
            this.tgvSales = new AdvancedDataGridView.TreeGridView();
            this.salDateOrID = new AdvancedDataGridView.TreeGridColumn();
            this.salAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salJob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpInventory = new System.Windows.Forms.TabPage();
            this.tgvInventory = new AdvancedDataGridView.TreeGridView();
            this.invDateOrID = new AdvancedDataGridView.TreeGridColumn();
            this.invAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invJob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpAll = new System.Windows.Forms.TabPage();
            this.tgvAll = new AdvancedDataGridView.TreeGridView();
            this.allDateOrID = new AdvancedDataGridView.TreeGridColumn();
            this.allAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allJob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gp.SuspendLayout();
            this.tc.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgvGeneral)).BeginInit();
            this.tpDisbursements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgvDisbursements)).BeginInit();
            this.tpReceipts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgvReceipts)).BeginInit();
            this.tpPurchases.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgvPurchases)).BeginInit();
            this.tpSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgvSales)).BeginInit();
            this.tpInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgvInventory)).BeginInit();
            this.tpAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgvAll)).BeginInit();
            this.SuspendLayout();
            // 
            // gp
            // 
            this.gp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gp.BackgroundColor = System.Drawing.Color.White;
            this.gp.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gp.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gp.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gp.BorderWidth = 1F;
            this.gp.Caption = "";
            this.gp.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gp.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gp.CaptionHeight = 25;
            this.gp.CaptionVisible = true;
            this.gp.Controls.Add(this.btnGenReload);
            this.gp.Controls.Add(this.lblEndDate);
            this.gp.Controls.Add(this.lblStartDate);
            this.gp.Controls.Add(this.dtpEndDate);
            this.gp.Controls.Add(this.dtpStartDate);
            this.gp.CornerRadius = 5;
            this.gp.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gp.DropShadowThickness = 3;
            this.gp.DropShadowVisible = false;
            this.gp.Location = new System.Drawing.Point(6, 7);
            this.gp.Name = "gp";
            this.gp.Size = new System.Drawing.Size(767, 71);
            this.gp.TabIndex = 0;
            this.gp.TabStop = false;
            // 
            // btnGenReload
            // 
            this.btnGenReload.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGenReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenReload.Location = new System.Drawing.Point(576, 38);
            this.btnGenReload.Name = "btnGenReload";
            this.btnGenReload.Size = new System.Drawing.Size(75, 23);
            this.btnGenReload.TabIndex = 8;
            this.btnGenReload.Text = "Reload";
            this.btnGenReload.UseVisualStyleBackColor = false;
            this.btnGenReload.Click += new System.EventHandler(this.btnGenReload_Click);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.BackColor = System.Drawing.Color.Transparent;
            this.lblEndDate.Location = new System.Drawing.Point(124, 8);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(20, 13);
            this.lblEndDate.TabIndex = 7;
            this.lblEndDate.Text = "To";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.BackColor = System.Drawing.Color.Transparent;
            this.lblStartDate.Location = new System.Drawing.Point(15, 8);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(65, 13);
            this.lblStartDate.TabIndex = 6;
            this.lblStartDate.Text = "Dated From:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(127, 31);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(90, 20);
            this.dtpEndDate.TabIndex = 4;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(14, 31);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(93, 20);
            this.dtpStartDate.TabIndex = 5;
            // 
            // tc
            // 
            this.tc.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tc.Controls.Add(this.tpGeneral);
            this.tc.Controls.Add(this.tpDisbursements);
            this.tc.Controls.Add(this.tpReceipts);
            this.tc.Controls.Add(this.tpPurchases);
            this.tc.Controls.Add(this.tpSales);
            this.tc.Controls.Add(this.tpInventory);
            this.tc.Controls.Add(this.tpAll);
            this.tc.HotTrack = true;
            this.tc.Location = new System.Drawing.Point(2, 78);
            this.tc.Name = "tc";
            this.tc.SelectedIndex = 0;
            this.tc.Size = new System.Drawing.Size(775, 468);
            this.tc.TabIndex = 1;
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.tgvGeneral);
            this.tpGeneral.Location = new System.Drawing.Point(4, 4);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(767, 441);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "General";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // tgvGeneral
            // 
            this.tgvGeneral.AllowUserToAddRows = false;
            this.tgvGeneral.AllowUserToDeleteRows = false;
            this.tgvGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tgvGeneral.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.genDateOrID,
            this.genAccountName,
            this.genDebit,
            this.genCredit,
            this.genJob});
            this.tgvGeneral.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tgvGeneral.ImageList = null;
            this.tgvGeneral.Location = new System.Drawing.Point(3, 6);
            this.tgvGeneral.Name = "tgvGeneral";
            this.tgvGeneral.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tgvGeneral.ShowLines = false;
            this.tgvGeneral.Size = new System.Drawing.Size(755, 420);
            this.tgvGeneral.TabIndex = 0;
            // 
            // genDateOrID
            // 
            this.genDateOrID.DefaultNodeImage = null;
            this.genDateOrID.HeaderText = "Src      Date       #ID";
            this.genDateOrID.Name = "genDateOrID";
            this.genDateOrID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.genDateOrID.Width = 180;
            // 
            // genAccountName
            // 
            this.genAccountName.HeaderText = "Account";
            this.genAccountName.Name = "genAccountName";
            this.genAccountName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.genAccountName.Width = 250;
            // 
            // genDebit
            // 
            this.genDebit.HeaderText = "Debit";
            this.genDebit.Name = "genDebit";
            this.genDebit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // genCredit
            // 
            this.genCredit.HeaderText = "Credit";
            this.genCredit.Name = "genCredit";
            this.genCredit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // genJob
            // 
            this.genJob.HeaderText = "Job";
            this.genJob.Name = "genJob";
            this.genJob.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.genJob.Width = 60;
            // 
            // tpDisbursements
            // 
            this.tpDisbursements.Controls.Add(this.tgvDisbursements);
            this.tpDisbursements.Location = new System.Drawing.Point(4, 4);
            this.tpDisbursements.Name = "tpDisbursements";
            this.tpDisbursements.Padding = new System.Windows.Forms.Padding(3);
            this.tpDisbursements.Size = new System.Drawing.Size(767, 441);
            this.tpDisbursements.TabIndex = 1;
            this.tpDisbursements.Text = "Disbursements";
            this.tpDisbursements.UseVisualStyleBackColor = true;
            // 
            // tgvDisbursements
            // 
            this.tgvDisbursements.AllowUserToAddRows = false;
            this.tgvDisbursements.AllowUserToDeleteRows = false;
            this.tgvDisbursements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tgvDisbursements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.disbDateOrID,
            this.disbAccountName,
            this.disbDebit,
            this.disbCredit,
            this.disbJob});
            this.tgvDisbursements.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tgvDisbursements.ImageList = null;
            this.tgvDisbursements.Location = new System.Drawing.Point(6, 6);
            this.tgvDisbursements.Name = "tgvDisbursements";
            this.tgvDisbursements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tgvDisbursements.ShowLines = false;
            this.tgvDisbursements.Size = new System.Drawing.Size(755, 429);
            this.tgvDisbursements.TabIndex = 1;
            // 
            // disbDateOrID
            // 
            this.disbDateOrID.DefaultNodeImage = null;
            this.disbDateOrID.HeaderText = "Src    Date   # ID";
            this.disbDateOrID.Name = "disbDateOrID";
            this.disbDateOrID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.disbDateOrID.Width = 180;
            // 
            // disbAccountName
            // 
            this.disbAccountName.HeaderText = "Account";
            this.disbAccountName.Name = "disbAccountName";
            this.disbAccountName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.disbAccountName.Width = 250;
            // 
            // disbDebit
            // 
            this.disbDebit.HeaderText = "Debit";
            this.disbDebit.Name = "disbDebit";
            this.disbDebit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // disbCredit
            // 
            this.disbCredit.HeaderText = "Credit";
            this.disbCredit.Name = "disbCredit";
            this.disbCredit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // disbJob
            // 
            this.disbJob.HeaderText = "Job";
            this.disbJob.Name = "disbJob";
            this.disbJob.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.disbJob.Width = 60;
            // 
            // tpReceipts
            // 
            this.tpReceipts.Controls.Add(this.tgvReceipts);
            this.tpReceipts.Location = new System.Drawing.Point(4, 4);
            this.tpReceipts.Name = "tpReceipts";
            this.tpReceipts.Size = new System.Drawing.Size(767, 441);
            this.tpReceipts.TabIndex = 2;
            this.tpReceipts.Text = "Receipts";
            this.tpReceipts.UseVisualStyleBackColor = true;
            // 
            // tgvReceipts
            // 
            this.tgvReceipts.AllowUserToAddRows = false;
            this.tgvReceipts.AllowUserToDeleteRows = false;
            this.tgvReceipts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tgvReceipts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.recDateOrID,
            this.recAccountName,
            this.recDebit,
            this.recCredit,
            this.recJob});
            this.tgvReceipts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tgvReceipts.ImageList = null;
            this.tgvReceipts.Location = new System.Drawing.Point(6, 6);
            this.tgvReceipts.Name = "tgvReceipts";
            this.tgvReceipts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tgvReceipts.ShowLines = false;
            this.tgvReceipts.Size = new System.Drawing.Size(748, 420);
            this.tgvReceipts.TabIndex = 2;
            // 
            // recDateOrID
            // 
            this.recDateOrID.DefaultNodeImage = null;
            this.recDateOrID.HeaderText = "Src    Date    #ID";
            this.recDateOrID.Name = "recDateOrID";
            this.recDateOrID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.recDateOrID.Width = 180;
            // 
            // recAccountName
            // 
            this.recAccountName.HeaderText = "Account";
            this.recAccountName.Name = "recAccountName";
            this.recAccountName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.recAccountName.Width = 250;
            // 
            // recDebit
            // 
            this.recDebit.HeaderText = "Debit";
            this.recDebit.Name = "recDebit";
            this.recDebit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // recCredit
            // 
            this.recCredit.HeaderText = "Credit";
            this.recCredit.Name = "recCredit";
            this.recCredit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // recJob
            // 
            this.recJob.HeaderText = "Job";
            this.recJob.Name = "recJob";
            this.recJob.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.recJob.Width = 60;
            // 
            // tpPurchases
            // 
            this.tpPurchases.Controls.Add(this.tgvPurchases);
            this.tpPurchases.Location = new System.Drawing.Point(4, 4);
            this.tpPurchases.Name = "tpPurchases";
            this.tpPurchases.Size = new System.Drawing.Size(767, 441);
            this.tpPurchases.TabIndex = 3;
            this.tpPurchases.Text = "Purchases";
            this.tpPurchases.UseVisualStyleBackColor = true;
            // 
            // tgvPurchases
            // 
            this.tgvPurchases.AllowUserToAddRows = false;
            this.tgvPurchases.AllowUserToDeleteRows = false;
            this.tgvPurchases.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tgvPurchases.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.purDateOrID,
            this.purAccountName,
            this.purDebit,
            this.purCredit,
            this.purJob});
            this.tgvPurchases.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tgvPurchases.ImageList = null;
            this.tgvPurchases.Location = new System.Drawing.Point(6, 6);
            this.tgvPurchases.Name = "tgvPurchases";
            this.tgvPurchases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tgvPurchases.ShowLines = false;
            this.tgvPurchases.Size = new System.Drawing.Size(744, 432);
            this.tgvPurchases.TabIndex = 2;
            // 
            // purDateOrID
            // 
            this.purDateOrID.DefaultNodeImage = null;
            this.purDateOrID.HeaderText = "Src    Date    #ID";
            this.purDateOrID.Name = "purDateOrID";
            this.purDateOrID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.purDateOrID.Width = 180;
            // 
            // purAccountName
            // 
            this.purAccountName.HeaderText = "Account";
            this.purAccountName.Name = "purAccountName";
            this.purAccountName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.purAccountName.Width = 250;
            // 
            // purDebit
            // 
            this.purDebit.HeaderText = "Debit";
            this.purDebit.Name = "purDebit";
            this.purDebit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // purCredit
            // 
            this.purCredit.HeaderText = "Credit";
            this.purCredit.Name = "purCredit";
            this.purCredit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // purJob
            // 
            this.purJob.HeaderText = "Job";
            this.purJob.Name = "purJob";
            this.purJob.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.purJob.Width = 60;
            // 
            // tpSales
            // 
            this.tpSales.Controls.Add(this.tgvSales);
            this.tpSales.Location = new System.Drawing.Point(4, 4);
            this.tpSales.Name = "tpSales";
            this.tpSales.Size = new System.Drawing.Size(767, 441);
            this.tpSales.TabIndex = 4;
            this.tpSales.Text = "Sales";
            this.tpSales.UseVisualStyleBackColor = true;
            // 
            // tgvSales
            // 
            this.tgvSales.AllowUserToAddRows = false;
            this.tgvSales.AllowUserToDeleteRows = false;
            this.tgvSales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tgvSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.salDateOrID,
            this.salAccountName,
            this.salDebit,
            this.salCredit,
            this.salJob});
            this.tgvSales.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tgvSales.ImageList = null;
            this.tgvSales.Location = new System.Drawing.Point(6, 6);
            this.tgvSales.Name = "tgvSales";
            this.tgvSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tgvSales.ShowLines = false;
            this.tgvSales.Size = new System.Drawing.Size(749, 420);
            this.tgvSales.TabIndex = 2;
            // 
            // salDateOrID
            // 
            this.salDateOrID.DefaultNodeImage = null;
            this.salDateOrID.HeaderText = "Src    Date    #ID";
            this.salDateOrID.Name = "salDateOrID";
            this.salDateOrID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.salDateOrID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.salDateOrID.Width = 180;
            // 
            // salAccountName
            // 
            this.salAccountName.HeaderText = "Account";
            this.salAccountName.Name = "salAccountName";
            this.salAccountName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.salAccountName.Width = 250;
            // 
            // salDebit
            // 
            this.salDebit.HeaderText = "Debit";
            this.salDebit.Name = "salDebit";
            this.salDebit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // salCredit
            // 
            this.salCredit.HeaderText = "Credit";
            this.salCredit.Name = "salCredit";
            this.salCredit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // salJob
            // 
            this.salJob.HeaderText = "Job";
            this.salJob.Name = "salJob";
            this.salJob.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.salJob.Width = 60;
            // 
            // tpInventory
            // 
            this.tpInventory.Controls.Add(this.tgvInventory);
            this.tpInventory.Location = new System.Drawing.Point(4, 4);
            this.tpInventory.Name = "tpInventory";
            this.tpInventory.Size = new System.Drawing.Size(767, 441);
            this.tpInventory.TabIndex = 5;
            this.tpInventory.Text = "Inventory";
            this.tpInventory.UseVisualStyleBackColor = true;
            // 
            // tgvInventory
            // 
            this.tgvInventory.AllowUserToAddRows = false;
            this.tgvInventory.AllowUserToDeleteRows = false;
            this.tgvInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tgvInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.invDateOrID,
            this.invAccountName,
            this.invDebit,
            this.invCredit,
            this.invJob});
            this.tgvInventory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tgvInventory.ImageList = null;
            this.tgvInventory.Location = new System.Drawing.Point(6, 6);
            this.tgvInventory.Name = "tgvInventory";
            this.tgvInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tgvInventory.ShowLines = false;
            this.tgvInventory.Size = new System.Drawing.Size(750, 411);
            this.tgvInventory.TabIndex = 2;
            // 
            // invDateOrID
            // 
            this.invDateOrID.DefaultNodeImage = null;
            this.invDateOrID.HeaderText = "Src    Date    #ID";
            this.invDateOrID.Name = "invDateOrID";
            this.invDateOrID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.invDateOrID.Width = 180;
            // 
            // invAccountName
            // 
            this.invAccountName.HeaderText = "Account";
            this.invAccountName.Name = "invAccountName";
            this.invAccountName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.invAccountName.Width = 250;
            // 
            // invDebit
            // 
            this.invDebit.HeaderText = "Debit";
            this.invDebit.Name = "invDebit";
            this.invDebit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // invCredit
            // 
            this.invCredit.HeaderText = "Credit";
            this.invCredit.Name = "invCredit";
            this.invCredit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // invJob
            // 
            this.invJob.HeaderText = "Job";
            this.invJob.Name = "invJob";
            this.invJob.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.invJob.Width = 60;
            // 
            // tpAll
            // 
            this.tpAll.Controls.Add(this.tgvAll);
            this.tpAll.Location = new System.Drawing.Point(4, 4);
            this.tpAll.Name = "tpAll";
            this.tpAll.Size = new System.Drawing.Size(767, 441);
            this.tpAll.TabIndex = 6;
            this.tpAll.Text = "All";
            this.tpAll.UseVisualStyleBackColor = true;
            // 
            // tgvAll
            // 
            this.tgvAll.AllowUserToAddRows = false;
            this.tgvAll.AllowUserToDeleteRows = false;
            this.tgvAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tgvAll.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.allDateOrID,
            this.allAccountName,
            this.allDebit,
            this.allCredit,
            this.allJob});
            this.tgvAll.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tgvAll.ImageList = null;
            this.tgvAll.Location = new System.Drawing.Point(6, 6);
            this.tgvAll.Name = "tgvAll";
            this.tgvAll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tgvAll.ShowLines = false;
            this.tgvAll.Size = new System.Drawing.Size(752, 419);
            this.tgvAll.TabIndex = 2;
            // 
            // allDateOrID
            // 
            this.allDateOrID.DefaultNodeImage = null;
            this.allDateOrID.HeaderText = "Src    Date    #ID";
            this.allDateOrID.Name = "allDateOrID";
            this.allDateOrID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.allDateOrID.Width = 180;
            // 
            // allAccountName
            // 
            this.allAccountName.HeaderText = "Account";
            this.allAccountName.Name = "allAccountName";
            this.allAccountName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.allAccountName.Width = 250;
            // 
            // allDebit
            // 
            this.allDebit.HeaderText = "Debit";
            this.allDebit.Name = "allDebit";
            this.allDebit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // allCredit
            // 
            this.allCredit.HeaderText = "Credit";
            this.allCredit.Name = "allCredit";
            this.allCredit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // allJob
            // 
            this.allJob.HeaderText = "Job";
            this.allJob.Name = "allJob";
            this.allJob.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.allJob.Width = 60;
            // 
            // FrmTransactionJournals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 548);
            this.Controls.Add(this.gp);
            this.Controls.Add(this.tc);
            this.Name = "FrmTransactionJournals";
            this.Text = "Transaction Journal";
            this.gp.ResumeLayout(false);
            this.gp.PerformLayout();
            this.tc.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tgvGeneral)).EndInit();
            this.tpDisbursements.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tgvDisbursements)).EndInit();
            this.tpReceipts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tgvReceipts)).EndInit();
            this.tpPurchases.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tgvPurchases)).EndInit();
            this.tpSales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tgvSales)).EndInit();
            this.tpInventory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tgvInventory)).EndInit();
            this.tpAll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tgvAll)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CZRoundedGroupBox gp;
        private System.Windows.Forms.TabControl tc;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.TabPage tpDisbursements;
        private AdvancedDataGridView.TreeGridView tgvGeneral;
        private AdvancedDataGridView.TreeGridColumn genDateOrID;
        private System.Windows.Forms.DataGridViewTextBoxColumn genAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn genDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn genCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn genJob;
        private System.Windows.Forms.Button btnGenReload;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private AdvancedDataGridView.TreeGridView tgvDisbursements;
        private AdvancedDataGridView.TreeGridColumn disbDateOrID;
        private System.Windows.Forms.DataGridViewTextBoxColumn disbAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn disbDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn disbCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn disbJob;
        private System.Windows.Forms.TabPage tpReceipts;
        private System.Windows.Forms.TabPage tpPurchases;
        private System.Windows.Forms.TabPage tpSales;
        private System.Windows.Forms.TabPage tpInventory;
        private AdvancedDataGridView.TreeGridView tgvReceipts;
        private AdvancedDataGridView.TreeGridView tgvPurchases;
        private AdvancedDataGridView.TreeGridView tgvSales;
        private AdvancedDataGridView.TreeGridView tgvInventory;
        private AdvancedDataGridView.TreeGridColumn invDateOrID;
        private System.Windows.Forms.DataGridViewTextBoxColumn invAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn invDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn invCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn invJob;
        private System.Windows.Forms.TabPage tpAll;
        private AdvancedDataGridView.TreeGridView tgvAll;
        private AdvancedDataGridView.TreeGridColumn allDateOrID;
        private System.Windows.Forms.DataGridViewTextBoxColumn allAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn allDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn allCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn allJob;
        private AdvancedDataGridView.TreeGridColumn recDateOrID;
        private System.Windows.Forms.DataGridViewTextBoxColumn recAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn recDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn recCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn recJob;
        private AdvancedDataGridView.TreeGridColumn purDateOrID;
        private System.Windows.Forms.DataGridViewTextBoxColumn purAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn purDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn purCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn purJob;
        private AdvancedDataGridView.TreeGridColumn salDateOrID;
        private System.Windows.Forms.DataGridViewTextBoxColumn salAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn salDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn salCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn salJob;
    }
}