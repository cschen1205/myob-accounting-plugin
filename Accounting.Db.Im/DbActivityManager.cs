using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Activities;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbActivityManager : ActivityManager
    {
        public DbActivityManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ActivityID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["IsInactive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["ActivityName"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["ActivityNumber"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["IncomeAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["IsHourly"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IsChargeable"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["BillingRateUsedID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["ActivityDescription"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["UseDescription"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["ActivityRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["SellUnitMeasure"] = DbManager.FIELDTYPE.VARCHAR_5;
            fields["ChangeControl"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["BillingRateUsedID"] = "BillingRateUsed(BillingRateUsedID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
            foreignKeys["IncomeAccountID"] = "Accounts(IncomeAccountID)";
         
             * */

            TableCommands["Activities"] = DbMgr.CreateTableCommand("Activities", fields, "ActivityID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(Activity _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("Activities", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(Activity _obj)
        {
            return DbMgr.CreateUpdateClause("Activities", GetFields(_obj), "ActivityID", _obj.ActivityID);
        }

        protected override OpResult _Store(Activity _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Activity object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));

            if (_obj.ActivityID == null)
            {
                _obj.ActivityID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }

    
}
