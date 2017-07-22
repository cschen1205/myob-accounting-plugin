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
using Accounting.Core.Inventory;

namespace SyntechRpt.WinForms
{
    public partial class FrmSync : Form
    {
        private static object missing = Type.Missing;
        public FrmSync()
        {
            InitializeComponent();
        }

        public IList<Item> mItems;

        private void FrmSync_Load(object sender, EventArgs e)
        {
            lvItems.Columns.Add("Item #", 100);
            lvItems.Columns.Add("Name", 100);
            lvItems.Columns.Add("Import", 60);

            List<Item> removed = new List<Item>();
            foreach (Item _item in mItems)
            {
                if (Globals.Sheet2.ItemExists(_item.ItemNumber))
                {
                    removed.Add(_item);
                }
            }

            foreach (Item _item in removed)
            {
                mItems.Remove(_item);
            }

            int rowCount = mItems.Count;
            for (int i = 1; i < rowCount; ++i)
            {
                ListViewItem _item = new ListViewItem();
                _item.Text = mItems[i].ItemNumber;
                _item.SubItems.Add(mItems[i].ItemName);
                lvItems.Items.Add(_item);
            }
        }

        public static List<T> EnumToList<T>()
        {

            Type enumType = typeof(T);

            // Can't use type constraints on value types, so have to do check like this

            if (enumType.BaseType != typeof(Enum))

                throw new ArgumentException("T must be of type System.Enum");

            return new List<T>(Enum.GetValues(enumType) as IEnumerable<T>);

        }

        

        private void btnRecord_Click(object sender, EventArgs e)
        {
            
            if (lvItems.SelectedItems.Count > 0)
            {
                
            }
        }

        private void lvItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if(lvItems.SelectedItems.Count == 0) return;

            txtItemNumber.Text =lvItems.SelectedItems[0].Text;
            
           
            
        }

        
    }
}
