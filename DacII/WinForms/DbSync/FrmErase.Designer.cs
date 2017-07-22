namespace DacII.WinForms.DbSync
{
    partial class FrmErase
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
            this.gpBackupContents = new System.Windows.Forms.CZRoundedGroupBox();
            this.BtnEraseData = new System.Windows.Forms.VistaButton();
            this.chkEraseDataFields = new System.Windows.Forms.CheckBox();
            this.chkEraseAuthentication = new System.Windows.Forms.CheckBox();
            this.chkEraseAuthorization = new System.Windows.Forms.CheckBox();
            this.chkEraseItemAddOn = new System.Windows.Forms.CheckBox();
            this.gpBackupContents.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpBackupContents
            // 
            this.gpBackupContents.BackgroundColor = System.Drawing.Color.White;
            this.gpBackupContents.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gpBackupContents.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gpBackupContents.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gpBackupContents.BorderWidth = 1F;
            this.gpBackupContents.Caption = "Options for Data Erasion";
            this.gpBackupContents.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gpBackupContents.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gpBackupContents.CaptionHeight = 25;
            this.gpBackupContents.CaptionVisible = true;
            this.gpBackupContents.Controls.Add(this.BtnEraseData);
            this.gpBackupContents.Controls.Add(this.chkEraseDataFields);
            this.gpBackupContents.Controls.Add(this.chkEraseAuthentication);
            this.gpBackupContents.Controls.Add(this.chkEraseAuthorization);
            this.gpBackupContents.Controls.Add(this.chkEraseItemAddOn);
            this.gpBackupContents.CornerRadius = 5;
            this.gpBackupContents.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gpBackupContents.DropShadowThickness = 3;
            this.gpBackupContents.DropShadowVisible = true;
            this.gpBackupContents.Location = new System.Drawing.Point(12, 12);
            this.gpBackupContents.Name = "gpBackupContents";
            this.gpBackupContents.Size = new System.Drawing.Size(260, 169);
            this.gpBackupContents.TabIndex = 9;
            this.gpBackupContents.TabStop = false;
            // 
            // BtnEraseData
            // 
            this.BtnEraseData.BackColor = System.Drawing.Color.Transparent;
            this.BtnEraseData.ButtonColor = System.Drawing.Color.SteelBlue;
            this.BtnEraseData.ButtonText = "Erase Now";
            this.BtnEraseData.Location = new System.Drawing.Point(160, 124);
            this.BtnEraseData.Name = "BtnEraseData";
            this.BtnEraseData.Size = new System.Drawing.Size(84, 32);
            this.BtnEraseData.TabIndex = 10;
            this.BtnEraseData.Click += new System.EventHandler(this.TriggerCmd_Erase);
            // 
            // chkEraseDataFields
            // 
            this.chkEraseDataFields.AutoSize = true;
            this.chkEraseDataFields.BackColor = System.Drawing.Color.Transparent;
            this.chkEraseDataFields.Location = new System.Drawing.Point(14, 106);
            this.chkEraseDataFields.Name = "chkEraseDataFields";
            this.chkEraseDataFields.Size = new System.Drawing.Size(109, 17);
            this.chkEraseDataFields.TabIndex = 0;
            this.chkEraseDataFields.Text = "Erase Data Fields";
            this.chkEraseDataFields.UseVisualStyleBackColor = false;
            // 
            // chkEraseAuthentication
            // 
            this.chkEraseAuthentication.AutoSize = true;
            this.chkEraseAuthentication.BackColor = System.Drawing.Color.Transparent;
            this.chkEraseAuthentication.Location = new System.Drawing.Point(14, 83);
            this.chkEraseAuthentication.Name = "chkEraseAuthentication";
            this.chkEraseAuthentication.Size = new System.Drawing.Size(124, 17);
            this.chkEraseAuthentication.TabIndex = 0;
            this.chkEraseAuthentication.Text = "Erase Authentication";
            this.chkEraseAuthentication.UseVisualStyleBackColor = false;
            // 
            // chkEraseAuthorization
            // 
            this.chkEraseAuthorization.AutoSize = true;
            this.chkEraseAuthorization.BackColor = System.Drawing.Color.Transparent;
            this.chkEraseAuthorization.Location = new System.Drawing.Point(14, 60);
            this.chkEraseAuthorization.Name = "chkEraseAuthorization";
            this.chkEraseAuthorization.Size = new System.Drawing.Size(117, 17);
            this.chkEraseAuthorization.TabIndex = 0;
            this.chkEraseAuthorization.Text = "Erase Authorization";
            this.chkEraseAuthorization.UseVisualStyleBackColor = false;
            // 
            // chkEraseItemAddOn
            // 
            this.chkEraseItemAddOn.AutoSize = true;
            this.chkEraseItemAddOn.BackColor = System.Drawing.Color.Transparent;
            this.chkEraseItemAddOn.Location = new System.Drawing.Point(15, 37);
            this.chkEraseItemAddOn.Name = "chkEraseItemAddOn";
            this.chkEraseItemAddOn.Size = new System.Drawing.Size(112, 17);
            this.chkEraseItemAddOn.TabIndex = 0;
            this.chkEraseItemAddOn.Text = "Erase Item AddOn";
            this.chkEraseItemAddOn.UseVisualStyleBackColor = false;
            // 
            // FrmErase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(284, 191);
            this.Controls.Add(this.gpBackupContents);
            this.Name = "FrmErase";
            this.Text = "Erase Data";
            this.gpBackupContents.ResumeLayout(false);
            this.gpBackupContents.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CZRoundedGroupBox gpBackupContents;
        private System.Windows.Forms.CheckBox chkEraseAuthentication;
        private System.Windows.Forms.CheckBox chkEraseAuthorization;
        private System.Windows.Forms.CheckBox chkEraseItemAddOn;
        private System.Windows.Forms.VistaButton BtnEraseData;
        private System.Windows.Forms.CheckBox chkEraseDataFields;
    }
}