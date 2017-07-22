namespace DacII.WinForms.DbSync
{
    partial class FrmBackup
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
            this.tc = new System.Windows.Forms.TabControl();
            this.tpDbBackup = new System.Windows.Forms.TabPage();
            this.tcDbBackupStorage = new System.Windows.Forms.TabControl();
            this.tpMySQL = new System.Windows.Forms.TabPage();
            this.BtnRestoreFromMySQL = new System.Windows.Forms.VistaButton();
            this.BtnRecMySQLBackupConfig = new System.Windows.Forms.VistaButton();
            this.chkBackupByMySQL = new System.Windows.Forms.CheckBox();
            this.txtMySQLPWD = new System.Windows.Forms.TextBox();
            this.txtMySQLUID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMySQLPort = new System.Windows.Forms.TextBox();
            this.txtMySQLDb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMySQLHost = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tpMSSQL = new System.Windows.Forms.TabPage();
            this.BtnRestoreFromMSSQL = new System.Windows.Forms.VistaButton();
            this.chkBackupByMSSQL = new System.Windows.Forms.CheckBox();
            this.txtMSSQLPWD = new System.Windows.Forms.TextBox();
            this.BtnRecMSSQLBackupConfig = new System.Windows.Forms.VistaButton();
            this.txtMSSQLUID = new System.Windows.Forms.TextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMSSQLPort = new System.Windows.Forms.TextBox();
            this.txtMSSQLDb = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMSSQLHost = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tpCloudBackup = new System.Windows.Forms.TabPage();
            this.BtnRestoreFromCloud = new System.Windows.Forms.VistaButton();
            this.btnRecCloudConfig = new System.Windows.Forms.VistaButton();
            this.txtCloudPWD = new System.Windows.Forms.TextBox();
            this.txtCloudUID = new System.Windows.Forms.TextBox();
            this.lblCloudPWD = new System.Windows.Forms.Label();
            this.lblCloudUID = new System.Windows.Forms.Label();
            this.txtCloudUrl = new System.Windows.Forms.TextBox();
            this.lblCloudUrl = new System.Windows.Forms.Label();
            this.chkBackupByCloud = new System.Windows.Forms.CheckBox();
            this.gpDbBackupWhen = new System.Windows.Forms.CZRoundedGroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.BtnSaveDbBackupSchedule = new System.Windows.Forms.VistaButton();
            this.cboDbBackupMinute = new System.Windows.Forms.ComboBox();
            this.cboDbBackupHour = new System.Windows.Forms.ComboBox();
            this.cboDbBackupSchedule = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEnableDbBackup = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnDbBackupNow = new System.Windows.Forms.VistaButton();
            this.gpBackupContents = new System.Windows.Forms.CZRoundedGroupBox();
            this.chkBackupAuthentication = new System.Windows.Forms.CheckBox();
            this.chkBackupAuthorization = new System.Windows.Forms.CheckBox();
            this.chkBackupItemAddOn = new System.Windows.Forms.CheckBox();
            this.gbFilter = new System.Windows.Forms.CZRoundedGroupBox();
            this.btnClose2 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.VistaButton();
            this.tc.SuspendLayout();
            this.tpDbBackup.SuspendLayout();
            this.tcDbBackupStorage.SuspendLayout();
            this.tpMySQL.SuspendLayout();
            this.tpMSSQL.SuspendLayout();
            this.tpCloudBackup.SuspendLayout();
            this.gpDbBackupWhen.SuspendLayout();
            this.gpBackupContents.SuspendLayout();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc
            // 
            this.tc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tc.Controls.Add(this.tpDbBackup);
            this.tc.Controls.Add(this.tpCloudBackup);
            this.tc.HotTrack = true;
            this.tc.Location = new System.Drawing.Point(6, 31);
            this.tc.Name = "tc";
            this.tc.SelectedIndex = 0;
            this.tc.Size = new System.Drawing.Size(421, 291);
            this.tc.TabIndex = 0;
            // 
            // tpDbBackup
            // 
            this.tpDbBackup.Controls.Add(this.tcDbBackupStorage);
            this.tpDbBackup.Location = new System.Drawing.Point(4, 22);
            this.tpDbBackup.Name = "tpDbBackup";
            this.tpDbBackup.Padding = new System.Windows.Forms.Padding(3);
            this.tpDbBackup.Size = new System.Drawing.Size(413, 265);
            this.tpDbBackup.TabIndex = 0;
            this.tpDbBackup.Text = "Database Backup";
            this.tpDbBackup.UseVisualStyleBackColor = true;
            // 
            // tcDbBackupStorage
            // 
            this.tcDbBackupStorage.Controls.Add(this.tpMySQL);
            this.tcDbBackupStorage.Controls.Add(this.tpMSSQL);
            this.tcDbBackupStorage.HotTrack = true;
            this.tcDbBackupStorage.Location = new System.Drawing.Point(6, 6);
            this.tcDbBackupStorage.Name = "tcDbBackupStorage";
            this.tcDbBackupStorage.SelectedIndex = 0;
            this.tcDbBackupStorage.Size = new System.Drawing.Size(401, 249);
            this.tcDbBackupStorage.TabIndex = 7;
            // 
            // tpMySQL
            // 
            this.tpMySQL.Controls.Add(this.BtnRestoreFromMySQL);
            this.tpMySQL.Controls.Add(this.BtnRecMySQLBackupConfig);
            this.tpMySQL.Controls.Add(this.chkBackupByMySQL);
            this.tpMySQL.Controls.Add(this.txtMySQLPWD);
            this.tpMySQL.Controls.Add(this.txtMySQLUID);
            this.tpMySQL.Controls.Add(this.label6);
            this.tpMySQL.Controls.Add(this.label7);
            this.tpMySQL.Controls.Add(this.txtMySQLPort);
            this.tpMySQL.Controls.Add(this.txtMySQLDb);
            this.tpMySQL.Controls.Add(this.label8);
            this.tpMySQL.Controls.Add(this.label9);
            this.tpMySQL.Controls.Add(this.txtMySQLHost);
            this.tpMySQL.Controls.Add(this.label10);
            this.tpMySQL.Location = new System.Drawing.Point(4, 22);
            this.tpMySQL.Name = "tpMySQL";
            this.tpMySQL.Padding = new System.Windows.Forms.Padding(3);
            this.tpMySQL.Size = new System.Drawing.Size(393, 223);
            this.tpMySQL.TabIndex = 0;
            this.tpMySQL.Text = "MySQL";
            this.tpMySQL.UseVisualStyleBackColor = true;
            // 
            // BtnRestoreFromMySQL
            // 
            this.BtnRestoreFromMySQL.BackColor = System.Drawing.Color.Transparent;
            this.BtnRestoreFromMySQL.BaseColor = System.Drawing.Color.SteelBlue;
            this.BtnRestoreFromMySQL.ButtonText = "Restore";
            this.BtnRestoreFromMySQL.Location = new System.Drawing.Point(260, 175);
            this.BtnRestoreFromMySQL.Name = "BtnRestoreFromMySQL";
            this.BtnRestoreFromMySQL.Size = new System.Drawing.Size(100, 32);
            this.BtnRestoreFromMySQL.TabIndex = 39;
            this.BtnRestoreFromMySQL.Click += new System.EventHandler(this.TriggerCmd_RestoreFromMySQL);
            // 
            // BtnRecMySQLBackupConfig
            // 
            this.BtnRecMySQLBackupConfig.BackColor = System.Drawing.Color.Transparent;
            this.BtnRecMySQLBackupConfig.BaseColor = System.Drawing.Color.SteelBlue;
            this.BtnRecMySQLBackupConfig.ButtonText = "Save Configuration";
            this.BtnRecMySQLBackupConfig.Location = new System.Drawing.Point(121, 175);
            this.BtnRecMySQLBackupConfig.Name = "BtnRecMySQLBackupConfig";
            this.BtnRecMySQLBackupConfig.Size = new System.Drawing.Size(133, 32);
            this.BtnRecMySQLBackupConfig.TabIndex = 39;
            this.BtnRecMySQLBackupConfig.Click += new System.EventHandler(this.TriggerCmd_RecMySQLBackupConfig);
            // 
            // chkBackupByMySQL
            // 
            this.chkBackupByMySQL.AutoSize = true;
            this.chkBackupByMySQL.Location = new System.Drawing.Point(14, 128);
            this.chkBackupByMySQL.Name = "chkBackupByMySQL";
            this.chkBackupByMySQL.Size = new System.Drawing.Size(197, 17);
            this.chkBackupByMySQL.TabIndex = 38;
            this.chkBackupByMySQL.Text = "Use this database server for backup";
            this.chkBackupByMySQL.UseVisualStyleBackColor = true;
            // 
            // txtMySQLPWD
            // 
            this.txtMySQLPWD.Location = new System.Drawing.Point(91, 94);
            this.txtMySQLPWD.Name = "txtMySQLPWD";
            this.txtMySQLPWD.PasswordChar = '*';
            this.txtMySQLPWD.Size = new System.Drawing.Size(269, 20);
            this.txtMySQLPWD.TabIndex = 21;
            this.txtMySQLPWD.Text = "chen0469";
            // 
            // txtMySQLUID
            // 
            this.txtMySQLUID.Location = new System.Drawing.Point(91, 68);
            this.txtMySQLUID.Name = "txtMySQLUID";
            this.txtMySQLUID.Size = new System.Drawing.Size(269, 20);
            this.txtMySQLUID.TabIndex = 20;
            this.txtMySQLUID.Text = "root";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.ImageIndex = 0;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(10, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "MySQL PW:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.ImageIndex = 0;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(11, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "MySQL UID:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMySQLPort
            // 
            this.txtMySQLPort.Location = new System.Drawing.Point(317, 42);
            this.txtMySQLPort.Name = "txtMySQLPort";
            this.txtMySQLPort.Size = new System.Drawing.Size(42, 20);
            this.txtMySQLPort.TabIndex = 16;
            this.txtMySQLPort.Text = "3306";
            // 
            // txtMySQLDb
            // 
            this.txtMySQLDb.Location = new System.Drawing.Point(91, 42);
            this.txtMySQLDb.Name = "txtMySQLDb";
            this.txtMySQLDb.Size = new System.Drawing.Size(178, 20);
            this.txtMySQLDb.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.ImageIndex = 0;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(275, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Port:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.ImageIndex = 0;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(10, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 16);
            this.label9.TabIndex = 11;
            this.label9.Text = "Database:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMySQLHost
            // 
            this.txtMySQLHost.Location = new System.Drawing.Point(91, 16);
            this.txtMySQLHost.Name = "txtMySQLHost";
            this.txtMySQLHost.Size = new System.Drawing.Size(178, 20);
            this.txtMySQLHost.TabIndex = 15;
            this.txtMySQLHost.Text = "localhost";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.ImageIndex = 0;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(11, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 16);
            this.label10.TabIndex = 13;
            this.label10.Text = "Host:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpMSSQL
            // 
            this.tpMSSQL.Controls.Add(this.BtnRestoreFromMSSQL);
            this.tpMSSQL.Controls.Add(this.chkBackupByMSSQL);
            this.tpMSSQL.Controls.Add(this.txtMSSQLPWD);
            this.tpMSSQL.Controls.Add(this.BtnRecMSSQLBackupConfig);
            this.tpMSSQL.Controls.Add(this.txtMSSQLUID);
            this.tpMSSQL.Controls.Add(this.lblKey);
            this.tpMSSQL.Controls.Add(this.label5);
            this.tpMSSQL.Controls.Add(this.txtMSSQLPort);
            this.tpMSSQL.Controls.Add(this.txtMSSQLDb);
            this.tpMSSQL.Controls.Add(this.label11);
            this.tpMSSQL.Controls.Add(this.label13);
            this.tpMSSQL.Controls.Add(this.txtMSSQLHost);
            this.tpMSSQL.Controls.Add(this.label14);
            this.tpMSSQL.Location = new System.Drawing.Point(4, 22);
            this.tpMSSQL.Name = "tpMSSQL";
            this.tpMSSQL.Padding = new System.Windows.Forms.Padding(3);
            this.tpMSSQL.Size = new System.Drawing.Size(393, 223);
            this.tpMSSQL.TabIndex = 1;
            this.tpMSSQL.Text = "MSSQL";
            this.tpMSSQL.UseVisualStyleBackColor = true;
            // 
            // BtnRestoreFromMSSQL
            // 
            this.BtnRestoreFromMSSQL.BackColor = System.Drawing.Color.Transparent;
            this.BtnRestoreFromMSSQL.ButtonColor = System.Drawing.Color.SteelBlue;
            this.BtnRestoreFromMSSQL.ButtonText = "Restore";
            this.BtnRestoreFromMSSQL.Location = new System.Drawing.Point(287, 185);
            this.BtnRestoreFromMSSQL.Name = "BtnRestoreFromMSSQL";
            this.BtnRestoreFromMSSQL.Size = new System.Drawing.Size(100, 32);
            this.BtnRestoreFromMSSQL.TabIndex = 40;
            this.BtnRestoreFromMSSQL.Click += new System.EventHandler(this.TriggerCmd_RestoreFromMSSQL);
            // 
            // chkBackupByMSSQL
            // 
            this.chkBackupByMSSQL.AutoSize = true;
            this.chkBackupByMSSQL.Location = new System.Drawing.Point(12, 124);
            this.chkBackupByMSSQL.Name = "chkBackupByMSSQL";
            this.chkBackupByMSSQL.Size = new System.Drawing.Size(197, 17);
            this.chkBackupByMSSQL.TabIndex = 37;
            this.chkBackupByMSSQL.Text = "Use this database server for backup";
            this.chkBackupByMSSQL.UseVisualStyleBackColor = true;
            // 
            // txtMSSQLPWD
            // 
            this.txtMSSQLPWD.Location = new System.Drawing.Point(90, 94);
            this.txtMSSQLPWD.Name = "txtMSSQLPWD";
            this.txtMSSQLPWD.Size = new System.Drawing.Size(281, 20);
            this.txtMSSQLPWD.TabIndex = 35;
            // 
            // BtnRecMSSQLBackupConfig
            // 
            this.BtnRecMSSQLBackupConfig.BackColor = System.Drawing.Color.Transparent;
            this.BtnRecMSSQLBackupConfig.ButtonColor = System.Drawing.Color.SteelBlue;
            this.BtnRecMSSQLBackupConfig.ButtonText = "Save Configuration";
            this.BtnRecMSSQLBackupConfig.Location = new System.Drawing.Point(162, 185);
            this.BtnRecMSSQLBackupConfig.Name = "BtnRecMSSQLBackupConfig";
            this.BtnRecMSSQLBackupConfig.Size = new System.Drawing.Size(119, 32);
            this.BtnRecMSSQLBackupConfig.TabIndex = 5;
            this.BtnRecMSSQLBackupConfig.Click += new System.EventHandler(this.TriggerCmd_RecMSSQLBackupConfig);
            // 
            // txtMSSQLUID
            // 
            this.txtMSSQLUID.Location = new System.Drawing.Point(90, 67);
            this.txtMSSQLUID.Name = "txtMSSQLUID";
            this.txtMSSQLUID.Size = new System.Drawing.Size(281, 20);
            this.txtMSSQLUID.TabIndex = 36;
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lblKey.ForeColor = System.Drawing.Color.Black;
            this.lblKey.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKey.ImageIndex = 0;
            this.lblKey.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblKey.Location = new System.Drawing.Point(9, 95);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(64, 16);
            this.lblKey.TabIndex = 31;
            this.lblKey.Text = "SQL PW:";
            this.lblKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.ImageIndex = 0;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(9, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 32;
            this.label5.Text = "SQL UID:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMSSQLPort
            // 
            this.txtMSSQLPort.Location = new System.Drawing.Point(329, 41);
            this.txtMSSQLPort.Name = "txtMSSQLPort";
            this.txtMSSQLPort.Size = new System.Drawing.Size(42, 20);
            this.txtMSSQLPort.TabIndex = 21;
            this.txtMSSQLPort.Text = "3306";
            // 
            // txtMSSQLDb
            // 
            this.txtMSSQLDb.Location = new System.Drawing.Point(90, 41);
            this.txtMSSQLDb.Name = "txtMSSQLDb";
            this.txtMSSQLDb.Size = new System.Drawing.Size(191, 20);
            this.txtMSSQLDb.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.ImageIndex = 0;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(287, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 16);
            this.label11.TabIndex = 16;
            this.label11.Text = "Port:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.ImageIndex = 0;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(9, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 16);
            this.label13.TabIndex = 15;
            this.label13.Text = "Database:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMSSQLHost
            // 
            this.txtMSSQLHost.Location = new System.Drawing.Point(90, 16);
            this.txtMSSQLHost.Name = "txtMSSQLHost";
            this.txtMSSQLHost.Size = new System.Drawing.Size(191, 20);
            this.txtMSSQLHost.TabIndex = 22;
            this.txtMSSQLHost.Text = "localhost";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label14.ImageIndex = 0;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(11, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 16);
            this.label14.TabIndex = 17;
            this.label14.Text = "Host:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpCloudBackup
            // 
            this.tpCloudBackup.Controls.Add(this.BtnRestoreFromCloud);
            this.tpCloudBackup.Controls.Add(this.btnRecCloudConfig);
            this.tpCloudBackup.Controls.Add(this.txtCloudPWD);
            this.tpCloudBackup.Controls.Add(this.txtCloudUID);
            this.tpCloudBackup.Controls.Add(this.lblCloudPWD);
            this.tpCloudBackup.Controls.Add(this.lblCloudUID);
            this.tpCloudBackup.Controls.Add(this.txtCloudUrl);
            this.tpCloudBackup.Controls.Add(this.lblCloudUrl);
            this.tpCloudBackup.Controls.Add(this.chkBackupByCloud);
            this.tpCloudBackup.Location = new System.Drawing.Point(4, 22);
            this.tpCloudBackup.Name = "tpCloudBackup";
            this.tpCloudBackup.Padding = new System.Windows.Forms.Padding(3);
            this.tpCloudBackup.Size = new System.Drawing.Size(413, 265);
            this.tpCloudBackup.TabIndex = 1;
            this.tpCloudBackup.Text = "Cloud Backup";
            this.tpCloudBackup.UseVisualStyleBackColor = true;
            // 
            // BtnRestoreFromCloud
            // 
            this.BtnRestoreFromCloud.BackColor = System.Drawing.Color.Transparent;
            this.BtnRestoreFromCloud.ButtonColor = System.Drawing.Color.SteelBlue;
            this.BtnRestoreFromCloud.ButtonText = "Restore";
            this.BtnRestoreFromCloud.Location = new System.Drawing.Point(291, 227);
            this.BtnRestoreFromCloud.Name = "BtnRestoreFromCloud";
            this.BtnRestoreFromCloud.Size = new System.Drawing.Size(100, 32);
            this.BtnRestoreFromCloud.TabIndex = 40;
            this.BtnRestoreFromCloud.Click += new System.EventHandler(this.TriggerCmd_RestoreFromCloud);
            // 
            // btnRecCloudConfig
            // 
            this.btnRecCloudConfig.BackColor = System.Drawing.Color.Transparent;
            this.btnRecCloudConfig.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnRecCloudConfig.ButtonText = "Save Configuration";
            this.btnRecCloudConfig.Location = new System.Drawing.Point(161, 227);
            this.btnRecCloudConfig.Name = "btnRecCloudConfig";
            this.btnRecCloudConfig.Size = new System.Drawing.Size(124, 32);
            this.btnRecCloudConfig.TabIndex = 26;
            this.btnRecCloudConfig.Click += new System.EventHandler(this.TriggerCmd_RecCloudBackupConfig);
            // 
            // txtCloudPWD
            // 
            this.txtCloudPWD.Location = new System.Drawing.Point(95, 69);
            this.txtCloudPWD.Name = "txtCloudPWD";
            this.txtCloudPWD.PasswordChar = '*';
            this.txtCloudPWD.Size = new System.Drawing.Size(242, 20);
            this.txtCloudPWD.TabIndex = 25;
            this.txtCloudPWD.Text = "chen0469";
            // 
            // txtCloudUID
            // 
            this.txtCloudUID.Location = new System.Drawing.Point(95, 43);
            this.txtCloudUID.Name = "txtCloudUID";
            this.txtCloudUID.Size = new System.Drawing.Size(242, 20);
            this.txtCloudUID.TabIndex = 24;
            this.txtCloudUID.Text = "root";
            // 
            // lblCloudPWD
            // 
            this.lblCloudPWD.AutoSize = true;
            this.lblCloudPWD.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lblCloudPWD.ForeColor = System.Drawing.Color.Black;
            this.lblCloudPWD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCloudPWD.ImageIndex = 0;
            this.lblCloudPWD.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCloudPWD.Location = new System.Drawing.Point(7, 71);
            this.lblCloudPWD.Name = "lblCloudPWD";
            this.lblCloudPWD.Size = new System.Drawing.Size(80, 16);
            this.lblCloudPWD.TabIndex = 22;
            this.lblCloudPWD.Text = "Cloud PWD:";
            this.lblCloudPWD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCloudUID
            // 
            this.lblCloudUID.AutoSize = true;
            this.lblCloudUID.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lblCloudUID.ForeColor = System.Drawing.Color.Black;
            this.lblCloudUID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCloudUID.ImageIndex = 0;
            this.lblCloudUID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCloudUID.Location = new System.Drawing.Point(8, 44);
            this.lblCloudUID.Name = "lblCloudUID";
            this.lblCloudUID.Size = new System.Drawing.Size(70, 16);
            this.lblCloudUID.TabIndex = 23;
            this.lblCloudUID.Text = "Cloud UID:";
            this.lblCloudUID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCloudUrl
            // 
            this.txtCloudUrl.Location = new System.Drawing.Point(95, 18);
            this.txtCloudUrl.Name = "txtCloudUrl";
            this.txtCloudUrl.Size = new System.Drawing.Size(242, 20);
            this.txtCloudUrl.TabIndex = 17;
            this.txtCloudUrl.Text = "localhost";
            // 
            // lblCloudUrl
            // 
            this.lblCloudUrl.AutoSize = true;
            this.lblCloudUrl.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lblCloudUrl.ForeColor = System.Drawing.Color.Black;
            this.lblCloudUrl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCloudUrl.ImageIndex = 0;
            this.lblCloudUrl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCloudUrl.Location = new System.Drawing.Point(8, 18);
            this.lblCloudUrl.Name = "lblCloudUrl";
            this.lblCloudUrl.Size = new System.Drawing.Size(65, 16);
            this.lblCloudUrl.TabIndex = 16;
            this.lblCloudUrl.Text = "Cloud Url:";
            this.lblCloudUrl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkBackupByCloud
            // 
            this.chkBackupByCloud.AutoSize = true;
            this.chkBackupByCloud.Location = new System.Drawing.Point(8, 178);
            this.chkBackupByCloud.Name = "chkBackupByCloud";
            this.chkBackupByCloud.Size = new System.Drawing.Size(129, 17);
            this.chkBackupByCloud.TabIndex = 1;
            this.chkBackupByCloud.Text = "Enable Cloud Backup";
            this.chkBackupByCloud.UseVisualStyleBackColor = true;
            // 
            // gpDbBackupWhen
            // 
            this.gpDbBackupWhen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gpDbBackupWhen.BackgroundColor = System.Drawing.Color.White;
            this.gpDbBackupWhen.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gpDbBackupWhen.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gpDbBackupWhen.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gpDbBackupWhen.BorderWidth = 1F;
            this.gpDbBackupWhen.Caption = "Backup Schedule";
            this.gpDbBackupWhen.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gpDbBackupWhen.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gpDbBackupWhen.CaptionHeight = 25;
            this.gpDbBackupWhen.CaptionVisible = true;
            this.gpDbBackupWhen.Controls.Add(this.label12);
            this.gpDbBackupWhen.Controls.Add(this.BtnSaveDbBackupSchedule);
            this.gpDbBackupWhen.Controls.Add(this.cboDbBackupMinute);
            this.gpDbBackupWhen.Controls.Add(this.cboDbBackupHour);
            this.gpDbBackupWhen.Controls.Add(this.cboDbBackupSchedule);
            this.gpDbBackupWhen.Controls.Add(this.label1);
            this.gpDbBackupWhen.Controls.Add(this.chkEnableDbBackup);
            this.gpDbBackupWhen.Controls.Add(this.label2);
            this.gpDbBackupWhen.CornerRadius = 5;
            this.gpDbBackupWhen.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gpDbBackupWhen.DropShadowThickness = 3;
            this.gpDbBackupWhen.DropShadowVisible = false;
            this.gpDbBackupWhen.Location = new System.Drawing.Point(435, 188);
            this.gpDbBackupWhen.Name = "gpDbBackupWhen";
            this.gpDbBackupWhen.Size = new System.Drawing.Size(290, 130);
            this.gpDbBackupWhen.TabIndex = 6;
            this.gpDbBackupWhen.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(226, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(10, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = ":";
            // 
            // BtnSaveDbBackupSchedule
            // 
            this.BtnSaveDbBackupSchedule.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnSaveDbBackupSchedule.ButtonColor = System.Drawing.Color.SteelBlue;
            this.BtnSaveDbBackupSchedule.ButtonText = "Save Schedule";
            this.BtnSaveDbBackupSchedule.Location = new System.Drawing.Point(130, 88);
            this.BtnSaveDbBackupSchedule.Name = "BtnSaveDbBackupSchedule";
            this.BtnSaveDbBackupSchedule.Size = new System.Drawing.Size(148, 32);
            this.BtnSaveDbBackupSchedule.TabIndex = 39;
            this.BtnSaveDbBackupSchedule.Click += new System.EventHandler(this.TriggerCmd_SaveDbBackupScheduleConfig);
            // 
            // cboDbBackupMinute
            // 
            this.cboDbBackupMinute.FormattingEnabled = true;
            this.cboDbBackupMinute.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.cboDbBackupMinute.Location = new System.Drawing.Point(242, 33);
            this.cboDbBackupMinute.Name = "cboDbBackupMinute";
            this.cboDbBackupMinute.Size = new System.Drawing.Size(36, 21);
            this.cboDbBackupMinute.TabIndex = 5;
            this.cboDbBackupMinute.Text = "0";
            // 
            // cboDbBackupHour
            // 
            this.cboDbBackupHour.FormattingEnabled = true;
            this.cboDbBackupHour.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cboDbBackupHour.Location = new System.Drawing.Point(187, 33);
            this.cboDbBackupHour.Name = "cboDbBackupHour";
            this.cboDbBackupHour.Size = new System.Drawing.Size(33, 21);
            this.cboDbBackupHour.TabIndex = 5;
            this.cboDbBackupHour.Text = "3";
            // 
            // cboDbBackupSchedule
            // 
            this.cboDbBackupSchedule.FormattingEnabled = true;
            this.cboDbBackupSchedule.Items.AddRange(new object[] {
            "Every Day",
            "Every Monday",
            "Every Tuesday",
            "Every Wednesday",
            "Every Thursday",
            "Every Friday",
            "Every Saturday",
            "Every Sunday"});
            this.cboDbBackupSchedule.Location = new System.Drawing.Point(61, 33);
            this.cboDbBackupSchedule.Name = "cboDbBackupSchedule";
            this.cboDbBackupSchedule.Size = new System.Drawing.Size(92, 21);
            this.cboDbBackupSchedule.TabIndex = 1;
            this.cboDbBackupSchedule.Text = "Every Day";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(8, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Backup ";
            // 
            // chkEnableDbBackup
            // 
            this.chkEnableDbBackup.AutoSize = true;
            this.chkEnableDbBackup.BackColor = System.Drawing.Color.Transparent;
            this.chkEnableDbBackup.Location = new System.Drawing.Point(11, 67);
            this.chkEnableDbBackup.Name = "chkEnableDbBackup";
            this.chkEnableDbBackup.Size = new System.Drawing.Size(88, 17);
            this.chkEnableDbBackup.TabIndex = 0;
            this.chkEnableDbBackup.Text = "Auto Backup";
            this.chkEnableDbBackup.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(165, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "at";
            // 
            // BtnDbBackupNow
            // 
            this.BtnDbBackupNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDbBackupNow.BackColor = System.Drawing.Color.Transparent;
            this.BtnDbBackupNow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnDbBackupNow.BaseColor = System.Drawing.Color.SteelBlue;
            this.BtnDbBackupNow.ButtonText = "Backup Now";
            this.BtnDbBackupNow.Location = new System.Drawing.Point(551, 324);
            this.BtnDbBackupNow.Name = "BtnDbBackupNow";
            this.BtnDbBackupNow.Size = new System.Drawing.Size(96, 32);
            this.BtnDbBackupNow.TabIndex = 5;
            this.BtnDbBackupNow.Click += new System.EventHandler(this.TriggerCmd_DbBackupNow);
            // 
            // gpBackupContents
            // 
            this.gpBackupContents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gpBackupContents.BackgroundColor = System.Drawing.Color.White;
            this.gpBackupContents.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gpBackupContents.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gpBackupContents.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gpBackupContents.BorderWidth = 1F;
            this.gpBackupContents.Caption = "Backup Options";
            this.gpBackupContents.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gpBackupContents.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gpBackupContents.CaptionHeight = 25;
            this.gpBackupContents.CaptionVisible = true;
            this.gpBackupContents.Controls.Add(this.chkBackupAuthentication);
            this.gpBackupContents.Controls.Add(this.chkBackupAuthorization);
            this.gpBackupContents.Controls.Add(this.chkBackupItemAddOn);
            this.gpBackupContents.CornerRadius = 5;
            this.gpBackupContents.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gpBackupContents.DropShadowThickness = 3;
            this.gpBackupContents.DropShadowVisible = false;
            this.gpBackupContents.Location = new System.Drawing.Point(435, 53);
            this.gpBackupContents.Name = "gpBackupContents";
            this.gpBackupContents.Size = new System.Drawing.Size(290, 129);
            this.gpBackupContents.TabIndex = 8;
            this.gpBackupContents.TabStop = false;
            // 
            // chkBackupAuthentication
            // 
            this.chkBackupAuthentication.AutoSize = true;
            this.chkBackupAuthentication.BackColor = System.Drawing.Color.Transparent;
            this.chkBackupAuthentication.Location = new System.Drawing.Point(10, 80);
            this.chkBackupAuthentication.Name = "chkBackupAuthentication";
            this.chkBackupAuthentication.Size = new System.Drawing.Size(176, 17);
            this.chkBackupAuthentication.TabIndex = 0;
            this.chkBackupAuthentication.Text = "Backup/Restore Authentication";
            this.chkBackupAuthentication.UseVisualStyleBackColor = false;
            this.chkBackupAuthentication.CheckedChanged += new System.EventHandler(this.chkBackupAuthentication_CheckedChanged);
            // 
            // chkBackupAuthorization
            // 
            this.chkBackupAuthorization.AutoSize = true;
            this.chkBackupAuthorization.BackColor = System.Drawing.Color.Transparent;
            this.chkBackupAuthorization.Location = new System.Drawing.Point(10, 57);
            this.chkBackupAuthorization.Name = "chkBackupAuthorization";
            this.chkBackupAuthorization.Size = new System.Drawing.Size(169, 17);
            this.chkBackupAuthorization.TabIndex = 0;
            this.chkBackupAuthorization.Text = "Backup/Restore Authorization";
            this.chkBackupAuthorization.UseVisualStyleBackColor = false;
            this.chkBackupAuthorization.CheckedChanged += new System.EventHandler(this.chkBackupAuthorization_CheckedChanged);
            // 
            // chkBackupItemAddOn
            // 
            this.chkBackupItemAddOn.AutoSize = true;
            this.chkBackupItemAddOn.BackColor = System.Drawing.Color.Transparent;
            this.chkBackupItemAddOn.Location = new System.Drawing.Point(11, 34);
            this.chkBackupItemAddOn.Name = "chkBackupItemAddOn";
            this.chkBackupItemAddOn.Size = new System.Drawing.Size(164, 17);
            this.chkBackupItemAddOn.TabIndex = 0;
            this.chkBackupItemAddOn.Text = "Backup/Restore Item AddOn";
            this.chkBackupItemAddOn.UseVisualStyleBackColor = false;
            this.chkBackupItemAddOn.CheckedChanged += new System.EventHandler(this.chkBackupItemAddOn_CheckedChanged);
            // 
            // gbFilter
            // 
            this.gbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFilter.BackgroundColor = System.Drawing.Color.White;
            this.gbFilter.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbFilter.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbFilter.BorderWidth = 1F;
            this.gbFilter.Caption = "Data Backup Synchronization Scheduler";
            this.gbFilter.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbFilter.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbFilter.CaptionHeight = 25;
            this.gbFilter.CaptionVisible = true;
            this.gbFilter.Controls.Add(this.BtnDbBackupNow);
            this.gbFilter.Controls.Add(this.gpDbBackupWhen);
            this.gbFilter.Controls.Add(this.btnClose2);
            this.gbFilter.Controls.Add(this.btnClose);
            this.gbFilter.Controls.Add(this.gpBackupContents);
            this.gbFilter.Controls.Add(this.tc);
            this.gbFilter.CornerRadius = 5;
            this.gbFilter.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbFilter.DropShadowThickness = 3;
            this.gbFilter.DropShadowVisible = true;
            this.gbFilter.Location = new System.Drawing.Point(5, 4);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(736, 370);
            this.gbFilter.TabIndex = 10;
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
            this.btnClose2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose2.Location = new System.Drawing.Point(709, 4);
            this.btnClose2.Name = "btnClose2";
            this.btnClose2.Size = new System.Drawing.Size(16, 16);
            this.btnClose2.TabIndex = 91;
            this.btnClose2.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.BaseColor = System.Drawing.Color.SteelBlue;
            this.btnClose.ButtonText = "Close";
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(653, 324);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 32);
            this.btnClose.TabIndex = 91;
            // 
            // FrmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(748, 386);
            this.Controls.Add(this.gbFilter);
            this.Name = "FrmBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Data Backup Sync Scheduler";
            this.tc.ResumeLayout(false);
            this.tpDbBackup.ResumeLayout(false);
            this.tcDbBackupStorage.ResumeLayout(false);
            this.tpMySQL.ResumeLayout(false);
            this.tpMySQL.PerformLayout();
            this.tpMSSQL.ResumeLayout(false);
            this.tpMSSQL.PerformLayout();
            this.tpCloudBackup.ResumeLayout(false);
            this.tpCloudBackup.PerformLayout();
            this.gpDbBackupWhen.ResumeLayout(false);
            this.gpDbBackupWhen.PerformLayout();
            this.gpBackupContents.ResumeLayout(false);
            this.gpBackupContents.PerformLayout();
            this.gbFilter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tc;
        private System.Windows.Forms.TabPage tpDbBackup;
        private System.Windows.Forms.TabPage tpCloudBackup;
        private System.Windows.Forms.CheckBox chkEnableDbBackup;
        private System.Windows.Forms.CheckBox chkBackupByCloud;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDbBackupSchedule;
        private System.Windows.Forms.VistaButton BtnDbBackupNow;
        private System.Windows.Forms.CZRoundedGroupBox gpDbBackupWhen;
        private System.Windows.Forms.CZRoundedGroupBox gpBackupContents;
        private System.Windows.Forms.CheckBox chkBackupItemAddOn;
        private System.Windows.Forms.CheckBox chkBackupAuthorization;
        private System.Windows.Forms.CheckBox chkBackupAuthentication;
        private System.Windows.Forms.TabControl tcDbBackupStorage;
        private System.Windows.Forms.TabPage tpMySQL;
        private System.Windows.Forms.TabPage tpMSSQL;
        private System.Windows.Forms.TextBox txtMSSQLPWD;
        private System.Windows.Forms.TextBox txtMSSQLUID;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMSSQLPort;
        private System.Windows.Forms.TextBox txtMSSQLDb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMSSQLHost;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkBackupByMSSQL;
        private System.Windows.Forms.TextBox txtMySQLPWD;
        private System.Windows.Forms.TextBox txtMySQLUID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMySQLPort;
        private System.Windows.Forms.TextBox txtMySQLDb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMySQLHost;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkBackupByMySQL;
        private System.Windows.Forms.VistaButton BtnRecMySQLBackupConfig;
        private System.Windows.Forms.VistaButton BtnRecMSSQLBackupConfig;
        private System.Windows.Forms.VistaButton BtnRestoreFromMySQL;
        private System.Windows.Forms.VistaButton BtnRestoreFromMSSQL;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboDbBackupHour;
        private System.Windows.Forms.ComboBox cboDbBackupMinute;
        private System.Windows.Forms.VistaButton BtnSaveDbBackupSchedule;
        private System.Windows.Forms.TextBox txtCloudUrl;
        private System.Windows.Forms.Label lblCloudUrl;
        private System.Windows.Forms.TextBox txtCloudPWD;
        private System.Windows.Forms.TextBox txtCloudUID;
        private System.Windows.Forms.Label lblCloudPWD;
        private System.Windows.Forms.Label lblCloudUID;
        private System.Windows.Forms.VistaButton btnRecCloudConfig;
        private System.Windows.Forms.VistaButton BtnRestoreFromCloud;
        private System.Windows.Forms.CZRoundedGroupBox gbFilter;
        private System.Windows.Forms.VistaButton btnClose;
        private System.Windows.Forms.Button btnClose2;
    }
}