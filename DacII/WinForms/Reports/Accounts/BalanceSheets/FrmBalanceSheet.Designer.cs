namespace DacII.WinForms.Reports.Accounts.BalanceSheets
{
    partial class FrmBalanceSheet
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
            this.BalanceSheetStdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpv = new Microsoft.Reporting.WinForms.ReportViewer();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButtonSend2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.emailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simpleTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceSheetStdBindingSource)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // BalanceSheetStdBindingSource
            // 
            this.BalanceSheetStdBindingSource.DataSource = typeof(Accounting.Report.Accounts.BalanceSheets.BalanceSheetStd);
            // 
            // rpv
            // 
            this.rpv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rpv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            reportDataSource1.Name = "Accounting_Report_Accounts_BalanceSheets_BalanceSheetStd";
            reportDataSource1.Value = this.BalanceSheetStdBindingSource;
            this.rpv.LocalReport.DataSources.Add(reportDataSource1);
            this.rpv.LocalReport.ReportEmbeddedResource = "DacII.Reports.Accounts.BalanceSheets.RptBalanceSheetStd.rdlc";
            this.rpv.Location = new System.Drawing.Point(1, 57);
            this.rpv.Name = "rpv";
            this.rpv.Size = new System.Drawing.Size(570, 242);
            this.rpv.TabIndex = 1;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButtonSend2});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(572, 52);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripDropDownButtonSend2
            // 
            this.toolStripDropDownButtonSend2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emailToolStripMenuItem,
            this.pDFToolStripMenuItem,
            this.excelToolStripMenuItem,
            this.simpleTextFileToolStripMenuItem});
            this.toolStripDropDownButtonSend2.Image = global::DacII.Properties.Resources.send2_32x32;
            this.toolStripDropDownButtonSend2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButtonSend2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonSend2.Name = "toolStripDropDownButtonSend2";
            this.toolStripDropDownButtonSend2.Size = new System.Drawing.Size(59, 49);
            this.toolStripDropDownButtonSend2.Text = "Send To";
            this.toolStripDropDownButtonSend2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // emailToolStripMenuItem
            // 
            this.emailToolStripMenuItem.Name = "emailToolStripMenuItem";
            this.emailToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.emailToolStripMenuItem.Text = "Email...";
            this.emailToolStripMenuItem.Click += new System.EventHandler(this.emailToolStripMenuItem_Click);
            // 
            // pDFToolStripMenuItem
            // 
            this.pDFToolStripMenuItem.Name = "pDFToolStripMenuItem";
            this.pDFToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.pDFToolStripMenuItem.Text = "PDF...";
            this.pDFToolStripMenuItem.Click += new System.EventHandler(this.pDFToolStripMenuItem_Click);
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.excelToolStripMenuItem.Text = "Excel...";
            this.excelToolStripMenuItem.Click += new System.EventHandler(this.excelToolStripMenuItem_Click);
            // 
            // simpleTextFileToolStripMenuItem
            // 
            this.simpleTextFileToolStripMenuItem.Name = "simpleTextFileToolStripMenuItem";
            this.simpleTextFileToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.simpleTextFileToolStripMenuItem.Text = "Simple Text File";
            this.simpleTextFileToolStripMenuItem.Click += new System.EventHandler(this.simpleTextFileToolStripMenuItem_Click);
            // 
            // FrmBalanceSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 311);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.rpv);
            this.Name = "FrmBalanceSheet";
            this.Text = "FrmBalanceSheet";
            this.Load += new System.EventHandler(this.FrmBalanceSheet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BalanceSheetStdBindingSource)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpv;
        private System.Windows.Forms.BindingSource BalanceSheetStdBindingSource;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonSend2;
        private System.Windows.Forms.ToolStripMenuItem emailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pDFToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simpleTextFileToolStripMenuItem;
    }
}