using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DacII.Util;
using System.Runtime.InteropServices;
using System.Data.Odbc;
using Accounting.Bll;
using Accounting.Db;
using Accounting.Db.MySQL;
using Accounting.Db.SqlClient;
using Accounting.Db.OleDb;

namespace DacII.WinForms.Security
{
    public partial class FrmMyobLogin : Form
    {
        [DllImport("odbc32.dll", CharSet = CharSet.Ansi)]
        static extern short SQLDataSources(int EnvironmentHandle,
            int Direction, StringBuilder ServerName,
            int BufferLength1, ref int NameLength1Ptr, StringBuilder
            Description,
            int BufferLength2, ref int NameLength2Ptr);

        [DllImport("odbc32.dll", CharSet = CharSet.Ansi)]
        static extern Int32 SQLDrivers(IntPtr EnvironmentHandle,
            int Direction,
            StringBuilder Description,
            int DriverDescMax,
            ref IntPtr DriverDesc,
            StringBuilder szDriverAttr,
            int DrvrAttrMax,
            ref IntPtr pcbDrvrAttr);

        [DllImport("ODBC32.DLL")]
        private static extern Int32 SQLAllocEnv(ref IntPtr env);


        [DllImport("ODBC32.DLL")]
        private static extern int SQLFreeEnv(IntPtr hEnv);


        [DllImport("odbc32.DLL")]
        private static extern int SQLAllocConnect(int env, ref int hdbc);


        [DllImport("odbc32.DLL")]
        private static extern int SQLConnect(int hdbc, string server, int
            serverlen, string uid, int uidlen, string pwd, int pwdlen);


        [DllImport("odbc32.DLL")]
        private static extern int SQLAllocHandle(int handleType, int
            inputHandle, ref int outputHandle);


        [DllImport("odbc32.DLL")]
        private static extern short SQLTables(int hstmt, string cat, int
            catlen,
            string sch, int schlen, string table, int tablen, string type, int
            typelen);


        [DllImport("odbc32.DLL")]
        private static extern short SQLBindCol(int hStmt, int colnum, int
            targettype, ref string targetvalue, int bufferlen, int len);


        [DllImport("odbc32.DLL")]
        private static extern int SQLFetch(int hStmt);

        public const short SQL_INVALID_HANDLE = -2;
        public const ushort SQL_HANDLE_ENV = 1;
        public const short SQL_SUCCESS = 0;
        public const short SQL_SUCCESS_WITH_INFO = 1;
        public const short SQL_NO_DATA = 100;
        public const int SQL_ATTR_ODBC_VERSION = 200;
        public const int SQL_OV_ODBC3 = 3;
        public const short SQL_FETCH_NEXT = 1;
        public const short SQL_FETCH_FIRST = 2;
        public const int MAX_DSN_LENGTH = 32;

        private bool GetMYOBDrivers()
        {
            bool bGetMYOBDrivers = false;
            IntPtr sql_env_handle = IntPtr.Zero;
            int rc = 0;
            StringBuilder dsn_name = new StringBuilder(MAX_DSN_LENGTH);
            StringBuilder desc_name = new StringBuilder(128);
            StringBuilder driver_name = new StringBuilder(128);
            IntPtr dsn_name_len = IntPtr.Zero, desc_len = IntPtr.Zero, driver_len = IntPtr.Zero;

            try
            {
                rc = SQLAllocEnv(ref sql_env_handle);
                if (rc == SQL_INVALID_HANDLE)
                    throw new Exception("Could not setup ODBC Environment handle");

                rc = SQLDrivers(sql_env_handle, SQL_FETCH_FIRST,
                                dsn_name, (short)dsn_name.Capacity, ref desc_len,
                                driver_name, (short)driver_name.Capacity, ref driver_len);

                while ((rc == SQL_SUCCESS) || (rc == SQL_SUCCESS_WITH_INFO))
                {
                    string asp = dsn_name.ToString().Substring(1, 3);

                    if ((dsn_name.ToString().Substring(0, 3) == "MYO") ||
                        (dsn_name.ToString().Substring(0, 9) == "MYOB_ODBC") ||
                        (dsn_name.ToString().Substring(0, 5) == "MYOB_"))
                    {
                        cboDriver.Items.Add(dsn_name.ToString());
                        bGetMYOBDrivers = true;
                    }
                    rc = SQLDrivers(sql_env_handle, SQL_FETCH_NEXT,
                                    dsn_name, (short)dsn_name.Capacity, ref desc_len,
                                    driver_name, (short)driver_name.Capacity, ref driver_len);

                    //if ((rc != SQL_SUCCESS) && (rc != SQL_SUCCESS_WITH_INFO) && (rc != SQL_NO_DATA))
                        //throw new Exception("Error getting ODBC Data Sources");
                }
            }
            finally
            {
                if (sql_env_handle != IntPtr.Zero)
                {
                    rc = SQLFreeEnv(sql_env_handle);
                }
            }
            return bGetMYOBDrivers;
        }

