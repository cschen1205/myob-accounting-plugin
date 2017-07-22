namespace DacII.WinForms.Sales
{
    partial class FrmSaleOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSaleOrder));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboReferralSource = new System.Windows.Forms.ComboBox();
            this.lblReferralSource = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tc = new System.Windows.Forms.TabControl();
            this.tpSaleOrder = new System.Windows.Forms.TabPage();
            this.gbCustomerDetails = new System.Windows.Forms.CZRoundedGroupBox();
            this.lblCustomerPhone2 = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.lblDestinationCountry = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblCustomerPO = new System.Windows.Forms.Label();
            this.lblCustomerEmail = new System.Windows.Forms.Label();
            this.lblCustomerPhone1 = new System.Windows.Forms.Label();
            this.lblCustomerCity = new System.Windows.Forms.Label();
            this.txtCustomerPhone2 = new System.Windows.Forms.TextBox();
            this.txtCustomerPO = new System.Windows.Forms.TextBox();
            this.txtCustomerEmail = new System.Windows.Forms.TextBox();
            this.txtCustomerPhone1 = new System.Windows.Forms.TextBox();
            this.txtDestinationCountry = new System.Windows.Forms.TextBox();
            this.txtCustomerCity = new System.Windows.Forms.TextBox();
            this.gbComments = new System.Windows.Forms.CZRoundedGroupBox();
            this.cboTerms = new System.Windows.Forms.ComboBox();
            this.lblTerms = new System.Windows.Forms.Label();
            this.cboComments = new System.Windows.Forms.ComboBox();
            this.lblComments = new System.Windows.Forms.Label();
            this.gbMainDetail = new System.Windows.Forms.CZRoundedGroupBox();
            this.cboSalesperson = new System.Windows.Forms.ComboBox();
            this.dtpSaleDate = new System.Windows.Forms.DateTimePicker();
            this.txtJournalMemo = new System.Windows.Forms.TextBox();
            this.lblSaleDate = new System.Windows.Forms.Label();
            this.lblSalesperson = new System.Windows.Forms.Label();
            this.dtpPromisedDate = new System.Windows.Forms.DateTimePicker();
            this.lblJournalMemo = new System.Windows.Forms.Label();
            this.lblPromisedDate = new System.Windows.Forms.Label();
            this.gbShipTo = new System.Windows.Forms.CZRoundedGroupBox();
            this.cboAddresses = new System.Windows.Forms.ComboBox();
            this.btnCopyAddress = new System.Windows.Forms.Button();
            this.btnClearAddress = new System.Windows.Forms.Button();
            this.cboShippingMethod = new System.Windows.Forms.ComboBox();
            this.txtAddressLine4 = new System.Windows.Forms.TextBox();
            this.lblAddressLine4 = new System.Windows.Forms.Label();
            this.txtAddressLine3 = new System.Windows.Forms.TextBox();
            this.lblAddressLine3 = new System.Windows.Forms.Label();
            this.txtAddressLine1 = new System.Windows.Forms.TextBox();
            this.lblAddressLine1 = new System.Windows.Forms.Label();
            this.lblShippingMethod = new System.Windows.Forms.Label();
            this.txtAddressLine2 = new System.Windows.Forms.TextBox();
            this.lblAddressLine2 = new System.Windows.Forms.Label();
            this.tpSaleLines = new System.Windows.Forms.TabPage();
            this.btnDelLine = new System.Windows.Forms.Button();
            this.btnNewLine = new System.Windows.Forms.Button();
            this.dgvSaleLines = new System.Windows.Forms.DataGridView();
            this.btnReceiveGoods = new System.Windows.Forms.Button();
            this.cboCurrency = new System.Windows.Forms.ComboBox();
            this.chkTaxInclusive = new System.Windows.Forms.CheckBox();
            this.gpSummary = new System.Windows.Forms.CZRoundedGroupBox();
            this.txtSaleNo = new System.Windows.Forms.TextBox();
            this.lblSaleNo = new System.Windows.Forms.Label();
            this.cboSaleLayout = new System.Windows.Forms.ComboBox();
            this.lblSaleLayout = new System.Windows.Forms.Label();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.cboInvoiceDelivery = new System.Windows.Forms.ComboBox();
            this.lblInvoiceDelivery = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.CZRoundedGroupBox();
            this.txtPaidToday = new System.Windows.Forms.TextBox();
            this.lblPaidToday = new System.Windows.Forms.Label();
            this.cboPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.czRoundedGroupBox1 = new System.Windows.Forms.CZRoundedGroupBox();
            this.groupBox1 = new System.Windows.Forms.CZRoundedGroupBox();
            this.lblBalanceDue = new System.Windows.Forms.Label();
            this.txtBalanceDue = new System.Windows.Forms.TextBox();
            this.txtTaxValue = new System.Windows.Forms.TextBox();
            this.cboFreightTaxCode = new System.Windows.Forms.ComboBox();
            this.lblSubtotalValue = new System.Windows.Forms.Label();
            this.lblFreight = new System.Windows.Forms.Label();
            this.txtFreight = new System.Windows.Forms.TextBox();
            this.txtSubtotalValue = new System.Windows.Forms.TextBox();
            this.lblTaxValue = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.txtTotalValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPlus = new System.Windows.Forms.Label();
            this.lblEqual = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tc.SuspendLayout();
            this.tpSaleOrder.SuspendLayout();
            this.gbCustomerDetails.SuspendLayout();
            this.gbComments.SuspendLayout();
            this.gbMainDetail.SuspendLayout();
            this.gbShipTo.SuspendLayout();
            this.tpSaleLines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleLines)).BeginInit();
            this.gpSummary.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.czRoundedGroupBox1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboReferralSource
            // 
            this.cboReferralSource.FormattingEnabled = true;
            this.cboReferralSource.Location = new System.Drawing.Point(106, 77);
            this.cboReferralSource.Name = "cboReferralSource";
            this.cboReferralSource.Size = new System.Drawing.Size(284, 21);
            this.cboReferralSource.TabIndex = 85;
            // 
            // lblReferralSource
            // 
            this.lblReferralSource.AutoSize = true;
            this.lblReferralSource.Location = new System.Drawing.Point(9, 80);
            this.lblReferralSource.Name = "lblReferralSource";
            this.lblReferralSource.Size = new System.Drawing.Size(81, 13);
            this.lblReferralSource.TabIndex = 84;
            this.lblReferralSource.Text = "Referral Source";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // tc
            // 
            this.tc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tc.Controls.Add(this.tpSaleOrder);
            this.tc.Controls.Add(this.tpSaleLines);
            this.tc.HotTrack = true;
            this.tc.Location = new System.Drawing.Point(7, 27);
            this.tc.Name = "tc";
            this.tc.SelectedIndex = 0;
            this.tc.Size = new System.Drawing.Size(780, 326);
            this.tc.TabIndex = 93;
            // 
            // tpSaleOrder
            // 
            this.tpSaleOrder.Controls.Add(this.gbCustomerDetails);
            this.tpSaleOrder.Controls.Add(this.gbComments);
            this.tpSaleOrder.Controls.Add(this.gbMainDetail);
            this.tpSaleOrder.Controls.Add(this.gbShipTo);
            this.tpSaleOrder.Location = new System.Drawing.Point(4, 22);
            this.tpSaleOrder.Name = "tpSaleOrder";
            this.tpSaleOrder.Padding = new System.Windows.Forms.Padding(3);
            this.tpSaleOrder.Size = new System.Drawing.Size(772, 300);
            this.tpSaleOrder.TabIndex = 0;
            this.tpSaleOrder.Text = "Sale Order";
            this.tpSaleOrder.UseVisualStyleBackColor = true;
            // 
            // gbCustomerDetails
            // 
            this.gbCustomerDetails.BackgroundColor = System.Drawing.Color.White;
            this.gbCustomerDetails.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbCustomerDetails.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbCustomerDetails.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbCustomerDetails.BorderWidth = 1F;
            this.gbCustomerDetails.Caption = "Sale Order Customer Information";
            this.gbCustomerDetails.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbCustomerDetails.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbCustomerDetails.CaptionHeight = 25;
            this.gbCustomerDetails.CaptionVisible = true;
            this.gbCustomerDetails.Controls.Add(this.lblCustomerPhone2);
            this.gbCustomerDetails.Controls.Add(this.cboCustomer);
            this.gbCustomerDetails.Controls.Add(this.lblDestinationCountry);
            this.gbCustomerDetails.Controls.Add(this.lblCustomer);
            this.gbCustomerDetails.Controls.Add(this.lblCustomerPO);
            this.gbCustomerDetails.Controls.Add(this.lblCustomerEmail);
            this.gbCustomerDetails.Controls.Add(this.lblCustomerPhone1);
            this.gbCustomerDetails.Controls.Add(this.lblCustomerCity);
            this.gbCustomerDetails.Controls.Add(this.txtCustomerPhone2);
            this.gbCustomerDetails.Controls.Add(this.txtCustomerPO);
            this.gbCustomerDetails.Controls.Add(this.txtCustomerEmail);
            this.gbCustomerDetails.Controls.Add(this.txtCustomerPhone1);
            this.gbCustomerDetails.Controls.Add(this.txtDestinationCountry);
            this.gbCustomerDetails.Controls.Add(this.txtCustomerCity);
            this.gbCustomerDetails.CornerRadius = 5;
            this.gbCustomerDetails.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbCustomerDetails.DropShadowThickness = 3;
            this.gbCustomerDetails.DropShadowVisible = false;
            this.gbCustomerDetails.Location = new System.Drawing.Point(7, 123);
            this.gbCustomerDetails.Name = "gbCustomerDetails";
            this.gbCustomerDetails.Size = new System.Drawing.Size(347, 168);
            this.gbCustomerDetails.TabIndex = 85;
            this.gbCustomerDetails.TabStop = false;
            // 
            // lblCustomerPhone2
            // 
            this.lblCustomerPhone2.AutoSize = true;
            this.lblCustomerPhone2.Location = new System.Drawing.Point(6, 87);
            this.lblCustomerPhone2.Name = "lblCustomerPhone2";
            this.lblCustomerPhone2.Size = new System.Drawing.Size(47, 13);
            this.lblCustomerPhone2.TabIndex = 0;
            this.lblCustomerPhone2.Text = "Phone 2";
            // 
            // cboCustomer
            // 
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(58, 29);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(273, 21);
            this.cboCustomer.TabIndex = 2;
            this.cboCustomer.SelectedIndexChanged += new System.EventHandler(this.OnCustomerChanged);
            // 
            // lblDestinationCountry
            // 
            this.lblDestinationCountry.AutoSize = true;
            this.lblDestinationCountry.Location = new System.Drawing.Point(180, 87);
            this.lblDestinationCountry.Name = "lblDestinationCountry";
            this.lblDestinationCountry.Size = new System.Drawing.Size(43, 13);
            this.lblDestinationCountry.TabIndex = 0;
            this.lblDestinationCountry.Text = "Country";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(6, 32);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(51, 13);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Customer";
            // 
            // lblCustomerPO
            // 
            this.lblCustomerPO.AutoSize = true;
            this.lblCustomerPO.Location = new System.Drawing.Point(6, 142);
            this.lblCustomerPO.Name = "lblCustomerPO";
            this.lblCustomerPO.Size = new System.Drawing.Size(32, 13);
            this.lblCustomerPO.TabIndex = 0;
            this.lblCustomerPO.Text = "PO #";
            // 
            // lblCustomerEmail
            // 
            this.lblCustomerEmail.AutoSize = true;
            this.lblCustomerEmail.Location = new System.Drawing.Point(6, 115);
            this.lblCustomerEmail.Name = "lblCustomerEmail";
            this.lblCustomerEmail.Size = new System.Drawing.Size(35, 13);
            this.lblCustomerEmail.TabIndex = 0;
            this.lblCustomerEmail.Text = "E-mail";
            // 
            // lblCustomerPhone1
            // 
            this.lblCustomerPhone1.AutoSize = true;
            this.lblCustomerPhone1.Location = new System.Drawing.Point(6, 59);
            this.lblCustomerPhone1.Name = "lblCustomerPhone1";
            this.lblCustomerPhone1.Size = new System.Drawing.Size(47, 13);
            this.lblCustomerPhone1.TabIndex = 0;
            this.lblCustomerPhone1.Text = "Phone 1";
            // 
            // lblCustomerCity
            // 
            this.lblCustomerCity.AutoSize = true;
            this.lblCustomerCity.Location = new System.Drawing.Point(198, 61);
            this.lblCustomerCity.Name = "lblCustomerCity";
            this.lblCustomerCity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCustomerCity.Size = new System.Drawing.Size(24, 13);
            this.lblCustomerCity.TabIndex = 0;
            this.lblCustomerCity.Text = "City";
            // 
            // txtCustomerPhone2
            // 
            this.txtCustomerPhone2.Enabled = false;
            this.txtCustomerPhone2.Location = new System.Drawing.Point(59, 84);
            this.txtCustomerPhone2.Name = "txtCustomerPhone2";
            this.txtCustomerPhone2.Size = new System.Drawing.Size(114, 20);
            this.txtCustomerPhone2.TabIndex = 1;
            // 
            // txtCustomerPO
            // 
            this.txtCustomerPO.Location = new System.Drawing.Point(58, 139);
            this.txtCustomerPO.Name = "txtCustomerPO";
            this.txtCustomerPO.Size = new System.Drawing.Size(115, 20);
            this.txtCustomerPO.TabIndex = 1;
            // 
            // txtCustomerEmail
            // 
            this.txtCustomerEmail.Enabled = false;
            this.txtCustomerEmail.Location = new System.Drawing.Point(59, 112);
            this.txtCustomerEmail.Name = "txtCustomerEmail";
            this.txtCustomerEmail.Size = new System.Drawing.Size(114, 20);
            this.txtCustomerEmail.TabIndex = 1;
            // 
            // txtCustomerPhone1
            // 
            this.txtCustomerPhone1.Enabled = false;
            this.txtCustomerPhone1.Location = new System.Drawing.Point(58, 57);
            this.txtCustomerPhone1.Name = "txtCustomerPhone1";
            this.txtCustomerPhone1.Size = new System.Drawing.Size(115, 20);
            this.txtCustomerPhone1.TabIndex = 1;
            // 
            // txtDestinationCountry
            // 
            this.txtDestinationCountry.Location = new System.Drawing.Point(228, 84);
            this.txtDestinationCountry.Name = "txtDestinationCountry";
            this.txtDestinationCountry.Size = new System.Drawing.Size(103, 20);
            this.txtDestinationCountry.TabIndex = 1;
            // 
            // txtCustomerCity
            // 
            this.txtCustomerCity.Enabled = false;
            this.txtCustomerCity.Location = new System.Drawing.Point(228, 57);
            this.txtCustomerCity.Name = "txtCustomerCity";
            this.txtCustomerCity.Size = new System.Drawing.Size(103, 20);
            this.txtCustomerCity.TabIndex = 1;
            // 
            // gbComments
            // 
            this.gbComments.BackgroundColor = System.Drawing.Color.White;
            this.gbComments.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbComments.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbComments.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbComments.BorderWidth = 1F;
            this.gbComments.Caption = "Sale Order Extra Information";
            this.gbComments.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbComments.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbComments.CaptionHeight = 25;
            this.gbComments.CaptionVisible = true;
            this.gbComments.Controls.Add(this.cboTerms);
            this.gbComments.Controls.Add(this.lblTerms);
            this.gbComments.Controls.Add(this.cboComments);
            this.gbComments.Controls.Add(this.lblComments);
            this.gbComments.Controls.Add(this.cboReferralSource);
            this.gbComments.Controls.Add(this.lblReferralSource);
            this.gbComments.CornerRadius = 5;
            this.gbComments.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbComments.DropShadowThickness = 3;
            this.gbComments.DropShadowVisible = false;
            this.gbComments.Location = new System.Drawing.Point(360, 8);
            this.gbComments.Name = "gbComments";
            this.gbComments.Size = new System.Drawing.Size(406, 109);
            this.gbComments.TabIndex = 84;
            this.gbComments.TabStop = false;
            // 
            // cboTerms
            // 
            this.cboTerms.FormattingEnabled = true;
            this.cboTerms.Location = new System.Drawing.Point(106, 52);
            this.cboTerms.Name = "cboTerms";
            this.cboTerms.Size = new System.Drawing.Size(284, 21);
            this.cboTerms.TabIndex = 2;
            // 
            // lblTerms
            // 
            this.lblTerms.AutoSize = true;
            this.lblTerms.Location = new System.Drawing.Point(6, 55);
            this.lblTerms.Name = "lblTerms";
            this.lblTerms.Size = new System.Drawing.Size(36, 13);
            this.lblTerms.TabIndex = 0;
            this.lblTerms.Text = "Terms";
            // 
            // cboComments
            // 
            this.cboComments.FormattingEnabled = true;
            this.cboComments.Location = new System.Drawing.Point(106, 28);
            this.cboComments.Name = "cboComments";
            this.cboComments.Size = new System.Drawing.Size(284, 21);
            this.cboComments.TabIndex = 2;
            // 
            // lblComments
            // 
            this.lblComments.AutoSize = true;
            this.lblComments.Location = new System.Drawing.Point(6, 31);
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(56, 13);
            this.lblComments.TabIndex = 0;
            this.lblComments.Text = "Comments";
            // 
            // gbMainDetail
            // 
            this.gbMainDetail.BackgroundColor = System.Drawing.Color.White;
            this.gbMainDetail.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbMainDetail.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbMainDetail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbMainDetail.BorderWidth = 1F;
            this.gbMainDetail.Caption = "Sale Order Header Information";
            this.gbMainDetail.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbMainDetail.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbMainDetail.CaptionHeight = 25;
            this.gbMainDetail.CaptionVisible = true;
            this.gbMainDetail.Controls.Add(this.cboSalesperson);
            this.gbMainDetail.Controls.Add(this.dtpSaleDate);
            this.gbMainDetail.Controls.Add(this.txtJournalMemo);
            this.gbMainDetail.Controls.Add(this.lblSaleDate);
            this.gbMainDetail.Controls.Add(this.lblSalesperson);
            this.gbMainDetail.Controls.Add(this.dtpPromisedDate);
            this.gbMainDetail.Controls.Add(this.lblJournalMemo);
            this.gbMainDetail.Controls.Add(this.lblPromisedDate);
            this.gbMainDetail.CornerRadius = 5;
            this.gbMainDetail.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbMainDetail.DropShadowThickness = 3;
            this.gbMainDetail.DropShadowVisible = false;
            this.gbMainDetail.Location = new System.Drawing.Point(7, 8);
            this.gbMainDetail.Name = "gbMainDetail";
            this.gbMainDetail.Size = new System.Drawing.Size(347, 109);
            this.gbMainDetail.TabIndex = 83;
            this.gbMainDetail.TabStop = false;
            // 
            // cboSalesperson
            // 
            this.cboSalesperson.FormattingEnabled = true;
            this.cboSalesperson.Location = new System.Drawing.Point(64, 28);
            this.cboSalesperson.Name = "cboSalesperson";
            this.cboSalesperson.Size = new System.Drawing.Size(267, 21);
            this.cboSalesperson.TabIndex = 19;
            // 
            // dtpSaleDate
            // 
            this.dtpSaleDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSaleDate.Location = new System.Drawing.Point(64, 53);
            this.dtpSaleDate.Name = "dtpSaleDate";
            this.dtpSaleDate.Size = new System.Drawing.Size(109, 20);
            this.dtpSaleDate.TabIndex = 3;
            // 
            // txtJournalMemo
            // 
            this.txtJournalMemo.Location = new System.Drawing.Point(64, 78);
            this.txtJournalMemo.Name = "txtJournalMemo";
            this.txtJournalMemo.Size = new System.Drawing.Size(267, 20);
            this.txtJournalMemo.TabIndex = 1;
            // 
            // lblSaleDate
            // 
            this.lblSaleDate.AutoSize = true;
            this.lblSaleDate.Location = new System.Drawing.Point(6, 57);
            this.lblSaleDate.Name = "lblSaleDate";
            this.lblSaleDate.Size = new System.Drawing.Size(30, 13);
            this.lblSaleDate.TabIndex = 0;
            this.lblSaleDate.Text = "Date";
            // 
            // lblSalesperson
            // 
            this.lblSalesperson.AutoSize = true;
            this.lblSalesperson.Location = new System.Drawing.Point(6, 31);
            this.lblSalesperson.Name = "lblSalesperson";
            this.lblSalesperson.Size = new System.Drawing.Size(43, 13);
            this.lblSalesperson.TabIndex = 0;
            this.lblSalesperson.Text = "Sale By";
            // 
            // dtpPromisedDate
            // 
            this.dtpPromisedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPromisedDate.Location = new System.Drawing.Point(228, 53);
            this.dtpPromisedDate.Name = "dtpPromisedDate";
            this.dtpPromisedDate.Size = new System.Drawing.Size(103, 20);
            this.dtpPromisedDate.TabIndex = 3;
            // 
            // lblJournalMemo
            // 
            this.lblJournalMemo.AutoSize = true;
            this.lblJournalMemo.Location = new System.Drawing.Point(6, 81);
            this.lblJournalMemo.Name = "lblJournalMemo";
            this.lblJournalMemo.Size = new System.Drawing.Size(36, 13);
            this.lblJournalMemo.TabIndex = 0;
            this.lblJournalMemo.Text = "Memo";
            // 
            // lblPromisedDate
            // 
            this.lblPromisedDate.AutoSize = true;
            this.lblPromisedDate.Location = new System.Drawing.Point(176, 56);
            this.lblPromisedDate.Name = "lblPromisedDate";
            this.lblPromisedDate.Size = new System.Drawing.Size(50, 13);
            this.lblPromisedDate.TabIndex = 0;
            this.lblPromisedDate.Text = "Promised";
            // 
            // gbShipTo
            // 
            this.gbShipTo.BackgroundColor = System.Drawing.Color.White;
            this.gbShipTo.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbShipTo.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbShipTo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbShipTo.BorderWidth = 1F;
            this.gbShipTo.Caption = "Sale Order Delivery Information";
            this.gbShipTo.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbShipTo.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbShipTo.CaptionHeight = 25;
            this.gbShipTo.CaptionVisible = true;
            this.gbShipTo.Controls.Add(this.cboAddresses);
            this.gbShipTo.Controls.Add(this.btnCopyAddress);
            this.gbShipTo.Controls.Add(this.btnClearAddress);
            this.gbShipTo.Controls.Add(this.cboShippingMethod);
            this.gbShipTo.Controls.Add(this.txtAddressLine4);
            this.gbShipTo.Controls.Add(this.lblAddressLine4);
            this.gbShipTo.Controls.Add(this.txtAddressLine3);
            this.gbShipTo.Controls.Add(this.lblAddressLine3);
            this.gbShipTo.Controls.Add(this.txtAddressLine1);
            this.gbShipTo.Controls.Add(this.lblAddressLine1);
            this.gbShipTo.Controls.Add(this.lblShippingMethod);
            this.gbShipTo.Controls.Add(this.txtAddressLine2);
            this.gbShipTo.Controls.Add(this.lblAddressLine2);
            this.gbShipTo.CornerRadius = 5;
            this.gbShipTo.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbShipTo.DropShadowThickness = 3;
            this.gbShipTo.DropShadowVisible = false;
            this.gbShipTo.Location = new System.Drawing.Point(360, 123);
            this.gbShipTo.Name = "gbShipTo";
            this.gbShipTo.Size = new System.Drawing.Size(406, 168);
            this.gbShipTo.TabIndex = 86;
            this.gbShipTo.TabStop = false;
            // 
            // cboAddresses
            // 
            this.cboAddresses.FormattingEnabled = true;
            this.cboAddresses.Location = new System.Drawing.Point(272, 57);
            this.cboAddresses.Name = "cboAddresses";
            this.cboAddresses.Size = new System.Drawing.Size(118, 21);
            this.cboAddresses.TabIndex = 19;
            this.cboAddresses.SelectedIndexChanged += new System.EventHandler(this.OnAddressIndexChanged);
            // 
            // btnCopyAddress
            // 
            this.btnCopyAddress.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCopyAddress.FlatAppearance.BorderSize = 0;
            this.btnCopyAddress.Location = new System.Drawing.Point(272, 83);
            this.btnCopyAddress.Name = "btnCopyAddress";
            this.btnCopyAddress.Size = new System.Drawing.Size(56, 22);
            this.btnCopyAddress.TabIndex = 29;
            this.btnCopyAddress.Text = "Load";
            this.btnCopyAddress.UseVisualStyleBackColor = false;
            this.btnCopyAddress.Click += new System.EventHandler(this.btnCopyAddress_Click);
            // 
            // btnClearAddress
            // 
            this.btnClearAddress.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClearAddress.FlatAppearance.BorderSize = 0;
            this.btnClearAddress.Location = new System.Drawing.Point(334, 83);
            this.btnClearAddress.Name = "btnClearAddress";
            this.btnClearAddress.Size = new System.Drawing.Size(56, 22);
            this.btnClearAddress.TabIndex = 29;
            this.btnClearAddress.Text = "Clear";
            this.btnClearAddress.UseVisualStyleBackColor = false;
            this.btnClearAddress.Click += new System.EventHandler(this.btnClearAddress_Click);
            // 
            // cboShippingMethod
            // 
            this.cboShippingMethod.FormattingEnabled = true;
            this.cboShippingMethod.Location = new System.Drawing.Point(106, 30);
            this.cboShippingMethod.Name = "cboShippingMethod";
            this.cboShippingMethod.Size = new System.Drawing.Size(159, 21);
            this.cboShippingMethod.TabIndex = 22;
            // 
            // txtAddressLine4
            // 
            this.txtAddressLine4.Location = new System.Drawing.Point(107, 134);
            this.txtAddressLine4.Name = "txtAddressLine4";
            this.txtAddressLine4.Size = new System.Drawing.Size(159, 20);
            this.txtAddressLine4.TabIndex = 25;
            // 
            // lblAddressLine4
            // 
            this.lblAddressLine4.AutoSize = true;
            this.lblAddressLine4.Location = new System.Drawing.Point(10, 137);
            this.lblAddressLine4.Name = "lblAddressLine4";
            this.lblAddressLine4.Size = new System.Drawing.Size(77, 13);
            this.lblAddressLine4.TabIndex = 22;
            this.lblAddressLine4.Text = "Address Line 4";
            // 
            // txtAddressLine3
            // 
            this.txtAddressLine3.Location = new System.Drawing.Point(107, 109);
            this.txtAddressLine3.Name = "txtAddressLine3";
            this.txtAddressLine3.Size = new System.Drawing.Size(159, 20);
            this.txtAddressLine3.TabIndex = 26;
            // 
            // lblAddressLine3
            // 
            this.lblAddressLine3.AutoSize = true;
            this.lblAddressLine3.Location = new System.Drawing.Point(10, 112);
            this.lblAddressLine3.Name = "lblAddressLine3";
            this.lblAddressLine3.Size = new System.Drawing.Size(77, 13);
            this.lblAddressLine3.TabIndex = 23;
            this.lblAddressLine3.Text = "Address Line 3";
            // 
            // txtAddressLine1
            // 
            this.txtAddressLine1.Location = new System.Drawing.Point(107, 58);
            this.txtAddressLine1.Name = "txtAddressLine1";
            this.txtAddressLine1.Size = new System.Drawing.Size(159, 20);
            this.txtAddressLine1.TabIndex = 27;
            // 
            // lblAddressLine1
            // 
            this.lblAddressLine1.AutoSize = true;
            this.lblAddressLine1.Location = new System.Drawing.Point(10, 61);
            this.lblAddressLine1.Name = "lblAddressLine1";
            this.lblAddressLine1.Size = new System.Drawing.Size(77, 13);
            this.lblAddressLine1.TabIndex = 20;
            this.lblAddressLine1.Text = "Address Line 1";
            // 
            // lblShippingMethod
            // 
            this.lblShippingMethod.AutoSize = true;
            this.lblShippingMethod.Location = new System.Drawing.Point(9, 31);
            this.lblShippingMethod.Name = "lblShippingMethod";
            this.lblShippingMethod.Size = new System.Drawing.Size(90, 13);
            this.lblShippingMethod.TabIndex = 0;
            this.lblShippingMethod.Text = "Shipping Method:";
            // 
            // txtAddressLine2
            // 
            this.txtAddressLine2.Location = new System.Drawing.Point(107, 83);
            this.txtAddressLine2.Name = "txtAddressLine2";
            this.txtAddressLine2.Size = new System.Drawing.Size(159, 20);
            this.txtAddressLine2.TabIndex = 24;
            // 
            // lblAddressLine2
            // 
            this.lblAddressLine2.AutoSize = true;
            this.lblAddressLine2.Location = new System.Drawing.Point(10, 86);
            this.lblAddressLine2.Name = "lblAddressLine2";
            this.lblAddressLine2.Size = new System.Drawing.Size(77, 13);
            this.lblAddressLine2.TabIndex = 21;
            this.lblAddressLine2.Text = "Address Line 2";
            // 
            // tpSaleLines
            // 
            this.tpSaleLines.Controls.Add(this.dgvSaleLines);
            this.tpSaleLines.Controls.Add(this.btnDelLine);
            this.tpSaleLines.Controls.Add(this.btnNewLine);
            this.tpSaleLines.Controls.Add(this.btnReceiveGoods);
            this.tpSaleLines.Location = new System.Drawing.Point(4, 22);
            this.tpSaleLines.Name = "tpSaleLines";
            this.tpSaleLines.Padding = new System.Windows.Forms.Padding(3);
            this.tpSaleLines.Size = new System.Drawing.Size(772, 300);
            this.tpSaleLines.TabIndex = 1;
            this.tpSaleLines.Text = "Sale Lines";
            this.tpSaleLines.UseVisualStyleBackColor = true;
            // 
            // btnDelLine
            // 
            this.btnDelLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelLine.BackgroundImage = global::DacII.Properties.Resources.delete_16x16;
            this.btnDelLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelLine.Location = new System.Drawing.Point(737, 262);
            this.btnDelLine.Name = "btnDelLine";
            this.btnDelLine.Size = new System.Drawing.Size(32, 32);
            this.btnDelLine.TabIndex = 9;
            this.btnDelLine.Click += new System.EventHandler(this.btnDelLine_Click);
            // 
            // btnNewLine
            // 
            this.btnNewLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewLine.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNewLine.BackgroundImage")));
            this.btnNewLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNewLine.Location = new System.Drawing.Point(704, 262);
            this.btnNewLine.Name = "btnNewLine";
            this.btnNewLine.Size = new System.Drawing.Size(32, 32);
            this.btnNewLine.TabIndex = 8;
            this.btnNewLine.Click += new System.EventHandler(this.btnNewLine_Click);
            // 
            // dgvSaleLines
            // 
            this.dgvSaleLines.AllowUserToAddRows = false;
            this.dgvSaleLines.AllowUserToDeleteRows = false;
            this.dgvSaleLines.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.dgvSaleLines.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSaleLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSaleLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSaleLines.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSaleLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSaleLines.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSaleLines.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSaleLines.Location = new System.Drawing.Point(4, 6);
            this.dgvSaleLines.MultiSelect = false;
            this.dgvSaleLines.Name = "dgvSaleLines";
            this.dgvSaleLines.RowHeadersVisible = false;
            this.dgvSaleLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSaleLines.Size = new System.Drawing.Size(762, 250);
            this.dgvSaleLines.TabIndex = 0;
            this.dgvSaleLines.DoubleClick += new System.EventHandler(this.dgvSaleLines_DoubleClick);
            // 
            // btnReceiveGoods
            // 
            this.btnReceiveGoods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReceiveGoods.BackgroundImage = global::DacII.Properties.Resources.receive_item_16x16;
            this.btnReceiveGoods.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReceiveGoods.Location = new System.Drawing.Point(670, 262);
            this.btnReceiveGoods.Name = "btnReceiveGoods";
            this.btnReceiveGoods.Size = new System.Drawing.Size(32, 32);
            this.btnReceiveGoods.TabIndex = 92;
            // 
            // cboCurrency
            // 
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.Location = new System.Drawing.Point(88, 103);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(96, 21);
            this.cboCurrency.TabIndex = 85;
            // 
            // chkTaxInclusive
            // 
            this.chkTaxInclusive.AutoSize = true;
            this.chkTaxInclusive.BackColor = System.Drawing.Color.Transparent;
            this.chkTaxInclusive.Checked = true;
            this.chkTaxInclusive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTaxInclusive.Location = new System.Drawing.Point(193, 106);
            this.chkTaxInclusive.Name = "chkTaxInclusive";
            this.chkTaxInclusive.Size = new System.Drawing.Size(100, 17);
            this.chkTaxInclusive.TabIndex = 3;
            this.chkTaxInclusive.Text = "Is Tax Inclusive";
            this.chkTaxInclusive.UseVisualStyleBackColor = false;
            // 
            // gpSummary
            // 
            this.gpSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gpSummary.BackgroundColor = System.Drawing.Color.White;
            this.gpSummary.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gpSummary.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gpSummary.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gpSummary.BorderWidth = 1F;
            this.gpSummary.Caption = "Sale Order Main Information";
            this.gpSummary.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gpSummary.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gpSummary.CaptionHeight = 25;
            this.gpSummary.CaptionVisible = true;
            this.gpSummary.Controls.Add(this.txtSaleNo);
            this.gpSummary.Controls.Add(this.lblSaleNo);
            this.gpSummary.Controls.Add(this.cboSaleLayout);
            this.gpSummary.Controls.Add(this.lblSaleLayout);
            this.gpSummary.Controls.Add(this.lblCurrency);
            this.gpSummary.Controls.Add(this.cboInvoiceDelivery);
            this.gpSummary.Controls.Add(this.cboCurrency);
            this.gpSummary.Controls.Add(this.lblInvoiceDelivery);
            this.gpSummary.Controls.Add(this.chkTaxInclusive);
            this.gpSummary.CornerRadius = 5;
            this.gpSummary.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gpSummary.DropShadowThickness = 3;
            this.gpSummary.DropShadowVisible = true;
            this.gpSummary.Location = new System.Drawing.Point(7, 370);
            this.gpSummary.Name = "gpSummary";
            this.gpSummary.Size = new System.Drawing.Size(311, 171);
            this.gpSummary.TabIndex = 94;
            this.gpSummary.TabStop = false;
            // 
            // txtSaleNo
            // 
            this.txtSaleNo.Location = new System.Drawing.Point(88, 28);
            this.txtSaleNo.Name = "txtSaleNo";
            this.txtSaleNo.Size = new System.Drawing.Size(205, 20);
            this.txtSaleNo.TabIndex = 88;
            // 
            // lblSaleNo
            // 
            this.lblSaleNo.AutoSize = true;
            this.lblSaleNo.BackColor = System.Drawing.Color.Transparent;
            this.lblSaleNo.Location = new System.Drawing.Point(8, 31);
            this.lblSaleNo.Name = "lblSaleNo";
            this.lblSaleNo.Size = new System.Drawing.Size(52, 13);
            this.lblSaleNo.TabIndex = 87;
            this.lblSaleNo.Text = "Invoice #";
            // 
            // cboSaleLayout
            // 
            this.cboSaleLayout.FormattingEnabled = true;
            this.cboSaleLayout.Location = new System.Drawing.Point(88, 77);
            this.cboSaleLayout.Name = "cboSaleLayout";
            this.cboSaleLayout.Size = new System.Drawing.Size(205, 21);
            this.cboSaleLayout.TabIndex = 91;
            // 
            // lblSaleLayout
            // 
            this.lblSaleLayout.AutoSize = true;
            this.lblSaleLayout.BackColor = System.Drawing.Color.Transparent;
            this.lblSaleLayout.Location = new System.Drawing.Point(8, 80);
            this.lblSaleLayout.Name = "lblSaleLayout";
            this.lblSaleLayout.Size = new System.Drawing.Size(39, 13);
            this.lblSaleLayout.TabIndex = 90;
            this.lblSaleLayout.Text = "Layout";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrency.Location = new System.Drawing.Point(8, 106);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(30, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Rate";
            // 
            // cboInvoiceDelivery
            // 
            this.cboInvoiceDelivery.FormattingEnabled = true;
            this.cboInvoiceDelivery.Location = new System.Drawing.Point(88, 52);
            this.cboInvoiceDelivery.Name = "cboInvoiceDelivery";
            this.cboInvoiceDelivery.Size = new System.Drawing.Size(205, 21);
            this.cboInvoiceDelivery.TabIndex = 92;
            // 
            // lblInvoiceDelivery
            // 
            this.lblInvoiceDelivery.AutoSize = true;
            this.lblInvoiceDelivery.BackColor = System.Drawing.Color.Transparent;
            this.lblInvoiceDelivery.Location = new System.Drawing.Point(6, 55);
            this.lblInvoiceDelivery.Name = "lblInvoiceDelivery";
            this.lblInvoiceDelivery.Size = new System.Drawing.Size(78, 13);
            this.lblInvoiceDelivery.TabIndex = 89;
            this.lblInvoiceDelivery.Text = "Delivery Status";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.BackgroundColor = System.Drawing.Color.White;
            this.groupBox2.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.groupBox2.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.groupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.groupBox2.BorderWidth = 1F;
            this.groupBox2.Caption = "";
            this.groupBox2.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.groupBox2.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.groupBox2.CaptionHeight = 25;
            this.groupBox2.CaptionVisible = false;
            this.groupBox2.Controls.Add(this.txtPaidToday);
            this.groupBox2.Controls.Add(this.lblPaidToday);
            this.groupBox2.Controls.Add(this.cboPaymentMethod);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.CornerRadius = 5;
            this.groupBox2.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.groupBox2.DropShadowThickness = 3;
            this.groupBox2.DropShadowVisible = true;
            this.groupBox2.Location = new System.Drawing.Point(324, 442);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(477, 35);
            this.groupBox2.TabIndex = 95;
            this.groupBox2.TabStop = false;
            // 
            // txtPaidToday
            // 
            this.txtPaidToday.Location = new System.Drawing.Point(74, 5);
            this.txtPaidToday.Name = "txtPaidToday";
            this.txtPaidToday.Size = new System.Drawing.Size(71, 20);
            this.txtPaidToday.TabIndex = 88;
            this.txtPaidToday.Text = "0";
            // 
            // lblPaidToday
            // 
            this.lblPaidToday.AutoSize = true;
            this.lblPaidToday.BackColor = System.Drawing.Color.Transparent;
            this.lblPaidToday.Location = new System.Drawing.Point(8, 9);
            this.lblPaidToday.Name = "lblPaidToday";
            this.lblPaidToday.Size = new System.Drawing.Size(64, 13);
            this.lblPaidToday.TabIndex = 87;
            this.lblPaidToday.Text = "Paid Today:";
            // 
            // cboPaymentMethod
            // 
            this.cboPaymentMethod.FormattingEnabled = true;
            this.cboPaymentMethod.Location = new System.Drawing.Point(250, 5);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(101, 21);
            this.cboPaymentMethod.TabIndex = 92;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(157, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 89;
            this.label4.Text = "Payment Method:";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Image = global::DacII.Properties.Resources.print_32x32;
            this.btnPrint.Location = new System.Drawing.Point(552, 485);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(56, 56);
            this.btnPrint.TabIndex = 91;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DacII.Properties.Resources.cancel_24x24;
            this.btnClose.Location = new System.Drawing.Point(741, 485);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 56);
            this.btnClose.TabIndex = 90;
            this.btnClose.Text = "Cancel";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRecord
            // 
            this.btnRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRecord.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRecord.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecord.Image = global::DacII.Properties.Resources.save_32x32;
            this.btnRecord.Location = new System.Drawing.Point(676, 485);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(56, 56);
            this.btnRecord.TabIndex = 89;
            this.btnRecord.Text = "Record";
            this.btnRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRecord.UseVisualStyleBackColor = false;
            this.btnRecord.Click += new System.EventHandler(this.Record);
            // 
            // btnBarcode
            // 
            this.btnBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBarcode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBarcode.BackgroundImage = global::DacII.Properties.Resources.barcode_48x48;
            this.btnBarcode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBarcode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBarcode.Location = new System.Drawing.Point(614, 485);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(56, 56);
            this.btnBarcode.TabIndex = 96;
            this.btnBarcode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBarcode.UseVisualStyleBackColor = false;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // czRoundedGroupBox1
            // 
            this.czRoundedGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.czRoundedGroupBox1.BackgroundColor = System.Drawing.Color.White;
            this.czRoundedGroupBox1.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.czRoundedGroupBox1.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.czRoundedGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.czRoundedGroupBox1.BorderWidth = 1F;
            this.czRoundedGroupBox1.Caption = "Sales --> Order";
            this.czRoundedGroupBox1.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.czRoundedGroupBox1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.czRoundedGroupBox1.CaptionHeight = 25;
            this.czRoundedGroupBox1.CaptionVisible = true;
            this.czRoundedGroupBox1.Controls.Add(this.tc);
            this.czRoundedGroupBox1.CornerRadius = 5;
            this.czRoundedGroupBox1.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.czRoundedGroupBox1.DropShadowThickness = 3;
            this.czRoundedGroupBox1.DropShadowVisible = true;
            this.czRoundedGroupBox1.Location = new System.Drawing.Point(3, 4);
            this.czRoundedGroupBox1.Name = "czRoundedGroupBox1";
            this.czRoundedGroupBox1.Size = new System.Drawing.Size(798, 363);
            this.czRoundedGroupBox1.TabIndex = 97;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.BackgroundColor = System.Drawing.Color.White;
            this.groupBox1.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.groupBox1.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.groupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.groupBox1.BorderWidth = 1F;
            this.groupBox1.Caption = "";
            this.groupBox1.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.groupBox1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.groupBox1.CaptionHeight = 25;
            this.groupBox1.CaptionVisible = true;
            this.groupBox1.Controls.Add(this.lblBalanceDue);
            this.groupBox1.Controls.Add(this.txtBalanceDue);
            this.groupBox1.Controls.Add(this.txtTaxValue);
            this.groupBox1.Controls.Add(this.cboFreightTaxCode);
            this.groupBox1.Controls.Add(this.lblSubtotalValue);
            this.groupBox1.Controls.Add(this.lblFreight);
            this.groupBox1.Controls.Add(this.txtFreight);
            this.groupBox1.Controls.Add(this.txtSubtotalValue);
            this.groupBox1.Controls.Add(this.lblTaxValue);
            this.groupBox1.Controls.Add(this.lblTotalValue);
            this.groupBox1.Controls.Add(this.txtTotalValue);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblPlus);
            this.groupBox1.Controls.Add(this.lblEqual);
            this.groupBox1.CornerRadius = 5;
            this.groupBox1.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.groupBox1.DropShadowThickness = 3;
            this.groupBox1.DropShadowVisible = true;
            this.groupBox1.Location = new System.Drawing.Point(324, 370);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(477, 68);
            this.groupBox1.TabIndex = 98;
            this.groupBox1.TabStop = false;
            // 
            // lblBalanceDue
            // 
            this.lblBalanceDue.AutoSize = true;
            this.lblBalanceDue.BackColor = System.Drawing.Color.Transparent;
            this.lblBalanceDue.Location = new System.Drawing.Point(390, 7);
            this.lblBalanceDue.Name = "lblBalanceDue";
            this.lblBalanceDue.Size = new System.Drawing.Size(72, 13);
            this.lblBalanceDue.TabIndex = 90;
            this.lblBalanceDue.Text = "Balance Due:";
            // 
            // txtBalanceDue
            // 
            this.txtBalanceDue.Location = new System.Drawing.Point(393, 34);
            this.txtBalanceDue.Name = "txtBalanceDue";
            this.txtBalanceDue.ReadOnly = true;
            this.txtBalanceDue.Size = new System.Drawing.Size(71, 20);
            this.txtBalanceDue.TabIndex = 88;
            this.txtBalanceDue.Text = "0";
            // 
            // txtTaxValue
            // 
            this.txtTaxValue.Location = new System.Drawing.Point(240, 34);
            this.txtTaxValue.Name = "txtTaxValue";
            this.txtTaxValue.ReadOnly = true;
            this.txtTaxValue.Size = new System.Drawing.Size(52, 20);
            this.txtTaxValue.TabIndex = 28;
            // 
            // cboFreightTaxCode
            // 
            this.cboFreightTaxCode.FormattingEnabled = true;
            this.cboFreightTaxCode.Location = new System.Drawing.Point(153, 33);
            this.cboFreightTaxCode.Name = "cboFreightTaxCode";
            this.cboFreightTaxCode.Size = new System.Drawing.Size(61, 21);
            this.cboFreightTaxCode.TabIndex = 19;
            // 
            // lblSubtotalValue
            // 
            this.lblSubtotalValue.AutoSize = true;
            this.lblSubtotalValue.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtotalValue.Location = new System.Drawing.Point(8, 7);
            this.lblSubtotalValue.Name = "lblSubtotalValue";
            this.lblSubtotalValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSubtotalValue.Size = new System.Drawing.Size(46, 13);
            this.lblSubtotalValue.TabIndex = 24;
            this.lblSubtotalValue.Text = "Subtotal";
            // 
            // lblFreight
            // 
            this.lblFreight.AutoSize = true;
            this.lblFreight.BackColor = System.Drawing.Color.Transparent;
            this.lblFreight.Location = new System.Drawing.Point(96, 7);
            this.lblFreight.Name = "lblFreight";
            this.lblFreight.Size = new System.Drawing.Size(39, 13);
            this.lblFreight.TabIndex = 20;
            this.lblFreight.Text = "Freight";
            // 
            // txtFreight
            // 
            this.txtFreight.Location = new System.Drawing.Point(93, 34);
            this.txtFreight.Name = "txtFreight";
            this.txtFreight.Size = new System.Drawing.Size(52, 20);
            this.txtFreight.TabIndex = 27;
            this.txtFreight.Text = "0";
            // 
            // txtSubtotalValue
            // 
            this.txtSubtotalValue.Location = new System.Drawing.Point(10, 34);
            this.txtSubtotalValue.Name = "txtSubtotalValue";
            this.txtSubtotalValue.ReadOnly = true;
            this.txtSubtotalValue.Size = new System.Drawing.Size(64, 20);
            this.txtSubtotalValue.TabIndex = 27;
            // 
            // lblTaxValue
            // 
            this.lblTaxValue.AutoSize = true;
            this.lblTaxValue.BackColor = System.Drawing.Color.Transparent;
            this.lblTaxValue.Location = new System.Drawing.Point(239, 7);
            this.lblTaxValue.Name = "lblTaxValue";
            this.lblTaxValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTaxValue.Size = new System.Drawing.Size(25, 13);
            this.lblTaxValue.TabIndex = 25;
            this.lblTaxValue.Text = "Tax";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalValue.Location = new System.Drawing.Point(313, 7);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotalValue.Size = new System.Drawing.Size(31, 13);
            this.lblTotalValue.TabIndex = 26;
            this.lblTotalValue.Text = "Total";
            // 
            // txtTotalValue
            // 
            this.txtTotalValue.Location = new System.Drawing.Point(311, 34);
            this.txtTotalValue.Name = "txtTotalValue";
            this.txtTotalValue.ReadOnly = true;
            this.txtTotalValue.Size = new System.Drawing.Size(74, 20);
            this.txtTotalValue.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(220, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "+";
            // 
            // lblPlus
            // 
            this.lblPlus.AutoSize = true;
            this.lblPlus.BackColor = System.Drawing.Color.Transparent;
            this.lblPlus.Location = new System.Drawing.Point(77, 37);
            this.lblPlus.Name = "lblPlus";
            this.lblPlus.Size = new System.Drawing.Size(13, 13);
            this.lblPlus.TabIndex = 31;
            this.lblPlus.Text = "+";
            // 
            // lblEqual
            // 
            this.lblEqual.AutoSize = true;
            this.lblEqual.BackColor = System.Drawing.Color.Transparent;
            this.lblEqual.Location = new System.Drawing.Point(295, 37);
            this.lblEqual.Name = "lblEqual";
            this.lblEqual.Size = new System.Drawing.Size(13, 13);
            this.lblEqual.TabIndex = 30;
            this.lblEqual.Text = "=";
            // 
            // FrmSaleOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(809, 553);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.czRoundedGroupBox1);
            this.Controls.Add(this.btnBarcode);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gpSummary);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRecord);
            this.Name = "FrmSaleOrder";
            this.Text = "Sale Order";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tc.ResumeLayout(false);
            this.tpSaleOrder.ResumeLayout(false);
            this.gbCustomerDetails.ResumeLayout(false);
            this.gbCustomerDetails.PerformLayout();
            this.gbComments.ResumeLayout(false);
            this.gbComments.PerformLayout();
            this.gbMainDetail.ResumeLayout(false);
            this.gbMainDetail.PerformLayout();
            this.gbShipTo.ResumeLayout(false);
            this.gbShipTo.PerformLayout();
            this.tpSaleLines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleLines)).EndInit();
            this.gpSummary.ResumeLayout(false);
            this.gpSummary.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.czRoundedGroupBox1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.ComboBox cboReferralSource;
        private System.Windows.Forms.Label lblReferralSource;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TabControl tc;
        private System.Windows.Forms.TabPage tpSaleOrder;
        private System.Windows.Forms.CZRoundedGroupBox gbCustomerDetails;
        private System.Windows.Forms.ComboBox cboAddresses;
        private System.Windows.Forms.Label lblCustomerPhone2;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label lblDestinationCountry;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cboCurrency;
        private System.Windows.Forms.Label lblCustomerPO;
        private System.Windows.Forms.Label lblCustomerEmail;
        private System.Windows.Forms.Label lblCustomerPhone1;
        private System.Windows.Forms.Label lblCustomerCity;
        private System.Windows.Forms.TextBox txtCustomerPhone2;
        private System.Windows.Forms.TextBox txtCustomerPO;
        private System.Windows.Forms.TextBox txtCustomerEmail;
        private System.Windows.Forms.TextBox txtCustomerPhone1;
        private System.Windows.Forms.TextBox txtDestinationCountry;
        private System.Windows.Forms.TextBox txtCustomerCity;
        private System.Windows.Forms.CZRoundedGroupBox gbComments;
        private System.Windows.Forms.ComboBox cboSalesperson;
        private System.Windows.Forms.CheckBox chkTaxInclusive;
        private System.Windows.Forms.ComboBox cboTerms;
        private System.Windows.Forms.Label lblTerms;
        private System.Windows.Forms.ComboBox cboComments;
        private System.Windows.Forms.Label lblSalesperson;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.CZRoundedGroupBox gbMainDetail;
        private System.Windows.Forms.DateTimePicker dtpSaleDate;
        private System.Windows.Forms.TextBox txtJournalMemo;
        private System.Windows.Forms.Label lblSaleDate;
        private System.Windows.Forms.Label lblJournalMemo;
        private System.Windows.Forms.CZRoundedGroupBox gbShipTo;
        private System.Windows.Forms.Button btnCopyAddress;
        private System.Windows.Forms.Button btnClearAddress;
        private System.Windows.Forms.DateTimePicker dtpPromisedDate;
        private System.Windows.Forms.ComboBox cboShippingMethod;
        private System.Windows.Forms.TextBox txtAddressLine4;
        private System.Windows.Forms.Label lblAddressLine4;
        private System.Windows.Forms.TextBox txtAddressLine3;
        private System.Windows.Forms.Label lblAddressLine3;
        private System.Windows.Forms.Label lblPromisedDate;
        private System.Windows.Forms.TextBox txtAddressLine1;
        private System.Windows.Forms.Label lblAddressLine1;
        private System.Windows.Forms.Label lblShippingMethod;
        private System.Windows.Forms.TextBox txtAddressLine2;
        private System.Windows.Forms.Label lblAddressLine2;
        private System.Windows.Forms.TabPage tpSaleLines;
        private System.Windows.Forms.DataGridView dgvSaleLines;
        private System.Windows.Forms.CZRoundedGroupBox gpSummary;
        private System.Windows.Forms.TextBox txtSaleNo;
        private System.Windows.Forms.Label lblSaleNo;
        private System.Windows.Forms.ComboBox cboSaleLayout;
        private System.Windows.Forms.Label lblSaleLayout;
        private System.Windows.Forms.ComboBox cboInvoiceDelivery;
        private System.Windows.Forms.Label lblInvoiceDelivery;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.CZRoundedGroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPaidToday;
        private System.Windows.Forms.Label lblPaidToday;
        private System.Windows.Forms.ComboBox cboPaymentMethod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDelLine;
        private System.Windows.Forms.Button btnNewLine;
        private System.Windows.Forms.Button btnReceiveGoods;
        private System.Windows.Forms.Button btnBarcode;
        private System.Windows.Forms.CZRoundedGroupBox czRoundedGroupBox1;
        private System.Windows.Forms.CZRoundedGroupBox groupBox1;
        private System.Windows.Forms.Label lblBalanceDue;
        private System.Windows.Forms.TextBox txtBalanceDue;
        private System.Windows.Forms.TextBox txtTaxValue;
        private System.Windows.Forms.ComboBox cboFreightTaxCode;
        private System.Windows.Forms.Label lblSubtotalValue;
        private System.Windows.Forms.Label lblFreight;
        private System.Windows.Forms.TextBox txtFreight;
        private System.Windows.Forms.TextBox txtSubtotalValue;
        private System.Windows.Forms.Label lblTaxValue;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.TextBox txtTotalValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPlus;
        private System.Windows.Forms.Label lblEqual;
    }
}