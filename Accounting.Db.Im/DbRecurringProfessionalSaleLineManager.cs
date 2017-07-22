using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Sales;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbRecurringProfessionalSaleLineManager : RecurringProfessionalSaleLineManager
    {
        public DbRecurringProfessionalSaleLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //RecurringProfessionalSaleLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringProfessionalSaleLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["RecurringSaleLineID"] = DbManager.FIELDTYPE.INTEGER;
            fields["RecurringSaleID"] = DbManager.FIELDTYPE.INTEGER;
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
            foreignKeys["RecurringSaleLineID"] = "RecurringSaleLines(RecurringSaleLineID)";
            foreignKeys["RecurringSaleID"] = "RecurringSales(RecurringSaleID)";          
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";                        
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";      
            foreignKeys["AccountID"] = "Account(AccountID)";         
             * */

            TableCommands["RecurringProfessionalSaleLines"] = DbMgr.CreateTableCommand("RecurringProfessionalSaleLines", fields, "RecurringProfessionalSaleLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(RecurringProfessionalSaleLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
           
            return DbMgr.CreateInsertClause("RecurringProfessionalSaleLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(RecurringProfessionalSaleLine _obj)
        {
            return DbMgr.CreateUpdateClause("RecurringProfessionalSaleLines", GetFields(_obj), "RecurringProfessionalSaleLineID", _obj.RecurringProfessionalSaleLineID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(RecurringProfessionalSaleLine _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("RecurringProfessionalSaleLines").Criteria.IsEqual("RecurringProfessionalSaleLines", "RecurringProfessionalSaleLineID", _obj.RecurringProfessionalSaleLineID);
            
            return clause;
        }

        

        protected override OpResult _Store(RecurringProfessionalSaleLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringProfessionalSaleLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.RecurringProfessionalSaleLineID == null)
            {
                _obj.RecurringProfessionalSaleLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(RecurringProfessionalSaleLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringProfessionalSaleLine object cannot be deleted as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }

            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "RecurringProfessionalSaleLine object cannot be deleted as it does not exist");
        }

    }
}
