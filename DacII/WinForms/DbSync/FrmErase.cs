using System;
using System.Windows.Forms;


namespace DacII.WinForms.DbSync
{
    using DacII.Presenters;
    using Accounting.Bll;

    public partial class FrmErase : BaseView
    {
        public FrmErase(ApplicationPresenter ap)
            : base(ap)
        {
            InitializeComponent();
        }

        private void TriggerCmd_Erase(object sender, EventArgs args)
        {
            TriggerAccess_Erase();
        }

        private void TriggerAccess_Erase()
        {
            if (MessageBox.Show("Your erase action is not recoverable, are you sure you want to proceed?", "Erase Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            Accountant acc = mApplicationController.mAccountant;
            if (chkEraseAuthorization.Checked)
            {
                bool doErase=true;
                if(chkEraseAuthentication.Checked==false)
                {
                    if (MessageBox.Show("Erasing Authorization will also erase authentication, are you sure you want to proceed?", "Erase Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        doErase = false;
                    }
                }
                if(doErase)
                {
                    acc.AuthRoleMgr.RecreateTable();
                    acc.AuthItemMgr.RecreateTable();
                    acc.AuthUserMgr.RecreateTable();
                }
            }
            if (chkEraseAuthentication.Checked)
            {
                acc.AuthUserMgr.RecreateTable();
            }
            if (chkEraseItemAddOn.Checked)
            {
                acc.ItemAddOnMgr.RecreateTable();
            }
            if (chkEraseDataFields.Checked)
            {
                acc.ItemDataFieldEntryMgr.RecreateTable();
                acc.DataFieldMgr.RecreateTable();
            }
        }
    }
}
