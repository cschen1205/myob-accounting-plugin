using System;
using System.Windows.Forms;


namespace DacII.WinForms.Cards
{
    using DacII.Presenters;
    using DacII.ViewModels;
    using DacII.Util;
    using DacII.DacHandlers;

    using Accounting.Core.Misc;
    using Accounting.Bll.Cards;
    using DacII.WinForms.Util;

    public partial class FrmSupplier : BaseView
    {
        private BOSupplier mModel=null;
        private BOViewModel mViewModel;

        public FrmSupplier(ApplicationPresenter ap, BOSupplier model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;
            mViewModel = new BOViewModel(mModel);
            mViewModel.ErrorProvider = errorProvider;

            BindViews();
            RegisterEventHandlers();
        }

        public BOSupplier Model
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
            cboInvoiceDelivery.DataSource = mApplicationController.FindallInvoiceDeliveries();
            cboPurchaseLayout.DataSource = mApplicationController.FindAllPurchaseLayouts();
            cboTaxCode.DataSource = mApplicationController.FindAllTaxCodes();
            cboShippingMethod.DataSource = mApplicationController.FindAllShippingMethods();
            cboExpenseAccount.DataSource = mApplicationController.FindAllExpenseAccounts();
            cboPurchaseComment.DataSource = mApplicationController.FindAllComments();
            cboFreightTaxCode.DataSource = mApplicationController.FindAllTaxCodes();
            cboTerms.DataSource = mApplicationController.FindAllTerms();
            cboPaymentMethod.DataSource = mApplicationController.FindAllPaymentMethods();

            mViewModel.BindView(BOSupplier.STATEMENT_TEXT, lblStatementText, txtStatementText);
            mViewModel.BindView(BOSupplier.CARD_IDENTIFICATION, lblSupplierCardID, txtSupplierCardID);
            mViewModel.BindView(BOSupplier.LAST_NAME, lblLastName, txtLastName);
            mViewModel.BindView(BOSupplier.FIRST_NAME, lblFirstName, txtFirstName);
            mViewModel.BindView(BOSupplier.PAYMENT_MEMO, lblPaymentMemo, txtPaymentMemo);
            mViewModel.BindView(BOSupplier.HOURLY_BILLING_RATE, lblHourlyBillingRate, txtHourlyBillingRate);
            mViewModel.BindView(BOSupplier.CREDIT_LIMIT, lblCreditLimit, txtCreditLimit);
            mViewModel.BindView(BOSupplier.ABN, lblABN, txtABN);
            mViewModel.BindView(BOSupplier.ABN_BRANCH, lblABNBranch, txtABNBranch);
            mViewModel.BindView(BOSupplier.TAX_ID_NUMBER, lblTaxIDNumber, txtTaxIDNumber);
            mViewModel.BindView(BOSupplier.CURRENT_BALANCE, lblCurrentBalance, txtCurrentBalance);
            mViewModel.BindView(BOSupplier.VOLUME_DISCOUNT, lblVolumeDiscount, txtVolumeDiscount);
            mViewModel.BindView(BOSupplier.NOTES, lblNotes, txtNotes);
            mViewModel.BindView(BOSupplier.HIGHEST_PURCHASE_AMOUNT, lblHighestPurchaseAmount, txtHighestPurchaseAmount);
            mViewModel.BindView(BOSupplier.HIGHEST_PAYABLE_AMOUNT, lblHighestPayableAmount, txtHighestPayableAmount);
            mViewModel.BindView(BOSupplier.ESTIMATED_COST_PER_HOUR, lblEstimatedCostPerHour, txtEstimatedCostPerHour);
            mViewModel.BindView(BOSupplier.LAST_PAYMENT_DATE, lblLastPaymentDate, dtpLastPaymentDate);
            mViewModel.BindView(BOSupplier.LAST_PURCHASE_DATE, lblLastPurchaseDate, dtpLastPurchaseDate);
            mViewModel.BindView(BOSupplier.SUPPLIER_SINCE, lblSupplierSince, dtpSupplierSince);
            mViewModel.BindView(BOSupplier.IS_ACTIVE, chkActive);
            mViewModel.BindView(BOSupplier.IS_INDIVIDUAL, chkIndividual);
            mViewModel.BindView(BOSupplier.USE_SUPPLIER_TAXCODE, chkUseSupplierTaxCode);
            mViewModel.BindView(BOSupplier.PICTURE, lblPicture);
            mViewModel.BindView(BOSupplier.SHIPPING_METHOD, lblShippingMethod, cboShippingMethod);
            mViewModel.BindView(BOSupplier.EXPENSE_ACCOUNT, lblExpenseAccount, cboExpenseAccount);
            mViewModel.BindView(BOSupplier.TAXCODE, lblTaxCode, cboTaxCode);
            mViewModel.BindView(BOSupplier.FREIGHT_TAXCODE, lblFreightTaxCode, cboFreightTaxCode);
            mViewModel.BindView(BOSupplier.INVOICE_DELIVERY, lblInvoiceDelivery, cboInvoiceDelivery);
            mViewModel.BindView(BOSupplier.PURCHASE_LAYOUT, lblPurchaseLayout, cboPurchaseLayout);
            mViewModel.BindView(BOSupplier.CURRENCY, lblCurrencyCode, cboCurrencyCode);
            mViewModel.BindView(BOSupplier.PURCHASE_COMMENT, lblPurchaseComment, cboPurchaseComment);
            mViewModel.BindView(BOSupplier.TERMS, lblTerms, cboTerms);
            mViewModel.BindView(BOSupplier.PAYMENT_METHOD, lblPaymentMethod, cboPaymentMethod);
            mViewModel.BindView(BOSupplier.CUSTOM_FIELD1, lblCustomField1, txtCustomField1);
            mViewModel.BindView(BOSupplier.CUSTOM_FIELD2, lblCustomField2, txtCustomField2);
            mViewModel.BindView(BOSupplier.CUSTOM_FIELD3, lblCustomField3, txtCustomField3);
            mViewModel.BindView(BOSupplier.PAYMENT_BANK_ACCOUNT_NAME, lblPaymentBankAccountName, txtPaymentBankAccountName);
            mViewModel.BindView(BOSupplier.PAYMENT_BANK_ACCOUNT_NUMBER, lblPaymentBankAccountNumber, txtPaymentBankAccountNumber);
            mViewModel.BindView(BOSupplier.PAYMENT_BSB, lblPaymentBSB, txtPaymentBSB);

