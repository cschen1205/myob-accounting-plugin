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
    public sealed class DbTimeBillingSaleLineManager : TimeBillingSaleLineManager
    {
        public DbTimeBillingSaleLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //TimeBillingSaleLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["TimeBillingSaleLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["SaleLineID"] = DbManager.FIELDTYPE.INTEGER;
            fields["SaleID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["LineDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["HoursUnits"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ActivityID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Notes"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["TaxExclusiveRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxExclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxBasisAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxBasisAmountIsInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["IsMultipleJob"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["EstimatedCost"] = DbManager.FIELDTYPE.DOUBLE;
            fields["LocationID"] = DbManager.FIELDTYPE.INTEGER;


            /*
            foreignKeys["SaleLineID"] = "SaleLines(SaleLineID)";
            foreignKeys["SaleID"] = "Sales(SaleID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";
            foreignKeys["ActivityID"] = "Activities(ActivityID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";            
            foreignKeys["LocationID"] = "Locations(LocationID)";
              * */

            TableCommands["TimeBillingSaleLines"] = DbMgr.CreateTableCommand("TimeBillingSaleLines", fields, "TimeBillingSaleLineID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(TimeBillingSaleLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("TimeBillingSaleLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(TimeBillingSaleLine _obj)
        {
            return DbMgr.CreateUpdateClause("TimeBillingSaleLines", GetFields(_obj), "TimeBillingSaleLineID", _obj.TimeBillingSaleLineID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(TimeBillingSaleLine _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("TimeBillingSaleLines").Criteria.IsEqual("TimeBillingSaleLines", "TimeBillingSaleLineID", _obj.TimeBillingSaleLineID);
            
            return clause;
        }

       

        protected override OpResult _Store(TimeBillingSaleLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "TimeBillingSaleLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.TimeBillingSaleLineID == null)
            {
                _obj.TimeBillingSaleLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(TimeBillingSaleLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "TimeBillingSaleLine object cannot be deleted as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }

            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj);
        }

    }
}
