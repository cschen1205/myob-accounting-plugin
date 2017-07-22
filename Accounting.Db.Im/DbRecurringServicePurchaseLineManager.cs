using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Purchases;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbRecurringServicePurchaseLineManager : RecurringServicePurchaseLineManager
    {
        public DbRecurringServicePurchaseLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //RecurringServicePurchaseLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringServicePurchaseLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["RecurringPurchaseLineID"] = DbManager.FIELDTYPE.INTEGER;
            fields["RecurringPurchaseID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxExclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxBasisAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxBasisAmountIsInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            /*
            foreignKeys["RecurringPurchaseLineID"] = "RecurringPurchaseLine(RecurringPurchaseLineID)";
            foreignKeys["RecurringPurchasesID"] = "RecurringPurchases(RecurringPurchasesID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";                        
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)"; 
            foreignKeys["AccountID"] = "Account(AccountID)";              
             * */

            TableCommands["RecurringServicePurchaseLines"] = DbMgr.CreateTableCommand("RecurringServicePurchaseLines", fields, "RecurringServicePurchaseLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(RecurringServicePurchaseLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            
            return DbMgr.CreateInsertClause("RecurringServicePurchaseLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(RecurringServicePurchaseLine _obj)
        {
            return DbMgr.CreateUpdateClause("RecurringServicePurchaseLines", GetFields(_obj), "RecurringServicePurchaseLineID", _obj.RecurringServicePurchaseLineID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(RecurringServicePurchaseLine _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("RecurringServicePurchaseLines").Criteria.IsEqual("RecurringServicePurchaseLines", "RecurringServicePurchaseLineID", _obj.RecurringServicePurchaseLineID);
            
            return clause;
        }

        
        protected override OpResult _Store(RecurringServicePurchaseLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringServicePurchaseLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));

            if (_obj.RecurringServicePurchaseLineID == null)
            {
                _obj.RecurringServicePurchaseLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(RecurringServicePurchaseLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringServicePurchaseLine object cannot be deleted as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }

            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "RecurringServicePurchaseLine object cannot be deleted as it does not exist");
        }

    }
}
