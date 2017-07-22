namespace DacII.WinForms.Sales
{
    partial class FrmSalesRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSalesRegister));
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFilter = new System.Windows.Forms.CZRoundedGroupBox();
            this.btnClose2 = new System.Windows.Forms.Button();
            this.tcSale = new System.Windows.Forms.TabControl();
            this.tpAll = new System.Windows.Forms.TabPage();
            this.lblCountAll = new System.Windows.Forms.Label();
            this.dgvAll = new System.Windows.Forms.DataGridView();
            this.tpQuote = new System.Windows.Forms.TabPage();
            this.lblCountQuotes = new System.Windows.Forms.Label();
            this.btnDelQuote = new System.Windows.Forms.VistaButton();
            this.btnCreatePO = new System.Windows.Forms.VistaButton();
            this.btnCreateQuote = new System.Windows.Forms.VistaButton();
            this.btnChangeQuote2OpenInvoice = new System.Windows.Forms.VistaButton();
            this.btnChangeQuote2Order = new System.Windows.Forms.VistaButton();
            this.dgvQuote = new System.Windows.Forms.DataGridView();
            this.tpOrder = new System.Windows.Forms.TabPage();
            this.lblCountOrders = new System.Windows.Forms.Label();
            this.btnCreateOrder = new System.Windows.Forms.VistaButton();
            this.btnChangeOrder2OpenInvoice = new System.Windows.Forms.VistaButton();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.tpOpen = new System.Windows.Forms.TabPage();
            this.lblCountOpenInvoices = new System.Windows.Forms.Label();
            this.btnCreateOpenInvoice = new System.Windows.Forms.VistaButton();
            this.dgvOpenInvoice = new System.Windows.Forms.DataGridView();
            this.tpCreditReturn = new System.Windows.Forms.TabPage();
            this.lblCountCreditReturns = new System.Windows.Forms.Label();
            this.dgvCreditReturn = new System.Windows.Forms.DataGridView();
            this.tpClosed = new System.Windows.Forms.TabPage();
            this.lblCountClosedInvoices = new System.Windows.Forms.Label();
            this.dgvClosedInvoice = new System.Windows.Forms.DataGridView();
            this.btnScanBarcode = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.chkAllCustomers = new System.Windows.Forms.CheckBox();
            this.ilLock = new System.Windows.Forms.ImageList(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblCustomerSearchCriteria = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.cboCustomerSearchCriteria = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.czRoundedGroupBox1 = new System.Windows.Forms.CZRoundedGroupBox();
            this.czRoundedGroupBox2 = new System.Windows.Forms.CZRoundedGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.gbFilter.SuspendLayout();
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
            this.czRoundedGroupBox1.SuspendLayout();
            this.czRoundedGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // gbFilter
            // 
            this.gbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFilter.BackgroundColor = System.Drawing.Color.White;
            this.gbFilter.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbFilter.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbFilter.BorderWidth = 1F;
            this.gbFilter.Caption = "Sales --> Sales Register";
            this.gbFilter.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbFilter.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbFilter.CaptionHeight = 25;
            this.gbFilter.CaptionVisible = true;
            this.gbFilter.Controls.Add(this.btnClose2);
            this.gbFilter.Controls.Add(this.tcSale);
            this.gbFilter.CornerRadius = 5;
            this.gbFilter.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbFilter.DropShadowThickness = 3;
            this.gbFilter.DropShadowVisible = true;
            this.gbFilter.Location = new System.Drawing.Point(4, 5);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(791, 377);
            this.gbFilter.TabIndex = 3;
            this.gbFilter.TabStop = false;
            // 
            // btnClose2
            // 
            this.btnClose2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose2.BackgroundImage = global::DacII.Properties.Resources.cancel_16x16;
            this.btnClose2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose2.FlatAppearance.BorderSize = 0;
            this.btnClose2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose2.Location = new System.Drawing.Point(759, 5);
            this.btnClose2.Name = "btnClose2";
            this.btnClose2.Size = new System.Drawing.Size(16, 16);
            this.btnClose2.TabIndex = 94;
            this.btnClose2.UseVisualStyleBackColor = false;
            this.btnClose2.Click += new System.EventHandler(this.btnClose_Click);
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
            this.tcSale.HotTrack = true;
            this.tcSale.Location = new System.Drawing.Point(8, 27);
            this.tcSale.Name = "tcSale";
            this.tcSale.SelectedIndex = 0;
            this.tcSale.Size = new System.Drawing.Size(766, 337);
            this.tcSale.TabIndex = 0;
            // 
            // tpAll
            // 
            this.tpAll.Controls.Add(this.lblCountAll);
            this.tpAll.Controls.Add(this.dgvAll);
            this.tpAll.Location = new System.Drawing.Point(4, 22);
            this.tpAll.Name = "tpAll";
            this.tpAll.Padding = new System.Windows.Forms.Padding(3);
            this.tpAll.Size = new System.Drawing.Size(758, 311);
            this.tpAll.TabIndex = 0;
            this.tpAll.Text = "All Sales";
            this.tpAll.UseVisualStyleBackColor = true;
            // 
            // lblCountAll
            // 
            this.lblCountAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCountAll.AutoSize = true;
            this.lblCountAll.Location = new System.Drawing.Point(3, 295);
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
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvAll.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAll.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAll.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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
            this.dgvAll.Location = new System.Drawing.Point(3, 6);
            this.dgvAll.MultiSelect = false;
            this.dgvAll.Name = "dgvAll";
            this.dgvAll.RowHeadersVisible = false;
            this.dgvAll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAll.Size = new System.Drawing.Size(747, 286);
            this.dgvAll.TabIndex = 0;
            this.dgvAll.DoubleClick += new System.EventHandler(this.OpenFrom_AllSales);
            // 
            // tpQuote
            // 
            this.tpQuote.Controls.Add(this.lblCountQuotes);
            this.tpQuote.Controls.Add(this.btnDelQuote);
            this.tpQuote.Controls.Add(this.btnCreatePO);
            this.tpQuote.Controls.Add(this.btnCreateQuote);
            this.tpQuote.Controls.Add(this.btnChangeQuote2OpenInvoice);
            this.tpQuote.Controls.Add(this.btnChangeQuote2Order);
            this.tpQuote.Controls.Add(this.dgvQuote);
            this.tpQuote.Location = new System.Drawing.Point(4, 22);
            this.tpQuote.Name = "tpQuote";
            this.tpQuote.Padding = new System.Windows.Forms.Padding(3);
            this.tpQuote.Size = new System.Drawing.Size(758, 311);
            this.tpQuote.TabIndex = 1;
            this.tpQuote.Text = "Sale Quotes";
            this.tpQuote.UseVisualStyleBackColor = true;
            // 
            // lblCountQuotes
            // 
            this.lblCountQuotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCountQuotes.AutoSize = true;
            this.lblCountQuotes.Location = new System.Drawing.Point(9, 289);
            this.lblCountQuotes.Name = "lblCountQuotes";
            this.lblCountQuotes.Size = new System.Drawing.Size(35, 13);
            this.lblCountQuotes.TabIndex = 10;
            this.lblCountQuotes.Text = "label1";
            // 
            // btnDelQuote
            // 
            this.btnDelQuote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelQuote.BackColor = System.Drawing.Color.Transparent;
            this.btnDelQuote.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelQuote.BaseColor = System.Drawing.Color.SteelBlue;
            this.btnDelQuote.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnDelQuote.ButtonText = " Delete Quote";
            this.btnDelQuote.CornerRadius = 16;
            this.btnDelQuote.Image = global::DacII.Properties.Resources.delete_24x24;
            this.btnDelQuote.Location = new System.Drawing.Point(48, 269);
            this.btnDelQuote.Name = "btnDelQuote";
            this.btnDelQuote.Size = new System.Drawing.Size(126, 37);
            this.btnDelQuote.TabIndex = 9;
            this.btnDelQuote.Click += new System.EventHandler(this.DeleteQuote);
            // 
            // btnCreatePO
            // 
            this.btnCreatePO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreatePO.BackColor = System.Drawing.Color.Transparent;
            this.btnCreatePO.BaseColor = System.Drawing.Color.SteelBlue;
            this.btnCreatePO.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnCreatePO.ButtonText = "Create PO";
            this.btnCreatePO.CornerRadius = 16;
            this.btnCreatePO.Image = global::DacII.Properties.Resources.new_16x16;
            this.btnCreatePO.Location = new System.Drawing.Point(180, 269);
            this.btnCreatePO.Name = "btnCreatePO";
            this.btnCreatePO.Size = new System.Drawing.Size(114, 37);
            this.btnCreatePO.TabIndex = 8;
            // 
            // btnCreateQuote
            // 
            this.btnCreateQuote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateQuote.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateQuote.BaseColor = System.Drawing.Color.SteelBlue;
            this.btnCreateQuote.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnCreateQuote.ButtonText = "Create Quote";
            this.btnCreateQuote.CornerRadius = 16;
            this.btnCreateQuote.Image = global::DacII.Properties.Resources.new_16x16;
            this.btnCreateQuote.Location = new System.Drawing.Point(300, 269);
            this.btnCreateQuote.Name = "btnCreateQuote";
            this.btnCreateQuote.Size = new System.Drawing.Size(114, 37);
            this.btnCreateQuote.TabIndex = 8;
            this.btnCreateQuote.Click += new System.EventHandler(this.CreateSaleQuote);
            // 
            // btnChangeQuote2OpenInvoice
            // 
            this.btnChangeQuote2OpenInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeQuote2OpenInvoice.BackColor = System.Drawing.Color.Transparent;
            this.btnChangeQuote2OpenInvoice.BaseColor = System.Drawing.Color.SteelBlue;
            this.btnChangeQuote2OpenInvoice.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnChangeQuote2OpenInvoice.ButtonText = "Change to Invoice";
            this.btnChangeQuote2OpenInvoice.CornerRadius = 16;
            this.btnChangeQuote2OpenInvoice.Image = global::DacII.Properties.Resources.edit_24x24;
            this.btnChangeQuote2OpenInvoice.Location = new System.Drawing.Point(584, 269);
            this.btnChangeQuote2OpenInvoice.Name = "btnChangeQuote2OpenInvoice";
            this.btnChangeQuote2OpenInvoice.Size = new System.Drawing.Size(167, 37);
            this.btnChangeQuote2OpenInvoice.TabIndex = 7;
            this.btnChangeQuote2OpenInvoice.Click += new System.EventHandler(this.ChangeOrder2OpenInvoice);
            // 
            // btnChangeQuote2Order
            // 
            this.btnChangeQuote2Order.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeQuote2Order.BackColor = System.Drawing.Color.Transparent;
            this.btnChangeQuote2Order.BaseColor = System.Drawing.Color.SteelBlue;
            this.btnChangeQuote2Order.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnChangeQuote2Order.ButtonText = "Change to Order";
            this.btnChangeQuote2Order.CornerRadius = 16;
            this.btnChangeQuote2Order.Image = global::DacII.Properties.Resources.edit_24x24;
            this.btnChangeQuote2Order.Location = new System.Drawing.Point(420, 269);
            this.btnChangeQuote2Order.Name = "btnChangeQuote2Order";
            this.btnChangeQuote2Order.Size = new System.Drawing.Size(158, 37);
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
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dgvQuote.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvQuote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQuote.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuote.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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
            this.dgvQuote.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvQuote.RowHeadersVisible = false;
            this.dgvQuote.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuote.ShowCellErrors = false;
            this.dgvQuote.ShowCellToolTips = false;
            this.dgvQuote.ShowEditingIcon = false;
            this.dgvQuote.ShowRowErrors = false;
            this.dgvQuote.Size = new System.Drawing.Size(745, 259);
            this.dgvQuote.TabIndex = 1;
            this.dgvQuote.DoubleClick += new System.EventHandler(this.OpenFrom_Quotes);
            // 
            // tpOrder
            // 
            this.tpOrder.Controls.Add(this.lblCountOrders);
            this.tpOrder.Controls.Add(this.btnCreateOrder);
            this.tpOrder.Controls.Add(this.btnChangeOrder2OpenInvoice);
            this.tpOrder.Controls.Add(this.dgvOrder);
            this.tpOrder.Location = new System.Drawing.Point(4, 22);
            this.tpOrder.Name = "tpOrder";
            this.tpOrder.Size = new System.Drawing.Size(758, 311);
            this.tpOrder.TabIndex = 2;
            this.tpOrder.Text = "Sale Orders";
            this.tpOrder.UseVisualStyleBackColor = true;
            // 
            // lblCountOrders
            // 
            this.lblCountOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCountOrders.AutoSize = true;
            this.lblCountOrders.Location = new System.Drawing.Point(3, 295);
            this.lblCountOrders.Name = "lblCountOrders";
            this.lblCountOrders.Size = new System.Drawing.Size(35, 13);
            this.lblCountOrders.TabIndex = 13;
            this.lblCountOrders.Text = "label1";
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateOrder.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateOrder.BaseColor = System.Drawing.Color.SteelBlue;
            this.btnCreateOrder.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnCreateOrder.ButtonText = "Create Order";
            this.btnCreateOrder.CornerRadius = 16;
            this.btnCreateOrder.Image = global::DacII.Properties.Resources.new_16x16;
            this.btnCreateOrder.Location = new System.Drawing.Point(452, 271);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(114, 37);
            this.btnCreateOrder.TabIndex = 12;
            this.btnCreateOrder.Click += new System.EventHandler(this.CreateSaleOrder);
            // 
            // btnChangeOrder2OpenInvoice
            // 
            this.btnChangeOrder2OpenInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeOrder2OpenInvoice.BackColor = System.Drawing.Color.Transparent;
            this.btnChangeOrder2OpenInvoice.BaseColor = System.Drawing.Color.SteelBlue;
            this.btnChangeOrder2OpenInvoice.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnChangeOrder2OpenInvoice.ButtonText = "Change to Invoice";
            this.btnChangeOrder2OpenInvoice.CornerRadius = 16;
            this.btnChangeOrder2OpenInvoice.Image = global::DacII.Properties.Resources.edit_24x24;
            this.btnChangeOrder2OpenInvoice.Location = new System.Drawing.Point(572, 271);
            this.btnChangeOrder2OpenInvoice.Name = "btnChangeOrder2OpenInvoice";
            this.btnChangeOrder2OpenInvoice.Size = new System.Drawing.Size(179, 37);
            this.btnChangeOrder2OpenInvoice.TabIndex = 10;
            this.btnChangeOrder2OpenInvoice.Click += new System.EventHandler(this.ChangeOrder2OpenInvoice);
            // 
            // dgvOrder
            // 
            this.dgvOrder.AllowUserToAddRows = false;
            this.dgvOrder.AllowUserToDeleteRows = false;
            this.dgvOrder.AllowUserToOrderColumns = true;
            this.dgvOrder.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.dgvOrder.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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
            this.dgvOrder.Size = new System.Drawing.Size(745, 264);
            this.dgvOrder.TabIndex = 1;
            this.dgvOrder.DoubleClick += new System.EventHandler(this.OpenFrom_Orders);
            // 
            // tpOpen
            // 
            this.tpOpen.Controls.Add(this.lblCountOpenInvoices);
            this.tpOpen.Controls.Add(this.btnCreateOpenInvoice);
            this.tpOpen.Controls.Add(this.dgvOpenInvoice);
            this.tpOpen.Location = new System.Drawing.Point(4, 22);
            this.tpOpen.Name = "tpOpen";
            this.tpOpen.Size = new System.Drawing.Size(758, 311);
            this.tpOpen.TabIndex = 3;
            this.tpOpen.Text = "Open Invoices";
            this.tpOpen.UseVisualStyleBackColor = true;
            // 
            // lblCountOpenInvoices
            // 
            this.lblCountOpenInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCountOpenInvoices.AutoSize = true;
            this.lblCountOpenInvoices.Location = new System.Drawing.Point(5, 293);
            this.lblCountOpenInvoices.Name = "lblCountOpenInvoices";
            this.lblCountOpenInvoices.Size = new System.Drawing.Size(35, 13);
            this.lblCountOpenInvoices.TabIndex = 13;
            this.lblCountOpenInvoices.Text = "label1";
            // 
            // btnCreateOpenInvoice
            // 
            this.btnCreateOpenInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateOpenInvoice.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateOpenInvoice.BaseColor = System.Drawing.Color.SteelBlue;
            this.btnCreateOpenInvoice.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnCreateOpenInvoice.ButtonText = "Create Invoice";
            this.btnCreateOpenInvoice.CornerRadius = 16;
            this.btnCreateOpenInvoice.Image = global::DacII.Properties.Resources.new_16x16;
            this.btnCreateOpenInvoice.Location = new System.Drawing.Point(617, 269);
            this.btnCreateOpenInvoice.Name = "btnCreateOpenInvoice";
            this.btnCreateOpenInvoice.Size = new System.Drawing.Size(134, 37);
            this.btnCreateOpenInvoice.TabIndex = 12;
            this.btnCreateOpenInvoice.Click += new System.EventHandler(this.CreateSaleOpenInvoice);
            // 
            // dgvOpenInvoice
            // 
            this.dgvOpenInvoice.AllowUserToAddRows = false;
            this.dgvOpenInvoice.AllowUserToDeleteRows = false;
            this.dgvOpenInvoice.AllowUserToOrderColumns = true;
            this.dgvOpenInvoice.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            this.dgvOpenInvoice.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvOpenInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOpenInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOpenInvoice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvOpenInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOpenInvoice.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvOpenInvoice.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvOpenInvoice.Location = new System.Drawing.Point(6, 5);
            this.dgvOpenInvoice.MultiSelect = false;
            this.dgvOpenInvoice.Name = "dgvOpenInvoice";
            this.dgvOpenInvoice.RowHeadersVisible = false;
            this.dgvOpenInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOpenInvoice.Size = new System.Drawing.Size(745, 260);
            this.dgvOpenInvoice.TabIndex = 1;
            this.dgvOpenInvoice.DoubleClick += new System.EventHandler(this.OpenFrom_OpenInvoices);
            // 
            // tpCreditReturn
            // 
            this.tpCreditReturn.Controls.Add(this.lblCountCreditReturns);
            this.tpCreditReturn.Controls.Add(this.dgvCreditReturn);
            this.tpCreditReturn.Location = new System.Drawing.Point(4, 22);
            this.tpCreditReturn.Name = "tpCreditReturn";
            this.tpCreditReturn.Size = new System.Drawing.Size(758, 311);
            this.tpCreditReturn.TabIndex = 5;
            this.tpCreditReturn.Text = "Credit Returns";
            this.tpCreditReturn.UseVisualStyleBackColor = true;
            // 
            // lblCountCreditReturns
            // 
            this.lblCountCreditReturns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCountCreditReturns.AutoSize = true;
            this.lblCountCreditReturns.Location = new System.Drawing.Point(7, 293);
            this.lblCountCreditReturns.Name = "lblCountCreditReturns";
            this.lblCountCreditReturns.Size = new System.Drawing.Size(35, 13);
            this.lblCountCreditReturns.TabIndex = 2;
            this.lblCountCreditReturns.Text = "label1";
            // 
            // dgvCreditReturn
            // 
            this.dgvCreditReturn.AllowUserToAddRows = false;
            this.dgvCreditReturn.AllowUserToDeleteRows = false;
            this.dgvCreditReturn.AllowUserToOrderColumns = true;
            this.dgvCreditReturn.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.dgvCreditReturn.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvCreditReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCreditReturn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCreditReturn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCreditReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCreditReturn.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvCreditReturn.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCreditReturn.Location = new System.Drawing.Point(6, 6);
            this.dgvCreditReturn.MultiSelect = false;
            this.dgvCreditReturn.Name = "dgvCreditReturn";
            this.dgvCreditReturn.RowHeadersVisible = false;
            this.dgvCreditReturn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCreditReturn.Size = new System.Drawing.Size(745, 284);
            this.dgvCreditReturn.TabIndex = 1;
            this.dgvCreditReturn.DoubleClick += new System.EventHandler(this.OpenFrom_CreditReturns);
            // 
            // tpClosed
            // 
            this.tpClosed.Controls.Add(this.lblCountClosedInvoices);
            this.tpClosed.Controls.Add(this.dgvClosedInvoice);
            this.tpClosed.Location = new System.Drawing.Point(4, 22);
            this.tpClosed.Name = "tpClosed";
            this.tpClosed.Size = new System.Drawing.Size(758, 311);
            this.tpClosed.TabIndex = 4;
            this.tpClosed.Text = "Closed Invoices";
            this.tpClosed.UseVisualStyleBackColor = true;
            // 
            // lblCountClosedInvoices
            // 
            this.lblCountClosedInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCountClosedInvoices.AutoSize = true;
            this.lblCountClosedInvoices.Location = new System.Drawing.Point(8, 294);
            this.lblCountClosedInvoices.Name = "lblCountClosedInvoices";
            this.lblCountClosedInvoices.Size = new System.Drawing.Size(35, 13);
            this.lblCountClosedInvoices.TabIndex = 2;
            this.lblCountClosedInvoices.Text = "label1";
            // 
            // dgvClosedInvoice
            // 
            this.dgvClosedInvoice.AllowUserToAddRows = false;
            this.dgvClosedInvoice.AllowUserToDeleteRows = false;
            this.dgvClosedInvoice.AllowUserToOrderColumns = true;
            this.dgvClosedInvoice.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.dgvClosedInvoice.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvClosedInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClosedInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClosedInvoice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvClosedInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClosedInvoice.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvClosedInvoice.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvClosedInvoice.Location = new System.Drawing.Point(6, 6);
            this.dgvClosedInvoice.MultiSelect = false;
            this.dgvClosedInvoice.Name = "dgvClosedInvoice";
            this.dgvClosedInvoice.RowHeadersVisible = false;
            this.dgvClosedInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClosedInvoice.Size = new System.Drawing.Size(749, 278);
            this.dgvClosedInvoice.TabIndex = 1;
            this.dgvClosedInvoice.DoubleClick += new System.EventHandler(this.OpenFrom_ClosedInvoices);
            // 
            // btnScanBarcode
            // 
            this.btnScanBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScanBarcode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnScanBarcode.BackgroundImage = global::DacII.Properties.Resources.barcode_48x48;
            this.btnScanBarcode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnScanBarcode.FlatAppearance.BorderSize = 0;
            this.btnScanBarcode.Location = new System.Drawing.Point(15, 29);
            this.btnScanBarcode.Name = "btnScanBarcode";
            this.btnScanBarcode.Size = new System.Drawing.Size(32, 32);
            this.btnScanBarcode.TabIndex = 30;
            this.btnScanBarcode.UseVisualStyleBackColor = false;
            this.btnScanBarcode.Click += new System.EventHandler(this.btnScanBarcode_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRefresh.BackgroundImage = global::DacII.Properties.Resources.reset_16x16;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Location = new System.Drawing.Point(53, 29);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(32, 32);
            this.btnRefresh.TabIndex = 30;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.Location = new System.Drawing.Point(91, 29);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(32, 32);
            this.btnPrint.TabIndex = 92;
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // chkAllCustomers
            // 
            this.chkAllCustomers.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAllCustomers.AutoSize = true;
            this.chkAllCustomers.BackColor = System.Drawing.Color.Transparent;
            this.chkAllCustomers.FlatAppearance.BorderSize = 0;
            this.chkAllCustomers.Location = new System.Drawing.Point(19, 34);
            this.chkAllCustomers.Name = "chkAllCustomers";
            this.chkAllCustomers.Size = new System.Drawing.Size(80, 23);
            this.chkAllCustomers.TabIndex = 14;
            this.chkAllCustomers.Text = "All Customers";
            this.chkAllCustomers.UseVisualStyleBackColor = false;
            // 
            // ilLock
            // 
            this.ilLock.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilLock.ImageStream")));
            this.ilLock.TransparentColor = System.Drawing.Color.Transparent;
            this.ilLock.Images.SetKeyName(0, "locked.png");
            this.ilLock.Images.SetKeyName(1, "unlocked.png");
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.BackgroundImage = global::DacII.Properties.Resources.cancel_16x16;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Location = new System.Drawing.Point(129, 29);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 32);
            this.btnClose.TabIndex = 91;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.BackColor = System.Drawing.Color.Transparent;
            this.lblEndDate.Location = new System.Drawing.Point(478, 6);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(20, 13);
            this.lblEndDate.TabIndex = 12;
            this.lblEndDate.Text = "To";
            // 
            // lblCustomerSearchCriteria
            // 
            this.lblCustomerSearchCriteria.AutoSize = true;
            this.lblCustomerSearchCriteria.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomerSearchCriteria.Location = new System.Drawing.Point(18, 6);
            this.lblCustomerSearchCriteria.Name = "lblCustomerSearchCriteria";
            this.lblCustomerSearchCriteria.Size = new System.Drawing.Size(54, 13);
            this.lblCustomerSearchCriteria.TabIndex = 11;
            this.lblCustomerSearchCriteria.Text = "Customer:";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.BackColor = System.Drawing.Color.Transparent;
            this.lblStartDate.Location = new System.Drawing.Point(373, 6);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(65, 13);
            this.lblStartDate.TabIndex = 11;
            this.lblStartDate.Text = "Dated From:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(481, 35);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(102, 20);
            this.dtpEndDate.TabIndex = 9;
            // 
            // cboCustomerSearchCriteria
            // 
            this.cboCustomerSearchCriteria.FormattingEnabled = true;
            this.cboCustomerSearchCriteria.Location = new System.Drawing.Point(103, 35);
            this.cboCustomerSearchCriteria.Name = "cboCustomerSearchCriteria";
            this.cboCustomerSearchCriteria.Size = new System.Drawing.Size(237, 21);
            this.cboCustomerSearchCriteria.TabIndex = 2;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(376, 36);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(99, 20);
            this.dtpStartDate.TabIndex = 10;
            // 
            // czRoundedGroupBox1
            // 
            this.czRoundedGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.czRoundedGroupBox1.BackgroundColor = System.Drawing.Color.White;
            this.czRoundedGroupBox1.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.czRoundedGroupBox1.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.czRoundedGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.czRoundedGroupBox1.BorderWidth = 1F;
            this.czRoundedGroupBox1.Caption = "";
            this.czRoundedGroupBox1.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.czRoundedGroupBox1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.czRoundedGroupBox1.CaptionHeight = 25;
            this.czRoundedGroupBox1.CaptionVisible = true;
            this.czRoundedGroupBox1.Controls.Add(this.lblCustomerSearchCriteria);
            this.czRoundedGroupBox1.Controls.Add(this.cboCustomerSearchCriteria);
            this.czRoundedGroupBox1.Controls.Add(this.chkAllCustomers);
            this.czRoundedGroupBox1.Controls.Add(this.lblStartDate);
            this.czRoundedGroupBox1.Controls.Add(this.lblEndDate);
            this.czRoundedGroupBox1.Controls.Add(this.dtpStartDate);
            this.czRoundedGroupBox1.Controls.Add(this.dtpEndDate);
            this.czRoundedGroupBox1.CornerRadius = 5;
            this.czRoundedGroupBox1.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.czRoundedGroupBox1.DropShadowThickness = 3;
            this.czRoundedGroupBox1.DropShadowVisible = true;
            this.czRoundedGroupBox1.Location = new System.Drawing.Point(5, 388);
            this.czRoundedGroupBox1.Name = "czRoundedGroupBox1";
            this.czRoundedGroupBox1.Size = new System.Drawing.Size(603, 70);
            this.czRoundedGroupBox1.TabIndex = 4;
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
            this.czRoundedGroupBox2.Controls.Add(this.btnClose);
            this.czRoundedGroupBox2.Controls.Add(this.btnRefresh);
            this.czRoundedGroupBox2.Controls.Add(this.btnPrint);
            this.czRoundedGroupBox2.CornerRadius = 5;
            this.czRoundedGroupBox2.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.czRoundedGroupBox2.DropShadowThickness = 3;
            this.czRoundedGroupBox2.DropShadowVisible = true;
            this.czRoundedGroupBox2.Location = new System.Drawing.Point(618, 388);
            this.czRoundedGroupBox2.Name = "czRoundedGroupBox2";
            this.czRoundedGroupBox2.Size = new System.Drawing.Size(178, 70);
            this.czRoundedGroupBox2.TabIndex = 5;
            // 
            // FrmSalesRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(803, 469);
            this.Controls.Add(this.czRoundedGroupBox2);
            this.Controls.Add(this.czRoundedGroupBox1);
            this.Controls.Add(this.gbFilter);
            this.Name = "FrmSalesRegister";
            this.Text = "Sale Register";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.gbFilter.ResumeLayout(false);
            this.tcSale.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpenInvoice)).EndInit();
            this.tpCreditReturn.ResumeLayout(false);
            this.tpCreditReturn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreditReturn)).EndInit();
            this.tpClosed.ResumeLayout(false);
            this.tpClosed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClosedInvoice)).EndInit();
            this.czRoundedGroupBox1.ResumeLayout(false);
            this.czRoundedGroupBox1.PerformLayout();
            this.czRoundedGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.CZRoundedGroupBox gbFilter;
        private System.Windows.Forms.CheckBox chkAllCustomers;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblCustomerSearchCriteria;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.ComboBox cboCustomerSearchCriteria;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ImageList ilLock;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TabControl tcSale;
        private System.Windows.Forms.TabPage tpAll;
        private System.Windows.Forms.DataGridView dgvAll;
        private System.Windows.Forms.TabPage tpQuote;
        private System.Windows.Forms.VistaButton btnDelQuote;
        private System.Windows.Forms.VistaButton btnCreatePO;
        private System.Windows.Forms.VistaButton btnCreateQuote;
        private System.Windows.Forms.VistaButton btnChangeQuote2OpenInvoice;
        private System.Windows.Forms.VistaButton btnChangeQuote2Order;
        private System.Windows.Forms.DataGridView dgvQuote;
        private System.Windows.Forms.TabPage tpOrder;
        private System.Windows.Forms.VistaButton btnCreateOrder;
        private System.Windows.Forms.VistaButton btnChangeOrder2OpenInvoice;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.TabPage tpOpen;
        private System.Windows.Forms.VistaButton btnCreateOpenInvoice;
        private System.Windows.Forms.DataGridView dgvOpenInvoice;
        private System.Windows.Forms.TabPage tpCreditReturn;
        private System.Windows.Forms.DataGridView dgvCreditReturn;
        private System.Windows.Forms.TabPage tpClosed;
        private System.Windows.Forms.DataGridView dgvClosedInvoice;
        private System.Windows.Forms.Button btnScanBarcode;
        private System.Windows.Forms.CZRoundedGroupBox czRoundedGroupBox2;
        private System.Windows.Forms.CZRoundedGroupBox czRoundedGroupBox1;
        private System.Windows.Forms.Label lblCountAll;
        private System.Windows.Forms.Label lblCountQuotes;
        private System.Windows.Forms.Label lblCountOrders;
        private System.Windows.Forms.Label lblCountOpenInvoices;
        private System.Windows.Forms.Label lblCountCreditReturns;
        private System.Windows.Forms.Label lblCountClosedInvoices;
        private System.Windows.Forms.Button btnClose2;
    }
}