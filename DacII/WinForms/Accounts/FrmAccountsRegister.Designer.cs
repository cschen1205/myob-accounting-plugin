namespace DacII.WinForms.Accounts
{
    partial class FrmAccountsRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAccountsRegister));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tc = new System.Windows.Forms.TabControl();
            this.tpAllAccounts = new System.Windows.Forms.TabPage();
            this.tgvAllAccounts = new AdvancedDataGridView.TreeGridView();
            this.colAccountName = new AdvancedDataGridView.TreeGridColumn();
            this.colAccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountLinked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colAccountBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpAsset = new System.Windows.Forms.TabPage();
            this.tgvAsset = new AdvancedDataGridView.TreeGridView();
            this.assetAccountName = new AdvancedDataGridView.TreeGridColumn();
            this.assetAccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assetAccountTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assetAccountLinked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.assetAccountBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpLiability = new System.Windows.Forms.TabPage();
            this.tgvLiability = new AdvancedDataGridView.TreeGridView();
            this.liabAccountName = new AdvancedDataGridView.TreeGridColumn();
            this.liabAccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.liabAccountTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.liabAccountLinked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.liabAccountBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpEquity = new System.Windows.Forms.TabPage();
            this.tgvEquity = new AdvancedDataGridView.TreeGridView();
            this.equiAccountName = new AdvancedDataGridView.TreeGridColumn();
            this.equiAccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equiAccountTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equiAccountLinked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.equiAccountBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpIncome = new System.Windows.Forms.TabPage();
            this.tgvIncome = new AdvancedDataGridView.TreeGridView();
            this.incoAccountName = new AdvancedDataGridView.TreeGridColumn();
            this.incoAccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.incoAccountTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.incoAccountLinked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.incoAccountBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpCostOfSales = new System.Windows.Forms.TabPage();
            this.tgvCoS = new AdvancedDataGridView.TreeGridView();
            this.cosAccountName = new AdvancedDataGridView.TreeGridColumn();
            this.cosAccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cosAccountTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cosAccountLinked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cosAccountBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpExpense = new System.Windows.Forms.TabPage();
            this.tgvExpense = new AdvancedDataGridView.TreeGridView();
            this.expeAccountName = new AdvancedDataGridView.TreeGridColumn();
            this.expeAccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expeAccountTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expeAccountLinked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.expeAccountBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpOtherIncome = new System.Windows.Forms.TabPage();
            this.tgvOtherIncome = new AdvancedDataGridView.TreeGridView();
            this.oincAccountName = new AdvancedDataGridView.TreeGridColumn();
            this.oincAccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oincAccountTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oincAccountLinked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.oincAccountBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpOtherExpense = new System.Windows.Forms.TabPage();
            this.tgvOtherExpense = new AdvancedDataGridView.TreeGridView();
            this.oexpAccountName = new AdvancedDataGridView.TreeGridColumn();
            this.oexpAccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oexpAccountTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oexpAccountLinked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.oexpAccountBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imgLst = new System.Windows.Forms.ImageList(this.components);
            this.gbFilter = new System.Windows.Forms.CZRoundedGroupBox();
            this.btnClose2 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.VistaButton();
            this.btnPrint = new System.Windows.Forms.VistaButton();
            this.btnRefresh = new System.Windows.Forms.VistaButton();
            this.tc.SuspendLayout();
            this.tpAllAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgvAllAccounts)).BeginInit();
            this.tpAsset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgvAsset)).BeginInit();
            this.tpLiability.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgvLiability)).BeginInit();
            this.tpEquity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgvEquity)).BeginInit();
            this.tpIncome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgvIncome)).BeginInit();
            this.tpCostOfSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgvCoS)).BeginInit();
            this.tpExpense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgvExpense)).BeginInit();
            this.tpOtherIncome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgvOtherIncome)).BeginInit();
            this.tpOtherExpense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgvOtherExpense)).BeginInit();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc
            // 
            resources.ApplyResources(this.tc, "tc");
            this.tc.Controls.Add(this.tpAllAccounts);
            this.tc.Controls.Add(this.tpAsset);
            this.tc.Controls.Add(this.tpLiability);
            this.tc.Controls.Add(this.tpEquity);
            this.tc.Controls.Add(this.tpIncome);
            this.tc.Controls.Add(this.tpCostOfSales);
            this.tc.Controls.Add(this.tpExpense);
            this.tc.Controls.Add(this.tpOtherIncome);
            this.tc.Controls.Add(this.tpOtherExpense);
            this.tc.HotTrack = true;
            this.tc.Name = "tc";
            this.tc.SelectedIndex = 0;
            // 
            // tpAllAccounts
            // 
            this.tpAllAccounts.Controls.Add(this.tgvAllAccounts);
            resources.ApplyResources(this.tpAllAccounts, "tpAllAccounts");
            this.tpAllAccounts.Name = "tpAllAccounts";
            this.tpAllAccounts.UseVisualStyleBackColor = true;
            // 
            // tgvAllAccounts
            // 
            this.tgvAllAccounts.AllowUserToAddRows = false;
            this.tgvAllAccounts.AllowUserToDeleteRows = false;
            this.tgvAllAccounts.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.tgvAllAccounts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.tgvAllAccounts, "tgvAllAccounts");
            this.tgvAllAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tgvAllAccounts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tgvAllAccounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAccountName,
            this.colAccountType,
            this.colAccountTax,
            this.colAccountLinked,
            this.colAccountBalance});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tgvAllAccounts.DefaultCellStyle = dataGridViewCellStyle2;
            this.tgvAllAccounts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tgvAllAccounts.ImageList = null;
            this.tgvAllAccounts.MultiSelect = false;
            this.tgvAllAccounts.Name = "tgvAllAccounts";
            this.tgvAllAccounts.RowHeadersVisible = false;
            this.tgvAllAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // colAccountName
            // 
            this.colAccountName.DefaultNodeImage = null;
            resources.ApplyResources(this.colAccountName, "colAccountName");
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAccountName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAccountType
            // 
            resources.ApplyResources(this.colAccountType, "colAccountType");
            this.colAccountType.Name = "colAccountType";
            this.colAccountType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAccountTax
            // 
            resources.ApplyResources(this.colAccountTax, "colAccountTax");
            this.colAccountTax.Name = "colAccountTax";
            this.colAccountTax.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAccountTax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAccountLinked
            // 
            resources.ApplyResources(this.colAccountLinked, "colAccountLinked");
            this.colAccountLinked.Name = "colAccountLinked";
            this.colAccountLinked.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colAccountBalance
            // 
            resources.ApplyResources(this.colAccountBalance, "colAccountBalance");
            this.colAccountBalance.Name = "colAccountBalance";
            this.colAccountBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tpAsset
            // 
            this.tpAsset.Controls.Add(this.tgvAsset);
            resources.ApplyResources(this.tpAsset, "tpAsset");
            this.tpAsset.Name = "tpAsset";
            this.tpAsset.UseVisualStyleBackColor = true;
            // 
            // tgvAsset
            // 
            this.tgvAsset.AllowUserToAddRows = false;
            this.tgvAsset.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.tgvAsset.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.tgvAsset, "tgvAsset");
            this.tgvAsset.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tgvAsset.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tgvAsset.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.assetAccountName,
            this.assetAccountType,
            this.assetAccountTax,
            this.assetAccountLinked,
            this.assetAccountBalance});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tgvAsset.DefaultCellStyle = dataGridViewCellStyle4;
            this.tgvAsset.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tgvAsset.ImageList = null;
            this.tgvAsset.Name = "tgvAsset";
            this.tgvAsset.RowHeadersVisible = false;
            this.tgvAsset.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // assetAccountName
            // 
            this.assetAccountName.DefaultNodeImage = null;
            resources.ApplyResources(this.assetAccountName, "assetAccountName");
            this.assetAccountName.Name = "assetAccountName";
            this.assetAccountName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // assetAccountType
            // 
            resources.ApplyResources(this.assetAccountType, "assetAccountType");
            this.assetAccountType.Name = "assetAccountType";
            this.assetAccountType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.assetAccountType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // assetAccountTax
            // 
            resources.ApplyResources(this.assetAccountTax, "assetAccountTax");
            this.assetAccountTax.Name = "assetAccountTax";
            this.assetAccountTax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // assetAccountLinked
            // 
            resources.ApplyResources(this.assetAccountLinked, "assetAccountLinked");
            this.assetAccountLinked.Name = "assetAccountLinked";
            // 
            // assetAccountBalance
            // 
            resources.ApplyResources(this.assetAccountBalance, "assetAccountBalance");
            this.assetAccountBalance.Name = "assetAccountBalance";
            this.assetAccountBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tpLiability
            // 
            this.tpLiability.Controls.Add(this.tgvLiability);
            resources.ApplyResources(this.tpLiability, "tpLiability");
            this.tpLiability.Name = "tpLiability";
            this.tpLiability.UseVisualStyleBackColor = true;
            // 
            // tgvLiability
            // 
            this.tgvLiability.AllowUserToAddRows = false;
            this.tgvLiability.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.tgvLiability.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.tgvLiability, "tgvLiability");
            this.tgvLiability.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tgvLiability.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tgvLiability.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.liabAccountName,
            this.liabAccountType,
            this.liabAccountTax,
            this.liabAccountLinked,
            this.liabAccountBalance});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tgvLiability.DefaultCellStyle = dataGridViewCellStyle6;
            this.tgvLiability.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tgvLiability.ImageList = null;
            this.tgvLiability.Name = "tgvLiability";
            this.tgvLiability.RowHeadersVisible = false;
            this.tgvLiability.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // liabAccountName
            // 
            this.liabAccountName.DefaultNodeImage = null;
            resources.ApplyResources(this.liabAccountName, "liabAccountName");
            this.liabAccountName.Name = "liabAccountName";
            this.liabAccountName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // liabAccountType
            // 
            resources.ApplyResources(this.liabAccountType, "liabAccountType");
            this.liabAccountType.Name = "liabAccountType";
            this.liabAccountType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // liabAccountTax
            // 
            resources.ApplyResources(this.liabAccountTax, "liabAccountTax");
            this.liabAccountTax.Name = "liabAccountTax";
            this.liabAccountTax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // liabAccountLinked
            // 
            resources.ApplyResources(this.liabAccountLinked, "liabAccountLinked");
            this.liabAccountLinked.Name = "liabAccountLinked";
            this.liabAccountLinked.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // liabAccountBalance
            // 
            resources.ApplyResources(this.liabAccountBalance, "liabAccountBalance");
            this.liabAccountBalance.Name = "liabAccountBalance";
            this.liabAccountBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tpEquity
            // 
            this.tpEquity.Controls.Add(this.tgvEquity);
            resources.ApplyResources(this.tpEquity, "tpEquity");
            this.tpEquity.Name = "tpEquity";
            this.tpEquity.UseVisualStyleBackColor = true;
            // 
            // tgvEquity
            // 
            this.tgvEquity.AllowUserToAddRows = false;
            this.tgvEquity.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.tgvEquity.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            resources.ApplyResources(this.tgvEquity, "tgvEquity");
            this.tgvEquity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tgvEquity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tgvEquity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.equiAccountName,
            this.equiAccountType,
            this.equiAccountTax,
            this.equiAccountLinked,
            this.equiAccountBalance});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tgvEquity.DefaultCellStyle = dataGridViewCellStyle8;
            this.tgvEquity.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tgvEquity.ImageList = null;
            this.tgvEquity.Name = "tgvEquity";
            this.tgvEquity.RowHeadersVisible = false;
            this.tgvEquity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // equiAccountName
            // 
            this.equiAccountName.DefaultNodeImage = null;
            resources.ApplyResources(this.equiAccountName, "equiAccountName");
            this.equiAccountName.Name = "equiAccountName";
            this.equiAccountName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // equiAccountType
            // 
            resources.ApplyResources(this.equiAccountType, "equiAccountType");
            this.equiAccountType.Name = "equiAccountType";
            this.equiAccountType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // equiAccountTax
            // 
            resources.ApplyResources(this.equiAccountTax, "equiAccountTax");
            this.equiAccountTax.Name = "equiAccountTax";
            this.equiAccountTax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // equiAccountLinked
            // 
            resources.ApplyResources(this.equiAccountLinked, "equiAccountLinked");
            this.equiAccountLinked.Name = "equiAccountLinked";
            this.equiAccountLinked.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // equiAccountBalance
            // 
            resources.ApplyResources(this.equiAccountBalance, "equiAccountBalance");
            this.equiAccountBalance.Name = "equiAccountBalance";
            this.equiAccountBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tpIncome
            // 
            this.tpIncome.Controls.Add(this.tgvIncome);
            resources.ApplyResources(this.tpIncome, "tpIncome");
            this.tpIncome.Name = "tpIncome";
            this.tpIncome.UseVisualStyleBackColor = true;
            // 
            // tgvIncome
            // 
            this.tgvIncome.AllowUserToAddRows = false;
            this.tgvIncome.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.tgvIncome.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            resources.ApplyResources(this.tgvIncome, "tgvIncome");
            this.tgvIncome.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tgvIncome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tgvIncome.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.incoAccountName,
            this.incoAccountType,
            this.incoAccountTax,
            this.incoAccountLinked,
            this.incoAccountBalance});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tgvIncome.DefaultCellStyle = dataGridViewCellStyle10;
            this.tgvIncome.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tgvIncome.ImageList = null;
            this.tgvIncome.Name = "tgvIncome";
            this.tgvIncome.RowHeadersVisible = false;
            this.tgvIncome.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // incoAccountName
            // 
            this.incoAccountName.DefaultNodeImage = null;
            resources.ApplyResources(this.incoAccountName, "incoAccountName");
            this.incoAccountName.Name = "incoAccountName";
            this.incoAccountName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // incoAccountType
            // 
            resources.ApplyResources(this.incoAccountType, "incoAccountType");
            this.incoAccountType.Name = "incoAccountType";
            this.incoAccountType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // incoAccountTax
            // 
            resources.ApplyResources(this.incoAccountTax, "incoAccountTax");
            this.incoAccountTax.Name = "incoAccountTax";
            this.incoAccountTax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // incoAccountLinked
            // 
            resources.ApplyResources(this.incoAccountLinked, "incoAccountLinked");
            this.incoAccountLinked.Name = "incoAccountLinked";
            // 
            // incoAccountBalance
            // 
            resources.ApplyResources(this.incoAccountBalance, "incoAccountBalance");
            this.incoAccountBalance.Name = "incoAccountBalance";
            this.incoAccountBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tpCostOfSales
            // 
            this.tpCostOfSales.Controls.Add(this.tgvCoS);
            resources.ApplyResources(this.tpCostOfSales, "tpCostOfSales");
            this.tpCostOfSales.Name = "tpCostOfSales";
            this.tpCostOfSales.UseVisualStyleBackColor = true;
            // 
            // tgvCoS
            // 
            this.tgvCoS.AllowUserToAddRows = false;
            this.tgvCoS.AllowUserToDeleteRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.tgvCoS.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            resources.ApplyResources(this.tgvCoS, "tgvCoS");
            this.tgvCoS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tgvCoS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tgvCoS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cosAccountName,
            this.cosAccountType,
            this.cosAccountTax,
            this.cosAccountLinked,
            this.cosAccountBalance});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tgvCoS.DefaultCellStyle = dataGridViewCellStyle12;
            this.tgvCoS.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tgvCoS.ImageList = null;
            this.tgvCoS.Name = "tgvCoS";
            this.tgvCoS.RowHeadersVisible = false;
            this.tgvCoS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // cosAccountName
            // 
            this.cosAccountName.DefaultNodeImage = null;
            resources.ApplyResources(this.cosAccountName, "cosAccountName");
            this.cosAccountName.Name = "cosAccountName";
            this.cosAccountName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cosAccountType
            // 
            resources.ApplyResources(this.cosAccountType, "cosAccountType");
            this.cosAccountType.Name = "cosAccountType";
            this.cosAccountType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cosAccountTax
            // 
            resources.ApplyResources(this.cosAccountTax, "cosAccountTax");
            this.cosAccountTax.Name = "cosAccountTax";
            this.cosAccountTax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cosAccountLinked
            // 
            resources.ApplyResources(this.cosAccountLinked, "cosAccountLinked");
            this.cosAccountLinked.Name = "cosAccountLinked";
            // 
            // cosAccountBalance
            // 
            resources.ApplyResources(this.cosAccountBalance, "cosAccountBalance");
            this.cosAccountBalance.Name = "cosAccountBalance";
            this.cosAccountBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tpExpense
            // 
            this.tpExpense.Controls.Add(this.tgvExpense);
            resources.ApplyResources(this.tpExpense, "tpExpense");
            this.tpExpense.Name = "tpExpense";
            this.tpExpense.UseVisualStyleBackColor = true;
            // 
            // tgvExpense
            // 
            this.tgvExpense.AllowUserToAddRows = false;
            this.tgvExpense.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.tgvExpense.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            resources.ApplyResources(this.tgvExpense, "tgvExpense");
            this.tgvExpense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tgvExpense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tgvExpense.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.expeAccountName,
            this.expeAccountType,
            this.expeAccountTax,
            this.expeAccountLinked,
            this.expeAccountBalance});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tgvExpense.DefaultCellStyle = dataGridViewCellStyle14;
            this.tgvExpense.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tgvExpense.ImageList = null;
            this.tgvExpense.Name = "tgvExpense";
            this.tgvExpense.RowHeadersVisible = false;
            this.tgvExpense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // expeAccountName
            // 
            this.expeAccountName.DefaultNodeImage = null;
            resources.ApplyResources(this.expeAccountName, "expeAccountName");
            this.expeAccountName.Name = "expeAccountName";
            this.expeAccountName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // expeAccountType
            // 
            resources.ApplyResources(this.expeAccountType, "expeAccountType");
            this.expeAccountType.Name = "expeAccountType";
            this.expeAccountType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // expeAccountTax
            // 
            resources.ApplyResources(this.expeAccountTax, "expeAccountTax");
            this.expeAccountTax.Name = "expeAccountTax";
            this.expeAccountTax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // expeAccountLinked
            // 
            resources.ApplyResources(this.expeAccountLinked, "expeAccountLinked");
            this.expeAccountLinked.Name = "expeAccountLinked";
            // 
            // expeAccountBalance
            // 
            resources.ApplyResources(this.expeAccountBalance, "expeAccountBalance");
            this.expeAccountBalance.Name = "expeAccountBalance";
            this.expeAccountBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tpOtherIncome
            // 
            this.tpOtherIncome.Controls.Add(this.tgvOtherIncome);
            resources.ApplyResources(this.tpOtherIncome, "tpOtherIncome");
            this.tpOtherIncome.Name = "tpOtherIncome";
            this.tpOtherIncome.UseVisualStyleBackColor = true;
            // 
            // tgvOtherIncome
            // 
            this.tgvOtherIncome.AllowUserToAddRows = false;
            this.tgvOtherIncome.AllowUserToDeleteRows = false;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.tgvOtherIncome.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle15;
            resources.ApplyResources(this.tgvOtherIncome, "tgvOtherIncome");
            this.tgvOtherIncome.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tgvOtherIncome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tgvOtherIncome.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.oincAccountName,
            this.oincAccountType,
            this.oincAccountTax,
            this.oincAccountLinked,
            this.oincAccountBalance});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tgvOtherIncome.DefaultCellStyle = dataGridViewCellStyle16;
            this.tgvOtherIncome.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tgvOtherIncome.ImageList = null;
            this.tgvOtherIncome.Name = "tgvOtherIncome";
            this.tgvOtherIncome.RowHeadersVisible = false;
            this.tgvOtherIncome.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // oincAccountName
            // 
            this.oincAccountName.DefaultNodeImage = null;
            resources.ApplyResources(this.oincAccountName, "oincAccountName");
            this.oincAccountName.Name = "oincAccountName";
            this.oincAccountName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // oincAccountType
            // 
            resources.ApplyResources(this.oincAccountType, "oincAccountType");
            this.oincAccountType.Name = "oincAccountType";
            this.oincAccountType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // oincAccountTax
            // 
            resources.ApplyResources(this.oincAccountTax, "oincAccountTax");
            this.oincAccountTax.Name = "oincAccountTax";
            this.oincAccountTax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // oincAccountLinked
            // 
            resources.ApplyResources(this.oincAccountLinked, "oincAccountLinked");
            this.oincAccountLinked.Name = "oincAccountLinked";
            // 
            // oincAccountBalance
            // 
            resources.ApplyResources(this.oincAccountBalance, "oincAccountBalance");
            this.oincAccountBalance.Name = "oincAccountBalance";
            this.oincAccountBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tpOtherExpense
            // 
            this.tpOtherExpense.Controls.Add(this.tgvOtherExpense);
            resources.ApplyResources(this.tpOtherExpense, "tpOtherExpense");
            this.tpOtherExpense.Name = "tpOtherExpense";
            this.tpOtherExpense.UseVisualStyleBackColor = true;
            // 
            // tgvOtherExpense
            // 
            this.tgvOtherExpense.AllowUserToAddRows = false;
            this.tgvOtherExpense.AllowUserToDeleteRows = false;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.tgvOtherExpense.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            resources.ApplyResources(this.tgvOtherExpense, "tgvOtherExpense");
            this.tgvOtherExpense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tgvOtherExpense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tgvOtherExpense.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.oexpAccountName,
            this.oexpAccountType,
            this.oexpAccountTax,
            this.oexpAccountLinked,
            this.oexpAccountBalance});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tgvOtherExpense.DefaultCellStyle = dataGridViewCellStyle18;
            this.tgvOtherExpense.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tgvOtherExpense.ImageList = null;
            this.tgvOtherExpense.Name = "tgvOtherExpense";
            this.tgvOtherExpense.RowHeadersVisible = false;
            this.tgvOtherExpense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // oexpAccountName
            // 
            this.oexpAccountName.DefaultNodeImage = null;
            resources.ApplyResources(this.oexpAccountName, "oexpAccountName");
            this.oexpAccountName.Name = "oexpAccountName";
            this.oexpAccountName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // oexpAccountType
            // 
            resources.ApplyResources(this.oexpAccountType, "oexpAccountType");
            this.oexpAccountType.Name = "oexpAccountType";
            this.oexpAccountType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // oexpAccountTax
            // 
            resources.ApplyResources(this.oexpAccountTax, "oexpAccountTax");
            this.oexpAccountTax.Name = "oexpAccountTax";
            this.oexpAccountTax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // oexpAccountLinked
            // 
            resources.ApplyResources(this.oexpAccountLinked, "oexpAccountLinked");
            this.oexpAccountLinked.Name = "oexpAccountLinked";
            // 
            // oexpAccountBalance
            // 
            resources.ApplyResources(this.oexpAccountBalance, "oexpAccountBalance");
            this.oexpAccountBalance.Name = "oexpAccountBalance";
            this.oexpAccountBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // imgLst
            // 
            this.imgLst.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.imgLst, "imgLst");
            this.imgLst.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // gbFilter
            // 
            resources.ApplyResources(this.gbFilter, "gbFilter");
            this.gbFilter.BackgroundColor = System.Drawing.Color.White;
            this.gbFilter.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbFilter.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbFilter.BorderWidth = 1F;
            this.gbFilter.Caption = "Accounts --> Accounts Register";
            this.gbFilter.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbFilter.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbFilter.CaptionHeight = 25;
            this.gbFilter.CaptionVisible = true;
            this.gbFilter.Controls.Add(this.btnClose2);
            this.gbFilter.Controls.Add(this.tc);
            this.gbFilter.CornerRadius = 5;
            this.gbFilter.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbFilter.DropShadowThickness = 3;
            this.gbFilter.DropShadowVisible = true;
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.TabStop = false;
            // 
            // btnClose2
            // 
            resources.ApplyResources(this.btnClose2, "btnClose2");
            this.btnClose2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose2.BackgroundImage = global::DacII.Properties.Resources.cancel_16x16;
            this.btnClose2.FlatAppearance.BorderSize = 0;
            this.btnClose2.Name = "btnClose2";
            this.btnClose2.UseVisualStyleBackColor = false;
            this.btnClose2.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BaseColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonText = "Close";
            this.btnClose.Name = "btnClose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.BaseColor = System.Drawing.Color.Transparent;
            this.btnPrint.ButtonText = "Print";
            this.btnPrint.Name = "btnPrint";
            // 
            // btnRefresh
            // 
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.BaseColor = System.Drawing.Color.Transparent;
            this.btnRefresh.ButtonText = "Refresh";
            this.btnRefresh.Name = "btnRefresh";
            // 
            // FrmAccountsRegister
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.gbFilter);
            this.Name = "FrmAccountsRegister";
            this.tc.ResumeLayout(false);
            this.tpAllAccounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tgvAllAccounts)).EndInit();
            this.tpAsset.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tgvAsset)).EndInit();
            this.tpLiability.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tgvLiability)).EndInit();
            this.tpEquity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tgvEquity)).EndInit();
            this.tpIncome.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tgvIncome)).EndInit();
            this.tpCostOfSales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tgvCoS)).EndInit();
            this.tpExpense.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tgvExpense)).EndInit();
            this.tpOtherIncome.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tgvOtherIncome)).EndInit();
            this.tpOtherExpense.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tgvOtherExpense)).EndInit();
            this.gbFilter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tc;
        private System.Windows.Forms.TabPage tpAllAccounts;
        private System.Windows.Forms.TabPage tpAsset;
        private System.Windows.Forms.TabPage tpLiability;
        private System.Windows.Forms.TabPage tpEquity;
        private System.Windows.Forms.TabPage tpIncome;
        private System.Windows.Forms.TabPage tpCostOfSales;
        private System.Windows.Forms.TabPage tpExpense;
        private System.Windows.Forms.TabPage tpOtherIncome;
        private System.Windows.Forms.TabPage tpOtherExpense;
        private AdvancedDataGridView.TreeGridView tgvAllAccounts;
        private AdvancedDataGridView.TreeGridView tgvAsset;
        private AdvancedDataGridView.TreeGridColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountTax;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAccountLinked;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountBalance;
        private AdvancedDataGridView.TreeGridColumn assetAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn assetAccountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn assetAccountTax;
        private System.Windows.Forms.DataGridViewCheckBoxColumn assetAccountLinked;
        private System.Windows.Forms.DataGridViewTextBoxColumn assetAccountBalance;
        private AdvancedDataGridView.TreeGridView tgvLiability;
        private AdvancedDataGridView.TreeGridColumn liabAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn liabAccountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn liabAccountTax;
        private System.Windows.Forms.DataGridViewCheckBoxColumn liabAccountLinked;
        private System.Windows.Forms.DataGridViewTextBoxColumn liabAccountBalance;
        private AdvancedDataGridView.TreeGridView tgvEquity;
        private AdvancedDataGridView.TreeGridColumn equiAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn equiAccountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn equiAccountTax;
        private System.Windows.Forms.DataGridViewCheckBoxColumn equiAccountLinked;
        private System.Windows.Forms.DataGridViewTextBoxColumn equiAccountBalance;
        private AdvancedDataGridView.TreeGridView tgvIncome;
        private AdvancedDataGridView.TreeGridColumn incoAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn incoAccountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn incoAccountTax;
        private System.Windows.Forms.DataGridViewCheckBoxColumn incoAccountLinked;
        private System.Windows.Forms.DataGridViewTextBoxColumn incoAccountBalance;
        private AdvancedDataGridView.TreeGridView tgvCoS;
        private AdvancedDataGridView.TreeGridColumn cosAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cosAccountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn cosAccountTax;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cosAccountLinked;
        private System.Windows.Forms.DataGridViewTextBoxColumn cosAccountBalance;
        private AdvancedDataGridView.TreeGridView tgvExpense;
        private AdvancedDataGridView.TreeGridColumn expeAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn expeAccountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn expeAccountTax;
        private System.Windows.Forms.DataGridViewCheckBoxColumn expeAccountLinked;
        private System.Windows.Forms.DataGridViewTextBoxColumn expeAccountBalance;
        private AdvancedDataGridView.TreeGridView tgvOtherIncome;
        private AdvancedDataGridView.TreeGridColumn oincAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn oincAccountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn oincAccountTax;
        private System.Windows.Forms.DataGridViewCheckBoxColumn oincAccountLinked;
        private System.Windows.Forms.DataGridViewTextBoxColumn oincAccountBalance;
        private AdvancedDataGridView.TreeGridView tgvOtherExpense;
        private AdvancedDataGridView.TreeGridColumn oexpAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn oexpAccountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn oexpAccountTax;
        private System.Windows.Forms.DataGridViewCheckBoxColumn oexpAccountLinked;
        private System.Windows.Forms.DataGridViewTextBoxColumn oexpAccountBalance;
        private System.Windows.Forms.CZRoundedGroupBox gbFilter;
        private System.Windows.Forms.VistaButton btnClose;
        private System.Windows.Forms.VistaButton btnPrint;
        private System.Windows.Forms.VistaButton btnRefresh;
        private System.Windows.Forms.ImageList imgLst;
        private System.Windows.Forms.Button btnClose2;
    }
}