        private Accountant mAccountant;
        public FrmMyobLogin(Accountant acc)
        {
            InitializeComponent();
            mAccountant = acc;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            GetMYOBDrivers();

            txtUsername.Text = mAccountant.DefaultMgrFactory_DbUsername;
            txtDB.Text = mAccountant.DefaultMgrFactory_Database;
            txtApp.Text = mAccountant.DefaultMgrFactory_HostExePath;
            cboDriver.Text = mAccountant.DefaultMgrFactory_Driver;
            txtDbUsername.Text = mAccountant.DefaultMgrFactory_DbUsername;
            txtDbPassword.Text = mAccountant.DefaultMgrFactory_DbPassword;

            txtMySQLUID.Text = mAccountant.ConfigMgr.GetParamValue("NETWORK_MySQLUID");
            txtMySQLPWD.Text = mAccountant.ConfigMgr.GetParamValue("NETWORK_MySQLPWD");
            txtMySQLDb.Text = mAccountant.ConfigMgr.GetParamValue("NETWORK_MySQLDB");
            txtMySQLHost.Text = mAccountant.ConfigMgr.GetParamValue("NETWORK_MySQLHOST");
            txtMySQLPort.Text = mAccountant.ConfigMgr.GetParamValue("NETWORK_MySQLPORT");

            txtMSSQLUID.Text = mAccountant.ConfigMgr.GetParamValue("NETWORK_MSSQLUID");
            txtMSSQLPWD.Text = mAccountant.ConfigMgr.GetParamValue("NETWORK_MSSQLPWD");
            txtMSSQLDb.Text = mAccountant.ConfigMgr.GetParamValue("NETWORK_MSSQLDB");
            txtMSSQLHost.Text = mAccountant.ConfigMgr.GetParamValue("NETWORK_MSSQLHOST");
            txtMSSQLPort.Text = mAccountant.ConfigMgr.GetParamValue("NETWORK_MSSQLPORT");

            string network_db = mAccountant.ConfigMgr.GetParamValue("NETWORK_NETWORKDB");
            if (network_db.Equals("1"))
            {
                rdoNetworkedMySQL.Checked = true;
            }
            else if (network_db.Equals("2"))
            {
                rdoNetworkedMSSQL.Checked = true;
            }
            else
            {
                rdoLocalDb.Checked = true;
            }

            if (!string.IsNullOrEmpty(CompanyLogoPath))
            {
                pbPicture.Load(CompanyLogoPath);
            }
        }

        private string CompanyLogoPath
        {
            get { return Application.StartupPath + System.IO.Path.DirectorySeparatorChar + "Images" + System.IO.Path.DirectorySeparatorChar + "company_logo.png"; }
        }
     

        private void TriggerCmd_RecMySQLLoginConfig(object sender, EventArgs args)
        {
            TriggerAccess_RecMySQLLoginConfig();
        }
        private void TriggerAccess_RecMySQLLoginConfig()
        {
            Accountant _obj = mAccountant;

            _obj.ConfigMgr.SetParam("NETWORK_MySQLUID", txtMySQLUID.Text);
            _obj.ConfigMgr.SetParam("NETWORK_MySQLPWD", txtMySQLPWD.Text);
            _obj.ConfigMgr.SetParam("NETWORK_MySQLDB", txtMySQLDb.Text);
            _obj.ConfigMgr.SetParam("NETWORK_MySQLHOST", txtMySQLHost.Text);
            _obj.ConfigMgr.SetParam("NETWORK_MySQLPORT", txtMySQLPort.Text);
            
        }

        private void TriggerCmd_RecMSSQLLoginConfig(object sender, EventArgs args)
        {
            TriggerAccess_RecMSSQLLoginConfig();
        }
        private void TriggerAccess_RecMSSQLLoginConfig()
        {
            Accountant _obj = mAccountant;

            _obj.ConfigMgr.SetParam("NETWORK_MSSQLUID", txtMSSQLUID.Text);
            _obj.ConfigMgr.SetParam("NETWORK_MSSQLPWD", txtMSSQLPWD.Text);
            _obj.ConfigMgr.SetParam("NETWORK_MSSQLDB", txtMSSQLDb.Text);
            _obj.ConfigMgr.SetParam("NETWORK_MSSQLHOST", txtMSSQLHost.Text);
            _obj.ConfigMgr.SetParam("NETWORK_MSSQLPORT", txtMSSQLPort.Text);
        }

