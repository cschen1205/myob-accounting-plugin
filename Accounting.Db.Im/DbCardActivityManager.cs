using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Im
{
    using Accounting.Core;
    using Accounting.Core.Cards;
    using Accounting.Db;
    using Accounting.Db.Elements;

    public class DbCardActivityManager : CardActivityManager
    {
        public DbCardActivityManager(DbManager mgr)
            : base(mgr)
        {

        }


        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["CardActivityID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["FinancialYear"] = DbManager.FIELDTYPE.INTEGER;
            fields["Period"] = DbManager.FIELDTYPE.INTEGER;
            fields["DollarsSold"] = DbManager.FIELDTYPE.DOUBLE;

            /*
            foreignKeys["CardRecordID"]="Cards(CardRecordID)";
            //foreignKeys["CardRecordID"]="Customers(CardRecordID)";
            //foreignKeys["CardRecordID"]="Suppliers(CardRecordID)";
            //foreignKeys["CardRecordID"]="Employees(CardRecordID)";
            //foreignKeys["CardRecordID"] = "PersonalCards(CardRecordID)";
             * */

            TableCommands["CardActivities"] = DbMgr.CreateTableCommand("CardActivities", fields, "CardActivityID", foreignKeys);
        }
        private DbInsertStatement GetQuery_InsertQuery(CardActivity _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("CardActivities", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(CardActivity _obj)
        {
            return DbMgr.CreateUpdateClause("CardActivities", GetFields(_obj), "CardActivityID", _obj.CardActivityID);
        }

        protected override OpResult _Store(CardActivity _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "CardActivity object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.CardActivityID == null)
            {
                _obj.CardActivityID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