            mViewModel.BindView(BOSupplier.ADDRESS1_LINE1, lblAddressLine11, txtAddressLine11);
            mViewModel.BindView(BOSupplier.ADDRESS1_LINE2, lblAddressLine12, txtAddressLine12);
            mViewModel.BindView(BOSupplier.ADDRESS1_LINE3, lblAddressLine13, txtAddressLine13);
            mViewModel.BindView(BOSupplier.ADDRESS1_LINE4, lblAddressLine14, txtAddressLine14);
            mViewModel.BindView(BOSupplier.ADDRESS1_PHONE1, lblPhone11, txtPhone11);
            mViewModel.BindView(BOSupplier.ADDRESS1_PHONE2, lblPhone21, txtPhone21);
            mViewModel.BindView(BOSupplier.ADDRESS1_PHONE3, lblPhone31, txtPhone31);
            mViewModel.BindView(BOSupplier.ADDRESS1_CITY, lblCity1, txtCity1);
            mViewModel.BindView(BOSupplier.ADDRESS1_COUNTRY, lblCountry1, txtCountry1);
            mViewModel.BindView(BOSupplier.ADDRESS1_EMAIL, lblEmail1, txtEmail1);
            mViewModel.BindView(BOSupplier.ADDRESS1_WEBSITE, lblWeb1, txtWeb1);
            mViewModel.BindView(BOSupplier.ADDRESS1_FAX, lblFax1, txtFax1);
            mViewModel.BindView(BOSupplier.ADDRESS1_CONTACT_NAME, lblContact1, txtContact1);
            mViewModel.BindView(BOSupplier.ADDRESS1_STATE, lblState1, txtState1);
            mViewModel.BindView(BOSupplier.ADDRESS1_POSTCODE, lblPostcode1, txtPostcode1);

            mViewModel.BindView(BOSupplier.ADDRESS2_LINE1, lblAddressLine21, txtAddressLine21);
            mViewModel.BindView(BOSupplier.ADDRESS2_LINE2, lblAddressLine22, txtAddressLine22);
            mViewModel.BindView(BOSupplier.ADDRESS2_LINE3, lblAddressLine23, txtAddressLine23);
            mViewModel.BindView(BOSupplier.ADDRESS2_LINE4, lblAddressLine24, txtAddressLine24);
            mViewModel.BindView(BOSupplier.ADDRESS2_PHONE1, lblPhone12, txtPhone12);
            mViewModel.BindView(BOSupplier.ADDRESS2_PHONE2, lblPhone22, txtPhone22);
            mViewModel.BindView(BOSupplier.ADDRESS2_PHONE3, lblPhone32, txtPhone32);
            mViewModel.BindView(BOSupplier.ADDRESS2_CITY, lblCity2, txtCity2);
            mViewModel.BindView(BOSupplier.ADDRESS2_COUNTRY, lblCountry2, txtCountry2);
            mViewModel.BindView(BOSupplier.ADDRESS2_EMAIL, lblEmail2, txtEmail2);
            mViewModel.BindView(BOSupplier.ADDRESS2_WEBSITE, lblWeb2, txtWeb2);
            mViewModel.BindView(BOSupplier.ADDRESS2_FAX, lblFax2, txtFax2);
            mViewModel.BindView(BOSupplier.ADDRESS2_CONTACT_NAME, lblContact2, txtContact2);
            mViewModel.BindView(BOSupplier.ADDRESS2_STATE, lblState2, txtState2);
            mViewModel.BindView(BOSupplier.ADDRESS2_POSTCODE, lblPostcode2, txtPostcode2);

