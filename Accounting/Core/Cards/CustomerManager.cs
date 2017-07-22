using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Cards
{
    using System.Data.Common;
    using System.Data;
    using Accounting.Db;
    using Accounting.Db.Elements;
    using Accounting.Core.Misc;

    public abstract class CustomerManager : EntityManager<Customer>
    {
        public CustomerManager(DbManager mgr)
            : base(mgr)
        {
            
        }


        #region -(Factory Methods)
        protected override Customer _CreateDbEntity()
        {
            Customer _obj = new Customer(true, this);
            _obj.CardTypeID = CardType.GetCardTypeID(CardType.TypeID.Customer);
            return _obj;
        }

        protected override Customer _CreateEntity()
        {
            Customer _obj = new Customer(false, this);
            _obj.CardTypeID = CardType.GetCardTypeID(CardType.TypeID.Customer);
            _obj.IsIndividual = "N";

            DataFileInformation c = RepositoryMgr.DataFileInformationMgr.Company;
            _obj.TermsID = c.DefaultCustomerTermsID;
            _obj.PriceLevelID = c.DefaultCustomerPriceLevelID;
            _obj.TaxCodeID = c.DefaultCustomerTaxCodeID;
            _obj.UseCustomerTaxCode = c.DefaultUseCustomerTaxCode;
            _obj.FreightTaxCodeID = c.DefaultCustomerFreightTaxCodeID;
            _obj.CreditLimit = c.DefaultCustomerCreditLimit;
            return _obj;
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(Customer _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["CustomerID"] = DbMgr.CreateAutoIntFieldEntry(_obj.CustomerID);
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["Name"] = DbMgr.CreateStringFieldEntry(_obj.Name);
            fields["TermsID"] = DbMgr.CreateIntFieldEntry(_obj.TermsID);
            fields["CurrentBalance"] = DbMgr.CreateDoubleFieldEntry(_obj.CurrentBalance);
            fields["CardIdentification"] = DbMgr.CreateStringFieldEntry(_obj.CardIdentification);
            fields["SaleCommentID"] = DbMgr.CreateIntFieldEntry(_obj.SaleCommentID);
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["TaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.TaxCodeID);
            fields["SaleLayoutID"] = DbMgr.CreateStringFieldEntry(_obj.SaleLayoutID);
            fields["PaymentDeliveryID"] = DbMgr.CreateStringFieldEntry(_obj.PaymentDeliveryID);
            fields["InvoiceDeliveryID"] = DbMgr.CreateStringFieldEntry(_obj.InvoiceDeliveryID);
            fields["IsInactive"] = DbMgr.CreateStringFieldEntry(_obj.IsInactive);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["SalespersonID"] = DbMgr.CreateIntFieldEntry(_obj.SalespersonID);
            fields["ShippingMethodID"] = DbMgr.CreateIntFieldEntry(_obj.ShippingMethodID);
            fields["FreightTaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.FreightTaxCodeID);
            fields["IsIndividual"] = DbMgr.CreateStringFieldEntry(_obj.IsIndividual);
            fields["PriceLevelID"] = DbMgr.CreateStringFieldEntry(_obj.PriceLevelID);
            fields["IncomeAccountID"] = DbMgr.CreateIntFieldEntry(_obj.IncomeAccountID);
            fields["ReceiptMemo"] = DbMgr.CreateStringFieldEntry(_obj.ReceiptMemo);
            fields["HourlyBillingRate"] = DbMgr.CreateDoubleFieldEntry(_obj.HourlyBillingRate);
            fields["CreditLimit"] = DbMgr.CreateDoubleFieldEntry(_obj.CreditLimit);
            fields["ABN"] = DbMgr.CreateStringFieldEntry(_obj.ABN);
            fields["ABNBranch"] = DbMgr.CreateStringFieldEntry(_obj.ABNBranch);
            fields["TaxIDNumber"] = DbMgr.CreateStringFieldEntry(_obj.TaxIDNumber);
            fields["UseCustomerTaxCode"] = DbMgr.CreateStringFieldEntry(_obj.UseCustomerTaxCode);
            fields["VolumeDiscount"] = DbMgr.CreateDoubleFieldEntry(_obj.VolumeDiscount);
            fields["Picture"] = DbMgr.CreateStringFieldEntry(_obj.Picture);
            fields["Notes"] = DbMgr.CreateStringFieldEntry(_obj.Notes);
            fields["MethodOfPaymentID"] = DbMgr.CreateIntFieldEntry(_obj.PaymentMethodID);
            fields["PaymentNotes"] = DbMgr.CreateStringFieldEntry(_obj.PaymentNotes);
            fields["PaymentCardNumber"] = DbMgr.CreateStringFieldEntry(_obj.PaymentCardNumber);
            fields["PaymentNameOnCard"] = DbMgr.CreateStringFieldEntry(_obj.PaymentNameOnCard);
            fields["PaymentExpiryDate"] = DbMgr.CreateStringFieldEntry(_obj.PaymentExpirationDate);
            fields["CustomerSince"] = DbMgr.CreateDateTimeFieldEntry(_obj.CustomerSince);
            fields["LastSaleDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.LastSaleDate);
            fields["LastPaymentDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.LastPaymentDate);
            fields["HighestInvoiceAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.HighestInvoiceAmount);
            fields["HighestReceivableAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.HighestReceivableAmount);
            fields["FirstName"] = DbMgr.CreateStringFieldEntry(_obj.FirstName);
            fields["LastName"] = DbMgr.CreateStringFieldEntry(_obj.LastName);
            fields["CustomField1"] = DbMgr.CreateStringFieldEntry(_obj.CustomField1);
            fields["CustomList1ID"] = DbMgr.CreateIntFieldEntry(_obj.CustomList1ID);
            fields["CustomField2"] = DbMgr.CreateStringFieldEntry(_obj.CustomField2);
            fields["CustomList2ID"] = DbMgr.CreateIntFieldEntry(_obj.CustomList2ID);
            fields["CustomField3"] = DbMgr.CreateStringFieldEntry(_obj.CustomField3);
            fields["CustomList3ID"] = DbMgr.CreateIntFieldEntry(_obj.CustomList3ID);
            fields["Identifiers"] = DbMgr.CreateStringFieldEntry(_obj.Identifiers);
            fields["PaymentBSB"] = DbMgr.CreateStringFieldEntry(_obj.PaymentBSB);
            fields["PaymentBankAccountNumber"] = DbMgr.CreateStringFieldEntry(_obj.PaymentBankAccountNumber);
            fields["PaymentBankAccountName"] = DbMgr.CreateStringFieldEntry(_obj.PaymentBankAccountName);
            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Customers");

            return clause;
        }

        public string GenerateCardIdentification()
        {
            string CardIdentification = "";
            int sequence = 1;
            bool found = false;
            do
            {
                CardIdentification = string.Format("CUS{0:d6}", sequence++);
                found = Exists(CardIdentification);
            } while (found);
            return CardIdentification;
        }

        private DbSelectStatement GetQuery_SelectByCustomerID(int CustomerID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Customers")
                .Criteria.IsEqual("Customers", "CustomerID", CustomerID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByCardIdentification(string CardIdentification)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Customers")
                .Criteria.IsEqual("Customers", "CardIdentification", CardIdentification);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByCustomerID(int CustomerID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("Customers")
                .Criteria.IsEqual("Customers", "CustomerID", CustomerID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByCardIdentification(string CardIdentification)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("Customers")
                .Criteria.IsEqual("Customers", "CardIdentification", CardIdentification);

            return clause;
        }

        private bool Exists(int? CustomerID)
        {
            if (CustomerID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByCustomerID(CustomerID.Value)) != 0;
        }

        private bool Exists(string CardIdentification)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByCardIdentification(CardIdentification)) != 0;
        }

        public override bool Exists(Customer _obj)
        {
            return Exists(_obj.CustomerID);
        }

        protected override Customer _FindByIntId(int? CustomerID)
        {
            if (Exists(CustomerID))
            {
                Customer _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByCustomerID(CustomerID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override Customer _FindByTextId(string CardIdentification)
        {
            if (Exists(CardIdentification))
            {
                Customer _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByCardIdentification(CardIdentification));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override void LoadFromReader(Customer _obj, DbDataReader _reader)
        {
            _obj.CustomerID =GetInt32(_reader, ("CustomerID"));
            _obj.Name =GetString(_reader, ("Name"));
            _obj.TermsID =GetInt32(_reader, ("TermsID"));
            _obj.CurrentBalance = GetDouble(_reader, ("CurrentBalance"));
            _obj.CardIdentification =GetString(_reader, ("CardIdentification"));
            _obj.SaleCommentID =GetInt32(_reader, ("SaleCommentID"));
            _obj.CardRecordID =GetInt32(_reader, ("CardRecordID"));
            _obj.TaxCodeID =GetInt32(_reader, ("TaxCodeID"));
            _obj.SaleLayoutID =GetString(_reader, ("SaleLayoutID"));
            _obj.PaymentDeliveryID =GetString(_reader, ("PaymentDeliveryID"));
            _obj.InvoiceDeliveryID =GetString(_reader, ("InvoiceDeliveryID"));
            _obj.OnHold =GetString(_reader, ("OnHold"));
            _obj.IsInactive =GetString(_reader, ("IsInactive"));
            _obj.CurrencyID =GetInt32(_reader, ("CurrencyID"));
            _obj.SalespersonID =GetInt32(_reader, ("SalespersonID"));
            _obj.ShippingMethodID =GetInt32(_reader, ("ShippingMethodID"));
            _obj.FreightTaxCodeID =GetInt32(_reader, ("FreightTaxCodeID"));
            _obj.IsIndividual = GetString(_reader, ("IsIndividual"));
            _obj.PriceLevelID = GetString(_reader, ("PriceLevelID"));
            _obj.IncomeAccountID = GetInt32(_reader, ("IncomeAccountID"));
            _obj.ReceiptMemo = GetString(_reader, ("ReceiptMemo"));
            _obj.HourlyBillingRate = GetDouble(_reader, ("HourlyBillingRate"));
            _obj.CreditLimit = GetDouble(_reader, ("CreditLimit"));
            _obj.ABN = GetString(_reader, ("ABN"));
            _obj.ABNBranch = GetString(_reader, ("ABNBranch"));
            _obj.TaxIDNumber = GetString(_reader, ("TaxIDNumber"));
            _obj.UseCustomerTaxCode = GetString(_reader, ("UseCustomerTaxCode"));
            _obj.VolumeDiscount = GetDouble(_reader, ("VolumeDiscount"));
            _obj.Picture = GetString(_reader, ("Picture"));
            _obj.Notes = GetString(_reader, ("Notes"));
            _obj.PaymentMethodID = GetInt32(_reader, "MethodOfPaymentID", "PaymentMethodID");
            _obj.PaymentNotes = GetString(_reader, "PaymentNotes");
            _obj.PaymentCardNumber = GetString(_reader, "PaymentCardNumber");
            _obj.PaymentNameOnCard = GetString(_reader, "PaymentNameOnCard");
            _obj.PaymentExpirationDate = GetString(_reader, "PaymentExpiryDate", "PaymentExpirationDate");
            _obj.CustomerSince = GetDateTime(_reader, "CustomerSince");
            _obj.LastSaleDate = GetDateTime(_reader, "LastSaleDate");
            _obj.LastPaymentDate = GetDateTime(_reader, "LastPaymentDate");
            _obj.HighestInvoiceAmount = GetDouble(_reader, "HighestInvoiceAmount");
            _obj.HighestReceivableAmount = GetDouble(_reader, "HighestReceivableAmount");
            _obj.FirstName = GetString(_reader, "FirstName");
            _obj.LastName = GetString(_reader, "LastName");
            _obj.CustomList1ID = GetInt32(_reader, "CustomList1ID");
            _obj.CustomField1 = GetString(_reader, "CustomField1");
            _obj.CustomList2ID = GetInt32(_reader, "CustomList2ID");
            _obj.CustomField2 = GetString(_reader, "CustomField2");
            _obj.CustomList3ID = GetInt32(_reader, "CustomList3ID");
            _obj.CustomField3 = GetString(_reader, "CustomField3");
            _obj.Identifiers = GetString(_reader, "Identifiers");
            _obj.PaymentBankAccountName = GetString(_reader, "PaymentBankAccountName");
            _obj.PaymentBankAccountNumber = GetString(_reader, "PaymentBankAccountNumber");
            _obj.PaymentBSB = GetString(_reader, "PaymentBSB");
        }

        protected override object GetDbProperty(Customer _obj, string property_name)
        {
            if (property_name == "TaxCode")
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.TaxCodeID);
            }
            else if (property_name == "PaymentDelivery")
            {
                return RepositoryMgr.InvoiceDeliveryMgr.FindById(_obj.PaymentDeliveryID);
            }
            else if (property_name == "InvoiceDelivery")
            {
                return RepositoryMgr.InvoiceDeliveryMgr.FindById(_obj.InvoiceDeliveryID);
            }
            else if (property_name == "SaleLayout")
            {
                return RepositoryMgr.InvoiceTypeMgr.FindById(_obj.SaleLayoutID);
            }
            else if (property_name == "Currency")
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name == "SalesPerson")
            {
                return RepositoryMgr.EmployeeMgr.FindById(_obj.SalespersonID);
            }
            else if (property_name == "ShippingMethod")
            {
                return RepositoryMgr.ShippingMethodMgr.FindById(_obj.ShippingMethodID);
            }
            else if (property_name == "Terms")
            {
                return RepositoryMgr.TermsMgr.FindById(_obj.TermsID);
            }
            else if (property_name == "SaleComment")
            {
                return RepositoryMgr.CommentMgr.FindById(_obj.SaleCommentID);
            }
            else if (property_name == "FreightTaxCode")
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.FreightTaxCodeID);
            }
            else if(property_name.Equals("IncomeAccount"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.IncomeAccountID);
            }
            else if (property_name == "Address1")
            {
                return RepositoryMgr.AddressMgr.FindByCardId(_obj.CardRecordID, 1);
            }
            else if (property_name == "Address2")
            {
                return RepositoryMgr.AddressMgr.FindByCardId(_obj.CardRecordID, 2);
            }
            else if (property_name == "Address3")
            {
                return RepositoryMgr.AddressMgr.FindByCardId(_obj.CardRecordID, 3);
            }
            else if (property_name == "Address4")
            {
                return RepositoryMgr.AddressMgr.FindByCardId(_obj.CardRecordID, 4);
            }
            else if (property_name == "Address5")
            {
                return RepositoryMgr.AddressMgr.FindByCardId(_obj.CardRecordID, 5);
            }
            else if (property_name == "CardType")
            {
                return RepositoryMgr.CardTypeMgr.FindById(_obj.CardTypeID);
            }
            else if (property_name.Equals("PriceLevel"))
            {
                return RepositoryMgr.PriceLevelMgr.FindById(_obj.PriceLevelID);
            }
            else if(property_name.Equals("PaymentMethod"))
            {
                return RepositoryMgr.PaymentMethodMgr.FindById(_obj.PaymentMethodID);
            }
            else if (property_name.Equals("CustomList1"))
            {
                return RepositoryMgr.CustomListMgr.FindById(_obj.CustomList1ID);
            }
            else if (property_name.Equals("CustomList2"))
            {
                return RepositoryMgr.CustomListMgr.FindById(_obj.CustomList2ID);
            }
            else if (property_name.Equals("CustomList3"))
            {
                return RepositoryMgr.CustomListMgr.FindById(_obj.CustomList3ID);
            }
            return null;
        }

        protected override IList<Customer>_FindAllCollection()
        {
            List<Customer> customers = new List<Customer>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Customer _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);

                customers.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return customers;
        }

        public List<CustomerRow> ListRow()
        {
            List<CustomerRow> customers = new List<CustomerRow>();

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectColumn("Customers", "CustomerID")
                .SelectColumn("Customers", "Name")
                .SelectColumn("Customers", "TermsID")
                .SelectColumn("Customers", "SaleCommentID")
                .From("Customers");

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                CustomerRow _obj = new CustomerRow();
                _obj.CustomerID = GetInt32(_reader, "CustomerID");
                _obj.Name = GetString(_reader, "Name");
                _obj.TermsID = GetInt32(_reader, "TermsID");
                _obj.SaleCommentID = GetInt32(_reader, "SaleCommentID");

                customers.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return customers;
        }

       

        public Customer CreateOrRetrieve(string CardIdentification, out bool created)
        {
            Customer _obj = _FindByTextId(CardIdentification);
            if (_obj != null)
            {
                created = false;
                return _obj;
            }
            else
            {
                created = true;
                return CreateEntity();
            }
        }

        public Customer CreateOrRetrieve(string CardIdentification)
        {
            bool created;
            return CreateOrRetrieve(CardIdentification, out created);
        }
    }
}
