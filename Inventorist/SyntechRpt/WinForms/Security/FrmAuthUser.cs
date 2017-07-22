using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.Bll;
using Accounting.Bll.Security;
using Accounting.Core.Security;

namespace SyntechRpt.WinForms.Security
{
    public partial class FrmAuthUser : Form
    {
        public FrmAuthUser()
        {
            InitializeComponent();
            BOUser current_user = AccountantPool.Instance.CurrentAccountant.User;
            cboRole.DataSource = current_user.List("AuthRole");
        }

        private void FrmAuthUser_Load(object sender, EventArgs e)
        {
            
        }

        public string Username
        {
            get { return txtUsername.Text; }
            set { txtUsername.Text = value; }
        }

        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }

        public string Description
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }

        public AuthRole Role
        {
            get { return (AuthRole)cboRole.SelectedItem; }
            set { cboRole.SelectedItem = value; }
        }
    }
}
