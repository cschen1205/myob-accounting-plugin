using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Definitions;
using Accounting.Core.Sales;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbSaleManager : SaleManager
    {
        public DbSaleManager(DbManager mgr)
            : base(mgr)
        {
            
        }


        protected override void CreateTableCommands() //Sales()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["SaleID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["InvoiceNumber"] = DbManager.FIELDTYPE.VARCHAR_8;
            fields["CustomerPONumber"] = DbManager.FIELDTYPE.VARCHAR_20;
            fields["IsHistorical"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["BackorderSaleID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["InvoiceDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["ShipToAddress"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["ShipToAddressLine1"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["ShipToAddressLine2"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["ShipToAddressLine3"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["ShipToAddressLine4"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["InvoiceTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["InvoiceStatusID"] = DbManager.FIELDTYPE.VARCHAR_2;
            fields["TermsID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TotalLines"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxExclusiveFreight"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveFreight"] = DbManager.FIELDTYPE.DOUBLE;
            fields["FreightTaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TotalTax"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TotalPaid"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TotalDeposits"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TotalCredits"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TotalDiscounts"] = DbManager.FIELDTYPE.DOUBLE;
            fields["OutstandingBalance"] = DbManager.FIELDTYPE.DOUBLE;
            fields["SalesPersonID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["Comment"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["ShippingMethodID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PromisedDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["ReferralSourceID"] = DbManager.FIELDTYPE.INTEGER;
            fields["IsAutoRecorded"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IsPrinted"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["InvoiceDeliveryID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["DaysTillPaid"] = DbManager.FIELDTYPE.INTEGER;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TransactionExchangeRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CategoryID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LinesPurged"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["PreAuditTrail"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IsTaxInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["DestinationCountry"] = DbManager.FIELDTYPE.VARCHAR_256;

            /*
            foreignKeys["CardRecordId"] = "Cards(CardRecordId)";
            foreignKeys["CardRecordId"] = "Customers(CardRecordId)";
            foreignKeys["InvoiceTypeID"] = "InvoiceType(InvoiceTypeID)";
            foreignKeys["InvoiceStatusID"] = "Status(InvoiceStatusID)";
            foreignKeys["TermsID"] = "Terms(TermsID)";
            foreignKeys["SalespersonID"] = "Cards(SalespersonID)";
            foreignKeys["SalespersonID"] = "Employees(SalespersonID)";
            foreignKeys["ReferralSourceID"] = "ReferralSources(ReferralSourceID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
            foreignKeys["InvoiceDeliveryID"] = "InvoiceDelivery(InvoiceDeliveryID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CategoryID"] = "Categories(CategoryID)";
             * */

            TableCommands["Sales"] = DbMgr.CreateTableCommand("Sales", fields, "SaleID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(Sale _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            
            return DbMgr.CreateInsertClause("Sales", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(Sale _obj)
        {
            return DbMgr.CreateUpdateClause("Sales", GetFields(_obj), "SaleID", _obj.SaleID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(Sale _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("Sales").Criteria.IsEqual("Sales", "SaleID", _obj.SaleID);
            
            return clause;
        }

        private void StoreLines(Sale _obj)
        {
            IList<SaleLine> lines = _obj.SaleLines;
            foreach (SaleLine line in lines)
            {
                RepositoryMgr.SaleLineMgr.Store(line);
                int? purchase_id = line.SaleID;
                int? purchase_line_id = line.SaleLineID;
                if (line is ItemSaleLine)
                {
                    ItemSaleLine _line = line as ItemSaleLine;
                    _line.SaleID = purchase_id;
                    _line.ItemSaleLineID = purchase_line_id;
                    RepositoryMgr.ItemSaleLineMgr.Store(_line);
                }
                else if (line is MiscSaleLine)
                {
                    MiscSaleLine _line = line as MiscSaleLine;
                    _line.SaleID = purchase_id;
                    _line.MiscSaleLineID = purchase_line_id;
                    RepositoryMgr.MiscSaleLineMgr.Store(_line);
                }
                else if (line is ProfessionalSaleLine)
                {
                    ProfessionalSaleLine _line = line as ProfessionalSaleLine;
                    _line.SaleID = purchase_id;
                    _line.ProfessionalSaleLineID = purchase_line_id;
                    RepositoryMgr.ProfessionalSaleLineMgr.Store(_line);
                }
                else if (line is ServiceSaleLine)
                {
                    ServiceSaleLine _line = line as ServiceSaleLine;
                    _line.SaleID = purchase_id;
                    _line.ServiceSaleLineID = purchase_line_id;
                    RepositoryMgr.ServiceSaleLineMgr.Store(_line);
                }
                else if (line is TimeBillingSaleLine)
                {
                    TimeBillingSaleLine _line = line as TimeBillingSaleLine;
                    _line.SaleID = purchase_id;
                    _line.TimeBillingSaleLineID = purchase_line_id;
                    RepositoryMgr.TimeBillingSaleLineMgr.Store(_line);
                }
            }
        }

        private void DeleteLines(Sale _obj)
        {
            RepositoryMgr.ProfessionalSaleLineMgr.DeleteCollectionBySaleID(_obj.SaleID);
            RepositoryMgr.MiscSaleLineMgr.DeleteCollectionBySaleID(_obj.SaleID);
            RepositoryMgr.TimeBillingSaleLineMgr.DeleteCollectionBySaleID(_obj.SaleID);
            RepositoryMgr.ServiceSaleLineMgr.DeleteCollectionBySaleID(_obj.SaleID);
            RepositoryMgr.ItemSaleLineMgr.DeleteCollectionBySaleID(_obj.SaleID);
            RepositoryMgr.SaleLineMgr.DeleteCollectionBySaleID(_obj.SaleID);

        }

        protected override OpResult _Store(Sale _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Sale object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                DeleteLines(_obj);
                StoreLines(_obj);
                

                RepositoryMgr.MiscNumberMgr.SaveInvoiceNumber(_obj.InvoiceNumber);
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.SaleID == null)
            {
                _obj.SaleID = DbMgr.GetLastInsertID();
            }

            DeleteLines(_obj);
            StoreLines(_obj);

            RepositoryMgr.MiscNumberMgr.SaveInvoiceNumber(_obj.InvoiceNumber);
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(Sale _obj)
        {
            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                DeleteLines(_obj);

                RepositoryMgr.MiscNumberMgr.DeleteInvoiceNumber(_obj.InvoiceNumber);
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }
            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "Sale object cannot be deleted as it does not exist");
        }
    }
}
