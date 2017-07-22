using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Office = Microsoft.Office.Core;
using Accounting.Bll;
using Accounting.Bll.Security;
using Accounting.Bll.Purchases;
using Accounting.Bll.Sales;
using System.Windows.Forms;
using SyntechRpt.WinForms;
using SyntechRpt.WinForms.Cards;
using SyntechRpt.WinForms.Inventory;
using SyntechRpt.WinForms.Purchases;
using SyntechRpt.WinForms.Sales;

namespace SyntechRpt
{
    public partial class RibbonSyntech : OfficeRibbon
    {
        public RibbonSyntech()
        {
            InitializeComponent();
        }

        private void RibbonSyntech_Load(object sender, RibbonUIEventArgs e)
        {
            chkLockMyobData.Checked = Globals.Sheet1.Locked;
            chkLockItemAttr.Checked = Globals.Sheet2.Locked;
            chkShowMyobData.Checked = Globals.Sheet1.Shown;
            chkShowItemAttr.Checked = Globals.Sheet2.Shown;
            Office.DocumentProperties props = Globals.ThisWorkbook.BuiltinDocumentProperties as Office.DocumentProperties;
            string company_caption = props["Company"].Value as string;
            //if (!string.IsNullOrEmpty(company_caption))
            //{
            //    this.tabSyntech.Label = company_caption;
            //}
            Globals.Sheet2.SheetVisibilityChanged += new Sheet2.SheetVisiblityChangedHandler(Sheet2_SheetVisibilityChanged);
            Globals.Sheet2.SheetLockChanged += new Sheet2.SheetLockChangedHandler(Sheet2_SheetLockChanged);
            Globals.Sheet1.SheetVisibilityChanged += new Sheet1.SheetVisiblityChangedHandler(Sheet1_SheetVisibilityChanged);
            Globals.Sheet1.SheetLockChanged += new Sheet1.SheetLockChangedHandler(Sheet1_SheetLockChanged);
        }

        void Sheet1_SheetLockChanged(bool locked)
        {
            chkLockMyobData.Checked = locked;
        }

        void Sheet1_SheetVisibilityChanged(bool visible)
        {
            chkShowMyobData.Checked = visible;
        }

        void Sheet2_SheetLockChanged(bool locked)
        {
            chkLockItemAttr.Checked = locked;
        }

        void Sheet2_SheetVisibilityChanged(bool visible)
        {
            chkShowItemAttr.Checked = visible;
        }

        private void btnDocProps_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisWorkbook.ShowDocProps();
        }

