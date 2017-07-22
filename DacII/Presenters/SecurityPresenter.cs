using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacII.Presenters
{
    using DacII.WinForms;
    using DacII.WinForms.Security;

    using Accounting.Core.Security;
    using Accounting.Bll.Security;

    public class SecurityPresenter : ModulePresenter
    {
        public SecurityPresenter(ApplicationPresenter ap, FrmDac shell)
            : base(ap, shell)
        {

        }

        private FrmSecurity mFrmSecurity = null;
        public void ShowSecurity()
        {
            if (IsInvalid(mFrmSecurity))
            {
                mFrmSecurity = new FrmSecurity(mApplicationController);
            }
            SetCurrentForm(mFrmSecurity);
        }

        private FrmAuthUser mFrmUser = null;
        public void ShowAuthUser(BOUser model)
        {
            if (IsInvalid(mFrmUser))
            {
                mFrmUser = new FrmAuthUser(mApplicationController, model);
            }
            else
            {
                mFrmUser.Model = model;
                mFrmUser.UpdateView();
            }
            SetCurrentDlg(mFrmUser);
        }

        public void ShowAuthRole(BORole model)
        {
            if (model == null) return;
            BaseView frm = new FrmAuthRole(mApplicationController, model);
            SetCurrentForm(frm);
        }

        
    }
}
