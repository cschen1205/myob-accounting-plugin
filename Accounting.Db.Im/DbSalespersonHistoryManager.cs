using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Sales;
using Accounting.Core.Cards;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbSalespersonHistoryManager : SalespersonHistoryManager
    {
        public DbSalespersonHistoryManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //SalespersonHistory()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["SalespersonHistoryID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["FinancialYear"] = DbManager.FIELDTYPE.INTEGER;
            fields["Period"] = DbManager.FIELDTYPE.INTEGER;
            fields["SoldAmount"] = DbManager.FIELDTYPE.DOUBLE;

            /*
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";         
             * */

            TableCommands["SalespersonHistory"] = DbMgr.CreateTableCommand("SalespersonHistory", fields, "SalespersonHistoryID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(SalespersonHistory _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
          
            return DbMgr.CreateInsertClause("SalespersonHistory", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(SalespersonHistory _obj)
        {
            return DbMgr.CreateUpdateClause("SalespersonHistory", GetFields(_obj), "SalespersonHistoryID", _obj.SalespersonHistoryID);
        }

        protected override OpResult _Store(SalespersonHistory _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "SalespersonHistory object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.SalespersonHistoryID == null)
            {
                _obj.SalespersonHistoryID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

       
    }



}
