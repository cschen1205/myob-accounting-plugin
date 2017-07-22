using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SyntechRpt.Util;
using Accounting.Bll;
using Accounting.Bll.Security;
using Accounting.Core.Security;

namespace SyntechRpt.WinForms.Security
{
    public partial class FrmSecurity : Form
    {
        public FrmSecurity()
        {
            InitializeComponent();
            ViewModel();
        }

        private void frmSecurity_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewModel()
        {
            BOUser current_user=AccountantPool.Instance.CurrentAccountant.User;
            dgvUsers.DataSource=current_user.UserDataGridView();
            dgvRoles.DataSource = current_user.RoleDataGridView();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnRebuild_Click(object sender, EventArgs e)
        {
            BOUser current_user=AccountantPool.Instance.CurrentAccountant.User;

            string ApplicationDirPath = System.Windows.Forms.Application.StartupPath;

            string auth_item_schema_file = string.Format("{0}\\AuthItems.xml", ApplicationDirPath);
            string auth_role_schema_file = string.Format("{0}\\AuthRoles.xml", ApplicationDirPath);
            string auth_user_schema_file = string.Format("{0}\\AuthUsers.xml", ApplicationDirPath);
            current_user.RebuildSecurity(auth_item_schema_file, auth_role_schema_file, auth_user_schema_file);

            ViewModel();
        }

        private void dgvUsers_DoubleClick(object sender, EventArgs e)
        {
            int UserID;
            if (WinFormUtil.DataGridView_GetSelectedID(dgvUsers, out UserID))
            {
                BOUser current_user = AccountantPool.Instance.CurrentAccountant.User;
                AuthUser user=current_user.GetAuthUser(UserID);
                if (user != null)
                {
                    FrmAuthUser frm = new FrmAuthUser();
                    frm.Username = user.Username;
                    frm.Password = user.Password;
                    frm.Role = user.Role;
                    frm.Description = user.Description;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        user.Username = frm.Username;
                        user.Password = frm.Password;
                        user.Description = frm.Description;
                        user.Role = frm.Role;
                        current_user.SaveAuthUser(user);
                        ViewModel();
                    }
                    
                }
            }
            
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            FrmAuthUser frm = new FrmAuthUser();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                AuthUser user = AuthUser.CreateAuthUser();

                user.Username = frm.Username;
                user.Password = frm.Password;
                user.Description = frm.Description;
                user.Role = frm.Role;

                BOUser current_user = AccountantPool.Instance.CurrentAccountant.User;
                current_user.SaveAuthUser(user);
                
                ViewModel();
            }
        }

        private void btnDelUser_Click(object sender, EventArgs e)
        {
            int UserID;
            if (WinFormUtil.DataGridView_GetSelectedID(dgvUsers, out UserID))
            {
                BOUser current_user = AccountantPool.Instance.CurrentAccountant.User;
                current_user.DeleteAuthUser(UserID);

                ViewModel();
            }
        }

        private void dgvRoles_DoubleClick(object sender, EventArgs e)
        {
            int RoleID;
            if (WinFormUtil.DataGridView_GetSelectedID(dgvRoles, out RoleID))
            {
                BOUser current_user = AccountantPool.Instance.CurrentAccountant.User;
                AuthRole role = current_user.GetAuthRole(RoleID);
                if (role != null)
                {
                    FrmAuthRole frm = new FrmAuthRole(role);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        ViewModel();
                    }

                }
            }
        }

        private void btnDeleteRole_Click(object sender, EventArgs e)
        {
             int RoleID;
             if (WinFormUtil.DataGridView_GetSelectedID(dgvRoles, out RoleID))
             {
                 BOUser current_user = AccountantPool.Instance.CurrentAccountant.User;
                 AuthRole role = current_user.GetAuthRole(RoleID);
                 if (role != null)
                 {
                     
                     if (current_user.CanDelete(role))
                     {
                         if (WinFormUtil.Confirm("Do you want to delete?", "Delete Warning") == DialogResult.Yes)
                         {
                             current_user.Delete(role);
                             ViewModel();
                         }
                     }
                     else if (WinFormUtil.Confirm("Other roles and users have inherited this role, delete this role will also delete them,\r\n do you still want to delete?", "Delete Warning") == DialogResult.Yes)
                     {
                         current_user.Delete(role);
                         ViewModel();
                     }
                 }
             }
        }

        private void btnCreateRole_Click(object sender, EventArgs e)
        {
                BOUser current_user = AccountantPool.Instance.CurrentAccountant.User;
                AuthRole role = current_user.CreateAuthRole();
                FrmAuthRole frm = new FrmAuthRole(role);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    ViewModel();
                }
        }

        
     }
}