            mViewModel.BindView(BOSupplier.ADDRESS3_LINE1, lblAddressLine31, txtAddressLine31);
            mViewModel.BindView(BOSupplier.ADDRESS3_LINE2, lblAddressLine32, txtAddressLine32);
            mViewModel.BindView(BOSupplier.ADDRESS3_LINE3, lblAddressLine33, txtAddressLine33);
            mViewModel.BindView(BOSupplier.ADDRESS3_LINE4, lblAddressLine34, txtAddressLine34);
            mViewModel.BindView(BOSupplier.ADDRESS3_PHONE1, lblPhone13, txtPhone13);
            mViewModel.BindView(BOSupplier.ADDRESS3_PHONE2, lblPhone23, txtPhone23);
            mViewModel.BindView(BOSupplier.ADDRESS3_PHONE3, lblPhone33, txtPhone33);
            mViewModel.BindView(BOSupplier.ADDRESS3_CITY, lblCity3, txtCity3);
            mViewModel.BindView(BOSupplier.ADDRESS3_COUNTRY, lblCountry3, txtCountry3);
            mViewModel.BindView(BOSupplier.ADDRESS3_EMAIL, lblEmail3, txtEmail3);
            mViewModel.BindView(BOSupplier.ADDRESS3_WEBSITE, lblWeb3, txtWeb3);
            mViewModel.BindView(BOSupplier.ADDRESS3_FAX, lblFax3, txtFax3);
            mViewModel.BindView(BOSupplier.ADDRESS3_CONTACT_NAME, lblContact3, txtContact3);
            mViewModel.BindView(BOSupplier.ADDRESS3_STATE, lblState3, txtState3);
            mViewModel.BindView(BOSupplier.ADDRESS3_POSTCODE, lblPostcode3, txtPostcode3);

            mViewModel.BindView(BOSupplier.ADDRESS4_LINE1, lblAddressLine41, txtAddressLine41);
            mViewModel.BindView(BOSupplier.ADDRESS4_LINE2, lblAddressLine42, txtAddressLine42);
            mViewModel.BindView(BOSupplier.ADDRESS4_LINE3, lblAddressLine43, txtAddressLine43);
            mViewModel.BindView(BOSupplier.ADDRESS4_LINE4, lblAddressLine44, txtAddressLine44);
            mViewModel.BindView(BOSupplier.ADDRESS4_PHONE1, lblPhone14, txtPhone14);
            mViewModel.BindView(BOSupplier.ADDRESS4_PHONE2, lblPhone24, txtPhone24);
            mViewModel.BindView(BOSupplier.ADDRESS4_PHONE3, lblPhone34, txtPhone34);
            mViewModel.BindView(BOSupplier.ADDRESS4_CITY, lblCity4, txtCity4);
            mViewModel.BindView(BOSupplier.ADDRESS4_COUNTRY, lblCountry4, txtCountry4);
            mViewModel.BindView(BOSupplier.ADDRESS4_EMAIL, lblEmail4, txtEmail4);
            mViewModel.BindView(BOSupplier.ADDRESS4_WEBSITE, lblWeb4, txtWeb4);
            mViewModel.BindView(BOSupplier.ADDRESS4_FAX, lblFax4, txtFax4);
            mViewModel.BindView(BOSupplier.ADDRESS4_CONTACT_NAME, lblContact4, txtContact4);
            mViewModel.BindView(BOSupplier.ADDRESS4_STATE, lblState4, txtState4);
            mViewModel.BindView(BOSupplier.ADDRESS4_POSTCODE, lblPostcode4, txtPostcode4);

