using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacII.Presenters
{
    using DacII.WinForms;

    using Accounting.Bll;
    using Accounting.Bll.Definitions;

    public class DefinitionPresenter : ModulePresenter
    {
        public DefinitionPresenter(ApplicationPresenter ap, FrmDac shell)
            : base(ap, shell)
        {

        }

        private DacII.WinForms.Definitions.FrmItemSize mFrmItemSizeForItemAddOn = null;
        public void ShowItemSizeForItemAddOn(BOItemSize model)
        {
            if (IsInvalid(mFrmItemSizeForItemAddOn))
            {
                mFrmItemSizeForItemAddOn = new DacII.WinForms.Definitions.FrmItemSize(mApplicationController, model);
            }
            else
            {
                mFrmItemSizeForItemAddOn.Model = model;
                mFrmItemSizeForItemAddOn.UpdateView();
            }
            SetCurrentDlg(mFrmItemSizeForItemAddOn);
        }

        private DacII.WinForms.Definitions.FrmItemSizesRegister mFrmItemSizesRegister = null;
        public void ShowItemSizesForItemAddOn(BOListItemSize model)
        {
            if (IsInvalid(mFrmItemSizesRegister))
            {
                mFrmItemSizesRegister = new DacII.WinForms.Definitions.FrmItemSizesRegister(mApplicationController, model);
            }
            SetCurrentForm(mFrmItemSizesRegister);
        }

        private DacII.WinForms.Definitions.FrmDataField mFrmDataFieldForItemAddOn = null;
        public void ShowDataFieldForItemAddOn(BODataField model)
        {
            if (IsInvalid(mFrmDataFieldForItemAddOn))
            {
                mFrmDataFieldForItemAddOn = new DacII.WinForms.Definitions.FrmDataField(mApplicationController, model);
            }
            else
            {
                mFrmDataFieldForItemAddOn.Model = model;
                mFrmDataFieldForItemAddOn.UpdateView();
            }
            SetCurrentDlg(mFrmDataFieldForItemAddOn);
        }

        private DacII.WinForms.Definitions.FrmDataFieldsRegister mFrmDataFieldsRegister = null;
        public void ShowDataFieldsForItemAddOn(BOListDataField model)
        {
            if (IsInvalid(mFrmDataFieldsRegister))
            {
                mFrmDataFieldsRegister = new DacII.WinForms.Definitions.FrmDataFieldsRegister(mApplicationController, model);
            }
            SetCurrentForm(mFrmDataFieldsRegister);
        }

        private DacII.WinForms.Definitions.FrmGender mFrmGenderForItemAddOn = null;
        public void ShowGenderForItemAddOn(BOGender model)
        {
            if (IsInvalid(mFrmGenderForItemAddOn))
            {
                mFrmGenderForItemAddOn = new DacII.WinForms.Definitions.FrmGender(mApplicationController, model);
            }
            else
            {
                mFrmGenderForItemAddOn.Model = model;
                mFrmGenderForItemAddOn.UpdateView();
            }
            SetCurrentDlg(mFrmGenderForItemAddOn);
        }

        private DacII.WinForms.Definitions.FrmGendersRegister mFrmGendersRegister = null;
        public void ShowGendersForItemAddOn(BOListGender model)
        {
            if (IsInvalid(mFrmGendersRegister))
            {
                mFrmGendersRegister = new DacII.WinForms.Definitions.FrmGendersRegister(mApplicationController, model);
            }
            SetCurrentForm(mFrmGendersRegister);
        }
    }
}
