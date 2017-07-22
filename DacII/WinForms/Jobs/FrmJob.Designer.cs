namespace DacII.WinForms.Jobs
{
    partial class FrmJob
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
            this.grpDetails = new System.Windows.Forms.CZRoundedGroupBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.dtpFinishDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.chkIsTrackingReimburseable = new System.Windows.Forms.CheckBox();
            this.chkIsHeader = new System.Windows.Forms.CheckBox();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.cboParentJob = new System.Windows.Forms.ComboBox();
            this.txtJobDescription = new System.Windows.Forms.TextBox();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.txtPercentCompleted = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblFinishDate = new System.Windows.Forms.Label();
            this.lblJobDescription = new System.Windows.Forms.Label();
            this.lblContactPerson = new System.Windows.Forms.Label();
            this.lblPercentCompleted = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblParentJob = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.txtManager = new System.Windows.Forms.TextBox();
            this.lblManager = new System.Windows.Forms.Label();
            this.txtJobNumber = new System.Windows.Forms.TextBox();
            this.lblJobNumber = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDetails
            // 
            this.grpDetails.BackgroundColor = System.Drawing.Color.White;
            this.grpDetails.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.grpDetails.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.grpDetails.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.grpDetails.BorderWidth = 1F;
            this.grpDetails.Caption = "Job Details";
            this.grpDetails.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.grpDetails.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.grpDetails.CaptionHeight = 25;
            this.grpDetails.CaptionVisible = true;
            this.grpDetails.Controls.Add(this.chkActive);
            this.grpDetails.Controls.Add(this.dtpFinishDate);
            this.grpDetails.Controls.Add(this.dtpStartDate);
            this.grpDetails.Controls.Add(this.chkIsTrackingReimburseable);
            this.grpDetails.Controls.Add(this.chkIsHeader);
            this.grpDetails.Controls.Add(this.cboCustomer);
            this.grpDetails.Controls.Add(this.cboParentJob);
            this.grpDetails.Controls.Add(this.txtJobDescription);
            this.grpDetails.Controls.Add(this.txtContactPerson);
            this.grpDetails.Controls.Add(this.txtPercentCompleted);
            this.grpDetails.Controls.Add(this.txtName);
            this.grpDetails.Controls.Add(this.lblFinishDate);
            this.grpDetails.Controls.Add(this.lblJobDescription);
            this.grpDetails.Controls.Add(this.lblContactPerson);
            this.grpDetails.Controls.Add(this.lblPercentCompleted);
            this.grpDetails.Controls.Add(this.lblCustomer);
            this.grpDetails.Controls.Add(this.lblName);
            this.grpDetails.Controls.Add(this.lblParentJob);
            this.grpDetails.Controls.Add(this.lblStartDate);
            this.grpDetails.Controls.Add(this.txtManager);
            this.grpDetails.Controls.Add(this.lblManager);
            this.grpDetails.Controls.Add(this.txtJobNumber);
            this.grpDetails.Controls.Add(this.lblJobNumber);
            this.grpDetails.CornerRadius = 5;
            this.grpDetails.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.grpDetails.DropShadowThickness = 3;
            this.grpDetails.DropShadowVisible = true;
            this.grpDetails.Location = new System.Drawing.Point(12, 12);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(605, 313);
            this.grpDetails.TabIndex = 9;
            this.grpDetails.TabStop = false;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.BackColor = System.Drawing.Color.Transparent;
            this.chkActive.Location = new System.Drawing.Point(309, 279);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 17);
            this.chkActive.TabIndex = 39;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = false;
            // 
            // dtpFinishDate
            // 
            this.dtpFinishDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinishDate.Location = new System.Drawing.Point(416, 167);
            this.dtpFinishDate.Name = "dtpFinishDate";
            this.dtpFinishDate.ShowCheckBox = true;
            this.dtpFinishDate.Size = new System.Drawing.Size(175, 20);
            this.dtpFinishDate.TabIndex = 38;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(416, 139);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.ShowCheckBox = true;
            this.dtpStartDate.Size = new System.Drawing.Size(175, 20);
            this.dtpStartDate.TabIndex = 38;
            // 
            // chkIsTrackingReimburseable
            // 
            this.chkIsTrackingReimburseable.AutoSize = true;
            this.chkIsTrackingReimburseable.BackColor = System.Drawing.Color.Transparent;
            this.chkIsTrackingReimburseable.Location = new System.Drawing.Point(309, 233);
            this.chkIsTrackingReimburseable.Name = "chkIsTrackingReimburseable";
            this.chkIsTrackingReimburseable.Size = new System.Drawing.Size(152, 17);
            this.chkIsTrackingReimburseable.TabIndex = 37;
            this.chkIsTrackingReimburseable.Text = "Is Tracking Reimburseable";
            this.chkIsTrackingReimburseable.UseVisualStyleBackColor = false;
            // 
            // chkIsHeader
            // 
            this.chkIsHeader.AutoSize = true;
            this.chkIsHeader.BackColor = System.Drawing.Color.Transparent;
            this.chkIsHeader.Location = new System.Drawing.Point(309, 256);
            this.chkIsHeader.Name = "chkIsHeader";
            this.chkIsHeader.Size = new System.Drawing.Size(72, 17);
            this.chkIsHeader.TabIndex = 37;
            this.chkIsHeader.Text = "Is Header";
            this.chkIsHeader.UseVisualStyleBackColor = false;
            // 
            // cboCustomer
            // 
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(106, 84);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(190, 21);
            this.cboCustomer.TabIndex = 30;
            // 
            // cboParentJob
            // 
            this.cboParentJob.FormattingEnabled = true;
            this.cboParentJob.Location = new System.Drawing.Point(416, 86);
            this.cboParentJob.Name = "cboParentJob";
            this.cboParentJob.Size = new System.Drawing.Size(175, 21);
            this.cboParentJob.TabIndex = 31;
            // 
            // txtJobDescription
            // 
            this.txtJobDescription.Location = new System.Drawing.Point(11, 143);
            this.txtJobDescription.Multiline = true;
            this.txtJobDescription.Name = "txtJobDescription";
            this.txtJobDescription.Size = new System.Drawing.Size(285, 153);
            this.txtJobDescription.TabIndex = 27;
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Location = new System.Drawing.Point(416, 193);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(175, 20);
            this.txtContactPerson.TabIndex = 26;
            // 
            // txtPercentCompleted
            // 
            this.txtPercentCompleted.Location = new System.Drawing.Point(416, 58);
            this.txtPercentCompleted.Name = "txtPercentCompleted";
            this.txtPercentCompleted.Size = new System.Drawing.Size(175, 20);
            this.txtPercentCompleted.TabIndex = 24;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(106, 58);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(190, 20);
            this.txtName.TabIndex = 25;
            // 
            // lblFinishDate
            // 
            this.lblFinishDate.AutoSize = true;
            this.lblFinishDate.BackColor = System.Drawing.Color.Transparent;
            this.lblFinishDate.Location = new System.Drawing.Point(306, 169);
            this.lblFinishDate.Name = "lblFinishDate";
            this.lblFinishDate.Size = new System.Drawing.Size(63, 13);
            this.lblFinishDate.TabIndex = 8;
            this.lblFinishDate.Text = "Finish Date:";
            // 
            // lblJobDescription
            // 
            this.lblJobDescription.AutoSize = true;
            this.lblJobDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblJobDescription.Location = new System.Drawing.Point(8, 118);
            this.lblJobDescription.Name = "lblJobDescription";
            this.lblJobDescription.Size = new System.Drawing.Size(80, 13);
            this.lblJobDescription.TabIndex = 9;
            this.lblJobDescription.Text = "Job Description";
            // 
            // lblContactPerson
            // 
            this.lblContactPerson.AutoSize = true;
            this.lblContactPerson.BackColor = System.Drawing.Color.Transparent;
            this.lblContactPerson.Location = new System.Drawing.Point(306, 196);
            this.lblContactPerson.Name = "lblContactPerson";
            this.lblContactPerson.Size = new System.Drawing.Size(80, 13);
            this.lblContactPerson.TabIndex = 18;
            this.lblContactPerson.Text = "Contact Person";
            // 
            // lblPercentCompleted
            // 
            this.lblPercentCompleted.AutoSize = true;
            this.lblPercentCompleted.BackColor = System.Drawing.Color.Transparent;
            this.lblPercentCompleted.Location = new System.Drawing.Point(306, 61);
            this.lblPercentCompleted.Name = "lblPercentCompleted";
            this.lblPercentCompleted.Size = new System.Drawing.Size(97, 13);
            this.lblPercentCompleted.TabIndex = 5;
            this.lblPercentCompleted.Text = "Percent Completed";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomer.Location = new System.Drawing.Point(8, 88);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(51, 13);
            this.lblCustomer.TabIndex = 15;
            this.lblCustomer.Text = "Customer";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Location = new System.Drawing.Point(8, 61);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 16;
            this.lblName.Text = "Name";
            // 
            // lblParentJob
            // 
            this.lblParentJob.AutoSize = true;
            this.lblParentJob.BackColor = System.Drawing.Color.Transparent;
            this.lblParentJob.Location = new System.Drawing.Point(306, 91);
            this.lblParentJob.Name = "lblParentJob";
            this.lblParentJob.Size = new System.Drawing.Size(55, 13);
            this.lblParentJob.TabIndex = 17;
            this.lblParentJob.Text = "Sub-job of";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.BackColor = System.Drawing.Color.Transparent;
            this.lblStartDate.Location = new System.Drawing.Point(306, 143);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(58, 13);
            this.lblStartDate.TabIndex = 13;
            this.lblStartDate.Text = "Start Date:";
            // 
            // txtManager
            // 
            this.txtManager.Location = new System.Drawing.Point(416, 32);
            this.txtManager.Name = "txtManager";
            this.txtManager.Size = new System.Drawing.Size(175, 20);
            this.txtManager.TabIndex = 21;
            // 
            // lblManager
            // 
            this.lblManager.AutoSize = true;
            this.lblManager.BackColor = System.Drawing.Color.Transparent;
            this.lblManager.Location = new System.Drawing.Point(306, 35);
            this.lblManager.Name = "lblManager";
            this.lblManager.Size = new System.Drawing.Size(49, 13);
            this.lblManager.TabIndex = 14;
            this.lblManager.Text = "Manager";
            // 
            // txtJobNumber
            // 
            this.txtJobNumber.Location = new System.Drawing.Point(106, 32);
            this.txtJobNumber.Name = "txtJobNumber";
            this.txtJobNumber.Size = new System.Drawing.Size(190, 20);
            this.txtJobNumber.TabIndex = 20;
            // 
            // lblJobNumber
            // 
            this.lblJobNumber.AutoSize = true;
            this.lblJobNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblJobNumber.Location = new System.Drawing.Point(8, 35);
            this.lblJobNumber.Name = "lblJobNumber";
            this.lblJobNumber.Size = new System.Drawing.Size(38, 13);
            this.lblJobNumber.TabIndex = 10;
            this.lblJobNumber.Text = "Job ID";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DacII.Properties.Resources.cancel_24x24;
            this.btnClose.Location = new System.Drawing.Point(561, 331);
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
            this.btnRecord.Image = global::DacII.Properties.Resources.save_32x32;
            this.btnRecord.Location = new System.Drawing.Point(499, 331);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(56, 56);
            this.btnRecord.TabIndex = 91;
            this.btnRecord.Text = "Record";
            this.btnRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRecord.UseVisualStyleBackColor = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FrmJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(629, 400);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.btnRecord);
            this.Name = "FrmJob";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Job";
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CZRoundedGroupBox grpDetails;
        private System.Windows.Forms.DateTimePicker dtpFinishDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.CheckBox chkIsTrackingReimburseable;
        private System.Windows.Forms.CheckBox chkIsHeader;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.ComboBox cboParentJob;
        private System.Windows.Forms.TextBox txtJobDescription;
        private System.Windows.Forms.TextBox txtContactPerson;
        private System.Windows.Forms.TextBox txtPercentCompleted;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblFinishDate;
        private System.Windows.Forms.Label lblJobDescription;
        private System.Windows.Forms.Label lblContactPerson;
        private System.Windows.Forms.Label lblPercentCompleted;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblParentJob;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.TextBox txtManager;
        private System.Windows.Forms.Label lblManager;
        private System.Windows.Forms.TextBox txtJobNumber;
        private System.Windows.Forms.Label lblJobNumber;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}