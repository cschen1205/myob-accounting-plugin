using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DacII.WinForms
{
    using DacII.Presenters;
    using Accounting;
    using Accounting.Bll;
    using Accounting.Core.Inventory;

    public partial class FrmScript : BaseView
    {
        public FrmScript(ApplicationPresenter ap)
            : base(ap)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int from_number = int.Parse(txtFrom.Text);
            int to_number = int.Parse(txtTo.Text);

            if (from_number > to_number)
            {
                to_number = from_number + 1000;
            }

            Accountant current_account = mApplicationController.mAccountant;
            ItemManager itemMgr = current_account.ItemMgr;
            
            for (int index = from_number; index <= to_number; ++index)
            {
                //Item item = Item.CreateItem();
                //item.ItemNumber = string.Format("{0}", index);
                //item.BaseSellingPrice = 10;
                //item.BuyTaxCode = null;
                //itemMgr.Store(item);
            }
            MessageBox.Show("Done!");
        }
    }
}
