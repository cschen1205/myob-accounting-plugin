using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Im
{
    using Accounting.Core;
    using Accounting.Core.Sales;
    using Accounting.Db;
    using Accounting.Db.Elements;

    public class DbSalesHistoryManager : SalesHistoryManager
    {
        public DbSalesHistoryManager(DbManager mgr)
            : base(mgr)
        {

        }

        protected override void CreateTableCommands() //SalesHistory()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["SalesHistoryID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["FinancialYear"] = DbManager.FIELDTYPE.INTEGER;
            fields["Period"] = DbManager.FIELDTYPE.INTEGER;
            fields["SaleAmount"] = DbManager.FIELDTYPE.DOUBLE;

            /*
                        foreignKeys["CardRecordID"] = "Cards(CardRecordID)";       
                         * */

            TableCommands["SalesHistory"] = DbMgr.CreateTableCommand("SalesHistory", fields, "SalesHistoryID", foreignKeys);
        }

       

        private DbInsertStatement GetQuery_InsertQuery(SalesHistory _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("SalesHistory", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(SalesHistory _obj)
        {
            return DbMgr.CreateUpdateClause("SalesHistory", GetFields(_obj), "SalesHistoryID", _obj.SalesHistoryID);
        }

        protected override OpResult _Store(SalesHistory _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "SalesHistory object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.SalesHistoryID == null)
            {
                _obj.SalesHistoryID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
