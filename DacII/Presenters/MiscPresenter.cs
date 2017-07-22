
namespace DacII.Presenters
{
    using System.Windows.Forms;
    
    using Accounting.Bll.Util;
    
    using DacII.WinForms;
    using DacII.WinForms.Email;
    using DacII.WinForms.Setup;
    public class MiscPresenter : ModulePresenter
    {

        public MiscPresenter(ApplicationPresenter ap, FrmDac shell)
            : base(ap, shell)
        {
            
        }

        public bool BackupEnabled
        {
            set
            {
                mShell.BackupEnabled = value;
            }
        }

        #region ShowMyob
        private DacII.WinForms.Util.FrmMyobSql mFrmMyob = null;
        public void ShowMyob()
        {
            if (IsInvalid(mFrmMyob))
            {
                mFrmMyob = new DacII.WinForms.Util.FrmMyobSql(mApplicationController);
            }
            SetCurrentForm(mFrmMyob);
        }
        #endregion

        #region ShowCmd
        private FrmCmd mFrmCmd=null;
        public void ShowCmd()
        {
            if (IsInvalid(mFrmCmd))
            {
                mFrmCmd = new FrmCmd(mApplicationController);
                mFrmCmd.MdiParent = mShell;
                mFrmCmd.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            SetCurrentForm(mFrmCmd);
        }
        #endregion


        private FrmEmail mFrmEmail = null;
        public void ShowEmail(BOEmail model)
        {
            if (IsInvalid(mFrmEmail))
            {
                mFrmEmail = new DacII.WinForms.Email.FrmEmail(mApplicationController, model);
            }
            else
            {
                mFrmEmail.UpdateView();
            }
            SetCurrentDlg(mFrmEmail);
        }

        public void ShowBarcodeReader(DacII.WinForms.Util.FrmReadBarcode.BarcodeReadHandler handler)
        {
            DacII.WinForms.Util.FrmReadBarcode frm = new DacII.WinForms.Util.FrmReadBarcode(mApplicationController);
            if (handler != null)
            {
                frm.BarcodeRead += handler;
            }
            frm.MdiParent = mShell;
            frm.DoShow();
        }       

       

        #region ShowUserGuide
        private DacII.WinForms.Help.FrmUserGuide mFrmUserGuide = null;
        public void ShowUserGuide()
        {
            if (IsInvalid(mFrmUserGuide))
            {
                mFrmUserGuide = new DacII.WinForms.Help.FrmUserGuide(mApplicationController);
            }
            SetCurrentForm(mFrmUserGuide);
        }
        #endregion

        #region ShowAbout
        private DacII.WinForms.Help.FrmAbout mFrmAbout = null;
        public void ShowAbout()
        {
            if (IsInvalid(mFrmAbout))
            {
                mFrmAbout = new DacII.WinForms.Help.FrmAbout(mApplicationController);
            }
            SetCurrentForm(mFrmAbout);
        }
        #endregion

        #region ShowBackupOptions
        private DacII.WinForms.DbSync.FrmBackup mFrmBackup = null;
        public void ShowBackupOptions()
        {
            if (IsInvalid(mFrmBackup))
            {
                mFrmBackup = new DacII.WinForms.DbSync.FrmBackup(mApplicationController);
            }
            SetCurrentForm(mFrmBackup);
        }
        #endregion

        #region ShowEraseOptions
        private DacII.WinForms.DbSync.FrmErase mFrmErase = null;
        public void ShowEraseOptions()
        {
            if (IsInvalid(mFrmErase))
            {
                mFrmErase = new DacII.WinForms.DbSync.FrmErase(mApplicationController);
            }
            SetCurrentForm(mFrmErase);
        }
        #endregion


        FrmTermsRegister mFrmTermsRegister = null;
        internal void ShowTerms()
        {
            if (IsInvalid(mFrmTermsRegister))
            {
                mFrmTermsRegister = new FrmTermsRegister(mApplicationController);
            }
            SetCurrentForm(mFrmTermsRegister);
        }

        FrmTaxCodesRegister mFrmTaxCodesRegister = null;
        public void ShowTaxCodes()
        {
            if (IsInvalid(mFrmTaxCodesRegister))
            {
                mFrmTaxCodesRegister = new FrmTaxCodesRegister(mApplicationController);
            }
            SetCurrentForm(mFrmTaxCodesRegister);
        }

        FrmCurrencyRegister mFrmCurrencyRegister = null;
        public void ShowCurrencies()
        {
            if (IsInvalid(mFrmCurrencyRegister))
            {
                mFrmCurrencyRegister = new FrmCurrencyRegister(mApplicationController);
            }
            SetCurrentForm(mFrmCurrencyRegister);
        }
    }
}
