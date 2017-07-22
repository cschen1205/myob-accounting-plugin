using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Db;
using Accounting.Db.Elements;
using System.Data;
using System.Data.Common;

namespace Accounting.Core.Misc
{
    public class DataFileInformationManager : EntityManager<DataFileInformation>
    {
        public DataFileInformationManager(DbManager mgr)
            : base(mgr)
        {

        }

        protected override DataFileInformation _CreateDbEntity()
        {
            return new DataFileInformation(true, this);
        }

        protected override DataFileInformation _CreateEntity()
        {
            return new DataFileInformation(false, this);
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("DataFileInformation");
        }

        private DbSelectStatement GetQuery_SelectCountByCompanyName(string companyName)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectCount().From("DataFileInformation").Criteria.IsEqual("DataFileInformation", "CompanyName", companyName);
            return clause;
        }

        public override bool Exists(DataFileInformation _obj)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByCompanyName(_obj.CompanyName)) != 0;
        }

        protected override IList<DataFileInformation>_FindAllCollection()
        {
            List<DataFileInformation> _grp = new List<DataFileInformation>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                DataFileInformation _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override void LoadFromReader(DataFileInformation _obj, DbDataReader reader)
        {
            _obj.ABN = GetString(reader, "ABN");
            _obj.ABNBranch = GetString(reader, "ABNBranch");
            _obj.ACN = GetString(reader, "ACN");
            _obj.Address = GetString(reader, "Address");
            _obj.BankAccountName = GetString(reader, "BankAccountName");
            _obj.BankAccountNumber = GetString(reader, "BankAccountNumber");
            _obj.BankCode = GetString(reader, "BankCode");
            _obj.BankID = GetString(reader, "BankID");
            _obj.BSBCode = GetString(reader, "BSBCode");
            _obj.ChangeControl = GetString(reader, "ChangeControl");
            _obj.City = GetString(reader, "City");
            _obj.CompanyFileNumber = GetString(reader, "CompanyFileNumber");
            _obj.CompanyName = GetString(reader, "CompanyName");
            _obj.CompanyRegistrationNumber = GetString(reader, "CompanyRegistrationNumber");
            _obj.ConversionDate = GetDateTime(reader, "ConversionDate");
            _obj.CostCentresRequired = GetString(reader, "CostCentresRequired");
            _obj.CurrentFinancialYear = GetInt32(reader, "CurrentFinancialYear");
            _obj.DatabaseVersion = GetString(reader, "DatabaseVersion");
            _obj.DataFileCountry = GetString(reader, "DataFileCountry");
            _obj.DefaultCustomerCreditLimit = GetDouble(reader, "DefaultCustomerCreditLimit");
            _obj.DefaultCustomerFreightTaxCodeID = GetInt32(reader, "DefaultCustomerFreightTaxCodeID");
            _obj.DefaultCustomerPriceLevelID = GetString(reader, "DefaultCustomerPriceLevelID");
            _obj.DefaultCustomerTaxCodeID = GetInt32(reader, "DefaultCustomerTaxCodeID");
            _obj.DefaultCustomerTermsID = GetInt32(reader, "DefaultCustomerTermsID");
            _obj.DefaultSupplierCreditLimit = GetDouble(reader, "DefaultSupplierCreditLimit");
            _obj.DefaultSupplierFreightTaxCodeID = GetInt32(reader, "DefaultSupplierFreightTaxCodeID");
            _obj.DefaultSupplierTaxCodeID = GetInt32(reader, "DefaultSupplierTaxCodeID");
            _obj.DefaultSupplierTermsID = GetInt32(reader, "DefaultSupplierTermsID");
            _obj.DefaultUseCustomerTaxCode = GetString(reader, "DefaultUseCustomerTaxCode");
            _obj.DefaultUseSupplierTaxCode = GetString(reader, "DefaultUseSupplierTaxCode");
            _obj.DriverBuildNumber = GetInt32(reader, "DriverBuildNumber");
            _obj.Email = GetString(reader, "Email");
            _obj.FaxNumber = GetString(reader, "FaxNumber", "Fax");
            _obj.FirstAgeingPeriod = GetInt32(reader, "FirstAgeingPeriod");
            _obj.GSTRegistrationNumber = GetString(reader, "GSTRegistrationNumber");
            _obj.ID = GetInt32(reader, "ID");
            _obj.IdentifyAgeByName = GetString(reader, "IdentifyAgeByName");
            _obj.IncludeInvoiceNumber = GetString(reader, "IncludeInvoiceNumber");
            _obj.IncludeInvoiceOrderNumber = GetString(reader, "IncludeInvoiceOrderNumber");
            _obj.IncludeInvoiceQuoteNumber = GetString(reader, "IncludeInvoiceQuoteNumber");
            _obj.IncludePurchaseNumber = GetString(reader, "IncludePurchaseNumber");
            _obj.IncludePurchaseOrderNumber = GetString(reader, "IncludePurchaseOrderNumber");
            _obj.InvoiceMessage = GetString(reader, "InvoiceMessage");
            _obj.InvoiceOrderMessage = GetString(reader, "InvoiceOrderMessage");
            _obj.InvoiceOrderSubject = GetString(reader, "InvoiceOrderSubject");
            _obj.InvoiceQuoteMessage = GetString(reader, "InvoiceQuoteMessage");
            _obj.InvoiceQuoteSubject = GetString(reader, "InvoiceQuoteSubject");
            _obj.InvoiceSubject = GetString(reader, "InvoiceSubject");
            _obj.IsSelfBalancing = GetString(reader, "IsSelfBalancing");
            _obj.LastBackupDate = GetDateTime(reader, "LastBackupDate");
            _obj.LastMonthInFinancialYear = GetInt32(reader, "LastMonthInFinancialYear");
            _obj.LastPurgeDate = GetDateTime(reader, "LastPurgeDate");
            _obj.LimitTypeID = GetString(reader, "LimitTypeID");
            _obj.LockPeriodDate = GetDateTime(reader, "LockPeriodDate");
            _obj.LockPeriodIsActive = GetString(reader, "LockPeriodIsActive");
            _obj.LockThirteenthPeriod = GetString(reader, "LockThirteenthPeriod");
            _obj.PayeeNumber = GetString(reader, "PayeeNumber");
            _obj.PaymentMessage = GetString(reader, "PaymentMessage");
            _obj.PaymentSubject = GetString(reader, "PaymentSubject");
            _obj.PeriodsPerYear = GetInt32(reader, "PeriodsPerYear");
            _obj.Phone1 = GetString(reader, "Phone", "Phone1");
            _obj.Phone2 = GetString(reader, "Phone", "Phone2");
            _obj.PostCode = GetString(reader, "PostCode", "Postcode");
            _obj.Province = GetString(reader, "Province");
            _obj.PurchaseMessage = GetString(reader, "PurchaseMessage");
            _obj.PurchaseOrderMessage = GetString(reader, "PurchaseOrderMessage");
            _obj.PurchaseQuoteSubject = GetString(reader, "PurchaseQuoteSubject");
            _obj.PurchaseSubject = GetString(reader, "PurchaseSubject");
            //_obj.RegistrationNumber = GetString(reader, "RegistrationNumber", "GSTRegistrationNumber");
            _obj.SalesTaxNumber = GetString(reader, "SalesTaxNumber");
            _obj.SecondAgeingPeriod = GetInt32(reader, "SecondAgeingPeriod");
            _obj.SerialNumber = GetString(reader, "SerialNumber");
            _obj.SimplifiedTaxSystemDate = GetDateTime(reader, "SimplifiedTaxSystemDate");
            _obj.StatementCode = GetString(reader, "StatementCode");
            _obj.StatementMessage = GetString(reader, "StatementMessage");
            _obj.StatementParticulars = GetString(reader, "StatementParticulars");
            _obj.StatementReference = GetString(reader, "StatementReference");
            _obj.StatementSubject = GetString(reader, "StatementSubject");
            _obj.ThirdAgeingPeriod = GetInt32(reader, "ThirdAgeingPeriod");
            _obj.UseAuditTracking = GetString(reader, "UseAuditTracking");
            _obj.UseCostCentres = GetString(reader, "UseCostCentres");
            _obj.UseCreditLimitWarning = GetString(reader, "UseCreditLimitWarning");
            _obj.UseDailyAgeing = GetString(reader, "UseDailyAgeing");
            _obj.UseMultipleCurrencies = GetString(reader, "UseMultipleCurrencies");
            _obj.UsePayablesDeposits = GetString(reader, "UsePayablesDeposits");
            _obj.UsePayablesDiscounts = GetString(reader, "UsePayablesDiscounts");
            _obj.UsePayablesFreight = GetString(reader, "UsePayablesFreight");
            _obj.UsePayablesInventory = GetString(reader, "UsePayablesInventory");
            _obj.UsePayablesLateFees = GetString(reader, "UsePayablesLateFees");
            _obj.UseReceivablesDeposits = GetString(reader, "UseReceivablesDeposits");
            _obj.UseReceivablesDiscounts = GetString(reader, "UseReceivablesDiscounts");
            _obj.UseReceivablesFreight = GetString(reader, "UseReceivablesFreight");
            _obj.UseReceivablesLateFees = GetString(reader, "UseReceivablesLateFees");
            _obj.UseRetailManagerLink = GetString(reader, "UseRetailManagerLink");
            _obj.UseSimplifiedTaxSystem = GetString(reader, "UseSimplifiedTaxSystem");
            _obj.UseStandardCost = GetString(reader, "UseStandardCost");
            _obj.WebSite = GetString(reader, "WebSite");
        }

        private DataFileInformation mCompany;
        public DataFileInformation Company
        {
            get
            {
                if (mCompany == null)
                {
                    IList<DataFileInformation> files =_FindAllCollection();
                    if (files.Count > 0)
                    {
                        mCompany = files[0];
                    }
                }
                return mCompany;
            }
        }

        public override Dictionary<string, DbFieldEntry> GetFields(DataFileInformation _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["Address"] = DbMgr.CreateStringFieldEntry(_obj.Address);
            fields["ABN"] = DbMgr.CreateStringFieldEntry(_obj.ABN);
            fields["ABNBranch"] = DbMgr.CreateStringFieldEntry(_obj.ABNBranch);
            fields["ACN"]=DbMgr.CreateStringFieldEntry(_obj.ACN);
            fields["BankAccountName"]=DbMgr.CreateStringFieldEntry(_obj.BankAccountName);
            fields["BankAccountNumber"] = DbMgr.CreateStringFieldEntry(_obj.BankAccountNumber);
            fields["BankCode"]=DbMgr.CreateStringFieldEntry(_obj.BankCode);
            fields["BankID"] = DbMgr.CreateStringFieldEntry(_obj.BankID);
            fields["BSBCode"] = DbMgr.CreateStringFieldEntry(_obj.BSBCode);
            fields["ChangeControl"] = DbMgr.CreateStringFieldEntry(_obj.ChangeControl);
            fields["City"] = DbMgr.CreateStringFieldEntry(_obj.City);
            fields["CompanyName"] = DbMgr.CreateStringFieldEntry(_obj.CompanyName);
            fields["CompanyFileNumber"]=DbMgr.CreateStringFieldEntry(_obj.CompanyFileNumber);
            fields["CompanyRegistrationNumber"]=DbMgr.CreateStringFieldEntry(_obj.CompanyRegistrationNumber);
            fields["ConversionDate"]=DbMgr.CreateDateTimeFieldEntry(_obj.ConversionDate);
            fields["CostCentresRequired"]=DbMgr.CreateStringFieldEntry(_obj.CostCentresRequired);
            fields["CurrentFinancialYear"]=DbMgr.CreateIntFieldEntry(_obj.CurrentFinancialYear);
            fields["DataFileCountry"] = DbMgr.CreateStringFieldEntry(_obj.DataFileCountry);
            fields["DatabaseVersion"]=DbMgr.CreateStringFieldEntry(_obj.DatabaseVersion);
            fields["DefaultCustomerCreditLimit"]=DbMgr.CreateDoubleFieldEntry(_obj.DefaultCustomerCreditLimit);
            fields["DefaultCustomerFreightTaxCodeID"]=DbMgr.CreateIntFieldEntry(_obj.DefaultCustomerFreightTaxCodeID);
            fields["DefaultCustomerPriceLevelID"]=DbMgr.CreateStringFieldEntry(_obj.DefaultCustomerPriceLevelID);
            fields["DefaultCustomerTaxCodeID"]=DbMgr.CreateIntFieldEntry(_obj.DefaultCustomerTaxCodeID);
            fields["DefaultCustomerTermsID"]=DbMgr.CreateIntFieldEntry(_obj.DefaultCustomerTermsID);
            fields["DefaultSupplierCreditLimit"]=DbMgr.CreateDoubleFieldEntry(_obj.DefaultSupplierCreditLimit);
            fields["DefaultSupplierFreightTaxCodeID"]=DbMgr.CreateIntFieldEntry(_obj.DefaultSupplierFreightTaxCodeID);
            fields["DefaultSupplierTaxCodeID"]=DbMgr.CreateIntFieldEntry(_obj.DefaultSupplierTaxCodeID);
            fields["DefaultSupplierTermsID"]=DbMgr.CreateIntFieldEntry(_obj.DefaultSupplierTermsID);
            fields["DefaultUseCustomerTaxCode"]=DbMgr.CreateStringFieldEntry(_obj.DefaultUseCustomerTaxCode);
            fields["DefaultUseSupplierTaxCode"]=DbMgr.CreateStringFieldEntry(_obj.DefaultUseSupplierTaxCode);
            fields["DriverBuildNumber"]=DbMgr.CreateIntFieldEntry(_obj.DriverBuildNumber);
            fields["Email"] = DbMgr.CreateStringFieldEntry(_obj.Email);
            fields["FirstAgeingPeriod"]=DbMgr.CreateIntFieldEntry(_obj.FirstAgeingPeriod);
            fields["FaxNumber"] = DbMgr.CreateStringFieldEntry(_obj.FaxNumber);
            fields["GSTRegistrationNumber"] = DbMgr.CreateStringFieldEntry(_obj.GSTRegistrationNumber);
            fields["ID"]=DbMgr.CreateIntFieldEntry(_obj.ID);
            fields["IdentifyAgeByName"]=DbMgr.CreateStringFieldEntry(_obj.IdentifyAgeByName);
            fields["IncludeInvoiceNumber"]=DbMgr.CreateStringFieldEntry(_obj.IncludeInvoiceNumber);
            fields["IncludeInvoiceOrderNumber"]=DbMgr.CreateStringFieldEntry(_obj.IncludeInvoiceOrderNumber);
            fields["IncludeInvoiceQuoteNumber"]=DbMgr.CreateStringFieldEntry(_obj.IncludeInvoiceQuoteNumber);
            fields["IncludePurchaseNumber"]=DbMgr.CreateStringFieldEntry(_obj.IncludePurchaseNumber);
            fields["IncludePurchaseOrderNumber"]=DbMgr.CreateStringFieldEntry(_obj.IncludePurchaseOrderNumber);
            fields["InvoiceMessage"]=DbMgr.CreateStringFieldEntry(_obj.InvoiceMessage);
            fields["InvoiceOrderMessage"]=DbMgr.CreateStringFieldEntry(_obj.InvoiceOrderMessage);
            fields["InvoiceOrderSubject"]=DbMgr.CreateStringFieldEntry(_obj.InvoiceOrderSubject);
            fields["InvoiceQuoteMessage"]=DbMgr.CreateStringFieldEntry(_obj.InvoiceQuoteMessage);
            fields["InvoiceQuoteSubject"]=DbMgr.CreateStringFieldEntry(_obj.InvoiceQuoteSubject);
            fields["InvoiceSubject"]=DbMgr.CreateStringFieldEntry(_obj.InvoiceSubject);
            fields["IsSelfBalancing"]=DbMgr.CreateStringFieldEntry(_obj.IsSelfBalancing);
            fields["LastBackupDate"]=DbMgr.CreateDateTimeFieldEntry(_obj.LastBackupDate);
            fields["LastMonthInFinancialYear"]=DbMgr.CreateIntFieldEntry(_obj.LastMonthInFinancialYear);
            fields["LastPurgeDate"]=DbMgr.CreateDateTimeFieldEntry(_obj.LastPurgeDate);
            fields["LimitTypeID"]=DbMgr.CreateStringFieldEntry(_obj.LimitTypeID);
            fields["LockPeriodDate"]=DbMgr.CreateDateTimeFieldEntry(_obj.LockPeriodDate);
            fields["LockPeriodIsActive"]=DbMgr.CreateStringFieldEntry(_obj.LockPeriodIsActive);
            fields["LockThirteenthPeriod"]=DbMgr.CreateStringFieldEntry(_obj.LockThirteenthPeriod);
            fields["PayeeNumber"]=DbMgr.CreateStringFieldEntry(_obj.PayeeNumber);
            fields["Phone1"] = DbMgr.CreateStringFieldEntry(_obj.Phone1);
            fields["Phone2"] = DbMgr.CreateStringFieldEntry(_obj.Phone2);
            fields["PostCode"] = DbMgr.CreateStringFieldEntry(_obj.PostCode);
            fields["Province"] = DbMgr.CreateStringFieldEntry(_obj.Province);
            fields["PaymentMessage"]=DbMgr.CreateStringFieldEntry(_obj.PaymentMessage);
            fields["PaymentSubject"]=DbMgr.CreateStringFieldEntry(_obj.PaymentSubject);
            fields["PeriodsPerYear"]=DbMgr.CreateIntFieldEntry(_obj.PeriodsPerYear);
            fields["PurchaseMessage"]=DbMgr.CreateStringFieldEntry(_obj.PurchaseMessage);
            fields["PurchaseOrderMessage"]=DbMgr.CreateStringFieldEntry(_obj.PurchaseOrderMessage);
            fields["PurchaseQuoteSubject"]=DbMgr.CreateStringFieldEntry(_obj.PurchaseQuoteSubject);
            fields["PurchaseSubject"]=DbMgr.CreateStringFieldEntry(_obj.PurchaseSubject);
            fields["SalesTaxNumber"]=DbMgr.CreateStringFieldEntry(_obj.SalesTaxNumber);
            fields["SecondAgeingPeriod"]=DbMgr.CreateIntFieldEntry(_obj.SecondAgeingPeriod);
            fields["SerialNumber"]=DbMgr.CreateStringFieldEntry(_obj.SerialNumber);
            fields["SimplifiedTaxSystemDate"]=DbMgr.CreateDateTimeFieldEntry(_obj.SimplifiedTaxSystemDate);
            fields["StatementCode"] = DbMgr.CreateStringFieldEntry(_obj.StatementCode);
            fields["StatementMessage"]=DbMgr.CreateStringFieldEntry(_obj.StatementMessage);
            fields["StatementParticulars"]=DbMgr.CreateStringFieldEntry(_obj.StatementParticulars);
            fields["StatementReference"] = DbMgr.CreateStringFieldEntry(_obj.StatementReference);
            fields["StatementSubject"]=DbMgr.CreateStringFieldEntry(_obj.StatementSubject);
            fields["ThirdAgeingPeriod"] = DbMgr.CreateIntFieldEntry(_obj.ThirdAgeingPeriod);
            fields["UseAuditTracking"]=DbMgr.CreateStringFieldEntry(_obj.UseAuditTracking);
            fields["UseCostCentres"]=DbMgr.CreateStringFieldEntry(_obj.UseCostCentres);
            fields["UseCreditLimitWarning"]=DbMgr.CreateStringFieldEntry(_obj.UseCreditLimitWarning);
            fields["UseDailyAgeing"]=DbMgr.CreateStringFieldEntry(_obj.UseDailyAgeing);
            fields["UseMultipleCurrencies"]=DbMgr.CreateStringFieldEntry(_obj.UseMultipleCurrencies);
            fields["UsePayablesDeposits"]=DbMgr.CreateStringFieldEntry(_obj.UsePayablesDeposits);
            fields["UsePayablesDiscounts"]=DbMgr.CreateStringFieldEntry(_obj.UsePayablesDiscounts);
            fields["UsePayablesFreight"]=DbMgr.CreateStringFieldEntry(_obj.UsePayablesFreight);
            fields["UsePayablesInventory"]=DbMgr.CreateStringFieldEntry(_obj.UsePayablesInventory);
            fields["UsePayablesLateFees"]=DbMgr.CreateStringFieldEntry(_obj.UsePayablesLateFees);
            fields["UseReceivablesDeposits"]=DbMgr.CreateStringFieldEntry(_obj.UseReceivablesDeposits);
            fields["UseReceivablesDiscounts"]=DbMgr.CreateStringFieldEntry(_obj.UseReceivablesDiscounts);
            fields["UseReceivablesFreight"]=DbMgr.CreateStringFieldEntry(_obj.UseReceivablesFreight);
            fields["UseReceivablesLateFees"]=DbMgr.CreateStringFieldEntry(_obj.UseReceivablesLateFees);
            fields["UseRetailManagerLink"]=DbMgr.CreateStringFieldEntry(_obj.UseRetailManagerLink);
            //fields["UseSimplifiedTaxSystem"]=DbMgr.CreateStringFieldEntry(_obj.UseSimplifiedTaxSystem);
            fields["UseStandardCost"]=DbMgr.CreateStringFieldEntry(_obj.UseStandardCost);
            fields["WebSite"] = DbMgr.CreateStringFieldEntry(_obj.WebSite);
            
            return fields;
        }
    }
}
