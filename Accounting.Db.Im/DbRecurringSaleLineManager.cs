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
    public sealed class DbRecurringSaleLineManager : RecurringSaleLineManager
    {
        public DbRecurringSaleLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //RecurringSaleLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringSaleLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["RecurringSaleID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["TaxExclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineMemo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxBasisAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxBasisAmountIsInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;

            /*
            foreignKeys["RecurringSaleID"] = "RecurringSales(RecurringSaleID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";                 
             * */

            TableCommands["RecurringSaleLines"] = DbMgr.CreateTableCommand("RecurringSaleLines", fields, "RecurringSaleLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(RecurringSaleLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            
            DbInsertStatement clause = DbMgr.CreateInsertClause();
            clause
                .InsertColumns(fields)
                .Into("RecurringSaleLines");

            return clause;
        }

        private DbUpdateStatement GetQuery_UpdateQuery(RecurringSaleLine _obj)
        {
            DbUpdateStatement clause = DbMgr.CreateUpdateClause();
            clause
                .UpdateColumns(GetFields(_obj))
                .From("RecurringSaleLines")
                .Criteria
                    .IsEqual("RecurringSaleLines", "RecurringSaleLineID", _obj.RecurringSaleLineID);
            return clause;
        }

        private DbDeleteStatement GetQuery_DeleteQuery(RecurringSaleLine _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause
                .DeleteFrom("RecurringSaleLines")
                .Criteria
                    .IsEqual("RecurringSaleLines", "RecurringSaleLineID", _obj.RecurringSaleLineID);
            return clause;
        }

       

        protected override OpResult _Store(RecurringSaleLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringSaleLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.RecurringSaleLineID == null)
            {
                _obj.RecurringSaleLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(RecurringSaleLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringSaleLine object cannot be deleted as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }

            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "RecurringSaleLine object cannot be deleted as it is null");
        }
    }
}
