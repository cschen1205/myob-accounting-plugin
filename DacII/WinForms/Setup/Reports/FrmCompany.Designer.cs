namespace DacII.WinForms.Setup.Reports
{
    partial class FrmCompany
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.CompanyInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpv = new Microsoft.Reporting.WinForms.ReportViewer();
            this.gbFilter = new System.Windows.Forms.CZRoundedGroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyInfoBindingSource)).BeginInit();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // rpv
            // 
            this.rpv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "Accounting_Core_CompanyInfo_CompanyInfo";
            reportDataSource1.Value = this.CompanyInfoBindingSource;
            this.rpv.LocalReport.DataSources.Add(reportDataSource1);
            this.rpv.Location = new System.Drawing.Point(0, 26);
            this.rpv.Name = "rpv";
            this.rpv.Size = new System.Drawing.Size(693, 337);
            this.rpv.TabIndex = 0;
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
            this.gbFilter.Caption = "Data File Information ";
            this.gbFilter.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbFilter.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbFilter.CaptionHeight = 25;
            this.gbFilter.CaptionVisible = true;
            this.gbFilter.Controls.Add(this.btnClose);
            this.gbFilter.Controls.Add(this.rpv);
            this.gbFilter.CornerRadius = 5;
            this.gbFilter.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)));
            this.gbFilter.DropShadowThickness = 3;
            this.gbFilter.DropShadowVisible = false;
            this.gbFilter.Location = new System.Drawing.Point(6, 6);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(693, 363);
            this.gbFilter.TabIndex = 7;
            this.gbFilter.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.BackgroundImage = global::DacII.Properties.Resources.cancel_16x16;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(669, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(16, 16);
            this.btnClose.TabIndex = 93;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(711, 381);
            this.Controls.Add(this.gbFilter);
            this.Name = "FrmCompany";
            this.Text = "Data File Information";
            ((System.ComponentModel.ISupportInitialize)(this.CompanyInfoBindingSource)).EndInit();
            this.gbFilter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpv;
        private System.Windows.Forms.BindingSource CompanyInfoBindingSource;
        private System.Windows.Forms.CZRoundedGroupBox gbFilter;
        private System.Windows.Forms.Button btnClose;
    }
}