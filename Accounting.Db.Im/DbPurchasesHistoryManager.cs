using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Im
{
    using Accounting.Core;
    using Accounting.Core.Purchases;
    using Accounting.Db;
    using Accounting.Db.Elements;

    public class DbPurchasesHistoryManager : PurchasesHistoryManager
    {
        public DbPurchasesHistoryManager(DbManager mgr)
            : base(mgr)
        {

        }

        protected override void CreateTableCommands() //PurchasesHistory()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["PurchasesHistoryID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["FinancialYear"] = DbManager.FIELDTYPE.INTEGER;
            fields["Period"] = DbManager.FIELDTYPE.INTEGER;
            fields["PurchaseAmount"] = DbManager.FIELDTYPE.DOUBLE;
            /*
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";        
             * */

            TableCommands["PurchasesHistory"] = DbMgr.CreateTableCommand("PurchasesHistory", fields, "PurchasesHistoryID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(PurchasesHistory _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("PurchasesHistory", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(PurchasesHistory _obj)
        {
            return DbMgr.CreateUpdateClause("PurchasesHistory", GetFields(_obj), "PurchasesHistoryID", _obj.PurchasesHistoryID);
        }

        protected override OpResult _Store(PurchasesHistory _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "PurchasesHistory object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.PurchasesHistoryID == null)
            {
                _obj.PurchasesHistoryID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
