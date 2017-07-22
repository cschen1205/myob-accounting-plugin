namespace DacII.WinForms.Inventory
{
    partial class FrmItemDataFieldEntry
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
            this.lblDataField = new System.Windows.Forms.Label();
            this.cboDataField = new System.Windows.Forms.ComboBox();
            this.lblContent = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
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
            this.btnOK.Location = new System.Drawing.Point(224, 65);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 97;
            this.btnOK.Click += new System.EventHandler(this.Record);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BaseColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonText = "Cancel";
            this.btnClose.Image = global::DacII.Properties.Resources.cancel_24x24;
            this.btnClose.Location = new System.Drawing.Point(330, 65);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 32);
            this.btnClose.TabIndex = 96;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblDataField
            // 
            this.lblDataField.AutoSize = true;
            this.lblDataField.ForeColor = System.Drawing.Color.White;
            this.lblDataField.Location = new System.Drawing.Point(10, 15);
            this.lblDataField.Name = "lblDataField";
            this.lblDataField.Size = new System.Drawing.Size(58, 13);
            this.lblDataField.TabIndex = 92;
            this.lblDataField.Text = "Data Field:";
            // 
            // cboDataField
            // 
            this.cboDataField.FormattingEnabled = true;
            this.cboDataField.Location = new System.Drawing.Point(105, 12);
            this.cboDataField.Name = "cboDataField";
            this.cboDataField.Size = new System.Drawing.Size(322, 21);
            this.cboDataField.TabIndex = 98;
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.ForeColor = System.Drawing.Color.White;
            this.lblContent.Location = new System.Drawing.Point(10, 42);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(63, 13);
            this.lblContent.TabIndex = 93;
            this.lblContent.Text = "Data Value:";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(105, 39);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(322, 20);
            this.txtContent.TabIndex = 94;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FrmItemDataFieldEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(442, 108);
            this.ControlBox = false;
            this.Controls.Add(this.cboDataField);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.lblDataField);
            this.Name = "FrmItemDataFieldEntry";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Item Data Field Entry";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.VistaButton btnOK;
        private System.Windows.Forms.VistaButton btnClose;
        private System.Windows.Forms.Label lblDataField;
        private System.Windows.Forms.ComboBox cboDataField;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}