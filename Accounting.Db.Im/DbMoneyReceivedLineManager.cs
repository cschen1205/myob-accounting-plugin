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

    public class DbMoneyReceivedLineManager : MoneyReceivedLineManager
    {
        public DbMoneyReceivedLineManager(DbManager mgr)
            : base(mgr)
        {

        }

        

        protected override void CreateTableCommands() //MoneyReceivedLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["MoneyReceivedLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["MoneyReceivedID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxExclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["IsMultipleJob"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineMemo"] = DbManager.FIELDTYPE.VARCHAR_255;

            /*
              foreignKeys["MoneyReceivedID"] = "MoneyReceived(MoneyReceivedID)";
              foreignKeys["AccountID"] = "Accounts(AccountID)";
              foreignKeys["JobID"] = "Jobs(JobID)";
              foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
           * */

            TableCommands["MoneyReceivedLines"] = DbMgr.CreateTableCommand("MoneyReceivedLines", fields, "MoneyReceivedLineID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(MoneyReceivedLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("MoneyReceivedLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(MoneyReceivedLine _obj)
        {
            return DbMgr.CreateUpdateClause("MoneyReceivedLines", GetFields(_obj), "MoneyReceivedLineID", _obj.MoneyReceivedLineID);
        }

        protected override OpResult _Store(MoneyReceivedLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "MoneyReceiveLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.MoneyReceivedLineID == null)
            {
                _obj.MoneyReceivedLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
