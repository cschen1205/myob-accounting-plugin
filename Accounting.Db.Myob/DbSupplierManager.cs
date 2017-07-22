using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Db.Myob
{
    using Accounting.Core;
    using Accounting.Core.Cards;
    using Accounting.Db;
    using Accounting.Db.Elements;
    using Accounting.Util;
    using System.Data.Odbc;
    using System.Data.Common;

    public class DbSupplierManager : SupplierManager
    {
        public DbSupplierManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override OpResult _Store(Supplier _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Supplier object cannot be deleted as it is null");
            }

            bool is_creating = !Exists(_obj);

            DbInsertStatement clause = DbMgr.CreateInsertClause();
            clause.InsertColumn("CardID", DbMgr.CreateStringFieldEntry(_obj.CardIdentification));
            clause.InsertColumn("FirstName", DbMgr.CreateStringFieldEntry(_obj.FirstName));
            clause.InsertColumn("CoLastName", DbMgr.CreateStringFieldEntry(_obj.LastName));
            clause.InsertColumn("CardStatus", DbMgr.CreateStringFieldEntry(_obj.IsInactive));
            if(RepositoryMgr.IsMultiUserVersion && _obj.Currency!=null)
            {
                clause.InsertColumn("CurrencyCode", DbMgr.CreateStringFieldEntry(_obj.Currency.CurrencyCode));
            }
            PopulateAddress(clause, _obj, 1);
            PopulateAddress(clause, _obj, 2);
            PopulateAddress(clause, _obj, 3);
            PopulateAddress(clause, _obj, 4);
            PopulateAddress(clause, _obj, 5);
            clause.InsertColumn("Picture", DbMgr.CreateStringFieldEntry(_obj.Picture));
            clause.InsertColumn("Notes", DbMgr.CreateStringFieldEntry(_obj.Notes));
            clause.InsertColumn("Identifiers", DbMgr.CreateStringFieldEntry(_obj.Identifiers));
            clause.InsertColumn("CustomField1", DbMgr.CreateStringFieldEntry(_obj.CustomField1));
            clause.InsertColumn("CustomField2", DbMgr.CreateStringFieldEntry(_obj.CustomField2));
            clause.InsertColumn("CustomField3", DbMgr.CreateStringFieldEntry(_obj.CustomField3));
            if (this.RepositoryMgr.IsMultiUserVersion)
            {
                clause.InsertColumn("BillingRate", DbMgr.CreateDoubleFieldEntry(_obj.HourlyBillingRate));
                clause.InsertColumn("CostPerHour", DbMgr.CreateDoubleFieldEntry(_obj.EstimatedCostPerHour));
            }
            if(_obj.Terms!=null)
            {
                clause.InsertColumn("PaymentIsDue", DbMgr.CreateIntFieldEntry(_obj.Terms.PaymentIsDue));
                clause.InsertColumn("DiscountDays", DbMgr.CreateIntFieldEntry(_obj.Terms.DiscountDays));
                clause.InsertColumn("BalanceDueDays", DbMgr.CreateIntFieldEntry(_obj.Terms.BalanceDueDays));
                clause.InsertColumn("PercentDiscount", DbMgr.CreateDoubleFieldEntry(_obj.Terms.EarlyPaymentDiscountPercent));
                //clause.InsertColumn("PercentMonthlyCharge", DbMgr.CreateDoubleFieldEntry(_obj.Terms.LatePaymentChargePercent));
            }
            if (_obj.TaxCode != null)
            {
                clause.InsertColumn("TaxCode", DbMgr.CreateStringFieldEntry(_obj.TaxCode.Code));
            }
            clause.InsertColumn("CreditLimit", DbMgr.CreateDoubleFieldEntry(_obj.CreditLimit));
            clause.InsertColumn("TaxIDNumber", DbMgr.CreateStringFieldEntry(_obj.TaxIDNumber));
            clause.InsertColumn("VolumeDiscount", DbMgr.CreateDoubleFieldEntry(_obj.VolumeDiscount));
            if (_obj.PurchaseLayout != null)
            {
                clause.InsertColumn("PurchaseLayout", DbMgr.CreateStringFieldEntry(_obj.PurchaseLayout.InvoiceTypeID));
            }
            if (_obj.PaymentMethod != null)
            {
                clause.InsertColumn("PaymentMethod", DbMgr.CreateStringFieldEntry(_obj.PaymentMethod.MethodType));
            }
            clause.InsertColumn("PaymentNotes", DbMgr.CreateStringFieldEntry(_obj.PaymentNotes));
            clause.InsertColumn("NameOnCard", DbMgr.CreateStringFieldEntry(_obj.PaymentNameOnCard));
            clause.InsertColumn("CardNumber", DbMgr.CreateStringFieldEntry(_obj.PaymentCardNumber));
            clause.InsertColumn("ExpiryDate", DbMgr.CreateStringFieldEntry(_obj.PaymentExpirationDate));
            clause.InsertColumn("BSB", DbMgr.CreateStringFieldEntry(_obj.PaymentBSB));

            string bank_account_number_text = _obj.PaymentBankAccountNumber;
            bank_account_number_text = bank_account_number_text.Replace("-", "");
            int bank_account_number;
            if (int.TryParse(bank_account_number_text, out bank_account_number))
            {
                clause.InsertColumn("AccountNumber", DbMgr.CreateIntFieldEntry(bank_account_number));
            }
            clause.InsertColumn("AccountName", DbMgr.CreateStringFieldEntry(_obj.PaymentBankAccountName));

            string statement_text=RepositoryMgr.DataFileInformationMgr.Company.CompanyName.ToUpper();
            clause.InsertColumn("StatementText", DbMgr.CreateStringFieldEntry(statement_text));

            clause.InsertColumn("ABN", DbMgr.CreateStringFieldEntry(_obj.ABN)); ;
            clause.InsertColumn("ABNBranch", DbMgr.CreateStringFieldEntry(_obj.ABNBranch));

            if (_obj.ExpenseAccount != null)
            {
                string expense_account_number_text = _obj.ExpenseAccount.AccountNumber;
                expense_account_number_text = expense_account_number_text.Replace("-", "");
                int expense_account_number;
                if (int.TryParse(expense_account_number_text, out expense_account_number))
                {
                    clause.InsertColumn("ExpenseAccount", DbMgr.CreateIntFieldEntry(expense_account_number));
                }
            }

            if(_obj.PurchaseComment != null)
            {
                clause.InsertColumn("PurchaseComment", DbMgr.CreateStringFieldEntry(_obj.PurchaseComment.Text));
            }

            if(_obj.ShippingMethod != null)
            {
                clause.InsertColumn("ShippingMethod", DbMgr.CreateStringFieldEntry(_obj.ShippingMethod.Method));
            }

            if(_obj.FreightTaxCode != null)
            {
                clause.InsertColumn("FreightTaxCode", DbMgr.CreateStringFieldEntry(_obj.FreightTaxCode.Code));
            }

            clause.InsertColumn("UseSuppliersTaxCode", DbMgr.CreateStringFieldEntry(_obj.UseSupplierTaxCode));

            if(_obj.InvoiceDelivery != null)
            {
                clause.InsertColumn("PurchaseDelivery", DbMgr.CreateStringFieldEntry(_obj.InvoiceDelivery.InvoiceDeliveryID));
            }

            clause.InsertColumn("PaymentMemo", DbMgr.CreateStringFieldEntry(_obj.PaymentMemo));

            clause.Into("Import_Supplier_Cards");

            DbCommand cmdSQLInsert = CreateDbCommand(clause);
            DbTransaction myTrans = DbMgr.DbConnection.BeginTransaction();
            try
            {
                cmdSQLInsert.CommandText = clause.ToString();
                cmdSQLInsert.Transaction = myTrans;
                cmdSQLInsert.ExecuteNonQuery();
                myTrans.Commit();
            }
            catch (OdbcException ex)
            {
                myTrans.Rollback();
                Log(ex.Message);
                //Console.WriteLine(ex.ToString());
                if (is_creating)
                {
                    return OpResult.NotifyStoreAction(OpResult.ResultStatus.CreatedWithException, _obj, ex.ToString());
                }
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.UpdatedWithException, _obj, ex.ToString());
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                //Console.WriteLine(ex.ToString());
                if (is_creating)
                {
                    return OpResult.NotifyStoreAction(OpResult.ResultStatus.CreatedWithException, _obj, ex.ToString());
                }
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.UpdatedWithException, _obj, ex.ToString());
            }

            _obj.FromDb = true;

            if (is_creating)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
            }
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
        }

        private void PopulateAddress(DbInsertStatement clause, Supplier _obj, int address_index)
        {
            Address address=null;
            switch(address_index)
            {
                case 1:
                    {
                        address=_obj.Address1;
                        break;
                    }
                case 2:
                    {
                        address = _obj.Address2;
                        break;
                    }
                case 3:
                    {
                        address = _obj.Address3;
                        break;
                    }
                case 4:
                    {
                        address = _obj.Address4;
                        break;
                    }
                case 5:
                    {
                        address = _obj.Address5;
                        break;
                    }
            }
            clause.InsertColumn(string.Format("Address{0}AddressLine1", address_index), DbMgr.CreateStringFieldEntry(address.StreetLine1));
            clause.InsertColumn(string.Format("Address{0}AddressLine2", address_index), DbMgr.CreateStringFieldEntry(address.StreetLine2));
            clause.InsertColumn(string.Format("Address{0}AddressLine3", address_index), DbMgr.CreateStringFieldEntry(address.StreetLine3));
            clause.InsertColumn(string.Format("Address{0}AddressLine4", address_index), DbMgr.CreateStringFieldEntry(address.StreetLine4));
            clause.InsertColumn(string.Format("Address{0}City", address_index), DbMgr.CreateStringFieldEntry(address.City));
            clause.InsertColumn(string.Format("Address{0}State", address_index), DbMgr.CreateStringFieldEntry(address.State));
            clause.InsertColumn(string.Format("Address{0}PostCode", address_index), DbMgr.CreateStringFieldEntry(address.Postcode));
            clause.InsertColumn(string.Format("Address{0}Country", address_index), DbMgr.CreateStringFieldEntry(address.Country));
            clause.InsertColumn(string.Format("Address{0}Phone1", address_index), DbMgr.CreateStringFieldEntry(address.Phone1));
            clause.InsertColumn(string.Format("Address{0}Phone2", address_index), DbMgr.CreateStringFieldEntry(address.Phone2));
            clause.InsertColumn(string.Format("Address{0}Phone3", address_index), DbMgr.CreateStringFieldEntry(address.Phone3));
            clause.InsertColumn(string.Format("Address{0}Fax", address_index), DbMgr.CreateStringFieldEntry(address.Fax));
            clause.InsertColumn(string.Format("Address{0}Email", address_index), DbMgr.CreateStringFieldEntry(address.Email));
            clause.InsertColumn(string.Format("Address{0}Website", address_index), DbMgr.CreateStringFieldEntry(address.Website));
            clause.InsertColumn(string.Format("Address{0}ContactName", address_index), DbMgr.CreateStringFieldEntry(address.ContactName));
            clause.InsertColumn(string.Format("Address{0}Salutation", address_index), DbMgr.CreateStringFieldEntry(address.Solutation));
        }
    }
}
