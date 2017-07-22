namespace SyntechRpt.WinForms.Security
{
    partial class FrmSecurity
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSecurity));
            this.imglist = new System.Windows.Forms.ImageList(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRebuild = new System.Windows.Forms.Button();
            this.tc = new System.Windows.Forms.TabControl();
            this.tpAuthUser = new System.Windows.Forms.TabPage();
            this.btnDelUser = new System.Windows.Forms.Button();
            this.btnCreateUser = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.tpAuthRole = new System.Windows.Forms.TabPage();
            this.btnDeleteRole = new System.Windows.Forms.Button();
            this.btnCreateRole = new System.Windows.Forms.Button();
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.tc.SuspendLayout();
            this.tpAuthUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.tpAuthRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // imglist
            // 
            this.imglist.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglist.ImageStream")));
            this.imglist.TransparentColor = System.Drawing.Color.Transparent;
            this.imglist.Images.SetKeyName(0, "hCard.png");
            this.imglist.Images.SetKeyName(1, "Phone-icon.png");
            this.imglist.Images.SetKeyName(2, "del.png");
            this.imglist.Images.SetKeyName(3, "add.png");
            this.imglist.Images.SetKeyName(4, "edit.gif");
            this.imglist.Images.SetKeyName(5, "big_green_tick_icon.png");
            this.imglist.Images.SetKeyName(6, "120px-Octagon_delete.svg.png");
            this.imglist.Images.SetKeyName(7, "images.jpg");
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRebuild
            // 
            this.btnRebuild.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnRebuild, "btnRebuild");
            this.btnRebuild.Name = "btnRebuild";
            this.btnRebuild.UseVisualStyleBackColor = true;
            this.btnRebuild.Click += new System.EventHandler(this.btnRebuild_Click);
            // 
            // tc
            // 
            this.tc.Controls.Add(this.tpAuthUser);
            this.tc.Controls.Add(this.tpAuthRole);
            resources.ApplyResources(this.tc, "tc");
            this.tc.Name = "tc";
            this.tc.SelectedIndex = 0;
            // 
            // tpAuthUser
            // 
            this.tpAuthUser.Controls.Add(this.btnDelUser);
            this.tpAuthUser.Controls.Add(this.btnCreateUser);
            this.tpAuthUser.Controls.Add(this.dgvUsers);
            resources.ApplyResources(this.tpAuthUser, "tpAuthUser");
            this.tpAuthUser.Name = "tpAuthUser";
            this.tpAuthUser.UseVisualStyleBackColor = true;
            // 
            // btnDelUser
            // 
            resources.ApplyResources(this.btnDelUser, "btnDelUser");
            this.btnDelUser.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelUser.Image = global::SyntechRpt.Properties.Resources.delete_line;
            this.btnDelUser.Name = "btnDelUser";
            this.btnDelUser.UseVisualStyleBackColor = false;
            this.btnDelUser.Click += new System.EventHandler(this.btnDelUser_Click);
            // 
            // btnCreateUser
            // 
            resources.ApplyResources(this.btnCreateUser, "btnCreateUser");
            this.btnCreateUser.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCreateUser.Image = global::SyntechRpt.Properties.Resources.new_line;
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.UseVisualStyleBackColor = false;
            this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgvUsers, "dgvUsers");
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.DoubleClick += new System.EventHandler(this.dgvUsers_DoubleClick);
            // 
            // tpAuthRole
            // 
            this.tpAuthRole.Controls.Add(this.btnDeleteRole);
            this.tpAuthRole.Controls.Add(this.btnCreateRole);
            this.tpAuthRole.Controls.Add(this.dgvRoles);
            resources.ApplyResources(this.tpAuthRole, "tpAuthRole");
            this.tpAuthRole.Name = "tpAuthRole";
            this.tpAuthRole.UseVisualStyleBackColor = true;
            // 
            // btnDeleteRole
            // 
            resources.ApplyResources(this.btnDeleteRole, "btnDeleteRole");
            this.btnDeleteRole.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteRole.Image = global::SyntechRpt.Properties.Resources.delete_line;
            this.btnDeleteRole.Name = "btnDeleteRole";
            this.btnDeleteRole.UseVisualStyleBackColor = false;
            this.btnDeleteRole.Click += new System.EventHandler(this.btnDeleteRole_Click);
            // 
            // btnCreateRole
            // 
            resources.ApplyResources(this.btnCreateRole, "btnCreateRole");
            this.btnCreateRole.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCreateRole.Image = global::SyntechRpt.Properties.Resources.new_line;
            this.btnCreateRole.Name = "btnCreateRole";
            this.btnCreateRole.UseVisualStyleBackColor = false;
            this.btnCreateRole.Click += new System.EventHandler(this.btnCreateRole_Click);
            // 
            // dgvRoles
            // 
            this.dgvRoles.AllowUserToAddRows = false;
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgvRoles, "dgvRoles");
            this.dgvRoles.MultiSelect = false;
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoles.DoubleClick += new System.EventHandler(this.dgvRoles_DoubleClick);
            // 
            // FrmSecurity
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tc);
            this.Controls.Add(this.btnRebuild);
            this.Controls.Add(this.btnCancel);
            this.Name = "FrmSecurity";
            this.Load += new System.EventHandler(this.frmSecurity_Load);
            this.tc.ResumeLayout(false);
            this.tpAuthUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.tpAuthRole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imglist;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRebuild;
        private System.Windows.Forms.TabControl tc;
        private System.Windows.Forms.TabPage tpAuthUser;
        private System.Windows.Forms.TabPage tpAuthRole;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.Button btnDelUser;
        private System.Windows.Forms.Button btnCreateUser;
        private System.Windows.Forms.Button btnDeleteRole;
        private System.Windows.Forms.Button btnCreateRole;
    }
}