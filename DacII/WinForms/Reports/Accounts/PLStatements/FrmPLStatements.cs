using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace DacII.WinForms.Reports.Accounts.PLStatements
{
    using DacII.Presenters;
    using Accounting.Bll;
    using Accounting.Util;
    using Accounting.Report.Accounts.PLStatements;
    using Microsoft.Reporting.WinForms;
    using System.IO;
    using SwissArmyKnife.IO;

    public partial class FrmPLStatement : BaseView
    {
        PLStatementAccrual mModel;
        public FrmPLStatement(ApplicationPresenter ap)
            : base(ap)
        {
            mModel = new PLStatementAccrual(mApplicationController.mAccountant);
            InitializeComponent();

            rpv.LocalReport.EnableExternalImages = true;
            rpv.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
        }

        void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            // Author id is passed to the subreport as a parameter.
            //int authorId = int.Parse(e.Parameters[0].Values[0]);
            // Supply data for the subreport.
            e.DataSources.Add(new ReportDataSource("Accounting_Report_Accounts_PLStatements_PLStatementLine", mModel.Lines));
        }

        private void FrmPLStatement_Load(object sender, EventArgs e)
        {
            this.PLStatementAccrualBindingSource.DataSource = mModel ;
            this.rpv.RefreshReport();
        }

        public void LoadReport(string reportfile)
        {
            this.rpv.LocalReport.ReportEmbeddedResource = reportfile;
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string subject = string.Format("{0}::Standard Balance Sheet::{1}", mModel.CompanyName, DateTime.Now.ToString("yyyy-MM-dd"));

            string filename1 = mApplicationController.GetFullPath(string.Format("Emails\\PLStatementAccrual({0}).pdf", DateTime.Now.ToString("yyyy-MM-dd")));
            SaveAs("PDF", filename1);

            string filename2 = mApplicationController.GetFullPath(string.Format("Emails\\PLStatementAccrual({0}).xls", DateTime.Now.ToString("yyyy-MM-dd")));
            SaveAs("Excel", filename2);

            mApplicationController.Email(subject, null, filename1, filename2);
        }

        private void pDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = string.Format("PLStatementAccrual({0}).pdf", DateTime.Now.ToString("yyyy-MM-dd"));
            OpenSaveAsDlg("PDF", filename, "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*");
        }

        private void OpenSaveAsDlg(string filetype, string filename, string filter)
        {
            saveFileDialog.FileName = filename;
            saveFileDialog.Filter =filter;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog.FileName;
                SaveAs(filetype, filename);
            }
        }

        private void SaveAs(string filetype, string filename)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] data = this.rpv.LocalReport.Render(
                filetype, "", out mimeType, out encoding, out extension,
               out streamids, out warnings);

            FileStream fs = new FileStream(filename, FileMode.Create);
            fs.Write(data, 0, data.Length);
            fs.Close();
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = string.Format("PLStatementAccrual({0}).xls", DateTime.Now.ToString("yyyy-MM-dd"));
            OpenSaveAsDlg("Excel", filename, "Excel Files (*.xls)|*.xls|All Files (*.*)|*.*");
        }

        private void simpleTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = string.Format("PLStatementAccrual({0}).txt", DateTime.Now.ToString("yyyy-MM-dd"));
            saveFileDialog.FileName = filename;
            saveFileDialog.Filter ="Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog.FileName;
                string pdffile = Path.GetFileNameWithoutExtension(filename)+".pdf";
                SaveAs("PDF", pdffile);
                //FileUtil.ConvertPDF2Txt(pdffile, filename, false);
                
            }

            
        }
    }
}
