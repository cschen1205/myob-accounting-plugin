using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacII.Presenters
{
    using DacII.WinForms;
    using DacII.WinForms.Sales;
    using DacII.WinForms.Sales.SaleLines;

    using Accounting.Bll;
    using Accounting.Bll.Sales;
    using Accounting.Bll.Sales.SaleLines;

    public class SalePresenter : ModulePresenter
    {
        public SalePresenter(ApplicationPresenter ap, FrmDac shell)
            : base(ap, shell)
        {
        }

        private FrmItemSaleLine mFrmItemSaleLine = null;
        private FrmServiceSaleLine mFrmServiceSaleLine = null;
        private FrmTimeBillingSaleLine mFrmTimeBillingSaleLine = null;
        private FrmMiscSaleLine mFrmMiscSaleLine = null;
        private FrmProfessionalSaleLine mFrmProfessionalSaleLine = null;
        public bool ShowSaleLine(BOSaleLine model)
        {
            BaseView frm = null;

            if (model != null)
            {
                if (model is BOItemSaleLine)
                {
                    if (IsInvalid(mFrmItemSaleLine))
                    {
                        mFrmItemSaleLine = new FrmItemSaleLine(mApplicationController, model as BOItemSaleLine);
                    }
                    else
                    {
                        mFrmItemSaleLine.Model = model as BOItemSaleLine;
                        mFrmItemSaleLine.UpdateView();
                    }
                    frm = mFrmItemSaleLine;
                }
                else if (model is BOServiceSaleLine)
                {
                    if (IsInvalid(mFrmServiceSaleLine))
                    {
                        mFrmServiceSaleLine = new FrmServiceSaleLine(mApplicationController, model as BOServiceSaleLine);
                    }
                    else
                    {
                        mFrmServiceSaleLine.Model = model as BOServiceSaleLine;
                        mFrmServiceSaleLine.UpdateView();
                    }
                    frm = mFrmServiceSaleLine;
                }
                else if (model is BOProfessionalSaleLine)
                {
                    if (IsInvalid(mFrmProfessionalSaleLine))
                    {
                        mFrmProfessionalSaleLine = new FrmProfessionalSaleLine(mApplicationController, model as BOProfessionalSaleLine);
                    }
                    else
                    {
                        mFrmProfessionalSaleLine.Model = model as BOProfessionalSaleLine;
                        mFrmProfessionalSaleLine.UpdateView();
                    }
                    frm = mFrmProfessionalSaleLine;
                }
                else if (model is BOTimeBillingSaleLine)
                {
                    if (IsInvalid(mFrmTimeBillingSaleLine))
                    {
                        mFrmTimeBillingSaleLine = new FrmTimeBillingSaleLine(mApplicationController, model as BOTimeBillingSaleLine);
                    }
                    else
                    {
                        mFrmTimeBillingSaleLine.Model = model as BOTimeBillingSaleLine;
                        mFrmTimeBillingSaleLine.UpdateView();
                    }
                    frm = mFrmTimeBillingSaleLine;
                }
                else if (model is BOMiscSaleLine)
                {
                    if (IsInvalid(mFrmMiscSaleLine))
                    {
                        mFrmMiscSaleLine = new FrmMiscSaleLine(mApplicationController, model as BOMiscSaleLine);
                    }
                    else
                    {
                        mFrmMiscSaleLine.Model = model as BOMiscSaleLine;
                        mFrmMiscSaleLine.UpdateView();
                    }
                    frm = mFrmMiscSaleLine;
                }
            }

            if (frm != null)
            {
                return SetCurrentDlg(frm);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please select a valid purchase layout first!", "Current Sale Layout: No Default");
                return false;
            }
        }

        private FrmSaleQuote mFrmSaleQuote = null;
        private FrmSaleOrder mFrmSaleOrder = null;
        private FrmSaleOpenInvoice mFrmSaleOpenInvoice = null;
        private FrmSaleClosedInvoice mFrmSaleClosedInvoice = null;
        private FrmSaleCreditReturn mFrmSaleCreditReturn = null;
        public void ShowSale(BOSale model)
        {
            BaseView frm = null;
            if (model is BOSaleQuote)
            {
                if (mApplicationController.CheckAccess(BOType.BOSaleQuote, BOPropertyAttrType.Visible))
                {
                    if (IsInvalid(mFrmSaleQuote))
                    {
                        mFrmSaleQuote = new FrmSaleQuote(mApplicationController, model as BOSaleQuote);
                    }
                    else
                    {
                        mFrmSaleQuote.Model = model as BOSaleQuote;
                        mFrmSaleQuote.UpdateView();
                    }
                    frm = mFrmSaleQuote;
                }
            }
            else if (model is BOSaleOrder)
            {
                if (mApplicationController.CheckAccess(BOType.BOSaleOrder, BOPropertyAttrType.Visible))
                {
                    if (IsInvalid(mFrmSaleOrder))
                    {
                        mFrmSaleOrder = new FrmSaleOrder(mApplicationController, model as BOSaleOrder);
                    }
                    else
                    {
                        mFrmSaleOrder.Model = model as BOSaleOrder;
                        mFrmSaleOrder.UpdateView();
                    }
                    frm = mFrmSaleOrder;
                }
            }
            else if (model is BOSaleOpenInvoice)
            {
                if (mApplicationController.CheckAccess(BOType.BOSaleOpenInvoice, BOPropertyAttrType.Visible))
                {
                    if (IsInvalid(mFrmSaleOpenInvoice))
                    {
                        mFrmSaleOpenInvoice = new FrmSaleOpenInvoice(mApplicationController, model as BOSaleOpenInvoice);
                    }
                    else
                    {
                        mFrmSaleOpenInvoice.Model = model as BOSaleOpenInvoice;
                        mFrmSaleOpenInvoice.UpdateView();
                    }
                    frm = mFrmSaleOpenInvoice;
                }
            }
            else if (model is BOSaleCreditReturn)
            {
                if (mApplicationController.CheckAccess(BOType.BOSaleCreditReturn, BOPropertyAttrType.Visible))
                {
                    if (IsInvalid(mFrmSaleCreditReturn))
                    {
                        mFrmSaleCreditReturn = new FrmSaleCreditReturn(mApplicationController, model as BOSaleCreditReturn);
                    }
                    else
                    {
                        mFrmSaleCreditReturn.Model = model as BOSaleCreditReturn;
                        mFrmSaleCreditReturn.UpdateView();
                    }
                    frm = mFrmSaleCreditReturn;
                }
            }
            else if (model is BOSaleClosedInvoice)
            {
                if (mApplicationController.CheckAccess(BOType.BOSaleClosedInvoice, BOPropertyAttrType.Visible))
                {
                    if (IsInvalid(mFrmSaleClosedInvoice))
                    {
                        mFrmSaleClosedInvoice = new FrmSaleClosedInvoice(mApplicationController, model as BOSaleClosedInvoice);
                    }
                    else
                    {
                        mFrmSaleClosedInvoice.Model = model as BOSaleClosedInvoice;
                        mFrmSaleClosedInvoice.UpdateView();
                    }
                    frm = mFrmSaleClosedInvoice;
                }
            }

            if (frm != null)
            {
                SetCurrentForm(frm);
            }
        }

        private DacII.WinForms.Sales.FrmSalesRegister mFrmSalesRegister = null;
        public void ShowSales(BOListSale model)
        {
            if (mApplicationController.CheckAccess(BOType.BOListSale, BOPropertyAttrType.Visible))
            {
                if (IsInvalid(mFrmSalesRegister))
                {
                    mFrmSalesRegister = new DacII.WinForms.Sales.FrmSalesRegister(mApplicationController, model);
                }
                SetCurrentForm(mFrmSalesRegister);
            }
        }

        private DacII.WinForms.Reports.Sales.FrmRptSalesItem mFrmRptSalesItem = null;
        public void ShowSalesItemRpt()
        {
            if (IsInvalid(mFrmRptSalesItem))
            {
                mFrmRptSalesItem = new DacII.WinForms.Reports.Sales.FrmRptSalesItem(mApplicationController);
            }
            SetCurrentForm(mFrmRptSalesItem);
        }

        public void PrintSale(Accounting.Report.Sales.SalePrintPresenter report_presenter)
        {
            BaseView frm = new DacII.WinForms.Sales.Reports.FrmSale(mApplicationController, report_presenter);
            SetCurrentForm(frm);
        }
    }
}
