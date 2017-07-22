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
    public sealed class DbRecurringSaleManager : RecurringSaleManager
    {
        public DbRecurringSaleManager(DbManager mgr)
            : base(mgr)
        {
            
        }


        protected override void CreateTableCommands() //RecurringSales()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringSaleID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ShipToAddress"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["ShipToAddressLine1"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["ShipToAddressLine2"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["ShipToAddressLine3"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["ShipToAddressLine4"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["InvoiceTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["InvoiceStatusID"] = DbManager.FIELDTYPE.VARCHAR_2;
            fields["TermsID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxExclusiveFreight"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveFreight"] = DbManager.FIELDTYPE.DOUBLE;
            fields["FreightTaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["SalesPersonID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["Comment"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["ShippingMethodID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ReferralSourceID"] = DbManager.FIELDTYPE.INTEGER;
            fields["IsTaxInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["InvoiceDeliveryID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CategoryID"] = DbManager.FIELDTYPE.INTEGER;
            fields["RecurringName"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["FrequencyID"] = DbManager.FIELDTYPE.VARCHAR_2;
            fields["StartingOn"] = DbManager.FIELDTYPE.DATETIME;
            fields["NextDue"] = DbManager.FIELDTYPE.DATETIME;
            fields["RepeatedOn"] = DbManager.FIELDTYPE.DATETIME;
            fields["ScheduleID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["ContinueUntil"] = DbManager.FIELDTYPE.DATETIME;
            fields["PerformTimes"] = DbManager.FIELDTYPE.INTEGER;
            fields["RemainingTime"] = DbManager.FIELDTYPE.INTEGER;
            fields["AlertID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["AlertUserID"] = DbManager.FIELDTYPE.INTEGER;
            fields["AlertTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["DaysInAdvance"] = DbManager.FIELDTYPE.INTEGER;
            fields["NumberingTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["AppliedNumber"] = DbManager.FIELDTYPE.VARCHAR_8;
            fields["RetainChanges"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["LastPosted"] = DbManager.FIELDTYPE.DATETIME;
            /*
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["InvoiceTypeID"] = "InvoiceType(InvoiceTypeID)";
            foreignKeys["InvoiceStatusID"] = "Status(InvoiceStatusID)";
            foreignKeys["TermsID"] = "Terms(TermsID)";
            foreignKeys["FreightTaxCodeID"] = "TaxCodes(FreightTaxCodeID)";                        
            foreignKeys["SalesPersonID"] = "Cards(SalesPersonID)";
            foreignKeys["ShippingMethodID"] = "Methods(ShippingMethodID)";
            foreignKeys["ReferralSourceID"] = "ReferralSources(ReferralSourceID)";
            foreignKeys["InvoiceDeliveryID"] = "InvoiceDelivery(InvoiceDeliveryID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CategoryID"] = "Categories(CategoryID)";                        
            foreignKeys["FrequencyID"] = "Frequencies(FrequencyID)";
            foreignKeys["ScheduleID"] = "Schedule(ScheduleID)";
            foreignKeys["AlertID"] = "Alerts(AlertID)";
            foreignKeys["AlertUserID"] = "Users(AlertUserID)";
            foreignKeys["AlertTypeID"] = "AlertTypes(AlertTypeID)";
            foreignKeys["NumberingTypeID"] = "NumberingTypes(NumberingTypeID)";                                 
             * */

            TableCommands["RecurringSales"] = DbMgr.CreateTableCommand("RecurringSales", fields, "RecurringSaleID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(RecurringSale _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            
            return DbMgr.CreateInsertClause("RecurringSales", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(RecurringSale _obj)
        {
            return DbMgr.CreateUpdateClause("RecurringSales", GetFields(_obj), "RecurringSaleID", _obj.RecurringSaleID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(RecurringSale _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("RecurringSales").Criteria.IsEqual("RecurringSales", "RecurringSaleID", _obj.RecurringSaleID);
            
            return clause;
        }

        private void StoreLines(RecurringSale _obj)
        {
           
        }

        private void DeleteLines(RecurringSale _obj)
        {
           
        }

        protected override OpResult _Store(RecurringSale _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringSale object cannot be created as it is null");
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
            if (_obj.RecurringSaleID == null)
            {
                _obj.RecurringSaleID = DbMgr.GetLastInsertID();
            }

            DeleteLines(_obj);
            StoreLines(_obj);

            RepositoryMgr.MiscNumberMgr.SaveInvoiceNumber(_obj.InvoiceNumber);
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(RecurringSale _obj)
        {
            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                DeleteLines(_obj);

                RepositoryMgr.MiscNumberMgr.DeleteInvoiceNumber(_obj.InvoiceNumber);
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }
            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "RecurringSale object cannot be deleted as it does not exist") ;
        }
    }
}
