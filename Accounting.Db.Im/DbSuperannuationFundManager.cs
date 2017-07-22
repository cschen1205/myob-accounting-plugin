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
    public class DbSuperannuationFundManager : SuperannuationFundManager
    {
        public DbSuperannuationFundManager(DbManager mgr)
            : base(mgr)
        {
            
        }





        protected override void CreateTableCommands() //SuperannuationFunds()
        {
            //create table: Cards
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["SuperannuationFundID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["SuperannuationFundName"] = DbManager.FIELDTYPE.VARCHAR_76;
            fields["EmployerMembershipNumber"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["IsPaid"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["SuperannuationFundToPay"] = DbManager.FIELDTYPE.VARCHAR_76;
            fields["SuperannuationFundNumber"] = DbManager.FIELDTYPE.VARCHAR_9;

            TableCommands["SuperannuationFunds"] = DbMgr.CreateTableCommand("SuperannuationFunds", fields, "SuperannuationFundID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(SuperannuationFund _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("SuperannuationFunds", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(SuperannuationFund _obj)
        {
            return DbMgr.CreateUpdateClause("SuperannuationFunds", GetFields(_obj), "SuperannuationFundID", _obj.SuperannuationFundID);
        }

        protected override OpResult _Store(SuperannuationFund _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "SuperannuationFund object cannot be created as it is null");
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
