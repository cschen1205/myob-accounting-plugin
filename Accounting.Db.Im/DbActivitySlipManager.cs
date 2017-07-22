using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Activities;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbActivitySlipManager : ActivitySlipManager
    {
        public DbActivitySlipManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ActivitySlipID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["ActivityID"] = DbManager.FIELDTYPE.INTEGER;
            fields["EmployeeSupplierID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CardTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CustomerID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ActivitySlipNumber"] = DbManager.FIELDTYPE.VARCHAR_8;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["ActivityDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["Units"] = DbManager.FIELDTYPE.DOUBLE;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Rate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["AlreadyBilledUnits"] = DbManager.FIELDTYPE.DOUBLE;
            fields["AlreadyBilledAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["AdjustmentUnits"] = DbManager.FIELDTYPE.DOUBLE;
            fields["AdjustmentAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["Notes"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["StartTime"] = DbManager.FIELDTYPE.VARCHAR_5;
            fields["StopTime"] = DbManager.FIELDTYPE.VARCHAR_5;
            fields["ElapsedTime"] = DbManager.FIELDTYPE.INTEGER;
            fields["SlipStatusID"] = DbManager.FIELDTYPE.VARCHAR_1;

            /*
            foreignKeys["ActivityID"] = "Activities(ActivityID)";
            foreignKeys["EmployeeSupplierID"] = "Cards(EmployeeSupplierID)";
            foreignKeys["CardTypeID"] = "CardTypes(CardTypeID)";
            foreignKeys["SlipStatusID"] = "Status(SlipStatusID)";
            foreignKeys["CustomerID"] = "Cards(CustomerID)";                        
            foreignKeys["JobID"] = "Jobs(JobID)";
        
             * */

            TableCommands["ActivitySlips"] = DbMgr.CreateTableCommand("ActivitySlips", fields, "ActivitySlipID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(ActivitySlip _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("ActivitySlips", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(ActivitySlip _obj)
        {
            return DbMgr.CreateUpdateClause("ActivitySlips", GetFields(_obj), "ActivitySlipID", _obj.ActivitySlipID);
        }

        protected override OpResult _Store(ActivitySlip _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ActivitySlip object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
