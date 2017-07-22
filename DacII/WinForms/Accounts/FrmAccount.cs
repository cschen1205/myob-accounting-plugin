using System;
using System.Windows.Forms;

namespace DacII.WinForms.Accounts
{
    using DacII.Presenters;
    using DacII.ViewModels;
    using Accounting.Core;
    using Accounting.Bll.Accounts;
    using Accounting.Core.Accounts;

    public partial class FrmAccount : BaseView
    {
        private BOAccount mModel;
        private BOViewModel mViewModel;

        public FrmAccount(ApplicationPresenter ap, BOAccount model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;
            mViewModel = new BOViewModel(mModel);
            mViewModel.ErrorProvider = errorProvider;

            BindViews();
            RegisterEventHandlers();

            ConfigureDataGridView(dgvAccountHistory);
        }

        public BOAccount Model
        {
            set
            {
                mModel = value;
                mViewModel.Model = mModel;
            }
        }

        protected override void BindViews()
        {
            cboAccountType.DataSource = mApplicationController.FindAllAccountTypes();
            cboSubAccountType.DataSource = mApplicationController.FindAllSubAccountTypes();
            cboAccountClassification.DataSource = mApplicationController.FindAllAccountClassifications();
            cboCashFlowClassification.DataSource = mApplicationController.FindAllCashFlowClassification();
            cboTaxCode.DataSource = mApplicationController.FindAllTaxCodes();

            mViewModel.BindView(BOAccount.ACCOUNT_NAME, lblAccountName, txtAccountName);
            mViewModel.BindView(BOAccount.ACCOUNT_TYPE, lblAccountType, cboAccountType);
            mViewModel.BindView(BOAccount.CURRENT_ACCOUNT_BALANCE, lblCurrentBalance, txtCurrentBalance);
            mViewModel.BindView(BOAccount.LINKED_ACCOUNT_TYPE_DESCRIPTION, btnLinkedAccount);
            mViewModel.BindView(BOAccount.ACCOUNT_NUMBER, lblAccountNumber, txtAccountNumber);
            mViewModel.BindView(BOAccount.PERSIST_OBJECT, btnRecord);
            mViewModel.BindView(BOAccount.ACCOUNT_CLASSIFICATION, lblAccountClassification, cboAccountClassification);
            mViewModel.BindView(BOAccount.SUB_ACCOUNT_TYPE, lblSubAccountType, cboSubAccountType);
            mViewModel.BindView(BOAccount.IS_ACTIVE, chkActive);
            mViewModel.BindView(BOAccount.TAX_CODE, lblTaxCode, cboTaxCode);
            mViewModel.BindView(BOAccount.CASH_FLOW_CLASSIFICATION, lblCashFlowClassification, cboCashFlowClassification);
            mViewModel.BindView(BOAccount.DESCRIPTION, lblDescription, txtDescription);
            mViewModel.BindView(BOAccount.IS_TOTAL, chkIsTotal);
            mViewModel.BindView(BOAccount.LINKED_ACCOUNT_TYPE_DESCRIPTION, lblLinkedAccount);
            mViewModel.BindView(BOAccount.BSB_CODE, lblBSBCode, txtBSBCode);
            mViewModel.BindView(BOAccount.BANK_ACCOUNT_NUMBER, lblBankAccountNumber, txtBankAccountNumber);
            mViewModel.BindView(BOAccount.BANK_ACCOUNT_NAME, lblBankAccountName, txtBankAccountName);
            mViewModel.BindView(BOAccount.COMPANY_TRADING_NAME, lblCompanyTradingName, txtCompanyTradingName);
            mViewModel.BindView(BOAccount.CREATE_BANK_FILES, lblCreateBankFiles);
            mViewModel.BindView(BOAccount.CREATE_BANK_FILES, chkCreateBankFiles);
            mViewModel.BindView(BOAccount.BANK_CODE, lblBankCode, txtBankCode);
            mViewModel.BindView(BOAccount.DIRECT_ENTRY_USER_ID, lblDirectEntryUserID, txtDirectEntryUserID);
            mViewModel.BindView(BOAccount.IS_SELF_BALANCING, lblIsSelfBalancing);
            mViewModel.BindView(BOAccount.IS_SELF_BALANCING, chkIsSelfBalancing);
        }

        private void Record(object sender, EventArgs args)
        {
            if (mViewModel.ValidateModel())
            {
                OpResult result = mModel.Record();
                if (result.Status == OpResult.ResultStatus.UpdatedWithException)
                {
                    MessageBox.Show(result.Error);
                }
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        private void ConfigureDataGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            DataGridViewColumn c = null;

            if (dgv == dgvAccountHistory)
            {
                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "Month";
                c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                c.HeaderText = "Month";
                dgv.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                c.DataPropertyName = "CurrentFYBalance";
                c.HeaderText = string.Format("Current FY {0}", mModel.CurrentFinancialYear);
                dgv.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                c.DataPropertyName = "LastFYBalance";
                c.HeaderText = string.Format("Last FY {0}", mModel.LastFinancialYear);
                dgv.Columns.Add(c);
            }

            DacII.Util.DataGridViewHelper.UpdateColumnHeaderStyles(dgv);
        }

        protected override void LoadView()
        {
            mViewModel.UpdateView();
            if (mModel.IsBank)
            {
                if (!tc.TabPages.Contains(tpBanking))
                {
                    tc.TabPages.Add(tpBanking);
                }
            }
            else
            {
                if (tc.TabPages.Contains(tpBanking))
                {
                    tc.TabPages.Remove(tpBanking);
                }
            }
            dgvAccountHistory.DataSource = mModel.AccountHistories;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void cboAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            AccountType acctype=cboAccountType.SelectedItem as AccountType;
            if (acctype.IsHeader)
            {
                if(mModel.IsCreating) cboAccountClassification.Enabled = true;
                cboSubAccountType.Visible = false;
                lblSubAccountType.Visible = false;
            }
            else
            {
                if(mModel.IsCreating) cboSubAccountType.Visible = true;
                lblSubAccountType.Visible = true;
                cboAccountClassification.Enabled = false;
            }
        }

        private void chkCreateBankFiles_CheckedChanged(object sender, EventArgs e)
        {
            bool shown = chkCreateBankFiles.Checked;
            lblBankCode.Visible = txtBankCode.Visible = shown;
            lblDirectEntryUserID.Visible = txtDirectEntryUserID.Visible = shown;
            lblIsSelfBalancing.Visible = chkIsSelfBalancing.Visible = shown;
        }
    }
}
