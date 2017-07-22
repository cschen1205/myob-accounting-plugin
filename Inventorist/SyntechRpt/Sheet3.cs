using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace SyntechRpt
{
    public partial class Sheet3
    {

        Button mBtnRptItems = new Button();
        Button mBtnRptCustomers = new Button();
        Button mBtnRptSalespersons = new Button();
        Label mLblHeader = new Label();

        private void Sheet3_Startup(object sender, System.EventArgs e)
        {
            mLblHeader.Text = "Reports";
            mLblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            mLblHeader.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            //mLblHeader.ForeColor = System.Drawing.Color.AntiqueWhite;
            //mLblHeader.BackColor = System.Drawing.Color.PowderBlue;
            Globals.ThisWorkbook.ActionsPane.Controls.Add(mLblHeader);

            mBtnRptItems.Text = "Sales [Items]";
            mBtnRptItems.Click += new EventHandler(mBtnRptItems_Click);
            Globals.ThisWorkbook.ActionsPane.Controls.Add(mBtnRptItems);

            mBtnRptCustomers.Text = "Sales [Customers]";
            mBtnRptCustomers.Click += new EventHandler(mBtnRptCustomers_Click);
            Globals.ThisWorkbook.ActionsPane.Controls.Add(mBtnRptCustomers);

            mBtnRptSalespersons.Text = "Sales [Salespersons]";
            mBtnRptSalespersons.Click += new EventHandler(mBtnRptSalespersons_Click);
            Globals.ThisWorkbook.ActionsPane.Controls.Add(mBtnRptSalespersons);

        }

        void mBtnRptItems_Click(object sender, EventArgs e)
        {
            GenerateReport_Items();
        }

        void mBtnRptCustomers_Click(object sender, EventArgs e)
        {
            GenerateReport_Customers();
        }

        void mBtnRptSalespersons_Click(object sender, EventArgs e)
        {
            GenerateReport_Salespersons();
        }

        public void GenerateReport_Salespersons()
        {
            WinForms.FrmReportItems frm = new SyntechRpt.WinForms.FrmReportItems();
            frm.ShowDialog();
        }

        public void GenerateReport_Customers()
        {
            WinForms.FrmReportItems frm = new SyntechRpt.WinForms.FrmReportItems();
            frm.ShowDialog();
        }

        private void Sheet3_Shutdown(object sender, System.EventArgs e)
        {
        }

        public void GenerateReport_Items()
        {
            WinForms.FrmReportItems frm = new SyntechRpt.WinForms.FrmReportItems();
            frm.ShowDialog();
        }

        #region VSTO Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(Sheet3_Startup);
            this.Shutdown += new System.EventHandler(Sheet3_Shutdown);
        }

        #endregion

    }
}
