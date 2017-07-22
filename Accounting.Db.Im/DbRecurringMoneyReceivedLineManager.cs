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

    public class DbRecurringMoneyReceivedLineManager : RecurringMoneyReceivedLineManager
    {
        public DbRecurringMoneyReceivedLineManager(DbManager mgr)
            : base(mgr)
        {

        }



        protected override void CreateTableCommands() //RecurringMoneyReceivedLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringMoneyReceivedLines"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["RecurringMoneyReceivedID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxExclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineMemo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["RecurringMoneyReceivedID"] = "RecurringMoneyReceived(RecurringMoneyReceivedID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";                  
             * */

            TableCommands["RecurringMoneyReceivedLines"] = DbMgr.CreateTableCommand("RecurringMoneyReceivedLines", fields, "RecurringMoneyReceivedLines", foreignKeys);
        }

        

        private DbInsertStatement GetQuery_InsertQuery(RecurringMoneyReceivedLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("RecurringMoneyReceivedLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(RecurringMoneyReceivedLine _obj)
        {
            return DbMgr.CreateUpdateClause("RecurringMoneyReceivedLines", GetFields(_obj), "RecurringMoneyReceivedLineID", _obj.RecurringMoneyReceivedLineID);
        }

        protected override OpResult _Store(RecurringMoneyReceivedLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringMoneyReceivedLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.RecurringMoneyReceivedLineID == null)
            {
                _obj.RecurringMoneyReceivedLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj) ;
        }
    }
}
