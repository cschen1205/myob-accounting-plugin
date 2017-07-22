using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Db.Myob
{
    using Accounting.Core;
    using System.Data.Common;
    using System.Data.Odbc;
    using Accounting.Db;
    using Accounting.Db.Elements;
    using Accounting.Core.Cards;
    public class DbEmployeeManager : EmployeeManager
    {
        public DbEmployeeManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override OpResult _Store(Employee _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Employee object cannot be created as it is null");
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
            

            if (_obj.EmploymentBasis != null)
            {
                clause.InsertColumn("EmploymentBasis", DbMgr.CreateStringFieldEntry(_obj.EmploymentBasis.EmploymentBasisID));
            }

            if (_obj.PaymentType != null)
            {
                int payment_type_id = _obj.PaymentType.ToInt();
              
                clause.InsertColumn("PaymentMethod", DbMgr.CreateIntFieldEntry(payment_type_id));

                if (_obj.PaymentType.IsElectronic) 
                {
                    int number_of_accounts = _obj.NumberOfBankAccounts.Value;
                    clause.InsertColumn("NumberOfBankAccounts", DbMgr.CreateIntFieldEntry(number_of_accounts));

                    clause.InsertColumn("Bank1BSB", DbMgr.CreateStringFieldEntry(_obj.BSBCode));
                    string bank1_account_number_text = _obj.BankAccountNumber;
                    bank1_account_number_text = bank1_account_number_text.Replace("-", "");
                    int bank1_account_number;
                    if (int.TryParse(bank1_account_number_text, out bank1_account_number))
                    {
                        clause.InsertColumn("Bank1AccountNumber", DbMgr.CreateIntFieldEntry(bank1_account_number));
                    }
                    clause.InsertColumn("Bank1AccountName", DbMgr.CreateStringFieldEntry(_obj.BankAccountName));

                    clause.InsertColumn("Bank1BSB", DbMgr.CreateStringFieldEntry(_obj.BSBCode));

                    clause.InsertColumn("Bank1BankValue", DbMgr.CreateDoubleFieldEntry(_obj.Bank1Value));
                    if (_obj.Bank1ValueType != null)
                    {
                        clause.InsertColumn("Bank1BankValueType", DbMgr.CreateStringFieldEntry(_obj.Bank1ValueType.ValueTypeID));
                    }

                    clause.InsertColumn("StatementText", DbMgr.CreateStringFieldEntry(_obj.StatementText));

                    if (number_of_accounts == 2 || number_of_accounts == 3)
                    {
                        clause.InsertColumn("Bank2BSB", DbMgr.CreateStringFieldEntry(_obj.BSBCode2));
                        string bank2_account_number_text = _obj.BankAccountNumber2;
                        bank2_account_number_text = bank2_account_number_text.Replace("-", "");
                        int bank2_account_number;
                        if (int.TryParse(bank2_account_number_text, out bank2_account_number))
                        {
                            clause.InsertColumn("Bank2AccountNumber", DbMgr.CreateIntFieldEntry(bank2_account_number));
                        }
                        clause.InsertColumn("Bank2AccountName", DbMgr.CreateStringFieldEntry(_obj.BankAccountName2));

                        clause.InsertColumn("Bank2BankValue", DbMgr.CreateDoubleFieldEntry(_obj.Bank2Value));
                        if (_obj.Bank2ValueType != null)
                        {
                            clause.InsertColumn("Bank2BankValueType", DbMgr.CreateStringFieldEntry(_obj.Bank2ValueType.ValueTypeID));
                        }
                    }

                    if (number_of_accounts == 3)
                    {
                        clause.InsertColumn("Bank3BSB", DbMgr.CreateStringFieldEntry(_obj.BSBCode3));
                        string bank3_account_number_text = _obj.BankAccountNumber3;
                        bank3_account_number_text = bank3_account_number_text.Replace("-", "");
                        int bank3_account_number;
                        if (int.TryParse(bank3_account_number_text, out bank3_account_number))
                        {
                            clause.InsertColumn("Bank3AccountNumber", DbMgr.CreateIntFieldEntry(bank3_account_number));
                        }
                        clause.InsertColumn("Bank3AccountName", DbMgr.CreateStringFieldEntry(_obj.BankAccountName3));
                    }
                }
            }

            if (_obj.EmploymentClassification != null)
            {
                clause.InsertColumn("EmploymentClassification", DbMgr.CreateStringFieldEntry(_obj.EmploymentClassification.EmploymentClassificationName));
            }

            if (_obj.DateOfBirth != null)
            {
                clause.InsertColumn("DateOfBirth", DbMgr.CreateDateTimeFieldEntry(_obj.DateOfBirth));
            }

            clause.InsertColumn("Gender", DbMgr.CreateStringFieldEntry(_obj.Gender));

            if(_obj.StartDate != null)
            {
                clause.InsertColumn("StartDate", DbMgr.CreateDateTimeFieldEntry(_obj.StartDate));
            }
            if(_obj.TerminationDate != null)
            {
                clause.InsertColumn("TerminationDate", DbMgr.CreateDateTimeFieldEntry(_obj.TerminationDate));
            }

            if (_obj.PayBasis != null)
            {
                clause.InsertColumn("PayBasis", DbMgr.CreateStringFieldEntry(_obj.PayBasis.PayBasisID));
            }

            clause.InsertColumn("SalaryRate", DbMgr.CreateDoubleFieldEntry(_obj.BasePay));

            if (_obj.PayFrequency != null)
            {
                clause.InsertColumn("PayFrequency", DbMgr.CreateStringFieldEntry(_obj.PayFrequency.FrequencyID));
            }

            clause.InsertColumn("HoursInPayPeriod", DbMgr.CreateDoubleFieldEntry(_obj.HoursInPayPeriod));

            if (_obj.WagesExpenseAccount != null)
            {
                string wages_expense_account_number_text = _obj.WagesExpenseAccount.AccountNumber;
                wages_expense_account_number_text = wages_expense_account_number_text.Replace("-", "");
                int wages_expense_account_number;
                if (int.TryParse(wages_expense_account_number_text, out wages_expense_account_number))
                {
                    clause.InsertColumn("WagesExpenseAccount", DbMgr.CreateIntFieldEntry(wages_expense_account_number));
                }
            }

            if (_obj.SuperannuationFund != null)
            {
                clause.InsertColumn("SuperannuationFund", DbMgr.CreateStringFieldEntry(_obj.SuperannuationFund.SuperannuationFundName));
            }

            clause.InsertColumn("EmployeeMembership", DbMgr.CreateStringFieldEntry(_obj.SuperannuationMembershipNumber));

            string tax_file_number_text = _obj.TaxFileNumber;
            int tax_file_number;
            if (int.TryParse(tax_file_number_text, out tax_file_number))
            {
                clause.InsertColumn("TaxFileNumber", DbMgr.CreateIntFieldEntry(tax_file_number));
            }

            if(_obj.TaxScale != null)
            {
                clause.InsertColumn("TaxTable", DbMgr.CreateStringFieldEntry(_obj.TaxScale.Description));
            }

            clause.InsertColumn("WithholdingVariationRate", DbMgr.CreateDoubleFieldEntry(_obj.WithholdingVariationRate));

            clause.InsertColumn("TotalRebates", DbMgr.CreateDoubleFieldEntry(_obj.TotalRebates));
            clause.InsertColumn("ExtraTax", DbMgr.CreateDoubleFieldEntry(_obj.ExtraTax));

            clause.InsertColumn("EmploymentCategory", DbMgr.CreateStringFieldEntry(_obj.EmploymentCategory.EmploymentCategoryID));
            clause.InsertColumn("EmploymentStatus", DbMgr.CreateStringFieldEntry(_obj.EmploymentStatus.EmploymentStatusID));

            clause.Into("Import_Employee_Cards");


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

        private void PopulateAddress(DbInsertStatement clause, Employee _obj, int address_index)
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
            //clause.InsertColumn(string.Format("Address{0}ContactName", address_index), DbMgr.CreateStringFieldEntry(address.ContactName));
            clause.InsertColumn(string.Format("Address{0}Salutation", address_index), DbMgr.CreateStringFieldEntry(address.Solutation));
        }
    }
}
