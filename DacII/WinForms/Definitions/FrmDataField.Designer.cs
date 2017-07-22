namespace DacII.WinForms.Definitions
{
    partial class FrmDataField
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
            this.btnOK = new System.Windows.Forms.VistaButton();
            this.btnClose = new System.Windows.Forms.VistaButton();
            this.txtDataFieldName = new System.Windows.Forms.TextBox();
            this.lblDataFieldType = new System.Windows.Forms.Label();
            this.lblDataFieldName = new System.Windows.Forms.Label();
            this.cboDataFieldType = new System.Windows.Forms.ComboBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.BaseColor = System.Drawing.Color.Transparent;
            this.btnOK.ButtonText = "Record";
            this.btnOK.Image = global::DacII.Properties.Resources.OK_32x32;
            this.btnOK.Location = new System.Drawing.Point(134, 81);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(106, 32);
            this.btnOK.TabIndex = 97;
            this.btnOK.Click += new System.EventHandler(this.Record);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BaseColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonText = "Cancel";
            this.btnClose.Image = global::DacII.Properties.Resources.cancel_24x24;
            this.btnClose.Location = new System.Drawing.Point(246, 81);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 32);
            this.btnClose.TabIndex = 96;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtDataFieldName
            // 
            this.txtDataFieldName.Location = new System.Drawing.Point(105, 15);
            this.txtDataFieldName.Name = "txtDataFieldName";
            this.txtDataFieldName.Size = new System.Drawing.Size(247, 20);
            this.txtDataFieldName.TabIndex = 94;
            // 
            // lblDataFieldType
            // 
            this.lblDataFieldType.AutoSize = true;
            this.lblDataFieldType.ForeColor = System.Drawing.Color.White;
            this.lblDataFieldType.Location = new System.Drawing.Point(10, 48);
            this.lblDataFieldType.Name = "lblDataFieldType";
            this.lblDataFieldType.Size = new System.Drawing.Size(85, 13);
            this.lblDataFieldType.TabIndex = 92;
            this.lblDataFieldType.Text = "Data Field Type:";
            // 
            // lblDataFieldName
            // 
            this.lblDataFieldName.AutoSize = true;
            this.lblDataFieldName.ForeColor = System.Drawing.Color.White;
            this.lblDataFieldName.Location = new System.Drawing.Point(10, 18);
            this.lblDataFieldName.Name = "lblDataFieldName";
            this.lblDataFieldName.Size = new System.Drawing.Size(89, 13);
            this.lblDataFieldName.TabIndex = 93;
            this.lblDataFieldName.Text = "Data Field Name:";
            // 
            // cboDataFieldType
            // 
            this.cboDataFieldType.FormattingEnabled = true;
            this.cboDataFieldType.Items.AddRange(new object[] {
            "Text",
            "Real",
            "Integer",
            "DateTime"});
            this.cboDataFieldType.Location = new System.Drawing.Point(105, 45);
            this.cboDataFieldType.Name = "cboDataFieldType";
            this.cboDataFieldType.Size = new System.Drawing.Size(247, 21);
            this.cboDataFieldType.TabIndex = 98;
            this.cboDataFieldType.Text = "Text";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FrmDataField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(375, 126);
            this.Controls.Add(this.cboDataFieldType);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtDataFieldName);
            this.Controls.Add(this.lblDataFieldType);
            this.Controls.Add(this.lblDataFieldName);
            this.Name = "FrmDataField";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Data Field";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.VistaButton btnOK;
        private System.Windows.Forms.VistaButton btnClose;
        private System.Windows.Forms.TextBox txtDataFieldName;
        private System.Windows.Forms.Label lblDataFieldType;
        private System.Windows.Forms.Label lblDataFieldName;
        private System.Windows.Forms.ComboBox cboDataFieldType;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}