namespace DacII.WinForms.Security
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imglist = new System.Windows.Forms.ImageList(this.components);
            this.tc = new System.Windows.Forms.TabControl();
            this.tpAuthUser = new System.Windows.Forms.TabPage();
            this.btnPrintUsers = new System.Windows.Forms.VistaButton();
            this.btnDelUser = new System.Windows.Forms.VistaButton();
            this.btnCreateUser = new System.Windows.Forms.VistaButton();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.tpAuthRole = new System.Windows.Forms.TabPage();
            this.btnPrintRoles = new System.Windows.Forms.VistaButton();
            this.btnDeleteRole = new System.Windows.Forms.VistaButton();
            this.btnCreateRole = new System.Windows.Forms.VistaButton();
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.gbFilter = new System.Windows.Forms.CZRoundedGroupBox();
            this.chkAllCustomers = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.tc.SuspendLayout();
            this.tpAuthUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.tpAuthRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.gbFilter.SuspendLayout();
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
            // tc
            // 
            resources.ApplyResources(this.tc, "tc");
            this.tc.Controls.Add(this.tpAuthUser);
            this.tc.Controls.Add(this.tpAuthRole);
            this.tc.HotTrack = true;
            this.tc.Name = "tc";
            this.tc.SelectedIndex = 0;
            // 
            // tpAuthUser
            // 
            this.tpAuthUser.Controls.Add(this.btnPrintUsers);
            this.tpAuthUser.Controls.Add(this.btnDelUser);
            this.tpAuthUser.Controls.Add(this.btnCreateUser);
            this.tpAuthUser.Controls.Add(this.dgvUsers);
            resources.ApplyResources(this.tpAuthUser, "tpAuthUser");
            this.tpAuthUser.Name = "tpAuthUser";
            this.tpAuthUser.UseVisualStyleBackColor = true;
            // 
            // btnPrintUsers
            // 
            resources.ApplyResources(this.btnPrintUsers, "btnPrintUsers");
            this.btnPrintUsers.BackColor = System.Drawing.Color.Transparent;
            this.btnPrintUsers.BaseColor = System.Drawing.Color.SteelBlue;
            this.btnPrintUsers.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnPrintUsers.ButtonText = "Print Users";
            this.btnPrintUsers.CornerRadius = 16;
            this.btnPrintUsers.Image = global::DacII.Properties.Resources.print_32x32;
            this.btnPrintUsers.Name = "btnPrintUsers";
            // 
            // btnDelUser
            // 
            resources.ApplyResources(this.btnDelUser, "btnDelUser");
            this.btnDelUser.BackColor = System.Drawing.Color.Transparent;
            this.btnDelUser.BaseColor = System.Drawing.Color.SteelBlue;
            this.btnDelUser.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnDelUser.ButtonText = "Del User";
            this.btnDelUser.CornerRadius = 16;
            this.btnDelUser.Image = global::DacII.Properties.Resources.delete_24x24;
            this.btnDelUser.Name = "btnDelUser";
            this.btnDelUser.Click += new System.EventHandler(this.btnDelUser_Click);
            // 
            // btnCreateUser
            // 
            resources.ApplyResources(this.btnCreateUser, "btnCreateUser");
            this.btnCreateUser.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateUser.BaseColor = System.Drawing.Color.SteelBlue;
            this.btnCreateUser.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnCreateUser.ButtonText = "Create User";
            this.btnCreateUser.CornerRadius = 16;
            this.btnCreateUser.Image = global::DacII.Properties.Resources.new_16x16;
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.dgvUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.dgvUsers, "dgvUsers");
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsers.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.DoubleClick += new System.EventHandler(this.dgvUsers_DoubleClick);
            // 
            // tpAuthRole
            // 
            this.tpAuthRole.Controls.Add(this.btnPrintRoles);
            this.tpAuthRole.Controls.Add(this.btnDeleteRole);
            this.tpAuthRole.Controls.Add(this.btnCreateRole);
            this.tpAuthRole.Controls.Add(this.dgvRoles);
            resources.ApplyResources(this.tpAuthRole, "tpAuthRole");
            this.tpAuthRole.Name = "tpAuthRole";
            this.tpAuthRole.UseVisualStyleBackColor = true;
            // 
            // btnPrintRoles
            // 
            resources.ApplyResources(this.btnPrintRoles, "btnPrintRoles");
            this.btnPrintRoles.BackColor = System.Drawing.Color.Transparent;
            this.btnPrintRoles.BaseColor = System.Drawing.Color.SteelBlue;
            this.btnPrintRoles.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnPrintRoles.ButtonText = "Print Roles";
            this.btnPrintRoles.CornerRadius = 16;
            this.btnPrintRoles.Image = global::DacII.Properties.Resources.print_32x32;
            this.btnPrintRoles.Name = "btnPrintRoles";
            // 
            // btnDeleteRole
            // 
            resources.ApplyResources(this.btnDeleteRole, "btnDeleteRole");
            this.btnDeleteRole.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteRole.BaseColor = System.Drawing.Color.SteelBlue;
            this.btnDeleteRole.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnDeleteRole.ButtonText = "Del Role";
            this.btnDeleteRole.CornerRadius = 16;
            this.btnDeleteRole.Image = global::DacII.Properties.Resources.delete_24x24;
            this.btnDeleteRole.Name = "btnDeleteRole";
            this.btnDeleteRole.Click += new System.EventHandler(this.btnDeleteRole_Click);
            // 
            // btnCreateRole
            // 
            resources.ApplyResources(this.btnCreateRole, "btnCreateRole");
            this.btnCreateRole.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateRole.BaseColor = System.Drawing.Color.SteelBlue;
            this.btnCreateRole.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnCreateRole.ButtonText = "Create Role";
            this.btnCreateRole.CornerRadius = 16;
            this.btnCreateRole.Image = global::DacII.Properties.Resources.new_16x16;
            this.btnCreateRole.Name = "btnCreateRole";
            this.btnCreateRole.Click += new System.EventHandler(this.btnCreateRole_Click);
            // 
            // dgvRoles
            // 
            this.dgvRoles.AllowUserToAddRows = false;
            this.dgvRoles.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.dgvRoles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.dgvRoles, "dgvRoles");
            this.dgvRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRoles.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRoles.MultiSelect = false;
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.RowHeadersVisible = false;
            this.dgvRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoles.DoubleClick += new System.EventHandler(this.dgvRoles_DoubleClick);
            // 
            // gbFilter
            // 
            resources.ApplyResources(this.gbFilter, "gbFilter");
            this.gbFilter.BackgroundColor = System.Drawing.Color.White;
            this.gbFilter.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbFilter.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbFilter.BorderWidth = 1F;
            this.gbFilter.Caption = "Security Manager";
            this.gbFilter.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbFilter.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbFilter.CaptionHeight = 25;
            this.gbFilter.CaptionVisible = true;
            this.gbFilter.Controls.Add(this.tc);
            this.gbFilter.Controls.Add(this.chkAllCustomers);
            this.gbFilter.Controls.Add(this.btnClose);
            this.gbFilter.CornerRadius = 5;
            this.gbFilter.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)));
            this.gbFilter.DropShadowThickness = 3;
            this.gbFilter.DropShadowVisible = false;
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.TabStop = false;
            // 
            // chkAllCustomers
            // 
            resources.ApplyResources(this.chkAllCustomers, "chkAllCustomers");
            this.chkAllCustomers.BackColor = System.Drawing.Color.Transparent;
            this.chkAllCustomers.FlatAppearance.BorderSize = 0;
            this.chkAllCustomers.Name = "chkAllCustomers";
            this.chkAllCustomers.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.BackgroundImage = global::DacII.Properties.Resources.cancel_16x16;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmSecurity
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.Controls.Add(this.gbFilter);
            this.Name = "FrmSecurity";
            this.tc.ResumeLayout(false);
            this.tpAuthUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.tpAuthRole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imglist;
        private System.Windows.Forms.TabControl tc;
        private System.Windows.Forms.TabPage tpAuthUser;
        private System.Windows.Forms.TabPage tpAuthRole;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.VistaButton btnDelUser;
        private System.Windows.Forms.VistaButton btnCreateUser;
        private System.Windows.Forms.VistaButton btnDeleteRole;
        private System.Windows.Forms.VistaButton btnCreateRole;
        private System.Windows.Forms.CZRoundedGroupBox gbFilter;
        private System.Windows.Forms.VistaButton btnPrintUsers;
        private System.Windows.Forms.CheckBox chkAllCustomers;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.VistaButton btnPrintRoles;
    }
}