using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Im
{
    using Accounting.Core;
    using Accounting.Core.Transactions;
    using Accounting.Db;
    using Accounting.Db.Elements;

    public class DbRecurringMoneySpentLineManager : RecurringMoneySpentLineManager
    {
        public DbRecurringMoneySpentLineManager(DbManager mgr)
            : base(mgr)
        {

        }


        protected override void CreateTableCommands() //RecurringMoneySpentLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringMoneySpentLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["RecurringMoneySpentID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxExclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineMemo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            /*
            foreignKeys["RecurringMoneySpentID"] = "RecurringMoneySpent(RecurringMoneySpentID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";          
            * */

            TableCommands["RecurringMoneySpentLines"] = DbMgr.CreateTableCommand("RecurringMoneySpentLines", fields, "RecurringMoneySpentLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(RecurringMoneySpentLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("RecurringMoneySpentLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(RecurringMoneySpentLine _obj)
        {
            return DbMgr.CreateUpdateClause("RecurringMoneySpentLines", GetFields(_obj), "RecurringMoneySpentLineID", _obj.RecurringMoneySpentLineID);
        }

        protected override OpResult _Store(RecurringMoneySpentLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringMoneySpentLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.RecurringMoneySpentLineID == null)
            {
                _obj.RecurringMoneySpentLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
