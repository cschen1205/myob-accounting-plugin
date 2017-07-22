using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Accounting;
using Accounting.Core.Inventory;
using Accounting.Db.Elements;

namespace DacII.WinForms.Inventory
{
    public partial class FrmLocationRegister : Form
    {
        public FrmLocationRegister()
        {
            InitializeComponent();
            dgvLocations.ColumnHeadersBorderStyle = ProperColumnHeadersBorderStyle;
        }

        static DataGridViewHeaderBorderStyle ProperColumnHeadersBorderStyle
        {
            get
            {
                return (SystemFonts.MessageBoxFont.Name == "Segoe UI") ?
                    DataGridViewHeaderBorderStyle.None :
                    DataGridViewHeaderBorderStyle.Raised;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        private void frmLocations_Load(object sender, EventArgs e)
        {
            string[] fieldnames = new string[] { "LocationName", "City", "State", "Country" }; //"QuantityOnHand", "LastUnitPrice", "BaseSellingPrice" 
            foreach (string fieldname in fieldnames)
            {
                cboSearch.Items.Add(fieldname);
            }

            RefreshLocations();
            cboSearch.SelectedIndex = 0;
        }

        private void RefreshLocations()
        {
            /*
            DataView dt = Accountant.LocationMgr.GetView(GetViewFilter());
            this.dgvLocations.DataSource =dt;
            lblNoFound.Text=string.Format("# Found: {0}", dt.Count);    
             * */
        }

        /*
        DbCriteria GetViewCriteria()
        {
            string where = "";

            string search = txtSearch.Text;
            if (search != "")
            {
                string fieldname = (string)cboSearch.SelectedItem;
                where = string.Format("{0} LIKE \"*{1}*\"", fieldname, search);
            }
            return where;
        }
         * */

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshLocations();
        }

        private void dgvLocations_DoubleClick(object sender, EventArgs e)
        {
            /*
            if (dgvLocations.SelectedRows.Count > 0)
            {
                int LocationID =int.Parse(this.dgvLocations.SelectedRows[0].Cells[0].Value.ToString());
                Location _obj = Accountant.LocationMgr.FindById(LocationID);
                if (_obj != null)
                {
                    frmLocationInformation frm = new frmLocationInformation(_obj);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
             * */
        }
    }
}
