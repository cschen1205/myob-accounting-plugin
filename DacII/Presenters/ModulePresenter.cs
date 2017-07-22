using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacII.Presenters
{
    using DacII.WinForms;

    public class ModulePresenter : Notifier
    {
        protected FrmDac mShell = null;
        protected ApplicationPresenter mApplicationController;

        public ModulePresenter(ApplicationPresenter ap, FrmDac shell)
        {
            mApplicationController = ap;
            mShell = shell;
        }

        protected bool IsInvalid(BaseView frm)
        {
            return frm == null || frm.IsDisposed;
        }

        protected void SetCurrentForm(BaseView frm)
        {
            frm.MdiParent = mShell;
            frm.DoShow();
        }

        protected bool SetCurrentDlg(BaseView frm)
        {
            return frm.DoDialog();
        }
    }
}
