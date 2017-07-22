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
using Accounting.Bll;

namespace SyntechRpt
{
    public partial class Sheet1
    {
        Button mBtnLoadMyobData = new Button();
        Button mBtnLock = new Button();
        Button mBtnShow = new Button();
        Button mEnterItem = new Button();
        Label mLblHeader = new Label();

        private string mLockPassword = "czcodezone2011_";
        private bool mLocked = false;

        public delegate void SheetVisiblityChangedHandler(bool visible);
        public event SheetVisiblityChangedHandler SheetVisibilityChanged;
        private void onSheetVisibilityChanged(bool visible)
        {
            if (SheetVisibilityChanged != null)
            {
                SheetVisibilityChanged(visible);
            }
        }
        public delegate void SheetLockChangedHandler(bool locked);
        public event SheetLockChangedHandler SheetLockChanged;
        private void onSheetLockChanged(bool locked)
        {
            if (SheetLockChanged != null)
            {
                SheetLockChanged(locked);
            }
        }

        private void Sheet1_Startup(object sender, System.EventArgs e)
        {
            mLblHeader.Text = "Myob Data";
            mLblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            mLblHeader.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            //mLblHeader.ForeColor = System.Drawing.Color.AntiqueWhite;
            //mLblHeader.BackColor = System.Drawing.Color.PowderBlue;
            Globals.ThisWorkbook.ActionsPane.Controls.Add(mLblHeader);

            mBtnLoadMyobData.Text = "Load Myob Data";
            mBtnLoadMyobData.Click += new EventHandler(mBtnLoadMyobData_Click);
            Globals.ThisWorkbook.ActionsPane.Controls.Add(mBtnLoadMyobData);

            mEnterItem.Text = "Enter Myob Item";
            mEnterItem.Click += new EventHandler(mEnterItem_Click);
            Globals.ThisWorkbook.ActionsPane.Controls.Add(mEnterItem);

            mBtnShow.Text = "Show Myob Data";
            mBtnShow.Click += new EventHandler(mBtnShow_Click);
            Globals.ThisWorkbook.ActionsPane.Controls.Add(mBtnShow);
            this.Visible = Excel.XlSheetVisibility.xlSheetVeryHidden;

            mBtnLock.Text = "Unlock Myob Data";
            mBtnLock.Click += new EventHandler(mBtnLock_Click);
            Globals.ThisWorkbook.ActionsPane.Controls.Add(mBtnLock);
            Locked = true;
        }

        

        void mBtnShow_Click(object sender, EventArgs e)
        {
            Shown = !Shown;
        }

        public bool Shown
        {
            get
            {
                return this.Visible == Excel.XlSheetVisibility.xlSheetVisible;
            }
            set
            {
                if (value==false && this.Visible != Excel.XlSheetVisibility.xlSheetVeryHidden)
                {
                    this.Visible = Excel.XlSheetVisibility.xlSheetVeryHidden;
                    mBtnShow.Text = "Show Myob Data";
                    onSheetVisibilityChanged(value);
                }
                else if(value && this.Visible != Excel.XlSheetVisibility.xlSheetVisible)
                {
                    this.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                    this.Activate();
                    mBtnShow.Text = "Hide Myob Data";
                    onSheetVisibilityChanged(value);
                }
            }
        }

        void mEnterItem_Click(object sender, EventArgs e)
        {
            EnterItem();
        }

        public void EnterItem()
        {
            WinForms.Inventory.FrmItemInformation frm2 = new SyntechRpt.WinForms.Inventory.FrmItemInformation();
            if(frm2.ShowDialog()==DialogResult.OK)
            {
                _LoadMyobData();
            }
        }

        void mBtnLock_Click(object sender, EventArgs e)
        {
            if (Locked)
            {
                Locked = false;
                mBtnLock.Text = "Lock Myob Data";
            }
            else
            {
                Locked = true;
                mBtnLock.Text = "Unlock Myob Data";
            }

        }

