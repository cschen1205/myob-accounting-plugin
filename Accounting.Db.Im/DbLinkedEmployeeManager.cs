using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Payroll;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbLinkedEmployeeManager : LinkedEmployeeManager
    {
        public DbLinkedEmployeeManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //LinkedEmployees()
        {
            //create table: Cards
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["LinkedEmployeeID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CategoryID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CategoryTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;

            TableCommands["LinkedEmployees"] = DbMgr.CreateTableCommand("LinkedEmployees", fields, "LinkedEmployeeID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(LinkedEmployee _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("LinkedEmployees", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(LinkedEmployee _obj)
        {
            return DbMgr.CreateUpdateClause("LinkedEmployees", GetFields(_obj), "LinkedEmployeeID", _obj.LinkedEmployeeID);
        }

        protected override OpResult _Store(LinkedEmployee _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "LinkedEmployee object cannot be created as it is null");
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
