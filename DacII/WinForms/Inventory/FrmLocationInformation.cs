using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using Accounting.Core.Inventory;

namespace DacII.WinForms.Inventory
{
    public partial class FrmLocationInformation : Form
    {
        private Location mLocation;

        public FrmLocationInformation(Location _obj)
        {
            mLocation = _obj;
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
           
        }

        private void frmLocationInformation_Load(object sender, EventArgs e)
        {
            if (mLocation.LocationName != null)
            {
                InitData();
            }
            else
            {
                txtName.Enabled = false;
                txtAddress.Enabled = false;
                txtCity.Enabled = false;
                txtState.Enabled = false;
                txtCountry.Enabled = false;
                txtContact.Enabled = false;
                txtContactPhone.Enabled = false;
                txtNotes.Enabled = false;
                txtPostcode.Enabled = false;
            }
        }

        private void InitData()
        {
            

            txtAddress.Text = mLocation.Street;
            txtName.Text = mLocation.LocationName;
            txtNotes.Text = mLocation.Notes;
            txtState.Text = mLocation.State;
            txtCity.Text = mLocation.City;
            txtCountry.Text = mLocation.Country;
            txtLocationID.Text = mLocation.LocationIdentification;
            txtContact.Text = mLocation.Contact;
            txtContactPhone.Text = mLocation.ContactPhone;
            txtPostcode.Text = mLocation.Postcode;

            if (mLocation.IsInactive == "Y") chkIsInactive.Checked = true;
            else chkIsInactive.Checked = false;

            if (mLocation.CanBeSold == "Y") chkCanBeSold.Checked = true;
            else chkCanBeSold.Checked = false;
            
        }
    }
}
