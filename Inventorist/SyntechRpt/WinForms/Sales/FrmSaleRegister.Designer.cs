namespace SyntechRpt.WinForms.Sales
{
    partial class FrmSaleRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSaleRegister));
            this.gbSale = new System.Windows.Forms.GroupBox();
            this.tcSale = new System.Windows.Forms.TabControl();
            this.tpAll = new System.Windows.Forms.TabPage();
            this.dgvAll = new System.Windows.Forms.DataGridView();
            this.tpQuote = new System.Windows.Forms.TabPage();
            this.btnDelQuote = new System.Windows.Forms.Button();
            this.btnCreatePO = new System.Windows.Forms.Button();
            this.btnCreateQuote = new System.Windows.Forms.Button();
            this.btnChangeQuote2OpenInvoice = new System.Windows.Forms.Button();
            this.btnChangeQuote2Order = new System.Windows.Forms.Button();
            this.dgvQuote = new System.Windows.Forms.DataGridView();
            this.tpOrder = new System.Windows.Forms.TabPage();
            this.btnDelOrder = new System.Windows.Forms.Button();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.btnChangeOrder2OpenInvoice = new System.Windows.Forms.Button();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.tpOpen = new System.Windows.Forms.TabPage();
            this.btnDelOpenInvoice = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.dgvOpenInvoice = new System.Windows.Forms.DataGridView();
            this.tpCreditReturn = new System.Windows.Forms.TabPage();
            this.dgvCreditReturn = new System.Windows.Forms.DataGridView();
            this.tpClosed = new System.Windows.Forms.TabPage();
            this.dgvClosedInvoice = new System.Windows.Forms.DataGridView();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.chkAllCustomers = new System.Windows.Forms.CheckBox();
            this.ilLock = new System.Windows.Forms.ImageList(this.components);
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblCustomerSearchCriteria = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.cboCustomerSearchCriteria = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbSale.SuspendLayout();
            this.tcSale.SuspendLayout();
            this.tpAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAll)).BeginInit();
            this.tpQuote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuote)).BeginInit();
            this.tpOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.tpOpen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpenInvoice)).BeginInit();
            this.tpCreditReturn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreditReturn)).BeginInit();
            this.tpClosed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClosedInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSale
            // 
            this.gbSale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSale.Controls.Add(this.tcSale);
            this.gbSale.Location = new System.Drawing.Point(12, 8);
            this.gbSale.Name = "gbSale";
            this.gbSale.Size = new System.Drawing.Size(821, 364);
            this.gbSale.TabIndex = 0;
            this.gbSale.TabStop = false;
            // 
            // tcSale
            // 
            this.tcSale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcSale.Controls.Add(this.tpAll);
            this.tcSale.Controls.Add(this.tpQuote);
            this.tcSale.Controls.Add(this.tpOrder);
            this.tcSale.Controls.Add(this.tpOpen);
            this.tcSale.Controls.Add(this.tpCreditReturn);
            this.tcSale.Controls.Add(this.tpClosed);
            this.tcSale.Location = new System.Drawing.Point(6, 12);
            this.tcSale.Name = "tcSale";
            this.tcSale.SelectedIndex = 0;
            this.tcSale.Size = new System.Drawing.Size(809, 342);
            this.tcSale.TabIndex = 0;
            // 
            // tpAll
            // 
            this.tpAll.Controls.Add(this.dgvAll);
            this.tpAll.Location = new System.Drawing.Point(4, 22);
            this.tpAll.Name = "tpAll";
            this.tpAll.Padding = new System.Windows.Forms.Padding(3);
            this.tpAll.Size = new System.Drawing.Size(801, 316);
            this.tpAll.TabIndex = 0;
            this.tpAll.Text = "All Sales";
            this.tpAll.UseVisualStyleBackColor = true;
            // 
            // dgvAll
            // 
            this.dgvAll.AllowUserToAddRows = false;
            this.dgvAll.AllowUserToDeleteRows = false;
            this.dgvAll.AllowUserToOrderColumns = true;
            this.dgvAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAll.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAll.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAll.Location = new System.Drawing.Point(6, 6);
            this.dgvAll.MultiSelect = false;
            this.dgvAll.Name = "dgvAll";
            this.dgvAll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAll.Size = new System.Drawing.Size(789, 261);
            this.dgvAll.TabIndex = 0;
            this.dgvAll.DoubleClick += new System.EventHandler(this.dgvAll_DoubleClick);
            // 
            // tpQuote
            // 
            this.tpQuote.Controls.Add(this.btnDelQuote);
            this.tpQuote.Controls.Add(this.btnCreatePO);
            this.tpQuote.Controls.Add(this.btnCreateQuote);
            this.tpQuote.Controls.Add(this.btnChangeQuote2OpenInvoice);
            this.tpQuote.Controls.Add(this.btnChangeQuote2Order);
            this.tpQuote.Controls.Add(this.dgvQuote);
            this.tpQuote.Location = new System.Drawing.Point(4, 22);
            this.tpQuote.Name = "tpQuote";
            this.tpQuote.Padding = new System.Windows.Forms.Padding(3);
            this.tpQuote.Size = new System.Drawing.Size(801, 316);
            this.tpQuote.TabIndex = 1;
            this.tpQuote.Text = "Sale Quotes";
            this.tpQuote.UseVisualStyleBackColor = true;
            // 
            // btnDelQuote
            // 
            this.btnDelQuote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelQuote.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelQuote.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelQuote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelQuote.Image = global::SyntechRpt.Properties.Resources.delete_line;
            this.btnDelQuote.Location = new System.Drawing.Point(697, 273);
            this.btnDelQuote.Name = "btnDelQuote";
            this.btnDelQuote.Size = new System.Drawing.Size(98, 37);
            this.btnDelQuote.TabIndex = 9;
            this.btnDelQuote.Text = "Delete";
            this.btnDelQuote.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelQuote.UseVisualStyleBackColor = false;
            this.btnDelQuote.Click += new System.EventHandler(this.btnDelQuote_Click);
            // 
            // btnCreatePO
            // 
            this.btnCreatePO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreatePO.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCreatePO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreatePO.Image = global::SyntechRpt.Properties.Resources.new_line;
            this.btnCreatePO.Location = new System.Drawing.Point(165, 273);
            this.btnCreatePO.Name = "btnCreatePO";
            this.btnCreatePO.Size = new System.Drawing.Size(114, 37);
            this.btnCreatePO.TabIndex = 8;
            this.btnCreatePO.Text = "Create PO";
            this.btnCreatePO.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreatePO.UseVisualStyleBackColor = false;
            this.btnCreatePO.Click += new System.EventHandler(this.btnCreateQuote_Click);
            // 
            // btnCreateQuote
            // 
            this.btnCreateQuote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateQuote.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCreateQuote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateQuote.Image = global::SyntechRpt.Properties.Resources.new_line;
            this.btnCreateQuote.Location = new System.Drawing.Point(285, 273);
            this.btnCreateQuote.Name = "btnCreateQuote";
            this.btnCreateQuote.Size = new System.Drawing.Size(114, 37);
            this.btnCreateQuote.TabIndex = 8;
            this.btnCreateQuote.Text = "Create Quote";
            this.btnCreateQuote.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreateQuote.UseVisualStyleBackColor = false;
            this.btnCreateQuote.Click += new System.EventHandler(this.btnCreateQuote_Click);
            // 
            // btnChangeQuote2OpenInvoice
            // 
            this.btnChangeQuote2OpenInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeQuote2OpenInvoice.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnChangeQuote2OpenInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeQuote2OpenInvoice.Image = global::SyntechRpt.Properties.Resources.edit_line;
            this.btnChangeQuote2OpenInvoice.Location = new System.Drawing.Point(551, 273);
            this.btnChangeQuote2OpenInvoice.Name = "btnChangeQuote2OpenInvoice";
            this.btnChangeQuote2OpenInvoice.Size = new System.Drawing.Size(140, 37);
            this.btnChangeQuote2OpenInvoice.TabIndex = 7;
            this.btnChangeQuote2OpenInvoice.Text = "Change to Invoice";
            this.btnChangeQuote2OpenInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChangeQuote2OpenInvoice.UseVisualStyleBackColor = false;
            this.btnChangeQuote2OpenInvoice.Click += new System.EventHandler(this.btnChangeQuote2OpenInvoice_Click);
            // 
            // btnChangeQuote2Order
            // 
            this.btnChangeQuote2Order.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeQuote2Order.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnChangeQuote2Order.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeQuote2Order.Image = global::SyntechRpt.Properties.Resources.edit_line;
            this.btnChangeQuote2Order.Location = new System.Drawing.Point(405, 273);
            this.btnChangeQuote2Order.Name = "btnChangeQuote2Order";
            this.btnChangeQuote2Order.Size = new System.Drawing.Size(140, 37);
            this.btnChangeQuote2Order.TabIndex = 7;
            this.btnChangeQuote2Order.Text = "Change to Order";
            this.btnChangeQuote2Order.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChangeQuote2Order.UseVisualStyleBackColor = false;
            this.btnChangeQuote2Order.Click += new System.EventHandler(this.btnChangeQuote2Order_Click);
            // 
            // dgvQuote
            // 
            this.dgvQuote.AllowUserToAddRows = false;
            this.dgvQuote.AllowUserToDeleteRows = false;
            this.dgvQuote.AllowUserToOrderColumns = true;
            this.dgvQuote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQuote.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuote.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvQuote.Location = new System.Drawing.Point(6, 6);
            this.dgvQuote.MultiSelect = false;
            this.dgvQuote.Name = "dgvQuote";
            this.dgvQuote.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuote.Size = new System.Drawing.Size(789, 261);
            this.dgvQuote.TabIndex = 1;
            this.dgvQuote.DoubleClick += new System.EventHandler(this.dgvQuote_DoubleClick);
            // 
            // tpOrder
            // 
            this.tpOrder.Controls.Add(this.btnDelOrder);
            this.tpOrder.Controls.Add(this.btnCreateOrder);
            this.tpOrder.Controls.Add(this.btnChangeOrder2OpenInvoice);
            this.tpOrder.Controls.Add(this.dgvOrder);
            this.tpOrder.Location = new System.Drawing.Point(4, 22);
            this.tpOrder.Name = "tpOrder";
            this.tpOrder.Size = new System.Drawing.Size(801, 316);
            this.tpOrder.TabIndex = 2;
            this.tpOrder.Text = "Sale Orders";
            this.tpOrder.UseVisualStyleBackColor = true;
            // 
            // btnDelOrder
            // 
            this.btnDelOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelOrder.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelOrder.Image = global::SyntechRpt.Properties.Resources.delete_line;
            this.btnDelOrder.Location = new System.Drawing.Point(697, 273);
            this.btnDelOrder.Name = "btnDelOrder";
            this.btnDelOrder.Size = new System.Drawing.Size(98, 37);
            this.btnDelOrder.TabIndex = 13;
            this.btnDelOrder.Text = "Delete";
            this.btnDelOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelOrder.UseVisualStyleBackColor = false;
            this.btnDelOrder.Click += new System.EventHandler(this.btnDelOrder_Click);
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateOrder.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCreateOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateOrder.Image = global::SyntechRpt.Properties.Resources.new_line;
            this.btnCreateOrder.Location = new System.Drawing.Point(431, 273);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(114, 37);
            this.btnCreateOrder.TabIndex = 12;
            this.btnCreateOrder.Text = "Create Order";
            this.btnCreateOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreateOrder.UseVisualStyleBackColor = false;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // btnChangeOrder2OpenInvoice
            // 
            this.btnChangeOrder2OpenInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeOrder2OpenInvoice.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnChangeOrder2OpenInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeOrder2OpenInvoice.Image = global::SyntechRpt.Properties.Resources.edit_line;
            this.btnChangeOrder2OpenInvoice.Location = new System.Drawing.Point(551, 273);
            this.btnChangeOrder2OpenInvoice.Name = "btnChangeOrder2OpenInvoice";
            this.btnChangeOrder2OpenInvoice.Size = new System.Drawing.Size(140, 37);
            this.btnChangeOrder2OpenInvoice.TabIndex = 10;
            this.btnChangeOrder2OpenInvoice.Text = "Change to Invoice";
            this.btnChangeOrder2OpenInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChangeOrder2OpenInvoice.UseVisualStyleBackColor = false;
            this.btnChangeOrder2OpenInvoice.Click += new System.EventHandler(this.btnChangeOrder2OpenInvoice_Click);
            // 
            // dgvOrder
            // 
            this.dgvOrder.AllowUserToAddRows = false;
            this.dgvOrder.AllowUserToDeleteRows = false;
            this.dgvOrder.AllowUserToOrderColumns = true;
            this.dgvOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvOrder.Location = new System.Drawing.Point(6, 6);
            this.dgvOrder.MultiSelect = false;
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrder.Size = new System.Drawing.Size(789, 261);
            this.dgvOrder.TabIndex = 1;
            this.dgvOrder.DoubleClick += new System.EventHandler(this.dgvOrder_DoubleClick);
            // 
            // tpOpen
            // 
            this.tpOpen.Controls.Add(this.btnDelOpenInvoice);
            this.tpOpen.Controls.Add(this.button6);
            this.tpOpen.Controls.Add(this.button7);
            this.tpOpen.Controls.Add(this.button8);
            this.tpOpen.Controls.Add(this.dgvOpenInvoice);
            this.tpOpen.Location = new System.Drawing.Point(4, 22);
            this.tpOpen.Name = "tpOpen";
            this.tpOpen.Size = new System.Drawing.Size(801, 316);
            this.tpOpen.TabIndex = 3;
            this.tpOpen.Text = "Open Invoices";
            this.tpOpen.UseVisualStyleBackColor = true;
            // 
            // btnDelOpenInvoice
            // 
            this.btnDelOpenInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelOpenInvoice.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelOpenInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelOpenInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelOpenInvoice.Image = global::SyntechRpt.Properties.Resources.delete_line;
            this.btnDelOpenInvoice.Location = new System.Drawing.Point(697, 273);
            this.btnDelOpenInvoice.Name = "btnDelOpenInvoice";
            this.btnDelOpenInvoice.Size = new System.Drawing.Size(98, 37);
            this.btnDelOpenInvoice.TabIndex = 13;
            this.btnDelOpenInvoice.Text = "Delete";
            this.btnDelOpenInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelOpenInvoice.UseVisualStyleBackColor = false;
            this.btnDelOpenInvoice.Click += new System.EventHandler(this.btnDelOpenInvoice_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Image = global::SyntechRpt.Properties.Resources.new_line;
            this.button6.Location = new System.Drawing.Point(285, 273);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(114, 37);
            this.button6.TabIndex = 12;
            this.button6.Text = "Create PO";
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Image = global::SyntechRpt.Properties.Resources.edit_line;
            this.button7.Location = new System.Drawing.Point(551, 273);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(140, 37);
            this.button7.TabIndex = 10;
            this.button7.Text = "Change to Invoice";
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button8.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Image = global::SyntechRpt.Properties.Resources.edit_line;
            this.button8.Location = new System.Drawing.Point(405, 273);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(140, 37);
            this.button8.TabIndex = 11;
            this.button8.Text = "Change to Order";
            this.button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button8.UseVisualStyleBackColor = false;
            // 
            // dgvOpenInvoice
            // 
            this.dgvOpenInvoice.AllowUserToAddRows = false;
            this.dgvOpenInvoice.AllowUserToDeleteRows = false;
            this.dgvOpenInvoice.AllowUserToOrderColumns = true;
            this.dgvOpenInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOpenInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOpenInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOpenInvoice.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvOpenInvoice.Location = new System.Drawing.Point(6, 6);
            this.dgvOpenInvoice.MultiSelect = false;
            this.dgvOpenInvoice.Name = "dgvOpenInvoice";
            this.dgvOpenInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOpenInvoice.Size = new System.Drawing.Size(789, 261);
            this.dgvOpenInvoice.TabIndex = 1;
            this.dgvOpenInvoice.DoubleClick += new System.EventHandler(this.dgvOpenInvoice_DoubleClick);
            // 
            // tpCreditReturn
            // 
            this.tpCreditReturn.Controls.Add(this.dgvCreditReturn);
            this.tpCreditReturn.Location = new System.Drawing.Point(4, 22);
            this.tpCreditReturn.Name = "tpCreditReturn";
            this.tpCreditReturn.Size = new System.Drawing.Size(801, 316);
            this.tpCreditReturn.TabIndex = 5;
            this.tpCreditReturn.Text = "Credit Returns";
            this.tpCreditReturn.UseVisualStyleBackColor = true;
            // 
            // dgvCreditReturn
            // 
            this.dgvCreditReturn.AllowUserToAddRows = false;
            this.dgvCreditReturn.AllowUserToDeleteRows = false;
            this.dgvCreditReturn.AllowUserToOrderColumns = true;
            this.dgvCreditReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCreditReturn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCreditReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCreditReturn.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCreditReturn.Location = new System.Drawing.Point(6, 6);
            this.dgvCreditReturn.MultiSelect = false;
            this.dgvCreditReturn.Name = "dgvCreditReturn";
            this.dgvCreditReturn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCreditReturn.Size = new System.Drawing.Size(789, 261);
            this.dgvCreditReturn.TabIndex = 1;
            this.dgvCreditReturn.DoubleClick += new System.EventHandler(this.dgvCreditReturn_DoubleClick);
            // 
            // tpClosed
            // 
            this.tpClosed.Controls.Add(this.dgvClosedInvoice);
            this.tpClosed.Location = new System.Drawing.Point(4, 22);
            this.tpClosed.Name = "tpClosed";
            this.tpClosed.Size = new System.Drawing.Size(801, 316);
            this.tpClosed.TabIndex = 4;
            this.tpClosed.Text = "Closed Invoices";
            this.tpClosed.UseVisualStyleBackColor = true;
            // 
            // dgvClosedInvoice
            // 
            this.dgvClosedInvoice.AllowUserToAddRows = false;
            this.dgvClosedInvoice.AllowUserToDeleteRows = false;
            this.dgvClosedInvoice.AllowUserToOrderColumns = true;
            this.dgvClosedInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClosedInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClosedInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClosedInvoice.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvClosedInvoice.Location = new System.Drawing.Point(6, 6);
            this.dgvClosedInvoice.MultiSelect = false;
            this.dgvClosedInvoice.Name = "dgvClosedInvoice";
            this.dgvClosedInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClosedInvoice.Size = new System.Drawing.Size(789, 261);
            this.dgvClosedInvoice.TabIndex = 1;
            this.dgvClosedInvoice.DoubleClick += new System.EventHandler(this.dgvClosedInvoice_DoubleClick);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // gbFilter
            // 
            this.gbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbFilter.Controls.Add(this.btnRefresh);
            this.gbFilter.Controls.Add(this.chkAllCustomers);
            this.gbFilter.Controls.Add(this.lblEndDate);
            this.gbFilter.Controls.Add(this.lblCustomerSearchCriteria);
            this.gbFilter.Controls.Add(this.lblStartDate);
            this.gbFilter.Controls.Add(this.dtpEndDate);
            this.gbFilter.Controls.Add(this.cboCustomerSearchCriteria);
            this.gbFilter.Controls.Add(this.dtpStartDate);
            this.gbFilter.Location = new System.Drawing.Point(12, 378);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(422, 77);
            this.gbFilter.TabIndex = 3;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Search";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRefresh.BackgroundImage = global::SyntechRpt.Properties.Resources.reset;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(377, 43);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(25, 25);
            this.btnRefresh.TabIndex = 30;
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // chkAllCustomers
            // 
            this.chkAllCustomers.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAllCustomers.AutoSize = true;
            this.chkAllCustomers.FlatAppearance.BorderSize = 0;
            this.chkAllCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAllCustomers.ImageIndex = 0;
            this.chkAllCustomers.ImageList = this.ilLock;
            this.chkAllCustomers.Location = new System.Drawing.Point(377, 15);
            this.chkAllCustomers.Name = "chkAllCustomers";
            this.chkAllCustomers.Size = new System.Drawing.Size(25, 25);
            this.chkAllCustomers.TabIndex = 14;
            this.chkAllCustomers.UseVisualStyleBackColor = true;
            // 
            // ilLock
            // 
            this.ilLock.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilLock.ImageStream")));
            this.ilLock.TransparentColor = System.Drawing.Color.Transparent;
            this.ilLock.Images.SetKeyName(0, "locked.png");
            this.ilLock.Images.SetKeyName(1, "unlocked.png");
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(223, 47);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(20, 13);
            this.lblEndDate.TabIndex = 12;
            this.lblEndDate.Text = "To";
            // 
            // lblCustomerSearchCriteria
            // 
            this.lblCustomerSearchCriteria.AutoSize = true;
            this.lblCustomerSearchCriteria.Location = new System.Drawing.Point(8, 21);
            this.lblCustomerSearchCriteria.Name = "lblCustomerSearchCriteria";
            this.lblCustomerSearchCriteria.Size = new System.Drawing.Size(54, 13);
            this.lblCustomerSearchCriteria.TabIndex = 11;
            this.lblCustomerSearchCriteria.Text = "Customer:";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(8, 47);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(65, 13);
            this.lblStartDate.TabIndex = 11;
            this.lblStartDate.Text = "Dated From:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(249, 43);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(121, 20);
            this.dtpEndDate.TabIndex = 9;
            // 
            // cboCustomerSearchCriteria
            // 
            this.cboCustomerSearchCriteria.FormattingEnabled = true;
            this.cboCustomerSearchCriteria.Location = new System.Drawing.Point(79, 17);
            this.cboCustomerSearchCriteria.Name = "cboCustomerSearchCriteria";
            this.cboCustomerSearchCriteria.Size = new System.Drawing.Size(291, 21);
            this.cboCustomerSearchCriteria.TabIndex = 2;
            this.cboCustomerSearchCriteria.SelectedIndexChanged += new System.EventHandler(this.cboCustomerSearchCriteria_SelectedIndexChanged);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(79, 43);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(121, 20);
            this.dtpStartDate.TabIndex = 10;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Image = global::SyntechRpt.Properties.Resources.print;
            this.btnPrint.Location = new System.Drawing.Point(709, 399);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(56, 56);
            this.btnPrint.TabIndex = 92;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::SyntechRpt.Properties.Resources.cancel_record;
            this.btnClose.Location = new System.Drawing.Point(771, 399);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 56);
            this.btnClose.TabIndex = 91;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmSaleRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 467);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.gbSale);
            this.Name = "FrmSaleRegister";
            this.Text = "Sale Register";
            this.Load += new System.EventHandler(this.FrmSaleRegister_Load);
            this.gbSale.ResumeLayout(false);
            this.tcSale.ResumeLayout(false);
            this.tpAll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAll)).EndInit();
            this.tpQuote.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuote)).EndInit();
            this.tpOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.tpOpen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpenInvoice)).EndInit();
            this.tpCreditReturn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreditReturn)).EndInit();
            this.tpClosed.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClosedInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSale;
        private System.Windows.Forms.TabControl tcSale;
        private System.Windows.Forms.TabPage tpAll;
        private System.Windows.Forms.TabPage tpQuote;
        private System.Windows.Forms.DataGridView dgvAll;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TabPage tpOrder;
        private System.Windows.Forms.TabPage tpOpen;
        private System.Windows.Forms.TabPage tpCreditReturn;
        private System.Windows.Forms.TabPage tpClosed;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.CheckBox chkAllCustomers;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblCustomerSearchCriteria;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.ComboBox cboCustomerSearchCriteria;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DataGridView dgvQuote;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.DataGridView dgvOpenInvoice;
        private System.Windows.Forms.DataGridView dgvCreditReturn;
        private System.Windows.Forms.DataGridView dgvClosedInvoice;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ImageList ilLock;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnDelQuote;
        private System.Windows.Forms.Button btnCreateQuote;
        private System.Windows.Forms.Button btnChangeQuote2Order;
        private System.Windows.Forms.Button btnChangeQuote2OpenInvoice;
        private System.Windows.Forms.Button btnCreatePO;
        private System.Windows.Forms.Button btnDelOrder;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Button btnChangeOrder2OpenInvoice;
        private System.Windows.Forms.Button btnDelOpenInvoice;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
    }
}