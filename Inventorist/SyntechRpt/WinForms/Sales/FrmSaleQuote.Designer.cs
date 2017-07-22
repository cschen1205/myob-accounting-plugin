namespace SyntechRpt.WinForms.Sales
{
    partial class FrmSaleQuote
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTaxValue = new System.Windows.Forms.TextBox();
            this.lblSubtotalValue = new System.Windows.Forms.Label();
            this.txtSubtotalValue = new System.Windows.Forms.TextBox();
            this.lblTaxValue = new System.Windows.Forms.Label();
            this.lblTotalValues = new System.Windows.Forms.Label();
            this.txtTotalValue = new System.Windows.Forms.TextBox();
            this.lblPlus = new System.Windows.Forms.Label();
            this.lblEqual = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.cboReferralSource = new System.Windows.Forms.ComboBox();
            this.lblReferralSource = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tc = new System.Windows.Forms.TabControl();
            this.tpSaleQuote = new System.Windows.Forms.TabPage();
            this.gbCustomerDetails = new System.Windows.Forms.GroupBox();
            this.lblCustomerPhone2 = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.lblDestinationCountry = new System.Windows.Forms.Label();
            this.lblCustomerID = new System.Windows.Forms.Label();
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
            this.gbComments = new System.Windows.Forms.GroupBox();
            this.cboTerms = new System.Windows.Forms.ComboBox();
            this.lblTerms = new System.Windows.Forms.Label();
            this.cboComments = new System.Windows.Forms.ComboBox();
            this.lblComments = new System.Windows.Forms.Label();
            this.gbMainDetail = new System.Windows.Forms.GroupBox();
            this.cboSalesperson = new System.Windows.Forms.ComboBox();
            this.dtpSaleDate = new System.Windows.Forms.DateTimePicker();
            this.txtJournalMemo = new System.Windows.Forms.TextBox();
            this.lblSaleDate = new System.Windows.Forms.Label();
            this.lblSalesperson = new System.Windows.Forms.Label();
            this.dtpPromisedDate = new System.Windows.Forms.DateTimePicker();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPromisedDate = new System.Windows.Forms.Label();
            this.gbShipTo = new System.Windows.Forms.GroupBox();
            this.cboAddresses = new System.Windows.Forms.ComboBox();
            this.btnCopyAddress = new System.Windows.Forms.Button();
            this.btnClearAddress = new System.Windows.Forms.Button();
            this.cboFreightTaxCode = new System.Windows.Forms.ComboBox();
            this.cboShippMethod = new System.Windows.Forms.ComboBox();
            this.txtAddressLine4 = new System.Windows.Forms.TextBox();
            this.lblAddressLine4 = new System.Windows.Forms.Label();
            this.txtAddressLine3 = new System.Windows.Forms.TextBox();
            this.lblAddressLine3 = new System.Windows.Forms.Label();
            this.txtFreight = new System.Windows.Forms.TextBox();
            this.lblFreight = new System.Windows.Forms.Label();
            this.txtAddressLine1 = new System.Windows.Forms.TextBox();
            this.lblAddressLine1 = new System.Windows.Forms.Label();
            this.lblShippingMethod = new System.Windows.Forms.Label();
            this.txtAddressLine2 = new System.Windows.Forms.TextBox();
            this.lblAddressLine2 = new System.Windows.Forms.Label();
            this.tpSaleLines = new System.Windows.Forms.TabPage();
            this.gbSaleLines = new System.Windows.Forms.GroupBox();
            this.btnDelLine = new System.Windows.Forms.Button();
            this.btnNewLine = new System.Windows.Forms.Button();
            this.dgvSaleLines = new System.Windows.Forms.DataGridView();
            this.cboCurrency = new System.Windows.Forms.ComboBox();
            this.chkTaxInclusive = new System.Windows.Forms.CheckBox();
            this.gpSummary = new System.Windows.Forms.GroupBox();
            this.txtSaleNo = new System.Windows.Forms.TextBox();
            this.lblSaleOrderNo = new System.Windows.Forms.Label();
            this.cboSaleLayout = new System.Windows.Forms.ComboBox();
            this.lblSaleLayout = new System.Windows.Forms.Label();
            this.lblRate = new System.Windows.Forms.Label();
            this.cboInvoiceDelivery = new System.Windows.Forms.ComboBox();
            this.lblDeliveryStatusMainDetail = new System.Windows.Forms.Label();
            this.btnJournal = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tc.SuspendLayout();
            this.tpSaleQuote.SuspendLayout();
            this.gbCustomerDetails.SuspendLayout();
            this.gbComments.SuspendLayout();
            this.gbMainDetail.SuspendLayout();
            this.gbShipTo.SuspendLayout();
            this.tpSaleLines.SuspendLayout();
            this.gbSaleLines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleLines)).BeginInit();
            this.gpSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTaxValue);
            this.groupBox1.Controls.Add(this.lblSubtotalValue);
            this.groupBox1.Controls.Add(this.txtSubtotalValue);
            this.groupBox1.Controls.Add(this.lblTaxValue);
            this.groupBox1.Controls.Add(this.lblTotalValues);
            this.groupBox1.Controls.Add(this.txtTotalValue);
            this.groupBox1.Controls.Add(this.lblPlus);
            this.groupBox1.Controls.Add(this.lblEqual);
            this.groupBox1.Location = new System.Drawing.Point(12, 470);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 59);
            this.groupBox1.TabIndex = 87;
            this.groupBox1.TabStop = false;
            // 
            // txtTaxValue
            // 
            this.txtTaxValue.Enabled = false;
            this.txtTaxValue.Location = new System.Drawing.Point(124, 33);
            this.txtTaxValue.Name = "txtTaxValue";
            this.txtTaxValue.Size = new System.Drawing.Size(94, 20);
            this.txtTaxValue.TabIndex = 28;
            // 
            // lblSubtotalValue
            // 
            this.lblSubtotalValue.AutoSize = true;
            this.lblSubtotalValue.Location = new System.Drawing.Point(8, 16);
            this.lblSubtotalValue.Name = "lblSubtotalValue";
            this.lblSubtotalValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSubtotalValue.Size = new System.Drawing.Size(76, 13);
            this.lblSubtotalValue.TabIndex = 24;
            this.lblSubtotalValue.Text = "Subtotal Value";
            // 
            // txtSubtotalValue
            // 
            this.txtSubtotalValue.Enabled = false;
            this.txtSubtotalValue.Location = new System.Drawing.Point(10, 33);
            this.txtSubtotalValue.Name = "txtSubtotalValue";
            this.txtSubtotalValue.Size = new System.Drawing.Size(94, 20);
            this.txtSubtotalValue.TabIndex = 27;
            // 
            // lblTaxValue
            // 
            this.lblTaxValue.AutoSize = true;
            this.lblTaxValue.Location = new System.Drawing.Point(122, 16);
            this.lblTaxValue.Name = "lblTaxValue";
            this.lblTaxValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTaxValue.Size = new System.Drawing.Size(55, 13);
            this.lblTaxValue.TabIndex = 25;
            this.lblTaxValue.Text = "Tax Value";
            // 
            // lblTotalValues
            // 
            this.lblTotalValues.AutoSize = true;
            this.lblTotalValues.Location = new System.Drawing.Point(237, 16);
            this.lblTotalValues.Name = "lblTotalValues";
            this.lblTotalValues.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotalValues.Size = new System.Drawing.Size(66, 13);
            this.lblTotalValues.TabIndex = 26;
            this.lblTotalValues.Text = "Total Values";
            // 
            // txtTotalValue
            // 
            this.txtTotalValue.Enabled = false;
            this.txtTotalValue.Location = new System.Drawing.Point(239, 33);
            this.txtTotalValue.Name = "txtTotalValue";
            this.txtTotalValue.Size = new System.Drawing.Size(113, 20);
            this.txtTotalValue.TabIndex = 29;
            // 
            // lblPlus
            // 
            this.lblPlus.AutoSize = true;
            this.lblPlus.Location = new System.Drawing.Point(108, 36);
            this.lblPlus.Name = "lblPlus";
            this.lblPlus.Size = new System.Drawing.Size(13, 13);
            this.lblPlus.TabIndex = 31;
            this.lblPlus.Text = "+";
            // 
            // lblEqual
            // 
            this.lblEqual.AutoSize = true;
            this.lblEqual.Location = new System.Drawing.Point(221, 36);
            this.lblEqual.Name = "lblEqual";
            this.lblEqual.Size = new System.Drawing.Size(13, 13);
            this.lblEqual.TabIndex = 30;
            this.lblEqual.Text = "=";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::SyntechRpt.Properties.Resources.cancel_record;
            this.btnClose.Location = new System.Drawing.Point(680, 473);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 56);
            this.btnClose.TabIndex = 90;
            this.btnClose.Text = "Cancel";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cboReferralSource
            // 
            this.cboReferralSource.FormattingEnabled = true;
            this.cboReferralSource.Location = new System.Drawing.Point(106, 71);
            this.cboReferralSource.Name = "cboReferralSource";
            this.cboReferralSource.Size = new System.Drawing.Size(233, 21);
            this.cboReferralSource.TabIndex = 85;
            // 
            // lblReferralSource
            // 
            this.lblReferralSource.AutoSize = true;
            this.lblReferralSource.Location = new System.Drawing.Point(9, 74);
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
            this.tc.Controls.Add(this.tpSaleQuote);
            this.tc.Controls.Add(this.tpSaleLines);
            this.tc.Location = new System.Drawing.Point(12, 12);
            this.tc.Name = "tc";
            this.tc.SelectedIndex = 0;
            this.tc.Size = new System.Drawing.Size(728, 330);
            this.tc.TabIndex = 93;
            // 
            // tpSaleQuote
            // 
            this.tpSaleQuote.Controls.Add(this.gbCustomerDetails);
            this.tpSaleQuote.Controls.Add(this.gbComments);
            this.tpSaleQuote.Controls.Add(this.gbMainDetail);
            this.tpSaleQuote.Controls.Add(this.gbShipTo);
            this.tpSaleQuote.Location = new System.Drawing.Point(4, 22);
            this.tpSaleQuote.Name = "tpSaleQuote";
            this.tpSaleQuote.Padding = new System.Windows.Forms.Padding(3);
            this.tpSaleQuote.Size = new System.Drawing.Size(720, 304);
            this.tpSaleQuote.TabIndex = 0;
            this.tpSaleQuote.Text = "Sale Quote";
            this.tpSaleQuote.UseVisualStyleBackColor = true;
            // 
            // gbCustomerDetails
            // 
            this.gbCustomerDetails.Controls.Add(this.lblCustomerPhone2);
            this.gbCustomerDetails.Controls.Add(this.cboCustomer);
            this.gbCustomerDetails.Controls.Add(this.lblDestinationCountry);
            this.gbCustomerDetails.Controls.Add(this.lblCustomerID);
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
            this.gbCustomerDetails.Location = new System.Drawing.Point(7, 117);
            this.gbCustomerDetails.Name = "gbCustomerDetails";
            this.gbCustomerDetails.Size = new System.Drawing.Size(347, 179);
            this.gbCustomerDetails.TabIndex = 85;
            this.gbCustomerDetails.TabStop = false;
            this.gbCustomerDetails.Text = "Customer Details";
            // 
            // lblCustomerPhone2
            // 
            this.lblCustomerPhone2.AutoSize = true;
            this.lblCustomerPhone2.Location = new System.Drawing.Point(6, 77);
            this.lblCustomerPhone2.Name = "lblCustomerPhone2";
            this.lblCustomerPhone2.Size = new System.Drawing.Size(47, 13);
            this.lblCustomerPhone2.TabIndex = 0;
            this.lblCustomerPhone2.Text = "Phone 2";
            // 
            // cboCustomer
            // 
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(58, 19);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(273, 21);
            this.cboCustomer.TabIndex = 2;
            // 
            // lblDestinationCountry
            // 
            this.lblDestinationCountry.AutoSize = true;
            this.lblDestinationCountry.Location = new System.Drawing.Point(180, 77);
            this.lblDestinationCountry.Name = "lblDestinationCountry";
            this.lblDestinationCountry.Size = new System.Drawing.Size(43, 13);
            this.lblDestinationCountry.TabIndex = 0;
            this.lblDestinationCountry.Text = "Country";
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Location = new System.Drawing.Point(6, 22);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(51, 13);
            this.lblCustomerID.TabIndex = 0;
            this.lblCustomerID.Text = "Customer";
            // 
            // lblCustomerPO
            // 
            this.lblCustomerPO.AutoSize = true;
            this.lblCustomerPO.Location = new System.Drawing.Point(6, 132);
            this.lblCustomerPO.Name = "lblCustomerPO";
            this.lblCustomerPO.Size = new System.Drawing.Size(32, 13);
            this.lblCustomerPO.TabIndex = 0;
            this.lblCustomerPO.Text = "PO #";
            // 
            // lblCustomerEmail
            // 
            this.lblCustomerEmail.AutoSize = true;
            this.lblCustomerEmail.Location = new System.Drawing.Point(6, 105);
            this.lblCustomerEmail.Name = "lblCustomerEmail";
            this.lblCustomerEmail.Size = new System.Drawing.Size(35, 13);
            this.lblCustomerEmail.TabIndex = 0;
            this.lblCustomerEmail.Text = "E-mail";
            // 
            // lblCustomerPhone1
            // 
            this.lblCustomerPhone1.AutoSize = true;
            this.lblCustomerPhone1.Location = new System.Drawing.Point(6, 49);
            this.lblCustomerPhone1.Name = "lblCustomerPhone1";
            this.lblCustomerPhone1.Size = new System.Drawing.Size(47, 13);
            this.lblCustomerPhone1.TabIndex = 0;
            this.lblCustomerPhone1.Text = "Phone 1";
            // 
            // lblCustomerCity
            // 
            this.lblCustomerCity.AutoSize = true;
            this.lblCustomerCity.Location = new System.Drawing.Point(198, 51);
            this.lblCustomerCity.Name = "lblCustomerCity";
            this.lblCustomerCity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCustomerCity.Size = new System.Drawing.Size(24, 13);
            this.lblCustomerCity.TabIndex = 0;
            this.lblCustomerCity.Text = "City";
            // 
            // txtCustomerPhone2
            // 
            this.txtCustomerPhone2.Enabled = false;
            this.txtCustomerPhone2.Location = new System.Drawing.Point(59, 74);
            this.txtCustomerPhone2.Name = "txtCustomerPhone2";
            this.txtCustomerPhone2.Size = new System.Drawing.Size(114, 20);
            this.txtCustomerPhone2.TabIndex = 1;
            // 
            // txtCustomerPO
            // 
            this.txtCustomerPO.Location = new System.Drawing.Point(58, 129);
            this.txtCustomerPO.Name = "txtCustomerPO";
            this.txtCustomerPO.Size = new System.Drawing.Size(115, 20);
            this.txtCustomerPO.TabIndex = 1;
            // 
            // txtCustomerEmail
            // 
            this.txtCustomerEmail.Enabled = false;
            this.txtCustomerEmail.Location = new System.Drawing.Point(59, 102);
            this.txtCustomerEmail.Name = "txtCustomerEmail";
            this.txtCustomerEmail.Size = new System.Drawing.Size(114, 20);
            this.txtCustomerEmail.TabIndex = 1;
            // 
            // txtCustomerPhone1
            // 
            this.txtCustomerPhone1.Enabled = false;
            this.txtCustomerPhone1.Location = new System.Drawing.Point(58, 47);
            this.txtCustomerPhone1.Name = "txtCustomerPhone1";
            this.txtCustomerPhone1.Size = new System.Drawing.Size(115, 20);
            this.txtCustomerPhone1.TabIndex = 1;
            // 
            // txtDestinationCountry
            // 
            this.txtDestinationCountry.Location = new System.Drawing.Point(228, 74);
            this.txtDestinationCountry.Name = "txtDestinationCountry";
            this.txtDestinationCountry.Size = new System.Drawing.Size(103, 20);
            this.txtDestinationCountry.TabIndex = 1;
            // 
            // txtCustomerCity
            // 
            this.txtCustomerCity.Enabled = false;
            this.txtCustomerCity.Location = new System.Drawing.Point(228, 47);
            this.txtCustomerCity.Name = "txtCustomerCity";
            this.txtCustomerCity.Size = new System.Drawing.Size(103, 20);
            this.txtCustomerCity.TabIndex = 1;
            // 
            // gbComments
            // 
            this.gbComments.Controls.Add(this.cboTerms);
            this.gbComments.Controls.Add(this.lblTerms);
            this.gbComments.Controls.Add(this.cboComments);
            this.gbComments.Controls.Add(this.lblComments);
            this.gbComments.Controls.Add(this.cboReferralSource);
            this.gbComments.Controls.Add(this.lblReferralSource);
            this.gbComments.Location = new System.Drawing.Point(360, 8);
            this.gbComments.Name = "gbComments";
            this.gbComments.Size = new System.Drawing.Size(352, 103);
            this.gbComments.TabIndex = 84;
            this.gbComments.TabStop = false;
            // 
            // cboTerms
            // 
            this.cboTerms.FormattingEnabled = true;
            this.cboTerms.Location = new System.Drawing.Point(106, 42);
            this.cboTerms.Name = "cboTerms";
            this.cboTerms.Size = new System.Drawing.Size(233, 21);
            this.cboTerms.TabIndex = 2;
            // 
            // lblTerms
            // 
            this.lblTerms.AutoSize = true;
            this.lblTerms.Location = new System.Drawing.Point(6, 45);
            this.lblTerms.Name = "lblTerms";
            this.lblTerms.Size = new System.Drawing.Size(36, 13);
            this.lblTerms.TabIndex = 0;
            this.lblTerms.Text = "Terms";
            // 
            // cboComments
            // 
            this.cboComments.FormattingEnabled = true;
            this.cboComments.Location = new System.Drawing.Point(106, 15);
            this.cboComments.Name = "cboComments";
            this.cboComments.Size = new System.Drawing.Size(233, 21);
            this.cboComments.TabIndex = 2;
            // 
            // lblComments
            // 
            this.lblComments.AutoSize = true;
            this.lblComments.Location = new System.Drawing.Point(6, 22);
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(56, 13);
            this.lblComments.TabIndex = 0;
            this.lblComments.Text = "Comments";
            // 
            // gbMainDetail
            // 
            this.gbMainDetail.Controls.Add(this.cboSalesperson);
            this.gbMainDetail.Controls.Add(this.dtpSaleDate);
            this.gbMainDetail.Controls.Add(this.txtJournalMemo);
            this.gbMainDetail.Controls.Add(this.lblSaleDate);
            this.gbMainDetail.Controls.Add(this.lblSalesperson);
            this.gbMainDetail.Controls.Add(this.dtpPromisedDate);
            this.gbMainDetail.Controls.Add(this.lblDescription);
            this.gbMainDetail.Controls.Add(this.lblPromisedDate);
            this.gbMainDetail.Location = new System.Drawing.Point(7, 8);
            this.gbMainDetail.Name = "gbMainDetail";
            this.gbMainDetail.Size = new System.Drawing.Size(347, 103);
            this.gbMainDetail.TabIndex = 83;
            this.gbMainDetail.TabStop = false;
            this.gbMainDetail.Text = "Main Detail";
            // 
            // cboSalesperson
            // 
            this.cboSalesperson.FormattingEnabled = true;
            this.cboSalesperson.Location = new System.Drawing.Point(64, 18);
            this.cboSalesperson.Name = "cboSalesperson";
            this.cboSalesperson.Size = new System.Drawing.Size(267, 21);
            this.cboSalesperson.TabIndex = 19;
            // 
            // dtpSaleDate
            // 
            this.dtpSaleDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSaleDate.Location = new System.Drawing.Point(64, 45);
            this.dtpSaleDate.Name = "dtpSaleDate";
            this.dtpSaleDate.Size = new System.Drawing.Size(109, 20);
            this.dtpSaleDate.TabIndex = 3;
            // 
            // txtJournalMemo
            // 
            this.txtJournalMemo.Location = new System.Drawing.Point(64, 71);
            this.txtJournalMemo.Name = "txtJournalMemo";
            this.txtJournalMemo.Size = new System.Drawing.Size(267, 20);
            this.txtJournalMemo.TabIndex = 1;
            // 
            // lblSaleDate
            // 
            this.lblSaleDate.AutoSize = true;
            this.lblSaleDate.Location = new System.Drawing.Point(6, 49);
            this.lblSaleDate.Name = "lblSaleDate";
            this.lblSaleDate.Size = new System.Drawing.Size(30, 13);
            this.lblSaleDate.TabIndex = 0;
            this.lblSaleDate.Text = "Date";
            // 
            // lblSalesperson
            // 
            this.lblSalesperson.AutoSize = true;
            this.lblSalesperson.Location = new System.Drawing.Point(6, 21);
            this.lblSalesperson.Name = "lblSalesperson";
            this.lblSalesperson.Size = new System.Drawing.Size(43, 13);
            this.lblSalesperson.TabIndex = 0;
            this.lblSalesperson.Text = "Sale By";
            // 
            // dtpPromisedDate
            // 
            this.dtpPromisedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPromisedDate.Location = new System.Drawing.Point(228, 45);
            this.dtpPromisedDate.Name = "dtpPromisedDate";
            this.dtpPromisedDate.Size = new System.Drawing.Size(103, 20);
            this.dtpPromisedDate.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(6, 74);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(36, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Memo";
            // 
            // lblPromisedDate
            // 
            this.lblPromisedDate.AutoSize = true;
            this.lblPromisedDate.Location = new System.Drawing.Point(176, 48);
            this.lblPromisedDate.Name = "lblPromisedDate";
            this.lblPromisedDate.Size = new System.Drawing.Size(50, 13);
            this.lblPromisedDate.TabIndex = 0;
            this.lblPromisedDate.Text = "Promised";
            // 
            // gbShipTo
            // 
            this.gbShipTo.Controls.Add(this.cboAddresses);
            this.gbShipTo.Controls.Add(this.btnCopyAddress);
            this.gbShipTo.Controls.Add(this.btnClearAddress);
            this.gbShipTo.Controls.Add(this.cboFreightTaxCode);
            this.gbShipTo.Controls.Add(this.cboShippMethod);
            this.gbShipTo.Controls.Add(this.txtAddressLine4);
            this.gbShipTo.Controls.Add(this.lblAddressLine4);
            this.gbShipTo.Controls.Add(this.txtAddressLine3);
            this.gbShipTo.Controls.Add(this.lblAddressLine3);
            this.gbShipTo.Controls.Add(this.txtFreight);
            this.gbShipTo.Controls.Add(this.lblFreight);
            this.gbShipTo.Controls.Add(this.txtAddressLine1);
            this.gbShipTo.Controls.Add(this.lblAddressLine1);
            this.gbShipTo.Controls.Add(this.lblShippingMethod);
            this.gbShipTo.Controls.Add(this.txtAddressLine2);
            this.gbShipTo.Controls.Add(this.lblAddressLine2);
            this.gbShipTo.Location = new System.Drawing.Point(360, 117);
            this.gbShipTo.Name = "gbShipTo";
            this.gbShipTo.Size = new System.Drawing.Size(352, 179);
            this.gbShipTo.TabIndex = 86;
            this.gbShipTo.TabStop = false;
            this.gbShipTo.Text = "ShipTo";
            // 
            // cboAddresses
            // 
            this.cboAddresses.FormattingEnabled = true;
            this.cboAddresses.Location = new System.Drawing.Point(251, 71);
            this.cboAddresses.Name = "cboAddresses";
            this.cboAddresses.Size = new System.Drawing.Size(88, 21);
            this.cboAddresses.TabIndex = 19;
            this.cboAddresses.SelectedIndexChanged += new System.EventHandler(this.cboAddresses_SelectedIndexChanged);
            // 
            // btnCopyAddress
            // 
            this.btnCopyAddress.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCopyAddress.FlatAppearance.BorderSize = 0;
            this.btnCopyAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyAddress.Image = global::SyntechRpt.Properties.Resources.copy;
            this.btnCopyAddress.Location = new System.Drawing.Point(247, 148);
            this.btnCopyAddress.Name = "btnCopyAddress";
            this.btnCopyAddress.Size = new System.Drawing.Size(32, 23);
            this.btnCopyAddress.TabIndex = 29;
            this.btnCopyAddress.UseVisualStyleBackColor = false;
            this.btnCopyAddress.Click += new System.EventHandler(this.btnCopyAddress_Click);
            // 
            // btnClearAddress
            // 
            this.btnClearAddress.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClearAddress.BackgroundImage = global::SyntechRpt.Properties.Resources.reset;
            this.btnClearAddress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClearAddress.FlatAppearance.BorderSize = 0;
            this.btnClearAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearAddress.Location = new System.Drawing.Point(273, 149);
            this.btnClearAddress.Name = "btnClearAddress";
            this.btnClearAddress.Size = new System.Drawing.Size(32, 25);
            this.btnClearAddress.TabIndex = 29;
            this.btnClearAddress.UseVisualStyleBackColor = false;
            this.btnClearAddress.Click += new System.EventHandler(this.btnClearAddress_Click);
            // 
            // cboFreightTaxCode
            // 
            this.cboFreightTaxCode.FormattingEnabled = true;
            this.cboFreightTaxCode.Location = new System.Drawing.Point(251, 46);
            this.cboFreightTaxCode.Name = "cboFreightTaxCode";
            this.cboFreightTaxCode.Size = new System.Drawing.Size(88, 21);
            this.cboFreightTaxCode.TabIndex = 19;
            // 
            // cboShippMethod
            // 
            this.cboShippMethod.FormattingEnabled = true;
            this.cboShippMethod.Location = new System.Drawing.Point(106, 19);
            this.cboShippMethod.Name = "cboShippMethod";
            this.cboShippMethod.Size = new System.Drawing.Size(136, 21);
            this.cboShippMethod.TabIndex = 22;
            // 
            // txtAddressLine4
            // 
            this.txtAddressLine4.Location = new System.Drawing.Point(106, 151);
            this.txtAddressLine4.Name = "txtAddressLine4";
            this.txtAddressLine4.Size = new System.Drawing.Size(136, 20);
            this.txtAddressLine4.TabIndex = 25;
            // 
            // lblAddressLine4
            // 
            this.lblAddressLine4.AutoSize = true;
            this.lblAddressLine4.Location = new System.Drawing.Point(9, 154);
            this.lblAddressLine4.Name = "lblAddressLine4";
            this.lblAddressLine4.Size = new System.Drawing.Size(77, 13);
            this.lblAddressLine4.TabIndex = 22;
            this.lblAddressLine4.Text = "Address Line 4";
            // 
            // txtAddressLine3
            // 
            this.txtAddressLine3.Location = new System.Drawing.Point(106, 125);
            this.txtAddressLine3.Name = "txtAddressLine3";
            this.txtAddressLine3.Size = new System.Drawing.Size(136, 20);
            this.txtAddressLine3.TabIndex = 26;
            // 
            // lblAddressLine3
            // 
            this.lblAddressLine3.AutoSize = true;
            this.lblAddressLine3.Location = new System.Drawing.Point(9, 128);
            this.lblAddressLine3.Name = "lblAddressLine3";
            this.lblAddressLine3.Size = new System.Drawing.Size(77, 13);
            this.lblAddressLine3.TabIndex = 23;
            this.lblAddressLine3.Text = "Address Line 3";
            // 
            // txtFreight
            // 
            this.txtFreight.Location = new System.Drawing.Point(106, 46);
            this.txtFreight.Name = "txtFreight";
            this.txtFreight.Size = new System.Drawing.Size(136, 20);
            this.txtFreight.TabIndex = 27;
            this.txtFreight.Text = "0";
            // 
            // lblFreight
            // 
            this.lblFreight.AutoSize = true;
            this.lblFreight.Location = new System.Drawing.Point(9, 49);
            this.lblFreight.Name = "lblFreight";
            this.lblFreight.Size = new System.Drawing.Size(39, 13);
            this.lblFreight.TabIndex = 20;
            this.lblFreight.Text = "Freight";
            // 
            // txtAddressLine1
            // 
            this.txtAddressLine1.Location = new System.Drawing.Point(106, 72);
            this.txtAddressLine1.Name = "txtAddressLine1";
            this.txtAddressLine1.Size = new System.Drawing.Size(136, 20);
            this.txtAddressLine1.TabIndex = 27;
            // 
            // lblAddressLine1
            // 
            this.lblAddressLine1.AutoSize = true;
            this.lblAddressLine1.Location = new System.Drawing.Point(9, 75);
            this.lblAddressLine1.Name = "lblAddressLine1";
            this.lblAddressLine1.Size = new System.Drawing.Size(77, 13);
            this.lblAddressLine1.TabIndex = 20;
            this.lblAddressLine1.Text = "Address Line 1";
            // 
            // lblShippingMethod
            // 
            this.lblShippingMethod.AutoSize = true;
            this.lblShippingMethod.Location = new System.Drawing.Point(9, 22);
            this.lblShippingMethod.Name = "lblShippingMethod";
            this.lblShippingMethod.Size = new System.Drawing.Size(90, 13);
            this.lblShippingMethod.TabIndex = 0;
            this.lblShippingMethod.Text = "Shipping Method:";
            // 
            // txtAddressLine2
            // 
            this.txtAddressLine2.Location = new System.Drawing.Point(106, 99);
            this.txtAddressLine2.Name = "txtAddressLine2";
            this.txtAddressLine2.Size = new System.Drawing.Size(136, 20);
            this.txtAddressLine2.TabIndex = 24;
            // 
            // lblAddressLine2
            // 
            this.lblAddressLine2.AutoSize = true;
            this.lblAddressLine2.Location = new System.Drawing.Point(9, 102);
            this.lblAddressLine2.Name = "lblAddressLine2";
            this.lblAddressLine2.Size = new System.Drawing.Size(77, 13);
            this.lblAddressLine2.TabIndex = 21;
            this.lblAddressLine2.Text = "Address Line 2";
            // 
            // tpSaleLines
            // 
            this.tpSaleLines.Controls.Add(this.gbSaleLines);
            this.tpSaleLines.Location = new System.Drawing.Point(4, 22);
            this.tpSaleLines.Name = "tpSaleLines";
            this.tpSaleLines.Padding = new System.Windows.Forms.Padding(3);
            this.tpSaleLines.Size = new System.Drawing.Size(720, 304);
            this.tpSaleLines.TabIndex = 1;
            this.tpSaleLines.Text = "Sale Lines";
            this.tpSaleLines.UseVisualStyleBackColor = true;
            // 
            // gbSaleLines
            // 
            this.gbSaleLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSaleLines.Controls.Add(this.btnDelLine);
            this.gbSaleLines.Controls.Add(this.btnNewLine);
            this.gbSaleLines.Controls.Add(this.dgvSaleLines);
            this.gbSaleLines.Location = new System.Drawing.Point(7, 6);
            this.gbSaleLines.Name = "gbSaleLines";
            this.gbSaleLines.Size = new System.Drawing.Size(705, 292);
            this.gbSaleLines.TabIndex = 25;
            this.gbSaleLines.TabStop = false;
            this.gbSaleLines.Text = "Sale Lines";
            // 
            // btnDelLine
            // 
            this.btnDelLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelLine.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelLine.Image = global::SyntechRpt.Properties.Resources.delete_line;
            this.btnDelLine.Location = new System.Drawing.Point(596, 246);
            this.btnDelLine.Name = "btnDelLine";
            this.btnDelLine.Size = new System.Drawing.Size(103, 40);
            this.btnDelLine.TabIndex = 6;
            this.btnDelLine.Text = "Delete Line";
            this.btnDelLine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelLine.UseVisualStyleBackColor = false;
            this.btnDelLine.Click += new System.EventHandler(this.btnDelLine_Click);
            // 
            // btnNewLine
            // 
            this.btnNewLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewLine.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNewLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewLine.Image = global::SyntechRpt.Properties.Resources.new_line;
            this.btnNewLine.Location = new System.Drawing.Point(494, 246);
            this.btnNewLine.Name = "btnNewLine";
            this.btnNewLine.Size = new System.Drawing.Size(96, 40);
            this.btnNewLine.TabIndex = 5;
            this.btnNewLine.Text = "Create Line";
            this.btnNewLine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewLine.UseVisualStyleBackColor = false;
            this.btnNewLine.Click += new System.EventHandler(this.btnNewLine_Click);
            // 
            // dgvSaleLines
            // 
            this.dgvSaleLines.AllowUserToAddRows = false;
            this.dgvSaleLines.AllowUserToDeleteRows = false;
            this.dgvSaleLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSaleLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaleLines.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSaleLines.Location = new System.Drawing.Point(9, 19);
            this.dgvSaleLines.MultiSelect = false;
            this.dgvSaleLines.Name = "dgvSaleLines";
            this.dgvSaleLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSaleLines.Size = new System.Drawing.Size(690, 221);
            this.dgvSaleLines.TabIndex = 0;
            // 
            // cboCurrency
            // 
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.Location = new System.Drawing.Point(88, 91);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(96, 21);
            this.cboCurrency.TabIndex = 85;
            // 
            // chkTaxInclusive
            // 
            this.chkTaxInclusive.AutoSize = true;
            this.chkTaxInclusive.Checked = true;
            this.chkTaxInclusive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTaxInclusive.Location = new System.Drawing.Point(240, 93);
            this.chkTaxInclusive.Name = "chkTaxInclusive";
            this.chkTaxInclusive.Size = new System.Drawing.Size(100, 17);
            this.chkTaxInclusive.TabIndex = 3;
            this.chkTaxInclusive.Text = "Is Tax Inclusive";
            this.chkTaxInclusive.UseVisualStyleBackColor = true;
            this.chkTaxInclusive.CheckedChanged += new System.EventHandler(this.chkTaxInclusive_CheckedChanged);
            // 
            // gpSummary
            // 
            this.gpSummary.Controls.Add(this.txtSaleNo);
            this.gpSummary.Controls.Add(this.lblSaleOrderNo);
            this.gpSummary.Controls.Add(this.cboSaleLayout);
            this.gpSummary.Controls.Add(this.lblSaleLayout);
            this.gpSummary.Controls.Add(this.lblRate);
            this.gpSummary.Controls.Add(this.cboInvoiceDelivery);
            this.gpSummary.Controls.Add(this.cboCurrency);
            this.gpSummary.Controls.Add(this.lblDeliveryStatusMainDetail);
            this.gpSummary.Controls.Add(this.chkTaxInclusive);
            this.gpSummary.Location = new System.Drawing.Point(12, 344);
            this.gpSummary.Name = "gpSummary";
            this.gpSummary.Size = new System.Drawing.Size(358, 120);
            this.gpSummary.TabIndex = 94;
            this.gpSummary.TabStop = false;
            // 
            // txtSaleNo
            // 
            this.txtSaleNo.Location = new System.Drawing.Point(88, 16);
            this.txtSaleNo.Name = "txtSaleNo";
            this.txtSaleNo.Size = new System.Drawing.Size(96, 20);
            this.txtSaleNo.TabIndex = 88;
            // 
            // lblSaleOrderNo
            // 
            this.lblSaleOrderNo.AutoSize = true;
            this.lblSaleOrderNo.Location = new System.Drawing.Point(6, 16);
            this.lblSaleOrderNo.Name = "lblSaleOrderNo";
            this.lblSaleOrderNo.Size = new System.Drawing.Size(52, 13);
            this.lblSaleOrderNo.TabIndex = 87;
            this.lblSaleOrderNo.Text = "Invoice #";
            // 
            // cboSaleLayout
            // 
            this.cboSaleLayout.FormattingEnabled = true;
            this.cboSaleLayout.Location = new System.Drawing.Point(88, 65);
            this.cboSaleLayout.Name = "cboSaleLayout";
            this.cboSaleLayout.Size = new System.Drawing.Size(254, 21);
            this.cboSaleLayout.TabIndex = 91;
            // 
            // lblSaleLayout
            // 
            this.lblSaleLayout.AutoSize = true;
            this.lblSaleLayout.Location = new System.Drawing.Point(8, 68);
            this.lblSaleLayout.Name = "lblSaleLayout";
            this.lblSaleLayout.Size = new System.Drawing.Size(39, 13);
            this.lblSaleLayout.TabIndex = 90;
            this.lblSaleLayout.Text = "Layout";
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(8, 94);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(30, 13);
            this.lblRate.TabIndex = 0;
            this.lblRate.Text = "Rate";
            // 
            // cboInvoiceDelivery
            // 
            this.cboInvoiceDelivery.FormattingEnabled = true;
            this.cboInvoiceDelivery.Location = new System.Drawing.Point(88, 40);
            this.cboInvoiceDelivery.Name = "cboInvoiceDelivery";
            this.cboInvoiceDelivery.Size = new System.Drawing.Size(254, 21);
            this.cboInvoiceDelivery.TabIndex = 92;
            // 
            // lblDeliveryStatusMainDetail
            // 
            this.lblDeliveryStatusMainDetail.AutoSize = true;
            this.lblDeliveryStatusMainDetail.Location = new System.Drawing.Point(6, 43);
            this.lblDeliveryStatusMainDetail.Name = "lblDeliveryStatusMainDetail";
            this.lblDeliveryStatusMainDetail.Size = new System.Drawing.Size(78, 13);
            this.lblDeliveryStatusMainDetail.TabIndex = 89;
            this.lblDeliveryStatusMainDetail.Text = "Delivery Status";
            // 
            // btnJournal
            // 
            this.btnJournal.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnJournal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJournal.Image = global::SyntechRpt.Properties.Resources.journal;
            this.btnJournal.Location = new System.Drawing.Point(496, 473);
            this.btnJournal.Name = "btnJournal";
            this.btnJournal.Size = new System.Drawing.Size(56, 56);
            this.btnJournal.TabIndex = 92;
            this.btnJournal.Text = "Journal";
            this.btnJournal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnJournal.UseVisualStyleBackColor = false;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Image = global::SyntechRpt.Properties.Resources.print;
            this.btnPrint.Location = new System.Drawing.Point(557, 473);
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
            this.btnRecord.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRecord.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecord.Image = global::SyntechRpt.Properties.Resources.save;
            this.btnRecord.Location = new System.Drawing.Point(619, 473);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(56, 56);
            this.btnRecord.TabIndex = 89;
            this.btnRecord.Text = "Record";
            this.btnRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRecord.UseVisualStyleBackColor = false;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // FrmSaleQuote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 538);
            this.Controls.Add(this.gpSummary);
            this.Controls.Add(this.tc);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnJournal);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRecord);
            this.Name = "FrmSaleQuote";
            this.Text = "Sale Quote";
            this.Load += new System.EventHandler(this.FrmSaleQuote_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tc.ResumeLayout(false);
            this.tpSaleQuote.ResumeLayout(false);
            this.gbCustomerDetails.ResumeLayout(false);
            this.gbCustomerDetails.PerformLayout();
            this.gbComments.ResumeLayout(false);
            this.gbComments.PerformLayout();
            this.gbMainDetail.ResumeLayout(false);
            this.gbMainDetail.PerformLayout();
            this.gbShipTo.ResumeLayout(false);
            this.gbShipTo.PerformLayout();
            this.tpSaleLines.ResumeLayout(false);
            this.gbSaleLines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleLines)).EndInit();
            this.gpSummary.ResumeLayout(false);
            this.gpSummary.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTaxValue;
        private System.Windows.Forms.Label lblSubtotalValue;
        private System.Windows.Forms.TextBox txtSubtotalValue;
        private System.Windows.Forms.Label lblTaxValue;
        private System.Windows.Forms.Label lblTotalValues;
        private System.Windows.Forms.TextBox txtTotalValue;
        private System.Windows.Forms.Label lblPlus;
        private System.Windows.Forms.Label lblEqual;
        private System.Windows.Forms.Button btnJournal;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.ComboBox cboReferralSource;
        private System.Windows.Forms.Label lblReferralSource;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TabControl tc;
        private System.Windows.Forms.TabPage tpSaleQuote;
        private System.Windows.Forms.GroupBox gbCustomerDetails;
        private System.Windows.Forms.ComboBox cboAddresses;
        private System.Windows.Forms.Label lblCustomerPhone2;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label lblDestinationCountry;
        private System.Windows.Forms.Label lblCustomerID;
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
        private System.Windows.Forms.GroupBox gbComments;
        private System.Windows.Forms.ComboBox cboSalesperson;
        private System.Windows.Forms.CheckBox chkTaxInclusive;
        private System.Windows.Forms.ComboBox cboTerms;
        private System.Windows.Forms.Label lblTerms;
        private System.Windows.Forms.ComboBox cboComments;
        private System.Windows.Forms.Label lblSalesperson;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.GroupBox gbMainDetail;
        private System.Windows.Forms.DateTimePicker dtpSaleDate;
        private System.Windows.Forms.TextBox txtJournalMemo;
        private System.Windows.Forms.Label lblSaleDate;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.GroupBox gbShipTo;
        private System.Windows.Forms.Button btnCopyAddress;
        private System.Windows.Forms.Button btnClearAddress;
        private System.Windows.Forms.ComboBox cboFreightTaxCode;
        private System.Windows.Forms.DateTimePicker dtpPromisedDate;
        private System.Windows.Forms.ComboBox cboShippMethod;
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
        private System.Windows.Forms.TabPage tpSaleLines;
        private System.Windows.Forms.GroupBox gbSaleLines;
        private System.Windows.Forms.Button btnDelLine;
        private System.Windows.Forms.Button btnNewLine;
        private System.Windows.Forms.DataGridView dgvSaleLines;
        private System.Windows.Forms.GroupBox gpSummary;
        private System.Windows.Forms.TextBox txtSaleNo;
        private System.Windows.Forms.Label lblSaleOrderNo;
        private System.Windows.Forms.ComboBox cboSaleLayout;
        private System.Windows.Forms.Label lblSaleLayout;
        private System.Windows.Forms.ComboBox cboInvoiceDelivery;
        private System.Windows.Forms.Label lblDeliveryStatusMainDetail;
        private System.Windows.Forms.Label lblRate;
    }
}