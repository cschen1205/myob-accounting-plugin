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
    public class DbRecurringMiscSaleLineManager : RecurringMiscSaleLineManager
    {
        public DbRecurringMiscSaleLineManager(DbManager mgr)
            : base(mgr)
        {
          
        }


        protected override void CreateTableCommands() //RecurringMiscSaleLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringMiscSaleLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["RecurringSaleLineID"] = DbManager.FIELDTYPE.INTEGER;
            fields["RecurringSaleID"] = DbManager.FIELDTYPE.INTEGER;
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
            foreignKeys["RecurringSaleLineID"] = "RecurringSaleLines(RecurringSaleLineID)";
            foreignKeys["RecurringSaleID"] = "RecurringSales(RecurringSaleID)";          
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";                        
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";      
            foreignKeys["AccountID"] = "Account(AccountID)";              
             * */

            TableCommands["RecurringMiscSaleLines"] = DbMgr.CreateTableCommand("RecurringMiscSaleLines", fields, "RecurringMiscSaleLineID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(RecurringMiscSaleLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            
            return DbMgr.CreateInsertClause("RecurringMiscSaleLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(RecurringMiscSaleLine _obj)
        {
            return DbMgr.CreateUpdateClause("RecurringMiscSaleLines", GetFields(_obj), "RecurringMiscSaleLineID", _obj.RecurringMiscSaleLineID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(RecurringMiscSaleLine _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("RecurringMiscSaleLines").Criteria.IsEqual("RecurringMiscSaleLines", "RecurringMiscSaleLineID", _obj.RecurringMiscSaleLineID);
            
            return clause;
        }

        protected override OpResult _Store(RecurringMiscSaleLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringMiscSaleLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.RecurringMiscSaleLineID == null)
            {
                _obj.RecurringMiscSaleLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(RecurringMiscSaleLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringMiscSaleLine object cannot be deleted as it is null");
            }
            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }
            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "RecurringMiscSaleLine object cannot be deleted as it does not exist"); ;
        }
    }
}
