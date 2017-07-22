namespace DacII.WinForms.Setup
{
    partial class FrmTerms
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
            this.txtTermDescription = new System.Windows.Forms.TextBox();
            this.lblTermDescription = new System.Windows.Forms.Label();
            this.txtTermID = new System.Windows.Forms.TextBox();
            this.lblTermID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTermDescription
            // 
            this.txtTermDescription.Location = new System.Drawing.Point(97, 39);
            this.txtTermDescription.Multiline = true;
            this.txtTermDescription.Name = "txtTermDescription";
            this.txtTermDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTermDescription.Size = new System.Drawing.Size(299, 152);
            this.txtTermDescription.TabIndex = 9;
            // 
            // lblTermDescription
            // 
            this.lblTermDescription.AutoSize = true;
            this.lblTermDescription.Location = new System.Drawing.Point(13, 42);
            this.lblTermDescription.Name = "lblTermDescription";
            this.lblTermDescription.Size = new System.Drawing.Size(60, 13);
            this.lblTermDescription.TabIndex = 8;
            this.lblTermDescription.Text = "Description";
            // 
            // txtTermID
            // 
            this.txtTermID.Location = new System.Drawing.Point(97, 13);
            this.txtTermID.Name = "txtTermID";
            this.txtTermID.Size = new System.Drawing.Size(183, 20);
            this.txtTermID.TabIndex = 10;
            // 
            // lblTermID
            // 
            this.lblTermID.AutoSize = true;
            this.lblTermID.Location = new System.Drawing.Point(13, 16);
            this.lblTermID.Name = "lblTermID";
            this.lblTermID.Size = new System.Drawing.Size(45, 13);
            this.lblTermID.TabIndex = 7;
            this.lblTermID.Text = "Term ID";
            // 
            // FrmTerms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 208);
            this.Controls.Add(this.txtTermDescription);
            this.Controls.Add(this.lblTermDescription);
            this.Controls.Add(this.txtTermID);
            this.Controls.Add(this.lblTermID);
            this.Name = "FrmTerms";
            this.Text = "FrmTerms";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTermDescription;
        private System.Windows.Forms.Label lblTermDescription;
        private System.Windows.Forms.TextBox txtTermID;
        private System.Windows.Forms.Label lblTermID;
    }
}