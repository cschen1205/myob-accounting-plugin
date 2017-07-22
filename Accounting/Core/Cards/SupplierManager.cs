using System;
using System.Collections.Generic;
using System.Text;


namespace Accounting.Core.Cards
{
    using System.Linq;
    using System.ComponentModel;
    using System.Data.Common;
    using System.Data;
    using Accounting.Core.Misc;
    using Accounting.Db;
    using Accounting.Db.Elements;

    public abstract class SupplierManager : EntityManager<Supplier>
    {
        public SupplierManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        #region Supplier factory methods
        protected override Supplier _CreateDbEntity()
        {
            Supplier _obj = new Supplier(true, this);
            _obj.CardTypeID = CardType.GetCardTypeID(CardType.TypeID.Supplier);
            return _obj;
        }

        protected override Supplier _CreateEntity()
        {
            Supplier _obj = new Supplier(false, this);
            _obj.CardTypeID = CardType.GetCardTypeID(CardType.TypeID.Supplier);
            _obj.IsIndividual = "N";

            DataFileInformation c = RepositoryMgr.DataFileInformationMgr.Company;

            _obj.TermsID = c.DefaultSupplierTermsID;
            _obj.TaxCodeID = c.DefaultSupplierTaxCodeID;
            _obj.UseSupplierTaxCode = c.DefaultUseSupplierTaxCode;
            _obj.FreightTaxCodeID = c.DefaultSupplierFreightTaxCodeID;
            _obj.CreditLimit = c.DefaultSupplierCreditLimit;

            return _obj;
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(Supplier _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["SupplierID"] = DbMgr.CreateAutoIntFieldEntry(_obj.SupplierID);
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["Name"] = DbMgr.CreateStringFieldEntry(_obj.Name);
            fields["TermsID"] = DbMgr.CreateIntFieldEntry(_obj.TermsID);
            fields["CurrentBalance"] = DbMgr.CreateDoubleFieldEntry(_obj.CurrentBalance);
            fields["CardIdentification"] = DbMgr.CreateStringFieldEntry(_obj.CardIdentification);
            fields["PurchaseCommentID"] = DbMgr.CreateIntFieldEntry(_obj.PurchaseCommentID);
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["TaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.TaxCodeID);
            fields["PurchaseLayoutID"] = DbMgr.CreateStringFieldEntry(_obj.PurchaseLayoutID);
            fields["PaymentDeliveryID"] = DbMgr.CreateStringFieldEntry(_obj.PaymentDeliveryID);
            fields["InvoiceDeliveryID"] = DbMgr.CreateStringFieldEntry(_obj.InvoiceDeliveryID);
            fields["IsInactive"] = DbMgr.CreateStringFieldEntry(_obj.IsInactive);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["FreightTaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.FreightTaxCodeID);
            fields["ShippingMethodID"] = DbMgr.CreateIntFieldEntry(_obj.ShippingMethodID);
            fields["IsIndividual"] = DbMgr.CreateStringFieldEntry(_obj.IsIndividual);
            fields["ExpenseAccountID"] = DbMgr.CreateIntFieldEntry(_obj.ExpenseAccountID);
            fields["PaymentNotes"] = DbMgr.CreateStringFieldEntry(_obj.PaymentNotes);
            fields["HourlyBillingRate"] = DbMgr.CreateDoubleFieldEntry(_obj.HourlyBillingRate);
            fields["CreditLimit"] = DbMgr.CreateDoubleFieldEntry(_obj.CreditLimit);
            fields["ABN"] = DbMgr.CreateStringFieldEntry(_obj.ABN);
            fields["ABNBranch"] = DbMgr.CreateStringFieldEntry(_obj.ABNBranch);
            fields["TaxIDNumber"] = DbMgr.CreateStringFieldEntry(_obj.TaxIDNumber);
            fields["UseSupplierTaxCode"] = DbMgr.CreateStringFieldEntry(_obj.UseSupplierTaxCode);
            fields["VolumeDiscount"] = DbMgr.CreateDoubleFieldEntry(_obj.VolumeDiscount);
            fields["Picture"] = DbMgr.CreateStringFieldEntry(_obj.Picture);
            fields["Notes"] = DbMgr.CreateStringFieldEntry(_obj.Notes);
            fields["MethodOfPaymentID"] = DbMgr.CreateIntFieldEntry(_obj.PaymentMethodID);
            fields["PaymentMemo"] = DbMgr.CreateStringFieldEntry(_obj.PaymentMemo);
            fields["PaymentCardNumber"] = DbMgr.CreateStringFieldEntry(_obj.PaymentCardNumber);
            fields["PaymentNameOnCard"] = DbMgr.CreateStringFieldEntry(_obj.PaymentNameOnCard);
            fields["PaymentExpiryDate"] = DbMgr.CreateStringFieldEntry(_obj.PaymentExpirationDate);
            fields["SupplierSince"] = DbMgr.CreateDateTimeFieldEntry(_obj.SupplierSince);
            fields["LastPurchaseDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.LastPurchaseDate);
            fields["LastPaymentDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.LastPaymentDate);
            fields["HighestPurchaseAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.HighestPurchaseAmount);
            fields["HighestPayableAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.HighestPayableAmount);
            fields["EstimatedCostPerHour"] = DbMgr.CreateDoubleFieldEntry(_obj.EstimatedCostPerHour);
            fields["BSBCode"] = DbMgr.CreateStringFieldEntry(_obj.BSBCode);
            fields["BankAccountNumber"] = DbMgr.CreateStringFieldEntry(_obj.BankAccountNumber);
            fields["BankAccountName"] = DbMgr.CreateStringFieldEntry(_obj.BankAccountName);
            fields["LastName"] = DbMgr.CreateStringFieldEntry(_obj.LastName);
            fields["FirstName"] = DbMgr.CreateStringFieldEntry(_obj.FirstName);
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
                .From("Suppliers");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByCardIdentification(string CardIdentification)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Suppliers")
                .Criteria.IsEqual("Suppliers", "CardIdentification", CardIdentification);

            return clause;
        }

        public string GenerateCardIdentification()
        {
            string CardIdentification = "";
            int sequence = 1;
            bool found = false;
            do
            {
                CardIdentification = string.Format("SUPP{0:d6}", sequence++);
                found = Exists(CardIdentification);
            } while (found);
            return CardIdentification;
        }

        private DbSelectStatement GetQuery_SelectBySupplierID(int SupplierID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Suppliers")
                .Criteria.IsEqual("Suppliers", "SupplierID", SupplierID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByCardIdentification(string CardIdentification)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("Suppliers")
                .Criteria.IsEqual("Suppliers", "CardIdentification", CardIdentification);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountBySupplierID(int SupplierID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("Suppliers")
                .Criteria.IsEqual("Suppliers", "SupplierID", SupplierID);

            return clause;
        }

        private bool Exists(int? SupplierID)
        {
            if (SupplierID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountBySupplierID(SupplierID.Value)) != 0;
        }

        private bool Exists(string CardIdentification)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByCardIdentification(CardIdentification)) != 0;
        }

        public override bool Exists(Supplier _supplier)
        {
            return Exists(_supplier.SupplierID);
        }

        protected override Supplier _FindByIntId(int? SupplierID)
        {
            if (Exists(SupplierID))
            {
                Supplier _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectBySupplierID(SupplierID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override Supplier _FindByTextId(string CardIdentification)
        {
            if (Exists(CardIdentification))
            {
                Supplier _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByCardIdentification(CardIdentification));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        public Supplier CreateOrRetrieve(string CardIdentification)
        {
            bool created;
            return CreateOrRetrieve(CardIdentification, out created);
        }

        public Supplier CreateOrRetrieve(string CardIdentification, out bool created)
        {
            Supplier _obj = _FindByTextId(CardIdentification);
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

        protected override void LoadFromReader(Supplier _obj, DbDataReader _reader)
        {
            _obj.SupplierID =GetInt32(_reader, ("SupplierID"));
            _obj.Name =GetString(_reader, ("Name"));
            _obj.CardRecordID =GetInt32(_reader, ("CardRecordID"));
            _obj.TermsID =GetInt32(_reader, ("TermsID"));
            _obj.CurrentBalance = GetDouble(_reader, ("CurrentBalance"));
            _obj.CardIdentification =GetString(_reader, ("CardIdentification"));
            _obj.PurchaseCommentID =GetInt32(_reader, ("PurchaseCommentID"));
            _obj.CardRecordID =GetInt32(_reader, ("CardRecordID"));
            _obj.TaxCodeID =GetInt32(_reader, ("TaxCodeID"));
            _obj.PurchaseLayoutID =GetString(_reader, ("PurchaseLayoutID"));
            _obj.PaymentDeliveryID =GetString(_reader, ("PaymentDeliveryID"));
            _obj.InvoiceDeliveryID =GetString(_reader, ("InvoiceDeliveryID"));
            _obj.IsInactive =GetString(_reader, ("IsInactive"));
            _obj.CurrencyID =GetInt32(_reader, ("CurrencyID"));
            _obj.FreightTaxCodeID = GetInt32(_reader, ("FreightTaxCodeID"));
            _obj.ShippingMethodID = GetInt32(_reader, ("ShippingMethodID"));
            _obj.IsIndividual = GetString(_reader, ("IsIndividual"));
            _obj.ExpenseAccountID = GetInt32(_reader, ("ExpenseAccountID"));
            _obj.PaymentNotes = GetString(_reader, ("PaymentNotes"));
            _obj.HourlyBillingRate = GetDouble(_reader, ("HourlyBillingRate"));
            _obj.CreditLimit = GetDouble(_reader, ("CreditLimit"));
            _obj.PaymentMethodID = GetInt32(_reader, "PaymentMethodID", "MethodOfPaymentID");
            _obj.ABN = GetString(_reader, ("ABN"));
            _obj.ABNBranch = GetString(_reader, ("ABNBranch"));
            _obj.TaxIDNumber = GetString(_reader, ("TaxIDNumber"));
            _obj.UseSupplierTaxCode = GetString(_reader, ("UseSupplierTaxCode"));
            _obj.VolumeDiscount = GetDouble(_reader, ("VolumeDiscount"));
            _obj.Picture = GetString(_reader, ("Picture"));
            _obj.Notes = GetString(_reader, ("Notes"));
            _obj.PaymentMemo = GetString(_reader, "PaymentMemo");
            _obj.PaymentCardNumber = GetString(_reader, "PaymentCardNumber");
            _obj.PaymentNameOnCard = GetString(_reader, "PaymentNameOnCard");
            _obj.PaymentExpirationDate = GetString(_reader, "PaymentExpiryDate", "PaymentExpirationDate");
            _obj.SupplierSince = GetDateTime(_reader, "SupplierSince");
            _obj.LastPurchaseDate = GetDateTime(_reader, "LastPuchaseDate", "LastPurchaseDate");
            _obj.LastPaymentDate = GetDateTime(_reader, "LastPaymentDate");
            _obj.HighestPurchaseAmount = GetDouble(_reader, "HighestPurchaseAmount");
            _obj.HighestPayableAmount = GetDouble(_reader, "HighestPayableAmount");
            _obj.EstimatedCostPerHour = GetDouble(_reader, "EstimatedCostPerHour");
            _obj.BSBCode = GetString(_reader, "BSBCode");
            _obj.BankAccountNumber = GetString(_reader, "BankAccountNumber");
            _obj.BankAccountName = GetString(_reader, "BankAccountName");
            _obj.LastName = GetString(_reader, "LastName");
            _obj.FirstName = GetString(_reader, "FirstName");
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

        protected override object GetDbProperty(Supplier _obj, string property_name)
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
            else if (property_name == "PurchaseLayout")
            {
                return RepositoryMgr.InvoiceTypeMgr.FindById(_obj.PurchaseLayoutID);
            }
            else if (property_name == "Currency")
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name == "Terms")
            {
                return RepositoryMgr.TermsMgr.FindById(_obj.TermsID);
            }
            else if (property_name == "PurchaseComment")
            {
                return RepositoryMgr.CommentMgr.FindById(_obj.PurchaseCommentID);
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
            else if (property_name == "FreightTaxCode")
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.FreightTaxCodeID);
            }
            else if (property_name == "ShippingMethod")
            {
                return RepositoryMgr.ShippingMethodMgr.FindById(_obj.ShippingMethodID);
            }
            else if (property_name.Equals("PaymentMethod"))
            {
                return RepositoryMgr.PaymentMethodMgr.FindById(_obj.PaymentMethodID);
            }

            return null;
        }

        protected override IList<Supplier>_FindAllCollection()
        {
            BindingList<Supplier> suppliers = new BindingList<Supplier>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Supplier _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                suppliers.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return suppliers;
        }


       
    }
}
