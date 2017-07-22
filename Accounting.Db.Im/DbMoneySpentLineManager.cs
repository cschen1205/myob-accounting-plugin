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

    public class DbMoneySpentLineManager : MoneySpentLineManager
    {
        public DbMoneySpentLineManager(DbManager mgr)
            : base(mgr)
        {

        }



        protected override void CreateTableCommands() //MoneySpentLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["MoneySpentLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["MoneySpentID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxExclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["IsMultipleJob"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineMemo"] = DbManager.FIELDTYPE.VARCHAR_255;

            /*
            foreignKeys["MoneySpentID"] = "MoneySpent(MoneySpentID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
             * */

            TableCommands["MoneySpentLines"] = DbMgr.CreateTableCommand("MoneySpentLines", fields, "MoneySpentLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(MoneySpentLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("MoneySpentLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(MoneySpentLine _obj)
        {
            return DbMgr.CreateUpdateClause("MoneySpentLines", GetFields(_obj), "MoneySpentLineID", _obj.MoneySpentLineID);
        }

        protected override OpResult _Store(MoneySpentLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "MoneySpentLine cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.MoneySpentLineID == null)
            {
                _obj.MoneySpentLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj) ;
        }
    }
}
