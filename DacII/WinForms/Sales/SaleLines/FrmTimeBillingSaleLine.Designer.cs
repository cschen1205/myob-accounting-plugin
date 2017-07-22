namespace DacII.WinForms.Sales.SaleLines
{
    partial class FrmTimeBillingSaleLine
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
            this.gbTimeBillingSaleLine = new System.Windows.Forms.CZRoundedGroupBox();
            this.dtpLineDate = new System.Windows.Forms.DateTimePicker();
            this.lblLineDate = new System.Windows.Forms.Label();
            this.cboJob = new System.Windows.Forms.ComboBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblJob = new System.Windows.Forms.Label();
            this.cboLocation = new System.Windows.Forms.ComboBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.cboActivity = new System.Windows.Forms.ComboBox();
            this.lblActivity = new System.Windows.Forms.Label();
            this.cboTax = new System.Windows.Forms.ComboBox();
            this.lblTax = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblRate = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.lblHoursUnits = new System.Windows.Forms.Label();
            this.txtHoursUnits = new System.Windows.Forms.TextBox();
            this.gb2 = new System.Windows.Forms.CZRoundedGroupBox();
            this.txtEstimatedCost = new System.Windows.Forms.TextBox();
            this.lblEstimatedCost = new System.Windows.Forms.Label();
            this.gbTimeBillingSaleLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.gb2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTimeBillingSaleLine
            // 
            this.gbTimeBillingSaleLine.BackgroundColor = System.Drawing.Color.White;
            this.gbTimeBillingSaleLine.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbTimeBillingSaleLine.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbTimeBillingSaleLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbTimeBillingSaleLine.BorderWidth = 1F;
            this.gbTimeBillingSaleLine.Caption = "Sale Line Detalis";
            this.gbTimeBillingSaleLine.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbTimeBillingSaleLine.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbTimeBillingSaleLine.CaptionHeight = 25;
            this.gbTimeBillingSaleLine.CaptionVisible = true;
            this.gbTimeBillingSaleLine.Controls.Add(this.dtpLineDate);
            this.gbTimeBillingSaleLine.Controls.Add(this.lblLineDate);
            this.gbTimeBillingSaleLine.Controls.Add(this.cboJob);
            this.gbTimeBillingSaleLine.Controls.Add(this.txtNotes);
            this.gbTimeBillingSaleLine.Controls.Add(this.lblJob);
            this.gbTimeBillingSaleLine.Controls.Add(this.cboLocation);
            this.gbTimeBillingSaleLine.Controls.Add(this.lblLocation);
            this.gbTimeBillingSaleLine.Controls.Add(this.lblNotes);
            this.gbTimeBillingSaleLine.Controls.Add(this.cboActivity);
            this.gbTimeBillingSaleLine.Controls.Add(this.lblActivity);
            this.gbTimeBillingSaleLine.CornerRadius = 5;
            this.gbTimeBillingSaleLine.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbTimeBillingSaleLine.DropShadowThickness = 3;
            this.gbTimeBillingSaleLine.DropShadowVisible = true;
            this.gbTimeBillingSaleLine.Location = new System.Drawing.Point(12, 12);
            this.gbTimeBillingSaleLine.Name = "gbTimeBillingSaleLine";
            this.gbTimeBillingSaleLine.Size = new System.Drawing.Size(356, 264);
            this.gbTimeBillingSaleLine.TabIndex = 6;
            this.gbTimeBillingSaleLine.TabStop = false;
            // 
            // dtpLineDate
            // 
            this.dtpLineDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLineDate.Location = new System.Drawing.Point(237, 55);
            this.dtpLineDate.Name = "dtpLineDate";
            this.dtpLineDate.Size = new System.Drawing.Size(100, 20);
            this.dtpLineDate.TabIndex = 11;
            // 
            // lblLineDate
            // 
            this.lblLineDate.AutoSize = true;
            this.lblLineDate.BackColor = System.Drawing.Color.Transparent;
            this.lblLineDate.Location = new System.Drawing.Point(198, 60);
            this.lblLineDate.Name = "lblLineDate";
            this.lblLineDate.Size = new System.Drawing.Size(33, 13);
            this.lblLineDate.TabIndex = 10;
            this.lblLineDate.Text = "Date:";
            // 
            // cboJob
            // 
            this.cboJob.FormattingEnabled = true;
            this.cboJob.Location = new System.Drawing.Point(87, 55);
            this.cboJob.Name = "cboJob";
            this.cboJob.Size = new System.Drawing.Size(100, 21);
            this.cboJob.TabIndex = 5;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(19, 127);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(316, 118);
            this.txtNotes.TabIndex = 6;
            // 
            // lblJob
            // 
            this.lblJob.AutoSize = true;
            this.lblJob.BackColor = System.Drawing.Color.Transparent;
            this.lblJob.Location = new System.Drawing.Point(16, 58);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(27, 13);
            this.lblJob.TabIndex = 4;
            this.lblJob.Text = "Job:";
            // 
            // cboLocation
            // 
            this.cboLocation.FormattingEnabled = true;
            this.cboLocation.Location = new System.Drawing.Point(87, 82);
            this.cboLocation.Name = "cboLocation";
            this.cboLocation.Size = new System.Drawing.Size(100, 21);
            this.cboLocation.TabIndex = 5;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.BackColor = System.Drawing.Color.Transparent;
            this.lblLocation.Location = new System.Drawing.Point(16, 85);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(51, 13);
            this.lblLocation.TabIndex = 4;
            this.lblLocation.Text = "Location:";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.BackColor = System.Drawing.Color.Transparent;
            this.lblNotes.Location = new System.Drawing.Point(16, 111);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 13);
            this.lblNotes.TabIndex = 4;
            this.lblNotes.Text = "Notes:";
            // 
            // cboActivity
            // 
            this.cboActivity.FormattingEnabled = true;
            this.cboActivity.Location = new System.Drawing.Point(87, 28);
            this.cboActivity.Name = "cboActivity";
            this.cboActivity.Size = new System.Drawing.Size(248, 21);
            this.cboActivity.TabIndex = 5;
            this.cboActivity.SelectedIndexChanged += new System.EventHandler(this.OnActivityChanged);
            // 
            // lblActivity
            // 
            this.lblActivity.AutoSize = true;
            this.lblActivity.BackColor = System.Drawing.Color.Transparent;
            this.lblActivity.Location = new System.Drawing.Point(16, 31);
            this.lblActivity.Name = "lblActivity";
            this.lblActivity.Size = new System.Drawing.Size(44, 13);
            this.lblActivity.TabIndex = 4;
            this.lblActivity.Text = "Activity:";
            // 
            // cboTax
            // 
            this.cboTax.FormattingEnabled = true;
            this.cboTax.Location = new System.Drawing.Point(90, 110);
            this.cboTax.Name = "cboTax";
            this.cboTax.Size = new System.Drawing.Size(100, 21);
            this.cboTax.TabIndex = 5;
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.BackColor = System.Drawing.Color.Transparent;
            this.lblTax.Location = new System.Drawing.Point(6, 113);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(28, 13);
            this.lblTax.TabIndex = 4;
            this.lblTax.Text = "Tax:";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(499, 253);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOK.Location = new System.Drawing.Point(418, 253);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.Record);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.BackColor = System.Drawing.Color.Transparent;
            this.lblRate.Location = new System.Drawing.Point(6, 32);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(33, 13);
            this.lblRate.TabIndex = 4;
            this.lblRate.Text = "Rate:";
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(90, 29);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(100, 20);
            this.txtRate.TabIndex = 6;
            this.txtRate.Text = "0";
            // 
            // lblHoursUnits
            // 
            this.lblHoursUnits.AutoSize = true;
            this.lblHoursUnits.BackColor = System.Drawing.Color.Transparent;
            this.lblHoursUnits.Location = new System.Drawing.Point(4, 58);
            this.lblHoursUnits.Name = "lblHoursUnits";
            this.lblHoursUnits.Size = new System.Drawing.Size(67, 13);
            this.lblHoursUnits.TabIndex = 4;
            this.lblHoursUnits.Text = "Hours/Units:";
            // 
            // txtHoursUnits
            // 
            this.txtHoursUnits.Location = new System.Drawing.Point(90, 55);
            this.txtHoursUnits.Name = "txtHoursUnits";
            this.txtHoursUnits.Size = new System.Drawing.Size(100, 20);
            this.txtHoursUnits.TabIndex = 6;
            this.txtHoursUnits.Text = "1";
            // 
            // gb2
            // 
            this.gb2.BackgroundColor = System.Drawing.Color.White;
            this.gb2.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gb2.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gb2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gb2.BorderWidth = 1F;
            this.gb2.Caption = "Sale Line Charge Details";
            this.gb2.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gb2.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gb2.CaptionHeight = 25;
            this.gb2.CaptionVisible = true;
            this.gb2.Controls.Add(this.txtHoursUnits);
            this.gb2.Controls.Add(this.cboTax);
            this.gb2.Controls.Add(this.lblHoursUnits);
            this.gb2.Controls.Add(this.txtRate);
            this.gb2.Controls.Add(this.lblTax);
            this.gb2.Controls.Add(this.lblRate);
            this.gb2.Controls.Add(this.txtEstimatedCost);
            this.gb2.Controls.Add(this.lblEstimatedCost);
            this.gb2.CornerRadius = 5;
            this.gb2.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gb2.DropShadowThickness = 3;
            this.gb2.DropShadowVisible = true;
            this.gb2.Location = new System.Drawing.Point(374, 12);
            this.gb2.Name = "gb2";
            this.gb2.Size = new System.Drawing.Size(200, 150);
            this.gb2.TabIndex = 7;
            this.gb2.TabStop = false;
            // 
            // txtEstimatedCost
            // 
            this.txtEstimatedCost.Location = new System.Drawing.Point(90, 84);
            this.txtEstimatedCost.Name = "txtEstimatedCost";
            this.txtEstimatedCost.Size = new System.Drawing.Size(100, 20);
            this.txtEstimatedCost.TabIndex = 6;
            this.txtEstimatedCost.Text = "0";
            // 
            // lblEstimatedCost
            // 
            this.lblEstimatedCost.AutoSize = true;
            this.lblEstimatedCost.BackColor = System.Drawing.Color.Transparent;
            this.lblEstimatedCost.Location = new System.Drawing.Point(4, 87);
            this.lblEstimatedCost.Name = "lblEstimatedCost";
            this.lblEstimatedCost.Size = new System.Drawing.Size(80, 13);
            this.lblEstimatedCost.TabIndex = 4;
            this.lblEstimatedCost.Text = "Estimated Cost:";
            // 
            // FrmTimeBillingSaleLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 288);
            this.ControlBox = false;
            this.Controls.Add(this.gb2);
            this.Controls.Add(this.gbTimeBillingSaleLine);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "FrmTimeBillingSaleLine";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Service Sale Line";
            this.gbTimeBillingSaleLine.ResumeLayout(false);
            this.gbTimeBillingSaleLine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.gb2.ResumeLayout(false);
            this.gb2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CZRoundedGroupBox gbTimeBillingSaleLine;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.ComboBox cboJob;
        private System.Windows.Forms.ComboBox cboTax;
        private System.Windows.Forms.Label lblJob;
        private System.Windows.Forms.ComboBox cboActivity;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblActivity;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.TextBox txtHoursUnits;
        private System.Windows.Forms.Label lblHoursUnits;
        private System.Windows.Forms.CZRoundedGroupBox gb2;
        private System.Windows.Forms.ComboBox cboLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtEstimatedCost;
        private System.Windows.Forms.Label lblEstimatedCost;
        private System.Windows.Forms.DateTimePicker dtpLineDate;
        private System.Windows.Forms.Label lblLineDate;
    }
}