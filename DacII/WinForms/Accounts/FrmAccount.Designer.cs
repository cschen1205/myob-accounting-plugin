namespace DacII.WinForms.Accounts
{
    partial class FrmAccount
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
            this.lblAccountType = new System.Windows.Forms.Label();
            this.cboAccountType = new System.Windows.Forms.ComboBox();
            this.tc = new System.Windows.Forms.TabControl();
            this.tpProfile = new System.Windows.Forms.TabPage();
            this.cboAccountClassification = new System.Windows.Forms.ComboBox();
            this.cboSubAccountType = new System.Windows.Forms.ComboBox();
            this.lblAccountClassification = new System.Windows.Forms.Label();
            this.lblSubAccountType = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.tpDetails = new System.Windows.Forms.TabPage();
            this.chkIsTotal = new System.Windows.Forms.CheckBox();
            this.cboCashFlowClassification = new System.Windows.Forms.ComboBox();
            this.cboTaxCode = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnLinkedAccount = new System.Windows.Forms.VistaButton();
            this.lblCashFlowClassification = new System.Windows.Forms.Label();
            this.lblLinkedAccount = new System.Windows.Forms.Label();
            this.lblTaxCode = new System.Windows.Forms.Label();
            this.tpBanking = new System.Windows.Forms.TabPage();
            this.chkIsSelfBalancing = new System.Windows.Forms.CheckBox();
            this.chkCreateBankFiles = new System.Windows.Forms.CheckBox();
            this.txtCompanyTradingName = new System.Windows.Forms.TextBox();
            this.lblCompanyTradingName = new System.Windows.Forms.Label();
            this.txtDirectEntryUserID = new System.Windows.Forms.TextBox();
            this.txtBankAccountName = new System.Windows.Forms.TextBox();
            this.lblDirectEntryUserID = new System.Windows.Forms.Label();
            this.lblIsSelfBalancing = new System.Windows.Forms.Label();
            this.lblBankAccountName = new System.Windows.Forms.Label();
            this.lblCreateBankFiles = new System.Windows.Forms.Label();
            this.txtBankCode = new System.Windows.Forms.TextBox();
            this.lblBankCode = new System.Windows.Forms.Label();
            this.txtBankAccountNumber = new System.Windows.Forms.TextBox();
            this.lblBankAccountNumber = new System.Windows.Forms.Label();
            this.txtBSBCode = new System.Windows.Forms.TextBox();
            this.lblBSBCode = new System.Windows.Forms.Label();
            this.tpHistory = new System.Windows.Forms.TabPage();
            this.dgvAccountHistory = new System.Windows.Forms.DataGridView();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.czRoundedGroupBox1 = new System.Windows.Forms.CZRoundedGroupBox();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.txtCurrentBalance = new System.Windows.Forms.TextBox();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.lblAccountNumber = new System.Windows.Forms.Label();
            this.lblCurrentBalance = new System.Windows.Forms.Label();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.czRoundedGroupBox2 = new System.Windows.Forms.CZRoundedGroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.tc.SuspendLayout();
            this.tpProfile.SuspendLayout();
            this.tpDetails.SuspendLayout();
            this.tpBanking.SuspendLayout();
            this.tpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.czRoundedGroupBox1.SuspendLayout();
            this.czRoundedGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAccountType
            // 
            this.lblAccountType.AutoSize = true;
            this.lblAccountType.Location = new System.Drawing.Point(23, 20);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.Size = new System.Drawing.Size(77, 13);
            this.lblAccountType.TabIndex = 0;
            this.lblAccountType.Text = "Account Type:";
            // 
            // cboAccountType
            // 
            this.cboAccountType.FormattingEnabled = true;
            this.cboAccountType.Location = new System.Drawing.Point(149, 17);
            this.cboAccountType.Name = "cboAccountType";
            this.cboAccountType.Size = new System.Drawing.Size(165, 21);
            this.cboAccountType.TabIndex = 1;
            this.cboAccountType.SelectedIndexChanged += new System.EventHandler(this.cboAccountType_SelectedIndexChanged);
            // 
            // tc
            // 
            this.tc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tc.Controls.Add(this.tpProfile);
            this.tc.Controls.Add(this.tpDetails);
            this.tc.Controls.Add(this.tpBanking);
            this.tc.Controls.Add(this.tpHistory);
            this.tc.Location = new System.Drawing.Point(7, 28);
            this.tc.Name = "tc";
            this.tc.SelectedIndex = 0;
            this.tc.Size = new System.Drawing.Size(665, 355);
            this.tc.TabIndex = 2;
            // 
            // tpProfile
            // 
            this.tpProfile.Controls.Add(this.cboAccountClassification);
            this.tpProfile.Controls.Add(this.cboSubAccountType);
            this.tpProfile.Controls.Add(this.cboAccountType);
            this.tpProfile.Controls.Add(this.lblAccountClassification);
            this.tpProfile.Controls.Add(this.lblSubAccountType);
            this.tpProfile.Controls.Add(this.lblAccountType);
            this.tpProfile.Controls.Add(this.chkActive);
            this.tpProfile.Location = new System.Drawing.Point(4, 22);
            this.tpProfile.Name = "tpProfile";
            this.tpProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tpProfile.Size = new System.Drawing.Size(657, 329);
            this.tpProfile.TabIndex = 0;
            this.tpProfile.Text = "Profile";
            this.tpProfile.UseVisualStyleBackColor = true;
            // 
            // cboAccountClassification
            // 
            this.cboAccountClassification.FormattingEnabled = true;
            this.cboAccountClassification.Location = new System.Drawing.Point(149, 44);
            this.cboAccountClassification.Name = "cboAccountClassification";
            this.cboAccountClassification.Size = new System.Drawing.Size(165, 21);
            this.cboAccountClassification.TabIndex = 1;
            // 
            // cboSubAccountType
            // 
            this.cboSubAccountType.FormattingEnabled = true;
            this.cboSubAccountType.Location = new System.Drawing.Point(149, 71);
            this.cboSubAccountType.Name = "cboSubAccountType";
            this.cboSubAccountType.Size = new System.Drawing.Size(165, 21);
            this.cboSubAccountType.TabIndex = 1;
            // 
            // lblAccountClassification
            // 
            this.lblAccountClassification.AutoSize = true;
            this.lblAccountClassification.Location = new System.Drawing.Point(23, 47);
            this.lblAccountClassification.Name = "lblAccountClassification";
            this.lblAccountClassification.Size = new System.Drawing.Size(114, 13);
            this.lblAccountClassification.TabIndex = 0;
            this.lblAccountClassification.Text = "Account Classification:";
            // 
            // lblSubAccountType
            // 
            this.lblSubAccountType.AutoSize = true;
            this.lblSubAccountType.Location = new System.Drawing.Point(23, 74);
            this.lblSubAccountType.Name = "lblSubAccountType";
            this.lblSubAccountType.Size = new System.Drawing.Size(99, 13);
            this.lblSubAccountType.TabIndex = 0;
            this.lblSubAccountType.Text = "Sub Account Type:";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(458, 19);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(99, 17);
            this.chkActive.TabIndex = 2;
            this.chkActive.Text = "Active Account";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // tpDetails
            // 
            this.tpDetails.Controls.Add(this.chkIsTotal);
            this.tpDetails.Controls.Add(this.cboCashFlowClassification);
            this.tpDetails.Controls.Add(this.cboTaxCode);
            this.tpDetails.Controls.Add(this.txtDescription);
            this.tpDetails.Controls.Add(this.lblDescription);
            this.tpDetails.Controls.Add(this.btnLinkedAccount);
            this.tpDetails.Controls.Add(this.lblCashFlowClassification);
            this.tpDetails.Controls.Add(this.lblLinkedAccount);
            this.tpDetails.Controls.Add(this.lblTaxCode);
            this.tpDetails.Location = new System.Drawing.Point(4, 22);
            this.tpDetails.Name = "tpDetails";
            this.tpDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tpDetails.Size = new System.Drawing.Size(657, 329);
            this.tpDetails.TabIndex = 1;
            this.tpDetails.Text = "Details";
            this.tpDetails.UseVisualStyleBackColor = true;
            // 
            // chkIsTotal
            // 
            this.chkIsTotal.AutoSize = true;
            this.chkIsTotal.Location = new System.Drawing.Point(260, 123);
            this.chkIsTotal.Name = "chkIsTotal";
            this.chkIsTotal.Size = new System.Drawing.Size(282, 17);
            this.chkIsTotal.TabIndex = 7;
            this.chkIsTotal.Text = "When Reporting, Generate a Subtotal for This Section";
            this.chkIsTotal.UseVisualStyleBackColor = true;
            // 
            // cboCashFlowClassification
            // 
            this.cboCashFlowClassification.FormattingEnabled = true;
            this.cboCashFlowClassification.Location = new System.Drawing.Point(260, 173);
            this.cboCashFlowClassification.Name = "cboCashFlowClassification";
            this.cboCashFlowClassification.Size = new System.Drawing.Size(308, 21);
            this.cboCashFlowClassification.TabIndex = 6;
            // 
            // cboTaxCode
            // 
            this.cboTaxCode.FormattingEnabled = true;
            this.cboTaxCode.Location = new System.Drawing.Point(260, 146);
            this.cboTaxCode.Name = "cboTaxCode";
            this.cboTaxCode.Size = new System.Drawing.Size(103, 21);
            this.cboTaxCode.TabIndex = 6;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(260, 17);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(308, 102);
            this.txtDescription.TabIndex = 5;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(160, 20);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description:";
            // 
            // btnLinkedAccount
            // 
            this.btnLinkedAccount.BackColor = System.Drawing.Color.Transparent;
            this.btnLinkedAccount.ButtonText = null;
            this.btnLinkedAccount.Location = new System.Drawing.Point(260, 228);
            this.btnLinkedAccount.Name = "btnLinkedAccount";
            this.btnLinkedAccount.Size = new System.Drawing.Size(211, 32);
            this.btnLinkedAccount.TabIndex = 1;
            // 
            // lblCashFlowClassification
            // 
            this.lblCashFlowClassification.AutoSize = true;
            this.lblCashFlowClassification.Location = new System.Drawing.Point(17, 176);
            this.lblCashFlowClassification.Name = "lblCashFlowClassification";
            this.lblCashFlowClassification.Size = new System.Drawing.Size(206, 13);
            this.lblCashFlowClassification.TabIndex = 0;
            this.lblCashFlowClassification.Text = "Classification for Statement of Cash Flows:";
            // 
            // lblLinkedAccount
            // 
            this.lblLinkedAccount.AutoSize = true;
            this.lblLinkedAccount.Location = new System.Drawing.Point(120, 238);
            this.lblLinkedAccount.Name = "lblLinkedAccount";
            this.lblLinkedAccount.Size = new System.Drawing.Size(103, 13);
            this.lblLinkedAccount.TabIndex = 0;
            this.lblLinkedAccount.Text = "Linked Account For:";
            this.lblLinkedAccount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTaxCode
            // 
            this.lblTaxCode.AutoSize = true;
            this.lblTaxCode.Location = new System.Drawing.Point(160, 149);
            this.lblTaxCode.Name = "lblTaxCode";
            this.lblTaxCode.Size = new System.Drawing.Size(56, 13);
            this.lblTaxCode.TabIndex = 0;
            this.lblTaxCode.Text = "Tax Code:";
            // 
            // tpBanking
            // 
            this.tpBanking.Controls.Add(this.chkIsSelfBalancing);
            this.tpBanking.Controls.Add(this.chkCreateBankFiles);
            this.tpBanking.Controls.Add(this.txtCompanyTradingName);
            this.tpBanking.Controls.Add(this.lblCompanyTradingName);
            this.tpBanking.Controls.Add(this.txtDirectEntryUserID);
            this.tpBanking.Controls.Add(this.txtBankAccountName);
            this.tpBanking.Controls.Add(this.lblDirectEntryUserID);
            this.tpBanking.Controls.Add(this.lblIsSelfBalancing);
            this.tpBanking.Controls.Add(this.lblBankAccountName);
            this.tpBanking.Controls.Add(this.lblCreateBankFiles);
            this.tpBanking.Controls.Add(this.txtBankCode);
            this.tpBanking.Controls.Add(this.lblBankCode);
            this.tpBanking.Controls.Add(this.txtBankAccountNumber);
            this.tpBanking.Controls.Add(this.lblBankAccountNumber);
            this.tpBanking.Controls.Add(this.txtBSBCode);
            this.tpBanking.Controls.Add(this.lblBSBCode);
            this.tpBanking.Location = new System.Drawing.Point(4, 22);
            this.tpBanking.Name = "tpBanking";
            this.tpBanking.Size = new System.Drawing.Size(657, 329);
            this.tpBanking.TabIndex = 2;
            this.tpBanking.Text = "Banking";
            this.tpBanking.UseVisualStyleBackColor = true;
            // 
            // chkIsSelfBalancing
            // 
            this.chkIsSelfBalancing.AutoSize = true;
            this.chkIsSelfBalancing.Location = new System.Drawing.Point(188, 199);
            this.chkIsSelfBalancing.Name = "chkIsSelfBalancing";
            this.chkIsSelfBalancing.Size = new System.Drawing.Size(200, 17);
            this.chkIsSelfBalancing.TabIndex = 10;
            this.chkIsSelfBalancing.Text = "Include a Self-Balancing Transaction";
            this.chkIsSelfBalancing.UseVisualStyleBackColor = true;
            // 
            // chkCreateBankFiles
            // 
            this.chkCreateBankFiles.AutoSize = true;
            this.chkCreateBankFiles.Location = new System.Drawing.Point(188, 124);
            this.chkCreateBankFiles.Name = "chkCreateBankFiles";
            this.chkCreateBankFiles.Size = new System.Drawing.Size(226, 17);
            this.chkCreateBankFiles.TabIndex = 10;
            this.chkCreateBankFiles.Text = "I Create Bank Files [ABA] for This Account";
            this.chkCreateBankFiles.UseVisualStyleBackColor = true;
            this.chkCreateBankFiles.CheckedChanged += new System.EventHandler(this.chkCreateBankFiles_CheckedChanged);
            // 
            // txtCompanyTradingName
            // 
            this.txtCompanyTradingName.Location = new System.Drawing.Point(188, 98);
            this.txtCompanyTradingName.Name = "txtCompanyTradingName";
            this.txtCompanyTradingName.Size = new System.Drawing.Size(226, 20);
            this.txtCompanyTradingName.TabIndex = 9;
            // 
            // lblCompanyTradingName
            // 
            this.lblCompanyTradingName.AutoSize = true;
            this.lblCompanyTradingName.BackColor = System.Drawing.Color.Transparent;
            this.lblCompanyTradingName.Location = new System.Drawing.Point(57, 101);
            this.lblCompanyTradingName.Name = "lblCompanyTradingName";
            this.lblCompanyTradingName.Size = new System.Drawing.Size(124, 13);
            this.lblCompanyTradingName.TabIndex = 8;
            this.lblCompanyTradingName.Text = "Company Trading Name:";
            // 
            // txtDirectEntryUserID
            // 
            this.txtDirectEntryUserID.Location = new System.Drawing.Point(188, 173);
            this.txtDirectEntryUserID.Name = "txtDirectEntryUserID";
            this.txtDirectEntryUserID.Size = new System.Drawing.Size(90, 20);
            this.txtDirectEntryUserID.TabIndex = 9;
            // 
            // txtBankAccountName
            // 
            this.txtBankAccountName.Location = new System.Drawing.Point(188, 72);
            this.txtBankAccountName.Name = "txtBankAccountName";
            this.txtBankAccountName.Size = new System.Drawing.Size(316, 20);
            this.txtBankAccountName.TabIndex = 9;
            // 
            // lblDirectEntryUserID
            // 
            this.lblDirectEntryUserID.AutoSize = true;
            this.lblDirectEntryUserID.BackColor = System.Drawing.Color.Transparent;
            this.lblDirectEntryUserID.Location = new System.Drawing.Point(57, 176);
            this.lblDirectEntryUserID.Name = "lblDirectEntryUserID";
            this.lblDirectEntryUserID.Size = new System.Drawing.Size(104, 13);
            this.lblDirectEntryUserID.TabIndex = 8;
            this.lblDirectEntryUserID.Text = "Direct Entry User ID:";
            // 
            // lblIsSelfBalancing
            // 
            this.lblIsSelfBalancing.AutoSize = true;
            this.lblIsSelfBalancing.BackColor = System.Drawing.Color.Transparent;
            this.lblIsSelfBalancing.Location = new System.Drawing.Point(57, 200);
            this.lblIsSelfBalancing.Name = "lblIsSelfBalancing";
            this.lblIsSelfBalancing.Size = new System.Drawing.Size(84, 13);
            this.lblIsSelfBalancing.TabIndex = 6;
            this.lblIsSelfBalancing.Text = "Direct Entry File:";
            // 
            // lblBankAccountName
            // 
            this.lblBankAccountName.AutoSize = true;
            this.lblBankAccountName.BackColor = System.Drawing.Color.Transparent;
            this.lblBankAccountName.Location = new System.Drawing.Point(57, 75);
            this.lblBankAccountName.Name = "lblBankAccountName";
            this.lblBankAccountName.Size = new System.Drawing.Size(109, 13);
            this.lblBankAccountName.TabIndex = 8;
            this.lblBankAccountName.Text = "Bank Account Name:";
            // 
            // lblCreateBankFiles
            // 
            this.lblCreateBankFiles.AutoSize = true;
            this.lblCreateBankFiles.BackColor = System.Drawing.Color.Transparent;
            this.lblCreateBankFiles.Location = new System.Drawing.Point(57, 125);
            this.lblCreateBankFiles.Name = "lblCreateBankFiles";
            this.lblCreateBankFiles.Size = new System.Drawing.Size(128, 13);
            this.lblCreateBankFiles.TabIndex = 6;
            this.lblCreateBankFiles.Text = "Elecontric Payment Type:";
            // 
            // txtBankCode
            // 
            this.txtBankCode.Location = new System.Drawing.Point(188, 147);
            this.txtBankCode.Name = "txtBankCode";
            this.txtBankCode.Size = new System.Drawing.Size(65, 20);
            this.txtBankCode.TabIndex = 9;
            // 
            // lblBankCode
            // 
            this.lblBankCode.AutoSize = true;
            this.lblBankCode.BackColor = System.Drawing.Color.Transparent;
            this.lblBankCode.Location = new System.Drawing.Point(57, 150);
            this.lblBankCode.Name = "lblBankCode";
            this.lblBankCode.Size = new System.Drawing.Size(63, 13);
            this.lblBankCode.TabIndex = 8;
            this.lblBankCode.Text = "Bank Code:";
            // 
            // txtBankAccountNumber
            // 
            this.txtBankAccountNumber.Location = new System.Drawing.Point(188, 46);
            this.txtBankAccountNumber.Name = "txtBankAccountNumber";
            this.txtBankAccountNumber.Size = new System.Drawing.Size(316, 20);
            this.txtBankAccountNumber.TabIndex = 9;
            // 
            // lblBankAccountNumber
            // 
            this.lblBankAccountNumber.AutoSize = true;
            this.lblBankAccountNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblBankAccountNumber.Location = new System.Drawing.Point(57, 49);
            this.lblBankAccountNumber.Name = "lblBankAccountNumber";
            this.lblBankAccountNumber.Size = new System.Drawing.Size(118, 13);
            this.lblBankAccountNumber.TabIndex = 8;
            this.lblBankAccountNumber.Text = "Bank Account Number:";
            // 
            // txtBSBCode
            // 
            this.txtBSBCode.Location = new System.Drawing.Point(188, 20);
            this.txtBSBCode.Name = "txtBSBCode";
            this.txtBSBCode.Size = new System.Drawing.Size(90, 20);
            this.txtBSBCode.TabIndex = 9;
            // 
            // lblBSBCode
            // 
            this.lblBSBCode.AutoSize = true;
            this.lblBSBCode.BackColor = System.Drawing.Color.Transparent;
            this.lblBSBCode.Location = new System.Drawing.Point(57, 23);
            this.lblBSBCode.Name = "lblBSBCode";
            this.lblBSBCode.Size = new System.Drawing.Size(71, 13);
            this.lblBSBCode.TabIndex = 8;
            this.lblBSBCode.Text = "BSB Number:";
            // 
            // tpHistory
            // 
            this.tpHistory.Controls.Add(this.dgvAccountHistory);
            this.tpHistory.Location = new System.Drawing.Point(4, 22);
            this.tpHistory.Name = "tpHistory";
            this.tpHistory.Size = new System.Drawing.Size(657, 329);
            this.tpHistory.TabIndex = 3;
            this.tpHistory.Text = "History";
            this.tpHistory.UseVisualStyleBackColor = true;
            // 
            // dgvAccountHistory
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.dgvAccountHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAccountHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvAccountHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAccountHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvAccountHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvAccountHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAccountHistory.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAccountHistory.Location = new System.Drawing.Point(15, 16);
            this.dgvAccountHistory.Name = "dgvAccountHistory";
            this.dgvAccountHistory.RowHeadersVisible = false;
            this.dgvAccountHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccountHistory.Size = new System.Drawing.Size(624, 300);
            this.dgvAccountHistory.TabIndex = 0;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // czRoundedGroupBox1
            // 
            this.czRoundedGroupBox1.BackgroundColor = System.Drawing.Color.White;
            this.czRoundedGroupBox1.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.czRoundedGroupBox1.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.czRoundedGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.czRoundedGroupBox1.BorderWidth = 1F;
            this.czRoundedGroupBox1.Caption = "Account Summary";
            this.czRoundedGroupBox1.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.czRoundedGroupBox1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.czRoundedGroupBox1.CaptionHeight = 25;
            this.czRoundedGroupBox1.CaptionVisible = true;
            this.czRoundedGroupBox1.Controls.Add(this.txtAccountNumber);
            this.czRoundedGroupBox1.Controls.Add(this.txtCurrentBalance);
            this.czRoundedGroupBox1.Controls.Add(this.txtAccountName);
            this.czRoundedGroupBox1.Controls.Add(this.lblAccountNumber);
            this.czRoundedGroupBox1.Controls.Add(this.lblCurrentBalance);
            this.czRoundedGroupBox1.Controls.Add(this.lblAccountName);
            this.czRoundedGroupBox1.CornerRadius = 5;
            this.czRoundedGroupBox1.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.czRoundedGroupBox1.DropShadowThickness = 3;
            this.czRoundedGroupBox1.DropShadowVisible = true;
            this.czRoundedGroupBox1.Location = new System.Drawing.Point(13, 414);
            this.czRoundedGroupBox1.Name = "czRoundedGroupBox1";
            this.czRoundedGroupBox1.Size = new System.Drawing.Size(409, 94);
            this.czRoundedGroupBox1.TabIndex = 96;
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Location = new System.Drawing.Point(108, 58);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(90, 20);
            this.txtAccountNumber.TabIndex = 7;
            // 
            // txtCurrentBalance
            // 
            this.txtCurrentBalance.Location = new System.Drawing.Point(299, 58);
            this.txtCurrentBalance.Name = "txtCurrentBalance";
            this.txtCurrentBalance.Size = new System.Drawing.Size(97, 20);
            this.txtCurrentBalance.TabIndex = 8;
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(108, 32);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(288, 20);
            this.txtAccountName.TabIndex = 9;
            // 
            // lblAccountNumber
            // 
            this.lblAccountNumber.AutoSize = true;
            this.lblAccountNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblAccountNumber.Location = new System.Drawing.Point(10, 61);
            this.lblAccountNumber.Name = "lblAccountNumber";
            this.lblAccountNumber.Size = new System.Drawing.Size(90, 13);
            this.lblAccountNumber.TabIndex = 5;
            this.lblAccountNumber.Text = "Account Number:";
            // 
            // lblCurrentBalance
            // 
            this.lblCurrentBalance.AutoSize = true;
            this.lblCurrentBalance.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentBalance.Location = new System.Drawing.Point(207, 61);
            this.lblCurrentBalance.Name = "lblCurrentBalance";
            this.lblCurrentBalance.Size = new System.Drawing.Size(86, 13);
            this.lblCurrentBalance.TabIndex = 4;
            this.lblCurrentBalance.Text = "Current Balance:";
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.BackColor = System.Drawing.Color.Transparent;
            this.lblAccountName.Location = new System.Drawing.Point(10, 35);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(81, 13);
            this.lblAccountName.TabIndex = 6;
            this.lblAccountName.Text = "Account Name:";
            // 
            // czRoundedGroupBox2
            // 
            this.czRoundedGroupBox2.BackgroundColor = System.Drawing.Color.White;
            this.czRoundedGroupBox2.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.czRoundedGroupBox2.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.czRoundedGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.czRoundedGroupBox2.BorderWidth = 1F;
            this.czRoundedGroupBox2.Caption = "Accounts --> Account";
            this.czRoundedGroupBox2.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.czRoundedGroupBox2.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.czRoundedGroupBox2.CaptionHeight = 25;
            this.czRoundedGroupBox2.CaptionVisible = true;
            this.czRoundedGroupBox2.Controls.Add(this.tc);
            this.czRoundedGroupBox2.CornerRadius = 5;
            this.czRoundedGroupBox2.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.czRoundedGroupBox2.DropShadowThickness = 3;
            this.czRoundedGroupBox2.DropShadowVisible = true;
            this.czRoundedGroupBox2.Location = new System.Drawing.Point(12, 12);
            this.czRoundedGroupBox2.Name = "czRoundedGroupBox2";
            this.czRoundedGroupBox2.Size = new System.Drawing.Size(686, 396);
            this.czRoundedGroupBox2.TabIndex = 97;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Image = global::DacII.Properties.Resources.print_32x32;
            this.btnPrint.Location = new System.Drawing.Point(518, 446);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(56, 56);
            this.btnPrint.TabIndex = 100;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DacII.Properties.Resources.cancel_24x24;
            this.btnClose.Location = new System.Drawing.Point(642, 446);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 56);
            this.btnClose.TabIndex = 99;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRecord
            // 
            this.btnRecord.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRecord.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecord.Image = global::DacII.Properties.Resources.save_32x32;
            this.btnRecord.Location = new System.Drawing.Point(580, 446);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(56, 56);
            this.btnRecord.TabIndex = 98;
            this.btnRecord.Text = "Record";
            this.btnRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRecord.UseVisualStyleBackColor = false;
            this.btnRecord.Click += new System.EventHandler(this.Record);
            // 
            // FrmAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(710, 519);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.czRoundedGroupBox2);
            this.Controls.Add(this.czRoundedGroupBox1);
            this.Name = "FrmAccount";
            this.Text = "Account";
            this.tc.ResumeLayout(false);
            this.tpProfile.ResumeLayout(false);
            this.tpProfile.PerformLayout();
            this.tpDetails.ResumeLayout(false);
            this.tpDetails.PerformLayout();
            this.tpBanking.ResumeLayout(false);
            this.tpBanking.PerformLayout();
            this.tpHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.czRoundedGroupBox1.ResumeLayout(false);
            this.czRoundedGroupBox1.PerformLayout();
            this.czRoundedGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAccountType;
        private System.Windows.Forms.ComboBox cboAccountType;
        private System.Windows.Forms.TabControl tc;
        private System.Windows.Forms.TabPage tpProfile;
        private System.Windows.Forms.TabPage tpDetails;
        private System.Windows.Forms.TabPage tpBanking;
        private System.Windows.Forms.TabPage tpHistory;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label lblLinkedAccount;
        private System.Windows.Forms.VistaButton btnLinkedAccount;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox cboSubAccountType;
        private System.Windows.Forms.Label lblSubAccountType;
        private System.Windows.Forms.Label lblAccountClassification;
        private System.Windows.Forms.ComboBox cboAccountClassification;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ComboBox cboTaxCode;
        private System.Windows.Forms.Label lblTaxCode;
        private System.Windows.Forms.ComboBox cboCashFlowClassification;
        private System.Windows.Forms.Label lblCashFlowClassification;
        private System.Windows.Forms.CZRoundedGroupBox czRoundedGroupBox1;
        private System.Windows.Forms.TextBox txtAccountNumber;
        private System.Windows.Forms.TextBox txtCurrentBalance;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.Label lblAccountNumber;
        private System.Windows.Forms.Label lblCurrentBalance;
        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.CheckBox chkIsTotal;
        private System.Windows.Forms.TextBox txtCompanyTradingName;
        private System.Windows.Forms.Label lblCompanyTradingName;
        private System.Windows.Forms.TextBox txtBankAccountName;
        private System.Windows.Forms.Label lblBankAccountName;
        private System.Windows.Forms.TextBox txtBankAccountNumber;
        private System.Windows.Forms.Label lblBankAccountNumber;
        private System.Windows.Forms.TextBox txtBSBCode;
        private System.Windows.Forms.Label lblBSBCode;
        private System.Windows.Forms.CheckBox chkCreateBankFiles;
        private System.Windows.Forms.Label lblCreateBankFiles;
        private System.Windows.Forms.CheckBox chkIsSelfBalancing;
        private System.Windows.Forms.TextBox txtDirectEntryUserID;
        private System.Windows.Forms.Label lblDirectEntryUserID;
        private System.Windows.Forms.Label lblIsSelfBalancing;
        private System.Windows.Forms.TextBox txtBankCode;
        private System.Windows.Forms.Label lblBankCode;
        private System.Windows.Forms.DataGridView dgvAccountHistory;
        private System.Windows.Forms.CZRoundedGroupBox czRoundedGroupBox2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRecord;
    }
}