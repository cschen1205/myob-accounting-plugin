using System;
using System.Windows.Forms;

namespace DacII.WinForms.Cards
{
    using DacII.Presenters;
    using DacII.ViewModels;
    using DacII.Util;
    using DacII.DacHandlers;
    using DacII.WinForms.Util;

    using Accounting.Bll.Cards;
    using Accounting.Core.Definitions;

    public partial class FrmEmployee : BaseView
    {
        private BOEmployee mModel=null;
        private BOViewModel mViewModel;

        public FrmEmployee(ApplicationPresenter ap, BOEmployee model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;
            mViewModel = new BOViewModel(mModel);
            mViewModel.ErrorProvider = errorProvider;

            BindViews();
            RegisterEventHandlers();
        }

        public BOEmployee Model
        {
            set
            {
                mModel = value;
                mViewModel.Model = mModel;
            }
        }

        protected override void BindViews()
        {
            cboCurrencyCode.DataSource = mApplicationController.FindAllCurrencies();
            cboGender.DataSource = mApplicationController.FindAllGenders();
            cboNumberOfBankAccounts.DataSource = mApplicationController.FindNumberOfBankAccounts();
            cboBank1ValueType.DataSource = mApplicationController.FindAllBank1ValueTypes();
            cboBank2ValueType.DataSource = mApplicationController.FindAllBank2ValueTypes();
            cboBank3ValueType.DataSource = mApplicationController.FindAllBank3ValueTypes();
            cboEmploymentBasis.DataSource = mApplicationController.FindAllEmploymentBasis();
            cboPaymentType.DataSource = mApplicationController.FindAllPaymentTypes();
            cboEmploymentClassification.DataSource = mApplicationController.FindAllEmploymentClassifications();
            cboPayBasis.DataSource = mApplicationController.FindAllPayBasis();
            cboPayFrequency.DataSource = mApplicationController.FindAllPayFrequencies();
            cboWagesExpenseAccount.DataSource = mApplicationController.FindAllWagesExpenseAccounts();
            cboSuperannuationFund.DataSource = mApplicationController.FindAllSuperannuationFunds();
            cboTaxTable.DataSource = mApplicationController.FindAllTaxScales();
            cboEmploymentCategory.DataSource = mApplicationController.FindAllEmploymentCategories();
            cboEmploymentStatus.DataSource = mApplicationController.FindAllEmploymentStatuses();

            if (cboCurrencyCode.Items.Count > 0) cboCurrencyCode.SelectedIndex = 0;
            if (cboGender.Items.Count > 0) cboGender.SelectedIndex = 0;
            if (cboNumberOfBankAccounts.Items.Count > 0) cboNumberOfBankAccounts.SelectedIndex = 0;
            if (cboBank1ValueType.Items.Count > 0) cboBank1ValueType.SelectedIndex = 0;
            if (cboBank2ValueType.Items.Count > 0) cboBank2ValueType.SelectedIndex = 0;
            if (cboBank3ValueType.Items.Count > 0) cboBank3ValueType.SelectedIndex = 0;
            if (cboEmploymentBasis.Items.Count > 0) cboEmploymentBasis.SelectedIndex = 0;
            if (cboPaymentType.Items.Count > 0) cboPaymentType.SelectedIndex = 0;
            if (cboEmploymentClassification.Items.Count > 0) cboEmploymentClassification.SelectedIndex = 0;
            if (cboPayBasis.Items.Count > 0) cboPayBasis.SelectedIndex = 0;
            if (cboPayFrequency.Items.Count > 0) cboPayFrequency.SelectedIndex = 0;
            if (cboWagesExpenseAccount.Items.Count > 0) cboWagesExpenseAccount.SelectedIndex = 0;
            if (cboSuperannuationFund.Items.Count > 0) cboSuperannuationFund.SelectedIndex = 0;
            if (cboTaxTable.Items.Count > 0) cboTaxTable.SelectedIndex = 0;
            if (cboEmploymentCategory.Items.Count > 0) cboEmploymentCategory.SelectedIndex = 0;
            if (cboEmploymentStatus.Items.Count > 0) cboEmploymentStatus.SelectedIndex = 0;

            mViewModel.BindView(BOEmployee.CARD_IDENTIFICATION, lblEmployeeCardID, txtEmployeeCardID);
            mViewModel.BindView(BOEmployee.FIRST_NAME, lblFirstName, txtFirstName);
            mViewModel.BindView(BOEmployee.LAST_NAME, lblLastName, txtLastName);
            mViewModel.BindView(BOEmployee.IS_ACTIVE, chkActive);
            mViewModel.BindView(BOEmployee.IS_INDIVIDUAL, chkIndividual);
            mViewModel.BindView(BOEmployee.CURRENCY, lblCurrencyCode, cboCurrencyCode);
            mViewModel.BindView(BOEmployee.GENDER, lblGender, cboGender);
            mViewModel.BindView(BOEmployee.PICTURE, lblPicture);
            mViewModel.BindView(BOEmployee.NOTES, lblNotes, txtNotes);
            mViewModel.BindView(BOEmployee.CUSTOM_FIELD1, lblCustomField1, txtCustomField1);
            mViewModel.BindView(BOEmployee.CUSTOM_FIELD2, lblCustomField2, txtCustomField2);
            mViewModel.BindView(BOEmployee.CUSTOM_FIELD3, lblCustomField3, txtCustomField3);
            mViewModel.BindView(BOEmployee.HOURLY_BILLING_RATE, lblHourlyBillingRate, txtHourlyBillingRate);
            mViewModel.BindView(BOEmployee.ESTIMATED_COST_PER_HOUR, lblCostPerHour, txtCostPerHour);
            mViewModel.BindView(BOEmployee.NUMBER_OF_BANK_ACCOUNTS, lblNumberOfBankAccounts, cboNumberOfBankAccounts);
            mViewModel.BindView(BOEmployee.BANK1_BSB, lblBank1BSB, txtBank1BSB);
            mViewModel.BindView(BOEmployee.BANK1_ACCOUNT_NAME, lblBank1AccountName, txtBank1AccountName);
            mViewModel.BindView(BOEmployee.BANK1_ACCOUNT_NUMBER, lblBank1AccountNumber, txtBank1AccountNumber);
            mViewModel.BindView(BOEmployee.BANK1_VALUE, lblBank1Value, txtBank1Value);
            mViewModel.BindView(BOEmployee.BANK1_VALUE_TYPE, lblBank1Value, cboBank1ValueType);
            mViewModel.BindView(BOEmployee.BANK2_BSB, lblBank2BSB, txtBank2BSB);
            mViewModel.BindView(BOEmployee.BANK2_ACCOUNT_NAME, lblBank2AccountName, txtBank2AccountName);
            mViewModel.BindView(BOEmployee.BANK2_ACCOUNT_NUMBER, lblBank2AccountNumber, txtBank2AccountNumber);
            mViewModel.BindView(BOEmployee.BANK2_VALUE, lblBank2Value, txtBank2Value);
            mViewModel.BindView(BOEmployee.BANK2_VALUE_TYPE, lblBank2Value, cboBank2ValueType);
            mViewModel.BindView(BOEmployee.BANK3_BSB, lblBank3BSB, txtBank3BSB);
            mViewModel.BindView(BOEmployee.BANK3_ACCOUNT_NAME, lblBank3AccountName, txtBank3AccountName);
            mViewModel.BindView(BOEmployee.BANK3_ACCOUNT_NUMBER, lblBank3AccountNumber, txtBank3AccountNumber);
            mViewModel.BindView(BOEmployee.BANK3_VALUE, lblBank3Value, txtBank3Value);
            mViewModel.BindView(BOEmployee.BANK3_VALUE_TYPE, lblBank3Value, cboBank3ValueType);
            mViewModel.BindView(BOEmployee.EMPLOYMENT_BASIS, lblEmploymentBasis, cboEmploymentBasis);
            mViewModel.BindView(BOEmployee.PAYMENT_TYPE, lblPaymentType, cboPaymentType);
            mViewModel.BindView(BOEmployee.EMPLOYMENT_CLASSIFICATION, lblEmploymentClassification, cboEmploymentClassification);
            mViewModel.BindView(BOEmployee.DATE_OF_BIRTH, lblDateOfBirth, dtpDateOfBirth);
            mViewModel.BindView(BOEmployee.START_DATE, lblStartDate, dtpStartDate);
            mViewModel.BindView(BOEmployee.TERMINATION_DATE, lblTerminationDate, dtpTerminationDate);
            mViewModel.BindView(BOEmployee.PAY_BASIS, lblPayBasis, cboPayBasis);
            mViewModel.BindView(BOEmployee.BASE_PAY, lblBasePay, txtBasePay);
            mViewModel.BindView(BOEmployee.PAY_FREQUENCY, lblPayFrequency, cboPayFrequency);
            mViewModel.BindView(BOEmployee.HOURS_IN_PAY_PERIOD, lblHoursInPayPeriod, txtHoursInPayPeriod);
            mViewModel.BindView(BOEmployee.WAGES_EXPENSE_ACCOUNT, lblWagesExpenseAccount, cboWagesExpenseAccount);
            mViewModel.BindView(BOEmployee.SUPERANNUATION_FUND, lblSuperannuationFund, cboSuperannuationFund);
            mViewModel.BindView(BOEmployee.SUPERANNUATION_MEMBERSHIP_NUMBER, lblEmployeeMembershipNumber, txtEmployeeMembershipNumber);
            mViewModel.BindView(BOEmployee.TAX_FILE_NUMBER, lblTaxFileNumber, txtTaxFileNumber);
            mViewModel.BindView(BOEmployee.TAX_SCALE, lblTaxTable, cboTaxTable);
            mViewModel.BindView(BOEmployee.WITHHOLDING_VARIATION_RATE, lblWithholdingVariationRate, txtWithholdingVariationRate);
            mViewModel.BindView(BOEmployee.TOTAL_REBATES, lblTotalRebate, txtTotalRebate);
            mViewModel.BindView(BOEmployee.EXTRA_TAX, lblExtraTax, txtExtraTax);
            mViewModel.BindView(BOEmployee.EMPLOYMENT_CATEGORY, lblEmploymentCategory, cboEmploymentCategory);
            mViewModel.BindView(BOEmployee.EMPLOYMENT_STATUS, lblEmploymentStatus, cboEmploymentStatus);

            mViewModel.BindView(BOEmployee.ADDRESS1_LINE1, lblAddressLine11, txtAddressLine11);
            mViewModel.BindView(BOEmployee.ADDRESS1_LINE2, lblAddressLine12, txtAddressLine12);
            mViewModel.BindView(BOEmployee.ADDRESS1_LINE3, lblAddressLine13, txtAddressLine13);
            mViewModel.BindView(BOEmployee.ADDRESS1_LINE4, lblAddressLine14, txtAddressLine14);
            mViewModel.BindView(BOEmployee.ADDRESS1_PHONE1, lblPhone11, txtPhone11);
            mViewModel.BindView(BOEmployee.ADDRESS1_PHONE2, lblPhone21, txtPhone21);
            mViewModel.BindView(BOEmployee.ADDRESS1_PHONE3, lblPhone31, txtPhone31);
            mViewModel.BindView(BOEmployee.ADDRESS1_CITY, lblCity1, txtCity1);
            mViewModel.BindView(BOEmployee.ADDRESS1_COUNTRY, lblCountry1, txtCountry1);
            mViewModel.BindView(BOEmployee.ADDRESS1_EMAIL, lblEmail1, txtEmail1);
            mViewModel.BindView(BOEmployee.ADDRESS1_WEBSITE, lblWeb1, txtWeb1);
            mViewModel.BindView(BOEmployee.ADDRESS1_FAX, lblFax1, txtFax1);
            mViewModel.BindView(BOEmployee.ADDRESS1_STATE, lblState1, txtState1);
            mViewModel.BindView(BOEmployee.ADDRESS1_POSTCODE, lblPostcode1, txtPostcode1);

            mViewModel.BindView(BOEmployee.ADDRESS2_LINE1, lblAddressLine21, txtAddressLine21);
            mViewModel.BindView(BOEmployee.ADDRESS2_LINE2, lblAddressLine22, txtAddressLine22);
            mViewModel.BindView(BOEmployee.ADDRESS2_LINE3, lblAddressLine23, txtAddressLine23);
            mViewModel.BindView(BOEmployee.ADDRESS2_LINE4, lblAddressLine24, txtAddressLine24);
            mViewModel.BindView(BOEmployee.ADDRESS2_PHONE1, lblPhone12, txtPhone12);
            mViewModel.BindView(BOEmployee.ADDRESS2_PHONE2, lblPhone22, txtPhone22);
            mViewModel.BindView(BOEmployee.ADDRESS2_PHONE3, lblPhone32, txtPhone32);
            mViewModel.BindView(BOEmployee.ADDRESS2_CITY, lblCity2, txtCity2);
            mViewModel.BindView(BOEmployee.ADDRESS2_COUNTRY, lblCountry2, txtCountry2);
            mViewModel.BindView(BOEmployee.ADDRESS2_EMAIL, lblEmail2, txtEmail2);
            mViewModel.BindView(BOEmployee.ADDRESS2_WEBSITE, lblWeb2, txtWeb2);
            mViewModel.BindView(BOEmployee.ADDRESS2_FAX, lblFax2, txtFax2);
            mViewModel.BindView(BOEmployee.ADDRESS2_STATE, lblState2, txtState2);
            mViewModel.BindView(BOEmployee.ADDRESS2_POSTCODE, lblPostcode2, txtPostcode2);

            mViewModel.BindView(BOEmployee.ADDRESS3_LINE1, lblAddressLine31, txtAddressLine31);
            mViewModel.BindView(BOEmployee.ADDRESS3_LINE2, lblAddressLine32, txtAddressLine32);
            mViewModel.BindView(BOEmployee.ADDRESS3_LINE3, lblAddressLine33, txtAddressLine33);
            mViewModel.BindView(BOEmployee.ADDRESS3_LINE4, lblAddressLine34, txtAddressLine34);
            mViewModel.BindView(BOEmployee.ADDRESS3_PHONE1, lblPhone13, txtPhone13);
            mViewModel.BindView(BOEmployee.ADDRESS3_PHONE2, lblPhone23, txtPhone23);
            mViewModel.BindView(BOEmployee.ADDRESS3_PHONE3, lblPhone33, txtPhone33);
            mViewModel.BindView(BOEmployee.ADDRESS3_CITY, lblCity3, txtCity3);
            mViewModel.BindView(BOEmployee.ADDRESS3_COUNTRY, lblCountry3, txtCountry3);
            mViewModel.BindView(BOEmployee.ADDRESS3_EMAIL, lblEmail3, txtEmail3);
            mViewModel.BindView(BOEmployee.ADDRESS3_WEBSITE, lblWeb3, txtWeb3);
            mViewModel.BindView(BOEmployee.ADDRESS3_FAX, lblFax3, txtFax3);
            mViewModel.BindView(BOEmployee.ADDRESS3_STATE, lblState3, txtState3);
            mViewModel.BindView(BOEmployee.ADDRESS3_POSTCODE, lblPostcode3, txtPostcode3);

            mViewModel.BindView(BOEmployee.ADDRESS4_LINE1, lblAddressLine41, txtAddressLine41);
            mViewModel.BindView(BOEmployee.ADDRESS4_LINE2, lblAddressLine42, txtAddressLine42);
            mViewModel.BindView(BOEmployee.ADDRESS4_LINE3, lblAddressLine43, txtAddressLine43);
            mViewModel.BindView(BOEmployee.ADDRESS4_LINE4, lblAddressLine44, txtAddressLine44);
            mViewModel.BindView(BOEmployee.ADDRESS4_PHONE1, lblPhone14, txtPhone14);
            mViewModel.BindView(BOEmployee.ADDRESS4_PHONE2, lblPhone24, txtPhone24);
            mViewModel.BindView(BOEmployee.ADDRESS4_PHONE3, lblPhone34, txtPhone34);
            mViewModel.BindView(BOEmployee.ADDRESS4_CITY, lblCity4, txtCity4);
            mViewModel.BindView(BOEmployee.ADDRESS4_COUNTRY, lblCountry4, txtCountry4);
            mViewModel.BindView(BOEmployee.ADDRESS4_EMAIL, lblEmail4, txtEmail4);
            mViewModel.BindView(BOEmployee.ADDRESS4_WEBSITE, lblWeb4, txtWeb4);
            mViewModel.BindView(BOEmployee.ADDRESS4_FAX, lblFax4, txtFax4);
            mViewModel.BindView(BOEmployee.ADDRESS4_STATE, lblState4, txtState4);
            mViewModel.BindView(BOEmployee.ADDRESS4_POSTCODE, lblPostcode4, txtPostcode4);

            mViewModel.BindView(BOEmployee.ADDRESS5_LINE1, lblAddressLine51, txtAddressLine51);
            mViewModel.BindView(BOEmployee.ADDRESS5_LINE2, lblAddressLine52, txtAddressLine52);
            mViewModel.BindView(BOEmployee.ADDRESS5_LINE3, lblAddressLine53, txtAddressLine53);
            mViewModel.BindView(BOEmployee.ADDRESS5_LINE4, lblAddressLine54, txtAddressLine54);
            mViewModel.BindView(BOEmployee.ADDRESS5_PHONE1, lblPhone15, txtPhone15);
            mViewModel.BindView(BOEmployee.ADDRESS5_PHONE2, lblPhone25, txtPhone25);
            mViewModel.BindView(BOEmployee.ADDRESS5_PHONE3, lblPhone35, txtPhone35);
            mViewModel.BindView(BOEmployee.ADDRESS5_CITY, lblCity5, txtCity5);
            mViewModel.BindView(BOEmployee.ADDRESS5_COUNTRY, lblCountry5, txtCountry5);
            mViewModel.BindView(BOEmployee.ADDRESS5_EMAIL, lblEmail5, txtEmail5);
            mViewModel.BindView(BOEmployee.ADDRESS5_WEBSITE, lblWeb5, txtWeb5);
            mViewModel.BindView(BOEmployee.ADDRESS5_FAX, lblFax5, txtFax5);
            mViewModel.BindView(BOEmployee.ADDRESS5_STATE, lblState5, txtState5);
            mViewModel.BindView(BOEmployee.ADDRESS5_POSTCODE, lblPostcode5, txtPostcode5);
            mViewModel.BindView(BOEmployee.PERSIST_OBJECT, btnUpdate);
            mViewModel.BindView(BOEmployee.DELETE_OBJECT, btnDel2);
        }

