using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DacII.WinForms.DbSync.Myob
{
    public partial class FrmGetDrv : Form
    {

        [DllImport("ODBC_VER_DETECT.dll")]
        extern private static long GetDriverName([MarshalAs(UnmanagedType.LPStr)] String sDataBase,
                                                 [MarshalAs(UnmanagedType.LPStr)] StringBuilder sDriverName);

        [DllImport("ODBC_VER_DETECT.dll")]
        extern private static long GetCountry([MarshalAs(UnmanagedType.LPStr)] String sDataBase,
                                                 [MarshalAs(UnmanagedType.LPStr)] StringBuilder sCountry);

        [DllImport("ODBC_VER_DETECT.dll")]
        extern private static long GetCompanyFileVersion([MarshalAs(UnmanagedType.LPStr)] String sDataBase,
                                                 [MarshalAs(UnmanagedType.LPStr)] StringBuilder sVersion);

        public FrmGetDrv()
        {
            InitializeComponent();
        }

        private void LoadCompanyFileInfo()
        {
            StringBuilder sDriverName = new StringBuilder("");
            StringBuilder sCountry = new StringBuilder("");
            StringBuilder sVersion = new StringBuilder("");
            sCountry.Length = 127;
            sDriverName.Length = 127;
            sVersion.Length = 127;

            try
            {
                if (txtDatabase.Text.Length == 0)
                {
                    MessageBox.Show("Please enter a valid Database", "Data Entry Error");
                    return;
                }


                if (GetDriverName(txtDatabase.Text, sDriverName) > 0)
                {
                    txtDriverName.Text = sDriverName.ToString();
                }

                if (GetCountry(txtDatabase.Text, sCountry) > 0)
                {
                    txtCountry.Text = sCountry.ToString();
                }

                if (GetCompanyFileVersion(txtDatabase.Text, sVersion) > 0)
                {
                    txtVersion.Text = sVersion.ToString();
                }
            }
            catch (DllNotFoundException ex)
            {
                MessageBox.Show(
                    String.Format("Unable to locate ODBC_VER_DETECT.dll\r\n{0}", ex.Message), 
                    "File not Found");
            }
        }

        private void frmGetDrv_Load(object sender, EventArgs e)
        {
            LoadCompanyFileInfo();
        }
    }
}