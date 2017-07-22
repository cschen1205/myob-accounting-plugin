using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Transactions;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbPaySuperannuationLineManager : PaySuperannuationLineManager
    {
        public DbPaySuperannuationLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }


        protected override void CreateTableCommands() //PaySuperannuationLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["PaySuperannuationLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["PaySuperannuationID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["SourceLineID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["SuperannuationFundID"] = DbManager.FIELDTYPE.INTEGER;
            fields["AmountPaid"] = DbManager.FIELDTYPE.DOUBLE;
            fields["PaymentStatusID"] = DbManager.FIELDTYPE.VARCHAR_1;

            TableCommands["PaySuperannuationLines"] = DbMgr.CreateTableCommand("PaySuperannuationLines", fields, "PaySuperannuationLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(PaySuperannuationLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("PaySuperannuationLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(PaySuperannuationLine _obj)
        {
            return DbMgr.CreateUpdateClause("PaySuperannuationLines", GetFields(_obj), "PaySuperannuationLineID", _obj.PaySuperannuationLineID);
        }

        protected override OpResult _Store(PaySuperannuationLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "PaySuperannuationLine object cannot be created as it is null");
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
