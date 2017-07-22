using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacII.Presenters
{
    using DacII.WinForms;
    using Accounting.Bll.Company;
    using DacII.WinForms.Setup;
    public class SetupPresenter : ModulePresenter
    {
        public SetupPresenter(ApplicationPresenter ap, FrmDac shell)
            : base(ap, shell)
        {

        }


        public void PrintCompany(BOCompany model)
        {
            DacII.WinForms.Setup.Reports.FrmCompany frm = new DacII.WinForms.Setup.Reports.FrmCompany(mApplicationController, model);
           

            SetCurrentForm(frm);
        }

        private FrmDataFileInformation mFrmMainSetup = null;
        public void ShowCompany(BOCompany model)
        {
            if (IsInvalid(mFrmMainSetup))
            {
                mFrmMainSetup = new FrmDataFileInformation(mApplicationController, model);
            }
            else
            {
                mFrmMainSetup.Model = model;
                mFrmMainSetup.UpdateView();
            }
            SetCurrentForm(mFrmMainSetup);
        }
    }
}
