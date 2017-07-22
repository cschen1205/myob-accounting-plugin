namespace DacII.WinForms.Security
{
    partial class FrmAuthRole 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAuthRole));
            this.tc = new System.Windows.Forms.TabControl();
            this.tpAuthDetails = new System.Windows.Forms.TabPage();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.lblRoleName = new System.Windows.Forms.Label();
            this.chkFullControl = new System.Windows.Forms.CheckBox();
            this.tpAuthItems = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tgvAuthItems = new AdvancedDataGridView.TreeGridView();
            this.ColAuthItemName = new AdvancedDataGridView.TreeGridColumn();
            this.ColAuthItemEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColAuthItemVisible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColViewAll = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tpAuthRoles = new System.Windows.Forms.TabPage();
            this.tvAuthRoles = new System.Windows.Forms.TreeView();
            this.imgL = new System.Windows.Forms.ImageList(this.components);
            this.btnRecord = new System.Windows.Forms.Button();
            this.gbFilter = new System.Windows.Forms.CZRoundedGroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.chkAllCustomers = new System.Windows.Forms.CheckBox();
            this.btnClose2 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tc.SuspendLayout();
            this.tpAuthDetails.SuspendLayout();
            this.tpAuthItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgvAuthItems)).BeginInit();
            this.tpAuthRoles.SuspendLayout();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc
            // 
            this.tc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tc.Controls.Add(this.tpAuthDetails);
            this.tc.Controls.Add(this.tpAuthItems);
            this.tc.Controls.Add(this.tpAuthRoles);
            this.tc.HotTrack = true;
            this.tc.Location = new System.Drawing.Point(6, 32);
            this.tc.Name = "tc";
            this.tc.SelectedIndex = 0;
            this.tc.Size = new System.Drawing.Size(594, 334);
            this.tc.TabIndex = 0;
            // 
            // tpAuthDetails
            // 
            this.tpAuthDetails.Controls.Add(this.txtDescription);
            this.tpAuthDetails.Controls.Add(this.lblDescription);
            this.tpAuthDetails.Controls.Add(this.txtRoleName);
            this.tpAuthDetails.Controls.Add(this.lblRoleName);
            this.tpAuthDetails.Controls.Add(this.chkFullControl);
            this.tpAuthDetails.Location = new System.Drawing.Point(4, 22);
            this.tpAuthDetails.Name = "tpAuthDetails";
            this.tpAuthDetails.Size = new System.Drawing.Size(586, 308);
            this.tpAuthDetails.TabIndex = 2;
            this.tpAuthDetails.Text = "Auth Details";
            this.tpAuthDetails.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(92, 44);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(405, 175);
            this.txtDescription.TabIndex = 14;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lblDescription.ForeColor = System.Drawing.Color.Black;
            this.lblDescription.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDescription.Location = new System.Drawing.Point(12, 45);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(77, 16);
            this.lblDescription.TabIndex = 13;
            this.lblDescription.Text = "Description:";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(92, 18);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(177, 20);
            this.txtRoleName.TabIndex = 14;
            // 
            // lblRoleName
            // 
            this.lblRoleName.AutoSize = true;
            this.lblRoleName.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lblRoleName.ForeColor = System.Drawing.Color.Black;
            this.lblRoleName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRoleName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRoleName.Location = new System.Drawing.Point(12, 19);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.Size = new System.Drawing.Size(74, 16);
            this.lblRoleName.TabIndex = 13;
            this.lblRoleName.Text = "Role name:";
            this.lblRoleName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkFullControl
            // 
            this.chkFullControl.AutoSize = true;
            this.chkFullControl.Location = new System.Drawing.Point(92, 225);
            this.chkFullControl.Name = "chkFullControl";
            this.chkFullControl.Size = new System.Drawing.Size(78, 17);
            this.chkFullControl.TabIndex = 0;
            this.chkFullControl.Text = "Full Control";
            this.chkFullControl.UseVisualStyleBackColor = true;
            this.chkFullControl.CheckedChanged += new System.EventHandler(this.chkFullControl_CheckedChanged);
            // 
            // tpAuthItems
            // 
            this.tpAuthItems.Controls.Add(this.label1);
            this.tpAuthItems.Controls.Add(this.tgvAuthItems);
            this.tpAuthItems.Location = new System.Drawing.Point(4, 22);
            this.tpAuthItems.Name = "tpAuthItems";
            this.tpAuthItems.Padding = new System.Windows.Forms.Padding(3);
            this.tpAuthItems.Size = new System.Drawing.Size(586, 308);
            this.tpAuthItems.TabIndex = 0;
            this.tpAuthItems.Text = "Auth Items";
            this.tpAuthItems.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Press F2 and click on the cell to check or uncheck an option";
            // 
            // tgvAuthItems
            // 
            this.tgvAuthItems.AllowUserToAddRows = false;
            this.tgvAuthItems.AllowUserToDeleteRows = false;
            this.tgvAuthItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tgvAuthItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tgvAuthItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColAuthItemName,
            this.ColAuthItemEnabled,
            this.ColAuthItemVisible,
            this.ColViewAll});
            this.tgvAuthItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tgvAuthItems.ImageList = null;
            this.tgvAuthItems.Location = new System.Drawing.Point(6, 25);
            this.tgvAuthItems.Name = "tgvAuthItems";
            this.tgvAuthItems.RowHeadersVisible = false;
            this.tgvAuthItems.Size = new System.Drawing.Size(581, 277);
            this.tgvAuthItems.TabIndex = 0;
            // 
            // ColAuthItemName
            // 
            this.ColAuthItemName.DefaultNodeImage = null;
            this.ColAuthItemName.HeaderText = "AuthItem";
            this.ColAuthItemName.Name = "ColAuthItemName";
            this.ColAuthItemName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColAuthItemEnabled
            // 
            this.ColAuthItemEnabled.HeaderText = "Enabled";
            this.ColAuthItemEnabled.Name = "ColAuthItemEnabled";
            // 
            // ColAuthItemVisible
            // 
            this.ColAuthItemVisible.HeaderText = "Visible";
            this.ColAuthItemVisible.Name = "ColAuthItemVisible";
            // 
            // ColViewAll
            // 
            this.ColViewAll.HeaderText = "ViewAll";
            this.ColViewAll.Name = "ColViewAll";
            // 
            // tpAuthRoles
            // 
            this.tpAuthRoles.Controls.Add(this.tvAuthRoles);
            this.tpAuthRoles.Location = new System.Drawing.Point(4, 22);
            this.tpAuthRoles.Name = "tpAuthRoles";
            this.tpAuthRoles.Padding = new System.Windows.Forms.Padding(3);
            this.tpAuthRoles.Size = new System.Drawing.Size(586, 308);
            this.tpAuthRoles.TabIndex = 1;
            this.tpAuthRoles.Text = "Auth Roles";
            this.tpAuthRoles.UseVisualStyleBackColor = true;
            // 
            // tvAuthRoles
            // 
            this.tvAuthRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvAuthRoles.CheckBoxes = true;
            this.tvAuthRoles.ImageIndex = 0;
            this.tvAuthRoles.ImageList = this.imgL;
            this.tvAuthRoles.Location = new System.Drawing.Point(6, 7);
            this.tvAuthRoles.Name = "tvAuthRoles";
            this.tvAuthRoles.SelectedImageIndex = 0;
            this.tvAuthRoles.Size = new System.Drawing.Size(565, 289);
            this.tvAuthRoles.TabIndex = 1;
            // 
            // imgL
            // 
            this.imgL.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgL.ImageStream")));
            this.imgL.TransparentColor = System.Drawing.Color.Transparent;
            this.imgL.Images.SetKeyName(0, "update(16x16).png");
            this.imgL.Images.SetKeyName(1, "create(16x16).png");
            this.imgL.Images.SetKeyName(2, "delete(16x16).png");
            this.imgL.Images.SetKeyName(3, "read(16x16).png");
            this.imgL.Images.SetKeyName(4, "access(16x16).png");
            this.imgL.Images.SetKeyName(5, "index(16x16).png");
            // 
            // btnRecord
            // 
            this.btnRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecord.BackgroundImage = global::DacII.Properties.Resources.save_32x32;
            this.btnRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRecord.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRecord.Location = new System.Drawing.Point(526, 371);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(32, 32);
            this.btnRecord.TabIndex = 91;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // gbFilter
            // 
            this.gbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFilter.BackgroundColor = System.Drawing.Color.White;
            this.gbFilter.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbFilter.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbFilter.BorderWidth = 1F;
            this.gbFilter.Caption = "Authorization Role";
            this.gbFilter.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbFilter.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbFilter.CaptionHeight = 25;
            this.gbFilter.CaptionVisible = true;
            this.gbFilter.Controls.Add(this.btnPrint);
            this.gbFilter.Controls.Add(this.tc);
            this.gbFilter.Controls.Add(this.chkAllCustomers);
            this.gbFilter.Controls.Add(this.btnRecord);
            this.gbFilter.Controls.Add(this.btnClose2);
            this.gbFilter.Controls.Add(this.btnClose);
            this.gbFilter.CornerRadius = 5;
            this.gbFilter.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbFilter.DropShadowThickness = 3;
            this.gbFilter.DropShadowVisible = false;
            this.gbFilter.Location = new System.Drawing.Point(6, 7);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(603, 410);
            this.gbFilter.TabIndex = 93;
            this.gbFilter.TabStop = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrint.Location = new System.Drawing.Point(488, 371);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(32, 32);
            this.btnPrint.TabIndex = 92;
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // chkAllCustomers
            // 
            this.chkAllCustomers.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAllCustomers.AutoSize = true;
            this.chkAllCustomers.BackColor = System.Drawing.Color.Transparent;
            this.chkAllCustomers.FlatAppearance.BorderSize = 0;
            this.chkAllCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAllCustomers.ImageIndex = 0;
            this.chkAllCustomers.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkAllCustomers.Location = new System.Drawing.Point(308, 35);
            this.chkAllCustomers.Name = "chkAllCustomers";
            this.chkAllCustomers.Size = new System.Drawing.Size(6, 6);
            this.chkAllCustomers.TabIndex = 14;
            this.chkAllCustomers.UseVisualStyleBackColor = false;
            // 
            // btnClose2
            // 
            this.btnClose2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose2.BackgroundImage = global::DacII.Properties.Resources.cancel_16x16;
            this.btnClose2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose2.FlatAppearance.BorderSize = 0;
            this.btnClose2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose2.Location = new System.Drawing.Point(580, 5);
            this.btnClose2.Name = "btnClose2";
            this.btnClose2.Size = new System.Drawing.Size(16, 16);
            this.btnClose2.TabIndex = 91;
            this.btnClose2.UseVisualStyleBackColor = false;
            this.btnClose2.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.BackgroundImage = global::DacII.Properties.Resources.cancel_16x16;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(564, 371);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 32);
            this.btnClose.TabIndex = 91;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmAuthRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(612, 429);
            this.Controls.Add(this.gbFilter);
            this.Name = "FrmAuthRole";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Authorization Role";
            this.tc.ResumeLayout(false);
            this.tpAuthDetails.ResumeLayout(false);
            this.tpAuthDetails.PerformLayout();
            this.tpAuthItems.ResumeLayout(false);
            this.tpAuthItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgvAuthItems)).EndInit();
            this.tpAuthRoles.ResumeLayout(false);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tc;
        private System.Windows.Forms.TabPage tpAuthItems;
        private System.Windows.Forms.TabPage tpAuthRoles;
        private System.Windows.Forms.ImageList imgL;
        private System.Windows.Forms.TreeView tvAuthRoles;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.TabPage tpAuthDetails;
        private System.Windows.Forms.CheckBox chkFullControl;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.Label lblRoleName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private AdvancedDataGridView.TreeGridView tgvAuthItems;
        private AdvancedDataGridView.TreeGridColumn ColAuthItemName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColAuthItemEnabled;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColAuthItemVisible;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColViewAll;
        private System.Windows.Forms.CZRoundedGroupBox gbFilter;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.CheckBox chkAllCustomers;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClose2;
        private System.Windows.Forms.Label label1;
    }
}