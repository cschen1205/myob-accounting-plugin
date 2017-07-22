using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db.Elements;
using Accounting.Db;

namespace Accounting.Core.Cards
{
    public abstract class EmployeeManager : EntityManager<Employee>
    {
        public EmployeeManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        #region +(Factory Methods)
        protected override Employee _CreateDbEntity()
        {
            Employee _obj = new Employee(true, this);
            _obj.CardTypeID = CardType.GetCardTypeID(CardType.TypeID.Employee);
            return _obj;
        }

        protected override Employee _CreateEntity()
        {
            Employee _obj = new Employee(false, this);
            _obj.CardTypeID = CardType.GetCardTypeID(CardType.TypeID.Employee);
            _obj.IsIndividual = "Y";
            return _obj;
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(Employee _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["EmployeeID"] = DbMgr.CreateAutoIntFieldEntry(_obj.EmployeeID);
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["Name"] = DbMgr.CreateStringFieldEntry(_obj.Name);
            fields["FirstName"] = DbMgr.CreateStringFieldEntry(_obj.FirstName);
            fields["LastName"] = DbMgr.CreateStringFieldEntry(_obj.LastName);
            fields["Gender"] = DbMgr.CreateStringFieldEntry(_obj.Gender);
            fields["DateOfBirth"] = DbMgr.CreateDateTimeFieldEntry(_obj.DateOfBirth);
            fields["CardIdentification"] = DbMgr.CreateStringFieldEntry(_obj.CardIdentification);
            fields["BasePay"] = DbMgr.CreateDoubleFieldEntry(_obj.BasePay);
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["Notes"] = DbMgr.CreateStringFieldEntry(_obj.Notes);
            fields["PaymentDeliveryID"] = DbMgr.CreateStringFieldEntry(_obj.PaymentDeliveryID);
            fields["IsInactive"] = DbMgr.CreateStringFieldEntry(_obj.IsInactive);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["IsIndividual"] = DbMgr.CreateStringFieldEntry(_obj.IsIndividual);
            fields["EstimatedCostPerHour"] = DbMgr.CreateDoubleFieldEntry(_obj.EstimatedCostPerHour);
            fields["HourlyBillingRate"] = DbMgr.CreateDoubleFieldEntry(_obj.HourlyBillingRate);
            fields["CustomField1"] = DbMgr.CreateStringFieldEntry(_obj.CustomField1);
            fields["CustomList1ID"] = DbMgr.CreateIntFieldEntry(_obj.CustomList1ID);
            fields["CustomField2"] = DbMgr.CreateStringFieldEntry(_obj.CustomField2);
            fields["CustomList2ID"] = DbMgr.CreateIntFieldEntry(_obj.CustomList2ID);
            fields["CustomField3"] = DbMgr.CreateStringFieldEntry(_obj.CustomField3);
            fields["CustomList3ID"] = DbMgr.CreateIntFieldEntry(_obj.CustomList3ID);
            fields["Identifiers"] = DbMgr.CreateStringFieldEntry(_obj.Identifiers);
            fields["BSBCode"] = DbMgr.CreateStringFieldEntry(_obj.BSBCode);
            fields["BankAccountNumber"] = DbMgr.CreateStringFieldEntry(_obj.BankAccountNumber);
            fields["BankAccountName"] = DbMgr.CreateStringFieldEntry(_obj.BankAccountName);
            fields["NumberOfBankAccounts"] = DbMgr.CreateIntFieldEntry(_obj.NumberOfBankAccounts);
            fields["BSBCode2"] = DbMgr.CreateStringFieldEntry(_obj.BSBCode2);
            fields["BankAccountNumber2"] = DbMgr.CreateStringFieldEntry(_obj.BankAccountNumber2);
            fields["BankAccountName2"] = DbMgr.CreateStringFieldEntry(_obj.BankAccountName2);
            fields["BSBCode3"] = DbMgr.CreateStringFieldEntry(_obj.BSBCode3);
            fields["BankAccountNumber3"] = DbMgr.CreateStringFieldEntry(_obj.BankAccountNumber3);
            fields["BankAccountName3"] = DbMgr.CreateStringFieldEntry(_obj.BankAccountName3);
            fields["Bank1Value"] = DbMgr.CreateDoubleFieldEntry(_obj.Bank1Value);
            fields["Bank1ValueTypeID"] = DbMgr.CreateStringFieldEntry(_obj.Bank1ValueTypeID);
            fields["Bank2Value"] = DbMgr.CreateDoubleFieldEntry(_obj.Bank2Value);
            fields["Bank2ValueTypeID"] = DbMgr.CreateStringFieldEntry(_obj.Bank2ValueTypeID);
            fields["Bank3Value"] = DbMgr.CreateDoubleFieldEntry(_obj.Bank3Value);
            fields["Bank3ValueTypeID"] = DbMgr.CreateStringFieldEntry(_obj.Bank3ValueTypeID);
            fields["StatementText"] = DbMgr.CreateStringFieldEntry(_obj.StatementText);
            fields["EmploymentBasisID"] = DbMgr.CreateStringFieldEntry(_obj.EmploymentBasisID);
            fields["PaymentTypeID"] = DbMgr.CreateStringFieldEntry(_obj.PaymentTypeID);
            fields["EmploymentClassificationID"] = DbMgr.CreateIntFieldEntry(_obj.EmploymentClassificationID);
            fields["StartDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.StartDate);
            fields["TerminationDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.TerminationDate);
            fields["PayBasisID"] = DbMgr.CreateStringFieldEntry(_obj.PayBasisID);
            fields["PayFrequencyID"] = DbMgr.CreateStringFieldEntry(_obj.PayFrequencyID);
            fields["HoursInPayPeriod"] = DbMgr.CreateDoubleFieldEntry(_obj.HoursInPayPeriod);
            fields["WagesExpenseAccountID"] = DbMgr.CreateIntFieldEntry(_obj.WagesExpenseAccountID);
            fields["SuperannuationFundID"] = DbMgr.CreateIntFieldEntry(_obj.SuperannuationFundID);
            fields["SuperannuationMembershipNumber"] = DbMgr.CreateStringFieldEntry(_obj.SuperannuationMembershipNumber);
            fields["TaxFileNumber"] = DbMgr.CreateStringFieldEntry(_obj.TaxFileNumber);
            fields["TaxScaleID"] = DbMgr.CreateIntFieldEntry(_obj.TaxScaleID);
            fields["WithholdingVariationRate"] = DbMgr.CreateDoubleFieldEntry(_obj.WithholdingVariationRate);
            fields["TotalRebates"] = DbMgr.CreateDoubleFieldEntry(_obj.TotalRebates);
            fields["ExtraTax"] = DbMgr.CreateDoubleFieldEntry(_obj.ExtraTax);
            fields["EmploymentStatusID"] = DbMgr.CreateStringFieldEntry(_obj.EmploymentStatusID);
            fields["EmploymentCategoryID"] = DbMgr.CreateStringFieldEntry(_obj.EmploymentCategoryID);
            fields["Picture"] = DbMgr.CreateStringFieldEntry(_obj.Picture);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Employees");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByCardIdentification(string CardIdentification)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Employees")
                .Criteria.IsEqual("Employees", "CardIdentification", CardIdentification);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByEmployeeID(int EmployeeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Employees")
                .Criteria.IsEqual("Employees", "EmployeeID", EmployeeID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByCardIdentification(string CardIdentification)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("Employees")
                .Criteria.IsEqual("Employees", "CardIdentification", CardIdentification);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByEmployeeID(int EmployeeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("Employees")
                .Criteria.IsEqual("Employees", "EmployeeID", EmployeeID);

            return clause;
        }

        public override bool Exists(Employee _obj)
        {
            return Exists(_obj.EmployeeID);
        }

        protected override void LoadFromReader(Employee _obj, DbDataReader _reader)
        {
            _obj.EmployeeID =GetInt32(_reader, ("EmployeeID"));
            _obj.FirstName =GetString(_reader, ("FirstName"));
            _obj.Name =GetString(_reader, ("Name"));
            _obj.Gender =GetString(_reader, ("Gender"));
            _obj.BasePay = GetDouble(_reader, ("BasePay"));
            _obj.CardIdentification =GetString(_reader, ("CardIdentification"));
            _obj.DateOfBirth = GetDateTime(_reader, ("DateOfBirth"));
            _obj.CardRecordID =GetInt32(_reader, ("CardRecordID"));
            _obj.Notes =GetString(_reader, ("Notes"));
            _obj.LastName =GetString(_reader, ("LastName"));
            _obj.IsInactive =GetString(_reader, ("IsInactive"));
            _obj.PaymentDeliveryID =GetString(_reader, ("PaymentDeliveryID"));
            _obj.CurrencyID =GetInt32(_reader, ("CurrencyID"));
            _obj.IsIndividual = GetString(_reader, ("IsIndividual"));
            _obj.HourlyBillingRate = GetDouble(_reader, "HourlyBillingRate");
            _obj.EstimatedCostPerHour = GetDouble(_reader, "EstimatedCostPerHour");
            _obj.CustomList1ID = GetInt32(_reader, "CustomList1ID");
            _obj.CustomField1 = GetString(_reader, "CustomField1");
            _obj.CustomList2ID = GetInt32(_reader, "CustomList2ID");
            _obj.CustomField2 = GetString(_reader, "CustomField2");
            _obj.CustomList3ID = GetInt32(_reader, "CustomList3ID");
            _obj.CustomField3 = GetString(_reader, "CustomField3");
            _obj.Identifiers = GetString(_reader, "Identifiers");
            _obj.BankAccountName = GetString(_reader, "BankAccountName");
            _obj.BankAccountNumber = GetString(_reader, "BankAccountNumber");
            _obj.BSBCode = GetString(_reader, "BSBCode");
            _obj.NumberOfBankAccounts = GetInt32(_reader, "NumberOfBankAccounts");
            _obj.BankAccountName2 = GetString(_reader, "BankAccountName2");
            _obj.BankAccountNumber2 = GetString(_reader, "BankAccountNumber2");
            _obj.BSBCode2 = GetString(_reader, "BSBCode2");
            _obj.BankAccountName3 = GetString(_reader, "BankAccountName3");
            _obj.BankAccountNumber3 = GetString(_reader, "BankAccountNumber3");
            _obj.BSBCode3 = GetString(_reader, "BSBCode3");
            _obj.Bank1Value = GetDouble(_reader, "Bank1ValueID");
            _obj.Bank1ValueTypeID = GetString(_reader, "Bank1ValueTypeID");
            _obj.Bank2Value = GetDouble(_reader, "Bank2ValueID");
            _obj.Bank2ValueTypeID = GetString(_reader, "Bank2ValueTypeID");
            _obj.Bank3Value = GetDouble(_reader, "Bank3ValueID");
            _obj.Bank3ValueTypeID = GetString(_reader, "Bank3ValueTypeID");
            _obj.StatementText = GetString(_reader, "StatementText");
            _obj.EmploymentBasisID = GetString(_reader, "EmploymentBasisID");
            _obj.PaymentTypeID = GetString(_reader, "PaymentTypeID");
            _obj.EmploymentClassificationID = GetInt32(_reader, "EmploymentClassificationID");
            _obj.StartDate = GetDateTime(_reader, "StartDate");
            _obj.TerminationDate = GetDateTime(_reader, "TerminationDate");
            _obj.PayBasisID = GetString(_reader, "PayBasisID");
            _obj.PayFrequencyID = GetString(_reader, "PayFrequencyID");
            _obj.HoursInPayPeriod = GetDouble(_reader, "HoursInPayPeriod");
            _obj.WagesExpenseAccountID = GetInt32(_reader, "WagesExpenseAccountID");
            _obj.SuperannuationFundID = GetInt32(_reader, "SuperannuationFundID");
            _obj.SuperannuationMembershipNumber = GetString(_reader, "SuperannuationMembershipNumber");
            _obj.TaxFileNumber = GetString(_reader, "TaxFileNumber");
            _obj.TaxScaleID = GetInt32(_reader, "TaxScaleID");
            _obj.WithholdingVariationRate = GetDouble(_reader, "WithholdingVariationRate");
            _obj.TotalRebates = GetDouble(_reader, "TotalRebates");
            _obj.ExtraTax = GetDouble(_reader, "ExtraTax");
            _obj.EmploymentCategoryID = GetString(_reader, "EmploymentCategoryID");
            _obj.EmploymentStatusID = GetString(_reader, "EmploymentStatusID");
            _obj.Picture = GetString(_reader, "Picture");
        }

        public string GenerateCardIdentification()
        {
            string CardIdentification = "";
            int sequence = 1;
            bool found = false;
            do
            {
                CardIdentification = string.Format("EMP{0:d5}", sequence++);
                found=Exists(CardIdentification);
            } while (found);
            return CardIdentification;
        }

        protected override object GetDbProperty(Employee _obj, string property_name)
        {
            if (property_name == "Currency")
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name == "PaymentDelivery")
            {
                return RepositoryMgr.InvoiceDeliveryMgr.FindById(_obj.PaymentDeliveryID);
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
            else if (property_name == "Bank1ValueType")
            {
                return RepositoryMgr.PaymentValueTypeMgr.FindById(_obj.Bank1ValueTypeID);
            }
            else if (property_name == "Bank2ValueType")
            {
                return RepositoryMgr.PaymentValueTypeMgr.FindById(_obj.Bank2ValueTypeID);
            }
            else if (property_name == "Bank3ValueType")
            {
                return RepositoryMgr.PaymentValueTypeMgr.FindById(_obj.Bank3ValueTypeID);
            }
            else if (property_name == "PaymentType")
            {
                return RepositoryMgr.PaymentTypeMgr.FindById(_obj.PaymentTypeID);
            }
            else if (property_name == "EmploymentBasis")
            {
                return RepositoryMgr.EmploymentBasisMgr.FindById(_obj.EmploymentBasisID);
            }
            else if(property_name=="EmploymentClassification")
            {
                return RepositoryMgr.EmploymentClassificationMgr.FindById(_obj.EmploymentClassificationID);
            }
            else if (property_name == "PayBasis")
            {
                return RepositoryMgr.PayBasisMgr.FindById(_obj.PayBasisID);
            }
            else if (property_name == "PayFrequency")
            {
                return RepositoryMgr.FrequencyMgr.FindById(_obj.PayFrequencyID);
            }
            else if (property_name == "WagesExpenseAccount")
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.WagesExpenseAccountID);
            }
            else if (property_name == "SuperannuationFund")
            {
                return RepositoryMgr.SuperannuationFundMgr.FindById(_obj.SuperannuationFundID);
            }
            else if (property_name == "TaxScale")
            {
                return RepositoryMgr.TaxScaleMgr.FindById(_obj.TaxScaleID);
            }
            else if (property_name == "EmploymentStatus")
            {
                return RepositoryMgr.EmploymentStatusMgr.FindById(_obj.EmploymentStatusID);
            }
            else if (property_name == "EmploymentCategory")
            {
                return RepositoryMgr.EmploymentCategoryMgr.FindById(_obj.EmploymentCategoryID);
            }

            return null;
        }

        private bool Exists(int? EmployeeID)
        {
            if (EmployeeID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByEmployeeID(EmployeeID.Value)) != 0;
        }

        private bool Exists(string CardIdentification)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByCardIdentification(CardIdentification)) != 0;
        }

        protected override Employee _FindByIntId(int? EmployeeID)
        {
            if (Exists(EmployeeID))
            {
                Employee _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByEmployeeID(EmployeeID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        public Employee FindByCardIdentification(string CardIdentification)
        {
            if (Exists(CardIdentification))
            {
                Employee _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByCardIdentification(CardIdentification));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override IList<Employee>_FindAllCollection()
        {
            List<Employee> _employees = new List<Employee>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Employee _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _employees.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _employees;
        }

        public List<EmployeeRow> ListRow()
        {
            List<EmployeeRow> _employees = new List<EmployeeRow>();

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectColumn("Employees", "CardRecordID")
                .SelectColumn("Employees", "CardIdentification")
                .SelectColumn("Employees", "FirstName")
                .SelectColumn("Employees", "LastName")
                .SelectColumn("Employees", "IsInactive")
                .From("Employees");

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                EmployeeRow _obj = new EmployeeRow();
                _obj.CardIdentification = GetString(_reader, "CardIdentification");
                _obj.EmployeeID = GetInt32(_reader, "CardRecordID");
                _obj.FirstName = GetString(_reader, "FirstName");
                _obj.LastName = GetString(_reader, "LastName");
                string IsInactive = GetString(_reader, "IsInactive");
                if (IsInactive.Equals("Y"))
                {
                    _obj.IsInactive = true;
                }
                _employees.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _employees;
        }

      

        public Employee CreateOrRetrieve(string CardIdentification, out bool created)
        {
            Employee _obj = FindByCardIdentification(CardIdentification);
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

        public Employee CreateOrRetrieve(string CardIdentification)
        {
            bool created;
            return CreateOrRetrieve(CardIdentification, out created);
        }
    }
}
