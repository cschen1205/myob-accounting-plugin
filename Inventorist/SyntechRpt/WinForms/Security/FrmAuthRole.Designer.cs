namespace SyntechRpt.WinForms.Security
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
            this.tpAuthItems = new System.Windows.Forms.TabPage();
            this.tvAuthItems = new System.Windows.Forms.TreeView();
            this.imgL = new System.Windows.Forms.ImageList(this.components);
            this.tpAuthRoles = new System.Windows.Forms.TabPage();
            this.tvAuthRoles = new System.Windows.Forms.TreeView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.tpAuthDetails = new System.Windows.Forms.TabPage();
            this.chkFullControl = new System.Windows.Forms.CheckBox();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.lblRoleName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.tc.SuspendLayout();
            this.tpAuthItems.SuspendLayout();
            this.tpAuthRoles.SuspendLayout();
            this.tpAuthDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc
            // 
            this.tc.Controls.Add(this.tpAuthDetails);
            this.tc.Controls.Add(this.tpAuthItems);
            this.tc.Controls.Add(this.tpAuthRoles);
            this.tc.Location = new System.Drawing.Point(12, 12);
            this.tc.Name = "tc";
            this.tc.SelectedIndex = 0;
            this.tc.Size = new System.Drawing.Size(608, 342);
            this.tc.TabIndex = 0;
            // 
            // tpAuthItems
            // 
            this.tpAuthItems.Controls.Add(this.tvAuthItems);
            this.tpAuthItems.Location = new System.Drawing.Point(4, 22);
            this.tpAuthItems.Name = "tpAuthItems";
            this.tpAuthItems.Padding = new System.Windows.Forms.Padding(3);
            this.tpAuthItems.Size = new System.Drawing.Size(600, 316);
            this.tpAuthItems.TabIndex = 0;
            this.tpAuthItems.Text = "Auth Items";
            this.tpAuthItems.UseVisualStyleBackColor = true;
            // 
            // tvAuthItems
            // 
            this.tvAuthItems.CheckBoxes = true;
            this.tvAuthItems.ImageIndex = 0;
            this.tvAuthItems.ImageList = this.imgL;
            this.tvAuthItems.Location = new System.Drawing.Point(6, 6);
            this.tvAuthItems.Name = "tvAuthItems";
            this.tvAuthItems.SelectedImageIndex = 0;
            this.tvAuthItems.Size = new System.Drawing.Size(588, 303);
            this.tvAuthItems.TabIndex = 0;
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
            // tpAuthRoles
            // 
            this.tpAuthRoles.Controls.Add(this.tvAuthRoles);
            this.tpAuthRoles.Location = new System.Drawing.Point(4, 22);
            this.tpAuthRoles.Name = "tpAuthRoles";
            this.tpAuthRoles.Padding = new System.Windows.Forms.Padding(3);
            this.tpAuthRoles.Size = new System.Drawing.Size(600, 316);
            this.tpAuthRoles.TabIndex = 1;
            this.tpAuthRoles.Text = "Auth Roles";
            this.tpAuthRoles.UseVisualStyleBackColor = true;
            // 
            // tvAuthRoles
            // 
            this.tvAuthRoles.CheckBoxes = true;
            this.tvAuthRoles.ImageIndex = 0;
            this.tvAuthRoles.ImageList = this.imgL;
            this.tvAuthRoles.Location = new System.Drawing.Point(6, 7);
            this.tvAuthRoles.Name = "tvAuthRoles";
            this.tvAuthRoles.SelectedImageIndex = 0;
            this.tvAuthRoles.Size = new System.Drawing.Size(588, 303);
            this.tvAuthRoles.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::SyntechRpt.Properties.Resources.cancel_record;
            this.btnClose.Location = new System.Drawing.Point(564, 356);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 56);
            this.btnClose.TabIndex = 92;
            this.btnClose.Text = "Cancel";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRecord
            // 
            this.btnRecord.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRecord.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecord.Image = global::SyntechRpt.Properties.Resources.save;
            this.btnRecord.Location = new System.Drawing.Point(499, 356);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(56, 56);
            this.btnRecord.TabIndex = 91;
            this.btnRecord.Text = "Record";
            this.btnRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRecord.UseVisualStyleBackColor = false;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
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
            this.tpAuthDetails.Size = new System.Drawing.Size(600, 316);
            this.tpAuthDetails.TabIndex = 2;
            this.tpAuthDetails.Text = "Auth Details";
            this.tpAuthDetails.UseVisualStyleBackColor = true;
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
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(92, 44);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(405, 175);
            this.txtDescription.TabIndex = 14;
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Location = new System.Drawing.Point(9, 367);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(419, 13);
            this.lblInstruction.TabIndex = 93;
            this.lblInstruction.Text = "The red color auth item represented item or action that currently not available t" +
                "o this role";
            // 
            // FrmAuthRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 417);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.tc);
            this.Name = "FrmAuthRole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmAuthRole";
            this.Load += new System.EventHandler(this.FrmAuthRole_Load);
            this.tc.ResumeLayout(false);
            this.tpAuthItems.ResumeLayout(false);
            this.tpAuthRoles.ResumeLayout(false);
            this.tpAuthDetails.ResumeLayout(false);
            this.tpAuthDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tc;
        private System.Windows.Forms.TabPage tpAuthItems;
        private System.Windows.Forms.TabPage tpAuthRoles;
        private System.Windows.Forms.TreeView tvAuthItems;
        private System.Windows.Forms.ImageList imgL;
        private System.Windows.Forms.TreeView tvAuthRoles;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.TabPage tpAuthDetails;
        private System.Windows.Forms.CheckBox chkFullControl;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.Label lblRoleName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblInstruction;
    }
}