        private void Record(object sender, EventArgs args)
        {
            if (mViewModel.ValidateModel())
            {
                mModel.Record();
                LoadView_PaymentDetails();

                MessageBox.Show("Employee Record Saved!");
            }
        }

        private void Delete(object sender, EventArgs args)
        {
            if (MessageBox.Show("Do you want to delete the customer?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                mModel.Delete();
                GoBack();
            }
        }

        protected override void LoadView()
        {
            mViewModel.UpdateView();

            if (!string.IsNullOrEmpty(mModel.DefaultPicturePath))
            {
                pbPicture.Load(mModel.DefaultPicturePath);
            }

            LoadView_PaymentDetails();
        }

        protected override void RegisterEventHandlers()
        {
            RegisterEventHandler(chkIndividual, DacEventHandler.EventTypes.CheckedChanged, new EventHandler(chkIndividual_CheckedChanged));
            RegisterEventHandler(cboPaymentType, DacEventHandler.EventTypes.SelectedIndexChanged, new EventHandler(cboPaymentType_SelectedIndexChanged));
            RegisterEventHandler(cboNumberOfBankAccounts, DacEventHandler.EventTypes.SelectedIndexChanged, new EventHandler(cboNumberOfBankAccounts_SelectedIndexChanged));
        }

        private void cboPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadView_PaymentDetails();
        }

