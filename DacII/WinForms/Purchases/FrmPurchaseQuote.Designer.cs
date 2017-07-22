namespace DacII.WinForms.Purchases
{
    partial class FrmPurchaseQuote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPurchaseQuote));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.CZRoundedGroupBox();
            this.cboFreightTaxCode = new System.Windows.Forms.ComboBox();
            this.txtTaxValue = new System.Windows.Forms.TextBox();
            this.txtFreight = new System.Windows.Forms.TextBox();
            this.lblSubtotalValue = new System.Windows.Forms.Label();
            this.lblFreight = new System.Windows.Forms.Label();
            this.txtSubtotalValue = new System.Windows.Forms.TextBox();
            this.lblTaxValue = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.txtTotalValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPlus = new System.Windows.Forms.Label();
            this.lblEqual = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tc = new System.Windows.Forms.TabControl();
            this.tpPurchaseQuote = new System.Windows.Forms.TabPage();
            this.tpPurchaseLines = new System.Windows.Forms.TabPage();
            this.gbMainDetail = new System.Windows.Forms.CZRoundedGroupBox();
            this.lblSupplierPO = new System.Windows.Forms.Label();
            this.txtSupplierPO = new System.Windows.Forms.TextBox();
            this.cboReferralSource = new System.Windows.Forms.ComboBox();
            this.lblReferralSource = new System.Windows.Forms.Label();
            this.cboComments = new System.Windows.Forms.ComboBox();
            this.lblComments = new System.Windows.Forms.Label();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.txtJournalMemo = new System.Windows.Forms.TextBox();
            this.lblJournalMemo = new System.Windows.Forms.Label();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.lblPurchaseDate = new System.Windows.Forms.Label();
            this.dtpPromisedDate = new System.Windows.Forms.DateTimePicker();
            this.lblPromisedDate = new System.Windows.Forms.Label();
            this.cboTerms = new System.Windows.Forms.ComboBox();
            this.lblTerms = new System.Windows.Forms.Label();
            this.cboShippingMethod = new System.Windows.Forms.ComboBox();
            this.lblShippingMethod = new System.Windows.Forms.Label();
            this.gbPurchaseLines = new System.Windows.Forms.CZRoundedGroupBox();
            this.btnDelLine = new System.Windows.Forms.Button();
            this.btnNewLine = new System.Windows.Forms.Button();
            this.dgvPurchaseLines = new System.Windows.Forms.DataGridView();
            this.chkTaxInclusive = new System.Windows.Forms.CheckBox();
            this.cboCurrency = new System.Windows.Forms.ComboBox();
            this.gpSummary = new System.Windows.Forms.CZRoundedGroupBox();
            this.txtPurchaseNo = new System.Windows.Forms.TextBox();
            this.lblPurchaseNo = new System.Windows.Forms.Label();
            this.cboPurchaseLayout = new System.Windows.Forms.ComboBox();
            this.lblPurchaseLayout = new System.Windows.Forms.Label();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.cboInvoiceDelivery = new System.Windows.Forms.ComboBox();
            this.lblInvoiceDelivery = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.txtSupplierCity = new System.Windows.Forms.TextBox();
            this.lblSupplierEmail = new System.Windows.Forms.Label();
            this.lblSupplierPhone1 = new System.Windows.Forms.Label();
            this.txtSupplierEmail = new System.Windows.Forms.TextBox();
            this.lblDestinationCountry = new System.Windows.Forms.Label();
            this.lblSupplierPhone2 = new System.Windows.Forms.Label();
            this.txtSupplierCountry = new System.Windows.Forms.TextBox();
            this.txtSupplierPhone2 = new System.Windows.Forms.TextBox();
            this.txtSupplierPhone1 = new System.Windows.Forms.TextBox();
            this.lblSupplierCity = new System.Windows.Forms.Label();
            this.cboAddresses = new System.Windows.Forms.ComboBox();
            this.btnCopyAddress = new System.Windows.Forms.Button();
            this.btnClearAddress = new System.Windows.Forms.Button();
            this.txtAddressLine4 = new System.Windows.Forms.TextBox();
            this.lblAddressLine4 = new System.Windows.Forms.Label();
            this.txtAddressLine3 = new System.Windows.Forms.TextBox();
            this.lblAddressLine3 = new System.Windows.Forms.Label();
            this.txtAddressLine1 = new System.Windows.Forms.TextBox();
            this.lblAddressLine1 = new System.Windows.Forms.Label();
            this.txtAddressLine2 = new System.Windows.Forms.TextBox();
            this.lblAddressLine2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tc.SuspendLayout();
            this.tpPurchaseQuote.SuspendLayout();
            this.tpPurchaseLines.SuspendLayout();
            this.gbMainDetail.SuspendLayout();
            this.gbPurchaseLines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseLines)).BeginInit();
            this.gpSummary.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.cboFreightTaxCode);
            this.groupBox1.Controls.Add(this.txtTaxValue);
            this.groupBox1.Controls.Add(this.txtFreight);
            this.groupBox1.Controls.Add(this.lblSubtotalValue);
            this.groupBox1.Controls.Add(this.lblFreight);
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
            this.groupBox1.Location = new System.Drawing.Point(376, 431);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 70);
            this.groupBox1.TabIndex = 87;
            this.groupBox1.TabStop = false;
            // 
            // cboFreightTaxCode
            // 
            this.cboFreightTaxCode.FormattingEnabled = true;
            this.cboFreightTaxCode.Location = new System.Drawing.Point(175, 34);
            this.cboFreightTaxCode.Name = "cboFreightTaxCode";
            this.cboFreightTaxCode.Size = new System.Drawing.Size(51, 21);
            this.cboFreightTaxCode.TabIndex = 29;
            // 
            // txtTaxValue
            // 
            this.txtTaxValue.Location = new System.Drawing.Point(251, 35);
            this.txtTaxValue.Name = "txtTaxValue";
            this.txtTaxValue.ReadOnly = true;
            this.txtTaxValue.Size = new System.Drawing.Size(84, 20);
            this.txtTaxValue.TabIndex = 28;
            // 
            // txtFreight
            // 
            this.txtFreight.Location = new System.Drawing.Point(110, 35);
            this.txtFreight.Name = "txtFreight";
            this.txtFreight.Size = new System.Drawing.Size(59, 20);
            this.txtFreight.TabIndex = 32;
            this.txtFreight.Text = "0";
            // 
            // lblSubtotalValue
            // 
            this.lblSubtotalValue.AutoSize = true;
            this.lblSubtotalValue.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtotalValue.Location = new System.Drawing.Point(6, 8);
            this.lblSubtotalValue.Name = "lblSubtotalValue";
            this.lblSubtotalValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSubtotalValue.Size = new System.Drawing.Size(76, 13);
            this.lblSubtotalValue.TabIndex = 24;
            this.lblSubtotalValue.Text = "Subtotal Value";
            // 
            // lblFreight
            // 
            this.lblFreight.AutoSize = true;
            this.lblFreight.BackColor = System.Drawing.Color.Transparent;
            this.lblFreight.Location = new System.Drawing.Point(106, 8);
            this.lblFreight.Name = "lblFreight";
            this.lblFreight.Size = new System.Drawing.Size(39, 13);
            this.lblFreight.TabIndex = 30;
            this.lblFreight.Text = "Freight";
            // 
            // txtSubtotalValue
            // 
            this.txtSubtotalValue.Location = new System.Drawing.Point(9, 35);
            this.txtSubtotalValue.Name = "txtSubtotalValue";
            this.txtSubtotalValue.ReadOnly = true;
            this.txtSubtotalValue.Size = new System.Drawing.Size(76, 20);
            this.txtSubtotalValue.TabIndex = 27;
            // 
            // lblTaxValue
            // 
            this.lblTaxValue.AutoSize = true;
            this.lblTaxValue.BackColor = System.Drawing.Color.Transparent;
            this.lblTaxValue.Location = new System.Drawing.Point(245, 8);
            this.lblTaxValue.Name = "lblTaxValue";
            this.lblTaxValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTaxValue.Size = new System.Drawing.Size(55, 13);
            this.lblTaxValue.TabIndex = 25;
            this.lblTaxValue.Text = "Tax Value";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalValue.Location = new System.Drawing.Point(355, 8);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotalValue.Size = new System.Drawing.Size(66, 13);
            this.lblTotalValue.TabIndex = 26;
            this.lblTotalValue.Text = "Total Values";
            // 
            // txtTotalValue
            // 
            this.txtTotalValue.Location = new System.Drawing.Point(361, 35);
            this.txtTotalValue.Name = "txtTotalValue";
            this.txtTotalValue.ReadOnly = true;
            this.txtTotalValue.Size = new System.Drawing.Size(107, 20);
            this.txtTotalValue.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(232, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "+";
            // 
            // lblPlus
            // 
            this.lblPlus.AutoSize = true;
            this.lblPlus.BackColor = System.Drawing.Color.Transparent;
            this.lblPlus.Location = new System.Drawing.Point(91, 38);
            this.lblPlus.Name = "lblPlus";
            this.lblPlus.Size = new System.Drawing.Size(13, 13);
            this.lblPlus.TabIndex = 31;
            this.lblPlus.Text = "+";
            // 
            // lblEqual
            // 
            this.lblEqual.AutoSize = true;
            this.lblEqual.BackColor = System.Drawing.Color.Transparent;
            this.lblEqual.Location = new System.Drawing.Point(341, 38);
            this.lblEqual.Name = "lblEqual";
            this.lblEqual.Size = new System.Drawing.Size(13, 13);
            this.lblEqual.TabIndex = 30;
            this.lblEqual.Text = "=";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DacII.Properties.Resources.cancel_24x24;
            this.btnClose.Location = new System.Drawing.Point(834, 513);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 56);
            this.btnClose.TabIndex = 90;
            this.btnClose.Text = "Cancel";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // tc
            // 
            this.tc.Controls.Add(this.tpPurchaseQuote);
            this.tc.Controls.Add(this.tpPurchaseLines);
            this.tc.HotTrack = true;
            this.tc.Location = new System.Drawing.Point(374, 31);
            this.tc.Name = "tc";
            this.tc.SelectedIndex = 0;
            this.tc.Size = new System.Drawing.Size(490, 138);
            this.tc.TabIndex = 93;
            // 
            // tpPurchaseQuote
            // 
            this.tpPurchaseQuote.Controls.Add(this.cboAddresses);
            this.tpPurchaseQuote.Controls.Add(this.btnCopyAddress);
            this.tpPurchaseQuote.Controls.Add(this.btnClearAddress);
            this.tpPurchaseQuote.Controls.Add(this.txtAddressLine4);
            this.tpPurchaseQuote.Controls.Add(this.lblAddressLine4);
            this.tpPurchaseQuote.Controls.Add(this.txtAddressLine3);
            this.tpPurchaseQuote.Controls.Add(this.lblAddressLine3);
            this.tpPurchaseQuote.Controls.Add(this.txtAddressLine1);
            this.tpPurchaseQuote.Controls.Add(this.lblAddressLine1);
            this.tpPurchaseQuote.Controls.Add(this.txtAddressLine2);
            this.tpPurchaseQuote.Controls.Add(this.lblAddressLine2);
            this.tpPurchaseQuote.Location = new System.Drawing.Point(4, 22);
            this.tpPurchaseQuote.Name = "tpPurchaseQuote";
            this.tpPurchaseQuote.Padding = new System.Windows.Forms.Padding(3);
            this.tpPurchaseQuote.Size = new System.Drawing.Size(482, 112);
            this.tpPurchaseQuote.TabIndex = 0;
            this.tpPurchaseQuote.Text = "Supplier Address";
            this.tpPurchaseQuote.UseVisualStyleBackColor = true;
            // 
            // tpPurchaseLines
            // 
            this.tpPurchaseLines.Controls.Add(this.txtSupplierCity);
            this.tpPurchaseLines.Controls.Add(this.lblSupplierEmail);
            this.tpPurchaseLines.Controls.Add(this.lblSupplierPhone1);
            this.tpPurchaseLines.Controls.Add(this.txtSupplierEmail);
            this.tpPurchaseLines.Controls.Add(this.lblDestinationCountry);
            this.tpPurchaseLines.Controls.Add(this.lblSupplierPhone2);
            this.tpPurchaseLines.Controls.Add(this.txtSupplierCountry);
            this.tpPurchaseLines.Controls.Add(this.txtSupplierPhone2);
            this.tpPurchaseLines.Controls.Add(this.txtSupplierPhone1);
            this.tpPurchaseLines.Controls.Add(this.lblSupplierCity);
            this.tpPurchaseLines.Location = new System.Drawing.Point(4, 22);
            this.tpPurchaseLines.Name = "tpPurchaseLines";
            this.tpPurchaseLines.Padding = new System.Windows.Forms.Padding(3);
            this.tpPurchaseLines.Size = new System.Drawing.Size(482, 91);
            this.tpPurchaseLines.TabIndex = 1;
            this.tpPurchaseLines.Text = "Supplier Contact Details";
            this.tpPurchaseLines.UseVisualStyleBackColor = true;
            // 
            // gbMainDetail
            // 
            this.gbMainDetail.BackgroundColor = System.Drawing.Color.White;
            this.gbMainDetail.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbMainDetail.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbMainDetail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbMainDetail.BorderWidth = 1F;
            this.gbMainDetail.Caption = "Purchase Quote Main Details";
            this.gbMainDetail.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbMainDetail.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbMainDetail.CaptionHeight = 25;
            this.gbMainDetail.CaptionVisible = true;
            this.gbMainDetail.Controls.Add(this.lblSupplierPO);
            this.gbMainDetail.Controls.Add(this.txtSupplierPO);
            this.gbMainDetail.Controls.Add(this.cboReferralSource);
            this.gbMainDetail.Controls.Add(this.lblReferralSource);
            this.gbMainDetail.Controls.Add(this.tc);
            this.gbMainDetail.Controls.Add(this.cboComments);
            this.gbMainDetail.Controls.Add(this.lblComments);
            this.gbMainDetail.Controls.Add(this.cboSupplier);
            this.gbMainDetail.Controls.Add(this.lblSupplier);
            this.gbMainDetail.Controls.Add(this.txtJournalMemo);
            this.gbMainDetail.Controls.Add(this.lblJournalMemo);
            this.gbMainDetail.CornerRadius = 5;
            this.gbMainDetail.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbMainDetail.DropShadowThickness = 3;
            this.gbMainDetail.DropShadowVisible = true;
            this.gbMainDetail.Location = new System.Drawing.Point(12, 12);
            this.gbMainDetail.Name = "gbMainDetail";
            this.gbMainDetail.Size = new System.Drawing.Size(878, 183);
            this.gbMainDetail.TabIndex = 83;
            this.gbMainDetail.TabStop = false;
            // 
            // lblSupplierPO
            // 
            this.lblSupplierPO.AutoSize = true;
            this.lblSupplierPO.BackColor = System.Drawing.Color.Transparent;
            this.lblSupplierPO.Location = new System.Drawing.Point(8, 148);
            this.lblSupplierPO.Name = "lblSupplierPO";
            this.lblSupplierPO.Size = new System.Drawing.Size(32, 13);
            this.lblSupplierPO.TabIndex = 98;
            this.lblSupplierPO.Text = "PO #";
            // 
            // txtSupplierPO
            // 
            this.txtSupplierPO.Location = new System.Drawing.Point(96, 145);
            this.txtSupplierPO.Name = "txtSupplierPO";
            this.txtSupplierPO.Size = new System.Drawing.Size(131, 20);
            this.txtSupplierPO.TabIndex = 97;
            // 
            // cboReferralSource
            // 
            this.cboReferralSource.FormattingEnabled = true;
            this.cboReferralSource.Location = new System.Drawing.Point(96, 118);
            this.cboReferralSource.Name = "cboReferralSource";
            this.cboReferralSource.Size = new System.Drawing.Size(262, 21);
            this.cboReferralSource.TabIndex = 87;
            // 
            // lblReferralSource
            // 
            this.lblReferralSource.AutoSize = true;
            this.lblReferralSource.BackColor = System.Drawing.Color.Transparent;
            this.lblReferralSource.Location = new System.Drawing.Point(9, 121);
            this.lblReferralSource.Name = "lblReferralSource";
            this.lblReferralSource.Size = new System.Drawing.Size(81, 13);
            this.lblReferralSource.TabIndex = 86;
            this.lblReferralSource.Text = "Referral Source";
            // 
            // cboComments
            // 
            this.cboComments.FormattingEnabled = true;
            this.cboComments.Location = new System.Drawing.Point(96, 91);
            this.cboComments.Name = "cboComments";
            this.cboComments.Size = new System.Drawing.Size(262, 21);
            this.cboComments.TabIndex = 4;
            // 
            // lblComments
            // 
            this.lblComments.AutoSize = true;
            this.lblComments.BackColor = System.Drawing.Color.Transparent;
            this.lblComments.Location = new System.Drawing.Point(6, 94);
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(56, 13);
            this.lblComments.TabIndex = 3;
            this.lblComments.Text = "Comments";
            // 
            // cboSupplier
            // 
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(96, 37);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(262, 21);
            this.cboSupplier.TabIndex = 2;
            this.cboSupplier.SelectedIndexChanged += new System.EventHandler(this.OnSupplierChanged);
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.BackColor = System.Drawing.Color.Transparent;
            this.lblSupplier.Location = new System.Drawing.Point(6, 40);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(45, 13);
            this.lblSupplier.TabIndex = 0;
            this.lblSupplier.Text = "Supplier";
            // 
            // txtJournalMemo
            // 
            this.txtJournalMemo.Location = new System.Drawing.Point(96, 64);
            this.txtJournalMemo.Name = "txtJournalMemo";
            this.txtJournalMemo.Size = new System.Drawing.Size(262, 20);
            this.txtJournalMemo.TabIndex = 1;
            // 
            // lblJournalMemo
            // 
            this.lblJournalMemo.AutoSize = true;
            this.lblJournalMemo.BackColor = System.Drawing.Color.Transparent;
            this.lblJournalMemo.Location = new System.Drawing.Point(6, 67);
            this.lblJournalMemo.Name = "lblJournalMemo";
            this.lblJournalMemo.Size = new System.Drawing.Size(36, 13);
            this.lblJournalMemo.TabIndex = 0;
            this.lblJournalMemo.Text = "Memo";
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPurchaseDate.Location = new System.Drawing.Point(233, 30);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(109, 20);
            this.dtpPurchaseDate.TabIndex = 3;
            // 
            // lblPurchaseDate
            // 
            this.lblPurchaseDate.AutoSize = true;
            this.lblPurchaseDate.BackColor = System.Drawing.Color.Transparent;
            this.lblPurchaseDate.Location = new System.Drawing.Point(197, 33);
            this.lblPurchaseDate.Name = "lblPurchaseDate";
            this.lblPurchaseDate.Size = new System.Drawing.Size(30, 13);
            this.lblPurchaseDate.TabIndex = 0;
            this.lblPurchaseDate.Text = "Date";
            // 
            // dtpPromisedDate
            // 
            this.dtpPromisedDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpPromisedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPromisedDate.Location = new System.Drawing.Point(523, 188);
            this.dtpPromisedDate.Name = "dtpPromisedDate";
            this.dtpPromisedDate.Size = new System.Drawing.Size(103, 20);
            this.dtpPromisedDate.TabIndex = 3;
            // 
            // lblPromisedDate
            // 
            this.lblPromisedDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPromisedDate.AutoSize = true;
            this.lblPromisedDate.BackColor = System.Drawing.Color.Transparent;
            this.lblPromisedDate.Location = new System.Drawing.Point(470, 190);
            this.lblPromisedDate.Name = "lblPromisedDate";
            this.lblPromisedDate.Size = new System.Drawing.Size(50, 13);
            this.lblPromisedDate.TabIndex = 0;
            this.lblPromisedDate.Text = "Promised";
            // 
            // cboTerms
            // 
            this.cboTerms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboTerms.FormattingEnabled = true;
            this.cboTerms.Location = new System.Drawing.Point(48, 187);
            this.cboTerms.Name = "cboTerms";
            this.cboTerms.Size = new System.Drawing.Size(208, 21);
            this.cboTerms.TabIndex = 2;
            // 
            // lblTerms
            // 
            this.lblTerms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTerms.AutoSize = true;
            this.lblTerms.BackColor = System.Drawing.Color.Transparent;
            this.lblTerms.Location = new System.Drawing.Point(9, 190);
            this.lblTerms.Name = "lblTerms";
            this.lblTerms.Size = new System.Drawing.Size(36, 13);
            this.lblTerms.TabIndex = 0;
            this.lblTerms.Text = "Terms";
            // 
            // cboShippingMethod
            // 
            this.cboShippingMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboShippingMethod.FormattingEnabled = true;
            this.cboShippingMethod.Location = new System.Drawing.Point(321, 188);
            this.cboShippingMethod.Name = "cboShippingMethod";
            this.cboShippingMethod.Size = new System.Drawing.Size(136, 21);
            this.cboShippingMethod.TabIndex = 31;
            // 
            // lblShippingMethod
            // 
            this.lblShippingMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblShippingMethod.AutoSize = true;
            this.lblShippingMethod.BackColor = System.Drawing.Color.Transparent;
            this.lblShippingMethod.Location = new System.Drawing.Point(265, 191);
            this.lblShippingMethod.Name = "lblShippingMethod";
            this.lblShippingMethod.Size = new System.Drawing.Size(51, 13);
            this.lblShippingMethod.TabIndex = 28;
            this.lblShippingMethod.Text = "Shipping:";
            // 
            // gbPurchaseLines
            // 
            this.gbPurchaseLines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbPurchaseLines.BackgroundColor = System.Drawing.Color.White;
            this.gbPurchaseLines.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbPurchaseLines.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbPurchaseLines.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbPurchaseLines.BorderWidth = 1F;
            this.gbPurchaseLines.Caption = "Purchase Quote Lines";
            this.gbPurchaseLines.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbPurchaseLines.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbPurchaseLines.CaptionHeight = 25;
            this.gbPurchaseLines.CaptionVisible = true;
            this.gbPurchaseLines.Controls.Add(this.cboTerms);
            this.gbPurchaseLines.Controls.Add(this.cboShippingMethod);
            this.gbPurchaseLines.Controls.Add(this.lblTerms);
            this.gbPurchaseLines.Controls.Add(this.lblShippingMethod);
            this.gbPurchaseLines.Controls.Add(this.btnDelLine);
            this.gbPurchaseLines.Controls.Add(this.dtpPromisedDate);
            this.gbPurchaseLines.Controls.Add(this.btnNewLine);
            this.gbPurchaseLines.Controls.Add(this.dgvPurchaseLines);
            this.gbPurchaseLines.Controls.Add(this.lblPromisedDate);
            this.gbPurchaseLines.Controls.Add(this.chkTaxInclusive);
            this.gbPurchaseLines.CornerRadius = 5;
            this.gbPurchaseLines.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbPurchaseLines.DropShadowThickness = 3;
            this.gbPurchaseLines.DropShadowVisible = true;
            this.gbPurchaseLines.Location = new System.Drawing.Point(12, 201);
            this.gbPurchaseLines.MinimumSize = new System.Drawing.Size(0, 10);
            this.gbPurchaseLines.Name = "gbPurchaseLines";
            this.gbPurchaseLines.Size = new System.Drawing.Size(878, 224);
            this.gbPurchaseLines.TabIndex = 25;
            this.gbPurchaseLines.TabStop = false;
            // 
            // btnDelLine
            // 
            this.btnDelLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelLine.BackgroundImage = global::DacII.Properties.Resources.delete_16x16;
            this.btnDelLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelLine.Location = new System.Drawing.Point(838, 186);
            this.btnDelLine.Name = "btnDelLine";
            this.btnDelLine.Size = new System.Drawing.Size(27, 27);
            this.btnDelLine.TabIndex = 6;
            this.btnDelLine.Click += new System.EventHandler(this.btnDelLine_Click);
            // 
            // btnNewLine
            // 
            this.btnNewLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewLine.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNewLine.BackgroundImage")));
            this.btnNewLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNewLine.Location = new System.Drawing.Point(807, 187);
            this.btnNewLine.Name = "btnNewLine";
            this.btnNewLine.Size = new System.Drawing.Size(27, 27);
            this.btnNewLine.TabIndex = 5;
            this.btnNewLine.Click += new System.EventHandler(this.btnNewLine_Click);
            // 
            // dgvPurchaseLines
            // 
            this.dgvPurchaseLines.AllowUserToAddRows = false;
            this.dgvPurchaseLines.AllowUserToDeleteRows = false;
            this.dgvPurchaseLines.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.dgvPurchaseLines.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPurchaseLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPurchaseLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPurchaseLines.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPurchaseLines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPurchaseLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPurchaseLines.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvPurchaseLines.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPurchaseLines.Location = new System.Drawing.Point(9, 29);
            this.dgvPurchaseLines.MultiSelect = false;
            this.dgvPurchaseLines.Name = "dgvPurchaseLines";
            this.dgvPurchaseLines.RowHeadersVisible = false;
            this.dgvPurchaseLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchaseLines.Size = new System.Drawing.Size(856, 152);
            this.dgvPurchaseLines.TabIndex = 0;
            this.dgvPurchaseLines.DoubleClick += new System.EventHandler(this.dgvPurchaseLines_DoubleClick);
            // 
            // chkTaxInclusive
            // 
            this.chkTaxInclusive.AutoSize = true;
            this.chkTaxInclusive.BackColor = System.Drawing.Color.Transparent;
            this.chkTaxInclusive.Checked = true;
            this.chkTaxInclusive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTaxInclusive.Location = new System.Drawing.Point(765, 6);
            this.chkTaxInclusive.Name = "chkTaxInclusive";
            this.chkTaxInclusive.Size = new System.Drawing.Size(100, 17);
            this.chkTaxInclusive.TabIndex = 3;
            this.chkTaxInclusive.Text = "Is Tax Inclusive";
            this.chkTaxInclusive.UseVisualStyleBackColor = false;
            // 
            // cboCurrency
            // 
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.Location = new System.Drawing.Point(88, 105);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(96, 21);
            this.cboCurrency.TabIndex = 85;
            // 
            // gpSummary
            // 
            this.gpSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gpSummary.BackgroundColor = System.Drawing.Color.White;
            this.gpSummary.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gpSummary.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gpSummary.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gpSummary.BorderWidth = 1F;
            this.gpSummary.Caption = "Purchase Quote Main Details";
            this.gpSummary.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gpSummary.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gpSummary.CaptionHeight = 25;
            this.gpSummary.CaptionVisible = true;
            this.gpSummary.Controls.Add(this.txtPurchaseNo);
            this.gpSummary.Controls.Add(this.dtpPurchaseDate);
            this.gpSummary.Controls.Add(this.lblPurchaseNo);
            this.gpSummary.Controls.Add(this.cboPurchaseLayout);
            this.gpSummary.Controls.Add(this.lblPurchaseDate);
            this.gpSummary.Controls.Add(this.lblPurchaseLayout);
            this.gpSummary.Controls.Add(this.lblCurrency);
            this.gpSummary.Controls.Add(this.cboInvoiceDelivery);
            this.gpSummary.Controls.Add(this.cboCurrency);
            this.gpSummary.Controls.Add(this.lblInvoiceDelivery);
            this.gpSummary.CornerRadius = 5;
            this.gpSummary.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gpSummary.DropShadowThickness = 3;
            this.gpSummary.DropShadowVisible = true;
            this.gpSummary.Location = new System.Drawing.Point(12, 431);
            this.gpSummary.Name = "gpSummary";
            this.gpSummary.Size = new System.Drawing.Size(358, 142);
            this.gpSummary.TabIndex = 94;
            this.gpSummary.TabStop = false;
            // 
            // txtPurchaseNo
            // 
            this.txtPurchaseNo.Location = new System.Drawing.Point(88, 30);
            this.txtPurchaseNo.Name = "txtPurchaseNo";
            this.txtPurchaseNo.Size = new System.Drawing.Size(96, 20);
            this.txtPurchaseNo.TabIndex = 88;
            // 
            // lblPurchaseNo
            // 
            this.lblPurchaseNo.AutoSize = true;
            this.lblPurchaseNo.BackColor = System.Drawing.Color.Transparent;
            this.lblPurchaseNo.Location = new System.Drawing.Point(6, 30);
            this.lblPurchaseNo.Name = "lblPurchaseNo";
            this.lblPurchaseNo.Size = new System.Drawing.Size(65, 13);
            this.lblPurchaseNo.TabIndex = 87;
            this.lblPurchaseNo.Text = "Purchase #:";
            // 
            // cboPurchaseLayout
            // 
            this.cboPurchaseLayout.FormattingEnabled = true;
            this.cboPurchaseLayout.Location = new System.Drawing.Point(88, 79);
            this.cboPurchaseLayout.Name = "cboPurchaseLayout";
            this.cboPurchaseLayout.Size = new System.Drawing.Size(254, 21);
            this.cboPurchaseLayout.TabIndex = 91;
            // 
            // lblPurchaseLayout
            // 
            this.lblPurchaseLayout.AutoSize = true;
            this.lblPurchaseLayout.BackColor = System.Drawing.Color.Transparent;
            this.lblPurchaseLayout.Location = new System.Drawing.Point(8, 82);
            this.lblPurchaseLayout.Name = "lblPurchaseLayout";
            this.lblPurchaseLayout.Size = new System.Drawing.Size(39, 13);
            this.lblPurchaseLayout.TabIndex = 90;
            this.lblPurchaseLayout.Text = "Layout";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrency.Location = new System.Drawing.Point(8, 108);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(30, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Rate";
            // 
            // cboInvoiceDelivery
            // 
            this.cboInvoiceDelivery.FormattingEnabled = true;
            this.cboInvoiceDelivery.Location = new System.Drawing.Point(88, 54);
            this.cboInvoiceDelivery.Name = "cboInvoiceDelivery";
            this.cboInvoiceDelivery.Size = new System.Drawing.Size(254, 21);
            this.cboInvoiceDelivery.TabIndex = 92;
            // 
            // lblInvoiceDelivery
            // 
            this.lblInvoiceDelivery.AutoSize = true;
            this.lblInvoiceDelivery.BackColor = System.Drawing.Color.Transparent;
            this.lblInvoiceDelivery.Location = new System.Drawing.Point(6, 57);
            this.lblInvoiceDelivery.Name = "lblInvoiceDelivery";
            this.lblInvoiceDelivery.Size = new System.Drawing.Size(78, 13);
            this.lblInvoiceDelivery.TabIndex = 89;
            this.lblInvoiceDelivery.Text = "Delivery Status";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Image = global::DacII.Properties.Resources.print_32x32;
            this.btnPrint.Location = new System.Drawing.Point(649, 513);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(56, 56);
            this.btnPrint.TabIndex = 91;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnRecord
            // 
            this.btnRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRecord.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRecord.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecord.Image = global::DacII.Properties.Resources.save_32x32;
            this.btnRecord.Location = new System.Drawing.Point(773, 513);
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
            this.btnBarcode.Location = new System.Drawing.Point(711, 513);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(56, 56);
            this.btnBarcode.TabIndex = 95;
            this.btnBarcode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBarcode.UseVisualStyleBackColor = false;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // txtSupplierCity
            // 
            this.txtSupplierCity.Enabled = false;
            this.txtSupplierCity.Location = new System.Drawing.Point(227, 10);
            this.txtSupplierCity.Name = "txtSupplierCity";
            this.txtSupplierCity.Size = new System.Drawing.Size(139, 20);
            this.txtSupplierCity.TabIndex = 105;
            // 
            // lblSupplierEmail
            // 
            this.lblSupplierEmail.AutoSize = true;
            this.lblSupplierEmail.Location = new System.Drawing.Point(9, 63);
            this.lblSupplierEmail.Name = "lblSupplierEmail";
            this.lblSupplierEmail.Size = new System.Drawing.Size(35, 13);
            this.lblSupplierEmail.TabIndex = 98;
            this.lblSupplierEmail.Text = "E-mail";
            // 
            // lblSupplierPhone1
            // 
            this.lblSupplierPhone1.AutoSize = true;
            this.lblSupplierPhone1.Location = new System.Drawing.Point(9, 12);
            this.lblSupplierPhone1.Name = "lblSupplierPhone1";
            this.lblSupplierPhone1.Size = new System.Drawing.Size(47, 13);
            this.lblSupplierPhone1.TabIndex = 99;
            this.lblSupplierPhone1.Text = "Phone 1";
            // 
            // txtSupplierEmail
            // 
            this.txtSupplierEmail.Enabled = false;
            this.txtSupplierEmail.Location = new System.Drawing.Point(62, 63);
            this.txtSupplierEmail.Name = "txtSupplierEmail";
            this.txtSupplierEmail.Size = new System.Drawing.Size(304, 20);
            this.txtSupplierEmail.TabIndex = 107;
            // 
            // lblDestinationCountry
            // 
            this.lblDestinationCountry.AutoSize = true;
            this.lblDestinationCountry.Location = new System.Drawing.Point(179, 40);
            this.lblDestinationCountry.Name = "lblDestinationCountry";
            this.lblDestinationCountry.Size = new System.Drawing.Size(43, 13);
            this.lblDestinationCountry.TabIndex = 102;
            this.lblDestinationCountry.Text = "Country";
            // 
            // lblSupplierPhone2
            // 
            this.lblSupplierPhone2.AutoSize = true;
            this.lblSupplierPhone2.Location = new System.Drawing.Point(9, 40);
            this.lblSupplierPhone2.Name = "lblSupplierPhone2";
            this.lblSupplierPhone2.Size = new System.Drawing.Size(47, 13);
            this.lblSupplierPhone2.TabIndex = 101;
            this.lblSupplierPhone2.Text = "Phone 2";
            // 
            // txtSupplierCountry
            // 
            this.txtSupplierCountry.Location = new System.Drawing.Point(227, 37);
            this.txtSupplierCountry.Name = "txtSupplierCountry";
            this.txtSupplierCountry.Size = new System.Drawing.Size(139, 20);
            this.txtSupplierCountry.TabIndex = 104;
            // 
            // txtSupplierPhone2
            // 
            this.txtSupplierPhone2.Enabled = false;
            this.txtSupplierPhone2.Location = new System.Drawing.Point(62, 37);
            this.txtSupplierPhone2.Name = "txtSupplierPhone2";
            this.txtSupplierPhone2.Size = new System.Drawing.Size(114, 20);
            this.txtSupplierPhone2.TabIndex = 106;
            // 
            // txtSupplierPhone1
            // 
            this.txtSupplierPhone1.Enabled = false;
            this.txtSupplierPhone1.Location = new System.Drawing.Point(61, 10);
            this.txtSupplierPhone1.Name = "txtSupplierPhone1";
            this.txtSupplierPhone1.Size = new System.Drawing.Size(115, 20);
            this.txtSupplierPhone1.TabIndex = 103;
            // 
            // lblSupplierCity
            // 
            this.lblSupplierCity.AutoSize = true;
            this.lblSupplierCity.Location = new System.Drawing.Point(197, 14);
            this.lblSupplierCity.Name = "lblSupplierCity";
            this.lblSupplierCity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSupplierCity.Size = new System.Drawing.Size(24, 13);
            this.lblSupplierCity.TabIndex = 100;
            this.lblSupplierCity.Text = "City";
            // 
            // cboAddresses
            // 
            this.cboAddresses.FormattingEnabled = true;
            this.cboAddresses.Location = new System.Drawing.Point(354, 5);
            this.cboAddresses.Name = "cboAddresses";
            this.cboAddresses.Size = new System.Drawing.Size(112, 21);
            this.cboAddresses.TabIndex = 30;
            // 
            // btnCopyAddress
            // 
            this.btnCopyAddress.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCopyAddress.FlatAppearance.BorderSize = 0;
            this.btnCopyAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyAddress.Image = global::DacII.Properties.Resources.copy_16x16;
            this.btnCopyAddress.Location = new System.Drawing.Point(354, 82);
            this.btnCopyAddress.Name = "btnCopyAddress";
            this.btnCopyAddress.Size = new System.Drawing.Size(32, 23);
            this.btnCopyAddress.TabIndex = 39;
            this.btnCopyAddress.UseVisualStyleBackColor = false;
            this.btnCopyAddress.Click += new System.EventHandler(this.btnCopyAddress_Click);
            // 
            // btnClearAddress
            // 
            this.btnClearAddress.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClearAddress.BackgroundImage = global::DacII.Properties.Resources.reset_16x16;
            this.btnClearAddress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClearAddress.FlatAppearance.BorderSize = 0;
            this.btnClearAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearAddress.Location = new System.Drawing.Point(380, 83);
            this.btnClearAddress.Name = "btnClearAddress";
            this.btnClearAddress.Size = new System.Drawing.Size(32, 25);
            this.btnClearAddress.TabIndex = 40;
            this.btnClearAddress.UseVisualStyleBackColor = false;
            this.btnClearAddress.Click += new System.EventHandler(this.btnClearAddress_Click);
            // 
            // txtAddressLine4
            // 
            this.txtAddressLine4.Location = new System.Drawing.Point(101, 85);
            this.txtAddressLine4.Name = "txtAddressLine4";
            this.txtAddressLine4.Size = new System.Drawing.Size(241, 20);
            this.txtAddressLine4.TabIndex = 36;
            // 
            // lblAddressLine4
            // 
            this.lblAddressLine4.AutoSize = true;
            this.lblAddressLine4.Location = new System.Drawing.Point(4, 88);
            this.lblAddressLine4.Name = "lblAddressLine4";
            this.lblAddressLine4.Size = new System.Drawing.Size(77, 13);
            this.lblAddressLine4.TabIndex = 33;
            this.lblAddressLine4.Text = "Address Line 4";
            // 
            // txtAddressLine3
            // 
            this.txtAddressLine3.Location = new System.Drawing.Point(101, 59);
            this.txtAddressLine3.Name = "txtAddressLine3";
            this.txtAddressLine3.Size = new System.Drawing.Size(241, 20);
            this.txtAddressLine3.TabIndex = 37;
            // 
            // lblAddressLine3
            // 
            this.lblAddressLine3.AutoSize = true;
            this.lblAddressLine3.Location = new System.Drawing.Point(4, 62);
            this.lblAddressLine3.Name = "lblAddressLine3";
            this.lblAddressLine3.Size = new System.Drawing.Size(77, 13);
            this.lblAddressLine3.TabIndex = 34;
            this.lblAddressLine3.Text = "Address Line 3";
            // 
            // txtAddressLine1
            // 
            this.txtAddressLine1.Location = new System.Drawing.Point(101, 6);
            this.txtAddressLine1.Name = "txtAddressLine1";
            this.txtAddressLine1.Size = new System.Drawing.Size(241, 20);
            this.txtAddressLine1.TabIndex = 38;
            // 
            // lblAddressLine1
            // 
            this.lblAddressLine1.AutoSize = true;
            this.lblAddressLine1.Location = new System.Drawing.Point(4, 9);
            this.lblAddressLine1.Name = "lblAddressLine1";
            this.lblAddressLine1.Size = new System.Drawing.Size(77, 13);
            this.lblAddressLine1.TabIndex = 31;
            this.lblAddressLine1.Text = "Address Line 1";
            // 
            // txtAddressLine2
            // 
            this.txtAddressLine2.Location = new System.Drawing.Point(101, 33);
            this.txtAddressLine2.Name = "txtAddressLine2";
            this.txtAddressLine2.Size = new System.Drawing.Size(241, 20);
            this.txtAddressLine2.TabIndex = 35;
            // 
            // lblAddressLine2
            // 
            this.lblAddressLine2.AutoSize = true;
            this.lblAddressLine2.Location = new System.Drawing.Point(4, 36);
            this.lblAddressLine2.Name = "lblAddressLine2";
            this.lblAddressLine2.Size = new System.Drawing.Size(77, 13);
            this.lblAddressLine2.TabIndex = 32;
            this.lblAddressLine2.Text = "Address Line 2";
            // 
            // FrmPurchaseQuote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(902, 585);
            this.Controls.Add(this.btnBarcode);
            this.Controls.Add(this.gbMainDetail);
            this.Controls.Add(this.gbPurchaseLines);
            this.Controls.Add(this.gpSummary);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRecord);
            this.Name = "FrmPurchaseQuote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Purchase Quote";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tc.ResumeLayout(false);
            this.tpPurchaseQuote.ResumeLayout(false);
            this.tpPurchaseQuote.PerformLayout();
            this.tpPurchaseLines.ResumeLayout(false);
            this.tpPurchaseLines.PerformLayout();
            this.gbMainDetail.ResumeLayout(false);
            this.gbMainDetail.PerformLayout();
            this.gbPurchaseLines.ResumeLayout(false);
            this.gbPurchaseLines.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseLines)).EndInit();
            this.gpSummary.ResumeLayout(false);
            this.gpSummary.PerformLayout();
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
        private System.Windows.Forms.Label lblPlus;
        private System.Windows.Forms.Label lblEqual;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TabControl tc;
        private System.Windows.Forms.TabPage tpPurchaseQuote;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cboCurrency;
        private System.Windows.Forms.CheckBox chkTaxInclusive;
        private System.Windows.Forms.CZRoundedGroupBox gbMainDetail;
        private System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.TextBox txtJournalMemo;
        private System.Windows.Forms.Label lblPurchaseDate;
        private System.Windows.Forms.Label lblJournalMemo;
        private System.Windows.Forms.DateTimePicker dtpPromisedDate;
        private System.Windows.Forms.Label lblPromisedDate;
        private System.Windows.Forms.TabPage tpPurchaseLines;
        private System.Windows.Forms.CZRoundedGroupBox gbPurchaseLines;
        private System.Windows.Forms.Button btnDelLine;
        private System.Windows.Forms.Button btnNewLine;
        private System.Windows.Forms.DataGridView dgvPurchaseLines;
        private System.Windows.Forms.CZRoundedGroupBox gpSummary;
        private System.Windows.Forms.TextBox txtPurchaseNo;
        private System.Windows.Forms.Label lblPurchaseNo;
        private System.Windows.Forms.ComboBox cboPurchaseLayout;
        private System.Windows.Forms.Label lblPurchaseLayout;
        private System.Windows.Forms.ComboBox cboInvoiceDelivery;
        private System.Windows.Forms.Label lblInvoiceDelivery;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.ComboBox cboTerms;
        private System.Windows.Forms.Label lblTerms;
        private System.Windows.Forms.ComboBox cboFreightTaxCode;
        private System.Windows.Forms.ComboBox cboShippingMethod;
        private System.Windows.Forms.TextBox txtFreight;
        private System.Windows.Forms.Label lblShippingMethod;
        private System.Windows.Forms.Label lblFreight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSupplierPO;
        private System.Windows.Forms.TextBox txtSupplierPO;
        private System.Windows.Forms.ComboBox cboReferralSource;
        private System.Windows.Forms.Label lblReferralSource;
        private System.Windows.Forms.ComboBox cboComments;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.Button btnBarcode;
        private System.Windows.Forms.ComboBox cboAddresses;
        private System.Windows.Forms.Button btnCopyAddress;
        private System.Windows.Forms.Button btnClearAddress;
        private System.Windows.Forms.TextBox txtAddressLine4;
        private System.Windows.Forms.Label lblAddressLine4;
        private System.Windows.Forms.TextBox txtAddressLine3;
        private System.Windows.Forms.Label lblAddressLine3;
        private System.Windows.Forms.TextBox txtAddressLine1;
        private System.Windows.Forms.Label lblAddressLine1;
        private System.Windows.Forms.TextBox txtAddressLine2;
        private System.Windows.Forms.Label lblAddressLine2;
        private System.Windows.Forms.TextBox txtSupplierCity;
        private System.Windows.Forms.Label lblSupplierEmail;
        private System.Windows.Forms.Label lblSupplierPhone1;
        private System.Windows.Forms.TextBox txtSupplierEmail;
        private System.Windows.Forms.Label lblDestinationCountry;
        private System.Windows.Forms.Label lblSupplierPhone2;
        private System.Windows.Forms.TextBox txtSupplierCountry;
        private System.Windows.Forms.TextBox txtSupplierPhone2;
        private System.Windows.Forms.TextBox txtSupplierPhone1;
        private System.Windows.Forms.Label lblSupplierCity;
    }
}