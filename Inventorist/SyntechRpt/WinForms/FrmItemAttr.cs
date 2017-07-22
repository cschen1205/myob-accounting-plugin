using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace SyntechRpt.WinForms
{
    public partial class FrmItemAttr : Form
    {
        private static object missing = Type.Missing;
        public FrmItemAttr()
        {
            InitializeComponent();
        }

        private void FrmItemAttr_Load(object sender, EventArgs e)
        {
            lvItems.Columns.Add("Item #", 100);
            lvItems.Columns.Add("Name", 100);
            lvItems.Columns.Add("Batch #", 60);
            lvItems.Columns.Add("Serial #", 60);
            lvItems.Columns.Add("Expired", 100);

            Sheet1 ws=Globals.Sheet1;
            Sheet2 wsItemAttr = Globals.Sheet2 as Sheet2;

            bool oldItemAttrLocked = wsItemAttr.Locked;
            wsItemAttr.Locked = false;

            Excel.Range range=ws.UsedRange as Excel.Range;
            int rowCount=range.Rows.Count;
            for (int i = 1; i <= rowCount; ++i)
            {
                Excel.Range row_range = ws.Cells[i + 1, 1] as Excel.Range;
                object val = row_range.Value2;
                if (val == null) continue;
                string item_number = val.ToString();

                row_range = ws.Cells[i + 1, 2] as Excel.Range;
                val = row_range.Value2;
                if (val == null) continue;
                string item_name = val.ToString();

                lvItems.Items.Add(GetItem(item_number, item_name));
            }

            cboGender.DataSource = EnumToList<LightItem.ItemGender>();
            cboSize.DataSource = EnumToList<LightItem.ItemSize>();

            cboGender.SelectedIndex = 0;
            cboSize.SelectedIndex = 0;

            wsItemAttr.Locked = oldItemAttrLocked;
        }

        public static List<T> EnumToList<T>()
        {

            Type enumType = typeof(T);

            // Can't use type constraints on value types, so have to do check like this

            if (enumType.BaseType != typeof(Enum))

                throw new ArgumentException("T must be of type System.Enum");

            return new List<T>(Enum.GetValues(enumType) as IEnumerable<T>);

        }

        private ListViewItem GetItem(string item_number, string item_name)
        {
            LightItem _obj = Globals.Sheet2.GetItem(item_number);
            _obj.ItemName = item_name;

            ListViewItem _item = new ListViewItem(item_number);
            _item.SubItems.Add(item_name);
            _item.SubItems.Add(_obj.BatchNumber);
            _item.SubItems.Add(_obj.SerialNumber);
            _item.SubItems.Add(_obj.ExpiryDate.ToString("yyyy-MMM-dd"));
            _item.Tag = _obj;
            return _item;
        }

        

        private void btnRecord_Click(object sender, EventArgs e)
        {
            
            if (lvItems.SelectedItems.Count > 0)
            {
                ListViewItem lstItem = lvItems.SelectedItems[0];
                object tag = lstItem.Tag;
                if (tag == null) return;

                LightItem _item = tag as LightItem;
                if (_item == null) return;

                bool oldSheet2Locked = Globals.Sheet2.Locked;
                Globals.Sheet2.Locked = false;

                _item.BatchNumber = txtBatchNumber.Text;
                _item.SerialNumber = txtSerialNumber.Text;
                _item.ExpiryDate = dpExpiryDate.Value;
                _item.Gender = (LightItem.ItemGender)cboGender.SelectedItem;
                _item.Size = (LightItem.ItemSize)cboSize.SelectedItem;
                _item.Brand = txtBrand.Text;
                _item.Color = txtColor.Text;

                Globals.Sheet2.RecordItem(_item);

                lstItem.SubItems[1].Text = _item.ItemName;
                lstItem.SubItems[2].Text = _item.BatchNumber;
                lstItem.SubItems[3].Text = _item.SerialNumber;
                lstItem.SubItems[4].Text = _item.ExpiryDate.ToString("yyyy-MMM-dd");

                Globals.Sheet2.Locked = oldSheet2Locked;
            }
        }

        private void lvItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if(lvItems.SelectedItems.Count == 0) return;
            LightItem _item=lvItems.SelectedItems[0].Tag as LightItem;
            if(_item==null) return;
            txtItemNumber.Text = _item.ItemNumber;
            txtBatchNumber.Text = _item.BatchNumber;
            txtSerialNumber.Text = _item.SerialNumber;
            cboGender.SelectedItem = _item.Gender;
            cboSize.SelectedItem = _item.Size;
            txtBrand.Text = _item.Brand;
            txtColor.Text = _item.Color;

            if (!_item.ExpiryDate.Equals(DateTime.MinValue))
            {
                dpExpiryDate.Value = _item.ExpiryDate;
            }
            
        }

        
    }
}
