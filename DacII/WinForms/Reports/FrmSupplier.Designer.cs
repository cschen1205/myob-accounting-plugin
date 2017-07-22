namespace DacII.WinForms.Report
{
    partial class FrmSupplier
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
            this.SupplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptSuppliers = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SupplierBindingSource
            // 
            this.SupplierBindingSource.DataSource = typeof(Accounting.Core.Cards.Supplier);
            // 
            // rptSuppliers
            // 
            this.rptSuppliers.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Accounting_Core_Supplier_Supplier";
            reportDataSource1.Value = this.SupplierBindingSource;
            this.rptSuppliers.LocalReport.DataSources.Add(reportDataSource1);
            this.rptSuppliers.LocalReport.ReportEmbeddedResource = "Dac.WinForms.Report.rptSupplier.rdlc";
            this.rptSuppliers.Location = new System.Drawing.Point(0, 0);
            this.rptSuppliers.Name = "rptSuppliers";
            this.rptSuppliers.Size = new System.Drawing.Size(653, 461);
            this.rptSuppliers.TabIndex = 0;
            // 
            // frmSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 461);
            this.Controls.Add(this.rptSuppliers);
            this.Name = "frmSupplier";
            this.Text = "frmPrintSuppliers";
            this.Load += new System.EventHandler(this.FrmPrintSuppliers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SupplierBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptSuppliers;
        private System.Windows.Forms.BindingSource SupplierBindingSource;

    }
}