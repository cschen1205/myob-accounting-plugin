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
    public sealed class DbRecurringPurchaseLineManager : RecurringPurchaseLineManager
    {
        public DbRecurringPurchaseLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //RecurringPurchaseLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringPurchaseLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["RecurringPurchaseID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["TaxExclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxBasisAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxBasisAmountIsInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;

            /*
            foreignKeys["RecurringPurchasesID"] = "RecurringPurchases(RecurringPurchasesID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";                        
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";           
             * */

            TableCommands["RecurringPurchaseLines"] = DbMgr.CreateTableCommand("RecurringPurchaseLines", fields, "RecurringPurchaseLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(RecurringPurchaseLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            
            DbInsertStatement clause = DbMgr.CreateInsertClause();
            clause
                .InsertColumns(fields)
                .Into("RecurringPurchaseLines");

            return clause;
        }

        private DbUpdateStatement GetQuery_UpdateQuery(RecurringPurchaseLine _obj)
        {
            DbUpdateStatement clause = DbMgr.CreateUpdateClause();
            clause
                .UpdateColumns(GetFields(_obj))
                .From("RecurringPurchaseLines")
                .Criteria
                    .IsEqual("RecurringPurchaseLines", "RecurringPurchaseLineID", _obj.RecurringPurchaseLineID);
            return clause;
        }

        private DbDeleteStatement GetQuery_DeleteQuery(RecurringPurchaseLine _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause
                .DeleteFrom("RecurringPurchaseLines")
                .Criteria
                    .IsEqual("RecurringPurchaseLines", "RecurringPurchaseLineID", _obj.RecurringPurchaseLineID);
            return clause;
        }

       

        protected override OpResult _Store(RecurringPurchaseLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringPurchaseLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.RecurringPurchaseLineID == null)
            {
                _obj.RecurringPurchaseLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(RecurringPurchaseLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringPurchaseLine object cannot be deleted as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }

            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "RecurringPurchaseLine object cannot be deleted as it does not exist");
        }
    }
}
