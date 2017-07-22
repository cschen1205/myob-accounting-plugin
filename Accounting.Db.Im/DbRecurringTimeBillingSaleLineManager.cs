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
    public sealed class DbRecurringTimeBillingSaleLineManager : RecurringTimeBillingSaleLineManager
    {
        public DbRecurringTimeBillingSaleLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //RecurringTimeBillingSaleLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringTimeBillingSaleLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["RecurringSaleLineID"] = DbManager.FIELDTYPE.INTEGER;
            fields["RecurringSaleID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["LineDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["HoursUnits"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ActivityID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LocationID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxExclusiveRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxExclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineMemo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxBasisAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxBasisAmountIsInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            /*
            foreignKeys["RecurringSaleLineID"] = "RecurringSaleLines(RecurringSaleLineID)";
            foreignKeys["RecurringSaleID"] = "RecurringSales(RecurringSaleID)";          
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";   
            foreignKeys["ActivityID"] = "Activity(ActivityID)";
            foreignKeys["LocationID"] = "Locations(LocationID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";           
             * */

            TableCommands["RecurringTimeBillingSaleLine"] = DbMgr.CreateTableCommand("RecurringTimeBillingSaleLine", fields, "RecurringTimeBillingSaleLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(RecurringTimeBillingSaleLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("RecurringTimeBillingSaleLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(RecurringTimeBillingSaleLine _obj)
        {
            return DbMgr.CreateUpdateClause("RecurringTimeBillingSaleLines", GetFields(_obj), "RecurringTimeBillingSaleLineID", _obj.RecurringTimeBillingSaleLineID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(RecurringTimeBillingSaleLine _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("RecurringTimeBillingSaleLines").Criteria.IsEqual("RecurringTimeBillingSaleLines", "RecurringTimeBillingSaleLineID", _obj.RecurringTimeBillingSaleLineID);
            
            return clause;
        }

       

        protected override OpResult _Store(RecurringTimeBillingSaleLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringTimeBillingSaleLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.RecurringTimeBillingSaleLineID == null)
            {
                _obj.RecurringTimeBillingSaleLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(RecurringTimeBillingSaleLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringTimeBillingSaleLine object cannot be deleted as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }

            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "RecurringTimeBillingSaleLine object cannot be deleted as it does not exist");
        }

    }
}