        private bool ValidateLogin(List<string> message)
        {            
            mAccountant.DefaultMgrFactory.Database = txtDB.Text;
            mAccountant.DefaultMgrFactory.HostExePath = txtApp.Text;
            mAccountant.DefaultMgrFactory.Driver = cboDriver.Text;
            mAccountant.DefaultMgrFactory.Key = txtKey.Text;
            mAccountant.DefaultMgrFactory.DbUsername = txtDbUsername.Text;
            mAccountant.DefaultMgrFactory.DbPassword = txtDbPassword.Text;

            mAccountant.DefaultMgrFactory_Database = txtDB.Text;
            mAccountant.DefaultMgrFactory_HostExePath = txtApp.Text;
            mAccountant.DefaultMgrFactory_Driver = cboDriver.Text;
            mAccountant.DefaultMgrFactory_Key = txtKey.Text;
            mAccountant.DefaultMgrFactory_DbUsername = txtDbUsername.Text;
            mAccountant.DefaultMgrFactory_DbPassword = txtDbPassword.Text;

            string error;
            bool validated=mAccountant.CurrentAuthUser.Authenticate(txtUsername.Text, txtPassword.Text, out error);
            if (validated == false)
            {
                message.Add(error);
            }
            return validated;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(txtApp.Text))
            {
                MessageBox.Show("The Myob Application path is not set correctly!");
                DialogResult = DialogResult.None;
                return;
            }

            if (!System.IO.File.Exists(txtDB.Text))
            {
                MessageBox.Show("The Myob Database path is not set correctly!");
                DialogResult = DialogResult.None;
                return;
            }

            DbManager secondary_factory = null;

            string network_db = "0";
            if (rdoLocalDb.Checked)
            {
                secondary_factory = new OleDbManager(mAccountant, "SecondaryFactory");
                secondary_factory.Database = mAccountant.GetFullPath("inventorist.mdb");
                secondary_factory.DbPassword = "lkj3972897_89&";
            }
            else if (rdoNetworkedMySQL.Checked)
            {
                secondary_factory = new MySQLDbManager(mAccountant, "SecondaryFactory");
                secondary_factory.DbUsername = (txtMySQLUID.Text);
                secondary_factory.DbPassword = (txtMySQLPWD.Text);
                secondary_factory.Database = (txtMySQLDb.Text);
                secondary_factory.HostExePath = (txtMySQLHost.Text);
                secondary_factory.Port = (txtMySQLPort.Text);
                network_db = "1";
            }
            else if (rdoNetworkedMSSQL.Checked)
            {
                secondary_factory = new SqlClientDbManager(mAccountant, "SecondaryFactory");
                secondary_factory.DbUsername = (txtMSSQLUID.Text);
                secondary_factory.DbPassword = (txtMSSQLPWD.Text);
                secondary_factory.Database = (txtMSSQLDb.Text);
                secondary_factory.HostExePath = (txtMSSQLHost.Text);
                secondary_factory.Port = (txtMSSQLPort.Text);
                network_db = "2";
            }

            mAccountant.ConfigMgr.SetParam("NETWORK_NETWORKDB", network_db);

            mAccountant.AddMgrFactory(secondary_factory);

            mAccountant.AuthItemMgrFactory = secondary_factory;
            mAccountant.AuthRoleMgrFactory = secondary_factory;
            mAccountant.AuthUserMgrFactory = secondary_factory;
            mAccountant.ItemAddOnMgrFactory = secondary_factory;
            mAccountant.GenderMgrFactory = secondary_factory;
            mAccountant.ItemSizeMgrFactory = secondary_factory;


            List<string> message = new List<string>();

            if (!ValidateLogin(message))
            {
                if (message.Count == 0)
                {
                    MessageBox.Show("Invalid Login!");
                }
                else
                {
                    MessageBox.Show("Invalid Login! ("+message[0]+")");
                }
                DialogResult = DialogResult.None;
            }
        }

