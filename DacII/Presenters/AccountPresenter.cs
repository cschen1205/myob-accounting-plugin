using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacII.Presenters
{
    using DacII.WinForms;

    using Accounting.Bll;
    using Accounting.Bll.Accounts;
    using Accounting.Bll.Journals;

    using DacII.WinForms.Accounts;
    using DacII.WinForms.Journals;
    using DacII.WinForms.Analysis;
    public class AccountPresenter : ModulePresenter
    {
        public AccountPresenter(ApplicationPresenter ap, FrmDac shell)
            : base(ap, shell)
        {

        }

        private FrmAccount mFrmAccount = null;
        public void ShowAccount(BOAccount model)
        {
            if (IsInvalid(mFrmAccount))
            {
                mFrmAccount = new FrmAccount(mApplicationController, model);
            }
            else
            {
                mFrmAccount.Model = model;
                mFrmAccount.UpdateView();
            }
            SetCurrentForm(mFrmAccount);
        }

        private FrmAccountsRegister mFrmAccountsRegister = null;
        public void ShowAccounts(BOListAccount model)
        {
            if (IsInvalid(mFrmAccountsRegister))
            {
                mFrmAccountsRegister = new FrmAccountsRegister(mApplicationController, model);
            }
            SetCurrentForm(mFrmAccountsRegister);
        }

        private FrmTransactionJournals mFrmTransactionJournals = null;
        public void ShowTransactionJournals(BOListTransactionJournal model)
        {
            if (mApplicationController.CheckAccess(BOType.BOListTransactionJournal, BOPropertyAttrType.Visible))
            {
                if (IsInvalid(mFrmTransactionJournals))
                {
                    mFrmTransactionJournals = new FrmTransactionJournals(mApplicationController, model);
                }
                SetCurrentForm(mFrmTransactionJournals);
            }
        }

        private FrmBalanceSheet mFrmBalanceSheet = null;
        public void ShowBalanceSheetForAccountsAnalysis(BOListAccount model)
        {
            if (IsInvalid(mFrmBalanceSheet))
            {
                mFrmBalanceSheet = new FrmBalanceSheet(mApplicationController, model);
            }
            SetCurrentForm(mFrmBalanceSheet);
        }

        private DacII.WinForms.Analysis.FrmPLStatement mFrmProfitAndLoss = null;
        public void ShowProfitAndLossForAccountsAnalysis(BOListAccount model)
        {
            if (IsInvalid(mFrmProfitAndLoss))
            {
                mFrmProfitAndLoss = new DacII.WinForms.Analysis.FrmPLStatement(mApplicationController, model);
            }
            SetCurrentForm(mFrmProfitAndLoss);
        }

        private DacII.WinForms.Reports.Accounts.BalanceSheets.FrmBalanceSheet mFrmRptBalanceSheet = null;
        public void ShowBalanceSheetForAccountRpt()
        {
            if (IsInvalid(mFrmRptBalanceSheet))
            {
                mFrmRptBalanceSheet = new DacII.WinForms.Reports.Accounts.BalanceSheets.FrmBalanceSheet(mApplicationController);
            }
            SetCurrentForm(mFrmRptBalanceSheet);
        }

        private DacII.WinForms.Reports.Accounts.PLStatements.FrmPLStatement mFrmPLStatement = null;
        public void ShowProfitAndLossForAccountRpt()
        {
            if (IsInvalid(mFrmPLStatement))
            {
                mFrmPLStatement = new DacII.WinForms.Reports.Accounts.PLStatements.FrmPLStatement(mApplicationController);
            }
            SetCurrentForm(mFrmPLStatement);
        }
    }
}