        private void cboNumberOfBankAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadView_PaymentDetails();
        }

        private void chkIndividual_CheckedChanged(object sender, EventArgs e)
        {
            bool first_name_visible = chkIndividual.Checked;

            txtFirstName.Visible = first_name_visible;
            lblFirstName.Visible = first_name_visible;

            if (!first_name_visible)
            {
                txtFirstName.Text = "";
                lblLastName.Text = "Name:";
            }
            else
            {
            lblLastName.Text = "Last Name:";
            }
        }

        private void LoadView_PaymentDetails()
        {
            bool bank1_visible = false;
            bool bank2_visible = false;
            bool bank3_visible = false;

            PaymentType selected_payment_type=(PaymentType)cboPaymentType.SelectedItem;
            if (selected_payment_type != null)
            {
                if (selected_payment_type.IsElectronic)
                {
                    if (cboNumberOfBankAccounts.SelectedIndex != -1)
                    {
                        string number_of_accounts_text = (string)cboNumberOfBankAccounts.SelectedItem;
                        int number_of_accounts = int.Parse(number_of_accounts_text);
                        if (number_of_accounts == 1)
                        {
                            bank1_visible=true;
                        }
                        else if (number_of_accounts == 2)
                        {
                            bank1_visible = true;
                            bank2_visible = true;
                        }
                        else if (number_of_accounts == 3)
                        {
                            bank1_visible = true;
                            bank2_visible = true;
                            bank3_visible = true;
                        }
                    }
                }
            }

            lblBank1.Visible = bank1_visible;
            lblBank1BSB.Visible = txtBank1BSB.Visible = bank1_visible;
            lblBank1AccountName.Visible = txtBank1AccountName.Visible = bank1_visible;
            lblBank1AccountNumber.Visible = txtBank1AccountNumber.Visible = bank1_visible;
            lblBank1Value.Visible = txtBank1Value.Visible = bank1_visible;
            cboBank1ValueType.Visible = bank1_visible;
            txtStatementText.Visible = bank1_visible;
            lblStatementText.Visible = bank1_visible;

            lblBank2.Visible = bank2_visible;
            lblBank2BSB.Visible = txtBank2BSB.Visible = bank2_visible;
            lblBank2AccountName.Visible = txtBank2AccountName.Visible = bank2_visible;
            lblBank2AccountNumber.Visible = txtBank2AccountNumber.Visible = bank2_visible;
            lblBank2Value.Visible = txtBank2Value.Visible = bank2_visible;
            cboBank2ValueType.Visible = bank2_visible;
            if (bank2_visible == false)
            {
                txtBank2BSB.Text = "";
                txtBank2AccountName.Text = "";
                txtBank2AccountNumber.Text = "";
                txtBank2Value.Text = "";
                cboBank2ValueType.SelectedIndex = -1;
            }

            lblBank3.Visible = bank3_visible;
            lblBank3BSB.Visible = txtBank3BSB.Visible = bank3_visible;
            lblBank3AccountName.Visible = txtBank3AccountName.Visible = bank3_visible;
            lblBank3AccountNumber.Visible = txtBank3AccountNumber.Visible = bank3_visible;
            lblBank3Value.Visible = txtBank3Value.Visible = bank3_visible;
            cboBank3ValueType.Visible = bank3_visible;
            if (bank3_visible == false)
            {
                txtBank3BSB.Text = "";
                txtBank3AccountName.Text = "";
                txtBank3AccountNumber.Text = "";
                txtBank3Value.Text = "";
                cboBank3ValueType.SelectedIndex = -1;
            }
        }

        private void pbPicture_DoubleClick(object sender, EventArgs e)
        {
            FrmPicture frm = new FrmPicture();
            frm.InitialPicture = mModel.DefaultPicturePath;
            frm.PictureDirectory = mModel.DefaultPictureDirectory;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                lblPicture.Text = frm.ResultantPictureName;
                mModel.SetPropertyValue(BOEmployee.PICTURE, lblPicture.Text);
                if (string.IsNullOrEmpty(mModel.DefaultPicturePath))
                {
                    pbPicture.Image = null;
                }
                else
                {
                    string picture_path = mModel.DefaultPicturePath;
                    if (System.IO.File.Exists(picture_path))
                    {
                        pbPicture.Load(picture_path);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }
    }
}