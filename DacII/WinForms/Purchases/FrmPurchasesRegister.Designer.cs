namespace DacII.WinForms.Purchases
{
    partial class FrmPurchasesRegister
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPurchasesRegister));
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
            this.tcPurchase = new System.Windows.Forms.TabControl();
            this.tpAll = new System.Windows.Forms.TabPage();
            this.lblCountAll = new System.Windows.Forms.Label();
            this.dgvAll = new System.Windows.Forms.DataGridView();
            this.tpQuote = new System.Windows.Forms.TabPage();
            this.lblCountQuotes = new System.Windows.Forms.Label();
            this.btnDelQuote = new System.Windows.Forms.VistaButton();
            this.btnCreatePO = new System.Windows.Forms.VistaButton();
            this.btnCreateQuote = new System.Windows.Forms.VistaButton();
            this.btnChangeQuote2OpenBill = new System.Windows.Forms.VistaButton();
            this.btnChangeQuote2Order = new System.Windows.Forms.VistaButton();
            this.dgvQuote = new System.Windows.Forms.DataGridView();
            this.tpOrder = new System.Windows.Forms.TabPage();
            this.lblCountOrders = new System.Windows.Forms.Label();
            this.btnCreateOrder = new System.Windows.Forms.VistaButton();
            this.btnChangeOrder2OpenBill = new System.Windows.Forms.VistaButton();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.tpOpen = new System.Windows.Forms.TabPage();
            this.lblCountOpenBills = new System.Windows.Forms.Label();
            this.dgvOpenBill = new System.Windows.Forms.DataGridView();
            this.tpDebitReturn = new System.Windows.Forms.TabPage();
            this.lblCountDebitReturns = new System.Windows.Forms.Label();
            this.dgvDebitReturn = new System.Windows.Forms.DataGridView();
            this.tpClosed = new System.Windows.Forms.TabPage();
            this.lblCountClosedBills = new System.Windows.Forms.Label();
            this.dgvClosedBill = new System.Windows.Forms.DataGridView();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFilter = new System.Windows.Forms.CZRoundedGroupBox();
            this.chkAllSuppliers = new System.Windows.Forms.CheckBox();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblSupplierSearchCriteria = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.cboSupplierSearchCriteria = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.ilLock = new System.Windows.Forms.ImageList(this.components);
            this.czRoundedGroupBox1 = new System.Windows.Forms.CZRoundedGroupBox();
            this.btnClose2 = new System.Windows.Forms.Button();
            this.czRoundedGroupBox2 = new System.Windows.Forms.CZRoundedGroupBox();
            this.btnScanBarcode = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCreateOpenBill = new System.Windows.Forms.VistaButton();
            this.tcPurchase.SuspendLayout();
            this.tpAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAll)).BeginInit();
            this.tpQuote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuote)).BeginInit();
            this.tpOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.tpOpen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpenBill)).BeginInit();
            this.tpDebitReturn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebitReturn)).BeginInit();
            this.tpClosed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClosedBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.gbFilter.SuspendLayout();
            this.czRoundedGroupBox1.SuspendLayout();
            this.czRoundedGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcPurchase
            // 
            this.tcPurchase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcPurchase.Controls.Add(this.tpAll);
            this.tcPurchase.Controls.Add(this.tpQuote);
            this.tcPurchase.Controls.Add(this.tpOrder);
            this.tcPurchase.Controls.Add(this.tpOpen);
            this.tcPurchase.Controls.Add(this.tpDebitReturn);
            this.tcPurchase.Controls.Add(this.tpClosed);
            this.tcPurchase.HotTrack = true;
            this.tcPurchase.Location = new System.Drawing.Point(8, 28);
            this.tcPurchase.Name = "tcPurchase";
            this.tcPurchase.SelectedIndex = 0;
            this.tcPurchase.Size = new System.Drawing.Size(789, 377);
            this.tcPurchase.TabIndex = 0;
            // 
            // tpAll
            // 
            this.tpAll.Controls.Add(this.lblCountAll);
            this.tpAll.Controls.Add(this.dgvAll);
            this.tpAll.Location = new System.Drawing.Point(4, 22);
            this.tpAll.Name = "tpAll";
            this.tpAll.Padding = new System.Windows.Forms.Padding(3);
            this.tpAll.Size = new System.Drawing.Size(781, 351);
            this.tpAll.TabIndex = 0;
            this.tpAll.Text = "All Purchases";
            this.tpAll.UseVisualStyleBackColor = true;
            // 
            // lblCountAll
            // 
            this.lblCountAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCountAll.AutoSize = true;
            this.lblCountAll.Location = new System.Drawing.Point(6, 335);
            this.lblCountAll.Name = "lblCountAll";
            this.lblCountAll.Size = new System.Drawing.Size(35, 13);
            this.lblCountAll.TabIndex = 1;
            this.lblCountAll.Text = "label1";
            // 
            // dgvAll
            // 
            this.dgvAll.AllowUserToAddRows = false;
            this.dgvAll.AllowUserToDeleteRows = false;
            this.dgvAll.AllowUserToOrderColumns = true;
            this.dgvAll.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.dgvAll.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAll.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAll.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAll.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAll.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAll.Location = new System.Drawing.Point(6, 6);
            this.dgvAll.MultiSelect = false;
            this.dgvAll.Name = "dgvAll";
            this.dgvAll.RowHeadersVisible = false;
            this.dgvAll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAll.Size = new System.Drawing.Size(757, 326);
            this.dgvAll.TabIndex = 0;
            this.dgvAll.DoubleClick += new System.EventHandler(this.dgvAll_DoubleClick);
            // 
            // tpQuote
            // 
            this.tpQuote.Controls.Add(this.lblCountQuotes);
            this.tpQuote.Controls.Add(this.btnDelQuote);
            this.tpQuote.Controls.Add(this.btnCreatePO);
            this.tpQuote.Controls.Add(this.btnCreateQuote);
            this.tpQuote.Controls.Add(this.btnChangeQuote2OpenBill);
            this.tpQuote.Controls.Add(this.btnChangeQuote2Order);
            this.tpQuote.Controls.Add(this.dgvQuote);
            this.tpQuote.Location = new System.Drawing.Point(4, 22);
            this.tpQuote.Name = "tpQuote";
            this.tpQuote.Padding = new System.Windows.Forms.Padding(3);
            this.tpQuote.Size = new System.Drawing.Size(781, 351);
            this.tpQuote.TabIndex = 1;
            this.tpQuote.Text = "Purchase Quotes";
            this.tpQuote.UseVisualStyleBackColor = true;
            // 
            // lblCountQuotes
            // 
            this.lblCountQuotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCountQuotes.AutoSize = true;
            this.lblCountQuotes.Location = new System.Drawing.Point(6, 333);
            this.lblCountQuotes.Name = "lblCountQuotes";
            this.lblCountQuotes.Size = new System.Drawing.Size(35, 13);
            this.lblCountQuotes.TabIndex = 10;
            this.lblCountQuotes.Text = "label1";
            // 
            // btnDelQuote
            // 
            this.btnDelQuote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelQuote.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelQuote.BackgroundImage = global::DacII.Properties.Resources.btnback;
            this.btnDelQuote.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelQuote.BaseColor = System.Drawing.Color.SteelBlue;
            this.btnDelQuote.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnDelQuote.ButtonText = "Delete Quote";
            this.btnDelQuote.CornerRadius = 16;
            this.btnDelQuote.Image = global::DacII.Properties.Resources.delete_24x24;
            this.btnDelQuote.Location = new System.Drawing.Point(66, 309);
            this.btnDelQuote.Name = "btnDelQuote";
            this.btnDelQuote.Size = new System.Drawing.Size(134, 37);
            this.btnDelQuote.TabIndex = 9;
            this.btnDelQuote.Click += new System.EventHandler(this.DeleteQuote);
            // 
            // btnCreatePO
            // 
            this.btnCreatePO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreatePO.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCreatePO.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCreatePO.BackgroundImage")));
            this.btnCreatePO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCreatePO.BaseColor = System.Drawing.Color.SteelBlue;
            this.btnCreatePO.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnCreatePO.ButtonText = "Create PO";
            this.btnCreatePO.CornerRadius = 16;
            this.btnCreatePO.Image = global::DacII.Properties.Resources.new_16x16;
            this.btnCreatePO.Location = new System.Drawing.Point(206, 309);
            this.btnCreatePO.Name = "btnCreatePO";
            this.btnCreatePO.Size = new System.Drawing.Size(114, 37);
            this.btnCreatePO.TabIndex = 8;
            // 
            // btnCreateQuote
            // 
            this.btnCreateQuote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateQuote.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCreateQuote.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCreateQuote.BackgroundImage")));
            this.btnCreateQuote.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCreateQuote.BaseColor = System.Drawing.Color.SteelBlue;
            this.btnCreateQuote.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnCreateQuote.ButtonText = "Create Quote";
            this.btnCreateQuote.CornerRadius = 16;
            this.btnCreateQuote.Image = global::DacII.Properties.Resources.new_16x16;
            this.btnCreateQuote.Location = new System.Drawing.Point(326, 309);
            this.btnCreateQuote.Name = "btnCreateQuote";
            this.btnCreateQuote.Size = new System.Drawing.Size(114, 37);
            this.btnCreateQuote.TabIndex = 8;
            this.btnCreateQuote.Click += new System.EventHandler(this.CreatePurchaseQuote);
            // 
            // btnChangeQuote2OpenBill
            // 
            this.btnChangeQuote2OpenBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeQuote2OpenBill.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnChangeQuote2OpenBill.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnChangeQuote2OpenBill.BackgroundImage")));
            this.btnChangeQuote2OpenBill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChangeQuote2OpenBill.BaseColor = System.Drawing.Color.SteelBlue;
            this.btnChangeQuote2OpenBill.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnChangeQuote2OpenBill.ButtonText = "Change to Bill";
            this.btnChangeQuote2OpenBill.CornerRadius = 16;
            this.btnChangeQuote2OpenBill.Image = global::DacII.Properties.Resources.edit_24x24;
            this.btnChangeQuote2OpenBill.Location = new System.Drawing.Point(623, 309);
            this.btnChangeQuote2OpenBill.Name = "btnChangeQuote2OpenBill";
            this.btnChangeQuote2OpenBill.Size = new System.Drawing.Size(152, 37);
            this.btnChangeQuote2OpenBill.TabIndex = 7;
            this.btnChangeQuote2OpenBill.Click += new System.EventHandler(this.ChangeQuote2OpenBill);
            // 
            // btnChangeQuote2Order
            // 
            this.btnChangeQuote2Order.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeQuote2Order.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnChangeQuote2Order.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnChangeQuote2Order.BackgroundImage")));
            this.btnChangeQuote2Order.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChangeQuote2Order.BaseColor = System.Drawing.Color.SteelBlue;
            this.btnChangeQuote2Order.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnChangeQuote2Order.ButtonText = "Change to Order";
            this.btnChangeQuote2Order.CornerRadius = 16;
            this.btnChangeQuote2Order.Image = global::DacII.Properties.Resources.edit_24x24;
            this.btnChangeQuote2Order.Location = new System.Drawing.Point(446, 309);
            this.btnChangeQuote2Order.Name = "btnChangeQuote2Order";
            this.btnChangeQuote2Order.Size = new System.Drawing.Size(171, 37);
            this.btnChangeQuote2Order.TabIndex = 7;
            this.btnChangeQuote2Order.Click += new System.EventHandler(this.ChangeQuote2Order);
            // 
            // dgvQuote
            // 
            this.dgvQuote.AllowUserToAddRows = false;
            this.dgvQuote.AllowUserToDeleteRows = false;
            this.dgvQuote.AllowUserToOrderColumns = true;
            this.dgvQuote.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.dgvQuote.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvQuote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQuote.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvQuote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQuote.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvQuote.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvQuote.Location = new System.Drawing.Point(6, 6);
            this.dgvQuote.MultiSelect = false;
            this.dgvQuote.Name = "dgvQuote";
            this.dgvQuote.RowHeadersVisible = false;
            this.dgvQuote.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuote.Size = new System.Drawing.Size(769, 297);
            this.dgvQuote.TabIndex = 1;
            this.dgvQuote.DoubleClick += new System.EventHandler(this.dgvQuote_DoubleClick);
            // 
            // tpOrder
            // 
            this.tpOrder.Controls.Add(this.lblCountOrders);
            this.tpOrder.Controls.Add(this.btnCreateOrder);
            this.tpOrder.Controls.Add(this.btnChangeOrder2OpenBill);
            this.tpOrder.Controls.Add(this.dgvOrder);
            this.tpOrder.Location = new System.Drawing.Point(4, 22);
            this.tpOrder.Name = "tpOrder";
            this.tpOrder.Size = new System.Drawing.Size(781, 351);
            this.tpOrder.TabIndex = 2;
            this.tpOrder.Text = "Purchase Orders";
            this.tpOrder.UseVisualStyleBackColor = true;
            // 
            // lblCountOrders
            // 
            this.lblCountOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCountOrders.AutoSize = true;
            this.lblCountOrders.Location = new System.Drawing.Point(3, 333);
            this.lblCountOrders.Name = "lblCountOrders";
            this.lblCountOrders.Size = new System.Drawing.Size(35, 13);
            this.lblCountOrders.TabIndex = 13;
            this.lblCountOrders.Text = "label1";
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateOrder.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCreateOrder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCreateOrder.BackgroundImage")));
            this.btnCreateOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCreateOrder.BaseColor = System.Drawing.Color.SteelBlue;
            this.btnCreateOrder.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnCreateOrder.ButtonText = "Create Order";
            this.btnCreateOrder.CornerRadius = 16;
            this.btnCreateOrder.Image = global::DacII.Properties.Resources.new_16x16;
            this.btnCreateOrder.Location = new System.Drawing.Point(518, 309);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(114, 37);
            this.btnCreateOrder.TabIndex = 12;
            this.btnCreateOrder.Click += new System.EventHandler(this.CreatePurchaseOrder);
            // 
            // btnChangeOrder2OpenBill
            // 
            this.btnChangeOrder2OpenBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeOrder2OpenBill.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnChangeOrder2OpenBill.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnChangeOrder2OpenBill.BackgroundImage")));
            this.btnChangeOrder2OpenBill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChangeOrder2OpenBill.BaseColor = System.Drawing.Color.SteelBlue;
            this.btnChangeOrder2OpenBill.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnChangeOrder2OpenBill.ButtonText = "Change to Bill";
            this.btnChangeOrder2OpenBill.CornerRadius = 16;
            this.btnChangeOrder2OpenBill.Image = global::DacII.Properties.Resources.edit_24x24;
            this.btnChangeOrder2OpenBill.Location = new System.Drawing.Point(638, 309);
            this.btnChangeOrder2OpenBill.Name = "btnChangeOrder2OpenBill";
            this.btnChangeOrder2OpenBill.Size = new System.Drawing.Size(140, 37);
            this.btnChangeOrder2OpenBill.TabIndex = 10;
            this.btnChangeOrder2OpenBill.Click += new System.EventHandler(this.ChangeOrder2OpenBill);
            // 
            // dgvOrder
            // 
            this.dgvOrder.AllowUserToAddRows = false;
            this.dgvOrder.AllowUserToDeleteRows = false;
            this.dgvOrder.AllowUserToOrderColumns = true;
            this.dgvOrder.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.dgvOrder.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrder.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvOrder.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvOrder.Location = new System.Drawing.Point(6, 6);
            this.dgvOrder.MultiSelect = false;
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.RowHeadersVisible = false;
            this.dgvOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrder.Size = new System.Drawing.Size(772, 297);
            this.dgvOrder.TabIndex = 1;
            this.dgvOrder.DoubleClick += new System.EventHandler(this.dgvOrder_DoubleClick);
            // 
            // tpOpen
            // 
            this.tpOpen.Controls.Add(this.btnCreateOpenBill);
            this.tpOpen.Controls.Add(this.lblCountOpenBills);
            this.tpOpen.Controls.Add(this.dgvOpenBill);
            this.tpOpen.Location = new System.Drawing.Point(4, 22);
            this.tpOpen.Name = "tpOpen";
            this.tpOpen.Size = new System.Drawing.Size(781, 351);
            this.tpOpen.TabIndex = 3;
            this.tpOpen.Text = "Open Bills";
            this.tpOpen.UseVisualStyleBackColor = true;
            // 
            // lblCountOpenBills
            // 
            this.lblCountOpenBills.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCountOpenBills.AutoSize = true;
            this.lblCountOpenBills.Location = new System.Drawing.Point(3, 331);
            this.lblCountOpenBills.Name = "lblCountOpenBills";
            this.lblCountOpenBills.Size = new System.Drawing.Size(35, 13);
            this.lblCountOpenBills.TabIndex = 2;
            this.lblCountOpenBills.Text = "label1";
            // 
            // dgvOpenBill
            // 
            this.dgvOpenBill.AllowUserToAddRows = false;
            this.dgvOpenBill.AllowUserToDeleteRows = false;
            this.dgvOpenBill.AllowUserToOrderColumns = true;
            this.dgvOpenBill.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.dgvOpenBill.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvOpenBill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOpenBill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOpenBill.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOpenBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOpenBill.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvOpenBill.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvOpenBill.Location = new System.Drawing.Point(6, 6);
            this.dgvOpenBill.MultiSelect = false;
            this.dgvOpenBill.Name = "dgvOpenBill";
            this.dgvOpenBill.RowHeadersVisible = false;
            this.dgvOpenBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOpenBill.Size = new System.Drawing.Size(772, 295);
            this.dgvOpenBill.TabIndex = 1;
            this.dgvOpenBill.DoubleClick += new System.EventHandler(this.dgvOpenBill_DoubleClick);
            // 
            // tpDebitReturn
            // 
            this.tpDebitReturn.Controls.Add(this.lblCountDebitReturns);
            this.tpDebitReturn.Controls.Add(this.dgvDebitReturn);
            this.tpDebitReturn.Location = new System.Drawing.Point(4, 22);
            this.tpDebitReturn.Name = "tpDebitReturn";
            this.tpDebitReturn.Size = new System.Drawing.Size(781, 351);
            this.tpDebitReturn.TabIndex = 5;
            this.tpDebitReturn.Text = "Debit Returns";
            this.tpDebitReturn.UseVisualStyleBackColor = true;
            // 
            // lblCountDebitReturns
            // 
            this.lblCountDebitReturns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCountDebitReturns.AutoSize = true;
            this.lblCountDebitReturns.Location = new System.Drawing.Point(8, 333);
            this.lblCountDebitReturns.Name = "lblCountDebitReturns";
            this.lblCountDebitReturns.Size = new System.Drawing.Size(35, 13);
            this.lblCountDebitReturns.TabIndex = 2;
            this.lblCountDebitReturns.Text = "label1";
            // 
            // dgvDebitReturn
            // 
            this.dgvDebitReturn.AllowUserToAddRows = false;
            this.dgvDebitReturn.AllowUserToDeleteRows = false;
            this.dgvDebitReturn.AllowUserToOrderColumns = true;
            this.dgvDebitReturn.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.dgvDebitReturn.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDebitReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDebitReturn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDebitReturn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDebitReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDebitReturn.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvDebitReturn.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDebitReturn.Location = new System.Drawing.Point(6, 6);
            this.dgvDebitReturn.MultiSelect = false;
            this.dgvDebitReturn.Name = "dgvDebitReturn";
            this.dgvDebitReturn.RowHeadersVisible = false;
            this.dgvDebitReturn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDebitReturn.Size = new System.Drawing.Size(772, 318);
            this.dgvDebitReturn.TabIndex = 1;
            this.dgvDebitReturn.DoubleClick += new System.EventHandler(this.dgvDebitReturn_DoubleClick);
            // 
            // tpClosed
            // 
            this.tpClosed.Controls.Add(this.lblCountClosedBills);
            this.tpClosed.Controls.Add(this.dgvClosedBill);
            this.tpClosed.Location = new System.Drawing.Point(4, 22);
            this.tpClosed.Name = "tpClosed";
            this.tpClosed.Size = new System.Drawing.Size(781, 351);
            this.tpClosed.TabIndex = 4;
            this.tpClosed.Text = "Closed Bills";
            this.tpClosed.UseVisualStyleBackColor = true;
            // 
            // lblCountClosedBills
            // 
            this.lblCountClosedBills.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCountClosedBills.AutoSize = true;
            this.lblCountClosedBills.Location = new System.Drawing.Point(10, 333);
            this.lblCountClosedBills.Name = "lblCountClosedBills";
            this.lblCountClosedBills.Size = new System.Drawing.Size(35, 13);
            this.lblCountClosedBills.TabIndex = 2;
            this.lblCountClosedBills.Text = "label1";
            // 
            // dgvClosedBill
            // 
            this.dgvClosedBill.AllowUserToAddRows = false;
            this.dgvClosedBill.AllowUserToDeleteRows = false;
            this.dgvClosedBill.AllowUserToOrderColumns = true;
            this.dgvClosedBill.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.dgvClosedBill.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvClosedBill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClosedBill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClosedBill.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvClosedBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClosedBill.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvClosedBill.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvClosedBill.Location = new System.Drawing.Point(6, 6);
            this.dgvClosedBill.MultiSelect = false;
            this.dgvClosedBill.Name = "dgvClosedBill";
            this.dgvClosedBill.RowHeadersVisible = false;
            this.dgvClosedBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClosedBill.Size = new System.Drawing.Size(772, 324);
            this.dgvClosedBill.TabIndex = 1;
            this.dgvClosedBill.DoubleClick += new System.EventHandler(this.dgvClosedBill_DoubleClick);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // gbFilter
            // 
            this.gbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
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
            this.gbFilter.Controls.Add(this.chkAllSuppliers);
            this.gbFilter.Controls.Add(this.lblEndDate);
            this.gbFilter.Controls.Add(this.lblSupplierSearchCriteria);
            this.gbFilter.Controls.Add(this.lblStartDate);
            this.gbFilter.Controls.Add(this.dtpEndDate);
            this.gbFilter.Controls.Add(this.cboSupplierSearchCriteria);
            this.gbFilter.Controls.Add(this.dtpStartDate);
            this.gbFilter.CornerRadius = 5;
            this.gbFilter.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbFilter.DropShadowThickness = 3;
            this.gbFilter.DropShadowVisible = true;
            this.gbFilter.Location = new System.Drawing.Point(6, 438);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(629, 75);
            this.gbFilter.TabIndex = 3;
            this.gbFilter.TabStop = false;
            // 
            // chkAllSuppliers
            // 
            this.chkAllSuppliers.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAllSuppliers.AutoSize = true;
            this.chkAllSuppliers.BackColor = System.Drawing.Color.Transparent;
            this.chkAllSuppliers.FlatAppearance.BorderSize = 0;
            this.chkAllSuppliers.Location = new System.Drawing.Point(16, 37);
            this.chkAllSuppliers.Name = "chkAllSuppliers";
            this.chkAllSuppliers.Size = new System.Drawing.Size(74, 23);
            this.chkAllSuppliers.TabIndex = 14;
            this.chkAllSuppliers.Text = "All Suppliers";
            this.chkAllSuppliers.UseVisualStyleBackColor = false;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.BackColor = System.Drawing.Color.Transparent;
            this.lblEndDate.Location = new System.Drawing.Point(501, 7);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(20, 13);
            this.lblEndDate.TabIndex = 12;
            this.lblEndDate.Text = "To";
            // 
            // lblSupplierSearchCriteria
            // 
            this.lblSupplierSearchCriteria.AutoSize = true;
            this.lblSupplierSearchCriteria.BackColor = System.Drawing.Color.Transparent;
            this.lblSupplierSearchCriteria.Location = new System.Drawing.Point(12, 7);
            this.lblSupplierSearchCriteria.Name = "lblSupplierSearchCriteria";
            this.lblSupplierSearchCriteria.Size = new System.Drawing.Size(48, 13);
            this.lblSupplierSearchCriteria.TabIndex = 11;
            this.lblSupplierSearchCriteria.Text = "Supplier:";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.BackColor = System.Drawing.Color.Transparent;
            this.lblStartDate.Location = new System.Drawing.Point(394, 7);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(30, 13);
            this.lblStartDate.TabIndex = 11;
            this.lblStartDate.Text = "From";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(504, 38);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(97, 20);
            this.dtpEndDate.TabIndex = 9;
            // 
            // cboSupplierSearchCriteria
            // 
            this.cboSupplierSearchCriteria.FormattingEnabled = true;
            this.cboSupplierSearchCriteria.Location = new System.Drawing.Point(98, 37);
            this.cboSupplierSearchCriteria.Name = "cboSupplierSearchCriteria";
            this.cboSupplierSearchCriteria.Size = new System.Drawing.Size(264, 21);
            this.cboSupplierSearchCriteria.TabIndex = 2;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(397, 38);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(101, 20);
            this.dtpStartDate.TabIndex = 10;
            // 
            // ilLock
            // 
            this.ilLock.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilLock.ImageStream")));
            this.ilLock.TransparentColor = System.Drawing.Color.Transparent;
            this.ilLock.Images.SetKeyName(0, "locked.png");
            this.ilLock.Images.SetKeyName(1, "unlocked.png");
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
            this.czRoundedGroupBox1.Caption = "Purchases --> Purchase Registers";
            this.czRoundedGroupBox1.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.czRoundedGroupBox1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.czRoundedGroupBox1.CaptionHeight = 25;
            this.czRoundedGroupBox1.CaptionVisible = true;
            this.czRoundedGroupBox1.Controls.Add(this.btnClose2);
            this.czRoundedGroupBox1.Controls.Add(this.tcPurchase);
            this.czRoundedGroupBox1.CornerRadius = 5;
            this.czRoundedGroupBox1.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.czRoundedGroupBox1.DropShadowThickness = 3;
            this.czRoundedGroupBox1.DropShadowVisible = true;
            this.czRoundedGroupBox1.Location = new System.Drawing.Point(6, 9);
            this.czRoundedGroupBox1.Name = "czRoundedGroupBox1";
            this.czRoundedGroupBox1.Size = new System.Drawing.Size(814, 423);
            this.czRoundedGroupBox1.TabIndex = 4;
            // 
            // btnClose2
            // 
            this.btnClose2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose2.BackgroundImage = global::DacII.Properties.Resources.cancel_16x16;
            this.btnClose2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose2.FlatAppearance.BorderSize = 0;
            this.btnClose2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose2.Location = new System.Drawing.Point(782, 4);
            this.btnClose2.Name = "btnClose2";
            this.btnClose2.Size = new System.Drawing.Size(16, 16);
            this.btnClose2.TabIndex = 94;
            this.btnClose2.UseVisualStyleBackColor = false;
            this.btnClose2.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // czRoundedGroupBox2
            // 
            this.czRoundedGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.czRoundedGroupBox2.BackgroundColor = System.Drawing.Color.White;
            this.czRoundedGroupBox2.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.czRoundedGroupBox2.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.czRoundedGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.czRoundedGroupBox2.BorderWidth = 1F;
            this.czRoundedGroupBox2.Caption = "";
            this.czRoundedGroupBox2.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.czRoundedGroupBox2.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.czRoundedGroupBox2.CaptionHeight = 25;
            this.czRoundedGroupBox2.CaptionVisible = true;
            this.czRoundedGroupBox2.Controls.Add(this.btnScanBarcode);
            this.czRoundedGroupBox2.Controls.Add(this.btnPrint);
            this.czRoundedGroupBox2.Controls.Add(this.btnRefresh);
            this.czRoundedGroupBox2.Controls.Add(this.btnClose);
            this.czRoundedGroupBox2.CornerRadius = 5;
            this.czRoundedGroupBox2.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.czRoundedGroupBox2.DropShadowThickness = 3;
            this.czRoundedGroupBox2.DropShadowVisible = true;
            this.czRoundedGroupBox2.Location = new System.Drawing.Point(641, 438);
            this.czRoundedGroupBox2.Name = "czRoundedGroupBox2";
            this.czRoundedGroupBox2.Size = new System.Drawing.Size(179, 75);
            this.czRoundedGroupBox2.TabIndex = 5;
            // 
            // btnScanBarcode
            // 
            this.btnScanBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScanBarcode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnScanBarcode.BackgroundImage = global::DacII.Properties.Resources.barcode_48x48;
            this.btnScanBarcode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnScanBarcode.FlatAppearance.BorderSize = 0;
            this.btnScanBarcode.Location = new System.Drawing.Point(15, 30);
            this.btnScanBarcode.Name = "btnScanBarcode";
            this.btnScanBarcode.Size = new System.Drawing.Size(32, 32);
            this.btnScanBarcode.TabIndex = 93;
            this.btnScanBarcode.UseVisualStyleBackColor = false;
            this.btnScanBarcode.Click += new System.EventHandler(this.btnScanBarcode_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrint.BackgroundImage = global::DacII.Properties.Resources.print_32x32;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.Location = new System.Drawing.Point(91, 30);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(32, 32);
            this.btnPrint.TabIndex = 92;
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.BackgroundImage = global::DacII.Properties.Resources.reset_16x16;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Location = new System.Drawing.Point(53, 31);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(32, 32);
            this.btnRefresh.TabIndex = 30;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.BackgroundImage = global::DacII.Properties.Resources.cancel_16x16;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Location = new System.Drawing.Point(129, 30);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 32);
            this.btnClose.TabIndex = 91;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCreateOpenBill
            // 
            this.btnCreateOpenBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateOpenBill.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCreateOpenBill.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCreateOpenBill.BackgroundImage")));
            this.btnCreateOpenBill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCreateOpenBill.BaseColor = System.Drawing.Color.SteelBlue;
            this.btnCreateOpenBill.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnCreateOpenBill.ButtonText = "Create Bill";
            this.btnCreateOpenBill.CornerRadius = 16;
            this.btnCreateOpenBill.Image = global::DacII.Properties.Resources.new_16x16;
            this.btnCreateOpenBill.Location = new System.Drawing.Point(664, 307);
            this.btnCreateOpenBill.Name = "btnCreateOpenBill";
            this.btnCreateOpenBill.Size = new System.Drawing.Size(114, 37);
            this.btnCreateOpenBill.TabIndex = 13;
            this.btnCreateOpenBill.Click += new System.EventHandler(this.CreateOpenBill);
            // 
            // FrmPurchasesRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(825, 516);
            this.Controls.Add(this.czRoundedGroupBox2);
            this.Controls.Add(this.czRoundedGroupBox1);
            this.Controls.Add(this.gbFilter);
            this.Name = "FrmPurchasesRegister";
            this.Text = "Purchase Register";
            this.tcPurchase.ResumeLayout(false);
            this.tpAll.ResumeLayout(false);
            this.tpAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAll)).EndInit();
            this.tpQuote.ResumeLayout(false);
            this.tpQuote.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuote)).EndInit();
            this.tpOrder.ResumeLayout(false);
            this.tpOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.tpOpen.ResumeLayout(false);
            this.tpOpen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpenBill)).EndInit();
            this.tpDebitReturn.ResumeLayout(false);
            this.tpDebitReturn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebitReturn)).EndInit();
            this.tpClosed.ResumeLayout(false);
            this.tpClosed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClosedBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.czRoundedGroupBox1.ResumeLayout(false);
            this.czRoundedGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcPurchase;
        private System.Windows.Forms.TabPage tpAll;
        private System.Windows.Forms.TabPage tpQuote;
        private System.Windows.Forms.DataGridView dgvAll;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TabPage tpOrder;
        private System.Windows.Forms.TabPage tpOpen;
        private System.Windows.Forms.TabPage tpDebitReturn;
        private System.Windows.Forms.TabPage tpClosed;
        private System.Windows.Forms.CZRoundedGroupBox gbFilter;
        private System.Windows.Forms.CheckBox chkAllSuppliers;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblSupplierSearchCriteria;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.ComboBox cboSupplierSearchCriteria;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DataGridView dgvQuote;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.DataGridView dgvOpenBill;
        private System.Windows.Forms.DataGridView dgvDebitReturn;
        private System.Windows.Forms.DataGridView dgvClosedBill;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ImageList ilLock;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.VistaButton btnCreateQuote;
        private System.Windows.Forms.VistaButton btnChangeQuote2Order;
        private System.Windows.Forms.VistaButton btnChangeQuote2OpenBill;
        private System.Windows.Forms.VistaButton btnCreatePO;
        private System.Windows.Forms.VistaButton btnCreateOrder;
        private System.Windows.Forms.Button btnScanBarcode;
        private System.Windows.Forms.VistaButton btnChangeOrder2OpenBill;
        private System.Windows.Forms.CZRoundedGroupBox czRoundedGroupBox1;
        private System.Windows.Forms.CZRoundedGroupBox czRoundedGroupBox2;
        private System.Windows.Forms.VistaButton btnDelQuote;
        private System.Windows.Forms.Label lblCountAll;
        private System.Windows.Forms.Label lblCountQuotes;
        private System.Windows.Forms.Label lblCountOrders;
        private System.Windows.Forms.Label lblCountOpenBills;
        private System.Windows.Forms.Label lblCountDebitReturns;
        private System.Windows.Forms.Label lblCountClosedBills;
        private System.Windows.Forms.Button btnClose2;
        private System.Windows.Forms.VistaButton btnCreateOpenBill;
    }
}