        public bool Locked
        {
            get
            {
                return mLocked;
            }
            set
            {
                bool eventTriggered = false;
                if (value != mLocked) eventTriggered = true;
                if (value) Lock(mLockPassword);
                else Unlock(mLockPassword);
                if (eventTriggered) onSheetLockChanged(mLocked);
            }
        }

        void mBtnLoadMyobData_Click(object sender, EventArgs e)
        {
            LoadMyobData();
        }

        public void Lock(object password)
        {
            mLocked = true;
            this.Protect(password, missing, missing, missing, missing, missing,
                missing, missing, missing, missing,
                missing, missing, missing, missing, missing,
                missing);
        }

        public void Unlock(object password)
        {
            mLocked = false;
            this.Unprotect(password);
        }

        public void SyncMyobData(List<Item> items)
        {
            bool oldLocked = Locked;
            bool oldScreenUpdatingSetting = this.Application.ScreenUpdating;

            Locked = false;
            try
            {
                int fullRow = this.Rows.Count;

                Excel.Range r = this.Cells[fullRow, 1] as Excel.Range;
                Excel.Range endr = r.get_End(Excel.XlDirection.xlUp);
                int offset = endr.Row;

                List<string> headers = new List<string>();
                headers.Add("Item #");
                headers.Add("Name");

                int header_row = 1;
                for (int i = 0; i != headers.Count; ++i)
                {
                    Excel.Range range = this.Cells[header_row, i + 1] as Excel.Range;
                    range.Value2 = headers[i];
                    range.Font.Bold = true;
                    //Excel.Style range_style=range.Style as Excel.Style;
                    //range_style.Interior.Color = System.Drawing.Color.Orange;
                }
                if (offset == 1) offset++;

                for (int i = 0; i != items.Count; ++i)
                {
                    Excel.Range range = this.Cells[i + offset, 1] as Excel.Range;
                    range.Value2 = items[i].ItemNumber;
                    range = this.Cells[i + offset, 2] as Excel.Range;
                    range.Value2 = items[i].ItemName;
                }

                this.UsedRange.Columns.AutoFit();

            }
            finally
            {
                this.Application.ScreenUpdating = oldScreenUpdatingSetting;
                Locked = oldLocked;
            }
        }

        private void _LoadMyobData()
        {
            bool oldLocked = Locked;
            bool oldScreenUpdatingSetting = this.Application.ScreenUpdating;

            Locked = false;
            try
            {
                Accountant _obj = AccountantPool.Instance.CurrentAccountant;
                IList<Item> items = _obj.ItemMgr.List();

                int offset = 1;

                List<string> headers = new List<string>();
                headers.Add("Item #");
                headers.Add("Name");


                for (int i = 0; i != headers.Count; ++i)
                {
                    Excel.Range range = this.Cells[offset, i + 1] as Excel.Range;
                    range.Value2 = headers[i];
                    range.Font.Bold = true;
                    //Excel.Style range_style=range.Style as Excel.Style;
                    //range_style.Interior.Color = System.Drawing.Color.Orange;
                }

                offset++;
                for (int i = 0; i != items.Count; ++i)
                {
                    Excel.Range range = this.Cells[i + offset, 1] as Excel.Range;
                    range.Value2 = items[i].ItemNumber;
                    range = this.Cells[i + offset, 2] as Excel.Range;
                    range.Value2 = items[i].ItemName;
                }

                this.UsedRange.Columns.AutoFit();

            }
            finally
            {
                this.Application.ScreenUpdating = oldScreenUpdatingSetting;
                Locked = oldLocked;
            }
        }

        public void LoadMyobData()
        {
            _LoadMyobData();
        }
        

        private void Sheet1_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(Sheet1_Startup);
            this.Shutdown += new System.EventHandler(Sheet1_Shutdown);
        }

        #endregion

    }
}
