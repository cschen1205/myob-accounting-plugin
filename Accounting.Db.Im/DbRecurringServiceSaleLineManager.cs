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
    public sealed class DbRecurringServiceSaleLineManager : RecurringServiceSaleLineManager
    {
        public DbRecurringServiceSaleLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //RecurringServiceSaleLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringServiceSaleLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["RecurringSaleLineID"] = DbManager.FIELDTYPE.INTEGER;
            fields["RecurringSaleID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["TaxExclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxBasisAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxBasisAmountIsInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;

            /*
            foreignKeys["RecurringSaleLineID"] = "RecurringSaleLines(RecurringSaleLineID)";
            foreignKeys["AccountID"] = "Account(AccountID)";
            foreignKeys["RecurringSaleID"] = "RecurringSales(RecurringSaleID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";          
             * */

            TableCommands["RecurringServiceSaleLines"] = DbMgr.CreateTableCommand("RecurringServiceSaleLines", fields, "RecurringServiceSaleLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(RecurringServiceSaleLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            
            return DbMgr.CreateInsertClause("RecurringServiceSaleLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(RecurringServiceSaleLine _obj)
        {
            return DbMgr.CreateUpdateClause("RecurringServiceSaleLines", GetFields(_obj), "RecurringServiceSaleLineID", _obj.RecurringServiceSaleLineID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(RecurringServiceSaleLine _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("RecurringServiceSaleLines").Criteria.IsEqual("RecurringServiceSaleLines", "RecurringServiceSaleLineID", _obj.RecurringServiceSaleLineID);
            
            return clause;
        }

        
        protected override OpResult _Store(RecurringServiceSaleLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringServiceSaleLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));

            if (_obj.RecurringServiceSaleLineID == null)
            {
                _obj.RecurringServiceSaleLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(RecurringServiceSaleLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringServiceSaleLine object cannot be deleted as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }

            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "RecurringServiceSaleLine object cannot be deleted as it does not exist");
        }

    }
}
