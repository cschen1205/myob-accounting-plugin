using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;

namespace Accounting.Db.Im
{
    using Accounting.Core;
    using Accounting.Core.Purchases;
    using Accounting.Db;
    using Accounting.Db.Elements;
    using Accounting.Core.Definitions;

    public sealed class DbPurchaseManager : PurchaseManager
    {
        public DbPurchaseManager(DbManager mgr)
            : base(mgr)
        {

        }


        protected override void CreateTableCommands() //Purchases()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["PurchaseID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PurchaseNumber"] = DbManager.FIELDTYPE.VARCHAR_8;
            fields["SupplierInvoiceNumber"] = DbManager.FIELDTYPE.VARCHAR_20;
            fields["IsHistorical"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["BackorderPurchaseID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["PurchaseDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["ShipToAddress"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["ShipToAddressLine1"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["ShipToAddressLine2"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["ShipToAddressLine3"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["ShipToAddressLine4"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PurchaseTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["PurchaseStatusID"] = DbManager.FIELDTYPE.VARCHAR_2;
            fields["OrderStatusID"] = DbManager.FIELDTYPE.VARCHAR_2;
            fields["ReversalLinkID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TermsID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TotalLines"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxExclusiveFreight"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveFreight"] = DbManager.FIELDTYPE.DOUBLE;
            fields["FreightTaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TotalTax"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TotalPaid"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TotalDeposits"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TotalDebits"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TotalDiscounts"] = DbManager.FIELDTYPE.DOUBLE;
            fields["OutstandingBalance"] = DbManager.FIELDTYPE.DOUBLE;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["Comment"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["ShippingMethodID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PromisedDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsPrinted"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["InvoiceDeliveryID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IsAutoRecorded"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["DaysTillPaid"] = DbManager.FIELDTYPE.INTEGER;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["IsTaxInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["TransactionExchangeRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CategoryID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LinesPurged"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["PreAuditTrail"] = DbManager.FIELDTYPE.VARCHAR_1;


            /*
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["PurchaseTypeID"] = "InvoiceType(PurchaseTypeID)";
            foreignKeys["PurchaseStatusID"] = "Status(PurchaseStatusID)";
            foreignKeys["OrderStatusID"] = "OrderStatus(OrderStatusID)";
            foreignKeys["ReversalLinkID"] = "Purchases(ReversalLinkID)";
            foreignKeys["TermsID"] = "Terms(TermsID)";                        
            foreignKeys["FreightTaxCodeID"] = "TaxCodes(FreightTaxCodeID)";
            foreignKeys["ShippingMethodID"] = "Methods(ShippingMethodID)";
            foreignKeys["InvoiceDeliveryID"] = "InvoiceDelivery(InvoiceDeliveryID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CategoryID"] = "Categories(CategoryID)";
             * */

            TableCommands["Purchases"] = DbMgr.CreateTableCommand("Purchases", fields, "PurchaseID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(Purchase _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("Purchases", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(Purchase _obj)
        {
            return DbMgr.CreateUpdateClause("Purchases", GetFields(_obj), "PurchaseID", _obj.PurchaseID);
        }

        

        private void StoreLines(Purchase _obj)
        {
            IList<PurchaseLine> lines=_obj.PurchaseLines;
            foreach (PurchaseLine line in lines)
            {
                RepositoryMgr.PurchaseLineMgr.Store(line);
                int? purchase_id=line.PurchaseID;
                int? purchase_line_id = line.PurchaseLineID;
                if (line is ItemPurchaseLine)
                {
                    ItemPurchaseLine _line = line as ItemPurchaseLine;
                    _line.PurchaseID = purchase_id;
                    _line.ItemPurchaseLineID = purchase_line_id;
                    RepositoryMgr.ItemPurchaseLineMgr.Store(_line);
                }
                else if (line is MiscPurchaseLine)
                {
                    MiscPurchaseLine _line = line as MiscPurchaseLine;
                    _line.PurchaseID = purchase_id;
                    _line.MiscPurchaseLineID = purchase_line_id;
                    RepositoryMgr.MiscPurchaseLineMgr.Store(_line);
                }
                else if (line is ProfessionalPurchaseLine)
                {
                    ProfessionalPurchaseLine _line = line as ProfessionalPurchaseLine;
                    _line.PurchaseID = purchase_id;
                    _line.ProfessionalPurchaseLineID = purchase_line_id;
                    RepositoryMgr.ProfessionalPurchaseLineMgr.Store(_line);
                }
                else if (line is ServicePurchaseLine)
                {
                    ServicePurchaseLine _line = line as ServicePurchaseLine;
                    _line.PurchaseID = purchase_id;
                    _line.ServicePurchaseLineID = purchase_line_id;
                    RepositoryMgr.ServicePurchaseLineMgr.Store(_line);
                }
                else if (line is TimeBillingPurchaseLine)
                {
                    TimeBillingPurchaseLine _line = line as TimeBillingPurchaseLine;
                    _line.PurchaseID = purchase_id;
                    _line.TimeBillingPurchaseLineID = purchase_line_id;
                    RepositoryMgr.TimeBillingPurchaseLineMgr.Store(_line);
                }
            }            
        }

        private void DeleteLines(Purchase _obj)
        {
            RepositoryMgr.ProfessionalPurchaseLineMgr.DeleteCollectionByPurchaseID(_obj.PurchaseID);
            RepositoryMgr.MiscPurchaseLineMgr.DeleteCollectionByPurchaseID(_obj.PurchaseID);
            RepositoryMgr.TimeBillingPurchaseLineMgr.DeleteCollectionByPurchaseID(_obj.PurchaseID);
            RepositoryMgr.ServicePurchaseLineMgr.DeleteCollectionByPurchaseID(_obj.PurchaseID);
            RepositoryMgr.ItemPurchaseLineMgr.DeleteCollectionByPurchaseID(_obj.PurchaseID);
            RepositoryMgr.PurchaseLineMgr.DeleteCollectionByPurchaseID(_obj.PurchaseID);

        }

        private DbDeleteStatement GetQuery_DeleteQuery(Purchase _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("Purchases").Criteria.IsEqual("Purchases", "PurchaseID", _obj.PurchaseID);

            return clause;
        }

        protected override OpResult _Store(Purchase _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "AuditTrail object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                DeleteLines(_obj);
                StoreLines(_obj);

                RepositoryMgr.MiscNumberMgr.SavePurchaseNumber(_obj.PurchaseNumber);
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.PurchaseID == null)
            {
                _obj.PurchaseID = DbMgr.GetLastInsertID();
            }

            DeleteLines(_obj);
            StoreLines(_obj);

            RepositoryMgr.MiscNumberMgr.SavePurchaseNumber(_obj.PurchaseNumber);
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(Purchase _obj)
        {
            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                DeleteLines(_obj);

                RepositoryMgr.MiscNumberMgr.DeletePurchaseNumber(_obj.PurchaseNumber);
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }
            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "Purchase object cannot be deleted as it does not exist");
        }
    }
}
