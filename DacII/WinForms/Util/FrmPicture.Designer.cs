namespace DacII.WinForms.Util
{
    partial class FrmPicture
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
            this.btnLink = new System.Windows.Forms.VistaButton();
            this.btnUnlink = new System.Windows.Forms.VistaButton();
            this.btnOK = new System.Windows.Forms.VistaButton();
            this.btnCancel = new System.Windows.Forms.VistaButton();
            this.pbItemPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLink
            // 
            this.btnLink.BackColor = System.Drawing.Color.Transparent;
            this.btnLink.BaseColor = System.Drawing.Color.Transparent;
            this.btnLink.ButtonText = "Link";
            this.btnLink.Location = new System.Drawing.Point(12, 212);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(75, 34);
            this.btnLink.TabIndex = 1;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // btnUnlink
            // 
            this.btnUnlink.BackColor = System.Drawing.Color.Transparent;
            this.btnUnlink.BaseColor = System.Drawing.Color.Transparent;
            this.btnUnlink.ButtonText = "Unlink";
            this.btnUnlink.Location = new System.Drawing.Point(93, 212);
            this.btnUnlink.Name = "btnUnlink";
            this.btnUnlink.Size = new System.Drawing.Size(75, 34);
            this.btnUnlink.TabIndex = 1;
            this.btnUnlink.Click += new System.EventHandler(this.btnUnlink_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.BaseColor = System.Drawing.Color.Transparent;
            this.btnOK.ButtonText = "OK";
            this.btnOK.Location = new System.Drawing.Point(174, 212);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 34);
            this.btnOK.TabIndex = 2;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BaseColor = System.Drawing.Color.Transparent;
            this.btnCancel.ButtonText = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(255, 212);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 34);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pbItemPicture
            // 
            this.pbItemPicture.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pbItemPicture.Location = new System.Drawing.Point(12, 12);
            this.pbItemPicture.Name = "pbItemPicture";
            this.pbItemPicture.Size = new System.Drawing.Size(318, 190);
            this.pbItemPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbItemPicture.TabIndex = 0;
            this.pbItemPicture.TabStop = false;
            // 
            // FrmPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(340, 256);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnUnlink);
            this.Controls.Add(this.btnLink);
            this.Controls.Add(this.pbItemPicture);
            this.Name = "FrmPicture";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Picture Information";
            this.Load += new System.EventHandler(this.frmPictureInformation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbItemPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbItemPicture;
        private System.Windows.Forms.VistaButton btnLink;
        private System.Windows.Forms.VistaButton btnUnlink;
        private System.Windows.Forms.VistaButton btnOK;
        private System.Windows.Forms.VistaButton btnCancel;
    }
}