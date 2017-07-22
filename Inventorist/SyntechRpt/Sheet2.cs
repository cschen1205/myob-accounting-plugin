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
    public partial class Sheet2
    {
        Button mBtnEnterAttr = new Button();
        Button mBtnShow = new Button();
        Button mBtnLock = new Button();
        Label mLblHeader = new Label();

        bool mLocked = true;
        string mLockPassword = "czcodezone2011_";

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

        private void Sheet2_Startup(object sender, System.EventArgs e)
        {
            mLblHeader.Text = "Item Attributes";
            mLblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            mLblHeader.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            //mLblHeader.ForeColor = System.Drawing.Color.AntiqueWhite;
            //mLblHeader.BackColor = System.Drawing.Color.PowderBlue;
            Globals.ThisWorkbook.ActionsPane.Controls.Add(mLblHeader);

            mBtnEnterAttr.Text = "Enter Item Attributes";
            mBtnEnterAttr.Click += new EventHandler(mBtnEnterAttr_Click);
            Globals.ThisWorkbook.ActionsPane.Controls.Add(mBtnEnterAttr);

            mBtnShow.Text = "Show Item Attributes";
            mBtnShow.Click += new EventHandler(mBtnShow_Click);
            Globals.ThisWorkbook.ActionsPane.Controls.Add(mBtnShow);
            this.Visible = Excel.XlSheetVisibility.xlSheetVeryHidden;

            mBtnLock.Text = "Unlock Item Attributes";
            mBtnLock.Click += new EventHandler(mBtnLock_Click);
            Globals.ThisWorkbook.ActionsPane.Controls.Add(mBtnLock);
            Locked = true;
        }

        void mBtnLock_Click(object sender, EventArgs e)
        {
            if (Locked)
            {
                Locked = false;
                mBtnLock.Text = "Lock Item Attributes";
            }
            else
            {
                Locked = true;
                mBtnLock.Text = "Unlock Item Attributes";
            }

        }


        public bool ItemExists(string item_number)
        {
            int fullRow = this.Rows.Count;

            Excel.Range r = this.Cells[fullRow, 1] as Excel.Range;
            Excel.Range endr = r.get_End(Excel.XlDirection.xlUp);
            int nInLastRow = endr.Row;

            //int nInLastRow = ws.Cells.Find("*", System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlPrevious, false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row;

            int rowIndex = GetRowIndex(nInLastRow, item_number);

            if (rowIndex == nInLastRow + 1)
            {
                return false;
            }
            return true;
        }

        public LightItem GetItem(string item_number)
        {
            LightItem _obj = new LightItem();
            _obj.ItemNumber = item_number;

            int fullRow = this.Rows.Count;

            Excel.Range r = this.Cells[fullRow, 1] as Excel.Range;
            Excel.Range endr = r.get_End(Excel.XlDirection.xlUp);
            int nInLastRow = endr.Row;

            //int nInLastRow = ws.Cells.Find("*", System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlPrevious, false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row;

            int rowIndex = GetRowIndex(nInLastRow, item_number);
            if (rowIndex == nInLastRow + 1)
            {
                _obj.RecordIndex = rowIndex;
                RecordItem(_obj);
            }
            else
            {
                _obj.RecordIndex = rowIndex;
                LoadItem(_obj);
            }

            return _obj;
        }

        public void RecordItem(LightItem _obj)
        {
            Excel.Range cell = GetCell_ItemNumber(_obj);
            cell.Value2 = _obj.ItemNumber;

            cell = GetCell_BatchNumber(_obj);
            cell.Value2 = _obj.BatchNumber;

            cell = GetCell_SerialNumber(_obj);
            cell.Value2 = _obj.SerialNumber;

            cell = GetCell_ExpiryDate(_obj);
            cell.Value2 = _obj.ExpiryDate.ToString("yyyy-MMM-dd");

            cell = GetCell_Brand(_obj);
            cell.Value2 = _obj.Brand;

            cell = GetCell_Color(_obj);
            cell.Value2 = _obj.Color;

            cell = GetCell_Size(_obj);
            cell.Value2 = ((int)_obj.Size).ToString();

            cell = GetCell_Gender(_obj);
            cell.Value2 = ((int)_obj.Gender).ToString();
        }

        public int GetRowIndex(int nInLastRow, string item_number)
        {
            for (int row = 1; row <= nInLastRow; ++row)
            {
                Excel.Range range = this.Cells[row, 1] as Excel.Range;
                object val = range.Value2;
                if (val == null) continue;
                string value = val.ToString();
                if (value.Equals(item_number))
                {
                    return row;
                }
            }
            return nInLastRow + 1;
        }

        public void LoadItem(LightItem _obj)
        {
            Excel.Range cell = GetCell_ItemNumber(_obj);
            _obj.ItemNumber = cell.Value2.ToString();

            cell = GetCell_BatchNumber(_obj);
            if (cell.Value2 != null)
                _obj.BatchNumber = cell.Value2.ToString();

            cell = GetCell_SerialNumber(_obj);
            if (cell.Value2 != null)
                _obj.SerialNumber = cell.Value2.ToString();

            cell = GetCell_ExpiryDate(_obj);
            if (cell.Value2 != null)
                _obj.ExpiryDate = DateTime.Parse(cell.Value2.ToString());

            cell = GetCell_Brand(_obj);
            if (cell.Value2 != null)
                _obj.Brand = cell.Value2.ToString();

            cell = GetCell_Color(_obj);
            if (cell.Value2 != null)
                _obj.Color = cell.Value2.ToString();

            cell = GetCell_Size(_obj);
            if (cell.Value2 != null)
                _obj.Size = (LightItem.ItemSize)Convert.ToInt32(cell.Value2.ToString());

            cell = GetCell_Gender(_obj);
            if (cell.Value2 != null)
                _obj.Gender = (LightItem.ItemGender)Convert.ToInt32(cell.Value2.ToString());
        }

        public Excel.Range GetCell_ItemNumber(LightItem _obj)
        {
            return this.Cells[_obj.RecordIndex, 1] as Excel.Range;
        }

        public Excel.Range GetCell_BatchNumber(LightItem _obj)
        {
            return this.Cells[_obj.RecordIndex, 2] as Excel.Range;
        }

        public Excel.Range GetCell_SerialNumber(LightItem _obj)
        {
            return this.Cells[_obj.RecordIndex, 3] as Excel.Range;
        }

        public Excel.Range GetCell_ExpiryDate(LightItem _obj)
        {
            return this.Cells[_obj.RecordIndex, 4] as Excel.Range;
        }

        public Excel.Range GetCell_Brand(LightItem _obj)
        {
            return this.Cells[_obj.RecordIndex, 5] as Excel.Range;
        }

        public Excel.Range GetCell_Color(LightItem _obj)
        {
            return this.Cells[_obj.RecordIndex, 6] as Excel.Range;
        }

        public Excel.Range GetCell_Size(LightItem _obj)
        {
            return this.Cells[_obj.RecordIndex, 7] as Excel.Range;
        }

        public Excel.Range GetCell_Gender(LightItem _obj)
        {
            return this.Cells[_obj.RecordIndex, 8] as Excel.Range;
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
                if (mLocked != value) eventTriggered = true;
                if (value) Lock(mLockPassword);
                else Unlock(mLockPassword);
                if (eventTriggered) onSheetLockChanged(mLocked);
            }
        }

        private void Lock(object password)
        {
            mLocked = true;
            this.Protect(password, missing, missing, missing, missing, missing,
                missing, missing, missing, missing,
                missing, missing, missing, missing, missing,
                missing);
        }

        private void Unlock(object password)
        {
            mLocked = false;
            this.Unprotect(password);
        }

        void mBtnShow_Click(object sender, EventArgs e)
        {
            Shown = !Shown;
        }

        
        public bool Shown
        {
            get
            {
                return this.Visible==Excel.XlSheetVisibility.xlSheetVisible;
            }
            set
            {
                if (value==false && this.Visible != Excel.XlSheetVisibility.xlSheetVeryHidden)
                {
                    this.Visible = Excel.XlSheetVisibility.xlSheetVeryHidden;
                    mBtnShow.Text = "Show Item Attributes";
                    onSheetVisibilityChanged(value);
                }
                else if(value && this.Visible != Excel.XlSheetVisibility.xlSheetVisible)
                {
                    this.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                    this.Activate();
                    mBtnShow.Text = "Hide Item Attributes";
                    onSheetVisibilityChanged(value);
                }
            }
        }

        private void Sheet2_Shutdown(object sender, System.EventArgs e)
        {
        }

        void mBtnEnterAttr_Click(object sender, EventArgs e)
        {
            EnterItemAttr();
        }

        public void EnterItemAttr()
        {
            WinForms.FrmItemAttr frm = new SyntechRpt.WinForms.FrmItemAttr();
            frm.ShowDialog();
        }

        #region VSTO Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(Sheet2_Startup);
            this.Shutdown += new System.EventHandler(Sheet2_Shutdown);
        }

        #endregion

    }
}