        private void btnBrowseDB_Click(object sender, EventArgs e)
        { 
            //Create a new instance of the OpenFileDialog because it's an object.
            OpenFileDialog dialog = new OpenFileDialog();
 
            //Now set the file type
            //dialog.Filter = "MYOB Databases (*.myo)|*.myo|All files (*.*)|*.*";
            dialog.Filter = "MYOB Company Files (*.myo)|*.myo|MYOB Company Files (*.dat)|*.dat|MYOB Company Files (*.prm)|*.prm|MYOB Company Files (*.pls)|*.pls";
            dialog.FilterIndex = 0;

            //Set the starting directory and the title.
            dialog.InitialDirectory = "C:"; 
            dialog.Title = "Select the MYOB database";
            dialog.RestoreDirectory = true;

            String input = string.Empty;
            //Present to the user.
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                 input = dialog.FileName;
            }
            if (input == String.Empty)
            {
                 return;//user didn't select a file
            }
            mAccountant.ConfigMgr.SetParam("MYOBDB", input);
            txtDB.Text = mAccountant.ConfigMgr.GetParamValue("MYOBDB");

            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(input);
            string exe_path = di.Parent.FullName + "\\Myobp.exe";
            if (System.IO.File.Exists(exe_path))
            {
                mAccountant.ConfigMgr.SetParam("MYOBAPP", exe_path);
                txtApp.Text = mAccountant.ConfigMgr.GetParamValue("MYOBAPP");
            }
        }

        private void btnBrowseApp_Click(object sender, EventArgs e)
        {
            //Create a new instance of the OpenFileDialog because it's an object.
            OpenFileDialog dialog = new OpenFileDialog();

            //Now set the file type
            dialog.Filter = "MYOB Executable (*.exe)|*.exe|All files (*.*)|*.*";

            //Set the starting directory and the title.
            dialog.InitialDirectory = "C:"; dialog.Title = "Select the MYOB Application file";

            String input = string.Empty;
            //Present to the user.
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                input = dialog.FileName;
            }
            if (input == String.Empty)
            {
                return;//user didn't select a file
            }
            mAccountant.ConfigMgr.SetParam("MYOBAPP", input);
            txtApp.Text = mAccountant.ConfigMgr.GetParamValue("MYOBAPP");
        }

        private string GetADONETError(OdbcException ex)
        {
            string sQuery;
            long lNativeError = 0;

            string sErrorDesc = "";
            if (ex.Errors.Count == 0)
                return sErrorDesc;

            foreach (OdbcError oErr in ex.Errors)
            {
                sErrorDesc = oErr.Message;

                if (sErrorDesc.EndsWith("Transaction rollback"))
                {
                    lNativeError = oErr.NativeError;
                    break;
                }
            }

            if ((lNativeError >= 10000) && (lNativeError < 20000)) // 'Error
            {
                sErrorDesc = "Error: " + lNativeError.ToString() + " ";
                lNativeError = lNativeError - 10000;
                sQuery = "Select Description from ImportErrors where ImportErrorID = " + lNativeError.ToString();
            }
            else if ((lNativeError >= 1) && (lNativeError < 10000)) // 'Warning
            {
                sQuery = "Select Description from ImportWarnings where ImportWarningID = " + lNativeError.ToString();
                sErrorDesc = "Warning: " + lNativeError.ToString() + " ";
            }
            else if (lNativeError >= 20000)
            {
                sQuery = "Select Description from InternalODBCErrors where NativeErrorNumber = " + lNativeError.ToString();
                sErrorDesc = lNativeError.ToString() + " ";
            }
            else
            {
                // return first error in the list
                foreach (OdbcError oErr in ex.Errors)
                {
                    sErrorDesc = oErr.Message;
                    break;
                }
                return sErrorDesc;
            }

            /*
            OdbcDataAdapter adapter = new OdbcDataAdapter(sQuery, DbManager.Instance.MyobConnection);
            DataSet ADORecordset = new DataSet();
            adapter.Fill(ADORecordset, "ImportWarnings");

            foreach (DataRow drow in ADORecordset.Tables["ImportWarnings"].Rows)
            {
                sErrorDesc += drow["Description"];
            }
             */
            return sErrorDesc;
        }

        private void btnBrowseKey_Click(object sender, EventArgs e)
        {
            //Create a new instance of the OpenFileDialog because it's an object.
            OpenFileDialog dialog = new OpenFileDialog();

            //Now set the file type
            dialog.Filter = "MYOB Key (*.key)|*.key|All files (*.*)|*.*";

            //Set the starting directory and the title.
            dialog.InitialDirectory = "C:"; dialog.Title = "Select the MYOB key";

            String input = string.Empty;
            //Present to the user.
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                input = dialog.FileName;
            }
            if (input == String.Empty)
            {
                return;//user didn't select a file
            }
            mAccountant.ConfigMgr.SetParam("key", input);
            txtKey.Text = mAccountant.ConfigMgr.GetParamValue("key");
        }
    }
}
