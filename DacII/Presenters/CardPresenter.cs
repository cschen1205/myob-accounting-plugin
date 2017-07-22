using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacII.Presenters
{
    using DacII.WinForms;

    using Accounting.Bll;
    using Accounting.Bll.Cards;
    using DacII.WinForms.Reports.Card.Cards;

    using DacII.WinForms.Cards;
    public class CardPresenter : ModulePresenter
    {
        public CardPresenter(ApplicationPresenter ap, FrmDac shell)
            : base(ap, shell)
        {

        }

        private DacII.WinForms.Cards.FrmCardsRegister mFrmCards = null;
        public void ShowCards(BOListCard model)
        {
            if (mApplicationController.CheckAccess(BOType.BOListCard, BOPropertyAttrType.Visible))
            {
                if (IsInvalid(mFrmCards))
                {
                    mFrmCards = new FrmCardsRegister(mApplicationController, model);
                }
                else
                {
                    mFrmCards.Model = model;
                    mFrmCards.UpdateView();
                }
                SetCurrentForm(mFrmCards);
            }
        }

        private FrmSupplier mFrmSupplier = null;
        private FrmCustomer mFrmCustomer = null;
        private FrmEmployee mFrmEmployee = null;
        public void ShowCard(BOCard model)
        {
            if (model == null) return;

            if (model is BOSupplier)
            {
                if (IsInvalid(mFrmSupplier))
                {
                    mFrmSupplier = new FrmSupplier(mApplicationController, model as BOSupplier);
                }
                else
                {
                    mFrmSupplier.Model = model as BOSupplier;
                    mFrmSupplier.UpdateView();
                }
                SetCurrentForm(mFrmSupplier);
            }
            else if (model is BOCustomer)
            {
                if (IsInvalid(mFrmCustomer))
                {
                    mFrmCustomer = new FrmCustomer(mApplicationController, model as BOCustomer);
                }
                else
                {
                    mFrmCustomer.Model = model as BOCustomer;
                    mFrmCustomer.UpdateView();
                }
                SetCurrentForm(mFrmCustomer);
            }
            else if (model is BOEmployee)
            {
                if (IsInvalid(mFrmEmployee))
                {
                    mFrmEmployee = new FrmEmployee(mApplicationController, model as BOEmployee);
                }
                else
                {
                    mFrmEmployee.Model = model as BOEmployee;
                    mFrmEmployee.UpdateView();
                }
                SetCurrentForm(mFrmEmployee);
            }
        }

        FrmCardListSummary mFrmCardListSummary = null;
        internal void ShowCardListSummaryRpt()
        {
            if (IsInvalid(mFrmCardListSummary))
            {
                mFrmCardListSummary = new FrmCardListSummary(mApplicationController);
            }
            SetCurrentForm(mFrmCardListSummary);
        }
    }
}