            mViewModel.BindView(BOSupplier.ADDRESS5_LINE1, lblAddressLine51, txtAddressLine51);
            mViewModel.BindView(BOSupplier.ADDRESS5_LINE2, lblAddressLine52, txtAddressLine52);
            mViewModel.BindView(BOSupplier.ADDRESS5_LINE3, lblAddressLine53, txtAddressLine53);
            mViewModel.BindView(BOSupplier.ADDRESS5_LINE4, lblAddressLine54, txtAddressLine54);
            mViewModel.BindView(BOSupplier.ADDRESS5_PHONE1, lblPhone15, txtPhone15);
            mViewModel.BindView(BOSupplier.ADDRESS5_PHONE2, lblPhone25, txtPhone25);
            mViewModel.BindView(BOSupplier.ADDRESS5_PHONE3, lblPhone35, txtPhone35);
            mViewModel.BindView(BOSupplier.ADDRESS5_CITY, lblCity5, txtCity5);
            mViewModel.BindView(BOSupplier.ADDRESS5_COUNTRY, lblCountry5, txtCountry5);
            mViewModel.BindView(BOSupplier.ADDRESS5_EMAIL, lblEmail5, txtEmail5);
            mViewModel.BindView(BOSupplier.ADDRESS5_WEBSITE, lblWeb5, txtWeb5);
            mViewModel.BindView(BOSupplier.ADDRESS5_FAX, lblFax5, txtFax5);
            mViewModel.BindView(BOSupplier.ADDRESS5_CONTACT_NAME, lblContact5, txtContact5);
            mViewModel.BindView(BOSupplier.ADDRESS5_STATE, lblState5, txtState5);
            mViewModel.BindView(BOSupplier.ADDRESS5_POSTCODE, lblPostcode5, txtPostcode5);

            mViewModel.BindView(BOSupplier.PERSIST_OBJECT, btnUpdate);
            mViewModel.BindView(BOCustomer.DELETE_OBJECT, btnDel2);
        }

        private void Record(object sender, EventArgs args)
        {
            if (mViewModel.ValidateModel())
            {
                mModel.Record();
                LoadView_PaymentDetails();
                MessageBox.Show("Supplier Record Saved!");
            }
        }

        private void Delete(object sender, EventArgs args)
        {
            if (MessageBox.Show(
                "Do you want to delete the customer?", 
                "Delete",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            RegisterEventHandler(dtpStartDate, DacEventHandler.EventTypes.ValueChanged, new EventHandler(dtpStartDate_ValueChanged));
            RegisterEventHandler(dtpEndDate, DacEventHandler.EventTypes.ValueChanged, new EventHandler(dtpEndDate_ValueChanged));
            RegisterEventHandler(cboPaymentMethod, DacEventHandler.EventTypes.SelectedIndexChanged, new EventHandler(cboPaymentMethod_SelectedIndexChanged));
            RegisterEventHandler(chkIndividual, DacEventHandler.EventTypes.CheckedChanged, new EventHandler(chkIndividual_CheckedChanged));
        }

        void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {

        }

        void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dgvContactLog.DataSource = mModel.DataGridView_ContactLog(dtpStartDate.Value, dtpEndDate.Value);
        }

        void cboPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
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

        void LoadView_PaymentDetails()
        {
            PaymentMethod selected_payment_method = (PaymentMethod)cboPaymentMethod.SelectedItem;

            bool bank_account_name_visible = false;
            bool bank_account_number_visible = false;
            bool bsb_visible = false;
            bool card_number_visible = false;
            bool expiry_date_visible = false;
            bool name_on_card_visible = false;
            if (selected_payment_method != null)
            {
                if (selected_payment_method.Description == "American Express"
                    || selected_payment_method.Description == "Bank Card"
                    || selected_payment_method.Description == "Diners Club"
                    || selected_payment_method.Description == "EFTPOS"
                    || selected_payment_method.Description == "MasterCard"
                    || selected_payment_method.Description == "Visa"
                    )
                {
                    card_number_visible = true;
                    expiry_date_visible = true;
                    name_on_card_visible = true;
                }
                else if (selected_payment_method.Description == "Cheque")
                {
                    bsb_visible = true;
                    bank_account_name_visible = true;
                    bank_account_number_visible = true;
                }
            }

            txtPaymentBankAccountName.Visible = bank_account_name_visible;
            lblPaymentBankAccountName.Visible = bank_account_name_visible;
            txtPaymentBankAccountNumber.Visible = bank_account_number_visible;
            lblPaymentBankAccountNumber.Visible = bank_account_number_visible;
            txtPaymentBSB.Visible = bsb_visible;
            lblPaymentBSB.Visible = bsb_visible;
            txtPaymentCardNumber.Visible = card_number_visible;
            lblPaymentCardNumber.Visible = card_number_visible;
            txtPaymentExpirationDate.Visible = expiry_date_visible;
            lblPaymentExpirationDate.Visible = expiry_date_visible;
            txtPaymentNameOnCard.Visible = name_on_card_visible;
            lblPaymentNameOnCard.Visible = name_on_card_visible;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void pbPicture_DoubleClick(object sender, EventArgs e)
        {
            FrmPicture frm = new FrmPicture();
            frm.InitialPicture = mModel.DefaultPicturePath;
            frm.PictureDirectory = mModel.DefaultPictureDirectory;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                lblPicture.Text = frm.ResultantPictureName;
                mModel.SetPropertyValue(BOSupplier.PICTURE, lblPicture.Text);
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
    }
}