        private void chkLockMyobData_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.Sheet1.Locked = !Globals.Sheet1.Locked;
            chkLockMyobData.Checked = Globals.Sheet1.Locked;
        }

        private void chkShowMyobData_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.Sheet1.Shown = !Globals.Sheet1.Shown;
        }

        private void btnLoadMyobData_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.Sheet1.LoadMyobData();
        }

        private void btnEnterItemAttr_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.Sheet2.EnterItemAttr();
        }

        private void chkLockItemAttr_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.Sheet2.Locked = !Globals.Sheet2.Locked;
        }

        private void chkShowItemAttr_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.Sheet2.Shown = !Globals.Sheet2.Shown;
        }

        private void btnGenerateRpt_Items_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.Sheet3.GenerateReport_Items();
        }

        private void btnRptCustomers_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.Sheet3.GenerateReport_Customers();
        }

        private void btnSalespersons_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.Sheet3.GenerateReport_Salespersons();
        }

        private void btnEnterItem_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.Sheet1.EnterItem();
        }

        private void TriggerCmd_ItemsList(object sender, RibbonControlEventArgs e)
        {
            FrmItemList frm = new FrmItemList();
            ShowWindowsForm(frm);
        }

        private void TriggerCmd_PurchaseRegister(object sender, RibbonControlEventArgs e)
        {
            Purchase_Access();
        }

        private void Purchase_Access()
        {
            if (SecurityUtil.CheckAccess("Purchase_Access"))
            {
                FrmPurchaseRegister frm = new FrmPurchaseRegister();
                frm.Model = new BOListPurchase(AccountantPool.Instance.CurrentAccountant);
                ShowWindowsForm(frm);
            }
        }

        private void TriggerCmd_SalesRegister(object sender, RibbonControlEventArgs e)
        {
            Sale_Access();
        }

        private void Sale_Access()
        {
            if (SecurityUtil.CheckAccess("Sale_Access"))
            {
                BOListSale model = new BOListSale(AccountantPool.Instance.CurrentAccountant);
                FrmSaleRegister frm = new FrmSaleRegister();
                frm.Model = model;
                ShowWindowsForm(frm);
            }
        }

        private void TriggerCmd_AllCards(object sender, RibbonControlEventArgs e)
        {
            Card_Access();
        }

        private void Card_Access()
        {
            if (SecurityUtil.CheckAccess("Card_Access"))
            {
                FrmCardRegister frm = new FrmCardRegister();
                ShowWindowsForm(frm);
            }
        }

        private void TriggerCmd_Customers(object sender, RibbonControlEventArgs e)
        {
            Customer_Index();
        }

        private void Customer_Index()
        {
            if (SecurityUtil.CheckAccess("Customer_Index"))
            {
                FrmCardRegister frm = new FrmCardRegister();
                frm.Model.ActiveCardType = Accounting.Core.Cards.CardType.TypeID.Customer;
                ShowWindowsForm(frm);
            }
        }

        private void TriggerCmd_Employees(object sender, RibbonControlEventArgs e)
        {
            Employee_Index();
        }

        private void Employee_Index()
        {
            if (SecurityUtil.CheckAccess("Employee_Index"))
            {
                FrmCardRegister frm = new FrmCardRegister();
                frm.Model.ActiveCardType = Accounting.Core.Cards.CardType.TypeID.Employee;
                ShowWindowsForm(frm);
            }
        }

        private void TriggerCmd_Suppliers(object sender, RibbonControlEventArgs e)
        {
            Supplier_Index();
        }

        private void Supplier_Index()
        {
            if (SecurityUtil.CheckAccess("Supplier_Index"))
            {
                FrmCardRegister frm = new FrmCardRegister();
                frm.Model.ActiveCardType = Accounting.Core.Cards.CardType.TypeID.Supplier;
                ShowWindowsForm(frm);
            }
        }

        private void TriggerCmd_CreateSaleQuote(object sender, RibbonControlEventArgs e)
        {
            Sale_CreateSaleQuote();
        }


        private void Sale_CreateSaleQuote()
        {
            if (SecurityUtil.CheckAccess("Sale_CreateSaleQuote"))
            {
                FrmSaleQuote frm = new FrmSaleQuote();
                frm.Model = AccountantPool.Instance.CurrentAccountant.SaleFactory.CreateSaleQuote();
                ShowWindowsForm(frm);
            }
        }

        private void TriggerCmd_CreateSaleOrder(object sender, RibbonControlEventArgs e)
        {
            Sale_CreateSaleOrder();
        }

        private void Sale_CreateSaleOrder()
        {
            if (SecurityUtil.CheckAccess("Sale_CreateSaleOrder"))
            {
                FrmSaleOrder frm = new FrmSaleOrder();
                frm.Model = AccountantPool.Instance.CurrentAccountant.SaleFactory.CreateSaleOrder();
                ShowWindowsForm(frm);
            }
        }

        private void TriggerCmd_CreateSaleOpenInvoice(object sender, RibbonControlEventArgs e)
        {
            Sale_CreateSaleOpenInvoice();
        }

        private void Sale_CreateSaleOpenInvoice()
        {
            if (SecurityUtil.CheckAccess("Sale_CreateSaleOpenInvoice"))
            {
                FrmSaleOpenInvoice frm = new FrmSaleOpenInvoice();
                frm.Model = AccountantPool.Instance.CurrentAccountant.SaleFactory.CreateSaleOpenInvoice();
                ShowWindowsForm(frm);
            }
        }

        private void ShowWindowsForm(Form frm)
        {
            //frm.BackColor = Color.WhiteSmoke;
            frm.ShowDialog();
        }

        private void Purchase_CreatePurchaseQuote()
        {
            if (SecurityUtil.CheckAccess("Purchase_CreatePurchaseQuote"))
            {
                FrmPurchaseQuote frm = new FrmPurchaseQuote();
                frm.Model = AccountantPool.Instance.CurrentAccountant.PurchaseFactory.CreatePurchaseQuote();
                ShowWindowsForm(frm);
            }
        }

        private void Purchase_CreatePurchaseOrder()
        {
            if (SecurityUtil.CheckAccess("Purchase_CreatePurchaseOrder"))
            {
                FrmPurchaseOrder frm = new FrmPurchaseOrder();

                frm.Model = AccountantPool.Instance.CurrentAccountant.PurchaseFactory.CreatePurchaseOrder();
                ShowWindowsForm(frm);
            }
        }

        private void Purchase_CreatePurchaseOpenBill()
        {
            if (SecurityUtil.CheckAccess("Purchase_CreatePurchaseOpenBill"))
            {
                FrmPurchaseOpenBill frm = new FrmPurchaseOpenBill();
                frm.Model = AccountantPool.Instance.CurrentAccountant.PurchaseFactory.CreatePurchaseOpenBill();
                ShowWindowsForm(frm);
            }
        }

        private void TriggerCmd_CreatePurchaseQuote(object sender, RibbonControlEventArgs e)
        {
            Purchase_CreatePurchaseQuote();
        }

        private void TriggerCmd_CreatePurchaseOrder(object sender, RibbonControlEventArgs e)
        {
            Purchase_CreatePurchaseOrder();
        }

        private void TriggerCmd_CreatePurchaseOpenBill(object sender, RibbonControlEventArgs e)
        {
            Purchase_CreatePurchaseOpenBill();
        }

        private void TriggerCmd_ItemsRegister(object sender, RibbonControlEventArgs e)
        {
            Inventory_ItemsRegister_Access();
        }

        private void Inventory_ItemsRegister_Access()
        {
            if (SecurityUtil.CheckAccess("Inventory_ItemsRegister_Access"))
            {
                FrmItemRegister frm = new FrmItemRegister();
                ShowWindowsForm(frm);
            }
        }

        
    }
}
