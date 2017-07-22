using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SyntechRpt.WinForms.Security
{
    public partial class FrmEmailLogon : Form
    {
        public FrmEmailLogon()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        public string Username
        {
            get { return txtUsername.Text; }
        }

        public string Password
        {
            get { return txtPassword.Text; }
        }

        public string Domain
        {
            get { return txtDomain.Text; }
        }
    }
}
