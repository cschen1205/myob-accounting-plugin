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
    public sealed class DbRecurringProfessionalPurchaseLineManager : RecurringProfessionalPurchaseLineManager
    {
        public DbRecurringProfessionalPurchaseLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //RecurringProfessionalPurchaseLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringProfessionalPurchaseLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["RecurringPurchaseLineID"] = DbManager.FIELDTYPE.INTEGER;
            fields["RecurringPurchaseID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["LineDate"] = DbManager.FIELDTYPE.DATETIME;
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

            TableCommands["RecurringProfessionalPurchaseLines"] = DbMgr.CreateTableCommand("RecurringProfessionalPurchaseLines", fields, "RecurringProfessionalPurchaseLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(RecurringProfessionalPurchaseLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
           
            return DbMgr.CreateInsertClause("RecurringProfessionalPurchaseLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(RecurringProfessionalPurchaseLine _obj)
        {
            return DbMgr.CreateUpdateClause("RecurringProfessionalPurchaseLines", GetFields(_obj), "RecurringProfessionalPurchaseLineID", _obj.RecurringProfessionalPurchaseLineID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(RecurringProfessionalPurchaseLine _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("RecurringProfessionalPurchaseLines").Criteria.IsEqual("RecurringProfessionalPurchaseLines", "RecurringProfessionalPurchaseLineID", _obj.RecurringProfessionalPurchaseLineID);
            
            return clause;
        }

        

        protected override OpResult _Store(RecurringProfessionalPurchaseLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringProfessionalPurchaseLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.RecurringProfessionalPurchaseLineID == null)
            {
                _obj.RecurringProfessionalPurchaseLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(RecurringProfessionalPurchaseLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringProfessionalPurchaseLine object cannot be deleted as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }

            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "RecurringProfessionalPurchaseLine object cannot be deleted as it does not exist");
        }

    }
}
