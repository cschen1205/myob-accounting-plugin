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
using Accounting.Db.Myob;
using Accounting.Core.Inventory;
using SyntechRpt.Util;
using Accounting.Bll;
using Accounting.Bll.Security;

namespace SyntechRpt
{
    public partial class ThisWorkbook
    {
        Button mBtnDocProps;
        
        private void ThisWorkbook_Startup(object sender, System.EventArgs e)
        {
            AccLoader.Instance.Init(this.Path);
            AccLoader.Instance.Load();

            mBtnDocProps = new Button();
            mBtnDocProps.Text = "Document Properties";
            mBtnDocProps.Click += new EventHandler(mBtnDocProps_Click);
            this.ActionsPane.Controls.Add(mBtnDocProps);

            this.Saved = true;

            SyncMyobData();
        }

        void mBtnDocProps_Click(object sender, EventArgs e)
        {
            ShowDocProps();
        }

        public void ShowDocProps()
        {
            WinForms.FrmDocProps frm = new SyntechRpt.WinForms.FrmDocProps();
            frm.ShowDialog();
        }
        

        private void ThisWorkbook_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.BeforeClose += new Microsoft.Office.Interop.Excel.WorkbookEvents_BeforeCloseEventHandler(this.ThisWorkbook_BeforeClose);
            this.Shutdown += new System.EventHandler(this.ThisWorkbook_Shutdown);
            this.Startup += new System.EventHandler(this.ThisWorkbook_Startup);

        }

        #endregion

        private void ThisWorkbook_BeforeClose(ref bool Cancel)
        {
            AccLoader.Instance.Unload();
            this.Save();
        }

        public void SyncMyobData()
        {
            Accountant acc = AccountantPool.Instance.CurrentAccountant;
            WinForms.Security.FrmMyobLogin frm = new WinForms.Security.FrmMyobLogin(acc);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Accountant _obj = AccountantPool.Instance.CurrentAccountant;
                IList<Item> items = _obj.ItemMgr.List();

                WinForms.FrmSync frm2 = new SyntechRpt.WinForms.FrmSync();
                frm2.mItems = items;
                if (frm2.ShowDialog() == DialogResult.OK)
                {
                    Globals.Sheet1.LoadMyobData();
                }
            }
        }

        

    }
}
