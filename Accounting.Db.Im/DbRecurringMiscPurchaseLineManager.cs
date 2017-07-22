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
    public class DbRecurringMiscPurchaseLineManager : RecurringMiscPurchaseLineManager
    {
        public DbRecurringMiscPurchaseLineManager(DbManager mgr)
            : base(mgr)
        {
          
        }



        protected override void CreateTableCommands() //RecurringMiscPurchaseLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringMiscPurchaseLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
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
            foreignKeys["AccountID"] = "Accounts(AccountID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)"               
             * */

            TableCommands["RecurringMiscPurchaseLines"] = DbMgr.CreateTableCommand("RecurringMiscPurchaseLines", fields, "RecurringMiscPurchaseLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(RecurringMiscPurchaseLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            
            return DbMgr.CreateInsertClause("RecurringMiscPurchaseLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(RecurringMiscPurchaseLine _obj)
        {
            return DbMgr.CreateUpdateClause("RecurringMiscPurchaseLines", GetFields(_obj), "RecurringMiscPurchaseLineID", _obj.RecurringMiscPurchaseLineID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(RecurringMiscPurchaseLine _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("RecurringMiscPurchaseLines").Criteria.IsEqual("RecurringMiscPurchaseLines", "RecurringMiscPurchaseLineID", _obj.RecurringMiscPurchaseLineID);
            
            return clause;
        }

        protected override OpResult _Store(RecurringMiscPurchaseLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringMiscPurchaseLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.RecurringMiscPurchaseLineID == null)
            {
                _obj.RecurringMiscPurchaseLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(RecurringMiscPurchaseLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringMiscPurchaseLine object cannot be deleted as it is null");
            }
            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj); ;
            }
            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "RecurringMiscPurchaseLine object cannot be deleted as it does not exist") ;
        }
    }
}
