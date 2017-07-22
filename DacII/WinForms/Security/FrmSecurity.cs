using System;
using System.Windows.Forms;

namespace DacII.WinForms.Security
{
    using DacII.Presenters;
    using DacII.Util;
    using Accounting.Bll;
    using Accounting.Bll.Security;
    using Accounting.Core.Security;

    public partial class FrmSecurity : BaseView
    {
        public FrmSecurity(ApplicationPresenter ap)
            : base(ap)
        {
            InitializeComponent();

            BindViews();
            RegisterEventHandlers();

            ConfigureDataGridView(dgvUsers);
            ConfigureDataGridView(dgvRoles);
        }

        protected override void BindViews()
        {
            base.BindViews();
            dgvUsers.DataSource = mApplicationController.FindAllAuthUsers();
            dgvRoles.DataSource = mApplicationController.FindAllAuthRoles();
        }

        private void ConfigureDataGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            DataGridViewColumn c = null;

            if (dgv == dgvUsers)
            {
                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "Username";
                c.HeaderText = "Username";
                dgv.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "Password";
                c.HeaderText = "Password";
                dgv.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "Description";
                c.HeaderText = "Card ID";
                dgv.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "Role";
                c.HeaderText = "Role";
                dgv.Columns.Add(c);
            }
            else if (dgv == dgvRoles)
            {
                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "RoleName";
                c.HeaderText = "Role Name";
                dgv.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "IsFullControl";
                c.HeaderText = "Full Control";
                dgv.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "Description";
                c.HeaderText = "Description";
                dgv.Columns.Add(c);
            }

            DacII.Util.DataGridViewHelper.UpdateColumnHeaderStyles(dgv);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        protected override void LoadView()
        {
            BOUser current_user=mApplicationController.mAccountant.CurrentAuthUser;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void dgvUsers_DoubleClick(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0) return;
            mApplicationController.OpenAuthUser(dgvUsers.SelectedRows[0].DataBoundItem as AuthUser); 
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            mApplicationController.CreateAuthUser();
        }

        private void btnDelUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                return;
            }
            mApplicationController.DeleteAuthUser(dgvUsers.SelectedRows[0].DataBoundItem as AuthUser);
        }

        private void dgvRoles_DoubleClick(object sender, EventArgs e)
        {
            if (dgvRoles.SelectedRows.Count == 0) return;
            mApplicationController.OpenAuthRole(dgvRoles.SelectedRows[0].DataBoundItem as AuthRole);
        }

        private void btnDeleteRole_Click(object sender, EventArgs e)
        {
            if (dgvRoles.SelectedRows.Count == 0) return;
            AuthRole role = dgvRoles.SelectedRows[0].DataBoundItem as AuthRole;
            mApplicationController.DeleteAuthRole(role);
        }

        private void btnCreateRole_Click(object sender, EventArgs e)
        {
            mApplicationController.CreateAuthRole();
        }
     }
}
