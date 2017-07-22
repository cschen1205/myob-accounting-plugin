namespace DacII.WinForms.Purchases
{
    partial class FrmPurchaseOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPurchaseOrder));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnBarcode = new System.Windows.Forms.Button();
            this.cboPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.txtPaidToday = new System.Windows.Forms.TextBox();
            this.lblPaidToday = new System.Windows.Forms.Label();
            this.cboReferralSource = new System.Windows.Forms.ComboBox();
            this.lblReferralSource = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tc = new System.Windows.Forms.TabControl();
            this.tpPurchaseOrder = new System.Windows.Forms.TabPage();
            this.gbSupplierDetails = new System.Windows.Forms.CZRoundedGroupBox();
            this.lblSupplierPhone2 = new System.Windows.Forms.Label();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.lblDestinationCountry = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblSupplierPO = new System.Windows.Forms.Label();
            this.lblSupplierEmail = new System.Windows.Forms.Label();
            this.lblSupplierPhone1 = new System.Windows.Forms.Label();
            this.lblSupplierCity = new System.Windows.Forms.Label();
            this.txtSupplierPhone2 = new System.Windows.Forms.TextBox();
            this.txtSupplierPO = new System.Windows.Forms.TextBox();
            this.txtSupplierEmail = new System.Windows.Forms.TextBox();
            this.txtSupplierPhone1 = new System.Windows.Forms.TextBox();
            this.txtSupplierCountry = new System.Windows.Forms.TextBox();
            this.txtSupplierCity = new System.Windows.Forms.TextBox();
            this.gbComments = new System.Windows.Forms.CZRoundedGroupBox();
            this.cboTerms = new System.Windows.Forms.ComboBox();
            this.lblTerms = new System.Windows.Forms.Label();
            this.cboComments = new System.Windows.Forms.ComboBox();
            this.lblComments = new System.Windows.Forms.Label();
            this.gbMainDetail = new System.Windows.Forms.CZRoundedGroupBox();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.txtJournalMemo = new System.Windows.Forms.TextBox();
            this.lblPurchaseDate = new System.Windows.Forms.Label();
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
            this.tpPurchaseLines = new System.Windows.Forms.TabPage();
            this.btnDelLine = new System.Windows.Forms.Button();
            this.btnReceiveGoods = new System.Windows.Forms.Button();
            this.btnNewLine = new System.Windows.Forms.Button();
            this.dgvPurchaseLines = new System.Windows.Forms.DataGridView();
            this.cboCurrency = new System.Windows.Forms.ComboBox();
            this.chkTaxInclusive = new System.Windows.Forms.CheckBox();
            this.gpSummary = new System.Windows.Forms.CZRoundedGroupBox();
            this.txtPurchaseNo = new System.Windows.Forms.TextBox();
            this.lblPurchaseNo = new System.Windows.Forms.Label();
            this.cboPurchaseLayout = new System.Windows.Forms.ComboBox();
            this.lblPurchaseLayout = new System.Windows.Forms.Label();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.cboInvoiceDelivery = new System.Windows.Forms.ComboBox();
            this.lblInvoiceDelivery = new System.Windows.Forms.Label();
            this.czRoundedGroupBox1 = new System.Windows.Forms.CZRoundedGroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tc.SuspendLayout();
            this.tpPurchaseOrder.SuspendLayout();
            this.gbSupplierDetails.SuspendLayout();
            this.gbComments.SuspendLayout();
            this.gbMainDetail.SuspendLayout();
            this.gbShipTo.SuspendLayout();
            this.tpPurchaseLines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseLines)).BeginInit();
            this.gpSummary.SuspendLayout();
            this.czRoundedGroupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(331, 397);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(477, 68);
            this.groupBox1.TabIndex = 87;
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
            // btnBarcode
            // 
            this.btnBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBarcode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBarcode.BackgroundImage = global::DacII.Properties.Resources.barcode_48x48;
            this.btnBarcode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBarcode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBarcode.Location = new System.Drawing.Point(620, 483);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(56, 56);
            this.btnBarcode.TabIndex = 96;
            this.btnBarcode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBarcode.UseVisualStyleBackColor = false;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // cboPaymentMethod
            // 
            this.cboPaymentMethod.FormattingEnabled = true;
            this.cboPaymentMethod.Location = new System.Drawing.Point(228, 81);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(103, 21);
            this.cboPaymentMethod.TabIndex = 92;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(138, 85);
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
            this.btnPrint.Location = new System.Drawing.Point(555, 483);
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
            this.btnClose.Location = new System.Drawing.Point(752, 483);
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
            this.btnRecord.Location = new System.Drawing.Point(684, 483);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(56, 56);
            this.btnRecord.TabIndex = 89;
            this.btnRecord.Text = "Record";
            this.btnRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRecord.UseVisualStyleBackColor = false;
            this.btnRecord.Click += new System.EventHandler(this.Record);
            // 
            // txtPaidToday
            // 
            this.txtPaidToday.Location = new System.Drawing.Point(64, 82);
            this.txtPaidToday.Name = "txtPaidToday";
            this.txtPaidToday.Size = new System.Drawing.Size(68, 20);
            this.txtPaidToday.TabIndex = 88;
            this.txtPaidToday.Text = "0";
            // 
            // lblPaidToday
            // 
            this.lblPaidToday.AutoSize = true;
            this.lblPaidToday.BackColor = System.Drawing.Color.Transparent;
            this.lblPaidToday.Location = new System.Drawing.Point(6, 84);
            this.lblPaidToday.Name = "lblPaidToday";
            this.lblPaidToday.Size = new System.Drawing.Size(31, 13);
            this.lblPaidToday.TabIndex = 87;
            this.lblPaidToday.Text = "Paid:";
            // 
            // cboReferralSource
            // 
            this.cboReferralSource.FormattingEnabled = true;
            this.cboReferralSource.Location = new System.Drawing.Point(106, 81);
            this.cboReferralSource.Name = "cboReferralSource";
            this.cboReferralSource.Size = new System.Drawing.Size(282, 21);
            this.cboReferralSource.TabIndex = 85;
            // 
            // lblReferralSource
            // 
            this.lblReferralSource.AutoSize = true;
            this.lblReferralSource.Location = new System.Drawing.Point(9, 84);
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
            this.tc.Controls.Add(this.tpPurchaseOrder);
            this.tc.Controls.Add(this.tpPurchaseLines);
            this.tc.HotTrack = true;
            this.tc.Location = new System.Drawing.Point(8, 28);
            this.tc.Multiline = true;
            this.tc.Name = "tc";
            this.tc.SelectedIndex = 0;
            this.tc.Size = new System.Drawing.Size(777, 349);
            this.tc.TabIndex = 93;
            // 
            // tpPurchaseOrder
            // 
            this.tpPurchaseOrder.Controls.Add(this.gbSupplierDetails);
            this.tpPurchaseOrder.Controls.Add(this.gbComments);
            this.tpPurchaseOrder.Controls.Add(this.gbMainDetail);
            this.tpPurchaseOrder.Controls.Add(this.gbShipTo);
            this.tpPurchaseOrder.Location = new System.Drawing.Point(4, 22);
            this.tpPurchaseOrder.Name = "tpPurchaseOrder";
            this.tpPurchaseOrder.Padding = new System.Windows.Forms.Padding(3);
            this.tpPurchaseOrder.Size = new System.Drawing.Size(769, 323);
            this.tpPurchaseOrder.TabIndex = 0;
            this.tpPurchaseOrder.Text = "Purchase Order";
            this.tpPurchaseOrder.UseVisualStyleBackColor = true;
            // 
            // gbSupplierDetails
            // 
            this.gbSupplierDetails.BackgroundColor = System.Drawing.Color.White;
            this.gbSupplierDetails.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbSupplierDetails.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbSupplierDetails.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbSupplierDetails.BorderWidth = 1F;
            this.gbSupplierDetails.Caption = "Purchase Order Supplier Information";
            this.gbSupplierDetails.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbSupplierDetails.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbSupplierDetails.CaptionHeight = 25;
            this.gbSupplierDetails.CaptionVisible = true;
            this.gbSupplierDetails.Controls.Add(this.lblSupplierPhone2);
            this.gbSupplierDetails.Controls.Add(this.cboSupplier);
            this.gbSupplierDetails.Controls.Add(this.lblDestinationCountry);
            this.gbSupplierDetails.Controls.Add(this.lblSupplier);
            this.gbSupplierDetails.Controls.Add(this.lblSupplierPO);
            this.gbSupplierDetails.Controls.Add(this.lblSupplierEmail);
            this.gbSupplierDetails.Controls.Add(this.lblSupplierPhone1);
            this.gbSupplierDetails.Controls.Add(this.lblSupplierCity);
            this.gbSupplierDetails.Controls.Add(this.txtSupplierPhone2);
            this.gbSupplierDetails.Controls.Add(this.txtSupplierPO);
            this.gbSupplierDetails.Controls.Add(this.txtSupplierEmail);
            this.gbSupplierDetails.Controls.Add(this.txtSupplierPhone1);
            this.gbSupplierDetails.Controls.Add(this.txtSupplierCountry);
            this.gbSupplierDetails.Controls.Add(this.txtSupplierCity);
            this.gbSupplierDetails.CornerRadius = 5;
            this.gbSupplierDetails.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbSupplierDetails.DropShadowThickness = 3;
            this.gbSupplierDetails.DropShadowVisible = false;
            this.gbSupplierDetails.Location = new System.Drawing.Point(7, 125);
            this.gbSupplierDetails.Name = "gbSupplierDetails";
            this.gbSupplierDetails.Size = new System.Drawing.Size(347, 174);
            this.gbSupplierDetails.TabIndex = 85;
            this.gbSupplierDetails.TabStop = false;
            // 
            // lblSupplierPhone2
            // 
            this.lblSupplierPhone2.AutoSize = true;
            this.lblSupplierPhone2.Location = new System.Drawing.Point(6, 89);
            this.lblSupplierPhone2.Name = "lblSupplierPhone2";
            this.lblSupplierPhone2.Size = new System.Drawing.Size(47, 13);
            this.lblSupplierPhone2.TabIndex = 0;
            this.lblSupplierPhone2.Text = "Phone 2";
            // 
            // cboSupplier
            // 
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(58, 31);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(273, 21);
            this.cboSupplier.TabIndex = 2;
            this.cboSupplier.SelectedIndexChanged += new System.EventHandler(this.OnSupplierChanged);
            // 
            // lblDestinationCountry
            // 
            this.lblDestinationCountry.AutoSize = true;
            this.lblDestinationCountry.Location = new System.Drawing.Point(180, 89);
            this.lblDestinationCountry.Name = "lblDestinationCountry";
            this.lblDestinationCountry.Size = new System.Drawing.Size(43, 13);
            this.lblDestinationCountry.TabIndex = 0;
            this.lblDestinationCountry.Text = "Country";
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(6, 34);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(45, 13);
            this.lblSupplier.TabIndex = 0;
            this.lblSupplier.Text = "Supplier";
            // 
            // lblSupplierPO
            // 
            this.lblSupplierPO.AutoSize = true;
            this.lblSupplierPO.Location = new System.Drawing.Point(6, 144);
            this.lblSupplierPO.Name = "lblSupplierPO";
            this.lblSupplierPO.Size = new System.Drawing.Size(32, 13);
            this.lblSupplierPO.TabIndex = 0;
            this.lblSupplierPO.Text = "PO #";
            // 
            // lblSupplierEmail
            // 
            this.lblSupplierEmail.AutoSize = true;
            this.lblSupplierEmail.Location = new System.Drawing.Point(6, 117);
            this.lblSupplierEmail.Name = "lblSupplierEmail";
            this.lblSupplierEmail.Size = new System.Drawing.Size(35, 13);
            this.lblSupplierEmail.TabIndex = 0;
            this.lblSupplierEmail.Text = "E-mail";
            // 
            // lblSupplierPhone1
            // 
            this.lblSupplierPhone1.AutoSize = true;
            this.lblSupplierPhone1.Location = new System.Drawing.Point(6, 61);
            this.lblSupplierPhone1.Name = "lblSupplierPhone1";
            this.lblSupplierPhone1.Size = new System.Drawing.Size(47, 13);
            this.lblSupplierPhone1.TabIndex = 0;
            this.lblSupplierPhone1.Text = "Phone 1";
            // 
            // lblSupplierCity
            // 
            this.lblSupplierCity.AutoSize = true;
            this.lblSupplierCity.Location = new System.Drawing.Point(198, 63);
            this.lblSupplierCity.Name = "lblSupplierCity";
            this.lblSupplierCity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSupplierCity.Size = new System.Drawing.Size(24, 13);
            this.lblSupplierCity.TabIndex = 0;
            this.lblSupplierCity.Text = "City";
            // 
            // txtSupplierPhone2
            // 
            this.txtSupplierPhone2.Enabled = false;
            this.txtSupplierPhone2.Location = new System.Drawing.Point(59, 86);
            this.txtSupplierPhone2.Name = "txtSupplierPhone2";
            this.txtSupplierPhone2.Size = new System.Drawing.Size(114, 20);
            this.txtSupplierPhone2.TabIndex = 1;
            // 
            // txtSupplierPO
            // 
            this.txtSupplierPO.Location = new System.Drawing.Point(58, 141);
            this.txtSupplierPO.Name = "txtSupplierPO";
            this.txtSupplierPO.Size = new System.Drawing.Size(115, 20);
            this.txtSupplierPO.TabIndex = 1;
            // 
            // txtSupplierEmail
            // 
            this.txtSupplierEmail.Enabled = false;
            this.txtSupplierEmail.Location = new System.Drawing.Point(59, 114);
            this.txtSupplierEmail.Name = "txtSupplierEmail";
            this.txtSupplierEmail.Size = new System.Drawing.Size(114, 20);
            this.txtSupplierEmail.TabIndex = 1;
            // 
            // txtSupplierPhone1
            // 
            this.txtSupplierPhone1.Enabled = false;
            this.txtSupplierPhone1.Location = new System.Drawing.Point(58, 59);
            this.txtSupplierPhone1.Name = "txtSupplierPhone1";
            this.txtSupplierPhone1.Size = new System.Drawing.Size(115, 20);
            this.txtSupplierPhone1.TabIndex = 1;
            // 
            // txtSupplierCountry
            // 
            this.txtSupplierCountry.Location = new System.Drawing.Point(228, 86);
            this.txtSupplierCountry.Name = "txtSupplierCountry";
            this.txtSupplierCountry.Size = new System.Drawing.Size(103, 20);
            this.txtSupplierCountry.TabIndex = 1;
            // 
            // txtSupplierCity
            // 
            this.txtSupplierCity.Enabled = false;
            this.txtSupplierCity.Location = new System.Drawing.Point(228, 59);
            this.txtSupplierCity.Name = "txtSupplierCity";
            this.txtSupplierCity.Size = new System.Drawing.Size(103, 20);
            this.txtSupplierCity.TabIndex = 1;
            // 
            // gbComments
            // 
            this.gbComments.BackgroundColor = System.Drawing.Color.White;
            this.gbComments.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbComments.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbComments.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbComments.BorderWidth = 1F;
            this.gbComments.Caption = "Purchase Order Extra Information";
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
            this.gbComments.Size = new System.Drawing.Size(403, 111);
            this.gbComments.TabIndex = 84;
            this.gbComments.TabStop = false;
            // 
            // cboTerms
            // 
            this.cboTerms.FormattingEnabled = true;
            this.cboTerms.Location = new System.Drawing.Point(106, 55);
            this.cboTerms.Name = "cboTerms";
            this.cboTerms.Size = new System.Drawing.Size(282, 21);
            this.cboTerms.TabIndex = 2;
            // 
            // lblTerms
            // 
            this.lblTerms.AutoSize = true;
            this.lblTerms.Location = new System.Drawing.Point(6, 58);
            this.lblTerms.Name = "lblTerms";
            this.lblTerms.Size = new System.Drawing.Size(36, 13);
            this.lblTerms.TabIndex = 0;
            this.lblTerms.Text = "Terms";
            // 
            // cboComments
            // 
            this.cboComments.FormattingEnabled = true;
            this.cboComments.Location = new System.Drawing.Point(106, 30);
            this.cboComments.Name = "cboComments";
            this.cboComments.Size = new System.Drawing.Size(282, 21);
            this.cboComments.TabIndex = 2;
            // 
            // lblComments
            // 
            this.lblComments.AutoSize = true;
            this.lblComments.Location = new System.Drawing.Point(6, 37);
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
            this.gbMainDetail.Caption = "Purchase Order Header Information";
            this.gbMainDetail.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbMainDetail.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbMainDetail.CaptionHeight = 25;
            this.gbMainDetail.CaptionVisible = true;
            this.gbMainDetail.Controls.Add(this.dtpPurchaseDate);
            this.gbMainDetail.Controls.Add(this.txtJournalMemo);
            this.gbMainDetail.Controls.Add(this.lblPurchaseDate);
            this.gbMainDetail.Controls.Add(this.cboPaymentMethod);
            this.gbMainDetail.Controls.Add(this.dtpPromisedDate);
            this.gbMainDetail.Controls.Add(this.label4);
            this.gbMainDetail.Controls.Add(this.lblJournalMemo);
            this.gbMainDetail.Controls.Add(this.lblPromisedDate);
            this.gbMainDetail.Controls.Add(this.lblPaidToday);
            this.gbMainDetail.Controls.Add(this.txtPaidToday);
            this.gbMainDetail.CornerRadius = 5;
            this.gbMainDetail.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbMainDetail.DropShadowThickness = 3;
            this.gbMainDetail.DropShadowVisible = false;
            this.gbMainDetail.Location = new System.Drawing.Point(7, 8);
            this.gbMainDetail.Name = "gbMainDetail";
            this.gbMainDetail.Size = new System.Drawing.Size(347, 111);
            this.gbMainDetail.TabIndex = 83;
            this.gbMainDetail.TabStop = false;
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPurchaseDate.Location = new System.Drawing.Point(64, 31);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(109, 20);
            this.dtpPurchaseDate.TabIndex = 3;
            // 
            // txtJournalMemo
            // 
            this.txtJournalMemo.Location = new System.Drawing.Point(64, 57);
            this.txtJournalMemo.Name = "txtJournalMemo";
            this.txtJournalMemo.Size = new System.Drawing.Size(267, 20);
            this.txtJournalMemo.TabIndex = 1;
            // 
            // lblPurchaseDate
            // 
            this.lblPurchaseDate.AutoSize = true;
            this.lblPurchaseDate.Location = new System.Drawing.Point(6, 35);
            this.lblPurchaseDate.Name = "lblPurchaseDate";
            this.lblPurchaseDate.Size = new System.Drawing.Size(30, 13);
            this.lblPurchaseDate.TabIndex = 0;
            this.lblPurchaseDate.Text = "Date";
            // 
            // dtpPromisedDate
            // 
            this.dtpPromisedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPromisedDate.Location = new System.Drawing.Point(228, 31);
            this.dtpPromisedDate.Name = "dtpPromisedDate";
            this.dtpPromisedDate.ShowCheckBox = true;
            this.dtpPromisedDate.Size = new System.Drawing.Size(103, 20);
            this.dtpPromisedDate.TabIndex = 3;
            // 
            // lblJournalMemo
            // 
            this.lblJournalMemo.AutoSize = true;
            this.lblJournalMemo.Location = new System.Drawing.Point(6, 60);
            this.lblJournalMemo.Name = "lblJournalMemo";
            this.lblJournalMemo.Size = new System.Drawing.Size(36, 13);
            this.lblJournalMemo.TabIndex = 0;
            this.lblJournalMemo.Text = "Memo";
            // 
            // lblPromisedDate
            // 
            this.lblPromisedDate.AutoSize = true;
            this.lblPromisedDate.Location = new System.Drawing.Point(176, 34);
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
            this.gbShipTo.Caption = "Purchase Order Delivery Information";
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
            this.gbShipTo.Location = new System.Drawing.Point(360, 125);
            this.gbShipTo.Name = "gbShipTo";
            this.gbShipTo.Size = new System.Drawing.Size(403, 174);
            this.gbShipTo.TabIndex = 86;
            this.gbShipTo.TabStop = false;
            // 
            // cboAddresses
            // 
            this.cboAddresses.FormattingEnabled = true;
            this.cboAddresses.Location = new System.Drawing.Point(272, 58);
            this.cboAddresses.Name = "cboAddresses";
            this.cboAddresses.Size = new System.Drawing.Size(116, 21);
            this.cboAddresses.TabIndex = 19;
            this.cboAddresses.SelectedIndexChanged += new System.EventHandler(this.OnAddressIndexChanged);
            // 
            // btnCopyAddress
            // 
            this.btnCopyAddress.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCopyAddress.FlatAppearance.BorderSize = 0;
            this.btnCopyAddress.Location = new System.Drawing.Point(272, 84);
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
            this.btnClearAddress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClearAddress.FlatAppearance.BorderSize = 0;
            this.btnClearAddress.Location = new System.Drawing.Point(332, 84);
            this.btnClearAddress.Name = "btnClearAddress";
            this.btnClearAddress.Size = new System.Drawing.Size(56, 22);
            this.btnClearAddress.TabIndex = 29;
            this.btnClearAddress.Text = "Cear";
            this.btnClearAddress.UseVisualStyleBackColor = false;
            this.btnClearAddress.Click += new System.EventHandler(this.btnClearAddress_Click);
            // 
            // cboShippingMethod
            // 
            this.cboShippingMethod.FormattingEnabled = true;
            this.cboShippingMethod.Location = new System.Drawing.Point(106, 30);
            this.cboShippingMethod.Name = "cboShippingMethod";
            this.cboShippingMethod.Size = new System.Drawing.Size(158, 21);
            this.cboShippingMethod.TabIndex = 22;
            // 
            // txtAddressLine4
            // 
            this.txtAddressLine4.Location = new System.Drawing.Point(106, 138);
            this.txtAddressLine4.Name = "txtAddressLine4";
            this.txtAddressLine4.Size = new System.Drawing.Size(158, 20);
            this.txtAddressLine4.TabIndex = 25;
            // 
            // lblAddressLine4
            // 
            this.lblAddressLine4.AutoSize = true;
            this.lblAddressLine4.Location = new System.Drawing.Point(9, 141);
            this.lblAddressLine4.Name = "lblAddressLine4";
            this.lblAddressLine4.Size = new System.Drawing.Size(77, 13);
            this.lblAddressLine4.TabIndex = 22;
            this.lblAddressLine4.Text = "Address Line 4";
            // 
            // txtAddressLine3
            // 
            this.txtAddressLine3.Location = new System.Drawing.Point(106, 112);
            this.txtAddressLine3.Name = "txtAddressLine3";
            this.txtAddressLine3.Size = new System.Drawing.Size(158, 20);
            this.txtAddressLine3.TabIndex = 26;
            // 
            // lblAddressLine3
            // 
            this.lblAddressLine3.AutoSize = true;
            this.lblAddressLine3.Location = new System.Drawing.Point(9, 115);
            this.lblAddressLine3.Name = "lblAddressLine3";
            this.lblAddressLine3.Size = new System.Drawing.Size(77, 13);
            this.lblAddressLine3.TabIndex = 23;
            this.lblAddressLine3.Text = "Address Line 3";
            // 
            // txtAddressLine1
            // 
            this.txtAddressLine1.Location = new System.Drawing.Point(106, 59);
            this.txtAddressLine1.Name = "txtAddressLine1";
            this.txtAddressLine1.Size = new System.Drawing.Size(158, 20);
            this.txtAddressLine1.TabIndex = 27;
            // 
            // lblAddressLine1
            // 
            this.lblAddressLine1.AutoSize = true;
            this.lblAddressLine1.Location = new System.Drawing.Point(9, 62);
            this.lblAddressLine1.Name = "lblAddressLine1";
            this.lblAddressLine1.Size = new System.Drawing.Size(77, 13);
            this.lblAddressLine1.TabIndex = 20;
            this.lblAddressLine1.Text = "Address Line 1";
            // 
            // lblShippingMethod
            // 
            this.lblShippingMethod.AutoSize = true;
            this.lblShippingMethod.Location = new System.Drawing.Point(9, 33);
            this.lblShippingMethod.Name = "lblShippingMethod";
            this.lblShippingMethod.Size = new System.Drawing.Size(90, 13);
            this.lblShippingMethod.TabIndex = 0;
            this.lblShippingMethod.Text = "Shipping Method:";
            // 
            // txtAddressLine2
            // 
            this.txtAddressLine2.Location = new System.Drawing.Point(106, 86);
            this.txtAddressLine2.Name = "txtAddressLine2";
            this.txtAddressLine2.Size = new System.Drawing.Size(158, 20);
            this.txtAddressLine2.TabIndex = 24;
            // 
            // lblAddressLine2
            // 
            this.lblAddressLine2.AutoSize = true;
            this.lblAddressLine2.Location = new System.Drawing.Point(9, 89);
            this.lblAddressLine2.Name = "lblAddressLine2";
            this.lblAddressLine2.Size = new System.Drawing.Size(77, 13);
            this.lblAddressLine2.TabIndex = 21;
            this.lblAddressLine2.Text = "Address Line 2";
            // 
            // tpPurchaseLines
            // 
            this.tpPurchaseLines.Controls.Add(this.btnDelLine);
            this.tpPurchaseLines.Controls.Add(this.btnReceiveGoods);
            this.tpPurchaseLines.Controls.Add(this.btnNewLine);
            this.tpPurchaseLines.Controls.Add(this.dgvPurchaseLines);
            this.tpPurchaseLines.Location = new System.Drawing.Point(4, 22);
            this.tpPurchaseLines.Name = "tpPurchaseLines";
            this.tpPurchaseLines.Padding = new System.Windows.Forms.Padding(3);
            this.tpPurchaseLines.Size = new System.Drawing.Size(769, 323);
            this.tpPurchaseLines.TabIndex = 1;
            this.tpPurchaseLines.Text = "Purchase Lines";
            this.tpPurchaseLines.UseVisualStyleBackColor = true;
            // 
            // btnDelLine
            // 
            this.btnDelLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelLine.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelLine.BackgroundImage = global::DacII.Properties.Resources.delete_16x16;
            this.btnDelLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelLine.Location = new System.Drawing.Point(731, 285);
            this.btnDelLine.Name = "btnDelLine";
            this.btnDelLine.Size = new System.Drawing.Size(32, 32);
            this.btnDelLine.TabIndex = 9;
            this.btnDelLine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelLine.UseVisualStyleBackColor = false;
            this.btnDelLine.Click += new System.EventHandler(this.btnDelLine_Click);
            // 
            // btnReceiveGoods
            // 
            this.btnReceiveGoods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReceiveGoods.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReceiveGoods.BackgroundImage = global::DacII.Properties.Resources.receive_item_16x16;
            this.btnReceiveGoods.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReceiveGoods.Location = new System.Drawing.Point(663, 285);
            this.btnReceiveGoods.Name = "btnReceiveGoods";
            this.btnReceiveGoods.Size = new System.Drawing.Size(32, 32);
            this.btnReceiveGoods.TabIndex = 8;
            this.btnReceiveGoods.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReceiveGoods.UseVisualStyleBackColor = false;
            this.btnReceiveGoods.Click += new System.EventHandler(this.btnNewLine_Click);
            // 
            // btnNewLine
            // 
            this.btnNewLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewLine.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNewLine.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNewLine.BackgroundImage")));
            this.btnNewLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNewLine.Location = new System.Drawing.Point(698, 285);
            this.btnNewLine.Name = "btnNewLine";
            this.btnNewLine.Size = new System.Drawing.Size(32, 32);
            this.btnNewLine.TabIndex = 8;
            this.btnNewLine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewLine.UseVisualStyleBackColor = false;
            this.btnNewLine.Click += new System.EventHandler(this.btnNewLine_Click);
            // 
            // dgvPurchaseLines
            // 
            this.dgvPurchaseLines.AllowUserToAddRows = false;
            this.dgvPurchaseLines.AllowUserToDeleteRows = false;
            this.dgvPurchaseLines.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.dgvPurchaseLines.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPurchaseLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPurchaseLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPurchaseLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPurchaseLines.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPurchaseLines.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPurchaseLines.Location = new System.Drawing.Point(6, 6);
            this.dgvPurchaseLines.MultiSelect = false;
            this.dgvPurchaseLines.Name = "dgvPurchaseLines";
            this.dgvPurchaseLines.RowHeadersVisible = false;
            this.dgvPurchaseLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchaseLines.Size = new System.Drawing.Size(757, 273);
            this.dgvPurchaseLines.TabIndex = 0;
            this.dgvPurchaseLines.DoubleClick += new System.EventHandler(this.dgvPurchaseLines_DoubleClick);
            // 
            // cboCurrency
            // 
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.Location = new System.Drawing.Point(88, 110);
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
            this.chkTaxInclusive.Location = new System.Drawing.Point(198, 112);
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
            this.gpSummary.Caption = "Purchase Order Main Information";
            this.gpSummary.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gpSummary.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gpSummary.CaptionHeight = 25;
            this.gpSummary.CaptionVisible = true;
            this.gpSummary.Controls.Add(this.txtPurchaseNo);
            this.gpSummary.Controls.Add(this.lblPurchaseNo);
            this.gpSummary.Controls.Add(this.cboPurchaseLayout);
            this.gpSummary.Controls.Add(this.lblPurchaseLayout);
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
            this.gpSummary.Location = new System.Drawing.Point(12, 397);
            this.gpSummary.Name = "gpSummary";
            this.gpSummary.Size = new System.Drawing.Size(313, 150);
            this.gpSummary.TabIndex = 94;
            this.gpSummary.TabStop = false;
            // 
            // txtPurchaseNo
            // 
            this.txtPurchaseNo.Location = new System.Drawing.Point(88, 35);
            this.txtPurchaseNo.Name = "txtPurchaseNo";
            this.txtPurchaseNo.Size = new System.Drawing.Size(210, 20);
            this.txtPurchaseNo.TabIndex = 88;
            // 
            // lblPurchaseNo
            // 
            this.lblPurchaseNo.AutoSize = true;
            this.lblPurchaseNo.BackColor = System.Drawing.Color.Transparent;
            this.lblPurchaseNo.Location = new System.Drawing.Point(8, 38);
            this.lblPurchaseNo.Name = "lblPurchaseNo";
            this.lblPurchaseNo.Size = new System.Drawing.Size(65, 13);
            this.lblPurchaseNo.TabIndex = 87;
            this.lblPurchaseNo.Text = "Purchase #:";
            // 
            // cboPurchaseLayout
            // 
            this.cboPurchaseLayout.FormattingEnabled = true;
            this.cboPurchaseLayout.Location = new System.Drawing.Point(88, 84);
            this.cboPurchaseLayout.Name = "cboPurchaseLayout";
            this.cboPurchaseLayout.Size = new System.Drawing.Size(210, 21);
            this.cboPurchaseLayout.TabIndex = 91;
            // 
            // lblPurchaseLayout
            // 
            this.lblPurchaseLayout.AutoSize = true;
            this.lblPurchaseLayout.BackColor = System.Drawing.Color.Transparent;
            this.lblPurchaseLayout.Location = new System.Drawing.Point(8, 87);
            this.lblPurchaseLayout.Name = "lblPurchaseLayout";
            this.lblPurchaseLayout.Size = new System.Drawing.Size(39, 13);
            this.lblPurchaseLayout.TabIndex = 90;
            this.lblPurchaseLayout.Text = "Layout";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrency.Location = new System.Drawing.Point(10, 116);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(30, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Rate";
            // 
            // cboInvoiceDelivery
            // 
            this.cboInvoiceDelivery.FormattingEnabled = true;
            this.cboInvoiceDelivery.Location = new System.Drawing.Point(88, 59);
            this.cboInvoiceDelivery.Name = "cboInvoiceDelivery";
            this.cboInvoiceDelivery.Size = new System.Drawing.Size(210, 21);
            this.cboInvoiceDelivery.TabIndex = 92;
            // 
            // lblInvoiceDelivery
            // 
            this.lblInvoiceDelivery.AutoSize = true;
            this.lblInvoiceDelivery.BackColor = System.Drawing.Color.Transparent;
            this.lblInvoiceDelivery.Location = new System.Drawing.Point(7, 62);
            this.lblInvoiceDelivery.Name = "lblInvoiceDelivery";
            this.lblInvoiceDelivery.Size = new System.Drawing.Size(78, 13);
            this.lblInvoiceDelivery.TabIndex = 89;
            this.lblInvoiceDelivery.Text = "Delivery Status";
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
            this.czRoundedGroupBox1.Caption = "Purchases --> Purchase Order";
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
            this.czRoundedGroupBox1.Location = new System.Drawing.Point(12, 6);
            this.czRoundedGroupBox1.Name = "czRoundedGroupBox1";
            this.czRoundedGroupBox1.Size = new System.Drawing.Size(796, 385);
            this.czRoundedGroupBox1.TabIndex = 97;
            // 
            // FrmPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(815, 551);
            this.Controls.Add(this.czRoundedGroupBox1);
            this.Controls.Add(this.btnBarcode);
            this.Controls.Add(this.gpSummary);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRecord);
            this.Name = "FrmPurchaseOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Purchase Order";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tc.ResumeLayout(false);
            this.tpPurchaseOrder.ResumeLayout(false);
            this.gbSupplierDetails.ResumeLayout(false);
            this.gbSupplierDetails.PerformLayout();
            this.gbComments.ResumeLayout(false);
            this.gbComments.PerformLayout();
            this.gbMainDetail.ResumeLayout(false);
            this.gbMainDetail.PerformLayout();
            this.gbShipTo.ResumeLayout(false);
            this.gbShipTo.PerformLayout();
            this.tpPurchaseLines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseLines)).EndInit();
            this.gpSummary.ResumeLayout(false);
            this.gpSummary.PerformLayout();
            this.czRoundedGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CZRoundedGroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTaxValue;
        private System.Windows.Forms.Label lblSubtotalValue;
        private System.Windows.Forms.TextBox txtSubtotalValue;
        private System.Windows.Forms.Label lblTaxValue;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.TextBox txtTotalValue;
        private System.Windows.Forms.Label lblEqual;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.ComboBox cboReferralSource;
        private System.Windows.Forms.Label lblReferralSource;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TabControl tc;
        private System.Windows.Forms.TabPage tpPurchaseOrder;
        private System.Windows.Forms.CZRoundedGroupBox gbSupplierDetails;
        private System.Windows.Forms.ComboBox cboAddresses;
        private System.Windows.Forms.Label lblSupplierPhone2;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.Label lblDestinationCountry;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cboCurrency;
        private System.Windows.Forms.Label lblSupplierPO;
        private System.Windows.Forms.Label lblSupplierEmail;
        private System.Windows.Forms.Label lblSupplierPhone1;
        private System.Windows.Forms.Label lblSupplierCity;
        private System.Windows.Forms.TextBox txtSupplierPhone2;
        private System.Windows.Forms.TextBox txtSupplierPO;
        private System.Windows.Forms.TextBox txtSupplierEmail;
        private System.Windows.Forms.TextBox txtSupplierPhone1;
        private System.Windows.Forms.TextBox txtSupplierCountry;
        private System.Windows.Forms.TextBox txtSupplierCity;
        private System.Windows.Forms.CZRoundedGroupBox gbComments;
        private System.Windows.Forms.CheckBox chkTaxInclusive;
        private System.Windows.Forms.ComboBox cboTerms;
        private System.Windows.Forms.Label lblTerms;
        private System.Windows.Forms.ComboBox cboComments;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.CZRoundedGroupBox gbMainDetail;
        private System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.TextBox txtJournalMemo;
        private System.Windows.Forms.Label lblPurchaseDate;
        private System.Windows.Forms.Label lblJournalMemo;
        private System.Windows.Forms.CZRoundedGroupBox gbShipTo;
        private System.Windows.Forms.Button btnCopyAddress;
        private System.Windows.Forms.Button btnClearAddress;
        private System.Windows.Forms.ComboBox cboFreightTaxCode;
        private System.Windows.Forms.DateTimePicker dtpPromisedDate;
        private System.Windows.Forms.ComboBox cboShippingMethod;
        private System.Windows.Forms.TextBox txtAddressLine4;
        private System.Windows.Forms.Label lblAddressLine4;
        private System.Windows.Forms.TextBox txtAddressLine3;
        private System.Windows.Forms.Label lblAddressLine3;
        private System.Windows.Forms.Label lblPromisedDate;
        private System.Windows.Forms.TextBox txtFreight;
        private System.Windows.Forms.Label lblFreight;
        private System.Windows.Forms.TextBox txtAddressLine1;
        private System.Windows.Forms.Label lblAddressLine1;
        private System.Windows.Forms.Label lblShippingMethod;
        private System.Windows.Forms.TextBox txtAddressLine2;
        private System.Windows.Forms.Label lblAddressLine2;
        private System.Windows.Forms.TabPage tpPurchaseLines;
        private System.Windows.Forms.DataGridView dgvPurchaseLines;
        private System.Windows.Forms.CZRoundedGroupBox gpSummary;
        private System.Windows.Forms.TextBox txtPurchaseNo;
        private System.Windows.Forms.Label lblPurchaseNo;
        private System.Windows.Forms.ComboBox cboPurchaseLayout;
        private System.Windows.Forms.Label lblPurchaseLayout;
        private System.Windows.Forms.ComboBox cboInvoiceDelivery;
        private System.Windows.Forms.Label lblInvoiceDelivery;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.TextBox txtPaidToday;
        private System.Windows.Forms.Label lblPaidToday;
        private System.Windows.Forms.Label lblBalanceDue;
        private System.Windows.Forms.ComboBox cboPaymentMethod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBalanceDue;
        private System.Windows.Forms.Button btnDelLine;
        private System.Windows.Forms.Button btnNewLine;
        private System.Windows.Forms.Button btnBarcode;
        private System.Windows.Forms.CZRoundedGroupBox czRoundedGroupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPlus;
        private System.Windows.Forms.Button btnReceiveGoods;
    }
}