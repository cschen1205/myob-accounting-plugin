using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace DacII.WinForms.DbSync
{
    using DacII.Presenters;
    using Accounting.Bll;
    using Accounting.Bll.Im;
    using Accounting.Db;
    using Accounting.Db.SqlClient;
    using Accounting.Db.MySQL;
    using Accounting.Core.Inventory;
    using Accounting.Core.Definitions;
    using SwissArmyKnife.Net;

    public partial class FrmBackup : BaseView
    {
        public FrmBackup(ApplicationPresenter ap)
            : base(ap)
        {
            InitializeComponent();

            BindViews();
            RegisterEventHandlers();
        }

        protected override void LoadView()
        {
            Accountant _obj = mApplicationController.mAccountant;

            txtMySQLUID.Text = _obj.ConfigMgr.GetParamValue("BACKUP_MySQLUID");
            txtMySQLPWD.Text = _obj.ConfigMgr.GetParamValue("BACKUP_MySQLPWD");
            txtMySQLDb.Text = _obj.ConfigMgr.GetParamValue("BACKUP_MySQLDB");
            txtMySQLHost.Text = _obj.ConfigMgr.GetParamValue("BACKUP_MySQLHOST");
            txtMySQLPort.Text = _obj.ConfigMgr.GetParamValue("BACKUP_MySQLPORT");
            this.chkBackupByMySQL.Checked = _obj.ConfigMgr.GetParamValue("BACKUP_MySQLUSE").Equals("1");

            txtMSSQLUID.Text = _obj.ConfigMgr.GetParamValue("BACKUP_MSSQLUID");
            txtMSSQLPWD.Text = _obj.ConfigMgr.GetParamValue("BACKUP_MSSQLPWD");
            txtMSSQLDb.Text = _obj.ConfigMgr.GetParamValue("BACKUP_MSSQLDB");
            txtMSSQLHost.Text = _obj.ConfigMgr.GetParamValue("BACKUP_MSSQLHOST");
            txtMSSQLPort.Text = _obj.ConfigMgr.GetParamValue("BACKUP_MSSQLPORT");
            this.chkBackupByMSSQL.Checked = _obj.ConfigMgr.GetParamValue("BACKUP_MSSQLUSE").Equals("1");

            txtCloudUrl.Text = _obj.ConfigMgr.GetParamValue("BACKUP_CLOUDURL");
            txtCloudUID.Text = _obj.ConfigMgr.GetParamValue("BACKUP_CLOUDUID");
            txtCloudPWD.Text = _obj.ConfigMgr.GetParamValue("BACKUP_CLOUDPWD");
            this.chkBackupByCloud.Checked = _obj.ConfigMgr.GetParamValue("BACKUP_CLOUDUSE").Equals("1");

            this.chkBackupItemAddOn.Checked = _obj.ConfigMgr.GetParamValue("BACKUP_ITEMADDON").Equals("1");
            this.chkBackupAuthentication.Checked = _obj.ConfigMgr.GetParamValue("BACKUP_AUTHENTICATION").Equals("1");
            this.chkBackupAuthorization.Checked = _obj.ConfigMgr.GetParamValue("BACKUP_AUTHORIZATION").Equals("1");

            chkEnableDbBackup.Checked = _obj.ConfigMgr.GetParamValue("AutoDbBackup").Equals("1");

            cboDbBackupHour.Text = _obj.ConfigMgr.GetParamValue("AutoDbBackupHour");
            cboDbBackupMinute.Text = _obj.ConfigMgr.GetParamValue("AutoDbBackupMinute");
            cboDbBackupSchedule.Text = _obj.ConfigMgr.GetParamValue("AutoDbBackupInterval");

            //tc.Alignment = TabAlignment.Top;
        }

        private void TriggerCmd_RecMySQLBackupConfig(object sender, EventArgs args)
        {
            TriggerAccess_RecMySQLBackupConfig();
        }

        private void TriggerAccess_RecMySQLBackupConfig()
        {
            Accountant _obj = mApplicationController.mAccountant;

            _obj.ConfigMgr.SetParam("BACKUP_MySQLUID", txtMySQLUID.Text);
            _obj.ConfigMgr.SetParam("BACKUP_MySQLPWD", txtMySQLPWD.Text);
            _obj.ConfigMgr.SetParam("BACKUP_MySQLDB", txtMySQLDb.Text);
            _obj.ConfigMgr.SetParam("BACKUP_MySQLHOST", txtMySQLHost.Text);
            _obj.ConfigMgr.SetParam("BACKUP_MySQLPORT", txtMySQLPort.Text);
            _obj.ConfigMgr.SetParam("BACKUP_MySQLUSE", chkBackupByMySQL.Checked ? "1" : "0");
        }

        private void TriggerCmd_RecMSSQLBackupConfig(object sender, EventArgs args)
        {
            TriggerAccess_RecMSSQLBackupConfig();
        }

        private void TriggerCmd_RecCloudBackupConfig(object sender, EventArgs args)
        {
            TriggerAccess_RecCloudBackupConfig();
        }

        private void TriggerAccess_RecCloudBackupConfig()
        {
            Accountant _obj = mApplicationController.mAccountant;

            _obj.ConfigMgr.SetParam("BACKUP_CLOUDUID", txtCloudUID.Text);
            _obj.ConfigMgr.SetParam("BACKUP_CLOUDPWD", txtCloudPWD.Text);
            _obj.ConfigMgr.SetParam("BACKUP_CLOUDURL", txtCloudUrl.Text);

            _obj.ConfigMgr.SetParam("BACKUP_CLOUDUSE", chkBackupByCloud.Checked ? "1" : "0");

        }
        private void TriggerAccess_RecMSSQLBackupConfig()
        {
            Accountant _obj = mApplicationController.mAccountant;

            _obj.ConfigMgr.SetParam("BACKUP_MSSQLUID", txtMSSQLUID.Text);
            _obj.ConfigMgr.SetParam("BACKUP_MSSQLPWD", txtMSSQLPWD.Text);
            _obj.ConfigMgr.SetParam("BACKUP_MSSQLDB", txtMSSQLDb.Text);
            _obj.ConfigMgr.SetParam("BACKUP_MSSQLHOST", txtMSSQLHost.Text);
            _obj.ConfigMgr.SetParam("BACKUP_MSSQLPORT", txtMSSQLPort.Text);

            _obj.ConfigMgr.SetParam("BACKUP_MSSQLUSE", chkBackupByMSSQL.Checked ? "1" : "0");
        }

        private void TriggerCmd_DbBackupNow(object sender, EventArgs args)
        {
           
            if (chkBackupByMSSQL.Checked)
            {
                TriggerAccess_BackupToMSSQL();
            }
            if (chkBackupByMySQL.Checked)
            {
                TriggerAccess_BackupToMySQL();
            }
            if (chkBackupByCloud.Checked)
            {
                TriggerAccess_BackupToCloud();
            }
            
        }

        private void TriggerAccess_BackupToCloud()
        {
            Accountant curr_acc = mApplicationController.mAccountant;

            if (chkBackupItemAddOn.Checked)
            {
                IList<ItemAddOn> CurrItemAddOns = curr_acc.ItemAddOnMgr.FindAllCollection();
                int itemCount=CurrItemAddOns.Count;
                StringBuilder sb = new StringBuilder();
                sb.Append("backup=ItemAddOn");
                sb.AppendFormat("&count={0}", itemCount);

                string cloudUID = txtCloudUID.Text.Trim();
                if (string.IsNullOrEmpty(cloudUID))
                {
                    sb.AppendFormat("&uid={0}", NetUtil.UrlEncode(cloudUID));
                }
                string cloudPWD=txtCloudPWD.Text.Trim();
                if(string.IsNullOrEmpty(cloudPWD))
                {
                    sb.AppendFormat("&pwd={0}", NetUtil.UrlEncode(cloudPWD));
                }

                for (int i = 0; i < itemCount; ++i )
                {
                    ItemAddOn _addon = CurrItemAddOns[i];
                    sb.AppendFormat("&brand[]={0}", NetUtil.UrlEncode(_addon.Brand));
                    sb.AppendFormat("&serial[]={0}", NetUtil.UrlEncode(_addon.SerialNumber));
                    sb.AppendFormat("&batch[]={0}", NetUtil.UrlEncode(_addon.BatchNumber));
                    sb.AppendFormat("&color[]={0}", NetUtil.UrlEncode(_addon.Color));
                    sb.AppendFormat("&expiry[]={0}", NetUtil.UrlEncode(_addon.ExpiryDate));
                    sb.AppendFormat("&gender[]={0}", NetUtil.UrlEncode(_addon.GenderID));
                    sb.AppendFormat("&itemsize[]={0}", NetUtil.UrlEncode(_addon.ItemSizeID));
                }

                string cloudUrl=txtCloudUrl.Text;
                NetUtil.Instance.HttpPost(cloudUrl, sb.ToString());
            }
           
        }

        private void TriggerAccess_BackupToMSSQL()
        {
            Accountant curr_acc = mApplicationController.mAccountant;
            Accountant backup_acc = new ImAccountant("BackupAccount(MSSQL)");

            DbManager default_factory = new SqlClientDbManager(backup_acc, "PrimaryFactory");
            default_factory.Database = txtMSSQLDb.Text;
            default_factory.HostExePath = txtMSSQLHost.Text;
            default_factory.Port = txtMSSQLPort.Text;
            default_factory.DbPassword = txtMSSQLPWD.Text;
            default_factory.DbUsername = txtMSSQLUID.Text;
            backup_acc.DefaultMgrFactory = default_factory;

            string error;
            if (backup_acc.ConnectMgrFactories(out error))
            {
                if (chkBackupItemAddOn.Checked)
                {
                    backup_acc.ItemAddOnMgr.RecreateTable();
                    IList<ItemAddOn> CurrItemAddOns = curr_acc.ItemAddOnMgr.FindAllCollection();
                    foreach (ItemAddOn s in CurrItemAddOns)
                    {
                        backup_acc.ItemAddOnMgr.Store(s);
                    }
                    backup_acc.DataFieldMgr.RecreateTable();
                    IList<DataField> DataFields = curr_acc.DataFieldMgr.FindAllCollection();
                    foreach (DataField s in DataFields)
                    {
                        backup_acc.DataFieldMgr.Store(s);
                    }
                    backup_acc.ItemDataFieldEntryMgr.RecreateTable();
                    IList<ItemDataFieldEntry> ItemDataFieldEntries = curr_acc.ItemDataFieldEntryMgr.FindAllCollection();
                    foreach (ItemDataFieldEntry s in ItemDataFieldEntries)
                    {
                        backup_acc.ItemDataFieldEntryMgr.Store(s);
                    }
                }
            }
            else
            {
                MessageBox.Show(error);
            }

            backup_acc.Release();
        }

        private void TriggerAccess_BackupToMySQL()
        {
            Accountant curr_acc = mApplicationController.mAccountant;
            Accountant backup_acc = new ImAccountant("BackupAccount(MySQL)");

            DbManager default_factory = new MySQLDbManager(backup_acc, "PrimaryFactory");
            default_factory.Database = txtMySQLDb.Text;
            default_factory.HostExePath = txtMySQLHost.Text;
            default_factory.Port = txtMySQLPort.Text;
            default_factory.DbPassword = txtMySQLPWD.Text;
            default_factory.DbUsername = txtMySQLUID.Text;

            backup_acc.DefaultMgrFactory = default_factory;

            string error;
            if (backup_acc.ConnectMgrFactories(out error))
            {
                if (chkBackupItemAddOn.Checked)
                {
                    backup_acc.ItemAddOnMgr.RecreateTable();
                    IList<ItemAddOn> CurrItemAddOns = curr_acc.ItemAddOnMgr.FindAllCollection();
                    foreach (ItemAddOn s in CurrItemAddOns)
                    {
                        backup_acc.ItemAddOnMgr.Store(s);
                    }
                    backup_acc.DataFieldMgr.RecreateTable();
                    IList<DataField> DataFields = curr_acc.DataFieldMgr.FindAllCollection();
                    foreach (DataField s in DataFields)
                    {
                        backup_acc.DataFieldMgr.Store(s);
                    }
                    backup_acc.ItemDataFieldEntryMgr.RecreateTable();
                    IList<ItemDataFieldEntry> ItemDataFieldEntries = curr_acc.ItemDataFieldEntryMgr.FindAllCollection();
                    foreach (ItemDataFieldEntry s in ItemDataFieldEntries)
                    {
                        backup_acc.ItemDataFieldEntryMgr.Store(s);
                    }
                }
            }
            else
            {
                MessageBox.Show(error);
            }

            backup_acc.Release();
        }

        private void TriggerCmd_RestoreFromCloud(object sender, EventArgs args)
        {
            TriggerAccess_RestoreFromCloud();
        }

        private void TriggerAccess_RestoreFromCloud()
        {

        }

        private void TriggerCmd_RestoreFromMySQL(object sender, EventArgs args)
        {
            TriggerAccess_RestoreFromMySQL();
        }
        private void TriggerAccess_RestoreFromMySQL()
        {
            Accountant curr_acc = mApplicationController.mAccountant;
            Accountant source_acc = new ImAccountant("SourceAccount(MySQL)");

            DbManager default_factory = new MySQLDbManager(source_acc, "PrimaryFactory");
            default_factory.Database = txtMySQLDb.Text;
            default_factory.HostExePath = txtMySQLHost.Text;
            default_factory.Port = txtMySQLPort.Text;
            default_factory.DbPassword = txtMySQLPWD.Text;
            default_factory.DbUsername = txtMySQLUID.Text;

            source_acc.DefaultMgrFactory = default_factory;

            string error;
            if (source_acc.ConnectMgrFactories(out error))
            {
                if (chkBackupItemAddOn.Checked)
                {
                    curr_acc.ItemAddOnMgr.RecreateTable();
                    IList<ItemAddOn> CurrItemAddOns = source_acc.ItemAddOnMgr.FindAllCollection();
                    foreach (ItemAddOn s in CurrItemAddOns)
                    {
                        curr_acc.ItemAddOnMgr.Store(s);
                    }
                    curr_acc.DataFieldMgr.RecreateTable();
                    IList<DataField> DataFields = source_acc.DataFieldMgr.FindAllCollection();
                    foreach (DataField s in DataFields)
                    {
                        curr_acc.DataFieldMgr.Store(s);
                    }
                    curr_acc.ItemDataFieldEntryMgr.RecreateTable();
                    IList<ItemDataFieldEntry> ItemDataFieldEntries = source_acc.ItemDataFieldEntryMgr.FindAllCollection();
                    foreach (ItemDataFieldEntry s in ItemDataFieldEntries)
                    {
                        curr_acc.ItemDataFieldEntryMgr.Store(s);
                    }
                }
            }
            else
            {
                MessageBox.Show(error);
            }

            source_acc.Release();
        }

        private void TriggerCmd_RestoreFromMSSQL(object sender, EventArgs args)
        {
            TriggerAccess_RestoreFromMSSQL();
        }
        private void TriggerAccess_RestoreFromMSSQL()
        {
            Accountant curr_acc = mApplicationController.mAccountant;
            Accountant source_acc = new ImAccountant("SourceAccount(MSSQL)");

            DbManager default_factory = new SqlClientDbManager(source_acc, "PrimaryFactory");
            default_factory.Database = txtMSSQLDb.Text;
            default_factory.HostExePath = txtMSSQLHost.Text;
            default_factory.Port = txtMSSQLPort.Text;
            default_factory.DbPassword = txtMSSQLPWD.Text;
            default_factory.DbUsername = txtMSSQLUID.Text;
            source_acc.DefaultMgrFactory = default_factory;

            string error;
            if (source_acc.ConnectMgrFactories(out error))
            {
                if (chkBackupItemAddOn.Checked)
                {
                    curr_acc.ItemAddOnMgr.RecreateTable();
                    IList<ItemAddOn> CurrItemAddOns = source_acc.ItemAddOnMgr.FindAllCollection();
                    foreach (ItemAddOn s in CurrItemAddOns)
                    {
                        curr_acc.ItemAddOnMgr.Store(s);
                    }
                    curr_acc.DataFieldMgr.RecreateTable();
                    IList<DataField> DataFields = source_acc.DataFieldMgr.FindAllCollection();
                    foreach (DataField s in DataFields)
                    {
                        curr_acc.DataFieldMgr.Store(s);
                    }
                    curr_acc.ItemDataFieldEntryMgr.RecreateTable();
                    IList<ItemDataFieldEntry> ItemDataFieldEntries = source_acc.ItemDataFieldEntryMgr.FindAllCollection();
                    foreach (ItemDataFieldEntry s in ItemDataFieldEntries)
                    {
                        curr_acc.ItemDataFieldEntryMgr.Store(s);
                    }
                }
            }
            else
            {
                MessageBox.Show(error);
            }

            source_acc.Release();
        }

        private void TriggerCmd_SaveDbBackupScheduleConfig(object sender, EventArgs e)
        {
            TriggerAccess_SaveDbBackupScheduleConfig();
        }
        private void TriggerAccess_SaveDbBackupScheduleConfig()
        {
            Accountant acc = mApplicationController.mAccountant;
            string doDbBackup = "0";
            if (chkEnableDbBackup.Checked)
            {
                doDbBackup = "1";
            }
            acc.ConfigMgr.SetParam("AutoDbBackup", doDbBackup);

            acc.ConfigMgr.SetParam("AutoDbBackupHour", cboDbBackupHour.Text);
            acc.ConfigMgr.SetParam("AutoDbBackupMinute", cboDbBackupMinute.Text);
            acc.ConfigMgr.SetParam("AutoDbBackupInterval", cboDbBackupSchedule.Text);
        }

        private void chkBackupItemAddOn_CheckedChanged(object sender, EventArgs e)
        {
            Accountant _obj = mApplicationController.mAccountant;
            _obj.ConfigMgr.SetParam("BACKUP_ITEMADDON", chkBackupItemAddOn.Checked ? "1" : "0");
        }

        private void chkBackupAuthorization_CheckedChanged(object sender, EventArgs e)
        {
            Accountant _obj = mApplicationController.mAccountant;
            _obj.ConfigMgr.SetParam("BACKUP_AUTHORIZATION", chkBackupAuthorization.Checked ? "1" : "0");
        }

        private void chkBackupAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            Accountant _obj = mApplicationController.mAccountant;
            _obj.ConfigMgr.SetParam("BACKUP_AUTHENTICATION", chkBackupAuthentication.Checked ? "1" : "0");
        }
    }
}
