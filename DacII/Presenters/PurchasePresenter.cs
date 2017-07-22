using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacII.Presenters
{
    using DacII.WinForms;
    using DacII.WinForms.Purchases;
    using DacII.WinForms.Purchases.PurchaseLines;

    using Accounting.Bll;
    using Accounting.Bll.Purchases;
    using Accounting.Bll.Purchases.PurchaseLines;

    public class PurchasePresenter : ModulePresenter
    {
        public PurchasePresenter(ApplicationPresenter ap, FrmDac shell)
            : base(ap, shell)
        {
        }

        private FrmPurchaseQuote mFrmPurchaseQuote = null;
        private FrmPurchaseOrder mFrmPurchaseOrder = null;
        private FrmPurchaseOpenBill mFrmPurchaseOpenBill = null;
        private FrmPurchaseClosedBill mFrmPurchaseClosedBill = null;
        private FrmPurchaseDebitReturn mFrmPurchaseDebitReturn = null;
        public void ShowPurchase(BOPurchase model)
        {
            BaseView frm = null;
            if (model is BOPurchaseQuote)
            {
                if (mApplicationController.CheckAccess(BOType.BOPurchaseQuote, BOPropertyAttrType.Visible))
                {
                    if (IsInvalid(mFrmPurchaseQuote))
                    {
                        mFrmPurchaseQuote = new FrmPurchaseQuote(mApplicationController, model as BOPurchaseQuote);
                    }
                    else
                    {
                        mFrmPurchaseQuote.Model = model as BOPurchaseQuote;
                        mFrmPurchaseQuote.UpdateView();
                    }
                    frm = mFrmPurchaseQuote;
                }
            }
            else if (model is BOPurchaseOrder)
            {
                if (mApplicationController.CheckAccess(BOType.BOPurchaseOrder, BOPropertyAttrType.Visible))
                {
                    if (IsInvalid(mFrmPurchaseOrder))
                    {
                        mFrmPurchaseOrder = new FrmPurchaseOrder(mApplicationController, model as BOPurchaseOrder);
                    }
                    else
                    {
                        mFrmPurchaseOrder.Model = model as BOPurchaseOrder;
                        mFrmPurchaseOrder.UpdateView();
                    }
                    frm = mFrmPurchaseOrder;
                }
            }
            else if (model is BOPurchaseOpenBill)
            {
                if (mApplicationController.CheckAccess(BOType.BOPurchaseOpenBill, BOPropertyAttrType.Visible))
                {
                    if (IsInvalid(mFrmPurchaseOpenBill))
                    {
                        mFrmPurchaseOpenBill = new FrmPurchaseOpenBill(mApplicationController, model as BOPurchaseOpenBill);
                    }
                    else
                    {
                        mFrmPurchaseOpenBill.Model = model as BOPurchaseOpenBill;
                        mFrmPurchaseOpenBill.UpdateView();
                    }
                    frm = mFrmPurchaseOpenBill;
                }
            }
            else if (model is BOPurchaseDebitReturn)
            {
                if (mApplicationController.CheckAccess(BOType.BOPurchaseDebitReturn, BOPropertyAttrType.Visible))
                {
                    if (IsInvalid(mFrmPurchaseDebitReturn))
                    {
                        mFrmPurchaseDebitReturn = new FrmPurchaseDebitReturn(mApplicationController, model as BOPurchaseDebitReturn);
                    }
                    else
                    {
                        mFrmPurchaseDebitReturn.Model=model as BOPurchaseDebitReturn;
                        mFrmPurchaseDebitReturn.UpdateView();
                    }
                    frm = mFrmPurchaseDebitReturn;
                }
            }
            else if (model is BOPurchaseClosedBill)
            {
                if (mApplicationController.CheckAccess(BOType.BOPurchaseClosedBill, BOPropertyAttrType.Visible))
                {
                    if (IsInvalid(mFrmPurchaseClosedBill))
                    {
                        mFrmPurchaseClosedBill = new FrmPurchaseClosedBill(mApplicationController, model as BOPurchaseClosedBill);
                    }
                    else
                    {
                        mFrmPurchaseClosedBill.Model = model as BOPurchaseClosedBill;
                        mFrmPurchaseClosedBill.UpdateView();
                    }
                    frm = mFrmPurchaseClosedBill;
                }
            }

            if (frm != null)
            {
                SetCurrentForm(frm);
            }
        }



        private DacII.WinForms.Purchases.FrmPurchasesRegister mFrmPurchasesRegister = null;
        public void ShowPurchases(BOListPurchase model)
        {
            if (mApplicationController.CheckAccess(BOType.BOListPurchase, BOPropertyAttrType.Visible))
            {
                if (IsInvalid(mFrmPurchasesRegister))
                {
                    mFrmPurchasesRegister = new DacII.WinForms.Purchases.FrmPurchasesRegister(mApplicationController, model);
                }
                SetCurrentForm(mFrmPurchasesRegister);
            }
        }

        private FrmItemPurchaseLine mFrmItemPurchaseLine = null;
        private FrmServicePurchaseLine mFrmServicePurchaseLine = null;
        private FrmProfessionalPurchaseLine mFrmProfessionalPurchaseLine = null;
        private FrmMiscPurchaseLine mFrmMiscPurchaseLine = null;
        private FrmTimeBillingPurchaseLine mFrmTimeBillingPurchaseLine = null;
        public bool ShowPurchaseLine(BOPurchaseLine model)
        {
            BaseView frm = null;

            if (model != null)
            {
                if (model is BOItemPurchaseLine)
                {
                    if (IsInvalid(mFrmItemPurchaseLine))
                    {
                        mFrmItemPurchaseLine = new FrmItemPurchaseLine(mApplicationController, model as BOItemPurchaseLine);
                    }
                    else
                    {
                        mFrmItemPurchaseLine.Model = model as BOItemPurchaseLine;
                        mFrmItemPurchaseLine.UpdateView();
                    }
                    frm = mFrmItemPurchaseLine;
                }
                else if (model is BOServicePurchaseLine)
                {
                    if (IsInvalid(mFrmServicePurchaseLine))
                    {
                        mFrmServicePurchaseLine = new FrmServicePurchaseLine(mApplicationController, model as BOServicePurchaseLine);
                    }
                    else
                    {
                        mFrmServicePurchaseLine.Model = model as BOServicePurchaseLine;
                        mFrmServicePurchaseLine.UpdateView();
                    }
                    frm = mFrmServicePurchaseLine;
                }
                else if (model is BOProfessionalPurchaseLine)
                {
                    if (IsInvalid(mFrmProfessionalPurchaseLine))
                    {
                        mFrmProfessionalPurchaseLine = new FrmProfessionalPurchaseLine(mApplicationController, model as BOProfessionalPurchaseLine);
                    }
                    else
                    {
                        mFrmProfessionalPurchaseLine.Model = model as BOProfessionalPurchaseLine;
                        mFrmProfessionalPurchaseLine.UpdateView();
                    }
                    frm = mFrmProfessionalPurchaseLine;
                }
                else if (model is BOTimeBillingPurchaseLine)
                {
                    if (IsInvalid(mFrmTimeBillingPurchaseLine))
                    {
                        mFrmTimeBillingPurchaseLine = new FrmTimeBillingPurchaseLine(mApplicationController, model as BOTimeBillingPurchaseLine);
                    }
                    else
                    {
                        mFrmTimeBillingPurchaseLine.Model = model as BOTimeBillingPurchaseLine;
                        mFrmTimeBillingPurchaseLine.UpdateView();
                    }
                    frm = mFrmTimeBillingPurchaseLine;
                }
                else if (model is BOMiscPurchaseLine)
                {
                    if (IsInvalid(mFrmMiscPurchaseLine))
                    {
                        mFrmMiscPurchaseLine = new FrmMiscPurchaseLine(mApplicationController, model as BOMiscPurchaseLine);
                    }
                    else
                    {
                        mFrmMiscPurchaseLine.Model = model as BOMiscPurchaseLine;
                        mFrmMiscPurchaseLine.UpdateView();
                    }
                    frm = mFrmMiscPurchaseLine;
                }
            }

            if (frm != null)
            {
                return SetCurrentDlg(frm);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please select a valid purchase layout first!", "Current Purchase Layout: No Default");
                return false;
            }
        }

        private DacII.WinForms.Reports.Purchases.FrmRptPurchasesItem mFrmRptPurchasesItem = null;
        public void ShowPurchasesItemsRpt()
        {
            if (IsInvalid(mFrmRptPurchasesItem))
            {
                mFrmRptPurchasesItem = new DacII.WinForms.Reports.Purchases.FrmRptPurchasesItem(mApplicationController);
            }
            SetCurrentForm(mFrmRptPurchasesItem);
        }

        internal void PrintPurchase(Accounting.Report.Purchases.PurchasePrintPresenter report_presenter)
        {
            BaseView frm = new DacII.WinForms.Purchases.Reports.FrmPurchase(mApplicationController, report_presenter);
            SetCurrentForm(frm);
        }


    }
}
